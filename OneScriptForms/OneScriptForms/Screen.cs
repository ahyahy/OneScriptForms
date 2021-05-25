using ScriptEngine.Machine.Contexts;

namespace osf
{

    public class Screen
    {
        public ClScreen dll_obj;
        public System.Windows.Forms.Screen M_Screen;

        public Screen()
        {
            M_Screen = System.Windows.Forms.Screen.PrimaryScreen;
        }

        public Screen(System.Windows.Forms.Screen p1)
        {
            M_Screen = p1;
        }

        public Screen(osf.Screen p1)
        {
            M_Screen = p1.M_Screen;
        }

        //Свойства============================================================

        public osf.Rectangle Bounds
        {
            get { return new osf.Rectangle(M_Screen.Bounds); }
        }

        public osf.Screen PrimaryScreen
        {
            get { return new osf.Screen(System.Windows.Forms.Screen.PrimaryScreen); }
        }

        public osf.Rectangle WorkingArea
        {
            get { return new osf.Rectangle(M_Screen.WorkingArea); }
        }

        //Методы============================================================

    }

    [ContextClass ("КлЭкран", "ClScreen")]
    public class ClScreen : AutoContext<ClScreen>
    {
        private ClRectangle bounds;
        private ClRectangle workingArea;

        public ClScreen()
        {
            Screen Screen1 = new Screen();
            Screen1.dll_obj = this;
            Base_obj = Screen1;
            bounds = new ClRectangle(Base_obj.Bounds);
            workingArea = new ClRectangle(Base_obj.WorkingArea);
        }
		
        public ClScreen(Screen p1)
        {
            Screen Screen1 = p1;
            Screen1.dll_obj = this;
            Base_obj = Screen1;
            bounds = new ClRectangle(Base_obj.Bounds);
            workingArea = new ClRectangle(Base_obj.WorkingArea);
        }
        
        public Screen Base_obj;

        //Свойства============================================================

        [ContextProperty("Границы", "Bounds")]
        public ClRectangle Bounds
        {
            get { return bounds; }
        }

        [ContextProperty("ОсновнойЭкран", "PrimaryScreen")]
        public ClScreen PrimaryScreen
        {
            get { return new ClScreen(Base_obj.PrimaryScreen); }
        }

        [ContextProperty("РабочаяОбласть", "WorkingArea")]
        public ClRectangle WorkingArea
        {
            get { return workingArea; }
        }

        //Методы============================================================

    }
}
