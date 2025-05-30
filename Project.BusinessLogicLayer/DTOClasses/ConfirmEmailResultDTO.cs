using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.DTOClasses
{
    public class ConfirmEmailResultDTO
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
