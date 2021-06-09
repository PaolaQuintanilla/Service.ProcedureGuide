using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Paperworks.Models
{
    [Table("role")]
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User> User { get; set; }
    }
}
