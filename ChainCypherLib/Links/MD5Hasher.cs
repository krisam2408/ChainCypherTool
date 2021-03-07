using ChainCypherLib.Exceptions;
using ChainCypherLib.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ChainCypherLib.Links
{
    public class MD5Hasher : IHashLink
    {
        public string Hash(string stringChain, out int key)
        {
            key = 15;
            Random ran = new();
            for (int i = 0; i < 10; i++)
                key = ran.Next(30) + 15;
            return Hash(stringChain, key);
        }

        public string Hash(string stringChain, int key)
        {
            if (string.IsNullOrWhiteSpace(stringChain))
                throw new WhiteChainException(nameof(stringChain));

            string output = string.Empty;
            using MD5 md5 = MD5.Create();
            for(int i = 0; i < key; i += 5)
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(stringChain));
                StringBuilder builder = new();
                foreach (byte b in data)
                    builder.Append(b.ToString("x2"));

                output = builder.ToString();
            }

            return output;
        }
    }
}
