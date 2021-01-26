using Application.Models;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt)
            : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserQuestion> UsersQuestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            if (!opt.IsConfigured)
            {
                opt.UseSqlServer("Server=.;Database=ApplicationDb;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserQuestion>()
                .HasKey(x => new { x.UserId, x.QuestionId });

            modelBuilder.Entity<Friendship>(x =>
            {
                x.HasKey(x => new { x.RequesterId, x.ResponderId });

                x.HasOne(p => p.Requester)
                .WithMany().OnDelete(DeleteBehavior.Restrict);

                x.HasOne(p => p.Responder)
                .WithMany().OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(model =>
            {
                model
                   .HasIndex(u => u.Username)
                   .IsUnique();

                model
                   .HasIndex(u => u.Password)
                   .IsUnique();

                model
                  .HasMany(x => x.FriendshipRequests)
                  .WithOne(x => x.Requester)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.FriendshipResponses)
                  .WithOne(x => x.Responder)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.OwnComments)
                  .WithOne(x => x.FromUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.CommentsReceived)
                  .WithOne(x => x.ToUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.OwnLikes)
                  .WithOne(x => x.FromUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.LikesReceived)
                  .WithOne(x => x.ToUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.OwnPosts)
                  .WithOne(x => x.FromUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.PostsReceived)
                  .WithOne(x => x.ToUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.OwnMessages)
                  .WithOne(x => x.FromUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.MessagesReceived)
                  .WithOne(x => x.ToUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.Followings)
                  .WithOne(x => x.FromUser)
                  .OnDelete(DeleteBehavior.Restrict);

                model
                  .HasMany(x => x.Followers)
                  .WithOne(x => x.ToUser)
                  .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
