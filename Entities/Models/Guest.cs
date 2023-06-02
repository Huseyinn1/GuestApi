using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Guest
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }

        public string surname { get; set; }

        public string email { get; set; }

        public long phone { get; set; }
    }
}
