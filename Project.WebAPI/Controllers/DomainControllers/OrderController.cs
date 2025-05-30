using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.WebAPI.Models.RequestModels.Order;
using Project.WebAPI.Models.ResponseModels.OrderResponseModels;

namespace Project.WebAPI.Controllers.DomainControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       readonly IMapper _mapper;
        readonly IOrderManager _orderManager;
        public OrderController(IMapper mapper,IOrderManager orderManager)
        {
            _mapper = mapper;
            _orderManager = orderManager;

        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            List<OrderResponseModel> orders = _mapper.Map<List<OrderResponseModel>>(_orderManager.GetActives());
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            OrderResponseModel orderResponse = _mapper.Map<OrderResponseModel>(await _orderManager.FindAsync(id));
            return Ok(orderResponse);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestModel updateOrder)
        {
            await _orderManager.UpdateAsync(_mapper.Map<OrderDTO>(updateOrder))                                                                                        ;
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderManager.DeleteAsync(id);
            return Ok();
        }
    }
}
