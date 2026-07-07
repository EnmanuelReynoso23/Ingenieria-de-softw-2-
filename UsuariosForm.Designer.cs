namespace InventoryApp
{
    partial class UsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            UsuariosTitle = new Label();
            lblId = new Label();
            txtId = new TextBox();
            lblNombreCompleto = new Label();
            txtNombreCompleto = new TextBox();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            lblRol = new Label();
            cmbRol = new ComboBox();
            lblActivo = new Label();
            chkActivo = new CheckBox();
            btnAddUser = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            dgvInventory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // UsuariosTitle
            // 
            UsuariosTitle.AutoSize = true;
            UsuariosTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            UsuariosTitle.Location = new Point(43, 33);
            UsuariosTitle.Margin = new Padding(4, 0, 4, 0);
            UsuariosTitle.Name = "UsuariosTitle";
            UsuariosTitle.Size = new Size(318, 45);
            UsuariosTitle.TabIndex = 0;
            UsuariosTitle.Text = "Gestión de Usuarios";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(43, 120);
            lblId.Margin = new Padding(4, 0, 4, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(34, 25);
            lblId.TabIndex = 1;
            lblId.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Location = new Point(241, 117);
            txtId.Margin = new Padding(4, 5, 4, 5);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(218, 31);
            txtId.TabIndex = 2;
            // 
            // lblNombreCompleto
            // 
            lblNombreCompleto.AutoSize = true;
            lblNombreCompleto.Location = new Point(43, 199);
            lblNombreCompleto.Margin = new Padding(4, 0, 4, 0);
            lblNombreCompleto.Name = "lblNombreCompleto";
            lblNombreCompleto.Size = new Size(166, 25);
            lblNombreCompleto.TabIndex = 3;
            lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(241, 196);
            txtNombreCompleto.Margin = new Padding(4, 5, 4, 5);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(218, 31);
            txtNombreCompleto.TabIndex = 4;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(43, 274);
            lblNombreUsuario.Margin = new Padding(4, 0, 4, 0);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(147, 25);
            lblNombreUsuario.TabIndex = 5;
            lblNombreUsuario.Text = "Nombre Usuario:";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(241, 271);
            txtNombreUsuario.Margin = new Padding(4, 5, 4, 5);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(218, 31);
            txtNombreUsuario.TabIndex = 6;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(43, 351);
            lblContrasena.Margin = new Padding(4, 0, 4, 0);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(105, 25);
            lblContrasena.TabIndex = 7;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(241, 348);
            txtContrasena.Margin = new Padding(4, 5, 4, 5);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(218, 31);
            txtContrasena.TabIndex = 8;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(43, 425);
            lblConfirmar.Margin = new Padding(4, 0, 4, 0);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(189, 25);
            lblConfirmar.TabIndex = 9;
            lblConfirmar.Text = "Confirmar Contraseña:";
            // 
            // txtConfirmar
            // 
            txtConfirmar.Location = new Point(240, 422);
            txtConfirmar.Margin = new Padding(4, 5, 4, 5);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.PasswordChar = '*';
            txtConfirmar.Size = new Size(218, 31);
            txtConfirmar.TabIndex = 10;
            txtConfirmar.UseSystemPasswordChar = true;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(43, 502);
            lblRol.Margin = new Padding(4, 0, 4, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(41, 25);
            lblRol.TabIndex = 11;
            lblRol.Text = "Rol:";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Location = new Point(240, 499);
            cmbRol.Margin = new Padding(4, 5, 4, 5);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(218, 33);
            cmbRol.TabIndex = 12;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(43, 577);
            lblActivo.Margin = new Padding(4, 0, 4, 0);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(66, 25);
            lblActivo.TabIndex = 13;
            lblActivo.Text = "Activo:";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(240, 573);
            chkActivo.Margin = new Padding(4, 5, 4, 5);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(120, 29);
            chkActivo.TabIndex = 14;
            chkActivo.Text = "Habilitado";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(69, 651);
            btnAddUser.Margin = new Padding(4, 5, 4, 5);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(357, 58);
            btnAddUser.TabIndex = 15;
            btnAddUser.Text = "Agregar Usuario";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(69, 724);
            btnEditUser.Margin = new Padding(4, 5, 4, 5);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(357, 58);
            btnEditUser.TabIndex = 16;
            btnEditUser.Text = "Editar Usuario";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(69, 797);
            btnDeleteUser.Margin = new Padding(4, 5, 4, 5);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(357, 58);
            btnDeleteUser.TabIndex = 17;
            btnDeleteUser.Text = "Desactivar Usuario";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(488, 117);
            dgvInventory.Margin = new Padding(4, 5, 4, 5);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 62;
            dgvInventory.Size = new Size(905, 750);
            dgvInventory.TabIndex = 18;
            dgvInventory.CellClick += dgvInventory_CellClick;
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 935);
            Controls.Add(UsuariosTitle);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblNombreCompleto);
            Controls.Add(txtNombreCompleto);
            Controls.Add(lblNombreUsuario);
            Controls.Add(txtNombreUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(lblConfirmar);
            Controls.Add(txtConfirmar);
            Controls.Add(lblRol);
            Controls.Add(cmbRol);
            Controls.Add(lblActivo);
            Controls.Add(chkActivo);
            Controls.Add(btnAddUser);
            Controls.Add(btnEditUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(dgvInventory);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UsuariosForm";
            Text = "Gestión de Usuarios";
            Load += UsuariosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsuariosTitle;
        private Label lblId;
        private TextBox txtId;
        private Label lblNombreCompleto;
        private TextBox txtNombreCompleto;
        private Label lblNombreUsuario;
        private TextBox txtNombreUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Label lblConfirmar;
        private TextBox txtConfirmar;
        private Label lblRol;
        private ComboBox cmbRol;
        private Label lblActivo;
        private CheckBox chkActivo;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private DataGridView dgvInventory;
    }
}
