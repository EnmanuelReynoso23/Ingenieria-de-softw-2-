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
            clientesTitle.Location = new Point(30, 20);
            clientesTitle.Name = "clientesTitle";
            clientesTitle.Size = new Size(209, 30);
            clientesTitle.TabIndex = 14;
            clientesTitle.Text = "Gestión de clientes";
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(30, 401);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(250, 35);
            btnDeleteClient.TabIndex = 16;
            btnDeleteClient.Text = "Eliminar Cliente";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click_1;
            // 
            // btnEditClient
            // 
            btnEditClient.Location = new Point(30, 351);
            btnEditClient.Name = "btnEditClient";
            btnEditClient.Size = new Size(250, 35);
            btnEditClient.TabIndex = 17;
            btnEditClient.Text = "Editar Cliente";
            btnEditClient.UseVisualStyleBackColor = true;
            btnEditClient.Click += btnEditClient_Click_1;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(30, 301);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(250, 35);
            btnAddClient.TabIndex = 18;
            btnAddClient.Text = "Agregar Cliente";
            btnAddClient.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(127, 116);
            txtName.Name = "txtName";
            txtName.Size = new Size(154, 23);
            txtName.TabIndex = 25;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 118);
            lblName.Name = "lblName";
            lblName.Size = new Size(54, 15);
            lblName.TabIndex = 26;
            lblName.Text = "Nombre:";
            lblName.Click += lblName_Click;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(127, 67);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(154, 23);
            txtCode.TabIndex = 27;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(30, 70);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(49, 15);
            lblCode.TabIndex = 28;
            lblCode.Text = "Código:";
            lblCode.Click += lblCode_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(308, 70);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 62;
            dgvInventory.Size = new Size(650, 450);
            dgvInventory.TabIndex = 15;
            dgvInventory.CellContentClick += dgvInventory_CellContentClick;
            // 
            // textBoxRNC
            // 
            textBoxRNC.Location = new Point(127, 163);
            textBoxRNC.Name = "textBoxRNC";
            textBoxRNC.Size = new Size(154, 23);
            textBoxRNC.TabIndex = 29;
            textBoxRNC.TextChanged += textBoxRNC_TextChanged;
            // 
            // labelRNC
            // 
            labelRNC.AutoSize = true;
            labelRNC.Location = new Point(30, 166);
            labelRNC.Name = "labelRNC";
            labelRNC.Size = new Size(76, 15);
            labelRNC.TabIndex = 30;
            labelRNC.Text = "RNC/Cédula:";
            labelRNC.Click += labelRNC_Click;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(127, 209);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(154, 23);
            textBoxPhone.TabIndex = 31;
            textBoxPhone.TextChanged += textBoxPhone_TextChanged;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(30, 211);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(56, 15);
            labelPhone.TabIndex = 32;
            labelPhone.Text = "Teléfono:";
            labelPhone.Click += labelPhone_Click;
            // 
            // clientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
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
