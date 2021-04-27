using System;

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

        public GroupsLoad(int groupId, int subjectId, int load)
        {
            if (load <= 0)
                throw new ArgumentException("GroupsLoad's load is less than zero.");

            GroupId = groupId;
            SubjectId = subjectId;
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