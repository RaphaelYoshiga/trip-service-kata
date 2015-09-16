using NSubstitute;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;
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
            _tripDao = Substitute.For<ITripDAO>();
            _tripService = new TripService(_userSession, _tripDao);
        }


        [Test]
        [ExpectedException(typeof(UserNotLoggedInException))]
        public void User_Not_Logged_Should_Throw_UserNotLoggedInException()
        {
            User.User user = new User.User();

            _tripService.GetTripsByUser(user);
        }



    }
}
