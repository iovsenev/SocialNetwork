using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View
{
    public class AuthenticationView
    {
        UserService _userService;

        public AuthenticationView(UserService userService)
        {
            _userService = userService;
        }

        public void Show()
        {
            var autentificationData = new UserAuthenticationData();

            Console.Write("Введите Email: ");
            autentificationData.Email = Console.ReadLine();

            Console.Write("Введите пароль: ");
            autentificationData.Password = Console.ReadLine();

            try
            {
                var user = _userService.Authenticate(autentificationData);
                SuccessMessage.Show("Вы успешно вошли в аккаунт.\n");
                MessageForBegin.Show();
                Program.userMenuView.Show(user);

            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Не верный логин.");
            }
            catch (WrongPasswordException)
            {
                AllertMessage.Show("Не верный пароль");
            }
        }
    }
}
