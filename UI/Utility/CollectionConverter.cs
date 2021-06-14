using System.Collections.Generic;

namespace UI.Utility
{
    public static class CollectionConverter<T>
    {
        public static string GetString(ICollection<T> list)
        {
            if (list == null || list.Count == 0)
                return "";

            var res = "";

            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(res))
                    res += ", ";

                res += item.ToString();
            }

            return res;
        }

        public static List<T> GetList(string str, List<T> list)
        {
            var stringArray = str.Split(',');

            var resultList = new List<T>();

            foreach (var item in stringArray)
            {
                var el = list.Find(x => x.ToString() == item);

                if (el != null)
                    list.Add(el);
            }

            return list;
        }
    }
}