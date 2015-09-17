using System.Collections.Generic;
using System.Linq;
using TripServiceKata.DataAccess;
using TripServiceKata.Exception;
using TripServiceKata.Models;


namespace TripServiceKata.Services
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

        public List<Trip> GetTripsByUser(User user)
        {
            User loggedUser = _userSession.GetLoggedUser();
            if (loggedUser == null)
                throw new UserNotLoggedInException();

            var friends = user.GetFriends();
            bool isFriend = friends.Any(p => p == loggedUser);
            List<Trip> tripList = isFriend ? _tripDataAccess.FindTripsByUser(user) : new List<Trip>();
            return tripList;
        }
    }
}
