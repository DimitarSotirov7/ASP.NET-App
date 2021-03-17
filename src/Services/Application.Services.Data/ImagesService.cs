namespace Application.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data.Common;
    using Application.Data.Common.Repositories;
    using Application.Data.Models.Main;
    using Application.Services.Data.Contracts;

    public class ImagesService : IImagesService
    {
        private readonly IDeletableEntityRepository<Image> imagesRepo;

        public ImagesService(IDeletableEntityRepository<Image> imagesRepo)
        {
            this.imagesRepo = imagesRepo;
        }

        public IEnumerable<string> GetImageIdsByPostId(int postId)
        {
            return this.imagesRepo.AllAsNoTracking()
                .Where(x => x.PostId == postId)
                .Select(x => x.Id)
                .ToList();
        }

        public async Task HardDelete(string imageId, string folderPath)
        {
            var image = this.imagesRepo.All().FirstOrDefault(x => x.Id == imageId);

            if (image == null)
            {
                return;
            }

            // delete image physically
            string path = string.Format(GlobalConstants.GetsLocalImagePath, folderPath, image.Id, image.Extension);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            this.imagesRepo.HardDelete(image);
            await this.imagesRepo.SaveChangesAsync();
        }
    }
}
