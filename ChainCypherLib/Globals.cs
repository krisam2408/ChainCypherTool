using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherLib
{
    internal static class Globals
    {
        internal readonly static string CypherKey = "keyChain.cyp";

        internal readonly static string Base = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public readonly static string Spectrum = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZçßñáàâäéèêëíìîïóòôöúùûüÇßÑÁÀÂÄÉÈÊËÍÌÎÏÓÒÔÖÚÙÛÜ @-_.:,;!¡?¿|#$~+*{}[]()<>/\\&\"'%=€°¬·ª´¨`^";
        internal readonly static string[] NumberChains = { "null", "eins", "zwei", "drei", "vier", "fünf", "sexs", "sieb", "acht", "neun" };
    }
}
