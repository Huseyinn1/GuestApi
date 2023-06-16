using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAllGuests(bool trackChanges);
         Guest GetOneGuestById(Guid id,bool trackChanges);
        
        Guest CreateOneGuest(Guest guest);  
        void UpdateOneGuest(Guid id,GuestDtoForUpdate guestDto,bool trackChanges);
        void DeleteOneGuest(Guid id,bool trackChanges);
      
    }
}
