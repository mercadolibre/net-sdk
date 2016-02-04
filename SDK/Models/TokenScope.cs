using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MercadoLibre.SDK.Models
{
    /// <summary>
    /// Enumeration listing the different application scopes
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TokenScope
    {
        /// <summary>
        /// The application can only read from the API.
        /// </summary>
        [EnumMember(Value = "read")]
        Read,
        /// <summary>
        /// The application can only read and write (e.g. create items) using the API.
        /// </summary>
        [EnumMember(Value = "write")]
        Write,
        /// <summary>
        /// The application is given a refresh token to update the access token after it has expired.
        /// </summary>
        [EnumMember(Value = "offline_access")]
        OfflineAccess,
    }
}