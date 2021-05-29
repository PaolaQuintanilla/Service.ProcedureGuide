using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Paperworks.Criterias;
using Services.Paperworks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paperworks.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        #region User
        [HttpPost("login")]
        public async Task<ActionResult<User>> login( AccountCriteria criteria)
        {
            User result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.User.SingleOrDefault(u => u.Password == criteria.Password && u.Email == criteria.Email);
            }
            return result;
        }
        #endregion
    }
}
