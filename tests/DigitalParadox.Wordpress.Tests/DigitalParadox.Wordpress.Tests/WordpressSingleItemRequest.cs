namespace DigitalParadox.Wordpress.Tests
{
    using System.Linq;

    using DigitalParadox.Wordpress.Interface;
    using DigitalParadox.Wordpress.Requests;
    using DigitalParadox.Wordpress.Requests.Extensions;

    using Xunit;
    public class WordpressSingleItemRequest
    {
        [Fact]
        
        public void HasParameters()
        {
            var req = new MockWordpressRequest();
            Assert.NotNull(req.Parameters);
        }

        [Theory, InlineData(25), InlineData(17), InlineData(250)]
        public void IdAddsNewParmeterWhenEmpty(int expectedValue)
        {
            //arrange 
            IWordpressSingleItemRequest req = new MockWordpressRequest();
            //act
            var result = req.Id(expectedValue);

            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "id");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(10, 17), InlineData(10, 250), InlineData(25, "85")]
        public void IdUpdatesParmeterWhenExists(int initialValue, int expectedValue)
        {
            //arrange 
            IWordpressSingleItemRequest req = new MockWordpressRequest();
            req.Id(initialValue);

            //act
            var result = req.Id(expectedValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "id");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, InlineData(25), InlineData(17), InlineData(250)]
        public void SlugAddsNewParmeterWhenEmpty(string expectedValue)
        {
            //arrange 
            IWordpressSingleItemRequest req = new MockWordpressRequest();
            //act
            var result = req.Slug(expectedValue);

            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "slug");
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

    }

}