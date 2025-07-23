using System;
using DepositoDental.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepositoDental.Services.Implementations;

namespace DepositoDental.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AutenticarUsuarioAsync(string nombreUsuario, string password);
        Task<bool> CrearUsuarioAsync(string nombreUsuario, string email, string password,
            string primerNombre, string primerApellido, string telefono = null);
    }
}
