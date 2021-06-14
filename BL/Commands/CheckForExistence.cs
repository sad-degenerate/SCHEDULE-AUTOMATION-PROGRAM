using System.Collections.Generic;
using System.Linq;

namespace BL.Commands
{
    public static class CheckForExistence<T>
    {
        public static bool IsExist(T item, ICollection<T> collection)
        {
            if (collection.Where(x => x.Equals(item)).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
    }
}