using System.Runtime.Serialization;

namespace MercadoLibre.SDK.Models
{
    /// <summary>
    /// Model returned by the API when a request is not successful.
    /// </summary>
    [DataContract]
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the message (e.g. "invalid_token").
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the error (e.g. "not_found").
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [DataMember(Name = "error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status (e.g. 404).
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DataMember(Name = "status")]
        public int Status { get; set; }
    }
}
