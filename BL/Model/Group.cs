using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }

        public virtual ICollection<GroupsLoad> GroupsLoads { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<LessonFrame> LessonFrames { get; set; }

        public Group() { }

        public Group(List<object> list)
        {
            var name = list[0].ToString();
            if (!int.TryParse(list[1].ToString(), out int numberOfStudents))
                throw new ArgumentException("В поле количество студентов было введено не число.", nameof(numberOfStudents));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Название группы - пусто.");
            if (numberOfStudents <= 0)
                throw new ArgumentException("Количество студентов в группе меньше либо равно нулю.", nameof(numberOfStudents));

            Name = name;
            NumberOfStudents = numberOfStudents;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}