namespace InventoryApp
{
    partial class LoginForm
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
            btnEntrar = new Button();
            ChkBRecordar = new CheckBox();
            lblUsuario = new Label();
            lblContraseña = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(480, 320);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(159, 34);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // ChkBRecordar
            // 
            ChkBRecordar.AutoSize = true;
            ChkBRecordar.Location = new Point(257, 324);
            ChkBRecordar.Name = "ChkBRecordar";
            ChkBRecordar.Size = new Size(135, 29);
            ChkBRecordar.TabIndex = 2;
            ChkBRecordar.Text = "Recuerdame";
            ChkBRecordar.UseVisualStyleBackColor = true;
            ChkBRecordar.CheckedChanged += ChkBRecordar_CheckedChanged;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(118, 141);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(72, 25);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(118, 244);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(101, 25);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(257, 138);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(382, 31);
            txtUsuario.TabIndex = 5;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(257, 241);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(382, 31);
            txtContraseña.TabIndex = 6;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.TextChanged += txtContraseña_TextChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 515);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(ChkBRecordar);
            Controls.Add(btnEntrar);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private CheckBox ChkBRecordar;
        private Label lblUsuario;
        private Label lblContraseña;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
    }
}