using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News
{
    public partial class App : Application
    {
        // Dirty code (draft)
        public static string AccessToken = "";
        public static bool UserLogined = false;

        public App()
        {
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
