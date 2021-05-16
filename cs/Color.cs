using System;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.Machine;
using System.Reflection;

namespace osf
{

    public class Color
    {
        public ClColor dll_obj;
        public System.Drawing.Color M_Color;

        public Color()
        {
            M_Color = System.Drawing.Color.Empty;
        }

        public Color(System.Drawing.Color p1)
        {
            M_Color = p1;
        }

        //Свойства============================================================

        public Color(osf.Color p1)
        {
            M_Color = p1.M_Color;
        }

        //Свойства============================================================

        public int A
        {
            get { return M_Color.A; }
        }

        public osf.Color ActiveBorder
        {
            get { return new Color(System.Drawing.Color.FromName("ActiveBorder")); }
        }

        public osf.Color ActiveCaption
        {
            get { return new Color(System.Drawing.Color.FromName("ActiveCaption")); }
        }

        public osf.Color ActiveCaptionText
        {
            get { return new Color(System.Drawing.Color.FromName("ActiveCaptionText")); }
        }

        public osf.Color AliceBlue
        {
            get { return new Color(System.Drawing.Color.FromName("AliceBlue")); }
        }

        public osf.Color AntiqueWhite
        {
            get { return new Color(System.Drawing.Color.FromName("AntiqueWhite")); }
        }

        public osf.Color AppWorkspace
        {
            get { return new Color(System.Drawing.Color.FromName("AppWorkspace")); }
        }

        public osf.Color Aqua
        {
            get { return new Color(System.Drawing.Color.FromName("Aqua")); }
        }

        public osf.Color Aquamarine
        {
            get { return new Color(System.Drawing.Color.FromName("Aquamarine")); }
        }

        public osf.Color Azure
        {
            get { return new Color(System.Drawing.Color.FromName("Azure")); }
        }

        public int B
        {
            get { return Convert.ToInt32(M_Color.B); }
        }

        public osf.Color Beige
        {
            get { return new Color(System.Drawing.Color.FromName("Beige")); }
        }

        public osf.Color Bisque
        {
            get { return new Color(System.Drawing.Color.FromName("Bisque")); }
        }

        public osf.Color Black
        {
            get { return new Color(System.Drawing.Color.FromName("Black")); }
        }

        public osf.Color BlanchedAlmond
        {
            get { return new Color(System.Drawing.Color.FromName("BlanchedAlmond")); }
        }

        public osf.Color Blue
        {
            get { return new Color(System.Drawing.Color.FromName("Blue")); }
        }

        public osf.Color BlueViolet
        {
            get { return new Color(System.Drawing.Color.FromName("BlueViolet")); }
        }

        public osf.Color Brown
        {
            get { return new Color(System.Drawing.Color.FromName("Brown")); }
        }

        public osf.Color BurlyWood
        {
            get { return new Color(System.Drawing.Color.FromName("BurlyWood")); }
        }

        public osf.Color CadetBlue
        {
            get { return new Color(System.Drawing.Color.FromName("CadetBlue")); }
        }

        public osf.Color Chartreuse
        {
            get { return new Color(System.Drawing.Color.FromName("Chartreuse")); }
        }

        public osf.Color Chocolate
        {
            get { return new Color(System.Drawing.Color.FromName("Chocolate")); }
        }

        public osf.Color Control
        {
            get { return new Color(System.Drawing.Color.FromName("Control")); }
        }

        public osf.Color ControlDark
        {
            get { return new Color(System.Drawing.Color.FromName("ControlDark")); }
        }

        public osf.Color ControlDarkDark
        {
            get { return new Color(System.Drawing.Color.FromName("ControlDarkDark")); }
        }

        public osf.Color ControlLight
        {
            get { return new Color(System.Drawing.Color.FromName("ControlLight")); }
        }

        public osf.Color ControlLightLight
        {
            get { return new Color(System.Drawing.Color.FromName("ControlLightLight")); }
        }

        public osf.Color ControlText
        {
            get { return new Color(System.Drawing.Color.FromName("ControlText")); }
        }

        public osf.Color Coral
        {
            get { return new Color(System.Drawing.Color.FromName("Coral")); }
        }

        public osf.Color CornflowerBlue
        {
            get { return new Color(System.Drawing.Color.FromName("CornflowerBlue")); }
        }

        public osf.Color Cornsilk
        {
            get { return new Color(System.Drawing.Color.FromName("Cornsilk")); }
        }

        public osf.Color Crimson
        {
            get { return new Color(System.Drawing.Color.FromName("Crimson")); }
        }

        public osf.Color Cyan
        {
            get { return new Color(System.Drawing.Color.FromName("Cyan")); }
        }

        public osf.Color DarkBlue
        {
            get { return new Color(System.Drawing.Color.FromName("DarkBlue")); }
        }

        public osf.Color DarkCyan
        {
            get { return new Color(System.Drawing.Color.FromName("DarkCyan")); }
        }

        public osf.Color DarkGoldenrod
        {
            get { return new Color(System.Drawing.Color.FromName("DarkGoldenrod")); }
        }

        public osf.Color DarkGray
        {
            get { return new Color(System.Drawing.Color.FromName("DarkGray")); }
        }

        public osf.Color DarkGreen
        {
            get { return new Color(System.Drawing.Color.FromName("DarkGreen")); }
        }

        public osf.Color DarkKhaki
        {
            get { return new Color(System.Drawing.Color.FromName("DarkKhaki")); }
        }

        public osf.Color DarkMagenta
        {
            get { return new Color(System.Drawing.Color.FromName("DarkMagenta")); }
        }

        public osf.Color DarkOliveGreen
        {
            get { return new Color(System.Drawing.Color.FromName("DarkOliveGreen")); }
        }

        public osf.Color DarkOrange
        {
            get { return new Color(System.Drawing.Color.FromName("DarkOrange")); }
        }

        public osf.Color DarkOrchid
        {
            get { return new Color(System.Drawing.Color.FromName("DarkOrchid")); }
        }

