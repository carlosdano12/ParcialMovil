using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace registroNotas
{
    class UsuarioManager
    {

        public List<Usuario> Usuarios { get; set; }
        const string url = "http://10.0.2.2/api/api.php";

        private async Task<HttpClient> get()
        {

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");
            return cliente;
        }

        public async Task<List<Usuario>> GetAll()
        {


            HttpClient client = await get();
            string result = await client.GetStringAsync(url);

            return JsonConvert.DeserializeObject<List<Usuario>>(result);
        }

        public async Task<Usuario> Add(string nombre, string apellido, string correo, string contraseña)
        {
            Usuario user = new Usuario()
            {
                id = 0,
                nombre = nombre,
                apellido = apellido,
                correo = correo,
                contraseña= contraseña,
            };
            HttpClient cliente = await get();
            var response = await cliente.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());

        }
    }
}
