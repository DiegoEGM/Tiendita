using Tiendita.Models;
using Newtonsoft.Json;
using System.Text;
namespace Tiendita.Views;

public partial class RegistroPage : ContentPage
{
	private readonly HttpClient client = new HttpClient();
	public RegistroPage()
	{
		InitializeComponent();
	}
    private async void btnRegistrarse_Clicked(object sender, EventArgs e)
    {
        string url = "https://nutriciondiego.azurewebsites.net/api/Cuentas/registro";

        User user = new User
        {
            Username = txtNombre.Text,
            Password = txtContra.Text
        };

        string jsonUser = JsonConvert.SerializeObject(user);

        StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

        var respuesta = await client.PostAsync(url, content);

        

        if (respuesta.IsSuccessStatusCode)
        {
            var tokenString = respuesta.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<UserToken>(tokenString.Result);
            await SecureStorage.SetAsync("token", json.Token);
            await Navigation.PushAsync(new MainPage(txtNombre.Text));
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar", "Ok");
        }
    }
}