namespace InventoryApp
{
    partial class HistorialFacturasForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnAbrirPdf = new Button();
            lblTitulo = new Label();
            dgvHistorial = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnAbrirPdf);
            pnlTop.Controls.Add(lblTitulo);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 70);
            pnlTop.TabIndex = 0;
            // 
            // btnAbrirPdf
            // 
            btnAbrirPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAbrirPdf.BackColor = Color.SteelBlue;
            btnAbrirPdf.FlatAppearance.BorderSize = 0;
            btnAbrirPdf.FlatStyle = FlatStyle.Flat;
            btnAbrirPdf.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAbrirPdf.ForeColor = Color.White;
            btnAbrirPdf.Location = new Point(630, 20);
            btnAbrirPdf.Name = "btnAbrirPdf";
            btnAbrirPdf.Size = new Size(150, 35);
            btnAbrirPdf.TabIndex = 1;
            btnAbrirPdf.Text = "Ver Factura (PDF)";
            btnAbrirPdf.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(212, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Facturas";
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(0, 70);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(800, 380);
            dgvHistorial.TabIndex = 1;
            // 
            // HistorialFacturasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvHistorial);
            Controls.Add(pnlTop);
            Name = "HistorialFacturasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Facturas";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAbrirPdf;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}