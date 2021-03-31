using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.Tramites.Models
{
    [Table("tramiterequisito")]
    public partial class Tramiterequisito
    {
        [Key]
        [Column("Tramite_idTramites", TypeName = "int(11)")]
        public int TramiteIdTramites { get; set; }
        [Key]
        [Column("Requisito_idPasos", TypeName = "int(11)")]
        public int RequisitoIdPasos { get; set; }

        [ForeignKey(nameof(RequisitoIdPasos))]
        [InverseProperty(nameof(Requisito.Tramiterequisito))]
        public virtual Requisito RequisitoIdPasosNavigation { get; set; }
        [ForeignKey(nameof(TramiteIdTramites))]
        [InverseProperty(nameof(Tramite.Tramiterequisito))]
        public virtual Tramite TramiteIdTramitesNavigation { get; set; }
    }
}
