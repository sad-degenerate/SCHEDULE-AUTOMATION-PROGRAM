﻿using System.Data.Entity;

namespace BL.Commands
{
    public static class Update<T>
    {
        public static void UpdateTable(T item)
        {
            using (var context = new MyDbContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}