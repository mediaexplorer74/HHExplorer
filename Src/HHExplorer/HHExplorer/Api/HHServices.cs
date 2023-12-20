using System;
using System.Text;

namespace HHWebAuthenticator.HH
{
    public class HHServices
    {
        public static string BuildAuthenticationUrl()
        {
            return $"{HHConfiguration.Auth2Url}" +
                $"response_type=code" +
                $"&client_id={HHConfiguration.ClientId}" +
                $"&state=2F" +
                $"&redirect_uri={HHConfiguration.CallbackEscaped}";// +
                //$"&scope={HHConfiguration.ScopesEscaped}" +
                //$"&expires_in={HHConfiguration.ExpireIn}";
        }

        public static string Base64String()
        {
            var authString = HHConfiguration.ClientId + ":" + HHConfiguration.ClientSecret;
            var bytes = Encoding.UTF8.GetBytes(authString);
            var base64String = Convert.ToBase64String(bytes);

            return base64String;
        }
    }
}
