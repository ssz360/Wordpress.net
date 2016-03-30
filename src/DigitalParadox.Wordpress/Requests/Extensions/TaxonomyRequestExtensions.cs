namespace DigitalParadox.Wordpress.Requests.Extensions
{
    using JetBrains.Annotations;

    [PublicAPI]
    public static class TaxonomyRequestExtensions
    {
        public static TRequest ContentType<TRequest>(this TRequest req, string typeSlug) where TRequest : IWordpressTaxonomyRequest
        {
            req?.AddOrUpdateParameter("type", typeSlug);
            return req;
        }

    }
}