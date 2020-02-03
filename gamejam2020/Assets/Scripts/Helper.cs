using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class Helper
    {
        public static bool AreEquals<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            var deletedItems = list1.Except(list2).Any();
            var newItems = list2.Except(list1).Any();
            return !newItems && !deletedItems;
        }
    }
}
