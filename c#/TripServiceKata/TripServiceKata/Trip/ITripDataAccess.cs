using System;
using System.Collections.Generic;
namespace TripServiceKata.Trip
{
    public interface ITripDataAccess
    {
        List<Trip> FindTripsByUser(User.User user);
    }
}
