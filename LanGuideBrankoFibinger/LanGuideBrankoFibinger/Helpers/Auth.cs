using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanGuideBrankoFibinger.Helpers
{
    public interface IAuth
    {
        
        Task<bool> LoginUser(string email, string password);
        bool IsAuthenticated();
        string GetCurrentUserId();

    }
    internal class Auth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();
       
            public static async Task<bool> LoginUser(string email, string password)
            {
                try
                {
                    return await auth.LoginUser(email, password);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                    return false;
                }
            }

            public static bool IsAuthenticated()
            {
                return auth.IsAuthenticated();
            }

            public static string GetCurrentUserId()
            {
                return auth.GetCurrentUserId();
            }
        }
}
