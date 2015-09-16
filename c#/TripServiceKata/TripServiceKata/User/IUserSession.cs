using System;
namespace TripServiceKata.User
{
    public interface IUserSession
    {
        User GetLoggedUser();
        bool IsUserLoggedIn(User user);
        IUserSession GetInstance();
    }
}
