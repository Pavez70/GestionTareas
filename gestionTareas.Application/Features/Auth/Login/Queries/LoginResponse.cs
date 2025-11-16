using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Features.Auth.Login.Queries
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
