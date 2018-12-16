// < auto-generated />

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Text;
using Microsoft.CodeAnalysis.Collections;
using Roslyn.Utilities;

using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis.CSharp
  internal enum BoundKind 
    {
      FieldEqualsValue,
      PropertyEqualsValue,
      ParameterEqualsValue,
      GlobalStatementInitializer,
      DeconstructValuePlaceholder,
      TupleOperandPlaceholder,
      Dup,
      PassByCopy,
      BadExpression,
      BadStatement,
      TypeExpression,
      TypeOrValueExpression,
      NamespaceExpression,
      UnaryOperator,
      IncrementOperator,
      AddressOfOperator,
      PointerIndirectionOperator,
      PointerElementAccess,
      RefTypeOperator,
      MakeRefOperator,
      RefValueOperator,
      BinaryOperator,
      TupleBinaryOperator,
      UserDefinedConditionalLogicalOperator,
      CompoundAssignmentOperator,
      AssignmentOperator,
      DeconstructionAssignmentOperator,
      NullCoalescingOperator,
      ConditionalOperator,
      ArrayAccess,
      ArrayLength,
      AwaitExpression,
      TypeOfOperator,
      MethodDefIndex,
      MaximumMethodDefIndex,
      InstrumentationPayloadRoot,
      ModuleVersionId,
      ModuleVersionIdString,
      SourceDocumentIndex,
      MethodInfo,
      FieldInfo,
      DefaultExpression,
      IsOperator,
      AsOperator,
      SizeOfOperator,
      Conversion,
      ArgList,
      ArgListOperator,
      FixedLocalCollectionInitializer,
      SequencePoint,
      SequencePointExpression,
      SequencePointWithSpan,
      Block,
      Scope,
      StateMachineScope,
      LocalDeclaration,
      MultipleLocalDeclarations,
      LocalFunctionStatement,
      Sequence,
      NoOpStatement,
      ReturnStatement,
      YieldReturnStatement,
      YieldBreakStatement,
      ThrowStatement,
      ExpressionStatement,
      SwitchStatement,
      SwitchSection,
      SwitchLabel,
      BreakStatement,
      ContinueStatement,
      PatternSwitchStatement,
      PatternSwitchSection,
      PatternSwitchLabel,
      IfStatement,
      DoStatement,
      WhileStatement,
      ForStatement,
      ForEachStatement,
      ForEachDeconstructStep,
      UsingStatement,
      FixedStatement,
      LockStatement,
      TryStatement,
      CatchBlock,
      Literal,
      ThisReference,
      PreviousSubmissionReference,
      HostObjectMemberReference,
      BaseReference,
      Local,
      PseudoVariable,
      RangeVariable,
      Parameter,
      LabelStatement,
      GotoStatement,
      LabeledStatement,
      Label,
      StatementList,
      ConditionalGoto,
      DynamicMemberAccess,
      DynamicInvocation,
      ConditionalAccess,
      LoweredConditionalAccess,
      ConditionalReceiver,
      ComplexConditionalReceiver,
      MethodGroup,
      PropertyGroup,
      Call,
      EventAssignmentOperator,
      Attribute,
      ObjectCreationExpression,
      TupleLiteral,
      ConvertedTupleLiteral,
      DynamicObjectCreationExpression,
      NoPiaObjectCreationExpression,
      ObjectInitializerExpression,
      ObjectInitializerMember,
      DynamicObjectInitializerMember,
      CollectionInitializerExpression,
      CollectionElementInitializer,
      DynamicCollectionElementInitializer,
      ImplicitReceiver,
      AnonymousObjectCreationExpression,
      AnonymousPropertyDeclaration,
      NewT,
      DelegateCreationExpression,
      ArrayCreation,
      ArrayInitialization,
      StackAllocArrayCreation,
      ConvertedStackAllocExpression,
      FieldAccess,
      HoistedFieldAccess,
      PropertyAccess,
      EventAccess,
      IndexerAccess,
      DynamicIndexerAccess,
      Lambda,
      UnboundLambda,
      QueryClause,
      TypeOrInstanceInitializers,
      NameOfOperator,
      InterpolatedString,
      StringInsert,
      IsPatternExpression,
      DeclarationPattern,
      ConstantPattern,
      WildcardPattern,
      DiscardExpression,
      ThrowExpression,
      OutVariablePendingInference,
      DeconstructionVariablePendingInference,
      OutDeconstructVarPendingInference,
      NonConstructorMethodBody,
      ConstructorMethodBody,    }


  internal abstract partial class BoundInitializer{
    protected BoundInitializer(BoundKind kind, SyntaxNode syntax, bool hasErrors)
    kind, syntax, hasErrors{
    }
    protected BoundInitializer(BoundKind kind, SyntaxNode syntax)
    kind, syntax{
    }
  }internal abstract partial class BoundEqualsValue{
    protected BoundEqualsValue(BoundKind kind, SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false)
    kind, syntax, hasErrors{
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.Value = value    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundExpression Value { get; }  }internal sealed partial class BoundFieldEqualsValue{
    public BoundFieldEqualsValue(SyntaxNode syntax, FieldSymbol field, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false)
    BoundKind.FieldEqualsValue, syntax, locals, value, hasErrors || value.HasErrors(){
      Debug.Assert(field != null, "Field 'field' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Field = field    }
    public  FieldSymbol Field { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitFieldEqualsValue(this)
    public BoundFieldEqualsValue Update(FieldSymbol field, ImmutableArray<LocalSymbol> locals, BoundExpression value)
    {
      if ()
      {
        (this.Syntax, Field, Locals, Value, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPropertyEqualsValue{
    public BoundPropertyEqualsValue(SyntaxNode syntax, PropertySymbol property, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false)
    BoundKind.PropertyEqualsValue, syntax, locals, value, hasErrors || value.HasErrors(){
      Debug.Assert(property != null, "Field 'property' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Property = property    }
    public  PropertySymbol Property { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPropertyEqualsValue(this)
    public BoundPropertyEqualsValue Update(PropertySymbol property, ImmutableArray<LocalSymbol> locals, BoundExpression value)
    {
      if ()
      {
        (this.Syntax, Property, Locals, Value, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundParameterEqualsValue{
    public BoundParameterEqualsValue(SyntaxNode syntax, ParameterSymbol parameter, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false)
    BoundKind.ParameterEqualsValue, syntax, locals, value, hasErrors || value.HasErrors(){
      Debug.Assert(parameter != null, "Field 'parameter' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Parameter = parameter    }
    public  ParameterSymbol Parameter { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitParameterEqualsValue(this)
    public BoundParameterEqualsValue Update(ParameterSymbol parameter, ImmutableArray<LocalSymbol> locals, BoundExpression value)
    {
      if ()
      {
        (this.Syntax, Parameter, Locals, Value, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundGlobalStatementInitializer{
    public BoundGlobalStatementInitializer(SyntaxNode syntax, BoundStatement statement,  bool hasErrors = false)
    BoundKind.GlobalStatementInitializer, syntax, hasErrors || statement.HasErrors(){
      Debug.Assert(statement != null, "Field 'statement' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Statement = statement    }
    public  BoundStatement Statement { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitGlobalStatementInitializer(this)
    public BoundGlobalStatementInitializer Update(BoundStatement statement)
    {
      if ()
      {
        (this.Syntax, Statement, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundExpression{
    protected BoundExpression(BoundKind kind, SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    kind, syntax, hasErrors{
      this.Type = type    }
    protected BoundExpression(BoundKind kind, SyntaxNode syntax, TypeSymbol type)
    kind, syntax{
      this.Type = type;
    }
    public  TypeSymbol Type { get; }  }internal abstract partial class BoundValuePlaceholderBase{
    protected BoundValuePlaceholderBase(BoundKind kind, SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    kind, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    protected BoundValuePlaceholderBase(BoundKind kind, SyntaxNode syntax, TypeSymbol type)
    kind, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
  }internal sealed partial class BoundDeconstructValuePlaceholder{
    public BoundDeconstructValuePlaceholder(SyntaxNode syntax, uint valEscape, TypeSymbol type, bool hasErrors)
    BoundKind.DeconstructValuePlaceholder, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ValEscape = valEscape    }
    public BoundDeconstructValuePlaceholder(SyntaxNode syntax, uint valEscape, TypeSymbol type)
    BoundKind.DeconstructValuePlaceholder, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ValEscape = valEscape;
    }
    public  uint ValEscape { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDeconstructValuePlaceholder(this)
    public BoundDeconstructValuePlaceholder Update(uint valEscape, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ValEscape, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundTupleOperandPlaceholder{
    public BoundTupleOperandPlaceholder(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.TupleOperandPlaceholder, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundTupleOperandPlaceholder(SyntaxNode syntax, TypeSymbol type)
    BoundKind.TupleOperandPlaceholder, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTupleOperandPlaceholder(this)
    public BoundTupleOperandPlaceholder Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDup{
    public BoundDup(SyntaxNode syntax, RefKind refKind, TypeSymbol type, bool hasErrors)
    BoundKind.Dup, syntax, type, hasErrors{
      this.RefKind = refKind    }
    public BoundDup(SyntaxNode syntax, RefKind refKind, TypeSymbol type)
    BoundKind.Dup, syntax, type{
      this.RefKind = refKind;
    }
    public  RefKind RefKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDup(this)
    public BoundDup Update(RefKind refKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, RefKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPassByCopy{
    public BoundPassByCopy(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false)
    BoundKind.PassByCopy, syntax, type, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expression    }
    public  BoundExpression Expression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPassByCopy(this)
    public BoundPassByCopy Update(BoundExpression expression, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundBadExpression{
    public BoundBadExpression(SyntaxNode syntax, LookupResultKind resultKind, ImmutableArray<Symbol> symbols, ImmutableArray<BoundExpression> childBoundNodes, TypeSymbol type,  bool hasErrors = false)
    BoundKind.BadExpression, syntax, type, hasErrors || childBoundNodes.HasErrors(){
      Debug.Assert(!symbols.IsDefault, "Field 'symbols' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!childBoundNodes.IsDefault, "Field 'childBoundNodes' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ResultKind = resultKindthis.Symbols = symbolsthis.ChildBoundNodes = childBoundNodes    }
    public override LookupResultKind ResultKind { get; }public  ImmutableArray<Symbol> Symbols { get; }public  ImmutableArray<BoundExpression> ChildBoundNodes { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitBadExpression(this)
    public BoundBadExpression Update(LookupResultKind resultKind, ImmutableArray<Symbol> symbols, ImmutableArray<BoundExpression> childBoundNodes, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ResultKind, Symbols, ChildBoundNodes, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundBadStatement{
    public BoundBadStatement(SyntaxNode syntax, ImmutableArray<BoundNode> childBoundNodes,  bool hasErrors = false)
    BoundKind.BadStatement, syntax, hasErrors || childBoundNodes.HasErrors(){
      Debug.Assert(!childBoundNodes.IsDefault, "Field 'childBoundNodes' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ChildBoundNodes = childBoundNodes    }
    public  ImmutableArray<BoundNode> ChildBoundNodes { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitBadStatement(this)
    public BoundBadStatement Update(ImmutableArray<BoundNode> childBoundNodes)
    {
      if ()
      {
        (this.Syntax, ChildBoundNodes, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundTypeExpression{
    public BoundTypeExpression(SyntaxNode syntax, AliasSymbol aliasOpt, bool inferredType, BoundTypeExpression boundContainingTypeOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.TypeExpression, syntax, type, hasErrors || boundContainingTypeOpt.HasErrors(){
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.AliasOpt = aliasOptthis.InferredType = inferredTypethis.BoundContainingTypeOpt = boundContainingTypeOpt    }
    public  AliasSymbol AliasOpt { get; }public  bool InferredType { get; }public  BoundTypeExpression BoundContainingTypeOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTypeExpression(this)
    public BoundTypeExpression Update(AliasSymbol aliasOpt, bool inferredType, BoundTypeExpression boundContainingTypeOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, AliasOpt, InferredType, BoundContainingTypeOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundTypeOrValueExpression{
    public BoundTypeOrValueExpression(SyntaxNode syntax, BoundTypeOrValueData data, TypeSymbol type, bool hasErrors)
    BoundKind.TypeOrValueExpression, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Data = data    }
    public BoundTypeOrValueExpression(SyntaxNode syntax, BoundTypeOrValueData data, TypeSymbol type)
    BoundKind.TypeOrValueExpression, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Data = data;
    }
    public  BoundTypeOrValueData Data { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTypeOrValueExpression(this)
    public BoundTypeOrValueExpression Update(BoundTypeOrValueData data, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Data, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundNamespaceExpression{
    public BoundNamespaceExpression(SyntaxNode syntax, NamespaceSymbol namespaceSymbol, AliasSymbol aliasOpt, bool hasErrors)
    BoundKind.NamespaceExpression, syntax, null, hasErrors{
      Debug.Assert(namespaceSymbol != null, "Field 'namespaceSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.NamespaceSymbol = namespaceSymbolthis.AliasOpt = aliasOpt    }
    public BoundNamespaceExpression(SyntaxNode syntax, NamespaceSymbol namespaceSymbol, AliasSymbol aliasOpt)
    BoundKind.NamespaceExpression, syntax, null{
      Debug.Assert(namespaceSymbol != null, "Field 'namespaceSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.NamespaceSymbol = namespaceSymbol;
      this.AliasOpt = aliasOpt;
    }
    public  NamespaceSymbol NamespaceSymbol { get; }public  AliasSymbol AliasOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNamespaceExpression(this)
    public BoundNamespaceExpression Update(NamespaceSymbol namespaceSymbol, AliasSymbol aliasOpt)
    {
      if ()
      {
        (this.Syntax, NamespaceSymbol, AliasOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundUnaryOperator{
    public BoundUnaryOperator(SyntaxNode syntax, UnaryOperatorKind operatorKind, BoundExpression operand, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.UnaryOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.OperatorKind = operatorKindthis.Operand = operandthis.ConstantValueOpt = constantValueOptthis.MethodOpt = methodOptthis.ResultKind = resultKind    }
    public  UnaryOperatorKind OperatorKind { get; }public  BoundExpression Operand { get; }public  ConstantValue ConstantValueOpt { get; }public  MethodSymbol MethodOpt { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitUnaryOperator(this)
    public BoundUnaryOperator Update(UnaryOperatorKind operatorKind, BoundExpression operand, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, OperatorKind, Operand, ConstantValueOpt, MethodOpt, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundIncrementOperator{
    public BoundIncrementOperator(SyntaxNode syntax, UnaryOperatorKind operatorKind, BoundExpression operand, MethodSymbol methodOpt, Conversion operandConversion, Conversion resultConversion, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.IncrementOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.OperatorKind = operatorKindthis.Operand = operandthis.MethodOpt = methodOptthis.OperandConversion = operandConversionthis.ResultConversion = resultConversionthis.ResultKind = resultKind    }
    public  UnaryOperatorKind OperatorKind { get; }public  BoundExpression Operand { get; }public  MethodSymbol MethodOpt { get; }public  Conversion OperandConversion { get; }public  Conversion ResultConversion { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitIncrementOperator(this)
    public BoundIncrementOperator Update(UnaryOperatorKind operatorKind, BoundExpression operand, MethodSymbol methodOpt, Conversion operandConversion, Conversion resultConversion, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, OperatorKind, Operand, MethodOpt, OperandConversion, ResultConversion, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAddressOfOperator{
    public BoundAddressOfOperator(SyntaxNode syntax, BoundExpression operand, bool isManaged, TypeSymbol type,  bool hasErrors = false)
    BoundKind.AddressOfOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operandthis.IsManaged = isManaged    }
    public  BoundExpression Operand { get; }public  bool IsManaged { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAddressOfOperator(this)
    public BoundAddressOfOperator Update(BoundExpression operand, bool isManaged, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, IsManaged, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPointerIndirectionOperator{
    public BoundPointerIndirectionOperator(SyntaxNode syntax, BoundExpression operand, TypeSymbol type,  bool hasErrors = false)
    BoundKind.PointerIndirectionOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operand    }
    public  BoundExpression Operand { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPointerIndirectionOperator(this)
    public BoundPointerIndirectionOperator Update(BoundExpression operand, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPointerElementAccess{
    public BoundPointerElementAccess(SyntaxNode syntax, BoundExpression expression, BoundExpression index, bool @checked, TypeSymbol type,  bool hasErrors = false)
    BoundKind.PointerElementAccess, syntax, type, hasErrors || expression.HasErrors() || index.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(index != null, "Field 'index' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expressionthis.Index = indexthis.Checked = @checked    }
    public  BoundExpression Expression { get; }public  BoundExpression Index { get; }public  bool Checked { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPointerElementAccess(this)
    public BoundPointerElementAccess Update(BoundExpression expression, BoundExpression index, bool @checked, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Index, Checked, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundRefTypeOperator{
    public BoundRefTypeOperator(SyntaxNode syntax, BoundExpression operand, MethodSymbol getTypeFromHandle, TypeSymbol type,  bool hasErrors = false)
    BoundKind.RefTypeOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operandthis.GetTypeFromHandle = getTypeFromHandle    }
    public  BoundExpression Operand { get; }public  MethodSymbol GetTypeFromHandle { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitRefTypeOperator(this)
    public BoundRefTypeOperator Update(BoundExpression operand, MethodSymbol getTypeFromHandle, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, GetTypeFromHandle, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundMakeRefOperator{
    public BoundMakeRefOperator(SyntaxNode syntax, BoundExpression operand, TypeSymbol type,  bool hasErrors = false)
    BoundKind.MakeRefOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operand    }
    public  BoundExpression Operand { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitMakeRefOperator(this)
    public BoundMakeRefOperator Update(BoundExpression operand, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundRefValueOperator{
    public BoundRefValueOperator(SyntaxNode syntax, BoundExpression operand, TypeSymbol type,  bool hasErrors = false)
    BoundKind.RefValueOperator, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operand    }
    public  BoundExpression Operand { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitRefValueOperator(this)
    public BoundRefValueOperator Update(BoundExpression operand, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundBinaryOperator{
    public BoundBinaryOperator(SyntaxNode syntax, BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.BinaryOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors(){
      Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.OperatorKind = operatorKindthis.Left = leftthis.Right = rightthis.ConstantValueOpt = constantValueOptthis.MethodOpt = methodOptthis.ResultKind = resultKind    }
    public  BinaryOperatorKind OperatorKind { get; }public  BoundExpression Left { get; }public  BoundExpression Right { get; }public  ConstantValue ConstantValueOpt { get; }public  MethodSymbol MethodOpt { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitBinaryOperator(this)
    public BoundBinaryOperator Update(BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, OperatorKind, Left, Right, ConstantValueOpt, MethodOpt, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundTupleBinaryOperator{
    public BoundTupleBinaryOperator(SyntaxNode syntax, BoundExpression left, BoundExpression right, BoundExpression convertedLeft, BoundExpression convertedRight, BinaryOperatorKind operatorKind, TupleBinaryOperatorInfo.Multiple operators, TypeSymbol type,  bool hasErrors = false)
    BoundKind.TupleBinaryOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors() || convertedLeft.HasErrors() || convertedRight.HasErrors(){
      Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(convertedLeft != null, "Field 'convertedLeft' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(convertedRight != null, "Field 'convertedRight' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(operators != null, "Field 'operators' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Left = leftthis.Right = rightthis.ConvertedLeft = convertedLeftthis.ConvertedRight = convertedRightthis.OperatorKind = operatorKindthis.Operators = operators    }
    public  BoundExpression Left { get; }public  BoundExpression Right { get; }public  BoundExpression ConvertedLeft { get; }public  BoundExpression ConvertedRight { get; }public  BinaryOperatorKind OperatorKind { get; }public  TupleBinaryOperatorInfo.Multiple Operators { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTupleBinaryOperator(this)
    public BoundTupleBinaryOperator Update(BoundExpression left, BoundExpression right, BoundExpression convertedLeft, BoundExpression convertedRight, BinaryOperatorKind operatorKind, TupleBinaryOperatorInfo.Multiple operators, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Left, Right, ConvertedLeft, ConvertedRight, OperatorKind, Operators, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundUserDefinedConditionalLogicalOperator{
    public BoundUserDefinedConditionalLogicalOperator(SyntaxNode syntax, BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, MethodSymbol logicalOperator, MethodSymbol trueOperator, MethodSymbol falseOperator, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.UserDefinedConditionalLogicalOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors(){
      Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(logicalOperator != null, "Field 'logicalOperator' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(trueOperator != null, "Field 'trueOperator' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(falseOperator != null, "Field 'falseOperator' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.OperatorKind = operatorKindthis.Left = leftthis.Right = rightthis.LogicalOperator = logicalOperatorthis.TrueOperator = trueOperatorthis.FalseOperator = falseOperatorthis.ResultKind = resultKind    }
    public  BinaryOperatorKind OperatorKind { get; }public  BoundExpression Left { get; }public  BoundExpression Right { get; }public  MethodSymbol LogicalOperator { get; }public  MethodSymbol TrueOperator { get; }public  MethodSymbol FalseOperator { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitUserDefinedConditionalLogicalOperator(this)
    public BoundUserDefinedConditionalLogicalOperator Update(BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, MethodSymbol logicalOperator, MethodSymbol trueOperator, MethodSymbol falseOperator, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, OperatorKind, Left, Right, LogicalOperator, TrueOperator, FalseOperator, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundCompoundAssignmentOperator{
    public BoundCompoundAssignmentOperator(SyntaxNode syntax, BinaryOperatorSignature @operator, BoundExpression left, BoundExpression right, Conversion leftConversion, Conversion finalConversion, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.CompoundAssignmentOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors(){
      Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operator = @operatorthis.Left = leftthis.Right = rightthis.LeftConversion = leftConversionthis.FinalConversion = finalConversionthis.ResultKind = resultKind    }
    public  BinaryOperatorSignature Operator { get; }public  BoundExpression Left { get; }public  BoundExpression Right { get; }public  Conversion LeftConversion { get; }public  Conversion FinalConversion { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitCompoundAssignmentOperator(this)
    public BoundCompoundAssignmentOperator Update(BinaryOperatorSignature @operator, BoundExpression left, BoundExpression right, Conversion leftConversion, Conversion finalConversion, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operator, Left, Right, LeftConversion, FinalConversion, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAssignmentOperator{
    public BoundAssignmentOperator(SyntaxNode syntax, BoundExpression left, BoundExpression right, bool isRef, TypeSymbol type,  bool hasErrors = false)
    BoundKind.AssignmentOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors(){
      Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Left = leftthis.Right = rightthis.IsRef = isRef    }
    public  BoundExpression Left { get; }public  BoundExpression Right { get; }public  bool IsRef { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAssignmentOperator(this)
    public BoundAssignmentOperator Update(BoundExpression left, BoundExpression right, bool isRef, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Left, Right, IsRef, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDeconstructionAssignmentOperator{
    public BoundDeconstructionAssignmentOperator(SyntaxNode syntax, BoundTupleExpression left, BoundConversion right, bool isUsed, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DeconstructionAssignmentOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors(){
      Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Left = leftthis.Right = rightthis.IsUsed = isUsed    }
    public  BoundTupleExpression Left { get; }public  BoundConversion Right { get; }public  bool IsUsed { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDeconstructionAssignmentOperator(this)
    public BoundDeconstructionAssignmentOperator Update(BoundTupleExpression left, BoundConversion right, bool isUsed, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Left, Right, IsUsed, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundNullCoalescingOperator{
    public BoundNullCoalescingOperator(SyntaxNode syntax, BoundExpression leftOperand, BoundExpression rightOperand, Conversion leftConversion, TypeSymbol type,  bool hasErrors = false)
    BoundKind.NullCoalescingOperator, syntax, type, hasErrors || leftOperand.HasErrors() || rightOperand.HasErrors(){
      Debug.Assert(leftOperand != null, "Field 'leftOperand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(rightOperand != null, "Field 'rightOperand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LeftOperand = leftOperandthis.RightOperand = rightOperandthis.LeftConversion = leftConversion    }
    public  BoundExpression LeftOperand { get; }public  BoundExpression RightOperand { get; }public  Conversion LeftConversion { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNullCoalescingOperator(this)
    public BoundNullCoalescingOperator Update(BoundExpression leftOperand, BoundExpression rightOperand, Conversion leftConversion, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, LeftOperand, RightOperand, LeftConversion, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConditionalOperator{
    public BoundConditionalOperator(SyntaxNode syntax, bool isRef, BoundExpression condition, BoundExpression consequence, BoundExpression alternative, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ConditionalOperator, syntax, type, hasErrors || condition.HasErrors() || consequence.HasErrors() || alternative.HasErrors(){
      Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(consequence != null, "Field 'consequence' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(alternative != null, "Field 'alternative' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.IsRef = isRefthis.Condition = conditionthis.Consequence = consequencethis.Alternative = alternativethis.ConstantValueOpt = constantValueOpt    }
    public  bool IsRef { get; }public  BoundExpression Condition { get; }public  BoundExpression Consequence { get; }public  BoundExpression Alternative { get; }public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConditionalOperator(this)
    public BoundConditionalOperator Update(bool isRef, BoundExpression condition, BoundExpression consequence, BoundExpression alternative, ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, IsRef, Condition, Consequence, Alternative, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundArrayAccess{
    public BoundArrayAccess(SyntaxNode syntax, BoundExpression expression, ImmutableArray<BoundExpression> indices, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ArrayAccess, syntax, type, hasErrors || expression.HasErrors() || indices.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!indices.IsDefault, "Field 'indices' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expressionthis.Indices = indices    }
    public  BoundExpression Expression { get; }public  ImmutableArray<BoundExpression> Indices { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitArrayAccess(this)
    public BoundArrayAccess Update(BoundExpression expression, ImmutableArray<BoundExpression> indices, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Indices, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundArrayLength{
    public BoundArrayLength(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ArrayLength, syntax, type, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expression    }
    public  BoundExpression Expression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitArrayLength(this)
    public BoundArrayLength Update(BoundExpression expression, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAwaitExpression{
    public BoundAwaitExpression(SyntaxNode syntax, BoundExpression expression, MethodSymbol getAwaiter, PropertySymbol isCompleted, MethodSymbol getResult, TypeSymbol type,  bool hasErrors = false)
    BoundKind.AwaitExpression, syntax, type, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expressionthis.GetAwaiter = getAwaiterthis.IsCompleted = isCompletedthis.GetResult = getResult    }
    public  BoundExpression Expression { get; }public  MethodSymbol GetAwaiter { get; }public  PropertySymbol IsCompleted { get; }public  MethodSymbol GetResult { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAwaitExpression(this)
    public BoundAwaitExpression Update(BoundExpression expression, MethodSymbol getAwaiter, PropertySymbol isCompleted, MethodSymbol getResult, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, GetAwaiter, IsCompleted, GetResult, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundTypeOf{
    protected BoundTypeOf(BoundKind kind, SyntaxNode syntax, MethodSymbol getTypeFromHandle, TypeSymbol type, bool hasErrors)
    kind, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.GetTypeFromHandle = getTypeFromHandle    }
    protected BoundTypeOf(BoundKind kind, SyntaxNode syntax, MethodSymbol getTypeFromHandle, TypeSymbol type)
    kind, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.GetTypeFromHandle = getTypeFromHandle;
    }
    public  MethodSymbol GetTypeFromHandle { get; }  }internal sealed partial class BoundTypeOfOperator{
    public BoundTypeOfOperator(SyntaxNode syntax, BoundTypeExpression sourceType, MethodSymbol getTypeFromHandle, TypeSymbol type,  bool hasErrors = false)
    BoundKind.TypeOfOperator, syntax, getTypeFromHandle, type, hasErrors || sourceType.HasErrors(){
      Debug.Assert(sourceType != null, "Field 'sourceType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.SourceType = sourceType    }
    public  BoundTypeExpression SourceType { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTypeOfOperator(this)
    public BoundTypeOfOperator Update(BoundTypeExpression sourceType, MethodSymbol getTypeFromHandle, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, SourceType, GetTypeFromHandle, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundMethodDefIndex{
    public BoundMethodDefIndex(SyntaxNode syntax, MethodSymbol method, TypeSymbol type, bool hasErrors)
    BoundKind.MethodDefIndex, syntax, type, hasErrors{
      Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Method = method    }
    public BoundMethodDefIndex(SyntaxNode syntax, MethodSymbol method, TypeSymbol type)
    BoundKind.MethodDefIndex, syntax, type{
      Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Method = method;
    }
    public  MethodSymbol Method { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitMethodDefIndex(this)
    public BoundMethodDefIndex Update(MethodSymbol method, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Method, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundMaximumMethodDefIndex{
    public BoundMaximumMethodDefIndex(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.MaximumMethodDefIndex, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundMaximumMethodDefIndex(SyntaxNode syntax, TypeSymbol type)
    BoundKind.MaximumMethodDefIndex, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitMaximumMethodDefIndex(this)
    public BoundMaximumMethodDefIndex Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundInstrumentationPayloadRoot{
    public BoundInstrumentationPayloadRoot(SyntaxNode syntax, int analysisKind, TypeSymbol type, bool hasErrors)
    BoundKind.InstrumentationPayloadRoot, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.AnalysisKind = analysisKind    }
    public BoundInstrumentationPayloadRoot(SyntaxNode syntax, int analysisKind, TypeSymbol type)
    BoundKind.InstrumentationPayloadRoot, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.AnalysisKind = analysisKind;
    }
    public  int AnalysisKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitInstrumentationPayloadRoot(this)
    public BoundInstrumentationPayloadRoot Update(int analysisKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, AnalysisKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundModuleVersionId{
    public BoundModuleVersionId(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.ModuleVersionId, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundModuleVersionId(SyntaxNode syntax, TypeSymbol type)
    BoundKind.ModuleVersionId, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitModuleVersionId(this)
    public BoundModuleVersionId Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundModuleVersionIdString{
    public BoundModuleVersionIdString(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.ModuleVersionIdString, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundModuleVersionIdString(SyntaxNode syntax, TypeSymbol type)
    BoundKind.ModuleVersionIdString, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitModuleVersionIdString(this)
    public BoundModuleVersionIdString Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSourceDocumentIndex{
    public BoundSourceDocumentIndex(SyntaxNode syntax, Cci.DebugSourceDocument document, TypeSymbol type, bool hasErrors)
    BoundKind.SourceDocumentIndex, syntax, type, hasErrors{
      Debug.Assert(document != null, "Field 'document' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Document = document    }
    public BoundSourceDocumentIndex(SyntaxNode syntax, Cci.DebugSourceDocument document, TypeSymbol type)
    BoundKind.SourceDocumentIndex, syntax, type{
      Debug.Assert(document != null, "Field 'document' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Document = document;
    }
    public  Cci.DebugSourceDocument Document { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSourceDocumentIndex(this)
    public BoundSourceDocumentIndex Update(Cci.DebugSourceDocument document, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Document, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundMethodInfo{
    public BoundMethodInfo(SyntaxNode syntax, MethodSymbol method, MethodSymbol getMethodFromHandle, TypeSymbol type, bool hasErrors)
    BoundKind.MethodInfo, syntax, type, hasErrors{
      Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Method = methodthis.GetMethodFromHandle = getMethodFromHandle    }
    public BoundMethodInfo(SyntaxNode syntax, MethodSymbol method, MethodSymbol getMethodFromHandle, TypeSymbol type)
    BoundKind.MethodInfo, syntax, type{
      Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Method = method;
      this.GetMethodFromHandle = getMethodFromHandle;
    }
    public  MethodSymbol Method { get; }public  MethodSymbol GetMethodFromHandle { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitMethodInfo(this)
    public BoundMethodInfo Update(MethodSymbol method, MethodSymbol getMethodFromHandle, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Method, GetMethodFromHandle, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundFieldInfo{
    public BoundFieldInfo(SyntaxNode syntax, FieldSymbol field, MethodSymbol getFieldFromHandle, TypeSymbol type, bool hasErrors)
    BoundKind.FieldInfo, syntax, type, hasErrors{
      Debug.Assert(field != null, "Field 'field' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Field = fieldthis.GetFieldFromHandle = getFieldFromHandle    }
    public BoundFieldInfo(SyntaxNode syntax, FieldSymbol field, MethodSymbol getFieldFromHandle, TypeSymbol type)
    BoundKind.FieldInfo, syntax, type{
      Debug.Assert(field != null, "Field 'field' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Field = field;
      this.GetFieldFromHandle = getFieldFromHandle;
    }
    public  FieldSymbol Field { get; }public  MethodSymbol GetFieldFromHandle { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitFieldInfo(this)
    public BoundFieldInfo Update(FieldSymbol field, MethodSymbol getFieldFromHandle, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Field, GetFieldFromHandle, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDefaultExpression{
    public BoundDefaultExpression(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type, bool hasErrors)
    BoundKind.DefaultExpression, syntax, type, hasErrors{
      this.ConstantValueOpt = constantValueOpt    }
    public BoundDefaultExpression(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type)
    BoundKind.DefaultExpression, syntax, type{
      this.ConstantValueOpt = constantValueOpt;
    }
    public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDefaultExpression(this)
    public BoundDefaultExpression Update(ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundIsOperator{
    public BoundIsOperator(SyntaxNode syntax, BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type,  bool hasErrors = false)
    BoundKind.IsOperator, syntax, type, hasErrors || operand.HasErrors() || targetType.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(targetType != null, "Field 'targetType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operandthis.TargetType = targetTypethis.Conversion = conversion    }
    public  BoundExpression Operand { get; }public  BoundTypeExpression TargetType { get; }public  Conversion Conversion { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitIsOperator(this)
    public BoundIsOperator Update(BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, TargetType, Conversion, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAsOperator{
    public BoundAsOperator(SyntaxNode syntax, BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type,  bool hasErrors = false)
    BoundKind.AsOperator, syntax, type, hasErrors || operand.HasErrors() || targetType.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(targetType != null, "Field 'targetType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operandthis.TargetType = targetTypethis.Conversion = conversion    }
    public  BoundExpression Operand { get; }public  BoundTypeExpression TargetType { get; }public  Conversion Conversion { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAsOperator(this)
    public BoundAsOperator Update(BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, TargetType, Conversion, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSizeOfOperator{
    public BoundSizeOfOperator(SyntaxNode syntax, BoundTypeExpression sourceType, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.SizeOfOperator, syntax, type, hasErrors || sourceType.HasErrors(){
      Debug.Assert(sourceType != null, "Field 'sourceType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.SourceType = sourceTypethis.ConstantValueOpt = constantValueOpt    }
    public  BoundTypeExpression SourceType { get; }public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSizeOfOperator(this)
    public BoundSizeOfOperator Update(BoundTypeExpression sourceType, ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, SourceType, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConversion{
    public BoundConversion(SyntaxNode syntax, BoundExpression operand, Conversion conversion, bool isBaseConversion, bool @checked, bool explicitCastInCode, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.Conversion, syntax, type, hasErrors || operand.HasErrors(){
      Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Operand = operandthis.Conversion = conversionthis.IsBaseConversion = isBaseConversionthis.Checked = @checkedthis.ExplicitCastInCode = explicitCastInCodethis.ConstantValueOpt = constantValueOpt    }
    public  BoundExpression Operand { get; }public  Conversion Conversion { get; }public  bool IsBaseConversion { get; }public  bool Checked { get; }public  bool ExplicitCastInCode { get; }public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConversion(this)
    public BoundConversion Update(BoundExpression operand, Conversion conversion, bool isBaseConversion, bool @checked, bool explicitCastInCode, ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Operand, Conversion, IsBaseConversion, Checked, ExplicitCastInCode, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundArgList{
    public BoundArgList(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.ArgList, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundArgList(SyntaxNode syntax, TypeSymbol type)
    BoundKind.ArgList, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitArgList(this)
    public BoundArgList Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundArgListOperator{
    public BoundArgListOperator(SyntaxNode syntax, ImmutableArray<BoundExpression> arguments, ImmutableArray<RefKind> argumentRefKindsOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ArgListOperator, syntax, type, hasErrors || arguments.HasErrors(){
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Arguments = argumentsthis.ArgumentRefKindsOpt = argumentRefKindsOpt    }
    public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitArgListOperator(this)
    public BoundArgListOperator Update(ImmutableArray<BoundExpression> arguments, ImmutableArray<RefKind> argumentRefKindsOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Arguments, ArgumentRefKindsOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundFixedLocalCollectionInitializer{
    public BoundFixedLocalCollectionInitializer(SyntaxNode syntax, TypeSymbol elementPointerType, Conversion elementPointerTypeConversion, BoundExpression expression, MethodSymbol getPinnableOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.FixedLocalCollectionInitializer, syntax, type, hasErrors || expression.HasErrors(){
      Debug.Assert(elementPointerType != null, "Field 'elementPointerType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ElementPointerType = elementPointerTypethis.ElementPointerTypeConversion = elementPointerTypeConversionthis.Expression = expressionthis.GetPinnableOpt = getPinnableOpt    }
    public  TypeSymbol ElementPointerType { get; }public  Conversion ElementPointerTypeConversion { get; }public  BoundExpression Expression { get; }public  MethodSymbol GetPinnableOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitFixedLocalCollectionInitializer(this)
    public BoundFixedLocalCollectionInitializer Update(TypeSymbol elementPointerType, Conversion elementPointerTypeConversion, BoundExpression expression, MethodSymbol getPinnableOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ElementPointerType, ElementPointerTypeConversion, Expression, GetPinnableOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundStatement{
    protected BoundStatement(BoundKind kind, SyntaxNode syntax, bool hasErrors)
    kind, syntax, hasErrors{
    }
    protected BoundStatement(BoundKind kind, SyntaxNode syntax)
    kind, syntax{
    }
  }internal sealed partial class BoundSequencePoint{
    public BoundSequencePoint(SyntaxNode syntax, BoundStatement statementOpt,  bool hasErrors = false)
    BoundKind.SequencePoint, syntax, hasErrors || statementOpt.HasErrors(){
      this.StatementOpt = statementOpt    }
    public  BoundStatement StatementOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSequencePoint(this)
    public BoundSequencePoint Update(BoundStatement statementOpt)
    {
      if ()
      {
        (this.Syntax, StatementOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSequencePointExpression{
    public BoundSequencePointExpression(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false)
    BoundKind.SequencePointExpression, syntax, type, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expression    }
    public  BoundExpression Expression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSequencePointExpression(this)
    public BoundSequencePointExpression Update(BoundExpression expression, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSequencePointWithSpan{
    public BoundSequencePointWithSpan(SyntaxNode syntax, BoundStatement statementOpt, TextSpan span,  bool hasErrors = false)
    BoundKind.SequencePointWithSpan, syntax, hasErrors || statementOpt.HasErrors(){
      this.StatementOpt = statementOptthis.Span = span    }
    public  BoundStatement StatementOpt { get; }public  TextSpan Span { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSequencePointWithSpan(this)
    public BoundSequencePointWithSpan Update(BoundStatement statementOpt, TextSpan span)
    {
      if ()
      {
        (this.Syntax, StatementOpt, Span, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundBlock{
    public BoundBlock(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<LocalFunctionSymbol> localFunctions, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    BoundKind.Block, syntax, statements, hasErrors || statements.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!localFunctions.IsDefault, "Field 'localFunctions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.LocalFunctions = localFunctions    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  ImmutableArray<LocalFunctionSymbol> LocalFunctions { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitBlock(this)
    public BoundBlock Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<LocalFunctionSymbol> localFunctions, ImmutableArray<BoundStatement> statements)
    {
      if ()
      {
        (this.Syntax, Locals, LocalFunctions, Statements, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundScope{
    public BoundScope(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    BoundKind.Scope, syntax, statements, hasErrors || statements.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = locals    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitScope(this)
    public BoundScope Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundStatement> statements)
    {
      if ()
      {
        (this.Syntax, Locals, Statements, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundStateMachineScope{
    public BoundStateMachineScope(SyntaxNode syntax, ImmutableArray<StateMachineFieldSymbol> fields, BoundStatement statement,  bool hasErrors = false)
    BoundKind.StateMachineScope, syntax, hasErrors || statement.HasErrors(){
      Debug.Assert(!fields.IsDefault, "Field 'fields' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(statement != null, "Field 'statement' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Fields = fieldsthis.Statement = statement    }
    public  ImmutableArray<StateMachineFieldSymbol> Fields { get; }public  BoundStatement Statement { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitStateMachineScope(this)
    public BoundStateMachineScope Update(ImmutableArray<StateMachineFieldSymbol> fields, BoundStatement statement)
    {
      if ()
      {
        (this.Syntax, Fields, Statement, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLocalDeclaration{
    public BoundLocalDeclaration(SyntaxNode syntax, LocalSymbol localSymbol, BoundTypeExpression declaredType, BoundExpression initializerOpt, ImmutableArray<BoundExpression> argumentsOpt,  bool hasErrors = false)
    BoundKind.LocalDeclaration, syntax, hasErrors || declaredType.HasErrors() || initializerOpt.HasErrors() || argumentsOpt.HasErrors(){
      Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(declaredType != null, "Field 'declaredType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LocalSymbol = localSymbolthis.DeclaredType = declaredTypethis.InitializerOpt = initializerOptthis.ArgumentsOpt = argumentsOpt    }
    public  LocalSymbol LocalSymbol { get; }public  BoundTypeExpression DeclaredType { get; }public  BoundExpression InitializerOpt { get; }public  ImmutableArray<BoundExpression> ArgumentsOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLocalDeclaration(this)
    public BoundLocalDeclaration Update(LocalSymbol localSymbol, BoundTypeExpression declaredType, BoundExpression initializerOpt, ImmutableArray<BoundExpression> argumentsOpt)
    {
      if ()
      {
        (this.Syntax, LocalSymbol, DeclaredType, InitializerOpt, ArgumentsOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundMultipleLocalDeclarations{
    public BoundMultipleLocalDeclarations(SyntaxNode syntax, ImmutableArray<BoundLocalDeclaration> localDeclarations,  bool hasErrors = false)
    BoundKind.MultipleLocalDeclarations, syntax, hasErrors || localDeclarations.HasErrors(){
      Debug.Assert(!localDeclarations.IsDefault, "Field 'localDeclarations' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LocalDeclarations = localDeclarations    }
    public  ImmutableArray<BoundLocalDeclaration> LocalDeclarations { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitMultipleLocalDeclarations(this)
    public BoundMultipleLocalDeclarations Update(ImmutableArray<BoundLocalDeclaration> localDeclarations)
    {
      if ()
      {
        (this.Syntax, LocalDeclarations, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLocalFunctionStatement{
    public BoundLocalFunctionStatement(SyntaxNode syntax, LocalFunctionSymbol symbol, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false)
    BoundKind.LocalFunctionStatement, syntax, hasErrors || blockBody.HasErrors() || expressionBody.HasErrors(){
      Debug.Assert(symbol != null, "Field 'symbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Symbol = symbolthis.BlockBody = blockBodythis.ExpressionBody = expressionBody    }
    public  LocalFunctionSymbol Symbol { get; }public  BoundBlock BlockBody { get; }public  BoundBlock ExpressionBody { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLocalFunctionStatement(this)
    public BoundLocalFunctionStatement Update(LocalFunctionSymbol symbol, BoundBlock blockBody, BoundBlock expressionBody)
    {
      if ()
      {
        (this.Syntax, Symbol, BlockBody, ExpressionBody, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSequence{
    public BoundSequence(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundExpression> sideEffects, BoundExpression value, TypeSymbol type,  bool hasErrors = false)
    BoundKind.Sequence, syntax, type, hasErrors || sideEffects.HasErrors() || value.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!sideEffects.IsDefault, "Field 'sideEffects' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.SideEffects = sideEffectsthis.Value = value    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  ImmutableArray<BoundExpression> SideEffects { get; }public  BoundExpression Value { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSequence(this)
    public BoundSequence Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundExpression> sideEffects, BoundExpression value, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Locals, SideEffects, Value, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundNoOpStatement{
    public BoundNoOpStatement(SyntaxNode syntax, NoOpStatementFlavor flavor, bool hasErrors)
    BoundKind.NoOpStatement, syntax, hasErrors{
      this.Flavor = flavor    }
    public BoundNoOpStatement(SyntaxNode syntax, NoOpStatementFlavor flavor)
    BoundKind.NoOpStatement, syntax{
      this.Flavor = flavor;
    }
    public  NoOpStatementFlavor Flavor { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNoOpStatement(this)
    public BoundNoOpStatement Update(NoOpStatementFlavor flavor)
    {
      if ()
      {
        (this.Syntax, Flavor, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundReturnStatement{
    public BoundReturnStatement(SyntaxNode syntax, RefKind refKind, BoundExpression expressionOpt,  bool hasErrors = false)
    BoundKind.ReturnStatement, syntax, hasErrors || expressionOpt.HasErrors(){
      this.RefKind = refKindthis.ExpressionOpt = expressionOpt    }
    public  RefKind RefKind { get; }public  BoundExpression ExpressionOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitReturnStatement(this)
    public BoundReturnStatement Update(RefKind refKind, BoundExpression expressionOpt)
    {
      if ()
      {
        (this.Syntax, RefKind, ExpressionOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundYieldReturnStatement{
    public BoundYieldReturnStatement(SyntaxNode syntax, BoundExpression expression,  bool hasErrors = false)
    BoundKind.YieldReturnStatement, syntax, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expression    }
    public  BoundExpression Expression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitYieldReturnStatement(this)
    public BoundYieldReturnStatement Update(BoundExpression expression)
    {
      if ()
      {
        (this.Syntax, Expression, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundYieldBreakStatement{
    public BoundYieldBreakStatement(SyntaxNode syntax, bool hasErrors)
    BoundKind.YieldBreakStatement, syntax, hasErrors{
    }
    public BoundYieldBreakStatement(SyntaxNode syntax)
    BoundKind.YieldBreakStatement, syntax{
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitYieldBreakStatement(this)
  }internal sealed partial class BoundThrowStatement{
    public BoundThrowStatement(SyntaxNode syntax, BoundExpression expressionOpt,  bool hasErrors = false)
    BoundKind.ThrowStatement, syntax, hasErrors || expressionOpt.HasErrors(){
      this.ExpressionOpt = expressionOpt    }
    public  BoundExpression ExpressionOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitThrowStatement(this)
    public BoundThrowStatement Update(BoundExpression expressionOpt)
    {
      if ()
      {
        (this.Syntax, ExpressionOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundExpressionStatement{
    public BoundExpressionStatement(SyntaxNode syntax, BoundExpression expression,  bool hasErrors = false)
    BoundKind.ExpressionStatement, syntax, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expression    }
    public  BoundExpression Expression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitExpressionStatement(this)
    public BoundExpressionStatement Update(BoundExpression expression)
    {
      if ()
      {
        (this.Syntax, Expression, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSwitchStatement{
    public BoundSwitchStatement(SyntaxNode syntax, BoundStatement loweredPreambleOpt, BoundExpression expression, LabelSymbol constantTargetOpt, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundSwitchSection> switchSections, GeneratedLabelSymbol breakLabel, MethodSymbol stringEquality,  bool hasErrors = false)
    BoundKind.SwitchStatement, syntax, hasErrors || loweredPreambleOpt.HasErrors() || expression.HasErrors() || switchSections.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!innerLocals.IsDefault, "Field 'innerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!innerLocalFunctions.IsDefault, "Field 'innerLocalFunctions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!switchSections.IsDefault, "Field 'switchSections' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LoweredPreambleOpt = loweredPreambleOptthis.Expression = expressionthis.ConstantTargetOpt = constantTargetOptthis.InnerLocals = innerLocalsthis.InnerLocalFunctions = innerLocalFunctionsthis.SwitchSections = switchSectionsthis.BreakLabel = breakLabelthis.StringEquality = stringEquality    }
    public  BoundStatement LoweredPreambleOpt { get; }public  BoundExpression Expression { get; }public  LabelSymbol ConstantTargetOpt { get; }public  ImmutableArray<LocalSymbol> InnerLocals { get; }public  ImmutableArray<LocalFunctionSymbol> InnerLocalFunctions { get; }public  ImmutableArray<BoundSwitchSection> SwitchSections { get; }public  GeneratedLabelSymbol BreakLabel { get; }public  MethodSymbol StringEquality { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSwitchStatement(this)
    public BoundSwitchStatement Update(BoundStatement loweredPreambleOpt, BoundExpression expression, LabelSymbol constantTargetOpt, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundSwitchSection> switchSections, GeneratedLabelSymbol breakLabel, MethodSymbol stringEquality)
    {
      if ()
      {
        (this.Syntax, LoweredPreambleOpt, Expression, ConstantTargetOpt, InnerLocals, InnerLocalFunctions, SwitchSections, BreakLabel, StringEquality, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSwitchSection{
    public BoundSwitchSection(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    BoundKind.SwitchSection, syntax, statements, hasErrors || switchLabels.HasErrors() || statements.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!switchLabels.IsDefault, "Field 'switchLabels' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.SwitchLabels = switchLabels    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  ImmutableArray<BoundSwitchLabel> SwitchLabels { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSwitchSection(this)
    public BoundSwitchSection Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements)
    {
      if ()
      {
        (this.Syntax, Locals, SwitchLabels, Statements, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundSwitchLabel{
    public BoundSwitchLabel(SyntaxNode syntax, LabelSymbol label, BoundExpression expressionOpt, ConstantValue constantValueOpt,  bool hasErrors = false)
    BoundKind.SwitchLabel, syntax, hasErrors || expressionOpt.HasErrors(){
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = labelthis.ExpressionOpt = expressionOptthis.ConstantValueOpt = constantValueOpt    }
    public  LabelSymbol Label { get; }public  BoundExpression ExpressionOpt { get; }public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitSwitchLabel(this)
    public BoundSwitchLabel Update(LabelSymbol label, BoundExpression expressionOpt, ConstantValue constantValueOpt)
    {
      if ()
      {
        (this.Syntax, Label, ExpressionOpt, ConstantValueOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundBreakStatement{
    public BoundBreakStatement(SyntaxNode syntax, GeneratedLabelSymbol label, bool hasErrors)
    BoundKind.BreakStatement, syntax, hasErrors{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label    }
    public BoundBreakStatement(SyntaxNode syntax, GeneratedLabelSymbol label)
    BoundKind.BreakStatement, syntax{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label;
    }
    public  GeneratedLabelSymbol Label { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitBreakStatement(this)
    public BoundBreakStatement Update(GeneratedLabelSymbol label)
    {
      if ()
      {
        (this.Syntax, Label, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundContinueStatement{
    public BoundContinueStatement(SyntaxNode syntax, GeneratedLabelSymbol label, bool hasErrors)
    BoundKind.ContinueStatement, syntax, hasErrors{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label    }
    public BoundContinueStatement(SyntaxNode syntax, GeneratedLabelSymbol label)
    BoundKind.ContinueStatement, syntax{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label;
    }
    public  GeneratedLabelSymbol Label { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitContinueStatement(this)
    public BoundContinueStatement Update(GeneratedLabelSymbol label)
    {
      if ()
      {
        (this.Syntax, Label, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPatternSwitchStatement{
    public BoundPatternSwitchStatement(SyntaxNode syntax, BoundExpression expression, bool someLabelAlwaysMatches, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundPatternSwitchSection> switchSections, BoundPatternSwitchLabel defaultLabel, GeneratedLabelSymbol breakLabel, PatternSwitchBinder binder, bool isComplete,  bool hasErrors = false)
    BoundKind.PatternSwitchStatement, syntax, hasErrors || expression.HasErrors() || switchSections.HasErrors() || defaultLabel.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!innerLocals.IsDefault, "Field 'innerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!innerLocalFunctions.IsDefault, "Field 'innerLocalFunctions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!switchSections.IsDefault, "Field 'switchSections' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(binder != null, "Field 'binder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expressionthis.SomeLabelAlwaysMatches = someLabelAlwaysMatchesthis.InnerLocals = innerLocalsthis.InnerLocalFunctions = innerLocalFunctionsthis.SwitchSections = switchSectionsthis.DefaultLabel = defaultLabelthis.BreakLabel = breakLabelthis.Binder = binderthis.IsComplete = isComplete    }
    public  BoundExpression Expression { get; }public  bool SomeLabelAlwaysMatches { get; }public  ImmutableArray<LocalSymbol> InnerLocals { get; }public  ImmutableArray<LocalFunctionSymbol> InnerLocalFunctions { get; }public  ImmutableArray<BoundPatternSwitchSection> SwitchSections { get; }public  BoundPatternSwitchLabel DefaultLabel { get; }public  GeneratedLabelSymbol BreakLabel { get; }public  PatternSwitchBinder Binder { get; }public  bool IsComplete { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPatternSwitchStatement(this)
    public BoundPatternSwitchStatement Update(BoundExpression expression, bool someLabelAlwaysMatches, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundPatternSwitchSection> switchSections, BoundPatternSwitchLabel defaultLabel, GeneratedLabelSymbol breakLabel, PatternSwitchBinder binder, bool isComplete)
    {
      if ()
      {
        (this.Syntax, Expression, SomeLabelAlwaysMatches, InnerLocals, InnerLocalFunctions, SwitchSections, DefaultLabel, BreakLabel, Binder, IsComplete, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPatternSwitchSection{
    public BoundPatternSwitchSection(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundPatternSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    BoundKind.PatternSwitchSection, syntax, statements, hasErrors || switchLabels.HasErrors() || statements.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!switchLabels.IsDefault, "Field 'switchLabels' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.SwitchLabels = switchLabels    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  ImmutableArray<BoundPatternSwitchLabel> SwitchLabels { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPatternSwitchSection(this)
    public BoundPatternSwitchSection Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundPatternSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements)
    {
      if ()
      {
        (this.Syntax, Locals, SwitchLabels, Statements, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPatternSwitchLabel{
    public BoundPatternSwitchLabel(SyntaxNode syntax, LabelSymbol label, BoundPattern pattern, BoundExpression guard, bool isReachable,  bool hasErrors = false)
    BoundKind.PatternSwitchLabel, syntax, hasErrors || pattern.HasErrors() || guard.HasErrors(){
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(pattern != null, "Field 'pattern' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = labelthis.Pattern = patternthis.Guard = guardthis.IsReachable = isReachable    }
    public  LabelSymbol Label { get; }public  BoundPattern Pattern { get; }public  BoundExpression Guard { get; }public  bool IsReachable { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPatternSwitchLabel(this)
    public BoundPatternSwitchLabel Update(LabelSymbol label, BoundPattern pattern, BoundExpression guard, bool isReachable)
    {
      if ()
      {
        (this.Syntax, Label, Pattern, Guard, IsReachable, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundIfStatement{
    public BoundIfStatement(SyntaxNode syntax, BoundExpression condition, BoundStatement consequence, BoundStatement alternativeOpt,  bool hasErrors = false)
    BoundKind.IfStatement, syntax, hasErrors || condition.HasErrors() || consequence.HasErrors() || alternativeOpt.HasErrors(){
      Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(consequence != null, "Field 'consequence' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Condition = conditionthis.Consequence = consequencethis.AlternativeOpt = alternativeOpt    }
    public  BoundExpression Condition { get; }public  BoundStatement Consequence { get; }public  BoundStatement AlternativeOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitIfStatement(this)
    public BoundIfStatement Update(BoundExpression condition, BoundStatement consequence, BoundStatement alternativeOpt)
    {
      if ()
      {
        (this.Syntax, Condition, Consequence, AlternativeOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundLoopStatement{
    protected BoundLoopStatement(BoundKind kind, SyntaxNode syntax, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel, bool hasErrors)
    kind, syntax, hasErrors{
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.BreakLabel = breakLabelthis.ContinueLabel = continueLabel    }
    protected BoundLoopStatement(BoundKind kind, SyntaxNode syntax, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
    kind, syntax{
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.BreakLabel = breakLabel;
      this.ContinueLabel = continueLabel;
    }
    public  GeneratedLabelSymbol BreakLabel { get; }public  GeneratedLabelSymbol ContinueLabel { get; }  }internal sealed partial class BoundDoStatement{
    public BoundDoStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false)
    BoundKind.DoStatement, syntax, breakLabel, continueLabel, hasErrors || condition.HasErrors() || body.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.Condition = conditionthis.Body = body    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundExpression Condition { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDoStatement(this)
    public BoundDoStatement Update(ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
    {
      if ()
      {
        (this.Syntax, Locals, Condition, Body, BreakLabel, ContinueLabel, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundWhileStatement{
    public BoundWhileStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false)
    BoundKind.WhileStatement, syntax, breakLabel, continueLabel, hasErrors || condition.HasErrors() || body.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.Condition = conditionthis.Body = body    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundExpression Condition { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitWhileStatement(this)
    public BoundWhileStatement Update(ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
    {
      if ()
      {
        (this.Syntax, Locals, Condition, Body, BreakLabel, ContinueLabel, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundForStatement{
    public BoundForStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> outerLocals, BoundStatement initializer, ImmutableArray<LocalSymbol> innerLocals, BoundExpression condition, BoundStatement increment, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false)
    BoundKind.ForStatement, syntax, breakLabel, continueLabel, hasErrors || initializer.HasErrors() || condition.HasErrors() || increment.HasErrors() || body.HasErrors(){
      Debug.Assert(!outerLocals.IsDefault, "Field 'outerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!innerLocals.IsDefault, "Field 'innerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.OuterLocals = outerLocalsthis.Initializer = initializerthis.InnerLocals = innerLocalsthis.Condition = conditionthis.Increment = incrementthis.Body = body    }
    public  ImmutableArray<LocalSymbol> OuterLocals { get; }public  BoundStatement Initializer { get; }public  ImmutableArray<LocalSymbol> InnerLocals { get; }public  BoundExpression Condition { get; }public  BoundStatement Increment { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitForStatement(this)
    public BoundForStatement Update(ImmutableArray<LocalSymbol> outerLocals, BoundStatement initializer, ImmutableArray<LocalSymbol> innerLocals, BoundExpression condition, BoundStatement increment, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
    {
      if ()
      {
        (this.Syntax, OuterLocals, Initializer, InnerLocals, Condition, Increment, Body, BreakLabel, ContinueLabel, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundForEachStatement{
    public BoundForEachStatement(SyntaxNode syntax, ForEachEnumeratorInfo enumeratorInfoOpt, Conversion elementConversion, BoundTypeExpression iterationVariableType, ImmutableArray<LocalSymbol> iterationVariables, BoundExpression iterationErrorExpressionOpt, BoundExpression expression, BoundForEachDeconstructStep deconstructionOpt, BoundStatement body, bool @checked, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false)
    BoundKind.ForEachStatement, syntax, breakLabel, continueLabel, hasErrors || iterationVariableType.HasErrors() || iterationErrorExpressionOpt.HasErrors() || expression.HasErrors() || deconstructionOpt.HasErrors() || body.HasErrors(){
      Debug.Assert(iterationVariableType != null, "Field 'iterationVariableType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!iterationVariables.IsDefault, "Field 'iterationVariables' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.EnumeratorInfoOpt = enumeratorInfoOptthis.ElementConversion = elementConversionthis.IterationVariableType = iterationVariableTypethis.IterationVariables = iterationVariablesthis.IterationErrorExpressionOpt = iterationErrorExpressionOptthis.Expression = expressionthis.DeconstructionOpt = deconstructionOptthis.Body = bodythis.Checked = @checked    }
    public  ForEachEnumeratorInfo EnumeratorInfoOpt { get; }public  Conversion ElementConversion { get; }public  BoundTypeExpression IterationVariableType { get; }public  ImmutableArray<LocalSymbol> IterationVariables { get; }public  BoundExpression IterationErrorExpressionOpt { get; }public  BoundExpression Expression { get; }public  BoundForEachDeconstructStep DeconstructionOpt { get; }public  BoundStatement Body { get; }public  bool Checked { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitForEachStatement(this)
    public BoundForEachStatement Update(ForEachEnumeratorInfo enumeratorInfoOpt, Conversion elementConversion, BoundTypeExpression iterationVariableType, ImmutableArray<LocalSymbol> iterationVariables, BoundExpression iterationErrorExpressionOpt, BoundExpression expression, BoundForEachDeconstructStep deconstructionOpt, BoundStatement body, bool @checked, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
    {
      if ()
      {
        (this.Syntax, EnumeratorInfoOpt, ElementConversion, IterationVariableType, IterationVariables, IterationErrorExpressionOpt, Expression, DeconstructionOpt, Body, Checked, BreakLabel, ContinueLabel, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundForEachDeconstructStep{
    public BoundForEachDeconstructStep(SyntaxNode syntax, BoundDeconstructionAssignmentOperator deconstructionAssignment, BoundDeconstructValuePlaceholder targetPlaceholder,  bool hasErrors = false)
    BoundKind.ForEachDeconstructStep, syntax, hasErrors || deconstructionAssignment.HasErrors() || targetPlaceholder.HasErrors(){
      Debug.Assert(deconstructionAssignment != null, "Field 'deconstructionAssignment' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(targetPlaceholder != null, "Field 'targetPlaceholder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.DeconstructionAssignment = deconstructionAssignmentthis.TargetPlaceholder = targetPlaceholder    }
    public  BoundDeconstructionAssignmentOperator DeconstructionAssignment { get; }public  BoundDeconstructValuePlaceholder TargetPlaceholder { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitForEachDeconstructStep(this)
    public BoundForEachDeconstructStep Update(BoundDeconstructionAssignmentOperator deconstructionAssignment, BoundDeconstructValuePlaceholder targetPlaceholder)
    {
      if ()
      {
        (this.Syntax, DeconstructionAssignment, TargetPlaceholder, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundUsingStatement{
    public BoundUsingStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarationsOpt, BoundExpression expressionOpt, Conversion iDisposableConversion, BoundStatement body,  bool hasErrors = false)
    BoundKind.UsingStatement, syntax, hasErrors || declarationsOpt.HasErrors() || expressionOpt.HasErrors() || body.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.DeclarationsOpt = declarationsOptthis.ExpressionOpt = expressionOptthis.IDisposableConversion = iDisposableConversionthis.Body = body    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundMultipleLocalDeclarations DeclarationsOpt { get; }public  BoundExpression ExpressionOpt { get; }public  Conversion IDisposableConversion { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitUsingStatement(this)
    public BoundUsingStatement Update(ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarationsOpt, BoundExpression expressionOpt, Conversion iDisposableConversion, BoundStatement body)
    {
      if ()
      {
        (this.Syntax, Locals, DeclarationsOpt, ExpressionOpt, IDisposableConversion, Body, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundFixedStatement{
    public BoundFixedStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarations, BoundStatement body,  bool hasErrors = false)
    BoundKind.FixedStatement, syntax, hasErrors || declarations.HasErrors() || body.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(declarations != null, "Field 'declarations' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.Declarations = declarationsthis.Body = body    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundMultipleLocalDeclarations Declarations { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitFixedStatement(this)
    public BoundFixedStatement Update(ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarations, BoundStatement body)
    {
      if ()
      {
        (this.Syntax, Locals, Declarations, Body, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLockStatement{
    public BoundLockStatement(SyntaxNode syntax, BoundExpression argument, BoundStatement body,  bool hasErrors = false)
    BoundKind.LockStatement, syntax, hasErrors || argument.HasErrors() || body.HasErrors(){
      Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Argument = argumentthis.Body = body    }
    public  BoundExpression Argument { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLockStatement(this)
    public BoundLockStatement Update(BoundExpression argument, BoundStatement body)
    {
      if ()
      {
        (this.Syntax, Argument, Body, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundTryStatement{
    public BoundTryStatement(SyntaxNode syntax, BoundBlock tryBlock, ImmutableArray<BoundCatchBlock> catchBlocks, BoundBlock finallyBlockOpt, bool preferFaultHandler,  bool hasErrors = false)
    BoundKind.TryStatement, syntax, hasErrors || tryBlock.HasErrors() || catchBlocks.HasErrors() || finallyBlockOpt.HasErrors(){
      Debug.Assert(tryBlock != null, "Field 'tryBlock' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!catchBlocks.IsDefault, "Field 'catchBlocks' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.TryBlock = tryBlockthis.CatchBlocks = catchBlocksthis.FinallyBlockOpt = finallyBlockOptthis.PreferFaultHandler = preferFaultHandler    }
    public  BoundBlock TryBlock { get; }public  ImmutableArray<BoundCatchBlock> CatchBlocks { get; }public  BoundBlock FinallyBlockOpt { get; }public  bool PreferFaultHandler { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTryStatement(this)
    public BoundTryStatement Update(BoundBlock tryBlock, ImmutableArray<BoundCatchBlock> catchBlocks, BoundBlock finallyBlockOpt, bool preferFaultHandler)
    {
      if ()
      {
        (this.Syntax, TryBlock, CatchBlocks, FinallyBlockOpt, PreferFaultHandler, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundCatchBlock{
    public BoundCatchBlock(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression exceptionSourceOpt, TypeSymbol exceptionTypeOpt, BoundExpression exceptionFilterOpt, BoundBlock body, bool isSynthesizedAsyncCatchAll,  bool hasErrors = false)
    BoundKind.CatchBlock, syntax, hasErrors || exceptionSourceOpt.HasErrors() || exceptionFilterOpt.HasErrors() || body.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.ExceptionSourceOpt = exceptionSourceOptthis.ExceptionTypeOpt = exceptionTypeOptthis.ExceptionFilterOpt = exceptionFilterOptthis.Body = bodythis.IsSynthesizedAsyncCatchAll = isSynthesizedAsyncCatchAll    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundExpression ExceptionSourceOpt { get; }public  TypeSymbol ExceptionTypeOpt { get; }public  BoundExpression ExceptionFilterOpt { get; }public  BoundBlock Body { get; }public  bool IsSynthesizedAsyncCatchAll { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitCatchBlock(this)
    public BoundCatchBlock Update(ImmutableArray<LocalSymbol> locals, BoundExpression exceptionSourceOpt, TypeSymbol exceptionTypeOpt, BoundExpression exceptionFilterOpt, BoundBlock body, bool isSynthesizedAsyncCatchAll)
    {
      if ()
      {
        (this.Syntax, Locals, ExceptionSourceOpt, ExceptionTypeOpt, ExceptionFilterOpt, Body, IsSynthesizedAsyncCatchAll, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLiteral{
    public BoundLiteral(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type, bool hasErrors)
    BoundKind.Literal, syntax, type, hasErrors{
      this.ConstantValueOpt = constantValueOpt    }
    public BoundLiteral(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type)
    BoundKind.Literal, syntax, type{
      this.ConstantValueOpt = constantValueOpt;
    }
    public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLiteral(this)
    public BoundLiteral Update(ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundThisReference{
    public BoundThisReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.ThisReference, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundThisReference(SyntaxNode syntax, TypeSymbol type)
    BoundKind.ThisReference, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitThisReference(this)
    public BoundThisReference Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPreviousSubmissionReference{
    public BoundPreviousSubmissionReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.PreviousSubmissionReference, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundPreviousSubmissionReference(SyntaxNode syntax, TypeSymbol type)
    BoundKind.PreviousSubmissionReference, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPreviousSubmissionReference(this)
    public BoundPreviousSubmissionReference Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundHostObjectMemberReference{
    public BoundHostObjectMemberReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.HostObjectMemberReference, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundHostObjectMemberReference(SyntaxNode syntax, TypeSymbol type)
    BoundKind.HostObjectMemberReference, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitHostObjectMemberReference(this)
    public BoundHostObjectMemberReference Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundBaseReference{
    public BoundBaseReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.BaseReference, syntax, type, hasErrors{
    }
    public BoundBaseReference(SyntaxNode syntax, TypeSymbol type)
    BoundKind.BaseReference, syntax, type{
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitBaseReference(this)
    public BoundBaseReference Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLocal{
    public BoundLocal(SyntaxNode syntax, LocalSymbol localSymbol, bool isDeclaration, ConstantValue constantValueOpt, TypeSymbol type, bool hasErrors)
    BoundKind.Local, syntax, type, hasErrors{
      Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LocalSymbol = localSymbolthis.IsDeclaration = isDeclarationthis.ConstantValueOpt = constantValueOpt    }
    public BoundLocal(SyntaxNode syntax, LocalSymbol localSymbol, bool isDeclaration, ConstantValue constantValueOpt, TypeSymbol type)
    BoundKind.Local, syntax, type{
      Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LocalSymbol = localSymbol;
      this.IsDeclaration = isDeclaration;
      this.ConstantValueOpt = constantValueOpt;
    }
    public  LocalSymbol LocalSymbol { get; }public  bool IsDeclaration { get; }public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLocal(this)
    public BoundLocal Update(LocalSymbol localSymbol, bool isDeclaration, ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, LocalSymbol, IsDeclaration, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPseudoVariable{
    public BoundPseudoVariable(SyntaxNode syntax, LocalSymbol localSymbol, PseudoVariableExpressions emitExpressions, TypeSymbol type, bool hasErrors)
    BoundKind.PseudoVariable, syntax, type, hasErrors{
      Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(emitExpressions != null, "Field 'emitExpressions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LocalSymbol = localSymbolthis.EmitExpressions = emitExpressions    }
    public BoundPseudoVariable(SyntaxNode syntax, LocalSymbol localSymbol, PseudoVariableExpressions emitExpressions, TypeSymbol type)
    BoundKind.PseudoVariable, syntax, type{
      Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(emitExpressions != null, "Field 'emitExpressions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.LocalSymbol = localSymbol;
      this.EmitExpressions = emitExpressions;
    }
    public  LocalSymbol LocalSymbol { get; }public  PseudoVariableExpressions EmitExpressions { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPseudoVariable(this)
    public BoundPseudoVariable Update(LocalSymbol localSymbol, PseudoVariableExpressions emitExpressions, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, LocalSymbol, EmitExpressions, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundRangeVariable{
    public BoundRangeVariable(SyntaxNode syntax, RangeVariableSymbol rangeVariableSymbol, BoundExpression value, TypeSymbol type,  bool hasErrors = false)
    BoundKind.RangeVariable, syntax, type, hasErrors || value.HasErrors(){
      Debug.Assert(rangeVariableSymbol != null, "Field 'rangeVariableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.RangeVariableSymbol = rangeVariableSymbolthis.Value = value    }
    public  RangeVariableSymbol RangeVariableSymbol { get; }public  BoundExpression Value { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitRangeVariable(this)
    public BoundRangeVariable Update(RangeVariableSymbol rangeVariableSymbol, BoundExpression value, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, RangeVariableSymbol, Value, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundParameter{
    public BoundParameter(SyntaxNode syntax, ParameterSymbol parameterSymbol, TypeSymbol type, bool hasErrors)
    BoundKind.Parameter, syntax, type, hasErrors{
      Debug.Assert(parameterSymbol != null, "Field 'parameterSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ParameterSymbol = parameterSymbol    }
    public BoundParameter(SyntaxNode syntax, ParameterSymbol parameterSymbol, TypeSymbol type)
    BoundKind.Parameter, syntax, type{
      Debug.Assert(parameterSymbol != null, "Field 'parameterSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ParameterSymbol = parameterSymbol;
    }
    public  ParameterSymbol ParameterSymbol { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitParameter(this)
    public BoundParameter Update(ParameterSymbol parameterSymbol, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ParameterSymbol, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLabelStatement{
    public BoundLabelStatement(SyntaxNode syntax, LabelSymbol label, bool hasErrors)
    BoundKind.LabelStatement, syntax, hasErrors{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label    }
    public BoundLabelStatement(SyntaxNode syntax, LabelSymbol label)
    BoundKind.LabelStatement, syntax{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label;
    }
    public  LabelSymbol Label { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLabelStatement(this)
    public BoundLabelStatement Update(LabelSymbol label)
    {
      if ()
      {
        (this.Syntax, Label, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundGotoStatement{
    public BoundGotoStatement(SyntaxNode syntax, LabelSymbol label, BoundExpression caseExpressionOpt, BoundLabel labelExpressionOpt,  bool hasErrors = false)
    BoundKind.GotoStatement, syntax, hasErrors || caseExpressionOpt.HasErrors() || labelExpressionOpt.HasErrors(){
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = labelthis.CaseExpressionOpt = caseExpressionOptthis.LabelExpressionOpt = labelExpressionOpt    }
    public  LabelSymbol Label { get; }public  BoundExpression CaseExpressionOpt { get; }public  BoundLabel LabelExpressionOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitGotoStatement(this)
    public BoundGotoStatement Update(LabelSymbol label, BoundExpression caseExpressionOpt, BoundLabel labelExpressionOpt)
    {
      if ()
      {
        (this.Syntax, Label, CaseExpressionOpt, LabelExpressionOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLabeledStatement{
    public BoundLabeledStatement(SyntaxNode syntax, LabelSymbol label, BoundStatement body,  bool hasErrors = false)
    BoundKind.LabeledStatement, syntax, hasErrors || body.HasErrors(){
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = labelthis.Body = body    }
    public  LabelSymbol Label { get; }public  BoundStatement Body { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLabeledStatement(this)
    public BoundLabeledStatement Update(LabelSymbol label, BoundStatement body)
    {
      if ()
      {
        (this.Syntax, Label, Body, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLabel{
    public BoundLabel(SyntaxNode syntax, LabelSymbol label, TypeSymbol type, bool hasErrors)
    BoundKind.Label, syntax, type, hasErrors{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label    }
    public BoundLabel(SyntaxNode syntax, LabelSymbol label, TypeSymbol type)
    BoundKind.Label, syntax, type{
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Label = label;
    }
    public  LabelSymbol Label { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLabel(this)
    public BoundLabel Update(LabelSymbol label, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Label, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal partial class BoundStatementList{
    protected BoundStatementList(BoundKind kind, SyntaxNode syntax, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    kind, syntax, hasErrors{
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Statements = statements    }
    public BoundStatementList(SyntaxNode syntax, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    BoundKind.StatementList, syntax, hasErrors || statements.HasErrors(){
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Statements = statements    }
    public  ImmutableArray<BoundStatement> Statements { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitStatementList(this)
    public BoundStatementList Update(ImmutableArray<BoundStatement> statements)
    {
      if ()
      {
        (this.Syntax, Statements, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConditionalGoto{
    public BoundConditionalGoto(SyntaxNode syntax, BoundExpression condition, bool jumpIfTrue, LabelSymbol label,  bool hasErrors = false)
    BoundKind.ConditionalGoto, syntax, hasErrors || condition.HasErrors(){
      Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Condition = conditionthis.JumpIfTrue = jumpIfTruethis.Label = label    }
    public  BoundExpression Condition { get; }public  bool JumpIfTrue { get; }public  LabelSymbol Label { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConditionalGoto(this)
    public BoundConditionalGoto Update(BoundExpression condition, bool jumpIfTrue, LabelSymbol label)
    {
      if ()
      {
        (this.Syntax, Condition, JumpIfTrue, Label, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundMethodOrPropertyGroup{
    protected BoundMethodOrPropertyGroup(BoundKind kind, SyntaxNode syntax, BoundExpression receiverOpt, LookupResultKind resultKind,  bool hasErrors = false)
    kind, syntax, null, hasErrors{
      this.ReceiverOpt = receiverOptthis.ResultKind = resultKind    }
    public  BoundExpression ReceiverOpt { get; }public override LookupResultKind ResultKind { get; }  }internal sealed partial class BoundDynamicMemberAccess{
    public BoundDynamicMemberAccess(SyntaxNode syntax, BoundExpression receiver, ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, bool invoked, bool indexed, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DynamicMemberAccess, syntax, type, hasErrors || receiver.HasErrors(){
      Debug.Assert(receiver != null, "Field 'receiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(name != null, "Field 'name' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Receiver = receiverthis.TypeArgumentsOpt = typeArgumentsOptthis.Name = namethis.Invoked = invokedthis.Indexed = indexed    }
    public  BoundExpression Receiver { get; }public  ImmutableArray<TypeSymbol> TypeArgumentsOpt { get; }public  string Name { get; }public  bool Invoked { get; }public  bool Indexed { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDynamicMemberAccess(this)
    public BoundDynamicMemberAccess Update(BoundExpression receiver, ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, bool invoked, bool indexed, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Receiver, TypeArgumentsOpt, Name, Invoked, Indexed, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDynamicInvocation{
    public BoundDynamicInvocation(SyntaxNode syntax, BoundExpression expression, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DynamicInvocation, syntax, type, hasErrors || expression.HasErrors() || arguments.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!applicableMethods.IsDefault, "Field 'applicableMethods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expressionthis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.ApplicableMethods = applicableMethods    }
    public  BoundExpression Expression { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  ImmutableArray<MethodSymbol> ApplicableMethods { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDynamicInvocation(this)
    public BoundDynamicInvocation Update(BoundExpression expression, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, ApplicableMethods, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConditionalAccess{
    public BoundConditionalAccess(SyntaxNode syntax, BoundExpression receiver, BoundExpression accessExpression, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ConditionalAccess, syntax, type, hasErrors || receiver.HasErrors() || accessExpression.HasErrors(){
      Debug.Assert(receiver != null, "Field 'receiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(accessExpression != null, "Field 'accessExpression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Receiver = receiverthis.AccessExpression = accessExpression    }
    public  BoundExpression Receiver { get; }public  BoundExpression AccessExpression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConditionalAccess(this)
    public BoundConditionalAccess Update(BoundExpression receiver, BoundExpression accessExpression, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Receiver, AccessExpression, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLoweredConditionalAccess{
    public BoundLoweredConditionalAccess(SyntaxNode syntax, BoundExpression receiver, MethodSymbol hasValueMethodOpt, BoundExpression whenNotNull, BoundExpression whenNullOpt, int id, TypeSymbol type,  bool hasErrors = false)
    BoundKind.LoweredConditionalAccess, syntax, type, hasErrors || receiver.HasErrors() || whenNotNull.HasErrors() || whenNullOpt.HasErrors(){
      Debug.Assert(receiver != null, "Field 'receiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(whenNotNull != null, "Field 'whenNotNull' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Receiver = receiverthis.HasValueMethodOpt = hasValueMethodOptthis.WhenNotNull = whenNotNullthis.WhenNullOpt = whenNullOptthis.Id = id    }
    public  BoundExpression Receiver { get; }public  MethodSymbol HasValueMethodOpt { get; }public  BoundExpression WhenNotNull { get; }public  BoundExpression WhenNullOpt { get; }public  int Id { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLoweredConditionalAccess(this)
    public BoundLoweredConditionalAccess Update(BoundExpression receiver, MethodSymbol hasValueMethodOpt, BoundExpression whenNotNull, BoundExpression whenNullOpt, int id, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Receiver, HasValueMethodOpt, WhenNotNull, WhenNullOpt, Id, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConditionalReceiver{
    public BoundConditionalReceiver(SyntaxNode syntax, int id, TypeSymbol type, bool hasErrors)
    BoundKind.ConditionalReceiver, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Id = id    }
    public BoundConditionalReceiver(SyntaxNode syntax, int id, TypeSymbol type)
    BoundKind.ConditionalReceiver, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Id = id;
    }
    public  int Id { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConditionalReceiver(this)
    public BoundConditionalReceiver Update(int id, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Id, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundComplexConditionalReceiver{
    public BoundComplexConditionalReceiver(SyntaxNode syntax, BoundExpression valueTypeReceiver, BoundExpression referenceTypeReceiver, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ComplexConditionalReceiver, syntax, type, hasErrors || valueTypeReceiver.HasErrors() || referenceTypeReceiver.HasErrors(){
      Debug.Assert(valueTypeReceiver != null, "Field 'valueTypeReceiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(referenceTypeReceiver != null, "Field 'referenceTypeReceiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ValueTypeReceiver = valueTypeReceiverthis.ReferenceTypeReceiver = referenceTypeReceiver    }
    public  BoundExpression ValueTypeReceiver { get; }public  BoundExpression ReferenceTypeReceiver { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitComplexConditionalReceiver(this)
    public BoundComplexConditionalReceiver Update(BoundExpression valueTypeReceiver, BoundExpression referenceTypeReceiver, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ValueTypeReceiver, ReferenceTypeReceiver, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundMethodGroup{
    public BoundMethodGroup(SyntaxNode syntax, ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, ImmutableArray<MethodSymbol> methods, Symbol lookupSymbolOpt, DiagnosticInfo lookupError, BoundMethodGroupFlags flags, BoundExpression receiverOpt, LookupResultKind resultKind,  bool hasErrors = false)
    BoundKind.MethodGroup, syntax, receiverOpt, resultKind, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(name != null, "Field 'name' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!methods.IsDefault, "Field 'methods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.TypeArgumentsOpt = typeArgumentsOptthis.Name = namethis.Methods = methodsthis.LookupSymbolOpt = lookupSymbolOptthis.LookupError = lookupErrorthis.Flags = flags    }
    public  ImmutableArray<TypeSymbol> TypeArgumentsOpt { get; }public  string Name { get; }public  ImmutableArray<MethodSymbol> Methods { get; }public  Symbol LookupSymbolOpt { get; }public  DiagnosticInfo LookupError { get; }public  BoundMethodGroupFlags Flags { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitMethodGroup(this)
    public BoundMethodGroup Update(ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, ImmutableArray<MethodSymbol> methods, Symbol lookupSymbolOpt, DiagnosticInfo lookupError, BoundMethodGroupFlags flags, BoundExpression receiverOpt, LookupResultKind resultKind)
    {
      if ()
      {
        (this.Syntax, TypeArgumentsOpt, Name, Methods, LookupSymbolOpt, LookupError, Flags, ReceiverOpt, ResultKind, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPropertyGroup{
    public BoundPropertyGroup(SyntaxNode syntax, ImmutableArray<PropertySymbol> properties, BoundExpression receiverOpt, LookupResultKind resultKind,  bool hasErrors = false)
    BoundKind.PropertyGroup, syntax, receiverOpt, resultKind, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(!properties.IsDefault, "Field 'properties' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Properties = properties    }
    public  ImmutableArray<PropertySymbol> Properties { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPropertyGroup(this)
    public BoundPropertyGroup Update(ImmutableArray<PropertySymbol> properties, BoundExpression receiverOpt, LookupResultKind resultKind)
    {
      if ()
      {
        (this.Syntax, Properties, ReceiverOpt, ResultKind, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundCall{
    public BoundCall(SyntaxNode syntax, BoundExpression receiverOpt, MethodSymbol method, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool isDelegateCall, bool expanded, bool invokedAsExtensionMethod, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.Call, syntax, type, hasErrors || receiverOpt.HasErrors() || arguments.HasErrors(){
      Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ReceiverOpt = receiverOptthis.Method = methodthis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.IsDelegateCall = isDelegateCallthis.Expanded = expandedthis.InvokedAsExtensionMethod = invokedAsExtensionMethodthis.ArgsToParamsOpt = argsToParamsOptthis.ResultKind = resultKindthis.BinderOpt = binderOpt    }
    public  BoundExpression ReceiverOpt { get; }public  MethodSymbol Method { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  bool IsDelegateCall { get; }public  bool Expanded { get; }public  bool InvokedAsExtensionMethod { get; }public  ImmutableArray<int> ArgsToParamsOpt { get; }public override LookupResultKind ResultKind { get; }public  Binder BinderOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitCall(this)
    public BoundCall Update(BoundExpression receiverOpt, MethodSymbol method, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool isDelegateCall, bool expanded, bool invokedAsExtensionMethod, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ReceiverOpt, Method, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, IsDelegateCall, Expanded, InvokedAsExtensionMethod, ArgsToParamsOpt, ResultKind, BinderOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundEventAssignmentOperator{
    public BoundEventAssignmentOperator(SyntaxNode syntax, EventSymbol @event, bool isAddition, bool isDynamic, BoundExpression receiverOpt, BoundExpression argument, TypeSymbol type,  bool hasErrors = false)
    BoundKind.EventAssignmentOperator, syntax, type, hasErrors || receiverOpt.HasErrors() || argument.HasErrors(){
      Debug.Assert(@event != null, "Field '@event' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Event = @eventthis.IsAddition = isAdditionthis.IsDynamic = isDynamicthis.ReceiverOpt = receiverOptthis.Argument = argument    }
    public  EventSymbol Event { get; }public  bool IsAddition { get; }public  bool IsDynamic { get; }public  BoundExpression ReceiverOpt { get; }public  BoundExpression Argument { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitEventAssignmentOperator(this)
    public BoundEventAssignmentOperator Update(EventSymbol @event, bool isAddition, bool isDynamic, BoundExpression receiverOpt, BoundExpression argument, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Event, IsAddition, IsDynamic, ReceiverOpt, Argument, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAttribute{
    public BoundAttribute(SyntaxNode syntax, MethodSymbol constructor, ImmutableArray<BoundExpression> constructorArguments, ImmutableArray<string> constructorArgumentNamesOpt, ImmutableArray<BoundExpression> namedArguments, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.Attribute, syntax, type, hasErrors || constructorArguments.HasErrors() || namedArguments.HasErrors(){
      Debug.Assert(!constructorArguments.IsDefault, "Field 'constructorArguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!namedArguments.IsDefault, "Field 'namedArguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Constructor = constructorthis.ConstructorArguments = constructorArgumentsthis.ConstructorArgumentNamesOpt = constructorArgumentNamesOptthis.NamedArguments = namedArgumentsthis.ResultKind = resultKind    }
    public  MethodSymbol Constructor { get; }public  ImmutableArray<BoundExpression> ConstructorArguments { get; }public  ImmutableArray<string> ConstructorArgumentNamesOpt { get; }public  ImmutableArray<BoundExpression> NamedArguments { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAttribute(this)
    public BoundAttribute Update(MethodSymbol constructor, ImmutableArray<BoundExpression> constructorArguments, ImmutableArray<string> constructorArgumentNamesOpt, ImmutableArray<BoundExpression> namedArguments, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Constructor, ConstructorArguments, ConstructorArgumentNamesOpt, NamedArguments, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundObjectCreationExpression{
    public BoundObjectCreationExpression(SyntaxNode syntax, MethodSymbol constructor, ImmutableArray<MethodSymbol> constructorsGroup, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, ConstantValue constantValueOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, Binder binderOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ObjectCreationExpression, syntax, type, hasErrors || arguments.HasErrors() || initializerExpressionOpt.HasErrors(){
      Debug.Assert(constructor != null, "Field 'constructor' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!constructorsGroup.IsDefault, "Field 'constructorsGroup' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Constructor = constructorthis.ConstructorsGroup = constructorsGroupthis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.Expanded = expandedthis.ArgsToParamsOpt = argsToParamsOptthis.ConstantValueOpt = constantValueOptthis.InitializerExpressionOpt = initializerExpressionOptthis.BinderOpt = binderOpt    }
    public  MethodSymbol Constructor { get; }public  ImmutableArray<MethodSymbol> ConstructorsGroup { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  bool Expanded { get; }public  ImmutableArray<int> ArgsToParamsOpt { get; }public  ConstantValue ConstantValueOpt { get; }public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }public  Binder BinderOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitObjectCreationExpression(this)
    public BoundObjectCreationExpression Update(MethodSymbol constructor, ImmutableArray<MethodSymbol> constructorsGroup, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, ConstantValue constantValueOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, Binder binderOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Constructor, ConstructorsGroup, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, Expanded, ArgsToParamsOpt, ConstantValueOpt, InitializerExpressionOpt, BinderOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundTupleExpression{
    protected BoundTupleExpression(BoundKind kind, SyntaxNode syntax, ImmutableArray<BoundExpression> arguments, TypeSymbol type,  bool hasErrors = false)
    kind, syntax, type, hasErrors{
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Arguments = arguments    }
    public  ImmutableArray<BoundExpression> Arguments { get; }  }internal sealed partial class BoundTupleLiteral{
    public BoundTupleLiteral(SyntaxNode syntax, ImmutableArray<string> argumentNamesOpt, ImmutableArray<bool> inferredNamesOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type,  bool hasErrors = false)
    BoundKind.TupleLiteral, syntax, arguments, type, hasErrors || arguments.HasErrors(){
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ArgumentNamesOpt = argumentNamesOptthis.InferredNamesOpt = inferredNamesOpt    }
    public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<bool> InferredNamesOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTupleLiteral(this)
    public BoundTupleLiteral Update(ImmutableArray<string> argumentNamesOpt, ImmutableArray<bool> inferredNamesOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ArgumentNamesOpt, InferredNamesOpt, Arguments, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConvertedTupleLiteral{
    public BoundConvertedTupleLiteral(SyntaxNode syntax, TypeSymbol naturalTypeOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ConvertedTupleLiteral, syntax, arguments, type, hasErrors || arguments.HasErrors(){
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.NaturalTypeOpt = naturalTypeOpt    }
    public  TypeSymbol NaturalTypeOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConvertedTupleLiteral(this)
    public BoundConvertedTupleLiteral Update(TypeSymbol naturalTypeOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, NaturalTypeOpt, Arguments, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDynamicObjectCreationExpression{
    public BoundDynamicObjectCreationExpression(SyntaxNode syntax, string name, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DynamicObjectCreationExpression, syntax, type, hasErrors || arguments.HasErrors() || initializerExpressionOpt.HasErrors(){
      Debug.Assert(name != null, "Field 'name' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!applicableMethods.IsDefault, "Field 'applicableMethods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Name = namethis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.InitializerExpressionOpt = initializerExpressionOptthis.ApplicableMethods = applicableMethods    }
    public  string Name { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }public  ImmutableArray<MethodSymbol> ApplicableMethods { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDynamicObjectCreationExpression(this)
    public BoundDynamicObjectCreationExpression Update(string name, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Name, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, InitializerExpressionOpt, ApplicableMethods, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundNoPiaObjectCreationExpression{
    public BoundNoPiaObjectCreationExpression(SyntaxNode syntax, string guidString, BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.NoPiaObjectCreationExpression, syntax, type, hasErrors || initializerExpressionOpt.HasErrors(){
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.GuidString = guidStringthis.InitializerExpressionOpt = initializerExpressionOpt    }
    public  string GuidString { get; }public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNoPiaObjectCreationExpression(this)
    public BoundNoPiaObjectCreationExpression Update(string guidString, BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, GuidString, InitializerExpressionOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundObjectInitializerExpressionBase{
    protected BoundObjectInitializerExpressionBase(BoundKind kind, SyntaxNode syntax, ImmutableArray<BoundExpression> initializers, TypeSymbol type,  bool hasErrors = false)
    kind, syntax, type, hasErrors{
      Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Initializers = initializers    }
    public  ImmutableArray<BoundExpression> Initializers { get; }  }internal sealed partial class BoundObjectInitializerExpression{
    public BoundObjectInitializerExpression(SyntaxNode syntax, ImmutableArray<BoundExpression> initializers, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ObjectInitializerExpression, syntax, initializers, type, hasErrors || initializers.HasErrors(){
      Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitObjectInitializerExpression(this)
    public BoundObjectInitializerExpression Update(ImmutableArray<BoundExpression> initializers, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Initializers, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundObjectInitializerMember{
    public BoundObjectInitializerMember(SyntaxNode syntax, Symbol memberSymbol, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, TypeSymbol receiverType, Binder binderOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ObjectInitializerMember, syntax, type, hasErrors || arguments.HasErrors(){
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(receiverType != null, "Field 'receiverType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.MemberSymbol = memberSymbolthis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.Expanded = expandedthis.ArgsToParamsOpt = argsToParamsOptthis.ResultKind = resultKindthis.ReceiverType = receiverTypethis.BinderOpt = binderOpt    }
    public  Symbol MemberSymbol { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  bool Expanded { get; }public  ImmutableArray<int> ArgsToParamsOpt { get; }public override LookupResultKind ResultKind { get; }public  TypeSymbol ReceiverType { get; }public  Binder BinderOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitObjectInitializerMember(this)
    public BoundObjectInitializerMember Update(Symbol memberSymbol, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, TypeSymbol receiverType, Binder binderOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, MemberSymbol, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, Expanded, ArgsToParamsOpt, ResultKind, ReceiverType, BinderOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDynamicObjectInitializerMember{
    public BoundDynamicObjectInitializerMember(SyntaxNode syntax, string memberName, TypeSymbol receiverType, TypeSymbol type, bool hasErrors)
    BoundKind.DynamicObjectInitializerMember, syntax, type, hasErrors{
      Debug.Assert(memberName != null, "Field 'memberName' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(receiverType != null, "Field 'receiverType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.MemberName = memberNamethis.ReceiverType = receiverType    }
    public BoundDynamicObjectInitializerMember(SyntaxNode syntax, string memberName, TypeSymbol receiverType, TypeSymbol type)
    BoundKind.DynamicObjectInitializerMember, syntax, type{
      Debug.Assert(memberName != null, "Field 'memberName' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(receiverType != null, "Field 'receiverType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.MemberName = memberName;
      this.ReceiverType = receiverType;
    }
    public  string MemberName { get; }public  TypeSymbol ReceiverType { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDynamicObjectInitializerMember(this)
    public BoundDynamicObjectInitializerMember Update(string memberName, TypeSymbol receiverType, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, MemberName, ReceiverType, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundCollectionInitializerExpression{
    public BoundCollectionInitializerExpression(SyntaxNode syntax, ImmutableArray<BoundExpression> initializers, TypeSymbol type,  bool hasErrors = false)
    BoundKind.CollectionInitializerExpression, syntax, initializers, type, hasErrors || initializers.HasErrors(){
      Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitCollectionInitializerExpression(this)
    public BoundCollectionInitializerExpression Update(ImmutableArray<BoundExpression> initializers, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Initializers, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundCollectionElementInitializer{
    public BoundCollectionElementInitializer(SyntaxNode syntax, MethodSymbol addMethod, ImmutableArray<BoundExpression> arguments, BoundExpression implicitReceiverOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, bool invokedAsExtensionMethod, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.CollectionElementInitializer, syntax, type, hasErrors || arguments.HasErrors() || implicitReceiverOpt.HasErrors(){
      Debug.Assert(addMethod != null, "Field 'addMethod' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.AddMethod = addMethodthis.Arguments = argumentsthis.ImplicitReceiverOpt = implicitReceiverOptthis.Expanded = expandedthis.ArgsToParamsOpt = argsToParamsOptthis.InvokedAsExtensionMethod = invokedAsExtensionMethodthis.ResultKind = resultKindthis.BinderOpt = binderOpt    }
    public  MethodSymbol AddMethod { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  BoundExpression ImplicitReceiverOpt { get; }public  bool Expanded { get; }public  ImmutableArray<int> ArgsToParamsOpt { get; }public  bool InvokedAsExtensionMethod { get; }public override LookupResultKind ResultKind { get; }public  Binder BinderOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitCollectionElementInitializer(this)
    public BoundCollectionElementInitializer Update(MethodSymbol addMethod, ImmutableArray<BoundExpression> arguments, BoundExpression implicitReceiverOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, bool invokedAsExtensionMethod, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, AddMethod, Arguments, ImplicitReceiverOpt, Expanded, ArgsToParamsOpt, InvokedAsExtensionMethod, ResultKind, BinderOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDynamicCollectionElementInitializer{
    public BoundDynamicCollectionElementInitializer(SyntaxNode syntax, ImmutableArray<BoundExpression> arguments, BoundImplicitReceiver implicitReceiver, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DynamicCollectionElementInitializer, syntax, type, hasErrors || arguments.HasErrors() || implicitReceiver.HasErrors(){
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(implicitReceiver != null, "Field 'implicitReceiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!applicableMethods.IsDefault, "Field 'applicableMethods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Arguments = argumentsthis.ImplicitReceiver = implicitReceiverthis.ApplicableMethods = applicableMethods    }
    public  ImmutableArray<BoundExpression> Arguments { get; }public  BoundImplicitReceiver ImplicitReceiver { get; }public  ImmutableArray<MethodSymbol> ApplicableMethods { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDynamicCollectionElementInitializer(this)
    public BoundDynamicCollectionElementInitializer Update(ImmutableArray<BoundExpression> arguments, BoundImplicitReceiver implicitReceiver, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Arguments, ImplicitReceiver, ApplicableMethods, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundImplicitReceiver{
    public BoundImplicitReceiver(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.ImplicitReceiver, syntax, type, hasErrors{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public BoundImplicitReceiver(SyntaxNode syntax, TypeSymbol type)
    BoundKind.ImplicitReceiver, syntax, type{
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitImplicitReceiver(this)
    public BoundImplicitReceiver Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAnonymousObjectCreationExpression{
    public BoundAnonymousObjectCreationExpression(SyntaxNode syntax, MethodSymbol constructor, ImmutableArray<BoundExpression> arguments, ImmutableArray<BoundAnonymousPropertyDeclaration> declarations, TypeSymbol type,  bool hasErrors = false)
    BoundKind.AnonymousObjectCreationExpression, syntax, type, hasErrors || arguments.HasErrors() || declarations.HasErrors(){
      Debug.Assert(constructor != null, "Field 'constructor' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!declarations.IsDefault, "Field 'declarations' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Constructor = constructorthis.Arguments = argumentsthis.Declarations = declarations    }
    public  MethodSymbol Constructor { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<BoundAnonymousPropertyDeclaration> Declarations { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAnonymousObjectCreationExpression(this)
    public BoundAnonymousObjectCreationExpression Update(MethodSymbol constructor, ImmutableArray<BoundExpression> arguments, ImmutableArray<BoundAnonymousPropertyDeclaration> declarations, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Constructor, Arguments, Declarations, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundAnonymousPropertyDeclaration{
    public BoundAnonymousPropertyDeclaration(SyntaxNode syntax, PropertySymbol property, TypeSymbol type, bool hasErrors)
    BoundKind.AnonymousPropertyDeclaration, syntax, type, hasErrors{
      Debug.Assert(property != null, "Field 'property' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Property = property    }
    public BoundAnonymousPropertyDeclaration(SyntaxNode syntax, PropertySymbol property, TypeSymbol type)
    BoundKind.AnonymousPropertyDeclaration, syntax, type{
      Debug.Assert(property != null, "Field 'property' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Property = property;
    }
    public  PropertySymbol Property { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitAnonymousPropertyDeclaration(this)
    public BoundAnonymousPropertyDeclaration Update(PropertySymbol property, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Property, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundNewT{
    public BoundNewT(SyntaxNode syntax, BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.NewT, syntax, type, hasErrors || initializerExpressionOpt.HasErrors(){
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.InitializerExpressionOpt = initializerExpressionOpt    }
    public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNewT(this)
    public BoundNewT Update(BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, InitializerExpressionOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDelegateCreationExpression{
    public BoundDelegateCreationExpression(SyntaxNode syntax, BoundExpression argument, MethodSymbol methodOpt, bool isExtensionMethod, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DelegateCreationExpression, syntax, type, hasErrors || argument.HasErrors(){
      Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Argument = argumentthis.MethodOpt = methodOptthis.IsExtensionMethod = isExtensionMethod    }
    public  BoundExpression Argument { get; }public  MethodSymbol MethodOpt { get; }public  bool IsExtensionMethod { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDelegateCreationExpression(this)
    public BoundDelegateCreationExpression Update(BoundExpression argument, MethodSymbol methodOpt, bool isExtensionMethod, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Argument, MethodOpt, IsExtensionMethod, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundArrayCreation{
    public BoundArrayCreation(SyntaxNode syntax, ImmutableArray<BoundExpression> bounds, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ArrayCreation, syntax, type, hasErrors || bounds.HasErrors() || initializerOpt.HasErrors(){
      Debug.Assert(!bounds.IsDefault, "Field 'bounds' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Bounds = boundsthis.InitializerOpt = initializerOpt    }
    public  ImmutableArray<BoundExpression> Bounds { get; }public  BoundArrayInitialization InitializerOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitArrayCreation(this)
    public BoundArrayCreation Update(ImmutableArray<BoundExpression> bounds, BoundArrayInitialization initializerOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Bounds, InitializerOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundArrayInitialization{
    public BoundArrayInitialization(SyntaxNode syntax, ImmutableArray<BoundExpression> initializers,  bool hasErrors = false)
    BoundKind.ArrayInitialization, syntax, null, hasErrors || initializers.HasErrors(){
      Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Initializers = initializers    }
    public  ImmutableArray<BoundExpression> Initializers { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitArrayInitialization(this)
    public BoundArrayInitialization Update(ImmutableArray<BoundExpression> initializers)
    {
      if ()
      {
        (this.Syntax, Initializers, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal partial class BoundStackAllocArrayCreation{
    protected BoundStackAllocArrayCreation(BoundKind kind, SyntaxNode syntax, TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false)
    kind, syntax, type, hasErrors{
      Debug.Assert(elementType != null, "Field 'elementType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(count != null, "Field 'count' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ElementType = elementTypethis.Count = countthis.InitializerOpt = initializerOpt    }
    public BoundStackAllocArrayCreation(SyntaxNode syntax, TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.StackAllocArrayCreation, syntax, type, hasErrors || count.HasErrors() || initializerOpt.HasErrors(){
      Debug.Assert(elementType != null, "Field 'elementType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(count != null, "Field 'count' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ElementType = elementTypethis.Count = countthis.InitializerOpt = initializerOpt    }
    public  TypeSymbol ElementType { get; }public  BoundExpression Count { get; }public  BoundArrayInitialization InitializerOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitStackAllocArrayCreation(this)
    public BoundStackAllocArrayCreation Update(TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ElementType, Count, InitializerOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConvertedStackAllocExpression{
    public BoundConvertedStackAllocExpression(SyntaxNode syntax, TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ConvertedStackAllocExpression, syntax, elementType, count, initializerOpt, type, hasErrors || count.HasErrors() || initializerOpt.HasErrors(){
      Debug.Assert(elementType != null, "Field 'elementType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(count != null, "Field 'count' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConvertedStackAllocExpression(this)
    public BoundConvertedStackAllocExpression Update(TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ElementType, Count, InitializerOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundFieldAccess{
    public BoundFieldAccess(SyntaxNode syntax, BoundExpression receiverOpt, FieldSymbol fieldSymbol, ConstantValue constantValueOpt, LookupResultKind resultKind, bool isByValue, bool isDeclaration, TypeSymbol type,  bool hasErrors = false)
    BoundKind.FieldAccess, syntax, type, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(fieldSymbol != null, "Field 'fieldSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ReceiverOpt = receiverOptthis.FieldSymbol = fieldSymbolthis.ConstantValueOpt = constantValueOptthis.ResultKind = resultKindthis.IsByValue = isByValuethis.IsDeclaration = isDeclaration    }
    public  BoundExpression ReceiverOpt { get; }public  FieldSymbol FieldSymbol { get; }public  ConstantValue ConstantValueOpt { get; }public override LookupResultKind ResultKind { get; }public  bool IsByValue { get; }public  bool IsDeclaration { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitFieldAccess(this)
    public BoundFieldAccess Update(BoundExpression receiverOpt, FieldSymbol fieldSymbol, ConstantValue constantValueOpt, LookupResultKind resultKind, bool isByValue, bool isDeclaration, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ReceiverOpt, FieldSymbol, ConstantValueOpt, ResultKind, IsByValue, IsDeclaration, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundHoistedFieldAccess{
    public BoundHoistedFieldAccess(SyntaxNode syntax, FieldSymbol fieldSymbol, TypeSymbol type, bool hasErrors)
    BoundKind.HoistedFieldAccess, syntax, type, hasErrors{
      Debug.Assert(fieldSymbol != null, "Field 'fieldSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.FieldSymbol = fieldSymbol    }
    public BoundHoistedFieldAccess(SyntaxNode syntax, FieldSymbol fieldSymbol, TypeSymbol type)
    BoundKind.HoistedFieldAccess, syntax, type{
      Debug.Assert(fieldSymbol != null, "Field 'fieldSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.FieldSymbol = fieldSymbol;
    }
    public  FieldSymbol FieldSymbol { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitHoistedFieldAccess(this)
    public BoundHoistedFieldAccess Update(FieldSymbol fieldSymbol, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, FieldSymbol, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundPropertyAccess{
    public BoundPropertyAccess(SyntaxNode syntax, BoundExpression receiverOpt, PropertySymbol propertySymbol, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.PropertyAccess, syntax, type, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(propertySymbol != null, "Field 'propertySymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ReceiverOpt = receiverOptthis.PropertySymbol = propertySymbolthis.ResultKind = resultKind    }
    public  BoundExpression ReceiverOpt { get; }public  PropertySymbol PropertySymbol { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitPropertyAccess(this)
    public BoundPropertyAccess Update(BoundExpression receiverOpt, PropertySymbol propertySymbol, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ReceiverOpt, PropertySymbol, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundEventAccess{
    public BoundEventAccess(SyntaxNode syntax, BoundExpression receiverOpt, EventSymbol eventSymbol, bool isUsableAsField, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false)
    BoundKind.EventAccess, syntax, type, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(eventSymbol != null, "Field 'eventSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ReceiverOpt = receiverOptthis.EventSymbol = eventSymbolthis.IsUsableAsField = isUsableAsFieldthis.ResultKind = resultKind    }
    public  BoundExpression ReceiverOpt { get; }public  EventSymbol EventSymbol { get; }public  bool IsUsableAsField { get; }public override LookupResultKind ResultKind { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitEventAccess(this)
    public BoundEventAccess Update(BoundExpression receiverOpt, EventSymbol eventSymbol, bool isUsableAsField, LookupResultKind resultKind, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ReceiverOpt, EventSymbol, IsUsableAsField, ResultKind, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundIndexerAccess{
    public BoundIndexerAccess(SyntaxNode syntax, BoundExpression receiverOpt, PropertySymbol indexer, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, Binder binderOpt, bool useSetterForDefaultArgumentGeneration, TypeSymbol type,  bool hasErrors = false)
    BoundKind.IndexerAccess, syntax, type, hasErrors || receiverOpt.HasErrors() || arguments.HasErrors(){
      Debug.Assert(indexer != null, "Field 'indexer' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ReceiverOpt = receiverOptthis.Indexer = indexerthis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.Expanded = expandedthis.ArgsToParamsOpt = argsToParamsOptthis.BinderOpt = binderOptthis.UseSetterForDefaultArgumentGeneration = useSetterForDefaultArgumentGeneration    }
    public  BoundExpression ReceiverOpt { get; }public  PropertySymbol Indexer { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  bool Expanded { get; }public  ImmutableArray<int> ArgsToParamsOpt { get; }public  Binder BinderOpt { get; }public  bool UseSetterForDefaultArgumentGeneration { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitIndexerAccess(this)
    public BoundIndexerAccess Update(BoundExpression receiverOpt, PropertySymbol indexer, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, Binder binderOpt, bool useSetterForDefaultArgumentGeneration, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ReceiverOpt, Indexer, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, Expanded, ArgsToParamsOpt, BinderOpt, UseSetterForDefaultArgumentGeneration, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundDynamicIndexerAccess{
    public BoundDynamicIndexerAccess(SyntaxNode syntax, BoundExpression receiverOpt, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<PropertySymbol> applicableIndexers, TypeSymbol type,  bool hasErrors = false)
    BoundKind.DynamicIndexerAccess, syntax, type, hasErrors || receiverOpt.HasErrors() || arguments.HasErrors(){
      Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!applicableIndexers.IsDefault, "Field 'applicableIndexers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.ReceiverOpt = receiverOptthis.Arguments = argumentsthis.ArgumentNamesOpt = argumentNamesOptthis.ArgumentRefKindsOpt = argumentRefKindsOptthis.ApplicableIndexers = applicableIndexers    }
    public  BoundExpression ReceiverOpt { get; }public  ImmutableArray<BoundExpression> Arguments { get; }public  ImmutableArray<string> ArgumentNamesOpt { get; }public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }public  ImmutableArray<PropertySymbol> ApplicableIndexers { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDynamicIndexerAccess(this)
    public BoundDynamicIndexerAccess Update(BoundExpression receiverOpt, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<PropertySymbol> applicableIndexers, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, ReceiverOpt, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, ApplicableIndexers, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundLambda{
    public BoundLambda(SyntaxNode syntax, LambdaSymbol symbol, BoundBlock body, ImmutableArray<Microsoft.CodeAnalysis.Diagnostic> diagnostics, Binder binder, TypeSymbol type,  bool hasErrors = false)
    BoundKind.Lambda, syntax, type, hasErrors || body.HasErrors(){
      Debug.Assert(symbol != null, "Field 'symbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(!diagnostics.IsDefault, "Field 'diagnostics' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(binder != null, "Field 'binder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Symbol = symbolthis.Body = bodythis.Diagnostics = diagnosticsthis.Binder = binder    }
    public  LambdaSymbol Symbol { get; }public  BoundBlock Body { get; }public  ImmutableArray<Microsoft.CodeAnalysis.Diagnostic> Diagnostics { get; }public  Binder Binder { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitLambda(this)
    public BoundLambda Update(LambdaSymbol symbol, BoundBlock body, ImmutableArray<Microsoft.CodeAnalysis.Diagnostic> diagnostics, Binder binder, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Symbol, Body, Diagnostics, Binder, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class UnboundLambda{
    public UnboundLambda(SyntaxNode syntax, UnboundLambdaState data, bool hasErrors)
    BoundKind.UnboundLambda, syntax, null, hasErrors{
      Debug.Assert(data != null, "Field 'data' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Data = data    }
    public UnboundLambda(SyntaxNode syntax, UnboundLambdaState data)
    BoundKind.UnboundLambda, syntax, null{
      Debug.Assert(data != null, "Field 'data' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Data = data;
    }
    public  UnboundLambdaState Data { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitUnboundLambda(this)
    public UnboundLambda Update(UnboundLambdaState data)
    {
      if ()
      {
        (this.Syntax, Data, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundQueryClause{
    public BoundQueryClause(SyntaxNode syntax, BoundExpression value, RangeVariableSymbol definedSymbol, Binder binder, TypeSymbol type,  bool hasErrors = false)
    BoundKind.QueryClause, syntax, type, hasErrors || value.HasErrors(){
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(binder != null, "Field 'binder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Value = valuethis.DefinedSymbol = definedSymbolthis.Binder = binder    }
    public  BoundExpression Value { get; }public  RangeVariableSymbol DefinedSymbol { get; }public  Binder Binder { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitQueryClause(this)
    public BoundQueryClause Update(BoundExpression value, RangeVariableSymbol definedSymbol, Binder binder, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Value, DefinedSymbol, Binder, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundTypeOrInstanceInitializers{
    public BoundTypeOrInstanceInitializers(SyntaxNode syntax, ImmutableArray<BoundStatement> statements,  bool hasErrors = false)
    BoundKind.TypeOrInstanceInitializers, syntax, statements, hasErrors || statements.HasErrors(){
      Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitTypeOrInstanceInitializers(this)
    public BoundTypeOrInstanceInitializers Update(ImmutableArray<BoundStatement> statements)
    {
      if ()
      {
        (this.Syntax, Statements, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundNameOfOperator{
    public BoundNameOfOperator(SyntaxNode syntax, BoundExpression argument, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false)
    BoundKind.NameOfOperator, syntax, type, hasErrors || argument.HasErrors(){
      Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(constantValueOpt != null, "Field 'constantValueOpt' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Argument = argumentthis.ConstantValueOpt = constantValueOpt    }
    public  BoundExpression Argument { get; }public  ConstantValue ConstantValueOpt { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNameOfOperator(this)
    public BoundNameOfOperator Update(BoundExpression argument, ConstantValue constantValueOpt, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Argument, ConstantValueOpt, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundInterpolatedString{
    public BoundInterpolatedString(SyntaxNode syntax, ImmutableArray<BoundExpression> parts, TypeSymbol type,  bool hasErrors = false)
    BoundKind.InterpolatedString, syntax, type, hasErrors || parts.HasErrors(){
      Debug.Assert(!parts.IsDefault, "Field 'parts' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Parts = parts    }
    public  ImmutableArray<BoundExpression> Parts { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitInterpolatedString(this)
    public BoundInterpolatedString Update(ImmutableArray<BoundExpression> parts, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Parts, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundStringInsert{
    public BoundStringInsert(SyntaxNode syntax, BoundExpression value, BoundExpression alignment, BoundLiteral format, TypeSymbol type,  bool hasErrors = false)
    BoundKind.StringInsert, syntax, type, hasErrors || value.HasErrors() || alignment.HasErrors() || format.HasErrors(){
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Value = valuethis.Alignment = alignmentthis.Format = format    }
    public  BoundExpression Value { get; }public  BoundExpression Alignment { get; }public  BoundLiteral Format { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitStringInsert(this)
    public BoundStringInsert Update(BoundExpression value, BoundExpression alignment, BoundLiteral format, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Value, Alignment, Format, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundIsPatternExpression{
    public BoundIsPatternExpression(SyntaxNode syntax, BoundExpression expression, BoundPattern pattern, TypeSymbol type,  bool hasErrors = false)
    BoundKind.IsPatternExpression, syntax, type, hasErrors || expression.HasErrors() || pattern.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      Debug.Assert(pattern != null, "Field 'pattern' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expressionthis.Pattern = pattern    }
    public  BoundExpression Expression { get; }public  BoundPattern Pattern { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitIsPatternExpression(this)
    public BoundIsPatternExpression Update(BoundExpression expression, BoundPattern pattern, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Pattern, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class BoundPattern{
    protected BoundPattern(BoundKind kind, SyntaxNode syntax, bool hasErrors)
    kind, syntax, hasErrors{
    }
    protected BoundPattern(BoundKind kind, SyntaxNode syntax)
    kind, syntax{
    }
  }internal sealed partial class BoundDeclarationPattern{
    public BoundDeclarationPattern(SyntaxNode syntax, Symbol variable, BoundExpression variableAccess, BoundTypeExpression declaredType, bool isVar,  bool hasErrors = false)
    BoundKind.DeclarationPattern, syntax, hasErrors || variableAccess.HasErrors() || declaredType.HasErrors(){
      Debug.Assert(variableAccess != null, "Field 'variableAccess' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Variable = variablethis.VariableAccess = variableAccessthis.DeclaredType = declaredTypethis.IsVar = isVar    }
    public  Symbol Variable { get; }public  BoundExpression VariableAccess { get; }public  BoundTypeExpression DeclaredType { get; }public  bool IsVar { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDeclarationPattern(this)
    public BoundDeclarationPattern Update(Symbol variable, BoundExpression variableAccess, BoundTypeExpression declaredType, bool isVar)
    {
      if ()
      {
        (this.Syntax, Variable, VariableAccess, DeclaredType, IsVar, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConstantPattern{
    public BoundConstantPattern(SyntaxNode syntax, BoundExpression value, ConstantValue constantValue,  bool hasErrors = false)
    BoundKind.ConstantPattern, syntax, hasErrors || value.HasErrors(){
      Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Value = valuethis.ConstantValue = constantValue    }
    public  BoundExpression Value { get; }public  ConstantValue ConstantValue { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConstantPattern(this)
    public BoundConstantPattern Update(BoundExpression value, ConstantValue constantValue)
    {
      if ()
      {
        (this.Syntax, Value, ConstantValue, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundWildcardPattern{
    public BoundWildcardPattern(SyntaxNode syntax, bool hasErrors)
    BoundKind.WildcardPattern, syntax, hasErrors{
    }
    public BoundWildcardPattern(SyntaxNode syntax)
    BoundKind.WildcardPattern, syntax{
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitWildcardPattern(this)
  }internal sealed partial class BoundDiscardExpression{
    public BoundDiscardExpression(SyntaxNode syntax, TypeSymbol type, bool hasErrors)
    BoundKind.DiscardExpression, syntax, type, hasErrors{
    }
    public BoundDiscardExpression(SyntaxNode syntax, TypeSymbol type)
    BoundKind.DiscardExpression, syntax, type{
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDiscardExpression(this)
    public BoundDiscardExpression Update(TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundThrowExpression{
    public BoundThrowExpression(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false)
    BoundKind.ThrowExpression, syntax, type, hasErrors || expression.HasErrors(){
      Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Expression = expression    }
    public  BoundExpression Expression { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitThrowExpression(this)
    public BoundThrowExpression Update(BoundExpression expression, TypeSymbol type)
    {
      if ()
      {
        (this.Syntax, Expression, Type, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal abstract partial class VariablePendingInference{
    protected VariablePendingInference(BoundKind kind, SyntaxNode syntax, Symbol variableSymbol, BoundExpression receiverOpt,  bool hasErrors = false)
    kind, syntax, null, hasErrors{
      Debug.Assert(variableSymbol != null, "Field 'variableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.VariableSymbol = variableSymbolthis.ReceiverOpt = receiverOpt    }
    public  Symbol VariableSymbol { get; }public  BoundExpression ReceiverOpt { get; }  }internal sealed partial class OutVariablePendingInference{
    public OutVariablePendingInference(SyntaxNode syntax, Symbol variableSymbol, BoundExpression receiverOpt,  bool hasErrors = false)
    BoundKind.OutVariablePendingInference, syntax, variableSymbol, receiverOpt, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(variableSymbol != null, "Field 'variableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitOutVariablePendingInference(this)
    public OutVariablePendingInference Update(Symbol variableSymbol, BoundExpression receiverOpt)
    {
      if ()
      {
        (this.Syntax, VariableSymbol, ReceiverOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class DeconstructionVariablePendingInference{
    public DeconstructionVariablePendingInference(SyntaxNode syntax, Symbol variableSymbol, BoundExpression receiverOpt,  bool hasErrors = false)
    BoundKind.DeconstructionVariablePendingInference, syntax, variableSymbol, receiverOpt, hasErrors || receiverOpt.HasErrors(){
      Debug.Assert(variableSymbol != null, "Field 'variableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitDeconstructionVariablePendingInference(this)
    public DeconstructionVariablePendingInference Update(Symbol variableSymbol, BoundExpression receiverOpt)
    {
      if ()
      {
        (this.Syntax, VariableSymbol, ReceiverOpt, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class OutDeconstructVarPendingInference{
    public OutDeconstructVarPendingInference(SyntaxNode syntax, bool hasErrors)
    BoundKind.OutDeconstructVarPendingInference, syntax, null, hasErrors{
    }
    public OutDeconstructVarPendingInference(SyntaxNode syntax)
    BoundKind.OutDeconstructVarPendingInference, syntax, null{
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitOutDeconstructVarPendingInference(this)
    public OutDeconstructVarPendingInference Update()
    {

      return this;
    }
  }internal abstract partial class BoundMethodBodyBase{
    protected BoundMethodBodyBase(BoundKind kind, SyntaxNode syntax, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false)
    kind, syntax, hasErrors{
      this.BlockBody = blockBodythis.ExpressionBody = expressionBody    }
    public  BoundBlock BlockBody { get; }public  BoundBlock ExpressionBody { get; }  }internal sealed partial class BoundNonConstructorMethodBody{
    public BoundNonConstructorMethodBody(SyntaxNode syntax, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false)
    BoundKind.NonConstructorMethodBody, syntax, blockBody, expressionBody, hasErrors || blockBody.HasErrors() || expressionBody.HasErrors(){
    }
    public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitNonConstructorMethodBody(this)
    public BoundNonConstructorMethodBody Update(BoundBlock blockBody, BoundBlock expressionBody)
    {
      if ()
      {
        (this.Syntax, BlockBody, ExpressionBody, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }internal sealed partial class BoundConstructorMethodBody{
    public BoundConstructorMethodBody(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpressionStatement initializer, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false)
    BoundKind.ConstructorMethodBody, syntax, blockBody, expressionBody, hasErrors || initializer.HasErrors() || blockBody.HasErrors() || expressionBody.HasErrors(){
      Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)")
      this.Locals = localsthis.Initializer = initializer    }
    public  ImmutableArray<LocalSymbol> Locals { get; }public  BoundExpressionStatement Initializer { get; }public override BoundNode Accept(BoundTreeVisitor visitor)
     => visitor.VisitConstructorMethodBody(this)
    public BoundConstructorMethodBody Update(ImmutableArray<LocalSymbol> locals, BoundExpressionStatement initializer, BoundBlock blockBody, BoundBlock expressionBody)
    {
      if ()
      {
        (this.Syntax, Locals, Initializer, BlockBody, ExpressionBody, this.HasErrors)

        result.WasCompilerGenerated = this.WasCompilerGenerated
        return result;
      }
      return this;
    }
  }
  internal abstract partial class BoundTreeVisitor<A,R>{
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal R VisitInternal(BoundNode node, A arg)
    switch (node.Kind)
    {
      case BoundKind.FieldEqualsValue:return VisitFieldEqualsValue(node as BoundFieldEqualsValue, arg);
      case BoundKind.PropertyEqualsValue:return VisitPropertyEqualsValue(node as BoundPropertyEqualsValue, arg);
      case BoundKind.ParameterEqualsValue:return VisitParameterEqualsValue(node as BoundParameterEqualsValue, arg);
      case BoundKind.GlobalStatementInitializer:return VisitGlobalStatementInitializer(node as BoundGlobalStatementInitializer, arg);
      case BoundKind.DeconstructValuePlaceholder:return VisitDeconstructValuePlaceholder(node as BoundDeconstructValuePlaceholder, arg);
      case BoundKind.TupleOperandPlaceholder:return VisitTupleOperandPlaceholder(node as BoundTupleOperandPlaceholder, arg);
      case BoundKind.Dup:return VisitDup(node as BoundDup, arg);
      case BoundKind.PassByCopy:return VisitPassByCopy(node as BoundPassByCopy, arg);
      case BoundKind.BadExpression:return VisitBadExpression(node as BoundBadExpression, arg);
      case BoundKind.BadStatement:return VisitBadStatement(node as BoundBadStatement, arg);
      case BoundKind.TypeExpression:return VisitTypeExpression(node as BoundTypeExpression, arg);
      case BoundKind.TypeOrValueExpression:return VisitTypeOrValueExpression(node as BoundTypeOrValueExpression, arg);
      case BoundKind.NamespaceExpression:return VisitNamespaceExpression(node as BoundNamespaceExpression, arg);
      case BoundKind.UnaryOperator:return VisitUnaryOperator(node as BoundUnaryOperator, arg);
      case BoundKind.IncrementOperator:return VisitIncrementOperator(node as BoundIncrementOperator, arg);
      case BoundKind.AddressOfOperator:return VisitAddressOfOperator(node as BoundAddressOfOperator, arg);
      case BoundKind.PointerIndirectionOperator:return VisitPointerIndirectionOperator(node as BoundPointerIndirectionOperator, arg);
      case BoundKind.PointerElementAccess:return VisitPointerElementAccess(node as BoundPointerElementAccess, arg);
      case BoundKind.RefTypeOperator:return VisitRefTypeOperator(node as BoundRefTypeOperator, arg);
      case BoundKind.MakeRefOperator:return VisitMakeRefOperator(node as BoundMakeRefOperator, arg);
      case BoundKind.RefValueOperator:return VisitRefValueOperator(node as BoundRefValueOperator, arg);
      case BoundKind.BinaryOperator:return VisitBinaryOperator(node as BoundBinaryOperator, arg);
      case BoundKind.TupleBinaryOperator:return VisitTupleBinaryOperator(node as BoundTupleBinaryOperator, arg);
      case BoundKind.UserDefinedConditionalLogicalOperator:return VisitUserDefinedConditionalLogicalOperator(node as BoundUserDefinedConditionalLogicalOperator, arg);
      case BoundKind.CompoundAssignmentOperator:return VisitCompoundAssignmentOperator(node as BoundCompoundAssignmentOperator, arg);
      case BoundKind.AssignmentOperator:return VisitAssignmentOperator(node as BoundAssignmentOperator, arg);
      case BoundKind.DeconstructionAssignmentOperator:return VisitDeconstructionAssignmentOperator(node as BoundDeconstructionAssignmentOperator, arg);
      case BoundKind.NullCoalescingOperator:return VisitNullCoalescingOperator(node as BoundNullCoalescingOperator, arg);
      case BoundKind.ConditionalOperator:return VisitConditionalOperator(node as BoundConditionalOperator, arg);
      case BoundKind.ArrayAccess:return VisitArrayAccess(node as BoundArrayAccess, arg);
      case BoundKind.ArrayLength:return VisitArrayLength(node as BoundArrayLength, arg);
      case BoundKind.AwaitExpression:return VisitAwaitExpression(node as BoundAwaitExpression, arg);
      case BoundKind.TypeOfOperator:return VisitTypeOfOperator(node as BoundTypeOfOperator, arg);
      case BoundKind.MethodDefIndex:return VisitMethodDefIndex(node as BoundMethodDefIndex, arg);
      case BoundKind.MaximumMethodDefIndex:return VisitMaximumMethodDefIndex(node as BoundMaximumMethodDefIndex, arg);
      case BoundKind.InstrumentationPayloadRoot:return VisitInstrumentationPayloadRoot(node as BoundInstrumentationPayloadRoot, arg);
      case BoundKind.ModuleVersionId:return VisitModuleVersionId(node as BoundModuleVersionId, arg);
      case BoundKind.ModuleVersionIdString:return VisitModuleVersionIdString(node as BoundModuleVersionIdString, arg);
      case BoundKind.SourceDocumentIndex:return VisitSourceDocumentIndex(node as BoundSourceDocumentIndex, arg);
      case BoundKind.MethodInfo:return VisitMethodInfo(node as BoundMethodInfo, arg);
      case BoundKind.FieldInfo:return VisitFieldInfo(node as BoundFieldInfo, arg);
      case BoundKind.DefaultExpression:return VisitDefaultExpression(node as BoundDefaultExpression, arg);
      case BoundKind.IsOperator:return VisitIsOperator(node as BoundIsOperator, arg);
      case BoundKind.AsOperator:return VisitAsOperator(node as BoundAsOperator, arg);
      case BoundKind.SizeOfOperator:return VisitSizeOfOperator(node as BoundSizeOfOperator, arg);
      case BoundKind.Conversion:return VisitConversion(node as BoundConversion, arg);
      case BoundKind.ArgList:return VisitArgList(node as BoundArgList, arg);
      case BoundKind.ArgListOperator:return VisitArgListOperator(node as BoundArgListOperator, arg);
      case BoundKind.FixedLocalCollectionInitializer:return VisitFixedLocalCollectionInitializer(node as BoundFixedLocalCollectionInitializer, arg);
      case BoundKind.SequencePoint:return VisitSequencePoint(node as BoundSequencePoint, arg);
      case BoundKind.SequencePointExpression:return VisitSequencePointExpression(node as BoundSequencePointExpression, arg);
      case BoundKind.SequencePointWithSpan:return VisitSequencePointWithSpan(node as BoundSequencePointWithSpan, arg);
      case BoundKind.Block:return VisitBlock(node as BoundBlock, arg);
      case BoundKind.Scope:return VisitScope(node as BoundScope, arg);
      case BoundKind.StateMachineScope:return VisitStateMachineScope(node as BoundStateMachineScope, arg);
      case BoundKind.LocalDeclaration:return VisitLocalDeclaration(node as BoundLocalDeclaration, arg);
      case BoundKind.MultipleLocalDeclarations:return VisitMultipleLocalDeclarations(node as BoundMultipleLocalDeclarations, arg);
      case BoundKind.LocalFunctionStatement:return VisitLocalFunctionStatement(node as BoundLocalFunctionStatement, arg);
      case BoundKind.Sequence:return VisitSequence(node as BoundSequence, arg);
      case BoundKind.NoOpStatement:return VisitNoOpStatement(node as BoundNoOpStatement, arg);
      case BoundKind.ReturnStatement:return VisitReturnStatement(node as BoundReturnStatement, arg);
      case BoundKind.YieldReturnStatement:return VisitYieldReturnStatement(node as BoundYieldReturnStatement, arg);
      case BoundKind.YieldBreakStatement:return VisitYieldBreakStatement(node as BoundYieldBreakStatement, arg);
      case BoundKind.ThrowStatement:return VisitThrowStatement(node as BoundThrowStatement, arg);
      case BoundKind.ExpressionStatement:return VisitExpressionStatement(node as BoundExpressionStatement, arg);
      case BoundKind.SwitchStatement:return VisitSwitchStatement(node as BoundSwitchStatement, arg);
      case BoundKind.SwitchSection:return VisitSwitchSection(node as BoundSwitchSection, arg);
      case BoundKind.SwitchLabel:return VisitSwitchLabel(node as BoundSwitchLabel, arg);
      case BoundKind.BreakStatement:return VisitBreakStatement(node as BoundBreakStatement, arg);
      case BoundKind.ContinueStatement:return VisitContinueStatement(node as BoundContinueStatement, arg);
      case BoundKind.PatternSwitchStatement:return VisitPatternSwitchStatement(node as BoundPatternSwitchStatement, arg);
      case BoundKind.PatternSwitchSection:return VisitPatternSwitchSection(node as BoundPatternSwitchSection, arg);
      case BoundKind.PatternSwitchLabel:return VisitPatternSwitchLabel(node as BoundPatternSwitchLabel, arg);
      case BoundKind.IfStatement:return VisitIfStatement(node as BoundIfStatement, arg);
      case BoundKind.DoStatement:return VisitDoStatement(node as BoundDoStatement, arg);
      case BoundKind.WhileStatement:return VisitWhileStatement(node as BoundWhileStatement, arg);
      case BoundKind.ForStatement:return VisitForStatement(node as BoundForStatement, arg);
      case BoundKind.ForEachStatement:return VisitForEachStatement(node as BoundForEachStatement, arg);
      case BoundKind.ForEachDeconstructStep:return VisitForEachDeconstructStep(node as BoundForEachDeconstructStep, arg);
      case BoundKind.UsingStatement:return VisitUsingStatement(node as BoundUsingStatement, arg);
      case BoundKind.FixedStatement:return VisitFixedStatement(node as BoundFixedStatement, arg);
      case BoundKind.LockStatement:return VisitLockStatement(node as BoundLockStatement, arg);
      case BoundKind.TryStatement:return VisitTryStatement(node as BoundTryStatement, arg);
      case BoundKind.CatchBlock:return VisitCatchBlock(node as BoundCatchBlock, arg);
      case BoundKind.Literal:return VisitLiteral(node as BoundLiteral, arg);
      case BoundKind.ThisReference:return VisitThisReference(node as BoundThisReference, arg);
      case BoundKind.PreviousSubmissionReference:return VisitPreviousSubmissionReference(node as BoundPreviousSubmissionReference, arg);
      case BoundKind.HostObjectMemberReference:return VisitHostObjectMemberReference(node as BoundHostObjectMemberReference, arg);
      case BoundKind.BaseReference:return VisitBaseReference(node as BoundBaseReference, arg);
      case BoundKind.Local:return VisitLocal(node as BoundLocal, arg);
      case BoundKind.PseudoVariable:return VisitPseudoVariable(node as BoundPseudoVariable, arg);
      case BoundKind.RangeVariable:return VisitRangeVariable(node as BoundRangeVariable, arg);
      case BoundKind.Parameter:return VisitParameter(node as BoundParameter, arg);
      case BoundKind.LabelStatement:return VisitLabelStatement(node as BoundLabelStatement, arg);
      case BoundKind.GotoStatement:return VisitGotoStatement(node as BoundGotoStatement, arg);
      case BoundKind.LabeledStatement:return VisitLabeledStatement(node as BoundLabeledStatement, arg);
      case BoundKind.Label:return VisitLabel(node as BoundLabel, arg);
      case BoundKind.StatementList:return VisitStatementList(node as BoundStatementList, arg);
      case BoundKind.ConditionalGoto:return VisitConditionalGoto(node as BoundConditionalGoto, arg);
      case BoundKind.DynamicMemberAccess:return VisitDynamicMemberAccess(node as BoundDynamicMemberAccess, arg);
      case BoundKind.DynamicInvocation:return VisitDynamicInvocation(node as BoundDynamicInvocation, arg);
      case BoundKind.ConditionalAccess:return VisitConditionalAccess(node as BoundConditionalAccess, arg);
      case BoundKind.LoweredConditionalAccess:return VisitLoweredConditionalAccess(node as BoundLoweredConditionalAccess, arg);
      case BoundKind.ConditionalReceiver:return VisitConditionalReceiver(node as BoundConditionalReceiver, arg);
      case BoundKind.ComplexConditionalReceiver:return VisitComplexConditionalReceiver(node as BoundComplexConditionalReceiver, arg);
      case BoundKind.MethodGroup:return VisitMethodGroup(node as BoundMethodGroup, arg);
      case BoundKind.PropertyGroup:return VisitPropertyGroup(node as BoundPropertyGroup, arg);
      case BoundKind.Call:return VisitCall(node as BoundCall, arg);
      case BoundKind.EventAssignmentOperator:return VisitEventAssignmentOperator(node as BoundEventAssignmentOperator, arg);
      case BoundKind.Attribute:return VisitAttribute(node as BoundAttribute, arg);
      case BoundKind.ObjectCreationExpression:return VisitObjectCreationExpression(node as BoundObjectCreationExpression, arg);
      case BoundKind.TupleLiteral:return VisitTupleLiteral(node as BoundTupleLiteral, arg);
      case BoundKind.ConvertedTupleLiteral:return VisitConvertedTupleLiteral(node as BoundConvertedTupleLiteral, arg);
      case BoundKind.DynamicObjectCreationExpression:return VisitDynamicObjectCreationExpression(node as BoundDynamicObjectCreationExpression, arg);
      case BoundKind.NoPiaObjectCreationExpression:return VisitNoPiaObjectCreationExpression(node as BoundNoPiaObjectCreationExpression, arg);
      case BoundKind.ObjectInitializerExpression:return VisitObjectInitializerExpression(node as BoundObjectInitializerExpression, arg);
      case BoundKind.ObjectInitializerMember:return VisitObjectInitializerMember(node as BoundObjectInitializerMember, arg);
      case BoundKind.DynamicObjectInitializerMember:return VisitDynamicObjectInitializerMember(node as BoundDynamicObjectInitializerMember, arg);
      case BoundKind.CollectionInitializerExpression:return VisitCollectionInitializerExpression(node as BoundCollectionInitializerExpression, arg);
      case BoundKind.CollectionElementInitializer:return VisitCollectionElementInitializer(node as BoundCollectionElementInitializer, arg);
      case BoundKind.DynamicCollectionElementInitializer:return VisitDynamicCollectionElementInitializer(node as BoundDynamicCollectionElementInitializer, arg);
      case BoundKind.ImplicitReceiver:return VisitImplicitReceiver(node as BoundImplicitReceiver, arg);
      case BoundKind.AnonymousObjectCreationExpression:return VisitAnonymousObjectCreationExpression(node as BoundAnonymousObjectCreationExpression, arg);
      case BoundKind.AnonymousPropertyDeclaration:return VisitAnonymousPropertyDeclaration(node as BoundAnonymousPropertyDeclaration, arg);
      case BoundKind.NewT:return VisitNewT(node as BoundNewT, arg);
      case BoundKind.DelegateCreationExpression:return VisitDelegateCreationExpression(node as BoundDelegateCreationExpression, arg);
      case BoundKind.ArrayCreation:return VisitArrayCreation(node as BoundArrayCreation, arg);
      case BoundKind.ArrayInitialization:return VisitArrayInitialization(node as BoundArrayInitialization, arg);
      case BoundKind.StackAllocArrayCreation:return VisitStackAllocArrayCreation(node as BoundStackAllocArrayCreation, arg);
      case BoundKind.ConvertedStackAllocExpression:return VisitConvertedStackAllocExpression(node as BoundConvertedStackAllocExpression, arg);
      case BoundKind.FieldAccess:return VisitFieldAccess(node as BoundFieldAccess, arg);
      case BoundKind.HoistedFieldAccess:return VisitHoistedFieldAccess(node as BoundHoistedFieldAccess, arg);
      case BoundKind.PropertyAccess:return VisitPropertyAccess(node as BoundPropertyAccess, arg);
      case BoundKind.EventAccess:return VisitEventAccess(node as BoundEventAccess, arg);
      case BoundKind.IndexerAccess:return VisitIndexerAccess(node as BoundIndexerAccess, arg);
      case BoundKind.DynamicIndexerAccess:return VisitDynamicIndexerAccess(node as BoundDynamicIndexerAccess, arg);
      case BoundKind.Lambda:return VisitLambda(node as BoundLambda, arg);
      case BoundKind.UnboundLambda:return VisitUnboundLambda(node as UnboundLambda, arg);
      case BoundKind.QueryClause:return VisitQueryClause(node as BoundQueryClause, arg);
      case BoundKind.TypeOrInstanceInitializers:return VisitTypeOrInstanceInitializers(node as BoundTypeOrInstanceInitializers, arg);
      case BoundKind.NameOfOperator:return VisitNameOfOperator(node as BoundNameOfOperator, arg);
      case BoundKind.InterpolatedString:return VisitInterpolatedString(node as BoundInterpolatedString, arg);
      case BoundKind.StringInsert:return VisitStringInsert(node as BoundStringInsert, arg);
      case BoundKind.IsPatternExpression:return VisitIsPatternExpression(node as BoundIsPatternExpression, arg);
      case BoundKind.DeclarationPattern:return VisitDeclarationPattern(node as BoundDeclarationPattern, arg);
      case BoundKind.ConstantPattern:return VisitConstantPattern(node as BoundConstantPattern, arg);
      case BoundKind.WildcardPattern:return VisitWildcardPattern(node as BoundWildcardPattern, arg);
      case BoundKind.DiscardExpression:return VisitDiscardExpression(node as BoundDiscardExpression, arg);
      case BoundKind.ThrowExpression:return VisitThrowExpression(node as BoundThrowExpression, arg);
      case BoundKind.OutVariablePendingInference:return VisitOutVariablePendingInference(node as OutVariablePendingInference, arg);
      case BoundKind.DeconstructionVariablePendingInference:return VisitDeconstructionVariablePendingInference(node as DeconstructionVariablePendingInference, arg);
      case BoundKind.OutDeconstructVarPendingInference:return VisitOutDeconstructVarPendingInference(node as OutDeconstructVarPendingInference, arg);
      case BoundKind.NonConstructorMethodBody:return VisitNonConstructorMethodBody(node as BoundNonConstructorMethodBody, arg);
      case BoundKind.ConstructorMethodBody:return VisitConstructorMethodBody(node as BoundConstructorMethodBody, arg);    }return default(R);
    {
    }
  }internal abstract partial class BoundTreeVisitor<A,R>{
    public virtual R VisitFieldEqualsValue(BoundFieldEqualsValue node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPropertyEqualsValue(BoundPropertyEqualsValue node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitParameterEqualsValue(BoundParameterEqualsValue node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDup(BoundDup node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPassByCopy(BoundPassByCopy node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitBadExpression(BoundBadExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitBadStatement(BoundBadStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTypeExpression(BoundTypeExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTypeOrValueExpression(BoundTypeOrValueExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNamespaceExpression(BoundNamespaceExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitUnaryOperator(BoundUnaryOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitIncrementOperator(BoundIncrementOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAddressOfOperator(BoundAddressOfOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPointerElementAccess(BoundPointerElementAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitRefTypeOperator(BoundRefTypeOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitMakeRefOperator(BoundMakeRefOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitRefValueOperator(BoundRefValueOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitBinaryOperator(BoundBinaryOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTupleBinaryOperator(BoundTupleBinaryOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAssignmentOperator(BoundAssignmentOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNullCoalescingOperator(BoundNullCoalescingOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConditionalOperator(BoundConditionalOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitArrayAccess(BoundArrayAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitArrayLength(BoundArrayLength node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAwaitExpression(BoundAwaitExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTypeOfOperator(BoundTypeOfOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitMethodDefIndex(BoundMethodDefIndex node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitModuleVersionId(BoundModuleVersionId node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitModuleVersionIdString(BoundModuleVersionIdString node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSourceDocumentIndex(BoundSourceDocumentIndex node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitMethodInfo(BoundMethodInfo node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitFieldInfo(BoundFieldInfo node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDefaultExpression(BoundDefaultExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitIsOperator(BoundIsOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAsOperator(BoundAsOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSizeOfOperator(BoundSizeOfOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConversion(BoundConversion node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitArgList(BoundArgList node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitArgListOperator(BoundArgListOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSequencePoint(BoundSequencePoint node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSequencePointExpression(BoundSequencePointExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSequencePointWithSpan(BoundSequencePointWithSpan node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitBlock(BoundBlock node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitScope(BoundScope node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitStateMachineScope(BoundStateMachineScope node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLocalDeclaration(BoundLocalDeclaration node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLocalFunctionStatement(BoundLocalFunctionStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSequence(BoundSequence node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNoOpStatement(BoundNoOpStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitReturnStatement(BoundReturnStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitYieldReturnStatement(BoundYieldReturnStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitYieldBreakStatement(BoundYieldBreakStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitThrowStatement(BoundThrowStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitExpressionStatement(BoundExpressionStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSwitchStatement(BoundSwitchStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSwitchSection(BoundSwitchSection node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitSwitchLabel(BoundSwitchLabel node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitBreakStatement(BoundBreakStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitContinueStatement(BoundContinueStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPatternSwitchStatement(BoundPatternSwitchStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPatternSwitchSection(BoundPatternSwitchSection node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPatternSwitchLabel(BoundPatternSwitchLabel node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitIfStatement(BoundIfStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDoStatement(BoundDoStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitWhileStatement(BoundWhileStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitForStatement(BoundForStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitForEachStatement(BoundForEachStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitForEachDeconstructStep(BoundForEachDeconstructStep node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitUsingStatement(BoundUsingStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitFixedStatement(BoundFixedStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLockStatement(BoundLockStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTryStatement(BoundTryStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitCatchBlock(BoundCatchBlock node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLiteral(BoundLiteral node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitThisReference(BoundThisReference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitHostObjectMemberReference(BoundHostObjectMemberReference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitBaseReference(BoundBaseReference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLocal(BoundLocal node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPseudoVariable(BoundPseudoVariable node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitRangeVariable(BoundRangeVariable node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitParameter(BoundParameter node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLabelStatement(BoundLabelStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitGotoStatement(BoundGotoStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLabeledStatement(BoundLabeledStatement node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLabel(BoundLabel node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitStatementList(BoundStatementList node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConditionalGoto(BoundConditionalGoto node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDynamicMemberAccess(BoundDynamicMemberAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDynamicInvocation(BoundDynamicInvocation node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConditionalAccess(BoundConditionalAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConditionalReceiver(BoundConditionalReceiver node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitMethodGroup(BoundMethodGroup node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPropertyGroup(BoundPropertyGroup node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitCall(BoundCall node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitEventAssignmentOperator(BoundEventAssignmentOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAttribute(BoundAttribute node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitObjectCreationExpression(BoundObjectCreationExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTupleLiteral(BoundTupleLiteral node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitObjectInitializerExpression(BoundObjectInitializerExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitObjectInitializerMember(BoundObjectInitializerMember node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitCollectionElementInitializer(BoundCollectionElementInitializer node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitImplicitReceiver(BoundImplicitReceiver node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNewT(BoundNewT node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDelegateCreationExpression(BoundDelegateCreationExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitArrayCreation(BoundArrayCreation node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitArrayInitialization(BoundArrayInitialization node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitFieldAccess(BoundFieldAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitHoistedFieldAccess(BoundHoistedFieldAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitPropertyAccess(BoundPropertyAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitEventAccess(BoundEventAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitIndexerAccess(BoundIndexerAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitLambda(BoundLambda node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitUnboundLambda(UnboundLambda node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitQueryClause(BoundQueryClause node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNameOfOperator(BoundNameOfOperator node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitInterpolatedString(BoundInterpolatedString node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitStringInsert(BoundStringInsert node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitIsPatternExpression(BoundIsPatternExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDeclarationPattern(BoundDeclarationPattern node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConstantPattern(BoundConstantPattern node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitWildcardPattern(BoundWildcardPattern node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDiscardExpression(BoundDiscardExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitThrowExpression(BoundThrowExpression node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitOutVariablePendingInference(OutVariablePendingInference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node, A arg)
     => this.DefaultVisit(node, arg)
    public virtual R VisitConstructorMethodBody(BoundConstructorMethodBody node, A arg)
     => this.DefaultVisit(node, arg)
  }internal abstract partial class BoundTreeVisitor{
    public virtual BoundNode VisitFieldEqualsValue(BoundFieldEqualsValue node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitParameterEqualsValue(BoundParameterEqualsValue node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDup(BoundDup node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPassByCopy(BoundPassByCopy node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitBadExpression(BoundBadExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitBadStatement(BoundBadStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTypeExpression(BoundTypeExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNamespaceExpression(BoundNamespaceExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitUnaryOperator(BoundUnaryOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitIncrementOperator(BoundIncrementOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAddressOfOperator(BoundAddressOfOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPointerElementAccess(BoundPointerElementAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitRefTypeOperator(BoundRefTypeOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitMakeRefOperator(BoundMakeRefOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitRefValueOperator(BoundRefValueOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitBinaryOperator(BoundBinaryOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAssignmentOperator(BoundAssignmentOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConditionalOperator(BoundConditionalOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitArrayAccess(BoundArrayAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitArrayLength(BoundArrayLength node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAwaitExpression(BoundAwaitExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTypeOfOperator(BoundTypeOfOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitMethodDefIndex(BoundMethodDefIndex node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitModuleVersionId(BoundModuleVersionId node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitModuleVersionIdString(BoundModuleVersionIdString node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitMethodInfo(BoundMethodInfo node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitFieldInfo(BoundFieldInfo node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDefaultExpression(BoundDefaultExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitIsOperator(BoundIsOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAsOperator(BoundAsOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSizeOfOperator(BoundSizeOfOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConversion(BoundConversion node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitArgList(BoundArgList node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitArgListOperator(BoundArgListOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSequencePoint(BoundSequencePoint node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSequencePointExpression(BoundSequencePointExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitBlock(BoundBlock node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitScope(BoundScope node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitStateMachineScope(BoundStateMachineScope node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLocalDeclaration(BoundLocalDeclaration node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSequence(BoundSequence node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNoOpStatement(BoundNoOpStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitReturnStatement(BoundReturnStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitYieldReturnStatement(BoundYieldReturnStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitYieldBreakStatement(BoundYieldBreakStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitThrowStatement(BoundThrowStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitExpressionStatement(BoundExpressionStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSwitchStatement(BoundSwitchStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSwitchSection(BoundSwitchSection node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitSwitchLabel(BoundSwitchLabel node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitBreakStatement(BoundBreakStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitContinueStatement(BoundContinueStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPatternSwitchSection(BoundPatternSwitchSection node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitIfStatement(BoundIfStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDoStatement(BoundDoStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitWhileStatement(BoundWhileStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitForStatement(BoundForStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitForEachStatement(BoundForEachStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitUsingStatement(BoundUsingStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitFixedStatement(BoundFixedStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLockStatement(BoundLockStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTryStatement(BoundTryStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitCatchBlock(BoundCatchBlock node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLiteral(BoundLiteral node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitThisReference(BoundThisReference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitBaseReference(BoundBaseReference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLocal(BoundLocal node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPseudoVariable(BoundPseudoVariable node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitRangeVariable(BoundRangeVariable node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitParameter(BoundParameter node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLabelStatement(BoundLabelStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitGotoStatement(BoundGotoStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLabeledStatement(BoundLabeledStatement node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLabel(BoundLabel node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitStatementList(BoundStatementList node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConditionalGoto(BoundConditionalGoto node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDynamicInvocation(BoundDynamicInvocation node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConditionalAccess(BoundConditionalAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConditionalReceiver(BoundConditionalReceiver node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitMethodGroup(BoundMethodGroup node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPropertyGroup(BoundPropertyGroup node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitCall(BoundCall node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAttribute(BoundAttribute node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitObjectCreationExpression(BoundObjectCreationExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTupleLiteral(BoundTupleLiteral node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitObjectInitializerMember(BoundObjectInitializerMember node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitImplicitReceiver(BoundImplicitReceiver node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNewT(BoundNewT node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitArrayCreation(BoundArrayCreation node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitArrayInitialization(BoundArrayInitialization node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitFieldAccess(BoundFieldAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitPropertyAccess(BoundPropertyAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitEventAccess(BoundEventAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitIndexerAccess(BoundIndexerAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitLambda(BoundLambda node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitUnboundLambda(UnboundLambda node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitQueryClause(BoundQueryClause node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNameOfOperator(BoundNameOfOperator node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitInterpolatedString(BoundInterpolatedString node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitStringInsert(BoundStringInsert node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitIsPatternExpression(BoundIsPatternExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDeclarationPattern(BoundDeclarationPattern node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConstantPattern(BoundConstantPattern node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitWildcardPattern(BoundWildcardPattern node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDiscardExpression(BoundDiscardExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitThrowExpression(BoundThrowExpression node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitOutVariablePendingInference(OutVariablePendingInference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node)
     => this.DefaultVisit(node)
    public virtual BoundNode VisitConstructorMethodBody(BoundConstructorMethodBody node)
     => this.DefaultVisit(node)
  }
  internal abstract partial class BoundTreeWalker{
    public override BoundNode VisitFieldEqualsValue(BoundFieldEqualsValue node)
    {
      this.Visit(node.Value)return null;
    }
    public override BoundNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node)
    {
      this.Visit(node.Value)return null;
    }
    public override BoundNode VisitParameterEqualsValue(BoundParameterEqualsValue node)
    {
      this.Visit(node.Value)return null;
    }
    public override BoundNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node)
    {
      this.Visit(node.Statement)return null;
    }
    public override BoundNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node)
    {
      return null;
    }
    public override BoundNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node)
    {
      return null;
    }
    public override BoundNode VisitDup(BoundDup node)
    {
      return null;
    }
    public override BoundNode VisitPassByCopy(BoundPassByCopy node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitBadExpression(BoundBadExpression node)
    {
      this.VisitList(node.ChildBoundNodes)return null;
    }
    public override BoundNode VisitBadStatement(BoundBadStatement node)
    {
      this.VisitList(node.ChildBoundNodes)return null;
    }
    public override BoundNode VisitTypeExpression(BoundTypeExpression node)
    {
      this.Visit(node.BoundContainingTypeOpt)return null;
    }
    public override BoundNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node)
    {
      return null;
    }
    public override BoundNode VisitNamespaceExpression(BoundNamespaceExpression node)
    {
      return null;
    }
    public override BoundNode VisitUnaryOperator(BoundUnaryOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitIncrementOperator(BoundIncrementOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitAddressOfOperator(BoundAddressOfOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitPointerElementAccess(BoundPointerElementAccess node)
    {
      this.Visit(node.Expression)this.Visit(node.Index)return null;
    }
    public override BoundNode VisitRefTypeOperator(BoundRefTypeOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitMakeRefOperator(BoundMakeRefOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitRefValueOperator(BoundRefValueOperator node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitBinaryOperator(BoundBinaryOperator node)
    {
      this.Visit(node.Left)this.Visit(node.Right)return null;
    }
    public override BoundNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node)
    {
      this.Visit(node.Left)this.Visit(node.Right)return null;
    }
    public override BoundNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node)
    {
      this.Visit(node.Left)this.Visit(node.Right)return null;
    }
    public override BoundNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node)
    {
      this.Visit(node.Left)this.Visit(node.Right)return null;
    }
    public override BoundNode VisitAssignmentOperator(BoundAssignmentOperator node)
    {
      this.Visit(node.Left)this.Visit(node.Right)return null;
    }
    public override BoundNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node)
    {
      this.Visit(node.Left)this.Visit(node.Right)return null;
    }
    public override BoundNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node)
    {
      this.Visit(node.LeftOperand)this.Visit(node.RightOperand)return null;
    }
    public override BoundNode VisitConditionalOperator(BoundConditionalOperator node)
    {
      this.Visit(node.Condition)this.Visit(node.Consequence)this.Visit(node.Alternative)return null;
    }
    public override BoundNode VisitArrayAccess(BoundArrayAccess node)
    {
      this.Visit(node.Expression)this.VisitList(node.Indices)return null;
    }
    public override BoundNode VisitArrayLength(BoundArrayLength node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitAwaitExpression(BoundAwaitExpression node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitTypeOfOperator(BoundTypeOfOperator node)
    {
      this.Visit(node.SourceType)return null;
    }
    public override BoundNode VisitMethodDefIndex(BoundMethodDefIndex node)
    {
      return null;
    }
    public override BoundNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node)
    {
      return null;
    }
    public override BoundNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node)
    {
      return null;
    }
    public override BoundNode VisitModuleVersionId(BoundModuleVersionId node)
    {
      return null;
    }
    public override BoundNode VisitModuleVersionIdString(BoundModuleVersionIdString node)
    {
      return null;
    }
    public override BoundNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node)
    {
      return null;
    }
    public override BoundNode VisitMethodInfo(BoundMethodInfo node)
    {
      return null;
    }
    public override BoundNode VisitFieldInfo(BoundFieldInfo node)
    {
      return null;
    }
    public override BoundNode VisitDefaultExpression(BoundDefaultExpression node)
    {
      return null;
    }
    public override BoundNode VisitIsOperator(BoundIsOperator node)
    {
      this.Visit(node.Operand)this.Visit(node.TargetType)return null;
    }
    public override BoundNode VisitAsOperator(BoundAsOperator node)
    {
      this.Visit(node.Operand)this.Visit(node.TargetType)return null;
    }
    public override BoundNode VisitSizeOfOperator(BoundSizeOfOperator node)
    {
      this.Visit(node.SourceType)return null;
    }
    public override BoundNode VisitConversion(BoundConversion node)
    {
      this.Visit(node.Operand)return null;
    }
    public override BoundNode VisitArgList(BoundArgList node)
    {
      return null;
    }
    public override BoundNode VisitArgListOperator(BoundArgListOperator node)
    {
      this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitSequencePoint(BoundSequencePoint node)
    {
      this.Visit(node.StatementOpt)return null;
    }
    public override BoundNode VisitSequencePointExpression(BoundSequencePointExpression node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node)
    {
      this.Visit(node.StatementOpt)return null;
    }
    public override BoundNode VisitBlock(BoundBlock node)
    {
      this.VisitList(node.Statements)return null;
    }
    public override BoundNode VisitScope(BoundScope node)
    {
      this.VisitList(node.Statements)return null;
    }
    public override BoundNode VisitStateMachineScope(BoundStateMachineScope node)
    {
      this.Visit(node.Statement)return null;
    }
    public override BoundNode VisitLocalDeclaration(BoundLocalDeclaration node)
    {
      this.Visit(node.DeclaredType)this.Visit(node.InitializerOpt)this.VisitList(node.ArgumentsOpt)return null;
    }
    public override BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node)
    {
      this.VisitList(node.LocalDeclarations)return null;
    }
    public override BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node)
    {
      this.Visit(node.BlockBody)this.Visit(node.ExpressionBody)return null;
    }
    public override BoundNode VisitSequence(BoundSequence node)
    {
      this.VisitList(node.SideEffects)this.Visit(node.Value)return null;
    }
    public override BoundNode VisitNoOpStatement(BoundNoOpStatement node)
    {
      return null;
    }
    public override BoundNode VisitReturnStatement(BoundReturnStatement node)
    {
      this.Visit(node.ExpressionOpt)return null;
    }
    public override BoundNode VisitYieldReturnStatement(BoundYieldReturnStatement node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitYieldBreakStatement(BoundYieldBreakStatement node)
    {
      return null;
    }
    public override BoundNode VisitThrowStatement(BoundThrowStatement node)
    {
      this.Visit(node.ExpressionOpt)return null;
    }
    public override BoundNode VisitExpressionStatement(BoundExpressionStatement node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitSwitchStatement(BoundSwitchStatement node)
    {
      this.Visit(node.LoweredPreambleOpt)this.Visit(node.Expression)this.VisitList(node.SwitchSections)return null;
    }
    public override BoundNode VisitSwitchSection(BoundSwitchSection node)
    {
      this.VisitList(node.SwitchLabels)this.VisitList(node.Statements)return null;
    }
    public override BoundNode VisitSwitchLabel(BoundSwitchLabel node)
    {
      this.Visit(node.ExpressionOpt)return null;
    }
    public override BoundNode VisitBreakStatement(BoundBreakStatement node)
    {
      return null;
    }
    public override BoundNode VisitContinueStatement(BoundContinueStatement node)
    {
      return null;
    }
    public override BoundNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node)
    {
      this.Visit(node.Expression)this.VisitList(node.SwitchSections)this.Visit(node.DefaultLabel)return null;
    }
    public override BoundNode VisitPatternSwitchSection(BoundPatternSwitchSection node)
    {
      this.VisitList(node.SwitchLabels)this.VisitList(node.Statements)return null;
    }
    public override BoundNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node)
    {
      this.Visit(node.Pattern)this.Visit(node.Guard)return null;
    }
    public override BoundNode VisitIfStatement(BoundIfStatement node)
    {
      this.Visit(node.Condition)this.Visit(node.Consequence)this.Visit(node.AlternativeOpt)return null;
    }
    public override BoundNode VisitDoStatement(BoundDoStatement node)
    {
      this.Visit(node.Condition)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitWhileStatement(BoundWhileStatement node)
    {
      this.Visit(node.Condition)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitForStatement(BoundForStatement node)
    {
      this.Visit(node.Initializer)this.Visit(node.Condition)this.Visit(node.Increment)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitForEachStatement(BoundForEachStatement node)
    {
      this.Visit(node.IterationVariableType)this.Visit(node.IterationErrorExpressionOpt)this.Visit(node.Expression)this.Visit(node.DeconstructionOpt)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node)
    {
      this.Visit(node.DeconstructionAssignment)this.Visit(node.TargetPlaceholder)return null;
    }
    public override BoundNode VisitUsingStatement(BoundUsingStatement node)
    {
      this.Visit(node.DeclarationsOpt)this.Visit(node.ExpressionOpt)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitFixedStatement(BoundFixedStatement node)
    {
      this.Visit(node.Declarations)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitLockStatement(BoundLockStatement node)
    {
      this.Visit(node.Argument)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitTryStatement(BoundTryStatement node)
    {
      this.Visit(node.TryBlock)this.VisitList(node.CatchBlocks)this.Visit(node.FinallyBlockOpt)return null;
    }
    public override BoundNode VisitCatchBlock(BoundCatchBlock node)
    {
      this.Visit(node.ExceptionSourceOpt)this.Visit(node.ExceptionFilterOpt)this.Visit(node.Body)return null;
    }
    public override BoundNode VisitLiteral(BoundLiteral node)
    {
      return null;
    }
    public override BoundNode VisitThisReference(BoundThisReference node)
    {
      return null;
    }
    public override BoundNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node)
    {
      return null;
    }
    public override BoundNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node)
    {
      return null;
    }
    public override BoundNode VisitBaseReference(BoundBaseReference node)
    {
      return null;
    }
    public override BoundNode VisitLocal(BoundLocal node)
    {
      return null;
    }
    public override BoundNode VisitPseudoVariable(BoundPseudoVariable node)
    {
      return null;
    }
    public override BoundNode VisitRangeVariable(BoundRangeVariable node)
    {
      this.Visit(node.Value)return null;
    }
    public override BoundNode VisitParameter(BoundParameter node)
    {
      return null;
    }
    public override BoundNode VisitLabelStatement(BoundLabelStatement node)
    {
      return null;
    }
    public override BoundNode VisitGotoStatement(BoundGotoStatement node)
    {
      this.Visit(node.CaseExpressionOpt)this.Visit(node.LabelExpressionOpt)return null;
    }
    public override BoundNode VisitLabeledStatement(BoundLabeledStatement node)
    {
      this.Visit(node.Body)return null;
    }
    public override BoundNode VisitLabel(BoundLabel node)
    {
      return null;
    }
    public override BoundNode VisitStatementList(BoundStatementList node)
    {
      this.VisitList(node.Statements)return null;
    }
    public override BoundNode VisitConditionalGoto(BoundConditionalGoto node)
    {
      this.Visit(node.Condition)return null;
    }
    public override BoundNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node)
    {
      this.Visit(node.Receiver)return null;
    }
    public override BoundNode VisitDynamicInvocation(BoundDynamicInvocation node)
    {
      this.Visit(node.Expression)this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitConditionalAccess(BoundConditionalAccess node)
    {
      this.Visit(node.Receiver)this.Visit(node.AccessExpression)return null;
    }
    public override BoundNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node)
    {
      this.Visit(node.Receiver)this.Visit(node.WhenNotNull)this.Visit(node.WhenNullOpt)return null;
    }
    public override BoundNode VisitConditionalReceiver(BoundConditionalReceiver node)
    {
      return null;
    }
    public override BoundNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node)
    {
      this.Visit(node.ValueTypeReceiver)this.Visit(node.ReferenceTypeReceiver)return null;
    }
    public override BoundNode VisitMethodGroup(BoundMethodGroup node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitPropertyGroup(BoundPropertyGroup node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitCall(BoundCall node)
    {
      this.Visit(node.ReceiverOpt)this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node)
    {
      this.Visit(node.ReceiverOpt)this.Visit(node.Argument)return null;
    }
    public override BoundNode VisitAttribute(BoundAttribute node)
    {
      this.VisitList(node.ConstructorArguments)this.VisitList(node.NamedArguments)return null;
    }
    public override BoundNode VisitObjectCreationExpression(BoundObjectCreationExpression node)
    {
      this.VisitList(node.Arguments)this.Visit(node.InitializerExpressionOpt)return null;
    }
    public override BoundNode VisitTupleLiteral(BoundTupleLiteral node)
    {
      this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node)
    {
      this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node)
    {
      this.VisitList(node.Arguments)this.Visit(node.InitializerExpressionOpt)return null;
    }
    public override BoundNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node)
    {
      this.Visit(node.InitializerExpressionOpt)return null;
    }
    public override BoundNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node)
    {
      this.VisitList(node.Initializers)return null;
    }
    public override BoundNode VisitObjectInitializerMember(BoundObjectInitializerMember node)
    {
      this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node)
    {
      return null;
    }
    public override BoundNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node)
    {
      this.VisitList(node.Initializers)return null;
    }
    public override BoundNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node)
    {
      this.VisitList(node.Arguments)this.Visit(node.ImplicitReceiverOpt)return null;
    }
    public override BoundNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node)
    {
      this.VisitList(node.Arguments)this.Visit(node.ImplicitReceiver)return null;
    }
    public override BoundNode VisitImplicitReceiver(BoundImplicitReceiver node)
    {
      return null;
    }
    public override BoundNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node)
    {
      this.VisitList(node.Arguments)this.VisitList(node.Declarations)return null;
    }
    public override BoundNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node)
    {
      return null;
    }
    public override BoundNode VisitNewT(BoundNewT node)
    {
      this.Visit(node.InitializerExpressionOpt)return null;
    }
    public override BoundNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node)
    {
      this.Visit(node.Argument)return null;
    }
    public override BoundNode VisitArrayCreation(BoundArrayCreation node)
    {
      this.VisitList(node.Bounds)this.Visit(node.InitializerOpt)return null;
    }
    public override BoundNode VisitArrayInitialization(BoundArrayInitialization node)
    {
      this.VisitList(node.Initializers)return null;
    }
    public override BoundNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node)
    {
      this.Visit(node.Count)this.Visit(node.InitializerOpt)return null;
    }
    public override BoundNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node)
    {
      this.Visit(node.Count)this.Visit(node.InitializerOpt)return null;
    }
    public override BoundNode VisitFieldAccess(BoundFieldAccess node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node)
    {
      return null;
    }
    public override BoundNode VisitPropertyAccess(BoundPropertyAccess node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitEventAccess(BoundEventAccess node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitIndexerAccess(BoundIndexerAccess node)
    {
      this.Visit(node.ReceiverOpt)this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node)
    {
      this.Visit(node.ReceiverOpt)this.VisitList(node.Arguments)return null;
    }
    public override BoundNode VisitLambda(BoundLambda node)
    {
      this.Visit(node.Body)return null;
    }
    public override BoundNode VisitUnboundLambda(UnboundLambda node)
    {
      return null;
    }
    public override BoundNode VisitQueryClause(BoundQueryClause node)
    {
      this.Visit(node.Value)return null;
    }
    public override BoundNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node)
    {
      this.VisitList(node.Statements)return null;
    }
    public override BoundNode VisitNameOfOperator(BoundNameOfOperator node)
    {
      this.Visit(node.Argument)return null;
    }
    public override BoundNode VisitInterpolatedString(BoundInterpolatedString node)
    {
      this.VisitList(node.Parts)return null;
    }
    public override BoundNode VisitStringInsert(BoundStringInsert node)
    {
      this.Visit(node.Value)this.Visit(node.Alignment)this.Visit(node.Format)return null;
    }
    public override BoundNode VisitIsPatternExpression(BoundIsPatternExpression node)
    {
      this.Visit(node.Expression)this.Visit(node.Pattern)return null;
    }
    public override BoundNode VisitDeclarationPattern(BoundDeclarationPattern node)
    {
      this.Visit(node.VariableAccess)this.Visit(node.DeclaredType)return null;
    }
    public override BoundNode VisitConstantPattern(BoundConstantPattern node)
    {
      this.Visit(node.Value)return null;
    }
    public override BoundNode VisitWildcardPattern(BoundWildcardPattern node)
    {
      return null;
    }
    public override BoundNode VisitDiscardExpression(BoundDiscardExpression node)
    {
      return null;
    }
    public override BoundNode VisitThrowExpression(BoundThrowExpression node)
    {
      this.Visit(node.Expression)return null;
    }
    public override BoundNode VisitOutVariablePendingInference(OutVariablePendingInference node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node)
    {
      this.Visit(node.ReceiverOpt)return null;
    }
    public override BoundNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node)
    {
      return null;
    }
    public override BoundNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node)
    {
      this.Visit(node.BlockBody)this.Visit(node.ExpressionBody)return null;
    }
    public override BoundNode VisitConstructorMethodBody(BoundConstructorMethodBody node)
    {
      this.Visit(node.Initializer)this.Visit(node.BlockBody)this.Visit(node.ExpressionBody)return null;
    }
  }

  internal abstract partial class BoundTreeRewriter{
    public override BoundNode VisitFieldEqualsValue(BoundFieldEqualsValue node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
    }
    public override BoundNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
    }
    public override BoundNode VisitParameterEqualsValue(BoundParameterEqualsValue node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
    }
    public override BoundNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node)
    {
      BoundStatement Statement = (BoundStatement)this.Visit(node.Statement)
    }
    public override BoundNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.ValEscape, Type)
    }
    public override BoundNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitDup(BoundDup node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.RefKind, Type)
    }
    public override BoundNode VisitPassByCopy(BoundPassByCopy node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Type)
    }
    public override BoundNode VisitBadExpression(BoundBadExpression node)
    {
      ImmutableArray<BoundExpression> ChildBoundNodes = (ImmutableArray<BoundExpression>)this.VisitList(node.ChildBoundNodes)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.ResultKind, node.Symbols, ChildBoundNodes, Type)
    }
    public override BoundNode VisitBadStatement(BoundBadStatement node)
    {
      ImmutableArray<BoundNode> ChildBoundNodes = (ImmutableArray<BoundNode>)this.VisitList(node.ChildBoundNodes)
    }
    public override BoundNode VisitTypeExpression(BoundTypeExpression node)
    {
      BoundTypeExpression BoundContainingTypeOpt = (BoundTypeExpression)this.Visit(node.BoundContainingTypeOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.AliasOpt, node.InferredType, BoundContainingTypeOpt, Type)
    }
    public override BoundNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Data, Type)
    }
    public override BoundNode VisitNamespaceExpression(BoundNamespaceExpression node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.NamespaceSymbol, node.AliasOpt)
    }
    public override BoundNode VisitUnaryOperator(BoundUnaryOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.OperatorKind, Operand, node.ConstantValueOpt, node.MethodOpt, node.ResultKind, Type)
    }
    public override BoundNode VisitIncrementOperator(BoundIncrementOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.OperatorKind, Operand, node.MethodOpt, node.OperandConversion, node.ResultConversion, node.ResultKind, Type)
    }
    public override BoundNode VisitAddressOfOperator(BoundAddressOfOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, node.IsManaged, Type)
    }
    public override BoundNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, Type)
    }
    public override BoundNode VisitPointerElementAccess(BoundPointerElementAccess node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)BoundExpression Index = (BoundExpression)this.Visit(node.Index)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Index, node.Checked, Type)
    }
    public override BoundNode VisitRefTypeOperator(BoundRefTypeOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, node.GetTypeFromHandle, Type)
    }
    public override BoundNode VisitMakeRefOperator(BoundMakeRefOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, Type)
    }
    public override BoundNode VisitRefValueOperator(BoundRefValueOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, Type)
    }
    public override BoundNode VisitBinaryOperator(BoundBinaryOperator node)
    {
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.OperatorKind, Left, Right, node.ConstantValueOpt, node.MethodOpt, node.ResultKind, Type)
    }
    public override BoundNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node)
    {
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)BoundExpression ConvertedLeft = node.ConvertedLeft
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)BoundExpression ConvertedLeft = node.ConvertedLeftBoundExpression ConvertedRight = node.ConvertedRight
      var Type = this.VisitType(node.Type)
      return node.Update;(Left, Right, ConvertedLeft, ConvertedRight, node.OperatorKind, node.Operators, Type)
    }
    public override BoundNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node)
    {
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.OperatorKind, Left, Right, node.LogicalOperator, node.TrueOperator, node.FalseOperator, node.ResultKind, Type)
    }
    public override BoundNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node)
    {
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Operator, Left, Right, node.LeftConversion, node.FinalConversion, node.ResultKind, Type)
    }
    public override BoundNode VisitAssignmentOperator(BoundAssignmentOperator node)
    {
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)
      BoundExpression Left = (BoundExpression)this.Visit(node.Left)BoundExpression Right = (BoundExpression)this.Visit(node.Right)
      var Type = this.VisitType(node.Type)
      return node.Update;(Left, Right, node.IsRef, Type)
    }
    public override BoundNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node)
    {
      BoundTupleExpression Left = (BoundTupleExpression)this.Visit(node.Left)
      BoundTupleExpression Left = (BoundTupleExpression)this.Visit(node.Left)BoundConversion Right = (BoundConversion)this.Visit(node.Right)
      var Type = this.VisitType(node.Type)
      return node.Update;(Left, Right, node.IsUsed, Type)
    }
    public override BoundNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node)
    {
      BoundExpression LeftOperand = (BoundExpression)this.Visit(node.LeftOperand)
      BoundExpression LeftOperand = (BoundExpression)this.Visit(node.LeftOperand)BoundExpression RightOperand = (BoundExpression)this.Visit(node.RightOperand)
      var Type = this.VisitType(node.Type)
      return node.Update;(LeftOperand, RightOperand, node.LeftConversion, Type)
    }
    public override BoundNode VisitConditionalOperator(BoundConditionalOperator node)
    {
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundExpression Consequence = (BoundExpression)this.Visit(node.Consequence)
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundExpression Consequence = (BoundExpression)this.Visit(node.Consequence)BoundExpression Alternative = (BoundExpression)this.Visit(node.Alternative)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.IsRef, Condition, Consequence, Alternative, node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitArrayAccess(BoundArrayAccess node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)ImmutableArray<BoundExpression> Indices = (ImmutableArray<BoundExpression>)this.VisitList(node.Indices)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Indices, Type)
    }
    public override BoundNode VisitArrayLength(BoundArrayLength node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Type)
    }
    public override BoundNode VisitAwaitExpression(BoundAwaitExpression node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, node.GetAwaiter, node.IsCompleted, node.GetResult, Type)
    }
    public override BoundNode VisitTypeOfOperator(BoundTypeOfOperator node)
    {
      BoundTypeExpression SourceType = (BoundTypeExpression)this.Visit(node.SourceType)
      var Type = this.VisitType(node.Type)
      return node.Update;(SourceType, node.GetTypeFromHandle, Type)
    }
    public override BoundNode VisitMethodDefIndex(BoundMethodDefIndex node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Method, Type)
    }
    public override BoundNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.AnalysisKind, Type)
    }
    public override BoundNode VisitModuleVersionId(BoundModuleVersionId node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitModuleVersionIdString(BoundModuleVersionIdString node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Document, Type)
    }
    public override BoundNode VisitMethodInfo(BoundMethodInfo node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Method, node.GetMethodFromHandle, Type)
    }
    public override BoundNode VisitFieldInfo(BoundFieldInfo node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Field, node.GetFieldFromHandle, Type)
    }
    public override BoundNode VisitDefaultExpression(BoundDefaultExpression node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitIsOperator(BoundIsOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)BoundTypeExpression TargetType = (BoundTypeExpression)this.Visit(node.TargetType)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, TargetType, node.Conversion, Type)
    }
    public override BoundNode VisitAsOperator(BoundAsOperator node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)BoundTypeExpression TargetType = (BoundTypeExpression)this.Visit(node.TargetType)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, TargetType, node.Conversion, Type)
    }
    public override BoundNode VisitSizeOfOperator(BoundSizeOfOperator node)
    {
      BoundTypeExpression SourceType = (BoundTypeExpression)this.Visit(node.SourceType)
      var Type = this.VisitType(node.Type)
      return node.Update;(SourceType, node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitConversion(BoundConversion node)
    {
      BoundExpression Operand = (BoundExpression)this.Visit(node.Operand)
      var Type = this.VisitType(node.Type)
      return node.Update;(Operand, node.Conversion, node.IsBaseConversion, node.Checked, node.ExplicitCastInCode, node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitArgList(BoundArgList node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitArgListOperator(BoundArgListOperator node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(Arguments, node.ArgumentRefKindsOpt, Type)
    }
    public override BoundNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      var ElementPointerType = this.VisitType(node.ElementPointerType)
      return node.Update;(ElementPointerType, node.ElementPointerTypeConversion, Expression, node.GetPinnableOpt, Type)
      var Type = this.VisitType(node.Type)
      return node.Update;(ElementPointerType, node.ElementPointerTypeConversion, Expression, node.GetPinnableOpt, Type)
    }
    public override BoundNode VisitSequencePoint(BoundSequencePoint node)
    {
      BoundStatement StatementOpt = (BoundStatement)this.Visit(node.StatementOpt)
    }
    public override BoundNode VisitSequencePointExpression(BoundSequencePointExpression node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Type)
    }
    public override BoundNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node)
    {
      BoundStatement StatementOpt = (BoundStatement)this.Visit(node.StatementOpt)
    }
    public override BoundNode VisitBlock(BoundBlock node)
    {
      ImmutableArray<BoundStatement> Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements)
    }
    public override BoundNode VisitScope(BoundScope node)
    {
      ImmutableArray<BoundStatement> Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements)
    }
    public override BoundNode VisitStateMachineScope(BoundStateMachineScope node)
    {
      BoundStatement Statement = (BoundStatement)this.Visit(node.Statement)
    }
    public override BoundNode VisitLocalDeclaration(BoundLocalDeclaration node)
    {
      BoundTypeExpression DeclaredType = (BoundTypeExpression)this.Visit(node.DeclaredType)
      BoundTypeExpression DeclaredType = (BoundTypeExpression)this.Visit(node.DeclaredType)BoundExpression InitializerOpt = (BoundExpression)this.Visit(node.InitializerOpt)
      BoundTypeExpression DeclaredType = (BoundTypeExpression)this.Visit(node.DeclaredType)BoundExpression InitializerOpt = (BoundExpression)this.Visit(node.InitializerOpt)ImmutableArray<BoundExpression> ArgumentsOpt = (ImmutableArray<BoundExpression>)this.VisitList(node.ArgumentsOpt)
    }
    public override BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node)
    {
      ImmutableArray<BoundLocalDeclaration> LocalDeclarations = (ImmutableArray<BoundLocalDeclaration>)this.VisitList(node.LocalDeclarations)
    }
    public override BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node)
    {
      BoundBlock BlockBody = (BoundBlock)this.Visit(node.BlockBody)
      BoundBlock BlockBody = (BoundBlock)this.Visit(node.BlockBody)BoundBlock ExpressionBody = (BoundBlock)this.Visit(node.ExpressionBody)
    }
    public override BoundNode VisitSequence(BoundSequence node)
    {
      ImmutableArray<BoundExpression> SideEffects = (ImmutableArray<BoundExpression>)this.VisitList(node.SideEffects)
      ImmutableArray<BoundExpression> SideEffects = (ImmutableArray<BoundExpression>)this.VisitList(node.SideEffects)BoundExpression Value = (BoundExpression)this.Visit(node.Value)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Locals, SideEffects, Value, Type)
    }
    public override BoundNode VisitNoOpStatement(BoundNoOpStatement node)
    {
    }
    public override BoundNode VisitReturnStatement(BoundReturnStatement node)
    {
      BoundExpression ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt)
    }
    public override BoundNode VisitYieldReturnStatement(BoundYieldReturnStatement node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
    }
    public override BoundNode VisitYieldBreakStatement(BoundYieldBreakStatement node)
    {
    }
    public override BoundNode VisitThrowStatement(BoundThrowStatement node)
    {
      BoundExpression ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt)
    }
    public override BoundNode VisitExpressionStatement(BoundExpressionStatement node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
    }
    public override BoundNode VisitSwitchStatement(BoundSwitchStatement node)
    {
      BoundStatement LoweredPreambleOpt = (BoundStatement)this.Visit(node.LoweredPreambleOpt)
      BoundStatement LoweredPreambleOpt = (BoundStatement)this.Visit(node.LoweredPreambleOpt)BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundStatement LoweredPreambleOpt = (BoundStatement)this.Visit(node.LoweredPreambleOpt)BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)ImmutableArray<BoundSwitchSection> SwitchSections = (ImmutableArray<BoundSwitchSection>)this.VisitList(node.SwitchSections)
    }
    public override BoundNode VisitSwitchSection(BoundSwitchSection node)
    {
      ImmutableArray<BoundSwitchLabel> SwitchLabels = (ImmutableArray<BoundSwitchLabel>)this.VisitList(node.SwitchLabels)
      ImmutableArray<BoundSwitchLabel> SwitchLabels = (ImmutableArray<BoundSwitchLabel>)this.VisitList(node.SwitchLabels)ImmutableArray<BoundStatement> Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements)
    }
    public override BoundNode VisitSwitchLabel(BoundSwitchLabel node)
    {
      BoundExpression ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt)
    }
    public override BoundNode VisitBreakStatement(BoundBreakStatement node)
    {
    }
    public override BoundNode VisitContinueStatement(BoundContinueStatement node)
    {
    }
    public override BoundNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)ImmutableArray<BoundPatternSwitchSection> SwitchSections = (ImmutableArray<BoundPatternSwitchSection>)this.VisitList(node.SwitchSections)
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)ImmutableArray<BoundPatternSwitchSection> SwitchSections = (ImmutableArray<BoundPatternSwitchSection>)this.VisitList(node.SwitchSections)BoundPatternSwitchLabel DefaultLabel = (BoundPatternSwitchLabel)this.Visit(node.DefaultLabel)
    }
    public override BoundNode VisitPatternSwitchSection(BoundPatternSwitchSection node)
    {
      ImmutableArray<BoundPatternSwitchLabel> SwitchLabels = (ImmutableArray<BoundPatternSwitchLabel>)this.VisitList(node.SwitchLabels)
      ImmutableArray<BoundPatternSwitchLabel> SwitchLabels = (ImmutableArray<BoundPatternSwitchLabel>)this.VisitList(node.SwitchLabels)ImmutableArray<BoundStatement> Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements)
    }
    public override BoundNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node)
    {
      BoundPattern Pattern = (BoundPattern)this.Visit(node.Pattern)
      BoundPattern Pattern = (BoundPattern)this.Visit(node.Pattern)BoundExpression Guard = (BoundExpression)this.Visit(node.Guard)
    }
    public override BoundNode VisitIfStatement(BoundIfStatement node)
    {
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundStatement Consequence = (BoundStatement)this.Visit(node.Consequence)
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundStatement Consequence = (BoundStatement)this.Visit(node.Consequence)BoundStatement AlternativeOpt = (BoundStatement)this.Visit(node.AlternativeOpt)
    }
    public override BoundNode VisitDoStatement(BoundDoStatement node)
    {
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitWhileStatement(BoundWhileStatement node)
    {
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitForStatement(BoundForStatement node)
    {
      BoundStatement Initializer = (BoundStatement)this.Visit(node.Initializer)
      BoundStatement Initializer = (BoundStatement)this.Visit(node.Initializer)BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)
      BoundStatement Initializer = (BoundStatement)this.Visit(node.Initializer)BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundStatement Increment = (BoundStatement)this.Visit(node.Increment)
      BoundStatement Initializer = (BoundStatement)this.Visit(node.Initializer)BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)BoundStatement Increment = (BoundStatement)this.Visit(node.Increment)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitForEachStatement(BoundForEachStatement node)
    {
      BoundTypeExpression IterationVariableType = (BoundTypeExpression)this.Visit(node.IterationVariableType)
      BoundTypeExpression IterationVariableType = (BoundTypeExpression)this.Visit(node.IterationVariableType)BoundExpression IterationErrorExpressionOpt = (BoundExpression)this.Visit(node.IterationErrorExpressionOpt)
      BoundTypeExpression IterationVariableType = (BoundTypeExpression)this.Visit(node.IterationVariableType)BoundExpression IterationErrorExpressionOpt = (BoundExpression)this.Visit(node.IterationErrorExpressionOpt)BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundTypeExpression IterationVariableType = (BoundTypeExpression)this.Visit(node.IterationVariableType)BoundExpression IterationErrorExpressionOpt = (BoundExpression)this.Visit(node.IterationErrorExpressionOpt)BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)BoundForEachDeconstructStep DeconstructionOpt = (BoundForEachDeconstructStep)this.Visit(node.DeconstructionOpt)
      BoundTypeExpression IterationVariableType = (BoundTypeExpression)this.Visit(node.IterationVariableType)BoundExpression IterationErrorExpressionOpt = (BoundExpression)this.Visit(node.IterationErrorExpressionOpt)BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)BoundForEachDeconstructStep DeconstructionOpt = (BoundForEachDeconstructStep)this.Visit(node.DeconstructionOpt)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node)
    {
      BoundDeconstructionAssignmentOperator DeconstructionAssignment = (BoundDeconstructionAssignmentOperator)this.Visit(node.DeconstructionAssignment)
      BoundDeconstructionAssignmentOperator DeconstructionAssignment = (BoundDeconstructionAssignmentOperator)this.Visit(node.DeconstructionAssignment)BoundDeconstructValuePlaceholder TargetPlaceholder = (BoundDeconstructValuePlaceholder)this.Visit(node.TargetPlaceholder)
    }
    public override BoundNode VisitUsingStatement(BoundUsingStatement node)
    {
      BoundMultipleLocalDeclarations DeclarationsOpt = (BoundMultipleLocalDeclarations)this.Visit(node.DeclarationsOpt)
      BoundMultipleLocalDeclarations DeclarationsOpt = (BoundMultipleLocalDeclarations)this.Visit(node.DeclarationsOpt)BoundExpression ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt)
      BoundMultipleLocalDeclarations DeclarationsOpt = (BoundMultipleLocalDeclarations)this.Visit(node.DeclarationsOpt)BoundExpression ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitFixedStatement(BoundFixedStatement node)
    {
      BoundMultipleLocalDeclarations Declarations = (BoundMultipleLocalDeclarations)this.Visit(node.Declarations)
      BoundMultipleLocalDeclarations Declarations = (BoundMultipleLocalDeclarations)this.Visit(node.Declarations)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitLockStatement(BoundLockStatement node)
    {
      BoundExpression Argument = (BoundExpression)this.Visit(node.Argument)
      BoundExpression Argument = (BoundExpression)this.Visit(node.Argument)BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitTryStatement(BoundTryStatement node)
    {
      BoundBlock TryBlock = (BoundBlock)this.Visit(node.TryBlock)
      BoundBlock TryBlock = (BoundBlock)this.Visit(node.TryBlock)ImmutableArray<BoundCatchBlock> CatchBlocks = (ImmutableArray<BoundCatchBlock>)this.VisitList(node.CatchBlocks)
      BoundBlock TryBlock = (BoundBlock)this.Visit(node.TryBlock)ImmutableArray<BoundCatchBlock> CatchBlocks = (ImmutableArray<BoundCatchBlock>)this.VisitList(node.CatchBlocks)BoundBlock FinallyBlockOpt = (BoundBlock)this.Visit(node.FinallyBlockOpt)
    }
    public override BoundNode VisitCatchBlock(BoundCatchBlock node)
    {
      BoundExpression ExceptionSourceOpt = (BoundExpression)this.Visit(node.ExceptionSourceOpt)
      BoundExpression ExceptionSourceOpt = (BoundExpression)this.Visit(node.ExceptionSourceOpt)BoundExpression ExceptionFilterOpt = (BoundExpression)this.Visit(node.ExceptionFilterOpt)
      BoundExpression ExceptionSourceOpt = (BoundExpression)this.Visit(node.ExceptionSourceOpt)BoundExpression ExceptionFilterOpt = (BoundExpression)this.Visit(node.ExceptionFilterOpt)BoundBlock Body = (BoundBlock)this.Visit(node.Body)
      var ExceptionTypeOpt = this.VisitType(node.ExceptionTypeOpt)
      return node.Update;(node.Locals, ExceptionSourceOpt, ExceptionTypeOpt, ExceptionFilterOpt, Body, node.IsSynthesizedAsyncCatchAll)
    }
    public override BoundNode VisitLiteral(BoundLiteral node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitThisReference(BoundThisReference node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitBaseReference(BoundBaseReference node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitLocal(BoundLocal node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.LocalSymbol, node.IsDeclaration, node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitPseudoVariable(BoundPseudoVariable node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.LocalSymbol, node.EmitExpressions, Type)
    }
    public override BoundNode VisitRangeVariable(BoundRangeVariable node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.RangeVariableSymbol, Value, Type)
    }
    public override BoundNode VisitParameter(BoundParameter node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.ParameterSymbol, Type)
    }
    public override BoundNode VisitLabelStatement(BoundLabelStatement node)
    {
    }
    public override BoundNode VisitGotoStatement(BoundGotoStatement node)
    {
      BoundExpression CaseExpressionOpt = (BoundExpression)this.Visit(node.CaseExpressionOpt)
      BoundExpression CaseExpressionOpt = (BoundExpression)this.Visit(node.CaseExpressionOpt)BoundLabel LabelExpressionOpt = (BoundLabel)this.Visit(node.LabelExpressionOpt)
    }
    public override BoundNode VisitLabeledStatement(BoundLabeledStatement node)
    {
      BoundStatement Body = (BoundStatement)this.Visit(node.Body)
    }
    public override BoundNode VisitLabel(BoundLabel node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Label, Type)
    }
    public override BoundNode VisitStatementList(BoundStatementList node)
    {
      ImmutableArray<BoundStatement> Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements)
    }
    public override BoundNode VisitConditionalGoto(BoundConditionalGoto node)
    {
      BoundExpression Condition = (BoundExpression)this.Visit(node.Condition)
    }
    public override BoundNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node)
    {
      BoundExpression Receiver = (BoundExpression)this.Visit(node.Receiver)
      var Type = this.VisitType(node.Type)
      return node.Update;(Receiver, node.TypeArgumentsOpt, node.Name, node.Invoked, node.Indexed, Type)
    }
    public override BoundNode VisitDynamicInvocation(BoundDynamicInvocation node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.ApplicableMethods, Type)
    }
    public override BoundNode VisitConditionalAccess(BoundConditionalAccess node)
    {
      BoundExpression Receiver = (BoundExpression)this.Visit(node.Receiver)
      BoundExpression Receiver = (BoundExpression)this.Visit(node.Receiver)BoundExpression AccessExpression = (BoundExpression)this.Visit(node.AccessExpression)
      var Type = this.VisitType(node.Type)
      return node.Update;(Receiver, AccessExpression, Type)
    }
    public override BoundNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node)
    {
      BoundExpression Receiver = (BoundExpression)this.Visit(node.Receiver)
      BoundExpression Receiver = (BoundExpression)this.Visit(node.Receiver)BoundExpression WhenNotNull = (BoundExpression)this.Visit(node.WhenNotNull)
      BoundExpression Receiver = (BoundExpression)this.Visit(node.Receiver)BoundExpression WhenNotNull = (BoundExpression)this.Visit(node.WhenNotNull)BoundExpression WhenNullOpt = (BoundExpression)this.Visit(node.WhenNullOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(Receiver, node.HasValueMethodOpt, WhenNotNull, WhenNullOpt, node.Id, Type)
    }
    public override BoundNode VisitConditionalReceiver(BoundConditionalReceiver node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Id, Type)
    }
    public override BoundNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node)
    {
      BoundExpression ValueTypeReceiver = (BoundExpression)this.Visit(node.ValueTypeReceiver)
      BoundExpression ValueTypeReceiver = (BoundExpression)this.Visit(node.ValueTypeReceiver)BoundExpression ReferenceTypeReceiver = (BoundExpression)this.Visit(node.ReferenceTypeReceiver)
      var Type = this.VisitType(node.Type)
      return node.Update;(ValueTypeReceiver, ReferenceTypeReceiver, Type)
    }
    public override BoundNode VisitMethodGroup(BoundMethodGroup node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.TypeArgumentsOpt, node.Name, node.Methods, node.LookupSymbolOpt, node.LookupError, node.Flags, ReceiverOpt, node.ResultKind)
    }
    public override BoundNode VisitPropertyGroup(BoundPropertyGroup node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Properties, ReceiverOpt, node.ResultKind)
    }
    public override BoundNode VisitCall(BoundCall node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(ReceiverOpt, node.Method, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.IsDelegateCall, node.Expanded, node.InvokedAsExtensionMethod, node.ArgsToParamsOpt, node.ResultKind, node.BinderOpt, Type)
    }
    public override BoundNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)BoundExpression Argument = (BoundExpression)this.Visit(node.Argument)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Event, node.IsAddition, node.IsDynamic, ReceiverOpt, Argument, Type)
    }
    public override BoundNode VisitAttribute(BoundAttribute node)
    {
      ImmutableArray<BoundExpression> ConstructorArguments = (ImmutableArray<BoundExpression>)this.VisitList(node.ConstructorArguments)
      ImmutableArray<BoundExpression> ConstructorArguments = (ImmutableArray<BoundExpression>)this.VisitList(node.ConstructorArguments)ImmutableArray<BoundExpression> NamedArguments = (ImmutableArray<BoundExpression>)this.VisitList(node.NamedArguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Constructor, ConstructorArguments, node.ConstructorArgumentNamesOpt, NamedArguments, node.ResultKind, Type)
    }
    public override BoundNode VisitObjectCreationExpression(BoundObjectCreationExpression node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)BoundObjectInitializerExpressionBase InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Constructor, node.ConstructorsGroup, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.ConstantValueOpt, InitializerExpressionOpt, node.BinderOpt, Type)
    }
    public override BoundNode VisitTupleLiteral(BoundTupleLiteral node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.ArgumentNamesOpt, node.InferredNamesOpt, Arguments, Type)
    }
    public override BoundNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var NaturalTypeOpt = this.VisitType(node.NaturalTypeOpt)
      return node.Update;(NaturalTypeOpt, Arguments, Type)
      var Type = this.VisitType(node.Type)
      return node.Update;(NaturalTypeOpt, Arguments, Type)
    }
    public override BoundNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)BoundObjectInitializerExpressionBase InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Name, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, InitializerExpressionOpt, node.ApplicableMethods, Type)
    }
    public override BoundNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node)
    {
      BoundObjectInitializerExpressionBase InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.GuidString, InitializerExpressionOpt, Type)
    }
    public override BoundNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node)
    {
      ImmutableArray<BoundExpression> Initializers = (ImmutableArray<BoundExpression>)this.VisitList(node.Initializers)
      var Type = this.VisitType(node.Type)
      return node.Update;(Initializers, Type)
    }
    public override BoundNode VisitObjectInitializerMember(BoundObjectInitializerMember node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var ReceiverType = this.VisitType(node.ReceiverType)
      return node.Update;(node.MemberSymbol, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.ResultKind, ReceiverType, node.BinderOpt, Type)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.MemberSymbol, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.ResultKind, ReceiverType, node.BinderOpt, Type)
    }
    public override BoundNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node)
    {
      var ReceiverType = this.VisitType(node.ReceiverType)
      return node.Update;(node.MemberName, ReceiverType, Type)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.MemberName, ReceiverType, Type)
    }
    public override BoundNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node)
    {
      ImmutableArray<BoundExpression> Initializers = (ImmutableArray<BoundExpression>)this.VisitList(node.Initializers)
      var Type = this.VisitType(node.Type)
      return node.Update;(Initializers, Type)
    }
    public override BoundNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)BoundExpression ImplicitReceiverOpt = (BoundExpression)this.Visit(node.ImplicitReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.AddMethod, Arguments, ImplicitReceiverOpt, node.Expanded, node.ArgsToParamsOpt, node.InvokedAsExtensionMethod, node.ResultKind, node.BinderOpt, Type)
    }
    public override BoundNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)BoundImplicitReceiver ImplicitReceiver = (BoundImplicitReceiver)this.Visit(node.ImplicitReceiver)
      var Type = this.VisitType(node.Type)
      return node.Update;(Arguments, ImplicitReceiver, node.ApplicableMethods, Type)
    }
    public override BoundNode VisitImplicitReceiver(BoundImplicitReceiver node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node)
    {
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)ImmutableArray<BoundAnonymousPropertyDeclaration> Declarations = (ImmutableArray<BoundAnonymousPropertyDeclaration>)this.VisitList(node.Declarations)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Constructor, Arguments, Declarations, Type)
    }
    public override BoundNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Property, Type)
    }
    public override BoundNode VisitNewT(BoundNewT node)
    {
      BoundObjectInitializerExpressionBase InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(InitializerExpressionOpt, Type)
    }
    public override BoundNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node)
    {
      BoundExpression Argument = (BoundExpression)this.Visit(node.Argument)
      var Type = this.VisitType(node.Type)
      return node.Update;(Argument, node.MethodOpt, node.IsExtensionMethod, Type)
    }
    public override BoundNode VisitArrayCreation(BoundArrayCreation node)
    {
      ImmutableArray<BoundExpression> Bounds = (ImmutableArray<BoundExpression>)this.VisitList(node.Bounds)
      ImmutableArray<BoundExpression> Bounds = (ImmutableArray<BoundExpression>)this.VisitList(node.Bounds)BoundArrayInitialization InitializerOpt = (BoundArrayInitialization)this.Visit(node.InitializerOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(Bounds, InitializerOpt, Type)
    }
    public override BoundNode VisitArrayInitialization(BoundArrayInitialization node)
    {
      ImmutableArray<BoundExpression> Initializers = (ImmutableArray<BoundExpression>)this.VisitList(node.Initializers)
      var Type = this.VisitType(node.Type)
      return node.Update;(Initializers)
    }
    public override BoundNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node)
    {
      BoundExpression Count = (BoundExpression)this.Visit(node.Count)
      BoundExpression Count = (BoundExpression)this.Visit(node.Count)BoundArrayInitialization InitializerOpt = (BoundArrayInitialization)this.Visit(node.InitializerOpt)
      var ElementType = this.VisitType(node.ElementType)
      return node.Update;(ElementType, Count, InitializerOpt, Type)
      var Type = this.VisitType(node.Type)
      return node.Update;(ElementType, Count, InitializerOpt, Type)
    }
    public override BoundNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node)
    {
      BoundExpression Count = (BoundExpression)this.Visit(node.Count)
      BoundExpression Count = (BoundExpression)this.Visit(node.Count)BoundArrayInitialization InitializerOpt = (BoundArrayInitialization)this.Visit(node.InitializerOpt)
      var ElementType = this.VisitType(node.ElementType)
      return node.Update;(ElementType, Count, InitializerOpt, Type)
      var Type = this.VisitType(node.Type)
      return node.Update;(ElementType, Count, InitializerOpt, Type)
    }
    public override BoundNode VisitFieldAccess(BoundFieldAccess node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(ReceiverOpt, node.FieldSymbol, node.ConstantValueOpt, node.ResultKind, node.IsByValue, node.IsDeclaration, Type)
    }
    public override BoundNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.FieldSymbol, Type)
    }
    public override BoundNode VisitPropertyAccess(BoundPropertyAccess node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(ReceiverOpt, node.PropertySymbol, node.ResultKind, Type)
    }
    public override BoundNode VisitEventAccess(BoundEventAccess node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(ReceiverOpt, node.EventSymbol, node.IsUsableAsField, node.ResultKind, Type)
    }
    public override BoundNode VisitIndexerAccess(BoundIndexerAccess node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(ReceiverOpt, node.Indexer, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.BinderOpt, node.UseSetterForDefaultArgumentGeneration, Type)
    }
    public override BoundNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)ImmutableArray<BoundExpression> Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments)
      var Type = this.VisitType(node.Type)
      return node.Update;(ReceiverOpt, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.ApplicableIndexers, Type)
    }
    public override BoundNode VisitLambda(BoundLambda node)
    {
      BoundBlock Body = (BoundBlock)this.Visit(node.Body)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Symbol, Body, node.Diagnostics, node.Binder, Type)
    }
    public override BoundNode VisitUnboundLambda(UnboundLambda node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(node.Data)
    }
    public override BoundNode VisitQueryClause(BoundQueryClause node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
      var Type = this.VisitType(node.Type)
      return node.Update;(Value, node.DefinedSymbol, node.Binder, Type)
    }
    public override BoundNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node)
    {
      ImmutableArray<BoundStatement> Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements)
    }
    public override BoundNode VisitNameOfOperator(BoundNameOfOperator node)
    {
      BoundExpression Argument = (BoundExpression)this.Visit(node.Argument)
      var Type = this.VisitType(node.Type)
      return node.Update;(Argument, node.ConstantValueOpt, Type)
    }
    public override BoundNode VisitInterpolatedString(BoundInterpolatedString node)
    {
      ImmutableArray<BoundExpression> Parts = (ImmutableArray<BoundExpression>)this.VisitList(node.Parts)
      var Type = this.VisitType(node.Type)
      return node.Update;(Parts, Type)
    }
    public override BoundNode VisitStringInsert(BoundStringInsert node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)BoundExpression Alignment = (BoundExpression)this.Visit(node.Alignment)
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)BoundExpression Alignment = (BoundExpression)this.Visit(node.Alignment)BoundLiteral Format = (BoundLiteral)this.Visit(node.Format)
      var Type = this.VisitType(node.Type)
      return node.Update;(Value, Alignment, Format, Type)
    }
    public override BoundNode VisitIsPatternExpression(BoundIsPatternExpression node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)BoundPattern Pattern = (BoundPattern)this.Visit(node.Pattern)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Pattern, Type)
    }
    public override BoundNode VisitDeclarationPattern(BoundDeclarationPattern node)
    {
      BoundExpression VariableAccess = (BoundExpression)this.Visit(node.VariableAccess)
      BoundExpression VariableAccess = (BoundExpression)this.Visit(node.VariableAccess)BoundTypeExpression DeclaredType = (BoundTypeExpression)this.Visit(node.DeclaredType)
    }
    public override BoundNode VisitConstantPattern(BoundConstantPattern node)
    {
      BoundExpression Value = (BoundExpression)this.Visit(node.Value)
    }
    public override BoundNode VisitWildcardPattern(BoundWildcardPattern node)
    {
    }
    public override BoundNode VisitDiscardExpression(BoundDiscardExpression node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;(Type)
    }
    public override BoundNode VisitThrowExpression(BoundThrowExpression node)
    {
      BoundExpression Expression = (BoundExpression)this.Visit(node.Expression)
      var Type = this.VisitType(node.Type)
      return node.Update;(Expression, Type)
    }
    public override BoundNode VisitOutVariablePendingInference(OutVariablePendingInference node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.VariableSymbol, ReceiverOpt)
    }
    public override BoundNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node)
    {
      BoundExpression ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt)
      var Type = this.VisitType(node.Type)
      return node.Update;(node.VariableSymbol, ReceiverOpt)
    }
    public override BoundNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node)
    {
      var Type = this.VisitType(node.Type)
      return node.Update;()
    }
    public override BoundNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node)
    {
      BoundBlock BlockBody = (BoundBlock)this.Visit(node.BlockBody)
      BoundBlock BlockBody = (BoundBlock)this.Visit(node.BlockBody)BoundBlock ExpressionBody = (BoundBlock)this.Visit(node.ExpressionBody)
    }
    public override BoundNode VisitConstructorMethodBody(BoundConstructorMethodBody node)
    {
      BoundExpressionStatement Initializer = (BoundExpressionStatement)this.Visit(node.Initializer)
      BoundExpressionStatement Initializer = (BoundExpressionStatement)this.Visit(node.Initializer)BoundBlock BlockBody = (BoundBlock)this.Visit(node.BlockBody)
      BoundExpressionStatement Initializer = (BoundExpressionStatement)this.Visit(node.Initializer)BoundBlock BlockBody = (BoundBlock)this.Visit(node.BlockBody)BoundBlock ExpressionBody = (BoundBlock)this.Visit(node.ExpressionBody)
    }
  }
  internal sealed class BoundTreeDumperNodeProducer{
    private BoundTreeDumperNodeProducer()
    {
      public static TreeDumperNode MakeTree(BoundNode node)
       => (new BoundTreeDumperNodeProducer()).Visit(node, null)
    }
    public override TreeDumperNode VisitFieldEqualsValue(BoundFieldEqualsValue node, object arg)
    {
      return new TreeDumperNode("FieldEqualsValue", null, new TreeDumperNode[]{
        new TreeDumperNode("Field", node.Field, null),new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) })      });
    }
    public override TreeDumperNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node, object arg)
    {
      return new TreeDumperNode("PropertyEqualsValue", null, new TreeDumperNode[]{
        new TreeDumperNode("Property", node.Property, null),new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) })      });
    }
    public override TreeDumperNode VisitParameterEqualsValue(BoundParameterEqualsValue node, object arg)
    {
      return new TreeDumperNode("ParameterEqualsValue", null, new TreeDumperNode[]{
        new TreeDumperNode("Parameter", node.Parameter, null),new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) })      });
    }
    public override TreeDumperNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node, object arg)
    {
      return new TreeDumperNode("GlobalStatementInitializer", null, new TreeDumperNode[]{
        new TreeDumperNode("Statement", null, new TreeDumperNode[] { Visit(node.Statement, null) })      });
    }
    public override TreeDumperNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node, object arg)
    {
      return new TreeDumperNode("DeconstructValuePlaceholder", null, new TreeDumperNode[]{
        new TreeDumperNode("ValEscape", node.ValEscape, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node, object arg)
    {
      return new TreeDumperNode("TupleOperandPlaceholder", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDup(BoundDup node, object arg)
    {
      return new TreeDumperNode("Dup", null, new TreeDumperNode[]{
        new TreeDumperNode("RefKind", node.RefKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPassByCopy(BoundPassByCopy node, object arg)
    {
      return new TreeDumperNode("PassByCopy", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitBadExpression(BoundBadExpression node, object arg)
    {
      return new TreeDumperNode("BadExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Symbols", node.Symbols, null),new TreeDumperNode("ChildBoundNodes", null, from x in node.ChildBoundNodes select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitBadStatement(BoundBadStatement node, object arg)
    {
      return new TreeDumperNode("BadStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("ChildBoundNodes", null, from x in node.ChildBoundNodes select Visit(x, null))      });
    }
    public override TreeDumperNode VisitTypeExpression(BoundTypeExpression node, object arg)
    {
      return new TreeDumperNode("TypeExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("AliasOpt", node.AliasOpt, null),new TreeDumperNode("InferredType", node.InferredType, null),new TreeDumperNode("BoundContainingTypeOpt", null, new TreeDumperNode[] { Visit(node.BoundContainingTypeOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node, object arg)
    {
      return new TreeDumperNode("TypeOrValueExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Data", node.Data, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitNamespaceExpression(BoundNamespaceExpression node, object arg)
    {
      return new TreeDumperNode("NamespaceExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("NamespaceSymbol", node.NamespaceSymbol, null),new TreeDumperNode("AliasOpt", node.AliasOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitUnaryOperator(BoundUnaryOperator node, object arg)
    {
      return new TreeDumperNode("UnaryOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("OperatorKind", node.OperatorKind, null),new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("MethodOpt", node.MethodOpt, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitIncrementOperator(BoundIncrementOperator node, object arg)
    {
      return new TreeDumperNode("IncrementOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("OperatorKind", node.OperatorKind, null),new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("MethodOpt", node.MethodOpt, null),new TreeDumperNode("OperandConversion", node.OperandConversion, null),new TreeDumperNode("ResultConversion", node.ResultConversion, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAddressOfOperator(BoundAddressOfOperator node, object arg)
    {
      return new TreeDumperNode("AddressOfOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("IsManaged", node.IsManaged, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node, object arg)
    {
      return new TreeDumperNode("PointerIndirectionOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPointerElementAccess(BoundPointerElementAccess node, object arg)
    {
      return new TreeDumperNode("PointerElementAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Index", null, new TreeDumperNode[] { Visit(node.Index, null) }),new TreeDumperNode("Checked", node.Checked, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitRefTypeOperator(BoundRefTypeOperator node, object arg)
    {
      return new TreeDumperNode("RefTypeOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("GetTypeFromHandle", node.GetTypeFromHandle, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitMakeRefOperator(BoundMakeRefOperator node, object arg)
    {
      return new TreeDumperNode("MakeRefOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitRefValueOperator(BoundRefValueOperator node, object arg)
    {
      return new TreeDumperNode("RefValueOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitBinaryOperator(BoundBinaryOperator node, object arg)
    {
      return new TreeDumperNode("BinaryOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("OperatorKind", node.OperatorKind, null),new TreeDumperNode("Left", null, new TreeDumperNode[] { Visit(node.Left, null) }),new TreeDumperNode("Right", null, new TreeDumperNode[] { Visit(node.Right, null) }),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("MethodOpt", node.MethodOpt, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node, object arg)
    {
      return new TreeDumperNode("TupleBinaryOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Left", null, new TreeDumperNode[] { Visit(node.Left, null) }),new TreeDumperNode("Right", null, new TreeDumperNode[] { Visit(node.Right, null) }),new TreeDumperNode("ConvertedLeft", null, new TreeDumperNode[] { Visit(node.ConvertedLeft, null) }),new TreeDumperNode("ConvertedRight", null, new TreeDumperNode[] { Visit(node.ConvertedRight, null) }),new TreeDumperNode("OperatorKind", node.OperatorKind, null),new TreeDumperNode("Operators", node.Operators, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node, object arg)
    {
      return new TreeDumperNode("UserDefinedConditionalLogicalOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("OperatorKind", node.OperatorKind, null),new TreeDumperNode("Left", null, new TreeDumperNode[] { Visit(node.Left, null) }),new TreeDumperNode("Right", null, new TreeDumperNode[] { Visit(node.Right, null) }),new TreeDumperNode("LogicalOperator", node.LogicalOperator, null),new TreeDumperNode("TrueOperator", node.TrueOperator, null),new TreeDumperNode("FalseOperator", node.FalseOperator, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node, object arg)
    {
      return new TreeDumperNode("CompoundAssignmentOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operator", node.Operator, null),new TreeDumperNode("Left", null, new TreeDumperNode[] { Visit(node.Left, null) }),new TreeDumperNode("Right", null, new TreeDumperNode[] { Visit(node.Right, null) }),new TreeDumperNode("LeftConversion", node.LeftConversion, null),new TreeDumperNode("FinalConversion", node.FinalConversion, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAssignmentOperator(BoundAssignmentOperator node, object arg)
    {
      return new TreeDumperNode("AssignmentOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Left", null, new TreeDumperNode[] { Visit(node.Left, null) }),new TreeDumperNode("Right", null, new TreeDumperNode[] { Visit(node.Right, null) }),new TreeDumperNode("IsRef", node.IsRef, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node, object arg)
    {
      return new TreeDumperNode("DeconstructionAssignmentOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Left", null, new TreeDumperNode[] { Visit(node.Left, null) }),new TreeDumperNode("Right", null, new TreeDumperNode[] { Visit(node.Right, null) }),new TreeDumperNode("IsUsed", node.IsUsed, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node, object arg)
    {
      return new TreeDumperNode("NullCoalescingOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("LeftOperand", null, new TreeDumperNode[] { Visit(node.LeftOperand, null) }),new TreeDumperNode("RightOperand", null, new TreeDumperNode[] { Visit(node.RightOperand, null) }),new TreeDumperNode("LeftConversion", node.LeftConversion, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitConditionalOperator(BoundConditionalOperator node, object arg)
    {
      return new TreeDumperNode("ConditionalOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("IsRef", node.IsRef, null),new TreeDumperNode("Condition", null, new TreeDumperNode[] { Visit(node.Condition, null) }),new TreeDumperNode("Consequence", null, new TreeDumperNode[] { Visit(node.Consequence, null) }),new TreeDumperNode("Alternative", null, new TreeDumperNode[] { Visit(node.Alternative, null) }),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitArrayAccess(BoundArrayAccess node, object arg)
    {
      return new TreeDumperNode("ArrayAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Indices", null, from x in node.Indices select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitArrayLength(BoundArrayLength node, object arg)
    {
      return new TreeDumperNode("ArrayLength", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAwaitExpression(BoundAwaitExpression node, object arg)
    {
      return new TreeDumperNode("AwaitExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("GetAwaiter", node.GetAwaiter, null),new TreeDumperNode("IsCompleted", node.IsCompleted, null),new TreeDumperNode("GetResult", node.GetResult, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitTypeOfOperator(BoundTypeOfOperator node, object arg)
    {
      return new TreeDumperNode("TypeOfOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("SourceType", null, new TreeDumperNode[] { Visit(node.SourceType, null) }),new TreeDumperNode("GetTypeFromHandle", node.GetTypeFromHandle, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitMethodDefIndex(BoundMethodDefIndex node, object arg)
    {
      return new TreeDumperNode("MethodDefIndex", null, new TreeDumperNode[]{
        new TreeDumperNode("Method", node.Method, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node, object arg)
    {
      return new TreeDumperNode("MaximumMethodDefIndex", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node, object arg)
    {
      return new TreeDumperNode("InstrumentationPayloadRoot", null, new TreeDumperNode[]{
        new TreeDumperNode("AnalysisKind", node.AnalysisKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitModuleVersionId(BoundModuleVersionId node, object arg)
    {
      return new TreeDumperNode("ModuleVersionId", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitModuleVersionIdString(BoundModuleVersionIdString node, object arg)
    {
      return new TreeDumperNode("ModuleVersionIdString", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node, object arg)
    {
      return new TreeDumperNode("SourceDocumentIndex", null, new TreeDumperNode[]{
        new TreeDumperNode("Document", node.Document, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitMethodInfo(BoundMethodInfo node, object arg)
    {
      return new TreeDumperNode("MethodInfo", null, new TreeDumperNode[]{
        new TreeDumperNode("Method", node.Method, null),new TreeDumperNode("GetMethodFromHandle", node.GetMethodFromHandle, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitFieldInfo(BoundFieldInfo node, object arg)
    {
      return new TreeDumperNode("FieldInfo", null, new TreeDumperNode[]{
        new TreeDumperNode("Field", node.Field, null),new TreeDumperNode("GetFieldFromHandle", node.GetFieldFromHandle, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDefaultExpression(BoundDefaultExpression node, object arg)
    {
      return new TreeDumperNode("DefaultExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitIsOperator(BoundIsOperator node, object arg)
    {
      return new TreeDumperNode("IsOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("TargetType", null, new TreeDumperNode[] { Visit(node.TargetType, null) }),new TreeDumperNode("Conversion", node.Conversion, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAsOperator(BoundAsOperator node, object arg)
    {
      return new TreeDumperNode("AsOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("TargetType", null, new TreeDumperNode[] { Visit(node.TargetType, null) }),new TreeDumperNode("Conversion", node.Conversion, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitSizeOfOperator(BoundSizeOfOperator node, object arg)
    {
      return new TreeDumperNode("SizeOfOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("SourceType", null, new TreeDumperNode[] { Visit(node.SourceType, null) }),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitConversion(BoundConversion node, object arg)
    {
      return new TreeDumperNode("Conversion", null, new TreeDumperNode[]{
        new TreeDumperNode("Operand", null, new TreeDumperNode[] { Visit(node.Operand, null) }),new TreeDumperNode("Conversion", node.Conversion, null),new TreeDumperNode("IsBaseConversion", node.IsBaseConversion, null),new TreeDumperNode("Checked", node.Checked, null),new TreeDumperNode("ExplicitCastInCode", node.ExplicitCastInCode, null),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitArgList(BoundArgList node, object arg)
    {
      return new TreeDumperNode("ArgList", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitArgListOperator(BoundArgListOperator node, object arg)
    {
      return new TreeDumperNode("ArgListOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node, object arg)
    {
      return new TreeDumperNode("FixedLocalCollectionInitializer", null, new TreeDumperNode[]{
        new TreeDumperNode("ElementPointerType", node.ElementPointerType, null),new TreeDumperNode("ElementPointerTypeConversion", node.ElementPointerTypeConversion, null),new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("GetPinnableOpt", node.GetPinnableOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitSequencePoint(BoundSequencePoint node, object arg)
    {
      return new TreeDumperNode("SequencePoint", null, new TreeDumperNode[]{
        new TreeDumperNode("StatementOpt", null, new TreeDumperNode[] { Visit(node.StatementOpt, null) })      });
    }
    public override TreeDumperNode VisitSequencePointExpression(BoundSequencePointExpression node, object arg)
    {
      return new TreeDumperNode("SequencePointExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node, object arg)
    {
      return new TreeDumperNode("SequencePointWithSpan", null, new TreeDumperNode[]{
        new TreeDumperNode("StatementOpt", null, new TreeDumperNode[] { Visit(node.StatementOpt, null) }),new TreeDumperNode("Span", node.Span, null)      });
    }
    public override TreeDumperNode VisitBlock(BoundBlock node, object arg)
    {
      return new TreeDumperNode("Block", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("LocalFunctions", node.LocalFunctions, null),new TreeDumperNode("Statements", null, from x in node.Statements select Visit(x, null))      });
    }
    public override TreeDumperNode VisitScope(BoundScope node, object arg)
    {
      return new TreeDumperNode("Scope", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Statements", null, from x in node.Statements select Visit(x, null))      });
    }
    public override TreeDumperNode VisitStateMachineScope(BoundStateMachineScope node, object arg)
    {
      return new TreeDumperNode("StateMachineScope", null, new TreeDumperNode[]{
        new TreeDumperNode("Fields", node.Fields, null),new TreeDumperNode("Statement", null, new TreeDumperNode[] { Visit(node.Statement, null) })      });
    }
    public override TreeDumperNode VisitLocalDeclaration(BoundLocalDeclaration node, object arg)
    {
      return new TreeDumperNode("LocalDeclaration", null, new TreeDumperNode[]{
        new TreeDumperNode("LocalSymbol", node.LocalSymbol, null),new TreeDumperNode("DeclaredType", null, new TreeDumperNode[] { Visit(node.DeclaredType, null) }),new TreeDumperNode("InitializerOpt", null, new TreeDumperNode[] { Visit(node.InitializerOpt, null) }),new TreeDumperNode("ArgumentsOpt", null, node.ArgumentsOpt.IsDefault ? Array.Empty<TreeDumperNode>() : from x in node.ArgumentsOpt select Visit(x, null))      });
    }
    public override TreeDumperNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node, object arg)
    {
      return new TreeDumperNode("MultipleLocalDeclarations", null, new TreeDumperNode[]{
        new TreeDumperNode("LocalDeclarations", null, from x in node.LocalDeclarations select Visit(x, null))      });
    }
    public override TreeDumperNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node, object arg)
    {
      return new TreeDumperNode("LocalFunctionStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Symbol", node.Symbol, null),new TreeDumperNode("BlockBody", null, new TreeDumperNode[] { Visit(node.BlockBody, null) }),new TreeDumperNode("ExpressionBody", null, new TreeDumperNode[] { Visit(node.ExpressionBody, null) })      });
    }
    public override TreeDumperNode VisitSequence(BoundSequence node, object arg)
    {
      return new TreeDumperNode("Sequence", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("SideEffects", null, from x in node.SideEffects select Visit(x, null)),new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitNoOpStatement(BoundNoOpStatement node, object arg)
    {
      return new TreeDumperNode("NoOpStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Flavor", node.Flavor, null)      });
    }
    public override TreeDumperNode VisitReturnStatement(BoundReturnStatement node, object arg)
    {
      return new TreeDumperNode("ReturnStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("RefKind", node.RefKind, null),new TreeDumperNode("ExpressionOpt", null, new TreeDumperNode[] { Visit(node.ExpressionOpt, null) })      });
    }
    public override TreeDumperNode VisitYieldReturnStatement(BoundYieldReturnStatement node, object arg)
    {
      return new TreeDumperNode("YieldReturnStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) })      });
    }
    public override TreeDumperNode VisitYieldBreakStatement(BoundYieldBreakStatement node, object arg)
    {
      return new TreeDumperNode("YieldBreakStatement", null, Array.Empty<TreeDumperNode>());
    }
    public override TreeDumperNode VisitThrowStatement(BoundThrowStatement node, object arg)
    {
      return new TreeDumperNode("ThrowStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("ExpressionOpt", null, new TreeDumperNode[] { Visit(node.ExpressionOpt, null) })      });
    }
    public override TreeDumperNode VisitExpressionStatement(BoundExpressionStatement node, object arg)
    {
      return new TreeDumperNode("ExpressionStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) })      });
    }
    public override TreeDumperNode VisitSwitchStatement(BoundSwitchStatement node, object arg)
    {
      return new TreeDumperNode("SwitchStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("LoweredPreambleOpt", null, new TreeDumperNode[] { Visit(node.LoweredPreambleOpt, null) }),new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("ConstantTargetOpt", node.ConstantTargetOpt, null),new TreeDumperNode("InnerLocals", node.InnerLocals, null),new TreeDumperNode("InnerLocalFunctions", node.InnerLocalFunctions, null),new TreeDumperNode("SwitchSections", null, from x in node.SwitchSections select Visit(x, null)),new TreeDumperNode("BreakLabel", node.BreakLabel, null),new TreeDumperNode("StringEquality", node.StringEquality, null)      });
    }
    public override TreeDumperNode VisitSwitchSection(BoundSwitchSection node, object arg)
    {
      return new TreeDumperNode("SwitchSection", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("SwitchLabels", null, from x in node.SwitchLabels select Visit(x, null)),new TreeDumperNode("Statements", null, from x in node.Statements select Visit(x, null))      });
    }
    public override TreeDumperNode VisitSwitchLabel(BoundSwitchLabel node, object arg)
    {
      return new TreeDumperNode("SwitchLabel", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null),new TreeDumperNode("ExpressionOpt", null, new TreeDumperNode[] { Visit(node.ExpressionOpt, null) }),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null)      });
    }
    public override TreeDumperNode VisitBreakStatement(BoundBreakStatement node, object arg)
    {
      return new TreeDumperNode("BreakStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null)      });
    }
    public override TreeDumperNode VisitContinueStatement(BoundContinueStatement node, object arg)
    {
      return new TreeDumperNode("ContinueStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null)      });
    }
    public override TreeDumperNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node, object arg)
    {
      return new TreeDumperNode("PatternSwitchStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("SomeLabelAlwaysMatches", node.SomeLabelAlwaysMatches, null),new TreeDumperNode("InnerLocals", node.InnerLocals, null),new TreeDumperNode("InnerLocalFunctions", node.InnerLocalFunctions, null),new TreeDumperNode("SwitchSections", null, from x in node.SwitchSections select Visit(x, null)),new TreeDumperNode("DefaultLabel", null, new TreeDumperNode[] { Visit(node.DefaultLabel, null) }),new TreeDumperNode("BreakLabel", node.BreakLabel, null),new TreeDumperNode("Binder", node.Binder, null),new TreeDumperNode("IsComplete", node.IsComplete, null)      });
    }
    public override TreeDumperNode VisitPatternSwitchSection(BoundPatternSwitchSection node, object arg)
    {
      return new TreeDumperNode("PatternSwitchSection", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("SwitchLabels", null, from x in node.SwitchLabels select Visit(x, null)),new TreeDumperNode("Statements", null, from x in node.Statements select Visit(x, null))      });
    }
    public override TreeDumperNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node, object arg)
    {
      return new TreeDumperNode("PatternSwitchLabel", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null),new TreeDumperNode("Pattern", null, new TreeDumperNode[] { Visit(node.Pattern, null) }),new TreeDumperNode("Guard", null, new TreeDumperNode[] { Visit(node.Guard, null) }),new TreeDumperNode("IsReachable", node.IsReachable, null)      });
    }
    public override TreeDumperNode VisitIfStatement(BoundIfStatement node, object arg)
    {
      return new TreeDumperNode("IfStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Condition", null, new TreeDumperNode[] { Visit(node.Condition, null) }),new TreeDumperNode("Consequence", null, new TreeDumperNode[] { Visit(node.Consequence, null) }),new TreeDumperNode("AlternativeOpt", null, new TreeDumperNode[] { Visit(node.AlternativeOpt, null) })      });
    }
    public override TreeDumperNode VisitDoStatement(BoundDoStatement node, object arg)
    {
      return new TreeDumperNode("DoStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Condition", null, new TreeDumperNode[] { Visit(node.Condition, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) }),new TreeDumperNode("BreakLabel", node.BreakLabel, null),new TreeDumperNode("ContinueLabel", node.ContinueLabel, null)      });
    }
    public override TreeDumperNode VisitWhileStatement(BoundWhileStatement node, object arg)
    {
      return new TreeDumperNode("WhileStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Condition", null, new TreeDumperNode[] { Visit(node.Condition, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) }),new TreeDumperNode("BreakLabel", node.BreakLabel, null),new TreeDumperNode("ContinueLabel", node.ContinueLabel, null)      });
    }
    public override TreeDumperNode VisitForStatement(BoundForStatement node, object arg)
    {
      return new TreeDumperNode("ForStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("OuterLocals", node.OuterLocals, null),new TreeDumperNode("Initializer", null, new TreeDumperNode[] { Visit(node.Initializer, null) }),new TreeDumperNode("InnerLocals", node.InnerLocals, null),new TreeDumperNode("Condition", null, new TreeDumperNode[] { Visit(node.Condition, null) }),new TreeDumperNode("Increment", null, new TreeDumperNode[] { Visit(node.Increment, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) }),new TreeDumperNode("BreakLabel", node.BreakLabel, null),new TreeDumperNode("ContinueLabel", node.ContinueLabel, null)      });
    }
    public override TreeDumperNode VisitForEachStatement(BoundForEachStatement node, object arg)
    {
      return new TreeDumperNode("ForEachStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("EnumeratorInfoOpt", node.EnumeratorInfoOpt, null),new TreeDumperNode("ElementConversion", node.ElementConversion, null),new TreeDumperNode("IterationVariableType", null, new TreeDumperNode[] { Visit(node.IterationVariableType, null) }),new TreeDumperNode("IterationVariables", node.IterationVariables, null),new TreeDumperNode("IterationErrorExpressionOpt", null, new TreeDumperNode[] { Visit(node.IterationErrorExpressionOpt, null) }),new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("DeconstructionOpt", null, new TreeDumperNode[] { Visit(node.DeconstructionOpt, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) }),new TreeDumperNode("Checked", node.Checked, null),new TreeDumperNode("BreakLabel", node.BreakLabel, null),new TreeDumperNode("ContinueLabel", node.ContinueLabel, null)      });
    }
    public override TreeDumperNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node, object arg)
    {
      return new TreeDumperNode("ForEachDeconstructStep", null, new TreeDumperNode[]{
        new TreeDumperNode("DeconstructionAssignment", null, new TreeDumperNode[] { Visit(node.DeconstructionAssignment, null) }),new TreeDumperNode("TargetPlaceholder", null, new TreeDumperNode[] { Visit(node.TargetPlaceholder, null) })      });
    }
    public override TreeDumperNode VisitUsingStatement(BoundUsingStatement node, object arg)
    {
      return new TreeDumperNode("UsingStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("DeclarationsOpt", null, new TreeDumperNode[] { Visit(node.DeclarationsOpt, null) }),new TreeDumperNode("ExpressionOpt", null, new TreeDumperNode[] { Visit(node.ExpressionOpt, null) }),new TreeDumperNode("IDisposableConversion", node.IDisposableConversion, null),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) })      });
    }
    public override TreeDumperNode VisitFixedStatement(BoundFixedStatement node, object arg)
    {
      return new TreeDumperNode("FixedStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Declarations", null, new TreeDumperNode[] { Visit(node.Declarations, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) })      });
    }
    public override TreeDumperNode VisitLockStatement(BoundLockStatement node, object arg)
    {
      return new TreeDumperNode("LockStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Argument", null, new TreeDumperNode[] { Visit(node.Argument, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) })      });
    }
    public override TreeDumperNode VisitTryStatement(BoundTryStatement node, object arg)
    {
      return new TreeDumperNode("TryStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("TryBlock", null, new TreeDumperNode[] { Visit(node.TryBlock, null) }),new TreeDumperNode("CatchBlocks", null, from x in node.CatchBlocks select Visit(x, null)),new TreeDumperNode("FinallyBlockOpt", null, new TreeDumperNode[] { Visit(node.FinallyBlockOpt, null) }),new TreeDumperNode("PreferFaultHandler", node.PreferFaultHandler, null)      });
    }
    public override TreeDumperNode VisitCatchBlock(BoundCatchBlock node, object arg)
    {
      return new TreeDumperNode("CatchBlock", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("ExceptionSourceOpt", null, new TreeDumperNode[] { Visit(node.ExceptionSourceOpt, null) }),new TreeDumperNode("ExceptionTypeOpt", node.ExceptionTypeOpt, null),new TreeDumperNode("ExceptionFilterOpt", null, new TreeDumperNode[] { Visit(node.ExceptionFilterOpt, null) }),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) }),new TreeDumperNode("IsSynthesizedAsyncCatchAll", node.IsSynthesizedAsyncCatchAll, null)      });
    }
    public override TreeDumperNode VisitLiteral(BoundLiteral node, object arg)
    {
      return new TreeDumperNode("Literal", null, new TreeDumperNode[]{
        new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitThisReference(BoundThisReference node, object arg)
    {
      return new TreeDumperNode("ThisReference", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node, object arg)
    {
      return new TreeDumperNode("PreviousSubmissionReference", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node, object arg)
    {
      return new TreeDumperNode("HostObjectMemberReference", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitBaseReference(BoundBaseReference node, object arg)
    {
      return new TreeDumperNode("BaseReference", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitLocal(BoundLocal node, object arg)
    {
      return new TreeDumperNode("Local", null, new TreeDumperNode[]{
        new TreeDumperNode("LocalSymbol", node.LocalSymbol, null),new TreeDumperNode("IsDeclaration", node.IsDeclaration, null),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPseudoVariable(BoundPseudoVariable node, object arg)
    {
      return new TreeDumperNode("PseudoVariable", null, new TreeDumperNode[]{
        new TreeDumperNode("LocalSymbol", node.LocalSymbol, null),new TreeDumperNode("EmitExpressions", node.EmitExpressions, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitRangeVariable(BoundRangeVariable node, object arg)
    {
      return new TreeDumperNode("RangeVariable", null, new TreeDumperNode[]{
        new TreeDumperNode("RangeVariableSymbol", node.RangeVariableSymbol, null),new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitParameter(BoundParameter node, object arg)
    {
      return new TreeDumperNode("Parameter", null, new TreeDumperNode[]{
        new TreeDumperNode("ParameterSymbol", node.ParameterSymbol, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitLabelStatement(BoundLabelStatement node, object arg)
    {
      return new TreeDumperNode("LabelStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null)      });
    }
    public override TreeDumperNode VisitGotoStatement(BoundGotoStatement node, object arg)
    {
      return new TreeDumperNode("GotoStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null),new TreeDumperNode("CaseExpressionOpt", null, new TreeDumperNode[] { Visit(node.CaseExpressionOpt, null) }),new TreeDumperNode("LabelExpressionOpt", null, new TreeDumperNode[] { Visit(node.LabelExpressionOpt, null) })      });
    }
    public override TreeDumperNode VisitLabeledStatement(BoundLabeledStatement node, object arg)
    {
      return new TreeDumperNode("LabeledStatement", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) })      });
    }
    public override TreeDumperNode VisitLabel(BoundLabel node, object arg)
    {
      return new TreeDumperNode("Label", null, new TreeDumperNode[]{
        new TreeDumperNode("Label", node.Label, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitStatementList(BoundStatementList node, object arg)
    {
      return new TreeDumperNode("StatementList", null, new TreeDumperNode[]{
        new TreeDumperNode("Statements", null, from x in node.Statements select Visit(x, null))      });
    }
    public override TreeDumperNode VisitConditionalGoto(BoundConditionalGoto node, object arg)
    {
      return new TreeDumperNode("ConditionalGoto", null, new TreeDumperNode[]{
        new TreeDumperNode("Condition", null, new TreeDumperNode[] { Visit(node.Condition, null) }),new TreeDumperNode("JumpIfTrue", node.JumpIfTrue, null),new TreeDumperNode("Label", node.Label, null)      });
    }
    public override TreeDumperNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node, object arg)
    {
      return new TreeDumperNode("DynamicMemberAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("Receiver", null, new TreeDumperNode[] { Visit(node.Receiver, null) }),new TreeDumperNode("TypeArgumentsOpt", node.TypeArgumentsOpt, null),new TreeDumperNode("Name", node.Name, null),new TreeDumperNode("Invoked", node.Invoked, null),new TreeDumperNode("Indexed", node.Indexed, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDynamicInvocation(BoundDynamicInvocation node, object arg)
    {
      return new TreeDumperNode("DynamicInvocation", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("ApplicableMethods", node.ApplicableMethods, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitConditionalAccess(BoundConditionalAccess node, object arg)
    {
      return new TreeDumperNode("ConditionalAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("Receiver", null, new TreeDumperNode[] { Visit(node.Receiver, null) }),new TreeDumperNode("AccessExpression", null, new TreeDumperNode[] { Visit(node.AccessExpression, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node, object arg)
    {
      return new TreeDumperNode("LoweredConditionalAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("Receiver", null, new TreeDumperNode[] { Visit(node.Receiver, null) }),new TreeDumperNode("HasValueMethodOpt", node.HasValueMethodOpt, null),new TreeDumperNode("WhenNotNull", null, new TreeDumperNode[] { Visit(node.WhenNotNull, null) }),new TreeDumperNode("WhenNullOpt", null, new TreeDumperNode[] { Visit(node.WhenNullOpt, null) }),new TreeDumperNode("Id", node.Id, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitConditionalReceiver(BoundConditionalReceiver node, object arg)
    {
      return new TreeDumperNode("ConditionalReceiver", null, new TreeDumperNode[]{
        new TreeDumperNode("Id", node.Id, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node, object arg)
    {
      return new TreeDumperNode("ComplexConditionalReceiver", null, new TreeDumperNode[]{
        new TreeDumperNode("ValueTypeReceiver", null, new TreeDumperNode[] { Visit(node.ValueTypeReceiver, null) }),new TreeDumperNode("ReferenceTypeReceiver", null, new TreeDumperNode[] { Visit(node.ReferenceTypeReceiver, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitMethodGroup(BoundMethodGroup node, object arg)
    {
      return new TreeDumperNode("MethodGroup", null, new TreeDumperNode[]{
        new TreeDumperNode("TypeArgumentsOpt", node.TypeArgumentsOpt, null),new TreeDumperNode("Name", node.Name, null),new TreeDumperNode("Methods", node.Methods, null),new TreeDumperNode("LookupSymbolOpt", node.LookupSymbolOpt, null),new TreeDumperNode("LookupError", node.LookupError, null),new TreeDumperNode("Flags", node.Flags, null),new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPropertyGroup(BoundPropertyGroup node, object arg)
    {
      return new TreeDumperNode("PropertyGroup", null, new TreeDumperNode[]{
        new TreeDumperNode("Properties", node.Properties, null),new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitCall(BoundCall node, object arg)
    {
      return new TreeDumperNode("Call", null, new TreeDumperNode[]{
        new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("Method", node.Method, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("IsDelegateCall", node.IsDelegateCall, null),new TreeDumperNode("Expanded", node.Expanded, null),new TreeDumperNode("InvokedAsExtensionMethod", node.InvokedAsExtensionMethod, null),new TreeDumperNode("ArgsToParamsOpt", node.ArgsToParamsOpt, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("BinderOpt", node.BinderOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node, object arg)
    {
      return new TreeDumperNode("EventAssignmentOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Event", node.Event, null),new TreeDumperNode("IsAddition", node.IsAddition, null),new TreeDumperNode("IsDynamic", node.IsDynamic, null),new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("Argument", null, new TreeDumperNode[] { Visit(node.Argument, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAttribute(BoundAttribute node, object arg)
    {
      return new TreeDumperNode("Attribute", null, new TreeDumperNode[]{
        new TreeDumperNode("Constructor", node.Constructor, null),new TreeDumperNode("ConstructorArguments", null, from x in node.ConstructorArguments select Visit(x, null)),new TreeDumperNode("ConstructorArgumentNamesOpt", node.ConstructorArgumentNamesOpt, null),new TreeDumperNode("NamedArguments", null, from x in node.NamedArguments select Visit(x, null)),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitObjectCreationExpression(BoundObjectCreationExpression node, object arg)
    {
      return new TreeDumperNode("ObjectCreationExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Constructor", node.Constructor, null),new TreeDumperNode("ConstructorsGroup", node.ConstructorsGroup, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("Expanded", node.Expanded, null),new TreeDumperNode("ArgsToParamsOpt", node.ArgsToParamsOpt, null),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("InitializerExpressionOpt", null, new TreeDumperNode[] { Visit(node.InitializerExpressionOpt, null) }),new TreeDumperNode("BinderOpt", node.BinderOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitTupleLiteral(BoundTupleLiteral node, object arg)
    {
      return new TreeDumperNode("TupleLiteral", null, new TreeDumperNode[]{
        new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("InferredNamesOpt", node.InferredNamesOpt, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node, object arg)
    {
      return new TreeDumperNode("ConvertedTupleLiteral", null, new TreeDumperNode[]{
        new TreeDumperNode("NaturalTypeOpt", node.NaturalTypeOpt, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node, object arg)
    {
      return new TreeDumperNode("DynamicObjectCreationExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Name", node.Name, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("InitializerExpressionOpt", null, new TreeDumperNode[] { Visit(node.InitializerExpressionOpt, null) }),new TreeDumperNode("ApplicableMethods", node.ApplicableMethods, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node, object arg)
    {
      return new TreeDumperNode("NoPiaObjectCreationExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("GuidString", node.GuidString, null),new TreeDumperNode("InitializerExpressionOpt", null, new TreeDumperNode[] { Visit(node.InitializerExpressionOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node, object arg)
    {
      return new TreeDumperNode("ObjectInitializerExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Initializers", null, from x in node.Initializers select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitObjectInitializerMember(BoundObjectInitializerMember node, object arg)
    {
      return new TreeDumperNode("ObjectInitializerMember", null, new TreeDumperNode[]{
        new TreeDumperNode("MemberSymbol", node.MemberSymbol, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("Expanded", node.Expanded, null),new TreeDumperNode("ArgsToParamsOpt", node.ArgsToParamsOpt, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("ReceiverType", node.ReceiverType, null),new TreeDumperNode("BinderOpt", node.BinderOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node, object arg)
    {
      return new TreeDumperNode("DynamicObjectInitializerMember", null, new TreeDumperNode[]{
        new TreeDumperNode("MemberName", node.MemberName, null),new TreeDumperNode("ReceiverType", node.ReceiverType, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node, object arg)
    {
      return new TreeDumperNode("CollectionInitializerExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Initializers", null, from x in node.Initializers select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node, object arg)
    {
      return new TreeDumperNode("CollectionElementInitializer", null, new TreeDumperNode[]{
        new TreeDumperNode("AddMethod", node.AddMethod, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ImplicitReceiverOpt", null, new TreeDumperNode[] { Visit(node.ImplicitReceiverOpt, null) }),new TreeDumperNode("Expanded", node.Expanded, null),new TreeDumperNode("ArgsToParamsOpt", node.ArgsToParamsOpt, null),new TreeDumperNode("InvokedAsExtensionMethod", node.InvokedAsExtensionMethod, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("BinderOpt", node.BinderOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node, object arg)
    {
      return new TreeDumperNode("DynamicCollectionElementInitializer", null, new TreeDumperNode[]{
        new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ImplicitReceiver", null, new TreeDumperNode[] { Visit(node.ImplicitReceiver, null) }),new TreeDumperNode("ApplicableMethods", node.ApplicableMethods, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitImplicitReceiver(BoundImplicitReceiver node, object arg)
    {
      return new TreeDumperNode("ImplicitReceiver", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node, object arg)
    {
      return new TreeDumperNode("AnonymousObjectCreationExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Constructor", node.Constructor, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("Declarations", null, from x in node.Declarations select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node, object arg)
    {
      return new TreeDumperNode("AnonymousPropertyDeclaration", null, new TreeDumperNode[]{
        new TreeDumperNode("Property", node.Property, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitNewT(BoundNewT node, object arg)
    {
      return new TreeDumperNode("NewT", null, new TreeDumperNode[]{
        new TreeDumperNode("InitializerExpressionOpt", null, new TreeDumperNode[] { Visit(node.InitializerExpressionOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node, object arg)
    {
      return new TreeDumperNode("DelegateCreationExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Argument", null, new TreeDumperNode[] { Visit(node.Argument, null) }),new TreeDumperNode("MethodOpt", node.MethodOpt, null),new TreeDumperNode("IsExtensionMethod", node.IsExtensionMethod, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitArrayCreation(BoundArrayCreation node, object arg)
    {
      return new TreeDumperNode("ArrayCreation", null, new TreeDumperNode[]{
        new TreeDumperNode("Bounds", null, from x in node.Bounds select Visit(x, null)),new TreeDumperNode("InitializerOpt", null, new TreeDumperNode[] { Visit(node.InitializerOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitArrayInitialization(BoundArrayInitialization node, object arg)
    {
      return new TreeDumperNode("ArrayInitialization", null, new TreeDumperNode[]{
        new TreeDumperNode("Initializers", null, from x in node.Initializers select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node, object arg)
    {
      return new TreeDumperNode("StackAllocArrayCreation", null, new TreeDumperNode[]{
        new TreeDumperNode("ElementType", node.ElementType, null),new TreeDumperNode("Count", null, new TreeDumperNode[] { Visit(node.Count, null) }),new TreeDumperNode("InitializerOpt", null, new TreeDumperNode[] { Visit(node.InitializerOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node, object arg)
    {
      return new TreeDumperNode("ConvertedStackAllocExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("ElementType", node.ElementType, null),new TreeDumperNode("Count", null, new TreeDumperNode[] { Visit(node.Count, null) }),new TreeDumperNode("InitializerOpt", null, new TreeDumperNode[] { Visit(node.InitializerOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitFieldAccess(BoundFieldAccess node, object arg)
    {
      return new TreeDumperNode("FieldAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("FieldSymbol", node.FieldSymbol, null),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("IsByValue", node.IsByValue, null),new TreeDumperNode("IsDeclaration", node.IsDeclaration, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node, object arg)
    {
      return new TreeDumperNode("HoistedFieldAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("FieldSymbol", node.FieldSymbol, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitPropertyAccess(BoundPropertyAccess node, object arg)
    {
      return new TreeDumperNode("PropertyAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("PropertySymbol", node.PropertySymbol, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitEventAccess(BoundEventAccess node, object arg)
    {
      return new TreeDumperNode("EventAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("EventSymbol", node.EventSymbol, null),new TreeDumperNode("IsUsableAsField", node.IsUsableAsField, null),new TreeDumperNode("ResultKind", node.ResultKind, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitIndexerAccess(BoundIndexerAccess node, object arg)
    {
      return new TreeDumperNode("IndexerAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("Indexer", node.Indexer, null),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("Expanded", node.Expanded, null),new TreeDumperNode("ArgsToParamsOpt", node.ArgsToParamsOpt, null),new TreeDumperNode("BinderOpt", node.BinderOpt, null),new TreeDumperNode("UseSetterForDefaultArgumentGeneration", node.UseSetterForDefaultArgumentGeneration, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node, object arg)
    {
      return new TreeDumperNode("DynamicIndexerAccess", null, new TreeDumperNode[]{
        new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("Arguments", null, from x in node.Arguments select Visit(x, null)),new TreeDumperNode("ArgumentNamesOpt", node.ArgumentNamesOpt, null),new TreeDumperNode("ArgumentRefKindsOpt", node.ArgumentRefKindsOpt, null),new TreeDumperNode("ApplicableIndexers", node.ApplicableIndexers, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitLambda(BoundLambda node, object arg)
    {
      return new TreeDumperNode("Lambda", null, new TreeDumperNode[]{
        new TreeDumperNode("Symbol", node.Symbol, null),new TreeDumperNode("Body", null, new TreeDumperNode[] { Visit(node.Body, null) }),new TreeDumperNode("Diagnostics", node.Diagnostics, null),new TreeDumperNode("Binder", node.Binder, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitUnboundLambda(UnboundLambda node, object arg)
    {
      return new TreeDumperNode("UnboundLambda", null, new TreeDumperNode[]{
        new TreeDumperNode("Data", node.Data, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitQueryClause(BoundQueryClause node, object arg)
    {
      return new TreeDumperNode("QueryClause", null, new TreeDumperNode[]{
        new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) }),new TreeDumperNode("DefinedSymbol", node.DefinedSymbol, null),new TreeDumperNode("Binder", node.Binder, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node, object arg)
    {
      return new TreeDumperNode("TypeOrInstanceInitializers", null, new TreeDumperNode[]{
        new TreeDumperNode("Statements", null, from x in node.Statements select Visit(x, null))      });
    }
    public override TreeDumperNode VisitNameOfOperator(BoundNameOfOperator node, object arg)
    {
      return new TreeDumperNode("NameOfOperator", null, new TreeDumperNode[]{
        new TreeDumperNode("Argument", null, new TreeDumperNode[] { Visit(node.Argument, null) }),new TreeDumperNode("ConstantValueOpt", node.ConstantValueOpt, null),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitInterpolatedString(BoundInterpolatedString node, object arg)
    {
      return new TreeDumperNode("InterpolatedString", null, new TreeDumperNode[]{
        new TreeDumperNode("Parts", null, from x in node.Parts select Visit(x, null)),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitStringInsert(BoundStringInsert node, object arg)
    {
      return new TreeDumperNode("StringInsert", null, new TreeDumperNode[]{
        new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) }),new TreeDumperNode("Alignment", null, new TreeDumperNode[] { Visit(node.Alignment, null) }),new TreeDumperNode("Format", null, new TreeDumperNode[] { Visit(node.Format, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitIsPatternExpression(BoundIsPatternExpression node, object arg)
    {
      return new TreeDumperNode("IsPatternExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Pattern", null, new TreeDumperNode[] { Visit(node.Pattern, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDeclarationPattern(BoundDeclarationPattern node, object arg)
    {
      return new TreeDumperNode("DeclarationPattern", null, new TreeDumperNode[]{
        new TreeDumperNode("Variable", node.Variable, null),new TreeDumperNode("VariableAccess", null, new TreeDumperNode[] { Visit(node.VariableAccess, null) }),new TreeDumperNode("DeclaredType", null, new TreeDumperNode[] { Visit(node.DeclaredType, null) }),new TreeDumperNode("IsVar", node.IsVar, null)      });
    }
    public override TreeDumperNode VisitConstantPattern(BoundConstantPattern node, object arg)
    {
      return new TreeDumperNode("ConstantPattern", null, new TreeDumperNode[]{
        new TreeDumperNode("Value", null, new TreeDumperNode[] { Visit(node.Value, null) }),new TreeDumperNode("ConstantValue", node.ConstantValue, null)      });
    }
    public override TreeDumperNode VisitWildcardPattern(BoundWildcardPattern node, object arg)
    {
      return new TreeDumperNode("WildcardPattern", null, Array.Empty<TreeDumperNode>());
    }
    public override TreeDumperNode VisitDiscardExpression(BoundDiscardExpression node, object arg)
    {
      return new TreeDumperNode("DiscardExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitThrowExpression(BoundThrowExpression node, object arg)
    {
      return new TreeDumperNode("ThrowExpression", null, new TreeDumperNode[]{
        new TreeDumperNode("Expression", null, new TreeDumperNode[] { Visit(node.Expression, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitOutVariablePendingInference(OutVariablePendingInference node, object arg)
    {
      return new TreeDumperNode("OutVariablePendingInference", null, new TreeDumperNode[]{
        new TreeDumperNode("VariableSymbol", node.VariableSymbol, null),new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node, object arg)
    {
      return new TreeDumperNode("DeconstructionVariablePendingInference", null, new TreeDumperNode[]{
        new TreeDumperNode("VariableSymbol", node.VariableSymbol, null),new TreeDumperNode("ReceiverOpt", null, new TreeDumperNode[] { Visit(node.ReceiverOpt, null) }),new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node, object arg)
    {
      return new TreeDumperNode("OutDeconstructVarPendingInference", null, new TreeDumperNode[]{
        new TreeDumperNode("Type", node.Type, null)      });
    }
    public override TreeDumperNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node, object arg)
    {
      return new TreeDumperNode("NonConstructorMethodBody", null, new TreeDumperNode[]{
        new TreeDumperNode("BlockBody", null, new TreeDumperNode[] { Visit(node.BlockBody, null) }),new TreeDumperNode("ExpressionBody", null, new TreeDumperNode[] { Visit(node.ExpressionBody, null) })      });
    }
    public override TreeDumperNode VisitConstructorMethodBody(BoundConstructorMethodBody node, object arg)
    {
      return new TreeDumperNode("ConstructorMethodBody", null, new TreeDumperNode[]{
        new TreeDumperNode("Locals", node.Locals, null),new TreeDumperNode("Initializer", null, new TreeDumperNode[] { Visit(node.Initializer, null) }),new TreeDumperNode("BlockBody", null, new TreeDumperNode[] { Visit(node.BlockBody, null) }),new TreeDumperNode("ExpressionBody", null, new TreeDumperNode[] { Visit(node.ExpressionBody, null) })      });
    }
  }