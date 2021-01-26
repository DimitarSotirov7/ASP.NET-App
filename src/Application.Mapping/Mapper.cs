using Application.Mapping.CategoryDTOModels;
using Application.Mapping.MessageDTOModels;
using Application.Mapping.PostDTOModels;
using Application.Mapping.UserDTOModels;
using Application.Models;
using Application.Models.Q_A_Game;
using Application.Models.UserStuffs;
using AutoMapper;

namespace Application.Mapping
{
    public class Mapper
    {
        public MapperConfiguration ConfigUser()
        {
            return new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserFullNameDTO>()
                    .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));

                cfg.CreateMap<User, UserIdDTO>();

                cfg.CreateMap<User, UserAuthDTO>();

                cfg.CreateMap<User, UserImagesDTO>()
                    .ForMember(x => x.ProfileImage, opt => opt.MapFrom(x => x.ProfileImage.ImageFile))
                    .ForMember(x => x.ProfileImageUrl, opt => opt.MapFrom(x => x.ProfileImage.ImageUrl))
                    .ForMember(x => x.CoverImage, opt => opt.MapFrom(x => x.CoverImage.ImageFile))
                    .ForMember(x => x.CoverImageUrl, opt => opt.MapFrom(x => x.CoverImage.ImageUrl));

                cfg.CreateMap<User, UserInfoDTO>()
                    .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.DateOfBirth.Value.ToString("dd-MMM-yyyy")))
                    .ForMember(x => x.JoinedOn, opt => opt.MapFrom(x => x.Joined.ToString("dd-MMM-yyyy")));
            });
        }

        public MapperConfiguration ConfigPost()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostInfoDTO>()
                    .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.Image.ImageUrl))
                    .ForMember(x => x.ImageFile, opt => opt.MapFrom(x => x.Image.ImageFile))
                    .ForMember(x => x.PostOn, opt => opt.MapFrom(x => x.PostOn.ToString("dd-MMM-yyyy")))
                    .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Count))
                    .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));

                cfg.CreateMap<Post, PostCommentsDTO>();
            });
        }

        public MapperConfiguration ConfigMessage()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessagesByUserIdsDTO>();
            });
        }

        public MapperConfiguration ConfigCategory()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryNameDTO>();
            });
        }
    }
}
