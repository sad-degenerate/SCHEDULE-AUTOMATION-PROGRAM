using System;

namespace BL.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }

        public Group() { }

        public Group(string name, int numberOfStudents)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Group's name is null.");
            if (numberOfStudents <= 0)
                throw new ArgumentException("Group's number of students is less than zero.", nameof(numberOfStudents));

            Name = name;
            NumberOfStudents = numberOfStudents;
        }

        public Group(int id, string name, int numberOfStudents)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Group's name is null.");
            if (numberOfStudents <= 0)
                throw new ArgumentException("Group's number of students is less than zero.", nameof(numberOfStudents));

            Id = id;
            Name = name;
            NumberOfStudents = numberOfStudents;
        }
    }
}