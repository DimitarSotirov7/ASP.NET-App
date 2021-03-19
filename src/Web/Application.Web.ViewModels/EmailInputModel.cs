namespace Application.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Application.Data.Models;
    using Application.Services.Mapping;
    using AutoMapper;

    public class EmailInputModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        [Required]
        public string FromName { get; set; }

        [Required]
        public string FromEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public string FromUserId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, EmailInputModel>()
                .ForMember(x => x.FromName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.FromEmail, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.FromUserId, opt => opt.MapFrom(x => x.Id));
        }
    }
}
