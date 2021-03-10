using ApiLite;
using ApiLite.Controllers;
using ApiLite.Models;
using IntelitraderAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
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
            var response = await _client.PostAsync("/api/Entidade", new StringContent(JsonConvert.SerializeObject(
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

        //Erro ao tentar deletar 
        //[Fact]
        //public async Task Values_Delete_ReturnOKResponse()
        //{

        //    var request = await _client.GetAsync(requestUri: "/api/Entidade");
        //    var response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        //    var newEntidade = System.Text.Json.JsonSerializer.Deserialize<List<Entidade>>(response);


        //    var responseId = await _client.DeleteAsync(requestUri: $"/api/entidade/{newEntidade[0].Id}");

        //    Assert.Equal(HttpStatusCode.Accepted, responseId.StatusCode);

        //}

        
        //[Fact]
        //public async Task Value_Put_ReturnUpdatedResponse()
        //{
        //    var request = await _client.GetAsync(requestUri: "/api/Entidade");
        //    var response = request.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        //    var newEntidade = System.Text.Json.JsonSerializer.Deserialize<List<Entidade>>(response);

        //    string collectionResult = System.Text.Json.JsonSerializer.Serialize(newEntidade[0], options);

        //    var push = new StringContent(collectionResult, Encoding.UTF8, "application/json");

        //    var putActiong = await _client.PutAsync(requestUri: $"/api/entidade/{newEntidade[0].Id}", push);

        //    Assert.Equal(HttpStatusCode.NoContent, putActiong.StatusCode);
        //}


    }
}
