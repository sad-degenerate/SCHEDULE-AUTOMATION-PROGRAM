using System;

namespace BL.Model
{
    public class TeachersLoad
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int Load { get; set; }

        public TeachersLoad() { }

        public TeachersLoad(int subjectId, int teacherId, int load)
        {
            if (load <= 0)
                throw new ArgumentException("Вы ввели неверно нагрузку преподавателя (меньше либо равна нулю).", nameof(load));

            TeacherId = teacherId;
            SubjectId = subjectId;
            Load = load;
        }

        public override bool Equals(object obj)
        {
            if (obj is TeachersLoad)
            {
                var another = obj as TeachersLoad;

                if (another.SubjectId == SubjectId && another.TeacherId == TeacherId)
                    return true;
            }

            return false;
        }
    }
}