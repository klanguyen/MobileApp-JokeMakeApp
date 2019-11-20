using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JokeMakerApp
{
    public class App : Application
    {
        static JokeMakerDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryBlue", Color.FromHex("27AEE3"));
            Resources.Add("primaryDarkBlue", Color.FromHex("2E77BB"));

            var nav = new NavigationPage(new JokeMakerListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryBlue"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static JokeMakerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new JokeMakerDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "JokeMakerSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtJokeId { get; set; }
    }
}

