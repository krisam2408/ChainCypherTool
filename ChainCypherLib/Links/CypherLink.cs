using ChainCypherLib.Exceptions;
using ChainCypherLib.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherLib.Links
{
    public class CypherLink
    {
        private List<string[]> Cypher { get; set; }

        private CypherLink() { }

        public static async Task<CypherLink> CreateAsync(string keyPath = null)
        {
            CypherLink link = new();
            KeyFactory factory = await KeyFactory.CreateAsync(keyPath);
            string[] baseCypher = factory.ReadKey();

            link.Cypher = new()
            {
                baseCypher,
                InversedLink(baseCypher),
                ModdedLink(baseCypher),
                baseCypher.Reverse().ToArray(),
                InversedLink(baseCypher).Reverse().ToArray(),
                ModdedLink(baseCypher).Reverse().ToArray()
            };

            return link;
        }

        public async Task<string> Encode(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));

            ValidateSpectrum(text);

            string code = string.Empty;
            text = text.Trim();
            int padLen = RoundUp(text.Length);
            text = text.PadRight(padLen);

            int ixi = 0;
            foreach(char ci in text)
            {
                int ixe = 0;
                foreach(char ce in Globals.Spectrum)
                {
                    if(ci == ce)
                    {
                        int ixo = Dim(ixi);
                        string glyph = Cypher[ixo][ixe];
                        code += glyph;
                        break;
                    }
                    ixe++;
                }
                ixi++;
            }

            string output = await Compress(code);
            return output;
        }

        public async Task<string> Decode(string code)
        {
            if(string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            string decompressedCode = await Decompress(code);

            ValidateBase(decompressedCode);

            string text = string.Empty;
            decompressedCode = decompressedCode.Trim();
            int textLen = decompressedCode.Length / 2;
            string[] codeChain = new string[textLen];
            for (int i = 0; i < textLen; i++)
                codeChain[i] = decompressedCode.Substring(i * 2, 2);

            int ixi = 0;
            foreach(string str in codeChain)
            {
                int ixe = 0;
                int ixo = Dim(ixi);
                foreach(char c in Globals.Base)
                {
                    if(codeChain[ixi] == Cypher[ixo][ixe])
                    {
                        text += Globals.Spectrum[ixe].ToString();
                        break;
                    }
                    ixe++;
                }
                ixi++;
            }

            return text.Trim();
        }

        private async static Task<string> Compress(string code)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(code);
            
            using MemoryStream msi = new(buffer);
            using MemoryStream mso = new ();
            using GZipStream gs = new(mso, CompressionLevel.Optimal);

            await msi.CopyToAsync(gs);

            byte[] output = msi.ToArray();

            return Convert.ToBase64String(output);
        }

        private async static Task<string> Decompress(string base64)
        {
            byte[] buffer = Convert.FromBase64String(base64);

            using MemoryStream msi = new(buffer);
            using MemoryStream mso = new();
            using GZipStream gs = new(msi, CompressionLevel.Optimal);

            await mso.CopyToAsync(gs);

            string output = Encoding.UTF8.GetString(mso.ToArray());
            return output;
        }

        private static void ValidateSpectrum(string text)
        {
            foreach (char c in text)
                if (!Globals.Spectrum.Contains(c))
                    throw new OutOfSpectrumException(c, Chains.Spectrum);
        }

        private static void ValidateBase(string code)
        {
            foreach (char c in code)
                if (!Globals.Base.Contains(c))
                    throw new OutOfSpectrumException(c, Chains.Base);
        }

        private static int Dim(int index)
        {
            if (index % 11 == 0) return 5;
            if (index % 7 == 0) return 4;
            if (index % 5 == 0) return 3;
            if (index % 3 == 0) return 2;
            if (index % 2 == 0) return 1;
            return 0;
        }

        private static int RoundUp(int num)
        {
            int revs = 2;
            do
            {
                num -= 5;
                revs++;
            } while (num >= 0);
            return revs * 5;
        }

        private static string[] InversedLink(string[] cypher)
        {
            return cypher.Select(ch => $"{ch[1]}{ch[0]}").ToArray();
        }

        private static string[] ModdedLink(string[] cypher)
        {
            List<string> output = new();

            for(int i=0; i < cypher.Length; i++)
            {
                string str = cypher[i];
                if (i % 2 == 0)
                    str = $"{cypher[i][1]}{cypher[i][0]}";
                output.Add(str);
            }

            return output.ToArray();
        }

    }
}
