using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoginFacebook
{
    public interface IAuthenticate
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider,
            IDictionary <string, string> parameters = null);
    }
}
