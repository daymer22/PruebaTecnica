using PruebaTecnica.Entidades.Dto;
using PruebaTecnica.Logica.EmpresaBIL;
using PruebaTecnica.Logica.EmpresaServices;
using System;
using System.Windows.Forms;

namespace PruebaTecnica.Interfaz
{
    public partial class FormCompanyEditor : Form
    {
        private readonly CreateEmpresaService _createEmpresaService;
        private readonly UpdateEmpresaService _updateEmpresaService;
        private readonly GetEmpresaService _getEmpresaService;
        private int _dataAModificar;
        private EmpresaDto _empresaDto;

        public FormCompanyEditor()
        {
            InitializeComponent();
            _createEmpresaService = new CreateEmpresaService();
        }

        public FormCompanyEditor(int idEmpresa)
        {
            InitializeComponent();
            this._dataAModificar = idEmpresa;
            _updateEmpresaService = new UpdateEmpresaService();
            _getEmpresaService = new GetEmpresaService();
            _empresaDto = _getEmpresaService.Ejecutar(this._dataAModificar);
            CargarDataParaModificar(_empresaDto);
        }
               
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EmpresaDto empresaDto = new EmpresaDto() { 
                Ciudad = txtCiudad.Text,
                Codigo = int.Parse(txtCodigo.Text),
                Departamento = txtDepartamento.Text,
                Direccion = txtDireccion.Text,
                FechaCreacion = null,
                FechaModificacion = null,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text
            };

            (bool, string) responseCreateEmpresa;
            (bool, string) responseUpdateEmpresa;
            if (_dataAModificar > 0)
            {
                empresaDto.IdEmpresa = _empresaDto.IdEmpresa;
                responseUpdateEmpresa = _updateEmpresaService.Ejecutar(empresaDto);
                MessageBox.Show(responseUpdateEmpresa.Item2);
                if (responseUpdateEmpresa.Item1)
                {
                    FormCompanyList formCompanyList = new FormCompanyList();
                    formCompanyList.Show();
                    this.Hide();
                }
            }
            else
            {
                responseCreateEmpresa = _createEmpresaService.Ejecutar(empresaDto);
                MessageBox.Show(responseCreateEmpresa.Item2);
                if (responseCreateEmpresa.Item1)
                {
                    FormCompanyList formCompanyList = new FormCompanyList();
                    formCompanyList.Show();
                    this.Hide();
                }
            }             
        }

        private void bntAtras_Click(object sender, EventArgs e)
        {
            FormCompanyList formCompanyList = new FormCompanyList();
            formCompanyList.Show();
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormCompanyList formCompanyList = new FormCompanyList();
            formCompanyList.Show();
            this.Hide();
        }

        private void CargarDataParaModificar(EmpresaDto empresaDto)
        {
            txtCiudad.Text = empresaDto.Ciudad;
            txtCodigo.Text = empresaDto.Codigo.ToString();
            txtDepartamento.Text = empresaDto.Departamento;
            txtDireccion.Text = empresaDto.Direccion;
            txtNombre.Text = empresaDto.Nombre;
            txtTelefono.Text = empresaDto.Telefono;
        }
    }
}