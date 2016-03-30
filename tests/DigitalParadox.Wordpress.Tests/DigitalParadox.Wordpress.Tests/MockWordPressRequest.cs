namespace DigitalParadox.Wordpress.Tests
{
    using DigitalParadox.Wordpress.Requests;
    using RestSharp;

    using System;

    using DigitalParadox.Wordpress.Interface;

    public class MockWordpressRequest : RestRequest, IWordpressCollectionRequest, IWordpressSingleItemRequest, IWordpressMediaRequest
    {
        public MockWordpressRequest()
        {
        }

        public MockWordpressRequest(string resource) : base(resource)
        {
        }

        public MockWordpressRequest(Uri resource) : base(resource)
        {
        }

    }
}
