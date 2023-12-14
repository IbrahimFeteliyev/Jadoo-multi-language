using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using WebUI.Areas.admin.ViewModel;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceManager _manager;
        private IWebHostEnvironment _environment;

        public ServiceController(IServiceManager manager, IWebHostEnvironment environment)
        {
            _manager = manager;
            _environment = environment;
        }


        // GET: ServiceController
        public IActionResult Index()
        {
            var service = _manager.GetAll();
            return View(service);
        }

        // GET: ServiceController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        public IActionResult Create(Service service, List<string> Title, List<string> Description, List<string> LangCode, string ImageUrl)
        {
            _manager.Create(service);
            for (int i = 0; i < Title.Count; i++)
            {
                _manager.CreateService(service.Id, Title[i], Description[i], LangCode[i], ImageUrl);
            }


            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                ServiceLanguages = _manager.GetServiceLanguages(id),
                Service = _manager.GetServiceById(id)

            };


            return View(editVM);

        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Service service, int ServiceId, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            for (int i = 0; i < Title.Count; i++)
            {
                _manager.Edit(service, ServiceId, LangID[i], Title[i], Description[i], LangCode[i], path);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
