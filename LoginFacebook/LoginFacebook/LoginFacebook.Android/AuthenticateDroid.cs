using System;
using System.Threading.Tasks;
using LoginFacebook.Droid;
using Microsoft.WindowsAzure.MobileServices;
using LoginFacebook;


[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace LoginFacebook.Droid
{
    public class AuthenticateDroid: IAuthenticate
    {

        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
            }
            catch (Exception ex)
            {
                return null;
            }


        }

    }
}