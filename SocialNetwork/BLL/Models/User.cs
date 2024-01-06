using SocialNetwork.DAL.Entities;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        public IEnumerable<MessageEntity> IncomingMessages { get; }
        public IEnumerable<MessageEntity> OutgoingMessages { get; }
        public IEnumerable<FriendEntity> Friends { get; }

        public User(
            int id,
            string firstName,
            string lastName,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook,
            IEnumerable<MessageEntity> incomingMessage,
            IEnumerable<MessageEntity> outgoingMessage,
            IEnumerable<FriendEntity> friendList)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
            IncomingMessages = incomingMessage;
            OutgoingMessages = outgoingMessage;
            Friends = friendList;
        }
    }
}
