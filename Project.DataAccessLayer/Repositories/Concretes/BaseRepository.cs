using Microsoft.EntityFrameworkCore;
using Project.DataAccessLayer.ContextClasses;
using Project.DataAccessLayer.Repositories.Abstracts;
using Project.Entities.Models.Enums;
using Project.Entities.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
           await SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }

 
        public async Task<T> FindAsync(int? id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
           await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T originalEntity, T newEntity)
        {
           
            _db.Entry(originalEntity).CurrentValues.SetValues(newEntity);
            await SaveChangesAsync();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
