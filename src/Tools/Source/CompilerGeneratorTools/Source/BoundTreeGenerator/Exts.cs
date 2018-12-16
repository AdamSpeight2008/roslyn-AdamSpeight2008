using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    static partial class Exts
    {
        public static Action ForAll<T>(this IEnumerable<T> these, Action act, Action<T, bool> doThis)
        {
            return () =>
             {
                 var items = these.ToArray();
                 var edx = items.Length - 1;
                 if (edx < 0) return;
                 act?.Invoke();
                 for (var idx = 0; idx <= edx; idx++)
                     doThis(items[idx], idx < edx);
             };
        }
        public static Action NotUsed = () => { };

        public static Action WithBody(this Action pre, Action act, Action suf)
            =>() => { pre?.Invoke(); act?.Invoke(); suf?.Invoke(); };

        public static Action NewLined(this Action act, IndentedWriter iw, bool bottom = false)
            => WithBody(() => iw.EOL(), act, bottom ? () => iw.EOL() : NotUsed);

        #region "Code"
        public static void Code(this string code, IndentedWriter iw, bool eol)
            => Code(() => code, iw, eol);

        public static void Code(this Func<string> code, IndentedWriter iw, bool eol)
            => code().Output(iw).__(iw.Lang.EOS.Output(iw, eol))();
 
        #endregion

        public static Action __(this Action a, Action b) => () => { a(); b(); };

        public static Action Indented(this Action act, IndentedWriter iw, bool onNewLines = true, bool eolThenSuf = false)
            =>  iw.Indent().WithBody(onNewLines ?  act.NewLined(iw, eolThenSuf) : act, iw.Undent());
 
        public static Action InBraces(this Action content, IndentedWriter iw)
            => "{".Output(iw).WithBody(content.Indented(iw), "}".Output(iw));

        public static Action Output(this string text, IndentedWriter iw, bool eol = false)=>()=>iw.Write(text, eol);
        public static Action Output(this Func<string> text, IndentedWriter iw, bool eol = false) => Output(text(), iw, eol);

        public static string StripBound(this string name)
            => (name.StartsWith("Bound", StringComparison.Ordinal)) ? name.Substring(5) : name;
        public static string ToCamelCase(this string name, LangSpecific lang)
            => lang.FixKeyword(char.IsUpper(name[0]) ? char.ToLowerInvariant(name[0]) + name.Substring(1) : name);

    }

}
