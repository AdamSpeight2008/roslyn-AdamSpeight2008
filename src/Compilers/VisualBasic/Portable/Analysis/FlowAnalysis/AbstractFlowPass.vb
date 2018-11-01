' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System
Imports System.Collections.Generic
Imports System.Collections.Immutable
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports Microsoft.CodeAnalysis.PooledObjects
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Roslyn.Utilities
Imports System.Runtime.InteropServices
Imports Microsoft.CodeAnalysis.VisualBasic.Extensions

' NOTE: VB does not support constant expressions in flow analysis during command-line compilation, but supports them when 
'       analysis is being called via public API. This distinction is governed by 'suppressConstantExpressions' flag

Namespace Microsoft.CodeAnalysis.VisualBasic

    Partial Friend MustInherit Class AbstractFlowPass(Of LocalState As AbstractLocalState)
        Inherits BoundTreeVisitor

        ''' <summary>
        ''' The compilation in which the analysis is taking place.  This is needed to determine which
        ''' conditional methods will be compiled and which will be omitted.
        ''' </summary>
        Protected ReadOnly compilation As VisualBasicCompilation

        ''' <summary>
        ''' The symbol of method whose body is being analyzed or field or property whose 
        ''' initializer is being analyzed
        ''' </summary>
        Public symbol As Symbol

        ''' <summary>
        ''' The bound code of the method or initializer being analyzed
        ''' </summary>
        Private ReadOnly _methodOrInitializerMainNode As BoundNode

        ''' <summary>
        ''' The flow analysis state at each label, computed by merging the state from branches to
        ''' that label with the state when we fall into the label.  Entries are created when the
        ''' label is encountered.  One case deserves special attention: when the destination of the
        ''' branch is a label earlier in the code, it is possible (though rarely occurs in practice)
        ''' that we are changing the state at a label that we've already analyzed. In that case we
        ''' run another pass of the analysis to allow those changes to propagate. This repeats until
        ''' no further changes to the state of these labels occurs.  This can result in quadratic
        ''' performance in unlikely but possible code such as this: "int x; if (cond) goto l1; x =
        ''' 3; l5: print x; l4: goto l5; l3: goto l4; l2: goto l3; l1: goto l2;"
        ''' </summary>
        Private ReadOnly _labels As PooledDictionary(Of LabelSymbol, LabelStateAndNesting) = PooledDictionary(Of LabelSymbol, LabelStateAndNesting).GetInstance

        ''' <summary> All of the labels seen so far in this forward scan of the body </summary>
        Private _labelsSeen As PooledHashSet(Of LabelSymbol) = PooledHashSet(Of LabelSymbol).GetInstance

        Private _placeholderReplacementMap As PooledDictionary(Of BoundValuePlaceholderBase, BoundExpression)

        ''' <summary>
        ''' Set to true after an analysis scan if the analysis was incomplete due to a backward
        ''' "goto" branch changing some analysis result.  In this case the caller scans again (until
        ''' this is false). Since the analysis proceeds by monotonically changing the state computed
        ''' at each label, this must terminate.
        ''' </summary>
        Friend backwardBranchChanged As Boolean = False

        ''' <summary> Actual storage for PendingBranches </summary>
        Private _pendingBranches As ArrayBuilder(Of PendingBranch) = ArrayBuilder(Of PendingBranch).GetInstance()

        ''' <summary> The definite assignment and/or reachability state at the point currently being analyzed. </summary>
        Protected State As LocalState
        Protected StateWhenTrue As LocalState
        Protected StateWhenFalse As LocalState
        Protected IsConditionalState As Boolean

        ''' <summary>
        ''' 'Me' parameter, relevant for methods, fields, properties, otherwise Nothing
        ''' </summary>
        Protected ReadOnly MeParameter As ParameterSymbol

        ''' <summary>
        ''' Used only in the data flows out walker, we track unassignments as well as assignments
        ''' </summary>
        Protected ReadOnly TrackUnassignments As Boolean

        ''' <summary>
        ''' The current lexical nesting in the BoundTree. 
        ''' </summary>
        ''' <remarks></remarks>
        Private _nesting As ArrayBuilder(Of Integer)

        ''' <summary>
        ''' Where all diagnostics are deposited.
        ''' </summary>
        Protected ReadOnly diagnostics As DiagnosticBag = DiagnosticBag.GetInstance()

        ''' <summary> Indicates whether or not support of constant expressions (boolean and nothing)
        ''' is enabled in this analyzer. In general, constant expressions support is enabled in analysis
        ''' exposed to public API consumer and disabled when used from command-line compiler. </summary>
        Private ReadOnly _suppressConstantExpressions As Boolean

        Protected _recursionDepth As Integer

        ''' <summary>
        ''' Construct an object for outside-region analysis
        ''' </summary>
        Protected Sub New(_info As FlowAnalysisInfo, suppressConstExpressionsSupport As Boolean)
            MyClass.New(_info, Nothing, suppressConstExpressionsSupport, False)
        End Sub

        ''' <summary>
        ''' Construct an object for region-aware analysis
        ''' </summary>
        Protected Sub New(_info As FlowAnalysisInfo, _region As FlowAnalysisRegionInfo, suppressConstExpressionsSupport As Boolean, trackUnassignments As Boolean)

            Debug.Assert(_info.Symbol.Kind.IsAnyOf(SymbolKind.Field, SymbolKind.Property, SymbolKind.Method, SymbolKind.Parameter))

            compilation = _info.Compilation
            symbol = _info.Symbol
            MeParameter = symbol.GetMeParameter()
            _methodOrInitializerMainNode = _info.Node

            _firstInRegion = _region.FirstInRegion
            _lastInRegion = _region.LastInRegion
            Me._region = _region.Region

            Me.TrackUnassignments = trackUnassignments
            _loopHeadState = If(trackUnassignments, PooledDictionary(Of BoundLoopStatement, LocalState).GetInstance, Nothing)
            _suppressConstantExpressions = suppressConstExpressionsSupport
        End Sub

        Protected Overridable Sub InitForScan()
        End Sub

        Protected MustOverride Function ReachableState() As LocalState

        Protected MustOverride Function UnreachableState() As LocalState

        ''' <summary> Set conditional state </summary>
        Private Sub SetConditionalState(_whenTrue As LocalState, _whenFalse As LocalState)
            State = Nothing
            StateWhenTrue = _whenTrue
            StateWhenFalse = _whenFalse
            IsConditionalState = True
        End Sub

        ''' <summary> Set unconditional state </summary>
        Protected Sub SetState(_state As LocalState)
            State = _state
            If Not IsConditionalState Then Exit Sub
            StateWhenTrue = Nothing
            StateWhenFalse = Nothing
            IsConditionalState = False
        End Sub

        ''' <summary> Split state </summary>
        Protected Sub Split()
            If Not IsConditionalState Then SetConditionalState(State, State.Clone())
        End Sub

        ''' <summary> Intersect and unsplit state </summary>
        Protected Sub Unsplit()
            If Not IsConditionalState Then Exit Sub
            IntersectWith(StateWhenTrue, StateWhenFalse)
            SetState(StateWhenTrue)
        End Sub

        ''' <summary>
        ''' Pending escapes generated in the current scope (or more deeply nested scopes). When jump
        ''' statements (goto, break, continue, return) are processed, they are placed in the
        ''' Me._pendingBranches buffer to be processed later by the code handling the destination
        ''' statement. As a special case, the processing of try-finally statements might modify the
        ''' contents of the Me._pendingBranches buffer to take into account the behavior of
        ''' "intervening" finally clauses.
        ''' </summary>
        Protected ReadOnly Property PendingBranches As ImmutableArray(Of PendingBranch)
            Get
                Return _pendingBranches.ToImmutable
            End Get
        End Property

        ''' <summary>
        ''' Perform a single pass of flow analysis.  Note that after this pass,
        ''' this.backwardBranchChanged indicates if a further pass is required.
        ''' </summary>
        ''' <returns>False if the region is invalid</returns>
        Protected Overridable Function Scan() As Boolean
            ' Clear diagnostics reported in the previous iteration
            diagnostics.Clear()

            ' initialize
            _regionPlace = RegionPlace.Before
            SetState(ReachableState())
            backwardBranchChanged = False

            _nesting?.Free()
            _nesting = ArrayBuilder(Of Integer).GetInstance()

            InitForScan()

            ' pending branches should be restored after each iteration
            Dim oldPending As SavedPending = SavePending()
            Visit(_methodOrInitializerMainNode)
            RestorePending(oldPending)
            _labelsSeen.Clear()

            ' if we are tracking regions, we must have left the region by now;
            ' otherwise the region was erroneous which must have been detected earlier
            Return _firstInRegion Is Nothing OrElse Me._regionPlace = RegionPlace.After
        End Function

        ''' <returns>False if the region is invalid</returns>
        Protected Overridable Function Analyze() As Boolean
            Do
                If Not Scan() Then Return False
            Loop While backwardBranchChanged
            Return True
        End Function

        Protected Overridable Sub Free()
            _nesting?.Free()
            diagnostics?.Free()
            _pendingBranches?.Free()
            _loopHeadState?.Free()
            _labelsSeen?.Free()
            _labels?.Free()
            _placeholderReplacementMap?.Free()
        End Sub

        ''' <summary>
        ''' If analysis is being performed in a context of a method returns method's parameters, 
        ''' otherwise returns an empty array
        ''' </summary>
        Protected ReadOnly Property MethodParameters As ImmutableArray(Of ParameterSymbol)
            Get
                Return If(Me.symbol.Kind = SymbolKind.Method, DirectCast(symbol, MethodSymbol).Parameters, ImmutableArray(Of ParameterSymbol).Empty)
            End Get
        End Property

        ''' <summary>
        ''' Specifies whether or not method's ByRef parameters should be analyzed. If there's more than one location in
        ''' the method being analyzed, then the method is partial and we prefer to report an out parameter in partial
        ''' method error.
        ''' Note: VB doesn't support "out" so it doesn't warn for unassigned parameters. However, check variables passed
        ''' byref are assigned so that data flow analysis detects parameters flowing out.
        ''' </summary>
        ''' <returns>true if the out parameters of the method should be analyzed</returns>
        Protected ReadOnly Property ShouldAnalyzeByRefParameters As Boolean
            Get
                Return Me.symbol.Kind = SymbolKind.Method AndAlso DirectCast(symbol, MethodSymbol).Locations.Length = 1
            End Get
        End Property

        ''' <summary>
        ''' Method symbol or nothing
        ''' TODO: Need to try and get rid of this property
        ''' </summary>
        Protected ReadOnly Property MethodSymbol As MethodSymbol
            Get
                Return If(Me.symbol.Kind = SymbolKind.Method, DirectCast(symbol, MethodSymbol), Nothing)
            End Get
        End Property

        ''' <summary>
        ''' If analysis is being performed in a context of a method returns method's return type, 
        ''' otherwise returns Nothing
        ''' </summary>
        Protected ReadOnly Property MethodReturnType As TypeSymbol
            Get
                Return If(Me.symbol.Kind = SymbolKind.Method, DirectCast(symbol, MethodSymbol).ReturnType, Nothing)
            End Get
        End Property

        ''' <summary>
        ''' Return the flow analysis state associated with a label.
        ''' </summary>
        ''' <param name="label"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function LabelState(label As LabelSymbol) As LocalState
            Dim result As LabelStateAndNesting = Nothing
            If _labels.TryGetValue(label, result) Then
                Return result.State
            End If
            Return UnreachableState()
        End Function

        ''' <summary>
        ''' Set the current state to one that indicates that it is unreachable.
        ''' </summary>
        Protected Sub SetUnreachable()
            SetState(UnreachableState())
        End Sub

        Private Function IsConstantTrue(node As BoundExpression) As Boolean
            If _suppressConstantExpressions OrElse Not node.IsConstant Then Return False

            Dim constantValue = node.ConstantValueOpt
            If constantValue.Discriminator <> ConstantValueTypeDiscriminator.Boolean Then Return False
            Return constantValue.BooleanValue
        End Function

        Private Function IsConstantFalse(node As BoundExpression) As Boolean
            If _suppressConstantExpressions OrElse Not node.IsConstant Then Return False

            Dim constantValue = node.ConstantValueOpt
            If constantValue.Discriminator <> ConstantValueTypeDiscriminator.Boolean Then Return False
            Return Not constantValue.BooleanValue
        End Function

        Private Function IsConstantNull(node As BoundExpression) As Boolean
            If _suppressConstantExpressions OrElse Not node.IsConstant Then Return False
            Return node.ConstantValueOpt.IsNull
        End Function

        Protected Shared Function IsNonPrimitiveValueType(type As TypeSymbol) As Boolean
            Debug.Assert(type IsNot Nothing)
            If Not type.IsValueType Then Return False
            Select Case type.SpecialType
                Case SpecialType.None,
                     SpecialType.System_Nullable_T,
                     SpecialType.System_IntPtr,
                     SpecialType.System_UIntPtr
                    Return True

                Case Else
                    Return False
            End Select
        End Function

        ''' <summary>
        ''' Called at the point in a loop where the backwards branch would go to.
        ''' </summary>
        ''' <param name="node"></param>
        ''' <remarks></remarks>
        Private Sub LoopHead(node As BoundLoopStatement)
            If Not TrackUnassignments Then Exit Sub
            Dim previousState As LocalState
            If _loopHeadState.TryGetValue(node, previousState) Then IntersectWith(State, previousState)
            _loopHeadState(node) = State.Clone()
        End Sub

        ''' <summary>
        ''' Called at the point in a loop where the backward branch is placed.
        ''' </summary>
        ''' <param name="node"></param>
        ''' <remarks></remarks>
        Private Sub LoopTail(node As BoundLoopStatement)
            If Not TrackUnassignments Then Exit Sub
            Dim oldState = _loopHeadState(node)
            If Not IntersectWith(oldState, State) Then Exit Sub
            _loopHeadState(node) = oldState
            backwardBranchChanged = True
        End Sub

        ''' <summary>
        ''' Used to resolve exit statements in each statement form that has an Exit statement
        ''' (loops, switch).
        ''' </summary>
        Private Sub ResolveBreaks(breakState As LocalState, breakLabel As LabelSymbol)
            Dim newPendingBranches = ArrayBuilder(Of PendingBranch).GetInstance()
            For Each pending In PendingBranches
                Select Case pending.Branch.Kind
                    Case BoundKind.ExitStatement
                        Dim exitStmt = TryCast(pending.Branch, BoundExitStatement)

                        If exitStmt.Label = breakLabel Then
                            IntersectWith(breakState, pending.State)
                        Else
                            ' If it doesn't match then it is for an outer block
                            newPendingBranches.Add(pending)
                        End If

                    Case Else
                        newPendingBranches.Add(pending)
                End Select
            Next
            ResetPendingBranches(newPendingBranches)
            SetState(breakState)
        End Sub

        ''' <summary>
        ''' Used to resolve continue statements in each statement form that supports it.
        ''' </summary>
        ''' <param name = "continueLabel"></param>
        Private Sub ResolveContinues(continueLabel As LabelSymbol)
            Dim newPendingBranches = ArrayBuilder(Of PendingBranch).GetInstance()
            For Each pending In PendingBranches
                Select Case pending.Branch.Kind
                    Case BoundKind.ContinueStatement

                        ' When the continue XXX does not match an enclosing XXX block then no label exists
                        Dim continueStmt = TryCast(pending.Branch, BoundContinueStatement)

                        ' Technically, nothing in the language specification depends on the state
                        ' at the continue label, so we could just discard them instead of merging
                        ' the states. In fact, we need not have added continue statements to the
                        ' pending jump queue in the first place if we were interested solely in the
                        ' flow analysis.  However, region analysis (in support of extract method)
                        ' depends on continue statements appearing in the pending branch queue, so
                        ' we process them from the queue here.
                        If continueStmt.Label = continueLabel Then
                            IntersectWith(State, pending.State)
                        Else
                            ' If it doesn't match then it is for an outer block
                            newPendingBranches.Add(pending)
                        End If

                    Case Else
                        newPendingBranches.Add(pending)
                End Select
            Next
            ResetPendingBranches(newPendingBranches)
        End Sub

        ''' <summary>
        ''' Subclasses override this if they want to take special actions on processing a goto
        ''' statement, when both the jump and the label have been located.
        ''' </summary>
        Protected Overridable Sub NoteBranch(pending As PendingBranch, stmt As BoundStatement, labelStmt As BoundLabelStatement)
        End Sub

        Private Shared Function GetBranchTargetLabel(branch As BoundStatement, gotoOnly As Boolean) As LabelSymbol
            Select Case branch.Kind
                Case BoundKind.GotoStatement
                    Return DirectCast(branch, BoundGotoStatement).Label
                Case BoundKind.ConditionalGoto
                    Return DirectCast(branch, BoundConditionalGoto).Label
                Case BoundKind.ExitStatement
                    Return If(gotoOnly, Nothing, DirectCast(branch, BoundExitStatement).Label)
                Case BoundKind.ReturnStatement
                    Return If(gotoOnly, Nothing, DirectCast(branch, BoundReturnStatement).ExitLabelOpt)
                Case BoundKind.ContinueStatement
                    Return Nothing
                Case BoundKind.YieldStatement
                    Return Nothing
                Case Else
                    Throw ExceptionUtilities.UnexpectedValue(branch.Kind)
            End Select
            Return Nothing
        End Function

        Protected Overridable Sub ResolveBranch(pending As PendingBranch, label As LabelSymbol, target As BoundLabelStatement, ByRef labelStateChanged As Boolean)
            Dim _state = LabelState(target.Label)
            NoteBranch(pending, pending.Branch, target)
            Dim changed = IntersectWith(_state, pending.State)
            If Not changed Then Exit Sub
            labelStateChanged = True
            _labels(target.Label) = New LabelStateAndNesting(target, _state, _nesting)
        End Sub

        ''' <summary>
        ''' To handle a label, we resolve all pending forward references to branches to that label.  Returns true if the state of
        ''' the label changes as a result. 
        ''' </summary>
        ''' <param name = "target"></param>
        ''' <returns></returns>
        Private Function ResolveBranches(target As BoundLabelStatement) As Boolean
            Dim labelStateChanged As Boolean = False

            If PendingBranches.Length <= 0 Then Return labelStateChanged

            Dim newPendingBranches = ArrayBuilder(Of PendingBranch).GetInstance()

            For Each pending In PendingBranches
                Dim label As LabelSymbol = GetBranchTargetLabel(pending.Branch, False)
                If label IsNot Nothing AndAlso label = target.Label Then
                    ResolveBranch(pending, label, target, labelStateChanged)
                Else
                    newPendingBranches.Add(pending)
                End If

            Next

            ResetPendingBranches(newPendingBranches)

            Return labelStateChanged
        End Function

        Protected Class SavedPending
            Public ReadOnly PendingBranches As ArrayBuilder(Of PendingBranch)
            Public ReadOnly LabelsSeen As PooledHashSet(Of LabelSymbol)

            Public Sub New(ByRef _pendingBranches As ArrayBuilder(Of PendingBranch), ByRef _labelsSeen As PooledHashSet(Of LabelSymbol))
                PendingBranches = _pendingBranches
                LabelsSeen = _labelsSeen

                _pendingBranches = ArrayBuilder(Of PendingBranch).GetInstance()
                _labelsSeen = PooledHashSet(Of LabelSymbol).GetInstance
            End Sub
        End Class


        ''' <summary>
        ''' When branching into constructs that don't support jumps into/out of (i.e. lambdas), 
        ''' we save the pending branches when visiting more nested constructs.
        ''' </summary>
        Protected Function SavePending() As SavedPending
            Return New SavedPending(_pendingBranches, _labelsSeen)
        End Function

        Private Sub ResetPendingBranches(newPendingBranches As ArrayBuilder(Of PendingBranch))
            Debug.Assert(newPendingBranches IsNot Nothing)
            Debug.Assert(newPendingBranches IsNot _pendingBranches)
            _pendingBranches.Free()
            _pendingBranches = newPendingBranches
        End Sub

        ''' <summary>
        ''' We use this to restore the old set of pending branches and labels after visiting a construct that contains nested statements.
        ''' </summary>
        ''' <param name="oldPending">The old pending branches/labels, which are to be merged with the current ones</param>
        Protected Sub RestorePending(oldPending As SavedPending, Optional mergeLabelsSeen As Boolean = False)
            If ResolveBranches(_labelsSeen) Then backwardBranchChanged = True

            oldPending.PendingBranches.AddRange(PendingBranches)
            ResetPendingBranches(oldPending.PendingBranches)

            ' We only use SavePending/RestorePending when there could be no branch into the region between them.
            ' So there is no need to save the labels seen between the calls.  If there were such a need, we would
            ' do "this.labelsSeen.UnionWith(oldPending.LabelsSeen);" instead of the following assignment
            If mergeLabelsSeen Then
                _labelsSeen.AddAll(oldPending.LabelsSeen)
            Else
                _labelsSeen = oldPending.LabelsSeen
            End If
        End Sub

        ''' <summary>
        ''' We look at all pending branches and attempt to resolve the branches with labels if the nesting of the 
        ''' block is the nearest common parent to the branch and the label. Because the code is evaluated recursively 
        ''' outward we only need to check if the current nesting is a prefix of both the branch and the label nesting.
        ''' </summary>
        Private Function ResolveBranches(labelsFilter As HashSet(Of LabelSymbol)) As Boolean
            Dim labelStateChanged As Boolean = False

            If PendingBranches.Length > 0 Then
                Dim newPendingBranches = ArrayBuilder(Of PendingBranch).GetInstance()

                For Each pending In PendingBranches
                    Dim labelSymbol As LabelSymbol = Nothing
                    Dim labelAndNesting As LabelStateAndNesting = Nothing
                    If BothBranchAndLabelArePrefixedByNesting(pending, labelsFilter, labelSymbol:=labelSymbol, labelAndNesting:=labelAndNesting) Then
                        Dim changed As Boolean
                        ResolveBranch(pending, labelSymbol, labelAndNesting.Target, changed)
                        If changed Then
                            labelStateChanged = True
                        End If
                        Continue For
                    End If
                    newPendingBranches.Add(pending)
                Next

                ResetPendingBranches(newPendingBranches)
            End If

            Return labelStateChanged
        End Function

        Private Function BothBranchAndLabelArePrefixedByNesting(branch As PendingBranch,
                                                                Optional labelsFilter As HashSet(Of LabelSymbol) = Nothing,
                                                                Optional ignoreLast As Boolean = False,
                                                                <Out()> Optional ByRef labelSymbol As LabelSymbol = Nothing,
                                                                <Out()> Optional ByRef labelAndNesting As LabelStateAndNesting = Nothing) As Boolean

            Dim branchStatement As BoundStatement = branch.Branch
            If branchStatement IsNot Nothing AndAlso branch.Nesting.IsPrefixedBy(_nesting, ignoreLast) Then
                labelSymbol = GetBranchTargetLabel(branchStatement, gotoOnly:=True)
                If labelSymbol IsNot Nothing AndAlso (labelsFilter Is Nothing OrElse labelsFilter.Contains(labelSymbol)) Then
                    Return _labels.TryGetValue(labelSymbol, labelAndNesting) AndAlso
                           labelAndNesting.Nesting.IsPrefixedBy(_nesting, ignoreLast)
                End If
            End If
            Return False
        End Function

        ''' <summary>
        ''' Report an unimplemented language construct.
        ''' </summary>
        ''' <param name = "node"></param>
        ''' <param name = "feature"></param>
        ''' <returns></returns>
        Protected Overridable Function Unimplemented(node As BoundNode, feature As [String]) As BoundNode
            Return Nothing
        End Function

        Protected Overridable Function AllBitsSet() As LocalState
            Return Nothing
        End Function

        Protected Sub SetPlaceholderSubstitute(placeholder As BoundValuePlaceholderBase, newSubstitute As BoundExpression)
            Debug.Assert(placeholder IsNot Nothing)

            _placeholderReplacementMap = If(_placeholderReplacementMap, PooledDictionary(Of BoundValuePlaceholderBase, BoundExpression).GetInstance)

            Debug.Assert(Not _placeholderReplacementMap.ContainsKey(placeholder))
            _placeholderReplacementMap(placeholder) = newSubstitute
        End Sub

        Protected Sub RemovePlaceholderSubstitute(placeholder As BoundValuePlaceholderBase)
            Debug.Assert(placeholder IsNot Nothing)
            Debug.Assert(_placeholderReplacementMap.ContainsKey(placeholder))
            _placeholderReplacementMap.Remove(placeholder)
        End Sub

        Protected ReadOnly Property GetPlaceholderSubstitute(placeholder As BoundValuePlaceholderBase) As BoundExpression
            Get
                Dim value As BoundExpression = Nothing
                Return If(_placeholderReplacementMap?.TryGetValue(placeholder, value), value, Nothing)
            End Get
        End Property

        Protected MustOverride Function Dump(state As LocalState) As String

    End Class

End Namespace
