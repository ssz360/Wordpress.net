namespace DigitalParadox.Wordpress.Requests
{
    using JetBrains.Annotations;

    [PublicAPI]
    public interface IWordpressServiceConfiguration
    {
        
        string JsonEndpoint { get; set; }

        [NotNull]
        string BaseUrl { get; set; }
          
        [CanBeNull]
        string ApiKey { get; set; }
        [CanBeNull]
        string AppSecret { get; set; }

        [CanBeNull]
       
        int? DefaultPageSize { get; set; }

        bool ThrowHttpExceptionOnHttpError { get; set; }

        bool ThrowHttpExceptionOnApi404 { get; set; }
    }
}
