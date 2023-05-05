using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using PruebaTecnica.Entidades.Dto;
using System.Linq;

namespace PruebaTecnica.Logica.EmpresaServices
{
    public class GetEmpresaService
    {
        private readonly PruebaTecnicaContext _context;

        public GetEmpresaService()
        {
            _context = new PruebaTecnicaContext();
        }

        public EmpresaDto Ejecutar(int idEmpresa)
        {
            Empresa empresa = _context.Empresa.FirstOrDefault(emp => emp.IdEmpresa == idEmpresa);

            EmpresaDto empresaDto = new EmpresaDto();

            empresaDto = new EmpresaDto().MapearDeEmpresaAEmpresaDto(empresa);

            return empresaDto;
        }
    }
}