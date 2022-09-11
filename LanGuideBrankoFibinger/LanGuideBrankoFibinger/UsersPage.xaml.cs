using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LanGuideBrankoFibinger.Model;

namespace LanGuideBrankoFibinger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var users = await User.GetUsers();
            userListView.ItemsSource = users;
        }

        int brojac_user = 0;
        int brojac_vrijeme = 0;

        private async void UserSortiranjePressed(object sender, EventArgs e)
        {
            brojac_user++;

            base.OnAppearing();
            var users = await User.GetUsers();

            if (brojac_user % 2 == 0)
            {
                userListView.ItemsSource = from user in users
                                           orderby user.id_user ascending
                                           select user;
            }
            else
            {
                userListView.ItemsSource = from user in users
                                           orderby user.id_user descending
                                           select user;
            }

        }

        private async void VrijemeSortiranjePressed(object sender, EventArgs e)
        {
            brojac_vrijeme++;

            base.OnAppearing();
            var users = await User.GetUsers();

            if (brojac_vrijeme % 2 == 0)
            {
                userListView.ItemsSource = from user in users
                                           orderby user.create_time ascending
                                           select user;
            }
            else
            {
                userListView.ItemsSource = from user in users
                                           orderby user.create_time descending
                                           select user;
            }
        }

        public async void Return_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new HomePage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}