        public osf.Color DarkRed
        {
            get { return new Color(System.Drawing.Color.FromName("DarkRed")); }
        }

        public osf.Color DarkSalmon
        {
            get { return new Color(System.Drawing.Color.FromName("DarkSalmon")); }
        }

        public osf.Color DarkSeaGreen
        {
            get { return new Color(System.Drawing.Color.FromName("DarkSeaGreen")); }
        }

        public osf.Color DarkSlateBlue
        {
            get { return new Color(System.Drawing.Color.FromName("DarkSlateBlue")); }
        }

        public osf.Color DarkSlateGray
        {
            get { return new Color(System.Drawing.Color.FromName("DarkSlateGray")); }
        }

        public osf.Color DarkTurquoise
        {
            get { return new Color(System.Drawing.Color.FromName("DarkTurquoise")); }
        }

        public osf.Color DarkViolet
        {
            get { return new Color(System.Drawing.Color.FromName("DarkViolet")); }
        }

        public osf.Color DeepPink
        {
            get { return new Color(System.Drawing.Color.FromName("DeepPink")); }
        }

        public osf.Color DeepSkyBlue
        {
            get { return new Color(System.Drawing.Color.FromName("DeepSkyBlue")); }
        }

        public osf.Color Desktop
        {
            get { return new Color(System.Drawing.Color.FromName("Desktop")); }
        }

        public osf.Color DimGray
        {
            get { return new Color(System.Drawing.Color.FromName("DimGray")); }
        }

        public osf.Color DodgerBlue
        {
            get { return new Color(System.Drawing.Color.FromName("DodgerBlue")); }
        }

        public osf.Color Firebrick
        {
            get { return new Color(System.Drawing.Color.FromName("Firebrick")); }
        }

        public osf.Color FloralWhite
        {
            get { return new Color(System.Drawing.Color.FromName("FloralWhite")); }
        }

        public osf.Color ForestGreen
        {
            get { return new Color(System.Drawing.Color.FromName("ForestGreen")); }
        }

        public osf.Color Fuchsia
        {
            get { return new Color(System.Drawing.Color.FromName("Fuchsia")); }
        }

        public int G
        {
            get { return Convert.ToInt32(M_Color.G); }
        }

        public osf.Color Gainsboro
        {
            get { return new Color(System.Drawing.Color.FromName("Gainsboro")); }
        }

        public osf.Color GhostWhite
        {
            get { return new Color(System.Drawing.Color.FromName("GhostWhite")); }
        }

        public osf.Color Gold
        {
            get { return new Color(System.Drawing.Color.FromName("Gold")); }
        }

        public osf.Color Goldenrod
        {
            get { return new Color(System.Drawing.Color.FromName("Goldenrod")); }
        }

        public osf.Color Gray
        {
            get { return new Color(System.Drawing.Color.FromName("Gray")); }
        }

        public osf.Color GrayText
        {
            get { return new Color(System.Drawing.Color.FromName("GrayText")); }
        }

        public osf.Color Green
        {
            get { return new Color(System.Drawing.Color.FromName("Green")); }
        }

        public osf.Color GreenYellow
        {
            get { return new Color(System.Drawing.Color.FromName("GreenYellow")); }
        }

        public osf.Color Highlight
        {
            get { return new Color(System.Drawing.Color.FromName("Highlight")); }
        }

        public osf.Color HighlightText
        {
            get { return new Color(System.Drawing.Color.FromName("HighlightText")); }
        }

        public osf.Color Honeydew
        {
            get { return new Color(System.Drawing.Color.FromName("Honeydew")); }
        }

        public osf.Color HotPink
        {
            get { return new Color(System.Drawing.Color.FromName("HotPink")); }
        }

        public osf.Color HotTrack
        {
            get { return new Color(System.Drawing.Color.FromName("HotTrack")); }
        }

        public osf.Color InactiveBorder
        {
            get { return new Color(System.Drawing.Color.FromName("InactiveBorder")); }
        }

        public osf.Color InactiveCaption
        {
            get { return new Color(System.Drawing.Color.FromName("InactiveCaption")); }
        }

        public osf.Color InactiveCaptionText
        {
            get { return new Color(System.Drawing.Color.FromName("InactiveCaptionText")); }
        }

        public osf.Color IndianRed
        {
            get { return new Color(System.Drawing.Color.FromName("IndianRed")); }
        }

        public osf.Color Indigo
        {
            get { return new Color(System.Drawing.Color.FromName("Indigo")); }
        }

        public osf.Color Info
        {
            get { return new Color(System.Drawing.Color.FromName("Info")); }
        }

        public osf.Color InfoText
        {
            get { return new Color(System.Drawing.Color.FromName("InfoText")); }
        }

        public bool IsEmpty
        {
            get { return M_Color.IsEmpty; }
        }

        public osf.Color Ivory
        {
            get { return new Color(System.Drawing.Color.FromName("Ivory")); }
        }

        public osf.Color Khaki
        {
            get { return new Color(System.Drawing.Color.FromName("Khaki")); }
        }

        public osf.Color Lavender
        {
            get { return new Color(System.Drawing.Color.FromName("Lavender")); }
        }

        public osf.Color LavenderBlush
        {
            get { return new Color(System.Drawing.Color.FromName("LavenderBlush")); }
        }

        public osf.Color LawnGreen
        {
            get { return new Color(System.Drawing.Color.FromName("LawnGreen")); }
        }

        public osf.Color LemonChiffon
        {
            get { return new Color(System.Drawing.Color.FromName("LemonChiffon")); }
        }

        public osf.Color LightBlue
        {
            get { return new Color(System.Drawing.Color.FromName("LightBlue")); }
        }

        public osf.Color LightCoral
        {
            get { return new Color(System.Drawing.Color.FromName("LightCoral")); }
        }

        public osf.Color LightCyan
        {
            get { return new Color(System.Drawing.Color.FromName("LightCyan")); }
        }

        public osf.Color LightGoldenrodYellow
        {
            get { return new Color(System.Drawing.Color.FromName("LightGoldenrodYellow")); }
        }

