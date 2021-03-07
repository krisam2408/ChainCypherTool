using System;

namespace ChainCypherLib.Interfaces
{
    public interface IHashLink
    {
        string Hash(string stringChain, out int key);
        string Hash(string stringChain, int key);
        bool Verify(string stringChain, string hash, int key)
        {
            string secondHash = Hash(stringChain, key);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(hash, secondHash) == 0)
                return true;
            return false;
        }
    }
}
