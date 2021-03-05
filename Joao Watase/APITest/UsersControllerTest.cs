using api_cadastro.Controllers;
using api_cadastro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web.Http.Results;
using Xunit;
using System.Linq;
using Moq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace APITest
{
    public class UsersControllerTest
    {
        UsersController _controller;

        public UsersControllerTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var dbContext = new AppDbContext(options);
            var mockLog = new Mock<ILogger<UsersController>>();

            _controller = new UsersController(dbContext, mockLog.Object);
        }

        [Fact]
        public void GetUsers_WhenCalled_ReturnsOk()
        {
            var response = _controller.GetUsers();
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public void GetUser_WhenCalled_ReturnsNotFound()
        {
            var response = _controller.GetUser(null);
            Assert.IsType<NotFoundObjectResult>(response);
        }
        [Fact]
        public void AddUser_WhenCalled_ReturnsOk()
        {
            string uniqueName = Guid.NewGuid().ToString();
            PostData userToAdd = new PostData(uniqueName, 10, "sobrenome");
            var response = _controller.AddUser(userToAdd);
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public void DelUser_WhenCalled_ReturnsNotFound()
        {
            var response = _controller.DelUser(Guid.NewGuid().ToString());
            Assert.IsType<NotFoundObjectResult>(response);
        }
        [Fact]
        public void DelUser_WhenCalled_ReturnsOk()
        {
            string uniquename = Guid.NewGuid().ToString();
            PostData newuser = new PostData(uniquename, 1, null);
            _controller.AddUser(newuser);

            var users = _controller.GetUsers() as ObjectResult;
            var usersContent = users.Value as DbSet<User>;
            var usersArray = usersContent.ToArray();
            var userToDelete = usersArray.Where(x => x.FirstName == uniquename).SingleOrDefault();
            var userId = userToDelete.Id;
            var response = _controller.DelUser(userId);
            Assert.IsType<OkObjectResult>(response);
        }
    }
}