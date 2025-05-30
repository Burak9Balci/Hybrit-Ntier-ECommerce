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
    public class ProductManager : BaseManager<ProductDTO, Product>, IProductManager
    {
        readonly IMapper _mapper;
        readonly IRepository<Product> _repositoryPro;
        readonly IRepository<Category> _repositoryCat;
        public ProductManager(IMapper mapper, IRepository<Product> repositoryPro,IRepository<Category> repositoryCat) : base(mapper, repositoryPro)
        {
            _mapper = mapper;
            _repositoryPro = repositoryPro;
            _repositoryCat = repositoryCat;
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            product.CategoryName = (await _repositoryCat.FindAsync(product.CategoryID)).CategoryName;
            await _repositoryPro.AddAsync(product);
        }
    }
}
