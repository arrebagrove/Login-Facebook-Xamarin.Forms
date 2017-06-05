using LoginFacebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginFacebook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        readonly AzureService azureService = new AzureService();
        public LoginPage()
        {
            InitializeComponent();

             LoginButton.Clicked += async (sender, args) =>
            {
                var user = await azureService.LoginAsync();
                if (user == true)
                {
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await DisplayAlert("Ops", "Falha no login, tente novamente.", "OK");
                }
            };
        }


        
    }
}