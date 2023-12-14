using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Index(string lang)
        {
            Response.Cookies.Append("Language", lang);

            return RedirectToAction("Index", "Home");
        }
    }
}
