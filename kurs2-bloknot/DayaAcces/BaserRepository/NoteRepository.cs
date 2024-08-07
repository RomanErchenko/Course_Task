﻿using AutoMapper;
using DayaAcces.BaserRepository;
using DayaAcces.IRepository;
using DayaAcces.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.BaserRepository
{
    public class NoteRepository :BaseRepository<Notes>, INotesRepository
    {
        private ModelContext Context;

        public NoteRepository(ModelContext context) : base(context)
        {
            Context = context;

        }
        
      public async Task<bool> DeleteNote(Guid id)
        {
            
           var p= await Context.Notess.Where(p => p.Id == id).ExecuteDeleteAsync();
          
            return true;
        }

       public  IEnumerable<Notes> GetAllNotes()
        {
           return Context.Notess.Include(p=>p.User).ToList();
            
        }

        public IEnumerable<Notes> GetAll()
        {
            return Context.Notess.ToList();

        }

        public async  Task<User> GetAuthor(Notes entity)

        {
            return  await  Context.Users.Where(p=>p.Id==entity.User.Id).FirstAsync();
           
        }

      public async  Task<Notes> GetById(Guid id)
        {
            return await Context.Notess.Where(p=>p.Id==id).FirstAsync();
        }

     new public  async Task<bool> SaveChangesAsync()
        {
           await Context.SaveChangesAsync();
            return true;
        }

      public async  Task<bool> UpdateNote(Notes entity )
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                //Context.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                await SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> CreateNewNote(Notes entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {  
                
               await Context.Notess.AddAsync(entity);
               await SaveChangesAsync();
                return true;
            }
        }


    }
}
