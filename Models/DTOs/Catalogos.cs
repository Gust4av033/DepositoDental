using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositoDental.Models.DTOs
{
    // ===============================
    // ESTADO DTOs
    // ===============================

    public class EstadoDto
    {
        public long Estadoid { get; set; }
        public string Nombreestado { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
        public bool? Activo { get; set; }
    }

    public class CrearEstadoDto
    {
        [Required(ErrorMessage = "El nombre del estado es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del estado no puede tener más de 100 caracteres")]
        public string Nombreestado { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(50, ErrorMessage = "El módulo no puede tener más de 50 caracteres")]
        public string Modulo { get; set; }
    }

    public class ActualizarEstadoDto
    {
        [Required(ErrorMessage = "El nombre del estado es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del estado no puede tener más de 100 caracteres")]
        public string Nombreestado { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(50, ErrorMessage = "El módulo no puede tener más de 50 caracteres")]
        public string Modulo { get; set; }

        public bool? Activo { get; set; }
    }

    // ===============================
    // TIPO DE DIRECCIÓN DTOs
    // ===============================

    public class TipoDireccionDto
    {
        public long Tipodireccionid { get; set; }
        public string Nombretipodireccion { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
    }

    public class CrearTipoDireccionDto
    {
        [Required(ErrorMessage = "El nombre del tipo de dirección es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de dirección no puede tener más de 100 caracteres")]
        public string Nombretipodireccion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }
    }

    public class ActualizarTipoDireccionDto
    {
        [Required(ErrorMessage = "El nombre del tipo de dirección es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de dirección no puede tener más de 100 caracteres")]
        public string Nombretipodireccion { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public bool? Activo { get; set; }
    }

    // ===============================
    // TIPO DE DOCUMENTO DTOs
    // ===============================

    public class TipoDocumentoDto
    {
        public long Tipodocumentoid { get; set; }
        public string Nombretipodocumento { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
        public bool? Afectacontabilidad { get; set; }
        public bool? Escreditofiscal { get; set; }
    }

    public class CrearTipoDocumentoDto
    {
        [Required(ErrorMessage = "El nombre del tipo de documento es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de documento no puede tener más de 100 caracteres")]
        public string Nombretipodocumento { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public bool? Afectacontabilidad { get; set; }
        public bool? Escreditofiscal { get; set; }
    }

    public class ActualizarTipoDocumentoDto
    {
        [Required(ErrorMessage = "El nombre del tipo de documento es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del tipo de documento no puede tener más de 100 caracteres")]
        public string Nombretipodocumento { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        public bool? Activo { get; set; }
        public bool? Afectacontabilidad { get; set; }
        public bool? Escreditofiscal { get; set; }
    }



    // ===============================
    // PAÍS DTOs
    // ===============================

    public class PaisDto
    {
        public long Paisid { get; set; }
        public string Nombrepais { get; set; }
        public string Codigopais { get; set; }
        public bool? Activo { get; set; }
        public List<DepartamentoDto> Departamentos { get; set; } = new List<DepartamentoDto>();
    }

    public class CrearPaisDto
    {
        [Required(ErrorMessage = "El nombre del país es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del país no puede tener más de 100 caracteres")]
        public string Nombrepais { get; set; }

        [StringLength(5, ErrorMessage = "El código del país no puede tener más de 5 caracteres")]
        public string Codigopais { get; set; }
    }

    public class ActualizarPaisDto
    {
        [Required(ErrorMessage = "El nombre del país es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del país no puede tener más de 100 caracteres")]
        public string Nombrepais { get; set; }

        [StringLength(5, ErrorMessage = "El código del país no puede tener más de 5 caracteres")]
        public string Codigopais { get; set; }

        public bool? Activo { get; set; }
    }

    // ===============================
    // DEPARTAMENTO DTOs
    // ===============================

    public class DepartamentoDto
    {
        public long Departamentoid { get; set; }
        public string Nombredepartamento { get; set; }
        public string Codigodepartamento { get; set; }
        public long Paisid { get; set; }
        public string NombrePais { get; set; }
        public bool? Activo { get; set; }
        public List<MunicipioDto> Municipios { get; set; } = new List<MunicipioDto>();
    }

    public class CrearDepartamentoDto
    {
        [Required(ErrorMessage = "El nombre del departamento es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del departamento no puede tener más de 100 caracteres")]
        public string Nombredepartamento { get; set; }

        [StringLength(5, ErrorMessage = "El código del departamento no puede tener más de 5 caracteres")]
        public string Codigodepartamento { get; set; }

        [Required(ErrorMessage = "El país es requerido")]
        public long Paisid { get; set; }
    }

    public class ActualizarDepartamentoDto
    {
        [Required(ErrorMessage = "El nombre del departamento es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del departamento no puede tener más de 100 caracteres")]
        public string Nombredepartamento { get; set; }

        [StringLength(5, ErrorMessage = "El código del departamento no puede tener más de 5 caracteres")]
        public string Codigodepartamento { get; set; }

        [Required(ErrorMessage = "El país es requerido")]
        public long Paisid { get; set; }

        public bool? Activo { get; set; }
    }

    // ===============================
    // MUNICIPIO DTOs
    // ===============================

    public class MunicipioDto
    {
        public long Municipioid { get; set; }
        public string Nombremunicipio { get; set; }
        public string Codigomunicipio { get; set; }
        public long Departamentoid { get; set; }
        public string NombreDepartamento { get; set; }
        public string NombrePais { get; set; }
        public bool? Activo { get; set; }
    }

    public class CrearMunicipioDto
    {
        [Required(ErrorMessage = "El nombre del municipio es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del municipio no puede tener más de 100 caracteres")]
        public string Nombremunicipio { get; set; }

        [StringLength(5, ErrorMessage = "El código del municipio no puede tener más de 5 caracteres")]
        public string Codigomunicipio { get; set; }

        [Required(ErrorMessage = "El departamento es requerido")]
        public long Departamentoid { get; set; }
    }

    public class ActualizarMunicipioDto
    {
        [Required(ErrorMessage = "El nombre del municipio es requerido")]
        [StringLength(100, ErrorMessage = "El nombre del municipio no puede tener más de 100 caracteres")]
        public string Nombremunicipio { get; set; }

        [StringLength(5, ErrorMessage = "El código del municipio no puede tener más de 5 caracteres")]
        public string Codigomunicipio { get; set; }

        [Required(ErrorMessage = "El departamento es requerido")]
        public long Departamentoid { get; set; }

        public bool? Activo { get; set; }
    }

    public class MunicipioListaDto
    {
        public long Municipioid { get; set; }
        public string Nombremunicipio { get; set; }
        public string NombreDepartamento { get; set; }
        public string NombrePais { get; set; }
        public bool? Activo { get; set; }
    }

}