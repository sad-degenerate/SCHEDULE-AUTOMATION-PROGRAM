using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class SpecialEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }

        public SpecialEquipment() { }

        public SpecialEquipment(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название специального оборудования.");

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is SpecialEquipment)
            {
                var another = obj as SpecialEquipment;

                if (another.Name == Name)
                    return true;
            }

            return false;
        }
    }
}