using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Ventanas.Login
{
    internal class ModeloRegister : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string WebApiKey = "";
        private INavigation _navigation;
        private string email;
        private string pass;

        public Command RegistroUser { get; }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        public string Pass
        {
            get => pass;
            set
            {
                pass = value;
                RaisePropertyChanged(nameof(Pass));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ModeloRegister(INavigation navigation)
        {
            _navigation = navigation;
            RegistroUser = new Command(async () => await RegistrarUsuarioTappedAsync());
        }

        private async Task RegistrarUsuarioTappedAsync()
        {
            try
            {
                var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={WebApiKey}";
                using (var client = new HttpClient())
                {
                    var payload = new
                    {
                        email = Email,
                        password = Pass,
                        returnSecureToken = true
                    };

                    var json = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content);
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseBody);
                    string token = result.idToken;

                    // You can use the token as needed
                }
                await App.Current.MainPage.DisplayAlert("Mensaje emergente", "Inicio sesion correctamente", "ok");
                await Shell.Current.Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
