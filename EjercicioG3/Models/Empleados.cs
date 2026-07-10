using System.ComponentModel.DataAnnotations;

namespace EjercicioG3.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaContratacion { get; set; }

        [StringLength(50)]
        [Required]
        public string Puesto { get; set; }

    }
}
