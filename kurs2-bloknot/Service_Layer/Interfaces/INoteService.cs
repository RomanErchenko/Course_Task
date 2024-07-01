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
        Task<bool> CreateNewNote(NoteDto entity);
        //Get Note Info
        Task<NoteDto> GetNote(int id);
        //Get all Notes
        IEnumerable<NoteDto> GetAllNotes();
        // Update Note
        Task<bool> UpdateNotes(NoteDto entity);
        //Delete  Note
        Task<bool> DeleteNote(int id);

        IEnumerable<NoteDto> GetAllNotesforUser(UserDto entity);

    }
}
