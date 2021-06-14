using BL.Commands;
using BL.Model;
using System.Collections.Generic;

namespace BL
{
    public static class OnStart
    {
        public static void Start()
        {
            if (Select.Days().Count == 0)
                Globals.CreateWeak(6);

            if (Select.SubjectTypes().Count == 0)
                CreateDefaultSubjectTypes();

            if (Select.OptimalityCriterions().Count == 0)
                CreateDefaultOptimalityCriterions();
        }

        private static void CreateDefaultOptimalityCriterions()
        {
            var items = new Dictionary<string, string>()
            {
                { "teachersBusy", "Загруженность учителей в день" },
                { "groupsBusy", "Загруженность групп в день" },
                { "teachersWindow", "Окна преподавателей" },
                { "groupsWindow", "Окна групп" },
                { "lateLessons", "Поздние уроки" }
            };

            foreach (var item in items)
                Insert<OptimalityCriterion>.InsertOriginal(new OptimalityCriterion(item.Value, item.Key, 1), Select.OptimalityCriterions());
        }

        private static void CreateDefaultSubjectTypes()
        {
            var items = new Dictionary<string, string>()
            {
                { "lecture", "Лекция" },
                { "group_seminar", "Семинар (группа)" },
                { "subgroup_seminar", "Семинар (подгруппа)" }
            };

            foreach (var item in items)
                Insert<SubjectType>.InsertOriginal(new SubjectType(item.Value, item.Key), Select.SubjectTypes());
        }
    }
}