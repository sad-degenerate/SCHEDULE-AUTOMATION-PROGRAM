using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
        public virtual ICollection<SpecialEquipment> SpecialEquipment { get; set; }

        public Equipment() { }

        public Equipment(string name, int numberOfSeats)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название оборудования.");
            if (numberOfSeats <= 0)
                throw new ArgumentException("Вы ввели неправильное количество мест (меньше нуля).", nameof(numberOfSeats));

            Name = name;
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Equipment)
            {
                var another = obj as Equipment;

                if (another.Name == Name)
                    return true;
            }

            return false;
        }
    }
}