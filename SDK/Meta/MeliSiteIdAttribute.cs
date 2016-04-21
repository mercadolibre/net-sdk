namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Attribute to help map a mercado libre site to a SiteId value.
    /// </summary>
    public class MeliSiteIdAttribute : BaseValueAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeliSiteIdAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public MeliSiteIdAttribute(string value) : base(value)
        {
        }
    }
}