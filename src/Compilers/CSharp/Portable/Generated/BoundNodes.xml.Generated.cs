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
{

    internal enum BoundKind  : byte
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
        ConstructorMethodBody,      }


    internal abstract partial class BoundInitializer : BoundNode
    {
      protected BoundInitializer(BoundKind kind, SyntaxNode syntax, bool hasErrors) : base(kind, syntax, hasErrors)
      {
      }
      protected BoundInitializer(BoundKind kind, SyntaxNode syntax) : base(kind, syntax)
      {
      }
    }

    internal abstract partial class BoundEqualsValue : BoundInitializer
    {
      protected BoundEqualsValue(BoundKind kind, SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false) : base(kind, syntax, hasErrors)
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.Value = value;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundExpression Value { get; }
    }

    internal sealed partial class BoundFieldEqualsValue : BoundEqualsValue
    {
      public BoundFieldEqualsValue(SyntaxNode syntax, FieldSymbol field, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false) : base(BoundKind.FieldEqualsValue, syntax, locals, value, hasErrors || value.HasErrors())
      {
        Debug.Assert(field != null, "Field 'field' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Field = field;
      }
      public  FieldSymbol Field { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitFieldEqualsValue(this);
      public BoundFieldEqualsValue Update(FieldSymbol field, ImmutableArray<LocalSymbol> locals, BoundExpression value)
      {
        if (field == this.Field && locals == this.Locals && value == this.Value)return this;
        var result = new BoundFieldEqualsValue(this.Syntax, Field, Locals, Value, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPropertyEqualsValue : BoundEqualsValue
    {
      public BoundPropertyEqualsValue(SyntaxNode syntax, PropertySymbol property, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false) : base(BoundKind.PropertyEqualsValue, syntax, locals, value, hasErrors || value.HasErrors())
      {
        Debug.Assert(property != null, "Field 'property' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Property = property;
      }
      public  PropertySymbol Property { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPropertyEqualsValue(this);
      public BoundPropertyEqualsValue Update(PropertySymbol property, ImmutableArray<LocalSymbol> locals, BoundExpression value)
      {
        if (property == this.Property && locals == this.Locals && value == this.Value)return this;
        var result = new BoundPropertyEqualsValue(this.Syntax, Property, Locals, Value, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundParameterEqualsValue : BoundEqualsValue
    {
      public BoundParameterEqualsValue(SyntaxNode syntax, ParameterSymbol parameter, ImmutableArray<LocalSymbol> locals, BoundExpression value,  bool hasErrors = false) : base(BoundKind.ParameterEqualsValue, syntax, locals, value, hasErrors || value.HasErrors())
      {
        Debug.Assert(parameter != null, "Field 'parameter' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Parameter = parameter;
      }
      public  ParameterSymbol Parameter { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitParameterEqualsValue(this);
      public BoundParameterEqualsValue Update(ParameterSymbol parameter, ImmutableArray<LocalSymbol> locals, BoundExpression value)
      {
        if (parameter == this.Parameter && locals == this.Locals && value == this.Value)return this;
        var result = new BoundParameterEqualsValue(this.Syntax, Parameter, Locals, Value, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundGlobalStatementInitializer : BoundInitializer
    {
      public BoundGlobalStatementInitializer(SyntaxNode syntax, BoundStatement statement,  bool hasErrors = false) : base(BoundKind.GlobalStatementInitializer, syntax, hasErrors || statement.HasErrors())
      {
        Debug.Assert(statement != null, "Field 'statement' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Statement = statement;
      }
      public  BoundStatement Statement { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitGlobalStatementInitializer(this);
      public BoundGlobalStatementInitializer Update(BoundStatement statement)
      {
        if (statement == this.Statement)return this;
        var result = new BoundGlobalStatementInitializer(this.Syntax, Statement, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundExpression : BoundNode
    {
      protected BoundExpression(BoundKind kind, SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(kind, syntax, hasErrors)
      {
        this.Type = type;
      }
      protected BoundExpression(BoundKind kind, SyntaxNode syntax, TypeSymbol type) : base(kind, syntax)
      {
      }
      public  TypeSymbol Type { get; }
    }

    internal abstract partial class BoundValuePlaceholderBase : BoundExpression
    {
      protected BoundValuePlaceholderBase(BoundKind kind, SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(kind, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      protected BoundValuePlaceholderBase(BoundKind kind, SyntaxNode syntax, TypeSymbol type) : base(kind, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
    }

    internal sealed partial class BoundDeconstructValuePlaceholder : BoundValuePlaceholderBase
    {
      public BoundDeconstructValuePlaceholder(SyntaxNode syntax, uint valEscape, TypeSymbol type, bool hasErrors) : base(BoundKind.DeconstructValuePlaceholder, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ValEscape = valEscape;
      }
      public BoundDeconstructValuePlaceholder(SyntaxNode syntax, uint valEscape, TypeSymbol type) : base(BoundKind.DeconstructValuePlaceholder, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  uint ValEscape { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDeconstructValuePlaceholder(this);
      public BoundDeconstructValuePlaceholder Update(uint valEscape, TypeSymbol type)
      {
        if (valEscape == this.ValEscape && type == this.Type)return this;
        var result = new BoundDeconstructValuePlaceholder(this.Syntax, ValEscape, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundTupleOperandPlaceholder : BoundValuePlaceholderBase
    {
      public BoundTupleOperandPlaceholder(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.TupleOperandPlaceholder, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundTupleOperandPlaceholder(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.TupleOperandPlaceholder, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTupleOperandPlaceholder(this);
      public BoundTupleOperandPlaceholder Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundTupleOperandPlaceholder(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDup : BoundExpression
    {
      public BoundDup(SyntaxNode syntax, RefKind refKind, TypeSymbol type, bool hasErrors) : base(BoundKind.Dup, syntax, type, hasErrors)
      {
        this.RefKind = refKind;
      }
      public BoundDup(SyntaxNode syntax, RefKind refKind, TypeSymbol type) : base(BoundKind.Dup, syntax, type)
      {
      }
      public  RefKind RefKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDup(this);
      public BoundDup Update(RefKind refKind, TypeSymbol type)
      {
        if (refKind == this.RefKind && type == this.Type)return this;
        var result = new BoundDup(this.Syntax, RefKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPassByCopy : BoundExpression
    {
      public BoundPassByCopy(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.PassByCopy, syntax, type, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
      }
      public  BoundExpression Expression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPassByCopy(this);
      public BoundPassByCopy Update(BoundExpression expression, TypeSymbol type)
      {
        if (expression == this.Expression && type == this.Type)return this;
        var result = new BoundPassByCopy(this.Syntax, Expression, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundBadExpression : BoundExpression
    {
      public BoundBadExpression(SyntaxNode syntax, LookupResultKind resultKind, ImmutableArray<Symbol> symbols, ImmutableArray<BoundExpression> childBoundNodes, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.BadExpression, syntax, type, hasErrors || childBoundNodes.HasErrors())
      {
        Debug.Assert(!symbols.IsDefault, "Field 'symbols' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!childBoundNodes.IsDefault, "Field 'childBoundNodes' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ResultKind = resultKind;
        this.Symbols = symbols;
        this.ChildBoundNodes = childBoundNodes;
      }
      public override LookupResultKind ResultKind { get; }
      public  ImmutableArray<Symbol> Symbols { get; }
      public  ImmutableArray<BoundExpression> ChildBoundNodes { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitBadExpression(this);
      public BoundBadExpression Update(LookupResultKind resultKind, ImmutableArray<Symbol> symbols, ImmutableArray<BoundExpression> childBoundNodes, TypeSymbol type)
      {
        if (resultKind == this.ResultKind && symbols == this.Symbols && childBoundNodes == this.ChildBoundNodes && type == this.Type)return this;
        var result = new BoundBadExpression(this.Syntax, ResultKind, Symbols, ChildBoundNodes, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundBadStatement : BoundStatement
    {
      public BoundBadStatement(SyntaxNode syntax, ImmutableArray<BoundNode> childBoundNodes,  bool hasErrors = false) : base(BoundKind.BadStatement, syntax, hasErrors || childBoundNodes.HasErrors())
      {
        Debug.Assert(!childBoundNodes.IsDefault, "Field 'childBoundNodes' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ChildBoundNodes = childBoundNodes;
      }
      public  ImmutableArray<BoundNode> ChildBoundNodes { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitBadStatement(this);
      public BoundBadStatement Update(ImmutableArray<BoundNode> childBoundNodes)
      {
        if (childBoundNodes == this.ChildBoundNodes)return this;
        var result = new BoundBadStatement(this.Syntax, ChildBoundNodes, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundTypeExpression : BoundExpression
    {
      public BoundTypeExpression(SyntaxNode syntax, AliasSymbol aliasOpt, bool inferredType, BoundTypeExpression boundContainingTypeOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.TypeExpression, syntax, type, hasErrors || boundContainingTypeOpt.HasErrors())
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.AliasOpt = aliasOpt;
        this.InferredType = inferredType;
        this.BoundContainingTypeOpt = boundContainingTypeOpt;
      }
      public  AliasSymbol AliasOpt { get; }
      public  bool InferredType { get; }
      public  BoundTypeExpression BoundContainingTypeOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTypeExpression(this);
      public BoundTypeExpression Update(AliasSymbol aliasOpt, bool inferredType, BoundTypeExpression boundContainingTypeOpt, TypeSymbol type)
      {
        if (aliasOpt == this.AliasOpt && inferredType == this.InferredType && boundContainingTypeOpt == this.BoundContainingTypeOpt && type == this.Type)return this;
        var result = new BoundTypeExpression(this.Syntax, AliasOpt, InferredType, BoundContainingTypeOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundTypeOrValueExpression : BoundExpression
    {
      public BoundTypeOrValueExpression(SyntaxNode syntax, BoundTypeOrValueData data, TypeSymbol type, bool hasErrors) : base(BoundKind.TypeOrValueExpression, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Data = data;
      }
      public BoundTypeOrValueExpression(SyntaxNode syntax, BoundTypeOrValueData data, TypeSymbol type) : base(BoundKind.TypeOrValueExpression, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  BoundTypeOrValueData Data { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTypeOrValueExpression(this);
      public BoundTypeOrValueExpression Update(BoundTypeOrValueData data, TypeSymbol type)
      {
        if (data == this.Data && type == this.Type)return this;
        var result = new BoundTypeOrValueExpression(this.Syntax, Data, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundNamespaceExpression : BoundExpression
    {
      public BoundNamespaceExpression(SyntaxNode syntax, NamespaceSymbol namespaceSymbol, AliasSymbol aliasOpt, bool hasErrors) : base(BoundKind.NamespaceExpression, syntax, null, hasErrors)
      {
        Debug.Assert(namespaceSymbol != null, "Field 'namespaceSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.NamespaceSymbol = namespaceSymbol;
        this.AliasOpt = aliasOpt;
      }
      public BoundNamespaceExpression(SyntaxNode syntax, NamespaceSymbol namespaceSymbol, AliasSymbol aliasOpt) : base(BoundKind.NamespaceExpression, syntax, null)
      {
        Debug.Assert(namespaceSymbol != null, "Field 'namespaceSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  NamespaceSymbol NamespaceSymbol { get; }
      public  AliasSymbol AliasOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNamespaceExpression(this);
      public BoundNamespaceExpression Update(NamespaceSymbol namespaceSymbol, AliasSymbol aliasOpt)
      {
        if (namespaceSymbol == this.NamespaceSymbol && aliasOpt == this.AliasOpt)return this;
        var result = new BoundNamespaceExpression(this.Syntax, NamespaceSymbol, AliasOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundUnaryOperator : BoundExpression
    {
      public BoundUnaryOperator(SyntaxNode syntax, UnaryOperatorKind operatorKind, BoundExpression operand, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.UnaryOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.OperatorKind = operatorKind;
        this.Operand = operand;
        this.ConstantValueOpt = constantValueOpt;
        this.MethodOpt = methodOpt;
        this.ResultKind = resultKind;
      }
      public  UnaryOperatorKind OperatorKind { get; }
      public  BoundExpression Operand { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public  MethodSymbol MethodOpt { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitUnaryOperator(this);
      public BoundUnaryOperator Update(UnaryOperatorKind operatorKind, BoundExpression operand, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type)
      {
        if (operatorKind == this.OperatorKind && operand == this.Operand && constantValueOpt == this.ConstantValueOpt && methodOpt == this.MethodOpt && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundUnaryOperator(this.Syntax, OperatorKind, Operand, ConstantValueOpt, MethodOpt, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundIncrementOperator : BoundExpression
    {
      public BoundIncrementOperator(SyntaxNode syntax, UnaryOperatorKind operatorKind, BoundExpression operand, MethodSymbol methodOpt, Conversion operandConversion, Conversion resultConversion, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.IncrementOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.OperatorKind = operatorKind;
        this.Operand = operand;
        this.MethodOpt = methodOpt;
        this.OperandConversion = operandConversion;
        this.ResultConversion = resultConversion;
        this.ResultKind = resultKind;
      }
      public  UnaryOperatorKind OperatorKind { get; }
      public  BoundExpression Operand { get; }
      public  MethodSymbol MethodOpt { get; }
      public  Conversion OperandConversion { get; }
      public  Conversion ResultConversion { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitIncrementOperator(this);
      public BoundIncrementOperator Update(UnaryOperatorKind operatorKind, BoundExpression operand, MethodSymbol methodOpt, Conversion operandConversion, Conversion resultConversion, LookupResultKind resultKind, TypeSymbol type)
      {
        if (operatorKind == this.OperatorKind && operand == this.Operand && methodOpt == this.MethodOpt && operandConversion == this.OperandConversion && resultConversion == this.ResultConversion && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundIncrementOperator(this.Syntax, OperatorKind, Operand, MethodOpt, OperandConversion, ResultConversion, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAddressOfOperator : BoundExpression
    {
      public BoundAddressOfOperator(SyntaxNode syntax, BoundExpression operand, bool isManaged, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.AddressOfOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
        this.IsManaged = isManaged;
      }
      public  BoundExpression Operand { get; }
      public  bool IsManaged { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAddressOfOperator(this);
      public BoundAddressOfOperator Update(BoundExpression operand, bool isManaged, TypeSymbol type)
      {
        if (operand == this.Operand && isManaged == this.IsManaged && type == this.Type)return this;
        var result = new BoundAddressOfOperator(this.Syntax, Operand, IsManaged, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPointerIndirectionOperator : BoundExpression
    {
      public BoundPointerIndirectionOperator(SyntaxNode syntax, BoundExpression operand, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.PointerIndirectionOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
      }
      public  BoundExpression Operand { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPointerIndirectionOperator(this);
      public BoundPointerIndirectionOperator Update(BoundExpression operand, TypeSymbol type)
      {
        if (operand == this.Operand && type == this.Type)return this;
        var result = new BoundPointerIndirectionOperator(this.Syntax, Operand, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPointerElementAccess : BoundExpression
    {
      public BoundPointerElementAccess(SyntaxNode syntax, BoundExpression expression, BoundExpression index, bool @checked, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.PointerElementAccess, syntax, type, hasErrors || expression.HasErrors() || index.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(index != null, "Field 'index' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
        this.Index = index;
        this.Checked = @checked;
      }
      public  BoundExpression Expression { get; }
      public  BoundExpression Index { get; }
      public  bool Checked { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPointerElementAccess(this);
      public BoundPointerElementAccess Update(BoundExpression expression, BoundExpression index, bool @checked, TypeSymbol type)
      {
        if (expression == this.Expression && index == this.Index && @checked == this.Checked && type == this.Type)return this;
        var result = new BoundPointerElementAccess(this.Syntax, Expression, Index, Checked, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundRefTypeOperator : BoundExpression
    {
      public BoundRefTypeOperator(SyntaxNode syntax, BoundExpression operand, MethodSymbol getTypeFromHandle, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.RefTypeOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
        this.GetTypeFromHandle = getTypeFromHandle;
      }
      public  BoundExpression Operand { get; }
      public  MethodSymbol GetTypeFromHandle { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitRefTypeOperator(this);
      public BoundRefTypeOperator Update(BoundExpression operand, MethodSymbol getTypeFromHandle, TypeSymbol type)
      {
        if (operand == this.Operand && getTypeFromHandle == this.GetTypeFromHandle && type == this.Type)return this;
        var result = new BoundRefTypeOperator(this.Syntax, Operand, GetTypeFromHandle, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundMakeRefOperator : BoundExpression
    {
      public BoundMakeRefOperator(SyntaxNode syntax, BoundExpression operand, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.MakeRefOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
      }
      public  BoundExpression Operand { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitMakeRefOperator(this);
      public BoundMakeRefOperator Update(BoundExpression operand, TypeSymbol type)
      {
        if (operand == this.Operand && type == this.Type)return this;
        var result = new BoundMakeRefOperator(this.Syntax, Operand, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundRefValueOperator : BoundExpression
    {
      public BoundRefValueOperator(SyntaxNode syntax, BoundExpression operand, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.RefValueOperator, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
      }
      public  BoundExpression Operand { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitRefValueOperator(this);
      public BoundRefValueOperator Update(BoundExpression operand, TypeSymbol type)
      {
        if (operand == this.Operand && type == this.Type)return this;
        var result = new BoundRefValueOperator(this.Syntax, Operand, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundBinaryOperator : BoundExpression
    {
      public BoundBinaryOperator(SyntaxNode syntax, BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.BinaryOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors())
      {
        Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.OperatorKind = operatorKind;
        this.Left = left;
        this.Right = right;
        this.ConstantValueOpt = constantValueOpt;
        this.MethodOpt = methodOpt;
        this.ResultKind = resultKind;
      }
      public  BinaryOperatorKind OperatorKind { get; }
      public  BoundExpression Left { get; }
      public  BoundExpression Right { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public  MethodSymbol MethodOpt { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitBinaryOperator(this);
      public BoundBinaryOperator Update(BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, ConstantValue constantValueOpt, MethodSymbol methodOpt, LookupResultKind resultKind, TypeSymbol type)
      {
        if (operatorKind == this.OperatorKind && left == this.Left && right == this.Right && constantValueOpt == this.ConstantValueOpt && methodOpt == this.MethodOpt && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundBinaryOperator(this.Syntax, OperatorKind, Left, Right, ConstantValueOpt, MethodOpt, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundTupleBinaryOperator : BoundExpression
    {
      public BoundTupleBinaryOperator(SyntaxNode syntax, BoundExpression left, BoundExpression right, BoundExpression convertedLeft, BoundExpression convertedRight, BinaryOperatorKind operatorKind, TupleBinaryOperatorInfo.Multiple operators, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.TupleBinaryOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors() || convertedLeft.HasErrors() || convertedRight.HasErrors())
      {
        Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(convertedLeft != null, "Field 'convertedLeft' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(convertedRight != null, "Field 'convertedRight' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(operators != null, "Field 'operators' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Left = left;
        this.Right = right;
        this.ConvertedLeft = convertedLeft;
        this.ConvertedRight = convertedRight;
        this.OperatorKind = operatorKind;
        this.Operators = operators;
      }
      public  BoundExpression Left { get; }
      public  BoundExpression Right { get; }
      public  BoundExpression ConvertedLeft { get; }
      public  BoundExpression ConvertedRight { get; }
      public  BinaryOperatorKind OperatorKind { get; }
      public  TupleBinaryOperatorInfo.Multiple Operators { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTupleBinaryOperator(this);
      public BoundTupleBinaryOperator Update(BoundExpression left, BoundExpression right, BoundExpression convertedLeft, BoundExpression convertedRight, BinaryOperatorKind operatorKind, TupleBinaryOperatorInfo.Multiple operators, TypeSymbol type)
      {
        if (left == this.Left && right == this.Right && convertedLeft == this.ConvertedLeft && convertedRight == this.ConvertedRight && operatorKind == this.OperatorKind && operators == this.Operators && type == this.Type)return this;
        var result = new BoundTupleBinaryOperator(this.Syntax, Left, Right, ConvertedLeft, ConvertedRight, OperatorKind, Operators, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundUserDefinedConditionalLogicalOperator : BoundExpression
    {
      public BoundUserDefinedConditionalLogicalOperator(SyntaxNode syntax, BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, MethodSymbol logicalOperator, MethodSymbol trueOperator, MethodSymbol falseOperator, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.UserDefinedConditionalLogicalOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors())
      {
        Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(logicalOperator != null, "Field 'logicalOperator' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(trueOperator != null, "Field 'trueOperator' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(falseOperator != null, "Field 'falseOperator' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.OperatorKind = operatorKind;
        this.Left = left;
        this.Right = right;
        this.LogicalOperator = logicalOperator;
        this.TrueOperator = trueOperator;
        this.FalseOperator = falseOperator;
        this.ResultKind = resultKind;
      }
      public  BinaryOperatorKind OperatorKind { get; }
      public  BoundExpression Left { get; }
      public  BoundExpression Right { get; }
      public  MethodSymbol LogicalOperator { get; }
      public  MethodSymbol TrueOperator { get; }
      public  MethodSymbol FalseOperator { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitUserDefinedConditionalLogicalOperator(this);
      public BoundUserDefinedConditionalLogicalOperator Update(BinaryOperatorKind operatorKind, BoundExpression left, BoundExpression right, MethodSymbol logicalOperator, MethodSymbol trueOperator, MethodSymbol falseOperator, LookupResultKind resultKind, TypeSymbol type)
      {
        if (operatorKind == this.OperatorKind && left == this.Left && right == this.Right && logicalOperator == this.LogicalOperator && trueOperator == this.TrueOperator && falseOperator == this.FalseOperator && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundUserDefinedConditionalLogicalOperator(this.Syntax, OperatorKind, Left, Right, LogicalOperator, TrueOperator, FalseOperator, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundCompoundAssignmentOperator : BoundExpression
    {
      public BoundCompoundAssignmentOperator(SyntaxNode syntax, BinaryOperatorSignature @operator, BoundExpression left, BoundExpression right, Conversion leftConversion, Conversion finalConversion, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.CompoundAssignmentOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors())
      {
        Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operator = @operator;
        this.Left = left;
        this.Right = right;
        this.LeftConversion = leftConversion;
        this.FinalConversion = finalConversion;
        this.ResultKind = resultKind;
      }
      public  BinaryOperatorSignature Operator { get; }
      public  BoundExpression Left { get; }
      public  BoundExpression Right { get; }
      public  Conversion LeftConversion { get; }
      public  Conversion FinalConversion { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitCompoundAssignmentOperator(this);
      public BoundCompoundAssignmentOperator Update(BinaryOperatorSignature @operator, BoundExpression left, BoundExpression right, Conversion leftConversion, Conversion finalConversion, LookupResultKind resultKind, TypeSymbol type)
      {
        if (@operator == this.Operator && left == this.Left && right == this.Right && leftConversion == this.LeftConversion && finalConversion == this.FinalConversion && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundCompoundAssignmentOperator(this.Syntax, Operator, Left, Right, LeftConversion, FinalConversion, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAssignmentOperator : BoundExpression
    {
      public BoundAssignmentOperator(SyntaxNode syntax, BoundExpression left, BoundExpression right, bool isRef, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.AssignmentOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors())
      {
        Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Left = left;
        this.Right = right;
        this.IsRef = isRef;
      }
      public  BoundExpression Left { get; }
      public  BoundExpression Right { get; }
      public  bool IsRef { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAssignmentOperator(this);
      public BoundAssignmentOperator Update(BoundExpression left, BoundExpression right, bool isRef, TypeSymbol type)
      {
        if (left == this.Left && right == this.Right && isRef == this.IsRef && type == this.Type)return this;
        var result = new BoundAssignmentOperator(this.Syntax, Left, Right, IsRef, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDeconstructionAssignmentOperator : BoundExpression
    {
      public BoundDeconstructionAssignmentOperator(SyntaxNode syntax, BoundTupleExpression left, BoundConversion right, bool isUsed, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DeconstructionAssignmentOperator, syntax, type, hasErrors || left.HasErrors() || right.HasErrors())
      {
        Debug.Assert(left != null, "Field 'left' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(right != null, "Field 'right' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Left = left;
        this.Right = right;
        this.IsUsed = isUsed;
      }
      public  BoundTupleExpression Left { get; }
      public  BoundConversion Right { get; }
      public  bool IsUsed { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDeconstructionAssignmentOperator(this);
      public BoundDeconstructionAssignmentOperator Update(BoundTupleExpression left, BoundConversion right, bool isUsed, TypeSymbol type)
      {
        if (left == this.Left && right == this.Right && isUsed == this.IsUsed && type == this.Type)return this;
        var result = new BoundDeconstructionAssignmentOperator(this.Syntax, Left, Right, IsUsed, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundNullCoalescingOperator : BoundExpression
    {
      public BoundNullCoalescingOperator(SyntaxNode syntax, BoundExpression leftOperand, BoundExpression rightOperand, Conversion leftConversion, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.NullCoalescingOperator, syntax, type, hasErrors || leftOperand.HasErrors() || rightOperand.HasErrors())
      {
        Debug.Assert(leftOperand != null, "Field 'leftOperand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(rightOperand != null, "Field 'rightOperand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.LeftOperand = leftOperand;
        this.RightOperand = rightOperand;
        this.LeftConversion = leftConversion;
      }
      public  BoundExpression LeftOperand { get; }
      public  BoundExpression RightOperand { get; }
      public  Conversion LeftConversion { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNullCoalescingOperator(this);
      public BoundNullCoalescingOperator Update(BoundExpression leftOperand, BoundExpression rightOperand, Conversion leftConversion, TypeSymbol type)
      {
        if (leftOperand == this.LeftOperand && rightOperand == this.RightOperand && leftConversion == this.LeftConversion && type == this.Type)return this;
        var result = new BoundNullCoalescingOperator(this.Syntax, LeftOperand, RightOperand, LeftConversion, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConditionalOperator : BoundExpression
    {
      public BoundConditionalOperator(SyntaxNode syntax, bool isRef, BoundExpression condition, BoundExpression consequence, BoundExpression alternative, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ConditionalOperator, syntax, type, hasErrors || condition.HasErrors() || consequence.HasErrors() || alternative.HasErrors())
      {
        Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(consequence != null, "Field 'consequence' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(alternative != null, "Field 'alternative' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.IsRef = isRef;
        this.Condition = condition;
        this.Consequence = consequence;
        this.Alternative = alternative;
        this.ConstantValueOpt = constantValueOpt;
      }
      public  bool IsRef { get; }
      public  BoundExpression Condition { get; }
      public  BoundExpression Consequence { get; }
      public  BoundExpression Alternative { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConditionalOperator(this);
      public BoundConditionalOperator Update(bool isRef, BoundExpression condition, BoundExpression consequence, BoundExpression alternative, ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (isRef == this.IsRef && condition == this.Condition && consequence == this.Consequence && alternative == this.Alternative && constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundConditionalOperator(this.Syntax, IsRef, Condition, Consequence, Alternative, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundArrayAccess : BoundExpression
    {
      public BoundArrayAccess(SyntaxNode syntax, BoundExpression expression, ImmutableArray<BoundExpression> indices, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ArrayAccess, syntax, type, hasErrors || expression.HasErrors() || indices.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!indices.IsDefault, "Field 'indices' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
        this.Indices = indices;
      }
      public  BoundExpression Expression { get; }
      public  ImmutableArray<BoundExpression> Indices { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitArrayAccess(this);
      public BoundArrayAccess Update(BoundExpression expression, ImmutableArray<BoundExpression> indices, TypeSymbol type)
      {
        if (expression == this.Expression && indices == this.Indices && type == this.Type)return this;
        var result = new BoundArrayAccess(this.Syntax, Expression, Indices, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundArrayLength : BoundExpression
    {
      public BoundArrayLength(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ArrayLength, syntax, type, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
      }
      public  BoundExpression Expression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitArrayLength(this);
      public BoundArrayLength Update(BoundExpression expression, TypeSymbol type)
      {
        if (expression == this.Expression && type == this.Type)return this;
        var result = new BoundArrayLength(this.Syntax, Expression, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAwaitExpression : BoundExpression
    {
      public BoundAwaitExpression(SyntaxNode syntax, BoundExpression expression, MethodSymbol getAwaiter, PropertySymbol isCompleted, MethodSymbol getResult, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.AwaitExpression, syntax, type, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
        this.GetAwaiter = getAwaiter;
        this.IsCompleted = isCompleted;
        this.GetResult = getResult;
      }
      public  BoundExpression Expression { get; }
      public  MethodSymbol GetAwaiter { get; }
      public  PropertySymbol IsCompleted { get; }
      public  MethodSymbol GetResult { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAwaitExpression(this);
      public BoundAwaitExpression Update(BoundExpression expression, MethodSymbol getAwaiter, PropertySymbol isCompleted, MethodSymbol getResult, TypeSymbol type)
      {
        if (expression == this.Expression && getAwaiter == this.GetAwaiter && isCompleted == this.IsCompleted && getResult == this.GetResult && type == this.Type)return this;
        var result = new BoundAwaitExpression(this.Syntax, Expression, GetAwaiter, IsCompleted, GetResult, Type, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundTypeOf : BoundExpression
    {
      protected BoundTypeOf(BoundKind kind, SyntaxNode syntax, MethodSymbol getTypeFromHandle, TypeSymbol type, bool hasErrors) : base(kind, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.GetTypeFromHandle = getTypeFromHandle;
      }
      protected BoundTypeOf(BoundKind kind, SyntaxNode syntax, MethodSymbol getTypeFromHandle, TypeSymbol type) : base(kind, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  MethodSymbol GetTypeFromHandle { get; }
    }

    internal sealed partial class BoundTypeOfOperator : BoundTypeOf
    {
      public BoundTypeOfOperator(SyntaxNode syntax, BoundTypeExpression sourceType, MethodSymbol getTypeFromHandle, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.TypeOfOperator, syntax, getTypeFromHandle, type, hasErrors || sourceType.HasErrors())
      {
        Debug.Assert(sourceType != null, "Field 'sourceType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.SourceType = sourceType;
      }
      public  BoundTypeExpression SourceType { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTypeOfOperator(this);
      public BoundTypeOfOperator Update(BoundTypeExpression sourceType, MethodSymbol getTypeFromHandle, TypeSymbol type)
      {
        if (sourceType == this.SourceType && getTypeFromHandle == this.GetTypeFromHandle && type == this.Type)return this;
        var result = new BoundTypeOfOperator(this.Syntax, SourceType, GetTypeFromHandle, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundMethodDefIndex : BoundExpression
    {
      public BoundMethodDefIndex(SyntaxNode syntax, MethodSymbol method, TypeSymbol type, bool hasErrors) : base(BoundKind.MethodDefIndex, syntax, type, hasErrors)
      {
        Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Method = method;
      }
      public BoundMethodDefIndex(SyntaxNode syntax, MethodSymbol method, TypeSymbol type) : base(BoundKind.MethodDefIndex, syntax, type)
      {
        Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  MethodSymbol Method { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitMethodDefIndex(this);
      public BoundMethodDefIndex Update(MethodSymbol method, TypeSymbol type)
      {
        if (method == this.Method && type == this.Type)return this;
        var result = new BoundMethodDefIndex(this.Syntax, Method, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundMaximumMethodDefIndex : BoundExpression
    {
      public BoundMaximumMethodDefIndex(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.MaximumMethodDefIndex, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundMaximumMethodDefIndex(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.MaximumMethodDefIndex, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitMaximumMethodDefIndex(this);
      public BoundMaximumMethodDefIndex Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundMaximumMethodDefIndex(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundInstrumentationPayloadRoot : BoundExpression
    {
      public BoundInstrumentationPayloadRoot(SyntaxNode syntax, int analysisKind, TypeSymbol type, bool hasErrors) : base(BoundKind.InstrumentationPayloadRoot, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.AnalysisKind = analysisKind;
      }
      public BoundInstrumentationPayloadRoot(SyntaxNode syntax, int analysisKind, TypeSymbol type) : base(BoundKind.InstrumentationPayloadRoot, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  int AnalysisKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitInstrumentationPayloadRoot(this);
      public BoundInstrumentationPayloadRoot Update(int analysisKind, TypeSymbol type)
      {
        if (analysisKind == this.AnalysisKind && type == this.Type)return this;
        var result = new BoundInstrumentationPayloadRoot(this.Syntax, AnalysisKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundModuleVersionId : BoundExpression
    {
      public BoundModuleVersionId(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.ModuleVersionId, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundModuleVersionId(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.ModuleVersionId, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitModuleVersionId(this);
      public BoundModuleVersionId Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundModuleVersionId(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundModuleVersionIdString : BoundExpression
    {
      public BoundModuleVersionIdString(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.ModuleVersionIdString, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundModuleVersionIdString(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.ModuleVersionIdString, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitModuleVersionIdString(this);
      public BoundModuleVersionIdString Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundModuleVersionIdString(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSourceDocumentIndex : BoundExpression
    {
      public BoundSourceDocumentIndex(SyntaxNode syntax, Cci.DebugSourceDocument document, TypeSymbol type, bool hasErrors) : base(BoundKind.SourceDocumentIndex, syntax, type, hasErrors)
      {
        Debug.Assert(document != null, "Field 'document' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Document = document;
      }
      public BoundSourceDocumentIndex(SyntaxNode syntax, Cci.DebugSourceDocument document, TypeSymbol type) : base(BoundKind.SourceDocumentIndex, syntax, type)
      {
        Debug.Assert(document != null, "Field 'document' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  Cci.DebugSourceDocument Document { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSourceDocumentIndex(this);
      public BoundSourceDocumentIndex Update(Cci.DebugSourceDocument document, TypeSymbol type)
      {
        if (document == this.Document && type == this.Type)return this;
        var result = new BoundSourceDocumentIndex(this.Syntax, Document, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundMethodInfo : BoundExpression
    {
      public BoundMethodInfo(SyntaxNode syntax, MethodSymbol method, MethodSymbol getMethodFromHandle, TypeSymbol type, bool hasErrors) : base(BoundKind.MethodInfo, syntax, type, hasErrors)
      {
        Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Method = method;
        this.GetMethodFromHandle = getMethodFromHandle;
      }
      public BoundMethodInfo(SyntaxNode syntax, MethodSymbol method, MethodSymbol getMethodFromHandle, TypeSymbol type) : base(BoundKind.MethodInfo, syntax, type)
      {
        Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  MethodSymbol Method { get; }
      public  MethodSymbol GetMethodFromHandle { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitMethodInfo(this);
      public BoundMethodInfo Update(MethodSymbol method, MethodSymbol getMethodFromHandle, TypeSymbol type)
      {
        if (method == this.Method && getMethodFromHandle == this.GetMethodFromHandle && type == this.Type)return this;
        var result = new BoundMethodInfo(this.Syntax, Method, GetMethodFromHandle, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundFieldInfo : BoundExpression
    {
      public BoundFieldInfo(SyntaxNode syntax, FieldSymbol field, MethodSymbol getFieldFromHandle, TypeSymbol type, bool hasErrors) : base(BoundKind.FieldInfo, syntax, type, hasErrors)
      {
        Debug.Assert(field != null, "Field 'field' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Field = field;
        this.GetFieldFromHandle = getFieldFromHandle;
      }
      public BoundFieldInfo(SyntaxNode syntax, FieldSymbol field, MethodSymbol getFieldFromHandle, TypeSymbol type) : base(BoundKind.FieldInfo, syntax, type)
      {
        Debug.Assert(field != null, "Field 'field' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  FieldSymbol Field { get; }
      public  MethodSymbol GetFieldFromHandle { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitFieldInfo(this);
      public BoundFieldInfo Update(FieldSymbol field, MethodSymbol getFieldFromHandle, TypeSymbol type)
      {
        if (field == this.Field && getFieldFromHandle == this.GetFieldFromHandle && type == this.Type)return this;
        var result = new BoundFieldInfo(this.Syntax, Field, GetFieldFromHandle, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDefaultExpression : BoundExpression
    {
      public BoundDefaultExpression(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type, bool hasErrors) : base(BoundKind.DefaultExpression, syntax, type, hasErrors)
      {
        this.ConstantValueOpt = constantValueOpt;
      }
      public BoundDefaultExpression(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type) : base(BoundKind.DefaultExpression, syntax, type)
      {
      }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDefaultExpression(this);
      public BoundDefaultExpression Update(ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundDefaultExpression(this.Syntax, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundIsOperator : BoundExpression
    {
      public BoundIsOperator(SyntaxNode syntax, BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.IsOperator, syntax, type, hasErrors || operand.HasErrors() || targetType.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(targetType != null, "Field 'targetType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
        this.TargetType = targetType;
        this.Conversion = conversion;
      }
      public  BoundExpression Operand { get; }
      public  BoundTypeExpression TargetType { get; }
      public  Conversion Conversion { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitIsOperator(this);
      public BoundIsOperator Update(BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type)
      {
        if (operand == this.Operand && targetType == this.TargetType && conversion == this.Conversion && type == this.Type)return this;
        var result = new BoundIsOperator(this.Syntax, Operand, TargetType, Conversion, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAsOperator : BoundExpression
    {
      public BoundAsOperator(SyntaxNode syntax, BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.AsOperator, syntax, type, hasErrors || operand.HasErrors() || targetType.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(targetType != null, "Field 'targetType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
        this.TargetType = targetType;
        this.Conversion = conversion;
      }
      public  BoundExpression Operand { get; }
      public  BoundTypeExpression TargetType { get; }
      public  Conversion Conversion { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAsOperator(this);
      public BoundAsOperator Update(BoundExpression operand, BoundTypeExpression targetType, Conversion conversion, TypeSymbol type)
      {
        if (operand == this.Operand && targetType == this.TargetType && conversion == this.Conversion && type == this.Type)return this;
        var result = new BoundAsOperator(this.Syntax, Operand, TargetType, Conversion, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSizeOfOperator : BoundExpression
    {
      public BoundSizeOfOperator(SyntaxNode syntax, BoundTypeExpression sourceType, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.SizeOfOperator, syntax, type, hasErrors || sourceType.HasErrors())
      {
        Debug.Assert(sourceType != null, "Field 'sourceType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.SourceType = sourceType;
        this.ConstantValueOpt = constantValueOpt;
      }
      public  BoundTypeExpression SourceType { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSizeOfOperator(this);
      public BoundSizeOfOperator Update(BoundTypeExpression sourceType, ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (sourceType == this.SourceType && constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundSizeOfOperator(this.Syntax, SourceType, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConversion : BoundExpression
    {
      public BoundConversion(SyntaxNode syntax, BoundExpression operand, Conversion conversion, bool isBaseConversion, bool @checked, bool explicitCastInCode, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.Conversion, syntax, type, hasErrors || operand.HasErrors())
      {
        Debug.Assert(operand != null, "Field 'operand' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Operand = operand;
        this.Conversion = conversion;
        this.IsBaseConversion = isBaseConversion;
        this.Checked = @checked;
        this.ExplicitCastInCode = explicitCastInCode;
        this.ConstantValueOpt = constantValueOpt;
      }
      public  BoundExpression Operand { get; }
      public  Conversion Conversion { get; }
      public  bool IsBaseConversion { get; }
      public  bool Checked { get; }
      public  bool ExplicitCastInCode { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConversion(this);
      public BoundConversion Update(BoundExpression operand, Conversion conversion, bool isBaseConversion, bool @checked, bool explicitCastInCode, ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (operand == this.Operand && conversion == this.Conversion && isBaseConversion == this.IsBaseConversion && @checked == this.Checked && explicitCastInCode == this.ExplicitCastInCode && constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundConversion(this.Syntax, Operand, Conversion, IsBaseConversion, Checked, ExplicitCastInCode, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundArgList : BoundExpression
    {
      public BoundArgList(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.ArgList, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundArgList(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.ArgList, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitArgList(this);
      public BoundArgList Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundArgList(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundArgListOperator : BoundExpression
    {
      public BoundArgListOperator(SyntaxNode syntax, ImmutableArray<BoundExpression> arguments, ImmutableArray<RefKind> argumentRefKindsOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ArgListOperator, syntax, type, hasErrors || arguments.HasErrors())
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Arguments = arguments;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
      }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitArgListOperator(this);
      public BoundArgListOperator Update(ImmutableArray<BoundExpression> arguments, ImmutableArray<RefKind> argumentRefKindsOpt, TypeSymbol type)
      {
        if (arguments == this.Arguments && argumentRefKindsOpt == this.ArgumentRefKindsOpt && type == this.Type)return this;
        var result = new BoundArgListOperator(this.Syntax, Arguments, ArgumentRefKindsOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundFixedLocalCollectionInitializer : BoundExpression
    {
      public BoundFixedLocalCollectionInitializer(SyntaxNode syntax, TypeSymbol elementPointerType, Conversion elementPointerTypeConversion, BoundExpression expression, MethodSymbol getPinnableOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.FixedLocalCollectionInitializer, syntax, type, hasErrors || expression.HasErrors())
      {
        Debug.Assert(elementPointerType != null, "Field 'elementPointerType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ElementPointerType = elementPointerType;
        this.ElementPointerTypeConversion = elementPointerTypeConversion;
        this.Expression = expression;
        this.GetPinnableOpt = getPinnableOpt;
      }
      public  TypeSymbol ElementPointerType { get; }
      public  Conversion ElementPointerTypeConversion { get; }
      public  BoundExpression Expression { get; }
      public  MethodSymbol GetPinnableOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitFixedLocalCollectionInitializer(this);
      public BoundFixedLocalCollectionInitializer Update(TypeSymbol elementPointerType, Conversion elementPointerTypeConversion, BoundExpression expression, MethodSymbol getPinnableOpt, TypeSymbol type)
      {
        if (elementPointerType == this.ElementPointerType && elementPointerTypeConversion == this.ElementPointerTypeConversion && expression == this.Expression && getPinnableOpt == this.GetPinnableOpt && type == this.Type)return this;
        var result = new BoundFixedLocalCollectionInitializer(this.Syntax, ElementPointerType, ElementPointerTypeConversion, Expression, GetPinnableOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundStatement : BoundNode
    {
      protected BoundStatement(BoundKind kind, SyntaxNode syntax, bool hasErrors) : base(kind, syntax, hasErrors)
      {
      }
      protected BoundStatement(BoundKind kind, SyntaxNode syntax) : base(kind, syntax)
      {
      }
    }

    internal sealed partial class BoundSequencePoint : BoundStatement
    {
      public BoundSequencePoint(SyntaxNode syntax, BoundStatement statementOpt,  bool hasErrors = false) : base(BoundKind.SequencePoint, syntax, hasErrors || statementOpt.HasErrors())
      {
        this.StatementOpt = statementOpt;
      }
      public  BoundStatement StatementOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSequencePoint(this);
      public BoundSequencePoint Update(BoundStatement statementOpt)
      {
        if (statementOpt == this.StatementOpt)return this;
        var result = new BoundSequencePoint(this.Syntax, StatementOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSequencePointExpression : BoundExpression
    {
      public BoundSequencePointExpression(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.SequencePointExpression, syntax, type, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
      }
      public  BoundExpression Expression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSequencePointExpression(this);
      public BoundSequencePointExpression Update(BoundExpression expression, TypeSymbol type)
      {
        if (expression == this.Expression && type == this.Type)return this;
        var result = new BoundSequencePointExpression(this.Syntax, Expression, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSequencePointWithSpan : BoundStatement
    {
      public BoundSequencePointWithSpan(SyntaxNode syntax, BoundStatement statementOpt, TextSpan span,  bool hasErrors = false) : base(BoundKind.SequencePointWithSpan, syntax, hasErrors || statementOpt.HasErrors())
      {
        this.StatementOpt = statementOpt;
        this.Span = span;
      }
      public  BoundStatement StatementOpt { get; }
      public  TextSpan Span { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSequencePointWithSpan(this);
      public BoundSequencePointWithSpan Update(BoundStatement statementOpt, TextSpan span)
      {
        if (statementOpt == this.StatementOpt && span == this.Span)return this;
        var result = new BoundSequencePointWithSpan(this.Syntax, StatementOpt, Span, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundBlock : BoundStatementList
    {
      public BoundBlock(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<LocalFunctionSymbol> localFunctions, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(BoundKind.Block, syntax, statements, hasErrors || statements.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!localFunctions.IsDefault, "Field 'localFunctions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.LocalFunctions = localFunctions;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  ImmutableArray<LocalFunctionSymbol> LocalFunctions { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitBlock(this);
      public BoundBlock Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<LocalFunctionSymbol> localFunctions, ImmutableArray<BoundStatement> statements)
      {
        if (locals == this.Locals && localFunctions == this.LocalFunctions && statements == this.Statements)return this;
        var result = new BoundBlock(this.Syntax, Locals, LocalFunctions, Statements, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundScope : BoundStatementList
    {
      public BoundScope(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(BoundKind.Scope, syntax, statements, hasErrors || statements.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitScope(this);
      public BoundScope Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundStatement> statements)
      {
        if (locals == this.Locals && statements == this.Statements)return this;
        var result = new BoundScope(this.Syntax, Locals, Statements, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundStateMachineScope : BoundStatement
    {
      public BoundStateMachineScope(SyntaxNode syntax, ImmutableArray<StateMachineFieldSymbol> fields, BoundStatement statement,  bool hasErrors = false) : base(BoundKind.StateMachineScope, syntax, hasErrors || statement.HasErrors())
      {
        Debug.Assert(!fields.IsDefault, "Field 'fields' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(statement != null, "Field 'statement' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Fields = fields;
        this.Statement = statement;
      }
      public  ImmutableArray<StateMachineFieldSymbol> Fields { get; }
      public  BoundStatement Statement { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitStateMachineScope(this);
      public BoundStateMachineScope Update(ImmutableArray<StateMachineFieldSymbol> fields, BoundStatement statement)
      {
        if (fields == this.Fields && statement == this.Statement)return this;
        var result = new BoundStateMachineScope(this.Syntax, Fields, Statement, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLocalDeclaration : BoundStatement
    {
      public BoundLocalDeclaration(SyntaxNode syntax, LocalSymbol localSymbol, BoundTypeExpression declaredType, BoundExpression initializerOpt, ImmutableArray<BoundExpression> argumentsOpt,  bool hasErrors = false) : base(BoundKind.LocalDeclaration, syntax, hasErrors || declaredType.HasErrors() || initializerOpt.HasErrors() || argumentsOpt.HasErrors())
      {
        Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(declaredType != null, "Field 'declaredType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.LocalSymbol = localSymbol;
        this.DeclaredType = declaredType;
        this.InitializerOpt = initializerOpt;
        this.ArgumentsOpt = argumentsOpt;
      }
      public  LocalSymbol LocalSymbol { get; }
      public  BoundTypeExpression DeclaredType { get; }
      public  BoundExpression InitializerOpt { get; }
      public  ImmutableArray<BoundExpression> ArgumentsOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLocalDeclaration(this);
      public BoundLocalDeclaration Update(LocalSymbol localSymbol, BoundTypeExpression declaredType, BoundExpression initializerOpt, ImmutableArray<BoundExpression> argumentsOpt)
      {
        if (localSymbol == this.LocalSymbol && declaredType == this.DeclaredType && initializerOpt == this.InitializerOpt && argumentsOpt == this.ArgumentsOpt)return this;
        var result = new BoundLocalDeclaration(this.Syntax, LocalSymbol, DeclaredType, InitializerOpt, ArgumentsOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundMultipleLocalDeclarations : BoundStatement
    {
      public BoundMultipleLocalDeclarations(SyntaxNode syntax, ImmutableArray<BoundLocalDeclaration> localDeclarations,  bool hasErrors = false) : base(BoundKind.MultipleLocalDeclarations, syntax, hasErrors || localDeclarations.HasErrors())
      {
        Debug.Assert(!localDeclarations.IsDefault, "Field 'localDeclarations' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.LocalDeclarations = localDeclarations;
      }
      public  ImmutableArray<BoundLocalDeclaration> LocalDeclarations { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitMultipleLocalDeclarations(this);
      public BoundMultipleLocalDeclarations Update(ImmutableArray<BoundLocalDeclaration> localDeclarations)
      {
        if (localDeclarations == this.LocalDeclarations)return this;
        var result = new BoundMultipleLocalDeclarations(this.Syntax, LocalDeclarations, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLocalFunctionStatement : BoundStatement
    {
      public BoundLocalFunctionStatement(SyntaxNode syntax, LocalFunctionSymbol symbol, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false) : base(BoundKind.LocalFunctionStatement, syntax, hasErrors || blockBody.HasErrors() || expressionBody.HasErrors())
      {
        Debug.Assert(symbol != null, "Field 'symbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Symbol = symbol;
        this.BlockBody = blockBody;
        this.ExpressionBody = expressionBody;
      }
      public  LocalFunctionSymbol Symbol { get; }
      public  BoundBlock BlockBody { get; }
      public  BoundBlock ExpressionBody { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLocalFunctionStatement(this);
      public BoundLocalFunctionStatement Update(LocalFunctionSymbol symbol, BoundBlock blockBody, BoundBlock expressionBody)
      {
        if (symbol == this.Symbol && blockBody == this.BlockBody && expressionBody == this.ExpressionBody)return this;
        var result = new BoundLocalFunctionStatement(this.Syntax, Symbol, BlockBody, ExpressionBody, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSequence : BoundExpression
    {
      public BoundSequence(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundExpression> sideEffects, BoundExpression value, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.Sequence, syntax, type, hasErrors || sideEffects.HasErrors() || value.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!sideEffects.IsDefault, "Field 'sideEffects' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.SideEffects = sideEffects;
        this.Value = value;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  ImmutableArray<BoundExpression> SideEffects { get; }
      public  BoundExpression Value { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSequence(this);
      public BoundSequence Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundExpression> sideEffects, BoundExpression value, TypeSymbol type)
      {
        if (locals == this.Locals && sideEffects == this.SideEffects && value == this.Value && type == this.Type)return this;
        var result = new BoundSequence(this.Syntax, Locals, SideEffects, Value, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundNoOpStatement : BoundStatement
    {
      public BoundNoOpStatement(SyntaxNode syntax, NoOpStatementFlavor flavor, bool hasErrors) : base(BoundKind.NoOpStatement, syntax, hasErrors)
      {
        this.Flavor = flavor;
      }
      public BoundNoOpStatement(SyntaxNode syntax, NoOpStatementFlavor flavor) : base(BoundKind.NoOpStatement, syntax)
      {
      }
      public  NoOpStatementFlavor Flavor { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNoOpStatement(this);
      public BoundNoOpStatement Update(NoOpStatementFlavor flavor)
      {
        if (flavor == this.Flavor)return this;
        var result = new BoundNoOpStatement(this.Syntax, Flavor, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundReturnStatement : BoundStatement
    {
      public BoundReturnStatement(SyntaxNode syntax, RefKind refKind, BoundExpression expressionOpt,  bool hasErrors = false) : base(BoundKind.ReturnStatement, syntax, hasErrors || expressionOpt.HasErrors())
      {
        this.RefKind = refKind;
        this.ExpressionOpt = expressionOpt;
      }
      public  RefKind RefKind { get; }
      public  BoundExpression ExpressionOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitReturnStatement(this);
      public BoundReturnStatement Update(RefKind refKind, BoundExpression expressionOpt)
      {
        if (refKind == this.RefKind && expressionOpt == this.ExpressionOpt)return this;
        var result = new BoundReturnStatement(this.Syntax, RefKind, ExpressionOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundYieldReturnStatement : BoundStatement
    {
      public BoundYieldReturnStatement(SyntaxNode syntax, BoundExpression expression,  bool hasErrors = false) : base(BoundKind.YieldReturnStatement, syntax, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
      }
      public  BoundExpression Expression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitYieldReturnStatement(this);
      public BoundYieldReturnStatement Update(BoundExpression expression)
      {
        if (expression == this.Expression)return this;
        var result = new BoundYieldReturnStatement(this.Syntax, Expression, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundYieldBreakStatement : BoundStatement
    {
      public BoundYieldBreakStatement(SyntaxNode syntax, bool hasErrors) : base(BoundKind.YieldBreakStatement, syntax, hasErrors)
      {
      }
      public BoundYieldBreakStatement(SyntaxNode syntax) : base(BoundKind.YieldBreakStatement, syntax)
      {
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitYieldBreakStatement(this);
    }

    internal sealed partial class BoundThrowStatement : BoundStatement
    {
      public BoundThrowStatement(SyntaxNode syntax, BoundExpression expressionOpt,  bool hasErrors = false) : base(BoundKind.ThrowStatement, syntax, hasErrors || expressionOpt.HasErrors())
      {
        this.ExpressionOpt = expressionOpt;
      }
      public  BoundExpression ExpressionOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitThrowStatement(this);
      public BoundThrowStatement Update(BoundExpression expressionOpt)
      {
        if (expressionOpt == this.ExpressionOpt)return this;
        var result = new BoundThrowStatement(this.Syntax, ExpressionOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundExpressionStatement : BoundStatement
    {
      public BoundExpressionStatement(SyntaxNode syntax, BoundExpression expression,  bool hasErrors = false) : base(BoundKind.ExpressionStatement, syntax, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
      }
      public  BoundExpression Expression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitExpressionStatement(this);
      public BoundExpressionStatement Update(BoundExpression expression)
      {
        if (expression == this.Expression)return this;
        var result = new BoundExpressionStatement(this.Syntax, Expression, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSwitchStatement : BoundStatement
    {
      public BoundSwitchStatement(SyntaxNode syntax, BoundStatement loweredPreambleOpt, BoundExpression expression, LabelSymbol constantTargetOpt, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundSwitchSection> switchSections, GeneratedLabelSymbol breakLabel, MethodSymbol stringEquality,  bool hasErrors = false) : base(BoundKind.SwitchStatement, syntax, hasErrors || loweredPreambleOpt.HasErrors() || expression.HasErrors() || switchSections.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!innerLocals.IsDefault, "Field 'innerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!innerLocalFunctions.IsDefault, "Field 'innerLocalFunctions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!switchSections.IsDefault, "Field 'switchSections' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.LoweredPreambleOpt = loweredPreambleOpt;
        this.Expression = expression;
        this.ConstantTargetOpt = constantTargetOpt;
        this.InnerLocals = innerLocals;
        this.InnerLocalFunctions = innerLocalFunctions;
        this.SwitchSections = switchSections;
        this.BreakLabel = breakLabel;
        this.StringEquality = stringEquality;
      }
      public  BoundStatement LoweredPreambleOpt { get; }
      public  BoundExpression Expression { get; }
      public  LabelSymbol ConstantTargetOpt { get; }
      public  ImmutableArray<LocalSymbol> InnerLocals { get; }
      public  ImmutableArray<LocalFunctionSymbol> InnerLocalFunctions { get; }
      public  ImmutableArray<BoundSwitchSection> SwitchSections { get; }
      public  GeneratedLabelSymbol BreakLabel { get; }
      public  MethodSymbol StringEquality { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSwitchStatement(this);
      public BoundSwitchStatement Update(BoundStatement loweredPreambleOpt, BoundExpression expression, LabelSymbol constantTargetOpt, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundSwitchSection> switchSections, GeneratedLabelSymbol breakLabel, MethodSymbol stringEquality)
      {
        if (loweredPreambleOpt == this.LoweredPreambleOpt && expression == this.Expression && constantTargetOpt == this.ConstantTargetOpt && innerLocals == this.InnerLocals && innerLocalFunctions == this.InnerLocalFunctions && switchSections == this.SwitchSections && breakLabel == this.BreakLabel && stringEquality == this.StringEquality)return this;
        var result = new BoundSwitchStatement(this.Syntax, LoweredPreambleOpt, Expression, ConstantTargetOpt, InnerLocals, InnerLocalFunctions, SwitchSections, BreakLabel, StringEquality, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSwitchSection : BoundStatementList
    {
      public BoundSwitchSection(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(BoundKind.SwitchSection, syntax, statements, hasErrors || switchLabels.HasErrors() || statements.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!switchLabels.IsDefault, "Field 'switchLabels' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.SwitchLabels = switchLabels;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  ImmutableArray<BoundSwitchLabel> SwitchLabels { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSwitchSection(this);
      public BoundSwitchSection Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements)
      {
        if (locals == this.Locals && switchLabels == this.SwitchLabels && statements == this.Statements)return this;
        var result = new BoundSwitchSection(this.Syntax, Locals, SwitchLabels, Statements, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundSwitchLabel : BoundNode
    {
      public BoundSwitchLabel(SyntaxNode syntax, LabelSymbol label, BoundExpression expressionOpt, ConstantValue constantValueOpt,  bool hasErrors = false) : base(BoundKind.SwitchLabel, syntax, hasErrors || expressionOpt.HasErrors())
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
        this.ExpressionOpt = expressionOpt;
        this.ConstantValueOpt = constantValueOpt;
      }
      public  LabelSymbol Label { get; }
      public  BoundExpression ExpressionOpt { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitSwitchLabel(this);
      public BoundSwitchLabel Update(LabelSymbol label, BoundExpression expressionOpt, ConstantValue constantValueOpt)
      {
        if (label == this.Label && expressionOpt == this.ExpressionOpt && constantValueOpt == this.ConstantValueOpt)return this;
        var result = new BoundSwitchLabel(this.Syntax, Label, ExpressionOpt, ConstantValueOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundBreakStatement : BoundStatement
    {
      public BoundBreakStatement(SyntaxNode syntax, GeneratedLabelSymbol label, bool hasErrors) : base(BoundKind.BreakStatement, syntax, hasErrors)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
      }
      public BoundBreakStatement(SyntaxNode syntax, GeneratedLabelSymbol label) : base(BoundKind.BreakStatement, syntax)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  GeneratedLabelSymbol Label { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitBreakStatement(this);
      public BoundBreakStatement Update(GeneratedLabelSymbol label)
      {
        if (label == this.Label)return this;
        var result = new BoundBreakStatement(this.Syntax, Label, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundContinueStatement : BoundStatement
    {
      public BoundContinueStatement(SyntaxNode syntax, GeneratedLabelSymbol label, bool hasErrors) : base(BoundKind.ContinueStatement, syntax, hasErrors)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
      }
      public BoundContinueStatement(SyntaxNode syntax, GeneratedLabelSymbol label) : base(BoundKind.ContinueStatement, syntax)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  GeneratedLabelSymbol Label { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitContinueStatement(this);
      public BoundContinueStatement Update(GeneratedLabelSymbol label)
      {
        if (label == this.Label)return this;
        var result = new BoundContinueStatement(this.Syntax, Label, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPatternSwitchStatement : BoundStatement
    {
      public BoundPatternSwitchStatement(SyntaxNode syntax, BoundExpression expression, bool someLabelAlwaysMatches, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundPatternSwitchSection> switchSections, BoundPatternSwitchLabel defaultLabel, GeneratedLabelSymbol breakLabel, PatternSwitchBinder binder, bool isComplete,  bool hasErrors = false) : base(BoundKind.PatternSwitchStatement, syntax, hasErrors || expression.HasErrors() || switchSections.HasErrors() || defaultLabel.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!innerLocals.IsDefault, "Field 'innerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!innerLocalFunctions.IsDefault, "Field 'innerLocalFunctions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!switchSections.IsDefault, "Field 'switchSections' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(binder != null, "Field 'binder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
        this.SomeLabelAlwaysMatches = someLabelAlwaysMatches;
        this.InnerLocals = innerLocals;
        this.InnerLocalFunctions = innerLocalFunctions;
        this.SwitchSections = switchSections;
        this.DefaultLabel = defaultLabel;
        this.BreakLabel = breakLabel;
        this.Binder = binder;
        this.IsComplete = isComplete;
      }
      public  BoundExpression Expression { get; }
      public  bool SomeLabelAlwaysMatches { get; }
      public  ImmutableArray<LocalSymbol> InnerLocals { get; }
      public  ImmutableArray<LocalFunctionSymbol> InnerLocalFunctions { get; }
      public  ImmutableArray<BoundPatternSwitchSection> SwitchSections { get; }
      public  BoundPatternSwitchLabel DefaultLabel { get; }
      public  GeneratedLabelSymbol BreakLabel { get; }
      public  PatternSwitchBinder Binder { get; }
      public  bool IsComplete { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPatternSwitchStatement(this);
      public BoundPatternSwitchStatement Update(BoundExpression expression, bool someLabelAlwaysMatches, ImmutableArray<LocalSymbol> innerLocals, ImmutableArray<LocalFunctionSymbol> innerLocalFunctions, ImmutableArray<BoundPatternSwitchSection> switchSections, BoundPatternSwitchLabel defaultLabel, GeneratedLabelSymbol breakLabel, PatternSwitchBinder binder, bool isComplete)
      {
        if (expression == this.Expression && someLabelAlwaysMatches == this.SomeLabelAlwaysMatches && innerLocals == this.InnerLocals && innerLocalFunctions == this.InnerLocalFunctions && switchSections == this.SwitchSections && defaultLabel == this.DefaultLabel && breakLabel == this.BreakLabel && binder == this.Binder && isComplete == this.IsComplete)return this;
        var result = new BoundPatternSwitchStatement(this.Syntax, Expression, SomeLabelAlwaysMatches, InnerLocals, InnerLocalFunctions, SwitchSections, DefaultLabel, BreakLabel, Binder, IsComplete, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPatternSwitchSection : BoundStatementList
    {
      public BoundPatternSwitchSection(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundPatternSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(BoundKind.PatternSwitchSection, syntax, statements, hasErrors || switchLabels.HasErrors() || statements.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!switchLabels.IsDefault, "Field 'switchLabels' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.SwitchLabels = switchLabels;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  ImmutableArray<BoundPatternSwitchLabel> SwitchLabels { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPatternSwitchSection(this);
      public BoundPatternSwitchSection Update(ImmutableArray<LocalSymbol> locals, ImmutableArray<BoundPatternSwitchLabel> switchLabels, ImmutableArray<BoundStatement> statements)
      {
        if (locals == this.Locals && switchLabels == this.SwitchLabels && statements == this.Statements)return this;
        var result = new BoundPatternSwitchSection(this.Syntax, Locals, SwitchLabels, Statements, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPatternSwitchLabel : BoundNode
    {
      public BoundPatternSwitchLabel(SyntaxNode syntax, LabelSymbol label, BoundPattern pattern, BoundExpression guard, bool isReachable,  bool hasErrors = false) : base(BoundKind.PatternSwitchLabel, syntax, hasErrors || pattern.HasErrors() || guard.HasErrors())
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(pattern != null, "Field 'pattern' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
        this.Pattern = pattern;
        this.Guard = guard;
        this.IsReachable = isReachable;
      }
      public  LabelSymbol Label { get; }
      public  BoundPattern Pattern { get; }
      public  BoundExpression Guard { get; }
      public  bool IsReachable { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPatternSwitchLabel(this);
      public BoundPatternSwitchLabel Update(LabelSymbol label, BoundPattern pattern, BoundExpression guard, bool isReachable)
      {
        if (label == this.Label && pattern == this.Pattern && guard == this.Guard && isReachable == this.IsReachable)return this;
        var result = new BoundPatternSwitchLabel(this.Syntax, Label, Pattern, Guard, IsReachable, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundIfStatement : BoundStatement
    {
      public BoundIfStatement(SyntaxNode syntax, BoundExpression condition, BoundStatement consequence, BoundStatement alternativeOpt,  bool hasErrors = false) : base(BoundKind.IfStatement, syntax, hasErrors || condition.HasErrors() || consequence.HasErrors() || alternativeOpt.HasErrors())
      {
        Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(consequence != null, "Field 'consequence' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Condition = condition;
        this.Consequence = consequence;
        this.AlternativeOpt = alternativeOpt;
      }
      public  BoundExpression Condition { get; }
      public  BoundStatement Consequence { get; }
      public  BoundStatement AlternativeOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitIfStatement(this);
      public BoundIfStatement Update(BoundExpression condition, BoundStatement consequence, BoundStatement alternativeOpt)
      {
        if (condition == this.Condition && consequence == this.Consequence && alternativeOpt == this.AlternativeOpt)return this;
        var result = new BoundIfStatement(this.Syntax, Condition, Consequence, AlternativeOpt, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundLoopStatement : BoundStatement
    {
      protected BoundLoopStatement(BoundKind kind, SyntaxNode syntax, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel, bool hasErrors) : base(kind, syntax, hasErrors)
      {
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.BreakLabel = breakLabel;
        this.ContinueLabel = continueLabel;
      }
      protected BoundLoopStatement(BoundKind kind, SyntaxNode syntax, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel) : base(kind, syntax)
      {
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  GeneratedLabelSymbol BreakLabel { get; }
      public  GeneratedLabelSymbol ContinueLabel { get; }
    }

    internal sealed partial class BoundDoStatement : BoundLoopStatement
    {
      public BoundDoStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false) : base(BoundKind.DoStatement, syntax, breakLabel, continueLabel, hasErrors || condition.HasErrors() || body.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.Condition = condition;
        this.Body = body;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundExpression Condition { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDoStatement(this);
      public BoundDoStatement Update(ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
      {
        if (locals == this.Locals && condition == this.Condition && body == this.Body && breakLabel == this.BreakLabel && continueLabel == this.ContinueLabel)return this;
        var result = new BoundDoStatement(this.Syntax, Locals, Condition, Body, BreakLabel, ContinueLabel, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundWhileStatement : BoundLoopStatement
    {
      public BoundWhileStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false) : base(BoundKind.WhileStatement, syntax, breakLabel, continueLabel, hasErrors || condition.HasErrors() || body.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.Condition = condition;
        this.Body = body;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundExpression Condition { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitWhileStatement(this);
      public BoundWhileStatement Update(ImmutableArray<LocalSymbol> locals, BoundExpression condition, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
      {
        if (locals == this.Locals && condition == this.Condition && body == this.Body && breakLabel == this.BreakLabel && continueLabel == this.ContinueLabel)return this;
        var result = new BoundWhileStatement(this.Syntax, Locals, Condition, Body, BreakLabel, ContinueLabel, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundForStatement : BoundLoopStatement
    {
      public BoundForStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> outerLocals, BoundStatement initializer, ImmutableArray<LocalSymbol> innerLocals, BoundExpression condition, BoundStatement increment, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false) : base(BoundKind.ForStatement, syntax, breakLabel, continueLabel, hasErrors || initializer.HasErrors() || condition.HasErrors() || increment.HasErrors() || body.HasErrors())
      {
        Debug.Assert(!outerLocals.IsDefault, "Field 'outerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!innerLocals.IsDefault, "Field 'innerLocals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.OuterLocals = outerLocals;
        this.Initializer = initializer;
        this.InnerLocals = innerLocals;
        this.Condition = condition;
        this.Increment = increment;
        this.Body = body;
      }
      public  ImmutableArray<LocalSymbol> OuterLocals { get; }
      public  BoundStatement Initializer { get; }
      public  ImmutableArray<LocalSymbol> InnerLocals { get; }
      public  BoundExpression Condition { get; }
      public  BoundStatement Increment { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitForStatement(this);
      public BoundForStatement Update(ImmutableArray<LocalSymbol> outerLocals, BoundStatement initializer, ImmutableArray<LocalSymbol> innerLocals, BoundExpression condition, BoundStatement increment, BoundStatement body, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
      {
        if (outerLocals == this.OuterLocals && initializer == this.Initializer && innerLocals == this.InnerLocals && condition == this.Condition && increment == this.Increment && body == this.Body && breakLabel == this.BreakLabel && continueLabel == this.ContinueLabel)return this;
        var result = new BoundForStatement(this.Syntax, OuterLocals, Initializer, InnerLocals, Condition, Increment, Body, BreakLabel, ContinueLabel, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundForEachStatement : BoundLoopStatement
    {
      public BoundForEachStatement(SyntaxNode syntax, ForEachEnumeratorInfo enumeratorInfoOpt, Conversion elementConversion, BoundTypeExpression iterationVariableType, ImmutableArray<LocalSymbol> iterationVariables, BoundExpression iterationErrorExpressionOpt, BoundExpression expression, BoundForEachDeconstructStep deconstructionOpt, BoundStatement body, bool @checked, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel,  bool hasErrors = false) : base(BoundKind.ForEachStatement, syntax, breakLabel, continueLabel, hasErrors || iterationVariableType.HasErrors() || iterationErrorExpressionOpt.HasErrors() || expression.HasErrors() || deconstructionOpt.HasErrors() || body.HasErrors())
      {
        Debug.Assert(iterationVariableType != null, "Field 'iterationVariableType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!iterationVariables.IsDefault, "Field 'iterationVariables' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(breakLabel != null, "Field 'breakLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(continueLabel != null, "Field 'continueLabel' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.EnumeratorInfoOpt = enumeratorInfoOpt;
        this.ElementConversion = elementConversion;
        this.IterationVariableType = iterationVariableType;
        this.IterationVariables = iterationVariables;
        this.IterationErrorExpressionOpt = iterationErrorExpressionOpt;
        this.Expression = expression;
        this.DeconstructionOpt = deconstructionOpt;
        this.Body = body;
        this.Checked = @checked;
      }
      public  ForEachEnumeratorInfo EnumeratorInfoOpt { get; }
      public  Conversion ElementConversion { get; }
      public  BoundTypeExpression IterationVariableType { get; }
      public  ImmutableArray<LocalSymbol> IterationVariables { get; }
      public  BoundExpression IterationErrorExpressionOpt { get; }
      public  BoundExpression Expression { get; }
      public  BoundForEachDeconstructStep DeconstructionOpt { get; }
      public  BoundStatement Body { get; }
      public  bool Checked { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitForEachStatement(this);
      public BoundForEachStatement Update(ForEachEnumeratorInfo enumeratorInfoOpt, Conversion elementConversion, BoundTypeExpression iterationVariableType, ImmutableArray<LocalSymbol> iterationVariables, BoundExpression iterationErrorExpressionOpt, BoundExpression expression, BoundForEachDeconstructStep deconstructionOpt, BoundStatement body, bool @checked, GeneratedLabelSymbol breakLabel, GeneratedLabelSymbol continueLabel)
      {
        if (enumeratorInfoOpt == this.EnumeratorInfoOpt && elementConversion == this.ElementConversion && iterationVariableType == this.IterationVariableType && iterationVariables == this.IterationVariables && iterationErrorExpressionOpt == this.IterationErrorExpressionOpt && expression == this.Expression && deconstructionOpt == this.DeconstructionOpt && body == this.Body && @checked == this.Checked && breakLabel == this.BreakLabel && continueLabel == this.ContinueLabel)return this;
        var result = new BoundForEachStatement(this.Syntax, EnumeratorInfoOpt, ElementConversion, IterationVariableType, IterationVariables, IterationErrorExpressionOpt, Expression, DeconstructionOpt, Body, Checked, BreakLabel, ContinueLabel, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundForEachDeconstructStep : BoundNode
    {
      public BoundForEachDeconstructStep(SyntaxNode syntax, BoundDeconstructionAssignmentOperator deconstructionAssignment, BoundDeconstructValuePlaceholder targetPlaceholder,  bool hasErrors = false) : base(BoundKind.ForEachDeconstructStep, syntax, hasErrors || deconstructionAssignment.HasErrors() || targetPlaceholder.HasErrors())
      {
        Debug.Assert(deconstructionAssignment != null, "Field 'deconstructionAssignment' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(targetPlaceholder != null, "Field 'targetPlaceholder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.DeconstructionAssignment = deconstructionAssignment;
        this.TargetPlaceholder = targetPlaceholder;
      }
      public  BoundDeconstructionAssignmentOperator DeconstructionAssignment { get; }
      public  BoundDeconstructValuePlaceholder TargetPlaceholder { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitForEachDeconstructStep(this);
      public BoundForEachDeconstructStep Update(BoundDeconstructionAssignmentOperator deconstructionAssignment, BoundDeconstructValuePlaceholder targetPlaceholder)
      {
        if (deconstructionAssignment == this.DeconstructionAssignment && targetPlaceholder == this.TargetPlaceholder)return this;
        var result = new BoundForEachDeconstructStep(this.Syntax, DeconstructionAssignment, TargetPlaceholder, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundUsingStatement : BoundStatement
    {
      public BoundUsingStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarationsOpt, BoundExpression expressionOpt, Conversion iDisposableConversion, BoundStatement body,  bool hasErrors = false) : base(BoundKind.UsingStatement, syntax, hasErrors || declarationsOpt.HasErrors() || expressionOpt.HasErrors() || body.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.DeclarationsOpt = declarationsOpt;
        this.ExpressionOpt = expressionOpt;
        this.IDisposableConversion = iDisposableConversion;
        this.Body = body;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundMultipleLocalDeclarations DeclarationsOpt { get; }
      public  BoundExpression ExpressionOpt { get; }
      public  Conversion IDisposableConversion { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitUsingStatement(this);
      public BoundUsingStatement Update(ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarationsOpt, BoundExpression expressionOpt, Conversion iDisposableConversion, BoundStatement body)
      {
        if (locals == this.Locals && declarationsOpt == this.DeclarationsOpt && expressionOpt == this.ExpressionOpt && iDisposableConversion == this.IDisposableConversion && body == this.Body)return this;
        var result = new BoundUsingStatement(this.Syntax, Locals, DeclarationsOpt, ExpressionOpt, IDisposableConversion, Body, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundFixedStatement : BoundStatement
    {
      public BoundFixedStatement(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarations, BoundStatement body,  bool hasErrors = false) : base(BoundKind.FixedStatement, syntax, hasErrors || declarations.HasErrors() || body.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(declarations != null, "Field 'declarations' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.Declarations = declarations;
        this.Body = body;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundMultipleLocalDeclarations Declarations { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitFixedStatement(this);
      public BoundFixedStatement Update(ImmutableArray<LocalSymbol> locals, BoundMultipleLocalDeclarations declarations, BoundStatement body)
      {
        if (locals == this.Locals && declarations == this.Declarations && body == this.Body)return this;
        var result = new BoundFixedStatement(this.Syntax, Locals, Declarations, Body, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLockStatement : BoundStatement
    {
      public BoundLockStatement(SyntaxNode syntax, BoundExpression argument, BoundStatement body,  bool hasErrors = false) : base(BoundKind.LockStatement, syntax, hasErrors || argument.HasErrors() || body.HasErrors())
      {
        Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Argument = argument;
        this.Body = body;
      }
      public  BoundExpression Argument { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLockStatement(this);
      public BoundLockStatement Update(BoundExpression argument, BoundStatement body)
      {
        if (argument == this.Argument && body == this.Body)return this;
        var result = new BoundLockStatement(this.Syntax, Argument, Body, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundTryStatement : BoundStatement
    {
      public BoundTryStatement(SyntaxNode syntax, BoundBlock tryBlock, ImmutableArray<BoundCatchBlock> catchBlocks, BoundBlock finallyBlockOpt, bool preferFaultHandler,  bool hasErrors = false) : base(BoundKind.TryStatement, syntax, hasErrors || tryBlock.HasErrors() || catchBlocks.HasErrors() || finallyBlockOpt.HasErrors())
      {
        Debug.Assert(tryBlock != null, "Field 'tryBlock' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!catchBlocks.IsDefault, "Field 'catchBlocks' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.TryBlock = tryBlock;
        this.CatchBlocks = catchBlocks;
        this.FinallyBlockOpt = finallyBlockOpt;
        this.PreferFaultHandler = preferFaultHandler;
      }
      public  BoundBlock TryBlock { get; }
      public  ImmutableArray<BoundCatchBlock> CatchBlocks { get; }
      public  BoundBlock FinallyBlockOpt { get; }
      public  bool PreferFaultHandler { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTryStatement(this);
      public BoundTryStatement Update(BoundBlock tryBlock, ImmutableArray<BoundCatchBlock> catchBlocks, BoundBlock finallyBlockOpt, bool preferFaultHandler)
      {
        if (tryBlock == this.TryBlock && catchBlocks == this.CatchBlocks && finallyBlockOpt == this.FinallyBlockOpt && preferFaultHandler == this.PreferFaultHandler)return this;
        var result = new BoundTryStatement(this.Syntax, TryBlock, CatchBlocks, FinallyBlockOpt, PreferFaultHandler, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundCatchBlock : BoundNode
    {
      public BoundCatchBlock(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpression exceptionSourceOpt, TypeSymbol exceptionTypeOpt, BoundExpression exceptionFilterOpt, BoundBlock body, bool isSynthesizedAsyncCatchAll,  bool hasErrors = false) : base(BoundKind.CatchBlock, syntax, hasErrors || exceptionSourceOpt.HasErrors() || exceptionFilterOpt.HasErrors() || body.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.ExceptionSourceOpt = exceptionSourceOpt;
        this.ExceptionTypeOpt = exceptionTypeOpt;
        this.ExceptionFilterOpt = exceptionFilterOpt;
        this.Body = body;
        this.IsSynthesizedAsyncCatchAll = isSynthesizedAsyncCatchAll;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundExpression ExceptionSourceOpt { get; }
      public  TypeSymbol ExceptionTypeOpt { get; }
      public  BoundExpression ExceptionFilterOpt { get; }
      public  BoundBlock Body { get; }
      public  bool IsSynthesizedAsyncCatchAll { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitCatchBlock(this);
      public BoundCatchBlock Update(ImmutableArray<LocalSymbol> locals, BoundExpression exceptionSourceOpt, TypeSymbol exceptionTypeOpt, BoundExpression exceptionFilterOpt, BoundBlock body, bool isSynthesizedAsyncCatchAll)
      {
        if (locals == this.Locals && exceptionSourceOpt == this.ExceptionSourceOpt && exceptionTypeOpt == this.ExceptionTypeOpt && exceptionFilterOpt == this.ExceptionFilterOpt && body == this.Body && isSynthesizedAsyncCatchAll == this.IsSynthesizedAsyncCatchAll)return this;
        var result = new BoundCatchBlock(this.Syntax, Locals, ExceptionSourceOpt, ExceptionTypeOpt, ExceptionFilterOpt, Body, IsSynthesizedAsyncCatchAll, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLiteral : BoundExpression
    {
      public BoundLiteral(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type, bool hasErrors) : base(BoundKind.Literal, syntax, type, hasErrors)
      {
        this.ConstantValueOpt = constantValueOpt;
      }
      public BoundLiteral(SyntaxNode syntax, ConstantValue constantValueOpt, TypeSymbol type) : base(BoundKind.Literal, syntax, type)
      {
      }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLiteral(this);
      public BoundLiteral Update(ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundLiteral(this.Syntax, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundThisReference : BoundExpression
    {
      public BoundThisReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.ThisReference, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundThisReference(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.ThisReference, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitThisReference(this);
      public BoundThisReference Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundThisReference(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPreviousSubmissionReference : BoundExpression
    {
      public BoundPreviousSubmissionReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.PreviousSubmissionReference, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundPreviousSubmissionReference(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.PreviousSubmissionReference, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPreviousSubmissionReference(this);
      public BoundPreviousSubmissionReference Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundPreviousSubmissionReference(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundHostObjectMemberReference : BoundExpression
    {
      public BoundHostObjectMemberReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.HostObjectMemberReference, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundHostObjectMemberReference(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.HostObjectMemberReference, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitHostObjectMemberReference(this);
      public BoundHostObjectMemberReference Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundHostObjectMemberReference(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundBaseReference : BoundExpression
    {
      public BoundBaseReference(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.BaseReference, syntax, type, hasErrors)
      {
      }
      public BoundBaseReference(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.BaseReference, syntax, type)
      {
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitBaseReference(this);
      public BoundBaseReference Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundBaseReference(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLocal : BoundExpression
    {
      public BoundLocal(SyntaxNode syntax, LocalSymbol localSymbol, bool isDeclaration, ConstantValue constantValueOpt, TypeSymbol type, bool hasErrors) : base(BoundKind.Local, syntax, type, hasErrors)
      {
        Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.LocalSymbol = localSymbol;
        this.IsDeclaration = isDeclaration;
        this.ConstantValueOpt = constantValueOpt;
      }
      public BoundLocal(SyntaxNode syntax, LocalSymbol localSymbol, bool isDeclaration, ConstantValue constantValueOpt, TypeSymbol type) : base(BoundKind.Local, syntax, type)
      {
        Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  LocalSymbol LocalSymbol { get; }
      public  bool IsDeclaration { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLocal(this);
      public BoundLocal Update(LocalSymbol localSymbol, bool isDeclaration, ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (localSymbol == this.LocalSymbol && isDeclaration == this.IsDeclaration && constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundLocal(this.Syntax, LocalSymbol, IsDeclaration, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPseudoVariable : BoundExpression
    {
      public BoundPseudoVariable(SyntaxNode syntax, LocalSymbol localSymbol, PseudoVariableExpressions emitExpressions, TypeSymbol type, bool hasErrors) : base(BoundKind.PseudoVariable, syntax, type, hasErrors)
      {
        Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(emitExpressions != null, "Field 'emitExpressions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.LocalSymbol = localSymbol;
        this.EmitExpressions = emitExpressions;
      }
      public BoundPseudoVariable(SyntaxNode syntax, LocalSymbol localSymbol, PseudoVariableExpressions emitExpressions, TypeSymbol type) : base(BoundKind.PseudoVariable, syntax, type)
      {
        Debug.Assert(localSymbol != null, "Field 'localSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(emitExpressions != null, "Field 'emitExpressions' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  LocalSymbol LocalSymbol { get; }
      public  PseudoVariableExpressions EmitExpressions { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPseudoVariable(this);
      public BoundPseudoVariable Update(LocalSymbol localSymbol, PseudoVariableExpressions emitExpressions, TypeSymbol type)
      {
        if (localSymbol == this.LocalSymbol && emitExpressions == this.EmitExpressions && type == this.Type)return this;
        var result = new BoundPseudoVariable(this.Syntax, LocalSymbol, EmitExpressions, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundRangeVariable : BoundExpression
    {
      public BoundRangeVariable(SyntaxNode syntax, RangeVariableSymbol rangeVariableSymbol, BoundExpression value, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.RangeVariable, syntax, type, hasErrors || value.HasErrors())
      {
        Debug.Assert(rangeVariableSymbol != null, "Field 'rangeVariableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.RangeVariableSymbol = rangeVariableSymbol;
        this.Value = value;
      }
      public  RangeVariableSymbol RangeVariableSymbol { get; }
      public  BoundExpression Value { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitRangeVariable(this);
      public BoundRangeVariable Update(RangeVariableSymbol rangeVariableSymbol, BoundExpression value, TypeSymbol type)
      {
        if (rangeVariableSymbol == this.RangeVariableSymbol && value == this.Value && type == this.Type)return this;
        var result = new BoundRangeVariable(this.Syntax, RangeVariableSymbol, Value, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundParameter : BoundExpression
    {
      public BoundParameter(SyntaxNode syntax, ParameterSymbol parameterSymbol, TypeSymbol type, bool hasErrors) : base(BoundKind.Parameter, syntax, type, hasErrors)
      {
        Debug.Assert(parameterSymbol != null, "Field 'parameterSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ParameterSymbol = parameterSymbol;
      }
      public BoundParameter(SyntaxNode syntax, ParameterSymbol parameterSymbol, TypeSymbol type) : base(BoundKind.Parameter, syntax, type)
      {
        Debug.Assert(parameterSymbol != null, "Field 'parameterSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  ParameterSymbol ParameterSymbol { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitParameter(this);
      public BoundParameter Update(ParameterSymbol parameterSymbol, TypeSymbol type)
      {
        if (parameterSymbol == this.ParameterSymbol && type == this.Type)return this;
        var result = new BoundParameter(this.Syntax, ParameterSymbol, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLabelStatement : BoundStatement
    {
      public BoundLabelStatement(SyntaxNode syntax, LabelSymbol label, bool hasErrors) : base(BoundKind.LabelStatement, syntax, hasErrors)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
      }
      public BoundLabelStatement(SyntaxNode syntax, LabelSymbol label) : base(BoundKind.LabelStatement, syntax)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  LabelSymbol Label { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLabelStatement(this);
      public BoundLabelStatement Update(LabelSymbol label)
      {
        if (label == this.Label)return this;
        var result = new BoundLabelStatement(this.Syntax, Label, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundGotoStatement : BoundStatement
    {
      public BoundGotoStatement(SyntaxNode syntax, LabelSymbol label, BoundExpression caseExpressionOpt, BoundLabel labelExpressionOpt,  bool hasErrors = false) : base(BoundKind.GotoStatement, syntax, hasErrors || caseExpressionOpt.HasErrors() || labelExpressionOpt.HasErrors())
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
        this.CaseExpressionOpt = caseExpressionOpt;
        this.LabelExpressionOpt = labelExpressionOpt;
      }
      public  LabelSymbol Label { get; }
      public  BoundExpression CaseExpressionOpt { get; }
      public  BoundLabel LabelExpressionOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitGotoStatement(this);
      public BoundGotoStatement Update(LabelSymbol label, BoundExpression caseExpressionOpt, BoundLabel labelExpressionOpt)
      {
        if (label == this.Label && caseExpressionOpt == this.CaseExpressionOpt && labelExpressionOpt == this.LabelExpressionOpt)return this;
        var result = new BoundGotoStatement(this.Syntax, Label, CaseExpressionOpt, LabelExpressionOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLabeledStatement : BoundStatement
    {
      public BoundLabeledStatement(SyntaxNode syntax, LabelSymbol label, BoundStatement body,  bool hasErrors = false) : base(BoundKind.LabeledStatement, syntax, hasErrors || body.HasErrors())
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
        this.Body = body;
      }
      public  LabelSymbol Label { get; }
      public  BoundStatement Body { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLabeledStatement(this);
      public BoundLabeledStatement Update(LabelSymbol label, BoundStatement body)
      {
        if (label == this.Label && body == this.Body)return this;
        var result = new BoundLabeledStatement(this.Syntax, Label, Body, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLabel : BoundExpression
    {
      public BoundLabel(SyntaxNode syntax, LabelSymbol label, TypeSymbol type, bool hasErrors) : base(BoundKind.Label, syntax, type, hasErrors)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Label = label;
      }
      public BoundLabel(SyntaxNode syntax, LabelSymbol label, TypeSymbol type) : base(BoundKind.Label, syntax, type)
      {
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  LabelSymbol Label { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLabel(this);
      public BoundLabel Update(LabelSymbol label, TypeSymbol type)
      {
        if (label == this.Label && type == this.Type)return this;
        var result = new BoundLabel(this.Syntax, Label, Type, this.HasErrors);
        return result;
      }
    }

    internal partial class BoundStatementList : BoundStatement
    {
      protected BoundStatementList(BoundKind kind, SyntaxNode syntax, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(kind, syntax, hasErrors)
      {
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Statements = statements;
      }
      public BoundStatementList(SyntaxNode syntax, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(BoundKind.StatementList, syntax, hasErrors || statements.HasErrors())
      {
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Statements = statements;
      }
      public  ImmutableArray<BoundStatement> Statements { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitStatementList(this);
      public BoundStatementList Update(ImmutableArray<BoundStatement> statements)
      {
        if (statements == this.Statements)return this;
        var result = new BoundStatementList(this.Syntax, Statements, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConditionalGoto : BoundStatement
    {
      public BoundConditionalGoto(SyntaxNode syntax, BoundExpression condition, bool jumpIfTrue, LabelSymbol label,  bool hasErrors = false) : base(BoundKind.ConditionalGoto, syntax, hasErrors || condition.HasErrors())
      {
        Debug.Assert(condition != null, "Field 'condition' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(label != null, "Field 'label' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Condition = condition;
        this.JumpIfTrue = jumpIfTrue;
        this.Label = label;
      }
      public  BoundExpression Condition { get; }
      public  bool JumpIfTrue { get; }
      public  LabelSymbol Label { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConditionalGoto(this);
      public BoundConditionalGoto Update(BoundExpression condition, bool jumpIfTrue, LabelSymbol label)
      {
        if (condition == this.Condition && jumpIfTrue == this.JumpIfTrue && label == this.Label)return this;
        var result = new BoundConditionalGoto(this.Syntax, Condition, JumpIfTrue, Label, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundMethodOrPropertyGroup : BoundExpression
    {
      protected BoundMethodOrPropertyGroup(BoundKind kind, SyntaxNode syntax, BoundExpression receiverOpt, LookupResultKind resultKind,  bool hasErrors = false) : base(kind, syntax, null, hasErrors)
      {
        this.ReceiverOpt = receiverOpt;
        this.ResultKind = resultKind;
      }
      public  BoundExpression ReceiverOpt { get; }
      public override LookupResultKind ResultKind { get; }
    }

    internal sealed partial class BoundDynamicMemberAccess : BoundExpression
    {
      public BoundDynamicMemberAccess(SyntaxNode syntax, BoundExpression receiver, ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, bool invoked, bool indexed, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DynamicMemberAccess, syntax, type, hasErrors || receiver.HasErrors())
      {
        Debug.Assert(receiver != null, "Field 'receiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(name != null, "Field 'name' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Receiver = receiver;
        this.TypeArgumentsOpt = typeArgumentsOpt;
        this.Name = name;
        this.Invoked = invoked;
        this.Indexed = indexed;
      }
      public  BoundExpression Receiver { get; }
      public  ImmutableArray<TypeSymbol> TypeArgumentsOpt { get; }
      public  string Name { get; }
      public  bool Invoked { get; }
      public  bool Indexed { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDynamicMemberAccess(this);
      public BoundDynamicMemberAccess Update(BoundExpression receiver, ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, bool invoked, bool indexed, TypeSymbol type)
      {
        if (receiver == this.Receiver && typeArgumentsOpt == this.TypeArgumentsOpt && name == this.Name && invoked == this.Invoked && indexed == this.Indexed && type == this.Type)return this;
        var result = new BoundDynamicMemberAccess(this.Syntax, Receiver, TypeArgumentsOpt, Name, Invoked, Indexed, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDynamicInvocation : BoundExpression
    {
      public BoundDynamicInvocation(SyntaxNode syntax, BoundExpression expression, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DynamicInvocation, syntax, type, hasErrors || expression.HasErrors() || arguments.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!applicableMethods.IsDefault, "Field 'applicableMethods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.ApplicableMethods = applicableMethods;
      }
      public  BoundExpression Expression { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  ImmutableArray<MethodSymbol> ApplicableMethods { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDynamicInvocation(this);
      public BoundDynamicInvocation Update(BoundExpression expression, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type)
      {
        if (expression == this.Expression && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && applicableMethods == this.ApplicableMethods && type == this.Type)return this;
        var result = new BoundDynamicInvocation(this.Syntax, Expression, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, ApplicableMethods, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConditionalAccess : BoundExpression
    {
      public BoundConditionalAccess(SyntaxNode syntax, BoundExpression receiver, BoundExpression accessExpression, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ConditionalAccess, syntax, type, hasErrors || receiver.HasErrors() || accessExpression.HasErrors())
      {
        Debug.Assert(receiver != null, "Field 'receiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(accessExpression != null, "Field 'accessExpression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Receiver = receiver;
        this.AccessExpression = accessExpression;
      }
      public  BoundExpression Receiver { get; }
      public  BoundExpression AccessExpression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConditionalAccess(this);
      public BoundConditionalAccess Update(BoundExpression receiver, BoundExpression accessExpression, TypeSymbol type)
      {
        if (receiver == this.Receiver && accessExpression == this.AccessExpression && type == this.Type)return this;
        var result = new BoundConditionalAccess(this.Syntax, Receiver, AccessExpression, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLoweredConditionalAccess : BoundExpression
    {
      public BoundLoweredConditionalAccess(SyntaxNode syntax, BoundExpression receiver, MethodSymbol hasValueMethodOpt, BoundExpression whenNotNull, BoundExpression whenNullOpt, int id, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.LoweredConditionalAccess, syntax, type, hasErrors || receiver.HasErrors() || whenNotNull.HasErrors() || whenNullOpt.HasErrors())
      {
        Debug.Assert(receiver != null, "Field 'receiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(whenNotNull != null, "Field 'whenNotNull' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Receiver = receiver;
        this.HasValueMethodOpt = hasValueMethodOpt;
        this.WhenNotNull = whenNotNull;
        this.WhenNullOpt = whenNullOpt;
        this.Id = id;
      }
      public  BoundExpression Receiver { get; }
      public  MethodSymbol HasValueMethodOpt { get; }
      public  BoundExpression WhenNotNull { get; }
      public  BoundExpression WhenNullOpt { get; }
      public  int Id { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLoweredConditionalAccess(this);
      public BoundLoweredConditionalAccess Update(BoundExpression receiver, MethodSymbol hasValueMethodOpt, BoundExpression whenNotNull, BoundExpression whenNullOpt, int id, TypeSymbol type)
      {
        if (receiver == this.Receiver && hasValueMethodOpt == this.HasValueMethodOpt && whenNotNull == this.WhenNotNull && whenNullOpt == this.WhenNullOpt && id == this.Id && type == this.Type)return this;
        var result = new BoundLoweredConditionalAccess(this.Syntax, Receiver, HasValueMethodOpt, WhenNotNull, WhenNullOpt, Id, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConditionalReceiver : BoundExpression
    {
      public BoundConditionalReceiver(SyntaxNode syntax, int id, TypeSymbol type, bool hasErrors) : base(BoundKind.ConditionalReceiver, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Id = id;
      }
      public BoundConditionalReceiver(SyntaxNode syntax, int id, TypeSymbol type) : base(BoundKind.ConditionalReceiver, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  int Id { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConditionalReceiver(this);
      public BoundConditionalReceiver Update(int id, TypeSymbol type)
      {
        if (id == this.Id && type == this.Type)return this;
        var result = new BoundConditionalReceiver(this.Syntax, Id, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundComplexConditionalReceiver : BoundExpression
    {
      public BoundComplexConditionalReceiver(SyntaxNode syntax, BoundExpression valueTypeReceiver, BoundExpression referenceTypeReceiver, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ComplexConditionalReceiver, syntax, type, hasErrors || valueTypeReceiver.HasErrors() || referenceTypeReceiver.HasErrors())
      {
        Debug.Assert(valueTypeReceiver != null, "Field 'valueTypeReceiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(referenceTypeReceiver != null, "Field 'referenceTypeReceiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ValueTypeReceiver = valueTypeReceiver;
        this.ReferenceTypeReceiver = referenceTypeReceiver;
      }
      public  BoundExpression ValueTypeReceiver { get; }
      public  BoundExpression ReferenceTypeReceiver { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitComplexConditionalReceiver(this);
      public BoundComplexConditionalReceiver Update(BoundExpression valueTypeReceiver, BoundExpression referenceTypeReceiver, TypeSymbol type)
      {
        if (valueTypeReceiver == this.ValueTypeReceiver && referenceTypeReceiver == this.ReferenceTypeReceiver && type == this.Type)return this;
        var result = new BoundComplexConditionalReceiver(this.Syntax, ValueTypeReceiver, ReferenceTypeReceiver, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundMethodGroup : BoundMethodOrPropertyGroup
    {
      public BoundMethodGroup(SyntaxNode syntax, ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, ImmutableArray<MethodSymbol> methods, Symbol lookupSymbolOpt, DiagnosticInfo lookupError, BoundMethodGroupFlags flags, BoundExpression receiverOpt, LookupResultKind resultKind,  bool hasErrors = false) : base(BoundKind.MethodGroup, syntax, receiverOpt, resultKind, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(name != null, "Field 'name' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!methods.IsDefault, "Field 'methods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.TypeArgumentsOpt = typeArgumentsOpt;
        this.Name = name;
        this.Methods = methods;
        this.LookupSymbolOpt = lookupSymbolOpt;
        this.LookupError = lookupError;
        this.Flags = flags;
      }
      public  ImmutableArray<TypeSymbol> TypeArgumentsOpt { get; }
      public  string Name { get; }
      public  ImmutableArray<MethodSymbol> Methods { get; }
      public  Symbol LookupSymbolOpt { get; }
      public  DiagnosticInfo LookupError { get; }
      public  BoundMethodGroupFlags Flags { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitMethodGroup(this);
      public BoundMethodGroup Update(ImmutableArray<TypeSymbol> typeArgumentsOpt, string name, ImmutableArray<MethodSymbol> methods, Symbol lookupSymbolOpt, DiagnosticInfo lookupError, BoundMethodGroupFlags flags, BoundExpression receiverOpt, LookupResultKind resultKind)
      {
        if (typeArgumentsOpt == this.TypeArgumentsOpt && name == this.Name && methods == this.Methods && lookupSymbolOpt == this.LookupSymbolOpt && lookupError == this.LookupError && flags == this.Flags && receiverOpt == this.ReceiverOpt && resultKind == this.ResultKind)return this;
        var result = new BoundMethodGroup(this.Syntax, TypeArgumentsOpt, Name, Methods, LookupSymbolOpt, LookupError, Flags, ReceiverOpt, ResultKind, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPropertyGroup : BoundMethodOrPropertyGroup
    {
      public BoundPropertyGroup(SyntaxNode syntax, ImmutableArray<PropertySymbol> properties, BoundExpression receiverOpt, LookupResultKind resultKind,  bool hasErrors = false) : base(BoundKind.PropertyGroup, syntax, receiverOpt, resultKind, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(!properties.IsDefault, "Field 'properties' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Properties = properties;
      }
      public  ImmutableArray<PropertySymbol> Properties { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPropertyGroup(this);
      public BoundPropertyGroup Update(ImmutableArray<PropertySymbol> properties, BoundExpression receiverOpt, LookupResultKind resultKind)
      {
        if (properties == this.Properties && receiverOpt == this.ReceiverOpt && resultKind == this.ResultKind)return this;
        var result = new BoundPropertyGroup(this.Syntax, Properties, ReceiverOpt, ResultKind, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundCall : BoundExpression
    {
      public BoundCall(SyntaxNode syntax, BoundExpression receiverOpt, MethodSymbol method, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool isDelegateCall, bool expanded, bool invokedAsExtensionMethod, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.Call, syntax, type, hasErrors || receiverOpt.HasErrors() || arguments.HasErrors())
      {
        Debug.Assert(method != null, "Field 'method' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ReceiverOpt = receiverOpt;
        this.Method = method;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.IsDelegateCall = isDelegateCall;
        this.Expanded = expanded;
        this.InvokedAsExtensionMethod = invokedAsExtensionMethod;
        this.ArgsToParamsOpt = argsToParamsOpt;
        this.ResultKind = resultKind;
        this.BinderOpt = binderOpt;
      }
      public  BoundExpression ReceiverOpt { get; }
      public  MethodSymbol Method { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  bool IsDelegateCall { get; }
      public  bool Expanded { get; }
      public  bool InvokedAsExtensionMethod { get; }
      public  ImmutableArray<int> ArgsToParamsOpt { get; }
      public override LookupResultKind ResultKind { get; }
      public  Binder BinderOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitCall(this);
      public BoundCall Update(BoundExpression receiverOpt, MethodSymbol method, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool isDelegateCall, bool expanded, bool invokedAsExtensionMethod, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type)
      {
        if (receiverOpt == this.ReceiverOpt && method == this.Method && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && isDelegateCall == this.IsDelegateCall && expanded == this.Expanded && invokedAsExtensionMethod == this.InvokedAsExtensionMethod && argsToParamsOpt == this.ArgsToParamsOpt && resultKind == this.ResultKind && binderOpt == this.BinderOpt && type == this.Type)return this;
        var result = new BoundCall(this.Syntax, ReceiverOpt, Method, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, IsDelegateCall, Expanded, InvokedAsExtensionMethod, ArgsToParamsOpt, ResultKind, BinderOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundEventAssignmentOperator : BoundExpression
    {
      public BoundEventAssignmentOperator(SyntaxNode syntax, EventSymbol @event, bool isAddition, bool isDynamic, BoundExpression receiverOpt, BoundExpression argument, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.EventAssignmentOperator, syntax, type, hasErrors || receiverOpt.HasErrors() || argument.HasErrors())
      {
        Debug.Assert(@event != null, "Field '@event' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Event = @event;
        this.IsAddition = isAddition;
        this.IsDynamic = isDynamic;
        this.ReceiverOpt = receiverOpt;
        this.Argument = argument;
      }
      public  EventSymbol Event { get; }
      public  bool IsAddition { get; }
      public  bool IsDynamic { get; }
      public  BoundExpression ReceiverOpt { get; }
      public  BoundExpression Argument { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitEventAssignmentOperator(this);
      public BoundEventAssignmentOperator Update(EventSymbol @event, bool isAddition, bool isDynamic, BoundExpression receiverOpt, BoundExpression argument, TypeSymbol type)
      {
        if (@event == this.Event && isAddition == this.IsAddition && isDynamic == this.IsDynamic && receiverOpt == this.ReceiverOpt && argument == this.Argument && type == this.Type)return this;
        var result = new BoundEventAssignmentOperator(this.Syntax, Event, IsAddition, IsDynamic, ReceiverOpt, Argument, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAttribute : BoundExpression
    {
      public BoundAttribute(SyntaxNode syntax, MethodSymbol constructor, ImmutableArray<BoundExpression> constructorArguments, ImmutableArray<string> constructorArgumentNamesOpt, ImmutableArray<BoundExpression> namedArguments, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.Attribute, syntax, type, hasErrors || constructorArguments.HasErrors() || namedArguments.HasErrors())
      {
        Debug.Assert(!constructorArguments.IsDefault, "Field 'constructorArguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!namedArguments.IsDefault, "Field 'namedArguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Constructor = constructor;
        this.ConstructorArguments = constructorArguments;
        this.ConstructorArgumentNamesOpt = constructorArgumentNamesOpt;
        this.NamedArguments = namedArguments;
        this.ResultKind = resultKind;
      }
      public  MethodSymbol Constructor { get; }
      public  ImmutableArray<BoundExpression> ConstructorArguments { get; }
      public  ImmutableArray<string> ConstructorArgumentNamesOpt { get; }
      public  ImmutableArray<BoundExpression> NamedArguments { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAttribute(this);
      public BoundAttribute Update(MethodSymbol constructor, ImmutableArray<BoundExpression> constructorArguments, ImmutableArray<string> constructorArgumentNamesOpt, ImmutableArray<BoundExpression> namedArguments, LookupResultKind resultKind, TypeSymbol type)
      {
        if (constructor == this.Constructor && constructorArguments == this.ConstructorArguments && constructorArgumentNamesOpt == this.ConstructorArgumentNamesOpt && namedArguments == this.NamedArguments && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundAttribute(this.Syntax, Constructor, ConstructorArguments, ConstructorArgumentNamesOpt, NamedArguments, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundObjectCreationExpression : BoundExpression
    {
      public BoundObjectCreationExpression(SyntaxNode syntax, MethodSymbol constructor, ImmutableArray<MethodSymbol> constructorsGroup, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, ConstantValue constantValueOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, Binder binderOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ObjectCreationExpression, syntax, type, hasErrors || arguments.HasErrors() || initializerExpressionOpt.HasErrors())
      {
        Debug.Assert(constructor != null, "Field 'constructor' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!constructorsGroup.IsDefault, "Field 'constructorsGroup' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Constructor = constructor;
        this.ConstructorsGroup = constructorsGroup;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.Expanded = expanded;
        this.ArgsToParamsOpt = argsToParamsOpt;
        this.ConstantValueOpt = constantValueOpt;
        this.InitializerExpressionOpt = initializerExpressionOpt;
        this.BinderOpt = binderOpt;
      }
      public  MethodSymbol Constructor { get; }
      public  ImmutableArray<MethodSymbol> ConstructorsGroup { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  bool Expanded { get; }
      public  ImmutableArray<int> ArgsToParamsOpt { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }
      public  Binder BinderOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitObjectCreationExpression(this);
      public BoundObjectCreationExpression Update(MethodSymbol constructor, ImmutableArray<MethodSymbol> constructorsGroup, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, ConstantValue constantValueOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, Binder binderOpt, TypeSymbol type)
      {
        if (constructor == this.Constructor && constructorsGroup == this.ConstructorsGroup && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && expanded == this.Expanded && argsToParamsOpt == this.ArgsToParamsOpt && constantValueOpt == this.ConstantValueOpt && initializerExpressionOpt == this.InitializerExpressionOpt && binderOpt == this.BinderOpt && type == this.Type)return this;
        var result = new BoundObjectCreationExpression(this.Syntax, Constructor, ConstructorsGroup, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, Expanded, ArgsToParamsOpt, ConstantValueOpt, InitializerExpressionOpt, BinderOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundTupleExpression : BoundExpression
    {
      protected BoundTupleExpression(BoundKind kind, SyntaxNode syntax, ImmutableArray<BoundExpression> arguments, TypeSymbol type,  bool hasErrors = false) : base(kind, syntax, type, hasErrors)
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Arguments = arguments;
      }
      public  ImmutableArray<BoundExpression> Arguments { get; }
    }

    internal sealed partial class BoundTupleLiteral : BoundTupleExpression
    {
      public BoundTupleLiteral(SyntaxNode syntax, ImmutableArray<string> argumentNamesOpt, ImmutableArray<bool> inferredNamesOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.TupleLiteral, syntax, arguments, type, hasErrors || arguments.HasErrors())
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.InferredNamesOpt = inferredNamesOpt;
      }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<bool> InferredNamesOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTupleLiteral(this);
      public BoundTupleLiteral Update(ImmutableArray<string> argumentNamesOpt, ImmutableArray<bool> inferredNamesOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type)
      {
        if (argumentNamesOpt == this.ArgumentNamesOpt && inferredNamesOpt == this.InferredNamesOpt && arguments == this.Arguments && type == this.Type)return this;
        var result = new BoundTupleLiteral(this.Syntax, ArgumentNamesOpt, InferredNamesOpt, Arguments, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConvertedTupleLiteral : BoundTupleExpression
    {
      public BoundConvertedTupleLiteral(SyntaxNode syntax, TypeSymbol naturalTypeOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ConvertedTupleLiteral, syntax, arguments, type, hasErrors || arguments.HasErrors())
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.NaturalTypeOpt = naturalTypeOpt;
      }
      public  TypeSymbol NaturalTypeOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConvertedTupleLiteral(this);
      public BoundConvertedTupleLiteral Update(TypeSymbol naturalTypeOpt, ImmutableArray<BoundExpression> arguments, TypeSymbol type)
      {
        if (naturalTypeOpt == this.NaturalTypeOpt && arguments == this.Arguments && type == this.Type)return this;
        var result = new BoundConvertedTupleLiteral(this.Syntax, NaturalTypeOpt, Arguments, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDynamicObjectCreationExpression : BoundExpression
    {
      public BoundDynamicObjectCreationExpression(SyntaxNode syntax, string name, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DynamicObjectCreationExpression, syntax, type, hasErrors || arguments.HasErrors() || initializerExpressionOpt.HasErrors())
      {
        Debug.Assert(name != null, "Field 'name' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!applicableMethods.IsDefault, "Field 'applicableMethods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Name = name;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.InitializerExpressionOpt = initializerExpressionOpt;
        this.ApplicableMethods = applicableMethods;
      }
      public  string Name { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }
      public  ImmutableArray<MethodSymbol> ApplicableMethods { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDynamicObjectCreationExpression(this);
      public BoundDynamicObjectCreationExpression Update(string name, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, BoundObjectInitializerExpressionBase initializerExpressionOpt, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type)
      {
        if (name == this.Name && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && initializerExpressionOpt == this.InitializerExpressionOpt && applicableMethods == this.ApplicableMethods && type == this.Type)return this;
        var result = new BoundDynamicObjectCreationExpression(this.Syntax, Name, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, InitializerExpressionOpt, ApplicableMethods, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundNoPiaObjectCreationExpression : BoundExpression
    {
      public BoundNoPiaObjectCreationExpression(SyntaxNode syntax, string guidString, BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.NoPiaObjectCreationExpression, syntax, type, hasErrors || initializerExpressionOpt.HasErrors())
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.GuidString = guidString;
        this.InitializerExpressionOpt = initializerExpressionOpt;
      }
      public  string GuidString { get; }
      public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNoPiaObjectCreationExpression(this);
      public BoundNoPiaObjectCreationExpression Update(string guidString, BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type)
      {
        if (guidString == this.GuidString && initializerExpressionOpt == this.InitializerExpressionOpt && type == this.Type)return this;
        var result = new BoundNoPiaObjectCreationExpression(this.Syntax, GuidString, InitializerExpressionOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundObjectInitializerExpressionBase : BoundExpression
    {
      protected BoundObjectInitializerExpressionBase(BoundKind kind, SyntaxNode syntax, ImmutableArray<BoundExpression> initializers, TypeSymbol type,  bool hasErrors = false) : base(kind, syntax, type, hasErrors)
      {
        Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Initializers = initializers;
      }
      public  ImmutableArray<BoundExpression> Initializers { get; }
    }

    internal sealed partial class BoundObjectInitializerExpression : BoundObjectInitializerExpressionBase
    {
      public BoundObjectInitializerExpression(SyntaxNode syntax, ImmutableArray<BoundExpression> initializers, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ObjectInitializerExpression, syntax, initializers, type, hasErrors || initializers.HasErrors())
      {
        Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitObjectInitializerExpression(this);
      public BoundObjectInitializerExpression Update(ImmutableArray<BoundExpression> initializers, TypeSymbol type)
      {
        if (initializers == this.Initializers && type == this.Type)return this;
        var result = new BoundObjectInitializerExpression(this.Syntax, Initializers, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundObjectInitializerMember : BoundExpression
    {
      public BoundObjectInitializerMember(SyntaxNode syntax, Symbol memberSymbol, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, TypeSymbol receiverType, Binder binderOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ObjectInitializerMember, syntax, type, hasErrors || arguments.HasErrors())
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(receiverType != null, "Field 'receiverType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.MemberSymbol = memberSymbol;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.Expanded = expanded;
        this.ArgsToParamsOpt = argsToParamsOpt;
        this.ResultKind = resultKind;
        this.ReceiverType = receiverType;
        this.BinderOpt = binderOpt;
      }
      public  Symbol MemberSymbol { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  bool Expanded { get; }
      public  ImmutableArray<int> ArgsToParamsOpt { get; }
      public override LookupResultKind ResultKind { get; }
      public  TypeSymbol ReceiverType { get; }
      public  Binder BinderOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitObjectInitializerMember(this);
      public BoundObjectInitializerMember Update(Symbol memberSymbol, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, LookupResultKind resultKind, TypeSymbol receiverType, Binder binderOpt, TypeSymbol type)
      {
        if (memberSymbol == this.MemberSymbol && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && expanded == this.Expanded && argsToParamsOpt == this.ArgsToParamsOpt && resultKind == this.ResultKind && receiverType == this.ReceiverType && binderOpt == this.BinderOpt && type == this.Type)return this;
        var result = new BoundObjectInitializerMember(this.Syntax, MemberSymbol, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, Expanded, ArgsToParamsOpt, ResultKind, ReceiverType, BinderOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDynamicObjectInitializerMember : BoundExpression
    {
      public BoundDynamicObjectInitializerMember(SyntaxNode syntax, string memberName, TypeSymbol receiverType, TypeSymbol type, bool hasErrors) : base(BoundKind.DynamicObjectInitializerMember, syntax, type, hasErrors)
      {
        Debug.Assert(memberName != null, "Field 'memberName' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(receiverType != null, "Field 'receiverType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.MemberName = memberName;
        this.ReceiverType = receiverType;
      }
      public BoundDynamicObjectInitializerMember(SyntaxNode syntax, string memberName, TypeSymbol receiverType, TypeSymbol type) : base(BoundKind.DynamicObjectInitializerMember, syntax, type)
      {
        Debug.Assert(memberName != null, "Field 'memberName' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(receiverType != null, "Field 'receiverType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  string MemberName { get; }
      public  TypeSymbol ReceiverType { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDynamicObjectInitializerMember(this);
      public BoundDynamicObjectInitializerMember Update(string memberName, TypeSymbol receiverType, TypeSymbol type)
      {
        if (memberName == this.MemberName && receiverType == this.ReceiverType && type == this.Type)return this;
        var result = new BoundDynamicObjectInitializerMember(this.Syntax, MemberName, ReceiverType, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundCollectionInitializerExpression : BoundObjectInitializerExpressionBase
    {
      public BoundCollectionInitializerExpression(SyntaxNode syntax, ImmutableArray<BoundExpression> initializers, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.CollectionInitializerExpression, syntax, initializers, type, hasErrors || initializers.HasErrors())
      {
        Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitCollectionInitializerExpression(this);
      public BoundCollectionInitializerExpression Update(ImmutableArray<BoundExpression> initializers, TypeSymbol type)
      {
        if (initializers == this.Initializers && type == this.Type)return this;
        var result = new BoundCollectionInitializerExpression(this.Syntax, Initializers, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundCollectionElementInitializer : BoundExpression
    {
      public BoundCollectionElementInitializer(SyntaxNode syntax, MethodSymbol addMethod, ImmutableArray<BoundExpression> arguments, BoundExpression implicitReceiverOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, bool invokedAsExtensionMethod, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.CollectionElementInitializer, syntax, type, hasErrors || arguments.HasErrors() || implicitReceiverOpt.HasErrors())
      {
        Debug.Assert(addMethod != null, "Field 'addMethod' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.AddMethod = addMethod;
        this.Arguments = arguments;
        this.ImplicitReceiverOpt = implicitReceiverOpt;
        this.Expanded = expanded;
        this.ArgsToParamsOpt = argsToParamsOpt;
        this.InvokedAsExtensionMethod = invokedAsExtensionMethod;
        this.ResultKind = resultKind;
        this.BinderOpt = binderOpt;
      }
      public  MethodSymbol AddMethod { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  BoundExpression ImplicitReceiverOpt { get; }
      public  bool Expanded { get; }
      public  ImmutableArray<int> ArgsToParamsOpt { get; }
      public  bool InvokedAsExtensionMethod { get; }
      public override LookupResultKind ResultKind { get; }
      public  Binder BinderOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitCollectionElementInitializer(this);
      public BoundCollectionElementInitializer Update(MethodSymbol addMethod, ImmutableArray<BoundExpression> arguments, BoundExpression implicitReceiverOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, bool invokedAsExtensionMethod, LookupResultKind resultKind, Binder binderOpt, TypeSymbol type)
      {
        if (addMethod == this.AddMethod && arguments == this.Arguments && implicitReceiverOpt == this.ImplicitReceiverOpt && expanded == this.Expanded && argsToParamsOpt == this.ArgsToParamsOpt && invokedAsExtensionMethod == this.InvokedAsExtensionMethod && resultKind == this.ResultKind && binderOpt == this.BinderOpt && type == this.Type)return this;
        var result = new BoundCollectionElementInitializer(this.Syntax, AddMethod, Arguments, ImplicitReceiverOpt, Expanded, ArgsToParamsOpt, InvokedAsExtensionMethod, ResultKind, BinderOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDynamicCollectionElementInitializer : BoundExpression
    {
      public BoundDynamicCollectionElementInitializer(SyntaxNode syntax, ImmutableArray<BoundExpression> arguments, BoundImplicitReceiver implicitReceiver, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DynamicCollectionElementInitializer, syntax, type, hasErrors || arguments.HasErrors() || implicitReceiver.HasErrors())
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(implicitReceiver != null, "Field 'implicitReceiver' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!applicableMethods.IsDefault, "Field 'applicableMethods' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Arguments = arguments;
        this.ImplicitReceiver = implicitReceiver;
        this.ApplicableMethods = applicableMethods;
      }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  BoundImplicitReceiver ImplicitReceiver { get; }
      public  ImmutableArray<MethodSymbol> ApplicableMethods { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDynamicCollectionElementInitializer(this);
      public BoundDynamicCollectionElementInitializer Update(ImmutableArray<BoundExpression> arguments, BoundImplicitReceiver implicitReceiver, ImmutableArray<MethodSymbol> applicableMethods, TypeSymbol type)
      {
        if (arguments == this.Arguments && implicitReceiver == this.ImplicitReceiver && applicableMethods == this.ApplicableMethods && type == this.Type)return this;
        var result = new BoundDynamicCollectionElementInitializer(this.Syntax, Arguments, ImplicitReceiver, ApplicableMethods, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundImplicitReceiver : BoundExpression
    {
      public BoundImplicitReceiver(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.ImplicitReceiver, syntax, type, hasErrors)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public BoundImplicitReceiver(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.ImplicitReceiver, syntax, type)
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitImplicitReceiver(this);
      public BoundImplicitReceiver Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundImplicitReceiver(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAnonymousObjectCreationExpression : BoundExpression
    {
      public BoundAnonymousObjectCreationExpression(SyntaxNode syntax, MethodSymbol constructor, ImmutableArray<BoundExpression> arguments, ImmutableArray<BoundAnonymousPropertyDeclaration> declarations, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.AnonymousObjectCreationExpression, syntax, type, hasErrors || arguments.HasErrors() || declarations.HasErrors())
      {
        Debug.Assert(constructor != null, "Field 'constructor' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!declarations.IsDefault, "Field 'declarations' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Constructor = constructor;
        this.Arguments = arguments;
        this.Declarations = declarations;
      }
      public  MethodSymbol Constructor { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<BoundAnonymousPropertyDeclaration> Declarations { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAnonymousObjectCreationExpression(this);
      public BoundAnonymousObjectCreationExpression Update(MethodSymbol constructor, ImmutableArray<BoundExpression> arguments, ImmutableArray<BoundAnonymousPropertyDeclaration> declarations, TypeSymbol type)
      {
        if (constructor == this.Constructor && arguments == this.Arguments && declarations == this.Declarations && type == this.Type)return this;
        var result = new BoundAnonymousObjectCreationExpression(this.Syntax, Constructor, Arguments, Declarations, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundAnonymousPropertyDeclaration : BoundExpression
    {
      public BoundAnonymousPropertyDeclaration(SyntaxNode syntax, PropertySymbol property, TypeSymbol type, bool hasErrors) : base(BoundKind.AnonymousPropertyDeclaration, syntax, type, hasErrors)
      {
        Debug.Assert(property != null, "Field 'property' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Property = property;
      }
      public BoundAnonymousPropertyDeclaration(SyntaxNode syntax, PropertySymbol property, TypeSymbol type) : base(BoundKind.AnonymousPropertyDeclaration, syntax, type)
      {
        Debug.Assert(property != null, "Field 'property' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  PropertySymbol Property { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitAnonymousPropertyDeclaration(this);
      public BoundAnonymousPropertyDeclaration Update(PropertySymbol property, TypeSymbol type)
      {
        if (property == this.Property && type == this.Type)return this;
        var result = new BoundAnonymousPropertyDeclaration(this.Syntax, Property, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundNewT : BoundExpression
    {
      public BoundNewT(SyntaxNode syntax, BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.NewT, syntax, type, hasErrors || initializerExpressionOpt.HasErrors())
      {
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.InitializerExpressionOpt = initializerExpressionOpt;
      }
      public  BoundObjectInitializerExpressionBase InitializerExpressionOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNewT(this);
      public BoundNewT Update(BoundObjectInitializerExpressionBase initializerExpressionOpt, TypeSymbol type)
      {
        if (initializerExpressionOpt == this.InitializerExpressionOpt && type == this.Type)return this;
        var result = new BoundNewT(this.Syntax, InitializerExpressionOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDelegateCreationExpression : BoundExpression
    {
      public BoundDelegateCreationExpression(SyntaxNode syntax, BoundExpression argument, MethodSymbol methodOpt, bool isExtensionMethod, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DelegateCreationExpression, syntax, type, hasErrors || argument.HasErrors())
      {
        Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Argument = argument;
        this.MethodOpt = methodOpt;
        this.IsExtensionMethod = isExtensionMethod;
      }
      public  BoundExpression Argument { get; }
      public  MethodSymbol MethodOpt { get; }
      public  bool IsExtensionMethod { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDelegateCreationExpression(this);
      public BoundDelegateCreationExpression Update(BoundExpression argument, MethodSymbol methodOpt, bool isExtensionMethod, TypeSymbol type)
      {
        if (argument == this.Argument && methodOpt == this.MethodOpt && isExtensionMethod == this.IsExtensionMethod && type == this.Type)return this;
        var result = new BoundDelegateCreationExpression(this.Syntax, Argument, MethodOpt, IsExtensionMethod, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundArrayCreation : BoundExpression
    {
      public BoundArrayCreation(SyntaxNode syntax, ImmutableArray<BoundExpression> bounds, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ArrayCreation, syntax, type, hasErrors || bounds.HasErrors() || initializerOpt.HasErrors())
      {
        Debug.Assert(!bounds.IsDefault, "Field 'bounds' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Bounds = bounds;
        this.InitializerOpt = initializerOpt;
      }
      public  ImmutableArray<BoundExpression> Bounds { get; }
      public  BoundArrayInitialization InitializerOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitArrayCreation(this);
      public BoundArrayCreation Update(ImmutableArray<BoundExpression> bounds, BoundArrayInitialization initializerOpt, TypeSymbol type)
      {
        if (bounds == this.Bounds && initializerOpt == this.InitializerOpt && type == this.Type)return this;
        var result = new BoundArrayCreation(this.Syntax, Bounds, InitializerOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundArrayInitialization : BoundExpression
    {
      public BoundArrayInitialization(SyntaxNode syntax, ImmutableArray<BoundExpression> initializers,  bool hasErrors = false) : base(BoundKind.ArrayInitialization, syntax, null, hasErrors || initializers.HasErrors())
      {
        Debug.Assert(!initializers.IsDefault, "Field 'initializers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Initializers = initializers;
      }
      public  ImmutableArray<BoundExpression> Initializers { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitArrayInitialization(this);
      public BoundArrayInitialization Update(ImmutableArray<BoundExpression> initializers)
      {
        if (initializers == this.Initializers)return this;
        var result = new BoundArrayInitialization(this.Syntax, Initializers, this.HasErrors);
        return result;
      }
    }

    internal partial class BoundStackAllocArrayCreation : BoundExpression
    {
      protected BoundStackAllocArrayCreation(BoundKind kind, SyntaxNode syntax, TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false) : base(kind, syntax, type, hasErrors)
      {
        Debug.Assert(elementType != null, "Field 'elementType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(count != null, "Field 'count' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ElementType = elementType;
        this.Count = count;
        this.InitializerOpt = initializerOpt;
      }
      public BoundStackAllocArrayCreation(SyntaxNode syntax, TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.StackAllocArrayCreation, syntax, type, hasErrors || count.HasErrors() || initializerOpt.HasErrors())
      {
        Debug.Assert(elementType != null, "Field 'elementType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(count != null, "Field 'count' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ElementType = elementType;
        this.Count = count;
        this.InitializerOpt = initializerOpt;
      }
      public  TypeSymbol ElementType { get; }
      public  BoundExpression Count { get; }
      public  BoundArrayInitialization InitializerOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitStackAllocArrayCreation(this);
      public BoundStackAllocArrayCreation Update(TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type)
      {
        if (elementType == this.ElementType && count == this.Count && initializerOpt == this.InitializerOpt && type == this.Type)return this;
        var result = new BoundStackAllocArrayCreation(this.Syntax, ElementType, Count, InitializerOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConvertedStackAllocExpression : BoundStackAllocArrayCreation
    {
      public BoundConvertedStackAllocExpression(SyntaxNode syntax, TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ConvertedStackAllocExpression, syntax, elementType, count, initializerOpt, type, hasErrors || count.HasErrors() || initializerOpt.HasErrors())
      {
        Debug.Assert(elementType != null, "Field 'elementType' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(count != null, "Field 'count' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConvertedStackAllocExpression(this);
      public BoundConvertedStackAllocExpression Update(TypeSymbol elementType, BoundExpression count, BoundArrayInitialization initializerOpt, TypeSymbol type)
      {
        if (elementType == this.ElementType && count == this.Count && initializerOpt == this.InitializerOpt && type == this.Type)return this;
        var result = new BoundConvertedStackAllocExpression(this.Syntax, ElementType, Count, InitializerOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundFieldAccess : BoundExpression
    {
      public BoundFieldAccess(SyntaxNode syntax, BoundExpression receiverOpt, FieldSymbol fieldSymbol, ConstantValue constantValueOpt, LookupResultKind resultKind, bool isByValue, bool isDeclaration, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.FieldAccess, syntax, type, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(fieldSymbol != null, "Field 'fieldSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ReceiverOpt = receiverOpt;
        this.FieldSymbol = fieldSymbol;
        this.ConstantValueOpt = constantValueOpt;
        this.ResultKind = resultKind;
        this.IsByValue = isByValue;
        this.IsDeclaration = isDeclaration;
      }
      public  BoundExpression ReceiverOpt { get; }
      public  FieldSymbol FieldSymbol { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override LookupResultKind ResultKind { get; }
      public  bool IsByValue { get; }
      public  bool IsDeclaration { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitFieldAccess(this);
      public BoundFieldAccess Update(BoundExpression receiverOpt, FieldSymbol fieldSymbol, ConstantValue constantValueOpt, LookupResultKind resultKind, bool isByValue, bool isDeclaration, TypeSymbol type)
      {
        if (receiverOpt == this.ReceiverOpt && fieldSymbol == this.FieldSymbol && constantValueOpt == this.ConstantValueOpt && resultKind == this.ResultKind && isByValue == this.IsByValue && isDeclaration == this.IsDeclaration && type == this.Type)return this;
        var result = new BoundFieldAccess(this.Syntax, ReceiverOpt, FieldSymbol, ConstantValueOpt, ResultKind, IsByValue, IsDeclaration, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundHoistedFieldAccess : BoundExpression
    {
      public BoundHoistedFieldAccess(SyntaxNode syntax, FieldSymbol fieldSymbol, TypeSymbol type, bool hasErrors) : base(BoundKind.HoistedFieldAccess, syntax, type, hasErrors)
      {
        Debug.Assert(fieldSymbol != null, "Field 'fieldSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.FieldSymbol = fieldSymbol;
      }
      public BoundHoistedFieldAccess(SyntaxNode syntax, FieldSymbol fieldSymbol, TypeSymbol type) : base(BoundKind.HoistedFieldAccess, syntax, type)
      {
        Debug.Assert(fieldSymbol != null, "Field 'fieldSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  FieldSymbol FieldSymbol { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitHoistedFieldAccess(this);
      public BoundHoistedFieldAccess Update(FieldSymbol fieldSymbol, TypeSymbol type)
      {
        if (fieldSymbol == this.FieldSymbol && type == this.Type)return this;
        var result = new BoundHoistedFieldAccess(this.Syntax, FieldSymbol, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundPropertyAccess : BoundExpression
    {
      public BoundPropertyAccess(SyntaxNode syntax, BoundExpression receiverOpt, PropertySymbol propertySymbol, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.PropertyAccess, syntax, type, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(propertySymbol != null, "Field 'propertySymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ReceiverOpt = receiverOpt;
        this.PropertySymbol = propertySymbol;
        this.ResultKind = resultKind;
      }
      public  BoundExpression ReceiverOpt { get; }
      public  PropertySymbol PropertySymbol { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitPropertyAccess(this);
      public BoundPropertyAccess Update(BoundExpression receiverOpt, PropertySymbol propertySymbol, LookupResultKind resultKind, TypeSymbol type)
      {
        if (receiverOpt == this.ReceiverOpt && propertySymbol == this.PropertySymbol && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundPropertyAccess(this.Syntax, ReceiverOpt, PropertySymbol, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundEventAccess : BoundExpression
    {
      public BoundEventAccess(SyntaxNode syntax, BoundExpression receiverOpt, EventSymbol eventSymbol, bool isUsableAsField, LookupResultKind resultKind, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.EventAccess, syntax, type, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(eventSymbol != null, "Field 'eventSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ReceiverOpt = receiverOpt;
        this.EventSymbol = eventSymbol;
        this.IsUsableAsField = isUsableAsField;
        this.ResultKind = resultKind;
      }
      public  BoundExpression ReceiverOpt { get; }
      public  EventSymbol EventSymbol { get; }
      public  bool IsUsableAsField { get; }
      public override LookupResultKind ResultKind { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitEventAccess(this);
      public BoundEventAccess Update(BoundExpression receiverOpt, EventSymbol eventSymbol, bool isUsableAsField, LookupResultKind resultKind, TypeSymbol type)
      {
        if (receiverOpt == this.ReceiverOpt && eventSymbol == this.EventSymbol && isUsableAsField == this.IsUsableAsField && resultKind == this.ResultKind && type == this.Type)return this;
        var result = new BoundEventAccess(this.Syntax, ReceiverOpt, EventSymbol, IsUsableAsField, ResultKind, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundIndexerAccess : BoundExpression
    {
      public BoundIndexerAccess(SyntaxNode syntax, BoundExpression receiverOpt, PropertySymbol indexer, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, Binder binderOpt, bool useSetterForDefaultArgumentGeneration, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.IndexerAccess, syntax, type, hasErrors || receiverOpt.HasErrors() || arguments.HasErrors())
      {
        Debug.Assert(indexer != null, "Field 'indexer' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ReceiverOpt = receiverOpt;
        this.Indexer = indexer;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.Expanded = expanded;
        this.ArgsToParamsOpt = argsToParamsOpt;
        this.BinderOpt = binderOpt;
        this.UseSetterForDefaultArgumentGeneration = useSetterForDefaultArgumentGeneration;
      }
      public  BoundExpression ReceiverOpt { get; }
      public  PropertySymbol Indexer { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  bool Expanded { get; }
      public  ImmutableArray<int> ArgsToParamsOpt { get; }
      public  Binder BinderOpt { get; }
      public  bool UseSetterForDefaultArgumentGeneration { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitIndexerAccess(this);
      public BoundIndexerAccess Update(BoundExpression receiverOpt, PropertySymbol indexer, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, bool expanded, ImmutableArray<int> argsToParamsOpt, Binder binderOpt, bool useSetterForDefaultArgumentGeneration, TypeSymbol type)
      {
        if (receiverOpt == this.ReceiverOpt && indexer == this.Indexer && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && expanded == this.Expanded && argsToParamsOpt == this.ArgsToParamsOpt && binderOpt == this.BinderOpt && useSetterForDefaultArgumentGeneration == this.UseSetterForDefaultArgumentGeneration && type == this.Type)return this;
        var result = new BoundIndexerAccess(this.Syntax, ReceiverOpt, Indexer, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, Expanded, ArgsToParamsOpt, BinderOpt, UseSetterForDefaultArgumentGeneration, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundDynamicIndexerAccess : BoundExpression
    {
      public BoundDynamicIndexerAccess(SyntaxNode syntax, BoundExpression receiverOpt, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<PropertySymbol> applicableIndexers, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.DynamicIndexerAccess, syntax, type, hasErrors || receiverOpt.HasErrors() || arguments.HasErrors())
      {
        Debug.Assert(!arguments.IsDefault, "Field 'arguments' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!applicableIndexers.IsDefault, "Field 'applicableIndexers' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.ReceiverOpt = receiverOpt;
        this.Arguments = arguments;
        this.ArgumentNamesOpt = argumentNamesOpt;
        this.ArgumentRefKindsOpt = argumentRefKindsOpt;
        this.ApplicableIndexers = applicableIndexers;
      }
      public  BoundExpression ReceiverOpt { get; }
      public  ImmutableArray<BoundExpression> Arguments { get; }
      public  ImmutableArray<string> ArgumentNamesOpt { get; }
      public  ImmutableArray<RefKind> ArgumentRefKindsOpt { get; }
      public  ImmutableArray<PropertySymbol> ApplicableIndexers { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDynamicIndexerAccess(this);
      public BoundDynamicIndexerAccess Update(BoundExpression receiverOpt, ImmutableArray<BoundExpression> arguments, ImmutableArray<string> argumentNamesOpt, ImmutableArray<RefKind> argumentRefKindsOpt, ImmutableArray<PropertySymbol> applicableIndexers, TypeSymbol type)
      {
        if (receiverOpt == this.ReceiverOpt && arguments == this.Arguments && argumentNamesOpt == this.ArgumentNamesOpt && argumentRefKindsOpt == this.ArgumentRefKindsOpt && applicableIndexers == this.ApplicableIndexers && type == this.Type)return this;
        var result = new BoundDynamicIndexerAccess(this.Syntax, ReceiverOpt, Arguments, ArgumentNamesOpt, ArgumentRefKindsOpt, ApplicableIndexers, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundLambda : BoundExpression
    {
      public BoundLambda(SyntaxNode syntax, LambdaSymbol symbol, BoundBlock body, ImmutableArray<Microsoft.CodeAnalysis.Diagnostic> diagnostics, Binder binder, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.Lambda, syntax, type, hasErrors || body.HasErrors())
      {
        Debug.Assert(symbol != null, "Field 'symbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(body != null, "Field 'body' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(!diagnostics.IsDefault, "Field 'diagnostics' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(binder != null, "Field 'binder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Symbol = symbol;
        this.Body = body;
        this.Diagnostics = diagnostics;
        this.Binder = binder;
      }
      public  LambdaSymbol Symbol { get; }
      public  BoundBlock Body { get; }
      public  ImmutableArray<Microsoft.CodeAnalysis.Diagnostic> Diagnostics { get; }
      public  Binder Binder { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitLambda(this);
      public BoundLambda Update(LambdaSymbol symbol, BoundBlock body, ImmutableArray<Microsoft.CodeAnalysis.Diagnostic> diagnostics, Binder binder, TypeSymbol type)
      {
        if (symbol == this.Symbol && body == this.Body && diagnostics == this.Diagnostics && binder == this.Binder && type == this.Type)return this;
        var result = new BoundLambda(this.Syntax, Symbol, Body, Diagnostics, Binder, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class UnboundLambda : BoundExpression
    {
      public UnboundLambda(SyntaxNode syntax, UnboundLambdaState data, bool hasErrors) : base(BoundKind.UnboundLambda, syntax, null, hasErrors)
      {
        Debug.Assert(data != null, "Field 'data' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Data = data;
      }
      public UnboundLambda(SyntaxNode syntax, UnboundLambdaState data) : base(BoundKind.UnboundLambda, syntax, null)
      {
        Debug.Assert(data != null, "Field 'data' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public  UnboundLambdaState Data { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitUnboundLambda(this);
      public UnboundLambda Update(UnboundLambdaState data)
      {
        if (data == this.Data)return this;
        var result = new UnboundLambda(this.Syntax, Data, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundQueryClause : BoundExpression
    {
      public BoundQueryClause(SyntaxNode syntax, BoundExpression value, RangeVariableSymbol definedSymbol, Binder binder, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.QueryClause, syntax, type, hasErrors || value.HasErrors())
      {
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(binder != null, "Field 'binder' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Value = value;
        this.DefinedSymbol = definedSymbol;
        this.Binder = binder;
      }
      public  BoundExpression Value { get; }
      public  RangeVariableSymbol DefinedSymbol { get; }
      public  Binder Binder { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitQueryClause(this);
      public BoundQueryClause Update(BoundExpression value, RangeVariableSymbol definedSymbol, Binder binder, TypeSymbol type)
      {
        if (value == this.Value && definedSymbol == this.DefinedSymbol && binder == this.Binder && type == this.Type)return this;
        var result = new BoundQueryClause(this.Syntax, Value, DefinedSymbol, Binder, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundTypeOrInstanceInitializers : BoundStatementList
    {
      public BoundTypeOrInstanceInitializers(SyntaxNode syntax, ImmutableArray<BoundStatement> statements,  bool hasErrors = false) : base(BoundKind.TypeOrInstanceInitializers, syntax, statements, hasErrors || statements.HasErrors())
      {
        Debug.Assert(!statements.IsDefault, "Field 'statements' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitTypeOrInstanceInitializers(this);
      public BoundTypeOrInstanceInitializers Update(ImmutableArray<BoundStatement> statements)
      {
        if (statements == this.Statements)return this;
        var result = new BoundTypeOrInstanceInitializers(this.Syntax, Statements, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundNameOfOperator : BoundExpression
    {
      public BoundNameOfOperator(SyntaxNode syntax, BoundExpression argument, ConstantValue constantValueOpt, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.NameOfOperator, syntax, type, hasErrors || argument.HasErrors())
      {
        Debug.Assert(argument != null, "Field 'argument' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(constantValueOpt != null, "Field 'constantValueOpt' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(type != null, "Field 'type' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Argument = argument;
        this.ConstantValueOpt = constantValueOpt;
      }
      public  BoundExpression Argument { get; }
      public  ConstantValue ConstantValueOpt { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNameOfOperator(this);
      public BoundNameOfOperator Update(BoundExpression argument, ConstantValue constantValueOpt, TypeSymbol type)
      {
        if (argument == this.Argument && constantValueOpt == this.ConstantValueOpt && type == this.Type)return this;
        var result = new BoundNameOfOperator(this.Syntax, Argument, ConstantValueOpt, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundInterpolatedString : BoundExpression
    {
      public BoundInterpolatedString(SyntaxNode syntax, ImmutableArray<BoundExpression> parts, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.InterpolatedString, syntax, type, hasErrors || parts.HasErrors())
      {
        Debug.Assert(!parts.IsDefault, "Field 'parts' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Parts = parts;
      }
      public  ImmutableArray<BoundExpression> Parts { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitInterpolatedString(this);
      public BoundInterpolatedString Update(ImmutableArray<BoundExpression> parts, TypeSymbol type)
      {
        if (parts == this.Parts && type == this.Type)return this;
        var result = new BoundInterpolatedString(this.Syntax, Parts, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundStringInsert : BoundExpression
    {
      public BoundStringInsert(SyntaxNode syntax, BoundExpression value, BoundExpression alignment, BoundLiteral format, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.StringInsert, syntax, type, hasErrors || value.HasErrors() || alignment.HasErrors() || format.HasErrors())
      {
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Value = value;
        this.Alignment = alignment;
        this.Format = format;
      }
      public  BoundExpression Value { get; }
      public  BoundExpression Alignment { get; }
      public  BoundLiteral Format { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitStringInsert(this);
      public BoundStringInsert Update(BoundExpression value, BoundExpression alignment, BoundLiteral format, TypeSymbol type)
      {
        if (value == this.Value && alignment == this.Alignment && format == this.Format && type == this.Type)return this;
        var result = new BoundStringInsert(this.Syntax, Value, Alignment, Format, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundIsPatternExpression : BoundExpression
    {
      public BoundIsPatternExpression(SyntaxNode syntax, BoundExpression expression, BoundPattern pattern, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.IsPatternExpression, syntax, type, hasErrors || expression.HasErrors() || pattern.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        Debug.Assert(pattern != null, "Field 'pattern' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
        this.Pattern = pattern;
      }
      public  BoundExpression Expression { get; }
      public  BoundPattern Pattern { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitIsPatternExpression(this);
      public BoundIsPatternExpression Update(BoundExpression expression, BoundPattern pattern, TypeSymbol type)
      {
        if (expression == this.Expression && pattern == this.Pattern && type == this.Type)return this;
        var result = new BoundIsPatternExpression(this.Syntax, Expression, Pattern, Type, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundPattern : BoundNode
    {
      protected BoundPattern(BoundKind kind, SyntaxNode syntax, bool hasErrors) : base(kind, syntax, hasErrors)
      {
      }
      protected BoundPattern(BoundKind kind, SyntaxNode syntax) : base(kind, syntax)
      {
      }
    }

    internal sealed partial class BoundDeclarationPattern : BoundPattern
    {
      public BoundDeclarationPattern(SyntaxNode syntax, Symbol variable, BoundExpression variableAccess, BoundTypeExpression declaredType, bool isVar,  bool hasErrors = false) : base(BoundKind.DeclarationPattern, syntax, hasErrors || variableAccess.HasErrors() || declaredType.HasErrors())
      {
        Debug.Assert(variableAccess != null, "Field 'variableAccess' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Variable = variable;
        this.VariableAccess = variableAccess;
        this.DeclaredType = declaredType;
        this.IsVar = isVar;
      }
      public  Symbol Variable { get; }
      public  BoundExpression VariableAccess { get; }
      public  BoundTypeExpression DeclaredType { get; }
      public  bool IsVar { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDeclarationPattern(this);
      public BoundDeclarationPattern Update(Symbol variable, BoundExpression variableAccess, BoundTypeExpression declaredType, bool isVar)
      {
        if (variable == this.Variable && variableAccess == this.VariableAccess && declaredType == this.DeclaredType && isVar == this.IsVar)return this;
        var result = new BoundDeclarationPattern(this.Syntax, Variable, VariableAccess, DeclaredType, IsVar, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConstantPattern : BoundPattern
    {
      public BoundConstantPattern(SyntaxNode syntax, BoundExpression value, ConstantValue constantValue,  bool hasErrors = false) : base(BoundKind.ConstantPattern, syntax, hasErrors || value.HasErrors())
      {
        Debug.Assert(value != null, "Field 'value' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Value = value;
        this.ConstantValue = constantValue;
      }
      public  BoundExpression Value { get; }
      public  ConstantValue ConstantValue { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConstantPattern(this);
      public BoundConstantPattern Update(BoundExpression value, ConstantValue constantValue)
      {
        if (value == this.Value && constantValue == this.ConstantValue)return this;
        var result = new BoundConstantPattern(this.Syntax, Value, ConstantValue, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundWildcardPattern : BoundPattern
    {
      public BoundWildcardPattern(SyntaxNode syntax, bool hasErrors) : base(BoundKind.WildcardPattern, syntax, hasErrors)
      {
      }
      public BoundWildcardPattern(SyntaxNode syntax) : base(BoundKind.WildcardPattern, syntax)
      {
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitWildcardPattern(this);
    }

    internal sealed partial class BoundDiscardExpression : BoundExpression
    {
      public BoundDiscardExpression(SyntaxNode syntax, TypeSymbol type, bool hasErrors) : base(BoundKind.DiscardExpression, syntax, type, hasErrors)
      {
      }
      public BoundDiscardExpression(SyntaxNode syntax, TypeSymbol type) : base(BoundKind.DiscardExpression, syntax, type)
      {
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDiscardExpression(this);
      public BoundDiscardExpression Update(TypeSymbol type)
      {
        if (type == this.Type)return this;
        var result = new BoundDiscardExpression(this.Syntax, Type, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundThrowExpression : BoundExpression
    {
      public BoundThrowExpression(SyntaxNode syntax, BoundExpression expression, TypeSymbol type,  bool hasErrors = false) : base(BoundKind.ThrowExpression, syntax, type, hasErrors || expression.HasErrors())
      {
        Debug.Assert(expression != null, "Field 'expression' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Expression = expression;
      }
      public  BoundExpression Expression { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitThrowExpression(this);
      public BoundThrowExpression Update(BoundExpression expression, TypeSymbol type)
      {
        if (expression == this.Expression && type == this.Type)return this;
        var result = new BoundThrowExpression(this.Syntax, Expression, Type, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class VariablePendingInference : BoundExpression
    {
      protected VariablePendingInference(BoundKind kind, SyntaxNode syntax, Symbol variableSymbol, BoundExpression receiverOpt,  bool hasErrors = false) : base(kind, syntax, null, hasErrors)
      {
        Debug.Assert(variableSymbol != null, "Field 'variableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.VariableSymbol = variableSymbol;
        this.ReceiverOpt = receiverOpt;
      }
      public  Symbol VariableSymbol { get; }
      public  BoundExpression ReceiverOpt { get; }
    }

    internal sealed partial class OutVariablePendingInference : VariablePendingInference
    {
      public OutVariablePendingInference(SyntaxNode syntax, Symbol variableSymbol, BoundExpression receiverOpt,  bool hasErrors = false) : base(BoundKind.OutVariablePendingInference, syntax, variableSymbol, receiverOpt, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(variableSymbol != null, "Field 'variableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitOutVariablePendingInference(this);
      public OutVariablePendingInference Update(Symbol variableSymbol, BoundExpression receiverOpt)
      {
        if (variableSymbol == this.VariableSymbol && receiverOpt == this.ReceiverOpt)return this;
        var result = new OutVariablePendingInference(this.Syntax, VariableSymbol, ReceiverOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class DeconstructionVariablePendingInference : VariablePendingInference
    {
      public DeconstructionVariablePendingInference(SyntaxNode syntax, Symbol variableSymbol, BoundExpression receiverOpt,  bool hasErrors = false) : base(BoundKind.DeconstructionVariablePendingInference, syntax, variableSymbol, receiverOpt, hasErrors || receiverOpt.HasErrors())
      {
        Debug.Assert(variableSymbol != null, "Field 'variableSymbol' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitDeconstructionVariablePendingInference(this);
      public DeconstructionVariablePendingInference Update(Symbol variableSymbol, BoundExpression receiverOpt)
      {
        if (variableSymbol == this.VariableSymbol && receiverOpt == this.ReceiverOpt)return this;
        var result = new DeconstructionVariablePendingInference(this.Syntax, VariableSymbol, ReceiverOpt, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class OutDeconstructVarPendingInference : BoundExpression
    {
      public OutDeconstructVarPendingInference(SyntaxNode syntax, bool hasErrors) : base(BoundKind.OutDeconstructVarPendingInference, syntax, null, hasErrors)
      {
      }
      public OutDeconstructVarPendingInference(SyntaxNode syntax) : base(BoundKind.OutDeconstructVarPendingInference, syntax, null)
      {
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitOutDeconstructVarPendingInference(this);
      public OutDeconstructVarPendingInference Update()
      {
        var result = new OutDeconstructVarPendingInference(this.Syntax, this.HasErrors);
        return result;
      }
    }

    internal abstract partial class BoundMethodBodyBase : BoundNode
    {
      protected BoundMethodBodyBase(BoundKind kind, SyntaxNode syntax, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false) : base(kind, syntax, hasErrors)
      {
        this.BlockBody = blockBody;
        this.ExpressionBody = expressionBody;
      }
      public  BoundBlock BlockBody { get; }
      public  BoundBlock ExpressionBody { get; }
    }

    internal sealed partial class BoundNonConstructorMethodBody : BoundMethodBodyBase
    {
      public BoundNonConstructorMethodBody(SyntaxNode syntax, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false) : base(BoundKind.NonConstructorMethodBody, syntax, blockBody, expressionBody, hasErrors || blockBody.HasErrors() || expressionBody.HasErrors())
      {
      }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitNonConstructorMethodBody(this);
      public BoundNonConstructorMethodBody Update(BoundBlock blockBody, BoundBlock expressionBody)
      {
        if (blockBody == this.BlockBody && expressionBody == this.ExpressionBody)return this;
        var result = new BoundNonConstructorMethodBody(this.Syntax, BlockBody, ExpressionBody, this.HasErrors);
        return result;
      }
    }

    internal sealed partial class BoundConstructorMethodBody : BoundMethodBodyBase
    {
      public BoundConstructorMethodBody(SyntaxNode syntax, ImmutableArray<LocalSymbol> locals, BoundExpressionStatement initializer, BoundBlock blockBody, BoundBlock expressionBody,  bool hasErrors = false) : base(BoundKind.ConstructorMethodBody, syntax, blockBody, expressionBody, hasErrors || initializer.HasErrors() || blockBody.HasErrors() || expressionBody.HasErrors())
      {
        Debug.Assert(!locals.IsDefault, "Field 'locals' cannot be null (use Null=\"allow\" in BoundNodes.xml to remove this check)");
        this.Locals = locals;
        this.Initializer = initializer;
      }
      public  ImmutableArray<LocalSymbol> Locals { get; }
      public  BoundExpressionStatement Initializer { get; }
      public override BoundNode Accept(BoundTreeVisitor visitor) => visitor.VisitConstructorMethodBody(this);
      public BoundConstructorMethodBody Update(ImmutableArray<LocalSymbol> locals, BoundExpressionStatement initializer, BoundBlock blockBody, BoundBlock expressionBody)
      {
        if (locals == this.Locals && initializer == this.Initializer && blockBody == this.BlockBody && expressionBody == this.ExpressionBody)return this;
        var result = new BoundConstructorMethodBody(this.Syntax, Locals, Initializer, BlockBody, ExpressionBody, this.HasErrors);
        return result;
      }
    }


    internal abstract partial class BoundTreeVisitor<A,R>
    {
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal R VisitInternal(BoundNode node, A arg)
      {
        switch (node.Kind)
        {
          case BoundKind.FieldEqualsValue                      : return VisitFieldEqualsValue(node as BoundFieldEqualsValue, arg);
          case BoundKind.PropertyEqualsValue                   : return VisitPropertyEqualsValue(node as BoundPropertyEqualsValue, arg);
          case BoundKind.ParameterEqualsValue                  : return VisitParameterEqualsValue(node as BoundParameterEqualsValue, arg);
          case BoundKind.GlobalStatementInitializer            : return VisitGlobalStatementInitializer(node as BoundGlobalStatementInitializer, arg);
          case BoundKind.DeconstructValuePlaceholder           : return VisitDeconstructValuePlaceholder(node as BoundDeconstructValuePlaceholder, arg);
          case BoundKind.TupleOperandPlaceholder               : return VisitTupleOperandPlaceholder(node as BoundTupleOperandPlaceholder, arg);
          case BoundKind.Dup                                   : return VisitDup(node as BoundDup, arg);
          case BoundKind.PassByCopy                            : return VisitPassByCopy(node as BoundPassByCopy, arg);
          case BoundKind.BadExpression                         : return VisitBadExpression(node as BoundBadExpression, arg);
          case BoundKind.BadStatement                          : return VisitBadStatement(node as BoundBadStatement, arg);
          case BoundKind.TypeExpression                        : return VisitTypeExpression(node as BoundTypeExpression, arg);
          case BoundKind.TypeOrValueExpression                 : return VisitTypeOrValueExpression(node as BoundTypeOrValueExpression, arg);
          case BoundKind.NamespaceExpression                   : return VisitNamespaceExpression(node as BoundNamespaceExpression, arg);
          case BoundKind.UnaryOperator                         : return VisitUnaryOperator(node as BoundUnaryOperator, arg);
          case BoundKind.IncrementOperator                     : return VisitIncrementOperator(node as BoundIncrementOperator, arg);
          case BoundKind.AddressOfOperator                     : return VisitAddressOfOperator(node as BoundAddressOfOperator, arg);
          case BoundKind.PointerIndirectionOperator            : return VisitPointerIndirectionOperator(node as BoundPointerIndirectionOperator, arg);
          case BoundKind.PointerElementAccess                  : return VisitPointerElementAccess(node as BoundPointerElementAccess, arg);
          case BoundKind.RefTypeOperator                       : return VisitRefTypeOperator(node as BoundRefTypeOperator, arg);
          case BoundKind.MakeRefOperator                       : return VisitMakeRefOperator(node as BoundMakeRefOperator, arg);
          case BoundKind.RefValueOperator                      : return VisitRefValueOperator(node as BoundRefValueOperator, arg);
          case BoundKind.BinaryOperator                        : return VisitBinaryOperator(node as BoundBinaryOperator, arg);
          case BoundKind.TupleBinaryOperator                   : return VisitTupleBinaryOperator(node as BoundTupleBinaryOperator, arg);
          case BoundKind.UserDefinedConditionalLogicalOperator : return VisitUserDefinedConditionalLogicalOperator(node as BoundUserDefinedConditionalLogicalOperator, arg);
          case BoundKind.CompoundAssignmentOperator            : return VisitCompoundAssignmentOperator(node as BoundCompoundAssignmentOperator, arg);
          case BoundKind.AssignmentOperator                    : return VisitAssignmentOperator(node as BoundAssignmentOperator, arg);
          case BoundKind.DeconstructionAssignmentOperator      : return VisitDeconstructionAssignmentOperator(node as BoundDeconstructionAssignmentOperator, arg);
          case BoundKind.NullCoalescingOperator                : return VisitNullCoalescingOperator(node as BoundNullCoalescingOperator, arg);
          case BoundKind.ConditionalOperator                   : return VisitConditionalOperator(node as BoundConditionalOperator, arg);
          case BoundKind.ArrayAccess                           : return VisitArrayAccess(node as BoundArrayAccess, arg);
          case BoundKind.ArrayLength                           : return VisitArrayLength(node as BoundArrayLength, arg);
          case BoundKind.AwaitExpression                       : return VisitAwaitExpression(node as BoundAwaitExpression, arg);
          case BoundKind.TypeOfOperator                        : return VisitTypeOfOperator(node as BoundTypeOfOperator, arg);
          case BoundKind.MethodDefIndex                        : return VisitMethodDefIndex(node as BoundMethodDefIndex, arg);
          case BoundKind.MaximumMethodDefIndex                 : return VisitMaximumMethodDefIndex(node as BoundMaximumMethodDefIndex, arg);
          case BoundKind.InstrumentationPayloadRoot            : return VisitInstrumentationPayloadRoot(node as BoundInstrumentationPayloadRoot, arg);
          case BoundKind.ModuleVersionId                       : return VisitModuleVersionId(node as BoundModuleVersionId, arg);
          case BoundKind.ModuleVersionIdString                 : return VisitModuleVersionIdString(node as BoundModuleVersionIdString, arg);
          case BoundKind.SourceDocumentIndex                   : return VisitSourceDocumentIndex(node as BoundSourceDocumentIndex, arg);
          case BoundKind.MethodInfo                            : return VisitMethodInfo(node as BoundMethodInfo, arg);
          case BoundKind.FieldInfo                             : return VisitFieldInfo(node as BoundFieldInfo, arg);
          case BoundKind.DefaultExpression                     : return VisitDefaultExpression(node as BoundDefaultExpression, arg);
          case BoundKind.IsOperator                            : return VisitIsOperator(node as BoundIsOperator, arg);
          case BoundKind.AsOperator                            : return VisitAsOperator(node as BoundAsOperator, arg);
          case BoundKind.SizeOfOperator                        : return VisitSizeOfOperator(node as BoundSizeOfOperator, arg);
          case BoundKind.Conversion                            : return VisitConversion(node as BoundConversion, arg);
          case BoundKind.ArgList                               : return VisitArgList(node as BoundArgList, arg);
          case BoundKind.ArgListOperator                       : return VisitArgListOperator(node as BoundArgListOperator, arg);
          case BoundKind.FixedLocalCollectionInitializer       : return VisitFixedLocalCollectionInitializer(node as BoundFixedLocalCollectionInitializer, arg);
          case BoundKind.SequencePoint                         : return VisitSequencePoint(node as BoundSequencePoint, arg);
          case BoundKind.SequencePointExpression               : return VisitSequencePointExpression(node as BoundSequencePointExpression, arg);
          case BoundKind.SequencePointWithSpan                 : return VisitSequencePointWithSpan(node as BoundSequencePointWithSpan, arg);
          case BoundKind.Block                                 : return VisitBlock(node as BoundBlock, arg);
          case BoundKind.Scope                                 : return VisitScope(node as BoundScope, arg);
          case BoundKind.StateMachineScope                     : return VisitStateMachineScope(node as BoundStateMachineScope, arg);
          case BoundKind.LocalDeclaration                      : return VisitLocalDeclaration(node as BoundLocalDeclaration, arg);
          case BoundKind.MultipleLocalDeclarations             : return VisitMultipleLocalDeclarations(node as BoundMultipleLocalDeclarations, arg);
          case BoundKind.LocalFunctionStatement                : return VisitLocalFunctionStatement(node as BoundLocalFunctionStatement, arg);
          case BoundKind.Sequence                              : return VisitSequence(node as BoundSequence, arg);
          case BoundKind.NoOpStatement                         : return VisitNoOpStatement(node as BoundNoOpStatement, arg);
          case BoundKind.ReturnStatement                       : return VisitReturnStatement(node as BoundReturnStatement, arg);
          case BoundKind.YieldReturnStatement                  : return VisitYieldReturnStatement(node as BoundYieldReturnStatement, arg);
          case BoundKind.YieldBreakStatement                   : return VisitYieldBreakStatement(node as BoundYieldBreakStatement, arg);
          case BoundKind.ThrowStatement                        : return VisitThrowStatement(node as BoundThrowStatement, arg);
          case BoundKind.ExpressionStatement                   : return VisitExpressionStatement(node as BoundExpressionStatement, arg);
          case BoundKind.SwitchStatement                       : return VisitSwitchStatement(node as BoundSwitchStatement, arg);
          case BoundKind.SwitchSection                         : return VisitSwitchSection(node as BoundSwitchSection, arg);
          case BoundKind.SwitchLabel                           : return VisitSwitchLabel(node as BoundSwitchLabel, arg);
          case BoundKind.BreakStatement                        : return VisitBreakStatement(node as BoundBreakStatement, arg);
          case BoundKind.ContinueStatement                     : return VisitContinueStatement(node as BoundContinueStatement, arg);
          case BoundKind.PatternSwitchStatement                : return VisitPatternSwitchStatement(node as BoundPatternSwitchStatement, arg);
          case BoundKind.PatternSwitchSection                  : return VisitPatternSwitchSection(node as BoundPatternSwitchSection, arg);
          case BoundKind.PatternSwitchLabel                    : return VisitPatternSwitchLabel(node as BoundPatternSwitchLabel, arg);
          case BoundKind.IfStatement                           : return VisitIfStatement(node as BoundIfStatement, arg);
          case BoundKind.DoStatement                           : return VisitDoStatement(node as BoundDoStatement, arg);
          case BoundKind.WhileStatement                        : return VisitWhileStatement(node as BoundWhileStatement, arg);
          case BoundKind.ForStatement                          : return VisitForStatement(node as BoundForStatement, arg);
          case BoundKind.ForEachStatement                      : return VisitForEachStatement(node as BoundForEachStatement, arg);
          case BoundKind.ForEachDeconstructStep                : return VisitForEachDeconstructStep(node as BoundForEachDeconstructStep, arg);
          case BoundKind.UsingStatement                        : return VisitUsingStatement(node as BoundUsingStatement, arg);
          case BoundKind.FixedStatement                        : return VisitFixedStatement(node as BoundFixedStatement, arg);
          case BoundKind.LockStatement                         : return VisitLockStatement(node as BoundLockStatement, arg);
          case BoundKind.TryStatement                          : return VisitTryStatement(node as BoundTryStatement, arg);
          case BoundKind.CatchBlock                            : return VisitCatchBlock(node as BoundCatchBlock, arg);
          case BoundKind.Literal                               : return VisitLiteral(node as BoundLiteral, arg);
          case BoundKind.ThisReference                         : return VisitThisReference(node as BoundThisReference, arg);
          case BoundKind.PreviousSubmissionReference           : return VisitPreviousSubmissionReference(node as BoundPreviousSubmissionReference, arg);
          case BoundKind.HostObjectMemberReference             : return VisitHostObjectMemberReference(node as BoundHostObjectMemberReference, arg);
          case BoundKind.BaseReference                         : return VisitBaseReference(node as BoundBaseReference, arg);
          case BoundKind.Local                                 : return VisitLocal(node as BoundLocal, arg);
          case BoundKind.PseudoVariable                        : return VisitPseudoVariable(node as BoundPseudoVariable, arg);
          case BoundKind.RangeVariable                         : return VisitRangeVariable(node as BoundRangeVariable, arg);
          case BoundKind.Parameter                             : return VisitParameter(node as BoundParameter, arg);
          case BoundKind.LabelStatement                        : return VisitLabelStatement(node as BoundLabelStatement, arg);
          case BoundKind.GotoStatement                         : return VisitGotoStatement(node as BoundGotoStatement, arg);
          case BoundKind.LabeledStatement                      : return VisitLabeledStatement(node as BoundLabeledStatement, arg);
          case BoundKind.Label                                 : return VisitLabel(node as BoundLabel, arg);
          case BoundKind.StatementList                         : return VisitStatementList(node as BoundStatementList, arg);
          case BoundKind.ConditionalGoto                       : return VisitConditionalGoto(node as BoundConditionalGoto, arg);
          case BoundKind.DynamicMemberAccess                   : return VisitDynamicMemberAccess(node as BoundDynamicMemberAccess, arg);
          case BoundKind.DynamicInvocation                     : return VisitDynamicInvocation(node as BoundDynamicInvocation, arg);
          case BoundKind.ConditionalAccess                     : return VisitConditionalAccess(node as BoundConditionalAccess, arg);
          case BoundKind.LoweredConditionalAccess              : return VisitLoweredConditionalAccess(node as BoundLoweredConditionalAccess, arg);
          case BoundKind.ConditionalReceiver                   : return VisitConditionalReceiver(node as BoundConditionalReceiver, arg);
          case BoundKind.ComplexConditionalReceiver            : return VisitComplexConditionalReceiver(node as BoundComplexConditionalReceiver, arg);
          case BoundKind.MethodGroup                           : return VisitMethodGroup(node as BoundMethodGroup, arg);
          case BoundKind.PropertyGroup                         : return VisitPropertyGroup(node as BoundPropertyGroup, arg);
          case BoundKind.Call                                  : return VisitCall(node as BoundCall, arg);
          case BoundKind.EventAssignmentOperator               : return VisitEventAssignmentOperator(node as BoundEventAssignmentOperator, arg);
          case BoundKind.Attribute                             : return VisitAttribute(node as BoundAttribute, arg);
          case BoundKind.ObjectCreationExpression              : return VisitObjectCreationExpression(node as BoundObjectCreationExpression, arg);
          case BoundKind.TupleLiteral                          : return VisitTupleLiteral(node as BoundTupleLiteral, arg);
          case BoundKind.ConvertedTupleLiteral                 : return VisitConvertedTupleLiteral(node as BoundConvertedTupleLiteral, arg);
          case BoundKind.DynamicObjectCreationExpression       : return VisitDynamicObjectCreationExpression(node as BoundDynamicObjectCreationExpression, arg);
          case BoundKind.NoPiaObjectCreationExpression         : return VisitNoPiaObjectCreationExpression(node as BoundNoPiaObjectCreationExpression, arg);
          case BoundKind.ObjectInitializerExpression           : return VisitObjectInitializerExpression(node as BoundObjectInitializerExpression, arg);
          case BoundKind.ObjectInitializerMember               : return VisitObjectInitializerMember(node as BoundObjectInitializerMember, arg);
          case BoundKind.DynamicObjectInitializerMember        : return VisitDynamicObjectInitializerMember(node as BoundDynamicObjectInitializerMember, arg);
          case BoundKind.CollectionInitializerExpression       : return VisitCollectionInitializerExpression(node as BoundCollectionInitializerExpression, arg);
          case BoundKind.CollectionElementInitializer          : return VisitCollectionElementInitializer(node as BoundCollectionElementInitializer, arg);
          case BoundKind.DynamicCollectionElementInitializer   : return VisitDynamicCollectionElementInitializer(node as BoundDynamicCollectionElementInitializer, arg);
          case BoundKind.ImplicitReceiver                      : return VisitImplicitReceiver(node as BoundImplicitReceiver, arg);
          case BoundKind.AnonymousObjectCreationExpression     : return VisitAnonymousObjectCreationExpression(node as BoundAnonymousObjectCreationExpression, arg);
          case BoundKind.AnonymousPropertyDeclaration          : return VisitAnonymousPropertyDeclaration(node as BoundAnonymousPropertyDeclaration, arg);
          case BoundKind.NewT                                  : return VisitNewT(node as BoundNewT, arg);
          case BoundKind.DelegateCreationExpression            : return VisitDelegateCreationExpression(node as BoundDelegateCreationExpression, arg);
          case BoundKind.ArrayCreation                         : return VisitArrayCreation(node as BoundArrayCreation, arg);
          case BoundKind.ArrayInitialization                   : return VisitArrayInitialization(node as BoundArrayInitialization, arg);
          case BoundKind.StackAllocArrayCreation               : return VisitStackAllocArrayCreation(node as BoundStackAllocArrayCreation, arg);
          case BoundKind.ConvertedStackAllocExpression         : return VisitConvertedStackAllocExpression(node as BoundConvertedStackAllocExpression, arg);
          case BoundKind.FieldAccess                           : return VisitFieldAccess(node as BoundFieldAccess, arg);
          case BoundKind.HoistedFieldAccess                    : return VisitHoistedFieldAccess(node as BoundHoistedFieldAccess, arg);
          case BoundKind.PropertyAccess                        : return VisitPropertyAccess(node as BoundPropertyAccess, arg);
          case BoundKind.EventAccess                           : return VisitEventAccess(node as BoundEventAccess, arg);
          case BoundKind.IndexerAccess                         : return VisitIndexerAccess(node as BoundIndexerAccess, arg);
          case BoundKind.DynamicIndexerAccess                  : return VisitDynamicIndexerAccess(node as BoundDynamicIndexerAccess, arg);
          case BoundKind.Lambda                                : return VisitLambda(node as BoundLambda, arg);
          case BoundKind.UnboundLambda                         : return VisitUnboundLambda(node as UnboundLambda, arg);
          case BoundKind.QueryClause                           : return VisitQueryClause(node as BoundQueryClause, arg);
          case BoundKind.TypeOrInstanceInitializers            : return VisitTypeOrInstanceInitializers(node as BoundTypeOrInstanceInitializers, arg);
          case BoundKind.NameOfOperator                        : return VisitNameOfOperator(node as BoundNameOfOperator, arg);
          case BoundKind.InterpolatedString                    : return VisitInterpolatedString(node as BoundInterpolatedString, arg);
          case BoundKind.StringInsert                          : return VisitStringInsert(node as BoundStringInsert, arg);
          case BoundKind.IsPatternExpression                   : return VisitIsPatternExpression(node as BoundIsPatternExpression, arg);
          case BoundKind.DeclarationPattern                    : return VisitDeclarationPattern(node as BoundDeclarationPattern, arg);
          case BoundKind.ConstantPattern                       : return VisitConstantPattern(node as BoundConstantPattern, arg);
          case BoundKind.WildcardPattern                       : return VisitWildcardPattern(node as BoundWildcardPattern, arg);
          case BoundKind.DiscardExpression                     : return VisitDiscardExpression(node as BoundDiscardExpression, arg);
          case BoundKind.ThrowExpression                       : return VisitThrowExpression(node as BoundThrowExpression, arg);
          case BoundKind.OutVariablePendingInference           : return VisitOutVariablePendingInference(node as OutVariablePendingInference, arg);
          case BoundKind.DeconstructionVariablePendingInference: return VisitDeconstructionVariablePendingInference(node as DeconstructionVariablePendingInference, arg);
          case BoundKind.OutDeconstructVarPendingInference     : return VisitOutDeconstructVarPendingInference(node as OutDeconstructVarPendingInference, arg);
          case BoundKind.NonConstructorMethodBody              : return VisitNonConstructorMethodBody(node as BoundNonConstructorMethodBody, arg);
          case BoundKind.ConstructorMethodBody                 : return VisitConstructorMethodBody(node as BoundConstructorMethodBody, arg);
        }
        return default(R);
      }
    }
    internal abstract partial class BoundTreeVisitor<A,R>
    {
      public virtual R VisitFieldEqualsValue(BoundFieldEqualsValue node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPropertyEqualsValue(BoundPropertyEqualsValue node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitParameterEqualsValue(BoundParameterEqualsValue node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDup(BoundDup node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPassByCopy(BoundPassByCopy node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitBadExpression(BoundBadExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitBadStatement(BoundBadStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTypeExpression(BoundTypeExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTypeOrValueExpression(BoundTypeOrValueExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNamespaceExpression(BoundNamespaceExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitUnaryOperator(BoundUnaryOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitIncrementOperator(BoundIncrementOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAddressOfOperator(BoundAddressOfOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPointerElementAccess(BoundPointerElementAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitRefTypeOperator(BoundRefTypeOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitMakeRefOperator(BoundMakeRefOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitRefValueOperator(BoundRefValueOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitBinaryOperator(BoundBinaryOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTupleBinaryOperator(BoundTupleBinaryOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAssignmentOperator(BoundAssignmentOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNullCoalescingOperator(BoundNullCoalescingOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConditionalOperator(BoundConditionalOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitArrayAccess(BoundArrayAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitArrayLength(BoundArrayLength node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAwaitExpression(BoundAwaitExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTypeOfOperator(BoundTypeOfOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitMethodDefIndex(BoundMethodDefIndex node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitModuleVersionId(BoundModuleVersionId node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitModuleVersionIdString(BoundModuleVersionIdString node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSourceDocumentIndex(BoundSourceDocumentIndex node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitMethodInfo(BoundMethodInfo node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitFieldInfo(BoundFieldInfo node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDefaultExpression(BoundDefaultExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitIsOperator(BoundIsOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAsOperator(BoundAsOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSizeOfOperator(BoundSizeOfOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConversion(BoundConversion node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitArgList(BoundArgList node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitArgListOperator(BoundArgListOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSequencePoint(BoundSequencePoint node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSequencePointExpression(BoundSequencePointExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSequencePointWithSpan(BoundSequencePointWithSpan node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitBlock(BoundBlock node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitScope(BoundScope node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitStateMachineScope(BoundStateMachineScope node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLocalDeclaration(BoundLocalDeclaration node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLocalFunctionStatement(BoundLocalFunctionStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSequence(BoundSequence node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNoOpStatement(BoundNoOpStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitReturnStatement(BoundReturnStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitYieldReturnStatement(BoundYieldReturnStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitYieldBreakStatement(BoundYieldBreakStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitThrowStatement(BoundThrowStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitExpressionStatement(BoundExpressionStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSwitchStatement(BoundSwitchStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSwitchSection(BoundSwitchSection node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitSwitchLabel(BoundSwitchLabel node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitBreakStatement(BoundBreakStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitContinueStatement(BoundContinueStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPatternSwitchStatement(BoundPatternSwitchStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPatternSwitchSection(BoundPatternSwitchSection node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPatternSwitchLabel(BoundPatternSwitchLabel node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitIfStatement(BoundIfStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDoStatement(BoundDoStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitWhileStatement(BoundWhileStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitForStatement(BoundForStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitForEachStatement(BoundForEachStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitForEachDeconstructStep(BoundForEachDeconstructStep node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitUsingStatement(BoundUsingStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitFixedStatement(BoundFixedStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLockStatement(BoundLockStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTryStatement(BoundTryStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitCatchBlock(BoundCatchBlock node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLiteral(BoundLiteral node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitThisReference(BoundThisReference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitHostObjectMemberReference(BoundHostObjectMemberReference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitBaseReference(BoundBaseReference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLocal(BoundLocal node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPseudoVariable(BoundPseudoVariable node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitRangeVariable(BoundRangeVariable node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitParameter(BoundParameter node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLabelStatement(BoundLabelStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitGotoStatement(BoundGotoStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLabeledStatement(BoundLabeledStatement node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLabel(BoundLabel node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitStatementList(BoundStatementList node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConditionalGoto(BoundConditionalGoto node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDynamicMemberAccess(BoundDynamicMemberAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDynamicInvocation(BoundDynamicInvocation node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConditionalAccess(BoundConditionalAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConditionalReceiver(BoundConditionalReceiver node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitMethodGroup(BoundMethodGroup node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPropertyGroup(BoundPropertyGroup node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitCall(BoundCall node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitEventAssignmentOperator(BoundEventAssignmentOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAttribute(BoundAttribute node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitObjectCreationExpression(BoundObjectCreationExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTupleLiteral(BoundTupleLiteral node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitObjectInitializerExpression(BoundObjectInitializerExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitObjectInitializerMember(BoundObjectInitializerMember node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitCollectionElementInitializer(BoundCollectionElementInitializer node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitImplicitReceiver(BoundImplicitReceiver node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNewT(BoundNewT node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDelegateCreationExpression(BoundDelegateCreationExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitArrayCreation(BoundArrayCreation node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitArrayInitialization(BoundArrayInitialization node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitFieldAccess(BoundFieldAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitHoistedFieldAccess(BoundHoistedFieldAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitPropertyAccess(BoundPropertyAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitEventAccess(BoundEventAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitIndexerAccess(BoundIndexerAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitLambda(BoundLambda node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitUnboundLambda(UnboundLambda node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitQueryClause(BoundQueryClause node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNameOfOperator(BoundNameOfOperator node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitInterpolatedString(BoundInterpolatedString node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitStringInsert(BoundStringInsert node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitIsPatternExpression(BoundIsPatternExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDeclarationPattern(BoundDeclarationPattern node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConstantPattern(BoundConstantPattern node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitWildcardPattern(BoundWildcardPattern node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDiscardExpression(BoundDiscardExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitThrowExpression(BoundThrowExpression node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitOutVariablePendingInference(OutVariablePendingInference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node, A arg) => this.DefaultVisit(node, arg);
      public virtual R VisitConstructorMethodBody(BoundConstructorMethodBody node, A arg) => this.DefaultVisit(node, arg);
    }
    internal abstract partial class BoundTreeVisitor
    {
      public virtual BoundNode VisitFieldEqualsValue(BoundFieldEqualsValue node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node) => this.DefaultVisit(node);
      public virtual BoundNode VisitParameterEqualsValue(BoundParameterEqualsValue node) => this.DefaultVisit(node);
      public virtual BoundNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDup(BoundDup node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPassByCopy(BoundPassByCopy node) => this.DefaultVisit(node);
      public virtual BoundNode VisitBadExpression(BoundBadExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitBadStatement(BoundBadStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTypeExpression(BoundTypeExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNamespaceExpression(BoundNamespaceExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitUnaryOperator(BoundUnaryOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitIncrementOperator(BoundIncrementOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAddressOfOperator(BoundAddressOfOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPointerElementAccess(BoundPointerElementAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitRefTypeOperator(BoundRefTypeOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitMakeRefOperator(BoundMakeRefOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitRefValueOperator(BoundRefValueOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitBinaryOperator(BoundBinaryOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAssignmentOperator(BoundAssignmentOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConditionalOperator(BoundConditionalOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitArrayAccess(BoundArrayAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitArrayLength(BoundArrayLength node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAwaitExpression(BoundAwaitExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTypeOfOperator(BoundTypeOfOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitMethodDefIndex(BoundMethodDefIndex node) => this.DefaultVisit(node);
      public virtual BoundNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node) => this.DefaultVisit(node);
      public virtual BoundNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node) => this.DefaultVisit(node);
      public virtual BoundNode VisitModuleVersionId(BoundModuleVersionId node) => this.DefaultVisit(node);
      public virtual BoundNode VisitModuleVersionIdString(BoundModuleVersionIdString node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node) => this.DefaultVisit(node);
      public virtual BoundNode VisitMethodInfo(BoundMethodInfo node) => this.DefaultVisit(node);
      public virtual BoundNode VisitFieldInfo(BoundFieldInfo node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDefaultExpression(BoundDefaultExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitIsOperator(BoundIsOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAsOperator(BoundAsOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSizeOfOperator(BoundSizeOfOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConversion(BoundConversion node) => this.DefaultVisit(node);
      public virtual BoundNode VisitArgList(BoundArgList node) => this.DefaultVisit(node);
      public virtual BoundNode VisitArgListOperator(BoundArgListOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSequencePoint(BoundSequencePoint node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSequencePointExpression(BoundSequencePointExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node) => this.DefaultVisit(node);
      public virtual BoundNode VisitBlock(BoundBlock node) => this.DefaultVisit(node);
      public virtual BoundNode VisitScope(BoundScope node) => this.DefaultVisit(node);
      public virtual BoundNode VisitStateMachineScope(BoundStateMachineScope node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLocalDeclaration(BoundLocalDeclaration node) => this.DefaultVisit(node);
      public virtual BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSequence(BoundSequence node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNoOpStatement(BoundNoOpStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitReturnStatement(BoundReturnStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitYieldReturnStatement(BoundYieldReturnStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitYieldBreakStatement(BoundYieldBreakStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitThrowStatement(BoundThrowStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitExpressionStatement(BoundExpressionStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSwitchStatement(BoundSwitchStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSwitchSection(BoundSwitchSection node) => this.DefaultVisit(node);
      public virtual BoundNode VisitSwitchLabel(BoundSwitchLabel node) => this.DefaultVisit(node);
      public virtual BoundNode VisitBreakStatement(BoundBreakStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitContinueStatement(BoundContinueStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPatternSwitchSection(BoundPatternSwitchSection node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node) => this.DefaultVisit(node);
      public virtual BoundNode VisitIfStatement(BoundIfStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDoStatement(BoundDoStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitWhileStatement(BoundWhileStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitForStatement(BoundForStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitForEachStatement(BoundForEachStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node) => this.DefaultVisit(node);
      public virtual BoundNode VisitUsingStatement(BoundUsingStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitFixedStatement(BoundFixedStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLockStatement(BoundLockStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTryStatement(BoundTryStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitCatchBlock(BoundCatchBlock node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLiteral(BoundLiteral node) => this.DefaultVisit(node);
      public virtual BoundNode VisitThisReference(BoundThisReference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitBaseReference(BoundBaseReference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLocal(BoundLocal node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPseudoVariable(BoundPseudoVariable node) => this.DefaultVisit(node);
      public virtual BoundNode VisitRangeVariable(BoundRangeVariable node) => this.DefaultVisit(node);
      public virtual BoundNode VisitParameter(BoundParameter node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLabelStatement(BoundLabelStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitGotoStatement(BoundGotoStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLabeledStatement(BoundLabeledStatement node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLabel(BoundLabel node) => this.DefaultVisit(node);
      public virtual BoundNode VisitStatementList(BoundStatementList node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConditionalGoto(BoundConditionalGoto node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDynamicInvocation(BoundDynamicInvocation node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConditionalAccess(BoundConditionalAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConditionalReceiver(BoundConditionalReceiver node) => this.DefaultVisit(node);
      public virtual BoundNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node) => this.DefaultVisit(node);
      public virtual BoundNode VisitMethodGroup(BoundMethodGroup node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPropertyGroup(BoundPropertyGroup node) => this.DefaultVisit(node);
      public virtual BoundNode VisitCall(BoundCall node) => this.DefaultVisit(node);
      public virtual BoundNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAttribute(BoundAttribute node) => this.DefaultVisit(node);
      public virtual BoundNode VisitObjectCreationExpression(BoundObjectCreationExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTupleLiteral(BoundTupleLiteral node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitObjectInitializerMember(BoundObjectInitializerMember node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node) => this.DefaultVisit(node);
      public virtual BoundNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node) => this.DefaultVisit(node);
      public virtual BoundNode VisitImplicitReceiver(BoundImplicitReceiver node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNewT(BoundNewT node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitArrayCreation(BoundArrayCreation node) => this.DefaultVisit(node);
      public virtual BoundNode VisitArrayInitialization(BoundArrayInitialization node) => this.DefaultVisit(node);
      public virtual BoundNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitFieldAccess(BoundFieldAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitPropertyAccess(BoundPropertyAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitEventAccess(BoundEventAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitIndexerAccess(BoundIndexerAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node) => this.DefaultVisit(node);
      public virtual BoundNode VisitLambda(BoundLambda node) => this.DefaultVisit(node);
      public virtual BoundNode VisitUnboundLambda(UnboundLambda node) => this.DefaultVisit(node);
      public virtual BoundNode VisitQueryClause(BoundQueryClause node) => this.DefaultVisit(node);
      public virtual BoundNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNameOfOperator(BoundNameOfOperator node) => this.DefaultVisit(node);
      public virtual BoundNode VisitInterpolatedString(BoundInterpolatedString node) => this.DefaultVisit(node);
      public virtual BoundNode VisitStringInsert(BoundStringInsert node) => this.DefaultVisit(node);
      public virtual BoundNode VisitIsPatternExpression(BoundIsPatternExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDeclarationPattern(BoundDeclarationPattern node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConstantPattern(BoundConstantPattern node) => this.DefaultVisit(node);
      public virtual BoundNode VisitWildcardPattern(BoundWildcardPattern node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDiscardExpression(BoundDiscardExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitThrowExpression(BoundThrowExpression node) => this.DefaultVisit(node);
      public virtual BoundNode VisitOutVariablePendingInference(OutVariablePendingInference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node) => this.DefaultVisit(node);
      public virtual BoundNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node) => this.DefaultVisit(node);
      public virtual BoundNode VisitConstructorMethodBody(BoundConstructorMethodBody node) => this.DefaultVisit(node);
    }

    internal abstract partial class BoundTreeWalker : BoundTreeVisitor
    {
      public override BoundNode VisitFieldEqualsValue(BoundFieldEqualsValue node)
      {
        this.Visit(node.Value);
        return null;
      }
      public override BoundNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node)
      {
        this.Visit(node.Value);
        return null;
      }
      public override BoundNode VisitParameterEqualsValue(BoundParameterEqualsValue node)
      {
        this.Visit(node.Value);
        return null;
      }
      public override BoundNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node)
      {
        this.Visit(node.Statement);
        return null;
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
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitBadExpression(BoundBadExpression node)
      {
        this.VisitList(node.ChildBoundNodes);
        return null;
      }
      public override BoundNode VisitBadStatement(BoundBadStatement node)
      {
        this.VisitList(node.ChildBoundNodes);
        return null;
      }
      public override BoundNode VisitTypeExpression(BoundTypeExpression node)
      {
        this.Visit(node.BoundContainingTypeOpt);
        return null;
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
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitIncrementOperator(BoundIncrementOperator node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitAddressOfOperator(BoundAddressOfOperator node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitPointerElementAccess(BoundPointerElementAccess node)
      {
        this.Visit(node.Expression);
        this.Visit(node.Index);
        return null;
      }
      public override BoundNode VisitRefTypeOperator(BoundRefTypeOperator node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitMakeRefOperator(BoundMakeRefOperator node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitRefValueOperator(BoundRefValueOperator node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitBinaryOperator(BoundBinaryOperator node)
      {
        this.Visit(node.Left);
        this.Visit(node.Right);
        return null;
      }
      public override BoundNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node)
      {
        this.Visit(node.Left);
        this.Visit(node.Right);
        return null;
      }
      public override BoundNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node)
      {
        this.Visit(node.Left);
        this.Visit(node.Right);
        return null;
      }
      public override BoundNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node)
      {
        this.Visit(node.Left);
        this.Visit(node.Right);
        return null;
      }
      public override BoundNode VisitAssignmentOperator(BoundAssignmentOperator node)
      {
        this.Visit(node.Left);
        this.Visit(node.Right);
        return null;
      }
      public override BoundNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node)
      {
        this.Visit(node.Left);
        this.Visit(node.Right);
        return null;
      }
      public override BoundNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node)
      {
        this.Visit(node.LeftOperand);
        this.Visit(node.RightOperand);
        return null;
      }
      public override BoundNode VisitConditionalOperator(BoundConditionalOperator node)
      {
        this.Visit(node.Condition);
        this.Visit(node.Consequence);
        this.Visit(node.Alternative);
        return null;
      }
      public override BoundNode VisitArrayAccess(BoundArrayAccess node)
      {
        this.Visit(node.Expression);
        this.VisitList(node.Indices);
        return null;
      }
      public override BoundNode VisitArrayLength(BoundArrayLength node)
      {
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitAwaitExpression(BoundAwaitExpression node)
      {
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitTypeOfOperator(BoundTypeOfOperator node)
      {
        this.Visit(node.SourceType);
        return null;
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
        this.Visit(node.Operand);
        this.Visit(node.TargetType);
        return null;
      }
      public override BoundNode VisitAsOperator(BoundAsOperator node)
      {
        this.Visit(node.Operand);
        this.Visit(node.TargetType);
        return null;
      }
      public override BoundNode VisitSizeOfOperator(BoundSizeOfOperator node)
      {
        this.Visit(node.SourceType);
        return null;
      }
      public override BoundNode VisitConversion(BoundConversion node)
      {
        this.Visit(node.Operand);
        return null;
      }
      public override BoundNode VisitArgList(BoundArgList node)
      {
        return null;
      }
      public override BoundNode VisitArgListOperator(BoundArgListOperator node)
      {
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node)
      {
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitSequencePoint(BoundSequencePoint node)
      {
        this.Visit(node.StatementOpt);
        return null;
      }
      public override BoundNode VisitSequencePointExpression(BoundSequencePointExpression node)
      {
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node)
      {
        this.Visit(node.StatementOpt);
        return null;
      }
      public override BoundNode VisitBlock(BoundBlock node)
      {
        this.VisitList(node.Statements);
        return null;
      }
      public override BoundNode VisitScope(BoundScope node)
      {
        this.VisitList(node.Statements);
        return null;
      }
      public override BoundNode VisitStateMachineScope(BoundStateMachineScope node)
      {
        this.Visit(node.Statement);
        return null;
      }
      public override BoundNode VisitLocalDeclaration(BoundLocalDeclaration node)
      {
        this.Visit(node.DeclaredType);
        this.Visit(node.InitializerOpt);
        this.VisitList(node.ArgumentsOpt);
        return null;
      }
      public override BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node)
      {
        this.VisitList(node.LocalDeclarations);
        return null;
      }
      public override BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node)
      {
        this.Visit(node.BlockBody);
        this.Visit(node.ExpressionBody);
        return null;
      }
      public override BoundNode VisitSequence(BoundSequence node)
      {
        this.VisitList(node.SideEffects);
        this.Visit(node.Value);
        return null;
      }
      public override BoundNode VisitNoOpStatement(BoundNoOpStatement node)
      {
        return null;
      }
      public override BoundNode VisitReturnStatement(BoundReturnStatement node)
      {
        this.Visit(node.ExpressionOpt);
        return null;
      }
      public override BoundNode VisitYieldReturnStatement(BoundYieldReturnStatement node)
      {
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitYieldBreakStatement(BoundYieldBreakStatement node)
      {
        return null;
      }
      public override BoundNode VisitThrowStatement(BoundThrowStatement node)
      {
        this.Visit(node.ExpressionOpt);
        return null;
      }
      public override BoundNode VisitExpressionStatement(BoundExpressionStatement node)
      {
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitSwitchStatement(BoundSwitchStatement node)
      {
        this.Visit(node.LoweredPreambleOpt);
        this.Visit(node.Expression);
        this.VisitList(node.SwitchSections);
        return null;
      }
      public override BoundNode VisitSwitchSection(BoundSwitchSection node)
      {
        this.VisitList(node.SwitchLabels);
        this.VisitList(node.Statements);
        return null;
      }
      public override BoundNode VisitSwitchLabel(BoundSwitchLabel node)
      {
        this.Visit(node.ExpressionOpt);
        return null;
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
        this.Visit(node.Expression);
        this.VisitList(node.SwitchSections);
        this.Visit(node.DefaultLabel);
        return null;
      }
      public override BoundNode VisitPatternSwitchSection(BoundPatternSwitchSection node)
      {
        this.VisitList(node.SwitchLabels);
        this.VisitList(node.Statements);
        return null;
      }
      public override BoundNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node)
      {
        this.Visit(node.Pattern);
        this.Visit(node.Guard);
        return null;
      }
      public override BoundNode VisitIfStatement(BoundIfStatement node)
      {
        this.Visit(node.Condition);
        this.Visit(node.Consequence);
        this.Visit(node.AlternativeOpt);
        return null;
      }
      public override BoundNode VisitDoStatement(BoundDoStatement node)
      {
        this.Visit(node.Condition);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitWhileStatement(BoundWhileStatement node)
      {
        this.Visit(node.Condition);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitForStatement(BoundForStatement node)
      {
        this.Visit(node.Initializer);
        this.Visit(node.Condition);
        this.Visit(node.Increment);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitForEachStatement(BoundForEachStatement node)
      {
        this.Visit(node.IterationVariableType);
        this.Visit(node.IterationErrorExpressionOpt);
        this.Visit(node.Expression);
        this.Visit(node.DeconstructionOpt);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node)
      {
        this.Visit(node.DeconstructionAssignment);
        this.Visit(node.TargetPlaceholder);
        return null;
      }
      public override BoundNode VisitUsingStatement(BoundUsingStatement node)
      {
        this.Visit(node.DeclarationsOpt);
        this.Visit(node.ExpressionOpt);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitFixedStatement(BoundFixedStatement node)
      {
        this.Visit(node.Declarations);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitLockStatement(BoundLockStatement node)
      {
        this.Visit(node.Argument);
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitTryStatement(BoundTryStatement node)
      {
        this.Visit(node.TryBlock);
        this.VisitList(node.CatchBlocks);
        this.Visit(node.FinallyBlockOpt);
        return null;
      }
      public override BoundNode VisitCatchBlock(BoundCatchBlock node)
      {
        this.Visit(node.ExceptionSourceOpt);
        this.Visit(node.ExceptionFilterOpt);
        this.Visit(node.Body);
        return null;
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
        this.Visit(node.Value);
        return null;
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
        this.Visit(node.CaseExpressionOpt);
        this.Visit(node.LabelExpressionOpt);
        return null;
      }
      public override BoundNode VisitLabeledStatement(BoundLabeledStatement node)
      {
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitLabel(BoundLabel node)
      {
        return null;
      }
      public override BoundNode VisitStatementList(BoundStatementList node)
      {
        this.VisitList(node.Statements);
        return null;
      }
      public override BoundNode VisitConditionalGoto(BoundConditionalGoto node)
      {
        this.Visit(node.Condition);
        return null;
      }
      public override BoundNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node)
      {
        this.Visit(node.Receiver);
        return null;
      }
      public override BoundNode VisitDynamicInvocation(BoundDynamicInvocation node)
      {
        this.Visit(node.Expression);
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitConditionalAccess(BoundConditionalAccess node)
      {
        this.Visit(node.Receiver);
        this.Visit(node.AccessExpression);
        return null;
      }
      public override BoundNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node)
      {
        this.Visit(node.Receiver);
        this.Visit(node.WhenNotNull);
        this.Visit(node.WhenNullOpt);
        return null;
      }
      public override BoundNode VisitConditionalReceiver(BoundConditionalReceiver node)
      {
        return null;
      }
      public override BoundNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node)
      {
        this.Visit(node.ValueTypeReceiver);
        this.Visit(node.ReferenceTypeReceiver);
        return null;
      }
      public override BoundNode VisitMethodGroup(BoundMethodGroup node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitPropertyGroup(BoundPropertyGroup node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitCall(BoundCall node)
      {
        this.Visit(node.ReceiverOpt);
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node)
      {
        this.Visit(node.ReceiverOpt);
        this.Visit(node.Argument);
        return null;
      }
      public override BoundNode VisitAttribute(BoundAttribute node)
      {
        this.VisitList(node.ConstructorArguments);
        this.VisitList(node.NamedArguments);
        return null;
      }
      public override BoundNode VisitObjectCreationExpression(BoundObjectCreationExpression node)
      {
        this.VisitList(node.Arguments);
        this.Visit(node.InitializerExpressionOpt);
        return null;
      }
      public override BoundNode VisitTupleLiteral(BoundTupleLiteral node)
      {
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node)
      {
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node)
      {
        this.VisitList(node.Arguments);
        this.Visit(node.InitializerExpressionOpt);
        return null;
      }
      public override BoundNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node)
      {
        this.Visit(node.InitializerExpressionOpt);
        return null;
      }
      public override BoundNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node)
      {
        this.VisitList(node.Initializers);
        return null;
      }
      public override BoundNode VisitObjectInitializerMember(BoundObjectInitializerMember node)
      {
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node)
      {
        return null;
      }
      public override BoundNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node)
      {
        this.VisitList(node.Initializers);
        return null;
      }
      public override BoundNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node)
      {
        this.VisitList(node.Arguments);
        this.Visit(node.ImplicitReceiverOpt);
        return null;
      }
      public override BoundNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node)
      {
        this.VisitList(node.Arguments);
        this.Visit(node.ImplicitReceiver);
        return null;
      }
      public override BoundNode VisitImplicitReceiver(BoundImplicitReceiver node)
      {
        return null;
      }
      public override BoundNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node)
      {
        this.VisitList(node.Arguments);
        this.VisitList(node.Declarations);
        return null;
      }
      public override BoundNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node)
      {
        return null;
      }
      public override BoundNode VisitNewT(BoundNewT node)
      {
        this.Visit(node.InitializerExpressionOpt);
        return null;
      }
      public override BoundNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node)
      {
        this.Visit(node.Argument);
        return null;
      }
      public override BoundNode VisitArrayCreation(BoundArrayCreation node)
      {
        this.VisitList(node.Bounds);
        this.Visit(node.InitializerOpt);
        return null;
      }
      public override BoundNode VisitArrayInitialization(BoundArrayInitialization node)
      {
        this.VisitList(node.Initializers);
        return null;
      }
      public override BoundNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node)
      {
        this.Visit(node.Count);
        this.Visit(node.InitializerOpt);
        return null;
      }
      public override BoundNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node)
      {
        this.Visit(node.Count);
        this.Visit(node.InitializerOpt);
        return null;
      }
      public override BoundNode VisitFieldAccess(BoundFieldAccess node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node)
      {
        return null;
      }
      public override BoundNode VisitPropertyAccess(BoundPropertyAccess node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitEventAccess(BoundEventAccess node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitIndexerAccess(BoundIndexerAccess node)
      {
        this.Visit(node.ReceiverOpt);
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node)
      {
        this.Visit(node.ReceiverOpt);
        this.VisitList(node.Arguments);
        return null;
      }
      public override BoundNode VisitLambda(BoundLambda node)
      {
        this.Visit(node.Body);
        return null;
      }
      public override BoundNode VisitUnboundLambda(UnboundLambda node)
      {
        return null;
      }
      public override BoundNode VisitQueryClause(BoundQueryClause node)
      {
        this.Visit(node.Value);
        return null;
      }
      public override BoundNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node)
      {
        this.VisitList(node.Statements);
        return null;
      }
      public override BoundNode VisitNameOfOperator(BoundNameOfOperator node)
      {
        this.Visit(node.Argument);
        return null;
      }
      public override BoundNode VisitInterpolatedString(BoundInterpolatedString node)
      {
        this.VisitList(node.Parts);
        return null;
      }
      public override BoundNode VisitStringInsert(BoundStringInsert node)
      {
        this.Visit(node.Value);
        this.Visit(node.Alignment);
        this.Visit(node.Format);
        return null;
      }
      public override BoundNode VisitIsPatternExpression(BoundIsPatternExpression node)
      {
        this.Visit(node.Expression);
        this.Visit(node.Pattern);
        return null;
      }
      public override BoundNode VisitDeclarationPattern(BoundDeclarationPattern node)
      {
        this.Visit(node.VariableAccess);
        this.Visit(node.DeclaredType);
        return null;
      }
      public override BoundNode VisitConstantPattern(BoundConstantPattern node)
      {
        this.Visit(node.Value);
        return null;
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
        this.Visit(node.Expression);
        return null;
      }
      public override BoundNode VisitOutVariablePendingInference(OutVariablePendingInference node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node)
      {
        this.Visit(node.ReceiverOpt);
        return null;
      }
      public override BoundNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node)
      {
        return null;
      }
      public override BoundNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node)
      {
        this.Visit(node.BlockBody);
        this.Visit(node.ExpressionBody);
        return null;
      }
      public override BoundNode VisitConstructorMethodBody(BoundConstructorMethodBody node)
      {
        this.Visit(node.Initializer);
        this.Visit(node.BlockBody);
        this.Visit(node.ExpressionBody);
        return null;
      }
    }


    internal abstract partial class BoundTreeRewriter : BoundTreeVisitor
    {
      public override BoundNode VisitFieldEqualsValue(BoundFieldEqualsValue node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        return node.Update(node.Field, node.Locals, Value);
      }
      public override BoundNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        return node.Update(node.Property, node.Locals, Value);
      }
      public override BoundNode VisitParameterEqualsValue(BoundParameterEqualsValue node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        return node.Update(node.Parameter, node.Locals, Value);
      }
      public override BoundNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node)
      {
        var Statement = (BoundStatement)this.Visit(node.Statement);
        return node.Update(Statement);
      }
      public override BoundNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.ValEscape, Type);
      }
      public override BoundNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitDup(BoundDup node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.RefKind, Type);
      }
      public override BoundNode VisitPassByCopy(BoundPassByCopy node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Type);
      }
      public override BoundNode VisitBadExpression(BoundBadExpression node)
      {
        var ChildBoundNodes = (ImmutableArray<BoundExpression>)this.VisitList(node.ChildBoundNodes);
        var Type = this.VisitType(node.Type);
        return node.Update(node.ResultKind, node.Symbols, ChildBoundNodes, Type);
      }
      public override BoundNode VisitBadStatement(BoundBadStatement node)
      {
        var ChildBoundNodes = (ImmutableArray<BoundNode>)this.VisitList(node.ChildBoundNodes);
        return node.Update(ChildBoundNodes);
      }
      public override BoundNode VisitTypeExpression(BoundTypeExpression node)
      {
        var BoundContainingTypeOpt = (BoundTypeExpression)this.Visit(node.BoundContainingTypeOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.AliasOpt, node.InferredType, BoundContainingTypeOpt, Type);
      }
      public override BoundNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Data, Type);
      }
      public override BoundNode VisitNamespaceExpression(BoundNamespaceExpression node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.NamespaceSymbol, node.AliasOpt);
      }
      public override BoundNode VisitUnaryOperator(BoundUnaryOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(node.OperatorKind, Operand, node.ConstantValueOpt, node.MethodOpt, node.ResultKind, Type);
      }
      public override BoundNode VisitIncrementOperator(BoundIncrementOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(node.OperatorKind, Operand, node.MethodOpt, node.OperandConversion, node.ResultConversion, node.ResultKind, Type);
      }
      public override BoundNode VisitAddressOfOperator(BoundAddressOfOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, node.IsManaged, Type);
      }
      public override BoundNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, Type);
      }
      public override BoundNode VisitPointerElementAccess(BoundPointerElementAccess node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Index = (BoundExpression)this.Visit(node.Index);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Index, node.Checked, Type);
      }
      public override BoundNode VisitRefTypeOperator(BoundRefTypeOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, node.GetTypeFromHandle, Type);
      }
      public override BoundNode VisitMakeRefOperator(BoundMakeRefOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, Type);
      }
      public override BoundNode VisitRefValueOperator(BoundRefValueOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, Type);
      }
      public override BoundNode VisitBinaryOperator(BoundBinaryOperator node)
      {
        var Left = (BoundExpression)this.Visit(node.Left);
        var Right = (BoundExpression)this.Visit(node.Right);
        var Type = this.VisitType(node.Type);
        return node.Update(node.OperatorKind, Left, Right, node.ConstantValueOpt, node.MethodOpt, node.ResultKind, Type);
      }
      public override BoundNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node)
      {
        var Left = (BoundExpression)this.Visit(node.Left);
        var Right = (BoundExpression)this.Visit(node.Right);
        var ConvertedLeft = node.ConvertedLeft;
        var ConvertedRight = node.ConvertedRight;
        var Type = this.VisitType(node.Type);
        return node.Update(Left, Right, ConvertedLeft, ConvertedRight, node.OperatorKind, node.Operators, Type);
      }
      public override BoundNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node)
      {
        var Left = (BoundExpression)this.Visit(node.Left);
        var Right = (BoundExpression)this.Visit(node.Right);
        var Type = this.VisitType(node.Type);
        return node.Update(node.OperatorKind, Left, Right, node.LogicalOperator, node.TrueOperator, node.FalseOperator, node.ResultKind, Type);
      }
      public override BoundNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node)
      {
        var Left = (BoundExpression)this.Visit(node.Left);
        var Right = (BoundExpression)this.Visit(node.Right);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Operator, Left, Right, node.LeftConversion, node.FinalConversion, node.ResultKind, Type);
      }
      public override BoundNode VisitAssignmentOperator(BoundAssignmentOperator node)
      {
        var Left = (BoundExpression)this.Visit(node.Left);
        var Right = (BoundExpression)this.Visit(node.Right);
        var Type = this.VisitType(node.Type);
        return node.Update(Left, Right, node.IsRef, Type);
      }
      public override BoundNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node)
      {
        var Left = (BoundTupleExpression)this.Visit(node.Left);
        var Right = (BoundConversion)this.Visit(node.Right);
        var Type = this.VisitType(node.Type);
        return node.Update(Left, Right, node.IsUsed, Type);
      }
      public override BoundNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node)
      {
        var LeftOperand = (BoundExpression)this.Visit(node.LeftOperand);
        var RightOperand = (BoundExpression)this.Visit(node.RightOperand);
        var Type = this.VisitType(node.Type);
        return node.Update(LeftOperand, RightOperand, node.LeftConversion, Type);
      }
      public override BoundNode VisitConditionalOperator(BoundConditionalOperator node)
      {
        var Condition = (BoundExpression)this.Visit(node.Condition);
        var Consequence = (BoundExpression)this.Visit(node.Consequence);
        var Alternative = (BoundExpression)this.Visit(node.Alternative);
        var Type = this.VisitType(node.Type);
        return node.Update(node.IsRef, Condition, Consequence, Alternative, node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitArrayAccess(BoundArrayAccess node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Indices = (ImmutableArray<BoundExpression>)this.VisitList(node.Indices);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Indices, Type);
      }
      public override BoundNode VisitArrayLength(BoundArrayLength node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Type);
      }
      public override BoundNode VisitAwaitExpression(BoundAwaitExpression node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, node.GetAwaiter, node.IsCompleted, node.GetResult, Type);
      }
      public override BoundNode VisitTypeOfOperator(BoundTypeOfOperator node)
      {
        var SourceType = (BoundTypeExpression)this.Visit(node.SourceType);
        var Type = this.VisitType(node.Type);
        return node.Update(SourceType, node.GetTypeFromHandle, Type);
      }
      public override BoundNode VisitMethodDefIndex(BoundMethodDefIndex node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Method, Type);
      }
      public override BoundNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.AnalysisKind, Type);
      }
      public override BoundNode VisitModuleVersionId(BoundModuleVersionId node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitModuleVersionIdString(BoundModuleVersionIdString node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Document, Type);
      }
      public override BoundNode VisitMethodInfo(BoundMethodInfo node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Method, node.GetMethodFromHandle, Type);
      }
      public override BoundNode VisitFieldInfo(BoundFieldInfo node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Field, node.GetFieldFromHandle, Type);
      }
      public override BoundNode VisitDefaultExpression(BoundDefaultExpression node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitIsOperator(BoundIsOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var TargetType = (BoundTypeExpression)this.Visit(node.TargetType);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, TargetType, node.Conversion, Type);
      }
      public override BoundNode VisitAsOperator(BoundAsOperator node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var TargetType = (BoundTypeExpression)this.Visit(node.TargetType);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, TargetType, node.Conversion, Type);
      }
      public override BoundNode VisitSizeOfOperator(BoundSizeOfOperator node)
      {
        var SourceType = (BoundTypeExpression)this.Visit(node.SourceType);
        var Type = this.VisitType(node.Type);
        return node.Update(SourceType, node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitConversion(BoundConversion node)
      {
        var Operand = (BoundExpression)this.Visit(node.Operand);
        var Type = this.VisitType(node.Type);
        return node.Update(Operand, node.Conversion, node.IsBaseConversion, node.Checked, node.ExplicitCastInCode, node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitArgList(BoundArgList node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitArgListOperator(BoundArgListOperator node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Type = this.VisitType(node.Type);
        return node.Update(Arguments, node.ArgumentRefKindsOpt, Type);
      }
      public override BoundNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var ElementPointerType = this.VisitType(node.ElementPointerType);
        var Type = this.VisitType(node.Type);
        return node.Update(ElementPointerType, node.ElementPointerTypeConversion, Expression, node.GetPinnableOpt, Type);
      }
      public override BoundNode VisitSequencePoint(BoundSequencePoint node)
      {
        var StatementOpt = (BoundStatement)this.Visit(node.StatementOpt);
        return node.Update(StatementOpt);
      }
      public override BoundNode VisitSequencePointExpression(BoundSequencePointExpression node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Type);
      }
      public override BoundNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node)
      {
        var StatementOpt = (BoundStatement)this.Visit(node.StatementOpt);
        return node.Update(StatementOpt, node.Span);
      }
      public override BoundNode VisitBlock(BoundBlock node)
      {
        var Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements);
        return node.Update(node.Locals, node.LocalFunctions, Statements);
      }
      public override BoundNode VisitScope(BoundScope node)
      {
        var Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements);
        return node.Update(node.Locals, Statements);
      }
      public override BoundNode VisitStateMachineScope(BoundStateMachineScope node)
      {
        var Statement = (BoundStatement)this.Visit(node.Statement);
        return node.Update(node.Fields, Statement);
      }
      public override BoundNode VisitLocalDeclaration(BoundLocalDeclaration node)
      {
        var DeclaredType = (BoundTypeExpression)this.Visit(node.DeclaredType);
        var InitializerOpt = (BoundExpression)this.Visit(node.InitializerOpt);
        var ArgumentsOpt = (ImmutableArray<BoundExpression>)this.VisitList(node.ArgumentsOpt);
        return node.Update(node.LocalSymbol, DeclaredType, InitializerOpt, ArgumentsOpt);
      }
      public override BoundNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node)
      {
        var LocalDeclarations = (ImmutableArray<BoundLocalDeclaration>)this.VisitList(node.LocalDeclarations);
        return node.Update(LocalDeclarations);
      }
      public override BoundNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node)
      {
        var BlockBody = (BoundBlock)this.Visit(node.BlockBody);
        var ExpressionBody = (BoundBlock)this.Visit(node.ExpressionBody);
        return node.Update(node.Symbol, BlockBody, ExpressionBody);
      }
      public override BoundNode VisitSequence(BoundSequence node)
      {
        var SideEffects = (ImmutableArray<BoundExpression>)this.VisitList(node.SideEffects);
        var Value = (BoundExpression)this.Visit(node.Value);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Locals, SideEffects, Value, Type);
      }
      public override BoundNode VisitNoOpStatement(BoundNoOpStatement node)
      {
        return node;
      }
      public override BoundNode VisitReturnStatement(BoundReturnStatement node)
      {
        var ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt);
        return node.Update(node.RefKind, ExpressionOpt);
      }
      public override BoundNode VisitYieldReturnStatement(BoundYieldReturnStatement node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        return node.Update(Expression);
      }
      public override BoundNode VisitYieldBreakStatement(BoundYieldBreakStatement node)
      {
        return node;
      }
      public override BoundNode VisitThrowStatement(BoundThrowStatement node)
      {
        var ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt);
        return node.Update(ExpressionOpt);
      }
      public override BoundNode VisitExpressionStatement(BoundExpressionStatement node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        return node.Update(Expression);
      }
      public override BoundNode VisitSwitchStatement(BoundSwitchStatement node)
      {
        var LoweredPreambleOpt = (BoundStatement)this.Visit(node.LoweredPreambleOpt);
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var SwitchSections = (ImmutableArray<BoundSwitchSection>)this.VisitList(node.SwitchSections);
        return node.Update(LoweredPreambleOpt, Expression, node.ConstantTargetOpt, node.InnerLocals, node.InnerLocalFunctions, SwitchSections, node.BreakLabel, node.StringEquality);
      }
      public override BoundNode VisitSwitchSection(BoundSwitchSection node)
      {
        var SwitchLabels = (ImmutableArray<BoundSwitchLabel>)this.VisitList(node.SwitchLabels);
        var Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements);
        return node.Update(node.Locals, SwitchLabels, Statements);
      }
      public override BoundNode VisitSwitchLabel(BoundSwitchLabel node)
      {
        var ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt);
        return node.Update(node.Label, ExpressionOpt, node.ConstantValueOpt);
      }
      public override BoundNode VisitBreakStatement(BoundBreakStatement node)
      {
        return node;
      }
      public override BoundNode VisitContinueStatement(BoundContinueStatement node)
      {
        return node;
      }
      public override BoundNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var SwitchSections = (ImmutableArray<BoundPatternSwitchSection>)this.VisitList(node.SwitchSections);
        var DefaultLabel = (BoundPatternSwitchLabel)this.Visit(node.DefaultLabel);
        return node.Update(Expression, node.SomeLabelAlwaysMatches, node.InnerLocals, node.InnerLocalFunctions, SwitchSections, DefaultLabel, node.BreakLabel, node.Binder, node.IsComplete);
      }
      public override BoundNode VisitPatternSwitchSection(BoundPatternSwitchSection node)
      {
        var SwitchLabels = (ImmutableArray<BoundPatternSwitchLabel>)this.VisitList(node.SwitchLabels);
        var Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements);
        return node.Update(node.Locals, SwitchLabels, Statements);
      }
      public override BoundNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node)
      {
        var Pattern = (BoundPattern)this.Visit(node.Pattern);
        var Guard = (BoundExpression)this.Visit(node.Guard);
        return node.Update(node.Label, Pattern, Guard, node.IsReachable);
      }
      public override BoundNode VisitIfStatement(BoundIfStatement node)
      {
        var Condition = (BoundExpression)this.Visit(node.Condition);
        var Consequence = (BoundStatement)this.Visit(node.Consequence);
        var AlternativeOpt = (BoundStatement)this.Visit(node.AlternativeOpt);
        return node.Update(Condition, Consequence, AlternativeOpt);
      }
      public override BoundNode VisitDoStatement(BoundDoStatement node)
      {
        var Condition = (BoundExpression)this.Visit(node.Condition);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.Locals, Condition, Body, node.BreakLabel, node.ContinueLabel);
      }
      public override BoundNode VisitWhileStatement(BoundWhileStatement node)
      {
        var Condition = (BoundExpression)this.Visit(node.Condition);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.Locals, Condition, Body, node.BreakLabel, node.ContinueLabel);
      }
      public override BoundNode VisitForStatement(BoundForStatement node)
      {
        var Initializer = (BoundStatement)this.Visit(node.Initializer);
        var Condition = (BoundExpression)this.Visit(node.Condition);
        var Increment = (BoundStatement)this.Visit(node.Increment);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.OuterLocals, Initializer, node.InnerLocals, Condition, Increment, Body, node.BreakLabel, node.ContinueLabel);
      }
      public override BoundNode VisitForEachStatement(BoundForEachStatement node)
      {
        var IterationVariableType = (BoundTypeExpression)this.Visit(node.IterationVariableType);
        var IterationErrorExpressionOpt = (BoundExpression)this.Visit(node.IterationErrorExpressionOpt);
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var DeconstructionOpt = (BoundForEachDeconstructStep)this.Visit(node.DeconstructionOpt);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.EnumeratorInfoOpt, node.ElementConversion, IterationVariableType, node.IterationVariables, IterationErrorExpressionOpt, Expression, DeconstructionOpt, Body, node.Checked, node.BreakLabel, node.ContinueLabel);
      }
      public override BoundNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node)
      {
        var DeconstructionAssignment = (BoundDeconstructionAssignmentOperator)this.Visit(node.DeconstructionAssignment);
        var TargetPlaceholder = (BoundDeconstructValuePlaceholder)this.Visit(node.TargetPlaceholder);
        return node.Update(DeconstructionAssignment, TargetPlaceholder);
      }
      public override BoundNode VisitUsingStatement(BoundUsingStatement node)
      {
        var DeclarationsOpt = (BoundMultipleLocalDeclarations)this.Visit(node.DeclarationsOpt);
        var ExpressionOpt = (BoundExpression)this.Visit(node.ExpressionOpt);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.Locals, DeclarationsOpt, ExpressionOpt, node.IDisposableConversion, Body);
      }
      public override BoundNode VisitFixedStatement(BoundFixedStatement node)
      {
        var Declarations = (BoundMultipleLocalDeclarations)this.Visit(node.Declarations);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.Locals, Declarations, Body);
      }
      public override BoundNode VisitLockStatement(BoundLockStatement node)
      {
        var Argument = (BoundExpression)this.Visit(node.Argument);
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(Argument, Body);
      }
      public override BoundNode VisitTryStatement(BoundTryStatement node)
      {
        var TryBlock = (BoundBlock)this.Visit(node.TryBlock);
        var CatchBlocks = (ImmutableArray<BoundCatchBlock>)this.VisitList(node.CatchBlocks);
        var FinallyBlockOpt = (BoundBlock)this.Visit(node.FinallyBlockOpt);
        return node.Update(TryBlock, CatchBlocks, FinallyBlockOpt, node.PreferFaultHandler);
      }
      public override BoundNode VisitCatchBlock(BoundCatchBlock node)
      {
        var ExceptionSourceOpt = (BoundExpression)this.Visit(node.ExceptionSourceOpt);
        var ExceptionFilterOpt = (BoundExpression)this.Visit(node.ExceptionFilterOpt);
        var Body = (BoundBlock)this.Visit(node.Body);
        var ExceptionTypeOpt = this.VisitType(node.ExceptionTypeOpt);
        return node.Update(node.Locals, ExceptionSourceOpt, ExceptionTypeOpt, ExceptionFilterOpt, Body, node.IsSynthesizedAsyncCatchAll);
      }
      public override BoundNode VisitLiteral(BoundLiteral node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitThisReference(BoundThisReference node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitBaseReference(BoundBaseReference node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitLocal(BoundLocal node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.LocalSymbol, node.IsDeclaration, node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitPseudoVariable(BoundPseudoVariable node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.LocalSymbol, node.EmitExpressions, Type);
      }
      public override BoundNode VisitRangeVariable(BoundRangeVariable node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        var Type = this.VisitType(node.Type);
        return node.Update(node.RangeVariableSymbol, Value, Type);
      }
      public override BoundNode VisitParameter(BoundParameter node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.ParameterSymbol, Type);
      }
      public override BoundNode VisitLabelStatement(BoundLabelStatement node)
      {
        return node;
      }
      public override BoundNode VisitGotoStatement(BoundGotoStatement node)
      {
        var CaseExpressionOpt = (BoundExpression)this.Visit(node.CaseExpressionOpt);
        var LabelExpressionOpt = (BoundLabel)this.Visit(node.LabelExpressionOpt);
        return node.Update(node.Label, CaseExpressionOpt, LabelExpressionOpt);
      }
      public override BoundNode VisitLabeledStatement(BoundLabeledStatement node)
      {
        var Body = (BoundStatement)this.Visit(node.Body);
        return node.Update(node.Label, Body);
      }
      public override BoundNode VisitLabel(BoundLabel node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Label, Type);
      }
      public override BoundNode VisitStatementList(BoundStatementList node)
      {
        var Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements);
        return node.Update(Statements);
      }
      public override BoundNode VisitConditionalGoto(BoundConditionalGoto node)
      {
        var Condition = (BoundExpression)this.Visit(node.Condition);
        return node.Update(Condition, node.JumpIfTrue, node.Label);
      }
      public override BoundNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node)
      {
        var Receiver = (BoundExpression)this.Visit(node.Receiver);
        var Type = this.VisitType(node.Type);
        return node.Update(Receiver, node.TypeArgumentsOpt, node.Name, node.Invoked, node.Indexed, Type);
      }
      public override BoundNode VisitDynamicInvocation(BoundDynamicInvocation node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.ApplicableMethods, Type);
      }
      public override BoundNode VisitConditionalAccess(BoundConditionalAccess node)
      {
        var Receiver = (BoundExpression)this.Visit(node.Receiver);
        var AccessExpression = (BoundExpression)this.Visit(node.AccessExpression);
        var Type = this.VisitType(node.Type);
        return node.Update(Receiver, AccessExpression, Type);
      }
      public override BoundNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node)
      {
        var Receiver = (BoundExpression)this.Visit(node.Receiver);
        var WhenNotNull = (BoundExpression)this.Visit(node.WhenNotNull);
        var WhenNullOpt = (BoundExpression)this.Visit(node.WhenNullOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(Receiver, node.HasValueMethodOpt, WhenNotNull, WhenNullOpt, node.Id, Type);
      }
      public override BoundNode VisitConditionalReceiver(BoundConditionalReceiver node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Id, Type);
      }
      public override BoundNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node)
      {
        var ValueTypeReceiver = (BoundExpression)this.Visit(node.ValueTypeReceiver);
        var ReferenceTypeReceiver = (BoundExpression)this.Visit(node.ReferenceTypeReceiver);
        var Type = this.VisitType(node.Type);
        return node.Update(ValueTypeReceiver, ReferenceTypeReceiver, Type);
      }
      public override BoundNode VisitMethodGroup(BoundMethodGroup node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.TypeArgumentsOpt, node.Name, node.Methods, node.LookupSymbolOpt, node.LookupError, node.Flags, ReceiverOpt, node.ResultKind);
      }
      public override BoundNode VisitPropertyGroup(BoundPropertyGroup node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Properties, ReceiverOpt, node.ResultKind);
      }
      public override BoundNode VisitCall(BoundCall node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Type = this.VisitType(node.Type);
        return node.Update(ReceiverOpt, node.Method, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.IsDelegateCall, node.Expanded, node.InvokedAsExtensionMethod, node.ArgsToParamsOpt, node.ResultKind, node.BinderOpt, Type);
      }
      public override BoundNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Argument = (BoundExpression)this.Visit(node.Argument);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Event, node.IsAddition, node.IsDynamic, ReceiverOpt, Argument, Type);
      }
      public override BoundNode VisitAttribute(BoundAttribute node)
      {
        var ConstructorArguments = (ImmutableArray<BoundExpression>)this.VisitList(node.ConstructorArguments);
        var NamedArguments = (ImmutableArray<BoundExpression>)this.VisitList(node.NamedArguments);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Constructor, ConstructorArguments, node.ConstructorArgumentNamesOpt, NamedArguments, node.ResultKind, Type);
      }
      public override BoundNode VisitObjectCreationExpression(BoundObjectCreationExpression node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Constructor, node.ConstructorsGroup, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.ConstantValueOpt, InitializerExpressionOpt, node.BinderOpt, Type);
      }
      public override BoundNode VisitTupleLiteral(BoundTupleLiteral node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Type = this.VisitType(node.Type);
        return node.Update(node.ArgumentNamesOpt, node.InferredNamesOpt, Arguments, Type);
      }
      public override BoundNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var NaturalTypeOpt = this.VisitType(node.NaturalTypeOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(NaturalTypeOpt, Arguments, Type);
      }
      public override BoundNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Name, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, InitializerExpressionOpt, node.ApplicableMethods, Type);
      }
      public override BoundNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node)
      {
        var InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.GuidString, InitializerExpressionOpt, Type);
      }
      public override BoundNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node)
      {
        var Initializers = (ImmutableArray<BoundExpression>)this.VisitList(node.Initializers);
        var Type = this.VisitType(node.Type);
        return node.Update(Initializers, Type);
      }
      public override BoundNode VisitObjectInitializerMember(BoundObjectInitializerMember node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var ReceiverType = this.VisitType(node.ReceiverType);
        var Type = this.VisitType(node.Type);
        return node.Update(node.MemberSymbol, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.ResultKind, ReceiverType, node.BinderOpt, Type);
      }
      public override BoundNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node)
      {
        var ReceiverType = this.VisitType(node.ReceiverType);
        var Type = this.VisitType(node.Type);
        return node.Update(node.MemberName, ReceiverType, Type);
      }
      public override BoundNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node)
      {
        var Initializers = (ImmutableArray<BoundExpression>)this.VisitList(node.Initializers);
        var Type = this.VisitType(node.Type);
        return node.Update(Initializers, Type);
      }
      public override BoundNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var ImplicitReceiverOpt = (BoundExpression)this.Visit(node.ImplicitReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.AddMethod, Arguments, ImplicitReceiverOpt, node.Expanded, node.ArgsToParamsOpt, node.InvokedAsExtensionMethod, node.ResultKind, node.BinderOpt, Type);
      }
      public override BoundNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var ImplicitReceiver = (BoundImplicitReceiver)this.Visit(node.ImplicitReceiver);
        var Type = this.VisitType(node.Type);
        return node.Update(Arguments, ImplicitReceiver, node.ApplicableMethods, Type);
      }
      public override BoundNode VisitImplicitReceiver(BoundImplicitReceiver node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node)
      {
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Declarations = (ImmutableArray<BoundAnonymousPropertyDeclaration>)this.VisitList(node.Declarations);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Constructor, Arguments, Declarations, Type);
      }
      public override BoundNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Property, Type);
      }
      public override BoundNode VisitNewT(BoundNewT node)
      {
        var InitializerExpressionOpt = (BoundObjectInitializerExpressionBase)this.Visit(node.InitializerExpressionOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(InitializerExpressionOpt, Type);
      }
      public override BoundNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node)
      {
        var Argument = (BoundExpression)this.Visit(node.Argument);
        var Type = this.VisitType(node.Type);
        return node.Update(Argument, node.MethodOpt, node.IsExtensionMethod, Type);
      }
      public override BoundNode VisitArrayCreation(BoundArrayCreation node)
      {
        var Bounds = (ImmutableArray<BoundExpression>)this.VisitList(node.Bounds);
        var InitializerOpt = (BoundArrayInitialization)this.Visit(node.InitializerOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(Bounds, InitializerOpt, Type);
      }
      public override BoundNode VisitArrayInitialization(BoundArrayInitialization node)
      {
        var Initializers = (ImmutableArray<BoundExpression>)this.VisitList(node.Initializers);
        var Type = this.VisitType(node.Type);
        return node.Update(Initializers);
      }
      public override BoundNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node)
      {
        var Count = (BoundExpression)this.Visit(node.Count);
        var InitializerOpt = (BoundArrayInitialization)this.Visit(node.InitializerOpt);
        var ElementType = this.VisitType(node.ElementType);
        var Type = this.VisitType(node.Type);
        return node.Update(ElementType, Count, InitializerOpt, Type);
      }
      public override BoundNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node)
      {
        var Count = (BoundExpression)this.Visit(node.Count);
        var InitializerOpt = (BoundArrayInitialization)this.Visit(node.InitializerOpt);
        var ElementType = this.VisitType(node.ElementType);
        var Type = this.VisitType(node.Type);
        return node.Update(ElementType, Count, InitializerOpt, Type);
      }
      public override BoundNode VisitFieldAccess(BoundFieldAccess node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(ReceiverOpt, node.FieldSymbol, node.ConstantValueOpt, node.ResultKind, node.IsByValue, node.IsDeclaration, Type);
      }
      public override BoundNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.FieldSymbol, Type);
      }
      public override BoundNode VisitPropertyAccess(BoundPropertyAccess node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(ReceiverOpt, node.PropertySymbol, node.ResultKind, Type);
      }
      public override BoundNode VisitEventAccess(BoundEventAccess node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(ReceiverOpt, node.EventSymbol, node.IsUsableAsField, node.ResultKind, Type);
      }
      public override BoundNode VisitIndexerAccess(BoundIndexerAccess node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Type = this.VisitType(node.Type);
        return node.Update(ReceiverOpt, node.Indexer, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.Expanded, node.ArgsToParamsOpt, node.BinderOpt, node.UseSetterForDefaultArgumentGeneration, Type);
      }
      public override BoundNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Arguments = (ImmutableArray<BoundExpression>)this.VisitList(node.Arguments);
        var Type = this.VisitType(node.Type);
        return node.Update(ReceiverOpt, Arguments, node.ArgumentNamesOpt, node.ArgumentRefKindsOpt, node.ApplicableIndexers, Type);
      }
      public override BoundNode VisitLambda(BoundLambda node)
      {
        var Body = (BoundBlock)this.Visit(node.Body);
        var Type = this.VisitType(node.Type);
        return node.Update(node.Symbol, Body, node.Diagnostics, node.Binder, Type);
      }
      public override BoundNode VisitUnboundLambda(UnboundLambda node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(node.Data);
      }
      public override BoundNode VisitQueryClause(BoundQueryClause node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        var Type = this.VisitType(node.Type);
        return node.Update(Value, node.DefinedSymbol, node.Binder, Type);
      }
      public override BoundNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node)
      {
        var Statements = (ImmutableArray<BoundStatement>)this.VisitList(node.Statements);
        return node.Update(Statements);
      }
      public override BoundNode VisitNameOfOperator(BoundNameOfOperator node)
      {
        var Argument = (BoundExpression)this.Visit(node.Argument);
        var Type = this.VisitType(node.Type);
        return node.Update(Argument, node.ConstantValueOpt, Type);
      }
      public override BoundNode VisitInterpolatedString(BoundInterpolatedString node)
      {
        var Parts = (ImmutableArray<BoundExpression>)this.VisitList(node.Parts);
        var Type = this.VisitType(node.Type);
        return node.Update(Parts, Type);
      }
      public override BoundNode VisitStringInsert(BoundStringInsert node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        var Alignment = (BoundExpression)this.Visit(node.Alignment);
        var Format = (BoundLiteral)this.Visit(node.Format);
        var Type = this.VisitType(node.Type);
        return node.Update(Value, Alignment, Format, Type);
      }
      public override BoundNode VisitIsPatternExpression(BoundIsPatternExpression node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Pattern = (BoundPattern)this.Visit(node.Pattern);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Pattern, Type);
      }
      public override BoundNode VisitDeclarationPattern(BoundDeclarationPattern node)
      {
        var VariableAccess = (BoundExpression)this.Visit(node.VariableAccess);
        var DeclaredType = (BoundTypeExpression)this.Visit(node.DeclaredType);
        return node.Update(node.Variable, VariableAccess, DeclaredType, node.IsVar);
      }
      public override BoundNode VisitConstantPattern(BoundConstantPattern node)
      {
        var Value = (BoundExpression)this.Visit(node.Value);
        return node.Update(Value, node.ConstantValue);
      }
      public override BoundNode VisitWildcardPattern(BoundWildcardPattern node)
      {
        return node;
      }
      public override BoundNode VisitDiscardExpression(BoundDiscardExpression node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update(Type);
      }
      public override BoundNode VisitThrowExpression(BoundThrowExpression node)
      {
        var Expression = (BoundExpression)this.Visit(node.Expression);
        var Type = this.VisitType(node.Type);
        return node.Update(Expression, Type);
      }
      public override BoundNode VisitOutVariablePendingInference(OutVariablePendingInference node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.VariableSymbol, ReceiverOpt);
      }
      public override BoundNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node)
      {
        var ReceiverOpt = (BoundExpression)this.Visit(node.ReceiverOpt);
        var Type = this.VisitType(node.Type);
        return node.Update(node.VariableSymbol, ReceiverOpt);
      }
      public override BoundNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node)
      {
        var Type = this.VisitType(node.Type);
        return node.Update();
      }
      public override BoundNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node)
      {
        var BlockBody = (BoundBlock)this.Visit(node.BlockBody);
        var ExpressionBody = (BoundBlock)this.Visit(node.ExpressionBody);
        return node.Update(BlockBody, ExpressionBody);
      }
      public override BoundNode VisitConstructorMethodBody(BoundConstructorMethodBody node)
      {
        var Initializer = (BoundExpressionStatement)this.Visit(node.Initializer);
        var BlockBody = (BoundBlock)this.Visit(node.BlockBody);
        var ExpressionBody = (BoundBlock)this.Visit(node.ExpressionBody);
        return node.Update(node.Locals, Initializer, BlockBody, ExpressionBody);
      }
    }

    internal sealed class BoundTreeDumperNodeProducer : BoundTreeVisitor<Object, TreeDumperNode>
    {
      private BoundTreeDumperNodeProducer(){
      }
      public static TreeDumperNode MakeTree(BoundNode node)
      {
        return (new BoundTreeDumperNodeProducer()).Visit(node, null);
      }
      public override TreeDumperNode VisitFieldEqualsValue(BoundFieldEqualsValue node, Object arg)
      {
        return new TreeDumperNode("fieldEqualsValue", null, new TreeDumperNode[]{
            new TreeDumperNode("field", node.Field, null),
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) })
        });
      }
      public override TreeDumperNode VisitPropertyEqualsValue(BoundPropertyEqualsValue node, Object arg)
      {
        return new TreeDumperNode("propertyEqualsValue", null, new TreeDumperNode[]{
            new TreeDumperNode("property", node.Property, null),
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) })
        });
      }
      public override TreeDumperNode VisitParameterEqualsValue(BoundParameterEqualsValue node, Object arg)
      {
        return new TreeDumperNode("parameterEqualsValue", null, new TreeDumperNode[]{
            new TreeDumperNode("parameter", node.Parameter, null),
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) })
        });
      }
      public override TreeDumperNode VisitGlobalStatementInitializer(BoundGlobalStatementInitializer node, Object arg)
      {
        return new TreeDumperNode("globalStatementInitializer", null, new TreeDumperNode[]{
            new TreeDumperNode("statement", null, new TreeDumperNode[]{ Visit(node.Statement, null) })
        });
      }
      public override TreeDumperNode VisitDeconstructValuePlaceholder(BoundDeconstructValuePlaceholder node, Object arg)
      {
        return new TreeDumperNode("deconstructValuePlaceholder", null, new TreeDumperNode[]{
            new TreeDumperNode("valEscape", node.ValEscape, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitTupleOperandPlaceholder(BoundTupleOperandPlaceholder node, Object arg)
      {
        return new TreeDumperNode("tupleOperandPlaceholder", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDup(BoundDup node, Object arg)
      {
        return new TreeDumperNode("dup", null, new TreeDumperNode[]{
            new TreeDumperNode("refKind", node.RefKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPassByCopy(BoundPassByCopy node, Object arg)
      {
        return new TreeDumperNode("passByCopy", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitBadExpression(BoundBadExpression node, Object arg)
      {
        return new TreeDumperNode("badExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("symbols", node.Symbols, null),
            new TreeDumperNode("childBoundNodes", null, from x in node.ChildBoundNodes select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitBadStatement(BoundBadStatement node, Object arg)
      {
        return new TreeDumperNode("badStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("childBoundNodes", null, from x in node.ChildBoundNodes select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitTypeExpression(BoundTypeExpression node, Object arg)
      {
        return new TreeDumperNode("typeExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("aliasOpt", node.AliasOpt, null),
            new TreeDumperNode("inferredType", node.InferredType, null),
            new TreeDumperNode("boundContainingTypeOpt", null, new TreeDumperNode[]{ Visit(node.BoundContainingTypeOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitTypeOrValueExpression(BoundTypeOrValueExpression node, Object arg)
      {
        return new TreeDumperNode("typeOrValueExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("data", node.Data, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitNamespaceExpression(BoundNamespaceExpression node, Object arg)
      {
        return new TreeDumperNode("namespaceExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("namespaceSymbol", node.NamespaceSymbol, null),
            new TreeDumperNode("aliasOpt", node.AliasOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitUnaryOperator(BoundUnaryOperator node, Object arg)
      {
        return new TreeDumperNode("unaryOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operatorKind", node.OperatorKind, null),
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("methodOpt", node.MethodOpt, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitIncrementOperator(BoundIncrementOperator node, Object arg)
      {
        return new TreeDumperNode("incrementOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operatorKind", node.OperatorKind, null),
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("methodOpt", node.MethodOpt, null),
            new TreeDumperNode("operandConversion", node.OperandConversion, null),
            new TreeDumperNode("resultConversion", node.ResultConversion, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAddressOfOperator(BoundAddressOfOperator node, Object arg)
      {
        return new TreeDumperNode("addressOfOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("isManaged", node.IsManaged, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPointerIndirectionOperator(BoundPointerIndirectionOperator node, Object arg)
      {
        return new TreeDumperNode("pointerIndirectionOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPointerElementAccess(BoundPointerElementAccess node, Object arg)
      {
        return new TreeDumperNode("pointerElementAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("index", null, new TreeDumperNode[]{ Visit(node.Index, null) }),
            new TreeDumperNode("@checked", node.Checked, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitRefTypeOperator(BoundRefTypeOperator node, Object arg)
      {
        return new TreeDumperNode("refTypeOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("getTypeFromHandle", node.GetTypeFromHandle, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitMakeRefOperator(BoundMakeRefOperator node, Object arg)
      {
        return new TreeDumperNode("makeRefOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitRefValueOperator(BoundRefValueOperator node, Object arg)
      {
        return new TreeDumperNode("refValueOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitBinaryOperator(BoundBinaryOperator node, Object arg)
      {
        return new TreeDumperNode("binaryOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operatorKind", node.OperatorKind, null),
            new TreeDumperNode("left", null, new TreeDumperNode[]{ Visit(node.Left, null) }),
            new TreeDumperNode("right", null, new TreeDumperNode[]{ Visit(node.Right, null) }),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("methodOpt", node.MethodOpt, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitTupleBinaryOperator(BoundTupleBinaryOperator node, Object arg)
      {
        return new TreeDumperNode("tupleBinaryOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("left", null, new TreeDumperNode[]{ Visit(node.Left, null) }),
            new TreeDumperNode("right", null, new TreeDumperNode[]{ Visit(node.Right, null) }),
            new TreeDumperNode("convertedLeft", null, new TreeDumperNode[]{ Visit(node.ConvertedLeft, null) }),
            new TreeDumperNode("convertedRight", null, new TreeDumperNode[]{ Visit(node.ConvertedRight, null) }),
            new TreeDumperNode("operatorKind", node.OperatorKind, null),
            new TreeDumperNode("operators", node.Operators, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitUserDefinedConditionalLogicalOperator(BoundUserDefinedConditionalLogicalOperator node, Object arg)
      {
        return new TreeDumperNode("userDefinedConditionalLogicalOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operatorKind", node.OperatorKind, null),
            new TreeDumperNode("left", null, new TreeDumperNode[]{ Visit(node.Left, null) }),
            new TreeDumperNode("right", null, new TreeDumperNode[]{ Visit(node.Right, null) }),
            new TreeDumperNode("logicalOperator", node.LogicalOperator, null),
            new TreeDumperNode("trueOperator", node.TrueOperator, null),
            new TreeDumperNode("falseOperator", node.FalseOperator, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitCompoundAssignmentOperator(BoundCompoundAssignmentOperator node, Object arg)
      {
        return new TreeDumperNode("compoundAssignmentOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("@operator", node.Operator, null),
            new TreeDumperNode("left", null, new TreeDumperNode[]{ Visit(node.Left, null) }),
            new TreeDumperNode("right", null, new TreeDumperNode[]{ Visit(node.Right, null) }),
            new TreeDumperNode("leftConversion", node.LeftConversion, null),
            new TreeDumperNode("finalConversion", node.FinalConversion, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAssignmentOperator(BoundAssignmentOperator node, Object arg)
      {
        return new TreeDumperNode("assignmentOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("left", null, new TreeDumperNode[]{ Visit(node.Left, null) }),
            new TreeDumperNode("right", null, new TreeDumperNode[]{ Visit(node.Right, null) }),
            new TreeDumperNode("isRef", node.IsRef, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDeconstructionAssignmentOperator(BoundDeconstructionAssignmentOperator node, Object arg)
      {
        return new TreeDumperNode("deconstructionAssignmentOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("left", null, new TreeDumperNode[]{ Visit(node.Left, null) }),
            new TreeDumperNode("right", null, new TreeDumperNode[]{ Visit(node.Right, null) }),
            new TreeDumperNode("isUsed", node.IsUsed, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitNullCoalescingOperator(BoundNullCoalescingOperator node, Object arg)
      {
        return new TreeDumperNode("nullCoalescingOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("leftOperand", null, new TreeDumperNode[]{ Visit(node.LeftOperand, null) }),
            new TreeDumperNode("rightOperand", null, new TreeDumperNode[]{ Visit(node.RightOperand, null) }),
            new TreeDumperNode("leftConversion", node.LeftConversion, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitConditionalOperator(BoundConditionalOperator node, Object arg)
      {
        return new TreeDumperNode("conditionalOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("isRef", node.IsRef, null),
            new TreeDumperNode("condition", null, new TreeDumperNode[]{ Visit(node.Condition, null) }),
            new TreeDumperNode("consequence", null, new TreeDumperNode[]{ Visit(node.Consequence, null) }),
            new TreeDumperNode("alternative", null, new TreeDumperNode[]{ Visit(node.Alternative, null) }),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitArrayAccess(BoundArrayAccess node, Object arg)
      {
        return new TreeDumperNode("arrayAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("indices", null, from x in node.Indices select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitArrayLength(BoundArrayLength node, Object arg)
      {
        return new TreeDumperNode("arrayLength", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAwaitExpression(BoundAwaitExpression node, Object arg)
      {
        return new TreeDumperNode("awaitExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("getAwaiter", node.GetAwaiter, null),
            new TreeDumperNode("isCompleted", node.IsCompleted, null),
            new TreeDumperNode("getResult", node.GetResult, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitTypeOfOperator(BoundTypeOfOperator node, Object arg)
      {
        return new TreeDumperNode("typeOfOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("sourceType", null, new TreeDumperNode[]{ Visit(node.SourceType, null) }),
            new TreeDumperNode("getTypeFromHandle", node.GetTypeFromHandle, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitMethodDefIndex(BoundMethodDefIndex node, Object arg)
      {
        return new TreeDumperNode("methodDefIndex", null, new TreeDumperNode[]{
            new TreeDumperNode("method", node.Method, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitMaximumMethodDefIndex(BoundMaximumMethodDefIndex node, Object arg)
      {
        return new TreeDumperNode("maximumMethodDefIndex", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitInstrumentationPayloadRoot(BoundInstrumentationPayloadRoot node, Object arg)
      {
        return new TreeDumperNode("instrumentationPayloadRoot", null, new TreeDumperNode[]{
            new TreeDumperNode("analysisKind", node.AnalysisKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitModuleVersionId(BoundModuleVersionId node, Object arg)
      {
        return new TreeDumperNode("moduleVersionId", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitModuleVersionIdString(BoundModuleVersionIdString node, Object arg)
      {
        return new TreeDumperNode("moduleVersionIdString", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitSourceDocumentIndex(BoundSourceDocumentIndex node, Object arg)
      {
        return new TreeDumperNode("sourceDocumentIndex", null, new TreeDumperNode[]{
            new TreeDumperNode("document", node.Document, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitMethodInfo(BoundMethodInfo node, Object arg)
      {
        return new TreeDumperNode("methodInfo", null, new TreeDumperNode[]{
            new TreeDumperNode("method", node.Method, null),
            new TreeDumperNode("getMethodFromHandle", node.GetMethodFromHandle, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitFieldInfo(BoundFieldInfo node, Object arg)
      {
        return new TreeDumperNode("fieldInfo", null, new TreeDumperNode[]{
            new TreeDumperNode("field", node.Field, null),
            new TreeDumperNode("getFieldFromHandle", node.GetFieldFromHandle, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDefaultExpression(BoundDefaultExpression node, Object arg)
      {
        return new TreeDumperNode("defaultExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitIsOperator(BoundIsOperator node, Object arg)
      {
        return new TreeDumperNode("isOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("targetType", null, new TreeDumperNode[]{ Visit(node.TargetType, null) }),
            new TreeDumperNode("conversion", node.Conversion, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAsOperator(BoundAsOperator node, Object arg)
      {
        return new TreeDumperNode("asOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("targetType", null, new TreeDumperNode[]{ Visit(node.TargetType, null) }),
            new TreeDumperNode("conversion", node.Conversion, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitSizeOfOperator(BoundSizeOfOperator node, Object arg)
      {
        return new TreeDumperNode("sizeOfOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("sourceType", null, new TreeDumperNode[]{ Visit(node.SourceType, null) }),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitConversion(BoundConversion node, Object arg)
      {
        return new TreeDumperNode("conversion", null, new TreeDumperNode[]{
            new TreeDumperNode("operand", null, new TreeDumperNode[]{ Visit(node.Operand, null) }),
            new TreeDumperNode("conversion", node.Conversion, null),
            new TreeDumperNode("isBaseConversion", node.IsBaseConversion, null),
            new TreeDumperNode("@checked", node.Checked, null),
            new TreeDumperNode("explicitCastInCode", node.ExplicitCastInCode, null),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitArgList(BoundArgList node, Object arg)
      {
        return new TreeDumperNode("argList", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitArgListOperator(BoundArgListOperator node, Object arg)
      {
        return new TreeDumperNode("argListOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitFixedLocalCollectionInitializer(BoundFixedLocalCollectionInitializer node, Object arg)
      {
        return new TreeDumperNode("fixedLocalCollectionInitializer", null, new TreeDumperNode[]{
            new TreeDumperNode("elementPointerType", node.ElementPointerType, null),
            new TreeDumperNode("elementPointerTypeConversion", node.ElementPointerTypeConversion, null),
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("getPinnableOpt", node.GetPinnableOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitSequencePoint(BoundSequencePoint node, Object arg)
      {
        return new TreeDumperNode("sequencePoint", null, new TreeDumperNode[]{
            new TreeDumperNode("statementOpt", null, new TreeDumperNode[]{ Visit(node.StatementOpt, null) })
        });
      }
      public override TreeDumperNode VisitSequencePointExpression(BoundSequencePointExpression node, Object arg)
      {
        return new TreeDumperNode("sequencePointExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitSequencePointWithSpan(BoundSequencePointWithSpan node, Object arg)
      {
        return new TreeDumperNode("sequencePointWithSpan", null, new TreeDumperNode[]{
            new TreeDumperNode("statementOpt", null, new TreeDumperNode[]{ Visit(node.StatementOpt, null) }),
            new TreeDumperNode("span", node.Span, null)
        });
      }
      public override TreeDumperNode VisitBlock(BoundBlock node, Object arg)
      {
        return new TreeDumperNode("block", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("localFunctions", node.LocalFunctions, null),
            new TreeDumperNode("statements", null, from x in node.Statements select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitScope(BoundScope node, Object arg)
      {
        return new TreeDumperNode("scope", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("statements", null, from x in node.Statements select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitStateMachineScope(BoundStateMachineScope node, Object arg)
      {
        return new TreeDumperNode("stateMachineScope", null, new TreeDumperNode[]{
            new TreeDumperNode("fields", node.Fields, null),
            new TreeDumperNode("statement", null, new TreeDumperNode[]{ Visit(node.Statement, null) })
        });
      }
      public override TreeDumperNode VisitLocalDeclaration(BoundLocalDeclaration node, Object arg)
      {
        return new TreeDumperNode("localDeclaration", null, new TreeDumperNode[]{
            new TreeDumperNode("localSymbol", node.LocalSymbol, null),
            new TreeDumperNode("declaredType", null, new TreeDumperNode[]{ Visit(node.DeclaredType, null) }),
            new TreeDumperNode("initializerOpt", null, new TreeDumperNode[]{ Visit(node.InitializerOpt, null) }),
            new TreeDumperNode("argumentsOpt", null, from x in node.ArgumentsOpt select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitMultipleLocalDeclarations(BoundMultipleLocalDeclarations node, Object arg)
      {
        return new TreeDumperNode("multipleLocalDeclarations", null, new TreeDumperNode[]{
            new TreeDumperNode("localDeclarations", null, from x in node.LocalDeclarations select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitLocalFunctionStatement(BoundLocalFunctionStatement node, Object arg)
      {
        return new TreeDumperNode("localFunctionStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("symbol", node.Symbol, null),
            new TreeDumperNode("blockBody", null, new TreeDumperNode[]{ Visit(node.BlockBody, null) }),
            new TreeDumperNode("expressionBody", null, new TreeDumperNode[]{ Visit(node.ExpressionBody, null) })
        });
      }
      public override TreeDumperNode VisitSequence(BoundSequence node, Object arg)
      {
        return new TreeDumperNode("sequence", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("sideEffects", null, from x in node.SideEffects select Visit(x, null)),
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitNoOpStatement(BoundNoOpStatement node, Object arg)
      {
        return new TreeDumperNode("noOpStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("flavor", node.Flavor, null)
        });
      }
      public override TreeDumperNode VisitReturnStatement(BoundReturnStatement node, Object arg)
      {
        return new TreeDumperNode("returnStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("refKind", node.RefKind, null),
            new TreeDumperNode("expressionOpt", null, new TreeDumperNode[]{ Visit(node.ExpressionOpt, null) })
        });
      }
      public override TreeDumperNode VisitYieldReturnStatement(BoundYieldReturnStatement node, Object arg)
      {
        return new TreeDumperNode("yieldReturnStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) })
        });
      }
      public override TreeDumperNode VisitYieldBreakStatement(BoundYieldBreakStatement node, Object arg)
      {
        return new TreeDumperNode("yieldBreakStatement", null, Array.Empty<TreeDumperNode>());
      }
      public override TreeDumperNode VisitThrowStatement(BoundThrowStatement node, Object arg)
      {
        return new TreeDumperNode("throwStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("expressionOpt", null, new TreeDumperNode[]{ Visit(node.ExpressionOpt, null) })
        });
      }
      public override TreeDumperNode VisitExpressionStatement(BoundExpressionStatement node, Object arg)
      {
        return new TreeDumperNode("expressionStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) })
        });
      }
      public override TreeDumperNode VisitSwitchStatement(BoundSwitchStatement node, Object arg)
      {
        return new TreeDumperNode("switchStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("loweredPreambleOpt", null, new TreeDumperNode[]{ Visit(node.LoweredPreambleOpt, null) }),
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("constantTargetOpt", node.ConstantTargetOpt, null),
            new TreeDumperNode("innerLocals", node.InnerLocals, null),
            new TreeDumperNode("innerLocalFunctions", node.InnerLocalFunctions, null),
            new TreeDumperNode("switchSections", null, from x in node.SwitchSections select Visit(x, null)),
            new TreeDumperNode("breakLabel", node.BreakLabel, null),
            new TreeDumperNode("stringEquality", node.StringEquality, null)
        });
      }
      public override TreeDumperNode VisitSwitchSection(BoundSwitchSection node, Object arg)
      {
        return new TreeDumperNode("switchSection", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("switchLabels", null, from x in node.SwitchLabels select Visit(x, null)),
            new TreeDumperNode("statements", null, from x in node.Statements select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitSwitchLabel(BoundSwitchLabel node, Object arg)
      {
        return new TreeDumperNode("switchLabel", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null),
            new TreeDumperNode("expressionOpt", null, new TreeDumperNode[]{ Visit(node.ExpressionOpt, null) }),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null)
        });
      }
      public override TreeDumperNode VisitBreakStatement(BoundBreakStatement node, Object arg)
      {
        return new TreeDumperNode("breakStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null)
        });
      }
      public override TreeDumperNode VisitContinueStatement(BoundContinueStatement node, Object arg)
      {
        return new TreeDumperNode("continueStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null)
        });
      }
      public override TreeDumperNode VisitPatternSwitchStatement(BoundPatternSwitchStatement node, Object arg)
      {
        return new TreeDumperNode("patternSwitchStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("someLabelAlwaysMatches", node.SomeLabelAlwaysMatches, null),
            new TreeDumperNode("innerLocals", node.InnerLocals, null),
            new TreeDumperNode("innerLocalFunctions", node.InnerLocalFunctions, null),
            new TreeDumperNode("switchSections", null, from x in node.SwitchSections select Visit(x, null)),
            new TreeDumperNode("defaultLabel", null, new TreeDumperNode[]{ Visit(node.DefaultLabel, null) }),
            new TreeDumperNode("breakLabel", node.BreakLabel, null),
            new TreeDumperNode("binder", node.Binder, null),
            new TreeDumperNode("isComplete", node.IsComplete, null)
        });
      }
      public override TreeDumperNode VisitPatternSwitchSection(BoundPatternSwitchSection node, Object arg)
      {
        return new TreeDumperNode("patternSwitchSection", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("switchLabels", null, from x in node.SwitchLabels select Visit(x, null)),
            new TreeDumperNode("statements", null, from x in node.Statements select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitPatternSwitchLabel(BoundPatternSwitchLabel node, Object arg)
      {
        return new TreeDumperNode("patternSwitchLabel", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null),
            new TreeDumperNode("pattern", null, new TreeDumperNode[]{ Visit(node.Pattern, null) }),
            new TreeDumperNode("guard", null, new TreeDumperNode[]{ Visit(node.Guard, null) }),
            new TreeDumperNode("isReachable", node.IsReachable, null)
        });
      }
      public override TreeDumperNode VisitIfStatement(BoundIfStatement node, Object arg)
      {
        return new TreeDumperNode("ifStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("condition", null, new TreeDumperNode[]{ Visit(node.Condition, null) }),
            new TreeDumperNode("consequence", null, new TreeDumperNode[]{ Visit(node.Consequence, null) }),
            new TreeDumperNode("alternativeOpt", null, new TreeDumperNode[]{ Visit(node.AlternativeOpt, null) })
        });
      }
      public override TreeDumperNode VisitDoStatement(BoundDoStatement node, Object arg)
      {
        return new TreeDumperNode("doStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("condition", null, new TreeDumperNode[]{ Visit(node.Condition, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) }),
            new TreeDumperNode("breakLabel", node.BreakLabel, null),
            new TreeDumperNode("continueLabel", node.ContinueLabel, null)
        });
      }
      public override TreeDumperNode VisitWhileStatement(BoundWhileStatement node, Object arg)
      {
        return new TreeDumperNode("whileStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("condition", null, new TreeDumperNode[]{ Visit(node.Condition, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) }),
            new TreeDumperNode("breakLabel", node.BreakLabel, null),
            new TreeDumperNode("continueLabel", node.ContinueLabel, null)
        });
      }
      public override TreeDumperNode VisitForStatement(BoundForStatement node, Object arg)
      {
        return new TreeDumperNode("forStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("outerLocals", node.OuterLocals, null),
            new TreeDumperNode("initializer", null, new TreeDumperNode[]{ Visit(node.Initializer, null) }),
            new TreeDumperNode("innerLocals", node.InnerLocals, null),
            new TreeDumperNode("condition", null, new TreeDumperNode[]{ Visit(node.Condition, null) }),
            new TreeDumperNode("increment", null, new TreeDumperNode[]{ Visit(node.Increment, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) }),
            new TreeDumperNode("breakLabel", node.BreakLabel, null),
            new TreeDumperNode("continueLabel", node.ContinueLabel, null)
        });
      }
      public override TreeDumperNode VisitForEachStatement(BoundForEachStatement node, Object arg)
      {
        return new TreeDumperNode("forEachStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("enumeratorInfoOpt", node.EnumeratorInfoOpt, null),
            new TreeDumperNode("elementConversion", node.ElementConversion, null),
            new TreeDumperNode("iterationVariableType", null, new TreeDumperNode[]{ Visit(node.IterationVariableType, null) }),
            new TreeDumperNode("iterationVariables", node.IterationVariables, null),
            new TreeDumperNode("iterationErrorExpressionOpt", null, new TreeDumperNode[]{ Visit(node.IterationErrorExpressionOpt, null) }),
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("deconstructionOpt", null, new TreeDumperNode[]{ Visit(node.DeconstructionOpt, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) }),
            new TreeDumperNode("@checked", node.Checked, null),
            new TreeDumperNode("breakLabel", node.BreakLabel, null),
            new TreeDumperNode("continueLabel", node.ContinueLabel, null)
        });
      }
      public override TreeDumperNode VisitForEachDeconstructStep(BoundForEachDeconstructStep node, Object arg)
      {
        return new TreeDumperNode("forEachDeconstructStep", null, new TreeDumperNode[]{
            new TreeDumperNode("deconstructionAssignment", null, new TreeDumperNode[]{ Visit(node.DeconstructionAssignment, null) }),
            new TreeDumperNode("targetPlaceholder", null, new TreeDumperNode[]{ Visit(node.TargetPlaceholder, null) })
        });
      }
      public override TreeDumperNode VisitUsingStatement(BoundUsingStatement node, Object arg)
      {
        return new TreeDumperNode("usingStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("declarationsOpt", null, new TreeDumperNode[]{ Visit(node.DeclarationsOpt, null) }),
            new TreeDumperNode("expressionOpt", null, new TreeDumperNode[]{ Visit(node.ExpressionOpt, null) }),
            new TreeDumperNode("iDisposableConversion", node.IDisposableConversion, null),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) })
        });
      }
      public override TreeDumperNode VisitFixedStatement(BoundFixedStatement node, Object arg)
      {
        return new TreeDumperNode("fixedStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("declarations", null, new TreeDumperNode[]{ Visit(node.Declarations, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) })
        });
      }
      public override TreeDumperNode VisitLockStatement(BoundLockStatement node, Object arg)
      {
        return new TreeDumperNode("lockStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("argument", null, new TreeDumperNode[]{ Visit(node.Argument, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) })
        });
      }
      public override TreeDumperNode VisitTryStatement(BoundTryStatement node, Object arg)
      {
        return new TreeDumperNode("tryStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("tryBlock", null, new TreeDumperNode[]{ Visit(node.TryBlock, null) }),
            new TreeDumperNode("catchBlocks", null, from x in node.CatchBlocks select Visit(x, null)),
            new TreeDumperNode("finallyBlockOpt", null, new TreeDumperNode[]{ Visit(node.FinallyBlockOpt, null) }),
            new TreeDumperNode("preferFaultHandler", node.PreferFaultHandler, null)
        });
      }
      public override TreeDumperNode VisitCatchBlock(BoundCatchBlock node, Object arg)
      {
        return new TreeDumperNode("catchBlock", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("exceptionSourceOpt", null, new TreeDumperNode[]{ Visit(node.ExceptionSourceOpt, null) }),
            new TreeDumperNode("exceptionTypeOpt", node.ExceptionTypeOpt, null),
            new TreeDumperNode("exceptionFilterOpt", null, new TreeDumperNode[]{ Visit(node.ExceptionFilterOpt, null) }),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) }),
            new TreeDumperNode("isSynthesizedAsyncCatchAll", node.IsSynthesizedAsyncCatchAll, null)
        });
      }
      public override TreeDumperNode VisitLiteral(BoundLiteral node, Object arg)
      {
        return new TreeDumperNode("literal", null, new TreeDumperNode[]{
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitThisReference(BoundThisReference node, Object arg)
      {
        return new TreeDumperNode("thisReference", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPreviousSubmissionReference(BoundPreviousSubmissionReference node, Object arg)
      {
        return new TreeDumperNode("previousSubmissionReference", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitHostObjectMemberReference(BoundHostObjectMemberReference node, Object arg)
      {
        return new TreeDumperNode("hostObjectMemberReference", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitBaseReference(BoundBaseReference node, Object arg)
      {
        return new TreeDumperNode("baseReference", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitLocal(BoundLocal node, Object arg)
      {
        return new TreeDumperNode("local", null, new TreeDumperNode[]{
            new TreeDumperNode("localSymbol", node.LocalSymbol, null),
            new TreeDumperNode("isDeclaration", node.IsDeclaration, null),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPseudoVariable(BoundPseudoVariable node, Object arg)
      {
        return new TreeDumperNode("pseudoVariable", null, new TreeDumperNode[]{
            new TreeDumperNode("localSymbol", node.LocalSymbol, null),
            new TreeDumperNode("emitExpressions", node.EmitExpressions, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitRangeVariable(BoundRangeVariable node, Object arg)
      {
        return new TreeDumperNode("rangeVariable", null, new TreeDumperNode[]{
            new TreeDumperNode("rangeVariableSymbol", node.RangeVariableSymbol, null),
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitParameter(BoundParameter node, Object arg)
      {
        return new TreeDumperNode("parameter", null, new TreeDumperNode[]{
            new TreeDumperNode("parameterSymbol", node.ParameterSymbol, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitLabelStatement(BoundLabelStatement node, Object arg)
      {
        return new TreeDumperNode("labelStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null)
        });
      }
      public override TreeDumperNode VisitGotoStatement(BoundGotoStatement node, Object arg)
      {
        return new TreeDumperNode("gotoStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null),
            new TreeDumperNode("caseExpressionOpt", null, new TreeDumperNode[]{ Visit(node.CaseExpressionOpt, null) }),
            new TreeDumperNode("labelExpressionOpt", null, new TreeDumperNode[]{ Visit(node.LabelExpressionOpt, null) })
        });
      }
      public override TreeDumperNode VisitLabeledStatement(BoundLabeledStatement node, Object arg)
      {
        return new TreeDumperNode("labeledStatement", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) })
        });
      }
      public override TreeDumperNode VisitLabel(BoundLabel node, Object arg)
      {
        return new TreeDumperNode("label", null, new TreeDumperNode[]{
            new TreeDumperNode("label", node.Label, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitStatementList(BoundStatementList node, Object arg)
      {
        return new TreeDumperNode("statementList", null, new TreeDumperNode[]{
            new TreeDumperNode("statements", null, from x in node.Statements select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitConditionalGoto(BoundConditionalGoto node, Object arg)
      {
        return new TreeDumperNode("conditionalGoto", null, new TreeDumperNode[]{
            new TreeDumperNode("condition", null, new TreeDumperNode[]{ Visit(node.Condition, null) }),
            new TreeDumperNode("jumpIfTrue", node.JumpIfTrue, null),
            new TreeDumperNode("label", node.Label, null)
        });
      }
      public override TreeDumperNode VisitDynamicMemberAccess(BoundDynamicMemberAccess node, Object arg)
      {
        return new TreeDumperNode("dynamicMemberAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiver", null, new TreeDumperNode[]{ Visit(node.Receiver, null) }),
            new TreeDumperNode("typeArgumentsOpt", node.TypeArgumentsOpt, null),
            new TreeDumperNode("name", node.Name, null),
            new TreeDumperNode("invoked", node.Invoked, null),
            new TreeDumperNode("indexed", node.Indexed, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDynamicInvocation(BoundDynamicInvocation node, Object arg)
      {
        return new TreeDumperNode("dynamicInvocation", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("applicableMethods", node.ApplicableMethods, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitConditionalAccess(BoundConditionalAccess node, Object arg)
      {
        return new TreeDumperNode("conditionalAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiver", null, new TreeDumperNode[]{ Visit(node.Receiver, null) }),
            new TreeDumperNode("accessExpression", null, new TreeDumperNode[]{ Visit(node.AccessExpression, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitLoweredConditionalAccess(BoundLoweredConditionalAccess node, Object arg)
      {
        return new TreeDumperNode("loweredConditionalAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiver", null, new TreeDumperNode[]{ Visit(node.Receiver, null) }),
            new TreeDumperNode("hasValueMethodOpt", node.HasValueMethodOpt, null),
            new TreeDumperNode("whenNotNull", null, new TreeDumperNode[]{ Visit(node.WhenNotNull, null) }),
            new TreeDumperNode("whenNullOpt", null, new TreeDumperNode[]{ Visit(node.WhenNullOpt, null) }),
            new TreeDumperNode("id", node.Id, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitConditionalReceiver(BoundConditionalReceiver node, Object arg)
      {
        return new TreeDumperNode("conditionalReceiver", null, new TreeDumperNode[]{
            new TreeDumperNode("id", node.Id, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitComplexConditionalReceiver(BoundComplexConditionalReceiver node, Object arg)
      {
        return new TreeDumperNode("complexConditionalReceiver", null, new TreeDumperNode[]{
            new TreeDumperNode("valueTypeReceiver", null, new TreeDumperNode[]{ Visit(node.ValueTypeReceiver, null) }),
            new TreeDumperNode("referenceTypeReceiver", null, new TreeDumperNode[]{ Visit(node.ReferenceTypeReceiver, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitMethodGroup(BoundMethodGroup node, Object arg)
      {
        return new TreeDumperNode("methodGroup", null, new TreeDumperNode[]{
            new TreeDumperNode("typeArgumentsOpt", node.TypeArgumentsOpt, null),
            new TreeDumperNode("name", node.Name, null),
            new TreeDumperNode("methods", node.Methods, null),
            new TreeDumperNode("lookupSymbolOpt", node.LookupSymbolOpt, null),
            new TreeDumperNode("lookupError", node.LookupError, null),
            new TreeDumperNode("flags", node.Flags, null),
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPropertyGroup(BoundPropertyGroup node, Object arg)
      {
        return new TreeDumperNode("propertyGroup", null, new TreeDumperNode[]{
            new TreeDumperNode("properties", node.Properties, null),
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitCall(BoundCall node, Object arg)
      {
        return new TreeDumperNode("call", null, new TreeDumperNode[]{
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("method", node.Method, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("isDelegateCall", node.IsDelegateCall, null),
            new TreeDumperNode("expanded", node.Expanded, null),
            new TreeDumperNode("invokedAsExtensionMethod", node.InvokedAsExtensionMethod, null),
            new TreeDumperNode("argsToParamsOpt", node.ArgsToParamsOpt, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("binderOpt", node.BinderOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitEventAssignmentOperator(BoundEventAssignmentOperator node, Object arg)
      {
        return new TreeDumperNode("eventAssignmentOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("@event", node.Event, null),
            new TreeDumperNode("isAddition", node.IsAddition, null),
            new TreeDumperNode("isDynamic", node.IsDynamic, null),
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("argument", null, new TreeDumperNode[]{ Visit(node.Argument, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAttribute(BoundAttribute node, Object arg)
      {
        return new TreeDumperNode("attribute", null, new TreeDumperNode[]{
            new TreeDumperNode("constructor", node.Constructor, null),
            new TreeDumperNode("constructorArguments", null, from x in node.ConstructorArguments select Visit(x, null)),
            new TreeDumperNode("constructorArgumentNamesOpt", node.ConstructorArgumentNamesOpt, null),
            new TreeDumperNode("namedArguments", null, from x in node.NamedArguments select Visit(x, null)),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitObjectCreationExpression(BoundObjectCreationExpression node, Object arg)
      {
        return new TreeDumperNode("objectCreationExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("constructor", node.Constructor, null),
            new TreeDumperNode("constructorsGroup", node.ConstructorsGroup, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("expanded", node.Expanded, null),
            new TreeDumperNode("argsToParamsOpt", node.ArgsToParamsOpt, null),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("initializerExpressionOpt", null, new TreeDumperNode[]{ Visit(node.InitializerExpressionOpt, null) }),
            new TreeDumperNode("binderOpt", node.BinderOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitTupleLiteral(BoundTupleLiteral node, Object arg)
      {
        return new TreeDumperNode("tupleLiteral", null, new TreeDumperNode[]{
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("inferredNamesOpt", node.InferredNamesOpt, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitConvertedTupleLiteral(BoundConvertedTupleLiteral node, Object arg)
      {
        return new TreeDumperNode("convertedTupleLiteral", null, new TreeDumperNode[]{
            new TreeDumperNode("naturalTypeOpt", node.NaturalTypeOpt, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDynamicObjectCreationExpression(BoundDynamicObjectCreationExpression node, Object arg)
      {
        return new TreeDumperNode("dynamicObjectCreationExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("name", node.Name, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("initializerExpressionOpt", null, new TreeDumperNode[]{ Visit(node.InitializerExpressionOpt, null) }),
            new TreeDumperNode("applicableMethods", node.ApplicableMethods, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitNoPiaObjectCreationExpression(BoundNoPiaObjectCreationExpression node, Object arg)
      {
        return new TreeDumperNode("noPiaObjectCreationExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("guidString", node.GuidString, null),
            new TreeDumperNode("initializerExpressionOpt", null, new TreeDumperNode[]{ Visit(node.InitializerExpressionOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitObjectInitializerExpression(BoundObjectInitializerExpression node, Object arg)
      {
        return new TreeDumperNode("objectInitializerExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("initializers", null, from x in node.Initializers select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitObjectInitializerMember(BoundObjectInitializerMember node, Object arg)
      {
        return new TreeDumperNode("objectInitializerMember", null, new TreeDumperNode[]{
            new TreeDumperNode("memberSymbol", node.MemberSymbol, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("expanded", node.Expanded, null),
            new TreeDumperNode("argsToParamsOpt", node.ArgsToParamsOpt, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("receiverType", node.ReceiverType, null),
            new TreeDumperNode("binderOpt", node.BinderOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDynamicObjectInitializerMember(BoundDynamicObjectInitializerMember node, Object arg)
      {
        return new TreeDumperNode("dynamicObjectInitializerMember", null, new TreeDumperNode[]{
            new TreeDumperNode("memberName", node.MemberName, null),
            new TreeDumperNode("receiverType", node.ReceiverType, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitCollectionInitializerExpression(BoundCollectionInitializerExpression node, Object arg)
      {
        return new TreeDumperNode("collectionInitializerExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("initializers", null, from x in node.Initializers select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitCollectionElementInitializer(BoundCollectionElementInitializer node, Object arg)
      {
        return new TreeDumperNode("collectionElementInitializer", null, new TreeDumperNode[]{
            new TreeDumperNode("addMethod", node.AddMethod, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("implicitReceiverOpt", null, new TreeDumperNode[]{ Visit(node.ImplicitReceiverOpt, null) }),
            new TreeDumperNode("expanded", node.Expanded, null),
            new TreeDumperNode("argsToParamsOpt", node.ArgsToParamsOpt, null),
            new TreeDumperNode("invokedAsExtensionMethod", node.InvokedAsExtensionMethod, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("binderOpt", node.BinderOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDynamicCollectionElementInitializer(BoundDynamicCollectionElementInitializer node, Object arg)
      {
        return new TreeDumperNode("dynamicCollectionElementInitializer", null, new TreeDumperNode[]{
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("implicitReceiver", null, new TreeDumperNode[]{ Visit(node.ImplicitReceiver, null) }),
            new TreeDumperNode("applicableMethods", node.ApplicableMethods, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitImplicitReceiver(BoundImplicitReceiver node, Object arg)
      {
        return new TreeDumperNode("implicitReceiver", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAnonymousObjectCreationExpression(BoundAnonymousObjectCreationExpression node, Object arg)
      {
        return new TreeDumperNode("anonymousObjectCreationExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("constructor", node.Constructor, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("declarations", null, from x in node.Declarations select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitAnonymousPropertyDeclaration(BoundAnonymousPropertyDeclaration node, Object arg)
      {
        return new TreeDumperNode("anonymousPropertyDeclaration", null, new TreeDumperNode[]{
            new TreeDumperNode("property", node.Property, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitNewT(BoundNewT node, Object arg)
      {
        return new TreeDumperNode("newT", null, new TreeDumperNode[]{
            new TreeDumperNode("initializerExpressionOpt", null, new TreeDumperNode[]{ Visit(node.InitializerExpressionOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDelegateCreationExpression(BoundDelegateCreationExpression node, Object arg)
      {
        return new TreeDumperNode("delegateCreationExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("argument", null, new TreeDumperNode[]{ Visit(node.Argument, null) }),
            new TreeDumperNode("methodOpt", node.MethodOpt, null),
            new TreeDumperNode("isExtensionMethod", node.IsExtensionMethod, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitArrayCreation(BoundArrayCreation node, Object arg)
      {
        return new TreeDumperNode("arrayCreation", null, new TreeDumperNode[]{
            new TreeDumperNode("bounds", null, from x in node.Bounds select Visit(x, null)),
            new TreeDumperNode("initializerOpt", null, new TreeDumperNode[]{ Visit(node.InitializerOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitArrayInitialization(BoundArrayInitialization node, Object arg)
      {
        return new TreeDumperNode("arrayInitialization", null, new TreeDumperNode[]{
            new TreeDumperNode("initializers", null, from x in node.Initializers select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitStackAllocArrayCreation(BoundStackAllocArrayCreation node, Object arg)
      {
        return new TreeDumperNode("stackAllocArrayCreation", null, new TreeDumperNode[]{
            new TreeDumperNode("elementType", node.ElementType, null),
            new TreeDumperNode("count", null, new TreeDumperNode[]{ Visit(node.Count, null) }),
            new TreeDumperNode("initializerOpt", null, new TreeDumperNode[]{ Visit(node.InitializerOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitConvertedStackAllocExpression(BoundConvertedStackAllocExpression node, Object arg)
      {
        return new TreeDumperNode("convertedStackAllocExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("elementType", node.ElementType, null),
            new TreeDumperNode("count", null, new TreeDumperNode[]{ Visit(node.Count, null) }),
            new TreeDumperNode("initializerOpt", null, new TreeDumperNode[]{ Visit(node.InitializerOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitFieldAccess(BoundFieldAccess node, Object arg)
      {
        return new TreeDumperNode("fieldAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("fieldSymbol", node.FieldSymbol, null),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("isByValue", node.IsByValue, null),
            new TreeDumperNode("isDeclaration", node.IsDeclaration, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitHoistedFieldAccess(BoundHoistedFieldAccess node, Object arg)
      {
        return new TreeDumperNode("hoistedFieldAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("fieldSymbol", node.FieldSymbol, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitPropertyAccess(BoundPropertyAccess node, Object arg)
      {
        return new TreeDumperNode("propertyAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("propertySymbol", node.PropertySymbol, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitEventAccess(BoundEventAccess node, Object arg)
      {
        return new TreeDumperNode("eventAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("eventSymbol", node.EventSymbol, null),
            new TreeDumperNode("isUsableAsField", node.IsUsableAsField, null),
            new TreeDumperNode("resultKind", node.ResultKind, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitIndexerAccess(BoundIndexerAccess node, Object arg)
      {
        return new TreeDumperNode("indexerAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("indexer", node.Indexer, null),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("expanded", node.Expanded, null),
            new TreeDumperNode("argsToParamsOpt", node.ArgsToParamsOpt, null),
            new TreeDumperNode("binderOpt", node.BinderOpt, null),
            new TreeDumperNode("useSetterForDefaultArgumentGeneration", node.UseSetterForDefaultArgumentGeneration, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDynamicIndexerAccess(BoundDynamicIndexerAccess node, Object arg)
      {
        return new TreeDumperNode("dynamicIndexerAccess", null, new TreeDumperNode[]{
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("arguments", null, from x in node.Arguments select Visit(x, null)),
            new TreeDumperNode("argumentNamesOpt", node.ArgumentNamesOpt, null),
            new TreeDumperNode("argumentRefKindsOpt", node.ArgumentRefKindsOpt, null),
            new TreeDumperNode("applicableIndexers", node.ApplicableIndexers, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitLambda(BoundLambda node, Object arg)
      {
        return new TreeDumperNode("lambda", null, new TreeDumperNode[]{
            new TreeDumperNode("symbol", node.Symbol, null),
            new TreeDumperNode("body", null, new TreeDumperNode[]{ Visit(node.Body, null) }),
            new TreeDumperNode("diagnostics", node.Diagnostics, null),
            new TreeDumperNode("binder", node.Binder, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitUnboundLambda(UnboundLambda node, Object arg)
      {
        return new TreeDumperNode("unboundLambda", null, new TreeDumperNode[]{
            new TreeDumperNode("data", node.Data, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitQueryClause(BoundQueryClause node, Object arg)
      {
        return new TreeDumperNode("queryClause", null, new TreeDumperNode[]{
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) }),
            new TreeDumperNode("definedSymbol", node.DefinedSymbol, null),
            new TreeDumperNode("binder", node.Binder, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitTypeOrInstanceInitializers(BoundTypeOrInstanceInitializers node, Object arg)
      {
        return new TreeDumperNode("typeOrInstanceInitializers", null, new TreeDumperNode[]{
            new TreeDumperNode("statements", null, from x in node.Statements select Visit(x, null))
        });
      }
      public override TreeDumperNode VisitNameOfOperator(BoundNameOfOperator node, Object arg)
      {
        return new TreeDumperNode("nameOfOperator", null, new TreeDumperNode[]{
            new TreeDumperNode("argument", null, new TreeDumperNode[]{ Visit(node.Argument, null) }),
            new TreeDumperNode("constantValueOpt", node.ConstantValueOpt, null),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitInterpolatedString(BoundInterpolatedString node, Object arg)
      {
        return new TreeDumperNode("interpolatedString", null, new TreeDumperNode[]{
            new TreeDumperNode("parts", null, from x in node.Parts select Visit(x, null)),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitStringInsert(BoundStringInsert node, Object arg)
      {
        return new TreeDumperNode("stringInsert", null, new TreeDumperNode[]{
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) }),
            new TreeDumperNode("alignment", null, new TreeDumperNode[]{ Visit(node.Alignment, null) }),
            new TreeDumperNode("format", null, new TreeDumperNode[]{ Visit(node.Format, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitIsPatternExpression(BoundIsPatternExpression node, Object arg)
      {
        return new TreeDumperNode("isPatternExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("pattern", null, new TreeDumperNode[]{ Visit(node.Pattern, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDeclarationPattern(BoundDeclarationPattern node, Object arg)
      {
        return new TreeDumperNode("declarationPattern", null, new TreeDumperNode[]{
            new TreeDumperNode("variable", node.Variable, null),
            new TreeDumperNode("variableAccess", null, new TreeDumperNode[]{ Visit(node.VariableAccess, null) }),
            new TreeDumperNode("declaredType", null, new TreeDumperNode[]{ Visit(node.DeclaredType, null) }),
            new TreeDumperNode("isVar", node.IsVar, null)
        });
      }
      public override TreeDumperNode VisitConstantPattern(BoundConstantPattern node, Object arg)
      {
        return new TreeDumperNode("constantPattern", null, new TreeDumperNode[]{
            new TreeDumperNode("value", null, new TreeDumperNode[]{ Visit(node.Value, null) }),
            new TreeDumperNode("constantValue", node.ConstantValue, null)
        });
      }
      public override TreeDumperNode VisitWildcardPattern(BoundWildcardPattern node, Object arg)
      {
        return new TreeDumperNode("wildcardPattern", null, Array.Empty<TreeDumperNode>());
      }
      public override TreeDumperNode VisitDiscardExpression(BoundDiscardExpression node, Object arg)
      {
        return new TreeDumperNode("discardExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitThrowExpression(BoundThrowExpression node, Object arg)
      {
        return new TreeDumperNode("throwExpression", null, new TreeDumperNode[]{
            new TreeDumperNode("expression", null, new TreeDumperNode[]{ Visit(node.Expression, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitOutVariablePendingInference(OutVariablePendingInference node, Object arg)
      {
        return new TreeDumperNode("outVariablePendingInference", null, new TreeDumperNode[]{
            new TreeDumperNode("variableSymbol", node.VariableSymbol, null),
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitDeconstructionVariablePendingInference(DeconstructionVariablePendingInference node, Object arg)
      {
        return new TreeDumperNode("deconstructionVariablePendingInference", null, new TreeDumperNode[]{
            new TreeDumperNode("variableSymbol", node.VariableSymbol, null),
            new TreeDumperNode("receiverOpt", null, new TreeDumperNode[]{ Visit(node.ReceiverOpt, null) }),
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitOutDeconstructVarPendingInference(OutDeconstructVarPendingInference node, Object arg)
      {
        return new TreeDumperNode("outDeconstructVarPendingInference", null, new TreeDumperNode[]{
            new TreeDumperNode("type", node.Type, null)
        });
      }
      public override TreeDumperNode VisitNonConstructorMethodBody(BoundNonConstructorMethodBody node, Object arg)
      {
        return new TreeDumperNode("nonConstructorMethodBody", null, new TreeDumperNode[]{
            new TreeDumperNode("blockBody", null, new TreeDumperNode[]{ Visit(node.BlockBody, null) }),
            new TreeDumperNode("expressionBody", null, new TreeDumperNode[]{ Visit(node.ExpressionBody, null) })
        });
      }
      public override TreeDumperNode VisitConstructorMethodBody(BoundConstructorMethodBody node, Object arg)
      {
        return new TreeDumperNode("constructorMethodBody", null, new TreeDumperNode[]{
            new TreeDumperNode("locals", node.Locals, null),
            new TreeDumperNode("initializer", null, new TreeDumperNode[]{ Visit(node.Initializer, null) }),
            new TreeDumperNode("blockBody", null, new TreeDumperNode[]{ Visit(node.BlockBody, null) }),
            new TreeDumperNode("expressionBody", null, new TreeDumperNode[]{ Visit(node.ExpressionBody, null) })
        });
      }
    }
}