        public osf.Color LightGray
        {
            get { return new Color(System.Drawing.Color.FromName("LightGray")); }
        }

        public osf.Color LightGreen
        {
            get { return new Color(System.Drawing.Color.FromName("LightGreen")); }
        }

        public osf.Color LightPink
        {
            get { return new Color(System.Drawing.Color.FromName("LightPink")); }
        }

        public osf.Color LightSalmon
        {
            get { return new Color(System.Drawing.Color.FromName("LightSalmon")); }
        }

        public osf.Color LightSeaGreen
        {
            get { return new Color(System.Drawing.Color.FromName("LightSeaGreen")); }
        }

        public osf.Color LightSkyBlue
        {
            get { return new Color(System.Drawing.Color.FromName("LightSkyBlue")); }
        }

        public osf.Color LightSlateGray
        {
            get { return new Color(System.Drawing.Color.FromName("LightSlateGray")); }
        }

        public osf.Color LightSteelBlue
        {
            get { return new Color(System.Drawing.Color.FromName("LightSteelBlue")); }
        }

        public osf.Color LightYellow
        {
            get { return new Color(System.Drawing.Color.FromName("LightYellow")); }
        }

        public osf.Color Lime
        {
            get { return new Color(System.Drawing.Color.FromName("Lime")); }
        }

        public osf.Color LimeGreen
        {
            get { return new Color(System.Drawing.Color.FromName("LimeGreen")); }
        }

        public osf.Color Linen
        {
            get { return new Color(System.Drawing.Color.FromName("Linen")); }
        }

        public osf.Color Magenta
        {
            get { return new Color(System.Drawing.Color.FromName("Magenta")); }
        }

        public osf.Color Maroon
        {
            get { return new Color(System.Drawing.Color.FromName("Maroon")); }
        }

        public osf.Color MediumAquamarine
        {
            get { return new Color(System.Drawing.Color.FromName("MediumAquamarine")); }
        }

        public osf.Color MediumBlue
        {
            get { return new Color(System.Drawing.Color.FromName("MediumBlue")); }
        }

        public osf.Color MediumOrchid
        {
            get { return new Color(System.Drawing.Color.FromName("MediumOrchid")); }
        }

        public osf.Color MediumPurple
        {
            get { return new Color(System.Drawing.Color.FromName("MediumPurple")); }
        }

        public osf.Color MediumSeaGreen
        {
            get { return new Color(System.Drawing.Color.FromName("MediumSeaGreen")); }
        }

        public osf.Color MediumSlateBlue
        {
            get { return new Color(System.Drawing.Color.FromName("MediumSlateBlue")); }
        }

        public osf.Color MediumSpringGreen
        {
            get { return new Color(System.Drawing.Color.FromName("MediumSpringGreen")); }
        }

        public osf.Color MediumTurquoise
        {
            get { return new Color(System.Drawing.Color.FromName("MediumTurquoise")); }
        }

        public osf.Color MediumVioletRed
        {
            get { return new Color(System.Drawing.Color.FromName("MediumVioletRed")); }
        }

        public osf.Color Menu
        {
            get { return new Color(System.Drawing.Color.FromName("Menu")); }
        }

        public osf.Color MenuText
        {
            get { return new Color(System.Drawing.Color.FromName("MenuText")); }
        }

        public osf.Color MidnightBlue
        {
            get { return new Color(System.Drawing.Color.FromName("MidnightBlue")); }
        }

        public osf.Color MintCream
        {
            get { return new Color(System.Drawing.Color.FromName("MintCream")); }
        }

        public osf.Color MistyRose
        {
            get { return new Color(System.Drawing.Color.FromName("MistyRose")); }
        }

        public osf.Color Moccasin
        {
            get { return new Color(System.Drawing.Color.FromName("Moccasin")); }
        }

        public string Name
        {
            get { return M_Color.Name; }
        }

        public osf.Color NavajoWhite
        {
            get { return new Color(System.Drawing.Color.FromName("NavajoWhite")); }
        }

        public osf.Color Navy
        {
            get { return new Color(System.Drawing.Color.FromName("Navy")); }
        }

        public osf.Color OldLace
        {
            get { return new Color(System.Drawing.Color.FromName("OldLace")); }
        }

        public osf.Color Olive
        {
            get { return new Color(System.Drawing.Color.FromName("Olive")); }
        }

        public osf.Color OliveDrab
        {
            get { return new Color(System.Drawing.Color.FromName("OliveDrab")); }
        }

        public osf.Color Orange
        {
            get { return new Color(System.Drawing.Color.FromName("Orange")); }
        }

        public osf.Color OrangeRed
        {
            get { return new Color(System.Drawing.Color.FromName("OrangeRed")); }
        }

        public osf.Color Orchid
        {
            get { return new Color(System.Drawing.Color.FromName("Orchid")); }
        }

        public osf.Color PaleGoldenrod
        {
            get { return new Color(System.Drawing.Color.FromName("PaleGoldenrod")); }
        }

        public osf.Color PaleGreen
        {
            get { return new Color(System.Drawing.Color.FromName("PaleGreen")); }
        }

        public osf.Color PaleTurquoise
        {
            get { return new Color(System.Drawing.Color.FromName("PaleTurquoise")); }
        }

        public osf.Color PaleVioletRed
        {
            get { return new Color(System.Drawing.Color.FromName("PaleVioletRed")); }
        }

        public osf.Color PapayaWhip
        {
            get { return new Color(System.Drawing.Color.FromName("PapayaWhip")); }
        }

        public osf.Color PeachPuff
        {
            get { return new Color(System.Drawing.Color.FromName("PeachPuff")); }
        }

        public osf.Color Peru
        {
            get { return new Color(System.Drawing.Color.FromName("Peru")); }
        }

        public osf.Color Pink
        {
            get { return new Color(System.Drawing.Color.FromName("Pink")); }
        }

        public osf.Color Plum
        {
            get { return new Color(System.Drawing.Color.FromName("Plum")); }
        }

