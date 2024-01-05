using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View
{
    public class FriendListView
    {
        public void Show(User user)
        {
            var friendList = user.Friends.ToList();

            if (friendList.Count > 0)
            {
                friendList.ForEach(fr =>
                {
                    Console.WriteLine("Имя: {0} email: {1}", fr.FriendName, fr.FriendEmail);
                });
                MessageForBegin.Show();
                return;
            }

            Console.WriteLine("У вас пока не добавленно ни одного друга!");
            MessageForBegin.Show();
        }
    }
}
