using BL.Model;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static List<Day> Days()
        {
            using (var context = new MyDbContext())
            {
                var days = context.Days.ToList();
                return days;
            }
        }

        public static List<Lesson> Lessons()
        {
            using (var context = new MyDbContext())
            {
                var lessons = context.Lessons.Include(x => x.Subject).Include(x => x.Subject.Equipment).
                    Include(x => x.Teacher).Include(x => x.Classroom).Include(x => x.Classroom.Equipment).Include(x => x.Day).ToList();
                return lessons;
            }
        }

        public static List<OptimalityCriterion> OptimalityCriterions()
        {
            using (var context = new MyDbContext())
            {
                var optimalityCriterions = context.OptimalityCriterions.ToList();
                return optimalityCriterions;
            }
        }

        public static List<LessonFrame> LessonFrames()
        {
            using (var context = new MyDbContext())
            {
                var lessonFrames = context.LessonFrames.Include(x => x.Subject)
                    .Include(x => x.Teacher).Include(x => x.Subject.Equipment).Include(x => x.Flow).ToList();
                return lessonFrames;
            }
        }

        public static List<Equipment> Equipment()
        {
            using (var context = new MyDbContext())
            {
                var equipment = context.Equipment.Include(x => x.SpecialEquipment).ToList();
                return equipment;
            }
        }

        public static List<SpecialEquipmentInEquipment> SpecialEquipmentInEquipment()
        {
            using (var context = new MyDbContext())
            {
                var specialEquipmentInEquipment = context.SpecialEquipmentInEquipment.ToList();
                return specialEquipmentInEquipment;
            }
        }

        public static List<SubgroupsInGroup> SubgroupsInGroups()
        {
            using (var context = new MyDbContext())
            {
                var subgroupsInGroup = context.SubgroupsInGroups.ToList();
                return subgroupsInGroup;
            }
        }

        public static List<GroupsInFlow> GroupsInFlows()
        {
            using (var context = new MyDbContext())
            {
                var groupsInFlow = context.GroupsInFlows.ToList();
                return groupsInFlow;
            }
        }

        public static List<SpecialEquipment> SpecialEquipment()
        {
            using (var context = new MyDbContext())
            {
                var specialEquipment = context.SpecialEquipment.ToList();
                return specialEquipment;
            }
        }

        public static List<Flow> Flows()
        {
            using (var context = new MyDbContext())
            {
                var flows = context.Flows.ToList();
                return flows;
            }
        }

        public static List<FlowsLoad> FlowsLoad()
        {
            using (var context = new MyDbContext())
            {
                var flowsLoads = context.FlowsLoads.Include(fl => fl.Subject).Include(fl => fl.Flow).ToList();
                return flowsLoads;
            }
        }

        public static List<Subject> Subjects()
        {
            using (var context = new MyDbContext())
            {
                var subjects = context.Subjects.Include(x => x.Equipment).Include(x => x.SubjectType).ToList();
                return subjects;
            }
        }

        public static List<SubjectType> SubjectTypes()
        {
            using (var context = new MyDbContext())
            {
                var subjectTypes = context.SubjectTypes.ToList();
                return subjectTypes;
            }
        }

        public static List<Group> Groups()
        {
            using (var context = new MyDbContext())
            {
                var groups = context.Groups.Include(x => x.Flow).Include(x => x.Subgroups).ToList();
                return groups;
            }
        }

        public static List<Subgroup> Subgroups()
        {
            using (var context = new MyDbContext())
            {
                var subgroups = context.Subgroups.Include(x => x.Group).Include(x => x.Group.Flow).ToList();
                return subgroups;
            }
        }

        public static List<TeachersLoad> TeachersLoads()
        {
            using (var context = new MyDbContext())
            {
                var teachersLoads = context.TeachersLoads.Include(x => x.Teacher).Include(x => x.Subject).ToList();
                return teachersLoads;
            }
        }

        public static List<Classroom> Classrooms()
        {
            using (var context = new MyDbContext())
            {
                var classrooms = context.Classrooms.Include(x => x.Equipment).ToList();
                return classrooms;
            }
        }

        public static List<SubgroupsInLessonFrames> SubgroupsInLessonFrames()
        {
            using (var context = new MyDbContext())
            {
                var subgroupsInLessonFrames = context.SubgroupsInLessonFrames.ToList();
                return subgroupsInLessonFrames;
            }
        }

        public static List<SubgroupsInLessons> SubgroupsInLessons()
        {
            using (var context = new MyDbContext())
            {
                var subgroupsInLessons = context.SubgroupsInLessons.Include(x => x.Lesson).Include(x => x.Subgroup).ToList();
                return subgroupsInLessons;
            }
        }
    }
}