namespace EDS.Widgets.Domain.ValueTypes
{
    using ArgSentry;

    using Newtonsoft.Json;

    /// <summary>
    /// The weight value type.
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Weight"/> class.
        /// </summary>
        /// <param name="grams">
        /// The weight in grams.
        /// </param>
        [JsonConstructor]
        public Weight(double grams)
        {
            Prevent.ValueLessThanOrEqualTo(grams, 0, nameof(grams));
            this.Grams = grams;
        }

        /// <summary>
        /// Gets the weight in grams.
        /// </summary>
        [JsonProperty]
        public double Grams { get; }

        /// <summary>
        /// Gets the weight in ounces.
        /// </summary>
        [JsonIgnore]
        public double Ounces => this.Grams * 0.035274;

        /// <summary>
        /// Gets the weight in pounds.
        /// </summary>
        [JsonIgnore]
        public double Pounds => this.Grams * 0.00220462;
    }
}
