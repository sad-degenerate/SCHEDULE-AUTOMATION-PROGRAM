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

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<LessonFrame> LessonFrames { get; set; }

        public Subject() { }

        public Subject(List<object> list)
        {
            var name = list[0].ToString();
            var equipment = list[1] as Equipment;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Название предмета - пусто.");

            Name = name;
            EquipmentId = equipment.Id;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}