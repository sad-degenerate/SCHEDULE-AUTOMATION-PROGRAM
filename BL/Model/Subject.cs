using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public int SubjectTypeId { get; set; }
        public virtual SubjectType SubjectType { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<LessonFrame> LessonFrames { get; set; }

        public Subject() { }

        public Subject(string name, int equipmentId, int typeId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название предмета.");

            Name = name;
            EquipmentId = equipmentId;
            SubjectTypeId = typeId;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Subject)
            {
                var another = obj as Subject;

                if (another.Name == Name && another.SubjectTypeId == SubjectTypeId)
                    return true;
            }

            return false;
        }
    }
}