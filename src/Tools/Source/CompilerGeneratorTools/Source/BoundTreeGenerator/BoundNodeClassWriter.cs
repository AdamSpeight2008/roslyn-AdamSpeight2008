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

        //protected static Func<string> NullFunc = () => null;
        protected static Action NotUsed = () => { };

        protected string[] SubMewParameters(TreeType node, bool isPublic, bool? hasErrorsIsOptional = default(bool?))
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
            nullCheckFields.ForAll(null,
                (field, eolLast) =>
                {
                    var isROArray = (GetGenericType(field.Type) == "ImmutableArray");
                    Write_DebugAssert_Nulls(isROArray, field, eolLast);
                })();
        }
        protected Action ApplyToTreeNodes(Action<Node,bool> a) => _tree.Types.OfType<Node>().ForAll(null, a);

        protected string _GetModifiers(TreeType node) =>
            (node is AbstractNode) ? $"{Lang.Abstract()} " : CanBeSealed(node) ? $"{Lang.Sealed()} " : "";

        protected void WriteType(TreeType node)
        {
            if (!(node is AbstractNode) && !(node is Node)) return;
            _o.Blank();
            Lang.WriteClass(_o, $"{Lang.Friend()} {_GetModifiers(node)}{Lang.Partial()}", node.Name, null, node.Base, Internals);

            void Internals()
            {
                var unsealed = !CanBeSealed(node);
                var concrete = !(node is AbstractNode);
                var hasChildNodes = AllNodeOrNodeListFields(node).Any();

                if (unsealed) WriteConstructor(node, false, hasChildNodes);
                if (concrete) WriteConstructor(node, true, hasChildNodes);
                var _fields = Fields(node).ToList();
                if (_fields.Count > 0)
                    foreach (var field in Fields(node))  WriteField(field);
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
        protected IEnumerable<Field> AllAlwaysNullFields(TreeType node) => from f in AllFields(node) where FieldNullHandling(node, f.Name) == NullHandling.Always select f;
        // Specifiable fields are those that aren't always null.
        protected IEnumerable<Field> AllSpecifiableFields(TreeType node) => from f in AllFields(node) where FieldNullHandling(node, f.Name) != NullHandling.Always select f;
        protected IEnumerable<Field> AllNodeOrNodeListFields(TreeType node) => AllFields(node).Where(field => IsDerivedOrListOfDerived("BoundNode", field.Type));
        protected IEnumerable<Field> AllTypeFields(TreeType node) => AllFields(node).Where(field => field.Type == "TypeSymbol");
        #endregion

        #region "Enumeration (Enums)"
        protected void E(string modifier, string name, string enumType, Action body) =>
            Exts.Body(
                pre: $"{modifier} {Lang.Enum()} {name} {Lang.EnumBase(enumType)}".Output(_o),
                act: body.Indented(_o),
                suf: Lang.End_Enum().Output(_o),
                iw: _o);

        protected void Write_Kinds_Enum()=>
            E( Lang.Friend(), "BoundKind", Lang.@byte(),
               Lang.GetCodeBlockBody(ApplyToTreeNodes(
                    (node, eolLast) => _o.Write($"{Lang.FixKeyword(node.Name.StripBound())}{Lang.EnumStatementEnding()}", eolLast)))
             );
 
        #endregion


        protected abstract void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional);
        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected abstract void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic);
        protected abstract void Write_DebugAssert_Nulls(bool isROArray, Field field,bool eolLast);
       #region "protected virtual"

        protected abstract void WriteField(Field field);
        protected abstract void WriteAccept(string name);
        protected abstract void Write_Update(Node node, bool emitNew);
        protected abstract void WriteVisitor();
        protected abstract void WriteWalker();
        protected abstract void WriteTreeDumperNodeProducer();
        protected abstract void WriteRewriter();
        protected abstract bool IsImmutableArray(string typeName);
        protected abstract bool IsNodeList(string typeName);
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
