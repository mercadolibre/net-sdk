namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Attribute to help map a mercado libre site to a domain name value.
    /// </summary>
    public class MeliDomainAttribute : BaseValueAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeliDomainAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public MeliDomainAttribute(string value) : base(value)
        {
        }
    }
}