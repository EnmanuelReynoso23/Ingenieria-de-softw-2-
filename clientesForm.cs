using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryApp.DB;      // Espacio de nombres de tu clase DataAccess
using InventoryApp.Models;  // Espacio de nombres de tu modelo Client

namespace InventoryApp
{
    public partial class clientesForm : Form
    {
        // 1. Instanciamos tu clase de acceso a datos
        private DataAccess dataAccess = new DataAccess();

        public clientesForm()
        {
            InitializeComponent();

            // Bloqueamos el campo del Código para que el usuario no lo edite manualmente (el ID lo da la base de datos)
            txtCode.ReadOnly = true;

            // 2. Vinculamos los botones a sus respectivos eventos de clic
            this.btnAddClient.Click += new EventHandler(this.btnAddClient_Click);
            //this.btnEditClient.Click += new EventHandler(this.btnEditClient_Click);
            //this.btnDeleteClient.Click += new EventHandler(this.btnDeleteClient_Click);

            // Vinculamos el clic en la tabla para pasar los datos a los TextBox
            this.dgvInventory.CellClick += new DataGridViewCellEventHandler(this.dgvInventory_CellClick);
        }

        private void clientesForm_Load(object sender, EventArgs e)
        {
            // Cargar los clientes en el DataGridView al abrir el formulario
            CargarClientes();
        }

        // Método auxiliar para refrescar la tabla
        private void CargarClientes()
        {
            try
            {
                List<Client> clientes = dataAccess.ListarClientes();
                dgvInventory.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para limpiar las cajas de texto
        private void LimpiarCampos()
        {
            txtCode.Clear();
            txtName.Clear();
            textBoxRNC.Clear();
            textBoxPhone.Clear();
        }

        // --- FUNCIONALIDAD DE LOS BOTONES ---

        // Botón Agregar Cliente
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("El nombre del cliente es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Armar el objeto Cliente con los datos del formulario
                Client nuevoCliente = new Client
                {
                    Name = txtName.Text.Trim(),
                    Rnc = textBoxRNC.Text.Trim(),
                    Phone = textBoxPhone.Text.Trim()
                };

                // Enviar a la base de datos
                dataAccess.AgregarCliente(nuevoCliente);

                MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarClientes(); // Refrescar la tabla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Botón Editar Cliente
        private void btnEditClient_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Por favor, seleccione un cliente de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Client clienteEditado = new Client
                {
                    Id = Convert.ToInt32(txtCode.Text),
                    Name = txtName.Text.Trim(),
                    Rnc = textBoxRNC.Text.Trim(),
                    Phone = textBoxPhone.Text.Trim()
                };

                dataAccess.ActualizarCliente(clienteEditado);

                MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Botón Eliminar Cliente
        private void btnDeleteClient_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                {
                    MessageBox.Show("Por favor, seleccione un cliente de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    int idCliente = Convert.ToInt32(txtCode.Text);
                    dataAccess.EliminarCliente(idCliente);

                    MessageBox.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- SELECCIONAR DATOS DE LA TABLA ---

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar errores si se hace clic en los encabezados de las columnas (RowIndex = -1)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaMapeada = dgvInventory.Rows[e.RowIndex];

                // Llenar los TextBox con los datos de la fila seleccionada
                // Asegúrate de que los nombres en el índice correspondan a las propiedades de tu clase 'Client'
                txtCode.Text = filaMapeada.Cells["Id"].Value?.ToString();
                txtName.Text = filaMapeada.Cells["Name"].Value?.ToString();
                textBoxRNC.Text = filaMapeada.Cells["Rnc"].Value?.ToString();
                textBoxPhone.Text = filaMapeada.Cells["Phone"].Value?.ToString();
            }
        }

        // --- EVENTOS DE DISEÑO VACÍOS (Mantenidos para no romper tu Designer) ---
        private void labelRNC_Click(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void labelPhone_Click(object sender, EventArgs e) { }
        private void textBoxPhone_TextChanged(object sender, EventArgs e) { }
        private void textBoxRNC_TextChanged(object sender, EventArgs e) { }
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblCode_Click(object sender, EventArgs e) { }


    }
}