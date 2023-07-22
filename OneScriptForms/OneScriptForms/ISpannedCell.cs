// Код создан на основе разработки автора Sergey Semyonov https://www.codeproject.com/Articles/34037/DataGridVewTextBoxCell-with-Span-Behaviour под лицензией 
// The Code Project Open License (CPOL) 1.02 https://www.codeproject.com/info/cpol10.aspx

namespace osf
{
    interface ISpannedCell
    {
        int ColumnSpan { get; }
        int RowSpan { get; }
        System.Windows.Forms.DataGridViewCell OwnerCell { get; }
    }
}
