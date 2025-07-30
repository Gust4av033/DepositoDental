using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepositoDental.Models.Entities;

namespace DepositoDental.Models.DTOs
{
    // ===============================
    // USUARIO DTOs
    // ===============================

    public class UsuarioDto
    {
        public long Usuarioid { get; set; }
        public string Nombreusuario { get; set; }
        public string Correoelectronico { get; set; }
        public string Primernombre { get; set; }
        public string Primerapellido { get; set; }
        public string Telefono { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Ultimoacceso { get; set; }
        public bool? Bloqueado { get; set; }
        public List<RolDto> Roles { get; set; } = new List<RolDto>();
    }

    public class CrearUsuarioDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(255, ErrorMessage = "El nombre de usuario no puede tener más de 255 caracteres")]
        public string Nombreusuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El primer nombre es requerido")]
        [StringLength(100, ErrorMessage = "El primer nombre no puede tener más de 100 caracteres")]
        public string Primernombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [StringLength(100, ErrorMessage = "El primer apellido no puede tener más de 100 caracteres")]
        public string Primerapellido { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        public List<long> RolesIds { get; set; } = new List<long>();
    }

    public class ActualizarUsuarioDto
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(255, ErrorMessage = "El nombre de usuario no puede tener más de 255 caracteres")]
        public string Nombreusuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        [Required(ErrorMessage = "El primer nombre es requerido")]
        [StringLength(100, ErrorMessage = "El primer nombre no puede tener más de 100 caracteres")]
        public string Primernombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [StringLength(100, ErrorMessage = "El primer apellido no puede tener más de 100 caracteres")]
        public string Primerapellido { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        public bool? Activo { get; set; }
        public List<long> RolesIds { get; set; } = new List<long>();
    }

    public class UsuarioListaDto
    {
        public long Usuarioid { get; set; }
        public string Nombreusuario { get; set; }
        public string Correoelectronico { get; set; }
        public string NombreCompleto { get; set; }
        public bool? Activo { get; set; }
        public bool? Bloqueado { get; set; }
        public DateTime? Ultimoacceso { get; set; }
        public string RolesNombres { get; set; }
    }

    public class CambiarPasswordDto
    {
        [Required(ErrorMessage = "La contraseña actual es requerida")]
        public string PasswordActual { get; set; }

        [Required(ErrorMessage = "La nueva contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La nueva contraseña debe tener al menos 8 caracteres")]
        public string NuevoPassword { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es requerida")]
        [Compare("NuevoPassword", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarPassword { get; set; }
    }

    // ===============================
    // ROL DTOs
    // ===============================

    public class RolDto
    {
        public long Rolid { get; set; }
        public string Nombrerol { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public List<PermisoDto> Permisos { get; set; } = new List<PermisoDto>();
    }

    public class CrearRolDto
    {
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del rol no puede tener más de 255 caracteres")]
        public string Nombrerol { get; set; }

        public string Descripcion { get; set; }
        public List<long> PermisosIds { get; set; } = new List<long>();
    }

    public class ActualizarRolDto
    {
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del rol no puede tener más de 255 caracteres")]
        public string Nombrerol { get; set; }

        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public List<long> PermisosIds { get; set; } = new List<long>();
    }

    public class RolListaDto
    {
        public long Rolid { get; set; }
        public string Nombrerol { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public int CantidadPermisos { get; set; }
        public int CantidadUsuarios { get; set; }
    }

    // ===============================
    // PERMISO DTOs
    // ===============================

    public class PermisoDto
    {
        public long Permisoid { get; set; }
        public string Nombrepermiso { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
        public bool? Activo { get; set; }
    }

    public class CrearPermisoDto
    {
        [Required(ErrorMessage = "El nombre del permiso es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del permiso no puede tener más de 255 caracteres")]
        public string Nombrepermiso { get; set; }

        public string Descripcion { get; set; }

        [StringLength(100, ErrorMessage = "El módulo no puede tener más de 100 caracteres")]
        public string Modulo { get; set; }
    }

    public class ActualizarPermisoDto
    {
        [Required(ErrorMessage = "El nombre del permiso es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del permiso no puede tener más de 255 caracteres")]
        public string Nombrepermiso { get; set; }

        public string Descripcion { get; set; }

        [StringLength(100, ErrorMessage = "El módulo no puede tener más de 100 caracteres")]
        public string Modulo { get; set; }

        public bool? Activo { get; set; }
    }

    // ===============================
    // AUTENTICACIÓN DTOs
    // ===============================

    public class LoginDto
    {
        [Required(ErrorMessage = "El nombre de usuario o correo es requerido")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }

        public bool RecordarSesion { get; set; }
    }

    public class LoginResponseDto
    {
        public bool Exitoso { get; set; }
        public string Token { get; set; }
        public DateTime? Expiracion { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string Mensaje { get; set; }
    }

    public class RefreshTokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    // ===============================
    // SESIÓN DTOs
    // ===============================

    public class SesionDto
    {
        public long Sesionid { get; set; }
        public long Usuarioid { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechafin { get; set; }
        public string Direccionip { get; set; }
        public bool? Activa { get; set; }
    }

    public class SesionListaDto
    {
        public long Sesionid { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechafin { get; set; }
        public string Direccionip { get; set; }
        public bool? Activa { get; set; }
        public string DuracionSesion { get; set; }
    }
}
