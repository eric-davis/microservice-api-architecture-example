namespace Test.WebApi.Unit.Controllers
{
    using System;

    using EDS.Widgets.Domain.Services;
    using EDS.Widgets.WebApi.Controllers;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WidgetsControllerTests
    {
        [TestInitialize]
        public void Init()
        {

        }

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
    }
}
