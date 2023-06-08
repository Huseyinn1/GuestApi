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

        public GuestManager(IRepositoryManager manager)
        {
            _manager = manager;
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
                throw new Exception($"Guest with id:{id} could not found");

            _manager.Guest.DeleteOneGuest(entity);
            _manager.Save();

        }
        public IEnumerable<Guest> GetAllGuests(bool trackChanges)
        {
           return _manager.Guest.GetAllGuests(trackChanges);
        }

        public Guest GetOneGuestById(Guid id, bool trackChanges)
        {
            return  _manager.Guest.GetOneGuestById(id, trackChanges);
        }

        public void UpdateOneGuest(Guid id, Guest guest,bool trackChanges)
        {
         var entity = _manager.Guest.GetOneGuestById(id,trackChanges);
            if(guest is null)
                throw new ArgumentNullException(nameof(guest));
            entity.firstName = guest.firstName;
            entity.email = guest.email;
            entity.phone = guest.phone;
           _manager.Guest.Update(entity);
            _manager.Save();
  
        }
    }
}
