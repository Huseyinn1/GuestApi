using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GuestManager : IGuestService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public GuestManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Guest CreateOneGuest(Guest guest)
        {
            if(guest is null)
            {
                throw new ArgumentNullException(nameof(Guest));
            }
            _manager.Guest.CreateOneGuest(guest);
            _manager.Save();
            return guest;
        }

        public void DeleteOneGuest(Guid id, bool trackChanges)
        {
            var entity = _manager.Guest.GetOneGuestById(id,trackChanges);
            if (entity is null)
            {
               throw new GuestNotFoundException(id);
            }
            _manager.Guest.DeleteOneGuest(entity);
            _manager.Save();

        }
        public IEnumerable<Guest> GetAllGuests(bool trackChanges)
        {
           return _manager.Guest.GetAllGuests(trackChanges);
        }

        public Guest GetOneGuestById(Guid id, bool trackChanges)
        {
            var guest =  _manager.Guest.GetOneGuestById(id, trackChanges);
            if (guest == null)
            {
                throw new GuestNotFoundException(id);
            }
            return guest;
        }

        public void UpdateOneGuest(Guid id, Guest guest,bool trackChanges)
        {
         var entity = _manager.Guest.GetOneGuestById(id,trackChanges);
            if(guest is null)
            {
                throw new GuestNotFoundException(id);
            }
            entity.firstName = guest.firstName;
            entity.surname = guest.surname;
            entity.email = guest.email;
            entity.phone = guest.phone;
           _manager.Guest.Update(entity);
            _manager.Save();
  
        }
    }
}
