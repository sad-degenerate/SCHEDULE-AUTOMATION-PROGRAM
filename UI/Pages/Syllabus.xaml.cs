using BL.Commands;
using System.Collections.Generic;
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
            var textGroups = new List<string>();

            foreach (var group in groups)
                textGroups.Add(group.Name);

            treeView.ItemsSource = textGroups;
        }

        private void treeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            textBoxPanel.Children.Clear();
            labelsPanel.Children.Clear();

            dataGrid.ItemsSource = Select.GroupsLoads().Where(g => g.Group.Name == treeView.SelectedItem.ToString());
        }
    }
}