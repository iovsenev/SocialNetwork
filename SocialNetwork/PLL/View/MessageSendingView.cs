using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.PLL.View
{
    public class MessageSendingView
    {
        MessageService _messageService;

        public MessageSendingView( MessageService messageService)
        {
            _messageService = messageService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();
            messageSendingData.SenderId = user.Id;
            string recipientEmail;

            while (true)
            {
                Console.Write("Введите Email пользователя кому хотите отправить сообщение: ");
                recipientEmail = Console.ReadLine();
                if (new EmailAddressAttribute().IsValid(recipientEmail))
                {
                    break;
                }
                AllertMessage.Show("Введите корректный Email");
            }

            messageSendingData.RecipientEmail = recipientEmail;

            Console.WriteLine("Введите сообщение не более 5000 символов.");
            messageSendingData.Content = Console.ReadLine();

            try
            {
                _messageService.SendingMessage(messageSendingData);
                SuccessMessage.Show("Сообщение отправлено");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Пользователь не найден");
            }
            catch (ArgumentException)
            {
                AllertMessage.Show("Не корректное сообщение.");
            }
            catch (Exception)
            {
                AllertMessage.Show("Ошибка отправки сообщения");
            }
        }
    }
}
