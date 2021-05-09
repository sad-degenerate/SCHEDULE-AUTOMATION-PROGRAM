using BL.Commands;
using System.Collections.Generic;
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
            

            switch (treeView.SelectedItem.ToString())
            {

            }
        }
    }
}