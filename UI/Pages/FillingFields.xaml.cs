using BL;
using BL.Commands;
using BL.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Utility;

namespace UI.Pages
{
    public partial class FillingFields : Page
    {
        private DataRowView _editingRow;

        public FillingFields()
        {
            InitializeComponent();

            treeView.ItemsSource = Globals.Classes.Keys;
        }

        private void Changing(object sender, PropertyChangedEventArgs e)
        {
            _editingRow = dataGrid.CurrentItem as DataRowView;
            EditingDataGrid();
        }

        private void AddTextBoxToScene(string text)
        {
            var tbx = AddingItemsHelper.CreateTextBox(text);
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);
        }

        private void AddComboBoxToScene(string name, ComboBox box)
        {
            var cbx = AddingItemsHelper.CreateComboBox(box, name);
            labelsPanel.Children.Add(cbx.Item1);
            textBoxPanel.Children.Add(cbx.Item2);
        }

        private void Teachers()
        {
            AddTextBoxToScene("ФИО учителя: ");
        }

        private void Classrooms()
        {
            AddTextBoxToScene("Название аудитории:");

            var ncb = new NewComboBox<Equipment>();
            var box = ncb.CreateComboBox(Select.Equipment());
            AddComboBoxToScene("Оборудование:", box);
        }

        private void Equipment()
        {
            AddTextBoxToScene("Название:");

            AddTextBoxToScene("Количество сидений:");

            var ncb = new NewComboBox<SpecialEquipment>();
            var box = ncb.CreateCheckBoxComboBox(Select.SpecialEquipment());
            AddComboBoxToScene("Специальное оборудование:", box);
        }

        private void Flows()
        {
            AddTextBoxToScene("Название:");
        }

        private void Groups()
        {
            AddTextBoxToScene("Название:");

            var ncb = new NewComboBox<Flow>();
            var box = ncb.CreateComboBox(Select.Flows());
            AddComboBoxToScene("Поток:", box);
        }

        private void SpecialEquipment()
        {
            AddTextBoxToScene("Название:");
        }

        private void Subgroups()
        {
            AddTextBoxToScene("Название:");

            AddTextBoxToScene("Количество студентов:");

            var ncb = new NewComboBox<Group>();
            var box = ncb.CreateComboBox(Select.Groups());
            AddComboBoxToScene("Группа:", box);
        }

        private void Subjects()
        {
            AddTextBoxToScene("Название:");

            var ncb = new NewComboBox<Equipment>();
            var box = ncb.CreateComboBox(Select.Equipment());
            AddComboBoxToScene("Оборудование:", box);

            var ncb2 = new NewComboBox<SubjectType>();
            box = ncb2.CreateComboBox(Select.SubjectTypes());
            AddComboBoxToScene("Тип предмета:", box);
        }

        private void treeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            labelsPanel.Children.Clear();
            textBoxPanel.Children.Clear();

            var res = new Button();
            ResultButtonStyle(ref res);

            var value = Globals.Classes[treeView.SelectedItem.ToString()];
            AddEvent(ref res, value);
            BuildScene(value);            

            UpdateDataGrid(value);

            res.Click += Update;
            textBoxPanel.Children.Add(res);
        }

        private void ResultButtonStyle(ref Button btn)
        {
            btn.VerticalAlignment = VerticalAlignment.Bottom;

            var marg = btn.Margin;
            marg.Top = 20;
            btn.Margin = marg;

            btn.Content = "Добавить / Изменить";
        }

        private void BuildScene(ModelObjectsTypes sender)
        {
            switch (sender)
            {
                case ModelObjectsTypes.teacher:
                    Teachers();
                    break;

                case ModelObjectsTypes.classroom:
                    Classrooms();
                    break;

                case ModelObjectsTypes.equipment:
                    Equipment();
                    break;

                case ModelObjectsTypes.group:
                    Groups();
                    break;

                case ModelObjectsTypes.subject:
                    Subjects();
                    break;


                case ModelObjectsTypes.flow:
                    Flows();
                    break;

                case ModelObjectsTypes.subgroup:
                    Subgroups();
                    break;

                case ModelObjectsTypes.specialEquipment:
                    SpecialEquipment();
                    break;

                default:
                    return;
            }
        }

        private void AddNewItem(object sender, EventArgs e)
        {
            try
            {
                UserInputToDB.Insert(DataListFromControlList.CreateList(textBoxPanel),
                    Globals.Classes[treeView.SelectedItem.ToString()]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEvent(ref Button btn, ModelObjectsTypes sender)
        {
            btn.Click += AddNewItem;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid(Globals.Classes[treeView.SelectedItem.ToString()]);
        }

        private void UpdateDataGrid(ModelObjectsTypes key)
        {
            try
            {
                switch (key)
                {
                    case ModelObjectsTypes.teacher:
                        dataGrid.ItemsSource = DataGridFilling.Teachers().AsDataView();
                        break;

                    case ModelObjectsTypes.classroom:
                        dataGrid.ItemsSource = DataGridFilling.Classrooms().AsDataView();
                        break;

                    case ModelObjectsTypes.equipment:
                        dataGrid.ItemsSource = DataGridFilling.Equipment().AsDataView();
                        break;

                    case ModelObjectsTypes.group:
                        dataGrid.ItemsSource = DataGridFilling.Groups().AsDataView();
                        break;

                    case ModelObjectsTypes.subject:
                        dataGrid.ItemsSource = DataGridFilling.Subjects().AsDataView();
                        break;

                    case ModelObjectsTypes.flow:
                        dataGrid.ItemsSource = DataGridFilling.Flows().AsDataView();
                        break;

                    case ModelObjectsTypes.subgroup:
                        dataGrid.ItemsSource = DataGridFilling.Subgroups().AsDataView();
                        break;

                    case ModelObjectsTypes.specialEquipment:
                        dataGrid.ItemsSource = DataGridFilling.SpecialEquipment().AsDataView();
                        break;

                    default:
                        return;
                }

                for (var i = 0; i < dataGrid.Items.Count; i++)
                {
                    ((DataRowView)dataGrid.Items[i]).PropertyChanged += Changing;
                }
            }
            catch { }
        }

        private void EditingDataGrid()
        {
            try
            {
                var edit = new DataGridEditing(_editingRow);
                edit.EditDataGrid(Globals.Classes[treeView.SelectedItem.ToString()]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateDataGrid(Globals.Classes[treeView.SelectedItem.ToString()]);
            }
        }

        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var index = dataGrid.SelectedIndex;
                var row = dataGrid.Items[index] as DataRowView;
                DataGridDeleting.Delete(int.Parse(row["ID"].ToString()), Globals.Classes[treeView.SelectedItem.ToString()]);
            }
        }
    }
}