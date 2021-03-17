namespace Application.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImagesService
    {
        public Task HardDelete(string imageId, string folderPath);

        public IEnumerable<string> GetImageIdsByPostId(int postId);
    }
}
