using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.View;

namespace SocialNetwork
{
    class Program
    {
        static IUserRepository _userRepository;
        static IMessageRepository _messageRepository;
        static IFriendRepository _friendRepository;

        static MessageService _messageService;
        static UserService _userService;
        static FriendService _friendService;

        public static MainView mainView;
        public static AuthenticationView authenticationView;
        public static RegistrationView registrationView;

        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;

        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        public static FriendMenuView friendMenuView;
        public static FriendListView friendListView;
        public static FriendAddView friendAddView;

        static void Main(string[] args)
        {
            _userRepository = new UserRepository();
            _messageRepository = new MessageRepository();
            _friendRepository = new FriendRepository();

            _userService = new UserService(_userRepository, _messageRepository, _friendRepository);
            _messageService = new MessageService(_userRepository, _messageRepository);
            _friendService = new FriendService(_userRepository, _friendRepository);

            mainView = new MainView();
            authenticationView = new AuthenticationView(_userService);
            registrationView = new RegistrationView(_userService);

            userMenuView = new UserMenuView(_userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(_userService);

            messageSendingView = new MessageSendingView(_messageService);
            userIncomingMessageView = new UserIncomingMessageView(_messageService);
            userOutcomingMessageView = new UserOutcomingMessageView(_messageService);

            friendMenuView = new FriendMenuView();
            friendListView = new FriendListView(_friendService);
            friendAddView = new FriendAddView(_friendService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}

