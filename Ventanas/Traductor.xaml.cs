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
    private void CambiodeIdioma(object sender, EventArgs e)
    {
        string tempLabel = InputLabel.Text;
        InputLabel.Text = OutputLabel.Text;
        OutputLabel.Text = tempLabel;

        string tempText = espanol.Text;
        espanol.Text = OutputText.Text;
        OutputText.Text = tempText;

        OutputText.Text = string.Empty;

    }
}