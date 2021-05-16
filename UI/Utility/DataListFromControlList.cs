using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace UI.Utility
{
    public static class DataListFromControlList
    {
        public static List<object> CreateList(Panel textBoxPanel)
        {
            var list = new List<object>();

            foreach (var el in textBoxPanel.Children)
            {
                if (el is TextBox)
                    list.Add(((TextBox)el).Text);
                else if (el is ComboBox)
                    list.Add(((ComboBox)el).SelectedItem);
                else if (el is TimePicker)
                    list.Add(((TimePicker)el).SelectedTime.Value);
            }

            return list;
        }
    }
}