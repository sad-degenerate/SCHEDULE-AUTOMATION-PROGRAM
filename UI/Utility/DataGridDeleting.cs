using BL.Commands;
using BL.Model;
using System;
using System.Linq;

namespace UI.Utility
{
    public static class DataGridDeleting
    {
        public static void Delete(int id, ModelObjectsTypes type)
        {
            switch (type)
            {
                case ModelObjectsTypes.teacher:
                    TeacherDelete(id);
                    break;

                case ModelObjectsTypes.classroom:
                    ClassroomDelete(id);
                    break;

                case ModelObjectsTypes.equipment:
                    EquipmentDelete(id);
                    break;

                case ModelObjectsTypes.group:
                    GroupDelete(id);
                    break;

                case ModelObjectsTypes.subject:
                    SubjectDelete(id);
                    break;

                case ModelObjectsTypes.flow:
                    FlowDelete(id);
                    break;

                case ModelObjectsTypes.subgroup:
                    SubgroupDelete(id);
                    break;

                case ModelObjectsTypes.specialEquipment:
                    SpecialEquipmentDelete(id);
                    break;

                case ModelObjectsTypes.teachersLoad:
                    TeacherLoadDelete(id);
                    break;

                case ModelObjectsTypes.flowsLoad:
                    FlowLoadDelete(id);
                    break;
            }
        }

        private static void FlowLoadDelete(int id)
        {
            var flowLoad = Select.FlowsLoad().Where(x => x.Id == id).First();
            Delete<FlowsLoad>.DeleteFromTable(flowLoad);
        }

        private static void TeacherLoadDelete(int id)
        {
            var teacherLoad = Select.TeachersLoads().Where(x => x.Id == id).First();
            Delete<TeachersLoad>.DeleteFromTable(teacherLoad);
        }

        private static void SpecialEquipmentDelete(int id)
        {
            var specialEquipment = Select.SpecialEquipment().Where(x => x.Id == id).First();
            Delete<SpecialEquipment>.DeleteFromTable(specialEquipment);
        }

        private static void SubgroupDelete(int id)
        {
            var subgroup = Select.Subgroups().Where(x => x.Id == id).First();
            Delete<Subgroup>.DeleteFromTable(subgroup);
        }

        private static void FlowDelete(int id)
        {
            var flow = Select.Flows().Where(x => x.Id == id).First();
            Delete<Flow>.DeleteFromTable(flow);
        }

        private static void SubjectDelete(int id)
        {
            var subject = Select.Subjects().Where(x => x.Id == id).First();
            Delete<Subject>.DeleteFromTable(subject);
        }

        private static void GroupDelete(int id)
        {
            var group = Select.Groups().Where(x => x.Id == id).First();
            Delete<Group>.DeleteFromTable(group);
        }

        private static void EquipmentDelete(int id)
        {
            var equipment = Select.Equipment().Where(x => x.Id == id).First();
            Delete<Equipment>.DeleteFromTable(equipment);
        }

        private static void ClassroomDelete(int id)
        {
            var classroom = Select.Classrooms().Where(x => x.Id == id).First();
            Delete<Classroom>.DeleteFromTable(classroom);
        }

        private static void TeacherDelete(int id)
        {
            var teacher = Select.Teachers().Where(x => x.Id == id).First();
            Delete<Teacher>.DeleteFromTable(teacher);
        }
    }
}