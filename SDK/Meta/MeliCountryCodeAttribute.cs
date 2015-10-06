namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Attribute to help map a mercado libre site to its ISO 3166-1 alpha 2 equivalent.
    /// </summary>
    public class MeliCountryCodeAttribute : BaseValueAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeliCountryCodeAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public MeliCountryCodeAttribute(string value) : base(value)
        {
        }
    }
}