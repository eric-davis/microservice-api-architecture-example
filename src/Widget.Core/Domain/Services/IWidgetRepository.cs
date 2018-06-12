namespace EDS.Widgets.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EDS.Widgets.Domain.Models;

    /// <summary>
    /// The WidgetRepository interface.
    /// </summary>
    public interface IWidgetRepository
    {
        /// <summary>
        /// Adds a new widget.
        /// </summary>
        /// <param name="widget">
        /// The new widget.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the newly created <see cref="Widget"/>.
        /// </returns>
        Task<Widget> AddAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all widgets.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the matching <see cref="IEnumerable{Widget}"/>, if found.
        /// </returns>
        Task<IEnumerable<Widget>> GetAllAsync();

        /// <summary>
        /// Gets a widget by id.
        /// </summary>
        /// <param name="id">
        /// The widget id.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the matching <see cref="Widget"/>, if found.
        /// </returns>
        Task<Widget> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates a widget.
        /// </summary>
        /// <param name="widget">
        /// The widget.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// </returns>
        Task UpdateAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a widget.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the deleted <see cref="Widget"/>, if found.
        /// </returns>
        Task<Widget> DeleteAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    }
}
