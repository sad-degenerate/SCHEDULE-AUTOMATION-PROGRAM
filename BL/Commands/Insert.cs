using BL.Model;
using System.Collections.Generic;

namespace BL.Commands
{
    public static class Insert
    {
        public static void Teacher(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Teachers.Add(new Teacher(list));
                context.SaveChanges();
            }
        }

        public static void Equipment(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Equipment.Add(new Equipment(list));
                context.SaveChanges();
            }
        }

        public static void Subject(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Subjects.Add(new Subject(list));
                context.SaveChanges();
            }
        }

        public static void GroupsLoad(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.GroupsLoads.Add(new GroupsLoad(list));
                context.SaveChanges();
            }
        }

        public static void TeachersLoad(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.TeachersLoads.Add(new TeachersLoad(list));
                context.SaveChanges();
            }
        }

        public static void Group(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Groups.Add(new Group(list));
                context.SaveChanges();
            }
        }

        public static void Classroom(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.Add(new Classroom(list));
                context.SaveChanges();
            }
        }
    }
}