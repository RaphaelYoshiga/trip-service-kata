using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Models;

namespace TripServiceKata.DataAccess
{
    public class TripDataAccess : ITripDataAccess
    {
        public List<Trip> FindTripsByUser(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
    }
}
