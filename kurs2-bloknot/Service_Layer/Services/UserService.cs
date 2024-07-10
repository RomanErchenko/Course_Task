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
                await _userRepository.SaveChangesAsync();
                return true;

            }
        }

        public  async Task<bool> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            return true;
        }

        public IEnumerable<UserDto> GetAllUser()
        {
            IEnumerable<User> notes = _userRepository.GetAllAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();
            IEnumerable<UserDto> user = mapper.Map<IEnumerable<User>, List<UserDto>>(notes);
            return user;
        }

        public async Task<UserDto> GetUser(int id)
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
            User p = _userRepository.GetAllUser().Where(p=>p.Login==login && j=>j.Password == password).FirstOrDefault();
            return p;
        }

       public  bool CheckPassword(UserDto entity)
        {
            if (entity == null)
            {
                return false;

            }
            
                var p =  _userRepository.GetAllUser().ToList();
            if (p != null)
            {
                return false;
            }
            else
            {
                return true;
            
            }
        
        }
    }
}
