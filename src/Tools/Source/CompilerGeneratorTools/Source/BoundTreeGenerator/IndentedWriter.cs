using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    public sealed class IndentedWriter : IDisposable
    {
        public void Dispose() => _writer.Dispose();
 
        private readonly int _levelSize;
        private readonly int _maxLevel;
        private bool _NeedsIndent = true;
        private readonly TextWriter _writer;
        private int _indent = 0;
        public LangSpecific Lang { get; set; }

        internal IndentedWriter(int levelSize, TextWriter writer)
        {
            if (levelSize < 0) { _levelSize = 0; } else { _levelSize = levelSize; }
            _maxLevel = int.MaxValue - _levelSize;
            _writer = writer;
        }
        public void Blank()
        {
            if (_NeedsIndent) EOL();
            //EOL();
        }
        public Action Undent() =>
            () =>
            {
                _indent -= _indent > 0 ? _levelSize : 0;
                _writer.Flush();
                _NeedsIndent = _indent > 0;
            };

        public Action Indent() =>
            () =>
            {
                _indent += _indent < _maxLevel ? _levelSize : 0;
                _writer.Flush();
                _NeedsIndent = _indent > 0;
            };

        public void EOL() => Write(null, true);
        public void Write(string text, bool eol)
        {
            var notEmpty = !string.IsNullOrEmpty(text);
            if (notEmpty && _NeedsIndent)  _writer.Write(new string(' ', _indent));
            if (notEmpty) _writer.Write(text);
            if (eol) _writer.WriteLine();
            _NeedsIndent = eol;
            _writer.Flush();
        }
    }

}
