// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoundTreeGenerator
{
    internal enum TargetLanguage { VB, CSharp }

    internal enum NullHandling
    {
        Allow,
        Disallow,
        Always,
        NotApplicable // for value types
    }

    public class UnexpectedTargetLanguage : ArgumentException
    {
        public UnexpectedTargetLanguage(string targetLanguage) : base("Unexpected target language", targetLanguage) { }
    }

    internal static class ext
    {
        public static void IfNonNull<T>(this T obj, Action<T> nonNull, Action isNull = null)
            where T : class
        {
            if (obj != null) nonNull(obj); else isNull?.Invoke();
        }
        public static Action __(this Action x, Action y ) => () =>{ x(); y(); };
    }

    internal abstract partial class BoundNodeClassWriter
    {
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

        protected TreeType BaseType(TreeType node) => (_typeMap[node.Name] != _tree.Root) ? (_tree.Types.Single(t => t.Name == _typeMap[node.Name])) : null;

        protected NullHandling FieldNullHandling(TreeType node, string fieldName)
        {
            var f = GetField(node, fieldName);

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

        internal static void Write(TextWriter writer, Tree tree, TargetLanguage targetLang)
        {
            switch (targetLang)
            {
                case TargetLanguage.CSharp: new BoundNodeClassWriter_CS(writer, tree).WriteFile(); break;
                case TargetLanguage.VB: new BoundNodeClassWriter_VB(writer, tree).WriteFile(); break;
                default: throw new UnexpectedTargetLanguage(nameof(_targetLang));
            }
        }

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
        protected void Write_Modifier(string text)=> text.IfNonNull((txt) => Write($"{txt} "));

        protected void Write(string text)
        {
            if (_needsIndent) WriteIndent();
            _writer.Write(text);
        }

        #region "Common"
        protected Action NotUsed() => () => { };
        protected void Blank() => Statement("",false);
        protected Action LBrace() => () => Write("{");
        protected Action RBrace() => () => Write("}");

        #region "Parenthesis"
        protected Action LParens() => () => Write("(");
        protected Action RParens() => () => Write(")");
        protected Action Parens(Action a, bool eol = false) => InBlock(LParens(), a, false, ()=>{ RParens()(); if (eol) EOL(); });
        #endregion

        #endregion

        #region "Indentation Handling"
        private int _indent;
        private bool _needsIndent = true;
        protected virtual int IndentSize() => 4;
        void WriteIndent() { _writer.Write(new string(' ', _indent * IndentSize())); _needsIndent = false; }
        protected int MaxIndent() => int.MaxValue - IndentSize();
        protected void Indent() => _indent = _indent < MaxIndent() ? (_indent + 1) : _indent;
        protected void Undent() => _indent = _indent > 0 ? (_indent - 1) : _indent;
        protected void Indented(Action body) => InBlock(Indent, body, false, Undent)();
        #endregion

        #region "Statement Handling"
        protected void Statement(string statement, bool eol=true, bool includeEnding = true)
        {
            Write(statement);
            if (includeEnding) EndOfStatement().IfNonNull(Write);           
            if (eol) EOL();
        }
        protected void Return(string text, bool eol = true) => Statement($"{@return()} {text}", eol);
        #endregion

        protected void Comment(string commentText) => Statement($"{CommentMarker()} {commentText}",false);
        protected void AutoGenerated() => Comment(XMLNode("auto-generated"));

        protected string XMLNode(string name) => $"< {name} />";
        
        
        protected string Inherits(string inheritsFrom) => $" : {Inherits()}{inheritsFrom}";

        #region "Imports and Namespace"
        protected void ImportNamespace(string nsName) => Statement($"{Imports()} {nsName}");

        protected void ImportNamespaces(params string[] namespaces){foreach (var ns in namespaces) ImportNamespace(ns);}

        private void CommonImports()=>ImportNamespaces(
            "System", "System.Collections", "System.Collections.Generic","System.Collections.Immutable",
            "System.Diagnostics", "System.Linq","System.Runtime.CompilerServices","System.Threading","System.Text",
            "Microsoft.CodeAnalysis.Collections","Roslyn.Utilities");

        protected virtual void InsideNamespace(string ns, Action body)=> InBlock(() => Statement($"{Namespace()} {ns}",true,false), body, false, () => End_Namespace())();
        #endregion

        protected void WriteFile()
        {
            AutoGenerated();
            Blank();
            CommonImports();
            ImportsNamespaces();
            InsideNamespace(InsideNamespace(),
                () =>
                {
                    Blank();
                    Write_Kinds_Enum();
                    WriteTypes();
                    WriteVisitor();
                    WriteWalker();
                    WriteRewriter();
                    WriteTreeDumperNodeProducer();
                });
        }
        protected void WriteTypes()
        {
            foreach (var node in _tree.Types.Where(n => !(n is PredefinedNode)))
                WriteType(node);
            Blank();
        }

 
        protected Action InBlock(Action header, Action body, bool indented, Action footer = null)
        {
            return () =>
            {
                header();
                if (indented) { Indented(body); } else { body(); };
                footer?.Invoke();
            };
        }

        protected string[] Parameters(params string[] parameters) => parameters;

        protected void WriteClass(string modifiers, string classname, string genericParams, string inherits, Action body, Action endClass, bool indentBody)
        {
            InBlock(
                () =>
                {
                    Write($"{modifiers} {Class()} {classname}");
                    if (genericParams != null) Write(Generics(genericParams));
                    if (inherits != null) Write(Inherits(inherits));
                    EOL();
                },
                body ?? NotUsed(),
                indentBody, endClass ?? NotUsed())();
        }
        protected bool CanBeSealed(TreeType node) => !_typeMap.Values.Contains(node.Name);  // Is this type the base type of anything?
        protected string OutIsPublic(bool isPublic) => isPublic ? @public() : @protected();

        #region "Seperated Content Helpers"
        protected void SeparatedList<T>(string separator, IEnumerable<T> items, Func<T, string> func)
        {
            var first = true;
            foreach (var item in items)
            {
                if (!first) _writer.Write(separator);
                first = false;
                _writer.Write(func(item));
            }
        }
        protected void Comma<T>(IEnumerable<T> items, Func<T, string> func) => SeparatedList(", ", items, func);
        protected void ParenList<T>(IEnumerable<T> items, Func<T, string> func)
        {
            Parens(() => { if (items != null) Comma(items, func); })();
        }
        protected void ParenList(IEnumerable<string> items) => ParenList(items, x => x);
        #endregion

        #region "Parameter"
        protected abstract string NameAsType(string name, string typename, bool isNew = false);
        protected string Parameter(string name, string typeName) => NameAsType(ToCamelCase(name), typeName);

        protected IEnumerable<string> OutputFirstParameters(bool isPublic)
        {
            if (!isPublic) yield return NameAsType("kind", "BoundKind");
            yield return NameAsType("syntax", "SyntaxNode");
        }
        #endregion

    }
}
