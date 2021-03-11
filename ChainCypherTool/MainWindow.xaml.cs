using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChainCypherTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        private static MainWindow instance;
        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainWindow();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
        }
    }
}
