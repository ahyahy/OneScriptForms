using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace osf
{
    public class Graphics
    {
        public ClGraphics dll_obj;
        public System.Drawing.Graphics M_Graphics;

        public Graphics(osf.Graphics p1)
        {
            M_Graphics = p1.M_Graphics;
            OneScriptForms.AddToHashtable(M_Graphics, this);
        }

        public Graphics(System.Drawing.Graphics p1)
        {
            M_Graphics = p1;
            OneScriptForms.AddToHashtable(M_Graphics, this);
        }

        public float DpiX
        {
            get { return M_Graphics.DpiX; }
        }

        public float DpiY
        {
            get { return M_Graphics.DpiY; }
        }

        public void Clear(Color p1)
        {
            M_Graphics.Clear(p1.M_Color);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void CopyFromScreen(int p1, int p2, int p3, int p4, Size p5)
        {
            M_Graphics.CopyFromScreen(p1, p2, p3, p4, p5.M_Size);
        }

        public void Dispose()
        {
            M_Graphics.Dispose();
        }

        public void DrawEllipse(osf.Pen pen, float x, float y, float width, float height)
        {
            M_Graphics.DrawEllipse(pen.M_Pen, x, y, width, height);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void DrawImage(osf.Image image, float dx, float dy, float dw, float dh, float sx = 0.0f, float sy = 0.0f, float sw = -1f, float sh = -1f)
        {
            System.Drawing.Rectangle Rectangle1 = new System.Drawing.Rectangle();
            Rectangle1.X = (int)System.Math.Round((double)dx);
            Rectangle1.Y = (int)System.Math.Round((double)dy);
            Rectangle1.Width = (int)System.Math.Round((double)dw);
            Rectangle1.Height = (int)System.Math.Round((double)dh);
            if ((double)sw == -1.0)
            {
                sw = (float)image.Width;
            }
            if ((double)sh == -1.0)
            {
                sh = (float)image.Height;
            }
            M_Graphics.DrawImage(image.M_Image, Rectangle1, sx, sy, sw, sh, System.Drawing.GraphicsUnit.Pixel);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void DrawLine(osf.Pen pen, float x1, float y1, float x2, float y2)
        {
            M_Graphics.DrawLine(pen.M_Pen, x1, y1, x2, y2);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void DrawRectangle(osf.Pen pen, float x, float y, float width, float height)
        {
            M_Graphics.DrawRectangle(pen.M_Pen, x, y, width, height);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void DrawRoundRect(System.Drawing.Rectangle r, System.Drawing.Color color, int radius, int width)
        {
            JonasKohl.Graphics.RoundRect.DrawRoundRect(this.M_Graphics, r, color, radius, width);
        }

        public void DrawString(string str, osf.Font font, osf.Brush brush, float x, float y)
        {
            M_Graphics.DrawString(str, font.M_Font, (System.Drawing.Brush)brush.M_Brush, x, y);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void FillEllipse(osf.Brush brush, float x, float y, float width, float height)
        {
            M_Graphics.FillEllipse((System.Drawing.Brush)brush.M_Brush, x, y, width, height);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void FillRectangle(osf.Brush brush, float x, float y, float width, float height)
        {
            M_Graphics.FillRectangle((System.Drawing.Brush)brush.M_Brush, x, y, width, height);
            //System.Windows.Forms.Application.DoEvents();
        }

        public void FillRoundRect(System.Drawing.Brush pBrush, System.Drawing.Rectangle r, System.Drawing.Color border, int radius)
        {
            JonasKohl.Graphics.RoundRect.FillRoundRect(this.M_Graphics, pBrush, r, border, radius);
        }

        public osf.Graphics FromImage(osf.Image p1)
        {
            Graphics Graphics1 = new Graphics(System.Drawing.Graphics.FromImage(p1.M_Image));
            //System.Windows.Forms.Application.DoEvents();
            return Graphics1;
        }

        public void RotateTransform(float p1)
        {
            M_Graphics.RotateTransform(p1);
        }

        public void ScaleTransform(float p1, float p2)
        {
            M_Graphics.ScaleTransform(p1, p2);
        }

        public void TranslateTransform(float p1, float p2)
        {
            M_Graphics.TranslateTransform(p1, p2);
        }
    }

    [ContextClass ("КлГрафика", "ClGraphics")]
    public class ClGraphics : AutoContext<ClGraphics>
    {
        public ClGraphics(Graphics p1)
        {
            Graphics Graphics1 = p1;
            Graphics1.dll_obj = this;
            Base_obj = Graphics1;
        }

        public Graphics Base_obj;
        
        [ContextProperty("РазрешениеИгрек", "DpiY")]
        public IValue DpiY
        {
            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.DpiY))); }
        }
        
        [ContextProperty("РазрешениеИкс", "DpiX")]
        public IValue DpiX
        {
            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.DpiX))); }
        }
        
        [ContextMethod("ЗаполнитьЗакругленныйПрямоугольник", "FillRoundRect")]
        public void FillRoundRect(IValue p1, ClRectangle p2, ClColor p3, int p4)
        {
            Base_obj.FillRoundRect(((dynamic)p1).Base_obj.M_Brush, p2.Base_obj.M_Rectangle, p3.Base_obj.M_Color, p4);
        }
        
        [ContextMethod("ЗаполнитьПрямоугольник", "FillRectangle")]
        public void FillRectangle(IValue p1, IValue p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.FillRectangle(((dynamic)p1).Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("ЗаполнитьЭллипс", "FillEllipse")]
        public void FillEllipse(IValue p1, IValue p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.FillEllipse(((dynamic)p1).Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("ИзИзображения", "FromImage")]
        public ClGraphics FromImage(ClBitmap p1)
        {
            return new ClGraphics(Base_obj.FromImage(p1.Base_obj));
        }
        
        [ContextMethod("КопироватьСЭкрана", "CopyFromScreen")]
        public void CopyFromScreen(int p1, int p2, int p3, int p4, ClSize p5)
        {
            Base_obj.CopyFromScreen(p1, p2, p3, p4, p5.Base_obj);
        }
        
        [ContextMethod("Масштабировать", "ScaleTransform")]
        public void ScaleTransform(IValue p1, IValue p2)
        {
            Base_obj.ScaleTransform(Convert.ToSingle(p1.AsNumber()), Convert.ToSingle(p2.AsNumber()));
        }
        
        [ContextMethod("Освободить", "Dispose")]
        public void Dispose()
        {
            Base_obj.Dispose();
        }
					
        [ContextMethod("Очистить", "Clear")]
        public void Clear(ClColor p1)
        {
            Base_obj.Clear(p1.Base_obj);
        }

        [ContextMethod("Повернуть", "RotateTransform")]
        public void RotateTransform(IValue p1)
        {
            Base_obj.RotateTransform(Convert.ToSingle(p1.AsNumber()));
        }
        
        [ContextMethod("РисоватьЗакругленныйПрямоугольник", "DrawRoundRect")]
        public void DrawRoundRect(ClRectangle p1, ClColor p2, int p3, int p4)
        {
            Base_obj.DrawRoundRect(p1.Base_obj.M_Rectangle, p2.Base_obj.M_Color, p3, p4);
        }
        
        [ContextMethod("РисоватьИзображение", "DrawImage")]
        public void DrawImage(ClBitmap p1, IValue p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.DrawImage(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("РисоватьЛинию", "DrawLine")]
        public void DrawLine(ClPen p1, IValue p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.DrawLine(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("РисоватьПрямоугольник", "DrawRectangle")]
        public void DrawRectangle(ClPen p1, IValue p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.DrawRectangle(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("РисоватьСтроку", "DrawString")]
        public void DrawString(string p1, ClFont p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.DrawString(p1, p2.Base_obj, ((dynamic)p3).Base_obj, Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("РисоватьЭллипс", "DrawEllipse")]
        public void DrawEllipse(ClPen p1, IValue p2, IValue p3, IValue p4, IValue p5)
        {
            Base_obj.DrawEllipse(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
        }
        
        [ContextMethod("Сдвинуть", "TranslateTransform")]
        public void TranslateTransform(IValue p1, IValue p2)
        {
            Base_obj.TranslateTransform(Convert.ToSingle(p1.AsNumber()), Convert.ToSingle(p2.AsNumber()));
        }
    }
}
