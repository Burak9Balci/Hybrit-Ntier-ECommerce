using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models.Domains
{
    public class OrderDetail : BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        //Rs Props
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
