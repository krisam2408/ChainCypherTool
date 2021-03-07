using System;

namespace ChainCypherLib.Exceptions
{
    internal class WhiteChainException:Exception
    {
        internal WhiteChainException(string property):base($"Property {property} is null or whitespace.")
        {
            
        }
    }
}
