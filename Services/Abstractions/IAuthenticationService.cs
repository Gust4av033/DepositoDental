using System;
using DepositoDental.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<SecUsuario> AutenticarUsuarioAsync(string username, string password); // Método para hashear y pasarlo al modulo de autenticación de usuarios

    }
}
