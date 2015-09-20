using System.Collections.Generic;

namespace TripServiceKata.Models
{
    public class User
    {
        public List<Trip> Trips { get; set; }
        public List<User> Friends { get; set; }

        public User()
        {
            Trips = new List<Trip>();
            Friends = new List<User>();
        }

    }
}
