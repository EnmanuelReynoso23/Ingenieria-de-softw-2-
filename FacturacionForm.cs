using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InventoryApp.DB;
using InventoryApp.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace InventoryApp
{
    public partial class facturacionForm : Form
    {
        private DataAccess dataAccess = new DataAccess();
        private DataTable dtCarrito = new DataTable();
        private decimal totalFactura = 0m;

        private int idUsuarioLogueado;

        public facturacionForm()
        {
            InitializeComponent();
            ConfigurarCarrito();

            //ID del usuario de la sesión activa
            if (Session.UsuarioActual != null)
            {
                idUsuarioLogueado = Session.UsuarioActual.Id;

                //Actualizamos el Label de la interfaz gráfica con su nombre real
                lblVendedorInfo.Text = $"Cajero: {Session.UsuarioActual.NombreCompleto}";
            }
            else
            {
                MessageBox.Show("Error de sesión. Por favor inicie sesión nuevamente.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //licencia comunitaria obligatoria de QuestPDF
            QuestPDF.Settings.License = LicenseType.Community;

            // Eventos
            this.Load += FacturacionForm_Load;
            this.cboCliente.SelectedIndexChanged += CboCliente_SelectedIndexChanged;
            this.cboProducto.SelectedIndexChanged += CboProducto_SelectedIndexChanged;
            this.btnAgregar.Click += BtnAgregar_Click;
            this.btnFacturar.Click += BtnFacturar_Click;
        }

        private void ConfigurarCarrito()
        {
            dtCarrito.Columns.Add("IdProducto", typeof(int));
            dtCarrito.Columns.Add("Descripción", typeof(string));
            dtCarrito.Columns.Add("Precio", typeof(decimal));
            dtCarrito.Columns.Add("Cantidad", typeof(int));
            dtCarrito.Columns.Add("Subtotal", typeof(decimal));
            dgvCarrito.DataSource = dtCarrito;
            dgvCarrito.Columns["IdProducto"].Visible = false;
        }

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            dtpFecha.Value = DateTime.Now;
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar Clientes
                var clientes = dataAccess.ListarClientes();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "Name";
                cboCliente.ValueMember = "Id";

                // Cargar Productos (Solo para visualizarlos, el stock real se re-verifica al agregar)
                var productos = dataAccess.ListarInventario();
                cboProducto.DataSource = productos;
                cboProducto.DisplayMember = "Name";
                cboProducto.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos: " + ex.Message);
            }
        }

        private void CboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem is Client clienteSeleccionado)
            {
                txtRnc.Text = clienteSeleccionado.Rnc;
            }
        }

        private void CboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is Product productoSeleccionado)
            {
                txtPrecio.Text = productoSeleccionado.Price.ToString("0.00");
                txtStock.Text = productoSeleccionado.Stock.ToString();
                numCantidad.Maximum = productoSeleccionado.Stock > 0 ? productoSeleccionado.Stock : 1;
                numCantidad.Value = 1;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!(cboProducto.SelectedItem is Product producto)) return;

            int cantidadRequerida = (int)numCantidad.Value;

            //Validar que la cantidad sea válida y haya stock
            if (cantidadRequerida <= 0) return;

            // Verificar si el producto ya está en el carrito para sumar la cantidad
            int cantidadEnCarrito = 0;
            foreach (DataRow row in dtCarrito.Rows)
            {
                if ((int)row["IdProducto"] == producto.Id)
                {
                    cantidadEnCarrito = (int)row["Cantidad"];
                    break;
                }
            }

            // Validación estricta de Stock
            if (cantidadRequerida + cantidadEnCarrito > producto.Stock)
            {
                MessageBox.Show($"¡No hay suficiente stock! Quedan {producto.Stock} y estás intentando vender {cantidadRequerida + cantidadEnCarrito}.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Agregar al carrito o actualizar cantidad
            bool existe = false;
            foreach (DataRow row in dtCarrito.Rows)
            {
                if ((int)row["IdProducto"] == producto.Id)
                {
                    row["Cantidad"] = (int)row["Cantidad"] + cantidadRequerida;
                    row["Subtotal"] = (int)row["Cantidad"] * producto.Price;
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                dtCarrito.Rows.Add(producto.Id, producto.Name, producto.Price, cantidadRequerida, cantidadRequerida * producto.Price);
            }

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            totalFactura = 0m;
            foreach (DataRow row in dtCarrito.Rows)
            {
                totalFactura += (decimal)row["Subtotal"];
            }
            lblTotal.Text = $"$ {totalFactura:N2}";
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            if (dtCarrito.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto para facturar.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cboCliente.SelectedItem is Client cliente)) return;

            try
            {
                // 1. Preparar Cabecera
                Factura nuevaFactura = new Factura
                {
                    IdCliente = cliente.Id,
                    IdUsuario = idUsuarioLogueado,
                    Total = totalFactura
                };

                // 2. Preparar Detalles
                List<DetalleFactura> detalles = new List<DetalleFactura>();
                foreach (DataRow row in dtCarrito.Rows)
                {
                    detalles.Add(new DetalleFactura
                    {
                        IdProducto = (int)row["IdProducto"],
                        NombreProducto = row["Descripción"].ToString(),
                        Cantidad = (int)row["Cantidad"],
                        PrecioUnitario = (decimal)row["Precio"],
                        Subtotal = (decimal)row["Subtotal"]
                    });
                }

                //Procesar en Base de Datos (Si falla por stock, caerá en el catch)
                int idFacturaGenerada = dataAccess.ProcesarFacturaTransaccion(nuevaFactura, detalles);

                // Generar PDF con QuestPDF
                string rutaArchivo = GenerarPDF(idFacturaGenerada, cliente, detalles);

                //Guardar ruta del PDF en BD
                dataAccess.ActualizarRutaPdfFactura(idFacturaGenerada, rutaArchivo);

                MessageBox.Show($"Factura #{idFacturaGenerada} generada y procesada con éxito.\nEl stock ha sido descontado.", "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar todo para la siguiente venta
                dtCarrito.Clear();
                CalcularTotal();
                CargarCombos(); // Recarga el inventario actualizado

                // Abrir el PDF para imprimir
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = rutaArchivo, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la factura: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MOTOR DE GENERACIÓN DE PDF (QUESTPDF) ---
        private string GenerarPDF(int idFactura, Client cliente, List<DetalleFactura> detalles)
        {
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Facturas");
            Directory.CreateDirectory(carpeta);
            string rutaPdf = Path.Combine(carpeta, $"Factura_{idFactura}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // Cabecera del PDF
                    page.Header().PaddingBottom(15).Row(row =>
                    {
                        // 1. LADO IZQUIERDO (Los datos en texto)
                        // RelativeItem() hace que el texto ocupe todo el espacio disponible a la izquierda
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("InvenTotal").SemiBold().FontSize(16).FontColor(Colors.Blue.Darken2);
                            col.Item().Text($"Factura #: {idFactura}").Bold();
                            col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
                            col.Item().Text($"Cliente: {cliente.Name}");
                            col.Item().Text($"RNC/Cédula: {cliente.Rnc}");
                        });

                        // 2. LADO DERECHO (El Logo)
                        string rutaLogo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "Logo InvenTotal.png");

                        if (File.Exists(rutaLogo))
                        {
                            // ConstantItem(120) reserva exactamente 120 píxeles a la derecha para la foto
                            // AlignRight() asegura que la imagen se pegue al margen derecho
                            row.ConstantItem(120).AlignRight().Image(rutaLogo);
                        }
                    });

                    // Tabla de productos
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(); // Nombre
                            columns.ConstantColumn(40); // Cantidad
                            columns.ConstantColumn(60); // Precio
                            columns.ConstantColumn(60); // Subtotal
                        });

                        // Encabezados
                        table.Header(header =>
                        {
                            header.Cell().BorderBottom(1).PaddingBottom(5).Text("Descripción").SemiBold();
                            header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Cant.").SemiBold();
                            header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Precio").SemiBold();
                            header.Cell().BorderBottom(1).PaddingBottom(5).AlignRight().Text("Subtotal").SemiBold();
                        });

                        // Filas
                        foreach (var det in detalles)
                        {
                            table.Cell().PaddingVertical(2).Text(det.NombreProducto);
                            table.Cell().PaddingVertical(2).AlignRight().Text(det.Cantidad.ToString());
                            table.Cell().PaddingVertical(2).AlignRight().Text($"${det.PrecioUnitario:N2}");
                            table.Cell().PaddingVertical(2).AlignRight().Text($"${det.Subtotal:N2}");
                        }
                    });

                    // Pie de página (Total)
                    page.Footer().Column(col =>
                    {
                        col.Item().LineHorizontal(1);
                        col.Item().AlignRight().PaddingTop(5).Text($"TOTAL: ${totalFactura:N2}").FontSize(14).Bold();
                        col.Item().AlignCenter().PaddingTop(10).Text("¡Gracias por su compra!").FontSize(9).Italic();
                    });
                });
            })
            .GeneratePdf(rutaPdf);

            return rutaPdf;
        }
    }
}