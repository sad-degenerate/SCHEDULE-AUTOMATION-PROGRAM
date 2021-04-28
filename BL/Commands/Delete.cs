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

        public static void Equipment(List<Equipment> equipment)
        {
            using (var context = new MyDbContext())
            {
                context.Equipment.RemoveRange(equipment);
                context.SaveChanges();
            }
        }

        public static void Subject(List<Subject> subjects)
        {
            using (var context = new MyDbContext())
            {
                context.Subjects.RemoveRange(subjects);
                context.SaveChanges();
            }
        }

        public static void GroupsLoad(List<GroupsLoad> groupsLoads)
        {
            using (var context = new MyDbContext())
            {
                context.GroupsLoads.RemoveRange(groupsLoads);
                context.SaveChanges();
            }
        }

        public static void TeachersLoad(List<TeachersLoad> teachersLoads)
        {
            using (var context = new MyDbContext())
            {
                context.TeachersLoads.RemoveRange(teachersLoads);
                context.SaveChanges();
            }
        }

        public static void Classroom(List<Classroom> classrooms)
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.RemoveRange(classrooms);
                context.SaveChanges();
            }
        }
    }
}