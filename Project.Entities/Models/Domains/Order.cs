using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models.Domains
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public int? AppUserID { get; set; }

        //Rs Prop
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
