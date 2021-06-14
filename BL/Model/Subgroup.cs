using System;

namespace BL.Model
{
    public class Subgroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public Subgroup() { }

        public Subgroup(string name, int numberOfStudents, int groupId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название подгруппы.");
            if (numberOfStudents <= 0)
                throw new ArgumentException("Вы ввели неверное количество студентов (меньше нуля).", nameof(numberOfStudents));

            Name = name;
            NumberOfStudents = numberOfStudents;
            GroupId = groupId;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Subgroup)
            {
                var another = obj as Subgroup;

                if (another.Name == Name && another.GroupId == GroupId)
                    return true;
            }

            return false;
        }
    }
}