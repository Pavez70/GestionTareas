using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTareas.Application.Contracts.Infrastructure
{
    public interface IEncryptExtension
    {
        string Encrypt(string texto);
        string Decrypt(string textoEncriptado);
    }
}
