using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View
{
    public class UserMenuView
    {
        UserService _userService;

        public UserMenuView(UserService userService)
        {
            _userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("******* Приветствуем вас, {0} *******", user.FirstName);
                Console.WriteLine("******* Вы в главном меню пользователя *******\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());

                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
                Console.WriteLine("Выйти из профиля (нажмите 7)");
                Console.ForegroundColor = color;
                int enterValue;
                try
                {
                    enterValue = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    AllertMessage.Show("Введено не корректное значение от 1 до 7");
                    MessageForBegin.Show();
                    continue;
                }

                if (enterValue == 7)
                    break;

                switch (enterValue)
                {
                    case 1:
                        Program.userInfoView.Show(user);
                        break;
                    case 2:
                        Program.userDataUpdateView.Show(user);
                        break;
                    case 3:
                        Program.friendMenuView.Show(user);
                        break;
                    case 4:
                        Program.messageSendingView.Show(user);
                        break;
                    case 5:
                        Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    case 6:
                        Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                        break;
                }

                MessageForBegin.Show();
                user = _userService.FindByEmail(user.Email);
            }
        }
    }
}
