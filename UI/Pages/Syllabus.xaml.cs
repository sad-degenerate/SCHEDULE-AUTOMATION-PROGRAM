using BL.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using UI.Utility;
using BL.Model;
using System;

namespace UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для Syllabus.xaml
    /// </summary>
    public partial class Syllabus : Page
    {
        private string currentTreeView = "teachers";

        public Syllabus()
        {
            InitializeComponent();

            Update();
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            textBoxPanel.Children.Clear();
            labelsPanel.Children.Clear();

            var res = new Button();
            var marg = res.Margin;
            marg.Top = 20;
            res.Margin = marg;
            res.VerticalAlignment = VerticalAlignment.Bottom;
            res.Content = "Добавить";

            // TODO: Переписать для случая преподавателей с одинаковыми именами.

            if (currentTreeView == "groups")
            {
                dataGrid.ItemsSource = Select.GroupsLoads().Where(g => g.Group.Name == treeView.SelectedItem.ToString());
            }
            else
            {
                dataGrid.ItemsSource = Select.TeachersLoads().Where(t => t.Teacher.Name == treeView.SelectedItem.ToString());
            }

            var box = new NewComboBox<Subject>();
            var subj = AddingItemsHelper.CreateComboBox(box.CreateComboBox(Select.Subjects()), "Предмет:");
            labelsPanel.Children.Add(subj.Item1);
            textBoxPanel.Children.Add(subj.Item2);

            var tbx = AddingItemsHelper.CreateTextBox("Нагрузка:");
            labelsPanel.Children.Add(tbx.Item1);
            textBoxPanel.Children.Add(tbx.Item2);

            

            textBoxPanel.Children.Add(res);

            res.Click += Add;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            // TODO: Ту да же исправление с одинаковыми именами.

            try
            {
                var list = DataListFromControlList.CreateList(textBoxPanel);
                if (currentTreeView == "teachers")
                {
                    list.Add(Select.Teachers().Where(t => t.Name == treeView.SelectedItem.ToString()).First());
                    Insert.TeachersLoad(list);
                }
                else
                {
                    list.Add(Select.Groups().Where(g => g.Name == treeView.SelectedItem.ToString()).First());
                    Insert.GroupsLoad(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update()
        {
            textBoxPanel.Children.Clear();
            labelsPanel.Children.Clear();

            var textList = new List<string>();

            switch (currentTreeView)
            {
                case "teachers":
                    var list = Select.Teachers();

                    foreach (var el in list)
                        textList.Add(el.Name);
                    break;

                case "groups":
                    var list1 = Select.Groups();

                    foreach (var el in list1)
                        textList.Add(el.Name);
                    break;

                default:
                    return;
            }

            treeView.ItemsSource = textList;
        }

        private void TreeViewSwitch(object sender, RoutedEventArgs e)
        {
            var s = sender as Button;

            if (s.Name == "btnTeachers")
                currentTreeView = "teachers";
            else
                currentTreeView = "groups";

            Update();
        }
    }
}