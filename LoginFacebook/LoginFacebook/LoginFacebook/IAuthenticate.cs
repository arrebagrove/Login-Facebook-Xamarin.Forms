using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace LoginFacebook
{
    public interface IAuthenticate
    {
        Task<MobileServiceUser> Authenticate(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider);
    }
}
