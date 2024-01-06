using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.View
{
    public class UserOutcomingMessageView
    {
        MessageService _messageService;

        public UserOutcomingMessageView(MessageService messageService)
        {
            _messageService = messageService;
        }

        public void Show(User user)
        {
            var messages = _messageService.GetOutcommingMessageByUserId(user.Id);

            if(messages.Count() > 0)
            {
                messages.ToList().ForEach(message =>
                {
                    Console.WriteLine("Кому: {0}, сообщение: {1}", message.RecipientEmail, message.Content);
                });
                return;
            }
            Console.WriteLine("У вас нет отправленных сообщений.");
        }
    }
}
