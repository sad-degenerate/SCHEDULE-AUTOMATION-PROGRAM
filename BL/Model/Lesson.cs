//namespace BL.Model
//{
//    public class Lesson
//    {
//        public int Id { get; set; }
//        public int SubjectId { get; set; }
//        public virtual Subject Subject { get; set; }
//        public int TeacherId { get; set; }
//        public virtual Teacher Teacher { get; set; }
//        public int GroupId { get; set; }
//        public virtual Group Group { get; set; }
//        public int LessonTimeId { get; set; }
//        public virtual LessonTime LessonTime { get; set; }
//        public int ClassroomId { get; set; }
//        public virtual Classroom Classroom { get; set; }

//        public Lesson() { }

//        public Lesson(int subjectId, int teacherId, int groupId, LessonTime lessonTime)
//        {
//            LessonTime = lessonTime;
//            SubjectId = subjectId;
//            TeacherId = teacherId;
//            GroupId = groupId;
//        }

//        public Lesson(int id, int subjectId, int teacherId, int groupId, LessonTime lessonTime)
//        {
//            Id = id;
//            LessonTime = LessonTime;
//            SubjectId = subjectId;
//            TeacherId = teacherId;
//            GroupId = groupId;
//        }
//    }
//}