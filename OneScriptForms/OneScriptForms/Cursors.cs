using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Collections.Generic;
using System.Collections;

namespace osf
{
    public class Cursors
    {
        public ClCursors dll_obj;

        public osf.Cursor AppStarting
        {
            get {return new Cursor(System.Windows.Forms.Cursors.AppStarting); }
        }

        public osf.Cursor Arrow
        {
            get {return new Cursor(System.Windows.Forms.Cursors.Arrow); }
        }

        public osf.Cursor Cross
        {
            get {return new Cursor(System.Windows.Forms.Cursors.Cross); }
        }

        public osf.Cursor Default
        {
            get {return new Cursor(System.Windows.Forms.Cursors.Default); }
        }

        public osf.Cursor Hand
        {
            get {return new Cursor(System.Windows.Forms.Cursors.Hand); }
        }

        public osf.Cursor Help
        {
            get {return new Cursor(System.Windows.Forms.Cursors.Help); }
        }

        public osf.Cursor HSplit
        {
            get {return new Cursor(System.Windows.Forms.Cursors.HSplit); }
        }

        public osf.Cursor IBeam
        {
            get {return new Cursor(System.Windows.Forms.Cursors.IBeam); }
        }

        public osf.Cursor No
        {
            get {return new Cursor(System.Windows.Forms.Cursors.No); }
        }

        public osf.Cursor NoMove2D
        {
            get {return new Cursor(System.Windows.Forms.Cursors.NoMove2D); }
        }

        public osf.Cursor NoMoveHoriz
        {
            get {return new Cursor(System.Windows.Forms.Cursors.NoMoveHoriz); }
        }

        public osf.Cursor NoMoveVert
        {
            get {return new Cursor(System.Windows.Forms.Cursors.NoMoveVert); }
        }

