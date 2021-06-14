using BL;
using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace UI.Utility
{
    public class DataGridEditing
    {
        private DataRowView _dataRowView;

        public DataGridEditing(DataRowView dataRowView)
        {
            _dataRowView = dataRowView;
        }

        public void EditDataGrid(ModelObjectsTypes type)
        {
            try
            {
                switch (type)
                {
                    case ModelObjectsTypes.teacher:
                        TeacherEdit();
                        break;

                    case ModelObjectsTypes.classroom:
                        ClassroomEdit();
                        break;

                    case ModelObjectsTypes.equipment:
                        EquipmentEdit();
                        break;

                    case ModelObjectsTypes.group:
                        GroupEdit();
                        break;

                    case ModelObjectsTypes.subject:
                        SubjectEdit();
                        break;

                    case ModelObjectsTypes.flow:
                        FlowEdit();
                        break;

                    case ModelObjectsTypes.subgroup:
                        SubgroupEdit();
                        break;

                    case ModelObjectsTypes.specialEquipment:
                        SpecialEquipmentEdit();
                        break;

                    case ModelObjectsTypes.teachersLoad:
                        TeacherLoadEdit();
                        break;

                    case ModelObjectsTypes.flowsLoad:
                        FlowLoadEdit();
                        break;
                }
            }
            catch { }
        }

        private void FlowLoadEdit()
        {
            var flowLoad = Select.FlowsLoad().Where(x => x.Id == GetId()).First();

            var flow = Select.Flows().Where(x => x.Name == GetDataGridValue("Поток")).FirstOrDefault();
            if (flow == null)
                throw new ArgumentException("Некорректно указан поток.");
            flowLoad.FlowId = flow.Id;
            flowLoad.Flow = flow;
            var subject = Select.Subjects().Where(x => x.Name == GetDataGridValue("Предмет")).FirstOrDefault();
            if (subject == null)
                throw new ArgumentException("Некорректно указан предмет.");
            flowLoad.SubjectId = subject.Id;
            flowLoad.Subject = subject;
            if (int.TryParse(GetDataGridValue("Нагрузка"), out var load) == false)
                throw new ArgumentException("Вы ввели не целочисленное число в поле \"Нагрузка\".");
            flowLoad.Load = load;

            Update<FlowsLoad>.UpdateTable(flowLoad);
        }

        private void TeacherLoadEdit()
        {
            var teacherLoad = Select.TeachersLoads().Where(x => x.Id == GetId()).First();

            var teacher = Select.Teachers().Where(x => x.Name == GetDataGridValue("Преподаватель")).FirstOrDefault();
            if (teacher == null)
                throw new ArgumentException("Некорректно указан преподаватель.");
            teacherLoad.TeacherId = teacher.Id;
            teacherLoad.Teacher = teacher;
            var subject = Select.Subjects().Where(x => x.Name == GetDataGridValue("Предмет")).FirstOrDefault();
            if (subject == null)
                throw new ArgumentException("Некорректно указан предмет.");
            teacherLoad.SubjectId = subject.Id;
            teacherLoad.Subject = subject;
            if (int.TryParse(GetDataGridValue("Нагрузка"), out var load) == false)
                throw new ArgumentException("Вы ввели не целочисленное число в поле \"Нагрузка\".");
            teacherLoad.Load = load;

            Update<TeachersLoad>.UpdateTable(teacherLoad);
        }

        private void SpecialEquipmentEdit()
        {
            var specialEquipment = Select.SpecialEquipment().Where(x => x.Id == GetId()).First();

            specialEquipment.Name = GetDataGridValue("Название специального оборудования");

            Update<SpecialEquipment>.UpdateTable(specialEquipment);
        }

        private void SubgroupEdit()
        {
            var subgroup = Select.Subgroups().Where(x => x.Id == GetId()).First();

            subgroup.Name = GetDataGridValue("Название подгруппы");
            var group = Select.Groups().Where(x => x.Name == GetDataGridValue("Группа")).FirstOrDefault();
            if (group == null)
                throw new ArgumentException("Некорректно указана группа.");
            subgroup.GroupId = group.Id;
            subgroup.Group = group;
            if (int.TryParse(GetDataGridValue("Количество студентов"), out var numberOfStudents) == false)
                throw new ArgumentException("Вы ввели не целочисленное число в поле \"Количество студентов\".");
            subgroup.NumberOfStudents = numberOfStudents;

            Update<Subgroup>.UpdateTable(subgroup);
        }

        private void FlowEdit()
        {
            var flow = Select.Flows().Where(x => x.Id == GetId()).First();

            flow.Name = GetDataGridValue("Название потока");

            Update<Flow>.UpdateTable(flow);
        }

        private void SubjectEdit()
        {
            var subject = Select.Subjects().Where(x => x.Id == GetId()).First();

            subject.Name = GetDataGridValue("Название предмета");
            var equipment = Select.Equipment().Where(x => x.Name == GetDataGridValue("Оборудование, необходимое для предмета")).FirstOrDefault();
            if (equipment == null)
                throw new ArgumentException("Некорректно указано оборудование.");
            subject.EquipmentId = equipment.Id;
            subject.Equipment = equipment;
            var subjectType = Select.SubjectTypes().Where(x => x.Name == GetDataGridValue("Тип предмета")).FirstOrDefault();
            if (subjectType == null)
                throw new ArgumentException("Некорректно указан тип предмета.");
            subject.SubjectTypeId = subjectType.Id;
            subject.SubjectType = subjectType;

            Update<Subject>.UpdateTable(subject);
        }

        private void GroupEdit()
        {
            var group = Select.Groups().Where(x => x.Id == GetId()).First();

            group.Name = GetDataGridValue("Название группы");
            var flow = Select.Flows().Where(x => x.Name == GetDataGridValue("Поток")).FirstOrDefault();
            if (flow == null)
                throw new ArgumentException("Некорректно указан поток.");
            group.FlowId = flow.Id;
            group.Flow = flow;

            Update<Group>.UpdateTable(group);
        }

        private void EquipmentEdit()
        {
            var equipment = Select.Equipment().Where(x => x.Id == GetId()).First();

            equipment.Name = GetDataGridValue("Название оборудования");
            if (int.TryParse(GetDataGridValue("Количество мест"), out var numberOfSeats) == false)
                throw new ArgumentException("Вы ввели не целочисленное число в поле \"Количество мест\".");
            equipment.NumberOfSeats = numberOfSeats;
            var specialEquipmentStrings = GetDataGridValue("Специальное оборудование").Split(',');
            var resultSpecialEquipment = new List<SpecialEquipment>();
            if (string.IsNullOrWhiteSpace(GetDataGridValue("Специальное оборудование")) == false)
                foreach (var specialEquipmentString in specialEquipmentStrings)
                {
                    var specialEquipment = Select.SpecialEquipment().Where(x => x.Name == specialEquipmentString.Trim()).FirstOrDefault();
                    if (specialEquipment != null)
                        throw new ArgumentException("Некорректно указано специальное оборудование.");
                    resultSpecialEquipment.Add(specialEquipment);
                }

            foreach (var specialEquipment in Select.SpecialEquipmentInEquipment().Where(x => x.EquipmentId == GetId()))
                Delete<SpecialEquipmentInEquipment>.DeleteFromTable(specialEquipment);

            foreach (var specialEquipment in resultSpecialEquipment)
                Insert<SpecialEquipmentInEquipment>.InsertOriginal(new SpecialEquipmentInEquipment(specialEquipment.Id, GetId()),
                    Select.SpecialEquipmentInEquipment());

            Update<Equipment>.UpdateTable(equipment);
        }

        private void ClassroomEdit()
        {
            var classroom = Select.Classrooms().Where(x => x.Id == GetId()).First();

            classroom.Name = GetDataGridValue("Название аудитории");
            var equipment = Select.Equipment().Where(x => x.Name == GetDataGridValue("Оборудование")).FirstOrDefault();
            if (equipment == null)
                throw new ArgumentException("Некорректно указано оборудование.");
            classroom.Equipment = equipment;
            classroom.EquipmentId = equipment.Id;

            Update<Classroom>.UpdateTable(classroom);
        }

        public void TeacherEdit()
        {
            var teacher = Select.Teachers().Where(x => x.Id == GetId()).First();

            teacher.Name = GetDataGridValue("ФИО преподавателя");

            Update<Teacher>.UpdateTable(teacher);
        }

        private int GetId()
        {
            var l = GetDataGridValue("ID");
            int.TryParse(l, out var id);
            return id;
        }

        private string GetDataGridValue(string rowName)
        {
            return _dataRowView.Row[rowName].ToString();
        }
    }
}