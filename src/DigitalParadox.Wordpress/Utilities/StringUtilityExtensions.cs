namespace DigitalParadox.Wordpress.Utilities
{
    using System.Collections;
    using System.Text;
    using JetBrains.Annotations;

    [PublicAPI]
    public static class StringUtilityExtensions
    {
        public static string ToCSV([NotNull] this IEnumerable list)
        {
            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0},", item);
            }
            return sb.ToString().TrimEnd(',');
        }

    }
}
