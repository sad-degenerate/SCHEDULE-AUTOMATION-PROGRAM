using BL.Model;

namespace BL.Commands
{
    public static class Insert
    {
        public static void Teacher(string name)
        {
            using (var context = new MyDbContext())
            {
                context.Teachers.Add(new Teacher(name));
                context.SaveChanges();
            }
        }

        public static void Equipment(string name, int numberOfSeats)
        {
            using (var context = new MyDbContext())
            {
                context.Equipment.Add(new Equipment(name, numberOfSeats));
                context.SaveChanges();
            }
        }

        public static void Subject(string name, int equipmentId)
        {
            using (var context = new MyDbContext())
            {
                context.Subjects.Add(new Subject(name, equipmentId));
                context.SaveChanges();
            }
        }

        public static void GroupsLoad(int groupId, int subjectId, int load)
        {
            using (var context = new MyDbContext())
            {
                context.GroupsLoads.Add(new GroupsLoad(groupId, subjectId, load));
                context.SaveChanges();
            }
        }

        public static void TeachersLoad(int teacherId, int subjectId, int load)
        {
            using (var context = new MyDbContext())
            {
                context.TeachersLoads.Add(new TeachersLoad(teacherId, subjectId, load));
                context.SaveChanges();
            }
        }

        public static void Group(string name, int numberOfStudents)
        {
            using (var context = new MyDbContext())
            {
                context.Groups.Add(new Group(name, numberOfStudents));
                context.SaveChanges();
            }
        }

        public static void Classroom(string name, int equipmentId)
        {
            using (var context = new MyDbContext())
            {
                context.Classrooms.Add(new Classroom(name, equipmentId));
                context.SaveChanges();
            }
        }
    }
}