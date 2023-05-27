using System;
using HHLibrary.Models;

namespace HHWebAuthenticator.HH
{
    public class HHConfiguration
    {
        // Credentials
        public const string ClientId        = "";  //client_id
        public const string ClientSecret    = "";  //client_secret


        // Callback
        public const string Callback = 
            //                "https://" +
            //"app-settings.hhdevelopercontent.com/simple-redirect.html";
                                         "com.vipxam.webauthenticator-12345://callback";
        public const string CallbackEscaped =
         //           "app-settings.hhdevelopercontent.com%3Fsimple-redirect.html";
        //"https%3A%2F%2Fapp-settings.hhdevelopercontent.com%3Fsimple-redirect.html";
        "com.vipxam.webauthenticator-12345%3A%2F%2Fcallback";

        public const string CallbackScheme = 
                            //"app-settings.hhdevelopercontent.com";
                                "com.vipxam.webauthenticator-12345";

        public const string Auth2Url = "https://hh.ru/oauth/authorize?";//"https://www.hh.com/oauth2/authorize?";

        public const string ScopesEscaped = "readwrite%20profile";
        public const string ExpireIn = "604800";

        // Token deals
        public const string TokenApiUri = "https://hh.ru/oauth/token";
        public const string GrantType = "authorization_code";

        // auth bearer auto-property
        public static string AuthorizationBearer { get; set; }

        // Token response auto-property
        public static HHResponseModel TokenResponse { get; set; }

        // Vacancies
        public const string HHAPIGetVacancies =
           "http://api.hh.ru/vacancies";
    }
}
