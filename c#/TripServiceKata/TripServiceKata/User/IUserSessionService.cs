using System;
namespace TripServiceKata.User
{
    public interface IUserSessionService
    {
        User GetLoggedUser();
        bool IsUserLoggedIn(User user);
        IUserSessionService GetInstance();
    }
}
