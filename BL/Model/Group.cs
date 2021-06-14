using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FlowId { get; set; }
        public virtual Flow Flow { get; set; }

        public virtual ICollection<Subgroup> Subgroups { get; set; }

        public Group() { }

        public Group(string name, int flowId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название группы.");

            Name = name;
            FlowId = flowId;
        }

        public override string ToString()
        {
            return $"{Flow}{Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Group)
            {
                var another = obj as Group;

                if (another.Name == Name && another.FlowId == FlowId)
                    return true;
            }

            return false;
        }
    }
}