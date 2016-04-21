using System;

namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Base value attribute.
    /// </summary>
    public abstract class BaseValueAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValueAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        protected BaseValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}