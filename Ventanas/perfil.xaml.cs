using MauiApp1.Ventanas.Login;

namespace MauiApp1.Ventanas;

public partial class perfil : ContentPage
{
	public perfil()
	{
		InitializeComponent();
        BindingContext = new ModeloLogin(Navigation);

    }


}