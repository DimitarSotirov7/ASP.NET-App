using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Services.Contracts
{
    public interface ICommentsService
    {
        public bool CreateComment(Comment comment);

        public ICollection<Comment> GetCommentsByImageId(int imageId);

        public ICollection<Comment> GetCommentsByPostId(int postId);
    }
}
