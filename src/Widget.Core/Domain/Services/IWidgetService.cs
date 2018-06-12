namespace EDS.Widgets.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EDS.Widgets.Domain.Models;

    /// <summary>
    /// The WidgetService interface.
    /// </summary>
    public interface IWidgetService
    {
        /// <summary>
        /// Gets all widgets.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the <see cref="IEnumerable{Widget}"/>.
        /// </returns>
        Task<IEnumerable<Widget>> GetAllWidgetsAsync();

        /// <summary>
        /// Gets a widget by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the <see cref="Widget"/>, if found.
        /// </returns>
        Task<Widget> GetWidgetByIdAsync(Guid id);

        /// <summary>
        /// Creates a new widget.
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
        Task<Widget> CreateWidgetAsync(Widget widget, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Renames a widget.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="version">
        /// The current version.
        /// </param>
        /// <param name="name">
        /// The new name.
        /// </param>
        /// <param name="description">
        /// The new description.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that represents the asynchronous operation.
        /// The task result contains the updated <see cref="Widget"/>.
        /// </returns>
        Task<Widget> RenameWidgetAsync(
            Guid id,
            int version,
            string name,
            string description = null,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
