using AutoMapper;
using Project.BusinessLogicLayer.DTOClasses;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.DTOMappers
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            CreateMap<User, AppUserDTO>().ReverseMap();
      
            CreateMap<Role, AppRoleDTO>().ReverseMap();
        
            CreateMap<Category, CategoryDTO>().ReverseMap();
   
            CreateMap<Product, ProductDTO>().ReverseMap();
  
            CreateMap<Order, OrderDTO>().ReverseMap();
         
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
