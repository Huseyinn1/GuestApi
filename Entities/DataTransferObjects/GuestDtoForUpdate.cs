using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{   
    public record GuestDtoForUpdate(Guid Id, string firstName, string surname, string email, long phone);

}
