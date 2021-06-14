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
using UI.Utility;

namespace UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для OptimalityCriterions.xaml
    /// </summary>
    public partial class OptimalityCriterions : Page
    {
        public OptimalityCriterions()
        {
            InitializeComponent();

            Update();
        }

        private void AddTextBoxToScene(string labelText, string textBoxName, int textBoxValue)
        {
            var tbx = AddingItemsHelper.CreateTextBox(labelText);

            var label = tbx.Item1;
            var textbox = tbx.Item2;
            textbox.Name = textBoxName;
            textbox.Text = textBoxValue.ToString();

            labelsPanel.Children.Add(label);
            textBoxPanel.Children.Add(textbox);
        }

        public void Update()
        {
            textBoxPanel.Children.Clear();
            labelsPanel.Children.Clear();

            var items = Select.OptimalityCriterions();

            foreach (var item in items)
                AddTextBoxToScene(item.Name, item.Code, item.Value);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var items = Select.OptimalityCriterions();

            foreach (var el in textBoxPanel.Children)
            {
                var textbox = el as TextBox;
                var item = items.Where(x => x.Code == textbox.Name).First();

                try
                {
                    int.TryParse(textbox.Text, out var value);
                    item.Value = value;
                    Update<OptimalityCriterion>.UpdateTable(item);
                }
                catch
                {
                    MessageBox.Show("Вы ввели не целочисленное число.");
                }
            }

            Update();
        }
    }
}
