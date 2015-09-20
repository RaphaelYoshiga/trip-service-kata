using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripServiceKata.Exception;
using TripServiceKata.Models;
using TripServiceKata.Services;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        private IUserService _userService;
        private IUserSessionService _userSessionService;

        public UserServiceTest()
        {
            _userSessionService = Substitute.For<IUserSessionService>();
            _userService = new UserService(_userSessionService);
        }

        [Test]
        public void Logged_User_Is_Friend_With_User()
        {
            var loggedUser = new User();
            _userSessionService.GetLoggedUser()
                .Returns(loggedUser);
            User user = new User();
            user.AddFriend(loggedUser);

            // Act
            bool isUser = _userService.VerifyUserIsFriendWithLoggedUser(user);

            // Assert
            isUser.ShouldBe(true);
        }

        [Test]
        public void Logged_User_Is_Not_Friend_With_User()
        {
            var loggedUser = new User();
            _userSessionService.GetLoggedUser()
                .Returns(loggedUser);
            var user = new User();

            // Act
            bool isUser = _userService.VerifyUserIsFriendWithLoggedUser(user);

            // Assert
            isUser.ShouldBe(false);
        }

        [Test]
        [ExpectedException(typeof(UserNotLoggedInException))]
        public void User_Not_Logged_Should_Throw_UserNotLoggedInException()
        {
            var user = new User();
            _userSessionService.GetLoggedUser()
                .Returns(p => null);

            _userService.VerifyUserIsFriendWithLoggedUser(user);
        }
    }
}
