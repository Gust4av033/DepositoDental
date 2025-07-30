using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // <-- Agrega esta directiva using


namespace DepositoDental.Models
{
    // ===============================
    // REPORTES DE VENTAS
    // ===============================

    public class ReporteVentasDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadFacturas { get; set; }
        public decimal PromedioVenta { get; set; }
        public List<VentaPorClienteDto> VentasPorCliente { get; set; } = new List<VentaPorClienteDto>();
        public List<VentaPorProductoDto> VentasPorProducto { get; set; } = new List<VentaPorProductoDto>();
        public List<VentaPorMesDto> VentasPorMes { get; set; } = new List<VentaPorMesDto>();
    }

    public class VentaPorClienteDto
    {
        public long Clienteid { get; set; }
        public string NombreCliente { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadFacturas { get; set; }
        public decimal Porcentaje { get; set; }
    }

    public class VentaPorProductoDto
    {
        public long Productoid { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal Porcentaje { get; set; }
    }

    public class VentaPorMesDto
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public string NombreMes { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadFacturas { get; set; }
    }

    public class ReporteVentasVendedorDto
    {
        public long Usuarioid { get; set; }
        public string NombreVendedor { get; set; }
        public decimal TotalVentas { get; set; }
        public int CantidadFacturas { get; set; }
        public decimal Comisiones { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    // ===============================
    // REPORTES DE INVENTARIO
    // ===============================

    public class ReporteInventarioDto
    {
        public DateTime FechaReporte { get; set; }
        public decimal ValorTotalInventario { get; set; }
        public int TotalProductos { get; set; }
        public int ProductosConStock { get; set; }
        public int ProductosSinStock { get; set; }
        public int ProductosBajoMinimo { get; set; }
        public List<ProductoInventarioDto> ProductosDetalle { get; set; } = new List<ProductoInventarioDto>();
    }

    public class ProductoInventarioDto
    {
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal ValorInventario { get; set; }
        public string EstadoStock { get; set; }
    }

    public class ReporteInventarioDetalladoDto
    {
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreBodega { get; set; }
        public int StockActual { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal ValorInventario { get; set; }
        public DateTime? UltimoMovimiento { get; set; }
    }

    // ===============================
    // REPORTES FINANCIEROS
    // ===============================

    public class ReporteFinancieroDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal Utilidad { get; set; }
        public decimal MargenUtilidad { get; set; }
        public List<IngresoPorMesDto> IngresosPorMes { get; set; } = new List<IngresoPorMesDto>();
    }

    public class IngresoPorMesDto
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public string NombreMes { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal Utilidad { get; set; }
    }

    // ===============================
    // PARÁMETROS DE REPORTES
    // ===============================

    public class ParametrosReporteVentasDto
    {
        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime FechaFin { get; set; }

        public long? Clienteid { get; set; }
        public long? Vendedorid { get; set; }
        public long? Productoid { get; set; }
        public bool IncluirAnuladas { get; set; } = false;
    }

    public class ParametrosReporteInventarioDto
    {
        public long? Categoriaid { get; set; }
        public long? Marcaid { get; set; }
        public long? Bodegaid { get; set; }
        public bool SoloConStock { get; set; } = false;
        public bool SoloBajoMinimo { get; set; } = false;
    }

    public class ParametrosReporteFinancieroDto
    {
        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime FechaFin { get; set; }

        public string TipoReporte { get; set; } = "Mensual"; // "Diario", "Semanal", "Mensual", "Anual"
    }
}

namespace DepositoDental.Models.DTOs.Comunes
{
    // ===============================
    // DTOs COMUNES PARA RESPUESTAS API
    // ===============================

    public class ApiResponseDto<T>
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
        public List<string> Errores { get; set; } = new List<string>();
        public DateTime FechaRespuesta { get; set; } = DateTime.Now;
    }

    public class PaginacionDto<T>
    {
        public List<T> Datos { get; set; } = new List<T>();
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamañoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public bool TienePaginaAnterior { get; set; }
        public bool TienePaginaSiguiente { get; set; }
    }

    public class ParametrosPaginacionDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "La página debe ser mayor a 0")]
        public int Pagina { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "El tamaño de página debe estar entre 1 y 100")]
        public int TamañoPagina { get; set; } = 10;

        public string TerminoBusqueda { get; set; } = "";
        public string CampoOrden { get; set; } = "";
        public string DireccionOrden { get; set; } = "asc"; // "asc" o "desc"
    }

    public class FiltroFechasDto
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }

    public class SeleccionMultipleDto
    {
        public List<long> Ids { get; set; } = new List<long>();
        public string Accion { get; set; } // "Activar", "Desactivar", "Eliminar"
    }

    // ===============================
    // DTOs PARA LOOKUP/COMBO
    // ===============================

    public class LookupDto
    {
        public long Id { get; set; }
        public string Texto { get; set; }
        public bool? Activo { get; set; }
        public string Descripcion { get; set; }
    }

    public class ComboBoxDto
    {
        public long Value { get; set; }
        public string Text { get; set; }
        public bool Disabled { get; set; } = false;
        public string Group { get; set; }
    }

    // ===============================
    // DTOs PARA AUDITORÍA
    // ===============================

    public class AuditoriaDto
    {
        public long Registroid { get; set; }
        public string Tabla { get; set; }
        public string Operacion { get; set; } // "INSERT", "UPDATE", "DELETE"
        public string ValoresAnteriores { get; set; }
        public string ValoresNuevos { get; set; }
        public long? Usuarioid { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string DireccionIp { get; set; }
    }

    // ===============================
    // DTOs PARA CONFIGURACIÓN
    // ===============================

    public class ConfiguracionDto
    {
        public string Clave { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; } // "String", "Number", "Boolean", "Date"
        public string Categoria { get; set; }
    }

    public class ActualizarConfiguracionDto
    {
        [Required(ErrorMessage = "El valor es requerido")]
        public string Valor { get; set; }
    }

    // ===============================
    // DTOs PARA DASHBOARD
    // ===============================

    public class DashboardDto
    {
        public EstadisticasGeneralesDto EstadisticasGenerales { get; set; }
        public List<VentaRecienteDto> VentasRecientes { get; set; } = new List<VentaRecienteDto>();
        public List<ProductoBajoStockDto> ProductosBajoStock { get; set; } = new List<ProductoBajoStockDto>();
        public List<ClienteTopDto> TopClientes { get; set; } = new List<ClienteTopDto>();
        public GraficoVentasDto GraficoVentas { get; set; }
    }

    public class EstadisticasGeneralesDto
    {
        public decimal VentasHoy { get; set; }
        public decimal VentasMes { get; set; }
        public int ClientesActivos { get; set; }
        public int ProductosStock { get; set; }
        public int FacturasPendientes { get; set; }
        public decimal ValorInventario { get; set; }
    }

    public class VentaRecienteDto
    {
        public long Facturaid { get; set; }
        public string NumeroFactura { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }

    public class ProductoBajoStockDto
    {
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
    }

    public class ClienteTopDto
    {
        public long Clienteid { get; set; }
        public string NombreCliente { get; set; }
        public decimal TotalCompras { get; set; }
        public int CantidadFacturas { get; set; }
    }

    public class GraficoVentasDto
    {
        public List<string> Etiquetas { get; set; } = new List<string>();
        public List<decimal> Valores { get; set; } = new List<decimal>();
        public string Titulo { get; set; }
        public string TipoGrafico { get; set; } = "line"; // "line", "bar", "pie"
    }

    // ===============================
    // DTOs PARA VALIDACIÓN
    // ===============================

    public class ValidacionDto
    {
        public bool EsValido { get; set; }
        public List<string> Errores { get; set; } = new List<string>();
        public List<string> Advertencias { get; set; } = new List<string>();
    }

    public class ValidacionStockDto
    {
        public long Productoid { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadSolicitada { get; set; }
        public int StockDisponible { get; set; }
        public bool TieneStock { get; set; }
        public string Mensaje { get; set; }
    }

    // ===============================
    // DTOs PARA IMPORTACIÓN/EXPORTACIÓN
    // ===============================

    public class ImportacionDto
    {
        public string NombreArchivo { get; set; }
        public int TotalFilas { get; set; }
        public int FilasExitosas { get; set; }
        public int FilasConError { get; set; }
        public List<ErrorImportacionDto> Errores { get; set; } = new List<ErrorImportacionDto>();
        public DateTime FechaImportacion { get; set; }
    }

    public class ErrorImportacionDto
    {
        public int NumeroFila { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string MensajeError { get; set; }
    }

    public class ExportacionDto
    {
        public string NombreArchivo { get; set; }
        public string Formato { get; set; } // "Excel", "CSV", "PDF"
        public int TotalRegistros { get; set; }
        public DateTime FechaExportacion { get; set; }
        public string Url { get; set; }
    }

    // ===============================
    // DTOs PARA NOTIFICACIONES
    // ===============================

    public class NotificacionDto
    {
        public long Notificacionid { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; } // "Info", "Warning", "Error", "Success"
        public bool Leida { get; set; }
        public DateTime FechaCreacion { get; set; }
        public long? Usuarioid { get; set; }
        public string Url { get; set; }
    }

    public class CrearNotificacionDto
    {
        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(200, ErrorMessage = "El título no puede tener más de 200 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El mensaje es requerido")]
        [StringLength(1000, ErrorMessage = "El mensaje no puede tener más de 1000 caracteres")]
        public string Mensaje { get; set; }

        [Required(ErrorMessage = "El tipo es requerido")]
        public string Tipo { get; set; }

        public List<long> UsuariosIds { get; set; } = new List<long>();
        public string Url { get; set; }
    }

    // ===============================
    // DTOs PARA LOGS Y ACTIVIDAD
    // ===============================

    public class LogActividadDto
    {
        public long Logid { get; set; }
        public string Accion { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public long? Usuarioid { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string DireccionIp { get; set; }
        public string UserAgent { get; set; }
    }

    // ===============================
    // DTOs PARA BACKUP Y RESTAURACIÓN
    // ===============================

    public class BackupDto
    {
        public long Backupid { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public long TamañoArchivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string TipoBackup { get; set; } // "Manual", "Automatico"
        public string Estado { get; set; } // "Exitoso", "Error", "En proceso"
        public string Observaciones { get; set; }
    }

    public class CrearBackupDto
    {
        public string Descripcion { get; set; }
        public bool IncluirDatos { get; set; } = true;
        public bool IncluirEstructura { get; set; } = true;
        public List<string> TablasSeleccionadas { get; set; } = new List<string>();
    }

    // ===============================
    // DTOs PARA ARCHIVOS
    // ===============================

    public class ArchivoDto
    {
        public long Archivoid { get; set; }
        public string NombreOriginal { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public string TipoMime { get; set; }
        public long TamañoArchivo { get; set; }
        public DateTime FechaSubida { get; set; }
        public long? Usuarioid { get; set; }
        public string UsuarioNombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class SubirArchivoDto
    {
        public IFormFile Archivo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
    }
}

namespace DepositoDental.Models.DTOs.Configuracion
{
    // ===============================
    // CONFIGURACIÓN DEL SISTEMA
    // ===============================

    public class ConfiguracionSistemaDto
    {
        public string NombreEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public string LogoEmpresa { get; set; }
        public string MonedaPredeterminada { get; set; }
        public decimal IvaPorcentaje { get; set; }
        public int DiasVencimientoFacturas { get; set; }
        public bool PermitirVentaSinStock { get; set; }
        public bool CalcularIvaAutomatico { get; set; }
        public string FormatoFactura { get; set; }
        public string ServidorCorreo { get; set; }
        public int PuertoCorreo { get; set; }
        public bool UsarSslCorreo { get; set; }
        public string UsuarioCorreo { get; set; }
        public string PasswordCorreo { get; set; }
    }

    public class ActualizarConfiguracionSistemaDto
    {
        [StringLength(255, ErrorMessage = "El nombre de la empresa no puede tener más de 255 caracteres")]
        public string NombreEmpresa { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string DireccionEmpresa { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string TelefonoEmpresa { get; set; }

        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string EmailEmpresa { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string NitEmpresa { get; set; }

        [StringLength(3, ErrorMessage = "La moneda no puede tener más de 3 caracteres")]
        public string MonedaPredeterminada { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de IVA debe estar entre 0 y 100")]
        public decimal IvaPorcentaje { get; set; }

        [Range(1, 365, ErrorMessage = "Los días de vencimiento deben estar entre 1 y 365")]
        public int DiasVencimientoFacturas { get; set; }

        public bool PermitirVentaSinStock { get; set; }
        public bool CalcularIvaAutomatico { get; set; }

        [StringLength(100, ErrorMessage = "El formato de factura no puede tener más de 100 caracteres")]
        public string FormatoFactura { get; set; }
    }
}
