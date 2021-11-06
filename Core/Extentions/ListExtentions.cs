using System.Collections.Generic;
using System.Linq;

namespace Core.Extentions
{
    public static class ListExtentions
    {
        public static bool AnyNotNull<T>(this IEnumerable<T> list)
        {
            return list != null && list.Any();
        }
    }
}
