using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Npgsql;

namespace InventoryApp.DB
{
    public class ConexionDB
    {
        private string conexionString;

        public ConexionDB()
        {
            conexionString = "Host=db.pztlyjvnukuikgxnkgxo.supabase.co;" +
                "Username=postgres;" +
                "Password=o25rx0LEoO57IhDm;" +
                "Database=postgres;" +
                "Port=5432;" +
                "Pooling=true;" +
                "SSL Mode=Require;" +
                "Trust Server Certificate=true";
        }

        public NpgsqlConnection GetConnection()
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(conexionString);
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo conectar con la base de datos:" + ex.Message);
            }
        }
    }
}
