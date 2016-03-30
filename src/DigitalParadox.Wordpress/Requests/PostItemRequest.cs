namespace DigitalParadox.Wordpress.Requests
{
    using DigitalParadox.Wordpress.Interface;
    using DigitalParadox.Wordpress.Requests.Extensions;

    using RestSharp;

    public class PostItemRequest : RestRequest, IWordpressSingleItemRequest
    {
        public PostItemRequest(int id) : base("/posts/{id}")
        {
            this.Method = Method.GET;
            this.Id(id);
        }
    }




}
