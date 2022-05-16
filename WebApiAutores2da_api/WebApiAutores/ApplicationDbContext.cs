
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // generar la tabla en la base de datos de la clase autor
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }




    }
}
