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

        public Classroom(List<object> list)
        {
            var name = list[0].ToString();
            var equipment = list[1] as Equipment;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Classroom's name is null.");

            Name = name;
            EquipmentId = equipment.Id;
        }

        public Classroom(int id, string name, Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Classroom's name is null.");

            Id = id;
            Name = name;
            Equipment = equipment;
            EquipmentId = equipment.Id;
        }
    }
}