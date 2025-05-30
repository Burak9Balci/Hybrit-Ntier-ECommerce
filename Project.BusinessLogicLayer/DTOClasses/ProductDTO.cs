using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.DTOClasses
{
    public class ProductDTO : BaseDTO
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? CategoryName { get; set; }
        public short? Stock { get; set; }
        public int? CategoryID { get; set; }
        public string? ImagePath { get; set; }
    }
}
