using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Routing;

namespace ZimLabs.NancyFx.RestHelper.DataObjects
{
    /// <summary>
    /// Represents the meta data of a route
    /// </summary>
    public sealed class CustomMetadata
    {
        /// <summary>
        /// Gets the name of the route
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the path of the route
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the method of the route
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// Gets the value which indicates if the method is GET
        /// </summary>
        public bool IsGet { get; }

        /// <summary>
        /// Gets the value which indicates if the method is HEAD
        /// </summary>
        public bool IsHead { get; }

        /// <summary>
        /// Gets the value which indicates if the method is POST
        /// </summary>
        public bool IsPost { get; }

        /// <summary>
        /// Gets the value which indicates if the method is PUT
        /// </summary>
        public bool IsPut { get; }

        /// <summary>
        /// Gets the value which indicates if the method is DELETE
        /// </summary>
        public bool IsDelete { get; }

        /// <summary>
        /// Gets the description of the route
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the segments of the route
        /// </summary>
        public string Segments { get; }

        /// <summary>
        /// Gets the response type (JSON, Text, etc.)
        /// </summary>
        public string ResponseType { get; }

        /// <summary>
        /// Gets the http status code in case of success
        /// </summary>
        public string ResponseSuccess { get; }

        /// <summary>
        /// Gets the http status codes in case of failure
        /// </summary>
        public string ResponseFailure { get; }

        /// <summary>
        /// Creates new instance of the <see cref="CustomMetadata"/>
        /// </summary>
        /// <param name="route">The original route description</param>
        /// <param name="description">The route description</param>
        /// <param name="responseType">The response type</param>
        /// <param name="responseSuccess">The http status code in case of success</param>
        /// <param name="responseFailure">The http status code in case of failure</param>
        public CustomMetadata(RouteDescription route, string description, string responseType, HttpStatusCode[] responseSuccess, HttpStatusCode[] responseFailure)
        {
            Name = route.Name;
            Path = route.Path;
            Method = route.Method;
            Segments = route.Segments != null ? string.Join(", ", route.Segments) : "";
            Description = description;
            ResponseType = responseType;

            var tmpResponseSuccess = responseSuccess == null ? new List<HttpStatusCode>() : responseSuccess.ToList();
            ResponseSuccess = string.Join("<br/>",
                tmpResponseSuccess.OrderBy(o => (int)o).Select(s =>
                    $"{(int)s} - {s}"));

            var tmpResponseFailure = responseFailure == null ? new List<HttpStatusCode>() : responseFailure.ToList();
            if (tmpResponseFailure.All(a => a != HttpStatusCode.InternalServerError))
                tmpResponseFailure.Add(HttpStatusCode.InternalServerError);

            ResponseFailure = string.Join("<br/>",
                tmpResponseFailure.OrderBy(o => (int)o).Select(s =>
                   $"{(int)s} - {s}"));

            IsGet = false;
            IsHead = false;
            IsPost = false;
            IsPut = false;
            IsDelete = false;
            switch (Method.ToLower())
            {
                case "get":
                    IsGet = true;
                    break;
                case "head":
                    IsHead = true;
                    break;
                case "post":
                    IsPost = true;
                    break;
                case "put":
                    IsPut = true;
                    break;
                case "delete":
                    IsDelete = true;
                    break;
            }
        }
    }
}
