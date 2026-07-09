namespace InventoryApp
{
    public static class PermisoRol
    {
        public static bool PuedeVerInventario(int idRol)   => idRol == 1 || idRol == 3;
        public static bool PuedeVerClientes(int idRol)     => idRol == 1 || idRol == 2;
        public static bool PuedeVerFacturacion(int idRol)  => idRol == 1 || idRol == 2;
        public static bool PuedeVerUsuarios(int idRol)     => idRol == 1;
    }
}
