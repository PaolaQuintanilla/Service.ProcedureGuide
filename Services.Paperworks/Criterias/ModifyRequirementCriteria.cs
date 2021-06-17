using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paperworks.Criterias
{
    public class ModifyRequirementCriteria
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int? PaperworkReceptionId { get; set; }
    }
}
