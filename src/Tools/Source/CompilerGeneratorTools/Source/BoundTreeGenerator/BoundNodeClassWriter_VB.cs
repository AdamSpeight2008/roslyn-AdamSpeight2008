// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using static Roslyn.Compilers.Internal.BoundTreeGenerator.Exts; 

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    public sealed class VBLangSpecific : LangSpecific
    {
        internal VBLangSpecific(): base() { }

        #region "language specific"
        public override string @internal()  => "Friend";
        public override string @overrides() => "Overrides";
        public override string Namespace()  => "Namespace";
        public override string Class()      => "Class";
        public override string Enum()       => "Enum";
        public override string Friend()     => "Friend";
        public override string Partial()    => "Partial";
        public override string Abstract()   => "MustInherit";
        public override string Sealed()     => "NotInheritable";
        public string Sub()                 => "Sub";
        public string Function()            => "Function";
        private string End()                => "End";
        public override string @public()    => "Public";
        public override string @private()   => "Private";
        public override string @protected() => "Protected";
        public override string @optional()  => "Optional";
        public override string @false()     => "False";
        public override string @bool()      => "Boolean";
        public override string @shadows()   => "Shadows";
        private string Overridable()        => "Overridable";
        public override string Imports()    => "Imports";
        public override string Inherits()   => "Inherits ";
        public override string OrElse()     => "OrElse";
        public override string AndAlso()    => "AndAlso";
        public override string @_nameof_()  => "NameOf";
        public override string @return()    => "Return";
        public override string @shared()    => "Shared";
        public override string @this()      => "Me";
        public override string @case()      => "Case";
        public override string @if()        => "If";
        public override string @then()      => "Then";
        public override string @New()       => "New";
        public override string @null()      => "Nothing";
        public override string @byte()      => "System.Byte";
        public override string @from()      => "From";
        public override string @In()        => "In";
        public override string @Select()    => "Select";
        public override string Decl()       => "Dim";
        public override string @override()    => "Override";
        public override string @overridable() => "Overridable";
        public override string EnumBase(string baseType) => AsType(baseType);
        public override string AsType(string typename, bool isNew = false) => (typename == null) ? "" : $"As {(isNew ? @New() + " " : "")}{typename}";
        public override Func<string> MyBaseNew() => ()=>"MyBase.New";
        public override string Attribute(string attribute) => $"<{attribute}>";
        public override string CommentMarker() => "'";
        public override string NameAsType(string name, string typename, bool isNew = false) => $"{name.ToCamelCase(this)} {AsType(typename, isNew)}";
        public override string EscapeKeyword(string name) => $"[{name}]";
        public override string Generics(string genericParams) => $"(Of {genericParams})";
        public override string Inherits(string inheritsFrom) => $" : {Inherits()}{inheritsFrom}";
        public override string InsideNamespace() => "Microsoft.CodeAnalysis.VisualBasic";
        public override IEnumerable<string> ImportedNamespaces()
        {
            yield return "Microsoft.CodeAnalysis.Text";
            yield return "Microsoft.CodeAnalysis.VisualBasic.Symbols";
            yield return "Microsoft.CodeAnalysis.VisualBasic.Syntax";
        }
        #endregion

        private string End_(string text)    => $"{End()} {text}";
        private string End_Class            => End_(Class());
        public string End_Select            => End_(Select());
        public string End_Sub               => End_(Sub());
        public string End_Function          => End_(Function());
        public override string End_Namespace=> End_(Namespace());
        public override string End_Enum     => End_(Enum());

        public override void WriteClass(
            IndentedWriter iw,
            string modifiers,
            string classname,
            string genericParams = null,
            string inherits = null,
            Action body = null)
            =>  base.WriteClass(iw,modifiers, classname, genericParams, inherits, body.Indented(iw),End_Class.Output(_iw,true));

        private static HashSet<string> s_keywords =
            new HashSet<string>(
                new string[] {
                    "addhandler", "addressof", "alias", "and", "andalso", "as",
                    "boolean", "byref", "byte", "byval",
                    "call", "case", "catch", "cbool", "cbyte", "cchar", "cdate", "cdbl", "cdec", "char", "cint", "class", "clng", "cobj", "const", "continue",
                    "csbyte", "cshort", "csng", "cstr", "ctype", "cuint", "culng", "cushort",
                    "date", "decimal", "declare", "default", "delegate", "dim", "directcast", "do", "double",
                    "each", "else", "elseif", "end", "endif", "enum", "erase", "error", "event", "exit",
                    "false", "finally", "for", "friend", "function",
                    "get", "gettype", "getxmlnamespace", "global", "gosub", "goTo",
                    "handles",
                    "if", "implements", "imports", "in", "inherits", "integer", "interface", "is", "isnot",
                    "let", "lib", "like", "long", "loop",
                    "me", "mod", "module", "mustinherit", "mustoverride", "mybase", "myclass",
                    "namespace", "narrowing", "new", "next", "not", "nothing", "notinheritable", "notoverridable",
                    "object", "of", "on", "operator", "option", "optional", "or", "orelse", "overloads", "overridable", "overrides",
                    "paramArray", "partial", "private", "property", "protected", "public",
                    "raiseevent", "readonly", "redim", "rem", "removehandler", "resume", "return",
                    "sbyte", "select", "set", "shadows", "shared", "short", "single", "static", "step", "stop", "string", "structure", "sub", "synclock",
                    "then", "throw", "to", "true", "try", "trycast", "typeof",
                    "uinteger", "ulong", "ushort", "using",
                    "variant", "wend", "when", "while", "widening", "with", "withevents", "writeonly",
                    "xor" }
                );
        public override bool IsKeyword(string name) => s_keywords.Contains(name.ToLower());
    }

    internal sealed class BoundNodeClassWriter_VB : BoundNodeClassWriter
    {
        internal BoundNodeClassWriter_VB(TextWriter writer, Tree tree)
            : base(tree, TargetLanguage.VB, new IndentedWriter(levelSize: 2,writer), new VBLangSpecific()) { }

        private Action MethodHeader(string modifiers, string methodKind, string methodName, string[] parameters, string returns)
            => () =>
            {
                if (modifiers != null) Write_Modifier(modifiers);
                $"{ methodKind} {methodName}".Output(_o)();
                ParenList(parameters).Output(_o)();
                if (returns != null) $" {Lang.AsType(returns)}".Output(_o)();
            };

        protected override void F(string modifiers, string methodName, string[] parameters, string returns, Action basecall = null, Action body = null) =>
          Exts.WithBody(MethodHeader(modifiers, ((VBLangSpecific)Lang).Function(), methodName, parameters, returns), body.Indented(_o,true,true),
                    ((VBLangSpecific)Lang).End_Function.Output(_o,true))();

        protected override void S(string modifier, string name, string[] parameters, Action body)
            => MethodHeader( modifier,((VBLangSpecific)Lang).Sub(), name, parameters, null).WithBody( body.Indented(_o,true,false),
                     ((VBLangSpecific)Lang).End_Sub.Output(_o, true))();

         private void WriteArgumentsToMethod(string head, string prefix, IEnumerable<Field> fx, TreeType node, string postfix, string foot = null)
        {
            head.Output(_o)();
            fx.ForAll(null,
                (baseField, __) =>
                {
                    var value = FieldNullHandling(node, baseField.Name) == NullHandling.Always ? Lang.@null() : baseField.Name.ToCamelCase(Lang);
                    prefix?.Output(_o)();
                    value?.Output(_o)();
                    postfix?.Output(_o)();
                })();
        }

        protected override void InitializeValueTypes(ref Dictionary<string, bool> _valueTypes)
        {
            _valueTypes.Add("Boolean", true);
            _valueTypes.Add("Integer", true);
            _valueTypes.Add("UInteger", true);
            _valueTypes.Add("Short", true);
            _valueTypes.Add("UShort", true);
            _valueTypes.Add("Long", true);
            _valueTypes.Add("ULong", true);
            _valueTypes.Add("Byte", true);
            _valueTypes.Add("SByte", true);
            _valueTypes.Add("Char", true);
        }

        #region "Write Constructors"
        private void WriteConstructor(TreeType node,
            bool isPublic, bool? hasErrorsIsOptional, Action whenPublic, string whenNonPublic, Action whenHasValidate = null)
        {
            var hasValidate = false;
            // A public constructor does not have an explicit kind parameter.
            S(OutIsPublic(isPublic),
                Lang.@New(), SubNewParameters(node, isPublic, hasErrorsIsOptional),
                () =>
                {
                    Lang.MyBaseNew().Output(_o)();
                    Action src = null;
                    if (isPublic) { src = whenPublic; } else { src =()=> NonPublic(); };
                    InParens(src, true)();
                    WriteNullChecks(node);
                    Fields(node).ForAll(null,(field, eolLast) => AssignmentTo(node, field).Code(_o, true))();

                    hasValidate = HasValidate(node);
                    
                    if (hasValidate) { "Validate()".Code(_o, true); }
                });

            if (hasValidate && whenHasValidate != null) whenHasValidate();

            void NonPublic() => WriteArgumentsToMethod("kind, syntax", ", ", AllSpecifiableFields(BaseType(node)), node, null, whenNonPublic);
        }
               
        protected override void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional)
        {
            WriteConstructor(node, isPublic, hasErrorsIsOptional, ()=>IsPublic(), ", hasErrors", Write_ValidateMethod);

            void Write_ValidateMethod() => S($"{Lang.@private()} {Lang.Partial()}", "Validate", null, NotUsed);

            void IsPublic() // Base call has bound kind, syntax, all fields in base type, plus merged HasErrors.
            {
                WriteArgumentsToMethod($"BoundKind.{node.Name.StripBound()}, syntax, ", null, AllSpecifiableFields(BaseType(node)), node, ", ");
                Or((new[]{"hasErrors"}).Concat(AllNodeOrNodeListFields(node).Select(f=>f.Name.ToCamelCase(Lang) + ".NonNullAndHasErrors()")), x => x).Output(_o)();
            }
        }

        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected override void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic)
        {
            // Base call has bound kind, syntax, fields.
            WriteConstructor(node, isPublic, null, ()=> WriteArgumentsToMethod($"BoundKind.{node.Name.StripBound()}, syntax", ", ", AllSpecifiableFields(BaseType(node)), node, null), null);
        }
        #endregion

        protected override void Write_DebugAssert_Nulls(bool isROArray, Field field, bool eolLast)
        {
            var fieldName = field.Name.ToCamelCase(Lang);
            "Debug.Assert(".Output(_o)();
            if (isROArray) { $"Not {fieldName}.IsDefault".Output(_o)(); } else { $"{fieldName} IsNot {Lang.@null()}".Output(_o)(); }
            $", $\"Field '{Lang._NameOf(fieldName)}' cannot be null (use Null=\"\"allow\"\" in BoundNodes.xml to remove this check)\")".Output(_o,eolLast)();
        }

        protected override void WriteField(Field field, bool eol = true)
        {
            $"{Lang.@public()} ".Output(_o)();
            if (IsNew(field))
                $"{Lang.shadows()} ".Output(_o)();
            else if (IsPropertyOverrides(field))
                $"{Lang.overrides()} ".Output(_o)();
            ReadOnly_Property(field);
            if (eol) _o.EOL();
        }

        protected override void ReadOnly_Property(Field field)
            => $"ReadOnly Property {Lang.NameAsType(field.Name, field.Type)}".Output(_o, true)();

        private Func<string> AssignmentTo(TreeType node, Field field)=>
            () => $"_{field.Name} = {(FieldNullHandling(node, field.Name) == NullHandling.Always ? Lang.@null() : field.Name.ToCamelCase(Lang))}";
 
        protected override void WriteAccept(string name) =>
            F($"{Lang.@public()} {Lang.@overrides()}", "Accept", Parameters(Lang.NameAsType("visitor", "BoundTreeVisitor")), boundNode,null,
              Return($"visitor.Visit{name.StripBound()}({Lang.@this()})",true));

        protected override void WriteVisitor()
        {
            Write_VisitInternal();
            Write_Visit_AsR();
            Write_Vist_AsBoundNode();

            void Write_VisitInternal() =>
                Friend_MustInherit_Partial_Class("BoundTreeVisitor","A,R", null,
                 ()=>
                 {
                     "<MethodImpl(MethodImplOptions.NoInlining)>".Output(_o, true)();
                     F(Lang.Friend(), $"VisitInternal", Parameters(NodeAsBoundNode(), Lang.NameAsType("arg", "A")), "R", null,
                       SelectCase().__(Return($"DefaultVisit({_node}, arg)",false)));
                 });

            Action SelectCase()
                => $"Select Case {_node}.Kind".Output(_o).WithBody(
                       CaseClauses().Indented( _o,true,true), ((VBLangSpecific)Lang).End_Select.Output(_o,true));

            Action CaseClauses()
            {
                var _OfTypes = _tree.Types.OfType<Node>().ToArray();
                var widest = _OfTypes.Max(node => Lang.FixKeyword(node.Name.StripBound()).Length);
                return _OfTypes.ForAll(null, (clause, eolLast) => WriteCaseClauseStatement(clause, widest, eolLast));
            }

            void WriteCaseClauseStatement(Node node, int widest, bool eolLast)
            {
                var stripName = node.Name.StripBound();
                var name = Lang.FixKeyword(stripName);
                $"{Lang.@case()} BoundKind.{name}{new string(' ', widest - name.Length)}: {Lang.@return()} Visit{stripName}(CType({_node}, {node.Name}), arg)".Output(_o, eolLast)();
            }

            void Write_Visit_AsR() =>
                Friend_MustInherit_Partial_Class("BoundTreeVisitor","A,R", null,
                    ApplyToTreeNodes((node, eolLast) => WriteVisitor(node, Parameters(NodeAs(node), Lang.NameAsType("arg", "A")), "R", "node,arg")));

            void Write_Vist_AsBoundNode()=>
                Friend_MustInherit_Partial_Class("BoundTreeVisitor",null, null,
                    ApplyToTreeNodes((node, eolLast) => WriteVisitor(node, Parameters(NodeAs(node)), boundNode, "node")));

            void WriteVisitor(Node node, string[] parameters, string returns, string argument) =>
                F($"{Lang.@public()} {Lang.overridable()}", $"Visit{node.Name.StripBound()}", parameters.ToArray(), returns, null,
                  Return($"{Lang.@this()}.DefaultVisit({argument})", false));

         }

        protected override void CreateConstructor(string name) => S(Lang.@private(), name, null, Exts.NotUsed);


        protected override void WriteTreeDumperNodeProducer() => base.WriteTreeDumperNodeProducer("New",null);

        protected override void WriteRewriter()
        {
            Friend_MustInherit_Partial_Class("BoundTreeRewriter", null,null, ApplyToTreeNodes((node, eolLast) => WriteOverridesVisitFunction(node)));

            void WriteOverridesVisitFunction(Node node)
            {
                var hadField = false;
                F($"{Lang.@public()} {Lang.@overrides()}", Visit(node),Parameters( NodeAs(node)), boundNode, null,
                () =>
                {
                    _o.EOL();
                    var f0 = AllNodeOrNodeListFields(node).ToArray();
                    var m0 = DefaultToZero(f0);
                    var f1 = AllTypeFields(node).ToArray();
                    var m1 = DefaultToZero(f1);
                    var widest = Math.Max(m0, m1)+1;
                    AddAny_NodeNodeListField(f0, widest);
                    AddAny_TypeFields(f1, widest);
                    AddReturnStatement();
                });

                int DefaultToZero(Field[] f) =>  f == null || f.Length == 0 ? 0 : f.Max(x => x.Name.Length);
                
                void AddAny_NodeNodeListField(Field[] fields,int widest)
                {
                    fields.ForAll(null,
                        (field,eolLast) =>
                        {
                            hadField = true;
                            if (SkipInVisitor(field))
                                Declaration("Dim",field.Name, null, $"{_node}.{field.Name}", false, eol: true, width: widest);
                            else if (IsNodeList(field.Type))
                                Declaration("Dim", field.Name, null, $"{Lang.@this()}.VisitList({_node}.{field.Name})", false, eol: true, width: widest);
                            else
                                Declaration("Dim", field.Name, null, $"DirectCast({Lang.@this()}.Visit({_node}.{field.Name}), {field.Type})", false, eol: true, width: widest);
                        })();
                }

                void AddAny_TypeFields(Field[] fields, int widest)
                {
                    fields.ForAll(null, (field, eolLast) =>
                    {
                        hadField = true;
                        Declaration("Dim", field.Name, null, $"{Lang.@this()}.VisitType({_node}.{field.Name})", false, eol: true, width: widest);
                        _o.EOL();
                    })();                   
                }

                void AddReturnStatement()
                {
                    Return(_node,false)();
                    if (!hadField) return;
                    ".Update".Output(_o)();
                    ParenList(AllSpecifiableFields(node).
                        Select(field => IsDerivedOrListOfDerived(boundNode, field.Type) || field.Type == "TypeSymbol" ? field.Name.ToCamelCase(Lang) : $"{_node}.{field.Name}")).Output(_o)();
                }
            }
        }

   
        #region "reqiuires constant _of"
        const string _of = "(Of ";
        protected override bool   IsImmutableArray(string typeName) => typeName.StartsWith($"ImmutableArray{_of}", StringComparison.OrdinalIgnoreCase);
        protected override bool   IsNodeList(string typeName) => typeName.StartsWith($"IList{_of}", StringComparison.OrdinalIgnoreCase) ||
                                                               typeName.StartsWith($"ImmutableArray{_of}", StringComparison.OrdinalIgnoreCase);
        #endregion
        protected override string GetGenericType(string typeName)
        {
            var iStart = typeName.IndexOf(_of, StringComparison.OrdinalIgnoreCase);
            return (iStart == -1) ? typeName : typeName.Substring(0, iStart);
        }

        protected override string GetElementType(string typeName)
        {
            var iStart = typeName.IndexOf(_of, StringComparison.OrdinalIgnoreCase);
            if (iStart == -1) return string.Empty;
            var iEnd = typeName.IndexOf(')', iStart + 3);
            if (iEnd < iStart) return string.Empty;
            return typeName.Substring(iStart + 3, iEnd - iStart - 3).Trim();
        }

    }

}
