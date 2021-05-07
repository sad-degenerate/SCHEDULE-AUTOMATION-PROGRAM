using BL.Model;
using System.Collections.Generic;

namespace BL.Commands
{
    public static class Insert
    {
        public static void Teachers(List<object> list)
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

        public static void Subjects(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Subjects.Add(new Subject(list));
                context.SaveChanges();
            }
        }

        public static void Lessons(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Lessons.Add(new Lesson(list));
                context.SaveChanges();
            }
        }

        public static void LessonTimes(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.LessonTimes.Add(new LessonTime(list));
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

        public static void Groups(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Groups.Add(new Group(list));
                context.SaveChanges();
            }
        }

        public static void Classrooms(List<object> list)
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.Add(new Classroom(list));
                context.SaveChanges();
            }
        }
    }
}