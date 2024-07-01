using AutoMapper;
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
    public class NoteServise:INoteService
    {
        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;
        public NoteServise(INotesRepository notesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notesRepository = notesRepository;

        }
        public async Task<bool> CreateNewNote(Notes_S entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                Notes note=_mapper.Map<Notes>(entity);
                await _notesRepository.CreatenewNote(note);
               await _notesRepository.SaveChangesAsync();
                return true;

            }
        }

        public async Task<bool> DeleteNote(int id)
        {
            await _notesRepository.DeleteAsync(id);
            return true;
        }

        public IEnumerable<Notes_S> GetAllNotes()
        {
            IEnumerable<Notes> notes= _notesRepository.GetAllAsync();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Notes, Notes_S>()).CreateMapper();
            IEnumerable<Notes_S> notess = mapper.Map<IEnumerable<Notes>, List<Notes_S>>(notes);
            return notess;
        }

        public async Task<User_S> GetAuthor(Notes_ entity)
        {
           var user= _notesRepository.GetAuthor(entity);
             User_S user = _mapper.Map<User>(user);

        }

        public async Task<Notes> GetById(int id)
        {
            return await _notesRepository.GetByIdAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _notesRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateNote(Notes entity)
        {
            await _notesRepository.UpdateAsync(entity);
            return true;
        }

    }
}
