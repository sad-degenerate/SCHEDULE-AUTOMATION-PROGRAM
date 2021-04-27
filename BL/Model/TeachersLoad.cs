using System;

namespace BL.Model
{
    public class TeachersLoad
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int Load { get; set; }

        public TeachersLoad() { }

        public TeachersLoad(int teacherId, int subjectId, int load)
        {
            if (load <= 0)
                throw new ArgumentException("TeachersLoad's load is less than zero.", nameof(load));

            TeacherId = teacherId;
            SubjectId = subjectId;
            Load = load;
        }

        public TeachersLoad(int id, Teacher teacher, Subject subject, int load)
        {
            if (load <= 0)
                throw new ArgumentException("TeachersLoad's load is less than zero.", nameof(load));

            Id = id;
            Teacher = teacher;
            TeacherId = teacher.Id;
            Subject = subject;
            SubjectId = subject.Id;
            Load = load;
        }
    }
}