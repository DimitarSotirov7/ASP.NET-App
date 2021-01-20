using Application.Models.Common;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class User : BaseModel
    {
        public User()
        {
            this.OwnLikes = new HashSet<Like>();
            this.LikesReceived = new HashSet<Like>();

            this.OwnComments = new HashSet<Comment>();
            this.CommentsReceived = new HashSet<Comment>();
            
            this.OwnMessages = new HashSet<Message>();
            this.MessagesReceived = new HashSet<Message>();

            this.Folloing = new HashSet<Follow>();
            this.Followers = new HashSet<Follow>();

            this.OwnPosts = new HashSet<Post>();
            this.PostsReceived = new HashSet<Post>();

            this.Questions = new HashSet<UserQuestion>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime Joined { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordHint { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }

        public virtual ICollection<Message> OwnMessages { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }

        public virtual ICollection<Follow> Folloing { get; set; }
        public virtual ICollection<Follow> Followers { get; set; }

        public virtual ICollection<Post> OwnPosts { get; set; }
        public virtual ICollection<Post> PostsReceived { get; set; }
        
        public virtual ICollection<Like> OwnLikes { get; set; }
        public virtual ICollection<Like> LikesReceived { get; set; }

        public virtual ICollection<Comment> OwnComments { get; set; }
        public virtual ICollection<Comment> CommentsReceived { get; set; }

        public virtual ICollection<UserQuestion> Questions { get; set; }
    }
}
