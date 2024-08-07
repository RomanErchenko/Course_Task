using DayaAcces.Model;
using kurs2_bloknot.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using Service_Layer.Interfaces;
using Service_Layer.Model;
using static Azure.Core.HttpHeader;

namespace kurs2_bloknot.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public AccountController(IUserService user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                bool userAlreadyExists = _user.GetAllUser().Any(x => x.Login == model.Login);
                if (userAlreadyExists)
                {
                    ModelState.AddModelError(nameof(model.Login), "Login is already in use");
                    return View(model);
                }
                var newUser = new UserCreated()
                {
                    Id = Guid.NewGuid(),
                    Login = model.Login,
                    Name = model.Name,
                    Password = PasswordHasher.HashPassword(model.Password)
                };
                UserDto us = _mapper.Map<UserDto>(newUser);
                _user.CreateNewUser(us);
                return RedirectToAction("Index", "StartApp");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View("SignIN");
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginBindingModel model)
        {
           
            var serviceModel  = _mapper.Map<LoginServiceModel>(model);

            if (ModelState.IsValid)
            {
                var userOrNull = _user.CheckPass(model.Login);
                var userOrNull1=_mapper.Map<UserCreated>(userOrNull);
                //var userOrNull = Database.Users.FirstOrDefault(x => x.Login == model.Login);
                if (userOrNull1 is UserCreated user)
                {
                    var isCorrectPassword = PasswordHasher.IsCorrectPassword(user, model.Password);
                    if (isCorrectPassword)
                    {
                        await SignInAsync(user);
                        return RedirectToAction("Index", "StartApp");
                    }
                }
                ModelState.AddModelError("", "Wrong login or password");
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "StartApp");
        }

        private async Task SignInAsync(UserCreated user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "User"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
        }

        public IActionResult Complete()
        {
            ViewBag.Username = User.Identity.Name;
            return View();
        }
        public IActionResult GetAllUser()
        { 
          var user=_user.GetAllUser().ToList();
           List<UserCreated> users = _mapper.Map<IEnumerable<UserDto>, List<UserCreated>>(user);
            ViewBag.AllUsers=users;
            return View("GetAllUsers");
        }
        
    }
}
