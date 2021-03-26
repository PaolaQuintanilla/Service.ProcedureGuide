using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.TramitesUmss.Models
{
    [Table("requisito")]
    public partial class Requisito
    {
        public Requisito()
        {
            Tramiterequisito = new HashSet<Tramiterequisito>();
        }

        [Key]
        [Column("idPasos", TypeName = "int(11)")]
        public int IdPasos { get; set; }
        [StringLength(45)]
        public string Nombre { get; set; }
        [Column("descripcion")]
        [StringLength(45)]
        public string Descripcion { get; set; }
        [Key]
        [Column("Ubicacion_idUbicacion", TypeName = "int(11)")]
        public int UbicacionIdUbicacion { get; set; }

        [ForeignKey(nameof(UbicacionIdUbicacion))]
        [InverseProperty(nameof(Ventanilla.Requisito))]
        public virtual Ventanilla UbicacionIdUbicacionNavigation { get; set; }
        [InverseProperty("Requisito")]
        public virtual ICollection<Tramiterequisito> Tramiterequisito { get; set; }
    }
}
