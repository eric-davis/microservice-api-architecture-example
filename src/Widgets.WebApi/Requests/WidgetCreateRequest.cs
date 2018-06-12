namespace EDS.Widgets.WebApi.Requests
{
    /// <summary>
    /// The widget create request.
    /// </summary>
    public sealed class WidgetCreateRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetCreateRequest"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="weightInGrams">
        /// The weight in grams.
        /// </param>
        public WidgetCreateRequest(string name, string description, double weightInGrams)
        {
            this.Name = name;
            this.Description = description;
            this.WeightInGrams = weightInGrams;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the weight in grams.
        /// </summary>
        public double WeightInGrams { get; }
    }
}
