using AutoMapper;
using kurs2_bloknot.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace kurs2_bloknot.Controllers
{
    public class AuthController : Controller
    {
       private readonly IUserRepository user;
       private readonly IMapper mapper;

        public AuthController(IUserRepository _user, IMapper _mapper)
        {
            user = _user;
            mapper = _mapper;
        }
        public IActionResult EnterLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnterLogin(string login, string password)
        {
            bool check = await user.GetPass(login, password);
            return View(check);
        }
    }
}
