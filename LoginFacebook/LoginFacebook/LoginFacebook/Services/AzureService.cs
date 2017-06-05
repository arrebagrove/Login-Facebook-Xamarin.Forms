using LoginFacebook;
using LoginFacebook.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace LoginFacebook
{
    public class AzureService
    {
        static readonly string Appurl = "http://demosociallogin.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set;} = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(Appurl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) 
                && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
                
            }
        }

        public  async Task<bool> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Login invalido.", "OK");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }
    }
}
