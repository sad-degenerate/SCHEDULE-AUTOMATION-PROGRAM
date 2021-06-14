using System;

namespace BL.Model
{
    public class FlowsLoad
    {
        public int Id { get; set; }

        public int FlowId { get; set; }
        public virtual Flow Flow { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int Load { get; set; }

        public FlowsLoad() { }

        public FlowsLoad(int flowId, int subjectId, int load)
        {
            if (load <= 0)
                throw new ArgumentException("Вы ввели неверную нагрузку потока (меньше нуля).", nameof(load));

            FlowId = flowId;
            SubjectId = subjectId;
            Load = load;
        }

        public override bool Equals(object obj)
        {
            if (obj is FlowsLoad)
            {
                var another = obj as FlowsLoad;

                if (another.FlowId == FlowId && another.SubjectId == SubjectId)
                    return true;
            }

            return false;
        }
    }
}