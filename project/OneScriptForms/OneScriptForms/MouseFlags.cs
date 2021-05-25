using ScriptEngine.Machine.Contexts;

namespace osf
{
    [ContextClass ("КлФлагиМыши", "ClMouseFlags")]
    public class ClMouseFlags : AutoContext<ClMouseFlags>
    {
        private int m_move = 1; // 1 Переместить мышь.
        private int m_leftDown = 2; // 2 Нажать левую кнопку мыши.
        private int m_leftUp = 4; // 4 Отпустить левую кнопку мыши.
        private int m_rightDown = 8; // 8 Нажать правую кнопку мыши.
        private int m_rightUp = 16; // 16 Отпустить правую кнопку мыши.
        private int m_middleDown = 32; // 32 Нажать среднюю кнопку мыши.
        private int m_middleUp = 64; // 64 Отпустить среднюю кнопку мыши.
        private int m_absolute = 32768; // 32768 Если задано значение <B>Абсолютно&nbsp;(Absolute)</B>, то координаты x и y содержат нормализованные абсолютные координаты в диапазоне от 0 до 65535. Процедура события отображает эти координаты на поверхность дисплея. Координаты (0,0) отображаются в верхнем левом углу поверхности дисплея, (65535,65535) - в нижнем правом углу. Если значение <B>Абсолютно&nbsp;(Absolute)</B> не задано, то координаты x и y задают относительные движения с момента создания последнего события мыши (последняя сообщенная позиция). Положительные значения означают, что мышь переместилась вправо (или вниз); отрицательные значения означают, что мышь переместилась влево (или вверх).

        [ContextProperty("Абсолютно", "Absolute")]
        public int Absolute
        {
        	get { return m_absolute; }
        }

        [ContextProperty("ЛеваяВверх", "LeftUp")]
        public int LeftUp
        {
        	get { return m_leftUp; }
        }

        [ContextProperty("ЛеваяВниз", "LeftDown")]
        public int LeftDown
        {
        	get { return m_leftDown; }
        }

        [ContextProperty("Переместить", "Move")]
        public int Move
        {
        	get { return m_move; }
        }

        [ContextProperty("ПраваяВверх", "RightUp")]
        public int RightUp
        {
        	get { return m_rightUp; }
        }

        [ContextProperty("ПраваяВниз", "RightDown")]
        public int RightDown
        {
        	get { return m_rightDown; }
        }

        [ContextProperty("СредняяВверх", "MiddleUp")]
        public int MiddleUp
        {
        	get { return m_middleUp; }
        }

        [ContextProperty("СредняяВниз", "MiddleDown")]
        public int MiddleDown
        {
        	get { return m_middleDown; }
        }

    }
}
