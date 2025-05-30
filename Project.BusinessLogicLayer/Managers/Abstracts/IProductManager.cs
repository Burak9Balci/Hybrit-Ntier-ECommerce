using Project.BusinessLogicLayer.DTOClasses;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Abstracts
{
    public interface IProductManager:IManager<ProductDTO,Product>
    {
        public Task AddProductAsync(ProductDTO productDTO);
    }
}
