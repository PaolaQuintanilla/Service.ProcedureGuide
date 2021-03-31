using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.Tramites.Models
{
    [Table("tramite")]
    public partial class Tramite
    {
        public Tramite()
        {
            Tramiterequisito = new HashSet<Tramiterequisito>();
        }

        [Key]
        [Column("idTramites", TypeName = "int(11)")]
        public int IdTramites { get; set; }
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [InverseProperty("TramiteIdTramitesNavigation")]
        public virtual ICollection<Tramiterequisito> Tramiterequisito { get; set; }
    }
}
