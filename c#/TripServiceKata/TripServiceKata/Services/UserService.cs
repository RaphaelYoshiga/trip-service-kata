using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripServiceKata.Exception;
using TripServiceKata.Models;

namespace TripServiceKata.Services
{
    public class UserService : IUserService
    {
        private IUserSessionService _userSession;

        public UserService(IUserSessionService userSession)
        {
            _userSession = userSession;
        }

        public bool VerifyUserIsFriendWithLoggedUser(User user)
        {
            User loggedUser = _userSession.GetLoggedUser();
            if (loggedUser == null)
                throw new UserNotLoggedInException();

            var friends = user.GetFriends();
            bool isFriend = friends.Any(p => p == loggedUser);
            return isFriend;
        }
    }
}
