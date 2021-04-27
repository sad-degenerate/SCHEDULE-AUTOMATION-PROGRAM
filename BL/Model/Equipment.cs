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

        public Equipment(string name, int numberOfSeats)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Equipment's name is null.");
            if (numberOfSeats <= 0)
                throw new ArgumentException("Equipment's number of seats is less than zero.");

            Name = name;
            NumberOfSeats = numberOfSeats;
        }

        public Equipment(int id, string name, int numberOfSeats, ICollection<Subject> subjects, ICollection<Classroom> classrooms)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Equipment's name is null.");
            if (numberOfSeats <= 0)
                throw new ArgumentException("Equipment's number of seats is less than zero.");

            Id = id;
            Name = name;
            NumberOfSeats = numberOfSeats;
            Subjects = subjects;
            Classrooms = classrooms;
        }
    }
}