using Entities.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Core;
using Services.Contracts;

namespace FullStack.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]

    public class GuestController : Controller
    {
        private readonly IServiceManager _manager;

        public GuestController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public  IActionResult GetAllGuests()
        {
          var guests = _manager.GuestService.GetAllGuests(false);
          
            return Ok(guests);

        }
       [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetOneGuest([FromRoute] Guid id)
        {
            var  guest =  _manager.GuestService.GetOneGuestById(id,false);
            if (guest == null)
            {
                return NotFound();
            }
            return Ok(guest);

        }


       [HttpPost]
        public IActionResult CreateGuests([FromBody] Guest guest)
        {
            guest.Id = Guid.NewGuid();
            _manager.GuestService.CreateOneGuest(guest);
         
            return Ok(guest);
        }
        [HttpPut]
        [Route("{id:Guid}")]

        public  IActionResult UpdateGuest([FromRoute] Guid id,Guest guest)
        {
            try
            {
                if (guest is null)
                    return BadRequest(); //400
                
                _manager.GuestService.UpdateOneGuest(id,guest,true);
                return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public  IActionResult DeleteGuest([FromRoute] Guid id)
         {
           

            _manager.GuestService.DeleteOneGuest(id, false);
             return NoContent() ;
         }

    }
}
