using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DepositoDental.Models.DTOs
{
    // ===============================
    // CLIENTE DTOs
    // ===============================

    public class ClienteDto
    {
        public long Clienteid { get; set; }
        public string Codigocliente { get; set; }
        public string Nombrescliente { get; set; }
        public string Apellidoscliente { get; set; }
        public string Nit { get; set; }
        public string Dui { get; set; }
        public string Giro { get; set; }
        public string Nombrecomercial { get; set; }
        public long Tipoclienteid { get; set; }
        public string TipoclienteNombre { get; set; }
        public bool? Escontribuyente { get; set; }
        public long? Municipioid { get; set; }
        public string MunicipioNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public decimal? Creditolimitado { get; set; }
        public int? Diasplazocredito { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public List<ContactoClienteDto> Contactos { get; set; } = new List<ContactoClienteDto>();
        public List<DireccionClienteDto> Direcciones { get; set; } = new List<DireccionClienteDto>();
    }

    public class CrearClienteDto
    {
        [Required(ErrorMessage = "Los nombres del cliente son requeridos")]
        [StringLength(255, ErrorMessage = "Los nombres no pueden tener más de 255 caracteres")]
        public string Nombrescliente { get; set; }

        [StringLength(255, ErrorMessage = "Los apellidos no pueden tener más de 255 caracteres")]
        public string Apellidoscliente { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string Nit { get; set; }

        [StringLength(10, ErrorMessage = "El DUI no puede tener más de 10 caracteres")]
        public string Dui { get; set; }

        [StringLength(500, ErrorMessage = "El giro no puede tener más de 500 caracteres")]
        public string Giro { get; set; }

        [StringLength(255, ErrorMessage = "El nombre comercial no puede tener más de 255 caracteres")]
        public string Nombrecomercial { get; set; }

        [Required(ErrorMessage = "El tipo de cliente es requerido")]
        public long Tipoclienteid { get; set; }

        public bool? Escontribuyente { get; set; }
        public long? Municipioid { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El crédito limitado no puede ser negativo")]
        public decimal? Creditolimitado { get; set; }

        [Range(0, 999, ErrorMessage = "Los días de crédito deben estar entre 0 y 999")]
        public int? Diasplazocredito { get; set; }

        public List<CrearContactoClienteDto> Contactos { get; set; } = new List<CrearContactoClienteDto>();
        public List<CrearDireccionClienteDto> Direcciones { get; set; } = new List<CrearDireccionClienteDto>();
    }

    public class ActualizarClienteDto
    {
        [Required(ErrorMessage = "Los nombres del cliente son requeridos")]
        [StringLength(255, ErrorMessage = "Los nombres no pueden tener más de 255 caracteres")]
        public string Nombrescliente { get; set; }

        [StringLength(255, ErrorMessage = "Los apellidos no pueden tener más de 255 caracteres")]
        public string Apellidoscliente { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string Nit { get; set; }

        [StringLength(10, ErrorMessage = "El DUI no puede tener más de 10 caracteres")]
        public string Dui { get; set; }

        [StringLength(500, ErrorMessage = "El giro no puede tener más de 500 caracteres")]
        public string Giro { get; set; }

        [StringLength(255, ErrorMessage = "El nombre comercial no puede tener más de 255 caracteres")]
        public string Nombrecomercial { get; set; }

        [Required(ErrorMessage = "El tipo de cliente es requerido")]
        public long Tipoclienteid { get; set; }

        public bool? Escontribuyente { get; set; }
        public long? Municipioid { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El crédito limitado no puede ser negativo")]
        public decimal? Creditolimitado { get; set; }

        [Range(0, 999, ErrorMessage = "Los días de crédito deben estar entre 0 y 999")]
        public int? Diasplazocredito { get; set; }

        public bool? Activo { get; set; }
    }

    public class ClienteListaDto
    {
        public long Clienteid { get; set; }
        public string Codigocliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Nit { get; set; }
        public string Dui { get; set; }
        public string TipoclienteNombre { get; set; }
        public string MunicipioNombre { get; set; }
        public decimal? Creditolimitado { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fechacreacion { get; set; }
    }

    public class ClienteResumenDto
    {
        public long Clienteid { get; set; }
        public string Codigocliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Nit { get; set; }
        public string TelefonoPrincipal { get; set; }
        public string CorreoPrincipal { get; set; }
    }

    // ===============================
    // CONTACTO CLIENTE DTOs
    // ===============================

    public class ContactoClienteDto
    {
        public long Contactoid { get; set; }
        public long Clienteid { get; set; }
        public string Nombrecontacto { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Correoelectronico { get; set; }
        public bool? Esprincipal { get; set; }
    }

    public class CrearContactoClienteDto
    {
        [Required(ErrorMessage = "El nombre del contacto es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del contacto no puede tener más de 255 caracteres")]
        public string Nombrecontacto { get; set; }

        [StringLength(100, ErrorMessage = "El cargo no puede tener más de 100 caracteres")]
        public string Cargo { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        public bool? Esprincipal { get; set; }
    }

    public class ActualizarContactoClienteDto
    {
        [Required(ErrorMessage = "El nombre del contacto es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del contacto no puede tener más de 255 caracteres")]
        public string Nombrecontacto { get; set; }

        [StringLength(100, ErrorMessage = "El cargo no puede tener más de 100 caracteres")]
        public string Cargo { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        public bool? Esprincipal { get; set; }
    }

    // ===============================
    // DIRECCIÓN CLIENTE DTOs
    // ===============================

    public class DireccionClienteDto
    {
        public long Direccionid { get; set; }
        public long Clienteid { get; set; }
        public string Direccion { get; set; }
        public long? Municipioid { get; set; }
        public string MunicipioNombre { get; set; }
        public string DepartamentoNombre { get; set; }
        public long? Tipodireccionid { get; set; }
        public string TipodireccionNombre { get; set; }
        public bool? Esprincipal { get; set; }
    }

    public class CrearDireccionClienteDto
    {
        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        public long? Municipioid { get; set; }
        public long? Tipodireccionid { get; set; }
        public bool? Esprincipal { get; set; }
    }

    public class ActualizarDireccionClienteDto
    {
        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        public long? Municipioid { get; set; }
        public long? Tipodireccionid { get; set; }
        public bool? Esprincipal { get; set; }
    }

    // ===============================
    // TIPO CLIENTE DTOs
    // ===============================

    public class TipoClienteDto
    {
        public long Tipoclienteid { get; set; }
        public string Nombretipocliente { get; set; }
        public string Descripcion { get; set; }
        public decimal? Descuentodefecto { get; set; }
    }

    public class CrearTipoClienteDto
    {
        [Required(ErrorMessage = "El nombre del tipo de cliente es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de cliente no puede tener más de 100 caracteres")]
        public string Nombretipocliente { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento por defecto debe estar entre 0 y 100")]
        public decimal? Descuentodefecto { get; set; }
    }

    public class ActualizarTipoClienteDto
    {
        [Required(ErrorMessage = "El nombre del tipo de cliente es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de cliente no puede tener más de 100 caracteres")]
        public string Nombretipocliente { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento por defecto debe estar entre 0 y 100")]
        public decimal? Descuentodefecto { get; set; }
    }
}
