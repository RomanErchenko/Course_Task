using AutoMapper;
using DayaAcces.Model;
using kurs2_bloknot.Models;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using Service_Layer.Model;

namespace kurs2_bloknot.Controllers
{
    public class NoteController : Controller
    {
        private readonly IUserService _user;
        private readonly INoteService _notes;
        private readonly IMapper _mapper;
        public NoteController(IUserService user, IMapper mapper, INoteService notes)
        {
            _user = user;
            _mapper = mapper;
            _notes = notes;
        }
        [HttpGet]
        public IActionResult CreateNote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNote(NotesCreated note)
        {
            UserDto us=_user.GetAllUser().Where(p=>p.Login== User.Identity.Name).FirstOrDefault();
            NoteDto note1= _mapper.Map<NoteDto>(note);
            if (us != null)
            {
                note1.UserId = us.Id;
                note1.Date = DateTime.Now;
                _notes.CreateNewNote(note1);
            }
            else
            {

               
                return View("Error");
            }

            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Update(Guid id)
        {
            NoteDto user = await _notes.GetNote(id);
            
            NotesCreated note = _mapper.Map<NotesCreated>(user);
            return View("Update", note);
           
        }

        [HttpPost]
        public async Task<ActionResult> Update(NotesCreated p)
        {
           
            p.Date = DateTime.Now;

            NoteDto note = _mapper.Map<NoteDto>(p);


            await _notes.UpdateNotes(note);

            return RedirectToAction("Index","StartApp");

        }
        public async Task<ActionResult> Delete(Guid id)
        {
            await _notes.DeleteNote(id);

            return RedirectToAction("Index", "StartApp");
        }
    }
}
