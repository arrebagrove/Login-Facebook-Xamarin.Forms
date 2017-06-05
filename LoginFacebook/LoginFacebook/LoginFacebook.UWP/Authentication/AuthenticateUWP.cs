using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginFacebook.Helpers;
namespace LoginFacebook.UWP
{
    public class AuthenticateUWP : IAuthenticate
    {

        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);
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
