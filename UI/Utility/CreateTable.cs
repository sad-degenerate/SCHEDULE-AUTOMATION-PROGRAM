using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace UI.Utility
{
    public class CreateTable
    {
        public List<Lesson> Lessons { get; set; }

        public CreateTable(List<Lesson> lessons, int columns, int rows)
        {
            if (lessons.Count <= 0)
                throw new ArgumentNullException(nameof(lessons), "Список уроков для создания таблицы оказался пуст.");
            if (columns <= 0)
                throw new ArgumentException("Количество столбцов для составления таблицы не должно быть меньше либо равно нулю.", nameof(columns));
            if (rows <= 0)
                throw new ArgumentException("Количество строк для составления таблицы не должно быть меньше либо равно нулю.", nameof(rows));

            Lessons = lessons;
        }

        public void CreateNewTable()
        {
               
        }
    }
}