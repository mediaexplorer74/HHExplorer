using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using HHWebAuthenticator.HH;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using HHLibrary.Models;

namespace News.Views
{
    public partial class ResumesPage : ContentPage
    {
        //Models.HHResponseModel HHAccessToken;

        public ResumesPage()
        {
            this.InitializeComponent();

            this.Title = "Resume group tasks";

            //HHAccessToken = HHConfiguration.TokenResponse;
            Debug.WriteLine("HH Access token: " + App.AccessToken); //HHConfiguration.TokenResponse.access_token);
            TBox1.Text = "HH Access token: " + App.AccessToken; //HHConfiguration.TokenResponse.access_token;

            //FetchUserActivity();
            //FetchUserProfile();
            TBox1.Text = TBox1.Text + " " 
                + $"Press the RESUME REFRESH button to refresh all your resumes";

        }


        void FetchUserProfile()
        {
            HHLibrary.Models.HHResponseModel _tokenResponse = HHConfiguration.TokenResponse;
            if (!string.IsNullOrEmpty(_tokenResponse.access_token) 
                && !string.IsNullOrEmpty(_tokenResponse.user_id))
                new HHAPIService().FetchUserProfileAsync();
        }

        void FetchUserActivity()
        {
            var _tokenResponse = HHConfiguration.TokenResponse;
            var todayDate = DateTime.Now.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(_tokenResponse.access_token) 
                && !string.IsNullOrEmpty(_tokenResponse.user_id))
                new HHAPIService().FetchUserActivityForDateAsync(
                    _tokenResponse.user_id, todayDate);
        }


        // ResumeUpdateButtonClick
        private async void ResumeUpdateButtonClick(object sender, EventArgs e)
        {
            //var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));

            // https://api.hh.ru/resumes/mine

            // - A -
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.hh.ru");
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer",
                    App.AccessToken/*HHConfiguration.TokenResponse.access_token*/);
                client.DefaultRequestHeaders.UserAgent.ParseAdd
                (
                    $"HHExplorer/1 (me@nm.ru)"
                );

                // 1 get resume
                string content = "";

                try
                {
                    content = await client.GetStringAsync($"/resumes/mine");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                    TBox1.Text = "Error: bad user access token (app access token used).";
           
                    Debug.WriteLine("Exception: " + ex.Message);
                    return;
                }

                Debug.WriteLine($"Resume content: {content}");
                TBox1.Text = $"Resume content: {content}";

                ResumeList Resumes = JsonConvert.DeserializeObject<ResumeList>(content);

                Debug.WriteLine($"Resumes count: {Resumes.Items.Count}");
                TBox1.Text = TBox1.Text  + " " + $"Resume count: {Resumes.Items.Count}";

                foreach (ResumeItem Resume in Resumes.Items)
                {
                    // Delay 2s
                    //Thread.Sleep(2000);

                    ResumeRefreshAsync(Resume.Id);
                }

            }//using...


        }//ResumeUpdateButtonClick end


        // 1 resume date-time update
        async void ResumeRefreshAsync(string ResumeId)
        {
            // - A -
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.hh.ru");
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer",
                    App.AccessToken/*HHConfiguration.TokenResponse.access_token*/);
                client.DefaultRequestHeaders.UserAgent.ParseAdd
                (
                    $"HHExplorer/1 (me@nm.ru)"
                );

                // 1 get resume
                string content = "";

                try
                {
                    content = await client.GetStringAsync($"/resumes/{ResumeId}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                    TBox1.Text = TBox1.Text + " " 
                        + "Error: bad user access token (app access token used).";
                   
                    Debug.WriteLine("Exception: " + ex.Message);
                    return;
                }

                Debug.WriteLine($"Resume content: {content}");
                TBox1.Text = TBox1.Text + " " + $"Resume content: {content}";

                DateTime nextPublishAt = 
                    JObject.Parse(content)["next_publish_at"].ToObject<DateTime>();

                Debug.WriteLine($"Time to update the resume: {nextPublishAt}");
                TBox1.Text = TBox1.Text + " "
                    + $"Time to update the resume: {nextPublishAt}";


                // 2 Try to update resume

                // Delay 2s
                //Thread.Sleep(2000);

                HttpResponseMessage updateResponse =
                    await client.PostAsync($"/resumes/{ResumeId}/publish", 
                    new StringContent(""));

                string contents = await updateResponse.Content.ReadAsStringAsync();

                Debug.WriteLine($"Update Response: {contents}");
                TBox1.Text = TBox1.Text + " " + $"Update Response: {contents}";

            }
        }

    }
}
