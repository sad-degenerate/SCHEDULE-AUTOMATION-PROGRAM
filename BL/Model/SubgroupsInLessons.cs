namespace BL.Model
{
    public class SubgroupsInLessons
    {
        public int Id { get; set; }

        public int SubgroupId { get; set; }
        public virtual Subgroup Subgroup { get; set; }

        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public SubgroupsInLessons() { }

        public SubgroupsInLessons(int subgroupId, int lessonId)
        {
            SubgroupId = subgroupId;
            LessonId = lessonId;
        }
    }
}
