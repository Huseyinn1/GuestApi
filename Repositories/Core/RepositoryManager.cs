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

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
        }

        public IGuestRepository Guest => new GuestRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
