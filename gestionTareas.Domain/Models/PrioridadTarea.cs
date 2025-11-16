using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class PrioridadTarea
    {
        public int Id { get; set; }
        public string NombrePrioridad { get; set; } = string.Empty; // Baja, Media, Alta, Crítica

        public ICollection<Tarea> Tareas { get; set; }
    }
}
