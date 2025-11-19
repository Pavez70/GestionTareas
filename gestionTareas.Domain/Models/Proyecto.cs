using gestionTareas.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class Proyecto : BaseDomainModel
    {
        public int Id { get; set; }
        public string NombreProyecto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        // Relaciones
        public ICollection<Tarea> Tareas { get; set; }
    }
}
