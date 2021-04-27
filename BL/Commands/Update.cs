using BL.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace BL.Commands
{
    public static class Update
    {
        public static void Teacher(List<Teacher> teachers)
        {
            using (var context = new MyDbContext())
            {
                foreach (var teacher in teachers)
                    context.Entry(teacher).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Equipment(List<Equipment> equipment)
        {
            using (var context = new MyDbContext())
            {
                foreach (var equip in equipment)
                    context.Entry(equip).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Subject(List<Subject> subjects)
        {
            using (var context = new MyDbContext())
            {
                foreach (var subject in subjects)
                    context.Entry(subject).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void GroupsLoad(List<GroupsLoad> groupsLoads)
        {
            using (var context = new MyDbContext())
            {
                foreach (var groupsLoad in groupsLoads)
                    context.Entry(groupsLoad).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void TeachersLoad(List<TeachersLoad> teachersLoads)
        {
            using (var context = new MyDbContext())
            {
                foreach (var teachersLoad in teachersLoads)
                    context.Entry(teachersLoad).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Group(List<Group> groups)
        {
            using (var context = new MyDbContext())
            {
                foreach (var group in groups)
                    context.Entry(group).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public static void Classroom(List<Classroom> classrooms)
        {
            using (var context = new MyDbContext())
            {
                foreach (var classroom in classrooms)
                    context.Entry(classroom).State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}