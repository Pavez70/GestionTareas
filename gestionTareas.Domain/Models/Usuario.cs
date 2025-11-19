using gestionTareas.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Domain.Models
{
    public class Usuario : BaseDomainModel
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Login
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Relaciones
        public ICollection<Tarea> TareasAsignadas { get; set; }
        public ICollection<ComentarioTarea> Comentarios { get; set; }
    }
}
