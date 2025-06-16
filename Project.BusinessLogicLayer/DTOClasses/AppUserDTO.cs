using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.DTOClasses
{
    public class AppUserDTO : BaseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid ActivationCode { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
