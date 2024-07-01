using Service_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces
{
    public interface INoteService
    {
       //Create new note
        Task<bool> CreateNewNote(Notes_S entity);
        //Get Note Info
        Task<Notes_S> GetNote(int id);
        //Get all Notes
        IQueryable GetAllNotes();
        // Update Note
        Task<bool> UpdateNotes(Notes_S entity);
        //Delete  Note
        Task<bool> DeleteNote(int id);

        Task<Notes_S> GetAllNotesforUser(User_S entity);

    }
}
