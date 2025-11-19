using gestionTareas.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class ArchivoTarea : BaseDomainModel
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string NombreArchivo { get; set; } = string.Empty;
        public DateTime FechaSubida { get; set; }

      
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }
    }
}
