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

        public Equipment() { }

        public Equipment(List<object> list)
        {
            var name = list[0].ToString();
            if (!int.TryParse(list[1].ToString(), out int numberOfSeats))
                throw new ArgumentException("Вы ввели не число!", nameof(numberOfSeats));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Название оборудования - пусто.");
            if (numberOfSeats <= 0)
                throw new ArgumentException("Количество сидений оборудования меньше либо равно нулю.");

            Name = name;
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}