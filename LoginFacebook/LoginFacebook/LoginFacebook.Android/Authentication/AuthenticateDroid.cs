using System;
using System.Threading.Tasks;
using LoginFacebook.Droid;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;
using LoginFacebook.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace LoginFacebook.Droid
{
    public class AuthenticateDroid: IAuthenticate
    {

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null )
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
               throw;
            }


        }

    }
}