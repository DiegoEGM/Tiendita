using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using Tiendita.Models;
using Tiendita.Views;
namespace Tiendita
{
    public partial class MainPage : ContentPage
    {
        private HttpClient client = new HttpClient();
        private string usuario;
        public MainPage(string username)
        {

            usuario = username;
            InitializeComponent();
            imagen.Source = ImageSource.FromUri(new Uri("https://pbs.twimg.com/media/FqgHXsTWcAEwx68.jpg"));

            BindingContext = this;
        }

        private void txtTakis_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://takis.ca/sites/default/files/styles/max_width_1200_no_alt/public/2022-03/BL_TAKISFUEGOCANADA280G_V01_A21_FRONT.png?itok=cma79Hw1"));
        }
        private void txtDoritos_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://media.justo.mx/products/7501011131064_bueno.jpg"));
        }
        private void txtSabritas_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://ayudabartender.com/cdn/shop/products/Sabritas170g_1000x.jpg?v=1610842257"));
        }
        private void txtChurrumais_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://m.media-amazon.com/images/I/61jwz2ZkZxL.jpg"));
        }
        private void txtPaketaxo_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://thisfruta.com/cdn/shop/products/paketaxo_xtra_flamin_hot_560x.jpg?v=1617922309"));
        }
        private void txtCheetos_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://dn1q3bunj3499.cloudfront.net/sku/7500478006175/1.png"));
        }
        private void txtFritos_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://i5.walmartimages.com.mx/gr/images/product-images/img_large/00750047802084L.jpg?odnHeight=612&odnWidth=612&odnBg=FFFFFF"));
        }
        private void txtChips_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://subodega.mx/articulo/4468/01.webp"));
        }
        private void txtChipsJ_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://subodega.mx/articulo/4426/01.webp"));
        }
        private void txtCoca_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://www.benavides.com.mx/media/catalog/product/cache/13134524bf2f7c32f6bea508eba7e730/5/3/531480_2.jpg"));
        }
        private void txtPepsi_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://d1zc67o3u1epb0.cloudfront.net/media/catalog/product/cache/23527bda4807566b561286b47d9060f4/6/8/6869_1.jpg"));
        }
        private void txtFanta_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://chedrauimx.vtexassets.com/arquivos/ids/21500299-800-auto?v=638343972394000000&width=800&height=auto&aspect=true"));
        }
        private void txtSprite_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://www.surtilag.com/cdn/shop/products/REFRESCO_SPRITE_LATA_c1008e43-9c4e-4305-9300-60e53dffa5da_600x.jpg?v=1654727975"));
        }
        private void txtFresca_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://i5.walmartimages.com.mx/gr/images/product-images/img_large/00750105536547L.jpg?odnHeight=612&odnWidth=612&odnBg=FFFFFF"));
        }
        private void txtSquirt_Focused(object sender, EventArgs e)
        {
            imagen.WidthRequest = 300;
            imagen.Source = ImageSource.FromUri(new Uri("https://i5.walmartimages.com.mx/gr/images/product-images/img_large/00750107112007L.jpg?odnHeight=612&odnWidth=612&odnBg=FFFFFF"));
        }
        private void btnComprar_Clicked(object sender, EventArgs e)
        {
            CalcularCompra();
        }

        private async void btnVerifica_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new VerificarCompra(usuario));
        }
        private async void CalcularCompra()
        {
            string url = "https://nutriciondiego.azurewebsites.net/api/Botanas/registro";
            Botana botana = new Botana();
            botana.Precio = txtTakis.Text != null ? int.Parse(txtTakis.Text) * 25 : 0;
            botana.Precio += txtDoritos.Text != null ? int.Parse(txtDoritos.Text) * 20 : 0;
            botana.Precio += txtSabritas.Text != null ? int.Parse(txtSabritas.Text) * 20 : 0;
            botana.Precio += txtChurrumais.Text != null ? int.Parse(txtChurrumais.Text) * 20 : 0;
            botana.Precio += txtPaketaxo.Text != null ? int.Parse(txtPaketaxo.Text) * 20 : 0;
            botana.Precio += txtCheetos.Text != null ? int.Parse(txtCheetos.Text) * 20 : 0;
            botana.Precio += txtFritos.Text != null ? int.Parse(txtFritos.Text) * 20 : 0;
            botana.Precio += txtChips.Text != null ? int.Parse(txtChips.Text) * 20 : 0;
            botana.Precio += txtChipsJ.Text != null ? int.Parse(txtChipsJ.Text) * 20 : 0;
            botana.Precio += txtCoca.Text != null ? int.Parse(txtCoca.Text) * 15 : 0;
            botana.Precio += txtPepsi.Text != null ? int.Parse(txtPepsi.Text) * 15 : 0;
            botana.Precio += txtFanta.Text != null ? int.Parse(txtFanta.Text) * 15 : 0;
            botana.Precio += txtSprite.Text != null ? int.Parse(txtSprite.Text) * 15 : 0;
            botana.Precio += txtFresca.Text != null ? int.Parse(txtFresca.Text) * 15 : 0;
            botana.Precio += txtSquirt.Text != null ? int.Parse(txtSquirt.Text) * 40 : 0;
            botana.Username = usuario;

            string json = JsonConvert.SerializeObject(botana);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var respuesta = await client.PostAsync(url, content);
            if (respuesta.IsSuccessStatusCode)
            {
                await DisplayAlert("Compra completada", "Su total es de " + botana.Precio.ToString(), "Ok");
            }
            else
            {
                await DisplayAlert("Error", "No se pudo realizar la compra", "Ok");
            }
        }
    }
}