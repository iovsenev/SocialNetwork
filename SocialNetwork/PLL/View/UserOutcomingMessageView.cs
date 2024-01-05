using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.View
{
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> messages)
        {
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
