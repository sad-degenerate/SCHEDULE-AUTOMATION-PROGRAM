using System;
using System.Collections.Generic;
using System.Linq;
using BL.Commands;
using BL.Model;

namespace BL
{
    public static class UserInputToDB
    {
        public static void Insert(List<object> data, ModelObjectsTypes modelType)
        {
            switch (modelType)
            {
                case ModelObjectsTypes.classroom:
                    Classroom(data);
                    break;

                case ModelObjectsTypes.equipment:
                    Equipment(data);
                    break;

                case ModelObjectsTypes.flow:
                    Flow(data);
                    break;

                case ModelObjectsTypes.flowsLoad:
                    FlowsLoad(data);
                    break;

                case ModelObjectsTypes.group:
                    Group(data);
                    break;

                case ModelObjectsTypes.specialEquipment:
                    SpecialEquipment(data);
                    break;

                case ModelObjectsTypes.subgroup:
                    Subgroup(data);
                    break;

                case ModelObjectsTypes.subject:
                    Subject(data);
                    break;

                case ModelObjectsTypes.teacher:
                    Teacher(data);
                    break;

                case ModelObjectsTypes.teachersLoad:
                    TeachersLoad(data);
                    break;
            }
        }

        private static void TeachersLoad(List<object> data)
        {
            var subject = data[0] as Subject;
            var teacher = Select.Teachers().Where(x => x.Name == data[2].ToString()).FirstOrDefault();

            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher), "Преподаватель не выбран.");
            if (subject == null)
                throw new ArgumentNullException(nameof(subject), "Предмет не выбран.");

            if (int.TryParse(data[1].ToString(), out int load) == false)
                throw new ArgumentException("Вы ввели не число в поле \"Нагрузка\"", nameof(load));

