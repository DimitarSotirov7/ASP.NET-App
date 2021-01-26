using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System;
using System.Linq;

namespace Application.Services
{
    public class MessagesService : IMessagesService
    {
        private ApplicationDbContext db;

        public MessagesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool CreateMessage(Message message)
        {
            bool invalid = message == null || (message.Context == null && message.ImageId == null && message.Image == null);

            if (invalid)
            {
                return false;
            }

            Message messageToCreate = new Message
            {
                Context = message.Context,
                FromUserId = message.FromUserId,
                ToUserId = message.ToUserId,
                ImageId = message.ImageId ?? null,
                Seen = false,
                SentOn = DateTime.Now
            };

            db.Messages.Add(messageToCreate);
            db.SaveChanges();

            return true;
        }

        public Message GetMessageByCreatorUsername(string creatorUsername)
        {
            return db.Messages.FirstOrDefault(x => x.FromUser.Username == creatorUsername);
        }

        public Message GetMessageById(int id)
        {
            return db.Messages.FirstOrDefault(x => x.Id == id);
        }

        public Message GetMessageByReceiverUsername(string receiverUsername)
        {
            return db.Messages.FirstOrDefault(x => x.ToUser.Username == receiverUsername);
        }

        public bool SetSeenMessageById(int id)
        {
            var message = db.Messages.FirstOrDefault(x => x.Id == id);

            if (message == null)
            {
                return false;
            }

            message.Seen = true;
            db.SaveChanges();

            return true;
        }
    }
}
