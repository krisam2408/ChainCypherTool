using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherLib.Exceptions
{
    internal class OutOfSpectrumException:Exception
    {
        public OutOfSpectrumException(char unsupportedChar, Chains chain) : base(chain == Chains.Spectrum ? $"{unsupportedChar} is not a supported character for encoding." : $"{unsupportedChar} is not a supported character for decoding.") { }
        public OutOfSpectrumException(int cypherOffset) : base($"Given cypher is {cypherOffset} elements off of spectrum.") { }
    }
}
