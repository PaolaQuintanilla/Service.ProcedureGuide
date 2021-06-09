using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("paperwork_requirement")]
    public partial class PaperworkRequirement
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int PaperWorkId { get; set; }
        [Key]
        [Column(TypeName = "int(11)")]
        public int RequirementId { get; set; }

        [ForeignKey(nameof(PaperWorkId))]
        [InverseProperty(nameof(Paperwork.PaperworkRequirement))]
        public virtual Paperwork PaperWork { get; set; }
        [ForeignKey(nameof(RequirementId))]
        [InverseProperty("PaperworkRequirement")]
        public virtual Requirement Requirement { get; set; }
    }
}
