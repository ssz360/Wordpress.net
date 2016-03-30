namespace DigitalParadox.Wordpress.Requests.Extensions
{
    using DigitalParadox.Wordpress.Interface;

    using JetBrains.Annotations;

    [PublicAPI]
    public static class WordpressSingleRequestExtensions
    {
        public static TRequest Id<TRequest>(this TRequest req, int id) where TRequest : IWordpressSingleItemRequest
        {
            req?.AddOrUpdateParameter("id", id);
            return req;
        }
    }
}
