using AutoMapper;
using kurs2_bloknot.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace kurs2_bloknot.Controllers
{
    public class AuthController : Controller
    {
        IUserRepository user;
        IMapper mapper;

        public AuthController(IUserRepository _user, IMapper _mapper)
        {
            user = _user;
            mapper = _mapper;
        }
        public IActionResult Enter_Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Enter_Login(string login, string password)
        {
            bool check = await user.GetPass(login, password);
            return View(check);
        }
    }
}
