using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class TeachersLoad
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int Load { get; set; }

        public TeachersLoad() { }

        public TeachersLoad(List<object> list)
        {
            var subject = list[0] as Subject;
            var teacher = list[2] as Teacher;
            if (!int.TryParse(list[1].ToString(), out var load))
                throw new ArgumentNullException(nameof(load), "Нагрузка преподавателя имеет не целочисленный формат, проверьте правильность ввода.");

            if (load <= 0)
                throw new ArgumentException("Нагрузка преподавателя меньше либо равна нулю.", nameof(load));

            TeacherId = teacher.Id;
            SubjectId = subject.Id;
            Load = load;
        }

        public override string ToString()
        {
            return $"{Subject.Name}  {Load}";
        }
    }
}