using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Npgsql;
using InventoryApp.DB;

namespace InventoryApp;

public partial class inventarioForm : Form
{
   
    private readonly ConexionDB dbConn = new ConexionDB();


    private int _idSeleccionado = 0;

    public inventarioForm()
    {
        InitializeComponent();
        SetupDataGridView();

       
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
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT id_producto AS Id, codigo AS Codigo, nombre AS Nombre,
                                      categoria AS Categoria, precio AS Precio, stock AS Stock,
                                      fecha_registro AS FechaRegistro
                               FROM productos
                               ORDER BY id_producto ASC";

                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    var tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvInventory.DataSource = tabla;
                }
            }

            if (dgvInventory.Columns["Id"] != null)
                dgvInventory.Columns["Id"].Visible = false;

            RenombrarColumnas();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RenombrarColumnas()
    {
        if (dgvInventory.Columns["Codigo"] != null) dgvInventory.Columns["Codigo"].HeaderText = "Código";
        if (dgvInventory.Columns["Nombre"] != null) dgvInventory.Columns["Nombre"].HeaderText = "Nombre";
        if (dgvInventory.Columns["Categoria"] != null) dgvInventory.Columns["Categoria"].HeaderText = "Categoría";
        if (dgvInventory.Columns["Precio"] != null) dgvInventory.Columns["Precio"].HeaderText = "Precio";
        if (dgvInventory.Columns["Stock"] != null) dgvInventory.Columns["Stock"].HeaderText = "Stock";
        if (dgvInventory.Columns["FechaRegistro"] != null) dgvInventory.Columns["FechaRegistro"].HeaderText = "Fecha de Registro";
    }

 

    private void DgvInventory_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        DataGridViewRow fila = dgvInventory.Rows[e.RowIndex];

        _idSeleccionado = fila.Cells["Id"].Value != null
            ? Convert.ToInt32(fila.Cells["Id"].Value)
            : 0;

        txtCode.Text = fila.Cells["Codigo"].Value?.ToString();
        txtName.Text = fila.Cells["Nombre"].Value?.ToString();
        txtCategory.Text = fila.Cells["Categoria"].Value?.ToString();
        txtPrice.Text = fila.Cells["Precio"].Value != null
            ? Convert.ToDecimal(fila.Cells["Precio"].Value).ToString("0.00", CultureInfo.InvariantCulture)
            : string.Empty;
        txtStock.Text = fila.Cells["Stock"].Value?.ToString();
    }



    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        if (!ValidarCampos(out decimal precio, out int stock)) return;

        try
        {
            if (ExisteCodigo(txtCode.Text.Trim(), 0))
            {
                MessageBox.Show("Ya existe un artículo con ese código.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO productos (codigo, nombre, categoria, precio, stock)
                               VALUES (@codigo, @nombre, @categoria, @precio, @stock)";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("codigo", txtCode.Text.Trim());
                    cmd.Parameters.AddWithValue("nombre", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("categoria", (object?)txtCategory.Text.Trim() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("precio", precio);
                    cmd.Parameters.AddWithValue("stock", stock);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Artículo agregado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarInventario();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al agregar el artículo: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

   

    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado <= 0)
        {
            MessageBox.Show("Seleccione un artículo de la lista para editar.", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidarCampos(out decimal precio, out int stock)) return;

        try
        {
            if (ExisteCodigo(txtCode.Text.Trim(), _idSeleccionado))
            {
                MessageBox.Show("Ya existe otro artículo con ese código.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return;
            }

            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE productos
                               SET codigo = @codigo, nombre = @nombre, categoria = @categoria,
                                   precio = @precio, stock = @stock
                               WHERE id_producto = @id";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", _idSeleccionado);
                    cmd.Parameters.AddWithValue("codigo", txtCode.Text.Trim());
                    cmd.Parameters.AddWithValue("nombre", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("categoria", (object?)txtCategory.Text.Trim() ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("precio", precio);
                    cmd.Parameters.AddWithValue("stock", stock);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Artículo actualizado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarInventario();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al actualizar el artículo: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    

    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (_idSeleccionado <= 0)
        {
            MessageBox.Show("Seleccione un artículo de la lista para eliminar.", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult confirmacion = MessageBox.Show(
            $"¿Está seguro de que desea eliminar el artículo \"{txtName.Text}\"?",
            "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirmacion != DialogResult.Yes) return;

        try
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM productos WHERE id_producto = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", _idSeleccionado);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Artículo eliminado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarInventario();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al eliminar el artículo: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

