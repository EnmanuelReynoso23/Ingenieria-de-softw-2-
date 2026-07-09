using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Text;
using System.Text;
using Npgsql;
using InventoryApp.Models;

namespace InventoryApp.DB
{
    public class DataAccess
    {
        private ConexionDB dbConn = new ConexionDB();

        // --- SECCIÓN DE USUARIOS / LOGIN ---

        public UserEntity? ValidarUsuario(string nombreUsuario, string contrasena)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT u.id_usuario, u.nombre_completo, u.nombre_usuario,
                                          u.id_rol, r.nombre_rol
                                   FROM usuarios u
                                   INNER JOIN roles r ON u.id_rol = r.id_rol
                                   WHERE u.nombre_usuario = @usuario
                                     AND u.contrasena_hash = @contrasena
                                     AND u.activo = true";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("usuario", nombreUsuario);
                        cmd.Parameters.AddWithValue("contrasena", contrasena);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new UserEntity
                                {
                                    Id = Convert.ToInt32(reader["id_usuario"]),
                                    NombreCompleto = Convert.ToString(reader["nombre_completo"]) ?? string.Empty,
                                    NombreUsuario = Convert.ToString(reader["nombre_usuario"]) ?? string.Empty,
                                    IdRol = Convert.ToInt32(reader["id_rol"]),
                                    NombreRol = Convert.ToString(reader["nombre_rol"]) ?? string.Empty
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al validar usuario: " + ex.Message);
                }
            }
            return null;
        }

        // --- SECCIÓN DE USUARIOS ---

        public List<UserEntity> ListarUsuarios()
        {
            List<UserEntity> lista = new List<UserEntity>();
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT u.id_usuario, u.nombre_completo, u.nombre_usuario,
                                          u.id_rol, r.nombre_rol, u.activo, u.fecha_creacion
                                   FROM usuarios u
                                   INNER JOIN roles r ON u.id_rol = r.id_rol
                                   ORDER BY u.id_usuario ASC";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UserEntity
                            {
                                Id = Convert.ToInt32(reader["id_usuario"]),
                                NombreCompleto = Convert.ToString(reader["nombre_completo"]) ?? string.Empty,
                                NombreUsuario = Convert.ToString(reader["nombre_usuario"]) ?? string.Empty,
                                IdRol = Convert.ToInt32(reader["id_rol"]),
                                NombreRol = Convert.ToString(reader["nombre_rol"]) ?? string.Empty,
                                Activo = Convert.ToBoolean(reader["activo"]),
                                FechaCreacion = reader["fecha_creacion"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["fecha_creacion"]).ToString("dd/MM/yyyy HH:mm")
                                    : "Sin fecha"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar usuarios: " + ex.Message);
                }
            }
            return lista;
        }

        public void AgregarUsuario(UserEntity usuario, string contrasena)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO usuarios (nombre_completo, nombre_usuario, contrasena_hash, id_rol, activo)
                                   VALUES (@nombre, @usuario, @contrasena, @rol, @activo)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nombre", usuario.NombreCompleto);
                        cmd.Parameters.AddWithValue("usuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("contrasena", contrasena);
                        cmd.Parameters.AddWithValue("rol", usuario.IdRol);
                        cmd.Parameters.AddWithValue("activo", usuario.Activo);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar usuario: " + ex.Message);
                }
            }
        }

        public void ActualizarUsuario(UserEntity usuario)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE usuarios
                                   SET nombre_completo = @nombre, nombre_usuario = @usuario,
                                       id_rol = @rol, activo = @activo
                                   WHERE id_usuario = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", usuario.Id);
                        cmd.Parameters.AddWithValue("nombre", usuario.NombreCompleto);
                        cmd.Parameters.AddWithValue("usuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("rol", usuario.IdRol);
                        cmd.Parameters.AddWithValue("activo", usuario.Activo);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar usuario: " + ex.Message);
                }
            }
        }

        public void CambiarContrasena(int idUsuario, string nuevaContrasena)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE usuarios SET contrasena_hash = @contrasena WHERE id_usuario = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("contrasena", nuevaContrasena);
                        cmd.Parameters.AddWithValue("id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cambiar contraseña: " + ex.Message);
                }
            }
        }

        public void DesactivarUsuario(int idUsuario)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE usuarios SET activo = false WHERE id_usuario = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al desactivar usuario: " + ex.Message);
                }
            }
        }

        // --- SECCIÓN DE CLIENTES ---

        // Listar todos los clientes
        public List<Client> ListarClientes()
        {
            List<Client> lista = new List<Client>();

            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT id_cliente, nombre, rnc_cedula, telefono, fecha_registro FROM clientes ORDER BY id_cliente ASC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object dbDate = reader["fecha_registro"];
                            string fechaFormateada = "Sin fecha";

                            if (dbDate != DBNull.Value && dbDate != null)
                            {
                                fechaFormateada = Convert.ToDateTime(dbDate).ToString("dd/MM/yyyy HH:mm");
                            }

                            lista.Add(new Client
                            {
                                Id = Convert.ToInt32(reader["id_cliente"]),
                                Name = Convert.ToString(reader["nombre"]) ?? string.Empty,
                                Rnc = Convert.ToString(reader["rnc_cedula"]) ?? string.Empty,
                                Phone = Convert.ToString(reader["telefono"]) ?? string.Empty,
                                Date = fechaFormateada
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar clientes: " + ex.Message);
                }
            }
            return lista;
        }

        // Agregar nuevo cliente
        public void AgregarCliente(Client cliente)
        {
            using (var connection = dbConn.GetConnection())
            {
                try
                {
                    connection.Open();
                    // INSERT con los campos exactos. fecha_registro tomará la fecha actual de la BD
                    string sql = @"INSERT INTO clientes (nombre, rnc_cedula, telefono) 
                                   VALUES (@nombre, @rnc, @telefono) RETURNING id_cliente";

                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("nombre", cliente.Name ?? string.Empty);
                        command.Parameters.AddWithValue("rnc", (object?)cliente.Rnc ?? DBNull.Value);
                        command.Parameters.AddWithValue("telefono", (object?)cliente.Phone ?? DBNull.Value);

                        var result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            cliente.Id = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el cliente: " + ex.Message);
                }
            }
        }


        // Eliminar cliente
        public void EliminarCliente(int id_cliente)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM clientes WHERE id_cliente = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", id_cliente);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el cliente: " + ex.Message);
                }
            }
        }

        // Actualizar cliente
        public void ActualizarCliente(Client cliente)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Usamos UPDATE para cambiar los datos del registro que coincida con el id_cliente
                    string sql = @"UPDATE clientes 
                                   SET nombre = @nombre, rnc_cedula = @rnc, telefono = @telefono 
                                   WHERE id_cliente = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", cliente.Id);
                        cmd.Parameters.AddWithValue("nombre", cliente.Name ?? string.Empty);
                        cmd.Parameters.AddWithValue("rnc", (object?)cliente.Rnc ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("telefono", (object?)cliente.Phone ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el cliente: " + ex.Message);
                }
            }
        }

        // --- SECCIÓN DE INVENTARIO ---

        // Listar todos los artículos del inventario
        public List<Product> ListarInventario()
        {
            List<Product> lista = new List<Product>();

            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT id_producto, nombre, precio, stock, fecha_registro
                                   FROM productos
                                   ORDER BY id_producto ASC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object dbDate = reader["fecha_registro"];
                            string fechaFormateada = "Sin fecha";

                            if (dbDate != DBNull.Value && dbDate != null)
                            {
                                fechaFormateada = Convert.ToDateTime(dbDate).ToString("dd/MM/yyyy HH:mm");
                            }

                            lista.Add(new Product
                            {
                                Id = Convert.ToInt32(reader["id_producto"]),
                                Name = Convert.ToString(reader["nombre"]) ?? string.Empty,
                                Price = reader["precio"] != DBNull.Value ? Convert.ToDecimal(reader["precio"]) : 0m,
                                Stock = reader["stock"] != DBNull.Value ? Convert.ToInt32(reader["stock"]) : 0,
                                Date = fechaFormateada
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar el inventario: " + ex.Message);
                }
            }
            return lista;
        }

        // Agregar nuevo artículo al inventario
        public void AgregarProducto(Product producto)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO productos (nombre, precio, stock)
                                   VALUES (@nombre, @precio, @stock)
                                   RETURNING id_producto";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nombre", producto.Name ?? string.Empty);
                        cmd.Parameters.AddWithValue("precio", producto.Price);
                        cmd.Parameters.AddWithValue("stock", producto.Stock);

                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            producto.Id = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el artículo: " + ex.Message);
                }
            }
        }

        // Actualizar artículo existente
        public void ActualizarProducto(Product producto)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE productos
                                   SET nombre = @nombre, precio = @precio, stock = @stock
                                   WHERE id_producto = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", producto.Id);
                        cmd.Parameters.AddWithValue("nombre", producto.Name ?? string.Empty);
                        cmd.Parameters.AddWithValue("precio", producto.Price);
                        cmd.Parameters.AddWithValue("stock", producto.Stock);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el artículo: " + ex.Message);
                }
            }
        }

        // Eliminar artículo del inventario
        public void EliminarProducto(int idProducto)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM productos WHERE id_producto = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", idProducto);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el artículo: " + ex.Message);
                }
            }
        }

        // Verificar si el NOMBRE ya existe (reemplaza la validación del código viejo)
        public bool ExisteNombreProducto(string nombre, int idExcluir = 0)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"SELECT COUNT(*) FROM productos
                                   WHERE LOWER(nombre) = LOWER(@nombre) AND id_producto <> @idExcluir";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nombre", nombre.Trim());
                        cmd.Parameters.AddWithValue("idExcluir", idExcluir);
                        long count = (long)(cmd.ExecuteScalar() ?? 0L);
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar el nombre: " + ex.Message);
                }
            }
        }

        // --- SECCIÓN DE FACTURACIÓN ---

        // Método maestro: Guarda factura, detalles y descuenta stock todo en una sola transacción
        public int ProcesarFacturaTransaccion(Factura factura, List<DetalleFactura> detalles)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                // Iniciamos la transacción (Si algo falla, hacemos Rollback)
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar la Cabecera de la Factura
                        string sqlFactura = @"INSERT INTO facturas (id_cliente, id_usuario, fecha_emision, total, ruta_pdf)
                                              VALUES (@cliente, @usuario, CURRENT_TIMESTAMP, @total, @ruta) RETURNING id_factura";

                        int idFactura = 0;
                        using (var cmdFactura = new NpgsqlCommand(sqlFactura, conn, tx))
                        {
                            cmdFactura.Parameters.AddWithValue("cliente", factura.IdCliente);
                            cmdFactura.Parameters.AddWithValue("usuario", factura.IdUsuario);
                            cmdFactura.Parameters.AddWithValue("total", factura.Total);
                            cmdFactura.Parameters.AddWithValue("ruta", factura.RutaPdf ?? string.Empty);

                            idFactura = Convert.ToInt32(cmdFactura.ExecuteScalar());
                        }

                        // 2. Procesar Detalles y Descontar Stock
                        string sqlDetalle = @"INSERT INTO detalle_factura (id_factura, id_producto, cantidad, precio_unitario, subtotal)
                                              VALUES (@factura, @producto, @cantidad, @precio, @subtotal)";

                        string sqlRestarStock = @"UPDATE productos 
                                                  SET stock = stock - @cantidad 
                                                  WHERE id_producto = @producto AND stock >= @cantidad";

                        foreach (var det in detalles)
                        {
                            // A) Intentar restar el stock primero (Validación de seguridad a nivel BD)
                            using (var cmdStock = new NpgsqlCommand(sqlRestarStock, conn, tx))
                            {
                                cmdStock.Parameters.AddWithValue("cantidad", det.Cantidad);
                                cmdStock.Parameters.AddWithValue("producto", det.IdProducto);

                                int filasAfectadas = cmdStock.ExecuteNonQuery();
                                // Si filasAfectadas es 0, significa que el stock actual es menor a la cantidad solicitada
                                if (filasAfectadas == 0)
                                {
                                    throw new Exception($"Stock insuficiente en base de datos para el producto '{det.NombreProducto}'.");
                                }
                            }

                            // B) Insertar el detalle de la factura
                            using (var cmdDetalle = new NpgsqlCommand(sqlDetalle, conn, tx))
                            {
                                cmdDetalle.Parameters.AddWithValue("factura", idFactura);
                                cmdDetalle.Parameters.AddWithValue("producto", det.IdProducto);
                                cmdDetalle.Parameters.AddWithValue("cantidad", det.Cantidad);
                                cmdDetalle.Parameters.AddWithValue("precio", det.PrecioUnitario);
                                cmdDetalle.Parameters.AddWithValue("subtotal", det.Subtotal);
                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // 3. Si todo salió perfecto, confirmamos los cambios
                        tx.Commit();
                        return idFactura;
                    }
                    catch (Exception)
                    {
                        // Si hubo algún error (ej. falta de stock), revertimos todo lo hecho
                        tx.Rollback();
                        throw; // Pasamos el error al formulario para mostrarlo
                    }
                }
            }
        }

        // Para guardar la ruta del PDF una vez generado
        public void ActualizarRutaPdfFactura(int idFactura, string rutaPdf)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE facturas SET ruta_pdf = @ruta WHERE id_factura = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("ruta", rutaPdf);
                    cmd.Parameters.AddWithValue("id", idFactura);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- HISTORIAL DE FACTURAS ---
        public List<FacturaHistorial> ListarHistorialFacturas()
        {
            List<FacturaHistorial> lista = new List<FacturaHistorial>();

            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Hacemos JOIN para traer los nombres reales del cliente y del vendedor
                    string sql = @"SELECT f.id_factura, c.nombre AS cliente, u.nombre_completo AS vendedor, 
                                          f.fecha_emision, f.total, f.ruta_pdf 
                                   FROM facturas f
                                   INNER JOIN clientes c ON f.id_cliente = c.id_cliente
                                   INNER JOIN usuarios u ON f.id_usuario = u.id_usuario
                                   ORDER BY f.id_factura DESC"; // Ordenadas de la más nueva a la más vieja

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object dbDate = reader["fecha_emision"];
                            string fechaFormateada = "Sin fecha";

                            if (dbDate != DBNull.Value && dbDate != null)
                            {
                                fechaFormateada = Convert.ToDateTime(dbDate).ToString("dd/MM/yyyy hh:mm tt");
                            }

                            lista.Add(new FacturaHistorial
                            {
                                IdFactura = Convert.ToInt32(reader["id_factura"]),
                                Cliente = Convert.ToString(reader["cliente"]) ?? string.Empty,
                                Vendedor = Convert.ToString(reader["vendedor"]) ?? string.Empty,
                                Fecha = fechaFormateada,
                                Total = reader["total"] != DBNull.Value ? Convert.ToDecimal(reader["total"]) : 0m,
                                RutaPdf = Convert.ToString(reader["ruta_pdf"]) ?? string.Empty
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar el historial de facturas: " + ex.Message);
                }
            }
            return lista;
        }

        // --- MÉTODOS PARA REGENERAR PDF DEL HISTORIAL ---

        // Obtener el RNC del cliente que compró en esa factura
        public string ObtenerRncClientePorFactura(int idFactura)
        {
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                // Hacemos JOIN para llegar al RNC del cliente
                string sql = @"SELECT c.rnc_cedula FROM facturas f 
                               INNER JOIN clientes c ON f.id_cliente = c.id_cliente 
                               WHERE f.id_factura = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", idFactura);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "N/A";
                }
            }
        }

        // Obtener los productos exactos que se vendieron en esa factura
        public List<DetalleFactura> ObtenerDetallesFactura(int idFactura)
        {
            List<DetalleFactura> detalles = new List<DetalleFactura>();
            using (NpgsqlConnection conn = dbConn.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT d.id_producto, p.nombre AS nombre_producto, d.cantidad, d.precio_unitario, d.subtotal 
                               FROM detalle_factura d
                               INNER JOIN productos p ON d.id_producto = p.id_producto
                               WHERE d.id_factura = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", idFactura);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new DetalleFactura
                            {
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                NombreProducto = reader["nombre_producto"].ToString(),
                                Cantidad = Convert.ToInt32(reader["cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"]),
                                Subtotal = Convert.ToDecimal(reader["subtotal"])
                            });
                        }
                    }
                }
            }
            return detalles;
        }

    }
}
