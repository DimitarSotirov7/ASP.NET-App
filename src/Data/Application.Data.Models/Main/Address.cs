namespace Application.Data.Models.Main
{
    using Application.Data.Common.Models;
    using System.Collections.Generic;

    public class Address : BaseDeletableModel<int>
    {
        public Address()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public string City { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
