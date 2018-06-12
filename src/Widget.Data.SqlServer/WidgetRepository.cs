namespace EDS.Widgets.Data.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EDS.Widgets.Domain.Models;
    using EDS.Widgets.Domain.Services;

    /// <inheritdoc />
    /// <summary>
    /// The widget repository.
    /// </summary>
    public sealed class WidgetRepository : IWidgetRepository
    {
        /// <inheritdoc />
        public Task<Widget> AddAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<IEnumerable<Widget>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Widget> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task UpdateAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Widget> DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
