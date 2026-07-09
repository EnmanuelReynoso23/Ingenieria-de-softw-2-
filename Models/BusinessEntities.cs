using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rnc { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }

    public class UserEntity
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public string FechaCreacion { get; set; } = string.Empty;
    }

    // Faltaba la clase Product que usa tu DataAccess
    public class Product
    {
        public int Id { get; set; } // Este será tu nuevo "Código"
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}