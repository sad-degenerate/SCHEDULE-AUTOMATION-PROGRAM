using System;
using System.Data.Entity;

namespace BL.Commands
{
    public static class Delete<T>
    {
        public static void DeleteFromTable(T item)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    context.Entry(item).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var x = ex.Message;
                }
            }
        }
    }
}