using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.TramitesUmss.Models
{
    [Table("tramiterequisito")]
    public partial class Tramiterequisito
    {
        [Key]
        [Column("Requisito_idPasos", TypeName = "int(11)")]
        public int RequisitoIdPasos { get; set; }
        [Key]
        [Column("Requisito_Ubicacion_idUbicacion", TypeName = "int(11)")]
        public int RequisitoUbicacionIdUbicacion { get; set; }
        [Key]
        [Column("Tramite_idTramites", TypeName = "int(11)")]
        public int TramiteIdTramites { get; set; }

        [ForeignKey("RequisitoIdPasos,RequisitoUbicacionIdUbicacion")]
        [InverseProperty("Tramiterequisito")]
        public virtual Requisito Requisito { get; set; }
        [ForeignKey(nameof(TramiteIdTramites))]
        [InverseProperty(nameof(Tramite.Tramiterequisito))]
        public virtual Tramite TramiteIdTramitesNavigation { get; set; }
    }
}
