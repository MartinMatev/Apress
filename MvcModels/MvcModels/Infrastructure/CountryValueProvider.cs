using System.Globalization;
using System.Web.Mvc;

namespace MvcModels.Infrastructure
{
    // This class will be used to provide values for the Country property.
    public class CountryValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("country") > -1;
        }

        public ValueProviderResult GetValue(string key)
        {
            // This value provider only responds to requests for values for the Country property and it always returns the value USA. For all other requests, I return null, indicating that I cannot provide data.
            if (ContainsPrefix(key))
            {
                // I have to return the data value as a ValueProviderResult class. This class has three constructor parameters. The first is the data item that I want to associate with the requested key. The second parameter is a version of the data value that is safe to display as part of an HTML page.
                return new ValueProviderResult("USA", "USA", CultureInfo.InvariantCulture);
            }
            else
            {
                return null;
            }
        }
    }
}