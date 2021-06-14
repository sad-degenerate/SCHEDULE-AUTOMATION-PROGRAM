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
                else if (el is ComboBox && ((ComboBox)el).HasItems)
                {
                    var comboBox = (ComboBox)el;
                    
                    if (comboBox.Items[0] is CheckBox)
                    {
                        var collection = new Dictionary<string, bool>();

                        foreach (CheckBox item in comboBox.Items)
                            collection.Add(item.Content.ToString(), (bool)item.IsChecked);
                            
                        list.Add(collection);
                    }
                    else
                        list.Add(((ComboBox)el).SelectedItem);
                }
            }

            return list;
        }
    }
}