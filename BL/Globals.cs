using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;

namespace BL
{
    public static class Globals
    {
        public static int MaxLessonsInDay { get; set; } = 6;


        public static Dictionary<string, ModelObjectsTypes> Classes = new Dictionary<string, ModelObjectsTypes>()
        {
            { "Список учителей", ModelObjectsTypes.teacher },
            { "Список аудиторий", ModelObjectsTypes.classroom },
            { "Список оборудования", ModelObjectsTypes.equipment },
            { "Список дополнительного оборудования", ModelObjectsTypes.specialEquipment },
            { "Список групп", ModelObjectsTypes.group },
            { "Список предметов", ModelObjectsTypes.subject },
            { "Список потоков", ModelObjectsTypes.flow },
            { "Список подгрупп", ModelObjectsTypes.subgroup },
        };

        private static List<string> Days = new List<string>()
        {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"
        };

        public static void CreateWeak(int count)
        {
            if (count <= 0 || count > 7)
                throw new ArgumentException();

            foreach (var day in Select.Days())
                Delete<Day>.DeleteFromTable(day);

            for (var i = 1; i <= count; i++)
                Insert<Day>.InsertOriginal(new Day(Days[i - 1], i), Select.Days());
        }
    }
}