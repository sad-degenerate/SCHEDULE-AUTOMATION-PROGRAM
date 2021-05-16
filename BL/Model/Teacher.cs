using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<TeachersLoad> TeachersLoads { get; set; }
        public virtual ICollection<LessonFrame> LessonFrames { get; set; }

        public Teacher() { }

        public Teacher(List<object> list)
        {
            var name = list[0].ToString();

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Не удалось считать имя преподавателя, оно равно - null.");

            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}