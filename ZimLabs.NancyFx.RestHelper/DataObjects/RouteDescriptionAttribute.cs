using System;
using Nancy;

namespace ZimLabs.NancyFx.RestHelper.DataObjects
{
    /// <summary>
    /// Provides the description attribute of a route
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true)]
    public sealed class RouteDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the route
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the route
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the response type (JSON, Text, etc.)
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// Gets or sets the http status cod ein case of success
        /// </summary>
        public HttpStatusCode[] ResponseSuccess { get; set; }

        /// <summary>
        /// Gets or sets the http status code in case of failure
        /// </summary>
        public HttpStatusCode[] ResponseFailure { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="RouteDescriptionAttribute"/>
        /// </summary>
        /// <param name="name">The name of the route</param>
        /// <param name="description">The description of the route</param>
        /// <param name="responseType">The response type (JSON, Text, etc.)</param>
        public RouteDescriptionAttribute(string name, string description, string responseType)
        {
            Name = name;
            Description = description;
            ResponseType = responseType;
            ResponseSuccess = new[] { HttpStatusCode.OK };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RouteDescriptionAttribute"/>
        /// </summary>
        /// <param name="name">The name of the route</param>
        /// <param name="description">The description of the route</param>
        /// <param name="responseType">The response type (JSON, Text, etc.)</param>
        /// <param name="responseSuccess">The http status code in case of success (optional)</param>
        public RouteDescriptionAttribute(string name, string description, string responseType,
            HttpStatusCode[] responseSuccess) : this(name, description, responseType)
        {
            ResponseSuccess = responseSuccess;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="RouteDescriptionAttribute"/>
        /// </summary>
        /// <param name="name">The name of the route</param>
        /// <param name="description">The description of the route</param>
        /// <param name="responseType">The response type (JSON, Text, etc.)</param>
        /// <param name="responseSuccess">The http status code in case of success</param>
        /// <param name="responseFailure">The http status code in case of failure</param>
        public RouteDescriptionAttribute(string name, string description, string responseType,
            HttpStatusCode[] responseSuccess, HttpStatusCode[] responseFailure) : this(name, description, responseType,
            responseSuccess)
        {
            ResponseFailure = responseFailure;
        }
    }
}
