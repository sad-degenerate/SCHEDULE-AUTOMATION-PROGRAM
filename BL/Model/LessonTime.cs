using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class LessonTime
    {
        public int Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public LessonTime() { }

        public LessonTime(List<object> list)
        {
            if (!DateTime.TryParse(list[0].ToString(), out DateTime start))
                throw new ArgumentException("Невозможно обработать время.", nameof(start));
            if (!DateTime.TryParse(list[1].ToString(), out DateTime end))
                throw new ArgumentException("Невозможно обработать время.", nameof(end));

            Start = start.TimeOfDay;
            End = end.TimeOfDay;
        }

        public override string ToString()
        {
            return $"{Start} - {End}";
        }
    }
}