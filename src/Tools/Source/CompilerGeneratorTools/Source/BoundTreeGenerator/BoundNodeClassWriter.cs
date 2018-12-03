// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoundTreeGenerator
{
    internal abstract partial class BoundNodeClassWriter
    {

        protected string[] SubMewParameters(TreeType node, bool isPublic, bool? hasErrorsIsOptional = default(bool?))
        {
            var fields = OutputFirstParameters(isPublic).Concat(from field in AllSpecifiableFields(node) select Parameter(field.Name, field.Type));
            if (hasErrorsIsOptional.HasValue) { Include_HasError(); };
            return fields.ToArray();

            void Include_HasError()
            {
                var param = NameAsType("hasErrors", @bool());
                if (hasErrorsIsOptional.Value)
                    fields = fields.Concat(new[] { $"{@optional()} {param} = {@false()}" });
                else
                    fields = fields.Concat(new[] { param });
            }
        }

        protected void WriteConstructor(TreeType node, bool isPublic, bool hasChildNodes)
        {
            if (hasChildNodes)
            {
                WriteConstructorWithHasErrors(node, isPublic, hasErrorsIsOptional: true);
            }
            else
            {
                WriteConstructorWithHasErrors(node, isPublic, hasErrorsIsOptional: false);
                WriteConstructorWithoutHasErrors(node, isPublic);
            }
        }

        protected void WriteNullChecks(TreeType node)
        {
            // Write the null checks for any fields that can't be null.
            var nullCheckFields = AllFields(node).Where(f => FieldNullHandling(node, f.Name) == NullHandling.Disallow);
            if (!nullCheckFields.Any()) return;
            foreach (var field in nullCheckFields)
            {
                var isROArray = (GetGenericType(field.Type) == "ImmutableArray");
                Write_DebugAssert_Nulls(isROArray, field);
            }
        }

        protected Action ApplyToTreeNodes(Action<Node> a) => () => { foreach (var node in _tree.Types.OfType<Node>()) { a(node); } };

        protected string _GetModifiers(TreeType node) => (node is AbstractNode) ? $"{Abstract()} " : CanBeSealed(node) ? $"{Sealed()} " : "";

        protected void WriteType(TreeType node)
        {
            if (!(node is AbstractNode) && !(node is Node)) return;
            Blank();
            WriteClass($"{Friend()} {_GetModifiers(node)}{Partial()}",node.Name,null,  node.Base,
                () =>
                {
                    var unsealed = !CanBeSealed(node);
                    var concrete = !(node is AbstractNode);
                    var hasChildNodes = AllNodeOrNodeListFields(node).Any();

                    if (unsealed) WriteConstructor(node, false, hasChildNodes);
                    if (concrete) WriteConstructor(node, true, hasChildNodes);
                    var _fields = Fields(node).ToList();
                    if (_fields.Count > 0)
                    {
                        foreach (var field in Fields(node))
                            WriteField(field);
                        Blank();
                    }
                    if (node is Node)
                    {
                        WriteAccept(node.Name);
                        WriteUpdateMethod(node as Node);
                    }
                });
        }
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
        protected IEnumerable<Field> AllAlwaysNullFields(TreeType node) => from f in AllFields(node) where FieldNullHandling(node, f.Name) == NullHandling.Always select f;
        // Specifiable fields are those that aren't always null.
        protected IEnumerable<Field> AllSpecifiableFields(TreeType node) => from f in AllFields(node) where FieldNullHandling(node, f.Name) != NullHandling.Always select f;
        protected IEnumerable<Field> AllNodeOrNodeListFields(TreeType node) => AllFields(node).Where(field => IsDerivedOrListOfDerived("BoundNode", field.Type));
        protected IEnumerable<Field> AllTypeFields(TreeType node) => AllFields(node).Where(field => field.Type == "TypeSymbol");
        #endregion

        #region "Enumeration (Enums)"
        protected void E(string modifier, string name, string enumType, Action body) =>
            Indented(InBlock(() => Statement($"{modifier} {Enum()} {NameAsType(name, enumType)}",true,false), body, true, footer: () => End_Enum()));

        protected void Write_Kinds_Enum() => E(Friend(), "BoundKind", "System.Byte",
            ApplyToTreeNodes(node => Statement($"{FixKeyword(StripBound(node.Name))}{EnumStatementEnding()}",true,false)));
        #endregion

        protected void Or<T>(IEnumerable<T> items, Func<T, string> func) => SeparatedList($" {OrElse()} ", items, func);
        protected void AndAlso<T>(IEnumerable<T> items, Func<T, string> func) => SeparatedList($" {AndAlso()} ", items, func);

        protected virtual void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected abstract void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic);
        protected abstract void Write_DebugAssert_Nulls(bool isROArray, Field field);
       #region "protected virtual"

        protected virtual void WriteField(Field field) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteAccept(string name) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void Write_Update(Node node, Boolean emitNew) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteVisitor() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteWalker() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteTreeDumperNodeProducer() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteRewriter() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual bool IsImmutableArray(string typeName) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual bool IsNodeList(string typeName) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual string GetGenericType(string typeName) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual string GetElementType(string typeName) => throw new UnexpectedTargetLanguage(nameof(_targetLang));


        protected abstract void InitializeValueTypes(ref Dictionary<string, bool> _valueTypes);
        #endregion

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

        #region "protected string"
        protected string StripBound(string name)    => (name.StartsWith("Bound", StringComparison.Ordinal)) ? name.Substring(5) : name;
        protected string ToCamelCase(string name)   => FixKeyword(char.IsUpper(name[0]) ? char.ToLowerInvariant(name[0]) + name.Substring(1) : name);
        protected string FixKeyword(string name)    => IsKeyword(name) ? EscapeKeyword(name) : name;
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
