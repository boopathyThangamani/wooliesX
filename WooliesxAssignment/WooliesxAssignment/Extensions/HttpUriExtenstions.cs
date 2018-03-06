using System;
using System.Web;
using WooliesxAssignment.Helpers;

namespace WooliesxAssignment.Extensions
{
    public static class HttpUriExtenstions
    {
        public static Uri AddQuery(this Uri uri, string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(ErrorMessageConstants.NullUri);
            var uriBuilder = new UriBuilder(uri);
            var httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
            httpValueCollection.Add(name, value);
            uriBuilder.Query = httpValueCollection.ToString();
            uri = uriBuilder.Uri;
            return uri;
        }
    }
}