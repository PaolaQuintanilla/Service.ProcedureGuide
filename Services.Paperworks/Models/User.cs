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
        [StringLength(200)]
        public string Name { get; set; }
        [Column("Rol_Id", TypeName = "int(11)")]
        public int RolId { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        [Column(TypeName = "int(11)")]
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "bit(1)")]
        public short IsActive { get; set; }
        [Column(TypeName = "int(11)")]
        public int? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        [ForeignKey(nameof(RolId))]
        [InverseProperty("User")]
        public virtual Rol Rol { get; set; }
    }
}
