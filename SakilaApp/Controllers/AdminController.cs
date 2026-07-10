using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SakilaApp.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}