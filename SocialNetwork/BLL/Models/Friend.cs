namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int FriendId { get; }
        public string FriendName { get; }
        public string FriendEmail { get; }

        public Friend(int friendId, string friendName, string friendEmail)
        {
            FriendId = friendId;
            FriendName = friendName;
            FriendEmail = friendEmail;
        }
    }
}
