using Application.Models.Common;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

            this.Followings = new HashSet<Follow>();
            this.Followers = new HashSet<Follow>();

            this.OwnPosts = new HashSet<Post>();
            this.PostsReceived = new HashSet<Post>();

            this.Questions = new HashSet<UserQuestion>();

            this.FriendshipRequests = new HashSet<Friendship>();
            this.FriendshipResponses = new HashSet<Friendship>();

            this.OtherImages = new HashSet<Image>();
        }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime Joined { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string PasswordHint { get; set; }

        public int? ProfileImageId { get; set; }
        public virtual Image ProfileImage { get; set; }

        public int? CoverImageId { get; set; }
        public virtual Image CoverImage { get; set; }

        public virtual ICollection<Image> OtherImages { get; set; }

        [InverseProperty("FromUser")]
        public virtual ICollection<Message> OwnMessages { get; set; }
        [InverseProperty("ToUser")]
        public virtual ICollection<Message> MessagesReceived { get; set; }

        [InverseProperty("FromUser")]
        public virtual ICollection<Follow> Followings { get; set; }
        [InverseProperty("ToUser")]
        public virtual ICollection<Follow> Followers { get; set; }

        [InverseProperty("FromUser")]
        public virtual ICollection<Post> OwnPosts { get; set; }
        [InverseProperty("ToUser")]
        public virtual ICollection<Post> PostsReceived { get; set; }

        [InverseProperty("FromUser")]
        public virtual ICollection<Like> OwnLikes { get; set; }
        [InverseProperty("ToUser")]
        public virtual ICollection<Like> LikesReceived { get; set; }

        [InverseProperty("FromUser")]
        public virtual ICollection<Comment> OwnComments { get; set; }
        [InverseProperty("ToUser")]
        public virtual ICollection<Comment> CommentsReceived { get; set; }

        public virtual ICollection<UserQuestion> Questions { get; set; }

        [InverseProperty("Requester")]
        public virtual ICollection<Friendship> FriendshipRequests { get; set; }
        [InverseProperty("Responder")]
        public virtual ICollection<Friendship> FriendshipResponses { get; set; }
    }
}
