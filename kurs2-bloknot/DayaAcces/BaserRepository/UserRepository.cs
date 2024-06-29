using AutoMapper;
using DayaAcces.IRepository;
using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.BaserRepository
{
    public class UserRepository : IUser<User>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserRepository(IRepository<User> userRepository, IMapper mapper)
        { 
            _userRepository = userRepository;
            _mapper = mapper;   
        
        }
        public async Task<bool> CreatenewUser(User entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                await _userRepository.AddAsync(entity);
                return true;

            }

        }

        public async Task<bool> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            return true;
        }

        public IQueryable GetAllUserNotes()
        {
            return _userRepository.GetAllAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {

            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUser(User entity)
        {
           await _userRepository.UpdateAsync(entity);
            return true;
        }
    }
}
