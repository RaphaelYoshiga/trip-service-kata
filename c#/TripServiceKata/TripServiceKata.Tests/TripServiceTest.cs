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
        private IUserSessionService _userSessionService;
        private ITripDataAccess _tripDataAccess;

        public TripServiceTest()
        {
            _userSessionService = Substitute.For<IUserSessionService>();
            _userSessionService.GetInstance().Returns(_userSessionService);

            _tripDataAccess = Substitute.For<ITripDataAccess>();
            _tripService = new TripService(_userSessionService, _tripDataAccess);
        }

        [Test]
        public void Logged_User_Is_Friend_With_User_Should_Return_Dao_Result()
        {
            var loggedUser = new User();
            _userSessionService.GetLoggedUser()
                .Returns(loggedUser);
            var friends = new List<User>() { 
                loggedUser
            };
            User user = new User();
            user.AddFriend(loggedUser);

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
            var loggedUser = new User();
            _userSessionService.GetLoggedUser()
                .Returns(loggedUser);
            var user = new User();

            // Act
            var tripsByUser = _tripService.GetTripsByUser(user);

            // Assert
            _tripDataAccess.DidNotReceive().FindTripsByUser(user);
            tripsByUser.Count.ShouldBe(0);

        }

        [Test]
        [ExpectedException(typeof(UserNotLoggedInException))]
        public void User_Not_Logged_Should_Throw_UserNotLoggedInException()
        {
            var user = new User();
            _userSessionService.GetLoggedUser()
                .Returns(p => null);

            _tripService.GetTripsByUser(user);
        }



    }
}
