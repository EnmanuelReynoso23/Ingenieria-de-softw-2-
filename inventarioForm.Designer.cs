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
        dgvInventory.Location = new Point(308, 70);
        dgvInventory.Name = "dgvInventory";
        dgvInventory.RowHeadersWidth = 62;
        dgvInventory.Size = new Size(650, 450);
        dgvInventory.TabIndex = 0;
        // 
        // lblCode
        // 
        lblCode.AutoSize = true;
        lblCode.Location = new Point(30, 69);
        lblCode.Name = "lblCode";
        lblCode.Size = new Size(49, 15);
        lblCode.TabIndex = 13;
        lblCode.Text = "Código:";
        // 
        // txtCode
        // 
        txtCode.Location = new Point(100, 67);
        txtCode.Name = "txtCode";
        txtCode.Size = new Size(180, 23);
        txtCode.TabIndex = 12;
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.Location = new Point(30, 115);
        lblName.Name = "lblName";
        lblName.Size = new Size(54, 15);
        lblName.TabIndex = 11;
        lblName.Text = "Nombre:";
        // 
        // txtName
        // 
        txtName.Location = new Point(100, 112);
        txtName.Name = "txtName";
        txtName.Size = new Size(180, 23);
        txtName.TabIndex = 10;
        // 
        // lblPrice
        // 
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(30, 157);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(43, 15);
        lblPrice.TabIndex = 7;
        lblPrice.Text = "Precio:";
        // 
        // txtPrice
        // 
        txtPrice.Location = new Point(100, 154);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(180, 23);
        txtPrice.TabIndex = 6;
        // 
        // lblStock
        // 
        lblStock.AutoSize = true;
        lblStock.Location = new Point(30, 202);
        lblStock.Name = "lblStock";
        lblStock.Size = new Size(39, 15);
        lblStock.TabIndex = 5;
        lblStock.Text = "Stock:";
        // 
        // txtStock
        // 
        txtStock.Location = new Point(100, 199);
        txtStock.Name = "txtStock";
        txtStock.Size = new Size(180, 23);
        txtStock.TabIndex = 4;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(30, 384);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(250, 35);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Agregar al Inventario";
        btnAdd.UseVisualStyleBackColor = true;
        // 
        // btnEdit
        // 
        btnEdit.Location = new Point(30, 434);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(250, 35);
        btnEdit.TabIndex = 2;
        btnEdit.Text = "Editar Artículo";
        btnEdit.UseVisualStyleBackColor = true;
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(30, 484);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(250, 35);
        btnDelete.TabIndex = 1;
        btnDelete.Text = "Eliminar Artículo";
        btnDelete.UseVisualStyleBackColor = true;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(236, 30);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Gestión de Inventario";
        // 
        // inventarioForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 561);
        Controls.Add(lblTitle);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(btnAdd);
        Controls.Add(txtStock);
        Controls.Add(lblStock);
        Controls.Add(txtPrice);
        Controls.Add(lblPrice);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(txtCode);
        Controls.Add(lblCode);
        Controls.Add(dgvInventory);
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
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.TextBox txtPrice;
    private System.Windows.Forms.Label lblStock;
    private System.Windows.Forms.TextBox txtStock;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Label lblTitle;
}
