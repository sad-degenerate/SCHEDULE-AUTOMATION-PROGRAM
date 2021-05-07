using System.Collections.Generic;
using System.Windows.Controls;
using UI;

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
}