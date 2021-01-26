using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Mapping.PostDTOModels
{
    public class PostCommentsDTO
    {
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
