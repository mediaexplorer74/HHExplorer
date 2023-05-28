// MainPage

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HHExplorer.Models;


// HHExplorer.Views namespace
namespace HHExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
 
    // Main Page (tabbed page)
    public partial class MainPage : TabbedPage
    {
        // MainPage
        public MainPage()
        {
            InitializeComponent();

        }//MainPage
       
    }//class end

}//namespace end