using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryApp.DB;
using InventoryApp.Models;

namespace InventoryApp
{
    public partial class UsuariosForm : Form
    {
        private readonly DataAccess _dataAccess = new DataAccess();

        // Roles
        private static readonly string[] _roles = { "Administrador", "Vendedor", "Almacen" };

        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            CargarRoles();
            ConfigurarGrid();
            CargarUsuarios();
        }

        // --- Configuración inicial ---

        private void CargarRoles()
        {
            cmbRol.Items.Clear();
            foreach (var rol in _roles)
            cmbRol.Items.Add(rol);
            cmbRol.SelectedIndex = 0;
        }

        private void ConfigurarGrid()
        {
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.ReadOnly = true;
        }

        // --- Carga de datos ---

        private void CargarUsuarios()
        {
            try
            {
                List<UserEntity> usuarios = _dataAccess.ListarUsuarios();
                dgvInventory.DataSource = usuarios;

                // Ocultar columnas internas que no son relevantes para el usuario
                if (dgvInventory.Columns["IdRol"] != null)
                    dgvInventory.Columns["IdRol"].Visible = false;

                // Renombrar encabezados de columnas a español
                RenombrarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenombrarColumnas()
        {
            var nombres = new Dictionary<string, string>
            {
                { "Id", "ID" },
                { "NombreCompleto", "Nombre Completo" },
                { "NombreUsuario", "Usuario" },
                { "NombreRol", "Rol" },
                { "Activo", "Activo" },
                { "FechaCreacion", "Fecha Registro" }
            };

            foreach (var par in nombres)
            {
                if (dgvInventory.Columns[par.Key] != null)
                    dgvInventory.Columns[par.Key].HeaderText = par.Value;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombreCompleto.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            txtConfirmar.Clear();
            cmbRol.SelectedIndex = 0;
            chkActivo.Checked = true;
        }

        // --- Selección en la tabla ---

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvInventory.Rows[e.RowIndex];
            txtId.Text = fila.Cells["Id"].Value?.ToString();
            txtNombreCompleto.Text = fila.Cells["NombreCompleto"].Value?.ToString();
            txtNombreUsuario.Text = fila.Cells["NombreUsuario"].Value?.ToString();
            txtContrasena.Clear();
            txtConfirmar.Clear();

            // Seleccionar el rol en el ComboBox (IdRol 1→índice 0, 2→1, 3→2)
            if (fila.Cells["IdRol"].Value != null)
            {
                int idRol = Convert.ToInt32(fila.Cells["IdRol"].Value);
                cmbRol.SelectedIndex = Math.Max(0, idRol - 1);
            }

            chkActivo.Checked = fila.Cells["Activo"].Value != null &&
                                 Convert.ToBoolean(fila.Cells["Activo"].Value);
        }

        // --- Botón Agregar ---

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposObligatorios(requiereContrasena: true)) return;
            if (!ValidarContrasenas()) return;

            try
            {
                var usuario = new UserEntity
                {
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    IdRol = cmbRol.SelectedIndex + 1,
                    Activo = chkActivo.Checked
                };

                _dataAccess.AgregarUsuario(usuario, txtContrasena.Text);

                MessageBox.Show("Usuario agregado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Botón Editar ---

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un usuario de la lista para editar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposObligatorios(requiereContrasena: false)) return;

            // Si escribió contraseña, validar que coincidan
            bool cambiarContrasena = !string.IsNullOrWhiteSpace(txtContrasena.Text);
            if (cambiarContrasena && !ValidarContrasenas()) return;

            try
            {
                var usuario = new UserEntity
                {
                    Id = Convert.ToInt32(txtId.Text),
                    NombreCompleto = txtNombreCompleto.Text.Trim(),
                    NombreUsuario = txtNombreUsuario.Text.Trim(),
                    IdRol = cmbRol.SelectedIndex + 1,
                    Activo = chkActivo.Checked
                };

                _dataAccess.ActualizarUsuario(usuario);

                if (cambiarContrasena)
                    _dataAccess.CambiarContrasena(usuario.Id, txtContrasena.Text);

                MessageBox.Show("Usuario actualizado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Botón Desactivar ---

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un usuario de la lista para desactivar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombreCompleto.Text;
            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea desactivar al usuario '{nombre}'?",
                "Confirmar desactivación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                _dataAccess.DesactivarUsuario(Convert.ToInt32(txtId.Text));

                MessageBox.Show("Usuario desactivado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desactivar usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Validaciones ---

        private bool ValidarCamposObligatorios(bool requiereContrasena)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El nombre completo es obligatorio.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (requiereContrasena && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para crear un usuario.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarContrasenas()
        {
            if (txtContrasena.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmar.Clear();
                txtConfirmar.Focus();
                return false;
            }

            if (txtContrasena.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            return true;
        }
    }
}