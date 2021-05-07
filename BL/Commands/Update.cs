using System.Collections.Generic;
using System.Data.Entity;

namespace BL.Commands
{
    public static class Update<T>
    {
        public static void UpdateTable(List<T> list)
        {
            using (var context = new MyDbContext())
            {
                foreach (var el in list)
                    context.Entry(el).State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}