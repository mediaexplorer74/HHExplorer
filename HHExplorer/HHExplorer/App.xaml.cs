using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace News
{
    public partial class App : Application
    {
        // Dirty code (draft)
        public static string AccessToken = "";
        public static bool UserLogined = false;

        public App()
        {
            // try to get (restore) "accesstoken" settings
            string accesstoken = Preferences.Get("accesstoken", "");
            if (accesstoken != "")
            {
                AccessToken = accesstoken;
                UserLogined = true;
            }

            InitializeComponent();

            MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
