using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Lesson
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }

        public int DayId { get; set; }
        public virtual Day Day { get; set; }

        public int LessonTime { get; set; }

        public virtual ICollection<Subgroup> Subgroups { get; set; }

        public Lesson() { }

        public Lesson(int subjectId, int teacherId, int classroomId, int dayId, int lessonTime)
        {
            if (lessonTime <= 0 || lessonTime > Globals.MaxLessonsInDay)
                throw new ArgumentException();

            SubjectId = subjectId;
            TeacherId = teacherId;
            ClassroomId = classroomId;
            DayId = dayId;
            LessonTime = lessonTime;
        }
    }
}