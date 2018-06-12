namespace EDS.Widgets.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ArgSentry;

    using EDS.Widgets.Domain.Exceptions;
    using EDS.Widgets.Domain.Models;

    /// <inheritdoc />
    /// <summary>
    /// The widget service.
    /// </summary>
    public sealed class WidgetService : IWidgetService
    {
        /// <summary>
        /// The widget repository.
        /// </summary>
        private readonly IWidgetRepository widgetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetService"/> class.
        /// </summary>
        /// <param name="widgetRepository">
        /// The widget repository.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if widgetRepository is NULL.
        /// </exception>
        public WidgetService(IWidgetRepository widgetRepository)
        {
            Prevent.NullObject(widgetRepository, nameof(widgetRepository));
            this.widgetRepository = widgetRepository;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Widget>> GetAllWidgetsAsync()
        {
            return await this.widgetRepository.GetAllAsync();
        }

        /// <inheritdoc />
        public async Task<Widget> GetWidgetByIdAsync(Guid id)
        {
            return await this.widgetRepository.GetByIdAsync(id);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// if widget is NULL.
        /// </exception>
        public async Task<Widget> CreateWidgetAsync(
            Widget widget,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Prevent.NullObject(widget, nameof(widget));

            // TODO: Validate widget before creating...
            return await this.widgetRepository.AddAsync(widget, cancellationToken);
        }

        /// <inheritdoc />
        /// <exception cref="WidgetNotFoundException">
        /// if the widget ID doesn't exist.
        /// </exception>
        /// <exception cref="WidgetConcurrencyException">
        /// if the widget has been updated since being requested.
        /// </exception>
        public async Task<Widget> RenameWidgetAsync(
            Guid id,
            int version,
            string name,
            string description = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var widget = await this.widgetRepository.GetByIdAsync(id);
            if (widget == null)
            {
                throw new WidgetNotFoundException(id);
            }

            if (widget.Version != version)
            {
                throw new WidgetConcurrencyException();
            }

            widget.Rename(name, description);
            await this.widgetRepository.UpdateAsync(widget, cancellationToken);

            return await this.widgetRepository.GetByIdAsync(widget.Id);
        }
    }
}
