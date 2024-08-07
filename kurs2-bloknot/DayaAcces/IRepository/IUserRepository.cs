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
        Task<User>? GetById(Guid id);
        Task<bool> CreatenewUser(User entity);
        IEnumerable<User> GetAllUserNotes();
        IEnumerable<User> GetAllUser();
        Task<bool> UpdateUser(User entity);
        Task<bool> DeleteUser(Guid id);
        new Task<bool> SaveChangesAsync();

    }
}
