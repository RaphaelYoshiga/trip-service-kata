using System.Collections.Generic;
using System.Linq;
using TripServiceKata.DataAccess;
using TripServiceKata.Exception;
using TripServiceKata.Models;


namespace TripServiceKata.Services
{
    public class TripService
    {
        private IUserService _userService;
        private ITripDataAccess _tripDataAccess;

        public TripService(IUserService userService, ITripDataAccess tripDataAcess)
        {
            _userService = userService;
            _tripDataAccess = tripDataAcess;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            bool isFriend = _userService.VerifyUserIsFriendWithLoggedUser(user);
            List<Trip> tripList = isFriend ? _tripDataAccess.FindTripsByUser(user) : new List<Trip>();
            return tripList;
        }


    }
}
