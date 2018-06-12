namespace EDS.Widgets.Domain.Exceptions
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The widget not found exception.
    /// </summary>
    public sealed class WidgetNotFoundException : Exception
    {
        /// <summary>
        /// The default message.
        /// </summary>
        private const string DefaultMessage = "The specified widget was not found.";

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetNotFoundException" /> class.
        /// </summary>
        public WidgetNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetNotFoundException" /> class.
        /// </summary>
        public WidgetNotFoundException(string message)
            : base(message)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetNotFoundException" /> class.
        /// </summary>
        public WidgetNotFoundException(Exception innerException)
            : base(innerException.Message, innerException)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetNotFoundException" /> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public WidgetNotFoundException(Guid id)
            : base($"{DefaultMessage} - ID: {id}")
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetNotFoundException" /> class.
        /// </summary>
        public WidgetNotFoundException()
            : base(DefaultMessage)
        {
            // Nothing to do...
        }
    }
}
