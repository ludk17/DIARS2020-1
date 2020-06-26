using Microsoft.EntityFrameworkCore;
using MVCProject.DB.Configurations;
using MVCProject.Models;

namespace MVCProject.DB
{
    public class AppPruebaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<ExamenPregunta> ExamenPreguntas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=Prueba;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // coddigo tabla tabla
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TemaConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new PreguntaConfiguration());
            modelBuilder.ApplyConfiguration(new AlternativaConfiguration());
            modelBuilder.ApplyConfiguration(new PeliculaConfiguration());
            modelBuilder.ApplyConfiguration(new ExamenConfiguration());
            modelBuilder.ApplyConfiguration(new ExamenPreguntaConfiguration());
        }

    }
}
