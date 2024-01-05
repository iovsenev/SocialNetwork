using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.View
{
    public class UserIncomingMessageView
    {
        public void Show(IEnumerable<Message> messages)
        {
            if (messages.Count() > 0)
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
