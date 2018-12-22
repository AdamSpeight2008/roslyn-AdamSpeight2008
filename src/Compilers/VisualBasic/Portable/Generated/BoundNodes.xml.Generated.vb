' < auto-generated />

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Immutable
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Text
Imports Microsoft.CodeAnalysis.Collections
Imports Roslyn.Utilities

Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.VisualBasic

  Friend Enum BoundKind As System.Byte
    TypeArguments
    OmittedArgument
    LValueToRValueWrapper
    WithLValueExpressionPlaceholder
    WithRValueExpressionPlaceholder
    RValuePlaceholder
    LValuePlaceholder
    Dup
    BadExpression
    BadStatement
    Parenthesized
    BadVariable
    ArrayAccess
    ArrayLength
    [GetType]
    FieldInfo
    MethodInfo
    TypeExpression
    TypeOrValueExpression
    NamespaceExpression
    MethodDefIndex
    MaximumMethodDefIndex
    InstrumentationPayloadRoot
    ModuleVersionId
    ModuleVersionIdString
    SourceDocumentIndex
    UnaryOperator
    UserDefinedUnaryOperator
    NullableIsTrueOperator
    BinaryOperator
    UserDefinedBinaryOperator
    UserDefinedShortCircuitingOperator
    CompoundAssignmentTargetPlaceholder
    AssignmentOperator
    ReferenceAssignment
    AddressOfOperator
    TernaryConditionalExpression
    BinaryConditionalExpression
    Conversion
    RelaxationLambda
    ConvertedTupleElements
    UserDefinedConversion
    [DirectCast]
    [TryCast]
    [TypeOf]
    SequencePoint
    SequencePointExpression
    SequencePointWithSpan
    NoOpStatement
    MethodGroup
    PropertyGroup
    ReturnStatement
    YieldStatement
    ThrowStatement
    RedimStatement
    RedimClause
    EraseStatement
    [Call]
    Attribute
    LateMemberAccess
    LateInvocation
    LateAddressOfOperator
    TupleLiteral
    ConvertedTupleLiteral
    ObjectCreationExpression
    NoPiaObjectCreationExpression
    AnonymousTypeCreationExpression
    AnonymousTypePropertyAccess
    AnonymousTypeFieldInitializer
    ObjectInitializerExpression
    CollectionInitializerExpression
    NewT
    DelegateCreationExpression
    ArrayCreation
    ArrayLiteral
    ArrayInitialization
    FieldAccess
    PropertyAccess
    EventAccess
    Block
    StateMachineScope
    LocalDeclaration
    AsNewLocalDeclarations
    DimStatement
    Initializer
    FieldInitializer
    PropertyInitializer
    ParameterEqualsValue
    GlobalStatementInitializer
    Sequence
    ExpressionStatement
    IfStatement
    SelectStatement
    CaseBlock
    CaseStatement
    SimpleCaseClause
    RangeCaseClause
    RelationalCaseClause
    DoLoopStatement
    WhileStatement
    ForToUserDefinedOperators
    ForToStatement
    ForEachStatement
    ExitStatement
    ContinueStatement
    TryStatement
    CatchBlock
    Literal
    MeReference
    ValueTypeMeReference
    MyBaseReference
    MyClassReference
    PreviousSubmissionReference
    HostObjectMemberReference
    Local
    PseudoVariable
    Parameter
    ByRefArgumentPlaceholder
    ByRefArgumentWithCopyBack
    LateBoundArgumentSupportingAssignmentWithCapture
    LabelStatement
    Label
    GotoStatement
    StatementList
    ConditionalGoto
    WithStatement
    UnboundLambda
    Lambda
    QueryExpression
    QuerySource
    ToQueryableCollectionConversion
    QueryableSource
    QueryClause
    Ordering
    QueryLambda
    RangeVariableAssignment
    GroupTypeInferenceLambda
    AggregateClause
    GroupAggregation
    RangeVariable
    AddHandlerStatement
    RemoveHandlerStatement
    RaiseEventStatement
    UsingStatement
    SyncLockStatement
    XmlName
    XmlNamespace
    XmlDocument
    XmlDeclaration
    XmlProcessingInstruction
    XmlComment
    XmlAttribute
    XmlElement
    XmlMemberAccess
    XmlEmbeddedExpression
    XmlCData
    ResumeStatement
    OnErrorStatement
    UnstructuredExceptionHandlingStatement
    UnstructuredExceptionHandlingCatchFilter
    UnstructuredExceptionOnErrorSwitch
    UnstructuredExceptionResumeSwitch
    AwaitOperator
    SpillSequence
    StopStatement
    EndStatement
    MidResult
    ConditionalAccess
    ConditionalAccessReceiverPlaceholder
    LoweredConditionalAccess
    ComplexConditionalAccessReceiver
    NameOfOperator
    TypeAsValueExpression
    InterpolatedStringExpression
    Interpolation
  End Enum

  Friend MustInherit Partial Class BoundExpression : Inherits BoundNode

    Protected Sub New
      MyBase.New(kind, syntax)
      _Type = type
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
      _Type = type
    End Sub
    Public ReadOnly Property type As TypeSymbol

  End Class

  Friend NotInheritable Partial Class BoundTypeArguments : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.TypeArguments, syntax, Nothing, hasErrors)
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Arguments = arguments
    End Sub
    Public Sub New
      MyBase.New(BoundKind.TypeArguments, syntax, Nothing)
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Arguments = arguments
    End Sub
    Public ReadOnly Property arguments As ImmutableArray(Of TypeSymbol)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTypeArguments(Me)
    End Function
    Public Function Update As BoundTypeArguments
      If (arguments = Me.Arguments) Then Return Me
      Dim result As New BoundTypeArguments
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundOmittedArgument : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.OmittedArgument, syntax, type, hasErrors)
    End Sub
    Public Sub New
      MyBase.New(BoundKind.OmittedArgument, syntax, type)
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitOmittedArgument(Me)
    End Function
    Public Function Update As BoundOmittedArgument
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundOmittedArgument
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundValuePlaceholderBase : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundLValueToRValueWrapper : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.LValueToRValueWrapper, syntax, type, hasErrors OrElse underlyingLValue.NonNullAndHasErrors())
      Debug.Assert(underlyingLValue IsNot Nothing, $"Field '{NameOf(underlyingLValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _UnderlyingLValue = underlyingLValue
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property underlyingLValue As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLValueToRValueWrapper(Me)
    End Function
    Public Function Update As BoundLValueToRValueWrapper
      If (underlyingLValue Is Me.UnderlyingLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLValueToRValueWrapper
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundLValuePlaceholderBase : Inherits BoundValuePlaceholderBase

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
  End Class

  Friend MustInherit Partial Class BoundRValuePlaceholderBase : Inherits BoundValuePlaceholderBase

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundWithLValueExpressionPlaceholder : Inherits BoundLValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.WithLValueExpressionPlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.WithLValueExpressionPlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitWithLValueExpressionPlaceholder(Me)
    End Function
    Public Function Update As BoundWithLValueExpressionPlaceholder
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundWithLValueExpressionPlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundWithRValueExpressionPlaceholder : Inherits BoundRValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.WithRValueExpressionPlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.WithRValueExpressionPlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitWithRValueExpressionPlaceholder(Me)
    End Function
    Public Function Update As BoundWithRValueExpressionPlaceholder
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundWithRValueExpressionPlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRValuePlaceholder : Inherits BoundRValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.RValuePlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.RValuePlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRValuePlaceholder(Me)
    End Function
    Public Function Update As BoundRValuePlaceholder
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundRValuePlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLValuePlaceholder : Inherits BoundLValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.LValuePlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.LValuePlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLValuePlaceholder(Me)
    End Function
    Public Function Update As BoundLValuePlaceholder
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundLValuePlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundDup : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Dup, syntax, type, hasErrors)
      _IsReference = isReference
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Dup, syntax, type)
      _IsReference = isReference
    End Sub
    Public ReadOnly Property isReference As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitDup(Me)
    End Function
    Public Function Update As BoundDup
      If (isReference = Me.IsReference) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundDup
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundBadExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.BadExpression, syntax, type, hasErrors OrElse childBoundNodes.NonNullAndHasErrors())
      Debug.Assert(Not symbols.IsDefault, $"Field '{NameOf(symbols)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not childBoundNodes.IsDefault, $"Field '{NameOf(childBoundNodes)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ResultKind = resultKind
      _Symbols = symbols
      _ChildBoundNodes = childBoundNodes
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides ReadOnly Property resultKind As LookupResultKind

    Public ReadOnly Property symbols As ImmutableArray(Of Symbol)

    Public ReadOnly Property childBoundNodes As ImmutableArray(Of BoundExpression)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitBadExpression(Me)
    End Function
    Public Function Update As BoundBadExpression
      If (resultKind = Me.ResultKind) AndAlso (symbols = Me.Symbols) AndAlso (childBoundNodes = Me.ChildBoundNodes) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundBadExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundBadStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.BadStatement, syntax, hasErrors OrElse childBoundNodes.NonNullAndHasErrors())
      Debug.Assert(Not childBoundNodes.IsDefault, $"Field '{NameOf(childBoundNodes)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ChildBoundNodes = childBoundNodes
    End Sub
    Public ReadOnly Property childBoundNodes As ImmutableArray(Of BoundNode)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitBadStatement(Me)
    End Function
    Public Function Update As BoundBadStatement
      If (childBoundNodes = Me.ChildBoundNodes) Then Return Me
      Dim result As New BoundBadStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundParenthesized : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Parenthesized, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitParenthesized(Me)
    End Function
    Public Function Update As BoundParenthesized
      If (expression Is Me.Expression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundParenthesized
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundBadVariable : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.BadVariable, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
      _IsLValue = isLValue
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitBadVariable(Me)
    End Function
    Public Function Update As BoundBadVariable
      If (expression Is Me.Expression) AndAlso (isLValue = Me.IsLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundBadVariable
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundArrayAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ArrayAccess, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors() OrElse indices.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not indices.IsDefault, $"Field '{NameOf(indices)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
      _Indices = indices
      _IsLValue = isLValue
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public ReadOnly Property indices As ImmutableArray(Of BoundExpression)

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitArrayAccess(Me)
    End Function
    Public Function Update As BoundArrayAccess
      If (expression Is Me.Expression) AndAlso (indices = Me.Indices) AndAlso (isLValue = Me.IsLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundArrayAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundArrayLength : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ArrayLength, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitArrayLength(Me)
    End Function
    Public Function Update As BoundArrayLength
      If (expression Is Me.Expression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundArrayLength
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundGetType : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.GetType, syntax, type, hasErrors OrElse sourceType.NonNullAndHasErrors())
      Debug.Assert(sourceType IsNot Nothing, $"Field '{NameOf(sourceType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _SourceType = sourceType
    End Sub
    Public ReadOnly Property sourceType As BoundTypeExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitGetType(Me)
    End Function
    Public Function Update As BoundGetType
      If (sourceType Is Me.SourceType) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundGetType
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundFieldInfo : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.FieldInfo, syntax, type, hasErrors)
      Debug.Assert(field IsNot Nothing, $"Field '{NameOf(field)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Field = field
    End Sub
    Public Sub New
      MyBase.New(BoundKind.FieldInfo, syntax, type)
      Debug.Assert(field IsNot Nothing, $"Field '{NameOf(field)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Field = field
    End Sub
    Public ReadOnly Property field As FieldSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitFieldInfo(Me)
    End Function
    Public Function Update As BoundFieldInfo
      If (field Is Me.Field) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundFieldInfo
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMethodInfo : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MethodInfo, syntax, type, hasErrors)
      Debug.Assert(method IsNot Nothing, $"Field '{NameOf(method)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Method = method
    End Sub
    Public Sub New
      MyBase.New(BoundKind.MethodInfo, syntax, type)
      Debug.Assert(method IsNot Nothing, $"Field '{NameOf(method)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Method = method
    End Sub
    Public ReadOnly Property method As MethodSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMethodInfo(Me)
    End Function
    Public Function Update As BoundMethodInfo
      If (method Is Me.Method) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundMethodInfo
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTypeExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.TypeExpression, syntax, type, hasErrors OrElse unevaluatedReceiverOpt.NonNullAndHasErrors())
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _UnevaluatedReceiverOpt = unevaluatedReceiverOpt
      _AliasOpt = aliasOpt
    End Sub
    Public ReadOnly Property unevaluatedReceiverOpt As BoundExpression

    Public ReadOnly Property aliasOpt As AliasSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTypeExpression(Me)
    End Function
    Public Function Update As BoundTypeExpression
      If (unevaluatedReceiverOpt Is Me.UnevaluatedReceiverOpt) AndAlso (aliasOpt Is Me.AliasOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTypeExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTypeOrValueExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.TypeOrValueExpression, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Data = data
    End Sub
    Public Sub New
      MyBase.New(BoundKind.TypeOrValueExpression, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Data = data
    End Sub
    Public ReadOnly Property data As BoundTypeOrValueData

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTypeOrValueExpression(Me)
    End Function
    Public Function Update As BoundTypeOrValueExpression
      If (data = Me.Data) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTypeOrValueExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundNamespaceExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.NamespaceExpression, syntax, Nothing, hasErrors OrElse unevaluatedReceiverOpt.NonNullAndHasErrors())
      Debug.Assert(namespaceSymbol IsNot Nothing, $"Field '{NameOf(namespaceSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _UnevaluatedReceiverOpt = unevaluatedReceiverOpt
      _AliasOpt = aliasOpt
      _NamespaceSymbol = namespaceSymbol
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property unevaluatedReceiverOpt As BoundExpression

    Public ReadOnly Property aliasOpt As AliasSymbol

    Public ReadOnly Property namespaceSymbol As NamespaceSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitNamespaceExpression(Me)
    End Function
    Public Function Update As BoundNamespaceExpression
      If (unevaluatedReceiverOpt Is Me.UnevaluatedReceiverOpt) AndAlso (aliasOpt Is Me.AliasOpt) AndAlso (namespaceSymbol Is Me.NamespaceSymbol) Then Return Me
      Dim result As New BoundNamespaceExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMethodDefIndex : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MethodDefIndex, syntax, type, hasErrors)
      Debug.Assert(method IsNot Nothing, $"Field '{NameOf(method)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Method = method
    End Sub
    Public Sub New
      MyBase.New(BoundKind.MethodDefIndex, syntax, type)
      Debug.Assert(method IsNot Nothing, $"Field '{NameOf(method)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Method = method
    End Sub
    Public ReadOnly Property method As MethodSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMethodDefIndex(Me)
    End Function
    Public Function Update As BoundMethodDefIndex
      If (method Is Me.Method) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundMethodDefIndex
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMaximumMethodDefIndex : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MaximumMethodDefIndex, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.MaximumMethodDefIndex, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMaximumMethodDefIndex(Me)
    End Function
    Public Function Update As BoundMaximumMethodDefIndex
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundMaximumMethodDefIndex
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundInstrumentationPayloadRoot : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.InstrumentationPayloadRoot, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _AnalysisKind = analysisKind
      _IsLValue = isLValue
    End Sub
    Public Sub New
      MyBase.New(BoundKind.InstrumentationPayloadRoot, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _AnalysisKind = analysisKind
      _IsLValue = isLValue
    End Sub
    Public ReadOnly Property analysisKind As Integer

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitInstrumentationPayloadRoot(Me)
    End Function
    Public Function Update As BoundInstrumentationPayloadRoot
      If (analysisKind = Me.AnalysisKind) AndAlso (isLValue = Me.IsLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundInstrumentationPayloadRoot
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundModuleVersionId : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ModuleVersionId, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _IsLValue = isLValue
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ModuleVersionId, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _IsLValue = isLValue
    End Sub
    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitModuleVersionId(Me)
    End Function
    Public Function Update As BoundModuleVersionId
      If (isLValue = Me.IsLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundModuleVersionId
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundModuleVersionIdString : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ModuleVersionIdString, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ModuleVersionIdString, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitModuleVersionIdString(Me)
    End Function
    Public Function Update As BoundModuleVersionIdString
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundModuleVersionIdString
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSourceDocumentIndex : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.SourceDocumentIndex, syntax, type, hasErrors)
      Debug.Assert(document IsNot Nothing, $"Field '{NameOf(document)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Document = document
    End Sub
    Public Sub New
      MyBase.New(BoundKind.SourceDocumentIndex, syntax, type)
      Debug.Assert(document IsNot Nothing, $"Field '{NameOf(document)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Document = document
    End Sub
    Public ReadOnly Property document As Cci.DebugSourceDocument

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSourceDocumentIndex(Me)
    End Function
    Public Function Update As BoundSourceDocumentIndex
      If (document Is Me.Document) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundSourceDocumentIndex
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUnaryOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UnaryOperator, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OperatorKind = operatorKind
      _Operand = operand
      _Checked = checked
      _ConstantValueOpt = constantValueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operatorKind As UnaryOperatorKind

    Public ReadOnly Property operand As BoundExpression

    Public ReadOnly Property checked As Boolean

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUnaryOperator(Me)
    End Function
    Public Function Update As BoundUnaryOperator
      If (operatorKind = Me.OperatorKind) AndAlso (operand Is Me.Operand) AndAlso (checked = Me.Checked) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundUnaryOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUserDefinedUnaryOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UserDefinedUnaryOperator, syntax, type, hasErrors OrElse underlyingExpression.NonNullAndHasErrors())
      Debug.Assert(underlyingExpression IsNot Nothing, $"Field '{NameOf(underlyingExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OperatorKind = operatorKind
      _UnderlyingExpression = underlyingExpression
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operatorKind As UnaryOperatorKind

    Public ReadOnly Property underlyingExpression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUserDefinedUnaryOperator(Me)
    End Function
    Public Function Update As BoundUserDefinedUnaryOperator
      If (operatorKind = Me.OperatorKind) AndAlso (underlyingExpression Is Me.UnderlyingExpression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundUserDefinedUnaryOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundNullableIsTrueOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.NullableIsTrueOperator, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operand As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitNullableIsTrueOperator(Me)
    End Function
    Public Function Update As BoundNullableIsTrueOperator
      If (operand Is Me.Operand) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundNullableIsTrueOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundBinaryOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.BinaryOperator, syntax, type, hasErrors OrElse left.NonNullAndHasErrors() OrElse right.NonNullAndHasErrors())
      Debug.Assert(left IsNot Nothing, $"Field '{NameOf(left)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(right IsNot Nothing, $"Field '{NameOf(right)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OperatorKind = operatorKind
      _Left = left
      _Right = right
      _Checked = checked
      _ConstantValueOpt = constantValueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operatorKind As BinaryOperatorKind

    Public ReadOnly Property left As BoundExpression

    Public ReadOnly Property right As BoundExpression

    Public ReadOnly Property checked As Boolean

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitBinaryOperator(Me)
    End Function
    Public Function Update As BoundBinaryOperator
      If (operatorKind = Me.OperatorKind) AndAlso (left Is Me.Left) AndAlso (right Is Me.Right) AndAlso (checked = Me.Checked) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundBinaryOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUserDefinedBinaryOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UserDefinedBinaryOperator, syntax, type, hasErrors OrElse underlyingExpression.NonNullAndHasErrors())
      Debug.Assert(underlyingExpression IsNot Nothing, $"Field '{NameOf(underlyingExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OperatorKind = operatorKind
      _UnderlyingExpression = underlyingExpression
      _Checked = checked
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operatorKind As BinaryOperatorKind

    Public ReadOnly Property underlyingExpression As BoundExpression

    Public ReadOnly Property checked As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUserDefinedBinaryOperator(Me)
    End Function
    Public Function Update As BoundUserDefinedBinaryOperator
      If (operatorKind = Me.OperatorKind) AndAlso (underlyingExpression Is Me.UnderlyingExpression) AndAlso (checked = Me.Checked) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundUserDefinedBinaryOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUserDefinedShortCircuitingOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UserDefinedShortCircuitingOperator, syntax, type, hasErrors OrElse leftOperand.NonNullAndHasErrors() OrElse leftOperandPlaceholder.NonNullAndHasErrors() OrElse leftTest.NonNullAndHasErrors() OrElse bitwiseOperator.NonNullAndHasErrors())
      Debug.Assert(bitwiseOperator IsNot Nothing, $"Field '{NameOf(bitwiseOperator)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LeftOperand = leftOperand
      _LeftOperandPlaceholder = leftOperandPlaceholder
      _LeftTest = leftTest
      _BitwiseOperator = bitwiseOperator
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property leftOperand As BoundExpression

    Public ReadOnly Property leftOperandPlaceholder As BoundRValuePlaceholder

    Public ReadOnly Property leftTest As BoundExpression

    Public ReadOnly Property bitwiseOperator As BoundUserDefinedBinaryOperator

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUserDefinedShortCircuitingOperator(Me)
    End Function
    Public Function Update As BoundUserDefinedShortCircuitingOperator
      If (leftOperand Is Me.LeftOperand) AndAlso (leftOperandPlaceholder Is Me.LeftOperandPlaceholder) AndAlso (leftTest Is Me.LeftTest) AndAlso (bitwiseOperator Is Me.BitwiseOperator) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundUserDefinedShortCircuitingOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundCompoundAssignmentTargetPlaceholder : Inherits BoundValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.CompoundAssignmentTargetPlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.CompoundAssignmentTargetPlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitCompoundAssignmentTargetPlaceholder(Me)
    End Function
    Public Function Update As BoundCompoundAssignmentTargetPlaceholder
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundCompoundAssignmentTargetPlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAssignmentOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.AssignmentOperator, syntax, type, hasErrors OrElse left.NonNullAndHasErrors() OrElse leftOnTheRightOpt.NonNullAndHasErrors() OrElse right.NonNullAndHasErrors())
      Debug.Assert(left IsNot Nothing, $"Field '{NameOf(left)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(right IsNot Nothing, $"Field '{NameOf(right)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Left = left
      _LeftOnTheRightOpt = leftOnTheRightOpt
      _Right = right
      _SuppressObjectClone = suppressObjectClone
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property left As BoundExpression

    Public ReadOnly Property leftOnTheRightOpt As BoundCompoundAssignmentTargetPlaceholder

    Public ReadOnly Property right As BoundExpression

    Public ReadOnly Property suppressObjectClone As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAssignmentOperator(Me)
    End Function
    Public Function Update As BoundAssignmentOperator
      If (left Is Me.Left) AndAlso (leftOnTheRightOpt Is Me.LeftOnTheRightOpt) AndAlso (right Is Me.Right) AndAlso (suppressObjectClone = Me.SuppressObjectClone) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAssignmentOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundReferenceAssignment : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ReferenceAssignment, syntax, type, hasErrors OrElse byRefLocal.NonNullAndHasErrors() OrElse lValue.NonNullAndHasErrors())
      Debug.Assert(byRefLocal IsNot Nothing, $"Field '{NameOf(byRefLocal)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ByRefLocal = byRefLocal
      _LValue = lValue
      _IsLValue = isLValue
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property byRefLocal As BoundLocal

    Public ReadOnly Property lValue As BoundExpression

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitReferenceAssignment(Me)
    End Function
    Public Function Update As BoundReferenceAssignment
      If (byRefLocal Is Me.ByRefLocal) AndAlso (lValue Is Me.LValue) AndAlso (isLValue = Me.IsLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundReferenceAssignment
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAddressOfOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.AddressOfOperator, syntax, Nothing, hasErrors OrElse methodGroup.NonNullAndHasErrors())
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(methodGroup IsNot Nothing, $"Field '{NameOf(methodGroup)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _MethodGroup = methodGroup
    End Sub
    Public ReadOnly Property binder As Binder

    Public ReadOnly Property methodGroup As BoundMethodGroup

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAddressOfOperator(Me)
    End Function
    Public Function Update As BoundAddressOfOperator
      If (binder Is Me.Binder) AndAlso (methodGroup Is Me.MethodGroup) Then Return Me
      Dim result As New BoundAddressOfOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTernaryConditionalExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.TernaryConditionalExpression, syntax, type, hasErrors OrElse condition.NonNullAndHasErrors() OrElse whenTrue.NonNullAndHasErrors() OrElse whenFalse.NonNullAndHasErrors())
      Debug.Assert(condition IsNot Nothing, $"Field '{NameOf(condition)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(whenTrue IsNot Nothing, $"Field '{NameOf(whenTrue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(whenFalse IsNot Nothing, $"Field '{NameOf(whenFalse)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Condition = condition
      _WhenTrue = whenTrue
      _WhenFalse = whenFalse
      _ConstantValueOpt = constantValueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property condition As BoundExpression

    Public ReadOnly Property whenTrue As BoundExpression

    Public ReadOnly Property whenFalse As BoundExpression

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTernaryConditionalExpression(Me)
    End Function
    Public Function Update As BoundTernaryConditionalExpression
      If (condition Is Me.Condition) AndAlso (whenTrue Is Me.WhenTrue) AndAlso (whenFalse Is Me.WhenFalse) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTernaryConditionalExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundBinaryConditionalExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.BinaryConditionalExpression, syntax, type, hasErrors OrElse testExpression.NonNullAndHasErrors() OrElse convertedTestExpression.NonNullAndHasErrors() OrElse testExpressionPlaceholder.NonNullAndHasErrors() OrElse elseExpression.NonNullAndHasErrors())
      Debug.Assert(testExpression IsNot Nothing, $"Field '{NameOf(testExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(elseExpression IsNot Nothing, $"Field '{NameOf(elseExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _TestExpression = testExpression
      _ConvertedTestExpression = convertedTestExpression
      _TestExpressionPlaceholder = testExpressionPlaceholder
      _ElseExpression = elseExpression
      _ConstantValueOpt = constantValueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property testExpression As BoundExpression

    Public ReadOnly Property convertedTestExpression As BoundExpression

    Public ReadOnly Property testExpressionPlaceholder As BoundRValuePlaceholder

    Public ReadOnly Property elseExpression As BoundExpression

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitBinaryConditionalExpression(Me)
    End Function
    Public Function Update As BoundBinaryConditionalExpression
      If (testExpression Is Me.TestExpression) AndAlso (convertedTestExpression Is Me.ConvertedTestExpression) AndAlso (testExpressionPlaceholder Is Me.TestExpressionPlaceholder) AndAlso (elseExpression Is Me.ElseExpression) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundBinaryConditionalExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundConversionOrCast : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundConversion : Inherits BoundConversionOrCast

    Public Sub New
      MyBase.New(BoundKind.Conversion, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors() OrElse extendedInfoOpt.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      _ConversionKind = conversionKind
      _Checked = checked
      _ExplicitCastInCode = explicitCastInCode
      _ConstantValueOpt = constantValueOpt
      _ExtendedInfoOpt = extendedInfoOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides ReadOnly Property operand As BoundExpression

    Public Overrides ReadOnly Property conversionKind As ConversionKind

    Public ReadOnly Property checked As Boolean

    Public Overrides ReadOnly Property explicitCastInCode As Boolean

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public ReadOnly Property extendedInfoOpt As BoundExtendedConversionInfo

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitConversion(Me)
    End Function
    Public Function Update As BoundConversion
      If (operand Is Me.Operand) AndAlso (conversionKind = Me.ConversionKind) AndAlso (checked = Me.Checked) AndAlso (explicitCastInCode = Me.ExplicitCastInCode) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (extendedInfoOpt Is Me.ExtendedInfoOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundConversion
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundExtendedConversionInfo : Inherits BoundNode

    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundRelaxationLambda : Inherits BoundExtendedConversionInfo

    Public Sub New
      MyBase.New(BoundKind.RelaxationLambda, syntax, hasErrors OrElse lambda.NonNullAndHasErrors() OrElse receiverPlaceholderOpt.NonNullAndHasErrors())
      Debug.Assert(lambda IsNot Nothing, $"Field '{NameOf(lambda)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Lambda = lambda
      _ReceiverPlaceholderOpt = receiverPlaceholderOpt
    End Sub
    Public ReadOnly Property lambda As BoundLambda

    Public ReadOnly Property receiverPlaceholderOpt As BoundRValuePlaceholder

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRelaxationLambda(Me)
    End Function
    Public Function Update As BoundRelaxationLambda
      If (lambda Is Me.Lambda) AndAlso (receiverPlaceholderOpt Is Me.ReceiverPlaceholderOpt) Then Return Me
      Dim result As New BoundRelaxationLambda
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundConvertedTupleElements : Inherits BoundExtendedConversionInfo

    Public Sub New
      MyBase.New(BoundKind.ConvertedTupleElements, syntax, hasErrors OrElse elementPlaceholders.NonNullAndHasErrors() OrElse convertedElements.NonNullAndHasErrors())
      Debug.Assert(Not elementPlaceholders.IsDefault, $"Field '{NameOf(elementPlaceholders)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not convertedElements.IsDefault, $"Field '{NameOf(convertedElements)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ElementPlaceholders = elementPlaceholders
      _ConvertedElements = convertedElements
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property elementPlaceholders As ImmutableArray(Of BoundRValuePlaceholder)

    Public ReadOnly Property convertedElements As ImmutableArray(Of BoundExpression)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitConvertedTupleElements(Me)
    End Function
    Public Function Update As BoundConvertedTupleElements
      If (elementPlaceholders = Me.ElementPlaceholders) AndAlso (convertedElements = Me.ConvertedElements) Then Return Me
      Dim result As New BoundConvertedTupleElements
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUserDefinedConversion : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UserDefinedConversion, syntax, type, hasErrors OrElse underlyingExpression.NonNullAndHasErrors())
      Debug.Assert(underlyingExpression IsNot Nothing, $"Field '{NameOf(underlyingExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _UnderlyingExpression = underlyingExpression
      _InOutConversionFlags = inOutConversionFlags
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property underlyingExpression As BoundExpression

    Public ReadOnly Property inOutConversionFlags As Byte

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUserDefinedConversion(Me)
    End Function
    Public Function Update As BoundUserDefinedConversion
      If (underlyingExpression Is Me.UnderlyingExpression) AndAlso (inOutConversionFlags = Me.InOutConversionFlags) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundUserDefinedConversion
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundDirectCast : Inherits BoundConversionOrCast

    Public Sub New
      MyBase.New(BoundKind.DirectCast, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors() OrElse relaxationLambdaOpt.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      _ConversionKind = conversionKind
      _SuppressVirtualCalls = suppressVirtualCalls
      _ConstantValueOpt = constantValueOpt
      _RelaxationLambdaOpt = relaxationLambdaOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides ReadOnly Property operand As BoundExpression

    Public Overrides ReadOnly Property conversionKind As ConversionKind

    Public Overrides ReadOnly Property suppressVirtualCalls As Boolean

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public ReadOnly Property relaxationLambdaOpt As BoundLambda

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitDirectCast(Me)
    End Function
    Public Function Update As BoundDirectCast
      If (operand Is Me.Operand) AndAlso (conversionKind = Me.ConversionKind) AndAlso (suppressVirtualCalls = Me.SuppressVirtualCalls) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (relaxationLambdaOpt Is Me.RelaxationLambdaOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundDirectCast
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTryCast : Inherits BoundConversionOrCast

    Public Sub New
      MyBase.New(BoundKind.TryCast, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors() OrElse relaxationLambdaOpt.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      _ConversionKind = conversionKind
      _ConstantValueOpt = constantValueOpt
      _RelaxationLambdaOpt = relaxationLambdaOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides ReadOnly Property operand As BoundExpression

    Public Overrides ReadOnly Property conversionKind As ConversionKind

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public ReadOnly Property relaxationLambdaOpt As BoundLambda

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTryCast(Me)
    End Function
    Public Function Update As BoundTryCast
      If (operand Is Me.Operand) AndAlso (conversionKind = Me.ConversionKind) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (relaxationLambdaOpt Is Me.RelaxationLambdaOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTryCast
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTypeOf : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.TypeOf, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(targetType IsNot Nothing, $"Field '{NameOf(targetType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      _IsTypeOfIsNotExpression = isTypeOfIsNotExpression
      _TargetType = targetType
    End Sub
    Public ReadOnly Property operand As BoundExpression

    Public ReadOnly Property isTypeOfIsNotExpression As Boolean

    Public ReadOnly Property targetType As TypeSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTypeOf(Me)
    End Function
    Public Function Update As BoundTypeOf
      If (operand Is Me.Operand) AndAlso (isTypeOfIsNotExpression = Me.IsTypeOfIsNotExpression) AndAlso (targetType Is Me.TargetType) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTypeOf
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundStatement : Inherits BoundNode

    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundSequencePoint : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.SequencePoint, syntax, hasErrors OrElse statementOpt.NonNullAndHasErrors())
      _StatementOpt = statementOpt
    End Sub
    Public ReadOnly Property statementOpt As BoundStatement

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSequencePoint(Me)
    End Function
    Public Function Update As BoundSequencePoint
      If (statementOpt Is Me.StatementOpt) Then Return Me
      Dim result As New BoundSequencePoint
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSequencePointExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.SequencePointExpression, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSequencePointExpression(Me)
    End Function
    Public Function Update As BoundSequencePointExpression
      If (expression Is Me.Expression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundSequencePointExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSequencePointWithSpan : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.SequencePointWithSpan, syntax, hasErrors OrElse statementOpt.NonNullAndHasErrors())
      _StatementOpt = statementOpt
      _Span = span
    End Sub
    Public ReadOnly Property statementOpt As BoundStatement

    Public ReadOnly Property span As TextSpan

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSequencePointWithSpan(Me)
    End Function
    Public Function Update As BoundSequencePointWithSpan
      If (statementOpt Is Me.StatementOpt) AndAlso (span = Me.Span) Then Return Me
      Dim result As New BoundSequencePointWithSpan
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundNoOpStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.NoOpStatement, syntax, hasErrors)
      _Flavor = flavor
    End Sub
    Public Sub New
      MyBase.New(BoundKind.NoOpStatement, syntax)
      _Flavor = flavor
    End Sub
    Public ReadOnly Property flavor As NoOpStatementFlavor

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitNoOpStatement(Me)
    End Function
    Public Function Update As BoundNoOpStatement
      If (flavor = Me.Flavor) Then Return Me
      Dim result As New BoundNoOpStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundMethodOrPropertyGroup : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, Nothing)
      _ReceiverOpt = receiverOpt
      _QualificationKind = qualificationKind
    End Sub
    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property qualificationKind As QualificationKind

  End Class

  Friend NotInheritable Partial Class BoundMethodGroup : Inherits BoundMethodOrPropertyGroup

    Public Sub New
      MyBase.New(BoundKind.MethodGroup, syntax, receiverOpt, qualificationKind, hasErrors OrElse typeArgumentsOpt.NonNullAndHasErrors() OrElse receiverOpt.NonNullAndHasErrors())
      Debug.Assert(Not methods.IsDefault, $"Field '{NameOf(methods)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _TypeArgumentsOpt = typeArgumentsOpt
      _Methods = methods
      _PendingExtensionMethodsOpt = pendingExtensionMethodsOpt
      _ResultKind = resultKind
    End Sub
    Public ReadOnly Property typeArgumentsOpt As BoundTypeArguments

    Public ReadOnly Property methods As ImmutableArray(Of MethodSymbol)

    Public ReadOnly Property pendingExtensionMethodsOpt As ExtensionMethodGroup

    Public Overrides ReadOnly Property resultKind As LookupResultKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMethodGroup(Me)
    End Function
    Public Function Update As BoundMethodGroup
      If (typeArgumentsOpt Is Me.TypeArgumentsOpt) AndAlso (methods = Me.Methods) AndAlso (pendingExtensionMethodsOpt Is Me.PendingExtensionMethodsOpt) AndAlso (resultKind = Me.ResultKind) AndAlso (receiverOpt Is Me.ReceiverOpt) AndAlso (qualificationKind = Me.QualificationKind) Then Return Me
      Dim result As New BoundMethodGroup
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundPropertyGroup : Inherits BoundMethodOrPropertyGroup

    Public Sub New
      MyBase.New(BoundKind.PropertyGroup, syntax, receiverOpt, qualificationKind, hasErrors OrElse receiverOpt.NonNullAndHasErrors())
      Debug.Assert(Not properties.IsDefault, $"Field '{NameOf(properties)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Properties = properties
      _ResultKind = resultKind
    End Sub
    Public ReadOnly Property properties As ImmutableArray(Of PropertySymbol)

    Public Overrides ReadOnly Property resultKind As LookupResultKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitPropertyGroup(Me)
    End Function
    Public Function Update As BoundPropertyGroup
      If (properties = Me.Properties) AndAlso (resultKind = Me.ResultKind) AndAlso (receiverOpt Is Me.ReceiverOpt) AndAlso (qualificationKind = Me.QualificationKind) Then Return Me
      Dim result As New BoundPropertyGroup
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundReturnStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ReturnStatement, syntax, hasErrors OrElse expressionOpt.NonNullAndHasErrors())
      _ExpressionOpt = expressionOpt
      _FunctionLocalOpt = functionLocalOpt
      _ExitLabelOpt = exitLabelOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property expressionOpt As BoundExpression

    Public ReadOnly Property functionLocalOpt As LocalSymbol

    Public ReadOnly Property exitLabelOpt As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitReturnStatement(Me)
    End Function
    Public Function Update As BoundReturnStatement
      If (expressionOpt Is Me.ExpressionOpt) AndAlso (functionLocalOpt Is Me.FunctionLocalOpt) AndAlso (exitLabelOpt Is Me.ExitLabelOpt) Then Return Me
      Dim result As New BoundReturnStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundYieldStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.YieldStatement, syntax, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitYieldStatement(Me)
    End Function
    Public Function Update As BoundYieldStatement
      If (expression Is Me.Expression) Then Return Me
      Dim result As New BoundYieldStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundThrowStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ThrowStatement, syntax, hasErrors OrElse expressionOpt.NonNullAndHasErrors())
      _ExpressionOpt = expressionOpt
    End Sub
    Public ReadOnly Property expressionOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitThrowStatement(Me)
    End Function
    Public Function Update As BoundThrowStatement
      If (expressionOpt Is Me.ExpressionOpt) Then Return Me
      Dim result As New BoundThrowStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRedimStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.RedimStatement, syntax, hasErrors OrElse clauses.NonNullAndHasErrors())
      Debug.Assert(Not clauses.IsDefault, $"Field '{NameOf(clauses)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Clauses = clauses
    End Sub
    Public ReadOnly Property clauses As ImmutableArray(Of BoundRedimClause)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRedimStatement(Me)
    End Function
    Public Function Update As BoundRedimStatement
      If (clauses = Me.Clauses) Then Return Me
      Dim result As New BoundRedimStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRedimClause : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.RedimClause, syntax, hasErrors OrElse operand.NonNullAndHasErrors() OrElse indices.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not indices.IsDefault, $"Field '{NameOf(indices)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      _Indices = indices
      _ArrayTypeOpt = arrayTypeOpt
      _Preserve = preserve
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operand As BoundExpression

    Public ReadOnly Property indices As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property arrayTypeOpt As ArrayTypeSymbol

    Public ReadOnly Property preserve As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRedimClause(Me)
    End Function
    Public Function Update As BoundRedimClause
      If (operand Is Me.Operand) AndAlso (indices = Me.Indices) AndAlso (arrayTypeOpt Is Me.ArrayTypeOpt) AndAlso (preserve = Me.Preserve) Then Return Me
      Dim result As New BoundRedimClause
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundEraseStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.EraseStatement, syntax, hasErrors OrElse clauses.NonNullAndHasErrors())
      Debug.Assert(Not clauses.IsDefault, $"Field '{NameOf(clauses)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Clauses = clauses
    End Sub
    Public ReadOnly Property clauses As ImmutableArray(Of BoundAssignmentOperator)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitEraseStatement(Me)
    End Function
    Public Function Update As BoundEraseStatement
      If (clauses = Me.Clauses) Then Return Me
      Dim result As New BoundEraseStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundCall : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Call, syntax, type, hasErrors OrElse methodGroupOpt.NonNullAndHasErrors() OrElse receiverOpt.NonNullAndHasErrors() OrElse arguments.NonNullAndHasErrors())
      Debug.Assert(method IsNot Nothing, $"Field '{NameOf(method)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Method = method
      _MethodGroupOpt = methodGroupOpt
      _ReceiverOpt = receiverOpt
      _Arguments = arguments
      _DefaultArguments = defaultArguments
      _ConstantValueOpt = constantValueOpt
      _IsLValue = isLValue
      _SuppressObjectClone = suppressObjectClone
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property method As MethodSymbol

    Public ReadOnly Property methodGroupOpt As BoundMethodGroup

    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property arguments As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property defaultArguments As BitVector

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public Overrides ReadOnly Property isLValue As Boolean

    Public ReadOnly Property suppressObjectClone As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitCall(Me)
    End Function
    Public Function Update As BoundCall
      If (method Is Me.Method) AndAlso (methodGroupOpt Is Me.MethodGroupOpt) AndAlso (receiverOpt Is Me.ReceiverOpt) AndAlso (arguments = Me.Arguments) AndAlso (defaultArguments = Me.DefaultArguments) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (isLValue = Me.IsLValue) AndAlso (suppressObjectClone = Me.SuppressObjectClone) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundCall
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAttribute : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Attribute, syntax, type, hasErrors OrElse constructorArguments.NonNullAndHasErrors() OrElse namedArguments.NonNullAndHasErrors())
      Debug.Assert(Not constructorArguments.IsDefault, $"Field '{NameOf(constructorArguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not namedArguments.IsDefault, $"Field '{NameOf(namedArguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Constructor = constructor
      _ConstructorArguments = constructorArguments
      _NamedArguments = namedArguments
      _ResultKind = resultKind
    End Sub
    Public ReadOnly Property constructor As MethodSymbol

    Public ReadOnly Property constructorArguments As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property namedArguments As ImmutableArray(Of BoundExpression)

    Public Overrides ReadOnly Property resultKind As LookupResultKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAttribute(Me)
    End Function
    Public Function Update As BoundAttribute
      If (constructor Is Me.Constructor) AndAlso (constructorArguments = Me.ConstructorArguments) AndAlso (namedArguments = Me.NamedArguments) AndAlso (resultKind = Me.ResultKind) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAttribute
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLateMemberAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.LateMemberAccess, syntax, type, hasErrors OrElse receiverOpt.NonNullAndHasErrors() OrElse typeArgumentsOpt.NonNullAndHasErrors())
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _NameOpt = nameOpt
      _ContainerTypeOpt = containerTypeOpt
      _ReceiverOpt = receiverOpt
      _TypeArgumentsOpt = typeArgumentsOpt
      _AccessKind = accessKind
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property nameOpt As String

    Public ReadOnly Property containerTypeOpt As TypeSymbol

    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property typeArgumentsOpt As BoundTypeArguments

    Public ReadOnly Property accessKind As LateBoundAccessKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLateMemberAccess(Me)
    End Function
    Public Function Update As BoundLateMemberAccess
      If (nameOpt Is Me.NameOpt) AndAlso (containerTypeOpt Is Me.ContainerTypeOpt) AndAlso (receiverOpt Is Me.ReceiverOpt) AndAlso (typeArgumentsOpt Is Me.TypeArgumentsOpt) AndAlso (accessKind = Me.AccessKind) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLateMemberAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLateInvocation : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.LateInvocation, syntax, type, hasErrors OrElse member.NonNullAndHasErrors() OrElse argumentsOpt.NonNullAndHasErrors() OrElse methodOrPropertyGroupOpt.NonNullAndHasErrors())
      Debug.Assert(member IsNot Nothing, $"Field '{NameOf(member)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Member = member
      _ArgumentsOpt = argumentsOpt
      _ArgumentNamesOpt = argumentNamesOpt
      _AccessKind = accessKind
      _MethodOrPropertyGroupOpt = methodOrPropertyGroupOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property member As BoundExpression

    Public ReadOnly Property argumentsOpt As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property argumentNamesOpt As ImmutableArray(Of string)

    Public ReadOnly Property accessKind As LateBoundAccessKind

    Public ReadOnly Property methodOrPropertyGroupOpt As BoundMethodOrPropertyGroup

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLateInvocation(Me)
    End Function
    Public Function Update As BoundLateInvocation
      If (member Is Me.Member) AndAlso (argumentsOpt = Me.ArgumentsOpt) AndAlso (argumentNamesOpt = Me.ArgumentNamesOpt) AndAlso (accessKind = Me.AccessKind) AndAlso (methodOrPropertyGroupOpt Is Me.MethodOrPropertyGroupOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLateInvocation
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLateAddressOfOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.LateAddressOfOperator, syntax, type, hasErrors OrElse memberAccess.NonNullAndHasErrors())
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(memberAccess IsNot Nothing, $"Field '{NameOf(memberAccess)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _MemberAccess = memberAccess
    End Sub
    Public ReadOnly Property binder As Binder

    Public ReadOnly Property memberAccess As BoundLateMemberAccess

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLateAddressOfOperator(Me)
    End Function
    Public Function Update As BoundLateAddressOfOperator
      If (binder Is Me.Binder) AndAlso (memberAccess Is Me.MemberAccess) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLateAddressOfOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundTupleExpression : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Arguments = arguments
    End Sub
    Public ReadOnly Property arguments As ImmutableArray(Of BoundExpression)

  End Class

  Friend NotInheritable Partial Class BoundTupleLiteral : Inherits BoundTupleExpression

    Public Sub New
      MyBase.New(BoundKind.TupleLiteral, syntax, arguments, type, hasErrors OrElse arguments.NonNullAndHasErrors())
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _InferredType = inferredType
      _ArgumentNamesOpt = argumentNamesOpt
      _InferredNamesOpt = inferredNamesOpt
    End Sub
    Public ReadOnly Property inferredType As TupleTypeSymbol

    Public ReadOnly Property argumentNamesOpt As ImmutableArray(Of String)

    Public ReadOnly Property inferredNamesOpt As ImmutableArray(Of Boolean)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTupleLiteral(Me)
    End Function
    Public Function Update As BoundTupleLiteral
      If (inferredType Is Me.InferredType) AndAlso (argumentNamesOpt = Me.ArgumentNamesOpt) AndAlso (inferredNamesOpt = Me.InferredNamesOpt) AndAlso (arguments = Me.Arguments) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTupleLiteral
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundConvertedTupleLiteral : Inherits BoundTupleExpression

    Public Sub New
      MyBase.New(BoundKind.ConvertedTupleLiteral, syntax, arguments, type, hasErrors OrElse arguments.NonNullAndHasErrors())
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _NaturalTypeOpt = naturalTypeOpt
    End Sub
    Public ReadOnly Property naturalTypeOpt As TypeSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitConvertedTupleLiteral(Me)
    End Function
    Public Function Update As BoundConvertedTupleLiteral
      If (naturalTypeOpt Is Me.NaturalTypeOpt) AndAlso (arguments = Me.Arguments) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundConvertedTupleLiteral
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundObjectCreationExpressionBase : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _InitializerOpt = initializerOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property initializerOpt As BoundObjectInitializerExpressionBase

  End Class

  Friend NotInheritable Partial Class BoundObjectCreationExpression : Inherits BoundObjectCreationExpressionBase

    Public Sub New
      MyBase.New(BoundKind.ObjectCreationExpression, syntax, initializerOpt, type, hasErrors OrElse methodGroupOpt.NonNullAndHasErrors() OrElse arguments.NonNullAndHasErrors() OrElse initializerOpt.NonNullAndHasErrors())
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ConstructorOpt = constructorOpt
      _MethodGroupOpt = methodGroupOpt
      _Arguments = arguments
      _DefaultArguments = defaultArguments
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property constructorOpt As MethodSymbol

    Public ReadOnly Property methodGroupOpt As BoundMethodGroup

    Public ReadOnly Property arguments As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property defaultArguments As BitVector

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitObjectCreationExpression(Me)
    End Function
    Public Function Update As BoundObjectCreationExpression
      If (constructorOpt Is Me.ConstructorOpt) AndAlso (methodGroupOpt Is Me.MethodGroupOpt) AndAlso (arguments = Me.Arguments) AndAlso (defaultArguments = Me.DefaultArguments) AndAlso (initializerOpt Is Me.InitializerOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundObjectCreationExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundNoPiaObjectCreationExpression : Inherits BoundObjectCreationExpressionBase

    Public Sub New
      MyBase.New(BoundKind.NoPiaObjectCreationExpression, syntax, initializerOpt, type, hasErrors OrElse initializerOpt.NonNullAndHasErrors())
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _GuidString = guidString
    End Sub
    Public ReadOnly Property guidString As string

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitNoPiaObjectCreationExpression(Me)
    End Function
    Public Function Update As BoundNoPiaObjectCreationExpression
      If (guidString Is Me.GuidString) AndAlso (initializerOpt Is Me.InitializerOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundNoPiaObjectCreationExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAnonymousTypeCreationExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.AnonymousTypeCreationExpression, syntax, type, hasErrors OrElse declarations.NonNullAndHasErrors() OrElse arguments.NonNullAndHasErrors())
      Debug.Assert(Not declarations.IsDefault, $"Field '{NameOf(declarations)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _BinderOpt = binderOpt
      _Declarations = declarations
      _Arguments = arguments
    End Sub
    Public ReadOnly Property binderOpt As Binder.AnonymousTypeCreationBinder

    Public ReadOnly Property declarations As ImmutableArray(Of BoundAnonymousTypePropertyAccess)

    Public ReadOnly Property arguments As ImmutableArray(Of BoundExpression)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAnonymousTypeCreationExpression(Me)
    End Function
    Public Function Update As BoundAnonymousTypeCreationExpression
      If (binderOpt Is Me.BinderOpt) AndAlso (declarations = Me.Declarations) AndAlso (arguments = Me.Arguments) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAnonymousTypeCreationExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAnonymousTypePropertyAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.AnonymousTypePropertyAccess, syntax, type, hasErrors)
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _PropertyIndex = propertyIndex
    End Sub
    Public Sub New
      MyBase.New(BoundKind.AnonymousTypePropertyAccess, syntax, type)
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _PropertyIndex = propertyIndex
    End Sub
    Public ReadOnly Property binder As Binder.AnonymousTypeCreationBinder

    Public ReadOnly Property propertyIndex As Integer

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAnonymousTypePropertyAccess(Me)
    End Function
    Public Function Update As BoundAnonymousTypePropertyAccess
      If (binder Is Me.Binder) AndAlso (propertyIndex = Me.PropertyIndex) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAnonymousTypePropertyAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAnonymousTypeFieldInitializer : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.AnonymousTypeFieldInitializer, syntax, type, hasErrors OrElse value.NonNullAndHasErrors())
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _Value = value
    End Sub
    Public ReadOnly Property binder As Binder.AnonymousTypeFieldInitializerBinder

    Public ReadOnly Property value As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAnonymousTypeFieldInitializer(Me)
    End Function
    Public Function Update As BoundAnonymousTypeFieldInitializer
      If (binder Is Me.Binder) AndAlso (value Is Me.Value) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAnonymousTypeFieldInitializer
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundObjectInitializerExpressionBase : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(Not initializers.IsDefault, $"Field '{NameOf(initializers)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _PlaceholderOpt = placeholderOpt
      _Initializers = initializers
    End Sub
    Public ReadOnly Property placeholderOpt As BoundWithLValueExpressionPlaceholder

    Public ReadOnly Property initializers As ImmutableArray(Of BoundExpression)

  End Class

  Friend NotInheritable Partial Class BoundObjectInitializerExpression : Inherits BoundObjectInitializerExpressionBase

    Public Sub New
      MyBase.New(BoundKind.ObjectInitializerExpression, syntax, placeholderOpt, initializers, type, hasErrors OrElse placeholderOpt.NonNullAndHasErrors() OrElse initializers.NonNullAndHasErrors())
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not initializers.IsDefault, $"Field '{NameOf(initializers)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _CreateTemporaryLocalForInitialization = createTemporaryLocalForInitialization
      _Binder = binder
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property createTemporaryLocalForInitialization As Boolean

    Public ReadOnly Property binder As Binder

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitObjectInitializerExpression(Me)
    End Function
    Public Function Update As BoundObjectInitializerExpression
      If (createTemporaryLocalForInitialization = Me.CreateTemporaryLocalForInitialization) AndAlso (binder Is Me.Binder) AndAlso (placeholderOpt Is Me.PlaceholderOpt) AndAlso (initializers = Me.Initializers) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundObjectInitializerExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundCollectionInitializerExpression : Inherits BoundObjectInitializerExpressionBase

    Public Sub New
      MyBase.New(BoundKind.CollectionInitializerExpression, syntax, placeholderOpt, initializers, type, hasErrors OrElse placeholderOpt.NonNullAndHasErrors() OrElse initializers.NonNullAndHasErrors())
      Debug.Assert(Not initializers.IsDefault, $"Field '{NameOf(initializers)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitCollectionInitializerExpression(Me)
    End Function
    Public Function Update As BoundCollectionInitializerExpression
      If (placeholderOpt Is Me.PlaceholderOpt) AndAlso (initializers = Me.Initializers) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundCollectionInitializerExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundNewT : Inherits BoundObjectCreationExpressionBase

    Public Sub New
      MyBase.New(BoundKind.NewT, syntax, initializerOpt, type, hasErrors OrElse initializerOpt.NonNullAndHasErrors())
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitNewT(Me)
    End Function
    Public Function Update As BoundNewT
      If (initializerOpt Is Me.InitializerOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundNewT
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundDelegateCreationExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.DelegateCreationExpression, syntax, type, hasErrors OrElse receiverOpt.NonNullAndHasErrors() OrElse relaxationLambdaOpt.NonNullAndHasErrors() OrElse relaxationReceiverPlaceholderOpt.NonNullAndHasErrors() OrElse methodGroupOpt.NonNullAndHasErrors())
      Debug.Assert(method IsNot Nothing, $"Field '{NameOf(method)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ReceiverOpt = receiverOpt
      _Method = method
      _RelaxationLambdaOpt = relaxationLambdaOpt
      _RelaxationReceiverPlaceholderOpt = relaxationReceiverPlaceholderOpt
      _MethodGroupOpt = methodGroupOpt
    End Sub
    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property method As MethodSymbol

    Public ReadOnly Property relaxationLambdaOpt As BoundLambda

    Public ReadOnly Property relaxationReceiverPlaceholderOpt As BoundRValuePlaceholder

    Public ReadOnly Property methodGroupOpt As BoundMethodGroup

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitDelegateCreationExpression(Me)
    End Function
    Public Function Update As BoundDelegateCreationExpression
      If (receiverOpt Is Me.ReceiverOpt) AndAlso (method Is Me.Method) AndAlso (relaxationLambdaOpt Is Me.RelaxationLambdaOpt) AndAlso (relaxationReceiverPlaceholderOpt Is Me.RelaxationReceiverPlaceholderOpt) AndAlso (methodGroupOpt Is Me.MethodGroupOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundDelegateCreationExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundArrayCreation : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ArrayCreation, syntax, type, hasErrors OrElse bounds.NonNullAndHasErrors() OrElse initializerOpt.NonNullAndHasErrors() OrElse arrayLiteralOpt.NonNullAndHasErrors())
      Debug.Assert(Not bounds.IsDefault, $"Field '{NameOf(bounds)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _IsParamArrayArgument = isParamArrayArgument
      _Bounds = bounds
      _InitializerOpt = initializerOpt
      _ArrayLiteralOpt = arrayLiteralOpt
      _ArrayLiteralConversion = arrayLiteralConversion
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property isParamArrayArgument As Boolean

    Public ReadOnly Property bounds As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property initializerOpt As BoundArrayInitialization

    Public ReadOnly Property arrayLiteralOpt As BoundArrayLiteral

    Public ReadOnly Property arrayLiteralConversion As ConversionKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitArrayCreation(Me)
    End Function
    Public Function Update As BoundArrayCreation
      If (isParamArrayArgument = Me.IsParamArrayArgument) AndAlso (bounds = Me.Bounds) AndAlso (initializerOpt Is Me.InitializerOpt) AndAlso (arrayLiteralOpt Is Me.ArrayLiteralOpt) AndAlso (arrayLiteralConversion = Me.ArrayLiteralConversion) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundArrayCreation
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundArrayLiteral : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ArrayLiteral, syntax, Nothing, hasErrors OrElse bounds.NonNullAndHasErrors() OrElse initializer.NonNullAndHasErrors())
      Debug.Assert(inferredType IsNot Nothing, $"Field '{NameOf(inferredType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not bounds.IsDefault, $"Field '{NameOf(bounds)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(initializer IsNot Nothing, $"Field '{NameOf(initializer)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _HasDominantType = hasDominantType
      _NumberOfCandidates = numberOfCandidates
      _InferredType = inferredType
      _Bounds = bounds
      _Initializer = initializer
      _Binder = binder
    End Sub
    Public ReadOnly Property hasDominantType As Boolean

    Public ReadOnly Property numberOfCandidates As Integer

    Public ReadOnly Property inferredType As ArrayTypeSymbol

    Public ReadOnly Property bounds As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property initializer As BoundArrayInitialization

    Public ReadOnly Property binder As Binder

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitArrayLiteral(Me)
    End Function
    Public Function Update As BoundArrayLiteral
      If (hasDominantType = Me.HasDominantType) AndAlso (numberOfCandidates = Me.NumberOfCandidates) AndAlso (inferredType Is Me.InferredType) AndAlso (bounds = Me.Bounds) AndAlso (initializer Is Me.Initializer) AndAlso (binder Is Me.Binder) Then Return Me
      Dim result As New BoundArrayLiteral
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundArrayInitialization : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ArrayInitialization, syntax, type, hasErrors OrElse initializers.NonNullAndHasErrors())
      Debug.Assert(Not initializers.IsDefault, $"Field '{NameOf(initializers)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Initializers = initializers
    End Sub
    Public ReadOnly Property initializers As ImmutableArray(Of BoundExpression)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitArrayInitialization(Me)
    End Function
    Public Function Update As BoundArrayInitialization
      If (initializers = Me.Initializers) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundArrayInitialization
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundFieldAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.FieldAccess, syntax, type, hasErrors OrElse receiverOpt.NonNullAndHasErrors())
      Debug.Assert(fieldSymbol IsNot Nothing, $"Field '{NameOf(fieldSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ReceiverOpt = receiverOpt
      _FieldSymbol = fieldSymbol
      _IsLValue = isLValue
      _SuppressVirtualCalls = suppressVirtualCalls
      _ConstantsInProgressOpt = constantsInProgressOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property fieldSymbol As FieldSymbol

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides ReadOnly Property suppressVirtualCalls As Boolean

    Public ReadOnly Property constantsInProgressOpt As SymbolsInProgress(Of FieldSymbol)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitFieldAccess(Me)
    End Function
    Public Function Update As BoundFieldAccess
      If (receiverOpt Is Me.ReceiverOpt) AndAlso (fieldSymbol Is Me.FieldSymbol) AndAlso (isLValue = Me.IsLValue) AndAlso (suppressVirtualCalls = Me.SuppressVirtualCalls) AndAlso (constantsInProgressOpt Is Me.ConstantsInProgressOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundFieldAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundPropertyAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.PropertyAccess, syntax, type, hasErrors OrElse propertyGroupOpt.NonNullAndHasErrors() OrElse receiverOpt.NonNullAndHasErrors() OrElse arguments.NonNullAndHasErrors())
      Debug.Assert(propertySymbol IsNot Nothing, $"Field '{NameOf(propertySymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not arguments.IsDefault, $"Field '{NameOf(arguments)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _PropertySymbol = propertySymbol
      _PropertyGroupOpt = propertyGroupOpt
      _AccessKind = accessKind
      _IsWriteable = isWriteable
      _IsLValue = isLValue
      _ReceiverOpt = receiverOpt
      _Arguments = arguments
      _DefaultArguments = defaultArguments
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property propertySymbol As PropertySymbol

    Public ReadOnly Property propertyGroupOpt As BoundPropertyGroup

    Public ReadOnly Property accessKind As PropertyAccessKind

    Public ReadOnly Property isWriteable As Boolean

    Public Overrides ReadOnly Property isLValue As Boolean

    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property arguments As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property defaultArguments As BitVector

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitPropertyAccess(Me)
    End Function
    Public Function Update As BoundPropertyAccess
      If (propertySymbol Is Me.PropertySymbol) AndAlso (propertyGroupOpt Is Me.PropertyGroupOpt) AndAlso (accessKind = Me.AccessKind) AndAlso (isWriteable = Me.IsWriteable) AndAlso (isLValue = Me.IsLValue) AndAlso (receiverOpt Is Me.ReceiverOpt) AndAlso (arguments = Me.Arguments) AndAlso (defaultArguments = Me.DefaultArguments) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundPropertyAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundEventAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.EventAccess, syntax, type, hasErrors OrElse receiverOpt.NonNullAndHasErrors())
      Debug.Assert(eventSymbol IsNot Nothing, $"Field '{NameOf(eventSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ReceiverOpt = receiverOpt
      _EventSymbol = eventSymbol
    End Sub
    Public ReadOnly Property receiverOpt As BoundExpression

    Public ReadOnly Property eventSymbol As EventSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitEventAccess(Me)
    End Function
    Public Function Update As BoundEventAccess
      If (receiverOpt Is Me.ReceiverOpt) AndAlso (eventSymbol Is Me.EventSymbol) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundEventAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundBlock : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.Block, syntax, hasErrors OrElse statements.NonNullAndHasErrors())
      Debug.Assert(Not locals.IsDefault, $"Field '{NameOf(locals)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not statements.IsDefault, $"Field '{NameOf(statements)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _StatementListSyntax = statementListSyntax
      _Locals = locals
      _Statements = statements
    End Sub
    Public ReadOnly Property statementListSyntax As SyntaxList(Of StatementSyntax)

    Public ReadOnly Property locals As ImmutableArray(Of LocalSymbol)

    Public ReadOnly Property statements As ImmutableArray(Of BoundStatement)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitBlock(Me)
    End Function
    Public Function Update As BoundBlock
      If (statementListSyntax = Me.StatementListSyntax) AndAlso (locals = Me.Locals) AndAlso (statements = Me.Statements) Then Return Me
      Dim result As New BoundBlock
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundStateMachineScope : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.StateMachineScope, syntax, hasErrors OrElse statement.NonNullAndHasErrors())
      Debug.Assert(Not fields.IsDefault, $"Field '{NameOf(fields)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(statement IsNot Nothing, $"Field '{NameOf(statement)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Fields = fields
      _Statement = statement
    End Sub
    Public ReadOnly Property fields As ImmutableArray(Of FieldSymbol)

    Public ReadOnly Property statement As BoundStatement

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitStateMachineScope(Me)
    End Function
    Public Function Update As BoundStateMachineScope
      If (fields = Me.Fields) AndAlso (statement Is Me.Statement) Then Return Me
      Dim result As New BoundStateMachineScope
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundLocalDeclarationBase : Inherits BoundStatement

    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundLocalDeclaration : Inherits BoundLocalDeclarationBase

    Public Sub New
      MyBase.New(BoundKind.LocalDeclaration, syntax, hasErrors OrElse declarationInitializerOpt.NonNullAndHasErrors() OrElse identifierInitializerOpt.NonNullAndHasErrors())
      Debug.Assert(localSymbol IsNot Nothing, $"Field '{NameOf(localSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalSymbol = localSymbol
      _DeclarationInitializerOpt = declarationInitializerOpt
      _IdentifierInitializerOpt = identifierInitializerOpt
      _InitializedByAsNew = initializedByAsNew
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property localSymbol As LocalSymbol

    Public ReadOnly Property declarationInitializerOpt As BoundExpression

    Public ReadOnly Property identifierInitializerOpt As BoundArrayCreation

    Public ReadOnly Property initializedByAsNew As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLocalDeclaration(Me)
    End Function
    Public Function Update As BoundLocalDeclaration
      If (localSymbol Is Me.LocalSymbol) AndAlso (declarationInitializerOpt Is Me.DeclarationInitializerOpt) AndAlso (identifierInitializerOpt Is Me.IdentifierInitializerOpt) AndAlso (initializedByAsNew = Me.InitializedByAsNew) Then Return Me
      Dim result As New BoundLocalDeclaration
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAsNewLocalDeclarations : Inherits BoundLocalDeclarationBase

    Public Sub New
      MyBase.New(BoundKind.AsNewLocalDeclarations, syntax, hasErrors OrElse localDeclarations.NonNullAndHasErrors() OrElse initializer.NonNullAndHasErrors())
      Debug.Assert(Not localDeclarations.IsDefault, $"Field '{NameOf(localDeclarations)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(initializer IsNot Nothing, $"Field '{NameOf(initializer)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalDeclarations = localDeclarations
      _Initializer = initializer
    End Sub
    Public ReadOnly Property localDeclarations As ImmutableArray(Of BoundLocalDeclaration)

    Public ReadOnly Property initializer As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAsNewLocalDeclarations(Me)
    End Function
    Public Function Update As BoundAsNewLocalDeclarations
      If (localDeclarations = Me.LocalDeclarations) AndAlso (initializer Is Me.Initializer) Then Return Me
      Dim result As New BoundAsNewLocalDeclarations
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundDimStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.DimStatement, syntax, hasErrors OrElse localDeclarations.NonNullAndHasErrors() OrElse initializerOpt.NonNullAndHasErrors())
      Debug.Assert(Not localDeclarations.IsDefault, $"Field '{NameOf(localDeclarations)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalDeclarations = localDeclarations
      _InitializerOpt = initializerOpt
    End Sub
    Public ReadOnly Property localDeclarations As ImmutableArray(Of BoundLocalDeclarationBase)

    Public ReadOnly Property initializerOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitDimStatement(Me)
    End Function
    Public Function Update As BoundDimStatement
      If (localDeclarations = Me.LocalDeclarations) AndAlso (initializerOpt Is Me.InitializerOpt) Then Return Me
      Dim result As New BoundDimStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend Partial Class BoundInitializer : Inherits BoundStatement

    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Initializer, syntax, hasErrors)
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Initializer, syntax)
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitInitializer(Me)
    End Function
  End Class

  Friend MustInherit Partial Class BoundFieldOrPropertyInitializer : Inherits BoundInitializer

    Protected Sub New
      MyBase.New(kind, syntax)
      Debug.Assert(initialValue IsNot Nothing, $"Field '{NameOf(initialValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _MemberAccessExpressionOpt = memberAccessExpressionOpt
      _InitialValue = initialValue
    End Sub
    Public ReadOnly Property memberAccessExpressionOpt As BoundExpression

    Public ReadOnly Property initialValue As BoundExpression

  End Class

  Friend NotInheritable Partial Class BoundFieldInitializer : Inherits BoundFieldOrPropertyInitializer

    Public Sub New
      MyBase.New(BoundKind.FieldInitializer, syntax, memberAccessExpressionOpt, initialValue, hasErrors OrElse memberAccessExpressionOpt.NonNullAndHasErrors() OrElse initialValue.NonNullAndHasErrors())
      Debug.Assert(Not initializedFields.IsDefault, $"Field '{NameOf(initializedFields)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(initialValue IsNot Nothing, $"Field '{NameOf(initialValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _InitializedFields = initializedFields
    End Sub
    Public ReadOnly Property initializedFields As ImmutableArray(Of FieldSymbol)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitFieldInitializer(Me)
    End Function
    Public Function Update As BoundFieldInitializer
      If (initializedFields = Me.InitializedFields) AndAlso (memberAccessExpressionOpt Is Me.MemberAccessExpressionOpt) AndAlso (initialValue Is Me.InitialValue) Then Return Me
      Dim result As New BoundFieldInitializer
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundPropertyInitializer : Inherits BoundFieldOrPropertyInitializer

    Public Sub New
      MyBase.New(BoundKind.PropertyInitializer, syntax, memberAccessExpressionOpt, initialValue, hasErrors OrElse memberAccessExpressionOpt.NonNullAndHasErrors() OrElse initialValue.NonNullAndHasErrors())
      Debug.Assert(Not initializedProperties.IsDefault, $"Field '{NameOf(initializedProperties)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(initialValue IsNot Nothing, $"Field '{NameOf(initialValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _InitializedProperties = initializedProperties
    End Sub
    Public ReadOnly Property initializedProperties As ImmutableArray(Of PropertySymbol)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitPropertyInitializer(Me)
    End Function
    Public Function Update As BoundPropertyInitializer
      If (initializedProperties = Me.InitializedProperties) AndAlso (memberAccessExpressionOpt Is Me.MemberAccessExpressionOpt) AndAlso (initialValue Is Me.InitialValue) Then Return Me
      Dim result As New BoundPropertyInitializer
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundParameterEqualsValue : Inherits BoundNode

    Public Sub New
      MyBase.New(BoundKind.ParameterEqualsValue, syntax, hasErrors OrElse value.NonNullAndHasErrors())
      Debug.Assert(parameter IsNot Nothing, $"Field '{NameOf(parameter)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Parameter = parameter
      _Value = value
    End Sub
    Public ReadOnly Property parameter As ParameterSymbol

    Public ReadOnly Property value As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitParameterEqualsValue(Me)
    End Function
    Public Function Update As BoundParameterEqualsValue
      If (parameter Is Me.Parameter) AndAlso (value Is Me.Value) Then Return Me
      Dim result As New BoundParameterEqualsValue
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundGlobalStatementInitializer : Inherits BoundInitializer

    Public Sub New
      MyBase.New(BoundKind.GlobalStatementInitializer, syntax, hasErrors OrElse statement.NonNullAndHasErrors())
      Debug.Assert(statement IsNot Nothing, $"Field '{NameOf(statement)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Statement = statement
    End Sub
    Public ReadOnly Property statement As BoundStatement

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitGlobalStatementInitializer(Me)
    End Function
    Public Function Update As BoundGlobalStatementInitializer
      If (statement Is Me.Statement) Then Return Me
      Dim result As New BoundGlobalStatementInitializer
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSequence : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Sequence, syntax, type, hasErrors OrElse sideEffects.NonNullAndHasErrors() OrElse valueOpt.NonNullAndHasErrors())
      Debug.Assert(Not locals.IsDefault, $"Field '{NameOf(locals)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not sideEffects.IsDefault, $"Field '{NameOf(sideEffects)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Locals = locals
      _SideEffects = sideEffects
      _ValueOpt = valueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property locals As ImmutableArray(Of LocalSymbol)

    Public ReadOnly Property sideEffects As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property valueOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSequence(Me)
    End Function
    Public Function Update As BoundSequence
      If (locals = Me.Locals) AndAlso (sideEffects = Me.SideEffects) AndAlso (valueOpt Is Me.ValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundSequence
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundExpressionStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ExpressionStatement, syntax, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitExpressionStatement(Me)
    End Function
    Public Function Update As BoundExpressionStatement
      If (expression Is Me.Expression) Then Return Me
      Dim result As New BoundExpressionStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundIfStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.IfStatement, syntax, hasErrors OrElse condition.NonNullAndHasErrors() OrElse consequence.NonNullAndHasErrors() OrElse alternativeOpt.NonNullAndHasErrors())
      Debug.Assert(condition IsNot Nothing, $"Field '{NameOf(condition)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(consequence IsNot Nothing, $"Field '{NameOf(consequence)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Condition = condition
      _Consequence = consequence
      _AlternativeOpt = alternativeOpt
    End Sub
    Public ReadOnly Property condition As BoundExpression

    Public ReadOnly Property consequence As BoundStatement

    Public ReadOnly Property alternativeOpt As BoundStatement

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitIfStatement(Me)
    End Function
    Public Function Update As BoundIfStatement
      If (condition Is Me.Condition) AndAlso (consequence Is Me.Consequence) AndAlso (alternativeOpt Is Me.AlternativeOpt) Then Return Me
      Dim result As New BoundIfStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSelectStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.SelectStatement, syntax, hasErrors OrElse expressionStatement.NonNullAndHasErrors() OrElse exprPlaceholderOpt.NonNullAndHasErrors() OrElse caseBlocks.NonNullAndHasErrors())
      Debug.Assert(expressionStatement IsNot Nothing, $"Field '{NameOf(expressionStatement)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not caseBlocks.IsDefault, $"Field '{NameOf(caseBlocks)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ExpressionStatement = expressionStatement
      _ExprPlaceholderOpt = exprPlaceholderOpt
      _CaseBlocks = caseBlocks
      _RecommendSwitchTable = recommendSwitchTable
      _ExitLabel = exitLabel
    End Sub
    Public ReadOnly Property expressionStatement As BoundExpressionStatement

    Public ReadOnly Property exprPlaceholderOpt As BoundRValuePlaceholder

    Public ReadOnly Property caseBlocks As ImmutableArray(Of BoundCaseBlock)

    Public ReadOnly Property recommendSwitchTable As Boolean

    Public ReadOnly Property exitLabel As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSelectStatement(Me)
    End Function
    Public Function Update As BoundSelectStatement
      If (expressionStatement Is Me.ExpressionStatement) AndAlso (exprPlaceholderOpt Is Me.ExprPlaceholderOpt) AndAlso (caseBlocks = Me.CaseBlocks) AndAlso (recommendSwitchTable = Me.RecommendSwitchTable) AndAlso (exitLabel Is Me.ExitLabel) Then Return Me
      Dim result As New BoundSelectStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundCaseBlock : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.CaseBlock, syntax, hasErrors OrElse caseStatement.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(caseStatement IsNot Nothing, $"Field '{NameOf(caseStatement)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _CaseStatement = caseStatement
      _Body = body
    End Sub
    Public ReadOnly Property caseStatement As BoundCaseStatement

    Public ReadOnly Property body As BoundBlock

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitCaseBlock(Me)
    End Function
    Public Function Update As BoundCaseBlock
      If (caseStatement Is Me.CaseStatement) AndAlso (body Is Me.Body) Then Return Me
      Dim result As New BoundCaseBlock
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundCaseStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.CaseStatement, syntax, hasErrors OrElse caseClauses.NonNullAndHasErrors() OrElse conditionOpt.NonNullAndHasErrors())
      Debug.Assert(Not caseClauses.IsDefault, $"Field '{NameOf(caseClauses)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _CaseClauses = caseClauses
      _ConditionOpt = conditionOpt
    End Sub
    Public ReadOnly Property caseClauses As ImmutableArray(Of BoundCaseClause)

    Public ReadOnly Property conditionOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitCaseStatement(Me)
    End Function
    Public Function Update As BoundCaseStatement
      If (caseClauses = Me.CaseClauses) AndAlso (conditionOpt Is Me.ConditionOpt) Then Return Me
      Dim result As New BoundCaseStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundCaseClause : Inherits BoundNode

    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
    End Sub
  End Class

  Friend MustInherit Partial Class BoundSingleValueCaseClause : Inherits BoundCaseClause

    Protected Sub New
      MyBase.New(kind, syntax)
      _ValueOpt = valueOpt
      _ConditionOpt = conditionOpt
    End Sub
    Public ReadOnly Property valueOpt As BoundExpression

    Public ReadOnly Property conditionOpt As BoundExpression

  End Class

  Friend NotInheritable Partial Class BoundSimpleCaseClause : Inherits BoundSingleValueCaseClause

    Public Sub New
      MyBase.New(BoundKind.SimpleCaseClause, syntax, valueOpt, conditionOpt, hasErrors OrElse valueOpt.NonNullAndHasErrors() OrElse conditionOpt.NonNullAndHasErrors())
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSimpleCaseClause(Me)
    End Function
    Public Function Update As BoundSimpleCaseClause
      If (valueOpt Is Me.ValueOpt) AndAlso (conditionOpt Is Me.ConditionOpt) Then Return Me
      Dim result As New BoundSimpleCaseClause
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRangeCaseClause : Inherits BoundCaseClause

    Public Sub New
      MyBase.New(BoundKind.RangeCaseClause, syntax, hasErrors OrElse lowerBoundOpt.NonNullAndHasErrors() OrElse upperBoundOpt.NonNullAndHasErrors() OrElse lowerBoundConditionOpt.NonNullAndHasErrors() OrElse upperBoundConditionOpt.NonNullAndHasErrors())
      _LowerBoundOpt = lowerBoundOpt
      _UpperBoundOpt = upperBoundOpt
      _LowerBoundConditionOpt = lowerBoundConditionOpt
      _UpperBoundConditionOpt = upperBoundConditionOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property lowerBoundOpt As BoundExpression

    Public ReadOnly Property upperBoundOpt As BoundExpression

    Public ReadOnly Property lowerBoundConditionOpt As BoundExpression

    Public ReadOnly Property upperBoundConditionOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRangeCaseClause(Me)
    End Function
    Public Function Update As BoundRangeCaseClause
      If (lowerBoundOpt Is Me.LowerBoundOpt) AndAlso (upperBoundOpt Is Me.UpperBoundOpt) AndAlso (lowerBoundConditionOpt Is Me.LowerBoundConditionOpt) AndAlso (upperBoundConditionOpt Is Me.UpperBoundConditionOpt) Then Return Me
      Dim result As New BoundRangeCaseClause
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRelationalCaseClause : Inherits BoundSingleValueCaseClause

    Public Sub New
      MyBase.New(BoundKind.RelationalCaseClause, syntax, valueOpt, conditionOpt, hasErrors OrElse valueOpt.NonNullAndHasErrors() OrElse conditionOpt.NonNullAndHasErrors())
      _OperatorKind = operatorKind
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operatorKind As BinaryOperatorKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRelationalCaseClause(Me)
    End Function
    Public Function Update As BoundRelationalCaseClause
      If (operatorKind = Me.OperatorKind) AndAlso (valueOpt Is Me.ValueOpt) AndAlso (conditionOpt Is Me.ConditionOpt) Then Return Me
      Dim result As New BoundRelationalCaseClause
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundLoopStatement : Inherits BoundStatement

    Protected Sub New
      MyBase.New(kind, syntax)
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ContinueLabel = continueLabel
      _ExitLabel = exitLabel
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax)
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ContinueLabel = continueLabel
      _ExitLabel = exitLabel
    End Sub
    Public ReadOnly Property continueLabel As LabelSymbol

    Public ReadOnly Property exitLabel As LabelSymbol

  End Class

  Friend NotInheritable Partial Class BoundDoLoopStatement : Inherits BoundLoopStatement

    Public Sub New
      MyBase.New(BoundKind.DoLoopStatement, syntax, continueLabel, exitLabel, hasErrors OrElse topConditionOpt.NonNullAndHasErrors() OrElse bottomConditionOpt.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _TopConditionOpt = topConditionOpt
      _BottomConditionOpt = bottomConditionOpt
      _TopConditionIsUntil = topConditionIsUntil
      _BottomConditionIsUntil = bottomConditionIsUntil
      _Body = body
    End Sub
    Public ReadOnly Property topConditionOpt As BoundExpression

    Public ReadOnly Property bottomConditionOpt As BoundExpression

    Public ReadOnly Property topConditionIsUntil As Boolean

    Public ReadOnly Property bottomConditionIsUntil As Boolean

    Public ReadOnly Property body As BoundStatement

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitDoLoopStatement(Me)
    End Function
    Public Function Update As BoundDoLoopStatement
      If (topConditionOpt Is Me.TopConditionOpt) AndAlso (bottomConditionOpt Is Me.BottomConditionOpt) AndAlso (topConditionIsUntil = Me.TopConditionIsUntil) AndAlso (bottomConditionIsUntil = Me.BottomConditionIsUntil) AndAlso (body Is Me.Body) AndAlso (continueLabel Is Me.ContinueLabel) AndAlso (exitLabel Is Me.ExitLabel) Then Return Me
      Dim result As New BoundDoLoopStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundWhileStatement : Inherits BoundLoopStatement

    Public Sub New
      MyBase.New(BoundKind.WhileStatement, syntax, continueLabel, exitLabel, hasErrors OrElse condition.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(condition IsNot Nothing, $"Field '{NameOf(condition)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Condition = condition
      _Body = body
    End Sub
    Public ReadOnly Property condition As BoundExpression

    Public ReadOnly Property body As BoundStatement

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitWhileStatement(Me)
    End Function
    Public Function Update As BoundWhileStatement
      If (condition Is Me.Condition) AndAlso (body Is Me.Body) AndAlso (continueLabel Is Me.ContinueLabel) AndAlso (exitLabel Is Me.ExitLabel) Then Return Me
      Dim result As New BoundWhileStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundForStatement : Inherits BoundLoopStatement

    Protected Sub New
      MyBase.New(kind, syntax, continueLabel, exitLabel)
      Debug.Assert(controlVariable IsNot Nothing, $"Field '{NameOf(controlVariable)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _DeclaredOrInferredLocalOpt = declaredOrInferredLocalOpt
      _ControlVariable = controlVariable
      _Body = body
      _NextVariablesOpt = nextVariablesOpt
    End Sub
    Public ReadOnly Property declaredOrInferredLocalOpt As LocalSymbol

    Public ReadOnly Property controlVariable As BoundExpression

    Public ReadOnly Property body As BoundStatement

    Public ReadOnly Property nextVariablesOpt As ImmutableArray(Of BoundExpression)

  End Class

  Friend NotInheritable Partial Class BoundForToUserDefinedOperators : Inherits BoundNode

    Public Sub New
      MyBase.New(BoundKind.ForToUserDefinedOperators, syntax, hasErrors OrElse leftOperandPlaceholder.NonNullAndHasErrors() OrElse rightOperandPlaceholder.NonNullAndHasErrors() OrElse addition.NonNullAndHasErrors() OrElse subtraction.NonNullAndHasErrors() OrElse lessThanOrEqual.NonNullAndHasErrors() OrElse greaterThanOrEqual.NonNullAndHasErrors())
      Debug.Assert(leftOperandPlaceholder IsNot Nothing, $"Field '{NameOf(leftOperandPlaceholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(rightOperandPlaceholder IsNot Nothing, $"Field '{NameOf(rightOperandPlaceholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(addition IsNot Nothing, $"Field '{NameOf(addition)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(subtraction IsNot Nothing, $"Field '{NameOf(subtraction)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(lessThanOrEqual IsNot Nothing, $"Field '{NameOf(lessThanOrEqual)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(greaterThanOrEqual IsNot Nothing, $"Field '{NameOf(greaterThanOrEqual)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LeftOperandPlaceholder = leftOperandPlaceholder
      _RightOperandPlaceholder = rightOperandPlaceholder
      _Addition = addition
      _Subtraction = subtraction
      _LessThanOrEqual = lessThanOrEqual
      _GreaterThanOrEqual = greaterThanOrEqual
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property leftOperandPlaceholder As BoundRValuePlaceholder

    Public ReadOnly Property rightOperandPlaceholder As BoundRValuePlaceholder

    Public ReadOnly Property addition As BoundUserDefinedBinaryOperator

    Public ReadOnly Property subtraction As BoundUserDefinedBinaryOperator

    Public ReadOnly Property lessThanOrEqual As BoundExpression

    Public ReadOnly Property greaterThanOrEqual As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitForToUserDefinedOperators(Me)
    End Function
    Public Function Update As BoundForToUserDefinedOperators
      If (leftOperandPlaceholder Is Me.LeftOperandPlaceholder) AndAlso (rightOperandPlaceholder Is Me.RightOperandPlaceholder) AndAlso (addition Is Me.Addition) AndAlso (subtraction Is Me.Subtraction) AndAlso (lessThanOrEqual Is Me.LessThanOrEqual) AndAlso (greaterThanOrEqual Is Me.GreaterThanOrEqual) Then Return Me
      Dim result As New BoundForToUserDefinedOperators
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundForToStatement : Inherits BoundForStatement

    Public Sub New
      MyBase.New(BoundKind.ForToStatement, syntax, declaredOrInferredLocalOpt, controlVariable, body, nextVariablesOpt, continueLabel, exitLabel, hasErrors OrElse initialValue.NonNullAndHasErrors() OrElse limitValue.NonNullAndHasErrors() OrElse stepValue.NonNullAndHasErrors() OrElse operatorsOpt.NonNullAndHasErrors() OrElse controlVariable.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors() OrElse nextVariablesOpt.NonNullAndHasErrors())
      Debug.Assert(initialValue IsNot Nothing, $"Field '{NameOf(initialValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(limitValue IsNot Nothing, $"Field '{NameOf(limitValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(stepValue IsNot Nothing, $"Field '{NameOf(stepValue)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(controlVariable IsNot Nothing, $"Field '{NameOf(controlVariable)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _InitialValue = initialValue
      _LimitValue = limitValue
      _StepValue = stepValue
      _Checked = checked
      _OperatorsOpt = operatorsOpt
    End Sub
    Public ReadOnly Property initialValue As BoundExpression

    Public ReadOnly Property limitValue As BoundExpression

    Public ReadOnly Property stepValue As BoundExpression

    Public ReadOnly Property checked As Boolean

    Public ReadOnly Property operatorsOpt As BoundForToUserDefinedOperators

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitForToStatement(Me)
    End Function
    Public Function Update As BoundForToStatement
      If (initialValue Is Me.InitialValue) AndAlso (limitValue Is Me.LimitValue) AndAlso (stepValue Is Me.StepValue) AndAlso (checked = Me.Checked) AndAlso (operatorsOpt Is Me.OperatorsOpt) AndAlso (declaredOrInferredLocalOpt Is Me.DeclaredOrInferredLocalOpt) AndAlso (controlVariable Is Me.ControlVariable) AndAlso (body Is Me.Body) AndAlso (nextVariablesOpt = Me.NextVariablesOpt) AndAlso (continueLabel Is Me.ContinueLabel) AndAlso (exitLabel Is Me.ExitLabel) Then Return Me
      Dim result As New BoundForToStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundForEachStatement : Inherits BoundForStatement

    Public Sub New
      MyBase.New(BoundKind.ForEachStatement, syntax, declaredOrInferredLocalOpt, controlVariable, body, nextVariablesOpt, continueLabel, exitLabel, hasErrors OrElse collection.NonNullAndHasErrors() OrElse controlVariable.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors() OrElse nextVariablesOpt.NonNullAndHasErrors())
      Debug.Assert(collection IsNot Nothing, $"Field '{NameOf(collection)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(enumeratorInfo IsNot Nothing, $"Field '{NameOf(enumeratorInfo)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(controlVariable IsNot Nothing, $"Field '{NameOf(controlVariable)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel IsNot Nothing, $"Field '{NameOf(continueLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(exitLabel IsNot Nothing, $"Field '{NameOf(exitLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Collection = collection
      _EnumeratorInfo = enumeratorInfo
    End Sub
    Public ReadOnly Property collection As BoundExpression

    Public ReadOnly Property enumeratorInfo As ForEachEnumeratorInfo

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitForEachStatement(Me)
    End Function
    Public Function Update As BoundForEachStatement
      If (collection Is Me.Collection) AndAlso (enumeratorInfo Is Me.EnumeratorInfo) AndAlso (declaredOrInferredLocalOpt Is Me.DeclaredOrInferredLocalOpt) AndAlso (controlVariable Is Me.ControlVariable) AndAlso (body Is Me.Body) AndAlso (nextVariablesOpt = Me.NextVariablesOpt) AndAlso (continueLabel Is Me.ContinueLabel) AndAlso (exitLabel Is Me.ExitLabel) Then Return Me
      Dim result As New BoundForEachStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundExitStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ExitStatement, syntax, hasErrors)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ExitStatement, syntax)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public ReadOnly Property label As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitExitStatement(Me)
    End Function
    Public Function Update As BoundExitStatement
      If (label Is Me.Label) Then Return Me
      Dim result As New BoundExitStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundContinueStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ContinueStatement, syntax, hasErrors)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ContinueStatement, syntax)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public ReadOnly Property label As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitContinueStatement(Me)
    End Function
    Public Function Update As BoundContinueStatement
      If (label Is Me.Label) Then Return Me
      Dim result As New BoundContinueStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTryStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.TryStatement, syntax, hasErrors OrElse tryBlock.NonNullAndHasErrors() OrElse catchBlocks.NonNullAndHasErrors() OrElse finallyBlockOpt.NonNullAndHasErrors())
      Debug.Assert(tryBlock IsNot Nothing, $"Field '{NameOf(tryBlock)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not catchBlocks.IsDefault, $"Field '{NameOf(catchBlocks)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _TryBlock = tryBlock
      _CatchBlocks = catchBlocks
      _FinallyBlockOpt = finallyBlockOpt
      _ExitLabelOpt = exitLabelOpt
    End Sub
    Public ReadOnly Property tryBlock As BoundBlock

    Public ReadOnly Property catchBlocks As ImmutableArray(Of BoundCatchBlock)

    Public ReadOnly Property finallyBlockOpt As BoundBlock

    Public ReadOnly Property exitLabelOpt As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTryStatement(Me)
    End Function
    Public Function Update As BoundTryStatement
      If (tryBlock Is Me.TryBlock) AndAlso (catchBlocks = Me.CatchBlocks) AndAlso (finallyBlockOpt Is Me.FinallyBlockOpt) AndAlso (exitLabelOpt Is Me.ExitLabelOpt) Then Return Me
      Dim result As New BoundTryStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundCatchBlock : Inherits BoundNode

    Public Sub New
      MyBase.New(BoundKind.CatchBlock, syntax, hasErrors OrElse exceptionSourceOpt.NonNullAndHasErrors() OrElse errorLineNumberOpt.NonNullAndHasErrors() OrElse exceptionFilterOpt.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalOpt = localOpt
      _ExceptionSourceOpt = exceptionSourceOpt
      _ErrorLineNumberOpt = errorLineNumberOpt
      _ExceptionFilterOpt = exceptionFilterOpt
      _Body = body
      _IsSynthesizedAsyncCatchAll = isSynthesizedAsyncCatchAll
    End Sub
    Public ReadOnly Property localOpt As LocalSymbol

    Public ReadOnly Property exceptionSourceOpt As BoundExpression

    Public ReadOnly Property errorLineNumberOpt As BoundExpression

    Public ReadOnly Property exceptionFilterOpt As BoundExpression

    Public ReadOnly Property body As BoundBlock

    Public ReadOnly Property isSynthesizedAsyncCatchAll As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitCatchBlock(Me)
    End Function
    Public Function Update As BoundCatchBlock
      If (localOpt Is Me.LocalOpt) AndAlso (exceptionSourceOpt Is Me.ExceptionSourceOpt) AndAlso (errorLineNumberOpt Is Me.ErrorLineNumberOpt) AndAlso (exceptionFilterOpt Is Me.ExceptionFilterOpt) AndAlso (body Is Me.Body) AndAlso (isSynthesizedAsyncCatchAll = Me.IsSynthesizedAsyncCatchAll) Then Return Me
      Dim result As New BoundCatchBlock
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLiteral : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Literal, syntax, type, hasErrors)
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Value = value
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Literal, syntax, type)
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Value = value
      Validate()
    End Sub
    Public ReadOnly Property value As ConstantValue

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLiteral(Me)
    End Function
    Public Function Update As BoundLiteral
      If (value Is Me.Value) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLiteral
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMeReference : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MeReference, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.MeReference, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMeReference(Me)
    End Function
    Public Function Update As BoundMeReference
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundMeReference
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundValueTypeMeReference : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ValueTypeMeReference, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ValueTypeMeReference, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Validate()
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitValueTypeMeReference(Me)
    End Function
    Public Function Update As BoundValueTypeMeReference
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundValueTypeMeReference
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMyBaseReference : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MyBaseReference, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.MyBaseReference, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMyBaseReference(Me)
    End Function
    Public Function Update As BoundMyBaseReference
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundMyBaseReference
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMyClassReference : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MyClassReference, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.MyClassReference, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMyClassReference(Me)
    End Function
    Public Function Update As BoundMyClassReference
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundMyClassReference
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundPreviousSubmissionReference : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.PreviousSubmissionReference, syntax, type, hasErrors)
      Debug.Assert(sourceType IsNot Nothing, $"Field '{NameOf(sourceType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _SourceType = sourceType
    End Sub
    Public Sub New
      MyBase.New(BoundKind.PreviousSubmissionReference, syntax, type)
      Debug.Assert(sourceType IsNot Nothing, $"Field '{NameOf(sourceType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _SourceType = sourceType
    End Sub
    Public ReadOnly Property sourceType As NamedTypeSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitPreviousSubmissionReference(Me)
    End Function
    Public Function Update As BoundPreviousSubmissionReference
      If (sourceType Is Me.SourceType) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundPreviousSubmissionReference
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundHostObjectMemberReference : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.HostObjectMemberReference, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Sub New
      MyBase.New(BoundKind.HostObjectMemberReference, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitHostObjectMemberReference(Me)
    End Function
    Public Function Update As BoundHostObjectMemberReference
      If (type Is Me.Type) Then Return Me
      Dim result As New BoundHostObjectMemberReference
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLocal : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Local, syntax, type, hasErrors)
      Debug.Assert(localSymbol IsNot Nothing, $"Field '{NameOf(localSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalSymbol = localSymbol
      _IsLValue = isLValue
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Local, syntax, type)
      Debug.Assert(localSymbol IsNot Nothing, $"Field '{NameOf(localSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalSymbol = localSymbol
      _IsLValue = isLValue
      Validate()
    End Sub
    Public ReadOnly Property localSymbol As LocalSymbol

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLocal(Me)
    End Function
    Public Function Update As BoundLocal
      If (localSymbol Is Me.LocalSymbol) AndAlso (isLValue = Me.IsLValue) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLocal
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundPseudoVariable : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.PseudoVariable, syntax, type, hasErrors)
      Debug.Assert(localSymbol IsNot Nothing, $"Field '{NameOf(localSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(emitExpressions IsNot Nothing, $"Field '{NameOf(emitExpressions)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalSymbol = localSymbol
      _IsLValue = isLValue
      _EmitExpressions = emitExpressions
    End Sub
    Public Sub New
      MyBase.New(BoundKind.PseudoVariable, syntax, type)
      Debug.Assert(localSymbol IsNot Nothing, $"Field '{NameOf(localSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(emitExpressions IsNot Nothing, $"Field '{NameOf(emitExpressions)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LocalSymbol = localSymbol
      _IsLValue = isLValue
      _EmitExpressions = emitExpressions
    End Sub
    Public ReadOnly Property localSymbol As LocalSymbol

    Public Overrides ReadOnly Property isLValue As Boolean

    Public ReadOnly Property emitExpressions As PseudoVariableExpressions

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitPseudoVariable(Me)
    End Function
    Public Function Update As BoundPseudoVariable
      If (localSymbol Is Me.LocalSymbol) AndAlso (isLValue = Me.IsLValue) AndAlso (emitExpressions Is Me.EmitExpressions) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundPseudoVariable
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundParameter : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Parameter, syntax, type, hasErrors)
      Debug.Assert(parameterSymbol IsNot Nothing, $"Field '{NameOf(parameterSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ParameterSymbol = parameterSymbol
      _IsLValue = isLValue
      _SuppressVirtualCalls = suppressVirtualCalls
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Parameter, syntax, type)
      Debug.Assert(parameterSymbol IsNot Nothing, $"Field '{NameOf(parameterSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ParameterSymbol = parameterSymbol
      _IsLValue = isLValue
      _SuppressVirtualCalls = suppressVirtualCalls
    End Sub
    Public ReadOnly Property parameterSymbol As ParameterSymbol

    Public Overrides ReadOnly Property isLValue As Boolean

    Public Overrides ReadOnly Property suppressVirtualCalls As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitParameter(Me)
    End Function
    Public Function Update As BoundParameter
      If (parameterSymbol Is Me.ParameterSymbol) AndAlso (isLValue = Me.IsLValue) AndAlso (suppressVirtualCalls = Me.SuppressVirtualCalls) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundParameter
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundByRefArgumentPlaceholder : Inherits BoundValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.ByRefArgumentPlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _IsOut = isOut
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ByRefArgumentPlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _IsOut = isOut
    End Sub
    Public ReadOnly Property isOut As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitByRefArgumentPlaceholder(Me)
    End Function
    Public Function Update As BoundByRefArgumentPlaceholder
      If (isOut = Me.IsOut) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundByRefArgumentPlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundByRefArgumentWithCopyBack : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ByRefArgumentWithCopyBack, syntax, type, hasErrors OrElse originalArgument.NonNullAndHasErrors() OrElse inConversion.NonNullAndHasErrors() OrElse inPlaceholder.NonNullAndHasErrors() OrElse outConversion.NonNullAndHasErrors() OrElse outPlaceholder.NonNullAndHasErrors())
      Debug.Assert(originalArgument IsNot Nothing, $"Field '{NameOf(originalArgument)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(inConversion IsNot Nothing, $"Field '{NameOf(inConversion)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(inPlaceholder IsNot Nothing, $"Field '{NameOf(inPlaceholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(outConversion IsNot Nothing, $"Field '{NameOf(outConversion)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(outPlaceholder IsNot Nothing, $"Field '{NameOf(outPlaceholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OriginalArgument = originalArgument
      _InConversion = inConversion
      _InPlaceholder = inPlaceholder
      _OutConversion = outConversion
      _OutPlaceholder = outPlaceholder
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property originalArgument As BoundExpression

    Public ReadOnly Property inConversion As BoundExpression

    Public ReadOnly Property inPlaceholder As BoundByRefArgumentPlaceholder

    Public ReadOnly Property outConversion As BoundExpression

    Public ReadOnly Property outPlaceholder As BoundRValuePlaceholder

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitByRefArgumentWithCopyBack(Me)
    End Function
    Public Function Update As BoundByRefArgumentWithCopyBack
      If (originalArgument Is Me.OriginalArgument) AndAlso (inConversion Is Me.InConversion) AndAlso (inPlaceholder Is Me.InPlaceholder) AndAlso (outConversion Is Me.OutConversion) AndAlso (outPlaceholder Is Me.OutPlaceholder) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundByRefArgumentWithCopyBack
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLateBoundArgumentSupportingAssignmentWithCapture : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.LateBoundArgumentSupportingAssignmentWithCapture, syntax, type, hasErrors OrElse originalArgument.NonNullAndHasErrors())
      Debug.Assert(originalArgument IsNot Nothing, $"Field '{NameOf(originalArgument)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(localSymbol IsNot Nothing, $"Field '{NameOf(localSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OriginalArgument = originalArgument
      _LocalSymbol = localSymbol
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property originalArgument As BoundExpression

    Public ReadOnly Property localSymbol As SynthesizedLocal

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLateBoundArgumentSupportingAssignmentWithCapture(Me)
    End Function
    Public Function Update As BoundLateBoundArgumentSupportingAssignmentWithCapture
      If (originalArgument Is Me.OriginalArgument) AndAlso (localSymbol Is Me.LocalSymbol) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLateBoundArgumentSupportingAssignmentWithCapture
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLabelStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.LabelStatement, syntax, hasErrors)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public Sub New
      MyBase.New(BoundKind.LabelStatement, syntax)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public ReadOnly Property label As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLabelStatement(Me)
    End Function
    Public Function Update As BoundLabelStatement
      If (label Is Me.Label) Then Return Me
      Dim result As New BoundLabelStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLabel : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Label, syntax, type, hasErrors)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public Sub New
      MyBase.New(BoundKind.Label, syntax, type)
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
    End Sub
    Public ReadOnly Property label As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLabel(Me)
    End Function
    Public Function Update As BoundLabel
      If (label Is Me.Label) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLabel
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundGotoStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.GotoStatement, syntax, hasErrors OrElse labelExpressionOpt.NonNullAndHasErrors())
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Label = label
      _LabelExpressionOpt = labelExpressionOpt
    End Sub
    Public ReadOnly Property label As LabelSymbol

    Public ReadOnly Property labelExpressionOpt As BoundLabel

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitGotoStatement(Me)
    End Function
    Public Function Update As BoundGotoStatement
      If (label Is Me.Label) AndAlso (labelExpressionOpt Is Me.LabelExpressionOpt) Then Return Me
      Dim result As New BoundGotoStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundStatementList : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.StatementList, syntax, hasErrors OrElse statements.NonNullAndHasErrors())
      Debug.Assert(Not statements.IsDefault, $"Field '{NameOf(statements)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Statements = statements
    End Sub
    Public ReadOnly Property statements As ImmutableArray(Of BoundStatement)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitStatementList(Me)
    End Function
    Public Function Update As BoundStatementList
      If (statements = Me.Statements) Then Return Me
      Dim result As New BoundStatementList
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundConditionalGoto : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ConditionalGoto, syntax, hasErrors OrElse condition.NonNullAndHasErrors())
      Debug.Assert(condition IsNot Nothing, $"Field '{NameOf(condition)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(label IsNot Nothing, $"Field '{NameOf(label)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Condition = condition
      _JumpIfTrue = jumpIfTrue
      _Label = label
    End Sub
    Public ReadOnly Property condition As BoundExpression

    Public ReadOnly Property jumpIfTrue As Boolean

    Public ReadOnly Property label As LabelSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitConditionalGoto(Me)
    End Function
    Public Function Update As BoundConditionalGoto
      If (condition Is Me.Condition) AndAlso (jumpIfTrue = Me.JumpIfTrue) AndAlso (label Is Me.Label) Then Return Me
      Dim result As New BoundConditionalGoto
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundWithStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.WithStatement, syntax, hasErrors OrElse originalExpression.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(originalExpression IsNot Nothing, $"Field '{NameOf(originalExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _OriginalExpression = originalExpression
      _Body = body
      _Binder = binder
    End Sub
    Public ReadOnly Property originalExpression As BoundExpression

    Public ReadOnly Property body As BoundBlock

    Public ReadOnly Property binder As WithBlockBinder

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitWithStatement(Me)
    End Function
    Public Function Update As BoundWithStatement
      If (originalExpression Is Me.OriginalExpression) AndAlso (body Is Me.Body) AndAlso (binder Is Me.Binder) Then Return Me
      Dim result As New BoundWithStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class UnboundLambda : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UnboundLambda, syntax, Nothing, hasErrors)
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not parameters.IsDefault, $"Field '{NameOf(parameters)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(bindingCache IsNot Nothing, $"Field '{NameOf(bindingCache)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _Flags = flags
      _Parameters = parameters
      _ReturnType = returnType
      _BindingCache = bindingCache
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.UnboundLambda, syntax, Nothing)
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not parameters.IsDefault, $"Field '{NameOf(parameters)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(bindingCache IsNot Nothing, $"Field '{NameOf(bindingCache)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _Flags = flags
      _Parameters = parameters
      _ReturnType = returnType
      _BindingCache = bindingCache
      Validate()
    End Sub
    Public ReadOnly Property binder As Binder

    Public ReadOnly Property flags As SourceMemberFlags

    Public ReadOnly Property parameters As ImmutableArray(Of ParameterSymbol)

    Public ReadOnly Property returnType As TypeSymbol

    Public ReadOnly Property bindingCache As UnboundLambda.UnboundLambdaBindingCache

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUnboundLambda(Me)
    End Function
    Public Function Update As UnboundLambda
      If (binder Is Me.Binder) AndAlso (flags = Me.Flags) AndAlso (parameters = Me.Parameters) AndAlso (returnType Is Me.ReturnType) AndAlso (bindingCache Is Me.BindingCache) Then Return Me
      Dim result As New UnboundLambda
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLambda : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.Lambda, syntax, Nothing, hasErrors OrElse body.NonNullAndHasErrors())
      Debug.Assert(lambdaSymbol IsNot Nothing, $"Field '{NameOf(lambdaSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not diagnostics.IsDefault, $"Field '{NameOf(diagnostics)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LambdaSymbol = lambdaSymbol
      _Body = body
      _Diagnostics = diagnostics
      _LambdaBinderOpt = lambdaBinderOpt
      _DelegateRelaxation = delegateRelaxation
      _MethodConversionKind = methodConversionKind
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property lambdaSymbol As LambdaSymbol

    Public ReadOnly Property body As BoundBlock

    Public ReadOnly Property diagnostics As ImmutableArray(Of Microsoft.CodeAnalysis.Diagnostic)

    Public ReadOnly Property lambdaBinderOpt As LambdaBodyBinder

    Public ReadOnly Property delegateRelaxation As ConversionKind

    Public ReadOnly Property methodConversionKind As MethodConversionKind

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLambda(Me)
    End Function
    Public Function Update As BoundLambda
      If (lambdaSymbol Is Me.LambdaSymbol) AndAlso (body Is Me.Body) AndAlso (diagnostics = Me.Diagnostics) AndAlso (lambdaBinderOpt Is Me.LambdaBinderOpt) AndAlso (delegateRelaxation = Me.DelegateRelaxation) AndAlso (methodConversionKind = Me.MethodConversionKind) Then Return Me
      Dim result As New BoundLambda
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundQueryExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.QueryExpression, syntax, type, hasErrors OrElse lastOperator.NonNullAndHasErrors())
      Debug.Assert(lastOperator IsNot Nothing, $"Field '{NameOf(lastOperator)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LastOperator = lastOperator
    End Sub
    Public ReadOnly Property lastOperator As BoundQueryClauseBase

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitQueryExpression(Me)
    End Function
    Public Function Update As BoundQueryExpression
      If (lastOperator Is Me.LastOperator) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundQueryExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundQueryPart : Inherits BoundExpression

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
  End Class

  Friend NotInheritable Partial Class BoundQuerySource : Inherits BoundQueryPart

    Public Sub New
      MyBase.New(BoundKind.QuerySource, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitQuerySource(Me)
    End Function
    Public Function Update As BoundQuerySource
      If (expression Is Me.Expression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundQuerySource
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundToQueryableCollectionConversion : Inherits BoundQueryPart

    Public Sub New
      MyBase.New(BoundKind.ToQueryableCollectionConversion, syntax, type, hasErrors OrElse conversionCall.NonNullAndHasErrors())
      Debug.Assert(conversionCall IsNot Nothing, $"Field '{NameOf(conversionCall)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ConversionCall = conversionCall
    End Sub
    Public ReadOnly Property conversionCall As BoundCall

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitToQueryableCollectionConversion(Me)
    End Function
    Public Function Update As BoundToQueryableCollectionConversion
      If (conversionCall Is Me.ConversionCall) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundToQueryableCollectionConversion
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundQueryClauseBase : Inherits BoundQueryPart

    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(Not rangeVariables.IsDefault, $"Field '{NameOf(rangeVariables)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compoundVariableType IsNot Nothing, $"Field '{NameOf(compoundVariableType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not binders.IsDefault, $"Field '{NameOf(binders)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _RangeVariables = rangeVariables
      _CompoundVariableType = compoundVariableType
      _Binders = binders
    End Sub
    Protected Sub New
      MyBase.New(kind, syntax, type)
      Debug.Assert(Not rangeVariables.IsDefault, $"Field '{NameOf(rangeVariables)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compoundVariableType IsNot Nothing, $"Field '{NameOf(compoundVariableType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not binders.IsDefault, $"Field '{NameOf(binders)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _RangeVariables = rangeVariables
      _CompoundVariableType = compoundVariableType
      _Binders = binders
    End Sub
    Public ReadOnly Property rangeVariables As ImmutableArray(Of RangeVariableSymbol)

    Public ReadOnly Property compoundVariableType As TypeSymbol

    Public ReadOnly Property binders As ImmutableArray(Of Binder)

  End Class

  Friend NotInheritable Partial Class BoundQueryableSource : Inherits BoundQueryClauseBase

    Public Sub New
      MyBase.New(BoundKind.QueryableSource, syntax, rangeVariables, compoundVariableType, binders, type, hasErrors OrElse source.NonNullAndHasErrors())
      Debug.Assert(source IsNot Nothing, $"Field '{NameOf(source)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not rangeVariables.IsDefault, $"Field '{NameOf(rangeVariables)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compoundVariableType IsNot Nothing, $"Field '{NameOf(compoundVariableType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not binders.IsDefault, $"Field '{NameOf(binders)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Source = source
      _RangeVariableOpt = rangeVariableOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property source As BoundQueryPart

    Public ReadOnly Property rangeVariableOpt As RangeVariableSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitQueryableSource(Me)
    End Function
    Public Function Update As BoundQueryableSource
      If (source Is Me.Source) AndAlso (rangeVariableOpt Is Me.RangeVariableOpt) AndAlso (rangeVariables = Me.RangeVariables) AndAlso (compoundVariableType Is Me.CompoundVariableType) AndAlso (binders = Me.Binders) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundQueryableSource
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundQueryClause : Inherits BoundQueryClauseBase

    Public Sub New
      MyBase.New(BoundKind.QueryClause, syntax, rangeVariables, compoundVariableType, binders, type, hasErrors OrElse underlyingExpression.NonNullAndHasErrors())
      Debug.Assert(underlyingExpression IsNot Nothing, $"Field '{NameOf(underlyingExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not rangeVariables.IsDefault, $"Field '{NameOf(rangeVariables)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compoundVariableType IsNot Nothing, $"Field '{NameOf(compoundVariableType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not binders.IsDefault, $"Field '{NameOf(binders)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _UnderlyingExpression = underlyingExpression
    End Sub
    Public ReadOnly Property underlyingExpression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitQueryClause(Me)
    End Function
    Public Function Update As BoundQueryClause
      If (underlyingExpression Is Me.UnderlyingExpression) AndAlso (rangeVariables = Me.RangeVariables) AndAlso (compoundVariableType Is Me.CompoundVariableType) AndAlso (binders = Me.Binders) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundQueryClause
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundOrdering : Inherits BoundQueryPart

    Public Sub New
      MyBase.New(BoundKind.Ordering, syntax, type, hasErrors OrElse underlyingExpression.NonNullAndHasErrors())
      Debug.Assert(underlyingExpression IsNot Nothing, $"Field '{NameOf(underlyingExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _UnderlyingExpression = underlyingExpression
    End Sub
    Public ReadOnly Property underlyingExpression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitOrdering(Me)
    End Function
    Public Function Update As BoundOrdering
      If (underlyingExpression Is Me.UnderlyingExpression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundOrdering
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundQueryLambda : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.QueryLambda, syntax, Nothing, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(lambdaSymbol IsNot Nothing, $"Field '{NameOf(lambdaSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not rangeVariables.IsDefault, $"Field '{NameOf(rangeVariables)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LambdaSymbol = lambdaSymbol
      _RangeVariables = rangeVariables
      _Expression = expression
      _ExprIsOperandOfConditionalBranch = exprIsOperandOfConditionalBranch
    End Sub
    Public ReadOnly Property lambdaSymbol As SynthesizedLambdaSymbol

    Public ReadOnly Property rangeVariables As ImmutableArray(Of RangeVariableSymbol)

    Public ReadOnly Property expression As BoundExpression

    Public ReadOnly Property exprIsOperandOfConditionalBranch As Boolean

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitQueryLambda(Me)
    End Function
    Public Function Update As BoundQueryLambda
      If (lambdaSymbol Is Me.LambdaSymbol) AndAlso (rangeVariables = Me.RangeVariables) AndAlso (expression Is Me.Expression) AndAlso (exprIsOperandOfConditionalBranch = Me.ExprIsOperandOfConditionalBranch) Then Return Me
      Dim result As New BoundQueryLambda
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRangeVariableAssignment : Inherits BoundQueryPart

    Public Sub New
      MyBase.New(BoundKind.RangeVariableAssignment, syntax, type, hasErrors OrElse value.NonNullAndHasErrors())
      Debug.Assert(rangeVariable IsNot Nothing, $"Field '{NameOf(rangeVariable)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _RangeVariable = rangeVariable
      _Value = value
    End Sub
    Public ReadOnly Property rangeVariable As RangeVariableSymbol

    Public ReadOnly Property value As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRangeVariableAssignment(Me)
    End Function
    Public Function Update As BoundRangeVariableAssignment
      If (rangeVariable Is Me.RangeVariable) AndAlso (value Is Me.Value) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundRangeVariableAssignment
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class GroupTypeInferenceLambda : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.GroupTypeInferenceLambda, syntax, Nothing, hasErrors)
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not parameters.IsDefault, $"Field '{NameOf(parameters)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compilation IsNot Nothing, $"Field '{NameOf(compilation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _Parameters = parameters
      _Compilation = compilation
    End Sub
    Public Sub New
      MyBase.New(BoundKind.GroupTypeInferenceLambda, syntax, Nothing)
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not parameters.IsDefault, $"Field '{NameOf(parameters)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compilation IsNot Nothing, $"Field '{NameOf(compilation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Binder = binder
      _Parameters = parameters
      _Compilation = compilation
    End Sub
    Public ReadOnly Property binder As Binder

    Public ReadOnly Property parameters As ImmutableArray(Of ParameterSymbol)

    Public ReadOnly Property compilation As VisualBasicCompilation

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitGroupTypeInferenceLambda(Me)
    End Function
    Public Function Update As GroupTypeInferenceLambda
      If (binder Is Me.Binder) AndAlso (parameters = Me.Parameters) AndAlso (compilation Is Me.Compilation) Then Return Me
      Dim result As New GroupTypeInferenceLambda
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAggregateClause : Inherits BoundQueryClauseBase

    Public Sub New
      MyBase.New(BoundKind.AggregateClause, syntax, rangeVariables, compoundVariableType, binders, type, hasErrors OrElse capturedGroupOpt.NonNullAndHasErrors() OrElse groupPlaceholderOpt.NonNullAndHasErrors() OrElse underlyingExpression.NonNullAndHasErrors())
      Debug.Assert(underlyingExpression IsNot Nothing, $"Field '{NameOf(underlyingExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not rangeVariables.IsDefault, $"Field '{NameOf(rangeVariables)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(compoundVariableType IsNot Nothing, $"Field '{NameOf(compoundVariableType)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not binders.IsDefault, $"Field '{NameOf(binders)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _CapturedGroupOpt = capturedGroupOpt
      _GroupPlaceholderOpt = groupPlaceholderOpt
      _UnderlyingExpression = underlyingExpression
    End Sub
    Public ReadOnly Property capturedGroupOpt As BoundQueryClauseBase

    Public ReadOnly Property groupPlaceholderOpt As BoundRValuePlaceholder

    Public ReadOnly Property underlyingExpression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAggregateClause(Me)
    End Function
    Public Function Update As BoundAggregateClause
      If (capturedGroupOpt Is Me.CapturedGroupOpt) AndAlso (groupPlaceholderOpt Is Me.GroupPlaceholderOpt) AndAlso (underlyingExpression Is Me.UnderlyingExpression) AndAlso (rangeVariables = Me.RangeVariables) AndAlso (compoundVariableType Is Me.CompoundVariableType) AndAlso (binders = Me.Binders) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAggregateClause
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundGroupAggregation : Inherits BoundQueryPart

    Public Sub New
      MyBase.New(BoundKind.GroupAggregation, syntax, type, hasErrors OrElse group.NonNullAndHasErrors())
      Debug.Assert(group IsNot Nothing, $"Field '{NameOf(group)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Group = group
    End Sub
    Public ReadOnly Property group As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitGroupAggregation(Me)
    End Function
    Public Function Update As BoundGroupAggregation
      If (group Is Me.Group) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundGroupAggregation
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRangeVariable : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.RangeVariable, syntax, type, hasErrors)
      Debug.Assert(rangeVariable IsNot Nothing, $"Field '{NameOf(rangeVariable)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _RangeVariable = rangeVariable
    End Sub
    Public Sub New
      MyBase.New(BoundKind.RangeVariable, syntax, type)
      Debug.Assert(rangeVariable IsNot Nothing, $"Field '{NameOf(rangeVariable)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _RangeVariable = rangeVariable
    End Sub
    Public ReadOnly Property rangeVariable As RangeVariableSymbol

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRangeVariable(Me)
    End Function
    Public Function Update As BoundRangeVariable
      If (rangeVariable Is Me.RangeVariable) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundRangeVariable
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend MustInherit Partial Class BoundAddRemoveHandlerStatement : Inherits BoundStatement

    Protected Sub New
      MyBase.New(kind, syntax)
      Debug.Assert(eventAccess IsNot Nothing, $"Field '{NameOf(eventAccess)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(handler IsNot Nothing, $"Field '{NameOf(handler)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _EventAccess = eventAccess
      _Handler = handler
    End Sub
    Public ReadOnly Property eventAccess As BoundExpression

    Public ReadOnly Property handler As BoundExpression

  End Class

  Friend NotInheritable Partial Class BoundAddHandlerStatement : Inherits BoundAddRemoveHandlerStatement

    Public Sub New
      MyBase.New(BoundKind.AddHandlerStatement, syntax, eventAccess, handler, hasErrors OrElse eventAccess.NonNullAndHasErrors() OrElse handler.NonNullAndHasErrors())
      Debug.Assert(eventAccess IsNot Nothing, $"Field '{NameOf(eventAccess)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(handler IsNot Nothing, $"Field '{NameOf(handler)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAddHandlerStatement(Me)
    End Function
    Public Function Update As BoundAddHandlerStatement
      If (eventAccess Is Me.EventAccess) AndAlso (handler Is Me.Handler) Then Return Me
      Dim result As New BoundAddHandlerStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRemoveHandlerStatement : Inherits BoundAddRemoveHandlerStatement

    Public Sub New
      MyBase.New(BoundKind.RemoveHandlerStatement, syntax, eventAccess, handler, hasErrors OrElse eventAccess.NonNullAndHasErrors() OrElse handler.NonNullAndHasErrors())
      Debug.Assert(eventAccess IsNot Nothing, $"Field '{NameOf(eventAccess)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(handler IsNot Nothing, $"Field '{NameOf(handler)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRemoveHandlerStatement(Me)
    End Function
    Public Function Update As BoundRemoveHandlerStatement
      If (eventAccess Is Me.EventAccess) AndAlso (handler Is Me.Handler) Then Return Me
      Dim result As New BoundRemoveHandlerStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundRaiseEventStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.RaiseEventStatement, syntax, hasErrors OrElse eventInvocation.NonNullAndHasErrors())
      Debug.Assert(eventSymbol IsNot Nothing, $"Field '{NameOf(eventSymbol)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(eventInvocation IsNot Nothing, $"Field '{NameOf(eventInvocation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _EventSymbol = eventSymbol
      _EventInvocation = eventInvocation
    End Sub
    Public ReadOnly Property eventSymbol As EventSymbol

    Public ReadOnly Property eventInvocation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitRaiseEventStatement(Me)
    End Function
    Public Function Update As BoundRaiseEventStatement
      If (eventSymbol Is Me.EventSymbol) AndAlso (eventInvocation Is Me.EventInvocation) Then Return Me
      Dim result As New BoundRaiseEventStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUsingStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.UsingStatement, syntax, hasErrors OrElse resourceList.NonNullAndHasErrors() OrElse resourceExpressionOpt.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(usingInfo IsNot Nothing, $"Field '{NameOf(usingInfo)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not locals.IsDefault, $"Field '{NameOf(locals)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ResourceList = resourceList
      _ResourceExpressionOpt = resourceExpressionOpt
      _Body = body
      _UsingInfo = usingInfo
      _Locals = locals
    End Sub
    Public ReadOnly Property resourceList As ImmutableArray(Of BoundLocalDeclarationBase)

    Public ReadOnly Property resourceExpressionOpt As BoundExpression

    Public ReadOnly Property body As BoundBlock

    Public ReadOnly Property usingInfo As UsingInfo

    Public ReadOnly Property locals As ImmutableArray(Of LocalSymbol)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUsingStatement(Me)
    End Function
    Public Function Update As BoundUsingStatement
      If (resourceList = Me.ResourceList) AndAlso (resourceExpressionOpt Is Me.ResourceExpressionOpt) AndAlso (body Is Me.Body) AndAlso (usingInfo Is Me.UsingInfo) AndAlso (locals = Me.Locals) Then Return Me
      Dim result As New BoundUsingStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSyncLockStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.SyncLockStatement, syntax, hasErrors OrElse lockExpression.NonNullAndHasErrors() OrElse body.NonNullAndHasErrors())
      Debug.Assert(lockExpression IsNot Nothing, $"Field '{NameOf(lockExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _LockExpression = lockExpression
      _Body = body
    End Sub
    Public ReadOnly Property lockExpression As BoundExpression

    Public ReadOnly Property body As BoundBlock

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSyncLockStatement(Me)
    End Function
    Public Function Update As BoundSyncLockStatement
      If (lockExpression Is Me.LockExpression) AndAlso (body Is Me.Body) Then Return Me
      Dim result As New BoundSyncLockStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlName : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlName, syntax, type, hasErrors OrElse xmlNamespace.NonNullAndHasErrors() OrElse localName.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(xmlNamespace IsNot Nothing, $"Field '{NameOf(xmlNamespace)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(localName IsNot Nothing, $"Field '{NameOf(localName)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _XmlNamespace = xmlNamespace
      _LocalName = localName
      _ObjectCreation = objectCreation
    End Sub
    Public ReadOnly Property xmlNamespace As BoundExpression

    Public ReadOnly Property localName As BoundExpression

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlName(Me)
    End Function
    Public Function Update As BoundXmlName
      If (xmlNamespace Is Me.XmlNamespace) AndAlso (localName Is Me.LocalName) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlName
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlNamespace : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlNamespace, syntax, type, hasErrors OrElse xmlNamespace.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(xmlNamespace IsNot Nothing, $"Field '{NameOf(xmlNamespace)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _XmlNamespace = xmlNamespace
      _ObjectCreation = objectCreation
    End Sub
    Public ReadOnly Property xmlNamespace As BoundExpression

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlNamespace(Me)
    End Function
    Public Function Update As BoundXmlNamespace
      If (xmlNamespace Is Me.XmlNamespace) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlNamespace
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlDocument : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlDocument, syntax, type, hasErrors OrElse declaration.NonNullAndHasErrors() OrElse childNodes.NonNullAndHasErrors())
      Debug.Assert(declaration IsNot Nothing, $"Field '{NameOf(declaration)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not childNodes.IsDefault, $"Field '{NameOf(childNodes)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(rewriterInfo IsNot Nothing, $"Field '{NameOf(rewriterInfo)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Declaration = declaration
      _ChildNodes = childNodes
      _RewriterInfo = rewriterInfo
    End Sub
    Public ReadOnly Property declaration As BoundExpression

    Public ReadOnly Property childNodes As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property rewriterInfo As BoundXmlContainerRewriterInfo

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlDocument(Me)
    End Function
    Public Function Update As BoundXmlDocument
      If (declaration Is Me.Declaration) AndAlso (childNodes = Me.ChildNodes) AndAlso (rewriterInfo Is Me.RewriterInfo) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlDocument
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlDeclaration : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlDeclaration, syntax, type, hasErrors OrElse version.NonNullAndHasErrors() OrElse encoding.NonNullAndHasErrors() OrElse standalone.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Version = version
      _Encoding = encoding
      _Standalone = standalone
      _ObjectCreation = objectCreation
    End Sub
    Public ReadOnly Property version As BoundExpression

    Public ReadOnly Property encoding As BoundExpression

    Public ReadOnly Property standalone As BoundExpression

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlDeclaration(Me)
    End Function
    Public Function Update As BoundXmlDeclaration
      If (version Is Me.Version) AndAlso (encoding Is Me.Encoding) AndAlso (standalone Is Me.Standalone) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlDeclaration
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlProcessingInstruction : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlProcessingInstruction, syntax, type, hasErrors OrElse target.NonNullAndHasErrors() OrElse data.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(target IsNot Nothing, $"Field '{NameOf(target)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(data IsNot Nothing, $"Field '{NameOf(data)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Target = target
      _Data = data
      _ObjectCreation = objectCreation
    End Sub
    Public ReadOnly Property target As BoundExpression

    Public ReadOnly Property data As BoundExpression

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlProcessingInstruction(Me)
    End Function
    Public Function Update As BoundXmlProcessingInstruction
      If (target Is Me.Target) AndAlso (data Is Me.Data) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlProcessingInstruction
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlComment : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlComment, syntax, type, hasErrors OrElse value.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Value = value
      _ObjectCreation = objectCreation
    End Sub
    Public ReadOnly Property value As BoundExpression

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlComment(Me)
    End Function
    Public Function Update As BoundXmlComment
      If (value Is Me.Value) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlComment
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlAttribute : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlAttribute, syntax, type, hasErrors OrElse name.NonNullAndHasErrors() OrElse value.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(name IsNot Nothing, $"Field '{NameOf(name)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Name = name
      _Value = value
      _MatchesImport = matchesImport
      _ObjectCreation = objectCreation
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property name As BoundExpression

    Public ReadOnly Property value As BoundExpression

    Public ReadOnly Property matchesImport As Boolean

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlAttribute(Me)
    End Function
    Public Function Update As BoundXmlAttribute
      If (name Is Me.Name) AndAlso (value Is Me.Value) AndAlso (matchesImport = Me.MatchesImport) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlAttribute
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlElement : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlElement, syntax, type, hasErrors OrElse argument.NonNullAndHasErrors() OrElse childNodes.NonNullAndHasErrors())
      Debug.Assert(argument IsNot Nothing, $"Field '{NameOf(argument)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not childNodes.IsDefault, $"Field '{NameOf(childNodes)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(rewriterInfo IsNot Nothing, $"Field '{NameOf(rewriterInfo)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Argument = argument
      _ChildNodes = childNodes
      _RewriterInfo = rewriterInfo
    End Sub
    Public ReadOnly Property argument As BoundExpression

    Public ReadOnly Property childNodes As ImmutableArray(Of BoundExpression)

    Public ReadOnly Property rewriterInfo As BoundXmlContainerRewriterInfo

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlElement(Me)
    End Function
    Public Function Update As BoundXmlElement
      If (argument Is Me.Argument) AndAlso (childNodes = Me.ChildNodes) AndAlso (rewriterInfo Is Me.RewriterInfo) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlElement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlMemberAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlMemberAccess, syntax, type, hasErrors OrElse memberAccess.NonNullAndHasErrors())
      Debug.Assert(memberAccess IsNot Nothing, $"Field '{NameOf(memberAccess)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _MemberAccess = memberAccess
    End Sub
    Public ReadOnly Property memberAccess As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlMemberAccess(Me)
    End Function
    Public Function Update As BoundXmlMemberAccess
      If (memberAccess Is Me.MemberAccess) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlMemberAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlEmbeddedExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlEmbeddedExpression, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlEmbeddedExpression(Me)
    End Function
    Public Function Update As BoundXmlEmbeddedExpression
      If (expression Is Me.Expression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlEmbeddedExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundXmlCData : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.XmlCData, syntax, type, hasErrors OrElse value.NonNullAndHasErrors() OrElse objectCreation.NonNullAndHasErrors())
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(objectCreation IsNot Nothing, $"Field '{NameOf(objectCreation)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Value = value
      _ObjectCreation = objectCreation
    End Sub
    Public ReadOnly Property value As BoundLiteral

    Public ReadOnly Property objectCreation As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitXmlCData(Me)
    End Function
    Public Function Update As BoundXmlCData
      If (value Is Me.Value) AndAlso (objectCreation Is Me.ObjectCreation) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundXmlCData
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundResumeStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.ResumeStatement, syntax, hasErrors OrElse labelExpressionOpt.NonNullAndHasErrors())
      _ResumeKind = resumeKind
      _LabelOpt = labelOpt
      _LabelExpressionOpt = labelExpressionOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property resumeKind As ResumeStatementKind

    Public ReadOnly Property labelOpt As LabelSymbol

    Public ReadOnly Property labelExpressionOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitResumeStatement(Me)
    End Function
    Public Function Update As BoundResumeStatement
      If (resumeKind = Me.ResumeKind) AndAlso (labelOpt Is Me.LabelOpt) AndAlso (labelExpressionOpt Is Me.LabelExpressionOpt) Then Return Me
      Dim result As New BoundResumeStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundOnErrorStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.OnErrorStatement, syntax, hasErrors OrElse labelExpressionOpt.NonNullAndHasErrors())
      _OnErrorKind = onErrorKind
      _LabelOpt = labelOpt
      _LabelExpressionOpt = labelExpressionOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property onErrorKind As OnErrorStatementKind

    Public ReadOnly Property labelOpt As LabelSymbol

    Public ReadOnly Property labelExpressionOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitOnErrorStatement(Me)
    End Function
    Public Function Update As BoundOnErrorStatement
      If (onErrorKind = Me.OnErrorKind) AndAlso (labelOpt Is Me.LabelOpt) AndAlso (labelExpressionOpt Is Me.LabelExpressionOpt) Then Return Me
      Dim result As New BoundOnErrorStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUnstructuredExceptionHandlingStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.UnstructuredExceptionHandlingStatement, syntax, hasErrors OrElse body.NonNullAndHasErrors())
      Debug.Assert(body IsNot Nothing, $"Field '{NameOf(body)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ContainsOnError = containsOnError
      _ContainsResume = containsResume
      _ResumeWithoutLabelOpt = resumeWithoutLabelOpt
      _TrackLineNumber = trackLineNumber
      _Body = body
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property containsOnError As Boolean

    Public ReadOnly Property containsResume As Boolean

    Public ReadOnly Property resumeWithoutLabelOpt As StatementSyntax

    Public ReadOnly Property trackLineNumber As Boolean

    Public ReadOnly Property body As BoundBlock

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUnstructuredExceptionHandlingStatement(Me)
    End Function
    Public Function Update As BoundUnstructuredExceptionHandlingStatement
      If (containsOnError = Me.ContainsOnError) AndAlso (containsResume = Me.ContainsResume) AndAlso (resumeWithoutLabelOpt Is Me.ResumeWithoutLabelOpt) AndAlso (trackLineNumber = Me.TrackLineNumber) AndAlso (body Is Me.Body) Then Return Me
      Dim result As New BoundUnstructuredExceptionHandlingStatement
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUnstructuredExceptionHandlingCatchFilter : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.UnstructuredExceptionHandlingCatchFilter, syntax, type, hasErrors OrElse activeHandlerLocal.NonNullAndHasErrors() OrElse resumeTargetLocal.NonNullAndHasErrors())
      Debug.Assert(activeHandlerLocal IsNot Nothing, $"Field '{NameOf(activeHandlerLocal)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(resumeTargetLocal IsNot Nothing, $"Field '{NameOf(resumeTargetLocal)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ActiveHandlerLocal = activeHandlerLocal
      _ResumeTargetLocal = resumeTargetLocal
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property activeHandlerLocal As BoundLocal

    Public ReadOnly Property resumeTargetLocal As BoundLocal

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUnstructuredExceptionHandlingCatchFilter(Me)
    End Function
    Public Function Update As BoundUnstructuredExceptionHandlingCatchFilter
      If (activeHandlerLocal Is Me.ActiveHandlerLocal) AndAlso (resumeTargetLocal Is Me.ResumeTargetLocal) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundUnstructuredExceptionHandlingCatchFilter
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUnstructuredExceptionOnErrorSwitch : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.UnstructuredExceptionOnErrorSwitch, syntax, hasErrors OrElse value.NonNullAndHasErrors() OrElse jumps.NonNullAndHasErrors())
      Debug.Assert(value IsNot Nothing, $"Field '{NameOf(value)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not jumps.IsDefault, $"Field '{NameOf(jumps)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Value = value
      _Jumps = jumps
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property value As BoundExpression

    Public ReadOnly Property jumps As ImmutableArray(Of BoundGotoStatement)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUnstructuredExceptionOnErrorSwitch(Me)
    End Function
    Public Function Update As BoundUnstructuredExceptionOnErrorSwitch
      If (value Is Me.Value) AndAlso (jumps = Me.Jumps) Then Return Me
      Dim result As New BoundUnstructuredExceptionOnErrorSwitch
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundUnstructuredExceptionResumeSwitch : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.UnstructuredExceptionResumeSwitch, syntax, hasErrors OrElse resumeTargetTemporary.NonNullAndHasErrors() OrElse resumeLabel.NonNullAndHasErrors() OrElse resumeNextLabel.NonNullAndHasErrors() OrElse jumps.NonNullAndHasErrors())
      Debug.Assert(resumeTargetTemporary IsNot Nothing, $"Field '{NameOf(resumeTargetTemporary)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(resumeLabel IsNot Nothing, $"Field '{NameOf(resumeLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(resumeNextLabel IsNot Nothing, $"Field '{NameOf(resumeNextLabel)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not jumps.IsDefault, $"Field '{NameOf(jumps)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ResumeTargetTemporary = resumeTargetTemporary
      _ResumeLabel = resumeLabel
      _ResumeNextLabel = resumeNextLabel
      _Jumps = jumps
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property resumeTargetTemporary As BoundLocal

    Public ReadOnly Property resumeLabel As BoundLabelStatement

    Public ReadOnly Property resumeNextLabel As BoundLabelStatement

    Public ReadOnly Property jumps As ImmutableArray(Of BoundGotoStatement)

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitUnstructuredExceptionResumeSwitch(Me)
    End Function
    Public Function Update As BoundUnstructuredExceptionResumeSwitch
      If (resumeTargetTemporary Is Me.ResumeTargetTemporary) AndAlso (resumeLabel Is Me.ResumeLabel) AndAlso (resumeNextLabel Is Me.ResumeNextLabel) AndAlso (jumps = Me.Jumps) Then Return Me
      Dim result As New BoundUnstructuredExceptionResumeSwitch
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundAwaitOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.AwaitOperator, syntax, type, hasErrors OrElse operand.NonNullAndHasErrors() OrElse awaitableInstancePlaceholder.NonNullAndHasErrors() OrElse getAwaiter.NonNullAndHasErrors() OrElse awaiterInstancePlaceholder.NonNullAndHasErrors() OrElse isCompleted.NonNullAndHasErrors() OrElse getResult.NonNullAndHasErrors())
      Debug.Assert(operand IsNot Nothing, $"Field '{NameOf(operand)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(awaitableInstancePlaceholder IsNot Nothing, $"Field '{NameOf(awaitableInstancePlaceholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(getAwaiter IsNot Nothing, $"Field '{NameOf(getAwaiter)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(awaiterInstancePlaceholder IsNot Nothing, $"Field '{NameOf(awaiterInstancePlaceholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(isCompleted IsNot Nothing, $"Field '{NameOf(isCompleted)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(getResult IsNot Nothing, $"Field '{NameOf(getResult)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Operand = operand
      _AwaitableInstancePlaceholder = awaitableInstancePlaceholder
      _GetAwaiter = getAwaiter
      _AwaiterInstancePlaceholder = awaiterInstancePlaceholder
      _IsCompleted = isCompleted
      _GetResult = getResult
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property operand As BoundExpression

    Public ReadOnly Property awaitableInstancePlaceholder As BoundRValuePlaceholder

    Public ReadOnly Property getAwaiter As BoundExpression

    Public ReadOnly Property awaiterInstancePlaceholder As BoundLValuePlaceholder

    Public ReadOnly Property isCompleted As BoundExpression

    Public ReadOnly Property getResult As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitAwaitOperator(Me)
    End Function
    Public Function Update As BoundAwaitOperator
      If (operand Is Me.Operand) AndAlso (awaitableInstancePlaceholder Is Me.AwaitableInstancePlaceholder) AndAlso (getAwaiter Is Me.GetAwaiter) AndAlso (awaiterInstancePlaceholder Is Me.AwaiterInstancePlaceholder) AndAlso (isCompleted Is Me.IsCompleted) AndAlso (getResult Is Me.GetResult) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundAwaitOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundSpillSequence : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.SpillSequence, syntax, type, hasErrors OrElse statements.NonNullAndHasErrors() OrElse valueOpt.NonNullAndHasErrors())
      Debug.Assert(Not locals.IsDefault, $"Field '{NameOf(locals)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not spillFields.IsDefault, $"Field '{NameOf(spillFields)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(Not statements.IsDefault, $"Field '{NameOf(statements)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Locals = locals
      _SpillFields = spillFields
      _Statements = statements
      _ValueOpt = valueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property locals As ImmutableArray(Of LocalSymbol)

    Public ReadOnly Property spillFields As ImmutableArray(Of FieldSymbol)

    Public ReadOnly Property statements As ImmutableArray(Of BoundStatement)

    Public ReadOnly Property valueOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitSpillSequence(Me)
    End Function
    Public Function Update As BoundSpillSequence
      If (locals = Me.Locals) AndAlso (spillFields = Me.SpillFields) AndAlso (statements = Me.Statements) AndAlso (valueOpt Is Me.ValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundSpillSequence
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundStopStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.StopStatement, syntax, hasErrors)
    End Sub
    Public Sub New
      MyBase.New(BoundKind.StopStatement, syntax)
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitStopStatement(Me)
    End Function
  End Class

  Friend NotInheritable Partial Class BoundEndStatement : Inherits BoundStatement

    Public Sub New
      MyBase.New(BoundKind.EndStatement, syntax, hasErrors)
    End Sub
    Public Sub New
      MyBase.New(BoundKind.EndStatement, syntax)
    End Sub
    Public Overrides Function Accept As BoundNode
      Return visitor.VisitEndStatement(Me)
    End Function
  End Class

  Friend NotInheritable Partial Class BoundMidResult : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.MidResult, syntax, type, hasErrors OrElse original.NonNullAndHasErrors() OrElse start.NonNullAndHasErrors() OrElse lengthOpt.NonNullAndHasErrors() OrElse source.NonNullAndHasErrors())
      Debug.Assert(original IsNot Nothing, $"Field '{NameOf(original)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(start IsNot Nothing, $"Field '{NameOf(start)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(source IsNot Nothing, $"Field '{NameOf(source)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Original = original
      _Start = start
      _LengthOpt = lengthOpt
      _Source = source
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property original As BoundExpression

    Public ReadOnly Property start As BoundExpression

    Public ReadOnly Property lengthOpt As BoundExpression

    Public ReadOnly Property source As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitMidResult(Me)
    End Function
    Public Function Update As BoundMidResult
      If (original Is Me.Original) AndAlso (start Is Me.Start) AndAlso (lengthOpt Is Me.LengthOpt) AndAlso (source Is Me.Source) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundMidResult
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundConditionalAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ConditionalAccess, syntax, type, hasErrors OrElse receiver.NonNullAndHasErrors() OrElse placeholder.NonNullAndHasErrors() OrElse accessExpression.NonNullAndHasErrors())
      Debug.Assert(receiver IsNot Nothing, $"Field '{NameOf(receiver)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(placeholder IsNot Nothing, $"Field '{NameOf(placeholder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(accessExpression IsNot Nothing, $"Field '{NameOf(accessExpression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Receiver = receiver
      _Placeholder = placeholder
      _AccessExpression = accessExpression
    End Sub
    Public ReadOnly Property receiver As BoundExpression

    Public ReadOnly Property placeholder As BoundRValuePlaceholder

    Public ReadOnly Property accessExpression As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitConditionalAccess(Me)
    End Function
    Public Function Update As BoundConditionalAccess
      If (receiver Is Me.Receiver) AndAlso (placeholder Is Me.Placeholder) AndAlso (accessExpression Is Me.AccessExpression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundConditionalAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundConditionalAccessReceiverPlaceholder : Inherits BoundRValuePlaceholderBase

    Public Sub New
      MyBase.New(BoundKind.ConditionalAccessReceiverPlaceholder, syntax, type, hasErrors)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _PlaceholderId = placeholderId
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public Sub New
      MyBase.New(BoundKind.ConditionalAccessReceiverPlaceholder, syntax, type)
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _PlaceholderId = placeholderId
      Validate()
    End Sub
    Public ReadOnly Property placeholderId As Integer

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitConditionalAccessReceiverPlaceholder(Me)
    End Function
    Public Function Update As BoundConditionalAccessReceiverPlaceholder
      If (placeholderId = Me.PlaceholderId) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundConditionalAccessReceiverPlaceholder
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundLoweredConditionalAccess : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.LoweredConditionalAccess, syntax, type, hasErrors OrElse receiverOrCondition.NonNullAndHasErrors() OrElse whenNotNull.NonNullAndHasErrors() OrElse whenNullOpt.NonNullAndHasErrors())
      Debug.Assert(receiverOrCondition IsNot Nothing, $"Field '{NameOf(receiverOrCondition)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(whenNotNull IsNot Nothing, $"Field '{NameOf(whenNotNull)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ReceiverOrCondition = receiverOrCondition
      _CaptureReceiver = captureReceiver
      _PlaceholderId = placeholderId
      _WhenNotNull = whenNotNull
      _WhenNullOpt = whenNullOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property receiverOrCondition As BoundExpression

    Public ReadOnly Property captureReceiver As Boolean

    Public ReadOnly Property placeholderId As Integer

    Public ReadOnly Property whenNotNull As BoundExpression

    Public ReadOnly Property whenNullOpt As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitLoweredConditionalAccess(Me)
    End Function
    Public Function Update As BoundLoweredConditionalAccess
      If (receiverOrCondition Is Me.ReceiverOrCondition) AndAlso (captureReceiver = Me.CaptureReceiver) AndAlso (placeholderId = Me.PlaceholderId) AndAlso (whenNotNull Is Me.WhenNotNull) AndAlso (whenNullOpt Is Me.WhenNullOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundLoweredConditionalAccess
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundComplexConditionalAccessReceiver : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.ComplexConditionalAccessReceiver, syntax, type, hasErrors OrElse valueTypeReceiver.NonNullAndHasErrors() OrElse referenceTypeReceiver.NonNullAndHasErrors())
      Debug.Assert(valueTypeReceiver IsNot Nothing, $"Field '{NameOf(valueTypeReceiver)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(referenceTypeReceiver IsNot Nothing, $"Field '{NameOf(referenceTypeReceiver)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _ValueTypeReceiver = valueTypeReceiver
      _ReferenceTypeReceiver = referenceTypeReceiver
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property valueTypeReceiver As BoundExpression

    Public ReadOnly Property referenceTypeReceiver As BoundExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitComplexConditionalAccessReceiver(Me)
    End Function
    Public Function Update As BoundComplexConditionalAccessReceiver
      If (valueTypeReceiver Is Me.ValueTypeReceiver) AndAlso (referenceTypeReceiver Is Me.ReferenceTypeReceiver) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundComplexConditionalAccessReceiver
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundNameOfOperator : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.NameOfOperator, syntax, type, hasErrors OrElse argument.NonNullAndHasErrors())
      Debug.Assert(argument IsNot Nothing, $"Field '{NameOf(argument)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Argument = argument
      _ConstantValueOpt = constantValueOpt
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property argument As BoundExpression

    Public Overrides ReadOnly Property constantValueOpt As ConstantValue

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitNameOfOperator(Me)
    End Function
    Public Function Update As BoundNameOfOperator
      If (argument Is Me.Argument) AndAlso (constantValueOpt Is Me.ConstantValueOpt) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundNameOfOperator
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundTypeAsValueExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.TypeAsValueExpression, syntax, type, hasErrors OrElse expression.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property expression As BoundTypeExpression

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitTypeAsValueExpression(Me)
    End Function
    Public Function Update As BoundTypeAsValueExpression
      If (expression Is Me.Expression) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundTypeAsValueExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundInterpolatedStringExpression : Inherits BoundExpression

    Public Sub New
      MyBase.New(BoundKind.InterpolatedStringExpression, syntax, type, hasErrors OrElse contents.NonNullAndHasErrors())
      Debug.Assert(Not contents.IsDefault, $"Field '{NameOf(contents)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(binder IsNot Nothing, $"Field '{NameOf(binder)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      Debug.Assert(type IsNot Nothing, $"Field '{NameOf(type)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Contents = contents
      _Binder = binder
      Validate()
    End Sub
    Private Partial Sub Validate
    End Sub
    Public ReadOnly Property contents As ImmutableArray(Of BoundNode)

    Public ReadOnly Property binder As Binder

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitInterpolatedStringExpression(Me)
    End Function
    Public Function Update As BoundInterpolatedStringExpression
      If (contents = Me.Contents) AndAlso (binder Is Me.Binder) AndAlso (type Is Me.Type) Then Return Me
      Dim result As New BoundInterpolatedStringExpression
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class

  Friend NotInheritable Partial Class BoundInterpolation : Inherits BoundNode

    Public Sub New
      MyBase.New(BoundKind.Interpolation, syntax, hasErrors OrElse expression.NonNullAndHasErrors() OrElse alignmentOpt.NonNullAndHasErrors() OrElse formatStringOpt.NonNullAndHasErrors())
      Debug.Assert(expression IsNot Nothing, $"Field '{NameOf(expression)}' cannot be null (use Null=""allow"" in BoundNodes.xml to remove this check)")
      _Expression = expression
      _AlignmentOpt = alignmentOpt
      _FormatStringOpt = formatStringOpt
    End Sub
    Public ReadOnly Property expression As BoundExpression

    Public ReadOnly Property alignmentOpt As BoundExpression

    Public ReadOnly Property formatStringOpt As BoundLiteral

    Public Overrides Function Accept As BoundNode
      Return visitor.VisitInterpolation(Me)
    End Function
    Public Function Update As BoundInterpolation
      If (expression Is Me.Expression) AndAlso (alignmentOpt Is Me.AlignmentOpt) AndAlso (formatStringOpt Is Me.FormatStringOpt) Then Return Me
      Dim result As New BoundInterpolation
      If Me.WasCompilerGenerated Then result.SetWasCompilerGenerated()
      Return result
    End Function
  End Class


  Friend MustInherit Partial Class BoundTreeVisitor(Of A,R)

    <MethodImpl(MethodImplOptions.NoInlining)>
    Friend Function VisitInternal As R
      Select Case node.Kind
        Case BoundKind.TypeArguments                                   : Return VisitTypeArguments(CType(node, BoundTypeArguments), arg)
        Case BoundKind.OmittedArgument                                 : Return VisitOmittedArgument(CType(node, BoundOmittedArgument), arg)
        Case BoundKind.LValueToRValueWrapper                           : Return VisitLValueToRValueWrapper(CType(node, BoundLValueToRValueWrapper), arg)
        Case BoundKind.WithLValueExpressionPlaceholder                 : Return VisitWithLValueExpressionPlaceholder(CType(node, BoundWithLValueExpressionPlaceholder), arg)
        Case BoundKind.WithRValueExpressionPlaceholder                 : Return VisitWithRValueExpressionPlaceholder(CType(node, BoundWithRValueExpressionPlaceholder), arg)
        Case BoundKind.RValuePlaceholder                               : Return VisitRValuePlaceholder(CType(node, BoundRValuePlaceholder), arg)
        Case BoundKind.LValuePlaceholder                               : Return VisitLValuePlaceholder(CType(node, BoundLValuePlaceholder), arg)
        Case BoundKind.Dup                                             : Return VisitDup(CType(node, BoundDup), arg)
        Case BoundKind.BadExpression                                   : Return VisitBadExpression(CType(node, BoundBadExpression), arg)
        Case BoundKind.BadStatement                                    : Return VisitBadStatement(CType(node, BoundBadStatement), arg)
        Case BoundKind.Parenthesized                                   : Return VisitParenthesized(CType(node, BoundParenthesized), arg)
        Case BoundKind.BadVariable                                     : Return VisitBadVariable(CType(node, BoundBadVariable), arg)
        Case BoundKind.ArrayAccess                                     : Return VisitArrayAccess(CType(node, BoundArrayAccess), arg)
        Case BoundKind.ArrayLength                                     : Return VisitArrayLength(CType(node, BoundArrayLength), arg)
        Case BoundKind.[GetType]                                       : Return VisitGetType(CType(node, BoundGetType), arg)
        Case BoundKind.FieldInfo                                       : Return VisitFieldInfo(CType(node, BoundFieldInfo), arg)
        Case BoundKind.MethodInfo                                      : Return VisitMethodInfo(CType(node, BoundMethodInfo), arg)
        Case BoundKind.TypeExpression                                  : Return VisitTypeExpression(CType(node, BoundTypeExpression), arg)
        Case BoundKind.TypeOrValueExpression                           : Return VisitTypeOrValueExpression(CType(node, BoundTypeOrValueExpression), arg)
        Case BoundKind.NamespaceExpression                             : Return VisitNamespaceExpression(CType(node, BoundNamespaceExpression), arg)
        Case BoundKind.MethodDefIndex                                  : Return VisitMethodDefIndex(CType(node, BoundMethodDefIndex), arg)
        Case BoundKind.MaximumMethodDefIndex                           : Return VisitMaximumMethodDefIndex(CType(node, BoundMaximumMethodDefIndex), arg)
        Case BoundKind.InstrumentationPayloadRoot                      : Return VisitInstrumentationPayloadRoot(CType(node, BoundInstrumentationPayloadRoot), arg)
        Case BoundKind.ModuleVersionId                                 : Return VisitModuleVersionId(CType(node, BoundModuleVersionId), arg)
        Case BoundKind.ModuleVersionIdString                           : Return VisitModuleVersionIdString(CType(node, BoundModuleVersionIdString), arg)
        Case BoundKind.SourceDocumentIndex                             : Return VisitSourceDocumentIndex(CType(node, BoundSourceDocumentIndex), arg)
        Case BoundKind.UnaryOperator                                   : Return VisitUnaryOperator(CType(node, BoundUnaryOperator), arg)
        Case BoundKind.UserDefinedUnaryOperator                        : Return VisitUserDefinedUnaryOperator(CType(node, BoundUserDefinedUnaryOperator), arg)
        Case BoundKind.NullableIsTrueOperator                          : Return VisitNullableIsTrueOperator(CType(node, BoundNullableIsTrueOperator), arg)
        Case BoundKind.BinaryOperator                                  : Return VisitBinaryOperator(CType(node, BoundBinaryOperator), arg)
        Case BoundKind.UserDefinedBinaryOperator                       : Return VisitUserDefinedBinaryOperator(CType(node, BoundUserDefinedBinaryOperator), arg)
        Case BoundKind.UserDefinedShortCircuitingOperator              : Return VisitUserDefinedShortCircuitingOperator(CType(node, BoundUserDefinedShortCircuitingOperator), arg)
        Case BoundKind.CompoundAssignmentTargetPlaceholder             : Return VisitCompoundAssignmentTargetPlaceholder(CType(node, BoundCompoundAssignmentTargetPlaceholder), arg)
        Case BoundKind.AssignmentOperator                              : Return VisitAssignmentOperator(CType(node, BoundAssignmentOperator), arg)
        Case BoundKind.ReferenceAssignment                             : Return VisitReferenceAssignment(CType(node, BoundReferenceAssignment), arg)
        Case BoundKind.AddressOfOperator                               : Return VisitAddressOfOperator(CType(node, BoundAddressOfOperator), arg)
        Case BoundKind.TernaryConditionalExpression                    : Return VisitTernaryConditionalExpression(CType(node, BoundTernaryConditionalExpression), arg)
        Case BoundKind.BinaryConditionalExpression                     : Return VisitBinaryConditionalExpression(CType(node, BoundBinaryConditionalExpression), arg)
        Case BoundKind.Conversion                                      : Return VisitConversion(CType(node, BoundConversion), arg)
        Case BoundKind.RelaxationLambda                                : Return VisitRelaxationLambda(CType(node, BoundRelaxationLambda), arg)
        Case BoundKind.ConvertedTupleElements                          : Return VisitConvertedTupleElements(CType(node, BoundConvertedTupleElements), arg)
        Case BoundKind.UserDefinedConversion                           : Return VisitUserDefinedConversion(CType(node, BoundUserDefinedConversion), arg)
        Case BoundKind.[DirectCast]                                    : Return VisitDirectCast(CType(node, BoundDirectCast), arg)
        Case BoundKind.[TryCast]                                       : Return VisitTryCast(CType(node, BoundTryCast), arg)
        Case BoundKind.[TypeOf]                                        : Return VisitTypeOf(CType(node, BoundTypeOf), arg)
        Case BoundKind.SequencePoint                                   : Return VisitSequencePoint(CType(node, BoundSequencePoint), arg)
        Case BoundKind.SequencePointExpression                         : Return VisitSequencePointExpression(CType(node, BoundSequencePointExpression), arg)
        Case BoundKind.SequencePointWithSpan                           : Return VisitSequencePointWithSpan(CType(node, BoundSequencePointWithSpan), arg)
        Case BoundKind.NoOpStatement                                   : Return VisitNoOpStatement(CType(node, BoundNoOpStatement), arg)
        Case BoundKind.MethodGroup                                     : Return VisitMethodGroup(CType(node, BoundMethodGroup), arg)
        Case BoundKind.PropertyGroup                                   : Return VisitPropertyGroup(CType(node, BoundPropertyGroup), arg)
        Case BoundKind.ReturnStatement                                 : Return VisitReturnStatement(CType(node, BoundReturnStatement), arg)
        Case BoundKind.YieldStatement                                  : Return VisitYieldStatement(CType(node, BoundYieldStatement), arg)
        Case BoundKind.ThrowStatement                                  : Return VisitThrowStatement(CType(node, BoundThrowStatement), arg)
        Case BoundKind.RedimStatement                                  : Return VisitRedimStatement(CType(node, BoundRedimStatement), arg)
        Case BoundKind.RedimClause                                     : Return VisitRedimClause(CType(node, BoundRedimClause), arg)
        Case BoundKind.EraseStatement                                  : Return VisitEraseStatement(CType(node, BoundEraseStatement), arg)
        Case BoundKind.[Call]                                          : Return VisitCall(CType(node, BoundCall), arg)
        Case BoundKind.Attribute                                       : Return VisitAttribute(CType(node, BoundAttribute), arg)
        Case BoundKind.LateMemberAccess                                : Return VisitLateMemberAccess(CType(node, BoundLateMemberAccess), arg)
        Case BoundKind.LateInvocation                                  : Return VisitLateInvocation(CType(node, BoundLateInvocation), arg)
        Case BoundKind.LateAddressOfOperator                           : Return VisitLateAddressOfOperator(CType(node, BoundLateAddressOfOperator), arg)
        Case BoundKind.TupleLiteral                                    : Return VisitTupleLiteral(CType(node, BoundTupleLiteral), arg)
        Case BoundKind.ConvertedTupleLiteral                           : Return VisitConvertedTupleLiteral(CType(node, BoundConvertedTupleLiteral), arg)
        Case BoundKind.ObjectCreationExpression                        : Return VisitObjectCreationExpression(CType(node, BoundObjectCreationExpression), arg)
        Case BoundKind.NoPiaObjectCreationExpression                   : Return VisitNoPiaObjectCreationExpression(CType(node, BoundNoPiaObjectCreationExpression), arg)
        Case BoundKind.AnonymousTypeCreationExpression                 : Return VisitAnonymousTypeCreationExpression(CType(node, BoundAnonymousTypeCreationExpression), arg)
        Case BoundKind.AnonymousTypePropertyAccess                     : Return VisitAnonymousTypePropertyAccess(CType(node, BoundAnonymousTypePropertyAccess), arg)
        Case BoundKind.AnonymousTypeFieldInitializer                   : Return VisitAnonymousTypeFieldInitializer(CType(node, BoundAnonymousTypeFieldInitializer), arg)
        Case BoundKind.ObjectInitializerExpression                     : Return VisitObjectInitializerExpression(CType(node, BoundObjectInitializerExpression), arg)
        Case BoundKind.CollectionInitializerExpression                 : Return VisitCollectionInitializerExpression(CType(node, BoundCollectionInitializerExpression), arg)
        Case BoundKind.NewT                                            : Return VisitNewT(CType(node, BoundNewT), arg)
        Case BoundKind.DelegateCreationExpression                      : Return VisitDelegateCreationExpression(CType(node, BoundDelegateCreationExpression), arg)
        Case BoundKind.ArrayCreation                                   : Return VisitArrayCreation(CType(node, BoundArrayCreation), arg)
        Case BoundKind.ArrayLiteral                                    : Return VisitArrayLiteral(CType(node, BoundArrayLiteral), arg)
        Case BoundKind.ArrayInitialization                             : Return VisitArrayInitialization(CType(node, BoundArrayInitialization), arg)
        Case BoundKind.FieldAccess                                     : Return VisitFieldAccess(CType(node, BoundFieldAccess), arg)
        Case BoundKind.PropertyAccess                                  : Return VisitPropertyAccess(CType(node, BoundPropertyAccess), arg)
        Case BoundKind.EventAccess                                     : Return VisitEventAccess(CType(node, BoundEventAccess), arg)
        Case BoundKind.Block                                           : Return VisitBlock(CType(node, BoundBlock), arg)
        Case BoundKind.StateMachineScope                               : Return VisitStateMachineScope(CType(node, BoundStateMachineScope), arg)
        Case BoundKind.LocalDeclaration                                : Return VisitLocalDeclaration(CType(node, BoundLocalDeclaration), arg)
        Case BoundKind.AsNewLocalDeclarations                          : Return VisitAsNewLocalDeclarations(CType(node, BoundAsNewLocalDeclarations), arg)
        Case BoundKind.DimStatement                                    : Return VisitDimStatement(CType(node, BoundDimStatement), arg)
        Case BoundKind.Initializer                                     : Return VisitInitializer(CType(node, BoundInitializer), arg)
        Case BoundKind.FieldInitializer                                : Return VisitFieldInitializer(CType(node, BoundFieldInitializer), arg)
        Case BoundKind.PropertyInitializer                             : Return VisitPropertyInitializer(CType(node, BoundPropertyInitializer), arg)
        Case BoundKind.ParameterEqualsValue                            : Return VisitParameterEqualsValue(CType(node, BoundParameterEqualsValue), arg)
        Case BoundKind.GlobalStatementInitializer                      : Return VisitGlobalStatementInitializer(CType(node, BoundGlobalStatementInitializer), arg)
        Case BoundKind.Sequence                                        : Return VisitSequence(CType(node, BoundSequence), arg)
        Case BoundKind.ExpressionStatement                             : Return VisitExpressionStatement(CType(node, BoundExpressionStatement), arg)
        Case BoundKind.IfStatement                                     : Return VisitIfStatement(CType(node, BoundIfStatement), arg)
        Case BoundKind.SelectStatement                                 : Return VisitSelectStatement(CType(node, BoundSelectStatement), arg)
        Case BoundKind.CaseBlock                                       : Return VisitCaseBlock(CType(node, BoundCaseBlock), arg)
        Case BoundKind.CaseStatement                                   : Return VisitCaseStatement(CType(node, BoundCaseStatement), arg)
        Case BoundKind.SimpleCaseClause                                : Return VisitSimpleCaseClause(CType(node, BoundSimpleCaseClause), arg)
        Case BoundKind.RangeCaseClause                                 : Return VisitRangeCaseClause(CType(node, BoundRangeCaseClause), arg)
        Case BoundKind.RelationalCaseClause                            : Return VisitRelationalCaseClause(CType(node, BoundRelationalCaseClause), arg)
        Case BoundKind.DoLoopStatement                                 : Return VisitDoLoopStatement(CType(node, BoundDoLoopStatement), arg)
        Case BoundKind.WhileStatement                                  : Return VisitWhileStatement(CType(node, BoundWhileStatement), arg)
        Case BoundKind.ForToUserDefinedOperators                       : Return VisitForToUserDefinedOperators(CType(node, BoundForToUserDefinedOperators), arg)
        Case BoundKind.ForToStatement                                  : Return VisitForToStatement(CType(node, BoundForToStatement), arg)
        Case BoundKind.ForEachStatement                                : Return VisitForEachStatement(CType(node, BoundForEachStatement), arg)
        Case BoundKind.ExitStatement                                   : Return VisitExitStatement(CType(node, BoundExitStatement), arg)
        Case BoundKind.ContinueStatement                               : Return VisitContinueStatement(CType(node, BoundContinueStatement), arg)
        Case BoundKind.TryStatement                                    : Return VisitTryStatement(CType(node, BoundTryStatement), arg)
        Case BoundKind.CatchBlock                                      : Return VisitCatchBlock(CType(node, BoundCatchBlock), arg)
        Case BoundKind.Literal                                         : Return VisitLiteral(CType(node, BoundLiteral), arg)
        Case BoundKind.MeReference                                     : Return VisitMeReference(CType(node, BoundMeReference), arg)
        Case BoundKind.ValueTypeMeReference                            : Return VisitValueTypeMeReference(CType(node, BoundValueTypeMeReference), arg)
        Case BoundKind.MyBaseReference                                 : Return VisitMyBaseReference(CType(node, BoundMyBaseReference), arg)
        Case BoundKind.MyClassReference                                : Return VisitMyClassReference(CType(node, BoundMyClassReference), arg)
        Case BoundKind.PreviousSubmissionReference                     : Return VisitPreviousSubmissionReference(CType(node, BoundPreviousSubmissionReference), arg)
        Case BoundKind.HostObjectMemberReference                       : Return VisitHostObjectMemberReference(CType(node, BoundHostObjectMemberReference), arg)
        Case BoundKind.Local                                           : Return VisitLocal(CType(node, BoundLocal), arg)
        Case BoundKind.PseudoVariable                                  : Return VisitPseudoVariable(CType(node, BoundPseudoVariable), arg)
        Case BoundKind.Parameter                                       : Return VisitParameter(CType(node, BoundParameter), arg)
        Case BoundKind.ByRefArgumentPlaceholder                        : Return VisitByRefArgumentPlaceholder(CType(node, BoundByRefArgumentPlaceholder), arg)
        Case BoundKind.ByRefArgumentWithCopyBack                       : Return VisitByRefArgumentWithCopyBack(CType(node, BoundByRefArgumentWithCopyBack), arg)
        Case BoundKind.LateBoundArgumentSupportingAssignmentWithCapture: Return VisitLateBoundArgumentSupportingAssignmentWithCapture(CType(node, BoundLateBoundArgumentSupportingAssignmentWithCapture), arg)
        Case BoundKind.LabelStatement                                  : Return VisitLabelStatement(CType(node, BoundLabelStatement), arg)
        Case BoundKind.Label                                           : Return VisitLabel(CType(node, BoundLabel), arg)
        Case BoundKind.GotoStatement                                   : Return VisitGotoStatement(CType(node, BoundGotoStatement), arg)
        Case BoundKind.StatementList                                   : Return VisitStatementList(CType(node, BoundStatementList), arg)
        Case BoundKind.ConditionalGoto                                 : Return VisitConditionalGoto(CType(node, BoundConditionalGoto), arg)
        Case BoundKind.WithStatement                                   : Return VisitWithStatement(CType(node, BoundWithStatement), arg)
        Case BoundKind.UnboundLambda                                   : Return VisitUnboundLambda(CType(node, UnboundLambda), arg)
        Case BoundKind.Lambda                                          : Return VisitLambda(CType(node, BoundLambda), arg)
        Case BoundKind.QueryExpression                                 : Return VisitQueryExpression(CType(node, BoundQueryExpression), arg)
        Case BoundKind.QuerySource                                     : Return VisitQuerySource(CType(node, BoundQuerySource), arg)
        Case BoundKind.ToQueryableCollectionConversion                 : Return VisitToQueryableCollectionConversion(CType(node, BoundToQueryableCollectionConversion), arg)
        Case BoundKind.QueryableSource                                 : Return VisitQueryableSource(CType(node, BoundQueryableSource), arg)
        Case BoundKind.QueryClause                                     : Return VisitQueryClause(CType(node, BoundQueryClause), arg)
        Case BoundKind.Ordering                                        : Return VisitOrdering(CType(node, BoundOrdering), arg)
        Case BoundKind.QueryLambda                                     : Return VisitQueryLambda(CType(node, BoundQueryLambda), arg)
        Case BoundKind.RangeVariableAssignment                         : Return VisitRangeVariableAssignment(CType(node, BoundRangeVariableAssignment), arg)
        Case BoundKind.GroupTypeInferenceLambda                        : Return VisitGroupTypeInferenceLambda(CType(node, GroupTypeInferenceLambda), arg)
        Case BoundKind.AggregateClause                                 : Return VisitAggregateClause(CType(node, BoundAggregateClause), arg)
        Case BoundKind.GroupAggregation                                : Return VisitGroupAggregation(CType(node, BoundGroupAggregation), arg)
        Case BoundKind.RangeVariable                                   : Return VisitRangeVariable(CType(node, BoundRangeVariable), arg)
        Case BoundKind.AddHandlerStatement                             : Return VisitAddHandlerStatement(CType(node, BoundAddHandlerStatement), arg)
        Case BoundKind.RemoveHandlerStatement                          : Return VisitRemoveHandlerStatement(CType(node, BoundRemoveHandlerStatement), arg)
        Case BoundKind.RaiseEventStatement                             : Return VisitRaiseEventStatement(CType(node, BoundRaiseEventStatement), arg)
        Case BoundKind.UsingStatement                                  : Return VisitUsingStatement(CType(node, BoundUsingStatement), arg)
        Case BoundKind.SyncLockStatement                               : Return VisitSyncLockStatement(CType(node, BoundSyncLockStatement), arg)
        Case BoundKind.XmlName                                         : Return VisitXmlName(CType(node, BoundXmlName), arg)
        Case BoundKind.XmlNamespace                                    : Return VisitXmlNamespace(CType(node, BoundXmlNamespace), arg)
        Case BoundKind.XmlDocument                                     : Return VisitXmlDocument(CType(node, BoundXmlDocument), arg)
        Case BoundKind.XmlDeclaration                                  : Return VisitXmlDeclaration(CType(node, BoundXmlDeclaration), arg)
        Case BoundKind.XmlProcessingInstruction                        : Return VisitXmlProcessingInstruction(CType(node, BoundXmlProcessingInstruction), arg)
        Case BoundKind.XmlComment                                      : Return VisitXmlComment(CType(node, BoundXmlComment), arg)
        Case BoundKind.XmlAttribute                                    : Return VisitXmlAttribute(CType(node, BoundXmlAttribute), arg)
        Case BoundKind.XmlElement                                      : Return VisitXmlElement(CType(node, BoundXmlElement), arg)
        Case BoundKind.XmlMemberAccess                                 : Return VisitXmlMemberAccess(CType(node, BoundXmlMemberAccess), arg)
        Case BoundKind.XmlEmbeddedExpression                           : Return VisitXmlEmbeddedExpression(CType(node, BoundXmlEmbeddedExpression), arg)
        Case BoundKind.XmlCData                                        : Return VisitXmlCData(CType(node, BoundXmlCData), arg)
        Case BoundKind.ResumeStatement                                 : Return VisitResumeStatement(CType(node, BoundResumeStatement), arg)
        Case BoundKind.OnErrorStatement                                : Return VisitOnErrorStatement(CType(node, BoundOnErrorStatement), arg)
        Case BoundKind.UnstructuredExceptionHandlingStatement          : Return VisitUnstructuredExceptionHandlingStatement(CType(node, BoundUnstructuredExceptionHandlingStatement), arg)
        Case BoundKind.UnstructuredExceptionHandlingCatchFilter        : Return VisitUnstructuredExceptionHandlingCatchFilter(CType(node, BoundUnstructuredExceptionHandlingCatchFilter), arg)
        Case BoundKind.UnstructuredExceptionOnErrorSwitch              : Return VisitUnstructuredExceptionOnErrorSwitch(CType(node, BoundUnstructuredExceptionOnErrorSwitch), arg)
        Case BoundKind.UnstructuredExceptionResumeSwitch               : Return VisitUnstructuredExceptionResumeSwitch(CType(node, BoundUnstructuredExceptionResumeSwitch), arg)
        Case BoundKind.AwaitOperator                                   : Return VisitAwaitOperator(CType(node, BoundAwaitOperator), arg)
        Case BoundKind.SpillSequence                                   : Return VisitSpillSequence(CType(node, BoundSpillSequence), arg)
        Case BoundKind.StopStatement                                   : Return VisitStopStatement(CType(node, BoundStopStatement), arg)
        Case BoundKind.EndStatement                                    : Return VisitEndStatement(CType(node, BoundEndStatement), arg)
        Case BoundKind.MidResult                                       : Return VisitMidResult(CType(node, BoundMidResult), arg)
        Case BoundKind.ConditionalAccess                               : Return VisitConditionalAccess(CType(node, BoundConditionalAccess), arg)
        Case BoundKind.ConditionalAccessReceiverPlaceholder            : Return VisitConditionalAccessReceiverPlaceholder(CType(node, BoundConditionalAccessReceiverPlaceholder), arg)
        Case BoundKind.LoweredConditionalAccess                        : Return VisitLoweredConditionalAccess(CType(node, BoundLoweredConditionalAccess), arg)
        Case BoundKind.ComplexConditionalAccessReceiver                : Return VisitComplexConditionalAccessReceiver(CType(node, BoundComplexConditionalAccessReceiver), arg)
        Case BoundKind.NameOfOperator                                  : Return VisitNameOfOperator(CType(node, BoundNameOfOperator), arg)
        Case BoundKind.TypeAsValueExpression                           : Return VisitTypeAsValueExpression(CType(node, BoundTypeAsValueExpression), arg)
        Case BoundKind.InterpolatedStringExpression                    : Return VisitInterpolatedStringExpression(CType(node, BoundInterpolatedStringExpression), arg)
        Case BoundKind.Interpolation                                   : Return VisitInterpolation(CType(node, BoundInterpolation), arg)
      End Select
      Return DefaultVisit(node, arg)
    End Function
  End Class
  Friend MustInherit Partial Class BoundTreeVisitor(Of A,R)

    Public Overridable Function VisitTypeArguments As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitOmittedArgument As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLValueToRValueWrapper As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitWithLValueExpressionPlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitWithRValueExpressionPlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRValuePlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLValuePlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitDup As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitBadExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitBadStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitParenthesized As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitBadVariable As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitArrayAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitArrayLength As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitGetType As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitFieldInfo As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMethodInfo As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTypeExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTypeOrValueExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitNamespaceExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMethodDefIndex As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMaximumMethodDefIndex As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitInstrumentationPayloadRoot As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitModuleVersionId As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitModuleVersionIdString As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSourceDocumentIndex As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUnaryOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUserDefinedUnaryOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitNullableIsTrueOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitBinaryOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUserDefinedBinaryOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUserDefinedShortCircuitingOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitCompoundAssignmentTargetPlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAssignmentOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitReferenceAssignment As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAddressOfOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTernaryConditionalExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitBinaryConditionalExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitConversion As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRelaxationLambda As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitConvertedTupleElements As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUserDefinedConversion As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitDirectCast As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTryCast As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTypeOf As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSequencePoint As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSequencePointExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSequencePointWithSpan As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitNoOpStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMethodGroup As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitPropertyGroup As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitReturnStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitYieldStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitThrowStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRedimStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRedimClause As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitEraseStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitCall As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAttribute As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLateMemberAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLateInvocation As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLateAddressOfOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTupleLiteral As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitConvertedTupleLiteral As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitObjectCreationExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitNoPiaObjectCreationExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAnonymousTypeCreationExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAnonymousTypePropertyAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAnonymousTypeFieldInitializer As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitObjectInitializerExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitCollectionInitializerExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitNewT As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitDelegateCreationExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitArrayCreation As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitArrayLiteral As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitArrayInitialization As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitFieldAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitPropertyAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitEventAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitBlock As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitStateMachineScope As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLocalDeclaration As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAsNewLocalDeclarations As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitDimStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitInitializer As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitFieldInitializer As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitPropertyInitializer As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitParameterEqualsValue As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitGlobalStatementInitializer As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSequence As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitExpressionStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitIfStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSelectStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitCaseBlock As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitCaseStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSimpleCaseClause As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRangeCaseClause As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRelationalCaseClause As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitDoLoopStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitWhileStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitForToUserDefinedOperators As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitForToStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitForEachStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitExitStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitContinueStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTryStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitCatchBlock As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLiteral As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMeReference As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitValueTypeMeReference As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMyBaseReference As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMyClassReference As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitPreviousSubmissionReference As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitHostObjectMemberReference As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLocal As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitPseudoVariable As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitParameter As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitByRefArgumentPlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitByRefArgumentWithCopyBack As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLateBoundArgumentSupportingAssignmentWithCapture As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLabelStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLabel As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitGotoStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitStatementList As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitConditionalGoto As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitWithStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUnboundLambda As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLambda As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitQueryExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitQuerySource As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitToQueryableCollectionConversion As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitQueryableSource As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitQueryClause As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitOrdering As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitQueryLambda As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRangeVariableAssignment As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitGroupTypeInferenceLambda As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAggregateClause As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitGroupAggregation As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRangeVariable As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAddHandlerStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRemoveHandlerStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitRaiseEventStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUsingStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSyncLockStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlName As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlNamespace As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlDocument As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlDeclaration As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlProcessingInstruction As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlComment As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlAttribute As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlElement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlMemberAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlEmbeddedExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitXmlCData As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitResumeStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitOnErrorStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUnstructuredExceptionHandlingStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUnstructuredExceptionHandlingCatchFilter As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUnstructuredExceptionOnErrorSwitch As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitUnstructuredExceptionResumeSwitch As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitAwaitOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitSpillSequence As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitStopStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitEndStatement As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitMidResult As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitConditionalAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitConditionalAccessReceiverPlaceholder As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitLoweredConditionalAccess As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitComplexConditionalAccessReceiver As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitNameOfOperator As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitTypeAsValueExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitInterpolatedStringExpression As R
      Return Me.DefaultVisit(node,arg)
    End Function
    Public Overridable Function VisitInterpolation As R
      Return Me.DefaultVisit(node,arg)
    End Function
  End Class
  Friend MustInherit Partial Class BoundTreeVisitor

    Public Overridable Function VisitTypeArguments As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitOmittedArgument As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLValueToRValueWrapper As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitWithLValueExpressionPlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitWithRValueExpressionPlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRValuePlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLValuePlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitDup As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitBadExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitBadStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitParenthesized As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitBadVariable As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitArrayAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitArrayLength As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitGetType As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitFieldInfo As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMethodInfo As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTypeExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTypeOrValueExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitNamespaceExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMethodDefIndex As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMaximumMethodDefIndex As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitInstrumentationPayloadRoot As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitModuleVersionId As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitModuleVersionIdString As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSourceDocumentIndex As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUnaryOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUserDefinedUnaryOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitNullableIsTrueOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitBinaryOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUserDefinedBinaryOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUserDefinedShortCircuitingOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitCompoundAssignmentTargetPlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAssignmentOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitReferenceAssignment As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAddressOfOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTernaryConditionalExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitBinaryConditionalExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitConversion As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRelaxationLambda As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitConvertedTupleElements As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUserDefinedConversion As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitDirectCast As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTryCast As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTypeOf As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSequencePoint As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSequencePointExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSequencePointWithSpan As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitNoOpStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMethodGroup As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitPropertyGroup As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitReturnStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitYieldStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitThrowStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRedimStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRedimClause As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitEraseStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitCall As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAttribute As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLateMemberAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLateInvocation As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLateAddressOfOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTupleLiteral As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitConvertedTupleLiteral As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitObjectCreationExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitNoPiaObjectCreationExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAnonymousTypeCreationExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAnonymousTypePropertyAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAnonymousTypeFieldInitializer As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitObjectInitializerExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitCollectionInitializerExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitNewT As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitDelegateCreationExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitArrayCreation As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitArrayLiteral As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitArrayInitialization As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitFieldAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitPropertyAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitEventAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitBlock As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitStateMachineScope As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLocalDeclaration As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAsNewLocalDeclarations As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitDimStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitInitializer As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitFieldInitializer As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitPropertyInitializer As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitParameterEqualsValue As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitGlobalStatementInitializer As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSequence As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitExpressionStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitIfStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSelectStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitCaseBlock As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitCaseStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSimpleCaseClause As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRangeCaseClause As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRelationalCaseClause As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitDoLoopStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitWhileStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitForToUserDefinedOperators As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitForToStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitForEachStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitExitStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitContinueStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTryStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitCatchBlock As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLiteral As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMeReference As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitValueTypeMeReference As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMyBaseReference As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMyClassReference As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitPreviousSubmissionReference As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitHostObjectMemberReference As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLocal As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitPseudoVariable As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitParameter As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitByRefArgumentPlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitByRefArgumentWithCopyBack As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLateBoundArgumentSupportingAssignmentWithCapture As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLabelStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLabel As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitGotoStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitStatementList As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitConditionalGoto As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitWithStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUnboundLambda As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLambda As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitQueryExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitQuerySource As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitToQueryableCollectionConversion As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitQueryableSource As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitQueryClause As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitOrdering As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitQueryLambda As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRangeVariableAssignment As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitGroupTypeInferenceLambda As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAggregateClause As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitGroupAggregation As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRangeVariable As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAddHandlerStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRemoveHandlerStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitRaiseEventStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUsingStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSyncLockStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlName As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlNamespace As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlDocument As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlDeclaration As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlProcessingInstruction As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlComment As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlAttribute As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlElement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlMemberAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlEmbeddedExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitXmlCData As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitResumeStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitOnErrorStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUnstructuredExceptionHandlingStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUnstructuredExceptionHandlingCatchFilter As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUnstructuredExceptionOnErrorSwitch As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitUnstructuredExceptionResumeSwitch As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitAwaitOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitSpillSequence As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitStopStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitEndStatement As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitMidResult As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitConditionalAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitConditionalAccessReceiverPlaceholder As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitLoweredConditionalAccess As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitComplexConditionalAccessReceiver As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitNameOfOperator As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitTypeAsValueExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitInterpolatedStringExpression As BoundNode
      Return Me.DefaultVisit(node)
    End Function
    Public Overridable Function VisitInterpolation As BoundNode
      Return Me.DefaultVisit(node)
    End Function
  End Class

  Friend MustInherit Partial Class BoundTreeWalker : Inherits BoundTreeVisitor

    Public Overrides Function VisitTypeArguments As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitOmittedArgument As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitLValueToRValueWrapper As BoundNode
      Me.Visit(node.UnderlyingLValue)
      Return Nothing
    End Function
    Public Overrides Function VisitWithLValueExpressionPlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitWithRValueExpressionPlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitRValuePlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitLValuePlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitDup As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitBadExpression As BoundNode
      Me.VisitList(node.ChildBoundNodes)
      Return Nothing
    End Function
    Public Overrides Function VisitBadStatement As BoundNode
      Me.VisitList(node.ChildBoundNodes)
      Return Nothing
    End Function
    Public Overrides Function VisitParenthesized As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitBadVariable As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitArrayAccess As BoundNode
      Me.Visit(node.Expression)
      Me.VisitList(node.Indices)
      Return Nothing
    End Function
    Public Overrides Function VisitArrayLength As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitGetType As BoundNode
      Me.Visit(node.SourceType)
      Return Nothing
    End Function
    Public Overrides Function VisitFieldInfo As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMethodInfo As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitTypeExpression As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitTypeOrValueExpression As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitNamespaceExpression As BoundNode
      Me.Visit(node.UnevaluatedReceiverOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitMethodDefIndex As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMaximumMethodDefIndex As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitInstrumentationPayloadRoot As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitModuleVersionId As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitModuleVersionIdString As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitSourceDocumentIndex As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitUnaryOperator As BoundNode
      Me.Visit(node.Operand)
      Return Nothing
    End Function
    Public Overrides Function VisitUserDefinedUnaryOperator As BoundNode
      Me.Visit(node.UnderlyingExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitNullableIsTrueOperator As BoundNode
      Me.Visit(node.Operand)
      Return Nothing
    End Function
    Public Overrides Function VisitBinaryOperator As BoundNode
      Me.Visit(node.Left)
      Me.Visit(node.Right)
      Return Nothing
    End Function
    Public Overrides Function VisitUserDefinedBinaryOperator As BoundNode
      Me.Visit(node.UnderlyingExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitUserDefinedShortCircuitingOperator As BoundNode
      Me.Visit(node.LeftOperand)
      Me.Visit(node.LeftOperandPlaceholder)
      Me.Visit(node.LeftTest)
      Me.Visit(node.BitwiseOperator)
      Return Nothing
    End Function
    Public Overrides Function VisitCompoundAssignmentTargetPlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitAssignmentOperator As BoundNode
      Me.Visit(node.Left)
      Me.Visit(node.LeftOnTheRightOpt)
      Me.Visit(node.Right)
      Return Nothing
    End Function
    Public Overrides Function VisitReferenceAssignment As BoundNode
      Me.Visit(node.ByRefLocal)
      Me.Visit(node.LValue)
      Return Nothing
    End Function
    Public Overrides Function VisitAddressOfOperator As BoundNode
      Me.Visit(node.MethodGroup)
      Return Nothing
    End Function
    Public Overrides Function VisitTernaryConditionalExpression As BoundNode
      Me.Visit(node.Condition)
      Me.Visit(node.WhenTrue)
      Me.Visit(node.WhenFalse)
      Return Nothing
    End Function
    Public Overrides Function VisitBinaryConditionalExpression As BoundNode
      Me.Visit(node.TestExpression)
      Me.Visit(node.ElseExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitConversion As BoundNode
      Me.Visit(node.Operand)
      Me.Visit(node.ExtendedInfoOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitRelaxationLambda As BoundNode
      Me.Visit(node.Lambda)
      Me.Visit(node.ReceiverPlaceholderOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitConvertedTupleElements As BoundNode
      Me.VisitList(node.ElementPlaceholders)
      Me.VisitList(node.ConvertedElements)
      Return Nothing
    End Function
    Public Overrides Function VisitUserDefinedConversion As BoundNode
      Me.Visit(node.UnderlyingExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitDirectCast As BoundNode
      Me.Visit(node.Operand)
      Me.Visit(node.RelaxationLambdaOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitTryCast As BoundNode
      Me.Visit(node.Operand)
      Me.Visit(node.RelaxationLambdaOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitTypeOf As BoundNode
      Me.Visit(node.Operand)
      Return Nothing
    End Function
    Public Overrides Function VisitSequencePoint As BoundNode
      Me.Visit(node.StatementOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitSequencePointExpression As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitSequencePointWithSpan As BoundNode
      Me.Visit(node.StatementOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitNoOpStatement As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMethodGroup As BoundNode
      Me.Visit(node.TypeArgumentsOpt)
      Me.Visit(node.ReceiverOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitPropertyGroup As BoundNode
      Me.Visit(node.ReceiverOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitReturnStatement As BoundNode
      Me.Visit(node.ExpressionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitYieldStatement As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitThrowStatement As BoundNode
      Me.Visit(node.ExpressionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitRedimStatement As BoundNode
      Me.VisitList(node.Clauses)
      Return Nothing
    End Function
    Public Overrides Function VisitRedimClause As BoundNode
      Me.Visit(node.Operand)
      Me.VisitList(node.Indices)
      Return Nothing
    End Function
    Public Overrides Function VisitEraseStatement As BoundNode
      Me.VisitList(node.Clauses)
      Return Nothing
    End Function
    Public Overrides Function VisitCall As BoundNode
      Me.Visit(node.ReceiverOpt)
      Me.VisitList(node.Arguments)
      Return Nothing
    End Function
    Public Overrides Function VisitAttribute As BoundNode
      Me.VisitList(node.ConstructorArguments)
      Me.VisitList(node.NamedArguments)
      Return Nothing
    End Function
    Public Overrides Function VisitLateMemberAccess As BoundNode
      Me.Visit(node.ReceiverOpt)
      Me.Visit(node.TypeArgumentsOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitLateInvocation As BoundNode
      Me.Visit(node.Member)
      Me.VisitList(node.ArgumentsOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitLateAddressOfOperator As BoundNode
      Me.Visit(node.MemberAccess)
      Return Nothing
    End Function
    Public Overrides Function VisitTupleLiteral As BoundNode
      Me.VisitList(node.Arguments)
      Return Nothing
    End Function
    Public Overrides Function VisitConvertedTupleLiteral As BoundNode
      Me.VisitList(node.Arguments)
      Return Nothing
    End Function
    Public Overrides Function VisitObjectCreationExpression As BoundNode
      Me.VisitList(node.Arguments)
      Me.Visit(node.InitializerOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitNoPiaObjectCreationExpression As BoundNode
      Me.Visit(node.InitializerOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitAnonymousTypeCreationExpression As BoundNode
      Me.VisitList(node.Declarations)
      Me.VisitList(node.Arguments)
      Return Nothing
    End Function
    Public Overrides Function VisitAnonymousTypePropertyAccess As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitAnonymousTypeFieldInitializer As BoundNode
      Me.Visit(node.Value)
      Return Nothing
    End Function
    Public Overrides Function VisitObjectInitializerExpression As BoundNode
      Me.Visit(node.PlaceholderOpt)
      Me.VisitList(node.Initializers)
      Return Nothing
    End Function
    Public Overrides Function VisitCollectionInitializerExpression As BoundNode
      Me.Visit(node.PlaceholderOpt)
      Me.VisitList(node.Initializers)
      Return Nothing
    End Function
    Public Overrides Function VisitNewT As BoundNode
      Me.Visit(node.InitializerOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitDelegateCreationExpression As BoundNode
      Me.Visit(node.ReceiverOpt)
      Me.Visit(node.RelaxationLambdaOpt)
      Me.Visit(node.RelaxationReceiverPlaceholderOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitArrayCreation As BoundNode
      Me.VisitList(node.Bounds)
      Me.Visit(node.InitializerOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitArrayLiteral As BoundNode
      Me.VisitList(node.Bounds)
      Me.Visit(node.Initializer)
      Return Nothing
    End Function
    Public Overrides Function VisitArrayInitialization As BoundNode
      Me.VisitList(node.Initializers)
      Return Nothing
    End Function
    Public Overrides Function VisitFieldAccess As BoundNode
      Me.Visit(node.ReceiverOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitPropertyAccess As BoundNode
      Me.Visit(node.ReceiverOpt)
      Me.VisitList(node.Arguments)
      Return Nothing
    End Function
    Public Overrides Function VisitEventAccess As BoundNode
      Me.Visit(node.ReceiverOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitBlock As BoundNode
      Me.VisitList(node.Statements)
      Return Nothing
    End Function
    Public Overrides Function VisitStateMachineScope As BoundNode
      Me.Visit(node.Statement)
      Return Nothing
    End Function
    Public Overrides Function VisitLocalDeclaration As BoundNode
      Me.Visit(node.DeclarationInitializerOpt)
      Me.Visit(node.IdentifierInitializerOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitAsNewLocalDeclarations As BoundNode
      Me.VisitList(node.LocalDeclarations)
      Me.Visit(node.Initializer)
      Return Nothing
    End Function
    Public Overrides Function VisitDimStatement As BoundNode
      Me.VisitList(node.LocalDeclarations)
      Me.Visit(node.InitializerOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitInitializer As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitFieldInitializer As BoundNode
      Me.Visit(node.MemberAccessExpressionOpt)
      Me.Visit(node.InitialValue)
      Return Nothing
    End Function
    Public Overrides Function VisitPropertyInitializer As BoundNode
      Me.Visit(node.MemberAccessExpressionOpt)
      Me.Visit(node.InitialValue)
      Return Nothing
    End Function
    Public Overrides Function VisitParameterEqualsValue As BoundNode
      Me.Visit(node.Value)
      Return Nothing
    End Function
    Public Overrides Function VisitGlobalStatementInitializer As BoundNode
      Me.Visit(node.Statement)
      Return Nothing
    End Function
    Public Overrides Function VisitSequence As BoundNode
      Me.VisitList(node.SideEffects)
      Me.Visit(node.ValueOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitExpressionStatement As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitIfStatement As BoundNode
      Me.Visit(node.Condition)
      Me.Visit(node.Consequence)
      Me.Visit(node.AlternativeOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitSelectStatement As BoundNode
      Me.Visit(node.ExpressionStatement)
      Me.Visit(node.ExprPlaceholderOpt)
      Me.VisitList(node.CaseBlocks)
      Return Nothing
    End Function
    Public Overrides Function VisitCaseBlock As BoundNode
      Me.Visit(node.CaseStatement)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitCaseStatement As BoundNode
      Me.VisitList(node.CaseClauses)
      Me.Visit(node.ConditionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitSimpleCaseClause As BoundNode
      Me.Visit(node.ValueOpt)
      Me.Visit(node.ConditionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitRangeCaseClause As BoundNode
      Me.Visit(node.LowerBoundOpt)
      Me.Visit(node.UpperBoundOpt)
      Me.Visit(node.LowerBoundConditionOpt)
      Me.Visit(node.UpperBoundConditionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitRelationalCaseClause As BoundNode
      Me.Visit(node.ValueOpt)
      Me.Visit(node.ConditionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitDoLoopStatement As BoundNode
      Me.Visit(node.TopConditionOpt)
      Me.Visit(node.BottomConditionOpt)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitWhileStatement As BoundNode
      Me.Visit(node.Condition)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitForToUserDefinedOperators As BoundNode
      Me.Visit(node.LeftOperandPlaceholder)
      Me.Visit(node.RightOperandPlaceholder)
      Me.Visit(node.Addition)
      Me.Visit(node.Subtraction)
      Me.Visit(node.LessThanOrEqual)
      Me.Visit(node.GreaterThanOrEqual)
      Return Nothing
    End Function
    Public Overrides Function VisitForToStatement As BoundNode
      Me.Visit(node.InitialValue)
      Me.Visit(node.LimitValue)
      Me.Visit(node.StepValue)
      Me.Visit(node.OperatorsOpt)
      Me.Visit(node.ControlVariable)
      Me.Visit(node.Body)
      Me.VisitList(node.NextVariablesOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitForEachStatement As BoundNode
      Me.Visit(node.Collection)
      Me.Visit(node.ControlVariable)
      Me.Visit(node.Body)
      Me.VisitList(node.NextVariablesOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitExitStatement As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitContinueStatement As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitTryStatement As BoundNode
      Me.Visit(node.TryBlock)
      Me.VisitList(node.CatchBlocks)
      Me.Visit(node.FinallyBlockOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitCatchBlock As BoundNode
      Me.Visit(node.ExceptionSourceOpt)
      Me.Visit(node.ErrorLineNumberOpt)
      Me.Visit(node.ExceptionFilterOpt)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitLiteral As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMeReference As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitValueTypeMeReference As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMyBaseReference As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMyClassReference As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitPreviousSubmissionReference As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitHostObjectMemberReference As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitLocal As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitPseudoVariable As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitParameter As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitByRefArgumentPlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitByRefArgumentWithCopyBack As BoundNode
      Me.Visit(node.OriginalArgument)
      Me.Visit(node.InConversion)
      Me.Visit(node.InPlaceholder)
      Me.Visit(node.OutConversion)
      Me.Visit(node.OutPlaceholder)
      Return Nothing
    End Function
    Public Overrides Function VisitLateBoundArgumentSupportingAssignmentWithCapture As BoundNode
      Me.Visit(node.OriginalArgument)
      Return Nothing
    End Function
    Public Overrides Function VisitLabelStatement As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitLabel As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitGotoStatement As BoundNode
      Me.Visit(node.LabelExpressionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitStatementList As BoundNode
      Me.VisitList(node.Statements)
      Return Nothing
    End Function
    Public Overrides Function VisitConditionalGoto As BoundNode
      Me.Visit(node.Condition)
      Return Nothing
    End Function
    Public Overrides Function VisitWithStatement As BoundNode
      Me.Visit(node.OriginalExpression)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitUnboundLambda As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitLambda As BoundNode
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitQueryExpression As BoundNode
      Me.Visit(node.LastOperator)
      Return Nothing
    End Function
    Public Overrides Function VisitQuerySource As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitToQueryableCollectionConversion As BoundNode
      Me.Visit(node.ConversionCall)
      Return Nothing
    End Function
    Public Overrides Function VisitQueryableSource As BoundNode
      Me.Visit(node.Source)
      Return Nothing
    End Function
    Public Overrides Function VisitQueryClause As BoundNode
      Me.Visit(node.UnderlyingExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitOrdering As BoundNode
      Me.Visit(node.UnderlyingExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitQueryLambda As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitRangeVariableAssignment As BoundNode
      Me.Visit(node.Value)
      Return Nothing
    End Function
    Public Overrides Function VisitGroupTypeInferenceLambda As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitAggregateClause As BoundNode
      Me.Visit(node.CapturedGroupOpt)
      Me.Visit(node.GroupPlaceholderOpt)
      Me.Visit(node.UnderlyingExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitGroupAggregation As BoundNode
      Me.Visit(node.Group)
      Return Nothing
    End Function
    Public Overrides Function VisitRangeVariable As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitAddHandlerStatement As BoundNode
      Me.Visit(node.EventAccess)
      Me.Visit(node.Handler)
      Return Nothing
    End Function
    Public Overrides Function VisitRemoveHandlerStatement As BoundNode
      Me.Visit(node.EventAccess)
      Me.Visit(node.Handler)
      Return Nothing
    End Function
    Public Overrides Function VisitRaiseEventStatement As BoundNode
      Me.Visit(node.EventInvocation)
      Return Nothing
    End Function
    Public Overrides Function VisitUsingStatement As BoundNode
      Me.VisitList(node.ResourceList)
      Me.Visit(node.ResourceExpressionOpt)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitSyncLockStatement As BoundNode
      Me.Visit(node.LockExpression)
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlName As BoundNode
      Me.Visit(node.XmlNamespace)
      Me.Visit(node.LocalName)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlNamespace As BoundNode
      Me.Visit(node.XmlNamespace)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlDocument As BoundNode
      Me.Visit(node.Declaration)
      Me.VisitList(node.ChildNodes)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlDeclaration As BoundNode
      Me.Visit(node.Version)
      Me.Visit(node.Encoding)
      Me.Visit(node.Standalone)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlProcessingInstruction As BoundNode
      Me.Visit(node.Target)
      Me.Visit(node.Data)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlComment As BoundNode
      Me.Visit(node.Value)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlAttribute As BoundNode
      Me.Visit(node.Name)
      Me.Visit(node.Value)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlElement As BoundNode
      Me.Visit(node.Argument)
      Me.VisitList(node.ChildNodes)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlMemberAccess As BoundNode
      Me.Visit(node.MemberAccess)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlEmbeddedExpression As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitXmlCData As BoundNode
      Me.Visit(node.Value)
      Return Nothing
    End Function
    Public Overrides Function VisitResumeStatement As BoundNode
      Me.Visit(node.LabelExpressionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitOnErrorStatement As BoundNode
      Me.Visit(node.LabelExpressionOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitUnstructuredExceptionHandlingStatement As BoundNode
      Me.Visit(node.Body)
      Return Nothing
    End Function
    Public Overrides Function VisitUnstructuredExceptionHandlingCatchFilter As BoundNode
      Me.Visit(node.ActiveHandlerLocal)
      Me.Visit(node.ResumeTargetLocal)
      Return Nothing
    End Function
    Public Overrides Function VisitUnstructuredExceptionOnErrorSwitch As BoundNode
      Me.Visit(node.Value)
      Me.VisitList(node.Jumps)
      Return Nothing
    End Function
    Public Overrides Function VisitUnstructuredExceptionResumeSwitch As BoundNode
      Me.Visit(node.ResumeTargetTemporary)
      Me.Visit(node.ResumeLabel)
      Me.Visit(node.ResumeNextLabel)
      Me.VisitList(node.Jumps)
      Return Nothing
    End Function
    Public Overrides Function VisitAwaitOperator As BoundNode
      Me.Visit(node.Operand)
      Me.Visit(node.AwaitableInstancePlaceholder)
      Me.Visit(node.GetAwaiter)
      Me.Visit(node.AwaiterInstancePlaceholder)
      Me.Visit(node.IsCompleted)
      Me.Visit(node.GetResult)
      Return Nothing
    End Function
    Public Overrides Function VisitSpillSequence As BoundNode
      Me.VisitList(node.Statements)
      Me.Visit(node.ValueOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitStopStatement As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitEndStatement As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitMidResult As BoundNode
      Me.Visit(node.Original)
      Me.Visit(node.Start)
      Me.Visit(node.LengthOpt)
      Me.Visit(node.Source)
      Return Nothing
    End Function
    Public Overrides Function VisitConditionalAccess As BoundNode
      Me.Visit(node.Receiver)
      Me.Visit(node.Placeholder)
      Me.Visit(node.AccessExpression)
      Return Nothing
    End Function
    Public Overrides Function VisitConditionalAccessReceiverPlaceholder As BoundNode
      Return Nothing
    End Function
    Public Overrides Function VisitLoweredConditionalAccess As BoundNode
      Me.Visit(node.ReceiverOrCondition)
      Me.Visit(node.WhenNotNull)
      Me.Visit(node.WhenNullOpt)
      Return Nothing
    End Function
    Public Overrides Function VisitComplexConditionalAccessReceiver As BoundNode
      Me.Visit(node.ValueTypeReceiver)
      Me.Visit(node.ReferenceTypeReceiver)
      Return Nothing
    End Function
    Public Overrides Function VisitNameOfOperator As BoundNode
      Me.Visit(node.Argument)
      Return Nothing
    End Function
    Public Overrides Function VisitTypeAsValueExpression As BoundNode
      Me.Visit(node.Expression)
      Return Nothing
    End Function
    Public Overrides Function VisitInterpolatedStringExpression As BoundNode
      Me.VisitList(node.Contents)
      Return Nothing
    End Function
    Public Overrides Function VisitInterpolation As BoundNode
      Me.Visit(node.Expression)
      Me.Visit(node.AlignmentOpt)
      Me.Visit(node.FormatStringOpt)
      Return Nothing
    End Function
  End Class

  Friend MustInherit Partial Class BoundTreeRewriter

  End Class

  Friend NotInheritable Class BoundTreeDumperNodeProducer : Inherits BoundTreeVisitor(Of Object, TreeDumperNode)


    Private Sub New
    End Sub
    Public Shared Function MakeTree As TreeDumperNode
      Return (New BoundTreeDumperNodeProducer()).Visit(node, Nothing)

    End Function
    Public Overrides Function VisitTypeArguments As TreeDumperNode
      Return New TreeDumperNode("typeArguments", Nothing, {
          New TreeDumperNode("arguments", node.Arguments, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitOmittedArgument As TreeDumperNode
      Return New TreeDumperNode("omittedArgument", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLValueToRValueWrapper As TreeDumperNode
      Return New TreeDumperNode("lValueToRValueWrapper", Nothing, {
          New TreeDumperNode("underlyingLValue", Nothing, { Visit(node.UnderlyingLValue, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitWithLValueExpressionPlaceholder As TreeDumperNode
      Return New TreeDumperNode("withLValueExpressionPlaceholder", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitWithRValueExpressionPlaceholder As TreeDumperNode
      Return New TreeDumperNode("withRValueExpressionPlaceholder", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitRValuePlaceholder As TreeDumperNode
      Return New TreeDumperNode("rValuePlaceholder", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLValuePlaceholder As TreeDumperNode
      Return New TreeDumperNode("lValuePlaceholder", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitDup As TreeDumperNode
      Return New TreeDumperNode("dup", Nothing, {
          New TreeDumperNode("isReference", node.IsReference, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitBadExpression As TreeDumperNode
      Return New TreeDumperNode("badExpression", Nothing, {
          New TreeDumperNode("resultKind", node.ResultKind, Nothing),
          New TreeDumperNode("symbols", node.Symbols, Nothing),
          New TreeDumperNode("childBoundNodes", Nothing, From x In node.ChildBoundNodes Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitBadStatement As TreeDumperNode
      Return New TreeDumperNode("badStatement", Nothing, {
          New TreeDumperNode("childBoundNodes", Nothing, From x In node.ChildBoundNodes Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitParenthesized As TreeDumperNode
      Return New TreeDumperNode("parenthesized", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitBadVariable As TreeDumperNode
      Return New TreeDumperNode("badVariable", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitArrayAccess As TreeDumperNode
      Return New TreeDumperNode("arrayAccess", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("indices", Nothing, From x In node.Indices Select Visit(x, Nothing)),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitArrayLength As TreeDumperNode
      Return New TreeDumperNode("arrayLength", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitGetType As TreeDumperNode
      Return New TreeDumperNode("[getType]", Nothing, {
          New TreeDumperNode("sourceType", Nothing, { Visit(node.SourceType, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitFieldInfo As TreeDumperNode
      Return New TreeDumperNode("fieldInfo", Nothing, {
          New TreeDumperNode("field", node.Field, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitMethodInfo As TreeDumperNode
      Return New TreeDumperNode("methodInfo", Nothing, {
          New TreeDumperNode("method", node.Method, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTypeExpression As TreeDumperNode
      Return New TreeDumperNode("typeExpression", Nothing, {
          New TreeDumperNode("unevaluatedReceiverOpt", Nothing, { Visit(node.UnevaluatedReceiverOpt, Nothing) }),
          New TreeDumperNode("aliasOpt", node.AliasOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTypeOrValueExpression As TreeDumperNode
      Return New TreeDumperNode("typeOrValueExpression", Nothing, {
          New TreeDumperNode("data", node.Data, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitNamespaceExpression As TreeDumperNode
      Return New TreeDumperNode("namespaceExpression", Nothing, {
          New TreeDumperNode("unevaluatedReceiverOpt", Nothing, { Visit(node.UnevaluatedReceiverOpt, Nothing) }),
          New TreeDumperNode("aliasOpt", node.AliasOpt, Nothing),
          New TreeDumperNode("namespaceSymbol", node.NamespaceSymbol, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitMethodDefIndex As TreeDumperNode
      Return New TreeDumperNode("methodDefIndex", Nothing, {
          New TreeDumperNode("method", node.Method, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitMaximumMethodDefIndex As TreeDumperNode
      Return New TreeDumperNode("maximumMethodDefIndex", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitInstrumentationPayloadRoot As TreeDumperNode
      Return New TreeDumperNode("instrumentationPayloadRoot", Nothing, {
          New TreeDumperNode("analysisKind", node.AnalysisKind, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitModuleVersionId As TreeDumperNode
      Return New TreeDumperNode("moduleVersionId", Nothing, {
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitModuleVersionIdString As TreeDumperNode
      Return New TreeDumperNode("moduleVersionIdString", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitSourceDocumentIndex As TreeDumperNode
      Return New TreeDumperNode("sourceDocumentIndex", Nothing, {
          New TreeDumperNode("document", node.Document, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitUnaryOperator As TreeDumperNode
      Return New TreeDumperNode("unaryOperator", Nothing, {
          New TreeDumperNode("operatorKind", node.OperatorKind, Nothing),
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("checked", node.Checked, Nothing),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitUserDefinedUnaryOperator As TreeDumperNode
      Return New TreeDumperNode("userDefinedUnaryOperator", Nothing, {
          New TreeDumperNode("operatorKind", node.OperatorKind, Nothing),
          New TreeDumperNode("underlyingExpression", Nothing, { Visit(node.UnderlyingExpression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitNullableIsTrueOperator As TreeDumperNode
      Return New TreeDumperNode("nullableIsTrueOperator", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitBinaryOperator As TreeDumperNode
      Return New TreeDumperNode("binaryOperator", Nothing, {
          New TreeDumperNode("operatorKind", node.OperatorKind, Nothing),
          New TreeDumperNode("left", Nothing, { Visit(node.Left, Nothing) }),
          New TreeDumperNode("right", Nothing, { Visit(node.Right, Nothing) }),
          New TreeDumperNode("checked", node.Checked, Nothing),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitUserDefinedBinaryOperator As TreeDumperNode
      Return New TreeDumperNode("userDefinedBinaryOperator", Nothing, {
          New TreeDumperNode("operatorKind", node.OperatorKind, Nothing),
          New TreeDumperNode("underlyingExpression", Nothing, { Visit(node.UnderlyingExpression, Nothing) }),
          New TreeDumperNode("checked", node.Checked, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitUserDefinedShortCircuitingOperator As TreeDumperNode
      Return New TreeDumperNode("userDefinedShortCircuitingOperator", Nothing, {
          New TreeDumperNode("leftOperand", Nothing, { Visit(node.LeftOperand, Nothing) }),
          New TreeDumperNode("leftOperandPlaceholder", Nothing, { Visit(node.LeftOperandPlaceholder, Nothing) }),
          New TreeDumperNode("leftTest", Nothing, { Visit(node.LeftTest, Nothing) }),
          New TreeDumperNode("bitwiseOperator", Nothing, { Visit(node.BitwiseOperator, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitCompoundAssignmentTargetPlaceholder As TreeDumperNode
      Return New TreeDumperNode("compoundAssignmentTargetPlaceholder", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAssignmentOperator As TreeDumperNode
      Return New TreeDumperNode("assignmentOperator", Nothing, {
          New TreeDumperNode("left", Nothing, { Visit(node.Left, Nothing) }),
          New TreeDumperNode("leftOnTheRightOpt", Nothing, { Visit(node.LeftOnTheRightOpt, Nothing) }),
          New TreeDumperNode("right", Nothing, { Visit(node.Right, Nothing) }),
          New TreeDumperNode("suppressObjectClone", node.SuppressObjectClone, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitReferenceAssignment As TreeDumperNode
      Return New TreeDumperNode("referenceAssignment", Nothing, {
          New TreeDumperNode("byRefLocal", Nothing, { Visit(node.ByRefLocal, Nothing) }),
          New TreeDumperNode("lValue", Nothing, { Visit(node.LValue, Nothing) }),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAddressOfOperator As TreeDumperNode
      Return New TreeDumperNode("addressOfOperator", Nothing, {
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("methodGroup", Nothing, { Visit(node.MethodGroup, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTernaryConditionalExpression As TreeDumperNode
      Return New TreeDumperNode("ternaryConditionalExpression", Nothing, {
          New TreeDumperNode("condition", Nothing, { Visit(node.Condition, Nothing) }),
          New TreeDumperNode("whenTrue", Nothing, { Visit(node.WhenTrue, Nothing) }),
          New TreeDumperNode("whenFalse", Nothing, { Visit(node.WhenFalse, Nothing) }),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitBinaryConditionalExpression As TreeDumperNode
      Return New TreeDumperNode("binaryConditionalExpression", Nothing, {
          New TreeDumperNode("testExpression", Nothing, { Visit(node.TestExpression, Nothing) }),
          New TreeDumperNode("convertedTestExpression", Nothing, { Visit(node.ConvertedTestExpression, Nothing) }),
          New TreeDumperNode("testExpressionPlaceholder", Nothing, { Visit(node.TestExpressionPlaceholder, Nothing) }),
          New TreeDumperNode("elseExpression", Nothing, { Visit(node.ElseExpression, Nothing) }),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitConversion As TreeDumperNode
      Return New TreeDumperNode("conversion", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("conversionKind", node.ConversionKind, Nothing),
          New TreeDumperNode("checked", node.Checked, Nothing),
          New TreeDumperNode("explicitCastInCode", node.ExplicitCastInCode, Nothing),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("extendedInfoOpt", Nothing, { Visit(node.ExtendedInfoOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitRelaxationLambda As TreeDumperNode
      Return New TreeDumperNode("relaxationLambda", Nothing, {
          New TreeDumperNode("lambda", Nothing, { Visit(node.Lambda, Nothing) }),
          New TreeDumperNode("receiverPlaceholderOpt", Nothing, { Visit(node.ReceiverPlaceholderOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitConvertedTupleElements As TreeDumperNode
      Return New TreeDumperNode("convertedTupleElements", Nothing, {
          New TreeDumperNode("elementPlaceholders", Nothing, From x In node.ElementPlaceholders Select Visit(x, Nothing)),
          New TreeDumperNode("convertedElements", Nothing, From x In node.ConvertedElements Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitUserDefinedConversion As TreeDumperNode
      Return New TreeDumperNode("userDefinedConversion", Nothing, {
          New TreeDumperNode("underlyingExpression", Nothing, { Visit(node.UnderlyingExpression, Nothing) }),
          New TreeDumperNode("inOutConversionFlags", node.InOutConversionFlags, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitDirectCast As TreeDumperNode
      Return New TreeDumperNode("[directCast]", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("conversionKind", node.ConversionKind, Nothing),
          New TreeDumperNode("suppressVirtualCalls", node.SuppressVirtualCalls, Nothing),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("relaxationLambdaOpt", Nothing, { Visit(node.RelaxationLambdaOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTryCast As TreeDumperNode
      Return New TreeDumperNode("[tryCast]", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("conversionKind", node.ConversionKind, Nothing),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("relaxationLambdaOpt", Nothing, { Visit(node.RelaxationLambdaOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTypeOf As TreeDumperNode
      Return New TreeDumperNode("[typeOf]", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("isTypeOfIsNotExpression", node.IsTypeOfIsNotExpression, Nothing),
          New TreeDumperNode("targetType", node.TargetType, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitSequencePoint As TreeDumperNode
      Return New TreeDumperNode("sequencePoint", Nothing, {
          New TreeDumperNode("statementOpt", Nothing, { Visit(node.StatementOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitSequencePointExpression As TreeDumperNode
      Return New TreeDumperNode("sequencePointExpression", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitSequencePointWithSpan As TreeDumperNode
      Return New TreeDumperNode("sequencePointWithSpan", Nothing, {
          New TreeDumperNode("statementOpt", Nothing, { Visit(node.StatementOpt, Nothing) }),
          New TreeDumperNode("span", node.Span, Nothing)      })
    End Function
    Public Overrides Function VisitNoOpStatement As TreeDumperNode
      Return New TreeDumperNode("noOpStatement", Nothing, {
          New TreeDumperNode("flavor", node.Flavor, Nothing)      })
    End Function
    Public Overrides Function VisitMethodGroup As TreeDumperNode
      Return New TreeDumperNode("methodGroup", Nothing, {
          New TreeDumperNode("typeArgumentsOpt", Nothing, { Visit(node.TypeArgumentsOpt, Nothing) }),
          New TreeDumperNode("methods", node.Methods, Nothing),
          New TreeDumperNode("pendingExtensionMethodsOpt", node.PendingExtensionMethodsOpt, Nothing),
          New TreeDumperNode("resultKind", node.ResultKind, Nothing),
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("qualificationKind", node.QualificationKind, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitPropertyGroup As TreeDumperNode
      Return New TreeDumperNode("propertyGroup", Nothing, {
          New TreeDumperNode("properties", node.Properties, Nothing),
          New TreeDumperNode("resultKind", node.ResultKind, Nothing),
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("qualificationKind", node.QualificationKind, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitReturnStatement As TreeDumperNode
      Return New TreeDumperNode("returnStatement", Nothing, {
          New TreeDumperNode("expressionOpt", Nothing, { Visit(node.ExpressionOpt, Nothing) }),
          New TreeDumperNode("functionLocalOpt", node.FunctionLocalOpt, Nothing),
          New TreeDumperNode("exitLabelOpt", node.ExitLabelOpt, Nothing)      })
    End Function
    Public Overrides Function VisitYieldStatement As TreeDumperNode
      Return New TreeDumperNode("yieldStatement", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) })      })
    End Function
    Public Overrides Function VisitThrowStatement As TreeDumperNode
      Return New TreeDumperNode("throwStatement", Nothing, {
          New TreeDumperNode("expressionOpt", Nothing, { Visit(node.ExpressionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitRedimStatement As TreeDumperNode
      Return New TreeDumperNode("redimStatement", Nothing, {
          New TreeDumperNode("clauses", Nothing, From x In node.Clauses Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitRedimClause As TreeDumperNode
      Return New TreeDumperNode("redimClause", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("indices", Nothing, From x In node.Indices Select Visit(x, Nothing)),
          New TreeDumperNode("arrayTypeOpt", node.ArrayTypeOpt, Nothing),
          New TreeDumperNode("preserve", node.Preserve, Nothing)      })
    End Function
    Public Overrides Function VisitEraseStatement As TreeDumperNode
      Return New TreeDumperNode("eraseStatement", Nothing, {
          New TreeDumperNode("clauses", Nothing, From x In node.Clauses Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitCall As TreeDumperNode
      Return New TreeDumperNode("[call]", Nothing, {
          New TreeDumperNode("method", node.Method, Nothing),
          New TreeDumperNode("methodGroupOpt", Nothing, { Visit(node.MethodGroupOpt, Nothing) }),
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("arguments", Nothing, From x In node.Arguments Select Visit(x, Nothing)),
          New TreeDumperNode("defaultArguments", node.DefaultArguments, Nothing),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("suppressObjectClone", node.SuppressObjectClone, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAttribute As TreeDumperNode
      Return New TreeDumperNode("attribute", Nothing, {
          New TreeDumperNode("constructor", node.Constructor, Nothing),
          New TreeDumperNode("constructorArguments", Nothing, From x In node.ConstructorArguments Select Visit(x, Nothing)),
          New TreeDumperNode("namedArguments", Nothing, From x In node.NamedArguments Select Visit(x, Nothing)),
          New TreeDumperNode("resultKind", node.ResultKind, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLateMemberAccess As TreeDumperNode
      Return New TreeDumperNode("lateMemberAccess", Nothing, {
          New TreeDumperNode("nameOpt", node.NameOpt, Nothing),
          New TreeDumperNode("containerTypeOpt", node.ContainerTypeOpt, Nothing),
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("typeArgumentsOpt", Nothing, { Visit(node.TypeArgumentsOpt, Nothing) }),
          New TreeDumperNode("accessKind", node.AccessKind, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLateInvocation As TreeDumperNode
      Return New TreeDumperNode("lateInvocation", Nothing, {
          New TreeDumperNode("member", Nothing, { Visit(node.Member, Nothing) }),
          New TreeDumperNode("argumentsOpt", Nothing, From x In node.ArgumentsOpt Select Visit(x, Nothing)),
          New TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, Nothing),
          New TreeDumperNode("accessKind", node.AccessKind, Nothing),
          New TreeDumperNode("methodOrPropertyGroupOpt", Nothing, { Visit(node.MethodOrPropertyGroupOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLateAddressOfOperator As TreeDumperNode
      Return New TreeDumperNode("lateAddressOfOperator", Nothing, {
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("memberAccess", Nothing, { Visit(node.MemberAccess, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTupleLiteral As TreeDumperNode
      Return New TreeDumperNode("tupleLiteral", Nothing, {
          New TreeDumperNode("inferredType", node.InferredType, Nothing),
          New TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, Nothing),
          New TreeDumperNode("inferredNamesOpt", node.InferredNamesOpt, Nothing),
          New TreeDumperNode("arguments", Nothing, From x In node.Arguments Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitConvertedTupleLiteral As TreeDumperNode
      Return New TreeDumperNode("convertedTupleLiteral", Nothing, {
          New TreeDumperNode("naturalTypeOpt", node.NaturalTypeOpt, Nothing),
          New TreeDumperNode("arguments", Nothing, From x In node.Arguments Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitObjectCreationExpression As TreeDumperNode
      Return New TreeDumperNode("objectCreationExpression", Nothing, {
          New TreeDumperNode("constructorOpt", node.ConstructorOpt, Nothing),
          New TreeDumperNode("methodGroupOpt", Nothing, { Visit(node.MethodGroupOpt, Nothing) }),
          New TreeDumperNode("arguments", Nothing, From x In node.Arguments Select Visit(x, Nothing)),
          New TreeDumperNode("defaultArguments", node.DefaultArguments, Nothing),
          New TreeDumperNode("initializerOpt", Nothing, { Visit(node.InitializerOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitNoPiaObjectCreationExpression As TreeDumperNode
      Return New TreeDumperNode("noPiaObjectCreationExpression", Nothing, {
          New TreeDumperNode("guidString", node.GuidString, Nothing),
          New TreeDumperNode("initializerOpt", Nothing, { Visit(node.InitializerOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAnonymousTypeCreationExpression As TreeDumperNode
      Return New TreeDumperNode("anonymousTypeCreationExpression", Nothing, {
          New TreeDumperNode("binderOpt", node.BinderOpt, Nothing),
          New TreeDumperNode("declarations", Nothing, From x In node.Declarations Select Visit(x, Nothing)),
          New TreeDumperNode("arguments", Nothing, From x In node.Arguments Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAnonymousTypePropertyAccess As TreeDumperNode
      Return New TreeDumperNode("anonymousTypePropertyAccess", Nothing, {
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("propertyIndex", node.PropertyIndex, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAnonymousTypeFieldInitializer As TreeDumperNode
      Return New TreeDumperNode("anonymousTypeFieldInitializer", Nothing, {
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitObjectInitializerExpression As TreeDumperNode
      Return New TreeDumperNode("objectInitializerExpression", Nothing, {
          New TreeDumperNode("createTemporaryLocalForInitialization", node.CreateTemporaryLocalForInitialization, Nothing),
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("placeholderOpt", Nothing, { Visit(node.PlaceholderOpt, Nothing) }),
          New TreeDumperNode("initializers", Nothing, From x In node.Initializers Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitCollectionInitializerExpression As TreeDumperNode
      Return New TreeDumperNode("collectionInitializerExpression", Nothing, {
          New TreeDumperNode("placeholderOpt", Nothing, { Visit(node.PlaceholderOpt, Nothing) }),
          New TreeDumperNode("initializers", Nothing, From x In node.Initializers Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitNewT As TreeDumperNode
      Return New TreeDumperNode("newT", Nothing, {
          New TreeDumperNode("initializerOpt", Nothing, { Visit(node.InitializerOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitDelegateCreationExpression As TreeDumperNode
      Return New TreeDumperNode("delegateCreationExpression", Nothing, {
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("method", node.Method, Nothing),
          New TreeDumperNode("relaxationLambdaOpt", Nothing, { Visit(node.RelaxationLambdaOpt, Nothing) }),
          New TreeDumperNode("relaxationReceiverPlaceholderOpt", Nothing, { Visit(node.RelaxationReceiverPlaceholderOpt, Nothing) }),
          New TreeDumperNode("methodGroupOpt", Nothing, { Visit(node.MethodGroupOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitArrayCreation As TreeDumperNode
      Return New TreeDumperNode("arrayCreation", Nothing, {
          New TreeDumperNode("isParamArrayArgument", node.IsParamArrayArgument, Nothing),
          New TreeDumperNode("bounds", Nothing, From x In node.Bounds Select Visit(x, Nothing)),
          New TreeDumperNode("initializerOpt", Nothing, { Visit(node.InitializerOpt, Nothing) }),
          New TreeDumperNode("arrayLiteralOpt", Nothing, { Visit(node.ArrayLiteralOpt, Nothing) }),
          New TreeDumperNode("arrayLiteralConversion", node.ArrayLiteralConversion, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitArrayLiteral As TreeDumperNode
      Return New TreeDumperNode("arrayLiteral", Nothing, {
          New TreeDumperNode("hasDominantType", node.HasDominantType, Nothing),
          New TreeDumperNode("numberOfCandidates", node.NumberOfCandidates, Nothing),
          New TreeDumperNode("inferredType", node.InferredType, Nothing),
          New TreeDumperNode("bounds", Nothing, From x In node.Bounds Select Visit(x, Nothing)),
          New TreeDumperNode("initializer", Nothing, { Visit(node.Initializer, Nothing) }),
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitArrayInitialization As TreeDumperNode
      Return New TreeDumperNode("arrayInitialization", Nothing, {
          New TreeDumperNode("initializers", Nothing, From x In node.Initializers Select Visit(x, Nothing)),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitFieldAccess As TreeDumperNode
      Return New TreeDumperNode("fieldAccess", Nothing, {
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("fieldSymbol", node.FieldSymbol, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("suppressVirtualCalls", node.SuppressVirtualCalls, Nothing),
          New TreeDumperNode("constantsInProgressOpt", node.ConstantsInProgressOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitPropertyAccess As TreeDumperNode
      Return New TreeDumperNode("propertyAccess", Nothing, {
          New TreeDumperNode("propertySymbol", node.PropertySymbol, Nothing),
          New TreeDumperNode("propertyGroupOpt", Nothing, { Visit(node.PropertyGroupOpt, Nothing) }),
          New TreeDumperNode("accessKind", node.AccessKind, Nothing),
          New TreeDumperNode("isWriteable", node.IsWriteable, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("arguments", Nothing, From x In node.Arguments Select Visit(x, Nothing)),
          New TreeDumperNode("defaultArguments", node.DefaultArguments, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitEventAccess As TreeDumperNode
      Return New TreeDumperNode("eventAccess", Nothing, {
          New TreeDumperNode("receiverOpt", Nothing, { Visit(node.ReceiverOpt, Nothing) }),
          New TreeDumperNode("eventSymbol", node.EventSymbol, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitBlock As TreeDumperNode
      Return New TreeDumperNode("block", Nothing, {
          New TreeDumperNode("statementListSyntax", node.StatementListSyntax, Nothing),
          New TreeDumperNode("locals", node.Locals, Nothing),
          New TreeDumperNode("statements", Nothing, From x In node.Statements Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitStateMachineScope As TreeDumperNode
      Return New TreeDumperNode("stateMachineScope", Nothing, {
          New TreeDumperNode("fields", node.Fields, Nothing),
          New TreeDumperNode("statement", Nothing, { Visit(node.Statement, Nothing) })      })
    End Function
    Public Overrides Function VisitLocalDeclaration As TreeDumperNode
      Return New TreeDumperNode("localDeclaration", Nothing, {
          New TreeDumperNode("localSymbol", node.LocalSymbol, Nothing),
          New TreeDumperNode("declarationInitializerOpt", Nothing, { Visit(node.DeclarationInitializerOpt, Nothing) }),
          New TreeDumperNode("identifierInitializerOpt", Nothing, { Visit(node.IdentifierInitializerOpt, Nothing) }),
          New TreeDumperNode("initializedByAsNew", node.InitializedByAsNew, Nothing)      })
    End Function
    Public Overrides Function VisitAsNewLocalDeclarations As TreeDumperNode
      Return New TreeDumperNode("asNewLocalDeclarations", Nothing, {
          New TreeDumperNode("localDeclarations", Nothing, From x In node.LocalDeclarations Select Visit(x, Nothing)),
          New TreeDumperNode("initializer", Nothing, { Visit(node.Initializer, Nothing) })      })
    End Function
    Public Overrides Function VisitDimStatement As TreeDumperNode
      Return New TreeDumperNode("dimStatement", Nothing, {
          New TreeDumperNode("localDeclarations", Nothing, From x In node.LocalDeclarations Select Visit(x, Nothing)),
          New TreeDumperNode("initializerOpt", Nothing, { Visit(node.InitializerOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitInitializer As TreeDumperNode
      Return New TreeDumperNode("initializer", Nothing, Array.Empty(Of TreeDumperNode)())
    End Function
    Public Overrides Function VisitFieldInitializer As TreeDumperNode
      Return New TreeDumperNode("fieldInitializer", Nothing, {
          New TreeDumperNode("initializedFields", node.InitializedFields, Nothing),
          New TreeDumperNode("memberAccessExpressionOpt", Nothing, { Visit(node.MemberAccessExpressionOpt, Nothing) }),
          New TreeDumperNode("initialValue", Nothing, { Visit(node.InitialValue, Nothing) })      })
    End Function
    Public Overrides Function VisitPropertyInitializer As TreeDumperNode
      Return New TreeDumperNode("propertyInitializer", Nothing, {
          New TreeDumperNode("initializedProperties", node.InitializedProperties, Nothing),
          New TreeDumperNode("memberAccessExpressionOpt", Nothing, { Visit(node.MemberAccessExpressionOpt, Nothing) }),
          New TreeDumperNode("initialValue", Nothing, { Visit(node.InitialValue, Nothing) })      })
    End Function
    Public Overrides Function VisitParameterEqualsValue As TreeDumperNode
      Return New TreeDumperNode("parameterEqualsValue", Nothing, {
          New TreeDumperNode("parameter", node.Parameter, Nothing),
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) })      })
    End Function
    Public Overrides Function VisitGlobalStatementInitializer As TreeDumperNode
      Return New TreeDumperNode("globalStatementInitializer", Nothing, {
          New TreeDumperNode("statement", Nothing, { Visit(node.Statement, Nothing) })      })
    End Function
    Public Overrides Function VisitSequence As TreeDumperNode
      Return New TreeDumperNode("sequence", Nothing, {
          New TreeDumperNode("locals", node.Locals, Nothing),
          New TreeDumperNode("sideEffects", Nothing, From x In node.SideEffects Select Visit(x, Nothing)),
          New TreeDumperNode("valueOpt", Nothing, { Visit(node.ValueOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitExpressionStatement As TreeDumperNode
      Return New TreeDumperNode("expressionStatement", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) })      })
    End Function
    Public Overrides Function VisitIfStatement As TreeDumperNode
      Return New TreeDumperNode("ifStatement", Nothing, {
          New TreeDumperNode("condition", Nothing, { Visit(node.Condition, Nothing) }),
          New TreeDumperNode("consequence", Nothing, { Visit(node.Consequence, Nothing) }),
          New TreeDumperNode("alternativeOpt", Nothing, { Visit(node.AlternativeOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitSelectStatement As TreeDumperNode
      Return New TreeDumperNode("selectStatement", Nothing, {
          New TreeDumperNode("expressionStatement", Nothing, { Visit(node.ExpressionStatement, Nothing) }),
          New TreeDumperNode("exprPlaceholderOpt", Nothing, { Visit(node.ExprPlaceholderOpt, Nothing) }),
          New TreeDumperNode("caseBlocks", Nothing, From x In node.CaseBlocks Select Visit(x, Nothing)),
          New TreeDumperNode("recommendSwitchTable", node.RecommendSwitchTable, Nothing),
          New TreeDumperNode("exitLabel", node.ExitLabel, Nothing)      })
    End Function
    Public Overrides Function VisitCaseBlock As TreeDumperNode
      Return New TreeDumperNode("caseBlock", Nothing, {
          New TreeDumperNode("caseStatement", Nothing, { Visit(node.CaseStatement, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) })      })
    End Function
    Public Overrides Function VisitCaseStatement As TreeDumperNode
      Return New TreeDumperNode("caseStatement", Nothing, {
          New TreeDumperNode("caseClauses", Nothing, From x In node.CaseClauses Select Visit(x, Nothing)),
          New TreeDumperNode("conditionOpt", Nothing, { Visit(node.ConditionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitSimpleCaseClause As TreeDumperNode
      Return New TreeDumperNode("simpleCaseClause", Nothing, {
          New TreeDumperNode("valueOpt", Nothing, { Visit(node.ValueOpt, Nothing) }),
          New TreeDumperNode("conditionOpt", Nothing, { Visit(node.ConditionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitRangeCaseClause As TreeDumperNode
      Return New TreeDumperNode("rangeCaseClause", Nothing, {
          New TreeDumperNode("lowerBoundOpt", Nothing, { Visit(node.LowerBoundOpt, Nothing) }),
          New TreeDumperNode("upperBoundOpt", Nothing, { Visit(node.UpperBoundOpt, Nothing) }),
          New TreeDumperNode("lowerBoundConditionOpt", Nothing, { Visit(node.LowerBoundConditionOpt, Nothing) }),
          New TreeDumperNode("upperBoundConditionOpt", Nothing, { Visit(node.UpperBoundConditionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitRelationalCaseClause As TreeDumperNode
      Return New TreeDumperNode("relationalCaseClause", Nothing, {
          New TreeDumperNode("operatorKind", node.OperatorKind, Nothing),
          New TreeDumperNode("valueOpt", Nothing, { Visit(node.ValueOpt, Nothing) }),
          New TreeDumperNode("conditionOpt", Nothing, { Visit(node.ConditionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitDoLoopStatement As TreeDumperNode
      Return New TreeDumperNode("doLoopStatement", Nothing, {
          New TreeDumperNode("topConditionOpt", Nothing, { Visit(node.TopConditionOpt, Nothing) }),
          New TreeDumperNode("bottomConditionOpt", Nothing, { Visit(node.BottomConditionOpt, Nothing) }),
          New TreeDumperNode("topConditionIsUntil", node.TopConditionIsUntil, Nothing),
          New TreeDumperNode("bottomConditionIsUntil", node.BottomConditionIsUntil, Nothing),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("continueLabel", node.ContinueLabel, Nothing),
          New TreeDumperNode("exitLabel", node.ExitLabel, Nothing)      })
    End Function
    Public Overrides Function VisitWhileStatement As TreeDumperNode
      Return New TreeDumperNode("whileStatement", Nothing, {
          New TreeDumperNode("condition", Nothing, { Visit(node.Condition, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("continueLabel", node.ContinueLabel, Nothing),
          New TreeDumperNode("exitLabel", node.ExitLabel, Nothing)      })
    End Function
    Public Overrides Function VisitForToUserDefinedOperators As TreeDumperNode
      Return New TreeDumperNode("forToUserDefinedOperators", Nothing, {
          New TreeDumperNode("leftOperandPlaceholder", Nothing, { Visit(node.LeftOperandPlaceholder, Nothing) }),
          New TreeDumperNode("rightOperandPlaceholder", Nothing, { Visit(node.RightOperandPlaceholder, Nothing) }),
          New TreeDumperNode("addition", Nothing, { Visit(node.Addition, Nothing) }),
          New TreeDumperNode("subtraction", Nothing, { Visit(node.Subtraction, Nothing) }),
          New TreeDumperNode("lessThanOrEqual", Nothing, { Visit(node.LessThanOrEqual, Nothing) }),
          New TreeDumperNode("greaterThanOrEqual", Nothing, { Visit(node.GreaterThanOrEqual, Nothing) })      })
    End Function
    Public Overrides Function VisitForToStatement As TreeDumperNode
      Return New TreeDumperNode("forToStatement", Nothing, {
          New TreeDumperNode("initialValue", Nothing, { Visit(node.InitialValue, Nothing) }),
          New TreeDumperNode("limitValue", Nothing, { Visit(node.LimitValue, Nothing) }),
          New TreeDumperNode("stepValue", Nothing, { Visit(node.StepValue, Nothing) }),
          New TreeDumperNode("checked", node.Checked, Nothing),
          New TreeDumperNode("operatorsOpt", Nothing, { Visit(node.OperatorsOpt, Nothing) }),
          New TreeDumperNode("declaredOrInferredLocalOpt", node.DeclaredOrInferredLocalOpt, Nothing),
          New TreeDumperNode("controlVariable", Nothing, { Visit(node.ControlVariable, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("nextVariablesOpt", Nothing, From x In node.NextVariablesOpt Select Visit(x, Nothing)),
          New TreeDumperNode("continueLabel", node.ContinueLabel, Nothing),
          New TreeDumperNode("exitLabel", node.ExitLabel, Nothing)      })
    End Function
    Public Overrides Function VisitForEachStatement As TreeDumperNode
      Return New TreeDumperNode("forEachStatement", Nothing, {
          New TreeDumperNode("collection", Nothing, { Visit(node.Collection, Nothing) }),
          New TreeDumperNode("enumeratorInfo", node.EnumeratorInfo, Nothing),
          New TreeDumperNode("declaredOrInferredLocalOpt", node.DeclaredOrInferredLocalOpt, Nothing),
          New TreeDumperNode("controlVariable", Nothing, { Visit(node.ControlVariable, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("nextVariablesOpt", Nothing, From x In node.NextVariablesOpt Select Visit(x, Nothing)),
          New TreeDumperNode("continueLabel", node.ContinueLabel, Nothing),
          New TreeDumperNode("exitLabel", node.ExitLabel, Nothing)      })
    End Function
    Public Overrides Function VisitExitStatement As TreeDumperNode
      Return New TreeDumperNode("exitStatement", Nothing, {
          New TreeDumperNode("label", node.Label, Nothing)      })
    End Function
    Public Overrides Function VisitContinueStatement As TreeDumperNode
      Return New TreeDumperNode("continueStatement", Nothing, {
          New TreeDumperNode("label", node.Label, Nothing)      })
    End Function
    Public Overrides Function VisitTryStatement As TreeDumperNode
      Return New TreeDumperNode("tryStatement", Nothing, {
          New TreeDumperNode("tryBlock", Nothing, { Visit(node.TryBlock, Nothing) }),
          New TreeDumperNode("catchBlocks", Nothing, From x In node.CatchBlocks Select Visit(x, Nothing)),
          New TreeDumperNode("finallyBlockOpt", Nothing, { Visit(node.FinallyBlockOpt, Nothing) }),
          New TreeDumperNode("exitLabelOpt", node.ExitLabelOpt, Nothing)      })
    End Function
    Public Overrides Function VisitCatchBlock As TreeDumperNode
      Return New TreeDumperNode("catchBlock", Nothing, {
          New TreeDumperNode("localOpt", node.LocalOpt, Nothing),
          New TreeDumperNode("exceptionSourceOpt", Nothing, { Visit(node.ExceptionSourceOpt, Nothing) }),
          New TreeDumperNode("errorLineNumberOpt", Nothing, { Visit(node.ErrorLineNumberOpt, Nothing) }),
          New TreeDumperNode("exceptionFilterOpt", Nothing, { Visit(node.ExceptionFilterOpt, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("isSynthesizedAsyncCatchAll", node.IsSynthesizedAsyncCatchAll, Nothing)      })
    End Function
    Public Overrides Function VisitLiteral As TreeDumperNode
      Return New TreeDumperNode("literal", Nothing, {
          New TreeDumperNode("value", node.Value, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitMeReference As TreeDumperNode
      Return New TreeDumperNode("meReference", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitValueTypeMeReference As TreeDumperNode
      Return New TreeDumperNode("valueTypeMeReference", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitMyBaseReference As TreeDumperNode
      Return New TreeDumperNode("myBaseReference", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitMyClassReference As TreeDumperNode
      Return New TreeDumperNode("myClassReference", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitPreviousSubmissionReference As TreeDumperNode
      Return New TreeDumperNode("previousSubmissionReference", Nothing, {
          New TreeDumperNode("sourceType", node.SourceType, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitHostObjectMemberReference As TreeDumperNode
      Return New TreeDumperNode("hostObjectMemberReference", Nothing, {
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLocal As TreeDumperNode
      Return New TreeDumperNode("local", Nothing, {
          New TreeDumperNode("localSymbol", node.LocalSymbol, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitPseudoVariable As TreeDumperNode
      Return New TreeDumperNode("pseudoVariable", Nothing, {
          New TreeDumperNode("localSymbol", node.LocalSymbol, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("emitExpressions", node.EmitExpressions, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitParameter As TreeDumperNode
      Return New TreeDumperNode("parameter", Nothing, {
          New TreeDumperNode("parameterSymbol", node.ParameterSymbol, Nothing),
          New TreeDumperNode("isLValue", node.IsLValue, Nothing),
          New TreeDumperNode("suppressVirtualCalls", node.SuppressVirtualCalls, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitByRefArgumentPlaceholder As TreeDumperNode
      Return New TreeDumperNode("byRefArgumentPlaceholder", Nothing, {
          New TreeDumperNode("isOut", node.IsOut, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitByRefArgumentWithCopyBack As TreeDumperNode
      Return New TreeDumperNode("byRefArgumentWithCopyBack", Nothing, {
          New TreeDumperNode("originalArgument", Nothing, { Visit(node.OriginalArgument, Nothing) }),
          New TreeDumperNode("inConversion", Nothing, { Visit(node.InConversion, Nothing) }),
          New TreeDumperNode("inPlaceholder", Nothing, { Visit(node.InPlaceholder, Nothing) }),
          New TreeDumperNode("outConversion", Nothing, { Visit(node.OutConversion, Nothing) }),
          New TreeDumperNode("outPlaceholder", Nothing, { Visit(node.OutPlaceholder, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLateBoundArgumentSupportingAssignmentWithCapture As TreeDumperNode
      Return New TreeDumperNode("lateBoundArgumentSupportingAssignmentWithCapture", Nothing, {
          New TreeDumperNode("originalArgument", Nothing, { Visit(node.OriginalArgument, Nothing) }),
          New TreeDumperNode("localSymbol", node.LocalSymbol, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLabelStatement As TreeDumperNode
      Return New TreeDumperNode("labelStatement", Nothing, {
          New TreeDumperNode("label", node.Label, Nothing)      })
    End Function
    Public Overrides Function VisitLabel As TreeDumperNode
      Return New TreeDumperNode("label", Nothing, {
          New TreeDumperNode("label", node.Label, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitGotoStatement As TreeDumperNode
      Return New TreeDumperNode("gotoStatement", Nothing, {
          New TreeDumperNode("label", node.Label, Nothing),
          New TreeDumperNode("labelExpressionOpt", Nothing, { Visit(node.LabelExpressionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitStatementList As TreeDumperNode
      Return New TreeDumperNode("statementList", Nothing, {
          New TreeDumperNode("statements", Nothing, From x In node.Statements Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitConditionalGoto As TreeDumperNode
      Return New TreeDumperNode("conditionalGoto", Nothing, {
          New TreeDumperNode("condition", Nothing, { Visit(node.Condition, Nothing) }),
          New TreeDumperNode("jumpIfTrue", node.JumpIfTrue, Nothing),
          New TreeDumperNode("label", node.Label, Nothing)      })
    End Function
    Public Overrides Function VisitWithStatement As TreeDumperNode
      Return New TreeDumperNode("withStatement", Nothing, {
          New TreeDumperNode("originalExpression", Nothing, { Visit(node.OriginalExpression, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("binder", node.Binder, Nothing)      })
    End Function
    Public Overrides Function VisitUnboundLambda As TreeDumperNode
      Return New TreeDumperNode("unboundLambda", Nothing, {
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("flags", node.Flags, Nothing),
          New TreeDumperNode("parameters", node.Parameters, Nothing),
          New TreeDumperNode("returnType", node.ReturnType, Nothing),
          New TreeDumperNode("bindingCache", node.BindingCache, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLambda As TreeDumperNode
      Return New TreeDumperNode("lambda", Nothing, {
          New TreeDumperNode("lambdaSymbol", node.LambdaSymbol, Nothing),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("diagnostics", node.Diagnostics, Nothing),
          New TreeDumperNode("lambdaBinderOpt", node.LambdaBinderOpt, Nothing),
          New TreeDumperNode("delegateRelaxation", node.DelegateRelaxation, Nothing),
          New TreeDumperNode("methodConversionKind", node.MethodConversionKind, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitQueryExpression As TreeDumperNode
      Return New TreeDumperNode("queryExpression", Nothing, {
          New TreeDumperNode("lastOperator", Nothing, { Visit(node.LastOperator, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitQuerySource As TreeDumperNode
      Return New TreeDumperNode("querySource", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitToQueryableCollectionConversion As TreeDumperNode
      Return New TreeDumperNode("toQueryableCollectionConversion", Nothing, {
          New TreeDumperNode("conversionCall", Nothing, { Visit(node.ConversionCall, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitQueryableSource As TreeDumperNode
      Return New TreeDumperNode("queryableSource", Nothing, {
          New TreeDumperNode("source", Nothing, { Visit(node.Source, Nothing) }),
          New TreeDumperNode("rangeVariableOpt", node.RangeVariableOpt, Nothing),
          New TreeDumperNode("rangeVariables", node.RangeVariables, Nothing),
          New TreeDumperNode("compoundVariableType", node.CompoundVariableType, Nothing),
          New TreeDumperNode("binders", node.Binders, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitQueryClause As TreeDumperNode
      Return New TreeDumperNode("queryClause", Nothing, {
          New TreeDumperNode("underlyingExpression", Nothing, { Visit(node.UnderlyingExpression, Nothing) }),
          New TreeDumperNode("rangeVariables", node.RangeVariables, Nothing),
          New TreeDumperNode("compoundVariableType", node.CompoundVariableType, Nothing),
          New TreeDumperNode("binders", node.Binders, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitOrdering As TreeDumperNode
      Return New TreeDumperNode("ordering", Nothing, {
          New TreeDumperNode("underlyingExpression", Nothing, { Visit(node.UnderlyingExpression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitQueryLambda As TreeDumperNode
      Return New TreeDumperNode("queryLambda", Nothing, {
          New TreeDumperNode("lambdaSymbol", node.LambdaSymbol, Nothing),
          New TreeDumperNode("rangeVariables", node.RangeVariables, Nothing),
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("exprIsOperandOfConditionalBranch", node.ExprIsOperandOfConditionalBranch, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitRangeVariableAssignment As TreeDumperNode
      Return New TreeDumperNode("rangeVariableAssignment", Nothing, {
          New TreeDumperNode("rangeVariable", node.RangeVariable, Nothing),
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitGroupTypeInferenceLambda As TreeDumperNode
      Return New TreeDumperNode("groupTypeInferenceLambda", Nothing, {
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("parameters", node.Parameters, Nothing),
          New TreeDumperNode("compilation", node.Compilation, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAggregateClause As TreeDumperNode
      Return New TreeDumperNode("aggregateClause", Nothing, {
          New TreeDumperNode("capturedGroupOpt", Nothing, { Visit(node.CapturedGroupOpt, Nothing) }),
          New TreeDumperNode("groupPlaceholderOpt", Nothing, { Visit(node.GroupPlaceholderOpt, Nothing) }),
          New TreeDumperNode("underlyingExpression", Nothing, { Visit(node.UnderlyingExpression, Nothing) }),
          New TreeDumperNode("rangeVariables", node.RangeVariables, Nothing),
          New TreeDumperNode("compoundVariableType", node.CompoundVariableType, Nothing),
          New TreeDumperNode("binders", node.Binders, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitGroupAggregation As TreeDumperNode
      Return New TreeDumperNode("groupAggregation", Nothing, {
          New TreeDumperNode("group", Nothing, { Visit(node.Group, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitRangeVariable As TreeDumperNode
      Return New TreeDumperNode("rangeVariable", Nothing, {
          New TreeDumperNode("rangeVariable", node.RangeVariable, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitAddHandlerStatement As TreeDumperNode
      Return New TreeDumperNode("addHandlerStatement", Nothing, {
          New TreeDumperNode("eventAccess", Nothing, { Visit(node.EventAccess, Nothing) }),
          New TreeDumperNode("handler", Nothing, { Visit(node.Handler, Nothing) })      })
    End Function
    Public Overrides Function VisitRemoveHandlerStatement As TreeDumperNode
      Return New TreeDumperNode("removeHandlerStatement", Nothing, {
          New TreeDumperNode("eventAccess", Nothing, { Visit(node.EventAccess, Nothing) }),
          New TreeDumperNode("handler", Nothing, { Visit(node.Handler, Nothing) })      })
    End Function
    Public Overrides Function VisitRaiseEventStatement As TreeDumperNode
      Return New TreeDumperNode("raiseEventStatement", Nothing, {
          New TreeDumperNode("eventSymbol", node.EventSymbol, Nothing),
          New TreeDumperNode("eventInvocation", Nothing, { Visit(node.EventInvocation, Nothing) })      })
    End Function
    Public Overrides Function VisitUsingStatement As TreeDumperNode
      Return New TreeDumperNode("usingStatement", Nothing, {
          New TreeDumperNode("resourceList", Nothing, From x In node.ResourceList Select Visit(x, Nothing)),
          New TreeDumperNode("resourceExpressionOpt", Nothing, { Visit(node.ResourceExpressionOpt, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) }),
          New TreeDumperNode("usingInfo", node.UsingInfo, Nothing),
          New TreeDumperNode("locals", node.Locals, Nothing)      })
    End Function
    Public Overrides Function VisitSyncLockStatement As TreeDumperNode
      Return New TreeDumperNode("syncLockStatement", Nothing, {
          New TreeDumperNode("lockExpression", Nothing, { Visit(node.LockExpression, Nothing) }),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) })      })
    End Function
    Public Overrides Function VisitXmlName As TreeDumperNode
      Return New TreeDumperNode("xmlName", Nothing, {
          New TreeDumperNode("xmlNamespace", Nothing, { Visit(node.XmlNamespace, Nothing) }),
          New TreeDumperNode("localName", Nothing, { Visit(node.LocalName, Nothing) }),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlNamespace As TreeDumperNode
      Return New TreeDumperNode("xmlNamespace", Nothing, {
          New TreeDumperNode("xmlNamespace", Nothing, { Visit(node.XmlNamespace, Nothing) }),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlDocument As TreeDumperNode
      Return New TreeDumperNode("xmlDocument", Nothing, {
          New TreeDumperNode("declaration", Nothing, { Visit(node.Declaration, Nothing) }),
          New TreeDumperNode("childNodes", Nothing, From x In node.ChildNodes Select Visit(x, Nothing)),
          New TreeDumperNode("rewriterInfo", node.RewriterInfo, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlDeclaration As TreeDumperNode
      Return New TreeDumperNode("xmlDeclaration", Nothing, {
          New TreeDumperNode("version", Nothing, { Visit(node.Version, Nothing) }),
          New TreeDumperNode("encoding", Nothing, { Visit(node.Encoding, Nothing) }),
          New TreeDumperNode("standalone", Nothing, { Visit(node.Standalone, Nothing) }),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlProcessingInstruction As TreeDumperNode
      Return New TreeDumperNode("xmlProcessingInstruction", Nothing, {
          New TreeDumperNode("target", Nothing, { Visit(node.Target, Nothing) }),
          New TreeDumperNode("data", Nothing, { Visit(node.Data, Nothing) }),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlComment As TreeDumperNode
      Return New TreeDumperNode("xmlComment", Nothing, {
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) }),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlAttribute As TreeDumperNode
      Return New TreeDumperNode("xmlAttribute", Nothing, {
          New TreeDumperNode("name", Nothing, { Visit(node.Name, Nothing) }),
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) }),
          New TreeDumperNode("matchesImport", node.MatchesImport, Nothing),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlElement As TreeDumperNode
      Return New TreeDumperNode("xmlElement", Nothing, {
          New TreeDumperNode("argument", Nothing, { Visit(node.Argument, Nothing) }),
          New TreeDumperNode("childNodes", Nothing, From x In node.ChildNodes Select Visit(x, Nothing)),
          New TreeDumperNode("rewriterInfo", node.RewriterInfo, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlMemberAccess As TreeDumperNode
      Return New TreeDumperNode("xmlMemberAccess", Nothing, {
          New TreeDumperNode("memberAccess", Nothing, { Visit(node.MemberAccess, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlEmbeddedExpression As TreeDumperNode
      Return New TreeDumperNode("xmlEmbeddedExpression", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitXmlCData As TreeDumperNode
      Return New TreeDumperNode("xmlCData", Nothing, {
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) }),
          New TreeDumperNode("objectCreation", Nothing, { Visit(node.ObjectCreation, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitResumeStatement As TreeDumperNode
      Return New TreeDumperNode("resumeStatement", Nothing, {
          New TreeDumperNode("resumeKind", node.ResumeKind, Nothing),
          New TreeDumperNode("labelOpt", node.LabelOpt, Nothing),
          New TreeDumperNode("labelExpressionOpt", Nothing, { Visit(node.LabelExpressionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitOnErrorStatement As TreeDumperNode
      Return New TreeDumperNode("onErrorStatement", Nothing, {
          New TreeDumperNode("onErrorKind", node.OnErrorKind, Nothing),
          New TreeDumperNode("labelOpt", node.LabelOpt, Nothing),
          New TreeDumperNode("labelExpressionOpt", Nothing, { Visit(node.LabelExpressionOpt, Nothing) })      })
    End Function
    Public Overrides Function VisitUnstructuredExceptionHandlingStatement As TreeDumperNode
      Return New TreeDumperNode("unstructuredExceptionHandlingStatement", Nothing, {
          New TreeDumperNode("containsOnError", node.ContainsOnError, Nothing),
          New TreeDumperNode("containsResume", node.ContainsResume, Nothing),
          New TreeDumperNode("resumeWithoutLabelOpt", node.ResumeWithoutLabelOpt, Nothing),
          New TreeDumperNode("trackLineNumber", node.TrackLineNumber, Nothing),
          New TreeDumperNode("body", Nothing, { Visit(node.Body, Nothing) })      })
    End Function
    Public Overrides Function VisitUnstructuredExceptionHandlingCatchFilter As TreeDumperNode
      Return New TreeDumperNode("unstructuredExceptionHandlingCatchFilter", Nothing, {
          New TreeDumperNode("activeHandlerLocal", Nothing, { Visit(node.ActiveHandlerLocal, Nothing) }),
          New TreeDumperNode("resumeTargetLocal", Nothing, { Visit(node.ResumeTargetLocal, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitUnstructuredExceptionOnErrorSwitch As TreeDumperNode
      Return New TreeDumperNode("unstructuredExceptionOnErrorSwitch", Nothing, {
          New TreeDumperNode("value", Nothing, { Visit(node.Value, Nothing) }),
          New TreeDumperNode("jumps", Nothing, From x In node.Jumps Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitUnstructuredExceptionResumeSwitch As TreeDumperNode
      Return New TreeDumperNode("unstructuredExceptionResumeSwitch", Nothing, {
          New TreeDumperNode("resumeTargetTemporary", Nothing, { Visit(node.ResumeTargetTemporary, Nothing) }),
          New TreeDumperNode("resumeLabel", Nothing, { Visit(node.ResumeLabel, Nothing) }),
          New TreeDumperNode("resumeNextLabel", Nothing, { Visit(node.ResumeNextLabel, Nothing) }),
          New TreeDumperNode("jumps", Nothing, From x In node.Jumps Select Visit(x, Nothing))      })
    End Function
    Public Overrides Function VisitAwaitOperator As TreeDumperNode
      Return New TreeDumperNode("awaitOperator", Nothing, {
          New TreeDumperNode("operand", Nothing, { Visit(node.Operand, Nothing) }),
          New TreeDumperNode("awaitableInstancePlaceholder", Nothing, { Visit(node.AwaitableInstancePlaceholder, Nothing) }),
          New TreeDumperNode("getAwaiter", Nothing, { Visit(node.GetAwaiter, Nothing) }),
          New TreeDumperNode("awaiterInstancePlaceholder", Nothing, { Visit(node.AwaiterInstancePlaceholder, Nothing) }),
          New TreeDumperNode("isCompleted", Nothing, { Visit(node.IsCompleted, Nothing) }),
          New TreeDumperNode("getResult", Nothing, { Visit(node.GetResult, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitSpillSequence As TreeDumperNode
      Return New TreeDumperNode("spillSequence", Nothing, {
          New TreeDumperNode("locals", node.Locals, Nothing),
          New TreeDumperNode("spillFields", node.SpillFields, Nothing),
          New TreeDumperNode("statements", Nothing, From x In node.Statements Select Visit(x, Nothing)),
          New TreeDumperNode("valueOpt", Nothing, { Visit(node.ValueOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitStopStatement As TreeDumperNode
      Return New TreeDumperNode("stopStatement", Nothing, Array.Empty(Of TreeDumperNode)())
    End Function
    Public Overrides Function VisitEndStatement As TreeDumperNode
      Return New TreeDumperNode("endStatement", Nothing, Array.Empty(Of TreeDumperNode)())
    End Function
    Public Overrides Function VisitMidResult As TreeDumperNode
      Return New TreeDumperNode("midResult", Nothing, {
          New TreeDumperNode("original", Nothing, { Visit(node.Original, Nothing) }),
          New TreeDumperNode("start", Nothing, { Visit(node.Start, Nothing) }),
          New TreeDumperNode("lengthOpt", Nothing, { Visit(node.LengthOpt, Nothing) }),
          New TreeDumperNode("source", Nothing, { Visit(node.Source, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitConditionalAccess As TreeDumperNode
      Return New TreeDumperNode("conditionalAccess", Nothing, {
          New TreeDumperNode("receiver", Nothing, { Visit(node.Receiver, Nothing) }),
          New TreeDumperNode("placeholder", Nothing, { Visit(node.Placeholder, Nothing) }),
          New TreeDumperNode("accessExpression", Nothing, { Visit(node.AccessExpression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitConditionalAccessReceiverPlaceholder As TreeDumperNode
      Return New TreeDumperNode("conditionalAccessReceiverPlaceholder", Nothing, {
          New TreeDumperNode("placeholderId", node.PlaceholderId, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitLoweredConditionalAccess As TreeDumperNode
      Return New TreeDumperNode("loweredConditionalAccess", Nothing, {
          New TreeDumperNode("receiverOrCondition", Nothing, { Visit(node.ReceiverOrCondition, Nothing) }),
          New TreeDumperNode("captureReceiver", node.CaptureReceiver, Nothing),
          New TreeDumperNode("placeholderId", node.PlaceholderId, Nothing),
          New TreeDumperNode("whenNotNull", Nothing, { Visit(node.WhenNotNull, Nothing) }),
          New TreeDumperNode("whenNullOpt", Nothing, { Visit(node.WhenNullOpt, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitComplexConditionalAccessReceiver As TreeDumperNode
      Return New TreeDumperNode("complexConditionalAccessReceiver", Nothing, {
          New TreeDumperNode("valueTypeReceiver", Nothing, { Visit(node.ValueTypeReceiver, Nothing) }),
          New TreeDumperNode("referenceTypeReceiver", Nothing, { Visit(node.ReferenceTypeReceiver, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitNameOfOperator As TreeDumperNode
      Return New TreeDumperNode("nameOfOperator", Nothing, {
          New TreeDumperNode("argument", Nothing, { Visit(node.Argument, Nothing) }),
          New TreeDumperNode("constantValueOpt", node.ConstantValueOpt, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitTypeAsValueExpression As TreeDumperNode
      Return New TreeDumperNode("typeAsValueExpression", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitInterpolatedStringExpression As TreeDumperNode
      Return New TreeDumperNode("interpolatedStringExpression", Nothing, {
          New TreeDumperNode("contents", Nothing, From x In node.Contents Select Visit(x, Nothing)),
          New TreeDumperNode("binder", node.Binder, Nothing),
          New TreeDumperNode("type", node.Type, Nothing)      })
    End Function
    Public Overrides Function VisitInterpolation As TreeDumperNode
      Return New TreeDumperNode("interpolation", Nothing, {
          New TreeDumperNode("expression", Nothing, { Visit(node.Expression, Nothing) }),
          New TreeDumperNode("alignmentOpt", Nothing, { Visit(node.AlignmentOpt, Nothing) }),
          New TreeDumperNode("formatStringOpt", Nothing, { Visit(node.FormatStringOpt, Nothing) })      })
    End Function
  End Class
End Namespace