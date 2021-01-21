﻿using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface ICommentsService
    {
        public string CreateComment(Comment comment);

        public Comment GetCommentById(int id);

        public Comment GetCommentByCreatorUsername(string creatorUsername);

        public Comment GetCommentByReceiverUsername(string receiverUsername);
    }
}
