using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Contracts.Infrastructure
{
    public interface IUserService
    {
        int GetUserId();
        string GetEmail();
        string GetNombre();
    }
}
