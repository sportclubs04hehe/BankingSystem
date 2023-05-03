using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingWeb.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class HomeManagerAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
