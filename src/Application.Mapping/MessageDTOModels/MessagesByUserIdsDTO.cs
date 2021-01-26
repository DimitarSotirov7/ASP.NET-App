using Application.Models.UserStuffs;
using System.Collections.Generic;

namespace Application.Mapping.MessageDTOModels
{
    public class MessagesByUserIdsDTO
    {
        public ICollection<Message> Messages { get; set; }
    }
}
