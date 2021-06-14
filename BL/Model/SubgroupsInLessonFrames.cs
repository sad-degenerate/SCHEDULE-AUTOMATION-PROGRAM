namespace BL.Model
{
    public class SubgroupsInLessonFrames
    {
        public int Id { get; set; }

        public int SubgroupId { get; set; }
        public virtual Subgroup Subgroup { get; set; }

        public int LessonFrameId { get; set; }
        public virtual LessonFrame LessonFrame { get; set; }

        public SubgroupsInLessonFrames() { }

        public SubgroupsInLessonFrames(int subgroupId, int lessonFrameId)
        {
            SubgroupId = subgroupId;
            LessonFrameId = lessonFrameId;
        }

        public override bool Equals(object obj)
        {
            if (obj is SubgroupsInLessonFrames)
            {
                var another = obj as SubgroupsInLessonFrames;

                if (another.LessonFrameId == LessonFrameId && another.SubgroupId == SubgroupId)
                    return true;
            }

            return false;
        }
    }
}