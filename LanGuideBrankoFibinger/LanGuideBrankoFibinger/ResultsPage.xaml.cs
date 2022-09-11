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
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
        }

         protected override async void OnAppearing()
        {
            base.OnAppearing();

            var results = await Result.GetResults();
            resultListView.ItemsSource = results;
        }

        private async void searchUser_TextChanged(object sender, EventArgs e)
        {
            var user_input = searchUser.Text;
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from x in results
                                             where x.id_user == Int32.Parse(user_input)
                                             select x;
            }
            else
                return;
        }

        public async void searchExercise_TextChanged(object sender, EventArgs e)
        {
            var user_input = searchExercise.Text;
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            else
                resultListView.ItemsSource = results.Where(result => result.id_exercise.ToLower().StartsWith(user_input.ToLower()));
        }

     


        private async void SortUser_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.id_user ascending
                                         select result;
        }

    /*    private async void ImageButton_Pressed_1(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.create_time);
        }*/

        private async void SortExercise_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.id_exercise);
        }

        private async void SortResult_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_percent ascending
                                         select result;
        }

        private async void SortScore_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_score ascending
                                         select result;
        }

        private async void SortMax_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = from result in results
                                         orderby result.result_max ascending
                                         select result;
        }

      /*  private async void ImageButton_Pressed_6(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.skill);
        }*/

        private async void SortLanguage_Pressed(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.language);
        }

      /*  private async void ImageButton_Pressed_8(object sender, EventArgs e)
        {
            base.OnAppearing();
            var results = await Result.GetResults();
            resultListView.ItemsSource = results.OrderBy(result => result.result_date);
        }*/

        private async void resultMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = resultMax.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_percent <= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void resultMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = resultMin.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_percent >= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void scoreMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = scoreMax.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_score <= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;

        }

        private async void scoreMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = scoreMin.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_score >= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void scoreMaxMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = scoreMaxMax.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_max <= Int32.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        private async void scoreMaxMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var user_input = scoreMaxMin.Text;
            base.OnAppearing();
            var results = await Result.GetResults();
            if (user_input == "")
                resultListView.ItemsSource = results;
            int y = 0;
            if (Int32.TryParse(user_input, out y))
            {
                resultListView.ItemsSource = from result in results
                                             where result.result_max >= Int16.Parse(user_input)
                                             select result;
            }
            else
                return;
        }

        public async void Return_Clicked2(object sender, EventArgs e)
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