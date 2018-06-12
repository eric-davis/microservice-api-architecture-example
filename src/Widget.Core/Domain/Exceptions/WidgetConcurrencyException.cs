namespace EDS.Widgets.Domain.Exceptions
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The widget concurrency exception.
    /// </summary>
    public sealed class WidgetConcurrencyException : Exception
    {
        /// <summary>
        /// The default message.
        /// </summary>
        private const string DefaultMessage = "TBD";

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetConcurrencyException" /> class.
        /// </summary>
        public WidgetConcurrencyException(string message, Exception innerException)
            : base(message, innerException)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetConcurrencyException" /> class.
        /// </summary>
        public WidgetConcurrencyException(string message)
            : base(message)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetConcurrencyException" /> class.
        /// </summary>
        public WidgetConcurrencyException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetConcurrencyException" /> class.
        /// </summary>
        public WidgetConcurrencyException()
            : base(DefaultMessage)
        {
            // Nothing to do...
        }
    }
}
