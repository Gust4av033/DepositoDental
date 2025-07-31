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

        public async Task<AuthenticationResult> AutenticarUsuarioAsync(string nombreUsuario, string password)
        {
            try
            {
                var usuario = await _context.SecUsuarios
                    .Include(u => u.SecUsuarioroles)
                        .ThenInclude(ur => ur.Rol)
                    .FirstOrDefaultAsync(u => u.Nombreusuario == nombreUsuario && u.Activo == true);

                if (usuario == null)
                {
                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = "Usuario no encontrado o inactivo"
                    };
                }

                if (usuario.Bloqueado == true)
                {
                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = "Usuario bloqueado. Contacte al administrador"
                    };
                }

                // Verificar contraseña con BCrypt
                bool passwordValid = BCrypt.Net.BCrypt.Verify(password, usuario.Passwordhash);

                if (!passwordValid)
                {
                    // Incrementar intentos de login fallidos
                    usuario.Intentoslogin = (usuario.Intentoslogin ?? 0) + 1;

                    if (usuario.Intentoslogin >= 5)
                    {
                        usuario.Bloqueado = true;
                    }

                    await _context.SaveChangesAsync();

                    return new AuthenticationResult
                    {
                        IsSuccess = false,
                        ErrorMessage = "Contraseña incorrecta"
                    };
                }

                // Login exitoso - resetear intentos y actualizar último acceso
                usuario.Intentoslogin = 0;
                usuario.Ultimoacceso = DateTime.Now;
                await _context.SaveChangesAsync();

                return new AuthenticationResult
                {
                    IsSuccess = true,
                    Usuario = usuario,
                    Roles = usuario.SecUsuarioroles
                        .Where(ur => ur.Activo == true && ur.Rol?.Activo == true)
                        .Select(ur => ur.Rol.Nombrerol)
                        .ToList()
                };
            }
            catch (Exception ex)
            {
                // Log the exception here
                System.Diagnostics.Debug.WriteLine($"Error en autenticación: {ex.Message}");

                return new AuthenticationResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Error al procesar la solicitud. Por favor intente nuevamente."
                };
            }
        }

        public async Task<bool> CrearUsuarioAsync(string nombreUsuario, string email, string password,
            string primerNombre, string primerApellido, string telefono = null)
        {
            try
            {
                // Verificar si el usuario ya existe
                var existeUsuario = await _context.SecUsuarios
                    .AnyAsync(u => u.Nombreusuario == nombreUsuario || u.Correoelectronico == email);

                if (existeUsuario)
                    return false;

                // Crear hash de la contraseña con BCrypt
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));

                var nuevoUsuario = new SecUsuario
                {
                    Nombreusuario = nombreUsuario,
                    Correoelectronico = email,
                    Passwordhash = passwordHash,
                    Sal = "", // BCrypt incluye la sal en el hash
                    Primernombre = primerNombre,
                    Primerapellido = primerApellido,
                    Telefono = telefono,
                    Activo = true,
                    Bloqueado = false,
                    Intentoslogin = 0
                };

                _context.SecUsuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al crear usuario: {ex.Message}");
                return false;
            }
        }
    }

    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public SecUsuario Usuario { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
