using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using System;
using System.Linq;

namespace Application.Services
{
    public class MessagesService : IMessagesService
    {
        private const string SuccessfullMessage = "Done!";

        private ApplicationDbContext db;

        public MessagesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateMessage(Message message)
        {
            bool requiredInfo = message != null & message.Context != null;

            if (requiredInfo)
            {
                return null;
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

            return SuccessfullMessage;
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

        public string SetSeenMessageById(int id)
        {
            var message = db.Messages.FirstOrDefault(x => x.Id == id);
            message.Seen = true;
            db.SaveChanges();

            return SuccessfullMessage;
        }
    }
}
