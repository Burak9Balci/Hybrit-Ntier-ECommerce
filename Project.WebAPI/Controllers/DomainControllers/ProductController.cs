using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.BusinessLogicLayer.Managers.Concretes;
using Project.WebAPI.Models.RequestModels.Product;
using Project.WebAPI.Models.ResponseModels.ProductResponseModels;

namespace Project.WebAPI.Controllers.DomainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IProductManager _productManager;

        public ProductController(IMapper mapper,IProductManager productManager)
        {
            _mapper = mapper;
            _productManager = productManager;
  
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            List<ProductResponseModel> productResponses = _mapper.Map<List<ProductResponseModel>>(_productManager.GetActives());
            return Ok(productResponses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductResponseModel productResponse = _mapper.Map<ProductResponseModel>(await _productManager.FindAsync(id));
            return Ok(productResponse);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductRequestModel productRequest)
        {
            ProductDTO productDTO = _mapper.Map<ProductDTO>(productRequest);
            await _productManager.AddProductAsync(productDTO);
            return Ok("Ekleme yapıldı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel updateRequest)
        {
            ProductDTO productDTO = _mapper.Map<ProductDTO>(updateRequest);
            await _productManager.UpdateAsync(productDTO);
            return Ok("Güncelleme yapıldı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productManager.DeleteAsync(id);
            return Ok("Silme Yapıldı");
        }
    }
}
