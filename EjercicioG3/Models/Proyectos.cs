using System.ComponentModel.DataAnnotations;

namespace EjercicioG3.Models
{
    public class Proyectos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }
    }
}
