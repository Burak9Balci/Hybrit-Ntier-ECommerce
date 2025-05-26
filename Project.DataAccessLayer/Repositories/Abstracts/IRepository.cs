using Project.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Repositories.Abstracts
{
    public interface IRepository<T> where T: IEntity
    {
        //List Comands
        Task<List<T>> GetAllAsync();
        Task AddAsync(T item);
        Task UpdateAsync(T originalEntity, T newEntity);

        List<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FindAsync(int id);
    }
}
