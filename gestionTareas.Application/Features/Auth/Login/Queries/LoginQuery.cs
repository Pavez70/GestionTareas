using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Features.Auth.Login.Queries
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public string Email { get; }
        public string Password { get; }

        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
