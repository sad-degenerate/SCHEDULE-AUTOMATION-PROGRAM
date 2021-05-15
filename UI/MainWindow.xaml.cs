using BL.Commands;
using System.Windows;
using UI.Pages;

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

            // TODO: Переписать.
            var s = Select.Subjects();
        }

        private void btnFillingFileds_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FillingFields();
        }

        private void btnInputSyllabus_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Syllabus();
        }
    }
}