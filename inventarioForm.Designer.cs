namespace InventoryApp;

partial class inventarioForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms
    private void InitializeComponent()
    {
        dgvInventory = new DataGridView();
        lblCode = new Label();
        txtCode = new TextBox();
        lblName = new Label();
        txtName = new TextBox();
        lblCategory = new Label();
        txtCategory = new TextBox();
        lblPrice = new Label();
        txtPrice = new TextBox();
        lblStock = new Label();
        txtStock = new TextBox();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        lblTitle = new Label();
        ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
        SuspendLayout();
        // 
        // dgvInventory
        // 
        dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvInventory.Location = new Point(440, 117);
        dgvInventory.Margin = new Padding(4, 5, 4, 5);
        dgvInventory.Name = "dgvInventory";
        dgvInventory.RowHeadersWidth = 62;
        dgvInventory.RowTemplate.Height = 25;
        dgvInventory.Size = new Size(929, 750);
        dgvInventory.TabIndex = 0;
        // 
        // lblCode
        // 
        lblCode.AutoSize = true;
        lblCode.Location = new Point(43, 115);
        lblCode.Margin = new Padding(4, 0, 4, 0);
        lblCode.Name = "lblCode";
        lblCode.Size = new Size(75, 25);
        lblCode.TabIndex = 13;
        lblCode.Text = "Código:";
        // 
        // txtCode
        // 
        txtCode.Location = new Point(143, 112);
        txtCode.Margin = new Padding(4, 5, 4, 5);
        txtCode.Name = "txtCode";
        txtCode.Size = new Size(255, 31);
        txtCode.TabIndex = 12;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(43, 192);
        lblName.Margin = new Padding(4, 0, 4, 0);
        lblName.Name = "lblName";
        lblName.Size = new Size(82, 25);
        lblName.TabIndex = 11;
        lblName.Text = "Nombre:";
        // 
        // txtName
        // 
        txtName.Location = new Point(143, 187);
        txtName.Margin = new Padding(4, 5, 4, 5);
        txtName.Name = "txtName";
        txtName.Size = new Size(255, 31);
        txtName.TabIndex = 10;
        // 
        // lblCategory
        // 
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(43, 267);
        lblCategory.Margin = new Padding(4, 0, 4, 0);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(92, 25);
        lblCategory.TabIndex = 9;
        lblCategory.Text = "Categoría:";
        // 
        // txtCategory
        // 
        txtCategory.Location = new Point(143, 262);
        txtCategory.Margin = new Padding(4, 5, 4, 5);
        txtCategory.Name = "txtCategory";
        txtCategory.Size = new Size(255, 31);
        txtCategory.TabIndex = 8;
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(43, 342);
        lblPrice.Margin = new Padding(4, 0, 4, 0);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(64, 25);
        lblPrice.TabIndex = 7;
        lblPrice.Text = "Precio:";
        // 
        // txtPrice
        // 
        txtPrice.Location = new Point(143, 337);
        txtPrice.Margin = new Padding(4, 5, 4, 5);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(255, 31);
        txtPrice.TabIndex = 6;
        // 
        // lblStock
        // 
        lblStock.AutoSize = true;
        lblStock.Location = new Point(43, 417);
        lblStock.Margin = new Padding(4, 0, 4, 0);
        lblStock.Name = "lblStock";
        lblStock.Size = new Size(59, 25);
        lblStock.TabIndex = 5;
        lblStock.Text = "Stock:";
        // 
        // txtStock
        // 
        txtStock.Location = new Point(143, 412);
        txtStock.Margin = new Padding(4, 5, 4, 5);
        txtStock.Name = "txtStock";
        txtStock.Size = new Size(255, 31);
        txtStock.TabIndex = 4;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(43, 508);
        btnAdd.Margin = new Padding(4, 5, 4, 5);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(357, 58);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Agregar al Inventario";
        btnAdd.UseVisualStyleBackColor = true;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(43, 592);
        btnEdit.Margin = new Padding(4, 5, 4, 5);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(357, 58);
        btnEdit.TabIndex = 2;
        btnEdit.Text = "Editar Artículo";
        btnEdit.UseVisualStyleBackColor = true;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(43, 675);
        btnDelete.Margin = new Padding(4, 5, 4, 5);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(357, 58);
        btnDelete.TabIndex = 1;
        btnDelete.Text = "Eliminar Artículo";
        btnDelete.UseVisualStyleBackColor = true;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(43, 33);
        lblTitle.Margin = new Padding(4, 0, 4, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(342, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Gestión de Inventario";
        // 
        // inventarioForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1406, 935);
        Controls.Add(lblTitle);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(txtStock);
        Controls.Add(lblStock);
        Controls.Add(txtPrice);
        Controls.Add(lblPrice);
        Controls.Add(txtCategory);
        Controls.Add(lblCategory);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(txtCode);
        Controls.Add(lblCode);
        Controls.Add(dgvInventory);
        Margin = new Padding(4, 5, 4, 5);
        Name = "inventarioForm";
        Text = "Sistema de Inventario";
        ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private System.Windows.Forms.DataGridView dgvInventory;
    private System.Windows.Forms.Label lblCode;
    private System.Windows.Forms.TextBox txtCode;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.TextBox txtCategory;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.TextBox txtPrice;
    private System.Windows.Forms.Label lblStock;
    private System.Windows.Forms.TextBox txtStock;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Label lblTitle;
}
