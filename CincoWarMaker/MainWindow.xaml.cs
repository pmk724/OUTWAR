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

namespace CincoWarMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private static Session sess;

        public MainWindow()
        {
			Console.WriteLine("Oh, Hello!");
            InitializeComponent();
			Session sess = new Session();
        }

		/// <summary>
		/// Named DoStuff because I'm not really sure what I want to do yet
		/// Basically just making this method so I can await my calls without dealing with VS nagging me worse than my wife on trash night
		/// </summary>
		/// <returns></returns>
		private static async Task DoStuff()
		{
			await sess.Login();
			sess.OpenInBrowser();
		}
    }
}
