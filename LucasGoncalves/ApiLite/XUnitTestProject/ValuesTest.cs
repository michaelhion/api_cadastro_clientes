using ApiLite;
using ApiLite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        private HttpClient _client;

        private TestServer _server;

        public UnitTest1()
        {
            //Faz a Conexao com o db, usando as configurações da startup
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();

        }

        [Fact]
        public async Task Values_Post_ReturnCreatedResponse()
        {
            var response = await _client.PostAsync("/api/Entidade", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(
                new Entidade()
                { FirstName = "Lucas", SurName = "Goncalves", Age = 17, CreationDate = DateTime.Now }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Values_Get_ReturnOkResponse()
        {
            var response = await _client.GetAsync(requestUri: "/api/Entidade");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task GetById_ReturnokResponse()
        {
            var request = await _client.GetAsync(requestUri: "/api/Entidade");
            var response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var newEntidade = System.Text.Json.JsonSerializer.Deserialize<List<Entidade>>(response);

            var responseId = await _client.GetAsync(requestUri: $"/api/entidade/{newEntidade[0].Id}");

            Assert.Equal(HttpStatusCode.OK, responseId.StatusCode);

        }

        [Fact]
        public async Task values_delete_returNotFound()
        {

            var request = await _client.GetAsync(requestUri: "/api/entidade");
            var responseGet = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var newEntidade = JsonConvert.DeserializeObject<List<Entidade>>(responseGet);


            var test = await _client.DeleteAsync(requestUri: $"/api/entidade/{newEntidade[0].Id}");

            Assert.Equal(HttpStatusCode.OK, test.StatusCode);

        }


        [Fact]
        public async Task Value_Put_ReturnOkResponse()
        {
            var request = await _client.GetAsync(requestUri: "/api/Entidade");
            var response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var newEntidade = JsonConvert.DeserializeObject<List<Entidade>>(response);

            var putActiong = await _client.PutAsync(requestUri: $"/api/entidade/{newEntidade[0].Id}", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(
                new Entidade()
                { FirstName = "Lucas", SurName = "Goncalves", Age = 17, CreationDate = DateTime.Now }), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, putActiong.StatusCode);
        }


    }
}
