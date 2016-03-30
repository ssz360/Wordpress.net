namespace DigitalParadox.Wordpress.Requests.Extensions
{
    using DigitalParadox.Wordpress.Utilities;

    using JetBrains.Annotations;

    [PublicAPI]
    public static class WordpressCollectionRequestExtensions
    {
        public static TRequest Status<TRequest>(this TRequest req, string status) where TRequest : IWordpressRequest
        {
            req?.AddOrUpdateParameter("status", status);
            return req;
        }

        public static TRequest Slug<TRequest>(this TRequest req, string slug) where TRequest : IWordpressRequest
        {
            req?.AddOrUpdateParameter("slug", slug);
            return req;
        }

        public static TRequest PerPage<TRequest>(this TRequest req, int perPage) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("per_page", perPage);
            return req;
        }

        public static TRequest Page<TRequest>(this TRequest req, int pageNum) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("page", pageNum);

            return req;
        }
        public static TRequest Parent<TRequest>(this TRequest req, params int[] parent) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("parent", parent.ToCSV());
            return req;
        }

        public static TRequest ParentExclude<TRequest>(this TRequest req, params int[] parentExclude) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("parent_exclude", parentExclude.ToCSV());
            return req;
        }

        public static TRequest ExcludeIds<TRequest>(this TRequest req, params int[] ids) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("exclude", ids.ToCSV());
            return req;
        }

        public static TRequest IncludeIds<TRequest>(this TRequest req, params int[] ids) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("include", ids.ToCSV());
            return req;
        }

        public static TRequest Sort<TRequest>(this TRequest req, SortOrder order) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("order", order.ToString().ToLower());
            return req;
        }

        public static TRequest SortBy<TRequest>(this TRequest req, OrderBy orderBy) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("orderby", orderBy.ToString().ToLower());
            return req;
        }

        public static TRequest FilterQuery<TRequest>(this TRequest req, string filter) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("filter", filter);
            return req;
        }

        public static TRequest Offset<TRequest>(this TRequest req, int offset) where TRequest : IWordpressCollectionRequest
        {
            req?.AddOrUpdateParameter("offset", offset);
            return req;
        }
        
    }
}
