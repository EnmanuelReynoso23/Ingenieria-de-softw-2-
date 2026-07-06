namespace InventoryApp;

public partial class inventarioForm : Form
{
    public inventarioForm()
    {
        InitializeComponent();
        SetupDataGridView();
    }

    private void SetupDataGridView()
    {
        dgvInventory.ColumnCount = 5;
        dgvInventory.Columns[0].Name = "Código";
        dgvInventory.Columns[1].Name = "Nombre";
        dgvInventory.Columns[2].Name = "Categoría";
        dgvInventory.Columns[3].Name = "Precio";
        dgvInventory.Columns[4].Name = "Stock";

        // Estilos 
        dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvInventory.MultiSelect = false;
        dgvInventory.AllowUserToAddRows = false;

       
    }
}
