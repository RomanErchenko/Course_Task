using AutoMapper;
using DayaAcces.BaserRepository;
using DayaAcces.IRepository;
using DayaAcces.Model;
using Service_Layer.Interfaces;
using Service_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Service_Layer.Services
{
    public  class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

       

        public async Task<bool> CreateNewUser(UserDto entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                User user = _mapper.Map<User>(entity);
                await _userRepository.CreatenewUser(user);
                //await _userRepository.SaveChangesAsync();
                return true;

            }
        }

        public  async Task<bool> DeleteUser(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return true;
        }

        public IEnumerable<UserDto>? GetAllUser()
        {
            IEnumerable<User> notes = _userRepository.GetAllUser();        
            IEnumerable<UserDto> user = _mapper.Map<IEnumerable<User>, List<UserDto>>(notes);
            return user;
        }

        public async Task<UserDto>? GetUser(Guid id)
        {
            
            var user = await _userRepository.GetById(id);

            UserDto userdto = _mapper.Map<UserDto>(user);
            return userdto;

        }

        public async Task<bool> UpdateUser(UserDto entity)
        {
            User user = _mapper.Map<User>(entity);
            await _userRepository.UpdateAsync(user);
            return true;
        }

        public UserDto Validation(string login, string password)
        {
            User p = _userRepository.GetAllUser().Where(p=>p.Login==login).Where( p=>p.Password == password).First();
            UserDto user = _mapper.Map<UserDto>(p);
            return user;
        }

        //public bool CheckPassword(string login,string password)
        // {


        //         var p =  _userRepository.GetAllUser().Where(p=>p.Login==login).Where(p=>p.Password==password).ToList();
        //     if (p != null)
        //     {
        //         return false;

        //     }
        //     else
        //     {
        //         return true;

        //     }

        // }
        public UserDto CheckPass(string login)
        {


            var z = _userRepository.GetAllUser().Where(p => p.Login == login).FirstOrDefault();
            UserDto user = _mapper.Map<UserDto>(z);

           
            return user;

        }
    }
}
