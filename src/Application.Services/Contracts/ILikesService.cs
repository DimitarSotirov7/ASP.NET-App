﻿using Application.Models.UserStuffs;

namespace Application.Services.Contracts
{
    public interface ILikesService
    {
        public string CreateLike(Like like);

        public Like GetLikeById(int id);

        public Like GetLikeByCreatorUsername(string creatorUsername);

        public Like GetLikeByReceiverUsername(string receiverUsername);
    }
}
