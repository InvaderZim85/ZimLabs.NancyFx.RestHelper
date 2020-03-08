using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nancy.Metadata.Modules;
using ZimLabs.NancyFx.RestHelper.DataObjects;

namespace ZimLabs.NancyFx.RestHelper.Metadata
{
    /// <summary>
    /// Provides the base class for the metadata
    /// </summary>
    /// <typeparam name="TModule">The route module</typeparam>
    public class MetadataBase<TModule> : MetadataModule<CustomMetadata> where TModule : class
    {
        /// <summary>
        /// Creates a new instance of the <see cref="MetadataBase{TModule}"/>
        /// </summary>
        protected MetadataBase()
        {
            AddDescription();
        }

        /// <summary>
        /// Adds the description to the nancy context
        /// </summary>
        private void AddDescription()
        {
            var metaData = GetCustomMetadata();

            foreach (var entry in metaData)
            {
                Describe[entry.Name] = x => new CustomMetadata(x, entry.Description, entry.ResponseType,
                    entry.ResponseSuccess, entry.ResponseFailure);
            }
        }

        /// <summary>
        /// Extracts the metadata of the given class
        /// </summary>
        /// <returns>The route descriptions</returns>
        private static IEnumerable<RouteDescriptionAttribute> GetCustomMetadata()
        {
            // Get all constructor attributes
            var constructorList = (from constructor in typeof(TModule).GetConstructors()
                from attribute in constructor.GetCustomAttributes<RouteDescriptionAttribute>()
                select attribute).ToList();

            // Get all method attributes
            var methodList = (from method in typeof(TModule).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                from attribute in method.GetCustomAttributes<RouteDescriptionAttribute>()
                select attribute).ToList();

            return constructorList.Union(methodList).ToList();
        }
    }
}
