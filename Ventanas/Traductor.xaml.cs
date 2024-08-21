namespace MauiApp1.Ventanas;

public partial class Traductor : ContentPage
{
	public Traductor()
	{
		InitializeComponent();
	}

    private void limitecaracter(object sender, TextChangedEventArgs e)
    {
		int count = e.NewTextValue.Length;
        contadorcaracter.Text = $"Caracteres {count}/250";
    }
}