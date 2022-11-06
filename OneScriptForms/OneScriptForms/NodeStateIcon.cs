using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Aga.Controls.Tree.NodeControls;
using Aga.Controls.Threading;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeStateIcon : NodeIcon
    {
        private Image image;
        private Image selectedImage;
        public Dictionary<Node, Image> nodeStateIconImage = new Dictionary<Node, Image>();
        public Dictionary<Node, osf.ClBitmap> StateIconImage = new Dictionary<Node, osf.ClBitmap>();

        public NodeStateIcon()
        {
        }
		
        public void ResetStateIconImage(Node p1)
        {
            nodeStateIconImage.Remove(p1);
        }

        public void SetStateIconImage(Node p1, Image p2)
        {
            if (!nodeStateIconImage.ContainsKey(p1))
            {
                nodeStateIconImage.Add(p1, p2);
            }
            else
            {
                if (!((object)nodeStateIconImage[p1]).Equals(p2))
                {
                    nodeStateIconImage[p1] = p2;
                }
            }
        }

        public Image GetStateIconImage(Node p1)
        {
            try
            {
                return nodeStateIconImage[p1];
            }
            catch
            {
                return null;
            }
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            Image image = GetIcon(node);
            Image imageNode = GetStateIconImage((Node)node.Tag);
            if (imageNode != null)
            {
                image = imageNode;
            }
		
            if (node.IsSelected)
            {
                if (SelectedImage != null)
                {
                    image = SelectedImage;
                }
            }

            if (image != null)
            {
                Rectangle r = GetBounds(node, context);
                if (image.Width > 0 && image.Height > 0)
                {
                    float f = (float)(image.Height - node.Tree.RowHeight) / 2;
                    switch (ScaleMode)
                    {
                        case ImageScaleMode.Fit:
                            {
                                r.Y = r.Y + Convert.ToInt32(f);
                                r.Height = node.Tree.RowHeight;
                                context.Graphics.DrawImage(image, r);
                            }
                            break;
                        case ImageScaleMode.AlwaysScale:
                            {
                                float fh = (float)node.Tree.RowHeight / (float)image.Height;
                                if (node.Tree.RowHeight > image.Height) // высота строки больше высоты рисунка - увеличиваем рисунок
                                {
                                    context.Graphics.DrawImage(image, r.X, r.Y + f, image.Width * fh, image.Height * fh);
                                }
                                else if (node.Tree.RowHeight < image.Height) // высота строки меньше высоты рисунка - уменьшаем рисунок
                                {
                                    context.Graphics.DrawImage(image, r.X, r.Y + f, image.Width * fh, image.Height * fh);
                                }
                                else // не масштабируем
                                {
                                    context.Graphics.DrawImage(image, r.X, r.Y, image.Width, image.Height);
                                }
                            }
                            break;
                        case ImageScaleMode.Clip:
                        default:
                            context.Graphics.DrawImage(image, r.X, r.Y, image.Width, image.Height);
                            break;
                    }
                }
            }
        }

        private static Image MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(bitmap.GetPixel(0, 0));
            return bitmap;
        }

        protected override Image GetIcon(TreeNodeAdv node)
        {
            return Image;
        }
		
        public System.Drawing.Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public System.Drawing.Image SelectedImage
        {
            get { return selectedImage; }
            set { selectedImage = value; }
        }
		
        public override Size MeasureSize(TreeNodeAdv node, DrawContext context)
        {
            Image image = GetIcon(node);
            Image imageNode = GetStateIconImage((Node)node.Tag);
            if (imageNode != null)
            {
                image = imageNode;
            }
		
            if (node.IsSelected)
            {
                if (SelectedImage != null)
                {
                    image = SelectedImage;
                }
            }
		
            if (image != null)
            {
                if (this.ScaleMode == ImageScaleMode.AlwaysScale)
                {
                    float fh = (float)node.Tree.RowHeight / (float)image.Height;
                    Size Size1 = image.Size;
                    Size1.Width = Convert.ToInt32(Size1.Width * fh);
                    return Size1;
                }
                else
                {
                    return image.Size;
                }
            }
            else
            {
                return Size.Empty;
            }
        }
    }
}

