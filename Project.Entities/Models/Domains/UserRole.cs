using Microsoft.AspNetCore.Identity;
using Project.Entities.Models.Enums;
using Project.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models.Domains
{
    public class UserRole : IdentityUserRole<int>, IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        

        // Rs 
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
