﻿using Application.Data;
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
            if (this.InvalidMessage(message))
            {
                return false;
            }

            message.SentOn = DateTime.UtcNow;

            db.Messages.Add(message);
            db.SaveChanges();

            return true;
        }

        public ICollection<Message> GetMessagesByUserIds(int firstUserId, int secondUserId, int messagesCount)
        {
            return db.Messages
                 .Where(x => (x.FromUserId == firstUserId || x.FromUserId == secondUserId) && 
                 (x.ToUserId == firstUserId || x.ToUserId == secondUserId))
                 .ToList();
        }

        public bool SetSeenMessageByUsers(int fromUserId, int toUserId)
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

        private bool InvalidMessage(Message message)
        {
            var fromUser = db.Users.FirstOrDefault(x => x.Id == message.FromUserId);
            var toUser = db.Users.FirstOrDefault(x => x.Id == message.ToUserId);

            return message == null || (message.Context == null && message.ImageId == null && message.Image == null) ||
                (fromUser == null && toUser == null);
        }
    }
}
