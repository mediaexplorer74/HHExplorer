// Settings Page

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HHLibrary.Models;
using HHWebAuthenticator;
using HHWebAuthenticator.HH;
using Xamarin.Forms;
using Xamarin.Essentials;

// HHExplorer.Views namespace
namespace HHExplorer.Views
{

    // SettingsPage class
    public partial class SettingsPage : ContentPage
    {
        // init settings page 
        public SettingsPage()
        {
            InitializeComponent();
            if (!App.UserLogined)
            {
                // User not "logined" yet

                LoginBtn.Text = "Get user access token";
            }
            else
            {
                // User "logined"

                Debug.WriteLine("HH Access token: " + App.AccessToken);
                TBox1.Text = App.AccessToken; 

                LoginBtn.Text = "Forget user access token";
            }
        }//SettingsPage


        // handle access token saving...
        public async Task SaveTokenBtn_Clicked(Object sender, EventArgs e)
        {
            App.AccessToken = TBox1.Text;

            //store "accesstoken" settings
            Preferences.Set("accesstoken", App.AccessToken);

        }//SaveTokenBtn_Clicked


        // auth / login deals
        public async Task Login_Button_Clicked(Object sender, EventArgs e)
        {
            if (!App.UserLogined)
            {
                Debug.WriteLine("[i] Checkpoint 1");

                await StartHHAuthenticationAsync();

                Debug.WriteLine("[i] Checkpoint 2");

                if (App.UserLogined)
                {
                    //this.Title = "AT=" + App.AccessToken;
                    Debug.WriteLine("[i] User logined!");

                    LoginBtn.Text = "Forget user access token";

                    //await this.Navigation.PushAsync(new UserDetailsPage(),true);
                    TBox1.Text = App.AccessToken;

                    //store "accesstoken" settings
                    Preferences.Set("accesstoken", App.AccessToken);
                }
            }
            else
            {
                //Always logined. Log out...
                try
                {
                    Preferences.Remove("accesstoken");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[ex] Remove accesstoken problem: "
                      + ex.Message);
                }

                LoginBtn.Text = "Get user access token";
            }

        }//Login_Button_Clicked

        // HH Authentication
        async Task StartHHAuthenticationAsync()
        {
            WebAuthenticatorHandler authenticator = new WebAuthenticatorHandler();

            string _hhCode = await authenticator.FetchHHCode();

            HHResponseModel _tokenResponse = new HHResponseModel();

            if (!string.IsNullOrEmpty(_hhCode))
            {
                _tokenResponse =
                    await new HHAPIService().CallTokenAPIAsync(_hhCode);

                if (!string.IsNullOrEmpty(_tokenResponse.access_token))
                {
                    App.AccessToken = _tokenResponse.access_token;
                    App.UserLogined = true;

                    Debug.WriteLine($"HH access token : {_tokenResponse.access_token}");
                    HHConfiguration.TokenResponse = _tokenResponse;
                    //this.Navigation.PushAsync(new UserDetailsPage());
                    Debug.WriteLine("[i] All is ok when fetching token.");
                    //this.Navigation.PushAsync(new UserDetailsPage());
                }
                else
                {
                    Debug.WriteLine("[e] Error fetching token!!");
                    //this.Navigation.PushAsync(new UserDetailsPage());
                }
            }
            else
            {
                Debug.WriteLine("[e] Error fetching token!!");
            }

            // RnD: await 
            //await 
            //this.Navigation.PushAsync(new UserDetailsPage());

            //Debug.WriteLine("[i] We can not go to UserDetailsPage :(");

        }//StartHHAuthenticationAsync

    }//class end

}//namespace end
