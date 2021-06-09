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

        #region Paperwork
        [HttpGet]
        public IEnumerable<Paperwork> GetPaperworks()
        {
            var result = new List<Paperwork>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperwork.Where(f => f.IsActive == 1).ToList();
            }

            return result;
        }

        [HttpGet("GetPaperworkBy/{id}")]
        public IEnumerable<Paperwork> GetPaperworkBy(int id)
        {
            var result = new List<Paperwork>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperwork.Where(p => p.FacultyId == id && p.IsActive == 1).ToList();
            }
            return result;
        }

        [HttpGet("GetPaperwork/{id}")]
        public Paperwork GetPaperwork(int id)
        {
            Paperwork result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperwork.Single(p => p.Id == id);
            }
            return result;
        }

        [HttpPost("ModifyPaperwork")]
        public async Task<ActionResult<Paperwork>> ModifyPaperwork(ModifyPaperworkCriteria item)
        {
            Paperwork result = new Paperwork();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperwork.FirstOrDefault(p => p.Id == item.Id);
                result.Name = item.Name;
                result.FacultyId = item.FacultyId;
                result.Description = item.Description;
                result.UpdatedBy = 1;
                result.UpdatedAt = DateTime.Now;
                result.IsActive = Convert.ToInt16(item.IsActive);
                db.SaveChanges();
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
                result.Description = item.Description;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Paperwork.Add(result);
                db.SaveChanges();
            }
            return result;
        }
        #endregion

        #region PaperworkRequirement
        [HttpPost("CreatePaperworkRequirement")]
        public async Task<ActionResult<PaperworkRequirement>> CreatePaperworkRequirement(ICollection<PaperworkRequirementCriteria> collection)
        {
            PaperworkRequirement pr = new PaperworkRequirement();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                foreach (var item in collection)
                {
                    pr.PaperWorkId = item.PaperworkId;
                    pr.RequirementId = item.RequirementId;
                    db.PaperworkRequirement.Add(pr);
                    db.SaveChanges();
                }
            }
            return pr;
        }
        #endregion

        #region Faculty

        [HttpGet("GetFaculties")]
        public IEnumerable<Faculty> GetFaculties()
        {
            var result = new List<Faculty>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Faculty.Where(f => f.IsActive == 1).ToList();
            }

            return result;
        }

        [HttpPost("CreateFaculty")]
        public async Task<ActionResult<Faculty>> CreateFaculty(FacultyCriteria item)
        {
            Faculty result = new Faculty();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }

        [HttpGet("GetFaculty/{id}")]
        public Faculty GetFaculty(int id)
        {
            Faculty result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Faculty.Single(p => p.Id == id);
            }
            return result;
        }

        [HttpPost("ModifyFaculty")]
        public async Task<ActionResult<Faculty>> ModifyFaculty(ModifyFacultyCriteria item)
        {
            Faculty result = new Faculty();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Faculty.FirstOrDefault(p => p.Id == item.Id);
                result.Name = item.Name;
                result.Description = item.Description;
                result.UpdatedBy = 1;
                result.UpdatedAt = DateTime.Now;
                result.IsActive = Convert.ToInt16(item.IsActive);
                db.SaveChanges();
            }
            return result;
        }
        #endregion

        #region Requirement

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

        [HttpGet("GetRequirementsBy/{id}")]
        public IEnumerable<Requirement> GetRequisitosBy(int id)
        {
            var result = new List<Requirement>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = (from pr in db.PaperworkRequirement
                          join r in db.Requirement
                          on pr.RequirementId equals r.Id
                          where pr.PaperWorkId == id
                          select r).ToList();
                foreach (var item in result)
                {
                    item.PaperWorkReception = db.Paperworkreception.Where(p => p.Id == item.PaperWorkReceptionId).Single();
                }
            }
            return result;
        }

        [HttpPost("CreateRequirement")]
        public async Task<ActionResult<Requirement>> CreateRequirement(RequirementCriteria item)
        {
            Requirement result = new Requirement();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.PaperworkLink = item.PaperworkLink;
                result.PaperWorkReceptionId = item.PaperWorkReceptionId;
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }
            return result;
        }
        #endregion

        #region Reception
        [HttpGet("GetPaperworkReceptions")]
        public IEnumerable<Paperworkreception> GetPaperworkReceptions()
        {
            var result = new List<Paperworkreception>();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperworkreception.Where(f => f.IsActive == 1).ToList();
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
                result.CreatedBy = 1;
                result.IsActive = 1;
                result.CreatedAt = DateTime.Now;
                db.Add(result);
                db.SaveChanges();
            }

            return result;
        }

        [HttpGet("GetReception/{id}")]
        public Paperworkreception GetReception(int id)
        {
            Paperworkreception result;
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperworkreception.Single(p => p.Id == id);
            }
            return result;
        }

        [HttpPost("ModifyReception")]
        public async Task<ActionResult<Paperworkreception>> ModifyReception(ModifyReceptionCriteria item)
        {
            Paperworkreception result = new Paperworkreception();
            using (dbtramiteContext db = new dbtramiteContext())
            {
                result = db.Paperworkreception.FirstOrDefault(p => p.Id == item.Id);
                result.Name = item.Name;
                result.Description = item.Description;
                result.Coordinate = new MySqlGeometry(item.Longitude, item.Latitude);
                result.UpdatedBy = 1;
                result.IsActive = Convert.ToInt16(item.IsActive);
                db.SaveChanges();
            }
            return result;
        }
        #endregion
    }
}
