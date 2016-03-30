namespace DigitalParadox.Wordpress.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using DigitalParadox.Wordpress.Models;
    using DigitalParadox.Wordpress.Requests;
    using DigitalParadox.Wordpress.Requests.Extensions;

    using Xunit;
    
    public class WordpressRequest
    {
        [Fact]
        public void HasParameters()
        {
            var req = new MockWordpressRequest();
            Assert.NotNull(req.Parameters);
        }

        [Theory]
        [InlineData("test"), InlineData(1), InlineData(123.87987), InlineData(OrderBy.Date)]
        public void AddOrUpdateParameterAddsNewParameterWhenEmpty(object expectedValue)
        {
            //arrange 
            var req = new MockWordpressRequest();
            //act
            req.AddOrUpdateParameter("test", expectedValue);

            //assert
            Assert.Equal(1, req.Parameters.Count);
            var param = req.Parameters.FirstOrDefault(q => q.Name == "test");
            Assert.NotNull(param);
            Assert.Equal(param.Name, "test");
            Assert.Equal(param.Value, expectedValue);
        }

        [Theory]
        [InlineData("test", "new-test"), InlineData(1, "99"), InlineData(123.87987, OrderBy.Slug), InlineData(OrderBy.Date, 123)]
        public void AddOrUpdateParameterUpdatesParameterWhenExists(object initialValue, object newValue)
        {
            //arrange 
            var req = new MockWordpressRequest();
            req.AddOrUpdateParameter("test", "test");
            //act
            req.AddOrUpdateParameter("test", "newtestvalue");

            //assert
            Assert.Equal(1, req.Parameters.Count);
            var param = req.Parameters.FirstOrDefault(q => q.Name == "test");
            Assert.NotNull(param);
            Assert.Equal(param.Name, "test");
            Assert.Equal(param.Value, "newtestvalue");
        }

    }
    
    public class TestConfig : IWordpressServiceConfiguration
    {
        public string JsonEndpoint { get; set; } = "/wp-json/wp/v2";

        public string BaseUrl { get; set; } = "http://dev.cms.digitalparadox.ca";

        public string ApiKey { get; set; }

        public string AppSecret { get; set; }

        public int? DefaultPageSize { get; set; } = 25;

        public bool ThrowHttpExceptionOnHttpError { get; set; } = true;
    }


    public class ContentClientTests
    {
        [Fact]
        public void GetPostsIntegration()
        { 
            var client = new ContentClient(config:new TestConfig());
            var request = new PostCollectionRequest().PerPage(50);
            var posts = client.GetPosts<List<Post>>(request);
            Assert.True(posts.Count == 50);
        }

        [Fact]
        public void GetPostIntegration()
        {
            var client = new ContentClient(config: new TestConfig());
            var request = new PostItemRequest(145);
            var posts = client.GetPost<Post>(request);
            Assert.True(posts.Id == 145);
        }
        [Fact]
        public void GetPagesIntegration()
        {
            var client = new ContentClient(config: new TestConfig());
            var request = new PageCollectionRequest().PerPage(5);
            var pages = client.GetPages(request);
            Assert.True(pages.Count() <= 5);
        }

        [Fact]
        public void GetPageIntegration()
        {
            var client = new ContentClient(config: new TestConfig());
            var request = new PageItemRequest(34);
            var pages = client.GetPage(request);
            Assert.True(pages.Id == 2);
        }
    }

}
