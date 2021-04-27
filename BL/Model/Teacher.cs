using System;

namespace BL.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Teacher() { }

        public Teacher(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Teacher's name is null.");

            Name = name;
        }

        public Teacher(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Teacher's name is null.");

            Id = id;
            Name = name;
        }
    }
}