using System.Data.Entity;

namespace BL.Commands
{
    public static class Add<T>
    {
        public static void AddNew(T item)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(item).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}