using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumirAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Empresa : ContentPage
    {
        public Empresa()
        {
            InitializeComponent();
            LlenarTransportes();
        }

        private async Task LlenarTransportes()
        {
            HttpClient client = new HttpClient();

            
            HttpResponseMessage request = await client.GetAsync("http://apisteven.somee.com/api/Transportes");

            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<List<Transportes>>(responseJson);

                listaTransportes.ItemsSource = response;
            }
        }
    }
}