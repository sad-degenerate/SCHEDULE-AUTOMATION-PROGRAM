using BL;
using BL.Commands;
using BL.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using UI.Utility;

namespace UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для FillingFields.xaml
    /// </summary>
    public partial class FillingFields : Page
    {
        public FillingFields()
        {
            InitializeComponent();

            treeView.ItemsSource = Data.Classes;
        }

        private void Teachers()
        {
            var tbx = AddingItemsHelper.CreateTextBox("ФИО учителя:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);
        }

        private void TeachersAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Teachers(DataListFromControlList.CreateList(textBoxPanel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Classrooms()
        {
            var tbx = AddingItemsHelper.CreateTextBox("Название аудитории:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);

            var box = new NewComboBox<Equipment>();
            var cbx = AddingItemsHelper.CreateComboBox(box.CreateComboBox(Select.Equipment()), "Оборудование:");
            labelsPanel.Children.Add(cbx.Item1);
            textBoxPanel.Children.Add(cbx.Item2);
        }

        private void ClassroomsAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Classrooms(DataListFromControlList.CreateList(textBoxPanel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void Equipment()
        {
            var tbx = AddingItemsHelper.CreateTextBox("Название:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);

            tbx = AddingItemsHelper.CreateTextBox("Количество сидений:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);
        }

        private void EquipmentAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Equipment(DataListFromControlList.CreateList(textBoxPanel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }      
        }

        private void Groups()
        {
            var tbx = AddingItemsHelper.CreateTextBox("Название:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);

            tbx = AddingItemsHelper.CreateTextBox("Количество учеников:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);
        }

        private void GroupsAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Groups(DataListFromControlList.CreateList(textBoxPanel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Subjects()
        {
            var tbx = AddingItemsHelper.CreateTextBox("Название:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);

            var box = new NewComboBox<Equipment>();
            var cbx = AddingItemsHelper.CreateComboBox(box.CreateComboBox(Select.Equipment()), "Оборудование:");
            labelsPanel.Children.Add(cbx.Item1);
            textBoxPanel.Children.Add(cbx.Item2);
        }

        private void SubjectsAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Subjects(DataListFromControlList.CreateList(textBoxPanel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LessonTimeAdd(object sender, RoutedEventArgs e)
        {
            try
            {
                Insert.LessonTimes(DataListFromControlList.CreateList(textBoxPanel));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LessonTime()
        {
            var tpr = AddingItemsHelper.CreateTimePicker("Начало:");
            labelsPanel.Children.Add(tpr.Item1);
            textBoxPanel.Children.Add(tpr.Item2);

            tpr = AddingItemsHelper.CreateTimePicker("Конец:");
            labelsPanel.Children.Add(tpr.Item1);
            textBoxPanel.Children.Add(tpr.Item2);
        }

        private void treeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            labelsPanel.Children.Clear();
            textBoxPanel.Children.Clear();

            var res = new Button();
            res.VerticalAlignment = VerticalAlignment.Bottom;

            var marg = res.Margin;
            marg.Top = 20;
            res.Margin = marg;

            res.Content = "Добавить";

            switch (treeView.SelectedItem.ToString())
            {
                case "Teachers":
                    Teachers();
                    res.Click += TeachersAdd;
                    dataGrid.ItemsSource = Select.Teachers();
                    break;

                case "Classrooms":
                    Classrooms();
                    res.Click += ClassroomsAdd;
                    dataGrid.ItemsSource = Select.Classrooms();
                    break;

                case "Equipment":
                    Equipment();
                    res.Click += EquipmentAdd;
                    dataGrid.ItemsSource = Select.Equipment();
                    break;

                case "Groups":
                    Groups();
                    res.Click += GroupsAdd;
                    dataGrid.ItemsSource = Select.Groups();
                    break;

                case "Subjects":
                    Subjects();
                    res.Click += SubjectsAdd;
                    dataGrid.ItemsSource = Select.Subjects();
                    break;

                case "Lesson time":
                    LessonTime();
                    res.Click += LessonTimeAdd;
                    dataGrid.ItemsSource = Select.LessonTimes();
                    break;

                default:
                    return;
            }

            res.Click += Update;
            textBoxPanel.Children.Add(res);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            switch (treeView.SelectedItem.ToString())
            {
                case "Teachers":
                    dataGrid.ItemsSource = Select.Teachers();
                    break;

                case "Classrooms":
                    dataGrid.ItemsSource = Select.Classrooms();
                    break;

                case "Equipment":
                    dataGrid.ItemsSource = Select.Equipment();
                    break;

                case "Groups":
                    dataGrid.ItemsSource = Select.Groups();
                    break;

                case "Subjects":
                    dataGrid.ItemsSource = Select.Subjects();
                    break;

                case "Lesson time":
                    dataGrid.ItemsSource = Select.LessonTimes();
                    break;

                default:
                    return;
            }
        }
    }
}