namespace EDS.Widgets.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ArgSentry;

    using EDS.Widgets.Domain.Models;
    using EDS.Widgets.Domain.Services;
    using EDS.Widgets.Domain.ValueTypes;
    using EDS.Widgets.WebApi.Requests;

    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    /// <summary>
    /// The widgets controller.
    /// </summary>
    [Route("/")]
    public class WidgetsController : Controller
    {
        /// <summary>
        /// The widget service.
        /// </summary>
        private readonly IWidgetService widgetService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetsController"/> class.
        /// </summary>
        /// <param name="widgetService">
        /// The widget service.
        /// </param>
        public WidgetsController(IWidgetService widgetService)
        {
            Prevent.NullObject(widgetService, nameof(widgetService));
            this.widgetService = widgetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWidgets()
        {
            var widgets = await this.widgetService.GetAllWidgetsAsync();
            return this.Json(widgets);
        }

        /// <summary>
        /// Gets a widget by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet("/id:guid")]
        public async Task<IActionResult> GetWidgetByIdAsync([FromRoute] Guid id)
        {
            var widget = await this.widgetService.GetWidgetByIdAsync(id);
            return widget == null ? this.NotFound(id) : (IActionResult)this.Json(widget);
        }

        /// <summary>
        /// Creates a new widget.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the <see cref="IActionResult"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateWidgetAsync(WidgetCreateRequest request)
        {
            Prevent.NullObject(request, nameof(request));

            var newWidget = Widget.Create(request.Name, request.Description, new Weight(request.WeightInGrams));
            var result = await this.widgetService.CreateWidgetAsync(newWidget);

            // TODO: Create widget GET Uri...
            return this.Created(string.Empty, result);
        }
    }
}
