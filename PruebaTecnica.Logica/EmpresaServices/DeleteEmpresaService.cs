using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using System.Linq;

namespace PruebaTecnica.Logica.EmpresaServices
{
    public class DeleteEmpresaService
    {
        private readonly PruebaTecnicaContext _context;

        public DeleteEmpresaService()
        {
            _context = new PruebaTecnicaContext();
        }

        public (bool, string) Ejecutar(int idEmpresa)
        {
            Empresa empresa = _context.Empresa.FirstOrDefault(emp => emp.IdEmpresa == idEmpresa);

            if (!(empresa is null))
                _context.Empresa.Remove(empresa);

            if (_context.SaveChanges() > 0)
                return (true, "Eliminación de empresa exitosa.");
            else
                return (false, "No se eliminó la empresa.");
        }
    }
}