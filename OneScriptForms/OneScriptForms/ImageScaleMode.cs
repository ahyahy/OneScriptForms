using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлРежимМасштабированияКартинки", "ClImageScaleMode")]
    public class ClImageScaleMode : AutoContext<ClImageScaleMode>
    {
        private int m_clip = 0; // 0 Не масштабировать
        private int m_fit = 1; // 1 Масштабирует изображение так, чтобы оно соответствовало прямоугольнику дисплея, соотношение сторон не фиксировано.
        private int m_alwaysScale = 2; // 2 Масштабирование изображения в соответствии с отображаемым прямоугольником с учетом соотношения сторон.

        [ContextProperty("Вписать", "Fit")]
        public int Fit
        {
        	get { return m_fit; }
        }

        [ContextProperty("Клип", "Clip")]
        public int Clip
        {
        	get { return m_clip; }
        }

        [ContextProperty("Масштабировать", "AlwaysScale")]
        public int AlwaysScale
        {
        	get { return m_alwaysScale; }
        }
    }
}
