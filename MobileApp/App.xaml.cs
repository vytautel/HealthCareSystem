using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace MobileApp
{
    public partial class App : Application
    {
        private static Database db;

        public static Database MyDatabase
        {
            get
            {
                if (db == null)
                {
                    db = new Database();
                }
                return db;
            }

        }

        public App()
        {
            InitializeComponent();
            MainPage homePage = new MainPage();
            MainPage = homePage;
        }
    }
}
