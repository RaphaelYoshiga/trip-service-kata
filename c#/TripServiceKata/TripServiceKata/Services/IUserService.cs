using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripServiceKata.Models;

namespace TripServiceKata.Services
{
    public interface IUserService
    {
        bool VerifyUserIsFriendWithLoggedUser(User user);
    }
}
