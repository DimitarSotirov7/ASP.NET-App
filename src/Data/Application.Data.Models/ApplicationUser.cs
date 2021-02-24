// ReSharper disable VirtualMemberCallInConstructor
namespace Application.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Application.Data.Common.Models;
    using Application.Data.Models.Main;
    using Application.Models.Main;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.OwnLikes = new HashSet<Like>();

            this.OwnComments = new HashSet<Comment>();
            this.CommentsReceived = new HashSet<Comment>();

            this.OwnMessages = new HashSet<Message>();
            this.MessagesReceived = new HashSet<Message>();

            this.Followings = new HashSet<Follow>();
            this.Followers = new HashSet<Follow>();

            this.OwnPosts = new HashSet<Post>();
            this.PostsReceived = new HashSet<Post>();

            this.FriendshipRequests = new HashSet<Friendship>();
            this.FriendshipResponses = new HashSet<Friendship>();

            this.OtherImages = new HashSet<Image>();
        }

        // Own properties
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PasswordHint { get; set; }

        public string ProfileImageId { get; set; }

        public virtual Image ProfileImage { get; set; }

        public string CoverImageId { get; set; }

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

        [InverseProperty("FromUser")]
        public virtual ICollection<Comment> OwnComments { get; set; }

        [InverseProperty("ToUser")]
        public virtual ICollection<Comment> CommentsReceived { get; set; }

        [InverseProperty("Requester")]
        public virtual ICollection<Friendship> FriendshipRequests { get; set; }

        [InverseProperty("Responder")]
        public virtual ICollection<Friendship> FriendshipResponses { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
