
using LoginFacebook.Helpers;
using LoginFacebook.Views;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginFacebook.ViewModels
{
    public class LoginViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => ExecuteLoginCommandAsync()));

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;

            //Title = "Social Login demo";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync()))
                return;
            else
            {
                var mainPage = new MainPage();
                await navigation.PushAsync(mainPage);

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
