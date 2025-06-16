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

        public List<ProductDTO> GetProductsByCategoryName(string categoryName)
        {
           return _mapper.Map<List<ProductDTO>>(_repositoryPro.Where(x =>x.CategoryName == categoryName));
        }
    }
}
