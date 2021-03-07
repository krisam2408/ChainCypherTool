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
        private readonly string @base = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int BaseLength {  get { return @base.Length; } }
        private readonly string spectrum = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZçßñáàâäéèêëíìîïóòôöúùûüÇßÑÁÀÂÄÉÈÊËÍÌÎÏÓÒÔÖÚÙÛÜ @-_.:,;!¡?¿|#$~+*{}[]()<>/\\&\"'%=€°¬·ª´¨`^";
        private int SpectrumLength { get { return spectrum.Length; } }

        public string GenerateMockKey()
        {
            string[] mockCypher =
            {
                "ag", "bc", "ca", "db", "ek", "fa", "gv", "hc", "ik", "js", "kr", "le", "mi", "nc", "oo", "pi", "qp", "rt", "sw", "tp", "uw", "vl", "wq", "xs", "yt", "za",
                "as", "be", "ct", "gn", "df", "hh", "jr", "mq", "qa", "yu", "it", "zz", "nf", "iy", "pc", "ps", "az", "ob", "ec", "rd", "aa", "er", "tf", "op", "po", "ew",
                "tt", "qw", "pl", "dr", "cd", "fr", "sx", "ji", "ru", "rs", "de", "dg", "xx", "cs", "bg", "gb", "km", "cm", "uu", "ul", "li", "vf",
                "va", "gr", "hy", "ok", "nm", "ti", "kt", "wx", "yz", "pn", "ku", "lo", "pu", "co", "bb", "yy", "sd", "hd", "uj", "ko", "we", "ey",
                "aq", "xa", "xo", "ss", "mn", "fv", "fg", "fj", "pb", "ar", "xc", "zc", "sc", "bv", "kj", "zg", "zu", "xu", "iu", "oi", "io", "ir", "or", "ll", "eq", "eu", "jk", "ln",
                "us", "os", "dv", "dw", "wh", "wr", "ny", "bs", "zv", "zm",
                "yh", "yo", "zh", "wy", "re", "ph", "qs", "jt"
            };

            return GenerateKey(mockCypher);
        }

        public string GenerateRandomKey()
        {
            List<string> cypherArray = new();
            Random ran = new();

            int i = 0;
            while(i < BaseLength)
            {
                string cc = string.Empty;
                for(int e = 0; e < 2; e++)
                {
                    int y = ran.Next(BaseLength);
                    cc += @base[y];
                }
                if(!cypherArray.Contains(cc))
                {
                    cypherArray.Add(cc);
                    i++;
                }
            }

            return GenerateKey(cypherArray.ToArray());
        }

        public string GenerateKey(string[] cypher)
        {
            if (cypher.Length != SpectrumLength)
                throw new OutOfSpectrumException(SpectrumLength-cypher.Length);

            string compresedCypher = string.Empty;
            foreach (string cy in cypher)
                compresedCypher += cy;

            return GenerateKey(compresedCypher);
        }

        private string GenerateKey(string cypher)
        {
            if (cypher.Length != (SpectrumLength * 2))
            {
                double calc = ((SpectrumLength * 2) - cypher.Length) / 2;
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

            return byteKey;
        }

        public async Task WriteKey(string byteKey)
        {
            string filename = Globals.CypherKey;
            string path = Path.GetFullPath(filename);
            await File.WriteAllTextAsync(path, byteKey);
        }
    }
}
