using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository _friendRepository;
        IUserRepository _userRepository;

        public FriendService()
        {
            _friendRepository = new FriendRepository();
            _userRepository = new UserRepository();
        }

        public IEnumerable<Friend> GetFriends(int userId)
        {
            var friends = new List<Friend>();

            _friendRepository.FindAllByUserId(userId).ToList().ForEach(friend =>
            {
                var friendName = _userRepository.FindById(friend.friend_id).firstname;
                var friendEmail = _userRepository.FindById(friend.friend_id).email;
                friends.Add(new Friend(friend.friend_id, friendName, friendEmail));
            });
            return friends;
        }

        public void AddFriend(int userId, string friendEmail)
        {
            var findUserEntity = _userRepository.FindByEmail(friendEmail);
            if (findUserEntity == null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity();
            friendEntity.friend_id = findUserEntity.id;
            friendEntity.user_id = userId;
             
            _friendRepository.Create(friendEntity);
        }
    }
}
