namespace OnlineShop.Application.Common.Interfaces.Repositories
{
    public interface IAuthenticationService
    {
        Task<bool> PasswordSignInAsync(string userName, string password);
    }
}
