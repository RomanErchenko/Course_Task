﻿using AutoMapper;
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
        public async Task<bool> CreateNewNote(NoteDto entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                Notes note=_mapper.Map<Notes>(entity);
                await _notesRepository.CreateNewNote(note);
              
                return true;

            }
        }
            
        public async Task<bool> DeleteNote(Guid id)
        {
           await _notesRepository.DeleteAsync(id);
           
            return true;
        }

        public IEnumerable<NoteDto> GetAllNotes()
        {
            IEnumerable<Notes> notes= _notesRepository.GetAllNotes();
            IEnumerable<NoteDto> notess = _mapper.Map<IEnumerable<Notes>, List<NoteDto>>(notes);
            return notess;
        }

        public IEnumerable<NoteDto> GetAllNotesforUser(UserDto entity)
        {
            User user = _mapper.Map<User>(entity);
            var p =  _notesRepository.GetAllNotes().Where(p => p.UserId == entity.Id).ToList();
           // var notes=   p.Where(p=>p.UserId==entity.Id).ToList();
            IEnumerable<NoteDto> notess = _mapper.Map<IEnumerable<Notes>, List<NoteDto>>(p);

            return notess;


        }

        public async Task<UserDto> GetAuthor(NoteDto entity)
        {
            Notes note = _mapper.Map<Notes>(entity);
            var user= await  _notesRepository.GetAuthor(note);

             UserDto userdto = _mapper.Map<UserDto>(user);
            return  userdto;
            
        }



        public async Task<NoteDto>? GetNote(Guid id)
        {
            var note = await _notesRepository.GetById(id);
            NoteDto notes = _mapper.Map<NoteDto>(note);
            return notes;
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _notesRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateNotes(NoteDto entity)
        {
            Notes note = _mapper.Map<Notes>(entity);
            await _notesRepository.UpdateAsync(note);
            return true;
        }

    }
}
