using Application.Data;
using Application.Models.UserStuffs;
using Application.Services.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class MessagesService : IMessagesService
    {
        private ApplicationDbContext db;
        private MapperConfiguration config;

        public MessagesService(ApplicationDbContext db, MapperConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public bool CreateMessage(Message message)
        {
            message.SentOn = DateTime.UtcNow;

            db.Messages.Add(message);
            db.SaveChanges();

            return true;
        }

        public ICollection<Message> GetMessagesByUserIds(string firstUserId, string secondUserId, int messagesCount)
        {
            return db.Messages
                 .Where(x => (x.FromUserId == firstUserId || x.FromUserId == secondUserId) && 
                 (x.ToUserId == firstUserId || x.ToUserId == secondUserId))
                 .Take(messagesCount)
                 .ToList();
        }

        public bool SetSeenMessageByUsers(string fromUserId, string toUserId)
        {
            var message = db.Messages.FirstOrDefault(x => x.FromUserId == fromUserId && x.ToUserId == toUserId);

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
