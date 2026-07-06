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
        this.dgvInventory = new System.Windows.Forms.DataGridView();
        this.lblCode = new System.Windows.Forms.Label();
        this.txtCode = new System.Windows.Forms.TextBox();
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.lblCategory = new System.Windows.Forms.Label();
        this.txtCategory = new System.Windows.Forms.TextBox();
        this.lblPrice = new System.Windows.Forms.Label();
        this.txtPrice = new System.Windows.Forms.TextBox();
        this.lblStock = new System.Windows.Forms.Label();
        this.txtStock = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnEdit = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.lblTitle = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
        this.SuspendLayout();
        
        this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvInventory.Location = new System.Drawing.Point(308, 70);
        this.dgvInventory.Name = "dgvInventory";
        this.dgvInventory.RowTemplate.Height = 25;
        this.dgvInventory.Size = new System.Drawing.Size(650, 450);
        this.dgvInventory.TabIndex = 0;
        
        this.lblCode.AutoSize = true;
        this.lblCode.Location = new System.Drawing.Point(30, 70);
        this.lblCode.Name = "lblCode";
        this.lblCode.Size = new System.Drawing.Size(49, 15);
        this.lblCode.Text = "Código:";
        
        this.txtCode.Location = new System.Drawing.Point(100, 67);
        this.txtCode.Name = "txtCode";
        this.txtCode.Size = new System.Drawing.Size(180, 23);
        
        this.lblName.AutoSize = true;
        this.lblName.Location = new System.Drawing.Point(30, 115);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(54, 15);
        this.lblName.Text = "Nombre:";
        
        this.txtName.Location = new System.Drawing.Point(100, 112);
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(180, 23);
        
        this.lblCategory.AutoSize = true;
        this.lblCategory.Location = new System.Drawing.Point(30, 160);
        this.lblCategory.Name = "lblCategory";
        this.lblCategory.Size = new System.Drawing.Size(61, 15);
        this.lblCategory.Text = "Categoría:";
        
        this.txtCategory.Location = new System.Drawing.Point(100, 157);
        this.txtCategory.Name = "txtCategory";
        this.txtCategory.Size = new System.Drawing.Size(180, 23);
        
        this.lblPrice.AutoSize = true;
        this.lblPrice.Location = new System.Drawing.Point(30, 205);
        this.lblPrice.Name = "lblPrice";
        this.lblPrice.Size = new System.Drawing.Size(43, 15);
        this.lblPrice.Text = "Precio:";
        
        this.txtPrice.Location = new System.Drawing.Point(100, 202);
        this.txtPrice.Name = "txtPrice";
        this.txtPrice.Size = new System.Drawing.Size(180, 23);
        
        this.lblStock.AutoSize = true;
        this.lblStock.Location = new System.Drawing.Point(30, 250);
        this.lblStock.Name = "lblStock";
        this.lblStock.Size = new System.Drawing.Size(39, 15);
        this.lblStock.Text = "Stock:";
        
        this.txtStock.Location = new System.Drawing.Point(100, 247);
        this.txtStock.Name = "txtStock";
        this.txtStock.Size = new System.Drawing.Size(180, 23);
        
        this.btnAdd.Location = new System.Drawing.Point(30, 305);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(250, 35);
        this.btnAdd.Text = "Agregar al Inventario";
        this.btnAdd.UseVisualStyleBackColor = true;
        
        this.btnEdit.Location = new System.Drawing.Point(30, 355);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(250, 35);
        this.btnEdit.Text = "Editar Artículo";
        this.btnEdit.UseVisualStyleBackColor = true;
        
        this.btnDelete.Location = new System.Drawing.Point(30, 405);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(250, 35);
        this.btnDelete.Text = "Eliminar Artículo";
        this.btnDelete.UseVisualStyleBackColor = true;
        
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(30, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(248, 30);
        this.lblTitle.Text = "Gestión de Inventario";
        
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(984, 561);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.txtStock);
        this.Controls.Add(this.lblStock);
        this.Controls.Add(this.txtPrice);
        this.Controls.Add(this.lblPrice);
        this.Controls.Add(this.txtCategory);
        this.Controls.Add(this.lblCategory);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblName);
        this.Controls.Add(this.txtCode);
        this.Controls.Add(this.lblCode);
        this.Controls.Add(this.dgvInventory);
        this.Name = "Form1";
        this.Text = "Sistema de Inventario";
        ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
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
