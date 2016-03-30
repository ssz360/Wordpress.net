namespace DigitalParadox.Wordpress.Requests.Extensions
{
    using JetBrains.Annotations;

    [PublicAPI]
    public static class MediaRequestExtensions
    {
        public static TRequest MediaType<TRequest>(this TRequest req , MediaType mediaType) where TRequest : IWordpressMediaRequest
        {
            req?.AddOrUpdateParameter("media_type", mediaType.ToString().ToLower());
            return req;
        }
        public static TRequest MimeType<TRequest>(this TRequest req, string mimeType) where TRequest : IWordpressMediaRequest
        {
            req?.AddOrUpdateParameter("mime_type", mimeType);
            return req;
        }
    }
}