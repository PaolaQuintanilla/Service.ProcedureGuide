using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paperworks.Criterias
{
    public class ModifyPaperworkRequirementCriteria
    {
        public int PaperworkId { get; set; }
        public List<int> Old { get; set; }
        public List<int> Current { get; set; }
    }
}
