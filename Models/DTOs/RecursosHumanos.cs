using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Models.DTOs
{
    // ===============================
    // EMPLEADO DTOs
    // ===============================

    public class EmpleadoDto
    {
        public long Empleadoid { get; set; }
        public string Codigoempleado { get; set; }
        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public string Primerapellido { get; set; }
        public string Segundoapellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Dui { get; set; }
        public string Nit { get; set; }
        public DateTime? Fechanacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correoelectronico { get; set; }
        public DateTime? Fechaingreso { get; set; }
        public DateTime? Fechasalida { get; set; }
        public decimal? Salariobase { get; set; }
        public long? Usuarioid { get; set; }
        public string UsuarioNombre { get; set; }
        public bool? Activo { get; set; }
        public string EstadoLaboral { get; set; } // "Activo", "Inactivo", "Suspendido"
    }

    public class CrearEmpleadoDto
    {
        [Required(ErrorMessage = "El primer nombre es requerido")]
        [StringLength(100, ErrorMessage = "El primer nombre no puede tener más de 100 caracteres")]
        public string Primernombre { get; set; }

        [StringLength(100, ErrorMessage = "El segundo nombre no puede tener más de 100 caracteres")]
        public string Segundonombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [StringLength(100, ErrorMessage = "El primer apellido no puede tener más de 100 caracteres")]
        public string Primerapellido { get; set; }

        [StringLength(100, ErrorMessage = "El segundo apellido no puede tener más de 100 caracteres")]
        public string Segundoapellido { get; set; }

        [Required(ErrorMessage = "El DUI es requerido")]
        [StringLength(10, ErrorMessage = "El DUI no puede tener más de 10 caracteres")]
        public string Dui { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string Nit { get; set; }

        public DateTime? Fechanacimiento { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        public DateTime Fechaingreso { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario base no puede ser negativo")]
        public decimal? Salariobase { get; set; }

        public long? Usuarioid { get; set; }
    }

    public class ActualizarEmpleadoDto
    {
        [Required(ErrorMessage = "El primer nombre es requerido")]
        [StringLength(100, ErrorMessage = "El primer nombre no puede tener más de 100 caracteres")]
        public string Primernombre { get; set; }

        [StringLength(100, ErrorMessage = "El segundo nombre no puede tener más de 100 caracteres")]
        public string Segundonombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [StringLength(100, ErrorMessage = "El primer apellido no puede tener más de 100 caracteres")]
        public string Primerapellido { get; set; }

        [StringLength(100, ErrorMessage = "El segundo apellido no puede tener más de 100 caracteres")]
        public string Segundoapellido { get; set; }

        [StringLength(17, ErrorMessage = "El NIT no puede tener más de 17 caracteres")]
        public string Nit { get; set; }

        public DateTime? Fechanacimiento { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede tener más de 255 caracteres")]
        public string Correoelectronico { get; set; }

        public DateTime? Fechasalida { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El salario base no puede ser negativo")]
        public decimal? Salariobase { get; set; }

        public long? Usuarioid { get; set; }
        public bool? Activo { get; set; }
    }

    public class EmpleadoListaDto
    {
        public long Empleadoid { get; set; }
        public string Codigoempleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Dui { get; set; }
        public string Telefono { get; set; }
        public DateTime? Fechaingreso { get; set; }
        public decimal? Salariobase { get; set; }
        public bool? Activo { get; set; }
        public string EstadoLaboral { get; set; }
    }

    public class EmpleadoResumenDto
    {
        public long Empleadoid { get; set; }
        public string Codigoempleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Correoelectronico { get; set; }
    }

    // ===============================
    // PLANILLA DTOs
    // ===============================

    public class PlanillaDto
    {
        public long Planillaid { get; set; }
        public string Numeroplanilla { get; set; }
        public long Tipoplanillaid { get; set; }
        public string TipoPlanillaNombre { get; set; }
        public DateTime? Fechaplanilla { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechafin { get; set; }
        public decimal? Totaldevengado { get; set; }
        public decimal? Totaldeducciones { get; set; }
        public decimal? Totalneto { get; set; }
        public bool? Procesada { get; set; }
        public bool? Pagada { get; set; }
        public DateTime? Fechapago { get; set; }
        public List<PlanillaDetalleDto> Detalles { get; set; } = new List<PlanillaDetalleDto>();
    }

    public class CrearPlanillaDto
    {
        [Required(ErrorMessage = "El tipo de planilla es requerido")]
        public long Tipoplanillaid { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime Fechainicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es requerida")]
        public DateTime Fechafin { get; set; }

        [Required(ErrorMessage = "Debe incluir al menos un empleado")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un empleado")]
        public List<long> EmpleadosIds { get; set; } = new List<long>();
    }

    public class PlanillaListaDto
    {
        public long Planillaid { get; set; }
        public string Numeroplanilla { get; set; }
        public string TipoPlanillaNombre { get; set; }
        public DateTime? Fechaplanilla { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechafin { get; set; }
        public decimal? Totalneto { get; set; }
        public bool? Procesada { get; set; }
        public bool? Pagada { get; set; }
        public int CantidadEmpleados { get; set; }
    }

    // ===============================
    // PLANILLA DETALLE DTOs
    // ===============================

    public class PlanillaDetalleDto
    {
        public long Planilladetalleid { get; set; }
        public long Empleadoid { get; set; }
        public string EmpleadoNombre { get; set; }
        public decimal? Salariobase { get; set; }
        public decimal? Horasordinarias { get; set; }
        public decimal? Horasextras { get; set; }
        public decimal? Bonificaciones { get; set; }
        public decimal? Comisiones { get; set; }
        public decimal? Totaldevengado { get; set; }
        public decimal? Isss { get; set; }
        public decimal? Afp { get; set; }
        public decimal? Renta { get; set; }
        public decimal? Otraseducciones { get; set; }
        public decimal? Totaldeducciones { get; set; }
        public decimal? Salariofinal { get; set; }
    }

    public class ActualizarPlanillaDetalleDto
    {
        [Range(0, double.MaxValue, ErrorMessage = "Las horas ordinarias no pueden ser negativas")]
        public decimal? Horasordinarias { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Las horas extras no pueden ser negativas")]
        public decimal? Horasextras { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Las bonificaciones no pueden ser negativas")]
        public decimal? Bonificaciones { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Las comisiones no pueden ser negativas")]
        public decimal? Comisiones { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Otras deducciones no pueden ser negativas")]
        public decimal? Otraseducciones { get; set; }
    }

    // ===============================
    // TIPO PLANILLA DTOs
    // ===============================

    public class TipoPlanillaDto
    {
        public long Tipoplanillaid { get; set; }
        public string Nombretipoplanilla { get; set; }
        public string Descripcion { get; set; }
        public int? Periodicidaddias { get; set; }
        public bool? Activo { get; set; }
    }

    public class CrearTipoPlanillaDto
    {
        [Required(ErrorMessage = "El nombre del tipo de planilla es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de planilla no puede tener más de 100 caracteres")]
        public string Nombretipoplanilla { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Range(1, 365, ErrorMessage = "La periodicidad debe estar entre 1 y 365 días")]
        public int? Periodicidaddias { get; set; }
    }

    public class ActualizarTipoPlanillaDto
    {
        [Required(ErrorMessage = "El nombre del tipo de planilla es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de planilla no puede tener más de 100 caracteres")]
        public string Nombretipoplanilla { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Range(1, 365, ErrorMessage = "La periodicidad debe estar entre 1 y 365 días")]
        public int? Periodicidaddias { get; set; }

        public bool? Activo { get; set; }
    }

    // ===============================
    // ASISTENCIA DTOs
    // ===============================

    public class AsistenciaDto
    {
        public long Asistenciaid { get; set; }
        public long Empleadoid { get; set; }
        public string EmpleadoNombre { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Horaentrada { get; set; }
        public TimeSpan? Horasalida { get; set; }
        public decimal? Horastrabajadas { get; set; }
        public decimal? Horasextras { get; set; }
        public string Observaciones { get; set; }
        public bool? Presente { get; set; }
    }

    public class RegistrarAsistenciaDto
    {
        [Required(ErrorMessage = "El empleado es requerido")]
        public long Empleadoid { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }

        public TimeSpan? Horaentrada { get; set; }
        public TimeSpan? Horasalida { get; set; }
        public string Observaciones { get; set; }
        public bool? Presente { get; set; }
    }

    public class AsistenciaListaDto
    {
        public long Asistenciaid { get; set; }
        public string EmpleadoNombre { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Horaentrada { get; set; }
        public TimeSpan? Horasalida { get; set; }
        public decimal? Horastrabajadas { get; set; }
        public bool? Presente { get; set; }
    }

    // ===============================
    // REPORTE DTOs
    // ===============================

    public class ReporteAsistenciaDto
    {
        public string EmpleadoNombre { get; set; }
        public int DiasPresente { get; set; }
        public int DiasAusente { get; set; }
        public decimal TotalHorasTrabajadas { get; set; }
        public decimal TotalHorasExtras { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class ReportePlanillaDto
    {
        public string TipoPlanilla { get; set; }
        public DateTime Periodo { get; set; }
        public int TotalEmpleados { get; set; }
        public decimal TotalDevengado { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal TotalNeto { get; set; }
    }
}
