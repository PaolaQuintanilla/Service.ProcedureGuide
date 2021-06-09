using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("requirement")]
    public partial class Requirement
    {
        public Requirement()
        {
            PaperworkRequirement = new HashSet<PaperworkRequirement>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int? PaperWorkReceptionId { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "int(11)")]
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [Column(TypeName = "int(11)")]
        public int? PaperworkLink { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(PaperWorkReceptionId))]
        [InverseProperty(nameof(Paperworkreception.Requirement))]
        public virtual Paperworkreception PaperWorkReception { get; set; }
        [InverseProperty("Requirement")]
        public virtual ICollection<PaperworkRequirement> PaperworkRequirement { get; set; }
    }
}
