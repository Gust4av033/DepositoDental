using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Models.DTOs
{
    // ===============================
    // FACTURA DTOs
    // ===============================

    public class FacturaDto
    {
        public long Facturaid { get; set; }
        public string Numerofactura { get; set; }
        public long Serieid { get; set; }
        public string SerieNombre { get; set; }
        public long Clienteid { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteNit { get; set; }
        public string ClienteDui { get; set; }
        public DateTime? Fechafactura { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public long? Condicionpagoid { get; set; }
        public string CondicionPagoNombre { get; set; }
        public string Codigogeneracion { get; set; }
        public string Numerocontrol { get; set; }
        public string Sellorecepcion { get; set; }
        public DateTime? Fecharecepcionmh { get; set; }
        public string Estadomh { get; set; }
        public string Observacionesmh { get; set; }
        public long Estadoid { get; set; }
        public string EstadoNombre { get; set; }
        public bool? Anulada { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public List<FacturaDetalleDto> Detalles { get; set; } = new List<FacturaDetalleDto>();
    }

    public class CrearFacturaDto
    {
        [Required(ErrorMessage = "La serie es requerida")]
        public long Serieid { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        public long Clienteid { get; set; }

        public long? Condicionpagoid { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearFacturaDetalleDto> Detalles { get; set; } = new List<CrearFacturaDetalleDto>();
    }

    public class FacturaListaDto
    {
        public long Facturaid { get; set; }
        public string Numerofactura { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechafactura { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
        public bool? Anulada { get; set; }
        public string UsuarioCreacionNombre { get; set; }
    }

    public class FacturaResumenDto
    {
        public long Facturaid { get; set; }
        public string Numerofactura { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechafactura { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
    }

    // ===============================
    // FACTURA DETALLE DTOs
    // ===============================

    public class FacturaDetalleDto
    {
        public long Facturadetalleid { get; set; }
        public long Productoid { get; set; }
        public string Codigoproducto { get; set; }
        public string Nombreproducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal Ventasafectas { get; set; }
        public decimal? Iva { get; set; }
        public decimal TotalLinea { get; set; }
    }

    public class CrearFacturaDetalleDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
        public decimal Preciounitario { get; set; }
    }

    // ===============================
    // COTIZACIÓN DTOs
    // ===============================

    public class CotizacionDto
    {
        public long Cotizacionid { get; set; }
        public string Numerocotizacion { get; set; }
        public long Clienteid { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechacotizacion { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public decimal? Total { get; set; }
        public long Estadoid { get; set; }
        public string EstadoNombre { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public List<CotizacionDetalleDto> Detalles { get; set; } = new List<CotizacionDetalleDto>();
    }

    public class CrearCotizacionDto
    {
        [Required(ErrorMessage = "El cliente es requerido")]
        public long Clienteid { get; set; }

        public DateTime? Fechavencimiento { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearCotizacionDetalleDto> Detalles { get; set; } = new List<CrearCotizacionDetalleDto>();
    }

    public class CotizacionListaDto
    {
        public long Cotizacionid { get; set; }
        public string Numerocotizacion { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechacotizacion { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public bool Vencida { get; set; }
    }

    // ===============================
    // COTIZACIÓN DETALLE DTOs
    // ===============================

    public class CotizacionDetalleDto
    {
        public long Cotizaciondetalleid { get; set; }
        public long Productoid { get; set; }
        public string Codigoproducto { get; set; }
        public string Nombreproducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal? Descuentoporcentaje { get; set; }
        public decimal? Descuentomonto { get; set; }
        public decimal TotalLinea { get; set; }
    }

    public class CrearCotizacionDetalleDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
        public decimal Preciounitario { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100")]
        public decimal? Descuentoporcentaje { get; set; }
    }

    // ===============================
    // PEDIDO DTOs
    // ===============================

    public class PedidoDto
    {
        public long Pedidoid { get; set; }
        public string Numeropedido { get; set; }
        public long Clienteid { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechapedido { get; set; }
        public DateTime? Fechaentrega { get; set; }
        public decimal? Total { get; set; }
        public long Estadoid { get; set; }
        public string EstadoNombre { get; set; }
        public string Observaciones { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public List<PedidoDetalleDto> Detalles { get; set; } = new List<PedidoDetalleDto>();
    }

    public class CrearPedidoDto
    {
        [Required(ErrorMessage = "El cliente es requerido")]
        public long Clienteid { get; set; }

        public DateTime? Fechaentrega { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearPedidoDetalleDto> Detalles { get; set; } = new List<CrearPedidoDetalleDto>();
    }

    public class PedidoListaDto
    {
        public long Pedidoid { get; set; }
        public string Numeropedido { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechapedido { get; set; }
        public DateTime? Fechaentrega { get; set; }
        public decimal? Total { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public bool Atrasado { get; set; }
    }

    // ===============================
    // PEDIDO DETALLE DTOs
    // ===============================

    public class PedidoDetalleDto
    {
        public long Pedidodetalleid { get; set; }
        public long Productoid { get; set; }
        public string Codigoproducto { get; set; }
        public string Nombreproducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Preciounitario { get; set; }
        public decimal TotalLinea { get; set; }
    }

    public class CrearPedidoDetalleDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
        public decimal Preciounitario { get; set; }
    }

    // ===============================
    // NOTA DE CRÉDITO DTOs
    // ===============================

    public class NotaCreditoDto
    {
        public long Notacreditoid { get; set; }
        public string Numeronotacredito { get; set; }
        public long Facturaid { get; set; }
        public string NumeroFactura { get; set; }
        public long Clienteid { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechanotacredito { get; set; }
        public decimal? Total { get; set; }
        public string Motivo { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
    }

    public class CrearNotaCreditoDto
    {
        [Required(ErrorMessage = "La factura es requerida")]
        public long Facturaid { get; set; }

        [Required(ErrorMessage = "El motivo es requerido")]
        [StringLength(500, ErrorMessage = "El motivo no puede tener más de 500 caracteres")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "El total es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
        public decimal Total { get; set; }
    }

    public class NotaCreditoListaDto
    {
        public long Notacreditoid { get; set; }
        public string Numeronotacredito { get; set; }
        public string NumeroFactura { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime? Fechanotacredito { get; set; }
        public decimal? Total { get; set; }
        public string UsuarioCreacionNombre { get; set; }
    }

    // ===============================
    // CONDICIONES DE PAGO DTOs
    // ===============================

    public class CondicionPagoDto
    {
        public long Condicionpagoid { get; set; }
        public string Nombrecondicion { get; set; }
        public string Descripcion { get; set; }
        public int? Diasplazo { get; set; }
        public bool? Activa { get; set; }
    }

    public class CrearCondicionPagoDto
    {
        [Required(ErrorMessage = "El nombre de la condición es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la condición no puede tener más de 100 caracteres")]
        public string Nombrecondicion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, 999, ErrorMessage = "Los días de plazo deben estar entre 0 y 999")]
        public int? Diasplazo { get; set; }
    }

    public class ActualizarCondicionPagoDto
    {
        [Required(ErrorMessage = "El nombre de la condición es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la condición no puede tener más de 100 caracteres")]
        public string Nombrecondicion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, 999, ErrorMessage = "Los días de plazo deben estar entre 0 y 999")]
        public int? Diasplazo { get; set; }

        public bool? Activa { get; set; }
    }

    // ===============================
    // SERIES DTOs
    // ===============================

    public class SerieDto
    {
        public long Serieid { get; set; }
        public string Nombreserie { get; set; }
        public string Prefijo { get; set; }
        public long? Numeroinicial { get; set; }
        public long? Numerofinal { get; set; }
        public long? Numeroactual { get; set; }
        public bool? Activa { get; set; }
        public long? Tipodocumentoid { get; set; }
        public string TipoDocumentoNombre { get; set; }
    }

    public class CrearSerieDto
    {
        [Required(ErrorMessage = "El nombre de la serie es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la serie no puede tener más de 100 caracteres")]
        public string Nombreserie { get; set; }

        [StringLength(10, ErrorMessage = "El prefijo no puede tener más de 10 caracteres")]
        public string Prefijo { get; set; }

        [Required(ErrorMessage = "El número inicial es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "El número inicial debe ser mayor a 0")]
        public long Numeroinicial { get; set; }

        [Required(ErrorMessage = "El número final es requerido")]
        [Range(1, long.MaxValue, ErrorMessage = "El número final debe ser mayor a 0")]
        public long Numerofinal { get; set; }

        public long? Tipodocumentoid { get; set; }
    }

    public class ActualizarSerieDto
    {
        [Required(ErrorMessage = "El nombre de la serie es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la serie no puede tener más de 100 caracteres")]
        public string Nombreserie { get; set; }

        [StringLength(10, ErrorMessage = "El prefijo no puede tener más de 10 caracteres")]
        public string Prefijo { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "El número final debe ser mayor a 0")]
        public long? Numerofinal { get; set; }

        public bool? Activa { get; set; }
        public long? Tipodocumentoid { get; set; }
    }
}
