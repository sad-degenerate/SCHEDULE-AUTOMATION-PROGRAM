﻿using BL;
using BL.Commands;
using BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для FillingFields.xaml
    /// </summary>
    public partial class FillingFields : Window
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

        private List<object> CreateList()
        {
            var list = new List<object>();

            foreach (var el in textBoxPanel.Children)
            {
                if (el is TextBox)
                    list.Add(((TextBox)el).Text);
                else if (el is ComboBox)
                    list.Add(((ComboBox)el).SelectedItem);
            }

            return list;
        }

        private void Teachers()
        {
            AddTextBox("ФИО учителя:");
        }

        private void TeachersAdd(object sender, EventArgs e)
        {
            Insert.Teachers(CreateList());
        }

        private void Classrooms()
        {
            AddTextBox("Название аудитории:");
            
            var box = new NewComboBox<Equipment>();
            AddComboBox(box.CreateComboBox(Select.Equipment()), "Оборудование:");
        }

        private void ClassroomsAdd(object sender, EventArgs e)
        {
            Insert.Classrooms(CreateList());
        }

        private void Equipment()
        {
            AddTextBox("Название:");

            AddTextBox("Количество сидений:");
        }

        private void EquipmentAdd(object sender, EventArgs e)
        {
            Insert.Equipment(CreateList());
        }

        private void Groups()
        {
            AddTextBox("Название:");

            AddTextBox("Количество учеников:");
        }

        private void GroupsAdd(object sender, EventArgs e)
        {
            Insert.Groups(CreateList());
        }

        private void Subjects()
        {
            AddTextBox("Название:");

            var box = new NewComboBox<Equipment>();
            AddComboBox(box.CreateComboBox(Select.Equipment()), "Оборудование: ");
        }

        private void SubjectsAdd(object sender, EventArgs e)
        {
            Insert.Subjects(CreateList());
        }

        private void treeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            labelsPanel.Children.Clear();
            textBoxPanel.Children.Clear();

            var res = new Button();
            res.VerticalAlignment = VerticalAlignment.Bottom;
            
            var marg = res.Margin;
            marg.Bottom = -200;
            res.Margin = marg;

            res.Content = "Добавить";

            switch (treeView.SelectedItem.ToString())
            {
                case "Teachers":
                    Teachers();
                    res.Click += TeachersAdd;
                    break;

                case "Classrooms":
                    Classrooms();
                    res.Click += ClassroomsAdd;
                    break;

                case "Equipment":
                    Equipment();
                    res.Click += EquipmentAdd;
                    break;

                case "Groups":
                    Groups();
                    res.Click += GroupsAdd;
                    break;

                case "Subjects":
                    Subjects();
                    res.Click += SubjectsAdd;
                    break;

                default:
                    return;
            }

            textBoxPanel.Children.Add(res);
        }
    }
}