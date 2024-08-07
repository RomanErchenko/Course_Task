using AutoMapper;
using kurs2_bloknot.Models;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.Interfaces;
using Service_Layer.Model;

namespace kurs2_bloknot.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public AuthController(IUserService user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }
        public IActionResult LoginPage()
        { return View(); }

        //public bool CheckPassword(string login, string password)
        //{
        //    bool check = _user.CheckPassword(login, password);
        //    return check;
        //}
        public IActionResult CreateUser()
        {

            return View("CrateUser");
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateUser(UserCreated user)
        //{
        //    bool check = CheckPassword(user.Login, user.Password);
        //    if (check == true)
        //    {
        //        UserDto note = _mapper.Map<UserDto>(user);
        //       await _user.CreateNewUser(note);
            
            
        //    }
        //    return View();
        
    }
}
