namespace InventoryApp
{
    partial class clientesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clientesTitle = new Label();
            btnDeleteClient = new Button();
            btnEditClient = new Button();
            btnAddClient = new Button();
            txtName = new TextBox();
            lblName = new Label();
            txtCode = new TextBox();
            lblCode = new Label();
            dgvInventory = new DataGridView();
            textBoxRNC = new TextBox();
            labelRNC = new Label();
            textBoxPhone = new TextBox();
            labelPhone = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // clientesTitle
            // 
            clientesTitle.AutoSize = true;
            clientesTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            clientesTitle.Location = new Point(43, 33);
            clientesTitle.Margin = new Padding(4, 0, 4, 0);
            clientesTitle.Name = "clientesTitle";
            clientesTitle.Size = new Size(301, 45);
            clientesTitle.TabIndex = 14;
            clientesTitle.Text = "Gestión de clientes";
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(43, 668);
            btnDeleteClient.Margin = new Padding(4, 5, 4, 5);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(357, 58);
            btnDeleteClient.TabIndex = 16;
            btnDeleteClient.Text = "Eliminar Cliente";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click_1;
            // 
            // btnEditClient
            // 
            btnEditClient.Location = new Point(43, 585);
            btnEditClient.Margin = new Padding(4, 5, 4, 5);
            btnEditClient.Name = "btnEditClient";
            btnEditClient.Size = new Size(357, 58);
            btnEditClient.TabIndex = 17;
            btnEditClient.Text = "Editar Cliente";
            btnEditClient.UseVisualStyleBackColor = true;
            btnEditClient.Click += btnEditClient_Click_1;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(43, 502);
            btnAddClient.Margin = new Padding(4, 5, 4, 5);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(357, 58);
            btnAddClient.TabIndex = 18;
            btnAddClient.Text = "Agregar Cliente";
            btnAddClient.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(182, 193);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(218, 31);
            txtName.TabIndex = 25;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(43, 196);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(82, 25);
            lblName.TabIndex = 26;
            lblName.Text = "Nombre:";
            lblName.Click += lblName_Click;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(182, 112);
            txtCode.Margin = new Padding(4, 5, 4, 5);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(218, 31);
            txtCode.TabIndex = 27;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(43, 117);
            lblCode.Margin = new Padding(4, 0, 4, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(75, 25);
            lblCode.TabIndex = 28;
            lblCode.Text = "Código:";
            lblCode.Click += lblCode_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(440, 117);
            dgvInventory.Margin = new Padding(4, 5, 4, 5);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 62;
            dgvInventory.Size = new Size(929, 750);
            dgvInventory.TabIndex = 15;
            dgvInventory.CellContentClick += dgvInventory_CellContentClick;
            // 
            // textBoxRNC
            // 
            textBoxRNC.Location = new Point(182, 271);
            textBoxRNC.Margin = new Padding(4, 5, 4, 5);
            textBoxRNC.Name = "textBoxRNC";
            textBoxRNC.Size = new Size(218, 31);
            textBoxRNC.TabIndex = 29;
            textBoxRNC.TextChanged += textBoxRNC_TextChanged;
            // 
            // labelRNC
            // 
            labelRNC.AutoSize = true;
            labelRNC.Location = new Point(43, 277);
            labelRNC.Margin = new Padding(4, 0, 4, 0);
            labelRNC.Name = "labelRNC";
            labelRNC.Size = new Size(112, 25);
            labelRNC.TabIndex = 30;
            labelRNC.Text = "RNC/Cédula:";
            labelRNC.Click += labelRNC_Click;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(182, 348);
            textBoxPhone.Margin = new Padding(4, 5, 4, 5);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(218, 31);
            textBoxPhone.TabIndex = 31;
            textBoxPhone.TextChanged += textBoxPhone_TextChanged;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(43, 351);
            labelPhone.Margin = new Padding(4, 0, 4, 0);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(83, 25);
            labelPhone.TabIndex = 32;
            labelPhone.Text = "Teléfono:";
            labelPhone.Click += labelPhone_Click;
            // 
            // clientesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 935);
            Controls.Add(textBoxPhone);
            Controls.Add(labelPhone);
            Controls.Add(textBoxRNC);
            Controls.Add(labelRNC);
            Controls.Add(clientesTitle);
            Controls.Add(btnDeleteClient);
            Controls.Add(btnEditClient);
            Controls.Add(btnAddClient);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtCode);
            Controls.Add(lblCode);
            Controls.Add(dgvInventory);
            Margin = new Padding(4, 5, 4, 5);
            Name = "clientesForm";
            Text = "Gestión de Clientes";
            Load += clientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label clientesTitle;
        private Button btnDeleteClient;
        private Button btnEditClient;
        private Button btnAddClient;
        private TextBox txtStock;
        private Label lblStock;
        private TextBox txtPrice;
        private Label lblPrice;
        private TextBox txtCategory;
        private Label lblCategory;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtCode;
        private Label lblCode;
        private DataGridView dgvInventory;
        private TextBox textBoxRNC;
        private Label labelRNC;
        private TextBox textBoxPhone;
        private Label labelPhone;
    }
}        
