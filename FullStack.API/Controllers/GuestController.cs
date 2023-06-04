using Entities.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Core;

namespace FullStack.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]

    public class GuestController : Controller
    {
        readonly private IRepositoryManager _manager;

        public GuestController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public  IActionResult GetAllGuests()
        {
          var guests =  _manager.Guest.GetAllGuests(false);
          
            return Ok(guests);

        }
       [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetGuest([FromRoute] Guid id)
        {
            var  guest =  _manager.Guest.GetOneGuestById(id,false);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);

        }


       [HttpPost]
        public IActionResult AddGuests([FromBody] Guest guest)
        {
            guest.Id = Guid.NewGuid();
            _manager.Guest.CreateOneGuest(guest);
            _manager.Save();
            return Ok(guest);
        }
        [HttpPut]
        [Route("{id:Guid}")]

        public  IActionResult UpdateGuest([FromRoute] Guid id,Guest updateGuest)
        {
           var guest =_manager.Guest.GetOneGuestById(id,true);
            if (guest == null)
            {
                return NotFound();
            }

            guest.firstName = updateGuest.firstName;
            guest.surname = updateGuest.surname;
            guest.phone = updateGuest.phone;
            guest.email = updateGuest.email;

             _manager.Save();

            return Ok(guest);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public  IActionResult DeleteGuest([FromRoute] Guid id)
         {
             var guest =  _manager.Guest.GetOneGuestById(id,false);
             if (guest == null)
             {
                 return NotFound();
             }

             _manager.Guest.Delete(guest);
              _manager.Save();
             return Ok(guest);

         }

    }
}
