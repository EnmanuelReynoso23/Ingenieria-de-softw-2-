using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class DashboardForm : Form
    {
        private Form? _formularioActual;
        private static readonly Color ColorBotonActivo = Color.FromArgb(124, 10, 2);

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = Session.UsuarioActual?.NombreCompleto ?? string.Empty;
            lblRolUsuario.Text = Session.UsuarioActual?.NombreRol ?? string.Empty;
            AplicarPermisos();
            MostrarFormulario(new inventarioForm(), btnInventario);
        }

        private void AplicarPermisos()
        {
            int idRol = Session.UsuarioActual?.IdRol ?? 0;
            btnClientes.Visible = PermisoRol.PuedeVerClientes(idRol);
            btnFacturacion.Visible = PermisoRol.PuedeVerFacturacion(idRol);
            btnUsuarios.Visible = PermisoRol.PuedeVerUsuarios(idRol);
        }

        private void MostrarFormulario(Form formulario, Button botonActivo)
        {
            if (_formularioActual?.GetType() == formulario.GetType())
            {
                formulario.Dispose();
                return;
            }

            _formularioActual?.Dispose();
            _formularioActual = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(formulario);
            formulario.Show();

            MarcarBotonActivo(botonActivo);
        }

        private void MarcarBotonActivo(Button botonActivo)
        {
            foreach (Button btn in new[] { btnInventario, btnClientes, btnFacturacion, btnUsuarios })
                btn.BackColor = Color.White;

            botonActivo.BackColor = ColorBotonActivo;
        }

        private void BtnInventario_Click(object sender, EventArgs e) => MostrarFormulario(new inventarioForm(), btnInventario);
        private void BtnClientes_Click(object sender, EventArgs e) => MostrarFormulario(new clientesForm(), btnClientes);
        private void BtnFacturacion_Click(object sender, EventArgs e) => MostrarFormulario(new facturacionForm(), btnFacturacion);
        private void BtnUsuarios_Click(object sender, EventArgs e) => MostrarFormulario(new UsuariosForm(), btnUsuarios);

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea cerrar la sesión?", "Cerrar Sesión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            Session.UsuarioActual = null;
            _formularioActual?.Dispose();
            new LoginForm().Show();
            Close();
        }

        private void lblNombreUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblRolUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