            var teachersLoad = new TeachersLoad(subject.Id, teacher.Id, load);
            Insert<TeachersLoad>.InsertOriginal(teachersLoad, Select.TeachersLoads());
        }

        private static void FlowsLoad(List<object> data)
        {
            var subject = data[0] as Subject;
            var flow = Select.Flows().Where(x => x.Name == data[2].ToString()).FirstOrDefault();

            if (flow == null)
                throw new ArgumentNullException(nameof(flow), "Поток не выбран.");
            if (subject == null)
                throw new ArgumentNullException(nameof(subject), "Предмет не выбран.");

            if (int.TryParse(data[1].ToString(), out int load) == false)
                throw new ArgumentException("Вы ввели не число в поле \"Нагрузка\"", nameof(load));

            var flowsLoad = new FlowsLoad(flow.Id, subject.Id, load);
            Insert<FlowsLoad>.InsertOriginal(flowsLoad, Select.FlowsLoad());
        }

        private static void Teacher(List<object> data)
        {
            var name = data[0].ToString();

            var teacher = new Teacher(name);
            Insert<Teacher>.InsertOriginal(teacher, Select.Teachers());
        }

        private static void Subject(List<object> data)
        {
            var name = data[0].ToString();
            var equipment = data[1] as Equipment;
            var subjectType = data[2] as SubjectType;

            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment), "Не выбрано оборудование.");
            if (subjectType == null)
                throw new ArgumentNullException(nameof(subjectType), "Не выбран тип предмета.");

            var subject = new Subject(name, equipment.Id, subjectType.Id);
            Insert<Subject>.InsertOriginal(subject, Select.Subjects());
        }

        private static void Subgroup(List<object> data)
        {
            var name = data[0].ToString();
            if (!int.TryParse(data[1].ToString(), out int numberOfStudents))
                throw new ArgumentException("Не удалось преобразовать количество студентов в число", nameof(numberOfStudents));
            var group = data[2] as Group;


            if (group == null)
                throw new ArgumentNullException(nameof(group), "Не выбрана группа.");

            var subgroup = new Subgroup(name, numberOfStudents, group.Id);
            Insert<Subgroup>.InsertOriginal(subgroup, Select.Subgroups());
        }

        private static void SpecialEquipment(List<object> data)
        {
            var name = data[0].ToString();

            var specialEquipment = new SpecialEquipment(name);
            Insert<SpecialEquipment>.InsertOriginal(specialEquipment, Select.SpecialEquipment());
        }

        private static void Group(List<object> data)
        {
            var name = data[0].ToString();
            var flow = data[1] as Flow;

            if (flow == null)
                throw new ArgumentNullException(nameof(flow), "Поток не выбран.");

            var group = new Group(name, flow.Id);
            Insert<Group>.InsertOriginal(group, Select.Groups());

            //var subgroupsNames = data[2] as Dictionary<string, bool>;

            //if (subgroupsNames.Count == 0)
            //    return;

            //var subgroups = NamesToObjects<Subgroup>.GetObjects(subgroupsNames, Select.Subgroups());

            //foreach (var subgroup in subgroups)
            //{
            //    var val = new SubgroupsInGroup(group.Id, subgroup.Key.Id);

            //    if (CheckForExistence<SubgroupsInGroup>.IsExist(val, Select.SubgroupsInGroups()) == true && subgroup.Value == false)
            //        Delete<SubgroupsInGroup>.DeleteFromTable(val);
            //    else if (CheckForExistence<SubgroupsInGroup>.IsExist(val, Select.SubgroupsInGroups()) == false && subgroup.Value == true)
            //        Add<SubgroupsInGroup>.AddNew(val);
            //}
        }

        private static void Flow(List<object> data)
        {
            var name = data[0].ToString();

            var flow = new Flow(name);
            Insert<Flow>.InsertOriginal(flow, Select.Flows());

            //var groupsNames = data[1] as Dictionary<string, bool>;

            //if (groupsNames.Count == 0)
            //    return;

            //var groups = NamesToObjects<Group>.GetObjects(groupsNames, Select.Groups());

            //foreach (var group in groups)
            //{
            //    var val = new GroupsInFlow(flow.Id, group.Key.Id);

            //    if (CheckForExistence<GroupsInFlow>.IsExist(val, Select.GroupsInFlows()) == true && group.Value == false)
            //        Delete<GroupsInFlow>.DeleteFromTable(val);
            //    else if (CheckForExistence<GroupsInFlow>.IsExist(val, Select.GroupsInFlows()) == false && group.Value == true)
            //        Add<GroupsInFlow>.AddNew(val);
            //}
        }

        private static void Equipment(List<object> data)
        {
            var name = data[0].ToString();
            if (!int.TryParse(data[1].ToString(), out int numberOfSeats))
                throw new ArgumentException("Вы ввели не число в поле \"Количество сидений\"", nameof(numberOfSeats));

            var equipment = new Equipment(name, numberOfSeats);
            Insert<Equipment>.InsertOriginal(equipment, Select.Equipment());

            try
            {
                var specialEquipmentNames = data[2] as Dictionary<string, bool>;

                if (specialEquipmentNames.Count == 0)
                    return;

                var specialEquipmentCollection = NamesToObjects<SpecialEquipment>.GetObjects(specialEquipmentNames, Select.SpecialEquipment());

                foreach (var specialEquipment in specialEquipmentCollection)
                {
                    var val = new SpecialEquipmentInEquipment(specialEquipment.Key.Id, equipment.Id);

                    if (CheckForExistence<SpecialEquipmentInEquipment>.IsExist(val, Select.SpecialEquipmentInEquipment()) == true && specialEquipment.Value == false)
                        Delete<SpecialEquipmentInEquipment>.DeleteFromTable(val);
                    else if (CheckForExistence<SpecialEquipmentInEquipment>.IsExist(val, Select.SpecialEquipmentInEquipment()) == false && specialEquipment.Value == true)
                        Add<SpecialEquipmentInEquipment>.AddNew(val);
                }
            }
            catch { }
        }

        private static void Classroom(List<object> data)
        {
            var name = data[0].ToString();
            var equipment = data[1] as Equipment;

            if (equipment == null)
                throw new ArgumentNullException("Оборудование не выбрано.");

            var classroom = new Classroom(name, equipment.Id);
            Insert<Classroom>.InsertOriginal(classroom, Select.Classrooms());
        }
    }
}