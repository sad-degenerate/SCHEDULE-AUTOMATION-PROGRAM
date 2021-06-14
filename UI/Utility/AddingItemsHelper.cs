using System.Windows.Controls;

namespace UI.Utility
{
    public static class AddingItemsHelper
    {
        private static TextBlock CreateLabel(string text)
        {
            var block = new TextBlock();
            block.Text = text;
            var marg = block.Margin;
            marg.Left = 10;
            marg.Top = 5;
            block.Margin = marg;
            return block;
        }

        public static (TextBlock, TextBox) CreateTextBox(string lblText)
        {
            return (CreateLabel(lblText), new TextBox());
        }

        public static (TextBlock, ComboBox) CreateComboBox(ComboBox box, string lblText)
        {
            return (CreateLabel(lblText), box);
        }
    }
}