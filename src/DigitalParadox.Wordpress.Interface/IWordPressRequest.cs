namespace DigitalParadox.Wordpress.Requests
{
    using System.Collections.Generic;

    using JetBrains.Annotations;

    using RestSharp;

    public interface IWordpressRequest
    {
        List<Parameter> Parameters { get; }
        string Resource { get; set; }

        IRestRequest AddParameter([NotNull]string name, [NotNull] object value);
        IRestRequest AddUrlSegment([NotNull]string name, [NotNull] string value);
    }

    public interface IWordpressTypeRequest : IWordpressRequest
    {
    }

    public interface IWordpressStatusRequest : IWordpressRequest
    {

    }

    public interface IWordpressTaxonomyRequest : IWordpressRequest
    {

    }

}
