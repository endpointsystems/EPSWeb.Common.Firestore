using System.Collections.Generic;
using System.Text;

namespace EPSWeb.Common.Firestore.Test
{
    public static class Extensions
    {
        public static string ToCombinedString(this IEnumerable<string> src)
        {
            var sb = new StringBuilder();
            foreach (var str in src)
            {
                sb.Append(str + " ");
            }

            return sb.ToString();
        }
    }
}
