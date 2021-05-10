using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Paperworks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNetCore.Cors;
using Services.Paperworks.Criterias;
using MySql.Data.Types;

namespace Services.Paperworks.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class PaperworkController : ControllerBase
    {
        private readonly ILogger<PaperworkController> _logger;

        public PaperworkController(ILogger<PaperworkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Paperwork> GetPaperworks()
        {
            var result = new List<Paperwork>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperwork.ToList();
            }

            return result;
        }

        [HttpGet("GetFaculties")]
        public IEnumerable<Faculty> GetFaculties()
        {
            var result = new List<Faculty>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Faculty.ToList();
            }

            return result;
        }

        [HttpGet("GetByFaculty/{id}")]
        public IEnumerable<Paperwork> GetPaperworkBy(int id)
        {
            var result = new List<Paperwork>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperwork.Where(p => p.FacultyId == id).ToList();

            }
            return result;
        }

        [HttpGet("GetRequirementsBy/{id}")]
        public IEnumerable<Requirement> GetRequisitosBy(int id)
        {
            var result = new List<Requirement>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Requirement.Where(r => r.PaperWorkId == id)
                        .Include( re => re.PaperWorkReception).ToList();
                foreach (var item in result)
                {
                    item.PaperWorkReception = db.Paperworkreception.Where(p => p.Id == item.PaperWorkReceptionId).Single();
                }
            }
            return result;
        }

        [HttpGet("GetRequirements")]
        public IEnumerable<Requirement> GetRequirements()
        {
            var result = new List<Requirement>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Requirement.ToList();
            }
            return result;
        }

        [HttpGet("GetPaperworkReceptions")]
        public IEnumerable<Paperworkreception> GetPaperworkReceptions()
        {
            var result = new List<Paperworkreception>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperworkreception.ToList();
            }
            return result;
        }

        [HttpPost("CreatePaperwork")]
        public async Task<ActionResult<Paperwork>> CreatePaperwork(PaperworkCriteria item)
        {
            Paperwork result = new Paperwork();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result.Name = item.Name;
                result.FacultyId = item.FacultyId;
                result.CreatedBy = "1";
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }

        [HttpPost("CreatePaperworkReception")]
        public async Task<ActionResult<Paperworkreception>> CreatePaperworkReception(PaperworkreceptionCriteria item)
        {
            Paperworkreception result = new Paperworkreception();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.Coordinate = new MySqlGeometry(item.Longitude, item.Latitude);
                result.CreatedBy = "1";
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }

            return result;
        }
    }
}
