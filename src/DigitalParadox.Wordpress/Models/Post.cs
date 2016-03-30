
namespace DigitalParadox.Wordpress.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using JetBrains.Annotations;
    using Newtonsoft.Json;

    [PublicAPI]
    [DebuggerDisplay("Id: {Id} |{Title.Rendered} | {Slug}")]
    public class Post 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("date_gmt")]
        public DateTime DateGMT { get; set; }

        [JsonProperty("title")]
        public Content Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("modified_gmt")]
        public DateTime ModifiedGMT { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("excerpt")]
        public Content Excerpt { get; set; }

        [JsonProperty("author")]
        public int AuthorID { get; set; }

        [JsonProperty("meatured_media")]
        public int FeaturedMediaID { get; set; }

        [JsonProperty("sticky")]
        public bool Sticky { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("categories")]
        public ICollection<int> Categories { get; set; }

        [JsonProperty("tags")]
        public ICollection<int> Tags { get; set; }
         
    }
}
