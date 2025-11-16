using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Contracts.Infrastructure
{
    public interface IJasonWebToken
    {
        string Generate(string email, int userId, string nombreCompleto);
        bool Validate(string token);
    }
}
