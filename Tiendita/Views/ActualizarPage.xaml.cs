using Newtonsoft.Json;
using System.Text;
using Tiendita.Models;

namespace Tiendita.Views;

public partial class ActualizarPage : ContentPage
{
    private HttpClient client = new HttpClient();
	public ActualizarPage()
	{
		InitializeComponent();
	}

	private async void btnCambiar_Clicked(object sender, EventArgs e)
	{
		User usuario = new User();
		usuario.Username = txtNombre.Text;
		usuario.Password = txtContra.Text;

        string json = JsonConvert.SerializeObject(usuario);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        string url = "https://nutriciondiego.azurewebsites.net/api/Cuentas/actualizar";
        var respuesta = await client.PostAsync(url, content);
        if (respuesta.IsSuccessStatusCode) {
            await DisplayAlert("Éxito", "La contraseña se ha actualizado exitosamente", "OK");
        }
        else {
            await DisplayAlert("Error", "Ha ocurrido un error al cambiar la contraseña", "OK");
        }
    }
}