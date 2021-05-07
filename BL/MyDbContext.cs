using BL.Model;
using System.Data.Entity;

namespace BL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("TestDatabase") { }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GroupsLoad> GroupsLoads { get; set; }
        public DbSet<TeachersLoad> TeachersLoads { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<LessonTime> LessonTimes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}