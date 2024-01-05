using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.View;

namespace SocialNetwork
{
    class Program
    {
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
            _messageService = new MessageService();
            _userService = new UserService();
            _friendService = new FriendService();

            mainView = new MainView();
            authenticationView = new AuthenticationView(_userService);
            registrationView = new RegistrationView(_userService);

            userMenuView = new UserMenuView(_userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(_userService);

            messageSendingView = new MessageSendingView(_messageService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();

            friendMenuView = new FriendMenuView();
            friendListView = new FriendListView();
            friendAddView = new FriendAddView(_friendService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}

