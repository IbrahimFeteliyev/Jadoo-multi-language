using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly JadooDbContext _context;

        public ServiceManager(JadooDbContext context)
        {
            _context = context;
        }

        public Service Create(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();

            return service;
        }

        public void CreateService(int ServiceId, string Title, string Description, string LangCode, string ImageUrl)
        {
            ServiceLanguage serviceLanguage = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                ServiceId = ServiceId
            };

            _context.ServiceLanguages.Add(serviceLanguage);
            _context.SaveChanges();
        }

        public void Edit(Service service, int ServiceId, int LangID, string Title, string Description, string LangCode, string ImageUrl)
        {
            if (ImageUrl != null)
            {
                service.ImageUrl = ImageUrl;
                _context.Services.Update(service);
            }

            ServiceLanguage serviceLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                ServiceId = ServiceId,
                UpdatedDate = DateTime.Now
            };

            var updatedEntity = _context.Entry(serviceLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id);
        }

        public List<ServiceLanguage> GetAll(string lang)
        {
            return _context.ServiceLanguages.Include(x => x.Service).Where(x => x.LangCode == lang).ToList();
        }
        public List<ServiceLanguage> GetAll()
        {
            return _context.ServiceLanguages.Include(x => x.Service).Where(x => x.LangCode == "Az").ToList();
        }
        public List<ServiceLanguage> GetServiceLanguages(int id)
        {
            return _context.ServiceLanguages.Where(x => x.Service.Id == id).ToList();
        }
    }
}
