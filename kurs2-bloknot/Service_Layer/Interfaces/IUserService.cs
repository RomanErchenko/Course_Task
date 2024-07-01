using Service_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces
{
    public interface IUserService
    {
        //Create User
        Task<bool> CreateNewUser(User_S entity);
        //Get User Infor
        Task<User_S> GetUser(int id);
        //Get all User
        IQueryable GetAllUser();
        // Update user
        Task<bool> UpdateUser(User_S entity);
        //Delete  user
        Task<bool> DeleteUser(int id);


    }
}
