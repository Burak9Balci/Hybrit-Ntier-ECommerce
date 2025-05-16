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
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();

        Task AddAsync(T item);
        Task Update(T item);
        Task Delete(T item);

        List<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
        Task<T> FindAsync(int id);
    }
}
