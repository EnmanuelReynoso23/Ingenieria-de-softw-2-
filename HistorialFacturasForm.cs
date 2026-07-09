using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using InventoryApp.DB;
using InventoryApp.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InventoryApp
{
    public partial class HistorialFacturasForm : Form
    {
        private DataAccess dataAccess = new DataAccess();

        public HistorialFacturasForm()
        {
            InitializeComponent();

            // Requisito obligatorio para usar QuestPDF aquí también
            QuestPDF.Settings.License = LicenseType.Community;

            this.Load += HistorialFacturasForm_Load;
            this.btnAbrirPdf.Click += BtnAbrirPdf_Click;
            this.dgvHistorial.CellDoubleClick += DgvHistorial_CellDoubleClick;
        }

        private void HistorialFacturasForm_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                List<FacturaHistorial> facturas = dataAccess.ListarHistorialFacturas();
                dgvHistorial.DataSource = facturas;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvHistorial.Columns["IdFactura"] != null) dgvHistorial.Columns["IdFactura"].HeaderText = "No. Factura";
            if (dgvHistorial.Columns["Cliente"] != null) dgvHistorial.Columns["Cliente"].HeaderText = "Cliente";
            if (dgvHistorial.Columns["Vendedor"] != null) dgvHistorial.Columns["Vendedor"].HeaderText = "Cajero";
            if (dgvHistorial.Columns["Fecha"] != null) dgvHistorial.Columns["Fecha"].HeaderText = "Fecha de Emisión";

            if (dgvHistorial.Columns["Total"] != null)
            {
                dgvHistorial.Columns["Total"].HeaderText = "Total Pagado";
                dgvHistorial.Columns["Total"].DefaultCellStyle.Format = "C2";
            }

            if (dgvHistorial.Columns["RutaPdf"] != null) dgvHistorial.Columns["RutaPdf"].Visible = false;
        }

        private void BtnAbrirPdf_Click(object sender, EventArgs e) => AbrirPdfSeleccionado();

        private void DgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AbrirPdfSeleccionado();
        }

        // --- LA MAGIA: VERIFICAR Y/O DESCARGAR PDF ---
        private void AbrirPdfSeleccionado()
        {
            if (dgvHistorial.CurrentRow == null) return;

            // Extraemos los datos de la fila seleccionada
            int idFactura = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["IdFactura"].Value);
            string rutaDb = dgvHistorial.CurrentRow.Cells["RutaPdf"].Value?.ToString() ?? string.Empty;
            string clienteNombre = dgvHistorial.CurrentRow.Cells["Cliente"].Value?.ToString() ?? string.Empty;
            decimal totalFactura = Convert.ToDecimal(dgvHistorial.CurrentRow.Cells["Total"].Value);
            string fechaEmision = dgvHistorial.CurrentRow.Cells["Fecha"].Value?.ToString() ?? string.Empty;

            // 1. Configuramos la ruta de la carpeta "Facturas" de forma dinámica (sin hardcodear)
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string carpetaFacturas;

            // Si el programa está corriendo en Visual Studio, subimos 3 carpetas para llegar a la raíz de tu repo
            if (rutaBase.Contains("bin"))
            {
                carpetaFacturas = Path.GetFullPath(Path.Combine(rutaBase, @"..\..\..\Facturas"));
            }
            else
            {
                // Si el programa ya está compilado y en producción, usa la carpeta al lado del .exe
                carpetaFacturas = Path.Combine(rutaBase, "Facturas");
            }

            // Si la carpeta no existe, que la cree automáticamente
            if (!Directory.Exists(carpetaFacturas))
            {
                Directory.CreateDirectory(carpetaFacturas);
            }

            // 2. Extraemos SOLO el nombre del archivo (ej. Factura_15.pdf) ignorando rutas viejas
            string nombreArchivo = string.IsNullOrWhiteSpace(rutaDb) ? $"Factura_{idFactura}.pdf" : Path.GetFileName(rutaDb);
            string rutaLocalPdf = Path.Combine(carpetaFacturas, nombreArchivo);

            // 3. Verificamos si existe. Si NO existe (como cuando la borraste de prueba), la regenera.
            if (!File.Exists(rutaLocalPdf))
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    string rncCliente = dataAccess.ObtenerRncClientePorFactura(idFactura);
                    List<DetalleFactura> detalles = dataAccess.ObtenerDetallesFactura(idFactura);

                    GenerarPdfAlInstante(idFactura, clienteNombre, rncCliente, fechaEmision, totalFactura, detalles, rutaLocalPdf);
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Error al intentar regenerar la factura: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }

            // 4. Abrimos el PDF guardado o regenerado
            try
            {
                Process.Start(new ProcessStartInfo { FileName = rutaLocalPdf, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el archivo PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MOTOR DE DIBUJO DE QUESTPDF ---
        private void GenerarPdfAlInstante(int idFactura, string nombreCliente, string rnc, string fecha, decimal total, List<DetalleFactura> detalles, string rutaDestino)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // Cabecera (Idéntica a la que hicimos para facturación)
                    page.Header().PaddingBottom(15).Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("InvenTotal").SemiBold().FontSize(16).FontColor(Colors.Blue.Darken2);
                            col.Item().Text($"Factura #: {idFactura}").Bold();
                            col.Item().Text($"Fecha: {fecha}");
                            col.Item().Text($"Cliente: {nombreCliente}");
                            col.Item().Text($"RNC/Cédula: {rnc}");
                        });

                        string rutaLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "Logo InvenTotal.png");
                        if (File.Exists(rutaLogo))
                        {
                            row.ConstantItem(120).AlignRight().Image(rutaLogo);
                        }
                    });

                    // Tabla de productos
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.ConstantColumn(60);
                            columns.ConstantColumn(60);
                        });

                        table.Header(header =>
                        {
                            header.Cell().BorderBottom(1).PaddingBottom(5).Text("Descripción").SemiBold();
                            header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Cant.").SemiBold();
                            header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Precio").SemiBold();
                            header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Subtotal").SemiBold();
                        });

                        foreach (var det in detalles)
                        {
                            table.Cell().PaddingVertical(2).Text(det.NombreProducto);
                            table.Cell().PaddingVertical(2).AlignRight().Text(det.Cantidad.ToString());
                            table.Cell().PaddingVertical(2).AlignRight().Text($"${det.PrecioUnitario:N2}");
                            table.Cell().PaddingVertical(2).AlignRight().Text($"${det.Subtotal:N2}");
                        }
                    });

                    // Pie de página
                    page.Footer().Column(col =>
                    {
                        col.Item().LineHorizontal(1);
                        col.Item().AlignRight().PaddingTop(5).Text($"TOTAL: ${total:N2}").FontSize(14).Bold();
                        col.Item().AlignCenter().PaddingTop(10).Text("¡Gracias por su compra!").FontSize(9).Italic();
                        col.Item().AlignCenter().Text("--- Copia de Factura (Historial) ---").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                });
            })
            .GeneratePdf(rutaDestino);
        }
    }
}