        public osf.Cursor PanEast
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanEast); }
        }

        public osf.Cursor PanNE
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanNE); }
        }

        public osf.Cursor PanNorth
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanNorth); }
        }

        public osf.Cursor PanNW
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanNW); }
        }

        public osf.Cursor PanSE
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanSE); }
        }

        public osf.Cursor PanSouth
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanSouth); }
        }

        public osf.Cursor PanSW
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanSW); }
        }

        public osf.Cursor PanWest
        {
            get {return new Cursor(System.Windows.Forms.Cursors.PanWest); }
        }

        public osf.Cursor SizeAll
        {
            get {return new Cursor(System.Windows.Forms.Cursors.SizeAll); }
        }

        public osf.Cursor SizeNESW
        {
            get {return new Cursor(System.Windows.Forms.Cursors.SizeNESW); }
        }

        public osf.Cursor SizeNS
        {
            get {return new Cursor(System.Windows.Forms.Cursors.SizeNS); }
        }

        public osf.Cursor SizeNWSE
        {
            get {return new Cursor(System.Windows.Forms.Cursors.SizeNWSE); }
        }

        public osf.Cursor SizeWE
        {
            get {return new Cursor(System.Windows.Forms.Cursors.SizeWE); }
        }

        public osf.Cursor UpArrow
        {
            get {return new Cursor(System.Windows.Forms.Cursors.UpArrow); }
        }

        public osf.Cursor VSplit
        {
            get {return new Cursor(System.Windows.Forms.Cursors.VSplit); }
        }

        public osf.Cursor WaitCursor
        {
            get {return new Cursor(System.Windows.Forms.Cursors.WaitCursor); }
        }
    }

    [ContextClass ("КлКурсоры", "ClCursors")]
    public class ClCursors : AutoContext<ClCursors>, ICollectionContext, IEnumerable<IValue>
    {
        private List<IValue> _list;

        public ClCursors()
        {
            Cursors Cursors1 = new Cursors();
            Cursors1.dll_obj = this;
            Base_obj = Cursors1;

            _list = new List<IValue>();
            _list.Add(NoMove2D);
            _list.Add(NoMoveVert);
            _list.Add(NoMoveHoriz);
            _list.Add(VSplit);
            _list.Add(HSplit);
            _list.Add(PanEast);
            _list.Add(PanWest);
            _list.Add(WaitCursor);
            _list.Add(PanNorth);
            _list.Add(PanNE);
            _list.Add(PanNW);
            _list.Add(PanSouth);
            _list.Add(PanSE);
            _list.Add(PanSW);
            _list.Add(Hand);
            _list.Add(IBeam);
            _list.Add(No);
            _list.Add(Cross);
            _list.Add(Default);
            _list.Add(AppStarting);
            _list.Add(SizeWE);
            _list.Add(SizeNESW);
            _list.Add(SizeNWSE);
            _list.Add(SizeNS);
            _list.Add(SizeAll);
            _list.Add(Help);
            _list.Add(Arrow);
            _list.Add(UpArrow);
        }

        public ClCursors(Cursors p1)
        {
            Cursors Cursors1 = p1;
            Cursors1.dll_obj = this;
            Base_obj = Cursors1;

            _list = new List<IValue>();
            _list.Add(NoMove2D);
            _list.Add(NoMoveVert);
            _list.Add(NoMoveHoriz);
            _list.Add(VSplit);
            _list.Add(HSplit);
            _list.Add(PanEast);
            _list.Add(PanWest);
            _list.Add(WaitCursor);
            _list.Add(PanNorth);
            _list.Add(PanNE);
            _list.Add(PanNW);
            _list.Add(PanSouth);
            _list.Add(PanSE);
            _list.Add(PanSW);
            _list.Add(Hand);
            _list.Add(IBeam);
            _list.Add(No);
            _list.Add(Cross);
            _list.Add(Default);
            _list.Add(AppStarting);
            _list.Add(SizeWE);
            _list.Add(SizeNESW);
            _list.Add(SizeNWSE);
            _list.Add(SizeNS);
            _list.Add(SizeAll);
            _list.Add(Help);
            _list.Add(Arrow);
            _list.Add(UpArrow);
        }

        public int Count()
        {
            return _list.Count;
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IValue>)_list).GetEnumerator();
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        public Cursors Base_obj;
        
        [ContextProperty("БезДвижения2D", "NoMove2D")]
        public ClCursor NoMove2D
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.NoMove2D); }
        }

        [ContextProperty("БезДвиженияВертикально", "NoMoveVert")]
        public ClCursor NoMoveVert
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.NoMoveVert); }
        }

        [ContextProperty("БезДвиженияГоризонтально", "NoMoveHoriz")]
        public ClCursor NoMoveHoriz
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.NoMoveHoriz); }
        }

        [ContextProperty("ВРазделитель", "VSplit")]
        public ClCursor VSplit
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.VSplit); }
        }

        [ContextProperty("ГРазделитель", "HSplit")]
        public ClCursor HSplit
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.HSplit); }
        }

        [ContextProperty("КурсорВ", "PanEast")]
        public ClCursor PanEast
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanEast); }
        }

        [ContextProperty("КурсорЗ", "PanWest")]
        public ClCursor PanWest
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanWest); }
        }

        [ContextProperty("КурсорОжидания", "WaitCursor")]
        public ClCursor WaitCursor
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.WaitCursor); }
        }

        [ContextProperty("КурсорС", "PanNorth")]
        public ClCursor PanNorth
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanNorth); }
        }

        [ContextProperty("КурсорСВ", "PanNE")]
        public ClCursor PanNE
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanNE); }
        }

        [ContextProperty("КурсорСЗ", "PanNW")]
        public ClCursor PanNW
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanNW); }
        }

        [ContextProperty("КурсорЮ", "PanSouth")]
        public ClCursor PanSouth
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanSouth); }
        }

        [ContextProperty("КурсорЮВ", "PanSE")]
        public ClCursor PanSE
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanSE); }
        }

        [ContextProperty("КурсорЮЗ", "PanSW")]
        public ClCursor PanSW
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.PanSW); }
        }

        [ContextProperty("Ладонь", "Hand")]
        public ClCursor Hand
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Hand); }
        }

        [ContextProperty("Луч", "IBeam")]
        public ClCursor IBeam
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.IBeam); }
        }

        [ContextProperty("Нет", "No")]
        public ClCursor No
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.No); }
        }

        [ContextProperty("Перекрестие", "Cross")]
        public ClCursor Cross
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Cross); }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public ClCursor Default
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Default); }
        }

        [ContextProperty("ПриСтарте", "AppStarting")]
        public ClCursor AppStarting
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.AppStarting); }
        }

        [ContextProperty("РазмерЗВ", "SizeWE")]
        public ClCursor SizeWE
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.SizeWE); }
        }

        [ContextProperty("РазмерСВЮЗ", "SizeNESW")]
        public ClCursor SizeNESW
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.SizeNESW); }
        }

        [ContextProperty("РазмерСЗЮВ", "SizeNWSE")]
        public ClCursor SizeNWSE
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.SizeNWSE); }
        }

        [ContextProperty("РазмерСЮ", "SizeNS")]
        public ClCursor SizeNS
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.SizeNS); }
        }

        [ContextProperty("РазмерЧетырехконечный", "SizeAll")]
        public ClCursor SizeAll
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.SizeAll); }
        }

        [ContextProperty("Справка", "Help")]
        public ClCursor Help
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Help); }
        }

        [ContextProperty("Стрелка", "Arrow")]
        public ClCursor Arrow
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.Arrow); }
        }

        [ContextProperty("СтрелкаВверх", "UpArrow")]
        public ClCursor UpArrow
        {
            get { return (ClCursor)OneScriptForms.RevertObj(Base_obj.UpArrow); }
        }
        
    }
}
