using AutoMapper;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.DataAccessLayer.Repositories.Abstracts;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Concretes
{
    public class OrderManager : BaseManager<OrderDTO,Order>,IOrderManager
    {
        public OrderManager(IMapper mapper, IRepository<Order> repository): base(mapper,repository)
        {

        }
    }
}
