
using LoginFacebook.Helpers;
using LoginFacebook.Views;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginFacebook.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        public Command loginCommand { get; }

        public Command MainCommand { get; }
        

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;
            loginCommand = new Command(async () => await ExecuteLoginCommandAsync());

            //Title = "Social Login demo";
        }



        private async Task ExecuteLoginCommandAsync()
        {
            if (!await LoginAsync())
                return;
            else
            {
                var mainPage = new MainPage();
                await PushAsync<MainViewModel>(mainPage);

                RemovePageFromStack();
            }

        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach(var page in existingPages)
            {
                if (page.GetType() == typeof(LoginPage))
                    navigation.RemovePage(page);
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return azureService.LoginAsync();
        }
    }
}
