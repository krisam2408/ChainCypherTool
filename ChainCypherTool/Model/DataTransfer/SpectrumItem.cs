using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherTool.Model.DataTransfer
{
    public class SpectrumItem
    {
        public string Character { get; set; }
        private string combination;
        public string Combination
        {
            get { return combination; }
            set
            {
                if (value.Length < 3)
                    combination = value;
            }
        }
    }
}
