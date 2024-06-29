using AutoMapper;
using AutoMapper.QueryableExtensions;
using DayaAcces.BaserRepository;
using DayaAcces.IRepository;
using DayaAcces.Model;
using kurs2_bloknot.Models;
using Microsoft.EntityFrameworkCore;

namespace kurs2_bloknot.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _irepository;
        private readonly IMapper _mapper;
        User_View qw;

        public UserRepository(IRepository<User> irepository, IMapper mapper)
        {
            _irepository = irepository;
            _mapper = mapper;
        }

        public Task<User_View[]> GetAllUser()
        {
            return  _irepository.GetAllAsync().ProjectTo<User_View>(_mapper.ConfigurationProvider).ToArrayAsync();
            

            
        }

        //method get parameter by Id
        public async Task<User_View> GetUserIdAsync(int id)
        {

            var inf= await _irepository.GetByIdAsync(id);
            return _mapper.Map<User_View>(inf);
        }
        //method add new item
        public async Task<bool> AddAsync(User_Created entity)
        {
            var user=_mapper.Map<User>(entity);
            await _irepository.AddAsync(user);
            return true;
        }
        //method update item
        public async Task<bool> UpdateAsync(User_Created entity)
        {
            var user=_mapper.Map<User>(entity);
            await _irepository.UpdateAsync(user);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _irepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> GetPass(string pass, string log)
        {
            var q = await _irepository.GetInfo(pass);
            var z = await _irepository.GetInfo(log);
            if ((q != null) && (z != null))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
