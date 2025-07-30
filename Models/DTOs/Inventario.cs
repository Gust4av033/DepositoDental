using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Models.DTOs
{
    // ===============================
    // PRODUCTO DTOs
    // ===============================

    public class ProductoDto
    {
        public long Productoid { get; set; }
        public string Codigoproducto { get; set; }
        public string Codigobarras { get; set; }
        public string Nombreproducto { get; set; }
        public string Descripcion { get; set; }
        public long Categoriaid { get; set; }
        public string CategoriaNombre { get; set; }
        public long? Marcaid { get; set; }
        public string MarcaNombre { get; set; }
        public long Unidadmedidaid { get; set; }
        public string UnidadmedidaNombre { get; set; }
        public decimal? Costopromedio { get; set; }
        public decimal? Precioventa1 { get; set; }
        public decimal? Precioventa2 { get; set; }
        public decimal? Precioventa3 { get; set; }
        public int? Stockminimo { get; set; }
        public int? Stockmaximo { get; set; }
        public int? Stockactual { get; set; }
        public int? Stockcomprometido { get; set; }
        public bool? Aplicaiva { get; set; }
        public decimal? Porcentajeiva { get; set; }
        public string Codigotributario { get; set; }
        public bool? Manejavencimiento { get; set; }
        public bool? Manejalotes { get; set; }
        public bool? Activo { get; set; }
        public bool? Esservicio { get; set; }
        public List<StockBodegaDto> StockPorBodega { get; set; } = new List<StockBodegaDto>();
        public List<LoteDto> Lotes { get; set; } = new List<LoteDto>();
        public List<ProductoHistoricoDto> Historicos { get; set; } = new List<ProductoHistoricoDto>();
    }

    public class CrearProductoDto
    {
        [Required(ErrorMessage = "El código del producto es requerido")]
        [StringLength(50, ErrorMessage = "El código del producto no puede tener más de 50 caracteres")]
        public string Codigoproducto { get; set; }

        [StringLength(50, ErrorMessage = "El código de barras no puede tener más de 50 caracteres")]
        public string Codigobarras { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del producto no puede tener más de 255 caracteres")]
        public string Nombreproducto { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        public long Categoriaid { get; set; }

        public long? Marcaid { get; set; }

        [Required(ErrorMessage = "La unidad de medida es requerida")]
        public long Unidadmedidaid { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo promedio no puede ser negativo")]
        public decimal? Costopromedio { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta 1 no puede ser negativo")]
        public decimal? Precioventa1 { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta 2 no puede ser negativo")]
        public decimal? Precioventa2 { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta 3 no puede ser negativo")]
        public decimal? Precioventa3 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo")]
        public int? Stockminimo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock máximo no puede ser negativo")]
        public int? Stockmaximo { get; set; }

        public bool? Aplicaiva { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de IVA debe estar entre 0 y 100")]
        public decimal? Porcentajeiva { get; set; }

        [StringLength(50, ErrorMessage = "El código tributario no puede tener más de 50 caracteres")]
        public string Codigotributario { get; set; }

        public bool? Manejavencimiento { get; set; }
        public bool? Manejalotes { get; set; }
        public bool? Esservicio { get; set; }
    }

    public class ActualizarProductoDto
    {
        [StringLength(50, ErrorMessage = "El código de barras no puede tener más de 50 caracteres")]
        public string Codigobarras { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del producto no puede tener más de 255 caracteres")]
        public string Nombreproducto { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        public long Categoriaid { get; set; }

        public long? Marcaid { get; set; }

        [Required(ErrorMessage = "La unidad de medida es requerida")]
        public long Unidadmedidaid { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo promedio no puede ser negativo")]
        public decimal? Costopromedio { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta 1 no puede ser negativo")]
        public decimal? Precioventa1 { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta 2 no puede ser negativo")]
        public decimal? Precioventa2 { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta 3 no puede ser negativo")]
        public decimal? Precioventa3 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo")]
        public int? Stockminimo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock máximo no puede ser negativo")]
        public int? Stockmaximo { get; set; }

        public bool? Aplicaiva { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de IVA debe estar entre 0 y 100")]
        public decimal? Porcentajeiva { get; set; }

        [StringLength(50, ErrorMessage = "El código tributario no puede tener más de 50 caracteres")]
        public string Codigotributario { get; set; }

        public bool? Manejavencimiento { get; set; }
        public bool? Manejalotes { get; set; }
        public bool? Activo { get; set; }
        public bool? Esservicio { get; set; }
    }

    public class ProductoListaDto
    {
        public long Productoid { get; set; }
        public string Codigoproducto { get; set; }
        public string Codigobarras { get; set; }
        public string Nombreproducto { get; set; }
        public string CategoriaNombre { get; set; }
        public string MarcaNombre { get; set; }
        public decimal? Precioventa1 { get; set; }
        public int? Stockactual { get; set; }
        public int? Stockminimo { get; set; }
        public bool? Activo { get; set; }
        public string EstadoStock { get; set; } // "Normal", "Bajo", "Agotado"
        public bool? Esservicio { get; set; }
    }

    public class ProductoResumenDto
    {
        public long Productoid { get; set; }
        public string Codigoproducto { get; set; }
        public string Nombreproducto { get; set; }
        public decimal? Precioventa1 { get; set; }
        public int? Stockactual { get; set; }
        public bool? Esservicio { get; set; }
    }

    // ===============================
    // CATEGORIA DTOs
    // ===============================

    public class CategoriaDto
    {
        public long Categoriaid { get; set; }
        public string Nombrecategoria { get; set; }
        public string Descripcion { get; set; }
        public long? Categoriapadreid { get; set; }
        public string CategoriaPadreNombre { get; set; }
        public bool? Activa { get; set; }
        public int CantidadProductos { get; set; }
        public List<CategoriaDto> Subcategorias { get; set; } = new List<CategoriaDto>();
    }

    public class CrearCategoriaDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la categoría no puede tener más de 100 caracteres")]
        public string Nombrecategoria { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public long? Categoriapadreid { get; set; }
    }

    public class ActualizarCategoriaDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la categoría no puede tener más de 100 caracteres")]
        public string Nombrecategoria { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public long? Categoriapadreid { get; set; }
        public bool? Activa { get; set; }
    }

    // ===============================
    // MARCA DTOs
    // ===============================

    public class MarcaDto
    {
        public long Marcaid { get; set; }
        public string Nombremarca { get; set; }
        public string Descripcion { get; set; }
        public bool? Activa { get; set; }
        public int CantidadProductos { get; set; }
    }

    public class CrearMarcaDto
    {
        [Required(ErrorMessage = "El nombre de la marca es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la marca no puede tener más de 100 caracteres")]
        public string Nombremarca { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }
    }

    public class ActualizarMarcaDto
    {
        [Required(ErrorMessage = "El nombre de la marca es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la marca no puede tener más de 100 caracteres")]
        public string Nombremarca { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public bool? Activa { get; set; }
    }

    // ===============================
    // UNIDAD DE MEDIDA DTOs
    // ===============================

    public class UnidadMedidaDto
    {
        public long Unidadmedidaid { get; set; }
        public string Nombreunidad { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public bool? Activa { get; set; }
    }

    public class CrearUnidadMedidaDto
    {
        [Required(ErrorMessage = "El nombre de la unidad es requerido")]
        [StringLength(50, ErrorMessage = "El nombre de la unidad no puede tener más de 50 caracteres")]
        public string Nombreunidad { get; set; }

        [Required(ErrorMessage = "La abreviatura es requerida")]
        [StringLength(10, ErrorMessage = "La abreviatura no puede tener más de 10 caracteres")]
        public string Abreviatura { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }
    }

    public class ActualizarUnidadMedidaDto
    {
        [Required(ErrorMessage = "El nombre de la unidad es requerido")]
        [StringLength(50, ErrorMessage = "El nombre de la unidad no puede tener más de 50 caracteres")]
        public string Nombreunidad { get; set; }

        [Required(ErrorMessage = "La abreviatura es requerida")]
        [StringLength(10, ErrorMessage = "La abreviatura no puede tener más de 10 caracteres")]
        public string Abreviatura { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public bool? Activa { get; set; }
    }

    // ===============================
    // BODEGA DTOs
    // ===============================

    public class BodegaDto
    {
        public long Bodegaid { get; set; }
        public string Nombrebodega { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public bool? Esprincipal { get; set; }
        public bool? Activa { get; set; }
        public int CantidadProductos { get; set; }
        public decimal ValorInventario { get; set; }
        public List<UbicacionDto> Ubicaciones { get; set; } = new List<UbicacionDto>();
    }

    public class CrearBodegaDto
    {
        [Required(ErrorMessage = "El nombre de la bodega es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la bodega no puede tener más de 100 caracteres")]
        public string Nombrebodega { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        public bool? Esprincipal { get; set; }
    }

    public class ActualizarBodegaDto
    {
        [Required(ErrorMessage = "El nombre de la bodega es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la bodega no puede tener más de 100 caracteres")]
        public string Nombrebodega { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        public bool? Esprincipal { get; set; }
        public bool? Activa { get; set; }
    }

    // ===============================
    // UBICACIÓN DTOs
    // ===============================

    public class UbicacionDto
    {
        public long Ubicacionid { get; set; }
        public string Nombreubicacion { get; set; }
        public string Descripcion { get; set; }
        public long Bodegaid { get; set; }
        public string NombreBodega { get; set; }
        public bool? Activa { get; set; }
        public int ProductosUbicados { get; set; }
    }

    public class CrearUbicacionDto
    {
        [Required(ErrorMessage = "El nombre de la ubicación es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la ubicación no puede tener más de 100 caracteres")]
        public string Nombreubicacion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La bodega es requerida")]
        public long Bodegaid { get; set; }
    }

    public class ActualizarUbicacionDto
    {
        [Required(ErrorMessage = "El nombre de la ubicación es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la ubicación no puede tener más de 100 caracteres")]
        public string Nombreubicacion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public bool? Activa { get; set; }
    }

    // ===============================
    // STOCK BODEGA DTOs
    // ===============================

    public class StockBodegaDto
    {
        public long Stockbodegaid { get; set; }
        public long Bodegaid { get; set; }
        public string NombreBodega { get; set; }
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public long? Ubicacionid { get; set; }
        public string NombreUbicacion { get; set; }
        public int? Stockactual { get; set; }
        public decimal ValorStock { get; set; }
        public DateTime? UltimoMovimiento { get; set; }
    }

    public class ActualizarStockDto
    {
        [Required(ErrorMessage = "La bodega es requerida")]
        public long Bodegaid { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
        public int Stockactual { get; set; }

        public long? Ubicacionid { get; set; }
    }

    public class TransferirStockDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La bodega origen es requerida")]
        public long BodegaOrigenId { get; set; }

        [Required(ErrorMessage = "La bodega destino es requerida")]
        public long BodegaDestinoId { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        public string Observaciones { get; set; }
    }

    // ===============================
    // MOVIMIENTO INVENTARIO DTOs
    // ===============================

    public class MovimientoInventarioDto
    {
        public long Movimientoid { get; set; }
        public string Numeromovimiento { get; set; }
        public long Tipomovimientoid { get; set; }
        public string TipoMovimientoNombre { get; set; }
        public string TipoOperacion { get; set; } // 'E' Entrada, 'S' Salida
        public DateTime? Fechamovimiento { get; set; }
        public long? Bodegaorigenid { get; set; }
        public string BodegaOrigenNombre { get; set; }
        public long? Bodegadestinoid { get; set; }
        public string BodegaDestinoNombre { get; set; }
        public string Observaciones { get; set; }
        public long Estadoid { get; set; }
        public string EstadoNombre { get; set; }
        public long Usuariocreacion { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public List<MovimientoDetalleDto> Detalles { get; set; } = new List<MovimientoDetalleDto>();
    }

    public class CrearMovimientoInventarioDto
    {
        [Required(ErrorMessage = "El tipo de movimiento es requerido")]
        public long Tipomovimientoid { get; set; }

        public long? Bodegaorigenid { get; set; }
        public long? Bodegadestinoid { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un detalle")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto")]
        public List<CrearMovimientoDetalleDto> Detalles { get; set; } = new List<CrearMovimientoDetalleDto>();
    }

    public class MovimientoListaDto
    {
        public long Movimientoid { get; set; }
        public string Numeromovimiento { get; set; }
        public string TipoMovimientoNombre { get; set; }
        public string TipoOperacion { get; set; }
        public DateTime? Fechamovimiento { get; set; }
        public string BodegaOrigenNombre { get; set; }
        public string BodegaDestinoNombre { get; set; }
        public string EstadoNombre { get; set; }
        public string UsuarioCreacionNombre { get; set; }
        public int CantidadItems { get; set; }
    }

    public class MovimientoDetalleDto
    {
        public long Movimientodetalleid { get; set; }
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public long? Loteid { get; set; }
        public string CodigoLote { get; set; }
        public int Cantidad { get; set; }
        public decimal? Costounitario { get; set; }
        public decimal? TotalLinea { get; set; }
    }

    public class CrearMovimientoDetalleDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        public long? Loteid { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int Cantidad { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo unitario no puede ser negativo")]
        public decimal? Costounitario { get; set; }
    }

    // ===============================
    // TIPO MOVIMIENTO DTOs
    // ===============================

    public class TipoMovimientoDto
    {
        public long Tipomovimientoid { get; set; }
        public string Nombretipo { get; set; }
        public string Tipooperacion { get; set; } // 'E' Entrada, 'S' Salida
        public string DescripcionOperacion { get; set; }
        public bool Activo { get; set; }
    }

    public class CrearTipoMovimientoDto
    {
        [Required(ErrorMessage = "El nombre del tipo es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del tipo no puede tener más de 255 caracteres")]
        public string Nombretipo { get; set; }

        [Required(ErrorMessage = "El tipo de operación es requerido")]
        [StringLength(1, ErrorMessage = "El tipo de operación debe ser un solo carácter")]
        [RegularExpression("^[ES]$", ErrorMessage = "El tipo de operación debe ser 'E' (Entrada) o 'S' (Salida)")]
        public string Tipooperacion { get; set; }
    }

    public class ActualizarTipoMovimientoDto
    {
        [Required(ErrorMessage = "El nombre del tipo es requerido")]
        [StringLength(255, ErrorMessage = "El nombre del tipo no puede tener más de 255 caracteres")]
        public string Nombretipo { get; set; }

        [Required(ErrorMessage = "El tipo de operación es requerido")]
        [StringLength(1, ErrorMessage = "El tipo de operación debe ser un solo carácter")]
        [RegularExpression("^[ES]$", ErrorMessage = "El tipo de operación debe ser 'E' (Entrada) o 'S' (Salida)")]
        public string Tipooperacion { get; set; }

        public bool Activo { get; set; }
    }

    // ===============================
    // LOTE DTOs
    // ===============================

    public class LoteDto
    {
        public long Loteid { get; set; }
        public string Codigolote { get; set; }
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public DateTime? Fechaproduccion { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public int? Stockactual { get; set; }
        public decimal? Costounitario { get; set; }
        public bool? Activo { get; set; }
        public string EstadoVencimiento { get; set; } // "Vigente", "Por vencer", "Vencido"
        public int DiasRestantes { get; set; }
    }

    public class CrearLoteDto
    {
        [Required(ErrorMessage = "El código del lote es requerido")]
        [StringLength(50, ErrorMessage = "El código del lote no puede tener más de 50 caracteres")]
        public string Codigolote { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        public DateTime? Fechaproduccion { get; set; }
        public DateTime? Fechavencimiento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo unitario no puede ser negativo")]
        public decimal? Costounitario { get; set; }
    }

    public class ActualizarLoteDto
    {
        [Required(ErrorMessage = "El código del lote es requerido")]
        [StringLength(50, ErrorMessage = "El código del lote no puede tener más de 50 caracteres")]
        public string Codigolote { get; set; }

        public DateTime? Fechaproduccion { get; set; }
        public DateTime? Fechavencimiento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo unitario no puede ser negativo")]
        public decimal? Costounitario { get; set; }

        public bool? Activo { get; set; }
    }

    public class LoteListaDto
    {
        public long Loteid { get; set; }
        public string Codigolote { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public int? Stockactual { get; set; }
        public string EstadoVencimiento { get; set; }
        public bool? Activo { get; set; }
    }

    // ===============================
    // PRODUCTO HISTÓRICO DTOs
    // ===============================

    public class ProductoHistoricoDto
    {
        public long Historicoid { get; set; }
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Accion { get; set; } // "CREADO", "MODIFICADO", "PRECIO_ACTUALIZADO", etc.
        public string ValoresAnteriores { get; set; }
        public string ValoresNuevos { get; set; }
        public DateTime? Fechacambio { get; set; }
        public long? Usuarioid { get; set; }
        public string UsuarioNombre { get; set; }
        public string Observaciones { get; set; }
    }

    public class CrearProductoHistoricoDto
    {
        [Required(ErrorMessage = "El producto es requerido")]
        public long Productoid { get; set; }

        [Required(ErrorMessage = "La acción es requerida")]
        [StringLength(50, ErrorMessage = "La acción no puede tener más de 50 caracteres")]
        public string Accion { get; set; }

        public string ValoresAnteriores { get; set; }
        public string ValoresNuevos { get; set; }
        public string Observaciones { get; set; }
    }

    // ===============================
    // DTOs DE CONSULTAS Y REPORTES
    // ===============================

    public class ConsultaInventarioDto
    {
        public long? Categoriaid { get; set; }
        public long? Marcaid { get; set; }
        public long? Bodegaid { get; set; }
        public bool? SoloConStock { get; set; }
        public bool? SoloBajoMinimo { get; set; }
        public bool? SoloActivos { get; set; }
        public string TerminoBusqueda { get; set; }
    }

    public class ResumenInventarioDto
    {
        public int TotalProductos { get; set; }
        public int ProductosActivos { get; set; }
        public int ProductosConStock { get; set; }
        public int ProductosSinStock { get; set; }
        public int ProductosBajoMinimo { get; set; }
        public decimal ValorTotalInventario { get; set; }
        public DateTime FechaConsulta { get; set; }
    }

    public class MovimientosPorPeriodoDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int TotalMovimientos { get; set; }
        public int MovimientosEntrada { get; set; }
        public int MovimientosSalida { get; set; }
        public decimal ValorEntradas { get; set; }
        public decimal ValorSalidas { get; set; }
    }

    public class ProductosBajoStockDto
    {
        public long Productoid { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CategoriaNombre { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int CantidadSugerida { get; set; }
        public decimal? CostoPromedio { get; set; }
        public decimal? ValorSugerido { get; set; }
    }

    public class LotesProximosVencerDto
    {
        public long Loteid { get; set; }
        public string Codigolote { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public DateTime? Fechavencimiento { get; set; }
        public int DiasRestantes { get; set; }
        public int StockActual { get; set; }
        public decimal? ValorStock { get; set; }
        public string Prioridad { get; set; } // "Alta", "Media", "Baja"
    }

    // ===============================
    // DTOs PARA IMPORTACIÓN/EXPORTACIÓN
    // ===============================

    public class ImportarProductosDto
    {
        public List<ProductoImportacionDto> Productos { get; set; } = new List<ProductoImportacionDto>();
    }

    public class ProductoImportacionDto
    {
        public string Codigoproducto { get; set; }
        public string Codigobarras { get; set; }
        public string Nombreproducto { get; set; }
        public string Descripcion { get; set; }
        public string CategoriaNombre { get; set; }
        public string MarcaNombre { get; set; }
        public string UnidadMedidaNombre { get; set; }
        public decimal? Costopromedio { get; set; }
        public decimal? Precioventa1 { get; set; }
        public decimal? Precioventa2 { get; set; }
        public decimal? Precioventa3 { get; set; }
        public int? Stockminimo { get; set; }
        public int? Stockmaximo { get; set; }
        public bool? Aplicaiva { get; set; }
        public decimal? Porcentajeiva { get; set; }
        public string Codigotributario { get; set; }
        public bool? Manejavencimiento { get; set; }
        public bool? Manejalotes { get; set; }
        public bool? Esservicio { get; set; }
    }

    public class ExportarInventarioDto
    {
        public string Formato { get; set; } // "Excel", "CSV", "PDF"
        public bool IncluirStock { get; set; }
        public bool IncluirPrecios { get; set; }
        public bool IncluirCostos { get; set; }
        public bool SoloActivos { get; set; }
        public List<long> CategoriasIds { get; set; } = new List<long>();
        public List<long> MarcasIds { get; set; } = new List<long>();
    }
}
