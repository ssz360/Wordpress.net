namespace DigitalParadox.Wordpress.Requests.Extensions
{
    using JetBrains.Annotations;

    [PublicAPI]
    public static class CategoryRequestExtensions
    {
        public static TRequest HideEmpty<TRequest>(this TRequest req) where TRequest : IWordpressTaxonomyRequest
        {
            req?.AddOrUpdateParameter("type", true);
            return req;
        }

    }
}