using BL.Model;
using System.Data.Entity;

namespace BL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("TestDatabase") { }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<SpecialEquipment> SpecialEquipment { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeachersLoad> TeachersLoads { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonFrame> LessonFrames { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Flow> Flows { get; set; }
        public DbSet<SubgroupsInLessonFrames> SubgroupsInLessonFrames { get; set; }
        public DbSet<SubgroupsInLessons> SubgroupsInLessons { get; set; }
        public DbSet<FlowsLoad> FlowsLoads { get; set; }
        public DbSet<SubjectType> SubjectTypes { get; set; }
        public DbSet<Subgroup> Subgroups { get; set; }
        public DbSet<SpecialEquipmentInEquipment> SpecialEquipmentInEquipment { get; set; }
        public DbSet<SubgroupsInGroup> SubgroupsInGroups { get; set; }
        public DbSet<GroupsInFlow> GroupsInFlows { get; set; }
        public DbSet<OptimalityCriterion> OptimalityCriterions { get; set; }
    }
}