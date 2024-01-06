namespace SocialNetwork.Tests
{
    internal class RepositoriesBuilser
    {
        List<UserEntity> _users;
        List<MessageEntity> _messages;
        List<FriendEntity> _friends;

        public RepositoriesBuilser()
        {
            SetEntityes();
        }

        private void SetEntityes()
        {
            _users = new List<UserEntity>
            {
                new UserEntity {id= 1, email= "qwer1@qwer.qwer",
                    firstname = "John1", lastname = "smith1"},
                new UserEntity {id= 2, email= "qwer2@qwer.qwer",
                    firstname = "John2", lastname = "smith2"},
                new UserEntity {id= 3, email= "qwer3@qwer.qwer",
                    firstname = "John3", lastname = "smith3"},
                new UserEntity {id= 4, email= "qwer4@qwer.qwer",
                    firstname = "John4", lastname = "smith4"},
            };
            _messages = new List<MessageEntity>
            {
                new MessageEntity {id= 1, content = "1",
                    sender_id = 1, recipient_id = 2},
                new MessageEntity {id= 2, content = "2",
                    sender_id = 1, recipient_id = 4},
                new MessageEntity {id= 3, content = "3",
                    sender_id = 1, recipient_id = 4},
                new MessageEntity {id= 4, content = "4",
                    sender_id = 2, recipient_id = 1},
                new MessageEntity {id= 5, content = "5",
                    sender_id = 3, recipient_id = 1},
                new MessageEntity {id= 6, content = "6",
                    sender_id = 3, recipient_id = 4},
            };
            _friends = new List<FriendEntity> {
                new FriendEntity { id = 1, user_id = 1, friend_id = 2}, 
                new FriendEntity { id = 2, user_id = 1, friend_id = 3}, 
                new FriendEntity { id = 3, user_id = 2, friend_id = 1}, 
                new FriendEntity { id = 4, user_id = 3, friend_id = 1}, 
                new FriendEntity { id = 5, user_id = 3, friend_id = 2}, 
            };
        }

        public Mock<IUserRepository> GetTestingUserRepository()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(propa=>
            propa.FindById(1)).Returns(_users.Where(p=> p.id == 1).First());
            mockUserRepository.Setup(propa=>
            propa.FindById(2)).Returns(_users.Where(p=> p.id == 2).First());
            mockUserRepository.Setup(propa=>
            propa.FindById(3)).Returns(_users.Where(p=> p.id == 3).First());
            mockUserRepository.Setup(propa=>
            propa.FindById(4)).Returns(_users.Where(p=> p.id == 4).First());

            return mockUserRepository;
        }

        public Mock<IFriendRepository> GetTestingFriendRepository()
        {
            var mockFriendRepository = new Mock<IFriendRepository>();
            mockFriendRepository.Setup(p =>
            p.FindAllByUserId(1)).Returns(_friends.Where(p => p.user_id == 1));
            mockFriendRepository.Setup(p =>
            p.FindAllByUserId(2)).Returns(_friends.Where(p => p.user_id == 2));
            mockFriendRepository.Setup(p =>
            p.FindAllByUserId(3)).Returns(_friends.Where(p => p.user_id == 3));
            mockFriendRepository.Setup(p =>
            p.FindAllByUserId(4)).Returns(_friends.Where(p => p.user_id == 4));
            return mockFriendRepository;
        }

        public Mock<IMessageRepository> GetTestingMessageRepositoriy()
        {
            var mockMessageRepository = new Mock<IMessageRepository>();

            return mockMessageRepository;
        }
    }
}
