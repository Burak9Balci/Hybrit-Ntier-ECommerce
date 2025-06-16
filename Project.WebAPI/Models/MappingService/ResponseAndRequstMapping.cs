using AutoMapper;
using Project.BusinessLogicLayer.DTOClasses;
using Project.WebAPI.Models.RequestModels.AppRole;
using Project.WebAPI.Models.RequestModels.AppUser;
using Project.WebAPI.Models.RequestModels.Category;
using Project.WebAPI.Models.RequestModels.Order;
using Project.WebAPI.Models.RequestModels.Product;
using Project.WebAPI.Models.ResponseModels.AppRole;
using Project.WebAPI.Models.ResponseModels.AppUserResponseModels;
using Project.WebAPI.Models.ResponseModels.CategoryResponseModels;
using Project.WebAPI.Models.ResponseModels.OrderResponseModels;
using Project.WebAPI.Models.ResponseModels.ProductResponseModels;

namespace Project.WebAPI.Models.MappingService
{
    public class ResponseAndRequstMapping : Profile
    {
        public ResponseAndRequstMapping()
        {
            

           

            CreateMap<CategoryDTO, CategoryResponseModel>();
            CreateMap<ProductDTO, ProductResponseModel>();
            CreateMap<OrderDTO, OrderResponseModel>();
            CreateMap<AppUserDTO, AppUserResponseModel>();
            CreateMap<AppRoleDTO, AppRoleResponseModel>();


            CreateMap<CreateCategoryRequestModel, CategoryDTO>();
            CreateMap<CreateProductRequestModel, ProductDTO>();
            CreateMap<CreateOrderRequestModel, OrderDTO>();
            CreateMap<CreateUserRequestModel, AppUserDTO>();
            CreateMap<CreateAppRoleRequestModel, AppRoleDTO>();

            CreateMap<UpdateCategoryRequestModel, CategoryDTO>();
            CreateMap<UpdateProductRequestModel, ProductDTO>();
            CreateMap<UpdateOrderRequestModel, OrderDTO>();
            CreateMap<UpdateUserRequestModel, AppUserDTO>();
            CreateMap<UpdateAppRoleRequestModel, AppRoleDTO>();
        }
    }
}
