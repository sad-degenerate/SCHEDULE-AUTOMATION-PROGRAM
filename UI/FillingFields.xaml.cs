using BL;
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

        private void Teachers()
        {
            var name = new TextBlock();
            name.Text = "ФИО учителя:";
            labelsPanel.Children.Add(name);
            textBoxPanel.Children.Add(new TextBox());
        }

        private void TeachersAdd(object sender, EventArgs e)
        {
            var list = new List<object>();

            foreach (var el in textBoxPanel.Children)
            {
                if (el is TextBox)
                    list.Add(((TextBox)el).Text);
            }

            Insert.Teacher(list);
        }

        private void Classrooms()
        {
            var name = new TextBlock();
            name.Text = "Название аудитории:";
            labelsPanel.Children.Add(name);
            textBoxPanel.Children.Add(new TextBox());

            var equipment = Select.Equipment();
            var comboBox = new ComboBox();
            comboBox.ItemsSource = equipment;
            textBoxPanel.Children.Add(comboBox);
            var equipmentLabel = new TextBlock();
            equipmentLabel.Text = "Оборудование:";
            labelsPanel.Children.Add(equipmentLabel);
        }

        private void ClassroomsAdd(object sender, EventArgs e)
        {
            var list = new List<object>();

            foreach (var el in textBoxPanel.Children)
            {
                if (el is TextBox)
                    list.Add(((TextBox)el).Text);
                else
                    list.Add(el);
            }

            Insert.Classroom(list);
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

                default:
                    return;
            }

            textBoxPanel.Children.Add(res);
        }
    }
}