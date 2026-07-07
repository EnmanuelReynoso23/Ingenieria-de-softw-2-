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
    }
}