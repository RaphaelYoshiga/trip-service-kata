using TripServiceKata.Exception;

namespace TripServiceKata.User
{
    public class UserSession : IUserSession
    {
        private static readonly UserSession _userSession = new UserSession();

        private UserSession() { }

        public IUserSession GetInstance()
        {
            return _userSession;
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
