using Tiendita.Models;
using Newtonsoft.Json;
using System.Text;

namespace Tiendita.Views;

public partial class LoginPage : ContentPage
{
    HttpClient client = new HttpClient();

    private int id = -1;
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        string url = "https://nutriciondiego.azurewebsites.net/api/Cuentas/login";

        User user = new User
        {
            Username = txtUsuario.Text,
            Password = txtPassword.Text
        };
        string jsonUser = JsonConvert.SerializeObject(user);
        StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
        var respuesta = await client.PostAsync(url, content);
        if (respuesta.IsSuccessStatusCode)
        {
            var tokenString = respuesta.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<UserToken>(tokenString.Result);
            if (respuesta.IsSuccessStatusCode)
            {
                await SecureStorage.SetAsync("token", json.Token);
                await Navigation.PushAsync(new MainPage(txtUsuario.Text));
            }
        }
        else
        {
            await DisplayAlert("Error", "Error en los datos del usuario", "Ok");
        }
    }
    private async void btnRegistro_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistroPage());
    }
    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ActualizarPage());
    }
}