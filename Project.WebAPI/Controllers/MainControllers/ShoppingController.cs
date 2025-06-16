using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.Entities.Models.Domains;
using Project.WebAPI.Models.SessionService;
using Project.WebAPI.Models.ShoppingTools;

namespace Project.WebAPI.Controllers.MainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        IProductManager _productManager;
        IMapper _mapper;
        public ShoppingController(IProductManager productManager,IMapper mapper)
        {
            _mapper = mapper;
            _productManager = productManager;
        }
        
        
        void SetCartToSession(Cart c,string key)
        {
            HttpContext.Session.SetObject(key, c);
        }
        Cart GetCartFromSession(string key) 
        {
            return HttpContext.Session.GetObject<Cart>(key);
        }
        void ControlCart(Cart c)
        {
            if (c.GetCartItems.Count == 0) HttpContext.Session.Remove("kcart");
        }
        [HttpGet]
        public IActionResult CartPage()
        {
            if (GetCartFromSession("kcart") != null)
            {
                Cart c = GetCartFromSession("kcart");
                return Ok(c);
            }
            return Ok("Cart Boş");

        }
        [HttpPost("AddToCart/{id}")]
        public async Task<IActionResult> AddToCart(int id)
        {
            Cart c = GetCartFromSession("kcart") ?? new Cart();

            ProductDTO p = await _productManager.FindAsync(id);
            if (p == null) return NotFound("Ürün bulunamadı.");

            CartItem cartItem = new()
            {
                ID = p.ID,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                CategoryName = string.IsNullOrEmpty(p.CategoryName) ? "Kategorisi yok" : p.CategoryName
            };

            c.AddToCart(cartItem);
            SetCartToSession(c, "kcart");

            return Ok("Ekleme yapıldı");

        }
        [HttpDelete("{id}")]
        public  IActionResult RemoveFromCart(int id)
        {
            if (GetCartFromSession("kcart") != null)
            {
                Cart c = GetCartFromSession("kcart");
                c.RemoveFromCart(id);
                SetCartToSession(c,"kcart");
                ControlCart(c);
                return Ok("Sepetten cıkartıldı");
            }
            return Ok();
        }
        [HttpPost("DecreaseCartItem/{id}")]
        public IActionResult DecreaseCartItem(int id)
        {
            if(GetCartFromSession("kcart") != null)
            {
                Cart c = GetCartFromSession("kcart");
                c.Decrease(id);
                SetCartToSession(c,"kcart");
                ControlCart(c);
                return Ok("Eksiltildi");
            }
            return Ok();
        }
        [HttpPost("IncreaseCartItem/{id}")]
        public IActionResult IncreaseCartItem(int id)
        {
            if (GetCartFromSession("kcart") != null)
            {
                Cart c = GetCartFromSession("kcart");
                c.Increase(id);
                SetCartToSession(c, "kcart");
                ControlCart(c);
                return Ok("Artırıldı");
            }
            return Ok();
           
        }
    }
}
