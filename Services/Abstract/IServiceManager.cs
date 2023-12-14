using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceManager
    {
        List<ServiceLanguage> GetAll(string lang);
        List<ServiceLanguage> GetAll();
        Service Create(Service service);
        void CreateService(int ServiceId, string Title, string Description, string LangCode, string ImageUrl);
        List<ServiceLanguage> GetServiceLanguages(int id);
        Service GetServiceById(int id);
        void Edit(Service service, int ServiceId, int LangID, string Title, string Description, string LangCode, string ImageUrl);
    }
}
