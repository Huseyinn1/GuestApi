using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IGuestService> _guestService;  
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger)
        {
            _guestService = new Lazy<IGuestService>(() => new GuestManager(repositoryManager,logger));
        }
        public IGuestService GuestService => _guestService.Value;
    }
}
