using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class GroupsLoad
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int Load { get; set; }

        public GroupsLoad() { }

        public GroupsLoad(List<object> list)
        {
            var group = list[2] as Group;
            var subject = list[0] as Subject;
            if (!int.TryParse(list[1].ToString(), out var load))
                throw new ArgumentNullException(nameof(load), "Нагрузка группы имеет не целочисленный формат, проверьте правильность ввода.");

            if (load <= 0)
                throw new ArgumentException("Нагрузка группы меньше либо равна нулю.");

            GroupId = group.Id;
            SubjectId = subject.Id;
            Load = load;
        }

        public override string ToString()
        {
            return $"{Group.Name} - {Subject.Name} ({Load})";
        }
    }
}