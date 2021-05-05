using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("user")]
    public partial class User
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        [Key]
        [Column("Rol_Id", TypeName = "int(11)")]
        public int RolId { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [ForeignKey(nameof(RolId))]
        [InverseProperty("User")]
        public virtual Rol Rol { get; set; }
    }
}
