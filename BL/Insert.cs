using BL.Commands;
using BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public static class Insert<T>
    {
        public static void InsertOriginal(T item, ICollection<T> source)
        {
            if (CheckForExistence<T>.IsExist(item, source) == true)
                Update<T>.UpdateTable(item);
            else
                Add<T>.AddNew(item);
        }
    }
}