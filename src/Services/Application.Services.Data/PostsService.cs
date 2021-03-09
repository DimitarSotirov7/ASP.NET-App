namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common;
    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Data.Models.Main;
    using Application.Services.Contracts;
    using Application.Services.Mapping;
    using Application.Web.ViewModels.UserRelated.Comments;
    using Application.Web.ViewModels.UserRelated.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;
        private readonly IRepository<Like> likesRepo;
        private readonly IRepository<Dislike> dislikesRepo;

        public PostsService(IDeletableEntityRepository<Post> postsRepo,
            IDeletableEntityRepository<ApplicationUser> usersRepo,
            IRepository<Like> likesRepo, IRepository<Dislike> dislikesRepo)
        {
            this.postsRepo = postsRepo;
            this.usersRepo = usersRepo;
            this.likesRepo = likesRepo;
            this.dislikesRepo = dislikesRepo;
        }

        public async Task CreatePostAsync(PostInputModel input, string imagePath)
        {
            // var toUserId = this.usersRepo.AllAsNoTracking().FirstOrDefault(x => x.UserName == input.ToUserName).Id;
            var post = new Post()
            {
                Content = input.Content,
                FromUserId = input.FromUserId,
                ToUserId = null,
            };

            if (input.ImageUrl != null)
            {
                post.Images.Add(new Image
                {
                    ImageUrl = input.ImageUrl,
                });
            }

            // Validate extension
            if (input.LocalImages.Any())
            {
                Directory.CreateDirectory(imagePath);
                foreach (var localImages in input.LocalImages)
                {
                    var imageExtension = Path.GetExtension(localImages.FileName).TrimStart('.');

                    // TODO: throw exseption if extension is not valid
                    if (!GlobalConstants.AllowedImageExtensions.Contains(imageExtension))
                    {
                        continue;
                    }

                    // Create image in post
                    var image = new Image
                    {
                        Extension = imageExtension,
                    };

                    post.Images.Add(image);

                    // Save physically
                    var fileDirectoty = $"{imagePath}/{image.Id}.{image.Extension}";
                    using (Stream fileStream = new FileStream(fileDirectoty, FileMode.Create))
                    {
                        await input.LocalImages.FirstOrDefault().CopyToAsync(fileStream);
                    }
                }
            }

            await this.postsRepo.AddAsync(post);
            await this.postsRepo.SaveChangesAsync();
        }

        public ICollection<PostViewModel> GetAllLatestPosts(int currentPage, int countInPage = 10)
        {
            var countsToSkip = (currentPage - 1) * countInPage;

            return this.postsRepo.AllAsNoTracking()
                .Where(x => x.ToUserId == null)
                .OrderByDescending(x => x.CreatedOn)
                .Skip(countsToSkip).Take(countInPage)
                .To<PostViewModel>()
                .ToList();
        }

        public int GetCount()
        {
            return this.postsRepo.AllAsNoTracking().Count();
        }

        public async Task LikePostAsync(int postId, string userId)
        {
            var postExist = this.postsRepo.AllAsNoTracking().Any(x => x.Id == postId);
            var userExist = this.usersRepo.AllAsNoTracking().Any(x => x.Id == userId);
            if (!postExist || !userExist)
            {
                return;
            }

            var likeExist = this.likesRepo.AllAsNoTracking()
                .Any(x => x.FromUserId == userId && x.ToPostId == postId);

            var dislikeExist = this.dislikesRepo.AllAsNoTracking()
                .Any(x => x.FromUserId == userId && x.ToPostId == postId);

            if (likeExist || dislikeExist)
            {
                return;
            }

            var like = new Like
            {
                FromUserId = userId,
                ToPostId = postId,
            };

            // set like
            await this.likesRepo.AddAsync(like);
            await this.likesRepo.SaveChangesAsync();
        }

        public async Task DislikePostAsync(int postId, string userId)
        {
            var postExist = this.postsRepo.AllAsNoTracking().Any(x => x.Id == postId);
            var userExist = this.usersRepo.AllAsNoTracking().Any(x => x.Id == userId);
            if (!postExist || !userExist)
            {
                return;
            }

            var dislikeExist = this.dislikesRepo.AllAsNoTracking()
                .Any(x => x.FromUserId == userId && x.ToPostId == postId);

            var likeExist = this.likesRepo.AllAsNoTracking()
                .Any(x => x.FromUserId == userId && x.ToPostId == postId);

            if (likeExist || dislikeExist)
            {
                return;
            }

            var dislike = new Dislike
            {
                FromUserId = userId,
                ToPostId = postId,
            };

            // set dislike
            await this.dislikesRepo.AddAsync(dislike);
            await this.dislikesRepo.SaveChangesAsync();
        }

        public ThumbUpDownCountsViewModel GetLikesAndDislikes(int postId)
        {
            return this.postsRepo.AllAsNoTracking().Where(x => x.Id == postId)
                .To<ThumbUpDownCountsViewModel>()
                .FirstOrDefault();
        }

        public async Task DeleteLikeDislikeFromPostByUser(int postId, string userId, bool isLike)
        {
            if (isLike)
            {
                var like = this.likesRepo.All().Where(x => x.ToPostId == postId && x.FromUserId == userId);
                this.likesRepo.Delete((Like)like);
                await this.likesRepo.SaveChangesAsync();
            }
            else
            {
                var dislike = this.dislikesRepo.All().Where(x => x.ToPostId == postId && x.FromUserId == userId);
                this.dislikesRepo.Delete((Dislike)dislike);
                await this.dislikesRepo.SaveChangesAsync();
            }
        }

        public bool HasUserLikesInPost(string userId, int postId)
        {
            return this.usersRepo.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => new
                {
                    Likes = x.OwnLikes.Select(l => new
                    {
                        ToPostId = l.ToPostId,
                    }),
                })
                .Any(x => x.Likes.Any(l => l.ToPostId == postId));
        }

        public bool HasUserDislikesInPost(string userId, int postId)
        {
            return this.usersRepo.AllAsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => new
                {
                    Dislikes = x.OwnDislikes.Select(l => new
                    {
                        ToPostId = l.ToPostId,
                    }),
                })
                .Any(x => x.Dislikes.Any(l => l.ToPostId == postId));
        }

        public async Task AddCommentAsync(CommentInputModel input)
        {
            var userExist = this.usersRepo.AllAsNoTracking()
                .Any(x => x.Id == input.FromUserId);

            if (!userExist)
            {
                return;
            }

            var post = this.postsRepo.All().FirstOrDefault(x => x.Id == input.ToPostId);

            if (post == null)
            {
                return;
            }

            var comment = new Comment
            {
                Content = input.Content,
                FromUserId = input.FromUserId,
                ToPostId = input.ToPostId,
            };
            post.Comments.Add(comment);

            await this.postsRepo.SaveChangesAsync();
        }

        public CommentViewModel GetLastComment(CommentInputModel input)
        {
            return this.postsRepo.AllAsNoTracking()
                .Where(x => x.Id == input.ToPostId)
                .To<AllCommentsInPostViewModel>()
                .FirstOrDefault()
                .Comments
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault();
        }
    }
}
