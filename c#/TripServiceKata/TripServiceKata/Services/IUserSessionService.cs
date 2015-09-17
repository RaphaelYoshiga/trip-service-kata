using System;
using TripServiceKata.Models;
namespace TripServiceKata.Services
{
    public interface IUserSessionService
    {
        User GetLoggedUser();
        bool IsUserLoggedIn(User user);
        IUserSessionService GetInstance();
    }
}
