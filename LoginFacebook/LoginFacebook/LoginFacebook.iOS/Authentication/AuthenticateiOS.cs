using System;
using LoginFacebook.iOS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using LoginFacebook.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateiOS))]
namespace LoginFacebook.iOS
{
    public class AuthenticateiOS : IAuthenticate
    {

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;
            while (current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }

            return current;
        }
    }
}