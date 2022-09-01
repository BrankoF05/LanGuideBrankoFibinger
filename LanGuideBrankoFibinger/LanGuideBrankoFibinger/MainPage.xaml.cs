using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LanGuideBrankoFibinger.Helpers;

namespace LanGuideBrankoFibinger
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
         private async void loginButton_Clicked(object sender, EventArgs e)
         {
            //App.Current.MainPage = new HomePage();
             bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
               bool isPasswordEmpty = string.IsNullOrEmpty(passEntry.Text);
               if (!isEmailEmpty && !isPasswordEmpty)
               {
                   bool result = await Auth.LoginUser(emailEntry.Text, passEntry.Text);
                   if (result) await Navigation.PushAsync(new HomePage());
               }
               else
               {
                   // do not navigate
               }
        }
    }
}
