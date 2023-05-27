using System;
using System.Collections.Generic;
using HHLibrary;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Xml.Linq;

namespace HHExplorer
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;


        // 1 Interface connector
        IMegaClient megaClient;

        // 2 Interface declaration
        public interface IMegaClient
        {
            void RunUri(string s_uri);
        }

        public MainPage()
        {
            InitializeComponent();

            // 4 Interface Init  
            megaClient = DependencyService.Get<IMegaClient>();

            _restService = new RestService();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (VacancyName.Text == null || VacancyName.Text == "")
            {
                await DisplayAlert("", "Не введено название вакансии", "OK");
            }
            else
            {
                List<Vacancy> repositories =
                    await _restService.GetRepositoriesAsync(Constants.HHAPIGetVacancies
                    + "?text=" + VacancyName.Text +
                    "&area=1" +
                    "&page=1"
                    + "&per_page=50");

                Debug.WriteLine(repositories.ToString());

                collectionView.ItemsSource = repositories;
            }

        }//OnButtonClicked


        // !!! ItemSelected handling
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Debug.WriteLine("[i] ListView Item Clicked!");

            // starting...
            long idx = -1;
            //string StRes2 = "";

            if (e.SelectedItem == null)
            {
                return;
            }

            var SI = e.SelectedItem;

            idx = (SI as Vacancy).Id;

            if (idx < 0) return;



            // Make Dialog Popup
            bool choosedresult = await DisplayAlert
             (
                "Ссылка: " + (SI as Vacancy).Alternate_url,
                "Открыть данную ссылку в браузере для просмотра деталей по вакансии?",
                "Да",
                "Нет"
             );


            // If user choose "No", do nothing =)
            if (choosedresult == false)
            {
                return;
            }

            string s_uri = (SI as Vacancy).Alternate_url;

            Debug.WriteLine("[i] s_uri = " + s_uri);

            // Run Uri link            
            megaClient.RunUri(s_uri);

        }//ItemSelected

    }//class end

}//namespace end

/*
//using System.Web;
using Xamarin.Forms;

namespace News.Views
{
    public partial class ArticleView : ContentPage
    {
        //Here is where you show the news in Full page
        public ArticleView()
        {
            InitializeComponent();
         }
        public ArticleView(string Url)
        {
            InitializeComponent();
            BindingContext = new UrlWebViewSource
            {
                Url = "http://dzen.ru"//HttpUtility.UrlDecode(Url)
            };
        }
    }
}
*/
