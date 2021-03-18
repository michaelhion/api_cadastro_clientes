using api_cadastro_cliente;
using api_cadastro_cliente.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xunit_test
{
    [TestCaseOrderer("xunit_test.PriorityOrderer", "xunit_test")]
    public class UnitTest1
    {
        protected TestServer _testServer;

        public UnitTest1()
        {

            var options = new DbContextOptionsBuilder<ClienteContexto>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ClienteContexto(options);

            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();

            _testServer = new TestServer(webBuilder);
        }

        [Fact, TestPriority(3)]
        public async Task listarClients_return_OK()
        {
            
            var resp = await _testServer.CreateRequest("/api/Clientes").SendAsync("GET");

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact, TestPriority(2)]
        public async Task buscarPorId_return_OK()
        {
            
            var resp = await _testServer.CreateRequest("/api/Clientes/primeiro").SendAsync("GET");

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact, TestPriority(1)]
        public async Task inserirCliente_return_Create()
        {
            
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Clientes");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                {"Id","primeiro" },
                {"firstName", "Mellissa"},
                {"surname", "thomas"},
                {"age", "1" }

            }), Encoding.UTF8, "application/json");

            var client = _testServer.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact, TestPriority(4)]
        public async Task editarCliente_return_Create()
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "/api/Clientes/primeiro");
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                {"firstName", "Mellissa fofuchinha"},
                {"surname", "thomas"},
                {"age", "1" }

            }), Encoding.UTF8, "application/json");

            var client = _testServer.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Fact, TestPriority(5)]
        public async Task deletarCliente_return_OK()
        { 
            var client = _testServer.CreateClient();
            client.DefaultRequestHeaders.Clear();
            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/Clientes/primeiro");

            var response = await client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
