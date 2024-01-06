using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.View
{
    public class FriendListView
    {
        FriendService _friendService;

        public FriendListView(FriendService friendService)
        {
            _friendService = friendService;
        }

        public void Show(User user)
        {
            var friendList = _friendService.GetFriends(user.Id).ToList();

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
