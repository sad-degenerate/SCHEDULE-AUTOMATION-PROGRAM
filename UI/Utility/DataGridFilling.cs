using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace UI.Utility
{
    public static class DataGridFilling
    {
        private static DataTable CreateDataTable(Dictionary<string, string> headers)
        {
            var dataTable = new DataTable();

            foreach (var header in headers)
            {
                var column = new DataColumn();
                column.DataType = Type.GetType(header.Value);
                column.ColumnName = header.Key;

                if (column.ColumnName == "ID")
                    column.ReadOnly = true;

                dataTable.Columns.Add(column);
            }

            return dataTable;
        }

        public static DataTable TeachersLoad(string teacherName)
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Преподаватель", "System.String" },
                { "Предмет", "System.String" },
                { "Нагрузка", "System.Int32" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var teaccherLoad in Select.TeachersLoads().Where(x => x.Teacher.Name == teacherName))
            {
                var row = dataTable.NewRow();
                row[0] = teaccherLoad.Id;
                row[1] = teaccherLoad.Teacher.Name;
                row[2] = teaccherLoad.Subject.Name;
                row[3] = teaccherLoad.Load;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable FlowsLoad(string flowName)
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Поток", "System.String" },
                { "Предмет", "System.String" },
                { "Нагрузка", "System.Int32" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var teaccherLoad in Select.FlowsLoad().Where(x => x.Flow.Name == flowName))
            {
                var row = dataTable.NewRow();
                row[0] = teaccherLoad.Id;
                row[1] = teaccherLoad.Flow.Name;
                row[2] = teaccherLoad.Subject.Name;
                row[3] = teaccherLoad.Load;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Teachers()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "ФИО преподавателя", "System.String" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var teacher in Select.Teachers())
            {
                var row = dataTable.NewRow();
                row[0] = teacher.Id;
                row[1] = teacher.Name;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Classrooms()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Название аудитории", "System.String" },
                { "Оборудование", "System.String" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var classroom in Select.Classrooms())
            {
                var row = dataTable.NewRow();
                row[0] = classroom.Id;
                row[1] = classroom.Name;
                row[2] = classroom.Equipment.Name;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Equipment()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Название оборудования", "System.String" },
                { "Количество мест", "System.Int32" },
                { "Специальное оборудование", "System.String" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var equipment in Select.Equipment())
            {
                var row = dataTable.NewRow();
                row[0] = equipment.Id;
                row[1] = equipment.Name;
                row[2] = equipment.NumberOfSeats;

                var list = new List<SpecialEquipment>();

                foreach (var item in Select.SpecialEquipmentInEquipment().Where(x => x.EquipmentId == equipment.Id))
                    list.Add(Select.SpecialEquipment().Where(x => x.Id == item.SpecialEquipmentId).First());
              
                row[3] = CollectionConverter<SpecialEquipment>.GetString(list);

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable SpecialEquipment()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Название специального оборудования", "System.String" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var specialEquipment in Select.SpecialEquipment())
            {
                var row = dataTable.NewRow();
                row[0] = specialEquipment.Id;
                row[1] = specialEquipment.Name;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Flows()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Название потока", "System.String" },
            };

            var dataTable = CreateDataTable(headers);

            foreach (var flow in Select.Flows())
            {
                var row = dataTable.NewRow();
                row[0] = flow.Id;
                row[1] = flow.Name;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Groups()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Поток", "System.String" },
                { "Название группы", "System.String" },
            };

            var dataTable = CreateDataTable(headers);

            foreach (var group in Select.Groups())
            {
                var row = dataTable.NewRow();
                row[0] = group.Id;
                row[1] = group.Flow.Name;
                row[2] = group.Name;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Subgroups()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Поток", "System.String" },
                { "Группа", "System.String" },
                { "Название подгруппы", "System.String" },
                { "Количество студентов", "System.Int32" },
                
            };

            var dataTable = CreateDataTable(headers);
            dataTable.Columns[1].ReadOnly = true;

            foreach (var subgroup in Select.Subgroups())
            {
                var row = dataTable.NewRow();
                row[0] = subgroup.Id;
                row[1] = subgroup.Group.Flow.Name;
                row[2] = subgroup.Group.Name;
                row[3] = subgroup.Name;
                row[4] = subgroup.NumberOfStudents;
               

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable Subjects()
        {
            var headers = new Dictionary<string, string>()
            {
                { "ID", "System.Int32" },
                { "Название предмета", "System.String" },
                { "Оборудование, необходимое для предмета", "System.String" },
                { "Тип предмета", "System.String" }
            };

            var dataTable = CreateDataTable(headers);

            foreach (var subject in Select.Subjects())
            {
                var row = dataTable.NewRow();
                row[0] = subject.Id;
                row[1] = subject.Name;
                row[2] = subject.Equipment.Name;
                row[3] = subject.SubjectType;

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}