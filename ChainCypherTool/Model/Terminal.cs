using ChainCypherTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainCypherTool.Model
{
    public class Terminal
    {
        public KeyViewModel Key { get; set; }
        public NavigationViewModel Navigation { get; set; }

        private static Terminal instance;
        public static Terminal Instance
        {
            get
            {
                if (instance == null)
                    instance = new();
                return instance;
            }
        }


        private Terminal()
        {
            Key = new();
            Navigation = new();
        }
    }
}
