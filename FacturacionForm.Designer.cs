namespace InventoryApp
{
    partial class facturacionForm
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
            gbCabecera = new GroupBox();
            dtpFecha = new DateTimePicker();
            label3 = new Label();
            txtRnc = new TextBox();
            label2 = new Label();
            cboCliente = new ComboBox();
            label1 = new Label();
            lblVendedorInfo = new Label();
            gbProducto = new GroupBox();
            btnAgregar = new Button();
            numCantidad = new NumericUpDown();
            label7 = new Label();
            txtPrecio = new TextBox();
            label6 = new Label();
            txtStock = new TextBox();
            label5 = new Label();
            cboProducto = new ComboBox();
            label4 = new Label();
            dgvCarrito = new DataGridView();
            pnlTotales = new Panel();
            btnFacturar = new Button();
            lblTotal = new Label();
            label8 = new Label();
            lblTitulo = new Label();
            gbCabecera.SuspendLayout();
            gbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            pnlTotales.SuspendLayout();
            SuspendLayout();
            // 
            // gbCabecera
            // 
            gbCabecera.Controls.Add(dtpFecha);
            gbCabecera.Controls.Add(label3);
            gbCabecera.Controls.Add(txtRnc);
            gbCabecera.Controls.Add(label2);
            gbCabecera.Controls.Add(cboCliente);
            gbCabecera.Controls.Add(label1);
            gbCabecera.Controls.Add(lblVendedorInfo);
            gbCabecera.Location = new Point(20, 60);
            gbCabecera.Name = "gbCabecera";
            gbCabecera.Size = new Size(840, 80);
            gbCabecera.TabIndex = 0;
            gbCabecera.TabStop = false;
            gbCabecera.Text = "Datos de la Factura";
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(680, 35);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(140, 23);
            dtpFecha.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(680, 15);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "Fecha:";
            // 
            // txtRnc
            // 
            txtRnc.Location = new Point(470, 35);
            txtRnc.Name = "txtRnc";
            txtRnc.ReadOnly = true;
            txtRnc.Size = new Size(180, 23);
            txtRnc.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(470, 15);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 3;
            label2.Text = "RNC / Cédula:";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(200, 35);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(250, 23);
            cboCliente.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Cliente:";
            // 
            // lblVendedorInfo
            // 
            lblVendedorInfo.AutoSize = true;
            lblVendedorInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblVendedorInfo.Location = new Point(15, 36);
            lblVendedorInfo.Name = "lblVendedorInfo";
            lblVendedorInfo.Size = new Size(121, 17);
            lblVendedorInfo.TabIndex = 0;
            lblVendedorInfo.Text = "Cajero: [USUARIO]";
            // 
            // gbProducto
            // 
            gbProducto.Controls.Add(btnAgregar);
            gbProducto.Controls.Add(numCantidad);
            gbProducto.Controls.Add(label7);
            gbProducto.Controls.Add(txtPrecio);
            gbProducto.Controls.Add(label6);
            gbProducto.Controls.Add(txtStock);
            gbProducto.Controls.Add(label5);
            gbProducto.Controls.Add(cboProducto);
            gbProducto.Controls.Add(label4);
            gbProducto.Location = new Point(20, 150);
            gbProducto.Name = "gbProducto";
            gbProducto.Size = new Size(840, 80);
            gbProducto.TabIndex = 1;
            gbProducto.TabStop = false;
            gbProducto.Text = "Agregar Producto";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.MediumSeaGreen;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(700, 30);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 30);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "+ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(590, 35);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(80, 23);
            numCantidad.TabIndex = 10;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(590, 15);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 9;
            label7.Text = "Cantidad:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(470, 35);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(470, 15);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 7;
            label6.Text = "Precio:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(360, 35);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(90, 23);
            txtStock.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(360, 15);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Stock:";
            // 
            // cboProducto
            // 
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(15, 35);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(320, 23);
            cboProducto.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 15);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 3;
            label4.Text = "Producto:";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(20, 240);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(840, 280);
            dgvCarrito.TabIndex = 2;
            // 
            // pnlTotales
            // 
            pnlTotales.BackColor = Color.White;
            pnlTotales.BorderStyle = BorderStyle.FixedSingle;
            pnlTotales.Controls.Add(btnFacturar);
            pnlTotales.Controls.Add(lblTotal);
            pnlTotales.Controls.Add(label8);
            pnlTotales.Location = new Point(20, 530);
            pnlTotales.Name = "pnlTotales";
            pnlTotales.Size = new Size(840, 70);
            pnlTotales.TabIndex = 3;
            // 
            // btnFacturar
            // 
            btnFacturar.BackColor = Color.SteelBlue;
            btnFacturar.FlatAppearance.BorderSize = 0;
            btnFacturar.FlatStyle = FlatStyle.Flat;
            btnFacturar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnFacturar.ForeColor = Color.White;
            btnFacturar.Location = new Point(620, 10);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(200, 48);
            btnFacturar.TabIndex = 12;
            btnFacturar.Text = "Procesar Factura";
            btnFacturar.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(120, 10);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(110, 45);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "$ 0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label8.Location = new Point(15, 25);
            label8.Name = "label8";
            label8.Size = new Size(78, 25);
            label8.TabIndex = 0;
            label8.Text = "TOTAL: ";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(116, 30);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "InvenTotal";
            // 
            // facturacionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 620);
            Controls.Add(lblTitulo);
            Controls.Add(pnlTotales);
            Controls.Add(dgvCarrito);
            Controls.Add(gbProducto);
            Controls.Add(gbCabecera);
            Name = "facturacionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Módulo de Facturación";
            gbCabecera.ResumeLayout(false);
            gbCabecera.PerformLayout();
            gbProducto.ResumeLayout(false);
            gbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            pnlTotales.ResumeLayout(false);
            pnlTotales.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCabecera;
        private System.Windows.Forms.Label lblVendedorInfo;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRnc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label lblTitulo;
    }
}