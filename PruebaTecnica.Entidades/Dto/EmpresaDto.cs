using System;
using System.Collections.Generic;

namespace PruebaTecnica.Entidades.Dto
{
    public class EmpresaDto
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual bool VlidateData(EmpresaDto empresaDto)
        {
            if (string.IsNullOrEmpty(empresaDto.Nombre))
                return false;

            if (empresaDto.Codigo < 1)
                return false;

            if (string.IsNullOrEmpty(empresaDto.Direccion))
                return false;

            if (string.IsNullOrEmpty(empresaDto.Telefono))
                return false;

            if (string.IsNullOrEmpty(empresaDto.Ciudad))
                return false;

            if (string.IsNullOrEmpty(empresaDto.Departamento))
                return false;

            return true;
        }

        public virtual EmpresaDto MapearDeEmpresaAEmpresaDto(Empresa empresa)
        {
            return new EmpresaDto()
            {
                IdEmpresa = empresa.IdEmpresa,
                Ciudad = empresa.Ciudad,
                Codigo = empresa.Codigo,
                Departamento = empresa.Departamento,
                Direccion = empresa.Direccion,
                FechaModificacion = empresa.FechaModificacion,
                FechaCreacion = empresa.FechaCreacion,
                Nombre = empresa.Nombre,
                Telefono = empresa.Telefono
            };
        }

        public virtual List<EmpresaDto> MapearListaDeEmpresasAListaDeEmpresasDto(List<Empresa> empresas)
        {
            List<EmpresaDto> empresasDto = new List<EmpresaDto>();

            empresas.ForEach(empresa => {
                empresasDto.Add(
                    new EmpresaDto()
                    {
                        IdEmpresa = empresa.IdEmpresa,
                        Ciudad = empresa.Ciudad,
                        Codigo = empresa.Codigo,
                        Departamento = empresa.Departamento,
                        Direccion = empresa.Direccion,
                        FechaModificacion = empresa.FechaModificacion,
                        FechaCreacion = empresa.FechaCreacion,
                        Nombre = empresa.Nombre,
                        Telefono = empresa.Telefono
                    }    
                );
            });

            return empresasDto;
        }
    }
}