using System.Collections.Generic;

namespace BL.Model
{
    public class LessonFrame
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int? FreedoomOfLocation { get; set; }

        public LessonFrame() { }

        public LessonFrame(List<object> list)
        {
            var subject = list[0] as Subject;
            var teacher = list[1] as Teacher;
            var group = list[2] as Group;

            SubjectId = subject.Id;
            TeacherId = teacher.Id;
            GroupId = group.Id;
        }

        public override string ToString()
        {
            return $"{Subject.Name} - ({Teacher.Name}/{Group.Name})";
        }
    }
}