using System;
using HHLibrary.Models;

namespace HHWebAuthenticator.HH
{
    public class HHConfiguration
    {
        // Credentials
        public const string ClientId        
          = "KL9UN728TH5S1CD95RPOEPHPAPJSPGEF123J5FS0MVEV3UT9J5S85UJJG6LFDQHS"; //client_id
        public const string ClientSecret    
          = "M8EE75DDHHADRRIJ5GEL5AG5BSUORLRNIJOH2MJ8D86MR7C7D9PTISKC1SOUU7KC"; //client_secret

        // Callback
        public const string Callback
           = "com.vipxam.webauthenticator-12345://callback";
        public const string CallbackEscaped
           = "com.vipxam.webauthenticator-12345%3A%2F%2Fcallback";

        public const string CallbackScheme 
           = "com.vipxam.webauthenticator-12345";

        public const string Auth2Url = "https://hh.ru/oauth/authorize?";

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
