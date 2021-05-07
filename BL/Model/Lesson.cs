﻿using System.Collections.Generic;

namespace BL.Model
{
    public class Lesson
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int LessonTimeId { get; set; }
        public virtual LessonTime LessonTime { get; set; }
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }

        public Lesson() { }

        public Lesson(List<object> list)
        {
            // TODO: Возможно проверки.
            var lessonTime = list[0] as LessonTime;
            var subject = list[1] as Subject;
            var teacher = list[2] as Teacher;
            var group = list[3] as Group;

            LessonTimeId = lessonTime.Id;
            SubjectId = subject.Id;
            TeacherId = teacher.Id;
            GroupId = group.Id;
        }

        public Lesson(int id, int subjectId, int teacherId, int groupId, int lessonTimeId)
        {
            Id = id;
            LessonTime = LessonTime;
            SubjectId = subjectId;
            TeacherId = teacherId;
            GroupId = groupId;
        }
    }
}