using gestionTareas.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class Tarea : BaseDomainModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        // FK Proyecto
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }

        // FK Estado
        public int EstadoTareaId { get; set; }
        public EstadoTarea EstadoTarea { get; set; }

        // FK Prioridad
        public int PrioridadTareaId { get; set; }
        public PrioridadTarea PrioridadTarea { get; set; }

        // Usuario asignado a la tarea
        public int UsuarioAsignadoId { get; set; }
        public Usuario UsuarioAsignado { get; set; }

        // Comentarios
        public ICollection<ComentarioTarea> Comentarios { get; set; }

        // Archivos adjuntos
        public ICollection<ArchivoTarea> Archivos { get; set; }
    }
}
