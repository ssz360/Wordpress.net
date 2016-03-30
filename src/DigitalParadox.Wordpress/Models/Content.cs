namespace DigitalParadox.Wordpress.Models
{
    using JetBrains.Annotations;

    using Newtonsoft.Json;
    [PublicAPI]
    public class Content
    {
        [JsonProperty("rendered")]
        public string Rendered { get; set; }
    }
}