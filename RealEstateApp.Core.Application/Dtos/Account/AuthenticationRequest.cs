
namespace RealEstateApp.Core.Application.Dtos.Account
{
    public class AuthenticationRequest
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}
