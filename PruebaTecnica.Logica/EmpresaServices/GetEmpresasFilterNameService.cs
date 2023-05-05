using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using PruebaTecnica.Entidades.Dto;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.Logica.EmpresaServices
{
    public class GetEmpresasFilterNameService
    {
        private readonly PruebaTecnicaContext _context;

        public GetEmpresasFilterNameService()
        {
            _context = new PruebaTecnicaContext();
        }

        public List<EmpresaDto> Ejecutar(string nameEmpresa)
        {
            List<Empresa> empresas = _context.Empresa
                .Where(emp => emp.Nombre.Contains(nameEmpresa)).ToList();

            List<EmpresaDto> empresasDto = new List<EmpresaDto>();

            empresasDto = new EmpresaDto().MapearListaDeEmpresasAListaDeEmpresasDto(empresas);

            return empresasDto;
        }
    }
}