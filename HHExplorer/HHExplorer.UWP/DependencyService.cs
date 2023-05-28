using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;
using Xamarin.Forms;

using System.ServiceModel;

using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Windows.Storage;
using System.Diagnostics;
using static HHExplorer.Views.VacanciesPage;

[assembly: Dependency(typeof(HHExplorer.UWP.MegaClient))]
namespace HHExplorer.UWP
{
   
    // 3 IMegaClient "interface realization"
    public class MegaClient : IMegaClient
    {

        // Run Uri link
        public async void RunUri(string s_uri)
        {
            Debug.WriteLine("cp 1");

            Uri uri = new Uri(s_uri, UriKind.Absolute);

            if (uri != null)
            {

                Debug.WriteLine("cp 2");

                // Launch the retrieved file
                bool success = await Windows.System.Launcher.LaunchUriAsync(uri);

                Debug.WriteLine("cp 3");
            }

        }//RunUri end

    }//MegaClient end
   

}// namespace end
