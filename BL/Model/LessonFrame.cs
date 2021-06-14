namespace BL.Model
{
    public class LessonFrame
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int FlowId { get; set; }
        public virtual Flow Flow { get; set; }

        public double? FreedoomOfLocation { get; set; }
        public int LessonFrameCount { get; set; }

        public LessonFrame() { }

        public LessonFrame(Teacher teacher, Subject subject, Flow flow)
        {
            LessonFrameCount = 1;
            SubjectId = subject.Id;
            TeacherId = teacher.Id;
            FlowId = flow.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is LessonFrame)
            {
                var another = obj as LessonFrame;

                if (another.Id == Id)
                    return true;
            }

            return false;
        }
    }
}