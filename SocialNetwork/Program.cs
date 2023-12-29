using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System.Runtime.CompilerServices;

namespace SocialNetwork
{
    internal class Program
    {
        static UserService userService = new UserService();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в социальную сеть");
                Console.WriteLine("Для регистрации введите");

                Console.Write("Имя пользователя: ");
                var firstName = Console.ReadLine();

                Console.Write("Фамилия пользователя: ");
                var lastName = Console.ReadLine();

                Console.Write("Email пользователя: ");
                var email = Console.ReadLine();

                Console.Write("Пароль пользователя: ");
                var password = Console.ReadLine();

                var userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация прошла успешно.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректные данные.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла ошибка регистрации.");
                }
                Console.ReadLine();
            }
        }
    }
}
