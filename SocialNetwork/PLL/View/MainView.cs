using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View
{
    public class MainView
    {
        public void Show()
        {
            while (true)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("********** Добро пожаловать в социальную сеть. *********\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Войти в профиль (нажмите 1)");
                Console.WriteLine("Зарегистрироваться (нажмите 2)");
                Console.ForegroundColor = color;

                int enter;

                try
                {
                    enter = Convert.ToInt32(Console.ReadLine());
                    if (enter < 1 || enter > 2)
                        throw new Exception();
                }
                catch (Exception)
                {
                    AllertMessage.Show("Не корректный ввод!");
                    MessageForBegin.Show();
                    continue;
                }
                switch (enter)
                {
                    case 1:
                        Program.authenticationView.Show();
                        break;

                    case 2:
                        Program.registrationView.Show();
                        break;
                }
                MessageForBegin.Show();
            }
        }
    }
}
