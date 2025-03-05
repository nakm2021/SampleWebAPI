using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleWebAPI.Controllers;

namespace SampleWebAPI.Test.Mock
{
    [TestClass]
    public class SampleControllerTests
    {
        private Mock<ISampleService> _mockService;
        private SampleController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockService = new Mock<ISampleService>();
            _controller = new SampleController(_mockService.Object);
        }

        [TestMethod]
        public void GetData_Ok()
        {
            var sampleData = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                sampleData.Add($"Item {i}");
            }
            _mockService.Setup(x => x.GetData()).Returns(sampleData);

            var result = _controller.GetData() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            CollectionAssert.AreEqual(sampleData, (List<string>)result.Value);
        }

        [TestMethod]
        public void GetDataById_Ok()
        {
            var sampleData = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                sampleData.Add($"Item {i}");
            }
            _mockService.Setup(x => x.MyList).Returns(sampleData);
            _mockService.Setup(x => x.GetDataById(10)).Returns(_mockService.Object.MyList[10]);

            var result = _controller.GetDataById(10) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(sampleData[10], (string)result.Value);
        }

        [TestMethod]
        public void AddData_Ok()
        {
            var newItem = Guid.NewGuid().ToString();
            var result = _controller.AddData(newItem) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _mockService.Verify(service => service.AddData(newItem), Times.Once);
        }

        [TestMethod]
        public void AddData_Ng()
        {
            var sampleData = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                sampleData.Add($"Item {i}");
            }
            _mockService.Setup(x => x.MyList).Returns(sampleData);
            var result = _controller.AddData("") as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            _mockService.Verify(service => service.AddData(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void UpdateData_Ok()
        {
            var sampleData = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                sampleData.Add($"Item {i}");
            }
            _mockService.Setup(x => x.MyList).Returns(sampleData);
            var newItem = Guid.NewGuid().ToString();
            var result = _controller.UpdateData(10, newItem) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _mockService.Verify(service => service.UpdateData(10, newItem), Times.Once);
        }

        [TestMethod]
        public void UpdateData_Ng()
        {
            var sampleData = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                sampleData.Add($"Item {i}");
            }
            _mockService.Setup(x => x.MyList).Returns(sampleData);
            var result = _controller.UpdateData(10, "") as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            _mockService.Verify(service => service.UpdateData(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void DeleteData_Ok()
        {
            var sampleData = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                sampleData.Add($"Item {i}");
            }
            _mockService.Setup(x => x.MyList).Returns(sampleData);
            var result = _controller.DeleteData(10) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            _mockService.Verify(service => service.DeleteData(10), Times.Once);
        }

        [TestMethod]
        public void DeleteData_Ng()
        {
            _mockService.Setup(service => service.MyList).Returns(new List<string> { "Missing data......" });
            var result = _controller.DeleteData(9999) as NotFoundObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
            _mockService.Verify(service => service.DeleteData(It.IsAny<int>()), Times.Never);
        }
    }
}