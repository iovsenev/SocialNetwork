using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IUserRepository _userRepository;
        IMessageRepository _messageRepository;

        public MessageService(
            IUserRepository userRepository,
            IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetIncommingMessageByUserId(int recipientId)
        {
            var messages = new List<Message>();

            _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = _userRepository.FindById(m.sender_id);
                var recipientUserEntity = _userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcommingMessageByUserId(int senderId)
        {
            var messages = new List<Message>();

            _messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                var senderUserEntity = _userRepository.FindById(m.sender_id);
                var recipientUserEntity = _userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public void SendingMessage(MessageSendingData messageSendingData)
        {
            if (string.IsNullOrEmpty(messageSendingData.Content))
            {
                throw new ArgumentException();
            }
            if (messageSendingData.Content.Length > 5000)
            {
                throw new ArgumentException();
            }

            var findUserEntity = _userRepository.FindByEmail(messageSendingData.RecipientEmail);
            if (findUserEntity == null)
                throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                recipient_id = findUserEntity.id,
                sender_id = messageSendingData.SenderId
            };

            if (_messageRepository.Create(messageEntity) == 0)
                throw new Exception();
        }
    }
}
