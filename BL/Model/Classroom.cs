using System;

namespace BL.Model
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public Classroom() { }

        public Classroom(string name, int equipmentId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Classroom's name is null.");

            Name = name;
            EquipmentId = equipmentId;
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