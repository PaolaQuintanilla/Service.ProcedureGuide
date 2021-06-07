using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paperworks.Criterias
{
    public class UserCriteria
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RolId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
