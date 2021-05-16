using System.Collections.Generic;
using System.Data.Entity;

namespace BL.Commands
{
    public static class Delete<T>
    {
        public static void DeleteFromTable(List<T> list)
        {
            using (var context = new MyDbContext())
            {
                foreach (var el in list)
                    context.Entry(el).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}