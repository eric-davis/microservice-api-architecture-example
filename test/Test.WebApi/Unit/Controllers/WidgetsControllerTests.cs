namespace Test.WebApi.Unit.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EDS.Widgets.Domain.Models;
    using EDS.Widgets.Domain.Services;
    using EDS.Widgets.Domain.ValueTypes;
    using EDS.Widgets.WebApi.Controllers;
    using EDS.Widgets.WebApi.Requests;

    using FluentAssertions;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class WidgetsControllerTests
    {
        private List<Widget> testData;
        private Mock<IWidgetService> widgetServiceMock;

        [TestInitialize]
        public void Init()
        {
            this.testData = GetTestData();

            this.widgetServiceMock = new Mock<IWidgetService>();

            this.widgetServiceMock.Setup(x => x.GetAllWidgetsAsync()).ReturnsAsync(this.testData);

            this.widgetServiceMock.Setup(x => x.GetWidgetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => this.testData.SingleOrDefault(x => x.Id == id));
        }

        #region Constructor Tests

        [TestMethod]
        public void Constructor_WhenWidgetServiceIsNull_ShouldThrow()
        {
            // Arrange
            IWidgetService widgetService = null;

            // Act
            Action act = () => new WidgetsController(widgetService);

            // Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("widgetService");
        }

        [TestMethod]
        public void Constructor_WhenAllParametersAreValid_ShouldReturnInstance()
        {
            // Arrange
            var widgetService = this.widgetServiceMock.Object;

            // Act
            var result = new WidgetsController(widgetService);

            // Assert
            result.Should().NotBeNull().And.BeOfType<WidgetsController>();
        }

        #endregion

        #region GetAllWidgetsAsync Tests

        [TestMethod]
        public void GetAllWidgetsAsync_WhenWidgetsExist_ShouldReturnOkObjectResultWithAllWidgets()
        {
            // Arrange
            var controller = this.GetController();
            var expectedResult = this.testData;
            
            // Act
            var result = controller.GetAllWidgetsAsync().Result;

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();

            result.As<OkObjectResult>().Value.Should().BeOfType<List<Widget>>();
            result.As<OkObjectResult>().Value.As<List<Widget>>().Should().Contain(expectedResult).And
                .HaveCount(expectedResult.Count);

            this.widgetServiceMock.Verify(x => x.GetAllWidgetsAsync(), Times.Once);
        }

        [TestMethod]
        public void GetAllWidgetsAsync_WhenNoWidgetsExist_ShouldReturnEmptyOkObjectResult()
        {
            // Arrange
            this.testData.Clear();
            var controller = this.GetController();

            // Act
            var result = controller.GetAllWidgetsAsync().Result;

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeOfType<List<Widget>>();
            result.As<OkObjectResult>().Value.As<List<Widget>>().Should().BeEmpty();
            this.widgetServiceMock.Verify(x => x.GetAllWidgetsAsync(), Times.Once);
        }

        #endregion

        #region GetWidgetByIdAsync Tests

        [TestMethod]
        public void GetWidgetByIdAsync_WhenIdExists_ShouldReturnOkObjectResultWithWidget()
        {
            // Arrange
            var controller = this.GetController();
            var widgetIdx = new Random((int)DateTime.Now.Ticks).Next(0, this.testData.Count - 1);
            var expectedResult = this.testData[widgetIdx];
            var widgetId = expectedResult.Id;

            // Act
            var result = controller.GetWidgetByIdAsync(widgetId).Result;

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void GetWidgetByIdAsync_WhenIdDoesNotExist_ShouldReturnNotFoundResult()
        {
            // Arrange
            var controller = this.GetController();
            var widgetId = Guid.NewGuid();

            // Act
            var result = controller.GetWidgetByIdAsync(widgetId).Result;

            // Assert
            result.Should().NotBeNull().And.BeOfType<NotFoundObjectResult>();
            result.As<NotFoundObjectResult>().Value.Should().Be(widgetId);
        }

        #endregion

        #region CreateWidgetAsync Tests

        [TestMethod]
        public void CreateWidgetAsync_WhenRequestIsNull_ShouldThrow()
        {
            // Arrange
            var controller = this.GetController();
            WidgetCreateRequest request = null;

            // Act
            Action act = () => controller.CreateWidgetAsync(request).Wait();

            // Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("request");
        }

        #endregion

        private static List<Widget> GetTestData()
        {
            const int TotalWidgetCount = 5;
            var data = new List<Widget>();
            for (var i = 1; i <= TotalWidgetCount; i++)
            {
                data.Add(Widget.Create($"Widget #{i}", $"This is widget #{i}", new Weight(i * 100)));
            }

            return data;
        }

        private WidgetsController GetController()
        {
            return new WidgetsController(this.widgetServiceMock.Object);
        }
    }
}
