using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("faculty")]
    public partial class Faculty
    {
        public Faculty()
        {
            Paperwork = new HashSet<Paperwork>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "int(11)")]
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [InverseProperty("Faculty")]
        public virtual ICollection<Paperwork> Paperwork { get; set; }
    }
}
