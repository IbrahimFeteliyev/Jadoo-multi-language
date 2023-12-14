using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ServiceLanguage : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LangCode { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
