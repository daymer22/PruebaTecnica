using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using PruebaTecnica.Entidades.Dto;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.Logica.EmpresaServices
{
    public class GetEmpresasService
    {
        private readonly PruebaTecnicaContext _context;

        public GetEmpresasService()
        {
            _context = new PruebaTecnicaContext();
        }

        public List<EmpresaDto> Ejecutar()
        {
            List<Empresa> empresas = _context.Empresa.ToList();

            List<EmpresaDto> empresasDto = new List<EmpresaDto>();

            empresasDto = new EmpresaDto().MapearListaDeEmpresasAListaDeEmpresasDto(empresas);

            return empresasDto;
        }
    }
}