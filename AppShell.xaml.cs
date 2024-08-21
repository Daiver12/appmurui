using MauiApp1.Ventanas;


namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Accesos a paginas
            Routing.RegisterRoute(nameof(Traductor), typeof(Traductor));
            Routing.RegisterRoute(nameof(perfil), typeof(perfil));
            Routing.RegisterRoute(nameof(Inicio), typeof(Inicio));
            Routing.RegisterRoute(nameof(Informacion), typeof(Informacion));
            Routing.RegisterRoute(nameof(Crearperfil), typeof(Crearperfil));
        }
    }
}
