using Business.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _manager;

        public HomeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            HomeVM vm = new()
            { 
               ServiceLanguages = _manager.GetAll(langCode),
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}