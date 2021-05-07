using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class LessonTime
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public LessonTime() { }

        public LessonTime(List<object> list)
        {
            if (!DateTime.TryParse(list[0].ToString(), out DateTime start))
                throw new ArgumentException("Невозможно обработать время.");
            if (!DateTime.TryParse(list[1].ToString(), out DateTime end))
                throw new ArgumentException("Невозможно обработать время.");

            Start = start;
            End = end;
        }

        public LessonTime(int id, DateTime start, DateTime end)
        {
            Id = id;
            Start = start;
            End = end;
        }
    }
}