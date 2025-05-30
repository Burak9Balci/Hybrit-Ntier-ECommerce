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
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<List<AppUser>, List<AppUserDTO>>().ReverseMap();
            CreateMap<AppRole, AppRoleDTO>().ReverseMap();
            CreateMap<List<AppRole>, List<AppRoleDTO>>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<List<Category>, List<CategoryDTO>>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<List<Product>, List<ProductDTO>>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<List<Order>, List<OrderDTO>>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
