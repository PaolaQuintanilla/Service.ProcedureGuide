using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("requirement")]
    public partial class Requirement
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column("PaperWorkReception_id", TypeName = "int(11)")]
        public int? PaperWorkReceptionId { get; set; }
        [Required]
        [StringLength(45)]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(45)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [Column("PaperWork_Id", TypeName = "int(11)")]
        public int PaperWorkId { get; set; }
        [Column(TypeName = "int(11)")]
        public int? PaperworkLink { get; set; }

        [ForeignKey(nameof(PaperWorkId))]
        [InverseProperty(nameof(Paperwork.Requirement))]
        public virtual Paperwork PaperWork { get; set; }
        [ForeignKey(nameof(PaperWorkReceptionId))]
        [InverseProperty(nameof(Paperworkreception.Requirement))]
        public virtual Paperworkreception PaperWorkReception { get; set; }
    }
}
