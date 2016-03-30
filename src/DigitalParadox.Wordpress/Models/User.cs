namespace DigitalParadox.Wordpress.Models
{
    using System.Collections.Generic;

    using JetBrains.Annotations;

    using Newtonsoft.Json;

    [PublicAPI]
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string DisplayName { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("avatar_urls")]
        public Dictionary<string, string> AvatarUrls { get; set; }
    }

}