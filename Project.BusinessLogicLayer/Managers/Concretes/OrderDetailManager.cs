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
    public class OrderDetailManager : BaseManager<OrderDetailDTO,OrderDetail>,IOrderDetailManager
    {
        public OrderDetailManager(IMapper mapper,IRepository<OrderDetail> repository) : base(mapper, repository)
        {

        }
    }
}
