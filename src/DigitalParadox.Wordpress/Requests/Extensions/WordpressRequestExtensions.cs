namespace DigitalParadox.Wordpress.Requests.Extensions
{
    using System.Linq;

    using JetBrains.Annotations;

    [PublicAPI]
    public static class WordpressRequestExtensions
    {
        public static TRequest Context<TRequest>(this TRequest req, PostContext context) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("context", context.ToString().ToLower());
            return req;
        }


        public static TRequest AddOrUpdateUrlSegment<TRequest>(this TRequest req, [NotNull] string name, [NotNull] object value) where TRequest : IWordpressRequest
        {
            var param = req?.Parameters.FirstOrDefault(q => q.Name == name);

            req?.Parameters?.Remove(param);

            req?.AddUrlSegment(name, value.ToString());
            return req;
        }
        public static TRequest AddOrUpdateParameter<TRequest>(this TRequest req, [NotNull] string name, [NotNull] object value) where TRequest : IWordpressRequest
        {
            var param = req?.Parameters.FirstOrDefault(q => q.Name == name);
            if (req != null && req.Resource.Contains("{" + name + "}"))
            {
                return AddOrUpdateUrlSegment(req, name, value);
            }
            req?.Parameters?.Remove(param);
            req?.AddParameter(name, value);
            return req;
        }


    }


}