        public osf.Color PowderBlue
        {
            get { return new Color(System.Drawing.Color.FromName("PowderBlue")); }
        }

        public osf.Color Purple
        {
            get { return new Color(System.Drawing.Color.FromName("Purple")); }
        }

        public int R
        {
            get { return Convert.ToInt32(M_Color.R); }
        }

        public osf.Color Red
        {
            get { return new Color(System.Drawing.Color.FromName("Red")); }
        }

        public osf.Color RosyBrown
        {
            get { return new Color(System.Drawing.Color.FromName("RosyBrown")); }
        }

        public osf.Color RoyalBlue
        {
            get { return new Color(System.Drawing.Color.FromName("RoyalBlue")); }
        }

        public osf.Color SaddleBrown
        {
            get { return new Color(System.Drawing.Color.FromName("SaddleBrown")); }
        }

        public osf.Color Salmon
        {
            get { return new Color(System.Drawing.Color.FromName("Salmon")); }
        }

        public osf.Color SandyBrown
        {
            get { return new Color(System.Drawing.Color.FromName("SandyBrown")); }
        }

        public osf.Color ScrollBar
        {
            get { return new Color(System.Drawing.Color.FromName("ScrollBar")); }
        }

        public osf.Color SeaGreen
        {
            get { return new Color(System.Drawing.Color.FromName("SeaGreen")); }
        }

        public osf.Color SeaShell
        {
            get { return new Color(System.Drawing.Color.FromName("SeaShell")); }
        }

        public osf.Color Sienna
        {
            get { return new Color(System.Drawing.Color.FromName("Sienna")); }
        }

        public osf.Color Silver
        {
            get { return new Color(System.Drawing.Color.FromName("Silver")); }
        }

        public osf.Color SkyBlue
        {
            get { return new Color(System.Drawing.Color.FromName("SkyBlue")); }
        }

        public osf.Color SlateBlue
        {
            get { return new Color(System.Drawing.Color.FromName("SlateBlue")); }
        }

        public osf.Color SlateGray
        {
            get { return new Color(System.Drawing.Color.FromName("SlateGray")); }
        }

        public osf.Color Snow
        {
            get { return new Color(System.Drawing.Color.FromName("Snow")); }
        }

        public osf.Color SpringGreen
        {
            get { return new Color(System.Drawing.Color.FromName("SpringGreen")); }
        }

        public osf.Color SteelBlue
        {
            get { return new Color(System.Drawing.Color.FromName("SteelBlue")); }
        }

        public osf.Color Tan
        {
            get { return new Color(System.Drawing.Color.FromName("Tan")); }
        }

        public osf.Color Teal
        {
            get { return new Color(System.Drawing.Color.FromName("Teal")); }
        }

        public osf.Color Thistle
        {
            get { return new Color(System.Drawing.Color.FromName("Thistle")); }
        }

        public osf.Color Tomato
        {
            get { return new Color(System.Drawing.Color.FromName("Tomato")); }
        }

        public osf.Color Transparent
        {
            get { return new Color(System.Drawing.Color.FromName("Transparent")); }
        }

        public osf.Color Turquoise
        {
            get { return new Color(System.Drawing.Color.FromName("Turquoise")); }
        }

        public osf.Color Violet
        {
            get { return new Color(System.Drawing.Color.FromName("Violet")); }
        }

        public osf.Color Wheat
        {
            get { return new Color(System.Drawing.Color.FromName("Wheat")); }
        }

        public osf.Color White
        {
            get { return new Color(System.Drawing.Color.FromName("White")); }
        }

        public osf.Color WhiteSmoke
        {
            get { return new Color(System.Drawing.Color.FromName("WhiteSmoke")); }
        }

        public osf.Color Window
        {
            get { return new Color(System.Drawing.Color.FromName("Window")); }
        }

        public osf.Color WindowFrame
        {
            get { return new Color(System.Drawing.Color.FromName("WindowFrame")); }
        }

        public osf.Color WindowText
        {
            get { return new Color(System.Drawing.Color.FromName("WindowText")); }
        }

        public osf.Color Yellow
        {
            get { return new Color(System.Drawing.Color.FromName("Yellow")); }
        }

        public osf.Color YellowGreen
        {
            get { return new Color(System.Drawing.Color.FromName("YellowGreen")); }
        }

        //Методы============================================================

        public osf.Color FromArgb(int a, int r, int g, int b)
        {
            return new Color(System.Drawing.Color.FromArgb(a, r, g, b));
        }

        public osf.Color FromName(string p1)
        {
            return new Color(System.Drawing.Color.FromName(p1));
        }

        public osf.Color FromRgb(int r, int g, int b)
        {
            return new Color(System.Drawing.Color.FromArgb(r, g, b));
        }

        public int ToArgb()
        {
            return M_Color.ToArgb();
        }

    }

    [ContextClass ("КлЦвет", "ClColor")]
    public class ClColor : AutoContext<ClColor>
    {

        public ClColor()
        {
            Color Color1 = new Color();
            Color1.dll_obj = this;
            Base_obj = Color1;
        }
		
        public ClColor(Color p1)
        {
            Color Color1 = p1;
            Color1.dll_obj = this;
            Base_obj = Color1;
        }
        
        public Color Base_obj;

        //Свойства============================================================

