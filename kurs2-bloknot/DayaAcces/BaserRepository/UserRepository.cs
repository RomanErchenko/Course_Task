using AutoMapper;
using DayaAcces.IRepository;
using DayaAcces.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.BaserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private ModelContext Context;

        public UserRepository(ModelContext context):base(context) 
        {
            Context = context;  
        
        }
        public async Task<bool> CreatenewUser(User entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                await Context.Users.AddAsync(entity);
                await SaveChangesAsync();
                return true;

            }

        }

        public async Task<bool> DeleteUser(Guid id)
        {
            await Context.Notess.Where(p => p.Id == id).ExecuteDeleteAsync();
            
            return true;
        }

        public IEnumerable<User> GetAllUserNotes()
        {
            return Context.Users.Include(p => p.Note).ToList();
        }
        public IEnumerable<User> GetAllUser()
        {
            return Context.Users.ToList();
        }

        public async Task<User>? GetById(Guid id)
        {
            return await Context.Users.FindAsync(id);
        }

      new  public async Task<bool> SaveChangesAsync()
        {

            await Context.SaveChangesAsync();
           
            return true;
        }

        public async Task<bool> UpdateUser(User entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                Context.Entry(entity).State = EntityState.Modified;
                await SaveChangesAsync();
                return true;
            }
        }
    }
}
