using DayaAcces.IRepository;
using DayaAcces.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.BaserRepository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        private ModelContext Context;
        private DbSet<T> Entity;
        public BaseRepository(ModelContext MyContext)
        {
            Context = MyContext;
            Entity = Context.Set<T>();
        }
        //method get all parameters
        public IEnumerable<T> GetAllAsync()
        {
            return  Entity;
        }

        //method get parameter by Id
        public async Task<T> GetByIdAsync(int id)
        {

            return await Entity.FindAsync(id);
        }
        //method add new item
        public async Task<bool> AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
            await SaveChangesAsync();
            return true;
        }
        //method update item
        public async Task<bool> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await Entity.FindAsync(id);
            if (entity == null) return false;

            Entity.Remove(entity);
            await SaveChangesAsync();
            return true;
        }
        //method saving changes
        public async Task<bool> SaveChangesAsync()
        {
            await Context.SaveChangesAsync();

            return true;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> GetInfo(string pass)
        {
            var q = await Entity.FindAsync(pass);
            ;
            if (q != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
