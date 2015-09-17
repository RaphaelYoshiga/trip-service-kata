using TripServiceKata.Exception;
using TripServiceKata.Models;

namespace TripServiceKata.Services
{
    public class UserSessionService : IUserSessionService
    {
        private static readonly UserSessionService _userSessionService = new UserSessionService();

        private UserSessionService() { }

        public static IUserSessionService GetInstance()
        {
            return _userSessionService;
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}
