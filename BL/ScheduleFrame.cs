using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public static class ScheduleFrame
    {
        public static void MakeScheduleFrame()
        {
            DataCheck();

            var subjects = Select.Subjects();

            foreach (var subject in subjects)
            {
                if (subject.SubjectType.Code == "lecture")
                    AddLecture(subject);
                else if (subject.SubjectType.Code == "group_seminar")
                    AddGroupSeminar(subject);
                else
                    AddSubgroupSeminar(subject);
            }

            ProgressBarHelper.ProgressBarEvent(50);

            SetFreedoomOfLocation();
        }

        private static void AddSubgroupSeminar(Subject subject)
        {
            var flowsLoads = Select.FlowsLoad().Where(x => x.Load != 0).Where(x => x.SubjectId == subject.Id);
            var teachersLoads = Select.TeachersLoads().Where(x => x.Load != 0).Where(x => x.SubjectId == subject.Id);

            foreach (var flowLoad in flowsLoads)
            {
                var groups = Select.Groups().Where(x => x.FlowId == flowLoad.FlowId);
                foreach (var group in groups)
                {
                    var subgroups = Select.Subgroups().Where(x => x.GroupId == group.Id);
                    foreach (var subgroup in subgroups)
                    {
                        var subgroupLoad = flowLoad.Load;

                        foreach (var teacherLoad in teachersLoads)
                        {
                            if (teacherLoad.Load >= subgroupLoad)
                            {
                                var loads = CalculateLoad(teacherLoad.Load, subgroupLoad);

                                var lessonFrame = CreateLessonFrame(teacherLoad.Teacher, subject, flowLoad.Flow);
                                lessonFrame.LessonFrameCount += (subgroupLoad - loads.Item2);

                                AddSubgroupToLessonFrame(subgroup, lessonFrame);

                                teacherLoad.Load = loads.Item1;
                                subgroupLoad = loads.Item2;
                                break;
                            }
                        }

                        if (subgroupLoad != 0)
                        {
                            foreach (var teacherLoad in teachersLoads.OrderByDescending(x => x.Load))
                            {
                                var loads = CalculateLoad(teacherLoad.Load, subgroupLoad);

                                var lessonFrame = CreateLessonFrame(teacherLoad.Teacher, subject, flowLoad.Flow);
                                lessonFrame.LessonFrameCount += (subgroupLoad - loads.Item2);

                                AddSubgroupToLessonFrame(subgroup, lessonFrame);

                                teacherLoad.Load = loads.Item1;
                                subgroupLoad = loads.Item2;

                                if (subgroupLoad == 0)
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private static void AddGroupSeminar(Subject subject)
        {
            var flowsLoads = Select.FlowsLoad().Where(x => x.Load != 0).Where(x => x.SubjectId == subject.Id);
            var teachersLoads = Select.TeachersLoads().Where(x => x.Load != 0).Where(x => x.SubjectId == subject.Id);

            foreach (var flowLoad in flowsLoads)
            {
                var groups = Select.Groups().Where(x => x.FlowId == flowLoad.FlowId);

                foreach (var group in groups)
                {
                    var groupLoad = flowLoad.Load;

                    foreach (var teacherLoad in teachersLoads)
                    {
                        if (teacherLoad.Load >= groupLoad)
                        {
                            var loads = CalculateLoad(teacherLoad.Load, groupLoad);

                            var lessonFrame = CreateLessonFrame(teacherLoad.Teacher, subject, flowLoad.Flow);
                            lessonFrame.LessonFrameCount += (groupLoad - loads.Item2);

                            AddGroupToLessonFrame(group, lessonFrame);

                            teacherLoad.Load = loads.Item1;
                            groupLoad = loads.Item2;
                            break;
                        }
                    }

                    if (groupLoad != 0)
                    {
                        foreach (var teacherLoad in teachersLoads.OrderByDescending(x => x.Load))
                        {
                            var loads = CalculateLoad(teacherLoad.Load, groupLoad);

                            var lessonFrame = CreateLessonFrame(teacherLoad.Teacher, subject, flowLoad.Flow);
                            lessonFrame.LessonFrameCount += (groupLoad - loads.Item2);

                            AddGroupToLessonFrame(group, lessonFrame);

                            teacherLoad.Load = loads.Item1;
                            groupLoad = loads.Item2;

                            if (groupLoad == 0)
                                break;
                        }
                    }
                }
            }
        }

        private static void AddLecture(Subject subject)
        {
            var flowsLoads = Select.FlowsLoad().Where(x => x.Load != 0).Where(x => x.SubjectId == subject.Id);
            var teachersLoads = Select.TeachersLoads().Where(x => x.Load != 0).Where(x => x.SubjectId == subject.Id);

            foreach (var flowLoad in flowsLoads)
            {
                foreach (var teacherLoad in teachersLoads)
                {
                    if (teacherLoad.Load >= flowLoad.Load)
                    {
                        var loads = CalculateLoad(teacherLoad.Load, flowLoad.Load);

                        var lessonFrame = CreateLessonFrame(teacherLoad.Teacher, subject, flowLoad.Flow);
                        lessonFrame.LessonFrameCount += (flowLoad.Load - loads.Item2);

                        AddFlowToLessonFrame(flowLoad.Flow, lessonFrame);

                        teacherLoad.Load = loads.Item1;
                        flowLoad.Load = loads.Item2;
                        break;
                    }
                }

                if (flowLoad.Load != 0)
                {
                    foreach (var teacherLoad in teachersLoads.OrderByDescending(x => x.Load))
                    {
                        var loads = CalculateLoad(teacherLoad.Load, flowLoad.Load);

                        var lessonFrame = CreateLessonFrame(teacherLoad.Teacher, subject, flowLoad.Flow);
                        lessonFrame.LessonFrameCount += (flowLoad.Load - loads.Item2);

                        AddFlowToLessonFrame(flowLoad.Flow, lessonFrame);

                        teacherLoad.Load = loads.Item1;
                        flowLoad.Load = loads.Item2;

                        if (flowLoad.Load == 0)
                            break;
                    }
                }
            }
        }

        private static LessonFrame CreateLessonFrame(Teacher teacher, Subject subject, Flow flow)
        {
            var lessonFrame = new LessonFrame(teacher, subject, flow);
            Insert<LessonFrame>.InsertOriginal(lessonFrame, Select.LessonFrames());
            return lessonFrame;
        }

        private static (int, int) CalculateLoad(int teacherLoad, int otherLoad)
        {
            if (teacherLoad >= otherLoad)
            {
                teacherLoad -= otherLoad;
                otherLoad = 0;
            }
            else
            {
                otherLoad -= teacherLoad;
                teacherLoad = 0;
            }

            return (teacherLoad, otherLoad);
        }

        private static void AddFlowToLessonFrame(Flow flow, LessonFrame lessonFrame)
        {
            var groups = Select.Groups().Where(x => x.FlowId == flow.Id);

            foreach (var group in groups)
            {
                var subgroups = Select.Subgroups().Where(x => x.GroupId == group.Id);
                foreach (var subgroup in subgroups)
                {
                    AddSubgroupToLessonFrame(subgroup, lessonFrame);
                }
            }
        }

        private static void AddGroupToLessonFrame(Group group, LessonFrame lessonFrame)
        {
            var subgroups = Select.Subgroups().Where(x => x.GroupId == group.Id);

            foreach (var subgroup in subgroups)
                AddSubgroupToLessonFrame(subgroup, lessonFrame);
        }

        private static void AddSubgroupToLessonFrame(Subgroup subgroup, LessonFrame lessonFrame)
        {
            var subgroupInLessonFrame = new SubgroupsInLessonFrames(subgroup.Id, lessonFrame.Id);
            Insert<SubgroupsInLessonFrames>.InsertOriginal(subgroupInLessonFrame, Select.SubgroupsInLessonFrames());
        }

        private static void DataCheck()
        {
            ConformityCheck();
        }

        private static void ConformityCheck()
        {
            foreach (var subject in Select.Subjects())
            {
                var flowsLoads = Select.FlowsLoad().Where(x => x.SubjectId == subject.Id);
                var teachersLoads = Select.TeachersLoads().Where(x => x.SubjectId == subject.Id);

                var generalFlowsLoad = 0;
                var generalTeachersLoad = 0;

                foreach (var teacherLoad in teachersLoads)
                    generalTeachersLoad += teacherLoad.Load;

                if (subject.SubjectType.Code == "lecture")
                {
                    foreach (var flowLoad in flowsLoads)
                        generalFlowsLoad += flowLoad.Load;
                }
                else if (subject.SubjectType.Code == "group_seminar")
                {
                    foreach (var flowLoad in flowsLoads)
                    {
                        var groupsCount = Select.Groups().Where(x => x.FlowId == flowLoad.FlowId).Count();
                        generalFlowsLoad += flowLoad.Load * groupsCount;
                    }
                }
                else
                {
                    foreach (var flowLoad in flowsLoads)
                    {
                        var groups = Select.Groups().Where(x => x.FlowId == flowLoad.FlowId);
                        var subgroupsCount = 0;

                        foreach (var group in groups)
                            subgroupsCount += Select.Subgroups().Where(x => x.GroupId == group.Id).Count();

                        generalFlowsLoad += flowLoad.Load * subgroupsCount;
                    }
                }

                if (generalTeachersLoad < generalFlowsLoad)
                    throw new ArgumentException($"Не хватает преподавателей! (Предмет - {subject.Name}).");
            }
        }

        private static void SetFreedoomOfLocation()
        {
            var lessonFrames = Select.LessonFrames();
            var subgroupsInLessonFrames = Select.SubgroupsInLessonFrames();

            foreach (var lessonFrame in lessonFrames)
            {
                double classroomsCount = Select.Classrooms().Where(x => x.EquipmentId == lessonFrame.Subject.EquipmentId).Count();

                var teachers = lessonFrames.Where(x => x.TeacherId == lessonFrame.TeacherId)
                    .Where(x => x.SubjectId == lessonFrame.SubjectId);
                var flows = lessonFrames.Where(x => x.FlowId == lessonFrame.FlowId)
                    .Where(x => x.SubjectId == lessonFrame.SubjectId);

                double teachersCount = 0;
                foreach (var frame in teachers)
                    teachersCount += frame.LessonFrameCount;

                double flowsCount = 0;
                foreach (var frame in flows)
                    flowsCount += frame.LessonFrameCount;

                lessonFrame.FreedoomOfLocation = classroomsCount / (flowsCount * teachersCount);
                Update<LessonFrame>.UpdateTable(lessonFrame);
            }

            ProgressBarHelper.ProgressBarEvent(60);
        }
    }
}