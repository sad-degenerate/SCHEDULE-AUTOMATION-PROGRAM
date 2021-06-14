using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Flow
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<LessonFrame> LessonFrames { get; set; }

        public Flow() { }

        public Flow(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели название потока.");

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Flow)
            {
                var another = obj as Flow;

                if (another.Name == Name)
                    return true;
            }

            return false;
        }
    }
}