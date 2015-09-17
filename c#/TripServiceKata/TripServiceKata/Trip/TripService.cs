using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private IUserSessionService _userSession;
        private ITripDataAccess _tripDataAccess;

        public TripService(IUserSessionService userSessionService, ITripDataAccess tripDataAcess)
        {
            _userSession = userSessionService;
            _tripDataAccess = tripDataAcess;
        }

        public List<Trip> GetTripsByUser(User.User user)
        {
            User.User loggedUser = _userSession.GetLoggedUser();
            if (loggedUser != null)
            {
                var friends = user.GetFriends();
                bool isFriend = friends.Any(p => p == loggedUser);
                List<Trip> tripList = isFriend ? _tripDataAccess.FindTripsByUser(user) : new List<Trip>();
                return tripList;
            }
            else
                throw new UserNotLoggedInException();
        }
    }
}
