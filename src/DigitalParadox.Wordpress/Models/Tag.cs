namespace DigitalParadox.Wordpress.Models
{
    using JetBrains.Annotations;

    using Newtonsoft.Json;

    [PublicAPI]
    public class Tag
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("slug")]
        public string Slug{ get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("taxomomy")]
        public string Taxonomy { get; set; }

    }
}