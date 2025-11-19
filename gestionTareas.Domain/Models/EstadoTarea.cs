using gestionTareas.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class EstadoTarea : BaseDomainModel
    {
        public int Id { get; set; }
        public string NombreEstado { get; set; } = string.Empty; // Pendiente, En Progreso, Finalizada, etc.

        public ICollection<Tarea> Tareas { get; set; }
    }
}
