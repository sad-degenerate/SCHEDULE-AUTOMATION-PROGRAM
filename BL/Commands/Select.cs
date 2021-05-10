using BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace BL.Commands
{
    public static class Select
    {
        public static List<Teacher> Teachers()
        {
            using (var context = new MyDbContext())
            {
                var teachers = context.Teachers.ToList();
                return teachers;
            }
        }

        public static List<Lesson> Lessons()
        {
            using (var context = new MyDbContext())
            {
                var lessons = context.Lessons.ToList();
                return lessons;
            }
        }

        public static List<LessonTime> LessonTimes()
        {
            using (var context = new MyDbContext())
            {
                var lessonTimes = context.LessonTimes.ToList();
                return lessonTimes;
            }
        }

        public static List<Equipment> Equipment()
        {
            using (var context = new MyDbContext())
            {
                var equipment = context.Equipment.ToList();
                return equipment;
            }
        }

        public static List<Subject> Subjects()
        {
            using (var context = new MyDbContext())
            {
                var subjects = context.Subjects.ToList();
                return subjects;
            }
        }

        public static List<Group> Groups()
        {
            using (var context = new MyDbContext())
            {
                var groups = context.Groups.ToList();
                return groups;
            }
        }

        public static List<GroupsLoad> GroupsLoads()
        {
            using (var context = new MyDbContext())
            {
                var groupsLoads = context.GroupsLoads.ToList();
                return groupsLoads;
            }
        }

        public static List<Classroom> Classrooms()
        {
            using (var context = new MyDbContext())
            {
                var classrooms = context.Classrooms.ToList();
                return classrooms;
            }
        }
    }
}