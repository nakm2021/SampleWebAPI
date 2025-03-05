using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Controllers;

namespace SampleWebAPI.Test
{
    [TestClass]
    public class SampleControllerTests
    {
        private SampleController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new SampleController();
        }

        [TestMethod]
        public void GetData_ReturnsAllData()
        {
            // Act
            var result = _controller.GetData() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsInstanceOfType(result.Value, typeof(List<string>));
        }

        [TestMethod]
        public void GetDataById_ReturnsCorrectData()
        {
            // Act
            var result = _controller.GetDataById(0) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void GetDataById_ReturnsNotFound()
        {
            // Act
            var result = _controller.GetDataById(999) as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void AddData_ValidData_ReturnsOk()
        {
            // Act
            var result = _controller.AddData("TestItem") as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void AddData_EmptyData_ReturnsNotFound()
        {
            // Act
            var result = _controller.AddData("") as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void UpdateData_ValidData_ReturnsOk()
        {
            _controller.AddData("ItemToUpdate");

            // Act
            var result = _controller.UpdateData(0, "UpdatedItem") as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void DeleteData_ValidId_ReturnsOk()
        {
            _controller.AddData("ItemToDelete");

            // Act
            var result = _controller.DeleteData(0) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void DeleteData_InvalidId_ReturnsNotFound()
        {
            // Act
            var result = _controller.DeleteData(999) as NotFoundObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
