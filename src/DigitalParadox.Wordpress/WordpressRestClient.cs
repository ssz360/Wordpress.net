namespace DigitalParadox.Wordpress
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalParadox.Wordpress.Requests;

    using RestSharp;

    public class WordpressRestClient 
    {
        public IWordpressServiceConfiguration Config { get; }

        protected  IRestClient Http { get; set; }

        #region Constructors
        public WordpressRestClient(IWordpressServiceConfiguration config)
        {
            this.Config = config;
            this.Http = new RestClient($"{this.Config.BaseUrl}/{this.Config.JsonEndpoint}");

        }

        #endregion

        #region RequestBuilders
        protected IRestRequest Request(string route)
        {
            var req = new RestRequest(route);
            //prep any gobal headers 
            return req;
        }
        protected IRestRequest PostsRequest(
            int? page = null, 
            int? perPage = null, 
            SortOrder? order = null, 
            OrderBy orderby = OrderBy.Date, 
            PostContext context = PostContext.View, 
            int? offset = null, 
            string slug = null, 
            string status = "publish", 
            string filter = null, 
            ICollection<int> author = null)
        {
            perPage = perPage ?? this.Config.DefaultPageSize ?? 10;
            var request = this.Request("posts");

            //per_page only has logical meaning if page number is provided 
            if (offset.HasValue) request.AddParameter("offset", offset);
            if (page.HasValue)
            {
                request.AddParameter("page", page)
                       .AddParameter("per_page", perPage);

            }

            if (!string.IsNullOrWhiteSpace(filter)) request.AddParameter("filter", filter);
            if (!string.IsNullOrWhiteSpace(slug)) request.AddParameter("slug", slug);
            if (!string.IsNullOrWhiteSpace(status)) request.AddParameter("status", status);
            if (offset.HasValue) request.AddParameter("offset", offset);

            if (order != SortOrder.Descending) request.AddParameter("order", order.ToString().ToLower());
            if (orderby != OrderBy.Date) request.AddParameter("orderby", orderby.ToString().ToLower());
            if (context != PostContext.View) request.AddParameter("context", context.ToString().ToLower());

            return request;
        }

        protected void PageRequest(
            int? page = null,
            int? perPage = null,
            SortOrder order = SortOrder.Ascending,
            OrderBy orderby = OrderBy.Date,
            PostContext context = PostContext.View,
            int? offset = null,
            string slug = null,
            string status = "publish",
            string filter = null,
            ICollection<int> author = null,
            ICollection<int> authorExclude = null,
            ICollection<int> exclude = null,
            ICollection<int> include = null,
            ICollection<int> parent = null,
            ICollection<int> parentExclude = null,
            int? menuOrder = null,
            string search = null)
        {
            
        }

        private void MediaRequest(
            int? page = 1,
            int? perPage = null,
            SortOrder order = SortOrder.Ascending,
            OrderBy orderBy = OrderBy.Title,
            PostContext context = PostContext.View,
            int? offset = null,
            string slug = null,
            string status = "publish",
            string filter = null,
            ICollection<int> author = null,
            ICollection<int> authorExclude = null,
            ICollection<int> exclude = null,
            ICollection<int> include = null,
            int? parent = null,
            int? parentExclude = null,
            string mediaType = null,
            string mimeType = null,
            string search = null)
        {
            perPage = perPage ?? this.Config.DefaultPageSize ?? 25;

                var req = this.Request("media");
                //req.AddParameter();

        }
        #endregion

        public async Task<ICollection<dynamic>> SearchAsync(string query, int page = 1, int? perPage = null, SortOrder? order = null, OrderBy orderby = OrderBy.Date, PostContext context = PostContext.View, int? offset = null, string slug = null, string status = "publish", string filter = null, ICollection<int> author = null)
        {
            var request = this.PostsRequest(
                                page, perPage, order, orderby, context, offset, slug, status, filter, author);

            request.AddParameter("search", query.Replace(" ", "+"));

            return await this.Http.GetTaskAsync<dynamic>(request);
        }

        public async Task<List<dynamic>> GetPostsAsync(int page = 1, int? perPage = null, SortOrder? order = null, OrderBy orderby = OrderBy.Date, PostContext context = PostContext.View, int? offset = null, string slug = null, string status = "publish", string filter = null, ICollection<int> author = null)
        {
            var request = this.PostsRequest(
                                            page, perPage, order, orderby, context, offset, slug, status, filter, author);
            var result = await this.Http.GetTaskAsync<List<dynamic>>(request);

            return result;
        }

        public ICollection<dynamic> GetPosts(int page = 1, int? perPage = null, SortOrder? order = null, OrderBy orderby = OrderBy.Date, PostContext context = PostContext.View, int? offset = null, string slug = null, string status = "publish", string filter = null, ICollection<int> author = null)
        {
            var request = this.PostsRequest(
                                            page, perPage, order, orderby, context, offset, slug, status, filter, author);
            var result = this.Http.Get<List<dynamic>>(request).Data;

            return result;
        }
        
        public ICollection<dynamic> Search(string query, int page = 1, int? perPage = null, SortOrder? order = null, OrderBy orderby = OrderBy.Date, PostContext context = PostContext.View, int? offset = null, string slug = null, string status = "publish", string filter = null, ICollection<int> author = null)
        {
            var request = this.PostsRequest(
                                page, perPage, order, orderby, context, offset, slug, status, filter, author);

            request.AddParameter("search", query.Replace(" ", "+"));
            var result = this.Http.Get<List<dynamic>>(request);

            return result.Data;
        }

        public async Task<dynamic> GetPostAsync(int id, PostContext context = PostContext.View)
        {
            var request = this.Request("post/{id}");

            request.AddParameter("context", context.ToString().ToLower());

            var result =  await this.Http.GetTaskAsync<dynamic>(request);
            return result;
        }
        public dynamic GetPost(int id, PostContext context = PostContext.View)
        {
            var request = this.Request("post/{id}");

            request.AddParameter("context", context.ToString().ToLower());

            var result = this.Http.Get<dynamic>(request).Data;
            return result;
        }

    }
}
