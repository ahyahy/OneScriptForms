using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлПоведениеСсылки", "ClLinkLabelLinkBehavior")]
    public class ClLinkLabelLinkBehavior : AutoContext<ClLinkLabelLinkBehavior>
    {
        private int m_systemDefault = (int)System.Windows.Forms.LinkBehavior.SystemDefault; // 0 Поведение данной настройки зависит от параметров, заданных с помощью диалогового окна "Свойства обозревателя" панели управления или Internet Explorer.
        private int m_alwaysUnderline = (int)System.Windows.Forms.LinkBehavior.AlwaysUnderline; // 1 В ссылке всегда отображается подчеркнутый текст.
        private int m_hoverUnderline = (int)System.Windows.Forms.LinkBehavior.HoverUnderline; // 2 В ссылке отображается подчеркнутый текст, только когда мышь находится на тексте ссылки.
        private int m_neverUnderline = (int)System.Windows.Forms.LinkBehavior.NeverUnderline; // 3 Текст ссылки никогда не отображается подчеркнутым. Ссылку по-прежнему можно отличить от другого текста с помощью свойства <B>ЦветСсылки&nbsp;(LinkColor)</B> элемента управления <B>НадписьСсылка&nbsp;(LinkLabel)</B>.

        [ContextProperty("ВсегдаПодчеркнутый", "AlwaysUnderline")]
        public int AlwaysUnderline
        {
        	get { return m_alwaysUnderline; }
        }

        [ContextProperty("НеПодчеркнутый", "NeverUnderline")]
        public int NeverUnderline
        {
        	get { return m_neverUnderline; }
        }

        [ContextProperty("ПодчеркнутыйПриНаведении", "HoverUnderline")]
        public int HoverUnderline
        {
        	get { return m_hoverUnderline; }
        }

        [ContextProperty("СистемныйПоУмолчанию", "SystemDefault")]
        public int SystemDefault
        {
        	get { return m_systemDefault; }
        }

    }
}
