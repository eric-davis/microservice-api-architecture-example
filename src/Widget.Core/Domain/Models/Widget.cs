namespace EDS.Widgets.Domain.Models
{
    using System;

    using ArgSentry;

    using EDS.Widgets.Domain.ValueTypes;

    using Newtonsoft.Json;
    
    /// <summary>
    /// The widget domain model.
    /// </summary>
    public sealed class Widget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Widget"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <param name="createdDateUtc">
        /// The created UTC date.
        /// </param>
        /// <param name="lastModifiedDateUtc">
        /// The last modified UTC date.
        /// </param>
        [JsonConstructor]
        private Widget(
            Guid id,
            string name,
            string description,
            int version,
            Weight weight,
            DateTime createdDateUtc,
            DateTime lastModifiedDateUtc)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Version = version;
            this.Weight = weight;
            this.CreatedDateUtc = createdDateUtc;
            this.LastModifiedDateUtc = lastModifiedDateUtc;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Gets the weight.
        /// </summary>
        public Weight Weight { get; private set; }

        /// <summary>
        /// Gets the created date utc.
        /// </summary>
        public DateTime CreatedDateUtc { get; private set; }

        /// <summary>
        /// Gets the last modified date utc.
        /// </summary>
        public DateTime LastModifiedDateUtc { get; private set; }

        /// <summary>
        /// Creates a new widget instance.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        /// <returns>
        /// The <see cref="Widget"/>.
        /// </returns>
        public static Widget Create(string name, string description, Weight weight)
        {
            return new Widget(
                Guid.NewGuid(),
                name,
                description,
                default(int),
                weight,
                default(DateTime),
                default(DateTime));
        }

        /// <summary>
        /// Renames the widget.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        public void Rename(string name, string description)
        {
            Prevent.NullOrWhiteSpaceString(name, nameof(name));

            this.Name = name;
            this.Description = description;

            this.IncrementVersion();
            this.UpdateLastModifiedDate();
        }

        /// <summary>
        /// Changes the weight.
        /// </summary>
        /// <param name="weight">
        /// The weight.
        /// </param>
        public void ChangeWeight(Weight weight)
        {
            Prevent.NullObject(weight, nameof(weight));

            this.Weight = weight;

            this.IncrementVersion();
            this.UpdateLastModifiedDate();
        }

        /// <summary>
        /// Updates the last modified date value.
        /// </summary>
        /// <param name="value">
        /// The new value (optional).
        /// </param>
        private void UpdateLastModifiedDate(DateTime? value = null)
        {
            this.LastModifiedDateUtc = value ?? DateTime.UtcNow;
        }

        /// <summary>
        /// Increments the version value.
        /// </summary>
        private void IncrementVersion()
        {
            this.Version++;
        }
    }
}
