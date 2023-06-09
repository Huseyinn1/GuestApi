﻿using AutoMapper;
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
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper)
        {
            _guestService = new Lazy<IGuestService>(() => new GuestManager(repositoryManager,logger,mapper));
        }
        public IGuestService GuestService => _guestService.Value;
    }
}
