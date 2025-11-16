using gestionTareas.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Utilies
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetUserId()
        {
            var claim = _contextAccessor.HttpContext?.User?
                .FindFirst(JwtRegisteredClaimNames.Sub);

            if (claim == null)
                throw new Exception("No se encontró el UserId en el token");

            return int.Parse(claim.Value);
        }

        public string GetEmail()
        {
            var claim = _contextAccessor.HttpContext?.User?
                .FindFirst(JwtRegisteredClaimNames.Email);

            return claim?.Value ?? "";
        }

        public string GetNombre()
        {
            var claim = _contextAccessor.HttpContext?.User?
                .FindFirst(JwtRegisteredClaimNames.UniqueName);

            return claim?.Value ?? "";
        }
    }
}
