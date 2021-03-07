using System;

namespace ChainCypherLib.Exceptions
{
    public class WhiteChainException:Exception
    {
        public WhiteChainException(string property):base($"Property {property} is null or whitespace.")
        {
            
        }
    }
}
