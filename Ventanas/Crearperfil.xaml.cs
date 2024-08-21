namespace MauiApp1.Ventanas;

public partial class Crearperfil : ContentPage
{
	public Crearperfil()
	{
		InitializeComponent();
	}

    private void iniciarsesion_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(perfil));
    }
}