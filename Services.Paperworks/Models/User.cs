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
        [Column("Role_Id", TypeName = "int(11)")]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("User")]
        public virtual Role Role { get; set; }
    }
}
