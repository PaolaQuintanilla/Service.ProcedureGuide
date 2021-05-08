using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.Types;

namespace Services.Paperworks.Models
{
    [Table("paperworkreception")]
    public partial class Paperworkreception
    {
        public Paperworkreception()
        {
            Requirement = new HashSet<Requirement>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public MySqlGeometry Coordinate { get; set; }
        [Required]
        [StringLength(45)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [StringLength(45)]
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        [InverseProperty("PaperWorkReception")]
        public virtual ICollection<Requirement> Requirement { get; set; }
    }
}
