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
                throw new ArgumentNullException(nameof(name), "Название аудитории - пусто.");
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment), "Не выбрано оборудование.");

            Name = name;
            EquipmentId = equipment.Id;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}