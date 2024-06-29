using AutoMapper;
using DayaAcces.IRepository;
using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.BaserRepository
{
    public class NoteRepository : INotesRepository<Notes>
    {
        private readonly IRepository<Notes> _notesRepository;
        private readonly IMapper _mapper;
        public NoteRepository(IRepository<Notes> notesRepository,IMapper mapper)
        {
         _mapper = mapper;
         _notesRepository = notesRepository;
        
        }
       public  async Task<bool> CreatenewNote(Notes entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
              await _notesRepository.AddAsync(entity);
                return true;
            
            }
        }

      public async Task<bool> DeleteNote(int id)
        {
           await _notesRepository.DeleteAsync(id);
            return true;
        }

       public IQueryable GetAllNotes()
        {
           return _notesRepository.GetAllAsync();
            
        }

      public async  Task<User> GetAuthor(Notes entity)
        {
            var p= entity.User;
            return  p;
        }

      public async  Task<Notes> GetById(int id)
        {
            return await _notesRepository.GetByIdAsync(id);
        }

      public  async Task<bool> SaveChangesAsync()
        {
            await _notesRepository.SaveChangesAsync();
            return true;
        }

      public async  Task<bool> UpdateNote(Notes entity)
        {
            _notesRepository.UpdateAsync(entity);
            return true;
        }


    }
}
