using PruebaTecnica.AccesoADatos;
using PruebaTecnica.Entidades;
using PruebaTecnica.Entidades.Dto;

namespace PruebaTecnica.Logica.EmpresaBIL
{
    public class CreateEmpresaService
    {
        private readonly PruebaTecnicaContext _context;

        public CreateEmpresaService()
        {
            _context = new PruebaTecnicaContext();
        }

        public (bool, string) Ejecutar(EmpresaDto empresaDto)
        {
            bool validateData = new EmpresaDto().VlidateData(empresaDto);
            
            if (!validateData)
                return (false, "Complete toda la data.");

            Empresa empresa = new Empresa();

            empresa = empresa.MapearDesdeEmpresaDtoAEmpresa(empresaDto);

            _context.Empresa.Add(empresa);

            if (_context.SaveChanges() > 0)
                return (true, "Registro exitoso.");
            else
                return (false, "No se registró la información.");
        }
    }
}