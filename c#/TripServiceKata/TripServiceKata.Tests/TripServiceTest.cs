using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TripServiceKata.Exception;
using Shouldly;
using TripServiceKata.Services;
using TripServiceKata.DataAccess;
using TripServiceKata.Models;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceTest
    {
        private TripService _tripService;
        private IUserService _userService;
        private ITripDataAccess _tripDataAccess;

        public TripServiceTest()
        {
            _userService = Substitute.For<IUserService>();
            _tripDataAccess = Substitute.For<ITripDataAccess>();
            _tripService = new TripService(_userService, _tripDataAccess);
        }

        [Test]
        public void Logged_User_Is_Friend_With_User_Should_Call_DataAcess()
        {
            User user = new User();
            _userService.VerifyUserIsFriendWithLoggedUser(user)
                .Returns(true);
            var dataAccessTrips = new List<Trip>();
            _tripDataAccess.FindTripsByUser(user)
                .Returns(dataAccessTrips);
            // Act
            var tripsByUser = _tripService.GetTripsByUser(user);

            // Assert
            tripsByUser.ShouldBe(dataAccessTrips);
        }

        [Test]
        public void Logged_User_Is_Not_Friend_With_User_Should_Not_Call_DataAccess()
        {
            var user = new User();
            _userService.VerifyUserIsFriendWithLoggedUser(user)
                .Returns(false);

            // Act
            var tripsByUser = _tripService.GetTripsByUser(user);

            // Assert
            _tripDataAccess.DidNotReceive().FindTripsByUser(user);
            tripsByUser.Count.ShouldBe(0);

        }




    }
}
