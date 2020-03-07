using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExportarExcel.Models
{
    [Table("Productos", Schema = "ventas")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Producto")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Display(Name = "Disponible")]
        public bool? Descontinuado { get; set; }

        [Display(Name = "Fecha Recepción")]
        [StringLength(100)]
        public DateTime FechaDaLanzamiento { get; set; }

        [Display(Name = "Fecha")]
        public decimal Precio { get; set; }
    }
}
