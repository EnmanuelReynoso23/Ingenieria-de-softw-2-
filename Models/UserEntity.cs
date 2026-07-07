namespace InventoryApp.Models
{
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
}
