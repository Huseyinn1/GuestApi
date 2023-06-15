using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public GuestController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllGuests()
        {
            var guests = _manager.GuestService.GetAllGuests(false);

            return Ok(guests);

        }
        [HttpPost]
        public IActionResult CreateGuests([FromBody] Guest guest)
        {
            guest.Id = Guid.NewGuid();
            _manager.GuestService.CreateOneGuest(guest);

            return Ok(guest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetOneGuest([FromRoute] Guid id)
        {
            var guest = _manager.GuestService.GetOneGuestById(id, false);
           
            return Ok(guest);

        }

        [HttpPut]
        [Route("{id:Guid}")]

        public IActionResult UpdateGuest([FromRoute] Guid id, Guest guest)
        {

            if (guest is null)
                return BadRequest(); //400

            _manager.GuestService.UpdateOneGuest(id, guest, true);
            return NoContent(); //204


        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteGuest([FromRoute] Guid id)
        {


            _manager.GuestService.DeleteOneGuest(id, false);
            return NoContent();
        }

    }
}
