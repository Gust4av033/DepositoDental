using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Models.DTOs
{
    // ===============================
    // PROVEEDOR DTOs
    // ===============================

    public class ProveedorDto
    {
        public long Proveedorid { get; set; }
        public string Codigoproveedor { get; set; }
        public string Nombreproveedor { get; set; }
        public string Nit { get; set; }
        public string Dui { get; set; }
        public string Giro { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correoelectronico { get; set; }
        public string Nombrecontacto { get; set; }
        public string Telefonocontacto { get; set; }
        public bool? Activo { get; set; }
        public long? Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public DateTime? Fechacreacion { get; set; }
    }

    public class CrearProveedorDto
    {
        [Required(ErrorMessage = "El nombre del proveedor es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del proveedor no puede tener más de 255 caracteres")]
        public string Nombreproveedor { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string Nit { get; set; }

        [StringLength(10, ErrorMessage = "El DUI no puede tener más de 10 caracteres")]
        public string Dui { get; set; }

        [StringLength(500, ErrorMessage = "El giro no puede tener más de 500 caracteres")]
        public string Giro { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        [StringLength(255, ErrorMessage = "El nombre del contacto no puede tener más de 255 caracteres")]
        public string Nombrecontacto { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono del contacto no puede tener más de 20 caracteres")]
        public string Telefonocontacto { get; set; }
    }

    public class ActualizarProveedorDto
    {
        [Required(ErrorMessage = "El nombre del proveedor es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del proveedor no puede tener más de 255 caracteres")]
        public string Nombreproveedor { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string Nit { get; set; }

        [StringLength(10, ErrorMessage = "El DUI no puede tener más de 10 caracteres")]
        public string Dui { get; set; }

        [StringLength(500, ErrorMessage = "El giro no puede tener más de 500 caracteres")]
        public string Giro { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        [StringLength(255, ErrorMessage = "El nombre del contacto no puede tener más de 255 caracteres")]
        public string Nombrecontacto { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono del contacto no puede tener más de 20 caracteres")]
        public string Telefonocontacto { get; set; }

        public bool? Activo { get; set; }
    }

    public class ProveedorListaDto
    {
        public long Proveedorid { get; set; }
        public string Codigoproveedor { get; set; }
        public string Nombreproveedor { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Correoelectronico { get; set; }
        public bool? Activo { get; set; }
        public DateTime? Fechacreacion { get; set; }
    }

    public class ProveedorResumenDto
    {
        public long Proveedorid { get; set; }
        public string Codigoproveedor { get; set; }
        public string Nombreproveedor { get; set; }
        public string Telefono { get; set; }
        public string Correoelectronico { get; set; }
    }

    // ===============================
    // ORDEN DE COMPRA DTOs
    // ===============================

    public class OrdenCompraDto
    {
        public long Ordencompraid { get; set; }
        public string Numeroorden { get; set; }
        public long Proveedorid { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fechaorden { get; set; }
        public DateTime? Fechaentregaesperada { get; set; }
        public decimal? Total { get; set; }
        public long Estadoid { get; set; }
        public string EstadoNombre { get; set; }
        public string Observaciones { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public List<OrdenCompraDetalleDto> Detalles { get; set; } = new List<OrdenCompraDetalleDto>();
    }

    public class CrearOrdenCompraDto
    {
        [Required(ErrorMessage = "El proveedor es requerido")]
        public long Proveedorid { get; set; }

        public DateTime? Fechaentregaesperada { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearOrdenCompraDetalleDto> Detalles { get; set; } = new List<CrearOrdenCompraDetalleDto>();
    }

    public class OrdenCompraListaDto
    {
        public long Ordencompraid { get; set; }
        public string Numeroorden { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fechaorden { get; set; }
        public DateTime? Fechaentregaesperada { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public bool Atrasada { get; set; }
    }

    public class OrdenCompraResumenDto
    {
        public long Ordencompraid { get; set; }
        public string Numeroorden { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fechaorden { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
    }

    // ===============================
    // ORDEN COMPRA DETALLE DTOs
    // ===============================

    public class OrdenCompraDetalleDto
    {
        public long Ordencompradetalleid { get; set; }
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Costounitario { get; set; }
        public decimal TotalLinea { get; set; }
    }

    public class CrearOrdenCompraDetalleDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El costo unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo unitario debe ser mayor a 0")]
        public decimal Costounitario { get; set; }
    }

    public class ActualizarOrdenCompraDetalleDto
    {
        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El costo unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo unitario debe ser mayor a 0")]
        public decimal Costounitario { get; set; }
    }

    // ===============================
    // RECEPCIÓN DE COMPRA DTOs
    // ===============================

    public class RecepcionCompraDto
    {
        public long Recepcionid { get; set; }
        public string Numerorecepcion { get; set; }
        public long Ordencompraid { get; set; }
        public string NumeroOrden { get; set; }
        public long Proveedorid { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fecharecepcion { get; set; }
        public string Observaciones { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public List<RecepcionCompraDetalleDto> Detalles { get; set; } = new List<RecepcionCompraDetalleDto>();
    }

    public class CrearRecepcionCompraDto
    {
        [Required(ErrorMessage = "La orden de compra es requerida")]
        public long Ordencompraid { get; set; }

        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearRecepcionCompraDetalleDto> Detalles { get; set; } = new List<CrearRecepcionCompraDetalleDto>();
    }

    public class RecepcionCompraListaDto
    {
        public long Recepcionid { get; set; }
        public string Numerorecepcion { get; set; }
        public string NumeroOrden { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fecharecepcion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public int TotalProductosRecibidos { get; set; }
    }

    // ===============================
    // RECEPCIÓN COMPRA DETALLE DTOs
    // ===============================

    public class RecepcionCompraDetalleDto
    {
        public long Recepciondetalleid { get; set; }
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadOrdenada { get; set; }
        public int CantidadRecibida { get; set; }
        public decimal Costounitario { get; set; }
        public string Lote { get; set; }
        public DateTime? Fechavencimiento { get; set; }
    }

    public class CrearRecepcionCompraDetalleDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La cantidad recibida es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad recibida no puede ser negativa")]
        public int CantidadRecibida { get; set; }

        [Required(ErrorMessage = "El costo unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo unitario debe ser mayor a 0")]
        public decimal Costounitario { get; set; }

        [StringLength(50, ErrorMessage = "El lote no puede tener más de 50 caracteres")]
        public string Lote { get; set; }

        public DateTime? Fechavencimiento { get; set; }
    }

    // ===============================
    // FACTURA PROVEEDOR DTOs
    // ===============================

    public class FacturaProveedorDto
    {
        public long Facturaproveedorid { get; set; }
        public string Numerofactura { get; set; }
        public long Proveedorid { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fechafactura { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public string Observaciones { get; set; }
        public long Estadoid { get; set; }
        public string EstadoNombre { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
    }

    public class CrearFacturaProveedorDto
    {
        [Required(ErrorMessage = "El número de factura es requerido")]
        [StringLength(50, ErrorMessage = "El número de factura no puede tener más de 50 caracteres")]
        public string Numerofactura { get; set; }

        [Required(ErrorMessage = "El proveedor es requerido")]
        public long Proveedorid { get; set; }

        [Required(ErrorMessage = "La fecha de factura es requerida")]
        public DateTime Fechafactura { get; set; }

        public DateTime? Fechavencimiento { get; set; }

        [Required(ErrorMessage = "El subtotal es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El subtotal debe ser mayor a 0")]
        public decimal Subtotal { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El IVA no puede ser negativo")]
        public decimal? Iva { get; set; }

        [Required(ErrorMessage = "El total es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
        public decimal Total { get; set; }

        public string Observaciones { get; set; }
    }

    public class FacturaProveedorListaDto
    {
        public long Facturaproveedorid { get; set; }
        public string Numerofactura { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime? Fechafactura { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public bool Vencida { get; set; }
    }
}
