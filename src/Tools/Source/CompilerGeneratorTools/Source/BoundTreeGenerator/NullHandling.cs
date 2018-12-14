using System;
using System.Collections.Generic;
using System.Text;

namespace Roslyn.Compilers.Internal.BoundTreeGenerator
{
    internal enum NullHandling
    {
        Allow,
        Disallow,
        Always,
        NotApplicable // for value types
    }

}
