using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Core
{
    public class RepositoryManager : IRepositoryManager
    {


        private readonly RepositoryContext _context;
        private readonly Lazy<IGuestRepository> _guestRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _guestRepository = new Lazy<IGuestRepository>(() => new GuestRepository(_context));
        }

        public IGuestRepository Guest => _guestRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
