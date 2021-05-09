using BL.Commands;
using System.Linq;
using System.Windows.Controls;


namespace UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для Syllabus.xaml
    /// </summary>
    public partial class Syllabus : Page
    {
        public Syllabus()
        {
            InitializeComponent();

            var groups = Select.Groups();
            var subjects = Select.Subjects();

            for (var i = 0; i < groups.Count(); i++)
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (var i = 0; i < subjects.Count(); i++)
                mainGrid.RowDefinitions.Add(new RowDefinition());

            

            

            mainGrid.ShowGridLines = true;
        }
    }
}