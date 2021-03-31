using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Servicios.Tramites.Models
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
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }
        [Column("descripcion")]
        [StringLength(45)]
        public string Descripcion { get; set; }
        [Column("Ventanilla_id1", TypeName = "int(11)")]
        public int VentanillaId1 { get; set; }

        [ForeignKey(nameof(VentanillaId1))]
        [InverseProperty(nameof(Ventanilla.Requisito))]
        public virtual Ventanilla VentanillaId1Navigation { get; set; }
        [InverseProperty("RequisitoIdPasosNavigation")]
        public virtual ICollection<Tramiterequisito> Tramiterequisito { get; set; }
    }
}
