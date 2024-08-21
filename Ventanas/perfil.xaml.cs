namespace MauiApp1.Ventanas;

public partial class perfil : ContentPage
{
	public perfil()
	{
		InitializeComponent();
	}

    private void Crearperfil_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Crearperfil));
    }
}