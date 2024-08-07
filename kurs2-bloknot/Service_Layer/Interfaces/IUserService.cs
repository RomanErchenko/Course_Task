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
        Task<UserDto> GetUser(Guid id);
        //Get all User
        IEnumerable<UserDto> GetAllUser();
        // Update user
        Task<bool> UpdateUser(UserDto entity);
        //Delete  user
        Task<bool> DeleteUser(Guid id);
       //bool CheckPassword(string entity1, string entity2);
        UserDto CheckPass(string entity1);

       // UserDto Validation(string entity1, string entity2);



    }
}
