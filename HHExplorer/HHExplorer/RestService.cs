
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace HHLibrary
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
                      
        }

        public async Task<List<Vacancy>> GetRepositoriesAsync(string uri)
        {
            List<Vacancy> repositories = new List<Vacancy>();

            try
            {
                //RnD
                //_client.DefaultRequestHeaders.Add("cache-control", "no-cache");
                //_client.DefaultRequestHeaders.Add("Accept", "application/json");

                //_client.DefaultRequestHeaders.Add("Authorization",
                //    "Bearer xxx");

                _client.DefaultRequestHeaders.Add("User-Agent",
                   "HHExplorer/1 (me@nm.ru)");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] Exception: " + ex.Message);
            }

            try
            {
                //Debug.WriteLine("[i] await _client.GetAsync " + uri);

                HttpResponseMessage response = await _client.GetAsync(uri);

                //Debug.WriteLine("[i] HttpResponseMessage response code=" 
                //    + response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    //Debug.WriteLine("[i] content="
                   //+ response.Content.ToString());

                    string json = await response.Content.ReadAsStringAsync();

                    //Debug.WriteLine("[i] json="
                    //+ json);

                   
                    JToken apiJsonDocument = JToken.Parse(json);

                    
                    IJEnumerable<JToken> Llist = 
                        apiJsonDocument.Root.SelectToken("items").AsJEnumerable();

                    // RnD: JsonProperty
                    foreach (JToken pocketItemJsonProperty in Llist)
                    {
                        //try
                        //{
                            string s = pocketItemJsonProperty.ToString();

                            Debug.WriteLine("parsestring: " + s);

                            Vacancy hhItem = JsonConvert.DeserializeObject<Vacancy>(s);

                            // trim lead and end spaces
                            hhItem.Name = hhItem.Name.Trim();

                            string S1 = hhItem.Salary?.From != null ? hhItem.Salary?.Currency : "";
                            
                            hhItem.Salary_from = 
                                hhItem.Salary?.From + " " + S1;

                            string S2 = hhItem.Salary?.To != null ? hhItem.Salary?.Currency : "";

                            hhItem.Salary_to = 
                                hhItem.Salary?.To +   " " + S2;

                            Debug.WriteLine(hhItem.Name);
                            repositories.Add(hhItem);
                        //}
                        //catch (Exception ex)
                        //{
                        //    Debug.WriteLine("[ex] Parsing error: " + ex.Message);
                        //}

                    }//foreach
                }

            

                Debug.WriteLine("StatusCode: ", response.StatusCode);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception :", ex.Message);
            }

            return repositories;
        }
    }
}
