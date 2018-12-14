using System;
using System.Collections.Generic;
using System.Text;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    public class UnexpectedTargetLanguage : ArgumentException
    {
        public UnexpectedTargetLanguage(string targetLanguage) : base("Unexpected target language", targetLanguage) { }

    }
}
