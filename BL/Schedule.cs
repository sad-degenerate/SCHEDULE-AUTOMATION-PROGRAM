using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Schedule
    {
        public Dictionary<Lesson, int> results = new Dictionary<Lesson, int>();

        public void Start()
        {
            var groupsLoads = Select.GroupsLoads();

            foreach (var groupLoad in groupsLoads)
            {
                var teachersLoads = Select.TeachersLoads().Where(x => x.SubjectId == groupLoad.SubjectId);
                foreach (var teacherLoad in teachersLoads)
                {
                    if (teacherLoad.Load - groupLoad.Load >= 0)
                    {
                        teacherLoad.Load -= groupLoad.Load;
                        groupLoad.Load = 0;
                    }
                    else if (groupLoad.Load - teacherLoad.Load >= 0)
                    {
                        groupLoad.Load -= teacherLoad.Load;
                        teacherLoad.Load = 0;
                    }
                    else
                        throw new ArgumentException("Пока не доработано корректное распределение множества учителей.");

                    var createingList = new List<object>()
                    {
                        groupLoad.Subject,
                        teacherLoad.Teacher,
                        groupLoad.Group
                    };

                    Insert.LessonFrames(createingList);
                }
            }

            CheckEveryLesson();
        }

        private void CheckEveryLesson()
        {
            var lessonFrames = Select.LessonFrames();

            foreach (var lessonFrame in lessonFrames)
            {
                double classroomsCount = 0;
                foreach (var classroom in Select.Classrooms())
                    if (classroom.Equipment.Equals(lessonFrame.Subject.Equipment))
                        classroomsCount += 1;

                double teachersCount = Select.TeachersLoads().Where(tl => tl.SubjectId == lessonFrame.SubjectId).Count();
                double groupsCount = Select.GroupsLoads().Where(gl => gl.SubjectId == lessonFrame.SubjectId).Count();

                lessonFrame.FreedoomOfLocation = classroomsCount / (teachersCount * groupsCount);
            }

            Update<LessonFrame>.UpdateTable(lessonFrames);

            CheckOptimality();
        }

        private List<LessonFrame> Sort()
        {
            var lessonsFrames = Select.LessonFrames();
            return lessonsFrames.OrderBy(x => x.FreedoomOfLocation).ToList();
        }

        private void CheckOptimality()
        {
            var lessonsFames = Sort();
            var result = new Dictionary<Lesson, int>();

            foreach (var lessonFrame in lessonsFames)
            {
                foreach (var classroom in Select.Classrooms())
                    foreach (var lessonTime in Select.LessonTimes())
                    {
                        var list = new List<object>()
                        {
                            lessonTime,
                            lessonFrame.Subject,
                            lessonFrame.Teacher,
                            lessonFrame.Group,
                            classroom
                        };

                        var param = new int[]
                        {
                            10, 20
                        };

                        Insert.Lessons(list);

                        var lesson = new Lesson(list);

                        // Параметры будут описаны в UI.
                        var optimalityCheck = new OptimalityCheck(lesson, param);
                        result.Add(lesson, optimalityCheck.Optimality);
                    }
            }

            results = result;
        }
    }
}