using ChainCypherTool.Model;
using ChainCypherTool.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ChainCypherTool.ViewModel
{
    public class NavigationViewModel:BaseViewModel
    {
        private ObservableCollection<string> navDestinations;
        public ObservableCollection<string> NavDestinations { get { return navDestinations; } set { SetValue(ref navDestinations, value); } }

        public NavigationViewModel()
        {
            NavDestinations = SetNavMenu();
        }

        private ObservableCollection<string> SetNavMenu()
        {
            ObservableCollection<string> output = new();
            Type type = typeof(Terminal);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo pi in props)
                if (pi.PropertyType.GetInterface("INavegable") == typeof(INavegable))
                    output.Add(pi.Name);
            return output;
        }
    }
}
