using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.WebAPI.Models.RequestModels.Category;
using Project.WebAPI.Models.ResponseModels.CategoryResponseModels;

namespace Project.WebAPI.Controllers.DomainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       readonly IMapper _mapper;
        readonly ICategoryManager _categoryManager;
        public CategoryController(IMapper mapper,ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetCategories(CategoryResponseModel responseModel)
        {
            List<CategoryResponseModel> categories = _mapper.Map<List<CategoryResponseModel>>(_categoryManager.GetActives()); 
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
           CategoryResponseModel categoryResponse = _mapper.Map<CategoryResponseModel>(await _categoryManager.FindAsync(id));
            return Ok(categoryResponse);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryRequestModel createCategory)
        {
            CategoryDTO category = _mapper.Map<CategoryDTO>(createCategory);
            await _categoryManager.AddAsync(category);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestModel updateCategory)
        {
            CategoryDTO category = _mapper.Map<CategoryDTO>(updateCategory);
            await _categoryManager.UpdateAsync(category);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryManager.DeleteAsync(id);
            return Ok();
        }
    }
}
