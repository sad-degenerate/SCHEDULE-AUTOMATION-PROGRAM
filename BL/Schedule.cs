using BL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Schedule
    {
        public void Create()
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
        }
    }
}