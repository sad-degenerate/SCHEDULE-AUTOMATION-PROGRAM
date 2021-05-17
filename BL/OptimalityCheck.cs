using BL.Commands;
using BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class OptimalityCheck
    {
        public int Optimality { get; }
        private List<Lesson> lessons = Select.Lessons();
        private Lesson lesson;

        public OptimalityCheck(Lesson lessonSet, params int[] multipliers)
        {
            // Здесь выставляются коэффициенты.

            lesson = lessonSet;

            Optimality += IsBusyDay(multipliers[0]);
            Optimality += SeatsOverflow(multipliers[1]);
        }

        private int IsBusyDay(int multipler)
        {
            return 10 * multipler;
        }

        private int SeatsOverflow(int multipler)
        {
            var classroom = Select.Classrooms().Where(c => c.Id == lesson.ClassroomId).ToList().First();
            var subject = Select.Subjects().Where(s => s.Id == lesson.SubjectId).ToList().First();

            if (classroom.Equipment.NumberOfSeats > subject.Equipment.NumberOfSeats)
                return 1 * multipler;
            else
                return -1 * multipler;
        }
    }
}