using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherLib.Links
{
    public class CypherLink
    {
        private string[] cypherBase;

        private CypherLink() { }

        public static async Task<CypherLink> CreateAsync()
        {
            CypherLink link = new();
            string filename = Globals.CypherKey;
            string path = Path.GetFullPath(filename);
            string content = await File.ReadAllTextAsync(path);
            byte[] byteArray = content.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(b => byte.Parse(b)).ToArray();
            string byteKey = Encoding.UTF8.GetString(byteArray);

            return link;
        }

    }
}
