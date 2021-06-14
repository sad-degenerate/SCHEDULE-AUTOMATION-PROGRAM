using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public Classroom() { }

        public Classroom(string name, int equipmentId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название аудитории.");

            Name = name;
            EquipmentId = equipmentId;
        }

        public override bool Equals(object obj)
        {
            if (obj is Classroom)
            {
                var another = obj as Classroom;

                if (another.Name == Name)
                    return true;
            }

            return false;
        }
    }
}