using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using InventoryApp.DB;

namespace InventoryApp
{
    public partial class LoginForm : Form
    {
        private readonly DataAccess _dataAccess = new DataAccess();
        private static readonly string _archivoRecuerda =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                         "InventoryApp", "recuerda.txt");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(_archivoRecuerda))
            {
                string[] lineas = File.ReadAllLines(_archivoRecuerda);
                if (lineas.Length >= 2)
                {
                    txtUsuario.Text = lineas[0];
                    txtContraseña.Text = Encoding.UTF8.GetString(Convert.FromBase64String(lineas[1]));
                    ChkBRecordar.Checked = true;
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e) { }

        private void txtContraseña_TextChanged(object sender, EventArgs e) { }

        private void ChkBRecordar_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkBRecordar.Checked)
                EliminarUsuarioGuardado();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContraseña.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnEntrar.Enabled = false;
            btnEntrar.Text = "Verificando...";

            try
            {
                var usuarioValido = _dataAccess.ValidarUsuario(usuario, contrasena);

                if (usuarioValido == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o la cuenta está desactivada.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                    return;
                }

                if (ChkBRecordar.Checked)
                    GuardarCredenciales(usuario, contrasena);
                else
                    EliminarUsuarioGuardado();

                Session.UsuarioActual = usuarioValido;

                var formPrincipal = new DashboardForm();
                formPrincipal.Show();
                this.Hide();
                formPrincipal.FormClosed += (s, args) => this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message,
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEntrar.Enabled = true;
                btnEntrar.Text = "Entrar";
            }
        }

        private void GuardarCredenciales(string nombreUsuario, string contrasena)
        {
            try
            {
                string carpeta = Path.GetDirectoryName(_archivoRecuerda)!;
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);
                string contrasenaB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(contrasena));
                File.WriteAllLines(_archivoRecuerda, new[] { nombreUsuario, contrasenaB64 });
            }
            catch { }
        }

        private void EliminarUsuarioGuardado()
        {
            try
            {
                if (File.Exists(_archivoRecuerda))
                    File.Delete(_archivoRecuerda);
            }
            catch { }
        }
    }
}
