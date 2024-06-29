using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.IRepository
{
    public interface INotesRepository
    {
        Task<Notes> GetById(int id);
        Task<bool> CreatenewNote(Notes entity);
        IQueryable GetAllNotes();
        Task<bool> UpdateNote(Notes entity);
        Task<bool> DeleteNote(int id);
        Task<User> GetAuthor(Notes entity);
        Task<bool> SaveChangesAsync();
    }
}
