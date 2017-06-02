using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginFacebook
{
    public class AzureService
    {
        static readonly string Appurl = "https://demosociallogin.azurewebsite.net";

        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(Appurl);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null) {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Login invalido.", "OK");
                });
                return null;
            }
            return null;
        }
    }
}
