using AutoMapper;
using Project.BusinessLogicLayer.DTOClasses;
using Project.WebAPI.Models.RequestModels.AppUser;
using Project.WebAPI.Models.RequestModels.Category;
using Project.WebAPI.Models.RequestModels.Order;
using Project.WebAPI.Models.RequestModels.Product;
using Project.WebAPI.Models.ResponseModels.CategoryResponseModels;
using Project.WebAPI.Models.ResponseModels.OrderResponseModels;
using Project.WebAPI.Models.ResponseModels.ProductResponseModels;

namespace Project.WebAPI.Models.MappingService
{
    public class ResponseAndRequstMapping : Profile
    {
        public ResponseAndRequstMapping()
        {
            CreateMap<CreateUserRequestModel, AppUserDTO>();

           

            CreateMap<CategoryDTO, CategoryResponseModel>();
            CreateMap<ProductDTO, ProductResponseModel>().ReverseMap();
            CreateMap<OrderDTO, OrderResponseModel>();

            CreateMap<CreateCategoryRequestModel, CategoryDTO>();
            CreateMap<CreateProductRequestModel, ProductDTO>();
            CreateMap<CreateOrderRequestModel, OrderDTO>();

            CreateMap<UpdateCategoryRequestModel, CategoryDTO>();
            CreateMap<UpdateProductRequestModel, ProductDTO>();
            CreateMap<UpdateOrderRequestModel, OrderDTO>();
        }
    }
}
