using Microsoft.EntityFrameworkCore;
using EjercicioG3.Models;

namespace EjercicioG3.Data
{
    public class EmpleadoDbContext : DbContext
    {
        public EmpleadoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Asignaciones> Asignaciones { get; set; }
    }
}
