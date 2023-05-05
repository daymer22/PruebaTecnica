using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using PruebaTecnica.Entidades.Dto;

namespace PruebaTecnica.Logica.EmpresaServices
{
    public class UpdateEmpresaService
    {
        private readonly PruebaTecnicaContext _context;

        public UpdateEmpresaService()
        {
            _context = new PruebaTecnicaContext();
        }

        public (bool, string) Ejecutar(EmpresaDto empresaDto)
        {
            bool validateData = new EmpresaDto().VlidateData(empresaDto);

            if (!validateData)
                return (false, "Complete toda la data.");

            Empresa empresa = new Empresa();

            empresa = empresa.MapearDesdeEmpresaDtoAEmpresaUpdate(empresaDto);

            _context.Empresa.Update(empresa);

            if (_context.SaveChanges() > 0)
                return (true, "Modificación exitosa.");
            else
                return (false, "No se modificó la información.");
        }
    }
}