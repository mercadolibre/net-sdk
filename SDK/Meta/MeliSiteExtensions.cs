using System;
using System.Linq;

namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Extension methods to extract information from the <see cref="MeliSite"/> enumeration.
    /// </summary>
    public static class MeliSiteExtensions
    {
        /// <summary>
        /// Gets the value of the first relevant attribute on the given enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enum">The enum.</param>
        /// <returns></returns>
        public static string GetValue<T>(Enum @enum) where T : BaseValueAttribute
        {
            return EnumHelper.GetAttributesFromEnumConstant<T>(@enum)
                             .First()
                             .Value;
        }

        /// <summary>
        /// Froms the site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Unknown site ID</exception>
        public static MeliSite ToMeliSite(this string siteId)
        {
            var site = new MeliSite();

            var found = false;

            foreach (MeliSite value in Enum.GetValues(typeof (MeliSite)))
            {
                var siteIdForsite = value.ToSiteId();

                if (siteIdForsite.IndexOf(siteId, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    site = value;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new ArgumentOutOfRangeException(siteId, "Unknown site ID");
            }

            return site;
        }

        /// <summary>
        /// Converts a mercado libre site to a SiteId value;
        /// </summary>
        /// <param name="enum">The enum.</param>
        /// <returns></returns>
        public static string ToSiteId(this MeliSite @enum)
        {
            return GetValue<MeliSiteIdAttribute>(@enum);
        }

        /// <summary>
        /// Converts a mercado libre site to a two letter country code value;
        /// </summary>
        /// <param name="enum">The enum.</param>
        /// <returns></returns>
        public static string ToCountryCode(this MeliSite @enum)
        {
            return GetValue<MeliCountryCodeAttribute>(@enum);
        }

        /// <summary>
        /// Converts a mercado libre site to a base domain name value;
        /// </summary>
        /// <param name="enum">The enum.</param>
        /// <returns></returns>
        public static string ToDomain(this MeliSite @enum)
        {
            return GetValue<MeliDomainAttribute>(@enum);
        }
    }
}