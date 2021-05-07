using BL.Model;
using System.Collections.Generic;

namespace BL.Commands
{
    public static class Select
    {
        public static List<Teacher> Teachers()
        {
            var result = new List<Teacher>();

            using (var context = new MyDbContext())
            {
                var teachers = context.Teachers;

                foreach (var teacher in teachers)
                {
                    var newTeacher = new Teacher(teacher.Id, teacher.Name);
                    result.Add(newTeacher);
                }
            }

            return result;
        }

        public static List<Lesson> Lessons()
        {
            var result = new List<Lesson>();

            using (var context = new MyDbContext())
            {
                var lessons = context.Lessons;

                foreach (var lesson in lessons)
                {
                    var newLesson = new Lesson(lesson.Id, lesson.SubjectId, lesson.TeacherId, lesson.GroupId, lesson.LessonTimeId);
                    result.Add(newLesson);
                }
            }

            return result;
        }

        public static List<LessonTime> LessonTimes()
        {
            var result = new List<LessonTime>();

            using (var context = new MyDbContext())
            {
                var lessonTimes = context.LessonTimes;

                foreach (var lessonTime in lessonTimes)
                {
                    var newLessonTime = new LessonTime(lessonTime.Id, lessonTime.Start, lessonTime.End);
                    result.Add(newLessonTime);
                }
            }

            return result;
        }

        public static List<Equipment> Equipment()
        {
            var result = new List<Equipment>();

            using (var context = new MyDbContext())
            {
                var equipmentCollection = context.Equipment;

                foreach (var equipment in equipmentCollection)
                {
                    var newEquipment = new Equipment(equipment.Id, equipment.Name, equipment.NumberOfSeats, equipment.Subjects, equipment.Classrooms);
                    result.Add(newEquipment);
                }
            }

            return result;
        }

        public static List<Subject> Subjects()
        {
            var result = new List<Subject>();

            using (var context = new MyDbContext())
            {
                var subjects = context.Subjects;

                foreach (var subject in subjects)
                {
                    var newSubject = new Subject(subject.Id, subject.Name, subject.Equipment);
                    result.Add(newSubject);
                }
            }

            return result;
        }

        public static List<Group> Groups()
        {
            var result = new List<Group>();

            using (var context = new MyDbContext())
            {
                var groups = context.Groups;

                foreach (var group in groups)
                {
                    var newGroup = new Group(group.Id, group.Name, group.NumberOfStudents);
                    result.Add(newGroup);
                }
            }

            return result;
        }

        public static List<Classroom> Classrooms()
        {
            var result = new List<Classroom>();

            using (var context = new MyDbContext())
            {
                var classrooms = context.Classrooms;

                foreach (var classroom in classrooms)
                {
                    var newClassroom = new Classroom(classroom.Id, classroom.Name, classroom.Equipment);
                    result.Add(newClassroom);
                }
            }

            return result;
        }
    }
}