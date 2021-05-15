using BL;
using BL.Commands;
using BL.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        private void AddLabel(string text)
        {
            var block = new TextBlock();
            block.Text = text;
            var marg = block.Margin;
            marg.Left = 10;
            marg.Top = 5;
            block.Margin = marg;
            labelsPanel.Children.Add(block);
        }

        private void AddTextBox(string lblText)
        {
            AddLabel(lblText);

            textBoxPanel.Children.Add(new TextBox());
        }

        private void AddComboBox(ComboBox box, string lblText)
        {
            textBoxPanel.Children.Add(box);

            AddLabel(lblText);
        }

        private void AddTimePicker(string lblText)
        {
            var time = new TimePicker();
            textBoxPanel.Children.Add(time);

            AddLabel(lblText);
        }

        private List<object> CreateList()
        {
            var list = new List<object>();

            foreach (var el in textBoxPanel.Children)
            {
                if (el is TextBox)
                    list.Add(((TextBox)el).Text);
                else if (el is ComboBox)
                    list.Add(((ComboBox)el).SelectedItem);
                else if (el is TimePicker)
                    list.Add(((TimePicker)el).SelectedTime.Value);
            }

            return list;
        }

        private void Teachers()
        {
            AddTextBox("ФИО учителя:");
        }

        private void TeachersAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Teachers(CreateList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Classrooms()
        {
            AddTextBox("Название аудитории:");

            var box = new NewComboBox<Equipment>();
            AddComboBox(box.CreateComboBox(Select.Equipment()), "Оборудование:");
        }

        private void ClassroomsAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Classrooms(CreateList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void Equipment()
        {
            AddTextBox("Название:");

            AddTextBox("Количество сидений:");
        }

        private void EquipmentAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Equipment(CreateList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }      
        }

        private void Groups()
        {
            AddTextBox("Название:");

            AddTextBox("Количество учеников:");
        }

        private void GroupsAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Groups(CreateList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Subjects()
        {
            AddTextBox("Название:");

            var box = new NewComboBox<Equipment>();
            AddComboBox(box.CreateComboBox(Select.Equipment()), "Оборудование: ");
        }

        private void SubjectsAdd(object sender, EventArgs e)
        {
            try
            {
                Insert.Subjects(CreateList());
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
                Insert.LessonTimes(CreateList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LessonTime()
        {
            AddTimePicker("Начало:");
            AddTimePicker("Конец:");
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

            textBoxPanel.Children.Add(res);
        }
    }
}
