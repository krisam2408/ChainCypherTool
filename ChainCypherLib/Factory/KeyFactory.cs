using ChainCypherLib.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherLib.Factory
{
    public class KeyFactory
    {
        private string ByteKey { get; set; }

        public KeyFactory() { ByteKey = null; }

        public KeyFactory(string byteKey)
        {
            string[] parts = byteKey.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length == Globals.Spectrum.Length)

            ByteKey = byteKey;
        }

        public static async Task<KeyFactory> CreateAsync(string keyPath)
        {
            string filename = Globals.CypherKey;
            string path = Path.GetFullPath(filename);
            string content = await File.ReadAllTextAsync(path);
            byte[] byteArray = content.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(b => byte.Parse(b)).ToArray();
            string byteKey = Encoding.UTF8.GetString(byteArray);
            throw new NotImplementedException();
        }

        public void GenerateRandomKey()
        {
            List<string> cypherArray = new();
            Random ran = new();

            int i = 0;
            while(i < Globals.Spectrum.Length)
            {
                string cc = string.Empty;
                for(int e = 0; e < 2; e++)
                {
                    int y = ran.Next(Globals.Base.Length);
                    cc += Globals.Base[y];
                }
                if(!cypherArray.Contains(cc))
                {
                    cypherArray.Add(cc);
                    i++;
                }
            }

            GenerateKey(cypherArray.ToArray());
        }

        public void GenerateKey(string[] cypher)
        {
            if (cypher.Length != Globals.Spectrum.Length)
                throw new OutOfSpectrumException(Globals.Spectrum.Length - cypher.Length);

            string compresedCypher = string.Empty;
            foreach (string cy in cypher)
                compresedCypher += cy;

            GenerateKey(compresedCypher);
        }

        private void GenerateKey(string cypher)
        {
            if (cypher.Length != (Globals.Spectrum.Length * 2))
            {
                double calc = ((Globals.Spectrum.Length * 2) - cypher.Length) / 2;
                int offset = (int)Math.Ceiling(calc);
                throw new OutOfSpectrumException(offset);
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(cypher);
            string byteKey = string.Empty;

            int i = 0;
            int l = byteArray.Length - 1;
            foreach(byte b in byteArray)
            {
                byteKey += b.ToString();
                if (i < l)
                    byteKey += " ";
                i++;
            }

            ByteKey = byteKey;
        }

        public async Task WriteKey()
        {
            string filename = Globals.CypherKey;
            string path = Path.GetFullPath(filename);
            await File.WriteAllTextAsync(path, ByteKey);
        }

        public string[] ReadKey()
        {
            throw new NotImplementedException();
        }

        public static string[] GetSpectrum()
        {
            List<string> output = new();
            foreach (char c in Globals.Spectrum)
                output.Add(c.ToString());
            return output.ToArray();
        }
    }
}
