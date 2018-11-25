// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoundTreeGenerator
{
    internal enum TargetLanguage
    {
        VB,
        CSharp
    }

    internal enum NullHandling
    {
        Allow,
        Disallow,
        Always,
        NotApplicable // for value types
    }

    public class UnexpectedTargetLanguage : ArgumentException
    {
        public UnexpectedTargetLanguage(string targetLanguage) : base("Unexpected target language", targetLanguage)  { }
    }

    internal abstract class BoundNodeClassWriter
    {
        protected int _indent;
        protected bool _needsIndent = true;
        protected Dictionary<string, bool> _valueTypes;
        protected readonly Tree _tree;
        protected readonly TextWriter _writer;
        protected readonly Dictionary<string, string> _typeMap;
        protected readonly TargetLanguage _targetLang;

        internal BoundNodeClassWriter(TextWriter writer, Tree tree, TargetLanguage targetLang)
        {
            _tree = tree;
            _writer = writer;
            _typeMap = tree.Types.Where(t => !(t is EnumType || t is ValueType)).ToDictionary(n => n.Name, n => n.Base);
            _typeMap.Add(tree.Root, null);
            _targetLang = targetLang;
            InitializeValueTypes();
        }

        public bool IsNodeOrNodeList(string typeName) => IsNode(typeName) || IsNodeList(typeName);

        protected TreeType BaseType(TreeType node)
        {
            string name = _typeMap[node.Name];
            if (name == _tree.Root) return null;
            return _tree.Types.Single(t => t.Name == name);
        }
        protected NullHandling FieldNullHandling(TreeType node, string fieldName)
        {
            Field f = GetField(node, fieldName);

            if (f.Null != null)
            {
                switch (f.Null.ToUpperInvariant())
                {
                    case "ALLOW": return NullHandling.Allow;
                    case "DISALLOW": return NullHandling.Disallow;
                    case "ALWAYS": return NullHandling.Always;
                    case "NOTAPPLICABLE": return NullHandling.NotApplicable;
                    case "": break;
                    default: throw new ArgumentException("Unexpected value", nameof(f.Null));
                }
            }

            if (f.Override)
                return FieldNullHandling(BaseType(node), fieldName);
            else if (!IsValueType(f.Type) || GetGenericType(f.Type) == "ImmutableArray")
                return NullHandling.Disallow; // default is to disallow nulls.
            else
                return NullHandling.NotApplicable;   // value types can't check nulls.
        }
        protected Field GetField(TreeType node, string fieldName)
        {
            var fieldsWithName = from f in FieldsIncludingOverrides(node) where f.Name == fieldName select f;
            if (fieldsWithName.Any())
                return fieldsWithName.Single();
            else if (BaseType(node) != null)
                return GetField(BaseType(node), fieldName);
            else
                throw new InvalidOperationException($"Field {fieldName} not found in type {node.Name}");
        }


        public static void Write(TextWriter writer, Tree tree, TargetLanguage targetLang)
        {
            switch (targetLang)
            {
                case TargetLanguage.CSharp: new BoundNodeClassWriter_CS(writer, tree).WriteFile(); break;
                case TargetLanguage.VB: new BoundNodeClassWriter_VB(writer, tree).WriteFile(); break;
                default:
                    throw new UnexpectedTargetLanguage(nameof(_targetLang));
            }
        }

        #region "protected void"

        protected void InitializeValueTypes()
        {
            _valueTypes = new Dictionary<string, bool>();
            foreach (ValueType t in _tree.Types.Where(t => t is ValueType))
                _valueTypes.Add(t.Name, true);
            InitializeValueTypes(ref _valueTypes);

            _valueTypes.Add("Int8", true);
            _valueTypes.Add("Int16", true);
            _valueTypes.Add("Int32", true);
            _valueTypes.Add("Int64", true);
            _valueTypes.Add("UInt8", true);
            _valueTypes.Add("UInt16", true);
            _valueTypes.Add("UInt32", true);
            _valueTypes.Add("UInt64", true);
            _valueTypes.Add("ImmutableArray", true);
            _valueTypes.Add("PropertyAccessKind", true);
        }
        protected void Write(string text)
        {
            if (_needsIndent)
            {
                _writer.Write(new string(' ', _indent * 4));
                _needsIndent = false;
            }
            _writer.Write(text);
        }
        protected void WriteLine( string text, bool afterBlankLine = false, bool undent = false, bool thenIndent = false, bool thenBlankLine = false )
        {
            if (afterBlankLine) {  Blank(); }
            if (undent)         { Undent(); }
            Write(text);
            _writer.WriteLine();
            _needsIndent = true;
            if (thenIndent)     { Indent(); }
            if (thenBlankLine)  {  Blank(); }
        }
        protected void Blank() { _writer.WriteLine(); _needsIndent = true; }
        protected void LBrace()  => WriteLine("{", thenIndent: true);
        protected void RBrace()  => WriteLine("}", undent: true);
        protected void LParens() => Write("(");
        protected void RParens() => Write(")");
        protected void Indent()  => ++_indent;
        protected void Undent()  => _indent = _indent > 0 ? (_indent - 1) : _indent;

        protected void WriteFile()
        {
            AutoGenerated();

            Blank();
            WriteUsing("System");
            WriteUsing("System.Collections");
            WriteUsing("System.Collections.Generic");
            WriteUsing("System.Collections.Immutable");
            WriteUsing("System.Diagnostics");
            WriteUsing("System.Linq");
            WriteUsing("System.Runtime.CompilerServices");
            WriteUsing("System.Threading");
            WriteUsing("System.Text");
            WriteUsing("Microsoft.CodeAnalysis.Collections");
            WriteUsing("Roslyn.Utilities");

            Blank();
            WriteStartNamespace();
            WriteKinds();
            WriteTypes();
            WriteVisitor();
            WriteWalker();
            WriteRewriter();
            WriteTreeDumperNodeProducer();
            End_Namespace();
        }
        protected void WriteTypes()
        {
            foreach (var node in _tree.Types.Where(n => !(n is PredefinedNode)))
            {
                WriteType(node);
            }
            Blank();
        }
        protected bool CanBeSealed(TreeType node)
        {
            // Is this type the base type of anything?
            return !_typeMap.Values.Contains(node.Name);
        }

        protected void SeparatedList<T>(string separator, IEnumerable<T> items, Func<T, string> func)
        {
            var first = true;
            foreach (T item in items)
            {
                if (!first) _writer.Write(separator);
                first = false;
                _writer.Write(func(item));
            }
        }
        protected void Comma<T>(IEnumerable<T> items, Func<T, string> func) => SeparatedList(", ", items, func);
        protected void ParenList<T>(IEnumerable<T> items, Func<T, string> func)
        {
            LParens();
            Comma(items, func);
            RParens();
        }
        protected void ParenList(IEnumerable<string> items)
        {
            LParens();
            Comma(items, x => x);
            RParens();
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
        // Write the null checks for any fields that can't be null.
        protected void WriteNullChecks(TreeType node)
        {
            var nullCheckFields = AllFields(node).Where(f => FieldNullHandling(node, f.Name) == NullHandling.Disallow);

            if (nullCheckFields.Any())
            {
                foreach (var field in nullCheckFields)
                {
                    var isROArray = (GetGenericType(field.Type) == "ImmutableArray");
                    Write_DebugAssert_Nulls(isROArray, field);
                }
            }
        }
        protected void WriteType(TreeType node)
        {
            if (!(node is AbstractNode) && !(node is Node)) return;
            Blank();
            WriteClassHeader(node);

            bool unsealed = !CanBeSealed(node);
            bool concrete = !(node is AbstractNode);
            bool hasChildNodes = AllNodeOrNodeListFields(node).Any();

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

            WriteClassFooter(node);
        }
        protected void WriteUpdateMethod(Node node)
        {
            if (!AllFields(node).Any()) return;
            bool emitNew = (!Fields(node).Any()) && !(BaseType(node) is AbstractNode);
            Write_Update(node, emitNew);
        }

        #endregion

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

        #region "protected virtual"

        protected virtual void Or<T>(IEnumerable<T> items, Func<T, string> func) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteConstructorWithHasErrors(TreeType node, bool isPublic, bool hasErrorsIsOptional) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        // This constructor should only be created if no node or list fields, since it just calls base class constructor
        // without merging hasErrors.
        protected virtual void WriteConstructorWithoutHasErrors(TreeType node, bool isPublic) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void AutoGenerated() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void Write_DebugAssert_Nulls(bool isROArray, Field field) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteClassHeader(TreeType node) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteClassFooter(TreeType node) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteUsing(string nsName) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteStartNamespace() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void End_Namespace() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual void WriteKinds() => throw new UnexpectedTargetLanguage(nameof(_targetLang));
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
        protected virtual void InitializeValueTypes(ref Dictionary<string, bool> _valueTypes) { }
        protected virtual string EscapeKeyword(string name) => throw new UnexpectedTargetLanguage(nameof(_targetLang));
        protected virtual bool IsKeyword(string name) => throw new UnexpectedTargetLanguage(nameof(_targetLang));

        #endregion

        #region "protected bool"
        protected bool IsDerivedOrListOfDerived(string baseType, string derivedType) => IsDerivedType(baseType, derivedType) || IsListOfDerived(baseType, derivedType);
        protected bool IsListOfDerived(string baseType, string derivedType) => IsNodeList(derivedType) && IsDerivedType(baseType, GetElementType(derivedType));
        protected bool IsAnyList(string typeName) => IsNodeList(typeName);
        protected bool IsValueType(string typeName)
        {
            string genericType = GetGenericType(typeName);
            return (_valueTypes.TryGetValue(genericType, out bool isValueType)) ? isValueType : false;
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
        protected string StripBound(string name) => (name.StartsWith("Bound", StringComparison.Ordinal)) ? name.Substring(5) : name;
        protected string ToCamelCase(string name) => FixKeyword(char.IsUpper(name[0]) ? char.ToLowerInvariant(name[0]) + name.Substring(1) : name);
        protected string FixKeyword(string name) => IsKeyword(name) ? EscapeKeyword(name) : name;
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
        protected static bool HasValidate(TreeType node) => node.HasValidate != null && string.Compare(node.HasValidate, "true", true) == 0;
        protected static bool IsRoot(Node n) => n.Root != null && string.Compare(n.Root, "true", true) == 0;
        protected static bool IsNew(Field f) => f.New != null && string.Compare(f.New, "true", true) == 0;
        protected static bool IsPropertyOverrides(Field f) => f.PropertyOverrides != null && string.Compare(f.PropertyOverrides, "true", true) == 0;
        protected static bool SkipInVisitor(Field f) => f.SkipInVisitor != null && string.Compare(f.SkipInVisitor, "true", true) == 0;
        #endregion
    }
}
