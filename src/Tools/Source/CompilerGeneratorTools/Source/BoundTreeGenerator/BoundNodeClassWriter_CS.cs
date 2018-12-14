// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    internal sealed class CSLangSpecific : LangSpecific
    {
        internal CSLangSpecific() : base() { }
        public override Action GetCodeBlockBody(Action body) => body.InBraces(_iw);
        public override string Attribute(string attribute) => $"[{attribute}]";
        public override string EOS() => ";";
        #region "Language Specific"
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
        public override string Inherits(string inheritsFrom) =>"";
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
        public override string EnumStatementEnding() => ",";
        //public override void End_Namespace() { }
        //public override void InsideNamespace(string ns, Func<Action> body, IndentedWriter iw) => base.InsideNamespace(ns, body.Braced(iw), iw);
        public override string @override() => "Override";

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

        

        public override void WriteClass(IndentedWriter iw, string modifiers, string classname, string genericParams = null, string inherits = null, Action body = null)
            => base.WriteClass(iw,modifiers,classname, genericParams, inherits, body.InBraces(_iw),null);
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


        private void F(string modifiers, string methodName, string[] parameters, string returns = null, Action basecall = null, Action body = null)
        {
            Exts.Body(pre:
                ()=> {
                    MethodHeader(modifiers, methodName, parameters, returns);
                    basecall?.Invoke();
                },
                Lang.GetCodeBlockBody(body),
                ()=>_o.EOL(),_o);
        }

        private void BaseCall(string basecall)
            => Exts.Indented(act: () => {  $": base".Output(_o)(); Parens(() => basecall.Output(_o)())(); }, _o)();

        private void Fa(string modifiers, string methodName, string[] parameters, string returns, string basecall = null, string statement = null)
        {
            MethodHeader(modifiers, methodName, parameters, returns);
            if (basecall  != null) BaseCall(basecall);
            if (statement != null) _o.Write($" => {statement}",true);
        }

        private void MethodHeader(string modifiers, string methodName, string[] parameters, string returns, bool startNewLine = true)
        {
            if (modifiers != null) $"{modifiers}".Output(_o)();
            if (returns   != null) $" {returns}".Output(_o)();
            $" {methodName}".Output(_o)();
            ParenList(parameters);
            if (startNewLine) _o.EOL();
        }


        protected override void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional)
        {
            // A public constructor does not have an explicit kind parameter.
            F(OutIsPublic(isPublic), node.Name, SubMewParameters(node, isPublic, hasErrorsIsOptional),
               basecall: ()=>BASE(),
               body: () =>
               {
                   WriteNullChecks(node);
                   foreach (var field in Fields(node))
                       _o.Write($"this.{(IsPropertyOverrides(field) ? "" : "")}{field.Name} = {HandleField(node, field)}", false);
                });

            void BASE()
            {
                if (isPublic)
                {
                    // Base call has bound kind, syntax, all fields in base type, plus merged HasErrors.
                    $"BoundKind.{node.Name.StripBound()}, syntax, ".Output(_o)();
                    WriteFields("", AllSpecifiableFields(BaseType(node)), node, ", ");
                    Or((new[] { "hasErrors" })
                        .Concat(from field in AllNodeOrNodeListFields(node)
                                select field.Name + ".HasErrors()"), x => x.ToCamelCase(Lang)).Output(_o)();
                }
                else
                {
                    // Base call has kind, syntax, and hasErrors. No merging of hasErrors because derived class already did the merge.
                    "kind, syntax, ".Output(_o)();
                    WriteFields("", AllSpecifiableFields(BaseType(node)), node, ", ");
                    "hasErrors".Output(_o)();
                }

            }
        }

        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected override void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic)
        {
            // A public constructor does not have an explicit kind parameter.
           F(OutIsPublic(isPublic), node.Name, SubMewParameters(node, isPublic), null,
             basecall: ()=>BASE(),
             body: () =>
             {
                 WriteNullChecks(node);
                 foreach (var field in Fields(node))
                   Exts.Code(()=> $"this.{(IsPropertyOverrides(field) ? "" : "")}{field.Name} = {HandleField(node, field)}",_o,true);

             });

            void BASE()
            {
                if (isPublic)
                {
                    // Base call has bound kind, syntax, fields.
                    $"BoundKind.{node.Name.StripBound()}, syntax".Output(_o)();
                }
                else
                {
                    // Base call has kind, syntax, fields
                   "kind, syntax".Output(_o)();
                }
                WriteFields(", ", AllSpecifiableFields(BaseType(node)), node, "");
            }
        }

        private string HandleField(TreeType node, Field baseField) => FieldNullHandling(node, baseField.Name) == NullHandling.Always ? "null" : baseField.Name.ToCamelCase(this.Lang);

        private void WriteFields(string prefix, IEnumerable<Field> fx, TreeType node, string postfix)
        {
            foreach (var baseField in fx)
                $"{prefix}{HandleField(node, baseField)}{postfix}".Output(_o)();
        }

        protected override void Write_DebugAssert_Nulls(bool isROArray, Field field, bool eolLast)
        {
            "Debug.Assert(".Output(_o)();
            var member =field.Name.ToCamelCase(Lang);
            if (isROArray)
                $"!{member}.IsDefault".Output(_o)();
            else
                $"{member} != null".Output(_o)();
            $", \"Field '{member}' cannot be null (use Null=\\\"allow\\\" in BoundNodes.xml to remove this check)\")".Output(_o,eolLast)();
        }

        protected override void WriteField(Field field)=>
            $"{Lang.@public()} {(IsPropertyOverrides(field) ? Lang.overrides() : "")} {(IsNew(field) ? Lang.New()+" " : "")}{field.Type} {field.Name} {{ get; }}".Output(_o)();

        protected override void WriteAccept(string name)=>
            Fa("public override","Accept",Parameters(Parameter("visitor", "BoundTreeVisitor")), "BoundNode", statement:$"visitor.Visit{name.StripBound()}(this)");

        protected override void Write_Update(Node node, Boolean emitNew)
        {
            var newobj = emitNew ? " new" : "";
            F($"public","Update",Parameters(AllSpecifiableFields(node).Select(field =>Parameter(field.Name,field.Type)).ToArray()), node.Name,
              body:  ()=>
              {
                  if (AllSpecifiableFields(node).Any())
                  {
                      _o.Write("if ",false);
                      Parens(() => Or(AllSpecifiableFields(node), field => $"{field.Name} != this.{field.Name}")())();
                      _o.EOL();
                      Exts.InBraces(()=>
                        {
                            var res2 = $"var result = new {node.Name}";
                            var fields = new[] { "this.Syntax" }.Concat(AllSpecifiableFields(node).Select(f => f.Name)).Concat(new[] { "this.HasErrors" });
                            ParenList(fields);
                            _o.EOL();
                            _o.Blank();
                            _o.Write("result.WasCompilerGenerated = this.WasCompilerGenerated", true);
                            Return("result",true)();
                        }, _o)();
                  }
                  _o.EOL();
                  Return("this",true)();
              });
        }

        protected override void WriteVisitor()
        {
            Lang.WriteClass(_o,"internal abstract partial", "BoundTreeVisitor", "A,R",
                body: () =>
                {
                    _o.Write(Lang.Attribute("MethodImpl(MethodImplOptions.NoInlining)"),true);
                    F("internal", "VisitInternal", Parameters(Parameter("node", "BoundNode"), Parameter("arg", "A")), "R",
                        body: ()=>Exts.Body(
                               pre: ()=>_o.Write("switch (node.Kind)",true),
                               act: ApplyToTreeNodes(
                                   (node,eolLast) =>
                                   {
                                       var strip = node.Name.StripBound();
                                       _o.Write($"case BoundKind.{Lang.FixKeyword(strip)}:", false);
                                       Return($"Visit{strip}(node as {node.Name}, arg)", eolLast)();
                                   }).InBraces(_o),
                               suf: Return("default(R)",true), _o)
                                ); // end method
                      }); // end class

                Lang.WriteClass(_o, "internal abstract partial", "BoundTreeVisitor", "A,R",
                    body: ApplyToTreeNodes((node, eolLast) =>
                       Fa("public virtual", $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name), Parameter("arg", "A")), "R",
                       statement: "this.DefaultVisit(node, arg)")));

                Lang.WriteClass(_o,"internal abstract partial", "BoundTreeVisitor",
                    body: ApplyToTreeNodes((node, eolLast) =>
                      Fa("public virtual", $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name)), "BoundNode",
                      statement: "this.DefaultVisit(node)")));
        }

        private void ThisVisit(Field field)=> _o.Write($"this.Visit{(IsNodeList(field.Type) ? "List" : "")}(node.{field.Name})",false);

        protected override void WriteWalker()
        {
            Lang.WriteClass(this._o, "internal abstract partial", "BoundTreeWalker",
                 inherits: "BoundTreeVisitor",
                 body: ApplyToTreeNodes((node, eolLast) =>
                  F("public override", $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name)), "BoundNode",
                         body: () =>
                          {
                             foreach (var field in AllFields(node).Where(f => IsDerivedOrListOfDerived("BoundNode", f.Type) && !SkipInVisitor(f)))
                                 ThisVisit(field);
                             Return("null",true)();
                         }))
                );
        }

        protected override void WriteTreeDumperNodeProducer()
        {
            Lang.WriteClass(this._o,"internal sealed","BoundTreeDumperNodeProducer",
                genericParams: null,
                inherits: $"BoundTreeVisitor{Lang.Generics("object, TreeDumperNode")}",
                body: ()=>
                {
                    F("private", "BoundTreeDumperNodeProducer", Parameters(),
                        body: ()=>Fa("public static", "MakeTree", Parameters(Parameter("node", "BoundNode")), "TreeDumperNode",
                        statement:"(new BoundTreeDumperNodeProducer()).Visit(node, null)"));

                  foreach (var node in _tree.Types.OfType<Node>())
                  {
                        var strip = node.Name.StripBound();
                        F("public override",$"Visit{strip}",Parameters(Parameter("node",node.Name),Lang.NameAsType("arg","object")),"TreeDumperNode",
                      body:()=>
                      {
                          $"return new TreeDumperNode(\"{strip}\", null, ".Output(_o)();
                          var allFields = AllFields(node).ToArray();
                          if (allFields.Length > 0)
                          {
                              "new TreeDumperNode[]".Output(_o)();
                              Exts.InBraces(()=>
                              {
                                  for (var i = 0; i < allFields.Length; ++i)
                                  {
                                      var field = allFields[i];
                                      $"new TreeDumperNode(\"{field.Name}\", ".Output(_o)();
                                    if (IsDerivedType("BoundNode", field.Type))
                                        $"null, new TreeDumperNode[] {{ Visit(node.{field.Name}, null) }})".Output(_o)();
                                    else if (IsListOfDerived("BoundNode", field.Type))
                                    {
                                        if (IsImmutableArray(field.Type) && FieldNullHandling(node, field.Name) == NullHandling.Disallow)
                                        {
                                            $"null, from x in node.{field.Name} select Visit(x, null))".Output(_o)();
                                        }
                                        else
                                        {
                                            $"null, node.{field.Name}.IsDefault ? Array.Empty<TreeDumperNode>() : from x in node.{field.Name} select Visit(x, null))".Output(_o)();
                                        }
                                    }
                                    else
                                        $"node.{ field.Name}, null)".Output(_o)();

                                    if (i == allFields.Length - 1)
                                          _o.Blank();
                                    else
                                         ",".Output(_o)();
                                }
                            }, _o)();
                          }
                          else
                          {
                            "Array.Empty<TreeDumperNode>()".Output(_o)();
                          }
                          Exts.Code(()=>")",_o,true);
                        });
                  }
              });
        }

        protected override void WriteRewriter()
        {
            _o.Blank();
            Lang.WriteClass(this._o,"internal abstract partial", "BoundTreeRewriter",
                inherits: "BoundTreeVisitor",
                body: ApplyToTreeNodes((node, eolLast) =>
                        F("public override", $"Visit{node.Name.StripBound()}", Parameters(Parameter("node", node.Name)), "BoundNode",
                        body: () =>
                        {
                            var hadField = false;
                            var result = "";
                            foreach (var field in AllNodeOrNodeListFields(node))
                            {
                                var camel = field.Name;
                                hadField = true;
                                if (SkipInVisitor(field))
                                {
                                   result+=$"{field.Type} {camel} = node.{field.Name}";
                                }
                                else
                                {
                                    var member = IsNodeList(field.Type) ? "List" : "";
                                    result += $"{field.Type} {camel} = ({field.Type})this.Visit{member}(node.{field.Name})";
                                }
                                result.Output(_o, true)();//****
                            }
                            foreach (var field in AllTypeFields(node))
                            {
                                hadField = true;
                                _o.Write($"var {field.Name} = this.VisitType(node.{field.Name})",true);
                                if (hadField)
                                {
                                   Return("node.Update",false)();
                                    ParenList(AllSpecifiableFields(node), f => IsDerivedOrListOfDerived("BoundNode", f.Type) || f.Type == "TypeSymbol" ? f.Name : $"node.{f.Name}");
                                    _o.EOL();
                                }
                                else
                                {
                                   Return("node",true)();
                                }
                            }
                    })));
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
