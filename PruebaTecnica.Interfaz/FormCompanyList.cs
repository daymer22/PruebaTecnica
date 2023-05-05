using PruebaTecnica.Entidades.Dto;
using PruebaTecnica.Logica.EmpresaServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PruebaTecnica.Interfaz
{
    public partial class FormCompanyList : Form
    {
        private readonly GetEmpresasService _getEmpresasService;
        private readonly DeleteEmpresaService _deleteEmpresaService;
        private readonly DeleteEmpresasService _deleteEmpresasService;

        public FormCompanyList()
        {
            InitializeComponent();
            _getEmpresasService = new GetEmpresasService();
            _deleteEmpresaService = new DeleteEmpresaService();
            _deleteEmpresasService = new DeleteEmpresasService();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            FormCompanyEditor formCompany = new FormCompanyEditor();
            formCompany.Show();
            this.Hide();
        }

        private void FormCompanyList_Load(object sender, EventArgs e)
        {
            CargarDatosALaGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<int> idsEmpresas = new List<int>();

            for (int i = 0; i < dgvListado.Rows.Count; i++)
            {
                object checkeado = dgvListado.Rows[i].Cells[9].Value;

                if (!(checkeado is null))
                    if ((bool)checkeado)
                        idsEmpresas.Add((Int32)dgvListado.Rows[i].Cells[0].Value);                
            }

            if (idsEmpresas.Count < 1)
            {
                MessageBox.Show("Seleccione al menos 1 para eliminar.");
                return;
            }

            if (idsEmpresas.Count > 0 && idsEmpresas.Count < 2)
                _deleteEmpresaService.Ejecutar(idsEmpresas[0]);

            if (idsEmpresas.Count > 1)
                _deleteEmpresasService.Ejecutar(idsEmpresas);

            CargarDatosALaGrilla();
        }        

        private void bntEditar_Click(object sender, EventArgs e)
        {
            List<int> idsEmpresas = new List<int>();

            for (int i = 0; i < dgvListado.Rows.Count; i++)
            {
                object checkeado = dgvListado.Rows[i].Cells[9].Value;

                if (!(checkeado is null))
                    if ((bool)checkeado)
                        idsEmpresas.Add((Int32)dgvListado.Rows[i].Cells[0].Value);
            }

            if (idsEmpresas.Count < 1)
            {
                MessageBox.Show("Seleccione al menos 1 para modificar.");
                return;
            }

            if (idsEmpresas.Count > 1)
            {
                MessageBox.Show("Debe seleccionar sólo 1 para modificar.");
                return;
            }

            FormCompanyEditor formCompany = new FormCompanyEditor(idsEmpresas[0]);
            formCompany.Show();
            this.Hide();
        }
        
        private void CargarDatosALaGrilla()
        {
            List<EmpresaDto> empresasDto = _getEmpresasService.Ejecutar();

            dgvListado.Rows.Clear();

            empresasDto.ForEach(emp => {
                dgvListado.Rows.Add(emp.IdEmpresa, emp.Nombre, emp.Codigo, emp.Direccion, emp.Telefono, emp.Ciudad,
                    emp.Departamento, emp.FechaCreacion, emp.FechaModificacion);
            });
        }
    }
}