using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.IRepository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetById(int id);
        Task<bool> CreatenewUser(User entity);
        IEnumerable<User> GetAllUserNotes();
        Task<bool> UpdateUser(User entity);
        Task<bool> DeleteUser(int id);
       new  Task<bool> SaveChangesAsync();

    }
}
