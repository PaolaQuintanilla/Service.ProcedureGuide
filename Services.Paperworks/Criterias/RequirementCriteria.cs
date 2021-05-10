using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paperworks.Criterias
{
    public class RequirementCriteria
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PaperWorkReceptionId { get; set; }
        public int PaperWorkId { get; set; }
        public int? PaperworkLink { get; set; }
    }
}
