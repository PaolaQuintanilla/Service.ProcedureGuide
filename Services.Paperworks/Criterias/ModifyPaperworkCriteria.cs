using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paperworks.Criterias
{
    public class ModifyPaperworkCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public int IsActive { get; set; }
        public string Description { get; set; }
    }
}
