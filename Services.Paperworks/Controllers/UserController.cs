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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
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

        [HttpPost("register")]
        public async Task<ActionResult<User>> register(UserCriteria criteria)
        {
            User result = new User();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result.Name = criteria.Name;
                result.LastName = criteria.LastName;
                result.Password = criteria.Password;
                result.Email = criteria.Email;
                result.RolId = 1;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }
        #endregion
    }
}
