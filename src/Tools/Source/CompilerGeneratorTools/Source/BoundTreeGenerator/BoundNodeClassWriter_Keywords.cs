// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoundTreeGenerator
{
    internal abstract partial class BoundNodeClassWriter
    {
        // This section contains all of the language keywords, constructs that can tailored for each language.
        protected void EOL() { _writer.WriteLine(""); _needsIndent = true; }
        protected string _NameOf(string name) => $"{{{@_nameof_()}({name})}}";
        
        #region "Keywords"
        protected abstract string @bool();
        protected abstract string @private();
        protected abstract string @public();
        protected abstract string @optional();
        protected abstract string @false();
        protected abstract string @protected();
        protected abstract string InsideNamespace();
        protected abstract void ImportsNamespaces();
        protected abstract string Friend();
        protected abstract string @_nameof_();
        protected abstract string Partial();
        protected abstract string Abstract();
        protected abstract string Sealed();
        protected abstract string Namespace();
        protected abstract string Class();
        protected abstract string Enum();
        protected abstract string OrElse();
        protected abstract string AndAlso();
        protected abstract string Imports();
        protected abstract string Inherits();
        protected abstract string @return();
        protected abstract string @overrides();
        protected abstract string @shadows();
        protected abstract string @shared();
        protected abstract string @this();
        protected abstract string @case();
        protected abstract string @if();
        protected abstract string @then();
        protected abstract string @New();
        protected abstract string @null();

        #endregion

        protected abstract string Attribute(string attribute);
        protected abstract string CommentMarker();
        protected abstract string Generics(string genericParams);
        protected abstract void WriteClass(string modifiers, string classname, string genericParams = null, string inherits = null, Action body = null);
        protected abstract string EscapeKeyword(string name);
        protected abstract bool IsKeyword(string name);

        protected virtual  string EnumStatementEnding() => null;
        protected virtual string EndOfStatement() => null;

        protected virtual Action Braced(Action content) => () => InBlock(LBrace(), content ?? NotUsed(), true,  RBrace())();
        protected virtual void End_Enum() { }
        protected virtual void End_Namespace() {}



    }
}
