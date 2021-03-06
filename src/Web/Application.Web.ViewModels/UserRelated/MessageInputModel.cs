﻿namespace Application.Web.ViewModels.UserRelated
{
    using System;

    public class MessageInputModel
    {
        public string Content { get; set; }

        public string FromUserId { get; set; }

        public string FromUserProfileImagePath { get; set; }

        public string ToUserId { get; set; }

        public string ToUserProfileImagePath { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;
    }
}
