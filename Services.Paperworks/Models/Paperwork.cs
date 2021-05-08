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
            Requirement = new HashSet<Requirement>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [Column(TypeName = "int(11)")]
        public int FacultyId { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [StringLength(45)]
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        [StringLength(45)]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(FacultyId))]
        [InverseProperty("Paperwork")]
        public virtual Faculty Faculty { get; set; }
        [InverseProperty("PaperWork")]
        public virtual ICollection<Requirement> Requirement { get; set; }
    }
}
