namespace InventoryApp
{
    partial class DashboardForm
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
            pnlSidebar = new Panel();
            btnUsuarios = new Button();
            btnFacturacion = new Button();
            btnInventario = new Button();
            btnClientes = new Button();
            pnlSeparador = new Panel();
            lblNombreUsuario = new Label();
            lblRolUsuario = new Label();
            btnCerrarSesion = new Button();
            pnlContenido = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.MistyRose;
            pnlSidebar.Controls.Add(btnUsuarios);
            pnlSidebar.Controls.Add(btnFacturacion);
            pnlSidebar.Controls.Add(btnInventario);
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(pnlSeparador);
            pnlSidebar.Controls.Add(lblNombreUsuario);
            pnlSidebar.Controls.Add(lblRolUsuario);
            pnlSidebar.Controls.Add(btnCerrarSesion);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(314, 944);
            pnlSidebar.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUsuarios.BackColor = Color.White;
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Popup;
            btnUsuarios.Font = new Font("Segoe UI", 10F);
            btnUsuarios.ForeColor = Color.Black;
            btnUsuarios.Location = new Point(10, 475);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(294, 84);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "👥  Usuarios";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += BtnUsuarios_Click;
            // 
            // btnFacturacion
            // 
            btnFacturacion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnFacturacion.BackColor = Color.White;
            btnFacturacion.Cursor = Cursors.Hand;
            btnFacturacion.FlatAppearance.BorderSize = 0;
            btnFacturacion.FlatStyle = FlatStyle.Popup;
            btnFacturacion.Font = new Font("Segoe UI", 10F);
            btnFacturacion.ForeColor = Color.Black;
            btnFacturacion.Location = new Point(10, 347);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(294, 84);
            btnFacturacion.TabIndex = 3;
            btnFacturacion.Text = "\U0001f9fe  Facturación";
            btnFacturacion.UseVisualStyleBackColor = false;
            btnFacturacion.Click += BtnFacturacion_Click;
            // 
            // btnInventario
            // 
            btnInventario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInventario.BackColor = Color.White;
            btnInventario.Cursor = Cursors.Hand;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatStyle = FlatStyle.Popup;
            btnInventario.Font = new Font("Segoe UI", 10F);
            btnInventario.ForeColor = Color.Black;
            btnInventario.Location = new Point(12, 91);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(292, 84);
            btnInventario.TabIndex = 1;
            btnInventario.Text = "📦  Inventario";
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += BtnInventario_Click;
            // 
            // btnClientes
            // 
            btnClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnClientes.BackColor = Color.White;
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Popup;
            btnClientes.Font = new Font("Segoe UI", 10F);
            btnClientes.ForeColor = Color.Black;
            btnClientes.Location = new Point(12, 219);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(292, 84);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "👤  Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += BtnClientes_Click;
            // 
            // pnlSeparador
            // 
            pnlSeparador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeparador.BackColor = Color.Maroon;
            pnlSeparador.Location = new Point(0, 832);
            pnlSeparador.Name = "pnlSeparador";
            pnlSeparador.Size = new Size(314, 10);
            pnlSeparador.TabIndex = 5;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNombreUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.Black;
            lblNombreUsuario.Location = new Point(10, 855);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(294, 28);
            lblNombreUsuario.TabIndex = 6;
            lblNombreUsuario.Text = "Nombre Usuario";
            lblNombreUsuario.Click += lblNombreUsuario_Click;
            // 
            // lblRolUsuario
            // 
            lblRolUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRolUsuario.Font = new Font("Segoe UI", 8.5F);
            lblRolUsuario.ForeColor = Color.Black;
            lblRolUsuario.Location = new Point(10, 898);
            lblRolUsuario.Name = "lblRolUsuario";
            lblRolUsuario.Size = new Size(294, 22);
            lblRolUsuario.TabIndex = 7;
            lblRolUsuario.Text = "Rol";
            lblRolUsuario.Click += lblRolUsuario_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.White;
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Popup;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F);
            btnCerrarSesion.ForeColor = Color.FromArgb(64, 0, 0);
            btnCerrarSesion.Location = new Point(10, 755);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(292, 64);
            btnCerrarSesion.TabIndex = 8;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.WhiteSmoke;
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(314, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(1470, 944);
            pnlContenido.TabIndex = 1;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1784, 944);
            Controls.Add(pnlContenido);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(900, 550);
            Name = "DashboardForm";
            Text = "Sistema de Inventario y Ventas";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlContenido;
        private Panel pnlSeparador;
        private Button btnInventario;
        private Button btnClientes;
        private Button btnFacturacion;
        private Button btnUsuarios;
        private Label lblNombreUsuario;
        private Label lblRolUsuario;
        private Button btnCerrarSesion;
    }
}
