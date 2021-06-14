using System.Collections.Generic;
using System.Windows.Controls;
using UI.Pages;

public class NewComboBox<T> : FillingFields
{
    public NewComboBox() { }

    public ComboBox CreateComboBox(List<T> list)
    {
        var comboBox = new ComboBox();
        comboBox.ItemsSource = list;
        comboBox.SelectedIndex = 0;

        return comboBox;
    }

    public ComboBox CreateCheckBoxComboBox(List<T> list)
    {
        var comboBox = new ComboBox();

        var checkBoxes = new List<CheckBox>();

        foreach (var item in list)
        {
            var checkBox = new CheckBox();
            checkBox.Content = item.ToString();

            checkBoxes.Add(checkBox);
        }

        comboBox.ItemsSource = checkBoxes;

        return comboBox;
    }
}