
using gestionTareas.Application.Contracts.Infrastructure;
using gestionTareas.Application.Contracts.Persistence;
using gestionTareas.Application.Utilies;
using gestionTareas.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Features.Auth.Login.Queries
{

    public class LoginHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptExtension _encryptExtension;
        private readonly IJasonWebToken _jwt;

        public LoginHandler(
            IUnitOfWork unitOfWork,
            IEncryptExtension encryptExtension,
            IJasonWebToken jwt)
        {
            _unitOfWork = unitOfWork;
            _encryptExtension = encryptExtension;
            _jwt = jwt;
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
       
            var usuario = (await _unitOfWork.Repository<Usuario>()
             .GetAsync(x => x.Email == request.Email))
             .FirstOrDefault();

            if (usuario == null)
                throw new Exception("Credenciales incorrectas");

            var decrypted = _encryptExtension.Decrypt(usuario.Password.Trim());

            if (decrypted != request.Password.Trim())
                throw new Exception("Credenciales incorrectas");

       
            var response = new LoginResponse
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                Email = usuario.Email,
                Token = _jwt.Generate(usuario.Email, usuario.Id, usuario.NombreCompleto)
            };

            return response;
        }
    }
}
