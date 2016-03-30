namespace DigitalParadox.Wordpress.Tests
{
    using System.Linq;
    using DigitalParadox.Wordpress.Requests;
    using DigitalParadox.Wordpress.Requests.Extensions;

    using Xunit;
    
    public class WordpressMediaRequest
    {
        [Fact]
        public void HasParameters()
        {
            IWordpressMediaRequest req = new MockWordpressRequest();
            Assert.NotNull(req.Parameters);
        }

        [Theory,
         InlineData(MediaType.Audio, "audio"), InlineData(MediaType.Image, "image"), 
         InlineData(MediaType.Text, "text"), InlineData(MediaType.Video, "video"), 
         InlineData(MediaType.Application, "application")]
        public void MediaTypeAddsNewParmeterWhenEmpty(MediaType newValue, string expectedValue)
        {
            //arrange 
            IWordpressMediaRequest req = new MockWordpressRequest();
            //act
            var result = req.MediaType(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "media_type");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }

        [Theory, 
         InlineData(MediaType.Image, MediaType.Video, "video"), 
         InlineData(MediaType.Text, MediaType.Audio, "audio")]
        public void MediaTypeUpdatesParmeterWhenExists(MediaType initialValue, MediaType newValue, string expectedValue)
        {
            //arrange 
            IWordpressMediaRequest req = new MockWordpressRequest();
            req.MediaType(initialValue);

            //act
            var result = req.MediaType(newValue);
            //assert
            Assert.IsType<MockWordpressRequest>(result);
            Assert.Equal(1, req.Parameters.Count);
            var prm = req.Parameters.FirstOrDefault(q => q.Name == "media_type");
            Assert.NotNull(prm);
            Assert.Equal(expectedValue, prm.Value);
        }


    }

}
