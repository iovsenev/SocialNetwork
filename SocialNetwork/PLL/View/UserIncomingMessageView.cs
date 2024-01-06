using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.View
{
    public class UserIncomingMessageView
    {
        MessageService _messageService;

        public UserIncomingMessageView(MessageService messageService)
        {
            _messageService = messageService;
        }

        public void Show(User user)
        {
            var messages = _messageService.GetIncommingMessageByUserId(user.Id);
            if (user.IncomingMessages.Count() > 0)
            {
                messages.ToList().ForEach(message =>
                {
                    Console.WriteLine("От: {0} сообщение: {1}", message.SenderEmail, message.Content);
                });
                return;
            }

            Console.WriteLine("У вас нет входящих сообщений");
        }
    }
}
