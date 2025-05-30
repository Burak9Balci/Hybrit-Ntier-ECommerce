using AutoMapper;
using Project.BusinessLogicLayer.DTOClasses;
using Project.WebAPI.Models.RequestModels;
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
            CreateMap<UserRequestModel, AppUserDTO>();

            CreateMap<List<CategoryDTO>, List<CategoryResponseModel>>();
            CreateMap<List<ProductDTO>, List<ProductResponseModel>>();
            CreateMap<List<OrderDTO>, List<OrderResponseModel>>();

            CreateMap<CategoryDTO, CategoryResponseModel>();
            CreateMap<ProductDTO, ProductResponseModel>();
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
