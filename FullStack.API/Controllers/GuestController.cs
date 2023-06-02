using Entities.Models;
using FullStack.API.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]

    public class GuestController : Controller
    {
        readonly private RepositoryContext _guestAPIDbcontext;

        public GuestController(RepositoryContext guestAPIDbcontext)
        {
            _guestAPIDbcontext = guestAPIDbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
          var guests = await _guestAPIDbcontext.Guests.ToListAsync();
          
            return Ok(guests);

        }
       [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetGuest([FromRoute] Guid id)
        {
            var  guest =  await _guestAPIDbcontext.Guests.FirstOrDefaultAsync(x => x.Id == id);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);

        }


       [HttpPost]
        public async Task<IActionResult> AddGuests([FromBody] Guest guestRequest)
        {
            guestRequest.Id = Guid.NewGuid();
            await _guestAPIDbcontext.Guests.AddAsync(guestRequest);
            await _guestAPIDbcontext.SaveChangesAsync();
            return Ok(guestRequest);
        }
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult>UpdateGuest([FromRoute] Guid id,Guest updateGuest)
        {
           var guest = await  _guestAPIDbcontext.Guests.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            guest.firstName = updateGuest.firstName;
            guest.surname = updateGuest.surname;
            guest.phone = updateGuest.phone;
            guest.email = updateGuest.email;

            await _guestAPIDbcontext.SaveChangesAsync();

            return Ok(guest);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteGuest([FromRoute] Guid id)
         {
             var guest = await _guestAPIDbcontext.Guests.FindAsync(id);
             if (guest == null)
             {
                 return NotFound();
             }

             _guestAPIDbcontext.Guests.Remove(guest);
             await _guestAPIDbcontext.SaveChangesAsync();
             return Ok(guest);

         }

    }
}
