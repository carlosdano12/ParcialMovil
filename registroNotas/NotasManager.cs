using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace registroNotas
{
    class NotasManager
    {
        public List<Notas> notas { get; set; }
        const string url = "http://10.0.2.2/api/api_notas.php";

        private async Task<HttpClient> get()
        {

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("Accept", "application/json");
            return cliente;
        }

        public async Task<List<Notas>> GetAll(int id)
        {


            HttpClient client = await get();
            string result = await client.GetStringAsync(url+ "?id_usuario="+id);

            return JsonConvert.DeserializeObject<List<Notas>>(result);
        }

        public async Task<Notas> Add(Notas nota)
        {
            Console.WriteLine("Aqui MET3");
            Notas notaAlumno = nota;
            Console.WriteLine("Aqui MET 4");
            HttpClient cliente = await get();
            
            var response = await cliente.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(notaAlumno), Encoding.UTF8, "application/json"));
            
            return JsonConvert.DeserializeObject<Notas>(await response.Content.ReadAsStringAsync());

        }

        public async Task update(Notas nota)
        {
            HttpClient client = await get();
            await client.PutAsync(url + "?idAlumno=" + nota.idAlumno, new StringContent(JsonConvert.SerializeObject(nota), Encoding.UTF8, "application/json"));
        }

        public async Task delete(int idAlumno)
        {
            HttpClient client = await get();
            await client.DeleteAsync(url + "?idAlumno=" + idAlumno);
        }

    }
}
