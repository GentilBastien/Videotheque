using MaVideotheque.DatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MaVideotheque
{
    public partial class MainWindow : Window
    {
        //public static string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Users\basti\Desktop\MIASHS\M2\S9\MaVideotheque\App\Database.mdf;Integrated Security=True;Connect Timeout=30";
        //public static string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fbelh\source\repos\Videotheque\App\Database.mdf;Integrated Security=True;Connect Timeout=30";



        public MainWindow()
        {
            InitializeComponent();
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + projectDirectory + @"\Database.mdf;Integrated Security = True;";
        }
    }
}
