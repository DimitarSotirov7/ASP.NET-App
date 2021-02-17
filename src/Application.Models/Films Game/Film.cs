using Application.Models.Common;
using System;

namespace Application.Models.Films_Game
{
    public class Film : BaseModel<string>
    {
        public Film()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
    }
}
