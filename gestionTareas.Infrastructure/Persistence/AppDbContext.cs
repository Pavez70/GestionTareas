using gestionTareas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gestionTareas.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<EstadoTarea> EstadosTarea { get; set; }
        public DbSet<PrioridadTarea> PrioridadesTarea { get; set; }
        public DbSet<ComentarioTarea> ComentariosTarea { get; set; }
        public DbSet<ArchivoTarea> ArchivosTarea { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Proyecto>()
                .HasMany(p => p.Tareas)
                .WithOne(t => t.Proyecto)
                .HasForeignKey(t => t.ProyectoId);

            modelBuilder.Entity<EstadoTarea>()
                .HasMany(e => e.Tareas)
                .WithOne(t => t.EstadoTarea)
                .HasForeignKey(t => t.EstadoTareaId);

            modelBuilder.Entity<PrioridadTarea>()
                .HasMany(p => p.Tareas)
                .WithOne(t => t.PrioridadTarea)
                .HasForeignKey(t => t.PrioridadTareaId);

       
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.UsuarioAsignado)
                .WithMany(u => u.TareasAsignadas)
                .HasForeignKey(t => t.UsuarioAsignadoId)
                .OnDelete(DeleteBehavior.Restrict); 

         
            modelBuilder.Entity<ComentarioTarea>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 

        
            modelBuilder.Entity<ComentarioTarea>()
                .HasOne(c => c.Tarea)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TareaId);

            modelBuilder.Entity<ArchivoTarea>()
                .HasOne(a => a.Tarea)
                .WithMany(t => t.Archivos)
                .HasForeignKey(a => a.TareaId);
        }
    }
}
