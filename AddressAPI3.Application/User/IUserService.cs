namespace AddressAPI3.Application.User
{
    using Domain;

    public interface IUserService
    {
        User Authenticate(string username, string password, string referer);
    }
}
