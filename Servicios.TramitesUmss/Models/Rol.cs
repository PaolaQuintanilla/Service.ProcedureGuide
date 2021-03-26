using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.TramitesUmss.Models
{
    [Table("rol")]
    public partial class Rol
    {
        public Rol()
        {
            User = new HashSet<User>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [InverseProperty("Rol")]
        public virtual ICollection<User> User { get; set; }
    }
}
