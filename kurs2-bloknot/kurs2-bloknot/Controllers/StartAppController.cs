using AutoMapper;
using DayaAcces.Model;
using kurs2_bloknot.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using Service_Layer.Model;
using static Azure.Core.HttpHeader;
using System.Collections.Generic;

namespace kurs2_bloknot.Controllers
{
    public class StartAppController : Controller
    {
        private readonly IUserService _user;
        private readonly INoteService _notes;
        private readonly IMapper _mapper;
        public StartAppController(IUserService user, IMapper mapper,INoteService notes)
        {
            _user = user;
            _mapper = mapper;
            _notes = notes;
        }
        public IActionResult Index()
        {
            ViewBag.Username = User.Identity.Name;
            return View("StartApp");
        }
        [Authorize(Roles = "User")]
        public IActionResult Getall( )
        {
         
          
            UserDto u=_user.GetAllUser().Where(p=>p.Login== User.Identity.Name).FirstOrDefault();
            if (u != null)
            {
                var user1 = _notes.GetAllNotesforUser(u);
                List<NotesCreated> notes = _mapper.Map<IEnumerable<NoteDto>, List<NotesCreated>>(user1);

                ViewBag.MyNotes = notes;
                //var model = notes;
            }
           
         return View("ListofNotes");
        }
        public IActionResult GetN()
        {
          ViewBag.Test=  _notes.GetAllNotes();

            return View("TestNotes");
        }
    }


}
