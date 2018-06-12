namespace EDS.Widgets.Data.InMemory
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EDS.Widgets.Domain.Exceptions;
    using EDS.Widgets.Domain.Models;
    using EDS.Widgets.Domain.Services;

    /// <inheritdoc />
    /// <summary>
    /// The widget repository.
    /// </summary>
    public sealed class WidgetRepository : IWidgetRepository
    {
        /// <summary>
        /// The in-memory widget data store.
        /// </summary>
        private static readonly ConcurrentDictionary<Guid, Widget> WidgetDataStore;

        /// <summary>
        /// Initializes static members of the <see cref="WidgetRepository"/> class.
        /// </summary>
        static WidgetRepository()
        {
            WidgetDataStore = new ConcurrentDictionary<Guid, Widget>();
        }

        /// <inheritdoc />
        /// <exception cref="WidgetCreationException" />
        public Task<Widget> AddAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                if (WidgetDataStore.TryAdd(widget.Id, widget))
                {
                    return Task.FromResult(widget);
                }
            }
            catch (Exception ex)
            {
                throw new WidgetCreationException(ex);
            }

            throw new WidgetCreationException($"Widget creation failed. Widget ID already exists in the system: {widget.Id}");
        }

        /// <inheritdoc />
        public Task<IEnumerable<Widget>> GetAllAsync()
        {
            return Task.FromResult(WidgetDataStore.Values.AsEnumerable());
        }

        /// <inheritdoc />
        public Task<Widget> GetByIdAsync(Guid id)
        {
            WidgetDataStore.TryGetValue(id, out var widget);
            return Task.FromResult(widget);
        }

        /// <inheritdoc />
        /// <exception cref="WidgetNotFoundException" />
        /// <exception cref="WidgetConcurrencyException" />
        public Task UpdateAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (WidgetDataStore.TryGetValue(widget.Id, out var existingWidget) == false)
            {
                throw new WidgetNotFoundException();
            }

            if (WidgetDataStore.TryUpdate(widget.Id, widget, existingWidget))
            {
                return Task.CompletedTask;
            }

            throw new WidgetConcurrencyException();
        }

        /// <inheritdoc />
        /// <exception cref="WidgetNotFoundException" />
        public Task<Widget> DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (WidgetDataStore.TryRemove(id, out var widget))
            {
                return Task.FromResult(widget);
            }

            throw new WidgetNotFoundException();
        }
    }
}
