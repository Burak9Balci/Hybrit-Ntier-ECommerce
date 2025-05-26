using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.DTOClasses
{
    public class OrderDTO : BaseDTO
    {
        public string ShippingAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public int AppUserID { get; set; }
    }
}
