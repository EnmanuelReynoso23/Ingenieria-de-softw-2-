namespace InventoryApp;

static class Program
{
    /// <summary>
    ///  El punto de entrada principal de la aplicación.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Para personalizar la configuración de la aplicación, como establecer configuraciones de alto DPI o la fuente predeterminada,
        // visite https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }    
}