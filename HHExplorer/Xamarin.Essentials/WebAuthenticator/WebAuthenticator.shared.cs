using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Essentials
{
    public static partial class WebAuthenticator
    {
        public static Task<WebAuthenticatorResult> AuthenticateAsync
            (Uri url, Uri callbackUrl)
        {
            return PlatformAuthenticateAsync(new WebAuthenticatorOptions 
            { Url = url, CallbackUrl = callbackUrl });
        }

        public static Task<WebAuthenticatorResult> AuthenticateAsync
            (WebAuthenticatorOptions webAuthenticatorOptions)
        {
            return PlatformAuthenticateAsync(webAuthenticatorOptions);
        }
    }

    public class WebAuthenticatorOptions
    {
        public Uri Url { get; set; }

        public Uri CallbackUrl { get; set; }

        public bool PrefersEphemeralWebBrowserSession { get; set; }
    }
}
