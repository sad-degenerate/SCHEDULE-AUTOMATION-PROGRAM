using BL.Model;
using System.Collections.Generic;

namespace BL.Commands
{
    public static class Delete
    {
        public static void Teacher(List<Teacher> teachers)
        {
            using (var context = new MyDbContext())
            {
                context.Teachers.RemoveRange(teachers);
                context.SaveChanges();
            }
        }

        public static void Group(List<Group> groups)
        {
            using (var context = new MyDbContext())
            {
                context.Groups.RemoveRange(groups);
                context.SaveChanges();
            }
        }
    }
}