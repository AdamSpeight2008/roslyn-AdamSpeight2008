// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using static BoundTreeGenerator.Exts;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    internal abstract partial class BoundNodeClassWriter
    {
        protected const string boundNode = "BoundNode";
        protected const string _node = "node";
        protected string public_override() => $"{_o.Lang.@public()} {_o.Lang.@override()}";
        protected string internal_abstract_partial() => _o.Lang.@internal() + " " + _o.Lang.Abstract() + " " + _o.Lang.Partial();

        protected string Assignment(string id, string expr, bool eol = true) => $"{id} = {expr}";
        protected string Declaration(string id) => $"{Lang.Decl()} {id}";
        protected string Invocation(string type, string args) => $"{Lang.New()} {type}{args}";
        protected string EqualsExpr(string expr) => $" = {expr}";
        protected string Spaces(int x) => new string(' ', x < 0 ? 0 : x);
        
        protected string[] SubNewParameters(TreeType node, bool isPublic, bool? hasErrorsIsOptional = default(bool?))
        {
            var fields = OutputFirstParameters(isPublic).Concat(from field in AllSpecifiableFields(node) select Parameter(field.Name, field.Type));
            if (hasErrorsIsOptional.HasValue) { Include_HasError(); };
            return fields.ToArray();

            void Include_HasError()
            {
                var param = Lang.NameAsType("hasErrors", Lang.@bool());
                fields = fields.Concat(hasErrorsIsOptional.Value ? new[] { $"{Lang.@optional()} {param} = {Lang.@false()}" } : new[] { param });
            }
        }

        protected void WriteConstructor(TreeType node, bool isPublic, bool hasChildNodes)
        {
            WriteConstructorWithHasErrors(node, isPublic, hasErrorsIsOptional: hasChildNodes);
            if(!hasChildNodes) WriteConstructorWithoutHasErrors(node, isPublic);
        }

        protected void WriteNullChecks(TreeType node)
        {
            // Write the null checks for any fields that can't be null.
            var nullCheckFields = AllFields(node).Where(f => FieldNullHandling(node, f.Name) == NullHandling.Disallow);
            nullCheckFields.ForAll(null, (field, __) => {
                var isROArray = (GetGenericType(field.Type) == "ImmutableArray");
                Write_DebugAssert_Nulls(isROArray, field, true); })();
        }
        protected Action ApplyToTreeNodes(Action<Node,bool> a) => _tree.Types.OfType<Node>().ForAll(null, a);

        protected string _GetModifiers(TreeType node) =>
            (node is AbstractNode) ? $"{Lang.Abstract()} " : CanBeSealed(node) ? $"{Lang.Sealed()} " : "";

        protected void WriteType(TreeType node)
        {
            if (!(node is AbstractNode) && !(node is Node)) return;
            _o.Blank();
            Lang.WriteClass(_o, $"{Lang.Friend()} {_GetModifiers(node)}{Lang.Partial()}", node.Name, null, node.Base,Internals);

            void Internals()
            {
                var unsealed = !CanBeSealed(node);
                var concrete = !(node is AbstractNode);
                var hasChildNodes = AllNodeOrNodeListFields(node).Any();

                if (unsealed) WriteConstructor(node, false, hasChildNodes);
                if (concrete) WriteConstructor(node, true, hasChildNodes);
                var _fields = Fields(node).ToList();
                if (_fields.Count > 0)
                    foreach (var field in Fields(node))
                        WriteField(field, true);
                if (node is Node)
                {
                    WriteAccept(node.Name);
                    WriteUpdateMethod(node as Node);
                }
            }
        }
        protected abstract void ReadOnly_Property(Field field);

        protected void WriteUpdateMethod(Node node)
        {
            if (!AllFields(node).Any()) return;
            var emitNew = (!Fields(node).Any()) && !(BaseType(node) is AbstractNode);
            Write_Update(node, emitNew);
        }

        #region "protected IEnumerable<...>"

        protected IEnumerable<TreeType> TypeAndBaseTypes(TreeType node)
        {
            var n = node;
            while (n != null)
            {
                yield return n;
                n = BaseType(n);
            }
        }
        protected IEnumerable<Field> AllFields(TreeType node)
        {
            return (node == null) ? Enumerable.Empty<Field>()
                                  : from t in TypeAndBaseTypes(node)
                                    from f in Fields(t)
                                    select f;
        }
        // AlwaysNull fields are those that have Null="Always" specified (possibly in an override).
        protected IEnumerable<Field> AllAlwaysNullFields(TreeType node)
            => from f in AllFields(node) where FieldNullHandling(node, f.Name) == NullHandling.Always select f;
        // Specifiable fields are those that aren't always null.
        protected IEnumerable<Field> AllSpecifiableFields(TreeType node)
            => from f in AllFields(node) where FieldNullHandling(node, f.Name) != NullHandling.Always select f;
        protected IEnumerable<Field> AllNodeOrNodeListFields(TreeType node) => AllFields(node).Where(field => IsDerivedOrListOfDerived("BoundNode", field.Type));
        protected IEnumerable<Field> AllTypeFields(TreeType node) => AllFields(node).Where(field => field.Type == "TypeSymbol");
        #endregion

        #region "Enumeration (Enums)"
        protected void E(string modifier, string name, string enumType, Action body)
            => $"{modifier} {Lang.Enum()} {name} {Lang.EnumBase(enumType)}".Output(_o).WithBody(body.Indented(_o,eolThenSuf:true),Lang.End_Enum.Output(_o))();

        protected void Write_Kinds_Enum()=>
            E( Lang.Friend(), "BoundKind", Lang.@byte(), Lang.GetCodeBlockBody(ApplyToTreeNodes((node, eolLast)
                =>_o.Write($"{Lang.FixKeyword(node.Name.StripBound())}{Lang.EnumStatementEnding}", eolLast))));
        #endregion

        protected abstract void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional);
        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected abstract void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic);
        protected abstract void Write_DebugAssert_Nulls(bool isROArray, Field field,bool eolLast);
        #region "protected virtual"
        protected abstract void CreateConstructor(string name);
        protected abstract void S(string modifier, string name, string[] parameters, Action body);
        protected abstract void F(string modifiers, string methodName, string[] parameters, string returns, Action basecall = null, Action body=null);

        protected abstract void WriteField(Field field, bool eol = true);
        protected abstract void WriteAccept(string name);
        protected virtual void Write_Update(Node node, bool emitNew)
        {
            Internals();

            void Internals()
            {
                var modifier = emitNew ? $" {Lang.@shadows()}" : "";
                F($"{Lang.@public()}{modifier}",
                  "Update",
                  AllSpecifiableFields(node).Select(field => Lang.NameAsType(field.Name, field.Type)).ToArray(),
                  node.Name,
                  null,
                  () =>
                    {
                        if (!AllSpecifiableFields(node).Any())
                            Return(Lang.@this(), false)();
                        else
                        {
                            IfThen(AndAlso(AllSpecifiableFields(node), field => $"({field.Name.ToCamelCase(Lang)} {WriteComparision(field)}"), Return(Lang.@this(), true));
                            NewDeclaration();
                            IfThen(() => $"{Lang.@this()}.WasCompilerGenerated", "result.SetWasCompilerGenerated()".Output(_o, true));
                            Return("result", false)();
                        };
                    });
            }
            void NewDeclaration()
            {
                var p = ParenList( new[] { $"{Lang.@this()}.Syntax" }.
                                   Concat(AllSpecifiableFields(node).Select(f => f.Name.ToCamelCase(Lang)).
                                   Concat(new[] { $"{Lang.@this()}.HasErrors" })));

                (Declaration("result") +" As "+ Invocation(node.Name, p)).Code(_o, true);
            }
            // Helpers
            void IfThen(Func<string> cmp, Action a) { $"{Lang.@if()} {cmp()} {Lang.@then()} ".Output(_o)(); a(); }

            string WriteComparision(Field field) => $"{(IsValueType(field.Type) ? $"=" : "Is")} {Lang.@this()}.{ field.Name})";
        }
        protected void Declaration(string prefix, string field, string typeName, string value, bool isNew, bool eol, int width = 0)
        {
            width = width <= 0 ? field.Length : width;
            var result = prefix ?? "";
            result += $" {Lang.NameAsType(field, typeName, isNew: isNew).PadLeft(width)}";
            if (value != null) result += $" = {value}";
            result.Output(_o, eol)();
        }
        protected abstract void WriteVisitor();

        protected void Friend_MustInherit_Partial_Class(string className, string genericParams, string inherits, Action body)
           => Lang.WriteClass(_o, $"{Lang.Friend()} {Lang.Abstract()} {Lang.Partial()}", className, genericParams, inherits, body);

        protected void WriteWalker()
        {
           Friend_MustInherit_Partial_Class("BoundTreeWalker", null, "BoundTreeVisitor", Internal());

            Action Internal()
                => _tree.Types.OfType<Node>().ForAll(null, (node, __)
                   => F($"{Lang.@public()} {Lang.@overrides()}", Visit(node), Parameters(NodeAs(node)).ToArray(), boundNode,
                      body:Visiting(node).__(Return(Lang.@null(), true))));

            Action Visiting(Node node)
                => AllFields(node).Where(f => IsDerivedOrListOfDerived(boundNode, f.Type) && !SkipInVisitor(f)).
                   ForAll(null, (field, __) =>
                   {
                       var member = IsNodeList(field.Type) ? "List" : "";
                       $"{Lang.@this()}.Visit{member}(node.{field.Name})".Code(_o, true);
                   });
        }
        protected abstract void WriteRewriter();
        protected abstract bool IsImmutableArray(string typeName);
        protected abstract bool IsNodeList(string typeName);
        protected abstract string GetGenericType(string typeName);
        protected abstract string GetElementType(string typeName);

        protected abstract void InitializeValueTypes(ref Dictionary<string, bool> _valueTypes);
        #endregion

        protected abstract void WriteTreeDumperNodeProducer();

        protected void WriteTreeDumperNodeProducer(string name, string arr)
        {
            Lang.WriteClass(_o, $"{Lang.Friend()} {Lang.Sealed()}", "BoundTreeDumperNodeProducer", genericParams: null,
                inherits: $"BoundTreeVisitor{Lang.Generics("Object, TreeDumperNode")}",
                body: () =>
                {
                    CreateConstructor(name);
                    Write_MakeTree();
                    Write_Functions();
                });

            void Write_Functions()
            {
                ApplyToTreeNodes((node, eolLast) => F($"{Lang.@public()} {Lang.@overrides()}", Visit(node),
                    Parameters(NodeAs(node), Lang.NameAsType("arg", "Object")).ToArray(), "TreeDumperNode", null,
                    Write_InnerTree(node)))();
            }

            Action Write_InnerTree(Node node) =>
            () => Return($"{Lang.New()} TreeDumperNode",false).__(
                InParens(() =>
                {
                    $"\"{UseAsVariableName(node.Name)}\", {Lang.@null()}, ".Output(_o)();
                    var allFields = AllFields(node).ToArray();
                    if (allFields.Length > 0)
                        BraceField(allFields);
                    else
                        $"Array.Empty{Lang.Generics("TreeDumperNode")}()".Output(_o)();
                })).Code(_o, true);

            void Write_MakeTree() =>
              F($"{Lang.@public()} {Lang.@shared()}", "MakeTree", Parameters(NodeAsBoundNode()), "TreeDumperNode", null,
              Return($"({Lang.@New()} BoundTreeDumperNodeProducer()).Visit(node, {Lang.@null()})",true));

            void BraceField(Field[] allFields)
            {
                TreeDumperNodeArray().Output(_o)();
                allFields.ForAll(null,
                (field, eolLast) =>
                {
                    $"{Lang.@New()} TreeDumperNode".Output(_o)();
                    InParens(WithField(field))();
                    if (eolLast)  ",".Output(_o)();
                    _o.EOL();
                }).Indented(_o, false).InBraces(_o)();
            }

            Action WithField(Field field)
                => () =>
                {
                    $"\"{_Field(field)}\", ".Output(_o)();
                    if (IsDerivedType(boundNode, field.Type))
                        $"{Lang.@null()}, {TreeDumperNodeArray()}{{ Visit({_node}.{field.Name}, {Lang.@null()}) }}".Output(_o)();
                    else if (IsListOfDerived(boundNode, field.Type))
                        $"{Lang.@null()}, {Lang.@from()} x {Lang.@In()} {_node}.{field.Name} {Lang.@Select()} Visit(x, {Lang.@null()})".Output(_o)();
                    else
                        $"node.{field.Name}, {Lang.@null()}".Output(_o)();
                };
            string TreeDumperNodeArray() => (arr != null)? $"{Lang.New()} {arr}" : String.Empty;
        }

        protected string _Field(Field field) => field.Name.ToCamelCase(Lang);
        protected string UseAsVariableName(string name) => name.StripBound().ToCamelCase(Lang);
        protected string NodeAsBoundNode() => Lang.NameAsType(_node, boundNode);
        protected string NodeAs(Node node) => Lang.NameAsType(_node, node.Name);
        protected string Visit(Node node)  => $"Visit{node.Name.StripBound()}";

        #region "protected bool"
        protected bool IsDerivedOrListOfDerived(string baseType, string derivedType) => IsDerivedType(baseType, derivedType) || IsListOfDerived(baseType, derivedType);
        protected bool IsListOfDerived(string baseType, string derivedType) => IsNodeList(derivedType) && IsDerivedType(baseType, GetElementType(derivedType));
        protected bool IsAnyList(string typeName) => IsNodeList(typeName);
        protected bool IsValueType(string typeName)
        {
            var genericType = GetGenericType(typeName);
            return (_valueTypes.TryGetValue(genericType, out var isValueType)) ? isValueType : false;
        }
        protected bool IsDerivedType(string typeName, string derivedTypeName)
        {
            if (typeName == derivedTypeName) return true;
            if (derivedTypeName != null && _typeMap.TryGetValue(derivedTypeName, out var baseType)) return IsDerivedType(typeName, baseType);
            return false;
        }
        protected bool IsNode(string typeName) => _typeMap.ContainsKey(typeName);
        #endregion
        #region "protected static"
        protected static IEnumerable<Field> Fields(TreeType node)
        {
            if (node is Node nn) return from n in nn.Fields where !n.Override select n;
            if (node is AbstractNode an) return from n in an.Fields where !n.Override select n;
            return Enumerable.Empty<Field>();
        }
        protected static IEnumerable<Field> FieldsIncludingOverrides(TreeType node)
        {
            if (node is Node n) return n.Fields;
            if (node is AbstractNode an) return an.Fields;
            return Enumerable.Empty<Field>();
        }
        protected static bool HasValidate(TreeType node)    => node.HasValidate != null && string.Compare(node.HasValidate, "true", true) == 0;
        protected static bool IsRoot(Node n)                => n.Root != null && string.Compare(n.Root, "true", true) == 0;
        protected static bool IsNew(Field f)                => f.New != null && string.Compare(f.New, "true", true) == 0;
        protected static bool IsPropertyOverrides(Field f)  => f.PropertyOverrides != null && string.Compare(f.PropertyOverrides, "true", true) == 0;
        protected static bool SkipInVisitor(Field f)        => f.SkipInVisitor != null && string.Compare(f.SkipInVisitor, "true", true) == 0;
        #endregion
    }
}
