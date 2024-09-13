using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Ventanas.Login
{
    internal class ModeloLogin : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string WebApiKey = "";
        private INavigation _navigation;
        private string nombreUsuario;
        private string passUser;

        public Command BtnLogin { get; set; }
        public Command BtnRegistro { get; set; }

        public ModeloLogin(INavigation navigation)
        {
            this._navigation = navigation;
            BtnLogin = new Command(BtnLoginTappedAsync);
            BtnRegistro = new Command(BtnRegistroTappedAsync);
        }

        public string NombreUsuario
        {
            get => nombreUsuario;
            set
            {
                nombreUsuario = value;
                RaisePropertyChanged(nameof(NombreUsuario));
            }
        }

        public string PassUser
        {
            get => passUser;
            set
            {
                passUser = value;
                RaisePropertyChanged($"{nameof(PassUser)}");
            }
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private async void BtnRegistroTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new Crearperfil());
        }

        private async void BtnLoginTappedAsync(object obj)
        {
            try
            {
                var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={WebApiKey}";
                using (var client = new HttpClient())
                {
                    var payload = new
                    {
                        email = NombreUsuario,
                        password = PassUser,
                        returnSecureToken = true
                    };

                    var json = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseBody);
                    string token = result.idToken;

                    // Handle successful login, e.g., navigate to the dashboard
                    await Shell.Current.Navigation.PopAsync(); // Adjust navigation as needed
                }
                await App.Current.MainPage.DisplayAlert("Mensaje emergente", "Inicio sesion correctamente", "ok");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
