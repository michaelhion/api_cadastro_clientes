using Goiabinha_WebApi;
using Goiabinha_WebApi.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest_Goiabeira
{
    [TestCaseOrderer("XUnitTest_Goiabeira.PriorityOrderer", "XUnitTest_Goiabeira")]
    public class UnitTest1
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UnitTest1()
        {
            _server = new TestServer(new WebHostBuilder()
          .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        //Teste para retornar Not Found por ter nenhum usu�rio cadastrado
        [Fact, TestPriority(1)]
        public async Task Get_Return_Not_Found()
        {
            // Act
            var response = await _client.GetAsync(requestUri: "/api/Usuario");
            // Assert
            Assert.Equal("Not Found", response.ReasonPhrase.ToString());
        }

        //Teste para cadastrar novo usu�rio
        [Fact, TestPriority(2)]
        public async Task Post_Return_Created_Create_user()
        {
            dynamic MyDynamic = new ExpandoObject();

            MyDynamic.firstName = "Henrique";
            MyDynamic.surname = "Last";
            MyDynamic.age = 19;
            // Act
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(MyDynamic, options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(requestUri: "/api/Usuario", content: stringContent);
            // Assert
            Assert.Equal("Created", response.ReasonPhrase.ToString());
        }

        //Teste para retornar lista de usu�rios 
        [Fact, TestPriority(3)]
        public async Task Get_Return_OK_List_Users()
        {
            // Act
            var response = await _client.GetAsync(requestUri: "/api/Usuario");
            string responseString = response.ReasonPhrase.ToString();
            // Assert
            Assert.Equal("OK", responseString);
        }

        //Teste para atualizar um usu�rio
        [Fact, TestPriority(4)]
        public async Task Put_Return_Accepted_Update_Name()
        {
            var responseMessage = await _client.GetAsync(requestUri: "/api/Usuario");
            var respost = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var objetoResposta = JsonSerializer.Deserialize<List<Usuarios>>(respost);

            objetoResposta[0].firstName = "Robert";
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(objetoResposta[0], options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(requestUri: "/api/Usuario", content: stringContent);

            Assert.Equal("Accepted", response.ReasonPhrase.ToString());
        }

        //Teste para buscar um usu�rio pelo id
        [Fact, TestPriority(5)]
        public async Task Get_Return_OK_And_User()
        {
            var responseMessage = await _client.GetAsync(requestUri: "/api/Usuario");
            var respost = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var objetoResposta = JsonSerializer.Deserialize<List<Usuarios>>(respost);

            var response = await _client.GetAsync(requestUri: $"/api/Usuario/{objetoResposta[0].id}");

            Assert.Equal("OK", response.ReasonPhrase.ToString());
        }

        //Teste para dar um erro por o id est� errado.
        [Fact, TestPriority(6)]
        public async Task Delete_Return_Forbidden_Id_Invalid()
        {
            var response = await _client.DeleteAsync(requestUri: "/api/Usuario/3929-323si23-jakc-osa");
            Assert.Equal("Forbidden", response.ReasonPhrase.ToString());
        }

        //Teste para deletar um usu�rio.
        [Fact, TestPriority(7)]
        public async Task Delete_Return_Accepted()
        {
            var responseMessage = await _client.GetAsync(requestUri: "/api/Usuario");
            var respost = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var objetoResposta = JsonSerializer.Deserialize<List<Usuarios>>(respost);

            var response = await _client.DeleteAsync(requestUri: $"/api/Usuario/{objetoResposta[0].id}");

            Assert.Equal("Accepted", response.ReasonPhrase.ToString());
        }


        //Teste para dar um erro na hora de cadastrar um usu�rio por est� com nome vazio.
        [Fact, TestPriority(8)]
        public async Task Post_Return_Bad_Rquest_Name_Invalid()
        {
            dynamic MyDynamic = new ExpandoObject();

            MyDynamic.firstName = "";
            MyDynamic.surname = "Last";
            MyDynamic.age = 19;
            // Act
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(MyDynamic, options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(requestUri: "/api/Usuario", content: stringContent);
            // Assert
            Assert.Equal("Bad Request", response.ReasonPhrase.ToString());
        }

        //Teste para dar erro, por id est� errado na hora de atualizar
        [Fact, TestPriority(9)]
        public async Task Put_Return_BadRequest_Id_Invalid()
        {
            dynamic MyDynamic = new ExpandoObject();

            MyDynamic.id = "392944-32jdsds-3232-dsds2";
            MyDynamic.firstName = "Henrique";
            MyDynamic.surname = "Last";
            MyDynamic.age = 19;

            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(MyDynamic, options);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(requestUri: "/api/Usuario", content: stringContent);

            Assert.Equal("Bad Request", response.ReasonPhrase.ToString());
        }

        //Teste para dar erro, por id est� errado.
        [Fact, TestPriority(10)]
        public async Task Get_Return_BadRequest_Id_Invalid()
        {
            string id = "392944-32jdsds-3232-dsds2";

            var response = await _client.GetAsync(requestUri: $"/api/Usuario/{id}");

            Assert.Equal("Bad Request", response.ReasonPhrase.ToString());
        }
    }
}
