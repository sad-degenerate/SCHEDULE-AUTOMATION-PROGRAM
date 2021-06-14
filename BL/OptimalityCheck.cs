using BL.Commands;
using BL.Model;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public static class OptimalityCheck
    {
        private static List<Lesson> _schedule;
        private static List<SubgroupsInLessons> _subgroupsInLessons;
        private static double _overallScore;

        public static double Check(List<Lesson> schedule, List<SubgroupsInLessons> subgroupsInLessons)
        {
            _schedule = schedule;
            _subgroupsInLessons = subgroupsInLessons;
            _overallScore = 0d;

            var optimalityCriterions = Select.OptimalityCriterions();

            IsGroupsBusyDays(optimalityCriterions.Where(x => x.Code == "teachersBusy").First().Value);
            IsTeachersBusyDay(optimalityCriterions.Where(x => x.Code == "groupsBusy").First().Value);
            TeachersWindow(optimalityCriterions.Where(x => x.Code == "teachersWindow").First().Value);
            GroupsWindow(optimalityCriterions.Where(x => x.Code == "groupsWindow").First().Value);
            LateLessons(optimalityCriterions.Where(x => x.Code == "lateLessons").First().Value);


            return _overallScore;
        }

        private static void LateLessons(double mult)
        {
            var result = 0d;

            foreach (var day in Select.Days())
            {
                var lessons = _schedule.Where(x => x.DayId == day.Id);
                foreach (var lesson in lessons)
                    if (lesson.LessonTime > 4)
                        result += 1;
            }

            _overallScore -= result * mult;
        }

        private static void GroupsWindow(double mult)
        {
            var result = 0d;
                
            var subgroups = Select.Subgroups();
            foreach (var subgroup in subgroups)
            {
                var subgroupsInlessons = Select.SubgroupsInLessons().Where(x => x.SubgroupId == subgroup.Id);
                foreach (var day in Select.Days()) 
                {
                    var currentSubgroupInLessons = subgroupsInlessons.Where(x => x.Lesson.DayId == day.Id);
                    var lessons = new List<Lesson>();
                    if (currentSubgroupInLessons.Count() == 0)
                        continue;
                    foreach (var currentSubgroupInlesson in currentSubgroupInLessons)
                        lessons.Add(Select.Lessons().Where(x => x.Id == currentSubgroupInlesson.LessonId).First());

                    if (IsExistWindow(lessons) == true)
                        result += 1;
                }
            }
            
            _overallScore -= result * mult;
        }

        private static void TeachersWindow(double mult)
        {
            var result = 0d;

            foreach (var day in Select.Days())
            {
                var lessons = _schedule.Where(x => x.DayId == day.Id);
                foreach (var teacher in Select.Teachers())
                {
                    if (lessons.Where(x => x.TeacherId == teacher.Id).FirstOrDefault() == null)
                        continue;

                    if (IsExistWindow(lessons.Where(x => x.TeacherId == teacher.Id)) == true)
                        result += 1;
                }
                    
            }

            _overallScore -= result * mult;
        }

        private static bool IsExistWindow(IEnumerable<Lesson> input)
        {
            var lessons = input.OrderBy(x => x.LessonTime).ToList();
            for (var i = 0; i < lessons.Count() - 1; i++)
                if (lessons[i + 1].LessonTime - lessons[i].LessonTime != 1)
                    return true;

            return false;
        }

        private static void IsTeachersBusyDay(double mult)
        {
            var result = 0d;

            foreach (var day in Select.Days())
            {
                var lessons = _schedule.Where(x => x.DayId == day.Id);
                foreach (var teacher in Select.Teachers())
                {
                    var teacherBusy = lessons.Where(x => x.TeacherId == teacher.Id).Count();
                    if (teacherBusy > 4)
                        result += 1;
                }
            }

            _overallScore -= result * mult;
        }

        private static void IsGroupsBusyDays(double mult)
        {
            var result = 0d;

            foreach (var day in Select.Days())
            {
                var lessons = _schedule.Where(x => x.DayId == day.Id);

                var subgroups = _subgroupsInLessons;
                var groupsBusy = new Dictionary<int, int>();

                foreach (var lesson in lessons)
                {
                    var subgroupsInLesson = subgroups.Where(x => x.LessonId == lesson.Id);

                    foreach (var sub in subgroupsInLesson)
                    {
                        if (groupsBusy.ContainsKey(sub.SubgroupId))
                        {
                            groupsBusy[sub.SubgroupId] += 1;
                        }
                        else
                        {
                            groupsBusy.Add(sub.SubgroupId, 1);
                        }
                    }
                }

                foreach (var busy in groupsBusy)
                    if (busy.Value > 4)
                        result += 1;
            }

            _overallScore -= result * mult;
        }
    }
}