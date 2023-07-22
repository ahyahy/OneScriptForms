// Код создан на основе разработки автора Sergey Semyonov https://www.codeproject.com/Articles/34037/DataGridVewTextBoxCell-with-Span-Behaviour под лицензией 
// The Code Project Open License (CPOL) 1.02 https://www.codeproject.com/info/cpol10.aspx

namespace osf
{
    static class DataGridViewHelper
    {
        public static bool SingleHorizontalBorderAdded(this System.Windows.Forms.DataGridView dataGridView)
        {
            return !dataGridView.ColumnHeadersVisible &&
                (dataGridView.AdvancedCellBorderStyle.All == System.Windows.Forms.DataGridViewAdvancedCellBorderStyle.Single ||
                 dataGridView.CellBorderStyle == System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal);
        }

        public static bool SingleVerticalBorderAdded(this System.Windows.Forms.DataGridView dataGridView)
        {
            return !dataGridView.RowHeadersVisible &&
                (dataGridView.AdvancedCellBorderStyle.All == System.Windows.Forms.DataGridViewAdvancedCellBorderStyle.Single ||
                 dataGridView.CellBorderStyle == System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical);
        }
    }
}
