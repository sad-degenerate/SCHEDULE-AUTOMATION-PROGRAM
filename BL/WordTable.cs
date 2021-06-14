using System;
using System.Collections.Generic;
using System.Linq;
using BL.Commands;
using BL.Model;
using Microsoft.Office.Interop.Word;

namespace BL
{
    public static class WordTable
    {
        public static void Lesson(List<Lesson> lessons, List<SubgroupsInLessons> subgroupsInLessons)
        {
            var subgroups = Select.Subgroups();
            foreach (var day in Select.Days())
            {
                var app = new Application();

                object missing = Type.Missing;

                app.Visible = true;

                var doc = app.Documents.Add(Visible: true);

                object behiavor = WdDefaultTableBehavior.wdWord9TableBehavior;
                object autoFitBehiavor = WdAutoFitBehavior.wdAutoFitFixed;
                int columns = subgroups.Count;
                var range = doc.Range();
                var table = doc.Tables.Add(range, 1, columns, ref behiavor, ref autoFitBehiavor);

                var placement = new Dictionary<int, int>();

                for (var subgroup = 0; subgroup < subgroups.Count; subgroup++)
                {
                    table.Rows[1].Cells[subgroup + 1].Range.Text =
                        $"{subgroups[subgroup].Group.Flow.Name}{subgroups[subgroup].Group.Name}{subgroups[subgroup].Name}";
                    placement.Add(subgroups[subgroup].Id, subgroup + 1);
                }

                for (var lessonTime = 1; lessonTime <= Globals.MaxLessonsInDay; lessonTime++)
                {
                    var subList = subgroupsInLessons.Where(x => x.Lesson.LessonTime == lessonTime)
                        .Where(x => x.Lesson.DayId == day.Id);

                    table.Rows.Add(ref missing);
                    foreach (var sub in subList)
                    {
                        var lesson = lessons.Where(x => x.Id == sub.LessonId).First();
                        table.Rows[lessonTime + 1].Cells[placement[sub.SubgroupId]].Range.Text =
                            $"{lesson.Subject.Name}\n{lesson.Teacher.Name}\n{lesson.Classroom.Name}";
                    }
                }
            }
        }
    }
}