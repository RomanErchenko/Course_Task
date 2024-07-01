using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.IRepository
{
    public interface INotesRepository:IRepository<Notes>
    {
        Task<Notes> GetById(int id);
        Task<bool> CreatenewNote(Notes entity);
        IEnumerable<Notes> GetAllNotes();
        Task<bool> UpdateNote(Notes entity);
        Task<bool> DeleteNote(int id);
        Task<User> GetAuthor(Notes entity);
        new Task<bool> SaveChangesAsync();
    }
}
