using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HHLibrary.Models;
using HHWebAuthenticator;
using HHWebAuthenticator.HH;
using HHWebAuthenticator.Views;
using Xamarin.Forms;

namespace News.Views
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            this.Title = "Login";
        }

        public async Task Login_Button_Clicked(Object sender, EventArgs e)
        {
            Debug.WriteLine("[i] Checkpoint 1");
            await StartHHAuthenticationAsync();

            Debug.WriteLine("[i] Checkpoint 2");
            //RnD
            if (App.UserLogined)
            {
                this.Title = "AT=" + App.AccessToken;
                Debug.WriteLine("[i] User logined!");
                //await this.Navigation.PushAsync(new UserDetailsPage(),true);
                await this.Navigation.PushAsync(new UserDetailsPage(),true);
            }
            return;
        }

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
                Debug.WriteLine("[i] Login (scheme A) failed , try plan B");

                //_tokenResponse.access_token 
                //    = "P22U04L64BJF7M071R0DRON4A5Q5BIKE8LOUIEDD52R9R74H117L1S9SHUELEDNC";
                //_tokenResponse.expires_in = 10000;
                //_tokenResponse.refresh_token = "";
                //this.Navigation.PushAsync(new UserDetailsPage());
            }

            // RnD: await 
            //await 
            //this.Navigation.PushAsync(new UserDetailsPage());

            Debug.WriteLine("[i] We can not go to UserDetailsPage :(");
        }

    }
}