        [ContextProperty("Аквамариновый", "Aquamarine")]
        public ClColor Aquamarine
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Aquamarine); }
        }

        [ContextProperty("АнтичныйБелый", "AntiqueWhite")]
        public ClColor AntiqueWhite
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.AntiqueWhite); }
        }

        [ContextProperty("Бежевый", "Beige")]
        public ClColor Beige
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Beige); }
        }

        [ContextProperty("БелаяДымка", "WhiteSmoke")]
        public ClColor WhiteSmoke
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.WhiteSmoke); }
        }

        [ContextProperty("Белый", "White")]
        public ClColor White
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.White); }
        }

        [ContextProperty("БелыйНавахо", "NavajoWhite")]
        public ClColor NavajoWhite
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.NavajoWhite); }
        }

        [ContextProperty("Бирюзовый", "Turquoise")]
        public ClColor Turquoise
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Turquoise); }
        }

        [ContextProperty("Бисквитный", "Bisque")]
        public ClColor Bisque
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Bisque); }
        }

        [ContextProperty("БледноБирюзовый", "PaleTurquoise")]
        public ClColor PaleTurquoise
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PaleTurquoise); }
        }

        [ContextProperty("БледноЖелтый", "Cornsilk")]
        public ClColor Cornsilk
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Cornsilk); }
        }

        [ContextProperty("БледноЗеленый", "PaleGreen")]
        public ClColor PaleGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PaleGreen); }
        }

        [ContextProperty("БледноЗолотистый", "PaleGoldenrod")]
        public ClColor PaleGoldenrod
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PaleGoldenrod); }
        }

        [ContextProperty("Васильковый", "CornflowerBlue")]
        public ClColor CornflowerBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.CornflowerBlue); }
        }

        [ContextProperty("Выделенный", "HotTrack")]
        public ClColor HotTrack
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.HotTrack); }
        }

        [ContextProperty("ВыделеныйЭлемент", "ControlLightLight")]
        public ClColor ControlLightLight
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ControlLightLight); }
        }

        [ContextProperty("ГлубокийРозовый", "DeepPink")]
        public ClColor DeepPink
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DeepPink); }
        }

        [ContextProperty("Голубой", "DeepSkyBlue")]
        public ClColor DeepSkyBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DeepSkyBlue); }
        }

        [ContextProperty("ГраницаАктивного", "ActiveBorder")]
        public ClColor ActiveBorder
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ActiveBorder); }
        }

        [ContextProperty("ГраницаНеактивного", "InactiveBorder")]
        public ClColor InactiveBorder
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.InactiveBorder); }
        }

        [ContextProperty("ГрифельноСерый", "LightSlateGray")]
        public ClColor LightSlateGray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightSlateGray); }
        }

        [ContextProperty("ГрифельноСиний", "SlateBlue")]
        public ClColor SlateBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SlateBlue); }
        }

        [ContextProperty("ЖелтоЗеленый", "YellowGreen")]
        public ClColor YellowGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.YellowGreen); }
        }

        [ContextProperty("Желтый", "Yellow")]
        public ClColor Yellow
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Yellow); }
        }

        [ContextProperty("ЗаголовокАктивного", "ActiveCaption")]
        public ClColor ActiveCaption
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ActiveCaption); }
        }

        [ContextProperty("ЗаголовокНеактивного", "InactiveCaption")]
        public ClColor InactiveCaption
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.InactiveCaption); }
        }

        [ContextProperty("ЗащитноСиний", "DodgerBlue")]
        public ClColor DodgerBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DodgerBlue); }
        }

        [ContextProperty("ЗеленаяВесна", "SpringGreen")]
        public ClColor SpringGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SpringGreen); }
        }

        [ContextProperty("ЗеленаяЛужайка", "LawnGreen")]
        public ClColor LawnGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LawnGreen); }
        }

        [ContextProperty("ЗеленоЖелтый", "GreenYellow")]
        public ClColor GreenYellow
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.GreenYellow); }
        }

        [ContextProperty("ЗеленоеМоре", "SeaGreen")]
        public ClColor SeaGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SeaGreen); }
        }

        [ContextProperty("Зеленый", "Green")]
        public ClColor Green
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Green); }
        }

        [ContextProperty("ЗеленыйЛайм", "LimeGreen")]
        public ClColor LimeGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LimeGreen); }
        }

        [ContextProperty("ЗеленыйЛесной", "ForestGreen")]
        public ClColor ForestGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ForestGreen); }
        }

        [ContextProperty("ЗначениеАльфа", "A")]
        public int A
        {
            get { return Base_obj.A; }
        }

        [ContextProperty("ЗначениеЗеленый", "G")]
        public int G
        {
            get { return Base_obj.G; }
        }

        [ContextProperty("ЗначениеКрасный", "R")]
        public int R
        {
            get { return Base_obj.R; }
        }

        [ContextProperty("ЗначениеСиний", "B")]
        public int B
        {
            get { return Base_obj.B; }
        }

        [ContextProperty("Золотарник", "Goldenrod")]
        public ClColor Goldenrod
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Goldenrod); }
        }

        [ContextProperty("Золотой", "Gold")]
        public ClColor Gold
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Gold); }
        }

        [ContextProperty("Имя", "Имя")]
        public string NameRu
        {
            get
            {
                try
                {
                    return this.GetType().GetProperty(this.Base_obj.Name).GetCustomAttribute<ContextPropertyAttribute>().GetName();
                }
                catch
                {
                    int Dec1 = (Base_obj.R * 65536) + (Base_obj.G * 256) + Base_obj.B;
                    if (Dec1 == 0)
                    {
                        return "Черный (Black)";
                    }
                    return "RGB(" + this.R.ToString() + ", " + this.G.ToString() + ", " + this.B.ToString() + ")";
                }
            }
        }

        [ContextProperty("Name", "Name")]
        public string NameEn
        {
            get
            {
                try
                {
                    return this.GetType().GetProperty(this.Base_obj.Name).GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
                }
                catch
                {
                    int Dec1 = (Base_obj.R * 65536) + (Base_obj.G * 256) + Base_obj.B;
                    if (Dec1 == 0)
                    {
                        return "Черный (Black)";
                    }
                    return "RGB(" + this.R.ToString() + ", " + this.G.ToString() + ", " + this.B.ToString() + ")";
                }
            }
        }
        
        [ContextProperty("Индиго", "Indigo")]
        public ClColor Indigo
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Indigo); }
        }

        [ContextProperty("ИндийскийКрасный", "IndianRed")]
        public ClColor IndianRed
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.IndianRed); }
        }

        [ContextProperty("Кирпичный", "Firebrick")]
        public ClColor Firebrick
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Firebrick); }
        }

        [ContextProperty("КожаноКоричневый", "SaddleBrown")]
        public ClColor SaddleBrown
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SaddleBrown); }
        }

        [ContextProperty("Коралловый", "Coral")]
        public ClColor Coral
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Coral); }
        }

        [ContextProperty("КоричневоМалиновый", "Maroon")]
        public ClColor Maroon
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Maroon); }
        }

        [ContextProperty("Коричневый", "Brown")]
        public ClColor Brown
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Brown); }
        }

        [ContextProperty("КоролевскийСиний", "RoyalBlue")]
        public ClColor RoyalBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.RoyalBlue); }
        }

        [ContextProperty("Красный", "Red")]
        public ClColor Red
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Red); }
        }

        [ContextProperty("Кровавый", "Crimson")]
        public ClColor Crimson
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Crimson); }
        }

        [ContextProperty("Лаванда", "Lavender")]
        public ClColor Lavender
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Lavender); }
        }

        [ContextProperty("Лазурный", "Azure")]
        public ClColor Azure
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Azure); }
        }

        [ContextProperty("Лайм", "Lime")]
        public ClColor Lime
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Lime); }
        }

        [ContextProperty("Лиловый", "PaleVioletRed")]
        public ClColor PaleVioletRed
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PaleVioletRed); }
        }

        [ContextProperty("ЛицеваяЭлемента", "Control")]
        public ClColor Control
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Control); }
        }

        [ContextProperty("Лососевый", "Salmon")]
        public ClColor Salmon
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Salmon); }
        }

        [ContextProperty("Льняной", "Linen")]
        public ClColor Linen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Linen); }
        }

        [ContextProperty("Малиновый", "Magenta")]
        public ClColor Magenta
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Magenta); }
        }

        [ContextProperty("Медовый", "Honeydew")]
        public ClColor Honeydew
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Honeydew); }
        }

        [ContextProperty("Меню", "Menu")]
        public ClColor Menu
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Menu); }
        }

        [ContextProperty("Мокасиновый", "Moccasin")]
        public ClColor Moccasin
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Moccasin); }
        }

        [ContextProperty("МорскаяВолна", "Aqua")]
        public ClColor Aqua
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Aqua); }
        }

        [ContextProperty("МорскаяРакушка", "SeaShell")]
        public ClColor SeaShell
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SeaShell); }
        }

        [ContextProperty("МятноКремовый", "MintCream")]
        public ClColor MintCream
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MintCream); }
        }

        [ContextProperty("НебесноГолубой", "SkyBlue")]
        public ClColor SkyBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SkyBlue); }
        }

        [ContextProperty("НебесноГолубойСветлый", "LightSkyBlue")]
        public ClColor LightSkyBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightSkyBlue); }
        }

        [ContextProperty("НежноОливковый", "OliveDrab")]
        public ClColor OliveDrab
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.OliveDrab); }
        }

        [ContextProperty("Окно", "Window")]
        public ClColor Window
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Window); }
        }

        [ContextProperty("Оливковый", "Olive")]
        public ClColor Olive
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Olive); }
        }

        [ContextProperty("ОранжевоКрасный", "OrangeRed")]
        public ClColor OrangeRed
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.OrangeRed); }
        }

        [ContextProperty("Оранжевый", "Orange")]
        public ClColor Orange
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Orange); }
        }

        [ContextProperty("Орхидея", "Orchid")]
        public ClColor Orchid
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Orchid); }
        }

        [ContextProperty("Охра", "Sienna")]
        public ClColor Sienna
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Sienna); }
        }

        [ContextProperty("Персиковый", "PeachPuff")]
        public ClColor PeachPuff
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PeachPuff); }
        }

        [ContextProperty("Песочный", "SandyBrown")]
        public ClColor SandyBrown
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SandyBrown); }
        }

        [ContextProperty("ПобегПапайи", "PapayaWhip")]
        public ClColor PapayaWhip
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PapayaWhip); }
        }

        [ContextProperty("Подсказка", "Info")]
        public ClColor Info
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Info); }
        }

        [ContextProperty("ПолосаПрокрутки", "ScrollBar")]
        public ClColor ScrollBar
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ScrollBar); }
        }

        [ContextProperty("ПолуночноСиний", "MidnightBlue")]
        public ClColor MidnightBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MidnightBlue); }
        }

        [ContextProperty("ПороховаяСинь", "PowderBlue")]
        public ClColor PowderBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.PowderBlue); }
        }

        [ContextProperty("ПризрачноБелый", "GhostWhite")]
        public ClColor GhostWhite
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.GhostWhite); }
        }

        [ContextProperty("Прозрачный", "Transparent")]
        public ClColor Transparent
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Transparent); }
        }

        [ContextProperty("Пурпурный", "Purple")]
        public ClColor Purple
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Purple); }
        }

        [ContextProperty("Пусто", "IsEmpty")]
        public bool IsEmpty
        {
            get { return Base_obj.IsEmpty; }
        }

        [ContextProperty("Пшеничный", "Wheat")]
        public ClColor Wheat
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Wheat); }
        }

        [ContextProperty("РабочаяОбластьПриложения", "AppWorkspace")]
        public ClColor AppWorkspace
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.AppWorkspace); }
        }

        [ContextProperty("РабочийСтол", "Desktop")]
        public ClColor Desktop
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Desktop); }
        }

        [ContextProperty("РамкаОкна", "WindowFrame")]
        public ClColor WindowFrame
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.WindowFrame); }
        }

        [ContextProperty("РозовоКоричневый", "RosyBrown")]
        public ClColor RosyBrown
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.RosyBrown); }
        }

        [ContextProperty("РозовоЛавандовый", "LavenderBlush")]
        public ClColor LavenderBlush
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LavenderBlush); }
        }

        [ContextProperty("Розовый", "Pink")]
        public ClColor Pink
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Pink); }
        }

        [ContextProperty("СветлаяМорскаяВолна", "LightSeaGreen")]
        public ClColor LightSeaGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightSeaGreen); }
        }

        [ContextProperty("СветлоЖелтый", "LightYellow")]
        public ClColor LightYellow
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightYellow); }
        }

        [ContextProperty("СветлоЖелтыйЗолотистый", "LightGoldenrodYellow")]
        public ClColor LightGoldenrodYellow
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightGoldenrodYellow); }
        }

        [ContextProperty("СветлоЗеленый", "LightGreen")]
        public ClColor LightGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightGreen); }
        }

        [ContextProperty("СветлоКоралловый", "LightCoral")]
        public ClColor LightCoral
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightCoral); }
        }

        [ContextProperty("СветлоКоричневый", "Peru")]
        public ClColor Peru
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Peru); }
        }

        [ContextProperty("СветлоКремовый", "BlanchedAlmond")]
        public ClColor BlanchedAlmond
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.BlanchedAlmond); }
        }

        [ContextProperty("СветлоЛимонный", "LemonChiffon")]
        public ClColor LemonChiffon
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LemonChiffon); }
        }

        [ContextProperty("СветлоРозовый", "LightPink")]
        public ClColor LightPink
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightPink); }
        }

        [ContextProperty("СветлоСерый", "LightGray")]
        public ClColor LightGray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightGray); }
        }

        [ContextProperty("СветлоСиний", "LightBlue")]
        public ClColor LightBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightBlue); }
        }

        [ContextProperty("СветлыйЗеленоватоГолубой", "LightCyan")]
        public ClColor LightCyan
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightCyan); }
        }

        [ContextProperty("СветлыйЛососевый", "LightSalmon")]
        public ClColor LightSalmon
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightSalmon); }
        }

        [ContextProperty("СветлыйЭлемента", "ControlLight")]
        public ClColor ControlLight
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ControlLight); }
        }

        [ContextProperty("Серебристый", "Silver")]
        public ClColor Silver
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Silver); }
        }

        [ContextProperty("СероСиний", "CadetBlue")]
        public ClColor CadetBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.CadetBlue); }
        }

        [ContextProperty("Серый", "Gray")]
        public ClColor Gray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Gray); }
        }

        [ContextProperty("СерыйТекст", "GrayText")]
        public ClColor GrayText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.GrayText); }
        }

        [ContextProperty("СерыйШифер", "SlateGray")]
        public ClColor SlateGray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SlateGray); }
        }

        [ContextProperty("СинеГолубойСоСтальнымОттенком", "LightSteelBlue")]
        public ClColor LightSteelBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.LightSteelBlue); }
        }

        [ContextProperty("СинеЗеленый", "Teal")]
        public ClColor Teal
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Teal); }
        }

        [ContextProperty("СинеФиолетовый", "BlueViolet")]
        public ClColor BlueViolet
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.BlueViolet); }
        }

        [ContextProperty("Синий", "Blue")]
        public ClColor Blue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Blue); }
        }

        [ContextProperty("СинийЭлис", "AliceBlue")]
        public ClColor AliceBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.AliceBlue); }
        }

        [ContextProperty("СиняяСталь", "SteelBlue")]
        public ClColor SteelBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.SteelBlue); }
        }

        [ContextProperty("Сливовый", "Plum")]
        public ClColor Plum
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Plum); }
        }

        [ContextProperty("СлоноваяКость", "Ivory")]
        public ClColor Ivory
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Ivory); }
        }

        [ContextProperty("СтароеКружево", "OldLace")]
        public ClColor OldLace
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.OldLace); }
        }

        [ContextProperty("ТекстВыбранных", "HighlightText")]
        public ClColor HighlightText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.HighlightText); }
        }

        [ContextProperty("ТекстЗаголовкаАктивного", "ActiveCaptionText")]
        public ClColor ActiveCaptionText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ActiveCaptionText); }
        }

        [ContextProperty("ТекстЗаголовкаНеактивного", "InactiveCaptionText")]
        public ClColor InactiveCaptionText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.InactiveCaptionText); }
        }

        [ContextProperty("ТекстМеню", "MenuText")]
        public ClColor MenuText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MenuText); }
        }

        [ContextProperty("ТекстОкна", "WindowText")]
        public ClColor WindowText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.WindowText); }
        }

        [ContextProperty("ТекстПодсказки", "InfoText")]
        public ClColor InfoText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.InfoText); }
        }

        [ContextProperty("ТекстЭлемента", "ControlText")]
        public ClColor ControlText
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ControlText); }
        }

        [ContextProperty("ТемнаяЛососина", "DarkSalmon")]
        public ClColor DarkSalmon
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkSalmon); }
        }

        [ContextProperty("ТемнаяМорскаяВолна", "DarkSeaGreen")]
        public ClColor DarkSeaGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkSeaGreen); }
        }

        [ContextProperty("ТемнаяОрхидея", "DarkOrchid")]
        public ClColor DarkOrchid
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkOrchid); }
        }

        [ContextProperty("ТемнаяТеньЭлемента", "ControlDarkDark")]
        public ClColor ControlDarkDark
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ControlDarkDark); }
        }

        [ContextProperty("ТемноАспидныйСерый", "DarkSlateGray")]
        public ClColor DarkSlateGray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkSlateGray); }
        }

        [ContextProperty("ТемноГолубой", "DarkCyan")]
        public ClColor DarkCyan
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkCyan); }
        }

        [ContextProperty("ТемноЗеленый", "DarkGreen")]
        public ClColor DarkGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkGreen); }
        }

        [ContextProperty("ТемноКрасный", "DarkRed")]
        public ClColor DarkRed
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkRed); }
        }

        [ContextProperty("ТемноМандариновый", "DarkTurquoise")]
        public ClColor DarkTurquoise
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkTurquoise); }
        }

        [ContextProperty("ТемноПурпурный", "DarkMagenta")]
        public ClColor DarkMagenta
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkMagenta); }
        }

        [ContextProperty("ТемноСерый", "DarkGray")]
        public ClColor DarkGray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkGray); }
        }

        [ContextProperty("ТемноСиний", "DarkBlue")]
        public ClColor DarkBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkBlue); }
        }

        [ContextProperty("ТемноФиолетовый", "DarkViolet")]
        public ClColor DarkViolet
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkViolet); }
        }

        [ContextProperty("ТемныйГрифельноСиний", "DarkSlateBlue")]
        public ClColor DarkSlateBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkSlateBlue); }
        }

        [ContextProperty("ТемныйЗолотой", "DarkGoldenrod")]
        public ClColor DarkGoldenrod
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkGoldenrod); }
        }

        [ContextProperty("ТемныйОливковоЗеленый", "DarkOliveGreen")]
        public ClColor DarkOliveGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkOliveGreen); }
        }

        [ContextProperty("ТемныйОранжевый", "DarkOrange")]
        public ClColor DarkOrange
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkOrange); }
        }

        [ContextProperty("ТемныйХаки", "DarkKhaki")]
        public ClColor DarkKhaki
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DarkKhaki); }
        }

        [ContextProperty("ТеньЭлемента", "ControlDark")]
        public ClColor ControlDark
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.ControlDark); }
        }

        [ContextProperty("Томатный", "Tomato")]
        public ClColor Tomato
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Tomato); }
        }

        [ContextProperty("ТуманноБелый", "Gainsboro")]
        public ClColor Gainsboro
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Gainsboro); }
        }

        [ContextProperty("ТусклоРозовый", "MistyRose")]
        public ClColor MistyRose
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MistyRose); }
        }

        [ContextProperty("ТусклоСерый", "DimGray")]
        public ClColor DimGray
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.DimGray); }
        }

        [ContextProperty("УмеренныйАквамарин", "MediumAquamarine")]
        public ClColor MediumAquamarine
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumAquamarine); }
        }

        [ContextProperty("УмеренныйБирюзовый", "MediumTurquoise")]
        public ClColor MediumTurquoise
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumTurquoise); }
        }

        [ContextProperty("УмеренныйВесеннеЗеленый", "MediumSpringGreen")]
        public ClColor MediumSpringGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumSpringGreen); }
        }

        [ContextProperty("УмеренныйГрифельноСиний", "MediumSlateBlue")]
        public ClColor MediumSlateBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumSlateBlue); }
        }

        [ContextProperty("УмеренныйМорскаяВолна", "MediumSeaGreen")]
        public ClColor MediumSeaGreen
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumSeaGreen); }
        }

        [ContextProperty("УмеренныйОрхидея", "MediumOrchid")]
        public ClColor MediumOrchid
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumOrchid); }
        }

        [ContextProperty("УмеренныйСиний", "MediumBlue")]
        public ClColor MediumBlue
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumBlue); }
        }

        [ContextProperty("УмеренныйФиолетовоКрасный", "MediumVioletRed")]
        public ClColor MediumVioletRed
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumVioletRed); }
        }

        [ContextProperty("УмеренныйФиолетовый", "MediumPurple")]
        public ClColor MediumPurple
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.MediumPurple); }
        }

        [ContextProperty("Фиолетовый", "Violet")]
        public ClColor Violet
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Violet); }
        }

        [ContextProperty("ФонВыбранных", "Highlight")]
        public ClColor Highlight
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Highlight); }
        }

        [ContextProperty("Фуксия", "Fuchsia")]
        public ClColor Fuchsia
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Fuchsia); }
        }

        [ContextProperty("Хаки", "Khaki")]
        public ClColor Khaki
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Khaki); }
        }

        [ContextProperty("ЦветЗагара", "Tan")]
        public ClColor Tan
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Tan); }
        }

        [ContextProperty("ЦветПлотнойДревесины", "BurlyWood")]
        public ClColor BurlyWood
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.BurlyWood); }
        }

        [ContextProperty("ЦветФормыМорскихОфицеров", "Navy")]
        public ClColor Navy
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Navy); }
        }

        [ContextProperty("ЦветочноБелый", "FloralWhite")]
        public ClColor FloralWhite
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.FloralWhite); }
        }

        [ContextProperty("Циан", "Cyan")]
        public ClColor Cyan
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Cyan); }
        }

        [ContextProperty("Черный", "Black")]
        public ClColor Black
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Black); }
        }

        [ContextProperty("Чертополох", "Thistle")]
        public ClColor Thistle
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Thistle); }
        }

        [ContextProperty("Шартрез", "Chartreuse")]
        public ClColor Chartreuse
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Chartreuse); }
        }

        [ContextProperty("Шоколадный", "Chocolate")]
        public ClColor Chocolate
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Chocolate); }
        }

        [ContextProperty("ЯркийБелый", "Snow")]
        public ClColor Snow
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.Snow); }
        }

        [ContextProperty("ЯркоРозовый", "HotPink")]
        public ClColor HotPink
        {
            get { return (ClColor)OneScriptForms.RevertObj(Base_obj.HotPink); }
        }

        //Методы============================================================

        [ContextMethod("ИзArgb", "FromArgb")]
        public ClColor FromArgb(int p1, int p2, int p3, int p4)
        {
            return new ClColor(Base_obj.FromArgb(p1, p2, p3, p4));
        }
        
        [ContextMethod("ИзRgb", "FromRgb")]
        public ClColor FromRgb(int p1, int p2, int p3)
        {
            return new ClColor(Base_obj.FromRgb(p1, p2, p3));
        }
        
        [ContextMethod("ИзИмени", "FromName")]
        public ClColor FromName(string p1)
        {
            int NumberProp1 = this.FindProperty(p1);
            dynamic obj1 = this.GetPropValue(NumberProp1);
            return (ClColor)ValueFactory.Create(obj1);
        }
        
        [ContextMethod("ПолучитьArgb", "ToArgb")]
        public int ToArgb()
        {
            return (Base_obj.R * 65536) + (Base_obj.G * 256) + Base_obj.B;
        }
    }
}
