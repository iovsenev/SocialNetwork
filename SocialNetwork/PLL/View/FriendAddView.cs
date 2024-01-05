using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.PLL.View
{
    public class FriendAddView
    {
        FriendService _friendService;

        public FriendAddView(FriendService friendService)
        {
            _friendService = friendService;
        }

        public void Show(User user)
        {
            string email;

            while (true)
            {
                Console.Write("Введите email пользователя которого хотите добавить в друзья: ");
                email = Console.ReadLine();
                if (new EmailAddressAttribute().IsValid(email))
                    break;
                AllertMessage.Show("Не корректно введен email!");
                MessageForBegin.Show();
            }

            try
            {
                _friendService.AddFriend(user.Id, email);
                SuccessMessage.Show("Пользователь добавлен в ваш список друзей.");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден");
            }
            catch (Exception)
            {
                AllertMessage.Show("Добавить не удалось");
            }
            MessageForBegin.Show();
        }
    }
}
