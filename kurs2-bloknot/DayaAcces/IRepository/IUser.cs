using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.IRepository
{
    public interface IUser<T>
    {
        Task<T> GetById(int id);
        Task<bool> CreatenewUser(T entity);
        IQueryable GetAllUserNotes();
        Task<bool> UpdateUser(T entity);
        Task<bool> DeleteUser(int id);
        Task<bool> SaveChangesAsync();

    }
}
