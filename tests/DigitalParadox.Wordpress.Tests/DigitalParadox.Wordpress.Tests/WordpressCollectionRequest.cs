namespace DigitalParadox.Wordpress.Tests
{
    using System.ComponentModel;
    using System.Linq;
    using DigitalParadox.Wordpress.Requests;
    using DigitalParadox.Wordpress.Requests.Extensions;

    using Xunit;

   
    public class WordpressCollectionRequest
    {
        
        [Fact]
        public void HasParameters()
        {
            var req = new MockWordpressRequest();
            Assert.NotNull(req.Parameters);
        }

        [Theory, InlineData(25), InlineData("test"), InlineData("test-post")]
        public void SlugAddsNewParmeterWhenEmpty(object expectedValue)
        {
            //arrange 
            var req = new MockWordpressRequest();
            //act
            var result = req.Slug(expectedValue.ToString());
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "slug");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue.ToString(), prm.Value);
        }

        [Theory, InlineData("test-post", "test-post-new"), InlineData("test", "test-new"), InlineData(25, 50), InlineData(25, "25-new")]
        public void SlugUpdatesParmeterWhenExists(object initialValue, object expectedValue)
        {
            //arrange 
            var req = new MockWordpressRequest();
            req.Slug(initialValue.ToString());

            //act
            var result = req.Slug(expectedValue.ToString());
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "slug");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue.ToString(), prm.Value);
        }

        [Theory, InlineData(PostContext.Embed, "embed"), InlineData(PostContext.Edit, "edit"), InlineData(PostContext.View, "view")]
        public void ContextAddsNewParmeterWhenEmpty(PostContext newValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.Context(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "context");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(PostContext.Edit, PostContext.View, "view"), InlineData(PostContext.Embed, PostContext.Edit, "edit"), InlineData(PostContext.View, PostContext.Embed, "embed")]
        public void ContextUpdatesParmeterWhenExists(PostContext initialValue, PostContext newValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.Context(initialValue);

            //act
            var result = req.Context(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "context");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25), InlineData(50), InlineData(250)]
        public void PerPageAddsNewParmeterWhenEmpty(int expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.PerPage(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "per_page");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25, 100, 100), InlineData(15, 25, 25), InlineData(25, 50, 50)]
        public void PerPageUpdatesParmeterWhenExists(int initialValue, int newValue, object expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.PerPage(initialValue);

            //act
            var result = req.PerPage(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "per_page");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25), InlineData(50), InlineData(250)]
        public void PageAddsNewParmeterWhenEmpty(int expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.Page(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "page");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25, 100, 100), InlineData(15, 25, 25), InlineData(25, 50, 50)]
        public void PageUpdatesParmeterWhenExists(int initialValue, int newValue, object expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.Page(initialValue);

            //act
            var result = req.Page(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "page");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25), InlineData(50), InlineData(250)]
        public void OffestAddsNewParmeterWhenEmpty(int expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.Offset(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "offset");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25, 100, 100), InlineData(15, 25, 25), InlineData(25, 50, 50)]
        public void OffsetUpdatesParmeterWhenExists(int initialValue, int newValue, object expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.Offset(initialValue);

            //act
            var result = req.Offset(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "offset");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("draft"), InlineData("publish"), InlineData("custom-status")]
        public void StatusAddsNewParmeterWhenEmpty(string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.Status(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "status");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("publish", "draft"), InlineData("draft", "publish"), InlineData("publish", "custom-status")]
        public void StatusUpdatesParmeterWhenExists(string initialValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.Status(initialValue);

            //act
            var result = req.Status(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "status");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(SortOrder.Ascending, "ascending"), InlineData(SortOrder.Descending, "descending")]
        public void SortAddsNewParmeterWhenEmpty(SortOrder newValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.Sort(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "order");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(SortOrder.Ascending, SortOrder.Descending, "descending"), InlineData(SortOrder.Descending, SortOrder.Ascending, "ascending")]
        public void SortUpdatesParmeterWhenExists(SortOrder initialValue, SortOrder newValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.Sort(initialValue);

            //act
            var result = req.Sort(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "order");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory,    InlineData(OrderBy.Date, "date"), InlineData(OrderBy.Slug, "slug"), 
                    InlineData(OrderBy.Title, "title"), InlineData(OrderBy.Id, "id")]
        public void SortByAddsNewParmeterWhenEmpty(OrderBy newValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.SortBy(newValue);
            //assert  
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "orderby");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(OrderBy.Date, OrderBy.Id, "id"), InlineData(OrderBy.Date, OrderBy.Id, "id"), InlineData(OrderBy.Date, OrderBy.Id, "id")]
        public void SortByUpdatesParmeterWhenExists(OrderBy initialValue, OrderBy newValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.SortBy(initialValue);

            //act
            var result = req.SortBy(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "orderby");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }


        [Theory, InlineData("1,2,3", new[] {1,2,3}), InlineData("1", new [] {1})]
        public void IncludeIdsAddsNewParmeterWhenEmpty(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.IncludeIds(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "include");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void IncludeIdsUpdatesParmeterWhenExists(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.IncludeIds(10, 11, 12);
            
            //assert initial value
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "include");
            Assert.Equal(prm.Value, "10,11,12");

            //act
            var result = req.IncludeIds(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            prm = req.Parameters.FirstOrDefault(q => q.Name == "include");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void ExcludeIdsAddsNewParmeterWhenEmpty(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.ExcludeIds(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "exclude");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void ExcludeIdsUpdatesParmeterWhenExists(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.ExcludeIds(10, 11, 12);

            //assert initial value
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "exclude");
            Assert.NotNull(prm);
            Assert.Equal(prm.Value, "10,11,12");

            //act
            var result = req.ExcludeIds(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            prm = req.Parameters.FirstOrDefault(q => q.Name == "exclude");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void ParentAddsNewParmeterWhenEmpty(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.Parent(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "parent");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void ParentUpdatesParmeterWhenExists(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.Parent(10, 11, 12);

            //assert initial value
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "parent");
            Assert.NotNull(prm);
            Assert.Equal(prm.Value, "10,11,12");

            //act
            var result = req.Parent(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            prm = req.Parameters.FirstOrDefault(q => q.Name == "parent");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }
        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void ExcludeParentAddsNewParmeterWhenEmpty(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.ParentExclude(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "parent_exclude");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("1,2,3", new[] { 1, 2, 3 }), InlineData("1", new[] { 1 })]
        public void ExcludeParentUpdatesParmeterWhenExists(string expectedValue, params int[] newValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.ParentExclude(10, 11, 12);

            //assert initial value
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "parent_exclude");
            Assert.NotNull(prm);
            Assert.Equal(prm.Value, "10,11,12");

            //act
            var result = req.ParentExclude(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            prm = req.Parameters.FirstOrDefault(q => q.Name == "parent_exclude");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("customfield(234)"), InlineData("filtervalue=345")]
        public void FilterQueryAddsNewParmeterWhenEmpty(string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            //act
            var result = req.FilterQuery(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "filter");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData("test", "customfield(234)"), InlineData("test2", "filtervalue=345")]
        public void FilterQueryUpdatesParmeterWhenExists(string initialValue, string expectedValue)
        {
            //arrange 
            IWordpressCollectionRequest req = new MockWordpressRequest();
            req.FilterQuery(initialValue);

            //assert initial value
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "filter");
            Assert.NotNull(prm);
            Assert.Equal(prm.Value, initialValue);

            //act
            var result = req.FilterQuery(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            prm = req.Parameters.FirstOrDefault(q => q.Name == "filter");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

    }



}
