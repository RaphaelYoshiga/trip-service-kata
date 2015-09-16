using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;
using Shouldly;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceTest
    {
        private TripService _tripService;
        private IUserSession _userSession;
        private ITripDAO _tripDao;

        public TripServiceTest()
        {
            _userSession = Substitute.For<IUserSession>();
            _userSession.GetInstance().Returns(_userSession);

            _tripDao = Substitute.For<ITripDAO>();
            _tripService = new TripService(_userSession, _tripDao);
        }

        [Test]
        public void Logged_User_Is_Friend_With_User_Should_Return_Dao_Result()
        {
            var loggedUser = new User.User();
            _userSession.GetLoggedUser()
                .Returns(loggedUser);
            var friends = new List<User.User>() { 
                loggedUser
            };
            User.User user = new User.User();
            user.AddFriend(loggedUser);

            var dataAccessTrips = new List<Trip.Trip>();
            _tripDao.FindTripsByUser(user)
                .Returns(dataAccessTrips);

            // Act
            var tripsByUser = _tripService.GetTripsByUser(user);

            // Assert
            tripsByUser.ShouldBe(dataAccessTrips);
        }

        [Test]
        public void Logged_User_Is_Not_Friend_With_User_Should_Not_Call_DataAccess()
        {
            var loggedUser = new User.User();
            _userSession.GetLoggedUser()
                .Returns(loggedUser);
            User.User user = new User.User();

            // Act
            var tripsByUser = _tripService.GetTripsByUser(user);

            // Assert
            _tripDao.DidNotReceive().FindTripsByUser(user);
            tripsByUser.Count.ShouldBe(0);
            
        }

        [Test]
        [ExpectedException(typeof(UserNotLoggedInException))]
        public void User_Not_Logged_Should_Throw_UserNotLoggedInException()
        {
            User.User user = new User.User();
            _userSession.GetLoggedUser()
                .Returns(p => null);

            _tripService.GetTripsByUser(user);
        }



    }
}
