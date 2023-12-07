using Newtonsoft.Json;
using System.Net.Http.Headers;
using Tiendita.Models;

namespace Tiendita.Views;

public partial class VerificarCompra : ContentPage
{
	public int id = -1;

    private readonly HttpClient client = new HttpClient();
    public VerificarCompra(string usuario)
	{
		InitializeComponent();
		ObtenerDatos(usuario);
	}

	private async void ObtenerDatos(string usuario)
	{
        string url = "https://nutriciondiego.azurewebsites.net/api/Botanas/lista";

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("bearer", await SecureStorage.GetAsync("token"));

        var respuesta = client.GetAsync(url);

        if (!respuesta.Result.IsSuccessStatusCode)
        {
            await DisplayAlert("Error", "No se pudo obtener los datos", "Ok"); 
            return;
        }
        else
        {
            var json = await respuesta.Result.Content.ReadAsStringAsync();
            List<Botana> lista = JsonConvert.DeserializeObject<List<Botana>>(json);
            var compras = lista.Where(x => x.Username == usuario).ToList();
            lstCompras.ItemsSource = compras;
        }
    }

	private void lstCompras_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
		id = ((Botana)e.SelectedItem).Id;
	}

	private async void btnBorrar_Clicked(object sender, EventArgs e)
	{
        string url = "https://nutriciondiego.azurewebsites.net/api/Botanas/delete/" + id.ToString();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("bearer", await SecureStorage.GetAsync("token"));
        var respuesta = await client.DeleteAsync(url);
        if (respuesta.IsSuccessStatusCode)
        {
            await DisplayAlert("Exito", "Se ha borrado la compra exitosamente", "Ok");
        }
        else
        {
            await DisplayAlert("Error", "No se pudo borrar la compra", "Ok");
        }
    }
}