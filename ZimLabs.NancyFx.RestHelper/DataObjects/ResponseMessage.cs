using Nancy;

namespace ZimLabs.NancyFx.RestHelper.DataObjects
{
    /// <summary>
    /// Represents a basic response message
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        /// Gets or sets the HttpStatusCode
        /// </summary>
        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMessage { get; set; } = "";

        /// <summary>
        /// Creates a new instance of the <see cref="ResponseMessage"/> wit the default values (HttpStatusCode = 200, ErrorMessage = "")
        /// </summary>
        /// <param name="message">The message</param>
        public ResponseMessage(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ResponseMessage"/> with an empty error message
        /// </summary>
        /// <param name="code">The http status code</param>
        /// <param name="message">The message</param>
        public ResponseMessage(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ResponseMessage"/>
        /// </summary>
        /// <param name="code">The http status code</param>
        /// <param name="message">The message</param>
        /// <param name="errorMessage">The error message</param>
        public ResponseMessage(HttpStatusCode code, string message, string errorMessage)
        {
            Code = code;
            Message = message;
            ErrorMessage = errorMessage;
        }
    }
}
