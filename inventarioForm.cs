using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using InventoryApp.DB;
using InventoryApp.Models;

namespace InventoryApp
{
    public partial class inventarioForm : Form
    {
        private readonly DataAccess dataAccess = new DataAccess();
        private int _idSeleccionado = 0;

        public inventarioForm()
        {
            InitializeComponent();
            SetupDataGridView();

            // Bloqueamos la caja de código porque el ID se genera solo en la BD
            txtCode.ReadOnly = true;

            this.Load += InventarioForm_Load;
            this.btnAdd.Click += BtnAdd_Click;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.dgvInventory.CellClick += DgvInventory_CellClick;
        }

        private void InventarioForm_Load(object? sender, EventArgs e)
        {
            CargarInventario();
        }

        private void SetupDataGridView()
        {
            dgvInventory.AutoGenerateColumns = true;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.ReadOnly = true;
        }

        private void CargarInventario()
        {
            try
            {
                List<Product> productos = dataAccess.ListarInventario();
                dgvInventory.DataSource = productos;
                RenombrarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenombrarColumnas()
        {
            // Ponemos visible la columna Id y le cambiamos el nombre a "Código" visualmente
            if (dgvInventory.Columns["Id"] != null)
            {
                dgvInventory.Columns["Id"].Visible = true;
                dgvInventory.Columns["Id"].HeaderText = "Código (ID)";
            }

            if (dgvInventory.Columns["Name"] != null) dgvInventory.Columns["Name"].HeaderText = "Nombre";
            if (dgvInventory.Columns["Price"] != null) dgvInventory.Columns["Price"].HeaderText = "Precio";
            if (dgvInventory.Columns["Stock"] != null) dgvInventory.Columns["Stock"].HeaderText = "Stock";
            if (dgvInventory.Columns["Date"] != null) dgvInventory.Columns["Date"].HeaderText = "Fecha de Registro";
        }

        private void DgvInventory_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvInventory.Rows[e.RowIndex];

            _idSeleccionado = fila.Cells["Id"].Value != null ? Convert.ToInt32(fila.Cells["Id"].Value) : 0;

            // Mostramos el ID en el TextBox del código
            txtCode.Text = _idSeleccionado.ToString();
            txtName.Text = fila.Cells["Name"].Value?.ToString();
            txtPrice.Text = fila.Cells["Price"].Value != null
                ? Convert.ToDecimal(fila.Cells["Price"].Value).ToString("0.00", CultureInfo.InvariantCulture)
                : string.Empty;
            txtStock.Text = fila.Cells["Stock"].Value?.ToString();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos(out decimal precio, out int stock)) return;

            try
            {
                // Validación para que no metan dos artículos con el mismo nombre exacto
                if (dataAccess.ExisteNombreProducto(txtName.Text.Trim(), 0))
                {
                    MessageBox.Show("Ya existe un artículo con ese nombre.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                Product nuevoProducto = new Product
                {
                    // No mandamos el Id/Código porque se asigna solo en PostgreSQL
                    Name = txtName.Text.Trim(),
                    Price = precio,
                    Stock = stock
                };

                dataAccess.AgregarProducto(nuevoProducto);

                MessageBox.Show("Artículo agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (_idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un artículo de la lista para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos(out decimal precio, out int stock)) return;

            try
            {
                if (dataAccess.ExisteNombreProducto(txtName.Text.Trim(), _idSeleccionado))
                {
                    MessageBox.Show("Ya existe otro artículo con ese nombre.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                Product productoEditado = new Product
                {
                    Id = _idSeleccionado,
                    Name = txtName.Text.Trim(),
                    Price = precio,
                    Stock = stock
                };

                dataAccess.ActualizarProducto(productoEditado);

                MessageBox.Show("Artículo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un artículo de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el artículo \"{txtName.Text}\"?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                dataAccess.EliminarProducto(_idSeleccionado);

                MessageBox.Show("Artículo eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos(out decimal precio, out int stock)
        {
            precio = 0;
            stock = 0;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precio))
            {
                MessageBox.Show("El precio ingresado no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("El stock ingresado no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtCode.Clear();
            txtName.Clear();
            // txtCategory.Clear(); <-- Borrar o comentar si ya lo eliminaste del form
            txtPrice.Clear();
            txtStock.Clear();
            _idSeleccionado = 0;
        }
    }
}