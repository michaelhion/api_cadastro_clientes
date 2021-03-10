using Goiabeira_Xamarin_Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Goiabeira_Xamarin_Mobile.Repositories
{
    public class ServiceRepository
    {
        public async Task<string> Cadastrar(Usuario NovoUsuario)
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri(string.Format("http://IP_V4:8000/api/Usuario"));
                var content = new StringContent(JsonConvert.SerializeObject(NovoUsuario), Encoding.UTF8, "application/json");
                
                HttpResponseMessage response = await client.PostAsync(uri, content);

                return response.ReasonPhrase;    
            }
        }
    }
}
