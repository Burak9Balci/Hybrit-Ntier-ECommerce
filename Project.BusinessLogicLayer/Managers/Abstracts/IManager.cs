using Project.BusinessLogicLayer.DTOClasses;
using Project.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogicLayer.Managers.Abstracts
{
    public interface IManager<T, U> where T : BaseDTO where U : class, IEntity
    {

        Task<List<T>> GetAllAsync();
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();

        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
      
        Task<bool> AnyAsync(Expression<Func<U, bool>> exp);
        Task<T> FindAsync(int id);
    }
}
