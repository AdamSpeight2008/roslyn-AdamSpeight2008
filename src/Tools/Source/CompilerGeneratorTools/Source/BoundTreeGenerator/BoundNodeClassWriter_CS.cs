// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoundTreeGenerator
{
    internal sealed class BoundNodeClassWriter_CS : BoundNodeClassWriter
    {
        internal BoundNodeClassWriter_CS(TextWriter writer, Tree tree) : base(writer, tree, TargetLanguage.CSharp) { }
        protected override int IndentSize() => 2;
        protected override string Namespace() => "namespace";
        protected override void InsideNamespace(string ns, Action body) => base.InsideNamespace(ns, Braced(body));

        protected override string Attribute(string attribute) => $"[{attribute}]";
        protected override string CommentMarker() => "//";
        protected override string @optional() => "";
        protected override string @false() => "false";
        protected override string OrElse() => "||";
        protected override string AndAlso() => "&&";
        protected override string Class() => "class";
        protected override string Enum() => "enum";
        protected override string Friend() => "internal";
        protected override string Partial() => "partial";
        protected override string @public() => "public";
        protected override string @bool() => "bool";
        protected override string @_nameof_() => "nameof";
        protected override string @protected() => "protected";
        protected override string @private() => "private";
        protected override string Imports() => "using";
        protected override string EndOfStatement() => ";";
        protected override string Inherits() => "";
        protected override string Abstract() => "abstract";
        protected override string Sealed() => "sealed";
        protected override string @return() => "return";
        protected override string @overrides() => "override";
        protected override string @shadows() => "shadows";
        protected override string @shared() => "static";
        protected override string @this() => "this";
        protected override string @case() => "case";
        protected override string @if() => "if";
        protected override string @then() => "";
        protected override string @New() => "new";
        protected override string @null() => "null";

        protected override Action Braced(Action content)=> base.Braced(()=> { EOL(); content?.Invoke(); EOL(); });

        protected override string Generics(string genericParams) => $"<{genericParams}>";
        protected override string InsideNamespace() => "Microsoft.CodeAnalysis.CSharp";
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
        protected override void ImportsNamespaces() => ImportNamespaces("Microsoft.CodeAnalysis.Text","Microsoft.CodeAnalysis.CSharp.Symbols","Microsoft.CodeAnalysis.CSharp.Syntax");
        
        protected override void End_Namespace() { }
        protected override string NameAsType(string name, string typename, bool isNew = false) => $"{typename} {name}";
        protected override string EnumStatementEnding() => ",";

        private void F(string modifiers, string methodName, string[] parameters,string returns = null,  Action basecall = null, Action body = null)
        {
            InBlock(
                () =>
                {
                    MethodHeader(modifiers, methodName, parameters, returns);
                    if (basecall != null)
                    {
                        Indented(() =>
                        {
                            Write($": base");
                            Parens(basecall,true)();
                        });
                    }
                },
                Braced(body),
                false
                )();
        }
        private void Fa(string modifiers, string methodName, string[] parameters, string returns, Action basecall = null, string statement = null)
        {
            MethodHeader(modifiers, methodName, parameters, returns, startNewLine:false);
            if (basecall != null)
            {
                Indented(() =>
                {
                    Write($": base");
                    Parens(basecall)();
                });
            }
            statement.IfNonNull(s => Write($" => {s}"));
            EOL();
        }

        private void MethodHeader(string modifiers, string methodName, string[] parameters, string returns,bool startNewLine = true)
        {
            if (modifiers != null) Write($"{modifiers}");
            if (returns != null) Write($" {returns}");
            Write($" {methodName}");
            ParenList(parameters);
            if(startNewLine) EOL();
        }

        protected override void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional)
        {
            // A public constructor does not have an explicit kind parameter.
           F(OutIsPublic(isPublic), node.Name, SubMewParameters(node, isPublic, hasErrorsIsOptional),
              basecall: () =>
                    {
                        if (isPublic)
                        {
                            // Base call has bound kind, syntax, all fields in base type, plus merged HasErrors.
                            Write($"BoundKind.{StripBound(node.Name)}, syntax, ");
                            WriteFields("", AllSpecifiableFields(BaseType(node)), node, ", ");
                            Or((new[] { "hasErrors" })
                                .Concat(from field in AllNodeOrNodeListFields(node)
                                        select field.Name + ".HasErrors()"), x => ToCamelCase(x));
                        }
                        else
                        {
                            // Base call has kind, syntax, and hasErrors. No merging of hasErrors because derived class already did the merge.
                            Write("kind, syntax, ");
                            WriteFields("", AllSpecifiableFields(BaseType(node)), node, ", ");
                            Write("hasErrors");
                        }
                    }
                    ,
              body: () =>
               {
                    WriteNullChecks(node);
                    foreach (var field in Fields(node))
                        Statement($"this.{(IsPropertyOverrides(field) ? "" : "")}{field.Name} = {HandleField(node, field)}");
                });
        }

        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected override void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic)
        {
            // A public constructor does not have an explicit kind parameter.
            F(OutIsPublic(isPublic), node.Name, SubMewParameters(node, isPublic), null,
             basecall: () =>
             {
                 if (isPublic)
                 {
                    // Base call has bound kind, syntax, fields.
                    Write($"BoundKind.{StripBound(node.Name)}, syntax");
                 }
                 else
                 {
                    // Base call has kind, syntax, fields
                    Write("kind, syntax");
                 } 
                 WriteFields(", ", AllSpecifiableFields(BaseType(node)), node, "");
             },
             body: () =>
             {
                 WriteNullChecks(node);
                 foreach (var field in Fields(node))
                     Statement($"this.{(IsPropertyOverrides(field) ? "" : "")}{field.Name} = {HandleField(node, field)}");
             });
            Blank();
        }

        private string HandleField(TreeType node, Field baseField) => FieldNullHandling(node, baseField.Name) == NullHandling.Always ? "null" : ToCamelCase(baseField.Name);
        private void WriteFields(string prefix, IEnumerable<Field> fx, TreeType node, string postfix)
        {
            foreach (var baseField in fx)
                Write($"{prefix}{HandleField(node, baseField)}{postfix}");
        }

        protected override void Write_DebugAssert_Nulls(bool isROArray, Field field)
        {
            Write("Debug.Assert(");
            var member = ToCamelCase(field.Name);
            if (isROArray)
                Write($"!{member}.IsDefault");
            else
                Write($"{member} != null");

            Statement($", \"Field '{member}' cannot be null (use Null=\\\"allow\\\" in BoundNodes.xml to remove this check)\")");
        }

        protected override void WriteField(Field field)
            => Statement($"public {(IsPropertyOverrides(field) ?"override":"")} {(IsNew(field) ? "new " : "")}{field.Type} {field.Name} {{ get; }}",true,false);

        protected override void WriteAccept(string name)=>
            Fa("public override","Accept",Parameters(Parameter("visitor", "BoundTreeVisitor")), "BoundNode", statement:$"visitor.Visit{StripBound(name)}(this)");

        protected override void Write_Update(Node node, Boolean emitNew)
        {
            Blank();
            var newobj = emitNew ? " new" : "";
            F($"public","Update",Parameters(AllSpecifiableFields(node).Select(field =>Parameter(field.Name,field.Type)).ToArray()), node.Name,
              body:  ()=>{
                    if (AllSpecifiableFields(node).Any())
                    {
                        Write("if ");
                        Parens(() => Or(AllSpecifiableFields(node), field => $"{field.Name} != this.{field.Name}"))();
                        Blank();
                        Braced(() =>
                        {
                            Write($"var result = new {node.Name}");
                            var fields = new[] { "this.Syntax" }.Concat(AllSpecifiableFields(node).Select(f => f.Name)).Concat(new[] { "this.HasErrors" });
                            ParenList(fields);
                            Statement("");
                            Statement("result.WasCompilerGenerated = this.WasCompilerGenerated");
                            Statement("return result");
                        })();
                    }
                  Statement("return this");
            });
        }

        protected override void WriteVisitor()
        {
            WriteClass("internal abstract partial","BoundTreeVisitor","A,R",
                  body:() =>
                    {
                        Attribute("MethodImpl(MethodImplOptions.NoInlining)");
                        F("internal", "VisitInternal", Parameters(Parameter("node", "BoundNode"), Parameter("arg", "A")), "R",
                        body: InBlock(
                                () => Statement("switch (node.Kind)",true,false),
                                Braced(
                                    ApplyToTreeNodes((node) =>
                                    {
                                        var strip = StripBound(node.Name);
                                        Statement($"case BoundKind.{FixKeyword(strip)}: return Visit{strip}(node as {node.Name}, arg)");
                                    })),
                                false,
                                footer: () => Statement("return default(R)"))
                             ); // end method
                    }); // end class

            WriteClass("internal abstract partial","BoundTreeVisitor","A,R",
                body: ApplyToTreeNodes((node)=>Fa("public virtual",$"Visit{StripBound(node.Name)}",Parameters(Parameter("node",node.Name), Parameter("arg","A")),"R",statement:"this.DefaultVisit(node, arg);")));
            WriteClass("internal abstract partial", "BoundTreeVisitor",
                body: ApplyToTreeNodes((node)=> Fa("public virtual", $"Visit{StripBound(node.Name)}", Parameters(Parameter("node", node.Name)), "BoundNode", statement: "this.DefaultVisit(node);")));

        }

        private void ThisVisit(Field field) => Statement($"this.Visit{(IsNodeList(field.Type) ? "List" : "")}(node.{field.Name})");

        protected override void WriteWalker()
        {
            WriteClass("internal abstract partial","BoundTreeWalker",
                inherits: "BoundTreeVisitor",
                body: ApplyToTreeNodes(node =>
                {
                    F("public override",$"Visit{StripBound(node.Name)}",Parameters(Parameter("node",node.Name)),"BoundNode",
                        body:()=>
                        {
                            foreach (var field in AllFields(node).Where(f => IsDerivedOrListOfDerived("BoundNode", f.Type) && !SkipInVisitor(f)))
                                ThisVisit(field);
                            Statement("return null");
                        }
                     );
                }));
            Blank();
        }

        protected override void WriteTreeDumperNodeProducer()
        {
            WriteClass("internal sealed","BoundTreeDumperNodeProducer",
                inherits: $"BoundTreeVisitor{Generics("object, TreeDumperNode")}",
                body: ()=>{
                    F("private", "BoundTreeDumperNodeProducer", Parameters());
                    Fa("public static", "MakeTree", Parameters(Parameter("node", "BoundNode")), "TreeDumperNode",statement:"(new BoundTreeDumperNodeProducer()).Visit(node, null);");
                    foreach (var node in _tree.Types.OfType<Node>())
                    {
                        var strip = StripBound(node.Name);
                        F("public override",$"Visit{strip}",Parameters(Parameter("node",node.Name),NameAsType("arg","object")),"TreeDumperNode",
                            body:()=>
                            {
                            Write($"return new TreeDumperNode(\"{strip}\", null, ");
                            var allFields = AllFields(node).ToArray();
                            if (allFields.Length > 0)
                            {
                                    Statement("new TreeDumperNode[]",false,false);
                                Braced(()=>
                                {
                                    for (var i = 0; i < allFields.Length; ++i)
                                    {
                                        var field = allFields[i];
                                        Write($"new TreeDumperNode(\"{field.Name}\", ");
                                        if (IsDerivedType("BoundNode", field.Type))
                                            Write($"null, new TreeDumperNode[] {{ Visit(node.{field.Name}, null) }})");
                                        else if (IsListOfDerived("BoundNode", field.Type))
                                        {
                                            if (IsImmutableArray(field.Type) && FieldNullHandling(node, field.Name) == NullHandling.Disallow)
                                            {
                                                Write($"null, from x in node.{field.Name} select Visit(x, null))");
                                            }
                                            else
                                            {
                                                Write($"null, node.{field.Name}.IsDefault ? Array.Empty<TreeDumperNode>() : from x in node.{field.Name} select Visit(x, null))");
                                            }
                                        }
                                        else
                                            Write($"node.{ field.Name}, null)");

                                        if (i == allFields.Length - 1)
                                           Blank();
                                        else
                                            Statement(",",true,false);
                                    }
                                })();
                            }
                            else
                            {
                                    Statement("Array.Empty<TreeDumperNode>()",true,false);
                            }
                                Statement(")");
                        });
                    }});
        }

        protected override void WriteRewriter()
        {
            Blank();
            WriteClass("internal abstract partial", "BoundTreeRewriter",
                inherits: "BoundTreeVisitor",
                body: ApplyToTreeNodes(node =>
                    {
                        F("public override", $"Visit{StripBound(node.Name)}", Parameters(Parameter("node", node.Name)), "BoundNode",
                        body: () =>
                        {
                            var hadField = false;
                            foreach (var field in AllNodeOrNodeListFields(node))
                            {
                                var camel = field.Name;
                                hadField = true;
                                if (SkipInVisitor(field))
                                {
                                    Statement($"{field.Type} {camel} = node.{field.Name}");
                                }
                                else
                                {
                                    var member = IsNodeList(field.Type) ? "List" : "";
                                    Statement($"{field.Type} {camel} = ({field.Type})this.Visit{member}(node.{field.Name})");
                                }
                            }
                            foreach (var field in AllTypeFields(node))
                            {
                                hadField = true;
                                Statement($"var {field.Name} = this.VisitType(node.{field.Name})");
                            }
                            if (hadField)
                            {
                                Write("return node.Update");
                                ParenList(AllSpecifiableFields(node), field => IsDerivedOrListOfDerived("BoundNode", field.Type) || field.Type == "TypeSymbol" ? field.Name : $"node.{field.Name}");
                                Statement("");
                            }
                            else
                            {
                                Statement("return node");
                            }

                        });
                    }));
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

        protected override string EscapeKeyword(string name) => "@" + name;
        protected override void WriteClass(string modifiers, string classname, string genericParams = null, string inherits = null, Action body = null)
        {
            base.WriteClass(modifiers, classname, genericParams, inherits, Braced(body), NotUsed(),false);
        }
    protected override bool IsKeyword(string name)
        {
            switch (name)
            {
                case "bool":
                case "byte":
                case "sbyte":
                case "short":
                case "ushort":
                case "int":
                case "uint":
                case "long":
                case "ulong":
                case "double":
                case "float":
                case "decimal":
                case "string":
                case "char":
                case "object":
                case "typeof":
                case "sizeof":
                case "null":
                case "true":
                case "false":
                case "if":
                case "else":
                case "while":
                case "for":
                case "foreach":
                case "do":
                case "switch":
                case "case":
                case "default":
                case "lock":
                case "try":
                case "throw":
                case "catch":
                case "finally":
                case "goto":
                case "break":
                case "continue":
                case "return":
                case "public":
                case "private":
                case "internal":
                case "protected":
                case "static":
                case "readonly":
                case "sealed":
                case "const":
                case "new":
                case "override":
                case "abstract":
                case "virtual":
                case "partial":
                case "ref":
                case "out":
                case "in":
                case "where":
                case "params":
                case "this":
                case "base":
                case "namespace":
                case "using":
                case "class":
                case "struct":
                case "interface":
                case "delegate":
                case "checked":
                case "get":
                case "set":
                case "add":
                case "remove":
                case "operator":
                case "implicit":
                case "explicit":
                case "fixed":
                case "extern":
                case "event":
                case "enum":
                case "unsafe":
                    return true;
                default:
                    return false;
            }
        }
    }
}
