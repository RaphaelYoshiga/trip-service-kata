using System;
using System.Collections.Generic;
namespace TripServiceKata.Trip
{
    public interface ITripDAO
    {
        List<Trip> FindTripsByUser(User.User user);
    }
}
