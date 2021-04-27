using System;

namespace BL.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public Subject() { }

        public Subject(string name, int equipmentId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Subject's name is null.");

            Name = name;
            EquipmentId = equipmentId;
        }

        public Subject(int id, string name, Equipment equipment)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Subject's name is null.");

            Id = id;
            Name = name;
            Equipment = equipment;
            EquipmentId = equipment.Id;
        }
    }
}