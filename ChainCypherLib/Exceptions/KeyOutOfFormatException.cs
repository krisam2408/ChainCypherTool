using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherLib.Exceptions
{
    internal class KeyOutOfFormatException:Exception
    {
        internal KeyOutOfFormatException():base("Key is out of format") { }
    }
}
