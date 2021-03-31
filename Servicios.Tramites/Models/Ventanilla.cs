using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.Tramites.Models
{
    [Table("ventanilla")]
    public partial class Ventanilla
    {
        public Ventanilla()
        {
            Requisito = new HashSet<Requisito>();
        }

        [Key]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [InverseProperty("VentanillaId1Navigation")]
        public virtual ICollection<Requisito> Requisito { get; set; }
    }
}
