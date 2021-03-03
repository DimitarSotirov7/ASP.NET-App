namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Models.Main;
    using Application.Services.Contracts;
    using Application.Services.Mapping;
    using Application.Web.ViewModels.UserRelated;

    public class PostsService : IPostsService
    {
        private readonly string[] allowedImageExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public PostsService(IDeletableEntityRepository<Post> postsRepo, IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.postsRepo = postsRepo;
            this.usersRepo = usersRepo;
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
                    if (!this.allowedImageExtensions.Contains(imageExtension))
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
    }
}
