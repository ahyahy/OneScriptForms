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

namespace osf
{

    [ContextClass("КлВыбранныеУзлыДереваЗначений", "ClSelectedTreeNodeAdvCollection")]
    public class ClSelectedTreeNodeAdvCollection : AutoContext<ClSelectedTreeNodeAdvCollection>
    {

        public ClSelectedTreeNodeAdvCollection(System.Collections.ObjectModel.ReadOnlyCollection<Aga.Controls.Tree.TreeNodeAdv> p1)
        {
            Base_obj = p1;
        }//end_constr

        public System.Collections.ObjectModel.ReadOnlyCollection<Aga.Controls.Tree.TreeNodeAdv> Base_obj;

        //Свойства============================================================
        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

        //endProperty
        //Методы============================================================
        [ContextMethod("Индекс", "IndexOf")]
        public int IndexOf(ClNode p1)
        {
            return Base_obj.IndexOf(p1.Base_obj.TreeNodeAdv);
        }
        
        [ContextMethod("Содержит", "Contains")]
        public bool Contains(ClNode p1)
        {
            return Base_obj.Contains(p1.Base_obj.TreeNodeAdv);
        }
        
        [ContextMethod("Элемент", "Item")]
        public ClNode Item(int p1)
        {
            return new ClNode((Aga.Controls.Tree.Node)Base_obj[p1].Tag);
        }
        
        //endMethods
    }//endClass

}//endnamespace
