using System;
using DepositoDental.Services.Abstractions;
using DepositoDental.Models.Entities;
using DepositoDental.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppDbContext _context;

        public AuthenticationService(AppDbContext context)
        {
            _context = context;
        }


        //metodo para autenticar un usuario
        public async Task<SecUsuario?> AutenticarUsuarioAsync(string username, string password)
        {
            var usernameParam = new SqlParameter("@nombreusuario", username);

            var usuarios = await _context.SecUsuarios
                .FromSqlRaw("EXEC sp_ObtenerUsuarioParaLogin @nombreusuario", usernameParam)
                .ToListAsync();

            var usuario = usuarios.FirstOrDefault();

            if (usuario == null || !(bool)usuario.Activo || (bool)usuario.Bloqueado)
            {
                return null; // El usuario no puede iniciar sesión
            }

            // Usamos BCrypt para verificar si la contraseña ingresada coincide con el hash guardado
            bool esValido = BCrypt.Net.BCrypt.Verify(password, usuario.Passwordhash);

            return esValido ? usuario : null;
        }

        //Metodo para hashear una contraseña
        public string HashearPassword(string password)
        {
            // Esta función la llamarás desde tu futuro `UserService` al crear un nuevo usuario.
            // Genera un hash seguro que incluye su propia sal.
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
