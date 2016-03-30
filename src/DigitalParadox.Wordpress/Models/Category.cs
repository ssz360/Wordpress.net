namespace DigitalParadox.Wordpress.Models
{
    using JetBrains.Annotations;

    [PublicAPI]
    public class Category
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }

    }
}