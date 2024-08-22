namespace MauiApp1.Ventanas;

public partial class Crearperfil : ContentPage
{
	public Crearperfil()
	{
		InitializeComponent();
	}

    private async void iniciarsesion_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }
}