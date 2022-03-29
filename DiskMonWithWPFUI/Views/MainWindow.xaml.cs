
global using Microsoft.Diagnostics.Tracing.Parsers;
global using Microsoft.Diagnostics.Tracing.Session;
global using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
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
namespace DiskMonWithWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public static void ShowWindowError()
        {
            new Error().Show();
        }
        public MainWindow()
        {
            if(TraceEventSession.IsElevated() ?? false)
            {
                InitializeComponent();
            }
            else
            {
                ShowWindowError();
                this.Close();
            }
        }
    }
}
