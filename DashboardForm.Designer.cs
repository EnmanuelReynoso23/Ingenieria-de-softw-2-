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
            btnFacturacion = new Button();
            btnHistorialFacturas = new Button();
            btnUsuarios = new Button();
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
            pnlSidebar.Controls.Add(btnHistorialFacturas);
            pnlSidebar.Controls.Add(btnInventario);
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(pnlSeparador);
            pnlSidebar.Controls.Add(lblNombreUsuario);
            pnlSidebar.Controls.Add(lblRolUsuario);
            pnlSidebar.Controls.Add(btnCerrarSesion);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 566);
            pnlSidebar.TabIndex = 0;
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
            btnFacturacion.Location = new Point(7, 286);
            btnFacturacion.Margin = new Padding(2);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.Size = new Size(206, 50);
            btnFacturacion.TabIndex = 3;
            btnFacturacion.Text = "\U0001f9fe  Facturación";
            btnFacturacion.UseVisualStyleBackColor = false;
            btnFacturacion.Click += BtnFacturacion_Click;
            // 
            // btnHistorialFacturas
            // 
            btnHistorialFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnHistorialFacturas.BackColor = Color.White;
            btnHistorialFacturas.Cursor = Cursors.Hand;
            btnHistorialFacturas.FlatAppearance.BorderSize = 0;
            btnHistorialFacturas.FlatStyle = FlatStyle.Popup;
            btnHistorialFacturas.Font = new Font("Segoe UI", 10F);
            btnHistorialFacturas.ForeColor = Color.Black;
            btnHistorialFacturas.Location = new Point(7, 355);
            btnHistorialFacturas.Margin = new Padding(2);
            btnHistorialFacturas.Name = "btnHistorialFacturas";
            btnHistorialFacturas.Size = new Size(206, 50);
            btnHistorialFacturas.TabIndex = 5;
            btnHistorialFacturas.Text = "📄  Historial de Facturas";
            btnHistorialFacturas.UseVisualStyleBackColor = false;
            btnHistorialFacturas.Click += BtnHistorialFacturas_Click;
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
            btnUsuarios.Location = new Point(7, 209);
            btnUsuarios.Margin = new Padding(2);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(206, 50);
            btnUsuarios.TabIndex = 4;
            btnUsuarios.Text = "👥  Usuarios";
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += BtnUsuarios_Click;
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
            btnInventario.Location = new Point(8, 55);
            btnInventario.Margin = new Padding(2);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(204, 50);
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
            btnClientes.Location = new Point(8, 131);
            btnClientes.Margin = new Padding(2);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(204, 50);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "👤  Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += BtnClientes_Click;
            // 
            // pnlSeparador
            // 
            pnlSeparador.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeparador.BackColor = Color.Maroon;
            pnlSeparador.Location = new Point(0, 499);
            pnlSeparador.Margin = new Padding(2);
            pnlSeparador.Name = "pnlSeparador";
            pnlSeparador.Size = new Size(220, 6);
            pnlSeparador.TabIndex = 5;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNombreUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.Black;
            lblNombreUsuario.Location = new Point(7, 513);
            lblNombreUsuario.Margin = new Padding(2, 0, 2, 0);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(206, 17);
            lblNombreUsuario.TabIndex = 6;
            lblNombreUsuario.Text = "Nombre Usuario";
            lblNombreUsuario.Click += lblNombreUsuario_Click;
            // 
            // lblRolUsuario
            // 
            lblRolUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRolUsuario.Font = new Font("Segoe UI", 8.5F);
            lblRolUsuario.ForeColor = Color.Black;
            lblRolUsuario.Location = new Point(7, 539);
            lblRolUsuario.Margin = new Padding(2, 0, 2, 0);
            lblRolUsuario.Name = "lblRolUsuario";
            lblRolUsuario.Size = new Size(206, 13);
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
            btnCerrarSesion.Location = new Point(7, 453);
            btnCerrarSesion.Margin = new Padding(2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(204, 38);
            btnCerrarSesion.TabIndex = 8;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.WhiteSmoke;
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(220, 0);
            pnlContenido.Margin = new Padding(2);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(1029, 566);
            pnlContenido.TabIndex = 1;
            pnlContenido.Paint += pnlContenido_Paint;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1249, 566);
            Controls.Add(pnlContenido);
            Controls.Add(pnlSidebar);
            Margin = new Padding(2);
            MinimumSize = new Size(635, 346);
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
        private Button btnHistorialFacturas;
        private Label lblNombreUsuario;
        private Label lblRolUsuario;
        private Button btnCerrarSesion;
    }
}