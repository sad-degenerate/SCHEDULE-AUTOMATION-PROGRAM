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
            var group = list[0] as Group;
            var subject = list[1] as Subject;
            var load = int.Parse(list[2].ToString());

            if (load <= 0)
                throw new ArgumentException("GroupsLoad's load is less than zero.");

            GroupId = group.Id;
            SubjectId = subject.Id;
            Load = load;
        }

        public GroupsLoad(int id, Group group, Subject subject, int load)
        {
            if (load <= 0)
                throw new ArgumentException("GroupsLoad's load is less than zero.");

            Id = id;
            Group = group;
            GroupId = group.Id;
            Subject = subject;
            SubjectId = subject.Id;
            Load = load;
        }
    }
}