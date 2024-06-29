using kurs2_bloknot.Models;

namespace kurs2_bloknot.Repositories
{
    public interface IUserRepository
    {
        Task<bool> GetPass(string pass, string log);
        Task<User_View[]> GetAllUser();
        Task<User_View> GetUserIdAsync(int id);
        Task<bool> AddAsync(User_Created entity);
        Task<bool> UpdateAsync(User_Created entity);
        Task<bool> DeleteAsync(int id);
        
    }
}
