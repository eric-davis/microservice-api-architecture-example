namespace EDS.Widgets.Domain.Exceptions
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The widget creation exception.
    /// </summary>
    public sealed class WidgetCreationException : Exception
    {
        /// <summary>
        /// The default message.
        /// </summary>
        private const string DefaultMessage = "Widget creation failed.";

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetCreationException" /> class.
        /// </summary>
        public WidgetCreationException(string message, Exception innerException)
            : base(message, innerException)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetCreationException" /> class.
        /// </summary>
        public WidgetCreationException(string message)
            : base(message)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetCreationException" /> class.
        /// </summary>
        public WidgetCreationException(Exception innerException)
            : base(DefaultMessage, innerException)
        {
            // Nothing to do...
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetCreationException" /> class.
        /// </summary>
        public WidgetCreationException()
            : base(DefaultMessage)
        {
            // Nothing to do...
        }
    }
}
