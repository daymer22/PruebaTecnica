using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnica.Logica.EmpresaServices
{
    public class DeleteEmpresasService
    {
        private readonly PruebaTecnicaContext _context;

        public DeleteEmpresasService()
        {
            _context = new PruebaTecnicaContext();
        }

        public (bool, string) Ejecutar(List<int> idsEmpresas)
        {
            List<Empresa> empresas = new List<Empresa>();

            idsEmpresas.ForEach(id => {
                empresas.Add(_context.Empresa.FirstOrDefault(emp => emp.IdEmpresa == id));
            });

            _context.RemoveRange(empresas);

            if (_context.SaveChanges() > 0)
                return (true, "Eliminaciones de empresas exitosa.");
            else
                return (false, "No se eliminaron las empresas.");
        }
    }
}