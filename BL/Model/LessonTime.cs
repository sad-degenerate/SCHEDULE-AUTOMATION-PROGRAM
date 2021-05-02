//using System;
//using System.Collections.Generic;

//namespace BL.Model
//{
//    public class LessonTime
//    {
//        public int Id { get; set; }
//        public DateTime Start { get; set; }
//        public DateTime End { get; set; }

//        public virtual ICollection<Lesson> Lessons { get; set; }

//        public LessonTime() { }

//        public LessonTime(DateTime start, DateTime end)
//        {
//            Start = start;
//            End = end;
//        }

//        public LessonTime(int id, DateTime start, DateTime end)
//        {
//            Id = id;
//            Start = start;
//            End = end;
//        }
//    }
//}