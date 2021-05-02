using System;
using System.Collections.Generic;

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

        public TeachersLoad(List<object> list)
        {
            var teacher = list[0] as Teacher;
            var subject = list[1] as Subject;
            var load = int.Parse(list[2].ToString());

            if (load <= 0)
                throw new ArgumentException("TeachersLoad's load is less than zero.", nameof(load));

            TeacherId = teacher.Id;
            SubjectId = subject.Id;
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