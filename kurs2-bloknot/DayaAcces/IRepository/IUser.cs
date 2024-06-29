using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.IRepository
{
    public interface IUser
    {
        Task<User> GetById(int id);
        Task<bool> CreatenewUser(User entity);
        IQueryable GetAllUserNotes();
        Task<bool> UpdateUser(User entity);
        Task<bool> DeleteUser(int id);
        Task<bool> SaveChangesAsync();

    }
}
