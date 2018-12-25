// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Roslyn.Compilers.Internal.BoundTreeGenerator.Exts;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    internal sealed class CSLangSpecific : LangSpecific
    {
        internal CSLangSpecific() : base() { }
        public override Action GetCodeBlockBody(Action body) => body.InBraces(_iw);
        public override string Attribute(string attribute) => $"[{attribute}]";
        public override string EOS => ";";
        #region "Language Specific"
        public override string @internal()      => "internal";
        public override string CommentMarker()  => @"//";
        public override string @optional()      => "";
        public override string @protected()     => "protected";
        public override string @false()         => "false";
        public override string OrElse()         => "||";
        public override string AndAlso()        => "&&";
        public override string Class()          => "class";
        public override string Enum()           => "enum";
        public override string Friend()         => "internal";
        public override string Partial()        => "partial";
        public override string @public()        => "public";
        public override string @bool()          => "bool";
        public override string @_nameof_()      => "nameof";
        public override string @private()       => "private";
        public override string Imports()        => "using";
        public override string Inherits()       => "";
        public override string Inherits(string inheritsFrom) =>$" : {inheritsFrom}";
        public override string Abstract()       => "abstract";
        public override string Sealed()         => "sealed";
        public override string @return()        => "return";
        public override string @overrides()     => "override";
        public override string @shadows()       => "shadows";
        public override string @shared()        => "static";
        public override string @this()          => "this";
        public override string @case()          => "case";
        public override string @if()            => "if";
        public override string @then()          => "";
        public override string @New()           => "new";
        public override string @null()          => "null";
        public override string @byte()          => "byte";
        public override string @from()          => "from";
        public override string @In()            => "in";
        public override string @Select()        => "select";
        public override string Decl() => "var";
        public override Func<string> MyBaseNew() => () => "base.new";

        public override IEnumerable<string> ImportedNamespaces()
        {
            yield return "Microsoft.CodeAnalysis.Text";
            yield return "Microsoft.CodeAnalysis.CSharp.Symbols";
            yield return "Microsoft.CodeAnalysis.CSharp.Syntax";
        }

        public override string Namespace() => "namespace";
        public override string EnumBase(string baseType) => Inherits(baseType);

        public override string Generics(string genericParams) => $"<{genericParams}>";
        public override string InsideNamespace() => "Microsoft.CodeAnalysis.CSharp";

        public override string EscapeKeyword(string name) => "@" + name;

        public override string NameAsType(string name, string typename, bool isNew = false) => $"{typename} {name}";
        public override string EnumStatementEnding => ",";
        public override string @override() => "override";

        #endregion
        private static HashSet<string> Keywords =
            new  HashSet<string>(
                new string[] {
                    "abstract","add",
                    "bool","byte","break","base",
                    "class","char","case","catch","continue","const","checked",
                    "decimal", "double","do","default","delegate",
                    "else","explicit","extern","event","enum",
                    "float","false","for","foreach","finally","fixed",
                    "goto","get",
                    "int","if","internal","in","interface","implicit",
                    "long","lock",
                    "null","new","namespace",
                    "object","override","out","operator",
                    "public","private","protected","partial","params",
                    "return","readonly","ref","remove",
                    "sbyte","short","string","sizeof","switch","static","sealed","struct","set",
                    "typeof","true","try","throw","this",
                    "ushort","uint","ulong","using","unsafe",
                    "while","where",
                    "virtual"});
        public override bool IsKeyword(string name) => Keywords.Contains(name.ToLower());

        public override void WriteClass(IndentedWriter iw, string modifiers, string classname, string genericParams, string inherits, Action body)
            => base.WriteClass( iw, modifiers, classname, genericParams, inherits, body.InBraces(_iw), ()=> _iw.EOL());
        public override string @overridable() => throw new NotImplementedException();
        public override string AsType(string typename, bool isNew = false) => (typename == null) ? "" : $" = {(isNew ? @New() + " " : "")}{typename}";

    }

    internal sealed class BoundNodeClassWriter_CS : BoundNodeClassWriter
    {
        internal BoundNodeClassWriter_CS(TextWriter writer, Tree tree)
            : base(tree, TargetLanguage.CSharp, new IndentedWriter(levelSize: 2, writer), new CSLangSpecific()) { }

        protected override void ReadOnly_Property(Field field) { }

        protected override void InitializeValueTypes(ref Dictionary<string, bool> _valueTypes)
        {
            _valueTypes.Add("bool", true);
            _valueTypes.Add("int", true);
            _valueTypes.Add("uint", true);
            _valueTypes.Add("short", true);
            _valueTypes.Add("ushort", true);
            _valueTypes.Add("long", true);
            _valueTypes.Add("ulong", true);
            _valueTypes.Add("byte", true);
            _valueTypes.Add("sbyte", true);
            _valueTypes.Add("char", true);
            _valueTypes.Add("Boolean", true);
        }

        protected override void F(string modifiers, string methodName, string[] parameters, string returns,Action basecall, Action body)
        {
            Exts.WithBody(pre:
                () => {
                    MethodHeader(modifiers, methodName, parameters, returns, false);
                    if (basecall != null) CallToBase(basecall);
                    _o.EOL();
                },
                Lang.GetCodeBlockBody(body),
                () => _o.EOL())();
        }

        private void CallToBase(Action basecall) => $" : base".Output(_o).__(InParens(basecall))();

        private void Fa(string modifiers, string methodName, string[] parameters, string returns, Action basecall, string statement = null)
        {
            MethodHeader(modifiers, methodName, parameters, returns, false);
            if (basecall != null) CallToBase(basecall);
            if (statement != null) $" => {statement}".Code(_o, true);
        }

         void MethodHeader(string modifiers, string methodName, string[] parameters, string returns, bool startNewLine)
        {
            if (modifiers != null) $"{modifiers}".Output(_o)();
            if (returns != null) $" {returns}".Output(_o)();
            $" {methodName}".Output(_o)();
            ParenList(parameters).Output(_o, startNewLine)();
        }

        protected override void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional)
        {
            // A public constructor does not have an explicit kind parameter.
            F(OutIsPublic(isPublic), node.Name, SubNewParameters(node, isPublic, hasErrorsIsOptional), returns: null,
               basecall: thisBaseCall(),
               body: () =>
               {
                   WriteNullChecks(node);
                   foreach (var field in Fields(node))
                       $"{_o.Lang.@this()}.{(IsPropertyOverrides(field) ? "" : "")}{field.Name} = {HandleField(node, field)}".Code(_o, true);
               });

            Action thisBaseCall()
            {
                var args = "";
                if (isPublic)
                {
                    // Base call has bound kind, syntax, all fields in base type, plus merged HasErrors.
                    args = $"BoundKind.{node.Name.StripBound()}, syntax";
                    args += WriteFields(", ", AllSpecifiableFields(BaseType(node)), node, "");
                    args += Or((new[] { ", hasErrors" }).Concat(AllNodeOrNodeListFields(node).Select(field => field.Name + ".HasErrors()")), x => x.ToCamelCase(Lang))();
                }
                else
                {
                    args = "kind, syntax";
                    // Base call has kind, syntax, and hasErrors. No merging of hasErrors because derived class already did the merge.
                    args += WriteFields(", ", AllSpecifiableFields(BaseType(node)), node, "");
                    args += ", hasErrors";
                }
                return args.Output(_o);
            }
        }

        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected override void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic)
        {
            // A public constructor does not have an explicit kind parameter.
            F(OutIsPublic(isPublic), node.Name, SubNewParameters(node, isPublic), null,
              basecall: CallToBase(),
              body: () =>
              {
                  WriteNullChecks(node);
                  foreach (var field in Fields(node))
                      Assignment($"{Lang.@this()}.{(IsPropertyOverrides(field) ? "" : "")}{field.Name}", $"{HandleField(node, field)}");

              });

            Action CallToBase()
            {
                var args = "";
                if (isPublic)
                {
                    // Base call has bound kind, syntax, fields.
                    args = $"BoundKind.{node.Name.StripBound()}, syntax" + WriteFields(", ", AllSpecifiableFields(BaseType(node)), node, "");
                }
                else
                {
                    // Base call has kind, syntax, fields
                    args = "kind, syntax" + WriteFields(", ", AllSpecifiableFields(BaseType(node)), node, "");
                }
                return args.Output(_o);
            }
        }

        private string HandleField(TreeType node, Field baseField) => FieldNullHandling(node, baseField.Name) == NullHandling.Always ? "null" : baseField.Name.ToCamelCase(this.Lang);

        private string WriteFields(string prefix, IEnumerable<Field> fx, TreeType node, string postfix)
        {
            return string.Join("", fx.Select(baseField => $"{prefix}{HandleField(node, baseField)}{postfix}"));
        }

        protected override void Write_DebugAssert_Nulls(bool isROArray, Field field, bool eolLast)
        {
            "Debug.Assert(".Output(_o)();
            var member = field.Name.ToCamelCase(Lang);
            if (isROArray)
                $"!{member}.IsDefault".Output(_o)();
            else
                $"{member} != null".Output(_o)();
            $", \"Field '{member}' cannot be null (use Null=\\\"allow\\\" in BoundNodes.xml to remove this check)\")".Code(_o, eolLast);
        }

        protected override void WriteField(Field field, bool eol = true) =>
            $"{Lang.@public()} {(IsPropertyOverrides(field) ? Lang.overrides() : "")} {(IsNew(field) ? Lang.New() + " " : "")}{field.Type} {field.Name} {{ get; }}".Output(_o,eol)();

        protected override void WriteAccept(string name) =>
            Fa(public_override(), "Accept", Parameters(Parameter("visitor", "BoundTreeVisitor")), "BoundNode", null, statement: $"visitor.Visit{name.StripBound()}(this)");

        protected override void Write_Update(Node node, Boolean emitNew)
        {
            var newobj = emitNew ? $" {Lang.New()}" : "";
            F(Lang.@public(), "Update", Parameters(AllSpecifiableFields(node).Select(field => Parameter(field.Name, field.Type)).ToArray()), node.Name, null,
              body: () =>
             {
                 var _fields = AllSpecifiableFields(node).ToArray();
                 if (_fields.Length > 0)
                 {
                     $"{Lang.@if()} ".Output(_o, false)();
                     InParens(() => AndAlso(_fields, field => $"{field.Name.ToCamelCase(_o.Lang)} == {Lang.@this()}.{ field.Name}").Output(_o, false)())();
                     Return(Lang.@this(), true)();
                 }
                 var fields = ParenList(new[] { $"{Lang.@this()}.Syntax" }.Concat(AllSpecifiableFields(node).Select(f => f.Name)).Concat(new[] { $"{Lang.@this()}.HasErrors" }));
                 (Declaration("result")+ EqualsExpr(Invocation($"{node.Name}", fields))).Code(_o,true);
                 Assignment("result.WasCompilerGenerated", $"{Lang.@this()}.WasCompilerGenerated");
                 Return("result", true)();
             });
        }

        protected override void WriteVisitor()
        {
            Lang.WriteClass(_o, internal_abstract_partial(), "BoundTreeVisitor", "A,R", inherits: null,
                body: () =>
                {
                    Lang.Attribute("MethodImpl(MethodImplOptions.NoInlining)").Output(_o, true)();
                    F("internal", "VisitInternal", Parameters(Parameter("node", "BoundNode"), Parameter("arg", "A")), "R", null, _Switch_()); // end method
                }); // end class

            Action _Switch_()=> $"switch ({_node}.Kind)".Output(_o,true).WithBody(CaseClauses().__(DefaultReturn()), null);

            Action CaseClauses()
            {
                var _OfTypes = _tree.Types.OfType<Node>().ToArray();
                var widest = _OfTypes.Max(node => Lang.FixKeyword(node.Name.StripBound()).Length);
                return _OfTypes.ForAll(null, (clause, eolLast) => WriteCaseClauseStatement(clause, widest, eolLast)).InBraces(_o);
            }

            void WriteCaseClauseStatement(Node node, int widest, bool eolLast)
            {
                var stripName = node.Name.StripBound();
                var name = Lang.FixKeyword(stripName);
                $"{Lang.@case()} BoundKind.{name}{new string(' ', widest - name.Length)}: ".Output(_o, false)();
                Return($"Visit{stripName}({_node} as {node.Name}, arg)", true)();
            }

            Action DefaultReturn() => () =>
            {
                _o.EOL();
                Return("default(R)", true)();
            };


            Lang.WriteClass(_o, internal_abstract_partial(), "BoundTreeVisitor", "A,R", inherits: null,
                body: ApplyToTreeNodes((node, eolLast) =>
                   Fa("public virtual", $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name), Parameter("arg", "A")), "R", null,
                   statement: $"{Lang.@this()}.DefaultVisit(node, arg)")));

            Lang.WriteClass(_o, internal_abstract_partial(), "BoundTreeVisitor", genericParams: null, inherits: null,
                body: ApplyToTreeNodes((node, eolLast) =>
                  Fa("public virtual", $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name)), "BoundNode", null,
                  statement: $"{Lang.@this()}.DefaultVisit(node)")));
        }

        protected override void CreateConstructor(string name)
        {
            MethodHeader(Lang.@private(), name, null, null, false);
            Lang.GetCodeBlockBody(Exts.NotUsed)();
            _o.EOL();
        }

        protected override void WriteTreeDumperNodeProducer()
            => base.WriteTreeDumperNodeProducer("BoundTreeDumperNodeProducer","TreeDumperNode[]");

        protected override void S(string modifier, string name, string[] parameters, Action body)
        {
            MethodHeader(modifier, name, parameters, "void", true);
            Lang.GetCodeBlockBody(body)();
            _o.EOL();
        }
 
        protected override void WriteRewriter()
        {
            _o.Blank();
            Lang.WriteClass(_o, internal_abstract_partial(), "BoundTreeRewriter", genericParams: null,
                inherits: "BoundTreeVisitor",
                body: ApplyToTreeNodes((node, eolLast) =>
                        F(public_override(), $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name)), "BoundNode", null,
                        body: () =>
                        {
                            var hadField = false;
                            WritePart1(node, ref hadField);
                            WritePart2(node, ref hadField);
                        })));

            void WritePart1(Node node, ref bool hadField)
            {
                var fields = AllNodeOrNodeListFields(node).ToArray();
                hadField = fields.Length > 0;
                if (!hadField) return;
                foreach (var field in fields)
                {
                    var camel = field.Name;
                    hadField = true;
                    var expr = "";
                    expr = SkipInVisitor(field) ? $"node.{field.Name}" : $"({field.Type}){Lang.@this()}.Visit{(IsNodeList(field.Type) ? "List" : "")}(node.{field.Name})";
                    (Declaration(camel) + EqualsExpr(expr)).Code(_o, true);
                }
            }
            void WritePart2(Node node, ref bool hadField)
            {
                var result = "";
                var fields = AllTypeFields(node).ToArray();
                hadField = hadField || fields.Length > 0;
                if (hadField)
                {
                    foreach (var field in fields)
                        (Declaration(field.Name) + EqualsExpr($"{Lang.@this()}.VisitType(node.{field.Name})")).Code(_o,true);
                    var args = ParenList(AllSpecifiableFields(node), f => IsDerivedOrListOfDerived("BoundNode", f.Type) || f.Type == "TypeSymbol" ? f.Name : $"node.{f.Name}");
                    result = $"{Lang.@return()} node.Update{args}";
                }
                else
                    result = $"{Lang.@return()} node";
                result.Code(_o, true);
            }
        }

        protected override bool IsImmutableArray(string typeName) => typeName.StartsWith("ImmutableArray<", StringComparison.Ordinal);

        protected override bool IsNodeList(string typeName) => typeName.StartsWith("IList<", StringComparison.Ordinal) ||
                                                               typeName.StartsWith("ImmutableArray<", StringComparison.Ordinal);

        protected override string GetGenericType(string typeName)
        {
            if (!typeName.Contains("<")) return typeName;
            var iStart = typeName.IndexOf('<');
            return typeName.Substring(0, iStart);
        }

        protected override string GetElementType(string typeName)
        {
            if (!typeName.Contains("<")) return string.Empty;
            var iStart = typeName.IndexOf('<');
            var iEnd = typeName.IndexOf('>', iStart + 1);
            if (iEnd < iStart) return string.Empty;
            return typeName.Substring(iStart + 1, iEnd - iStart - 1);
        }
    }
}
