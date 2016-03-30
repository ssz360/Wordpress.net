namespace DigitalParadox.Wordpress
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;

    using DigitalParadox.Wordpress.Interface;
    using DigitalParadox.Wordpress.Models;
    using DigitalParadox.Wordpress.Requests;
    using DigitalParadox.Wordpress.Requests.Extensions;
    using DigitalParadox.Wordpress.Utilities;

    using JetBrains.Annotations;

    using Newtonsoft.Json;

    using RestSharp;
    [PublicAPI]
    public class ContentClient
    {
        #region Properties

        [NotNull]
        public IWordpressServiceConfiguration Config { get; set; }

        protected IRestClient Http { get; set; }

        #endregion

        public ContentClient([NotNull] IWordpressServiceConfiguration config, IRestClient http = null)
        {
            this.Config = config;
            if (http == null)
            {
                var client = new RestClient($"{this.Config.BaseUrl}{this.Config.JsonEndpoint}");
                var serializer = new JsonNetSerializer();
                //implement json.net serializer   
                client.RemoveHandler("application/json");
                client.RemoveHandler("text/json");
                client.RemoveHandler("text/x-json");
                client.RemoveHandler("*+json");

                client.AddHandler("application/json", serializer);
                client.AddHandler("text/json", serializer);
                client.AddHandler("text/x-json", serializer);
                client.AddHandler("*+json", serializer);
                this.Http = client;
            }
            else
            {
                this.Http = http;
            }

        }

        #region Content
        public TModel GetContentCollection<TModel>(IRestRequest req) where TModel : IEnumerable<object>, new()
        {
            var result = this.Http.Get<TModel>(req);
            this.ValidateResponse(result);
            return result.Data;
        }
        public async Task<TModel> GetContentCollectionAsync<TModel>(IRestRequest req)
            where TModel : IEnumerable<object>, new()
        {
            var task = Http.GetTaskAsync<TModel>(req);
            return await task;
        }

        public async Task<TModel> GetContentItemAsync<TModel>(IRestRequest req) where TModel : class, new()
        {
            var task = Http.GetTaskAsync<TModel>(req);
            return await task;
        }

        public TModel GetContentItem<TModel>(IRestRequest req) where TModel : class, new()
        {
            var result = this.Http.Get<TModel>(req);
            this.ValidateResponse(result);
            return result.StatusCode >= HttpStatusCode.NotFound ? null : result.Data;
        }

        #endregion

        #region Post
        //standard calls
        public TModel GetPosts<TModel>(PostCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Post> GetPosts(PostCollectionRequest req) => this.GetPosts<List<Post>>(req);
        public TModel GetPost<TModel>(PostItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public CmsPage GetPost(PostItemRequest req) => this.GetPost<CmsPage>(req);

        //async calls
        public async Task<IEnumerable<Post>> GetPostsAsync(PostCollectionRequest req) => await this.GetPostsAsync<List<Post>>(req);
        public async Task<TModel> GetPostsAsync<TModel>(PostCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<Post> GetPostAsync(PostItemRequest req) => await this.GetPostAsync<Post>(req);
        public async Task<TModel> GetPostAsync<TModel>(PostItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion
        #region Page
        //standard calls
        public TModel GetPages<TModel>(PageCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<CmsPage> GetPages(PageCollectionRequest req) => this.GetPages<List<CmsPage>>(req);
        public TModel GetPage<TModel>(PageItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public CmsPage GetPage(PageItemRequest req) => this.GetPage<CmsPage>(req);

        //async calls
        public async Task<IEnumerable<CmsPage>> GetPagesAsync(PageCollectionRequest req) => await this.GetPagesAsync<List<CmsPage>>(req);
        public async Task<TModel> GetPagesAsync<TModel>(PageCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<CmsPage> GetPageAsync(PageItemRequest req) => await this.GetPageAsync<CmsPage>(req);
        public async Task<TModel> GetPageAsync<TModel>(PageItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion
        #region Tag
        //standard calls
        public TModel GetTags<TModel>(TagCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Tag> GetTags(TagCollectionRequest req) => this.GetTags<List<Tag>>(req);
        public TModel GetTag<TModel>(TagItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public Tag GetTag(TagItemRequest req) => this.GetTag<Tag>(req);

        //async calls
        public async Task<IEnumerable<Tag>> GetTagsAsync(TagCollectionRequest req) => await this.GetTagsAsync<List<Tag>>(req);
        public async Task<TModel> GetTagsAsync<TModel>(TagCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<Tag> GetTagAsync(TagItemRequest req) => await this.GetTagAsync<Tag>(req);
        public async Task<TModel> GetTagAsync<TModel>(TagItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion
        #region Category
        //standard calls
        public TModel GetCategories<TModel>(CategoryCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Category> GetCategories(CategoryCollectionRequest req) => this.GetCategories<List<Category>>(req);
        public TModel GetCategory<TModel>(CategoryItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public Category GetCategory(CategoryItemRequest req) => this.GetCategory<Category>(req);

        //async calls
        public async Task<IEnumerable<Category>> GetCategoriesAsync(CategoryCollectionRequest req) => await this.GetCategoriesAsync<List<Category>>(req);
        public async Task<TModel> GetCategoriesAsync<TModel>(CategoryCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<Category> GetCategoryAsync(CategoryItemRequest req) => await this.GetCategoryAsync<Category>(req);
        public async Task<TModel> GetCategoryAsync<TModel>(CategoryItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion
        #region Media
        //standard calls
        public TModel GetMedias<TModel>(MediaCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Media> GetMedias(MediaCollectionRequest req) => this.GetMedias<List<Media>>(req);
        public TModel GetMedia<TModel>(MediaItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);  
        public Media GetMedia(MediaItemRequest req) => this.GetMedia<Media>(req);

        //async calls
        public async Task<IEnumerable<Media>> GetMediasAsync(MediaCollectionRequest req) => await this.GetMediasAsync<List<Media>>(req);
        public async Task<TModel> GetMediasAsync<TModel>(MediaCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<Media> GetMediaAsync(MediaItemRequest req) => await this.GetMediaAsync<Media>(req);
        public async Task<TModel> GetMediaAsync<TModel>(MediaItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion

        #region User
        //standard calls
        public TModel GetUsers<TModel>(UserCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Post> GetUsers(UserCollectionRequest req) => this.GetUsers<List<Post>>(req);
        public TModel GetUser<TModel>(UserItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public User GetUser(UserItemRequest req) => this.GetUser<User>(req);

        //async calls
        public async Task<IEnumerable<User>> GetUsersAsync(UserCollectionRequest req) => await this.GetUsersAsync<List<User>>(req);
        public async Task<TModel> GetUsersAsync<TModel>(UserCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<User> GetUserAsync(UserItemRequest req) => await this.GetUserAsync<User>(req);
        public async Task<TModel> GetUserAsync<TModel>(UserItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion
        #region ContentType
        //standard calls
        public TModel GetContentTypes<TModel>(ContentTypeCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Post> GetContentTypes(ContentTypeCollectionRequest req) => this.GetContentTypes<List<Post>>(req);
        public TModel GetContentType<TModel>(ContentTypeItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public ContentType GetContentType(ContentTypeItemRequest req) => this.GetContentType<ContentType>(req);

        //async calls
        public async Task<IEnumerable<ContentType>> GetContentTypesAsync(ContentTypeCollectionRequest req) => await this.GetContentTypesAsync<List<ContentType>>(req);
        public async Task<TModel> GetContentTypesAsync<TModel>(ContentTypeCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<ContentType> GetContentTypeAsync(ContentTypeItemRequest req) => await this.GetContentTypeAsync<ContentType>(req);
        public async Task<TModel> GetContentTypeAsync<TModel>(ContentTypeItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion
        #region Status
        //standard calls
        public TModel GetStatuses<TModel>(StatusCollectionRequest req) where TModel : IEnumerable<object>, new() => GetContentCollection<TModel>(req);
        public IEnumerable<Post> GetStatuses(StatusCollectionRequest req) => this.GetStatuses<List<Post>>(req);
        public TModel GetStatus<TModel>(StatusItemRequest req) where TModel : class, new() => GetContentItem<TModel>(req);
        public Status GetStatus(StatusItemRequest req) => this.GetStatus<Status>(req);

        //async calls
        public async Task<IEnumerable<Status>> GetStatusesAsync(StatusCollectionRequest req) => await this.GetStatusesAsync<List<Status>>(req);
        public async Task<TModel> GetStatusesAsync<TModel>(StatusCollectionRequest req) where TModel : IEnumerable<object>, new() => await this.GetContentCollectionAsync<TModel>(req);
        public async Task<Status> GetStatusAsync(StatusItemRequest req) => await this.GetStatusAsync<Status>(req);
        public async Task<TModel> GetStatusAsync<TModel>(StatusItemRequest req) where TModel : class, new() => await this.GetContentItemAsync<TModel>(req);

        #endregion

        private IRestResponse<TModel> ValidateResponse<TModel> ([NotNull] IRestResponse<TModel> result)
        {
            if (this.Config.ThrowHttpExceptionOnApi404 && result.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpException((int)result.StatusCode, result.ErrorMessage, result.ErrorException);
            }

            if ((result.ResponseStatus == ResponseStatus.Error ) && this.Config.ThrowHttpExceptionOnHttpError)
                throw new HttpException((int)result.StatusCode, result.ErrorMessage, result.ErrorException);
            return result;
        }
    }

    public class Status
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("queryable")]
        public bool Queryable { get; set; }
    }


    public class ContentType
    {

        [JsonProperty("name")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("hierarchical")]
        public bool Hierarchical { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }


    }

    public class Media
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateGmt { get; set; }

        public DateTime Modified { get; set; }

        public DateTime ModifiedGmt { get; set; }

        public Content Guid { get; set; }

        public string Slug { get; set; }

        public string Link { get; set; }

        public string ContentType { get; set; }

        public Content Title { get; set; }

        public int AuthorId { get; set; }

        public string CommentStatus { get; set; }

        public string PingStatus { get; set; }

        public string AltText { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string MediaType { get; set; }

        public string MimeType { get; set; }

        public Dictionary<string, MediaSize> MediaDetails { get; set; }

        public int PostId { get; set; }
        

    }

    public class MediaDetails
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string File { get; set; }
        public Dictionary<string, MediaSize> Sizes { get; set; }
        public dynamic ImageMeta { get; set; }
        
    }

    public class MediaSize
    {
        public string File { get; set; }
        public int Width { get; set; }
        public string Height { get; set; }
        public string MimeType { get; set; }
        public string SourceUrl { get; set; }

    }

    public class StatusItemRequest : RestRequest, IWordpressSingleItemRequest, IWordpressTypeRequest
    {
        public StatusItemRequest()
        {
            this.Resource = "/statuses/{id}";
            this.Method = Method.GET;
        }
        public StatusItemRequest(int id) : this()
        {
            this.Id(id);
        }
    }
    public class StatusCollectionRequest : RestRequest, IWordpressCollectionRequest, IWordpressTypeRequest
    {
        public StatusCollectionRequest()
        {
            this.Resource = "/statuses";
            this.Method = Method.GET;
        }
    }
    public class ContentTypeItemRequest : RestRequest, IWordpressSingleItemRequest, IWordpressTypeRequest
    {
        public ContentTypeItemRequest()
        {
            this.Resource = "/type/{id}";
            this.Method = Method.GET;
        }
        public ContentTypeItemRequest(int id) : this()
        {
            this.Id(id);
        }
    }
    public class ContentTypeCollectionRequest : RestRequest, IWordpressCollectionRequest, IWordpressTypeRequest
    {
        public ContentTypeCollectionRequest()
        {
            this.Resource = "/types";
            this.Method = Method.GET;
        }
    }

    public class UserItemRequest : RestRequest, IWordpressSingleItemRequest
    {
        public UserItemRequest()
        {
            this.Resource = "/media/{id}";
            this.Method = Method.GET;
        }
        public UserItemRequest(int id) : this()
        {
            this.Id(id);
        }
    }
    public class UserCollectionRequest : RestRequest, IWordpressCollectionRequest
    {
        public UserCollectionRequest()
        {
            this.Resource = "/media";
            this.Method = Method.GET;
        }
    }

    public class MediaItemRequest : RestRequest, IWordpressSingleItemRequest, IWordpressMediaRequest
    {
        public MediaItemRequest()
        {
            this.Resource = "/media/{id}";
            this.Method = Method.GET;
        }
        public MediaItemRequest(int id) : this()
        {
            this.Id(id);
        }
    }
    public class MediaCollectionRequest : RestRequest, IWordpressCollectionRequest, IWordpressMediaRequest
    {
        public MediaCollectionRequest()
        {
            this.Resource = "/media";
            this.Method = Method.GET;
        }
    }

    public class TagItemRequest : RestRequest, IWordpressSingleItemRequest
    {
        public TagItemRequest()
        {
            this.Resource = "tag/{id}";
            this.Method = Method.GET;
        }
        public TagItemRequest(int id) : this()
        {
            this.Id(id);
        }
    }
    public class TagCollectionRequest : RestRequest, IWordpressCollectionRequest
    {
        public TagCollectionRequest()
        {
            this.Resource = "tags";
            this.Method = Method.GET;
        }
    }

    public class CategoryCollectionRequest : RestRequest, IWordpressCollectionRequest
    {
        public CategoryCollectionRequest()
        {
            Resource = "/categories";
            Method = Method.GET;
        }
    }
    public class CategoryItemRequest : RestRequest , IWordpressSingleItemRequest
    {
        public CategoryItemRequest(int id) : this()
        {
            this.Id(id);
        }

        public CategoryItemRequest()
        {
            Resource = "/category/{id}";
            Method = Method.GET;

        }
    }

    public class PageCollectionRequest : RestRequest, IWordpressCollectionRequest
    {
        public PageCollectionRequest()
        {
            this.Resource = "/pages";
            this.Method = Method.GET;
        }
    }
    public class PageItemRequest : RestRequest, IWordpressSingleItemRequest
    {
        public PageItemRequest(int id) : this()
        {
            this.Id(id);
        }

        public PageItemRequest()
        {
            this.Resource = "/page/{id}";
            this.Method = Method.GET;
        }
    }
}