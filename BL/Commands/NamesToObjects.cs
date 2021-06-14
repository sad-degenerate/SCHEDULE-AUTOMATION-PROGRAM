using System.Collections.Generic;
using System.Linq;

namespace BL.Commands
{
    public static class NamesToObjects<T>
    {
        public static Dictionary<T, bool> GetObjects(Dictionary<string, bool> names, ICollection<T> collection)
        {
            var result = new Dictionary<T, bool>();

            foreach (var name in names)
            {
                var obj = collection.Where(x => x.ToString() == name.Key).FirstOrDefault();

                result.Add(obj, name.Value);
            }

            return result;
        }

        public static T GetObject(string name, ICollection<T> collection)
        {
            return collection.Where(x => x.ToString() == name).FirstOrDefault();
        }
    }
}