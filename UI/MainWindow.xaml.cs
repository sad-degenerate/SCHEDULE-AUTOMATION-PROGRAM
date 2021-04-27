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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InsertTo()
        {
            Insert.Teacher("Сычёва Наталья Николаевна");

            Insert.Group("703a2", 23);

            Insert.Equipment("Лекционная аудитория", 100);
            Insert.Equipment("Аудитория для семинаров", 20);

            Insert.Classroom("102", 1);
            Insert.Classroom("303", 2);

            Insert.Subject("Русский язык (лекция)", 1);
            Insert.Subject("Математика (семинар)", 2);

            Insert.GroupsLoad(1, 1, 20);
            Insert.GroupsLoad(1, 2, 40);

            Insert.TeachersLoad(1, 1, 20);
            Insert.TeachersLoad(1, 2, 40);
        }

        private void SelectTo()
        {
            var teachers = Select.Teachers();
            foreach (var teacher in teachers)
                MessageBox.Show($"{teacher.Name} - {teacher.Id}");
        }

        private void UpdateTo()
        {
            var teacher = Select.Teachers().Where(t => t.Name == "test").SingleOrDefault();
            var teachers = new List<Teacher>();

            teacher.Name = "not test";
            teachers.Add(teacher);

            Update.Teacher(teachers);
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            SelectTo();
            //UpdateTo();
        }
    }
}