using DayaAcces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.IRepository
{
    public interface INotesRepository<T>
    {
        Task<T> GetById(int id);
        Task<bool> CreatenewNote(T entity);
        IQueryable GetAllNotes();
        Task<bool> UpdateNote(T entity);
        Task<bool> DeleteNote(int id);
        Task<User> GetAuthor(T entity);
        Task<bool> SaveChangesAsync();
    }
}