namespace osf
{

    [ContextClass("КлЗначокУзла", "ClNodeStateIcon")]
    public class ClNodeStateIcon : AutoContext<ClNodeStateIcon>
    {

        public ClNodeStateIcon()
        {
            Base_obj = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            Image = new ClBitmap("iVBORw0KGgoAAAANSUhEUgAAABgAAAAYCAYAAADgdz34AAAAK0lEQVR42u3NMQEAAAiEQL5/aF2s8JMQgAswFMsBKf1HQEBAQEBA4BlQawFcRy4BIkls/QAAAABJRU5ErkJggg==");
        }//end_constr
		
        public ClNodeStateIcon(Aga.Controls.Tree.NodeControls.NodeStateIcon p1)
        {
            Base_obj = p1;
        }//end_constr

        public Aga.Controls.Tree.NodeControls.NodeStateIcon Base_obj;

        //Свойства============================================================
        [ContextProperty("Изображение", "Image")]
       public ClBitmap Image
        {
            get { return (ClBitmap)OneScriptForms.RevertEqualsObj(Base_obj.Image); }
            set
            {
                Base_obj.Image = value.Base_obj.M_Bitmap;
                OneScriptForms.AddToHashtable(Base_obj.Image, value);
            }
        }
        
        [ContextProperty("ИзображениеВыбранного", "SelectedImage")]
        public ClBitmap SelectedImage
        {
            get { return (ClBitmap)OneScriptForms.RevertEqualsObj(Base_obj.SelectedImage); }
            set
            {
                Base_obj.SelectedImage = value.Base_obj.M_Bitmap;
                OneScriptForms.AddToHashtable(Base_obj.SelectedImage, value);
            }
        }
        
        [ContextProperty("Колонка", "ParentColumn")]
        public ClTreeColumn ParentColumn
        {
            get { return (ClTreeColumn)OneScriptForms.RevertEqualsObj(Base_obj.ParentColumn); }
            set
            {
                Base_obj.ParentColumn = value.Base_obj.M_TreeColumn;
                OneScriptForms.AddToHashtable(Base_obj.ParentColumn, value);
            }
        }
        
        [ContextProperty("ЛевыйОтступ", "LeftMargin")]
        public int LeftMargin
        {
            get { return Base_obj.LeftMargin; }
            set { Base_obj.LeftMargin = value; }
        }

        [ContextProperty("РежимМасштабирования", "ScaleMode")]
        public int ScaleMode
        {
            get { return (int)Base_obj.ScaleMode; }
            set { Base_obj.ScaleMode = (Aga.Controls.Tree.ImageScaleMode)value; }
        }

        //endProperty
        //Методы============================================================
        [ContextMethod("ПолучитьЗначение", "GetValue")]
        public ClBitmap GetValue(ClNode p1)
        {
            ClBitmap ClBitmap1 = null;
            try
            {
                ClBitmap1 = Base_obj.StateIconImage[p1.Base_obj];
            }
            catch { }
            return ClBitmap1;
        }

        [ContextMethod("СброситьЗначение", "ResetValue")]
        public void ResetValue(ClNode p1)
        {
            Base_obj.ResetStateIconImage(p1.Base_obj);
            Base_obj.StateIconImage.Remove(p1.Base_obj);
        }

        [ContextMethod("УстановитьЗначение", "SetValue")]
        public void SetValue(ClNode p1, ClBitmap p2)
        {
            Base_obj.SetStateIconImage(p1.Base_obj, p2.Base_obj.M_Image);
            Base_obj.StateIconImage.Add(p1.Base_obj, p2);
        }

        //endMethods
    }//endClass

}//endnamespace
