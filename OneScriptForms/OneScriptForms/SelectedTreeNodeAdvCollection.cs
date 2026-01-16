using ScriptEngine.Machine.Contexts;

namespace osf
{

    [ContextClass("КлВыбранныеУзлыДереваЗначений", "ClSelectedTreeNodeAdvCollection")]
    public class ClSelectedTreeNodeAdvCollection : AutoContext<ClSelectedTreeNodeAdvCollection>
    {

        public ClSelectedTreeNodeAdvCollection(System.Collections.ObjectModel.ReadOnlyCollection<Aga.Controls.Tree.TreeNodeAdv> p1)
        {
            Base_obj = p1;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Aga.Controls.Tree.TreeNodeAdv> Base_obj;

        [ContextProperty("Количество", "Count")]
        public int Count
        {
            get { return Base_obj.Count; }
        }

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

    }
}
