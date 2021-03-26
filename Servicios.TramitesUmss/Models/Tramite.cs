using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.TramitesUmss.Models
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
        [StringLength(45)]
        public string Tramitescol { get; set; }

        [InverseProperty("TramiteIdTramitesNavigation")]
        public virtual ICollection<Tramiterequisito> Tramiterequisito { get; set; }
    }
}
