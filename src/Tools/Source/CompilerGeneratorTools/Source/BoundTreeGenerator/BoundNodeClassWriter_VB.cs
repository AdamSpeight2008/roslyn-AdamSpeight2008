// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoundTreeGenerator
{
    internal sealed class BoundNodeClassWriter_VB : BoundNodeClassWriter
    {
        internal BoundNodeClassWriter_VB(TextWriter writer, Tree tree) : base(writer, tree, TargetLanguage.VB) { }

        protected override int IndentSize() => 2;


        #region "language specific"
        protected override string Namespace() => "Namespace";
        protected override string Class() => "Class";
        protected override string Enum() => "Enum";
        protected override string Friend() => "Friend";
        protected override string Partial() => "Partial";
        protected override string Abstract() => "MustInherit";
        protected override string Sealed() => "NotInheritable";
        private string Sub() => "Sub";
        private string Function() => "Function";
        private string End() => "End";
        private string Select() => "Select";
        private string Return() => "Return";
        protected override string @public() => "Public";
        protected override string @private() => "Private";
        private string Overrides() => "Overrides";
        protected override string @optional() => "Optional";
        protected override string @false() => "False";
        protected override string @bool() => "Boolean";
        protected override string @protected() => "Protected";
        private string Shadows() => "Shadows";
        private string Overridable() => "Overridable";
        protected override string Imports() => "Imports";
        protected override string Inherits() => "Inherits ";
        protected override string OrElse() => "OrElse";
        protected override string AndAlso() => "AndAlso";
        protected override string @_nameof_() => "NameOf";

        #endregion
        private string AsType(string typename, bool isNew = false) => (typename == null) ? "" : $" As {(isNew ? "New " : "")}{typename}";
        protected override string NameAsType(string name, string typename, bool isNew = false) => $"{ToCamelCase(name)}{AsType(typename, isNew)}";

        #region "block creation helpers"
        void ReturnType(string type) => WriteLine(AsType(type));
        protected override void WriteClass(string modifiers, string classname, string inherits = null, Action body = null) => 
            Indented(()=>base.WriteClass(modifiers, classname, inherits, body,()=> End_Class(),true));
        #region "method creation helpers"
        private void MethodHeader(string modifiers, string methodKind, string methodName, string[] parameters, string returns)
        {
            if (modifiers != null) Write($"{modifiers} ");
            Write($"{methodKind} {methodName}");
            ParenList(parameters);
            if (returns != null) { ReturnType(returns); } else { EOL(); };
        }

        private void F(string modifier, string name, string[] parameters, string returns, Action body) =>
            InBlock(() => MethodHeader(modifier, Function(), name, parameters, returns), body,true, footer: () => End_Function());
        private void S(string modifier, string name, string[] parameters, Action body) =>
            InBlock(() => MethodHeader(modifier, Sub(), name, parameters, null), body, true, footer: () => End_Sub());
        private void ReturnNode() => Return("node", eol: false);
        private void Return(string text, bool eol = true) { if (eol) { WriteLine($"{Return()} {text}"); } else { Write($"{Return()} {text}"); } }
        #endregion
        private void E(string modifier, string name, string enumType, Action body) =>
            Indented(()=>InBlock(() => WriteLine($"{modifier} {Enum()} {NameAsType(name, enumType)}"), body,true, footer: () => End_Enum()));
        private void Friend_MustInherit_Partial_Class(string className, string inherits, Action body) =>
            WriteClass($"{Friend()} {Abstract()} {Partial()}", className, inherits, body);


        #region "End Of Blocks"
        private void Write_End(string text) => WriteLine($"{End()} {text}");
        private void End_Sub() => Write_End(Sub());
        private void End_Enum() => Write_End(Enum());
        private void End_Select() => Write_End(Select());
        private void End_Class() => Write_End(Class());
        private void End_Function() => Write_End(Function());
        protected override void End_Namespace() => Write_End(Namespace());
        #endregion
        #endregion

        private void WriteArgumentsToMethod(string prefix, IEnumerable<Field> fx, TreeType node, string postfix)
        {
            foreach (var baseField in fx)
            {
                var value = FieldNullHandling(node, baseField.Name) == NullHandling.Always ? "Nothing" : ToCamelCase(baseField.Name);
                Write($"{prefix}{value}{postfix}");
            }
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
        protected override void AutoGenerated() => WriteLine("' <auto-generated />");
        protected override string InsideNamespace() => "Microsoft.CodeAnalysis.VisualBasic";
        protected override void ImportsNamespaces()
        {
            ImportNamespace("Microsoft.CodeAnalysis.Text");
            ImportNamespace("Microsoft.CodeAnalysis.VisualBasic.Symbols");
            ImportNamespace("Microsoft.CodeAnalysis.VisualBasic.Syntax");
        }

        protected override void WriteKinds() => E(Friend(),"BoundKind","Byte",ApplyToTreeNodes(node => WriteLine(FixKeyword(StripBound(node.Name)))) );



        protected override void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional)
        {
            var hasValidate = false;
            // A public constructor does not have an explicit kind parameter.
            S(OutIsPublic(isPublic),"New",SubMewParameters(node, isPublic, hasErrorsIsOptional),
                ()=>
                {
                    MyBase();
                    LParens();
                    if (isPublic) { IsPublic(); } else { NonPublic(); }
                    RParens();
                    EOL();
                    WriteNullChecks(node);
                    foreach (var field in Fields(node))
                        AssignmentTo(node,field);

                     hasValidate = HasValidate(node);

                    if (hasValidate) WriteLine("Validate()");

                });

            IfHasValidateThenWrite_ValidateMethod();

            void IfHasValidateThenWrite_ValidateMethod()
            {
                if (!hasValidate) return;
                S($"{@private()} {Partial()}", "Validate",null, () => { });
            }
            void IsPublic()
            {
                // Base call has bound kind, syntax, all fields in base type, plus merged HasErrors.
                Write($"BoundKind.{StripBound(node.Name)}");
                Write(", syntax, ");
                WriteArgumentsToMethod("", AllSpecifiableFields(BaseType(node)), node, ", ");

                Or((new[] { "hasErrors" })
                    .Concat(from field in AllNodeOrNodeListFields(node)
                            select ToCamelCase(field.Name) + ".NonNullAndHasErrors()"), x => x);
            }
            void NonPublic()
            {           
                // Base call has kind, syntax, and hasErrors. No merging of hasErrors because derived class already did the merge.
                Write("kind, syntax, ");
                WriteArgumentsToMethod("", AllSpecifiableFields(BaseType(node)), node, ", ");
                Write("hasErrors");
            }
        }
        protected override void Write_DebugAssert_Nulls(bool isROArray, Field field)
        {
            var fieldName = ToCamelCase(field.Name);
            Write("Debug.Assert(");
            if (isROArray) { Write($"Not {fieldName}.IsDefault"); } else { Write($"{fieldName} IsNot Nothing"); }
            WriteLine($", $\"Field '{_NameOf(fieldName)}' cannot be null (use Null=\"\"allow\"\" in BoundNodes.xml to remove this check)\")");
        }

        protected override void WriteField(Field field)
        {
            var shadows = IsNew(field) ? "Shadows " : (IsPropertyOverrides(field) ? "Overrides " : "");
            WriteLine($"Public {shadows}ReadOnly Property {NameAsType(field.Name, field.Type)}");
        }

        private void MyBase() => Write("MyBase.New");
   
        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected override void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic)
        {
            S(OutIsPublic(isPublic), "New", SubMewParameters(node, isPublic),
                () =>
                {
                    MyBase();
                    LParens();
                    if (isPublic) { WriteBaseCall_ForBoundKindSyntaxFields(); } else { WriteBaseCall_ForKindSyntaxFields(); }
                    RParens();
                    EOL();
                    WriteNullChecks(node);

                    foreach (var field in Fields(node))
                        AssignmentTo(node,field);

                    if (HasValidate(node)) WriteLine("Validate()");

                }) ;

            void WriteBaseCall_ForBoundKindSyntaxFields()
            {
                // Base call has bound kind, syntax, fields.
                Write($"BoundKind.{StripBound(node.Name)}, syntax");
                WriteArgumentsToMethod(", ", AllSpecifiableFields(BaseType(node)), node, "");
            }
            void WriteBaseCall_ForKindSyntaxFields()
            {
                // Base call has kind, syntax, fields
                Write("kind, syntax");
                WriteArgumentsToMethod(", ", AllSpecifiableFields(BaseType(node)), node, "");
            }
        }

        private void AssignmentTo(TreeType node, Field field) => WriteLine($"_{field.Name} = {(FieldNullHandling(node, field.Name) == NullHandling.Always ? "Nothing" : ToCamelCase(field.Name))}");



        protected override void WriteAccept(string name) =>
            F($"{@public()} {Overrides()}", "Accept", Parameters(NameAsType("visitor", "BoundTreeVisitor")), boundNode, () => { Return($"visitor.Visit{StripBound(name)}(Me)"); });

        protected override void Write_Update(Node node, bool emitNew)
        {
            Blank();
            var modifier = emitNew ? $" {Shadows()}" : "";
            F($"{@public()}{modifier}", "Update", AllSpecifiableFields(node).Select(field => NameAsType(field.Name, field.Type)).ToArray(), node.Name,
                () =>
                {
                    if (!AllSpecifiableFields(node).Any())
                    {
                        Return("Me");
                    }
                    else
                    {
                        IfThen(()=>AndAlso(AllSpecifiableFields(node), field => $"({ToCamelCase(field.Name)} {WriteComparision(field)}"),()=>Return("Me"));
                        Declaration("result", node.Name, null, isNew: true);
                        ParenList((new[] { "Me.Syntax" }).Concat(AllSpecifiableFields(node).Select(f => ToCamelCase(f.Name))).Concat(new[] { "Me.HasErrors" }));
                        EOL();
                        IfThen(() => Write("Me.WasCompilerGenerated"), () => WriteLine("result.SetWasCompilerGenerated()"));
                        Return("result");
                    };
                });
            // Helpers
            void IfThen(Action cmp, Action a)
            {
                Write($"If ");  cmp();  Write(" Then "); a();
            }
            string WriteComparision(Field field) => $"{(IsValueType(field.Type) ? $"=" : "Is")} Me.{field.Name})";
        }

        protected override void WriteVisitor()
        {
            Write_VisitInternal();
            Write_Visit_AsR();
            Write_Vist_AsBoundNode();

            void Write_VisitInternal()
            {
                Friend_MustInherit_Partial_Class("BoundTreeVisitor(Of A,R)", null,
                    () =>
                    {
                        WriteLine("<MethodImpl(MethodImplOptions.NoInlining)>");
                        F(Friend(), $"VisitInternal", Parameters(NodeAsBoundNode(), NameAsType("arg", "A")), "R",
                            () =>
                            {
                                SelectCase();
                                Return("DefaultVisit(node, arg)");
                            });
                    });
            }
            void SelectCase()
            {
                InBlock(() => WriteLine("Select Case node.Kind"),
                    () =>
                    {
                        var _OfTypes = _tree.Types.OfType<Node>().ToList();
                        var widest = _OfTypes.Max(node => FixKeyword(StripBound(node.Name)).Length);
                        for (var idx = 0; idx < _OfTypes.Count; idx++)
                        {
                            var node = _OfTypes[idx];
                            var stripName = StripBound(node.Name);
                            var name = FixKeyword(stripName);
                            WriteLine($"Case BoundKind.{name}{new string(' ', widest - name.Length)}: Return Visit{stripName}(CType(node, {node.Name}), arg)");
                        }
                    },
                    true,
                    footer: () => End_Select());
            }
            void Write_Visit_AsR() =>
                Friend_MustInherit_Partial_Class("BoundTreeVisitor(Of A,R)", null, ApplyToTreeNodes(node => WriteVisitor(node, Parameters(NodeAs(node), NameAsType("arg", "A")), "R", "node,arg")));

            void Write_Vist_AsBoundNode()=>
                Friend_MustInherit_Partial_Class("BoundTreeVisitor", null, ApplyToTreeNodes(node=> WriteVisitor(node, Parameters(NodeAs(node)), boundNode, "node")));

            void WriteVisitor(Node node, string[] parameters, string returns, string argument) =>
                F($"{@public()} {Overridable()}", $"Visit{StripBound(node.Name)}", parameters.ToArray(), returns, ()=> Return($"Me.DefaultVisit({argument})"));

        }

        private string NodeAsBoundNode() => NameAsType("node", "BoundNode");
        private string NodeAs(Node node) => NameAsType("node", node.Name);

        private string Visit(Node node) => $"Visit{StripBound(node.Name)}";

        private const string boundNode = "BoundNode";
        protected override void WriteWalker()
        {
            Friend_MustInherit_Partial_Class("BoundTreeWalker", "BoundTreeVisitor",
                () => { foreach (var node in _tree.Types.OfType<Node>())
                        {
                        F($"{@public()} {Overrides()}", Visit(node), Parameters(NodeAs(node)).ToArray(), boundNode,
                            () =>
                            {
                                Visiting(node);
                                Return("Nothing");
                            });
                        }
                      });

            void Visiting(Node node)
            {
                foreach (var field in AllFields(node).Where(f => IsDerivedOrListOfDerived(boundNode, f.Type) && !SkipInVisitor(f)))
                {
                    var member = IsNodeList(field.Type) ? "List" : "";
                    WriteLine($"Me.Visit{member}(node.{field.Name})");
                }
            }
        }
 
        private string useAsVariableName(string name) => ToCamelCase(StripBound(name));

        protected override void WriteTreeDumperNodeProducer()
        {
            WriteClass($"{Friend()} {Sealed()}", "BoundTreeDumperNodeProducer", "BoundTreeVisitor(Of Object, TreeDumperNode)",
                () =>
                {
                    Blank();
                    S(@private(), "New", null, () => { });

                    Write_MakeTree();
                    ApplyToTreeNodes(node =>
                    {
                        F("Public Overrides", Visit(node), Parameters(NodeAs(node), NameAsType("arg", "Object")).ToArray(), "TreeDumperNode",
                            () =>
                            {
                                Return($"New TreeDumperNode(\"{useAsVariableName(node.Name)}\", Nothing, ");
                                var allFields = AllFields(node).ToArray();
                                if (allFields.Length > 0)
                                {
                                    WriteLine("{");

                                        for (var i = 0; i < allFields.Length; ++i)
                                        {
                                            var field = allFields[i];
                                            Write($"New TreeDumperNode(\"{_Field(field)}\", ");
                                            if (IsDerivedType(boundNode, field.Type))
                                                Write($"Nothing, {{ Visit(node.{field.Name}, Nothing) }})");
                                            else if (IsListOfDerived(boundNode, field.Type))
                                                Write($"Nothing, From x In node.{field.Name} Select Visit(x, Nothing))");
                                            else
                                                Write($"node.{field.Name}, Nothing)");

                                            if (i == allFields.Length - 1)
                                                WriteLine("");
                                            else
                                                WriteLine(",");
                                        }
                                        WriteLine("})");
                                }
                                else
                                {
                                    WriteLine("Array.Empty(Of TreeDumperNode)())");
                                };
                            });
                    })();
                });

            void Write_MakeTree()
            {
                F("Public Shared", "MakeTree", Parameters(NodeAsBoundNode()), "TreeDumperNode",
                    () => Return("(New BoundTreeDumperNodeProducer()).Visit(node, Nothing)"));
            }

        }

        string _Field(Field field) => ToCamelCase(field.Name);
        protected override void WriteRewriter()
        {
            Friend_MustInherit_Partial_Class("BoundTreeRewriter", null,
                ApplyToTreeNodes(node => WriteOverridesVisitFunction(node)));

            void WriteOverridesVisitFunction(Node node)
            {
                var hadField = false;
                F($"{@public()} {Overrides()}", Visit(node),Parameters( NodeAs(node)), "BoundNode", 
                () =>
                {
                    var f0 = AllNodeOrNodeListFields(node).ToArray();
                    var m0 = f0.Length == 0 ? 0 : f0.Max(x => x.Name.Length);
                    var f1 = AllTypeFields(node).ToArray();
                    var m1 = f1.Length == 0 ? 0 : f1.Max(x => x.Name.Length);
                    var widest = Math.Max(m0, m1);
                    AddAny_NodeNodeListField(f0, widest);
                    AddAny_TypeFields(f1, widest);
                    AddReturnStatement();
                    EOL();
                });

                void AddAny_NodeNodeListField(Field[] fields,int widest)
                {
                    if (fields.Length <= 0) return;
                    for (var idx = 0; idx < fields.Length; idx++)
                    {
                        var field = fields[idx];
                        hadField = true;
                        if (SkipInVisitor(field))
                            Declaration(field.Name, null, $"node.{field.Name}", eol: true, width: widest);
                        else if (IsNodeList(field.Type))
                            Declaration(field.Name, null, $"Me.VisitList(node.{field.Name})", eol: true, width: widest);
                        else
                            Declaration(field.Name, null, $"DirectCast(Me.Visit(node.{field.Name}), {field.Type})", eol: true, width: widest);
                    }
                }
                void AddAny_TypeFields(Field[] fields, int widest)
                {
                    if (fields.Length <= 0) return;
                    for (var idx = 0; idx < fields.Length; idx++)
                    {
                        var field = fields[idx];
                        hadField = true;
                        Declaration(field.Name, null, $"Me.VisitType(node.{field.Name})", eol: true, width: widest);
                    }
                }
                void AddReturnStatement()
                {
                    ReturnNode();
                    if (!hadField) return;
                    Write(".Update");
                    ParenList(AllSpecifiableFields(node), field => IsDerivedOrListOfDerived("BoundNode", field.Type) || field.Type == "TypeSymbol" ? ToCamelCase(field.Name) : $"node.{field.Name}");
                }
            }
        }

        private void Declaration(string field, string typeName, string value , bool isNew = false, bool eol = false,  int width = 0)
        {
            width = width <= 0 ? field.Length : width;
           Write($"Dim {NameAsType(field, typeName, isNew: isNew).PadLeft(width)}");
           if (value != null) Write($" = {value}");
           if (eol) EOL();
        }

        protected override bool   IsImmutableArray(string typeName) => typeName.StartsWith("ImmutableArray(Of", StringComparison.OrdinalIgnoreCase);
        protected override bool   IsNodeList(string typeName) => typeName.StartsWith("IList(Of", StringComparison.OrdinalIgnoreCase) ||
                                                               typeName.StartsWith("ImmutableArray(Of", StringComparison.OrdinalIgnoreCase);
        protected override bool   IsKeyword(string name) => Keywords.Contains(name.ToLower());
        protected override string GetGenericType(string typeName)
        {
            var iStart = typeName.IndexOf("(Of", StringComparison.OrdinalIgnoreCase);
            return (iStart == -1) ? typeName : typeName.Substring(0, iStart);
        }
        protected override string GetElementType(string typeName)
        {
            var iStart = typeName.IndexOf("(Of", StringComparison.OrdinalIgnoreCase);
            if (iStart == -1) return string.Empty;
            var iEnd = typeName.IndexOf(')', iStart + 3);
            if (iEnd < iStart) return string.Empty;
            return typeName.Substring(iStart + 3, iEnd - iStart - 3).Trim();
        }
        protected override string EscapeKeyword(string name) => "[" + name + "]";

        private static HashSet<string> Keywords = new HashSet<string>(new string[]
        {  "addhandler", "addressof", "alias", "and", "andalso", "as",
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
            "xor"}
        );
    }
}
