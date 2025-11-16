using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class ComentarioTarea
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaComentario { get; set; }

        // FK Tarea
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }

        // FK Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
