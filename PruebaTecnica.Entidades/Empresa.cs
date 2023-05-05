using PruebaTecnica.Entidades.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Entidades
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required]
        [MaxLength(50), MinLength(5)]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "numeric(12,0)")]
        public int Codigo { get; set; }

        [Required]
        [MaxLength(25), MinLength(5)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(11), MinLength(6)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Ciudad { get; set; }

        [Required]
        [MaxLength(20), MinLength(5)]
        public string Departamento { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaModificacion{ get; set; }

        public virtual Empresa MapearDesdeEmpresaDtoAEmpresa(EmpresaDto empresaDto)
        {
            return new Empresa()
            {
                Ciudad = empresaDto.Ciudad,
                Codigo = empresaDto.Codigo,
                Departamento = empresaDto.Departamento,
                Direccion = empresaDto.Direccion,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Nombre = empresaDto.Nombre,
                Telefono = empresaDto.Telefono
            };
        }

        public virtual Empresa MapearDesdeEmpresaDtoAEmpresaUpdate(EmpresaDto empresaDto)
        {
            return new Empresa()
            {
                IdEmpresa = empresaDto.IdEmpresa,
                Ciudad = empresaDto.Ciudad,
                Codigo = empresaDto.Codigo,
                Departamento = empresaDto.Departamento,
                Direccion = empresaDto.Direccion,
                FechaModificacion = DateTime.Now,
                Nombre = empresaDto.Nombre,
                Telefono = empresaDto.Telefono
            };
        }
    }
}