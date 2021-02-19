using Application.Mapping.CategoryDTOModels;
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
                cfg.CreateMap<User, GetUserDTO>();

                cfg.CreateMap<User, GetUserIdDTO>();
            });
        }

        public MapperConfiguration ConfigPost()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, GetPostDTO>()
                    .ForMember(x => x.PostOn, opt => opt.MapFrom(x => x.PostOn.ToString("dd-MMM-yyyy")))
                    .ForMember(x => x.LikesCount, opt => opt.MapFrom(x => x.Likes.Count))
                    .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));

                cfg.CreateMap<Post, GetPostCommentsDTO>();
            });
        }

        public MapperConfiguration ConfigMessage()
        {
            return new MapperConfiguration(cfg =>
            {
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
