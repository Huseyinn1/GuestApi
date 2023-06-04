using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IGuestRepository : IRepositoryBase<Guest>
    {   IQueryable<Guest> GetAllGuests(bool trackChanges);
        Guest GetOneGuestById(Guid id,bool trackChanges);
        void CreateOneGuest(Guest guest);
        void UpdateOneGuest(Guest guest);
        void DeleteOneGuest(Guest guest);

    }
}
