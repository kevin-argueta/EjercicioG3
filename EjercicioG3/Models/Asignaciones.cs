using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioG3.Models
{
    public class Asignaciones
    {
        public int id { get; set; }
        
        [Required]
        public DateTime FechaAsignacion { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; }

        [Required]
        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }

        public Empleados Empleado { get; set; }

        [Required]
        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }

        public Proyectos Proyecto { get; set; }
    }
}
