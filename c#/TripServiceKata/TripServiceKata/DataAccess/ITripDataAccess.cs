using System;
using System.Collections.Generic;
using TripServiceKata.Models;
namespace TripServiceKata.DataAccess
{
    public interface ITripDataAccess
    {
        List<Trip> FindTripsByUser(User user);
    }
}
