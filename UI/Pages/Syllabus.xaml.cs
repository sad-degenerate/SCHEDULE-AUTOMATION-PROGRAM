using BL.Commands;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using UI.Utility;
using BL.Model;
using System;
using BL;
using System.Data;
using System.ComponentModel;
using System.Windows.Input;

namespace UI.Pages
{
    public partial class Syllabus : Page
    {
        private ModelObjectsTypes currentTreeView = ModelObjectsTypes.teachersLoad;
        private DataRowView _editingRow;

        public Syllabus()
        {
            InitializeComponent();

            Update();
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

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            textBoxPanel.Children.Clear();
            labelsPanel.Children.Clear();

            var res = ButtonStyle();
            UpdateDataGrid();

            var ncb = new NewComboBox<Subject>();
            var box = ncb.CreateComboBox(Select.Subjects());
            AddComboBoxToScene("Предмет:", box);

            AddTextBoxToScene("Нагрузка:");

            res.Click += Add;
            res.Click += UpdateDataGridEvent;

            textBoxPanel.Children.Add(res);
        }

        private void UpdateDataGridEvent(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            try
            {
                if (currentTreeView == ModelObjectsTypes.flowsLoad)
                    dataGrid.ItemsSource = DataGridFilling.FlowsLoad(treeView.SelectedItem.ToString()).AsDataView();
                else
                    dataGrid.ItemsSource = DataGridFilling.TeachersLoad(treeView.SelectedItem.ToString()).AsDataView();

                for (var i = 0; i < dataGrid.Items.Count; i++)
                {
                    ((DataRowView)dataGrid.Items[i]).PropertyChanged += Changing;
                }
            }
            catch { }
            
        }

        private void Changing(object sender, PropertyChangedEventArgs e)
        {
            _editingRow = dataGrid.CurrentItem as DataRowView;
            EditingDataGrid();
        }

        private static Button ButtonStyle()
        {
            var res = new Button();
            var marg = res.Margin;
            marg.Top = 20;
            res.Margin = marg;
            res.VerticalAlignment = VerticalAlignment.Bottom;
            res.Content = "Добавить";
            return res;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var list = DataListFromControlList.CreateList(textBoxPanel);
                object selected = treeView.SelectedItem.ToString();
                list.Add(selected);
                UserInputToDB.Insert(list, currentTreeView);
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
                case ModelObjectsTypes.teachersLoad:
                    var list = Select.Teachers();

                    foreach (var el in list)
                        textList.Add(el.Name);
                    break;

                case ModelObjectsTypes.flowsLoad:
                    var list1 = Select.Flows();

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
                currentTreeView = ModelObjectsTypes.teachersLoad;
            else
                currentTreeView = ModelObjectsTypes.flowsLoad;

            Update();
        }

        private void EditingDataGrid()
        {
            try
            {
                var edit = new DataGridEditing(_editingRow);
                edit.EditDataGrid(currentTreeView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateDataGrid();
            }
        }

        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    var index = dataGrid.SelectedIndex;
                    var row = dataGrid.Items[index] as DataRowView;
                    DataGridDeleting.Delete(int.Parse(row["ID"].ToString()), Globals.Classes[treeView.SelectedItem.ToString()]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}