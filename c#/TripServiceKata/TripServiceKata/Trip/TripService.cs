using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        private IUserSession _userSession;
        private ITripDAO _tripDao;

        public TripService(IUserSession userSession, ITripDAO tripDao)
        {
            _userSession = userSession;
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User.User user)
        {
            User.User loggedUser = _userSession.GetLoggedUser();
            if (loggedUser != null)
            {
                var friends = user.GetFriends();
                bool isFriend = friends.Any(p => p == loggedUser);
                List<Trip> tripList = isFriend ? _tripDao.FindTripsByUser(user) : new List<Trip>();
                return tripList;
            }
            else
                throw new UserNotLoggedInException();
        }
    }
}
