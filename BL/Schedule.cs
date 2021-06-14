using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Schedule
    {
        public List<Lesson> MostOptimalitySchedule { get; private set; }
        public List<SubgroupsInLessons> SubgroupsInLessons { get; private set; }

        private double _optimality;

        private List<LessonFrame> lessonFrames;

        public Schedule()
        {
            lessonFrames = Select.LessonFrames().OrderBy(x => x.FreedoomOfLocation).ToList();
        }

        public void Create()
        {
            foreach (var lesson in Select.Lessons())
                Delete<Lesson>.DeleteFromTable(lesson);
            foreach (var subgroupInLesson in Select.SubgroupsInLessons())
                Delete<SubgroupsInLessons>.DeleteFromTable(subgroupInLesson);

            for (var i = 0; i < 1; i++)
            {
                Make();

                var optimality = OptimalityCheck.Check(Select.Lessons(), Select.SubgroupsInLessons());

                if (MostOptimalitySchedule == null || optimality > _optimality)
                {
                    MostOptimalitySchedule = Select.Lessons();
                    SubgroupsInLessons = Select.SubgroupsInLessons();
                    _optimality = optimality;
                }

                foreach (var lesson in Select.Lessons())
                    Delete<Lesson>.DeleteFromTable(lesson);
                foreach (var subgroupInLesson in Select.SubgroupsInLessons())
                    Delete<SubgroupsInLessons>.DeleteFromTable(subgroupInLesson);
            }

            ProgressBarHelper.ProgressBarEvent(100);
        }

        private void Make()
        {
            for (var lessonFrame = 0; lessonFrame < lessonFrames.Count; lessonFrame++)
            {
                MakeOneLessonFrame(lessonFrame);
            }
        }

        private void MakeOneLessonFrame(int lessonFrame)
        {
            var days = Select.Days();
            days = Shuffles<Day>.Shuffle(days);
            for (var day = 0; day < days.Count; day++)
            {
                var classrooms = Select.Classrooms().Where(x => x.EquipmentId == lessonFrames[lessonFrame].Subject.EquipmentId).ToList();
                classrooms = Shuffles<Classroom>.Shuffle(classrooms);
                foreach (var classroom in classrooms)
                {
                    if (SelectClassroom(classroom, lessonFrame, days[day]) == true)
                    {
                        return;
                    }
                }
            }

            throw new ArgumentException($"Не удалось подобрать аудиторию. {lessonFrames[lessonFrame].Subject.Name}");
        }

        private bool SelectClassroom(Classroom classroom, int lessonFrame, Day day)
        {
            for (var lessonTime = 1; lessonTime <= Globals.MaxLessonsInDay; lessonTime++)
            {
                if (Check(classroom.Id, day.Id, lessonTime, lessonFrame))
                {
                    CreateLesson(lessonFrames[lessonFrame], classroom.Id, day.Id, lessonTime);
                    return true;
                }
            }

            return false;
        }

        private void CreateLesson(LessonFrame lessonFrame, int classroomId, int dayId, int lessonTime)
        {
            var lesson = new Lesson(lessonFrame.SubjectId, lessonFrame.TeacherId, classroomId, dayId, lessonTime);
            Insert<Lesson>.InsertOriginal(lesson, Select.Lessons());

            var subgroupsInLessonFrames = Select.SubgroupsInLessonFrames().Where(x => x.LessonFrameId == lessonFrame.Id);
            foreach (var subgroupInLessonFrame in subgroupsInLessonFrames)
            {
                var subgroupInLesson = new SubgroupsInLessons(subgroupInLessonFrame.SubgroupId, lesson.Id);
                Insert<SubgroupsInLessons>.InsertOriginal(subgroupInLesson, Select.SubgroupsInLessons());
            }
        }

        private bool Check(int classroomId, int dayId, int lessonTime, int lessonFrame)
        {
            if (IsClassroomBusy(classroomId, dayId, lessonTime) == true)
                return false;
            if (IsTeacherBusy(lessonFrames[lessonFrame].TeacherId, dayId, lessonTime) == true)
                return false;

            var subgroups = Select.SubgroupsInLessonFrames().Where(x => x.LessonFrameId == lessonFrames[lessonFrame].Id).ToList();
            if (IsSubgroupsBusy(subgroups, dayId, lessonTime))
                return false;

            return true;
        }

        private bool IsClassroomBusy(int classroomId, int dayId, int lessonTime)
        {
            var lesson = Select.Lessons().Where(x => x.ClassroomId == classroomId)
                .Where(x => x.DayId == dayId).Where(x => x.LessonTime == lessonTime).FirstOrDefault();

            if (lesson == null)
                return false;
            else
                return true;
        }

        private bool IsTeacherBusy(int teacherId, int dayId, int lessonTime)
        {
            var lesson = Select.Lessons().Where(x => x.TeacherId == teacherId)
                .Where(x => x.DayId == dayId).Where(x => x.LessonTime == lessonTime).FirstOrDefault();

            if (lesson == null)
                return false;
            else
                return true;
        }

        private bool IsSubgroupsBusy(List<SubgroupsInLessonFrames> subgroups, int dayId, int lessonTime)
        {
            var lessons = Select.Lessons().Where(x => x.DayId == dayId).Where(x => x.LessonTime == lessonTime);
            var subgroupsId = new List<int>();
            foreach (var subgroup in subgroups)
                if (subgroupsId.Contains(subgroup.SubgroupId) == false)
                    subgroupsId.Add(subgroup.Id);

            foreach (var lesson in lessons)
            {
                var subgroupsInLesson = Select.SubgroupsInLessons().Where(x => x.LessonId == lesson.Id);
                foreach (var subgroup in subgroupsInLesson)
                {
                    if (subgroupsId.Contains(subgroup.Id))
                        return true;
                }
            }

            return false;
        }
    }
}