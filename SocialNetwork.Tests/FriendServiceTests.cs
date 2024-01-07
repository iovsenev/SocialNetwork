using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTests
    {
        static RepositoriesBuilser builder = new RepositoriesBuilser();

        static Mock<IFriendRepository> _friendRepository = builder.GetTestingFriendRepository();
        static Mock<IUserRepository> _userRepository = builder.GetTestingUserRepository();

        FriendService _friendService = new FriendService(_userRepository.Object, _friendRepository.Object);

        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 0)]
        public void GetFriendsMustReturnCorrectValue(int userId, int expectedCount)
        {
            var friendsList = _friendService.GetFriends(userId).ToList();

            Assert.That(friendsList.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase(1, "qwer5@qwer.qwer")]
        public void AddFriendReturnsExceptionUserNotFound(int userId, string friendEmail)
        {
            Assert.Throws<UserNotFoundException>(() => _friendService.AddFriend(userId, friendEmail));
        }
    }
}
