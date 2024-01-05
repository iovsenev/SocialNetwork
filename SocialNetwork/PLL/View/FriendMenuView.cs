using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View
{
    public class FriendMenuView
    {
        public void Show(User user)
        {
            while (true)
            {
                Console.Clear();
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nВы в меню \"Друзья\".\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("У вас {0} друзей в списке", user.Friends.Count());
                Console.WriteLine("Посмотреть список друзей (введите 1).");
                Console.WriteLine("Добавить друга (введите 2).");
                Console.WriteLine("Вернуться в главное меню пользователя (введите 3).");
                Console.ForegroundColor = color;

                int enter;

                try
                {
                    enter = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    AllertMessage.Show("Не верный ввод!");
                    MessageForBegin.Show();
                    continue;
                }

                if (enter == 3)
                    return;

                switch (enter)
                {
                    case 1:
                        Program.friendListView.Show(user);
                        break;
                    case 2:
                        Program.friendAddView.Show(user);
                        break;
                    default:
                        AllertMessage.Show("Не верный ввод!"); 
                        break;
                }
            }
        }
    }
}
