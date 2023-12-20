using Xunit;
using Test.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Test.BLL;
using Test.DAL;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Xunit.Sdk;
using Xunit.Extensions.Ordering;

namespace Test.API.Controllers.Tests
{
    public class TaskControllerTests
    {
        private Guid _taskId = new Guid();
        

        [Fact, Order(0)]
        public void CreateTaskAsyncTestAsync()
        {
            //Arrange
            var mocService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<TaskController>>();

            var controller = new TaskController(mocService.Object, mockLogger.Object);

            //Act
            var result = controller.CreateTaskAsync().Result;
            var acceptRes = result as AcceptedResult;
            _taskId = (Guid)acceptRes.Value;

            //Assert
            Assert.NotNull(result);
            // Assert.NotEqual(new Guid(), (Guid)acceptRes.Value);
            Assert.Equal(202, acceptRes.StatusCode);
        }

        [Fact, Order(1)]
        public void GetTaskAsyncOKTest()
        {
            //Arrange
            var mocService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<TaskController>>();

            var controller = new TaskController(mocService.Object, mockLogger.Object);

            //Act
            var result = controller.GetTaskAsync(_taskId).Result;
            var okRes = result as OkResult;


            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, okRes.StatusCode);
        }

        [Fact]
        public void GetTaskAsyncNotFoundTest()
        {
            //Arrange
            var mocService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<TaskController>>();

            var controller = new TaskController(mocService.Object, mockLogger.Object);

            //Act
            var result = controller.GetTaskAsync(new Guid("89b3fcbe-a648-4b6e-90b3-e6efeed18cfd")).Result;
            var nfRes = result as NotFoundResult;

            //Assert
            Assert.Equal(404, nfRes.StatusCode);
        }

        [Fact]
        public void GetTaskAsyncBadRequestTest()
        {
            //Arrange
            var mocService = new Mock<ITaskService>();
            var mockLogger = new Mock<ILogger<TaskController>>();

            var controller = new TaskController(mocService.Object, mockLogger.Object);

            //Act
            var result = controller.GetTaskAsync(_taskId).Result;
            var brRes = result as BadRequestResult;

            //Assert
            Assert.Equal(400, brRes.StatusCode);
        }
    }
}