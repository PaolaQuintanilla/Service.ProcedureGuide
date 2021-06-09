using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("paperwork")]
    public partial class Paperwork
    {
        public Paperwork()
        {
            PaperworkRequirement = new HashSet<PaperworkRequirement>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int FacultyId { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [Column(TypeName = "int(11)")]
        public int? UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(FacultyId))]
        [InverseProperty("Paperwork")]
        public virtual Faculty Faculty { get; set; }
        [InverseProperty("PaperWork")]
        public virtual ICollection<PaperworkRequirement> PaperworkRequirement { get; set; }
    }
}
