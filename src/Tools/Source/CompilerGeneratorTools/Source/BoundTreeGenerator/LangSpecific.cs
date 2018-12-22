using System;
using System.Collections.Generic;
using System.Text;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{

    // This section contains all of the language keywords, constructs that can tailored for each language.
    public abstract class LangSpecific
    {
        public IndentedWriter _iw { get; set; }
        internal LangSpecific() { }

        #region "Pairs"
        #region "Braces"
        public string LBrace() => "{";
        public string RBrace() => "}";
        #endregion
        #region "Parenthesis"
        public string LParens() => "(";
        public string RParens() => ")";
        #endregion
        #endregion

        #region "Keywords"
        public abstract string @bool();
        public abstract string @internal();
        public abstract string @private();
        public abstract string @public();
        public abstract string @protected();
        public abstract string @optional();
        public abstract string @false();
        public abstract string InsideNamespace();
        public abstract string Friend();
        public abstract string @_nameof_();
        public abstract string Partial();
        public abstract string Abstract();
        public abstract string Sealed();
        public abstract string Namespace();
        public abstract string Class();
        public abstract string Enum();
        public abstract string OrElse();
        public abstract string AndAlso();
        public abstract string Imports();
        public abstract string Inherits();
        public abstract string Inherits(string inheritsFrom);
        public abstract string @return();
        public abstract string @override();
        public abstract string @overrides();
        public abstract string @shadows();
        public abstract string @shared();
        public abstract string @this();
        public abstract string @case();
        public abstract string @if();
        public abstract string @then();
        public abstract string @New();
        public abstract string @null();
        public abstract string @byte();
        public abstract string @from();
        public abstract string @In();
        public abstract string @Select();
        #endregion

        #region "Abstract Methods"
        public abstract string EnumBase(string baseType);
        public abstract string Attribute(string attribute);
        public abstract string CommentMarker();
        public abstract string Generics(string genericParams);
        public abstract string EscapeKeyword(string name);
        public abstract bool IsKeyword(string name);
        public abstract Func<string> MyBaseNew();
        public abstract string NameAsType(string name, string typename, bool isNew = false);
        public abstract string AsType(string typename, bool isNew = false);
        public abstract string @overridable();
        public abstract void WriteClass(IndentedWriter iw, string modifiers, string classname, string genericParams, string inherits, Action body);
        #endregion

        #region "Virtual Methods"
        public virtual Action GetCodeBlockBody(Action  body) => body;
        public virtual string EOS                   => null;
        public virtual string EnumStatementEnding   => null;
        public virtual string EndOfStatement        => null;
        public virtual string End_Enum              => string.Empty;
        public virtual string End_Namespace         => string.Empty;
        public virtual IEnumerable<string> ImportedNamespaces() => System.Linq.Enumerable.Empty<string>();
        #endregion

        protected void WriteClass(IndentedWriter iw, string modifiers, string classname, string genericParams, string inherits, Action body, Action endClass)
          => Exts.WithBody(
              () =>
              {
                  $"{modifiers} {Class()} {classname}".Output(_iw)();
                  if (genericParams != null) Generics(genericParams).Output(_iw)();
                  if (inherits      != null) Inherits(inherits).Output(_iw)();
                  iw.EOL();
              },
              body,
              endClass)();

        public void ImportNamespace(string nsName, IndentedWriter iw, bool eol) => $"{Imports()} {nsName}".Code(iw,eol);
        public string _NameOf(string name) => $"{{{@_nameof_()}({name})}}";
        public string FixKeyword(string name) => IsKeyword(name) ? EscapeKeyword(name) : name;
    }
}
