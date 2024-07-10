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
        Task<bool> CreateNewUser(UserDto entity);
        //Get User Infor
        Task<UserDto> GetUser(int id);
        //Get all User
        IEnumerable<UserDto> GetAllUser();
        // Update user
        Task<bool> UpdateUser(UserDto entity);
        //Delete  user
        Task<bool> DeleteUser(int id);
        Task<bool> CheckPassword(string entity1, string entity2);

        Task<UserDto> Validation(string entity1, string entity2);



    }
}
