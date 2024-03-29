﻿using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<TeachersLoad> TeachersLoads { get; set; }
        public virtual ICollection<LessonFrame> LessonFrames { get; set; }

        public Teacher() { }

        public Teacher(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Вы не ввели ФИО преподавателя.");

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Teacher)
            {
                var another = obj as Teacher;

                if (another.Name == Name)
                    return true;
            }

            return false;
        }
    }
}