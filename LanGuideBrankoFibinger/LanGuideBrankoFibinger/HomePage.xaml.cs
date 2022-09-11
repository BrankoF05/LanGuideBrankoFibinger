using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanGuideBrankoFibinger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            
            InitializeComponent();
        }

        private void UserButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new UsersPage();
        }

        private void ResultButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ResultsPage();
        }

        private void LanguageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LanguagesPage();
        }

        private void OnLogoutTap(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}