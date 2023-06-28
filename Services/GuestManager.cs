using AutoMapper;
using Entities.DataTransferObjects;
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
        private readonly IMapper _mapper;

        public GuestManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
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
        public IEnumerable<GuestDto> GetAllGuests(bool trackChanges)
        {
           var guests= _manager.Guest.GetAllGuests(trackChanges);

           return _mapper.Map<IEnumerable<GuestDto>>(guests);
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

        public void UpdateOneGuest(Guid id, GuestDtoForUpdate guestDto,bool trackChanges)
        {
         var entity = _manager.Guest.GetOneGuestById(id,trackChanges);
            if(entity is null)
            {
                throw new GuestNotFoundException(id);
            }
            //entity.firstName = guest.firstName;
            //entity.surname = guest.surname;
            //entity.email = guest.email;
            //entity.phone = guest.phone;
            var guest = _mapper.Map(guestDto, entity);
           _manager.Guest.Update(entity);
            _manager.Save();
  
        }
    }
}
