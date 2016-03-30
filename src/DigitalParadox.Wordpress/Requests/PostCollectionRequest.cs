namespace DigitalParadox.Wordpress.Requests
{
    using RestSharp;

    public class PostCollectionRequest : RestRequest, IWordpressCollectionRequest
    {
        public PostCollectionRequest()
        {
            this.Resource = "/posts";
            this.Method = Method.GET;
        }
    }
}