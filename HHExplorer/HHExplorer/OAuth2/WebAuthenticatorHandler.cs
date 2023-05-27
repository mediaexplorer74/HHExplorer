using System;
using System.Threading.Tasks;
using HHWebAuthenticator.HH;
using System.Diagnostics;
using Xamarin.Essentials;

namespace HHWebAuthenticator
{
    public class WebAuthenticatorHandler
    {
        public async Task<string> FetchHHCode()
        {
            string code = "";
            try
            {
                Uri callbackUrl = new Uri(HHConfiguration.Callback);

                Uri loginUrl = new Uri(HHServices.BuildAuthenticationUrl());

                WebAuthenticatorResult authenticationResult = 
                    await WebAuthenticator.AuthenticateAsync(loginUrl, callbackUrl);

                code = authenticationResult.Properties["code"];
                code = code.Replace("#_=_", "");

            }
            catch (TaskCanceledException ex1)
            {
                Debug.WriteLine("[ex] TaskCanceledException: " + ex1.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] Exception: " + ex.Message);
            }
            Debug.WriteLine($"FetchHHCode : {code}");
            return code;
        } 
    }

    
}
