using System;
using System.Drawing;
using System.Windows.Forms;
using InventoryApp.Models; // Asegura tener esto para leer la sesión

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

        // UN SOLO MÉTODO DE CARGA
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (Session.UsuarioActual != null)
            {
                lblNombreUsuario.Text = Session.UsuarioActual.NombreCompleto;
                lblRolUsuario.Text = Session.UsuarioActual.NombreRol;

                AplicarPermisos();
                MostrarFormulario(new inventarioForm(), btnInventario);
            }
            else
            {
                MessageBox.Show("Sesión no válida. Regresando al login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // LA SEGURIDAD CENTRALIZADA
        private void AplicarPermisos()
        {
            int idRol = Session.UsuarioActual?.IdRol ?? 0;

            btnInventario.Visible = PermisoRol.PuedeVerInventario(idRol);
            btnClientes.Visible = PermisoRol.PuedeVerClientes(idRol);
            btnFacturacion.Visible = PermisoRol.PuedeVerFacturacion(idRol);
            btnUsuarios.Visible = PermisoRol.PuedeVerUsuarios(idRol);

            // Aquí bloqueamos el historial (usando la regla de facturación o la del historial si la creaste)
            btnHistorialFacturas.Visible = PermisoRol.PuedeVerFacturacion(idRol);
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
            // Agregué el botón de historial aquí para que también se limpie su color cuando cambies de menú
            foreach (Button btn in new[] { btnInventario, btnClientes, btnFacturacion, btnUsuarios, btnHistorialFacturas })
            {
                btn.BackColor = Color.White;
            }

            botonActivo.BackColor = ColorBotonActivo;
        }

        // EVENTOS CLIC DE LOS BOTONES DEL MENÚ
        private void BtnInventario_Click(object sender, EventArgs e) => MostrarFormulario(new inventarioForm(), btnInventario);
        private void BtnClientes_Click(object sender, EventArgs e) => MostrarFormulario(new clientesForm(), btnClientes);
        private void BtnFacturacion_Click(object sender, EventArgs e) => MostrarFormulario(new facturacionForm(), btnFacturacion);
        private void BtnUsuarios_Click(object sender, EventArgs e) => MostrarFormulario(new UsuariosForm(), btnUsuarios);

        // EVENTO DEL NUEVO BOTÓN
        /*private void BtnHistorialFacturas_Click(object sender, EventArgs e)
        {
            MarcarBotonActivo(btnHistorialFacturas); // Pintamos el botón para que sepan dónde están

            HistorialFacturasForm formHistorial = new HistorialFacturasForm();
            formHistorial.ShowDialog(); // Lo abrimos flotante para que no rompa tu contenedor
        }*/

        // EVENTO DEL NUEVO BOTÓN (Ahora sí, integrado al panel central)
        private void BtnHistorialFacturas_Click(object sender, EventArgs e) => MostrarFormulario(new HistorialFacturasForm(), btnHistorialFacturas);

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea cerrar la sesión?", "Cerrar Sesión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            Session.UsuarioActual = null;
            _formularioActual?.Dispose();
            new LoginForm().Show();
            Close();
        }

        private void lblNombreUsuario_Click(object sender, EventArgs e) { }

        private void lblRolUsuario_Click(object sender, EventArgs e) { }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}