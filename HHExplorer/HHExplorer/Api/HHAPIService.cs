using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;
using HHLibrary;
using HHLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
//using RestSharp;

namespace HHWebAuthenticator.HH
{
    public class HHAPIService
    {
        public async Task<HHResponseModel> CallTokenAPIAsync(string code)
        {
            HHResponseModel tokenDetails = new HHResponseModel();
            try
            {
                RestClient client = new RestClient(HHConfiguration.TokenApiUri)
                {
                    //Timeout = -1
                };

                string _authorization = "Basic " + HHServices.Base64String();

                RestRequest request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", _authorization);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                request.AddParameter("grant_type", HHConfiguration.GrantType);
                request.AddParameter("client_id", HHConfiguration.ClientId);
                request.AddParameter("client_secret", HHConfiguration.ClientSecret);
                request.AddParameter("redirect_uri", HHConfiguration.Callback);
                request.AddParameter("code", code);

                IRestResponse response = await client.Execute(request);//.ExecuteAsync(request);
                Debug.WriteLine($"CallTokenAPI : {response.Content}");

                if (response.IsSuccess)//.IsSuccessful)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    string _jsonResult = JsonConvert.DeserializeObject(response.Content).ToString();

                    tokenDetails = JsonConvert.DeserializeObject<HHResponseModel>(_jsonResult,
                        settings);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] RestClient Exception: " + ex.Message);
            }

            return tokenDetails;
        }

        private async Task APIRequestAsync(string requestUri)
        {

            RestClient client = new RestClient(requestUri)
            {
                UserAgent = "HHExplorer/1 (me@nm.ru)"//,
                //Timeout = -1
            };

            var _accessToken = HHConfiguration.TokenResponse.access_token;

            var request = new RestRequest(Method.GET);

            var bearerToken = "Bearer " + _accessToken;
            request.AddHeader("Authorization", bearerToken);
            request.AddHeader("User-Agent", "HHExplorer/1 (me@nm.ru)"); //RnD

            IRestResponse response = await client.Execute(request);//.ExecuteAsync
            Debug.WriteLine(response.Content);
        }

        public async Task FetchUserProfileAsync()
        {
            var requestUri = "https://api.hh.com/1/user/-/profile.json";

            APIRequestAsync(requestUri);

        }

        public async Task FetchUserActivityForDateAsync(string userId, string date)
        {
            var requestUri = "https://api.hh.com/1/user/" + userId + "/activities/date/"
                + date + ".json";

            APIRequestAsync(requestUri);
        }
    }
}
