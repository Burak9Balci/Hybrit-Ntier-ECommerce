using AutoMapper;
using Project.BusinessLogicLayer.DTOClasses;
using Project.BusinessLogicLayer.Managers.Abstracts;
using Project.DataAccessLayer.Repositories.Abstracts;
using Project.Entities.Models.Enums;
using Project.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Concretes
{
    public class BaseManager<T, U> : IManager<T, U> where T : BaseDTO where U : class, IEntity
    {
        IRepository<U> _repository;
        IMapper _mapper;
        public BaseManager(IMapper mapper, IRepository<U> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task AddAsync(T item)
        {
            U domain = _mapper.Map<U>(item);
            await _repository.AddAsync(domain);
        }

        public async Task<bool> AnyAsync(Expression<Func<U, bool>> exp)
        {
          return await _repository.AnyAsync(exp);
        }

        public async Task DeleteAsync(int id)
        {
          
            U item = await _repository.FindAsync(id);
            item.DeletedDate = DateTime.Now;
            item.Status = DataStatus.Deleted;
            await _repository.SaveChangesAsync();
        }

        public async Task<U> FindAsync(int id)
        {
          return await _repository.FindAsync(id);
        }

        public List<T> GetActives()
        {
            List<U> values =  _repository.Where(x => x.Status != DataStatus.Deleted);
            return _mapper.Map<List<T>>(values);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<U> values = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(values);
        }

        public List<T> GetModifieds()
        {
            List<U> values = _repository.Where(x =>x.Status == DataStatus.Updated);
            return _mapper.Map<List<T>>(values);
        }

        public List<T> GetPassives()
        {
            List<U> value = _repository.Where(x =>x.Status == DataStatus.Deleted);
            return _mapper.Map<List<T>>(value);
        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = DataStatus.Updated;
            U entity = _mapper.Map<U>(item);
            U old = await _repository.FindAsync(entity.ID);
            await _repository.UpdateAsync(old, entity);
           
        }

    }
}
