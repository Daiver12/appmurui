using MauiApp1.Ventanas;
namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Traductor_button(object sender, EventArgs e)
        {
            //logica de pasar pagina
            Shell.Current.GoToAsync(nameof(Traductor));
        }

        private void Perfil_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(perfil));
        }

        private void Inicio_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Inicio));
        }

        private void Informacion_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(Informacion));
        }
    }

}
