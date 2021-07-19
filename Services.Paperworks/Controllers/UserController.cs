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
        public async Task<ActionResult<User>> login(AccountCriteria criteria)
        {
            User result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.User.SingleOrDefault(u => u.Password == criteria.Password && u.Email == criteria.Email);
                if (result != null)
                {
                    result.Role = db.Role.Single(r => r.Id == result.RoleId);
                }
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
                result.RoleId = criteria.RolId;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }

        [HttpGet("GetUserInformation")]
        public async Task<ActionResult<User>> getUserInformation(int id)
        {
            User result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.User.Single(u => u.Id == id);
                result.Role = db.Role.Single(r => r.Id == result.RoleId);
            }
            return result;
        }
        #endregion

        #region Rol
        [HttpGet("GetRoles")]
        public IEnumerable<Role> getRoles(int id)
        {
            List<Role> result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Role.ToList();
            }
            return result;
        }
        #endregion
    }
}
