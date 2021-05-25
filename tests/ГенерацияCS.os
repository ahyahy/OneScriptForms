Перем СтрДирективы, СтрШапка, СтрРазделОбъявленияПеременных, СтрКонструктор, СтрBase_obj, СтрСвойства, СтрМетоды, СтрПодвал, СтрВыгрузкиПеречислений;
Перем СтрРазделОбъявленияПеременныхДляПеречисления, СтрСвойстваДляПеречисления, СтрМетодовСистема, СписокСтрМетодовСистема;
Перем СписокЗамен, ИменаКалассовПеречислений;

Функция ОтобратьФайлы(Фильтр)
	// Фильтр = Класс Конструктор Члены Свойства Свойство Методы Метод Перечисление
	М_Фильтр = Новый Массив;
	ВыбранныеФайлы = НайтиФайлы("C:\444", "*.html", Истина);
	Найдено1 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "<H1 class=dtH1", "/H1>", , );
		Если М.Количество() > 0 Тогда
			СтрЗаголовка= М[0];
			Если (СтрНайти(СтрЗаголовка, Фильтр + "<") > 0) или (СтрНайти(СтрЗаголовка, Фильтр + " <") > 0) Тогда
				Найдено1 = Найдено1 + 1;
				// // Сообщить("================================================================================================");
				// // Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя + "=" + СтрЗаголовка);
				// Сообщить("" + СтрЗаголовка);
				М_Фильтр.Добавить(ВыбранныеФайлы[А].ПолноеИмя);
			КонецЕсли;
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 (" + Фильтр + ") = " + Найдено1);
	Возврат М_Фильтр;
КонецФункции

Функция РазобратьСтроку(Строка, Разделитель)
	Стр = СтрЗаменить(Строка, Разделитель, Символы.ПС);
	М = Новый Массив;
	Если ПустаяСтрока(Стр) Тогда
		Возврат М;
	КонецЕсли;
	Для Ч = 1 По СтрЧислоСтрок(Стр) Цикл
		М.Добавить(СтрПолучитьСтроку(Стр, Ч));
	КонецЦикла;
	Возврат М;
КонецФункции

Процедура СортироватьСтрРазделОбъявленияПеременных()//в строке СтрРазделОбъявленияПеременных должно быть не меньше трёх слов разделенных двумя пробелами
	СписокСортировки = Новый СписокЗначений;
	Для Счетчик = 1 По СтрЧислоСтрок(СтрРазделОбъявленияПеременных) Цикл
		ТекСтрока = СтрПолучитьСтроку(СтрРазделОбъявленияПеременных, Счетчик);
		ТекСтрокаДляРазбора = ТекСтрока;
		ТекСтрокаДляРазбора = СтрЗаменить(ТекСтрокаДляРазбора, "static ", "");
		М = РазобратьСтроку(СокрЛП(ТекСтрокаДляРазбора), " ");
		Если М.Количество() > 2 Тогда
			СписокСортировки.Добавить(М[2], ТекСтрока);
		КонецЕсли;
	КонецЦикла;
	СтрРазделОбъявленияПеременных = "";
	СписокСортировки.СортироватьПоЗначению();
	Для А = 0 По СписокСортировки.Количество() - 1 Цикл
		СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + СписокСортировки.Получить(А).Представление + Символы.ПС;
	КонецЦикла;
КонецПроцедуры

Процедура СортироватьСтрРазделОбъявленияПеременныхДляПеречисления()
	СписокСортировки = Новый СписокЗначений;
	Для Счетчик = 1 По СтрЧислоСтрок(СтрРазделОбъявленияПеременныхДляПеречисления) Цикл
		ТекСтрока = СтрПолучитьСтроку(СтрРазделОбъявленияПеременныхДляПеречисления, Счетчик);
		Если Не (СокрЛП(ТекСтрока) = "") Тогда
			М = РазобратьСтроку(СокрЛП(ТекСтрока), " ");
			ЗначениеСортировки = М[6];
			ЗначениеСортировки = СтрЗаменить(ЗначениеСортировки, ";", "");
			ЗначениеСортировки = Число(ЗначениеСортировки);
			СписокСортировки.Добавить(ЗначениеСортировки, ТекСтрока);
		КонецЕсли;
	КонецЦикла;
	СтрРазделОбъявленияПеременныхДляПеречисления = "" + Символы.ПС;
	СписокСортировки.СортироватьПоЗначению();
	Для А = 0 По СписокСортировки.Количество() - 1 Цикл
		Если А = (СписокСортировки.Количество() - 1) Тогда
			СтрРазделОбъявленияПеременныхДляПеречисления = СтрРазделОбъявленияПеременныхДляПеречисления + СписокСортировки.Получить(А).Представление;
		Иначе
			СтрРазделОбъявленияПеременныхДляПеречисления = СтрРазделОбъявленияПеременныхДляПеречисления + СписокСортировки.Получить(А).Представление + Символы.ПС;
		КонецЕсли;
	КонецЦикла;
КонецПроцедуры//СортироватьСтрРазделОбъявленияПеременныхДляПеречисления

Функция Директивы(ИмяКонтекстКлассаАнгл)
	Если ИмяКонтекстКлассаАнгл = "OneScriptForms" Тогда
		Стр = 
		"using System;
		|using System.Collections;
		|using System.Collections.Generic;
		|using System.Linq;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Reflection;
		|using System.Runtime.InteropServices;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "AnchorStyles" или 
		ИмяКонтекстКлассаАнгл = "DockStyle" или 
		ИмяКонтекстКлассаАнгл = "DockPaddingEdges" или 
		ИмяКонтекстКлассаАнгл = "DialogResult" или 
		ИмяКонтекстКлассаАнгл = "Day" или 
		ИмяКонтекстКлассаАнгл = "DataType" или 
		ИмяКонтекстКлассаАнгл = "DataRowState" или 
		ИмяКонтекстКлассаАнгл = "DataGridTextBoxColumn" или 
		ИмяКонтекстКлассаАнгл = "DataGridCell" или 
		ИмяКонтекстКлассаАнгл = "DataGridBoolColumn" или 
		ИмяКонтекстКлассаАнгл = "Cursors" или 
		ИмяКонтекстКлассаАнгл = "Cursor" или 
		ИмяКонтекстКлассаАнгл = "ContextMenuPopupEventArgs" или 
		ИмяКонтекстКлассаАнгл = "ContentAlignment" или 
		ИмяКонтекстКлассаАнгл = "ComboBoxStyle" или 
		ИмяКонтекстКлассаАнгл = "ColumnHeaderStyle" или 
		ИмяКонтекстКлассаАнгл = "ColumnHeader" или 
		ИмяКонтекстКлассаАнгл = "ColumnClickEventArgs" или 
		ИмяКонтекстКлассаАнгл = "ColorDepth" или 
		ИмяКонтекстКлассаАнгл = "CloseReason" или 
		ИмяКонтекстКлассаАнгл = "BitmapData" или 
		ИмяКонтекстКлассаАнгл = "CheckState" или 
		ИмяКонтекстКлассаАнгл = "CharacterCasing" или 
		ИмяКонтекстКлассаАнгл = "CancelEventArgs" или 
		ИмяКонтекстКлассаАнгл = "BorderStyle" или 
		ИмяКонтекстКлассаАнгл = "DrawMode" или 
		ИмяКонтекстКлассаАнгл = "Encoding" или 
		ИмяКонтекстКлассаАнгл = "FileSystemEventArgs" или 
		ИмяКонтекстКлассаАнгл = "FontStyle" или 
		ИмяКонтекстКлассаАнгл = "FormatDateTimePicker" или 
		ИмяКонтекстКлассаАнгл = "FormBorderStyle" или 
		ИмяКонтекстКлассаАнгл = "FormClosingEventArgs" или 
		ИмяКонтекстКлассаАнгл = "FormStartPosition" или 
		ИмяКонтекстКлассаАнгл = "FormWindowState" или 
		ИмяКонтекстКлассаАнгл = "GridItemType" или 
		ИмяКонтекстКлассаАнгл = "HatchBrush" или 
		ИмяКонтекстКлассаАнгл = "HatchStyle" или 
		ИмяКонтекстКлассаАнгл = "HorizontalAlignment" или 
		ИмяКонтекстКлассаАнгл = "ImageCollection" или 
		ИмяКонтекстКлассаАнгл = "ImageFormat" или 
		ИмяКонтекстКлассаАнгл = "ImageLayout" или 
		ИмяКонтекстКлассаАнгл = "ImageList" или 
		ИмяКонтекстКлассаАнгл = "ItemActivation" или 
		ИмяКонтекстКлассаАнгл = "ItemCheckEventArgs" или 
		ИмяКонтекстКлассаАнгл = "KeyEventArgs" или 
		ИмяКонтекстКлассаАнгл = "Keys" или 
		ИмяКонтекстКлассаАнгл = "LabelEditEventArgs" или 
		ИмяКонтекстКлассаАнгл = "LeftRightAlignment" или 
		ИмяКонтекстКлассаАнгл = "LinkArea" или 
		ИмяКонтекстКлассаАнгл = "LinkClickedEventArgs" или 
		ИмяКонтекстКлассаАнгл = "LinkLabelLinkBehavior" или 
		ИмяКонтекстКлассаАнгл = "LinkLabelLinkClickedEventArgs" или 
		ИмяКонтекстКлассаАнгл = "ListViewAlignment" или 
		ИмяКонтекстКлассаАнгл = "ListViewCheckedItemCollection" или 
		ИмяКонтекстКлассаАнгл = "ListViewItem" или 
		ИмяКонтекстКлассаАнгл = "ListViewSelectedItemCollection" или 
		ИмяКонтекстКлассаАнгл = "ListViewSubItem" или 
		ИмяКонтекстКлассаАнгл = "MenuItemCollection" или 
		ИмяКонтекстКлассаАнгл = "MenuMerge" или 
		ИмяКонтекстКлассаАнгл = "MenuNotifyIcon" или 
		ИмяКонтекстКлассаАнгл = "MessageBox" или 
		ИмяКонтекстКлассаАнгл = "MessageBoxButtons" или 
		ИмяКонтекстКлассаАнгл = "MessageBoxIcon" или 
		ИмяКонтекстКлассаАнгл = "MouseButtons" или 
		ИмяКонтекстКлассаАнгл = "MouseEventArgs" или 
		ИмяКонтекстКлассаАнгл = "MouseFlags" или 
		ИмяКонтекстКлассаАнгл = "NodeLabelEditEventArgs" или 
		ИмяКонтекстКлассаАнгл = "NotifyFilters" или 
		ИмяКонтекстКлассаАнгл = "NotifyIcon" или 
		ИмяКонтекстКлассаАнгл = "PaintEventArgs" или 
		ИмяКонтекстКлассаАнгл = "Pen" или 
		ИмяКонтекстКлассаАнгл = "PictureBoxSizeMode" или 
		ИмяКонтекстКлассаАнгл = "PixelFormat" или 
		ИмяКонтекстКлассаАнгл = "Point" или 
		ИмяКонтекстКлассаАнгл = "Process" или 
		ИмяКонтекстКлассаАнгл = "ProcessWindowStyle" или 
		ИмяКонтекстКлассаАнгл = "PropertySort" или 
		ИмяКонтекстКлассаАнгл = "Rectangle" или 
		ИмяКонтекстКлассаАнгл = "RenamedEventArgs" или 
		ИмяКонтекстКлассаАнгл = "RichTextBoxFinds" или 
		ИмяКонтекстКлассаАнгл = "RichTextBoxStreamType" или 
		ИмяКонтекстКлассаАнгл = "Screen" или 
		ИмяКонтекстКлассаАнгл = "ScrollBars" или 
		ИмяКонтекстКлассаАнгл = "ScrollEventArgs" или 
		ИмяКонтекстКлассаАнгл = "ScrollEventType" или 
		ИмяКонтекстКлассаАнгл = "ScrollOrientation" или 
		ИмяКонтекстКлассаАнгл = "SeekOrigin" или 
		ИмяКонтекстКлассаАнгл = "SelectionMode" или 
		ИмяКонтекстКлассаАнгл = "Shortcut" или 
		ИмяКонтекстКлассаАнгл = "Size" или 
		ИмяКонтекстКлассаАнгл = "SolidBrush" или 
		ИмяКонтекстКлассаАнгл = "SortOrder" или 
		ИмяКонтекстКлассаАнгл = "SortType" или 
		ИмяКонтекстКлассаАнгл = "Sounds" или 
		ИмяКонтекстКлассаАнгл = "SpecialFolder" или 
		ИмяКонтекстКлассаАнгл = "StatusBarPanel" или 
		ИмяКонтекстКлассаАнгл = "StatusBarPanelAutoSize" или 
		ИмяКонтекстКлассаАнгл = "StatusBarPanelBorderStyle" или 
		ИмяКонтекстКлассаАнгл = "StatusBarPanelCollection" или 
		ИмяКонтекстКлассаАнгл = "StreamReader" или 
		ИмяКонтекстКлассаАнгл = "TabAlignment" или 
		ИмяКонтекстКлассаАнгл = "TabAppearance" или 
		ИмяКонтекстКлассаАнгл = "TabSizeMode" или 
		ИмяКонтекстКлассаАнгл = "TextureBrush" или 
		ИмяКонтекстКлассаАнгл = "Timer" или 
		ИмяКонтекстКлассаАнгл = "ToolBarAppearance" или 
		ИмяКонтекстКлассаАнгл = "ToolBarButton" или 
		ИмяКонтекстКлассаАнгл = "ToolBarButtonClickEventArgs" или 
		ИмяКонтекстКлассаАнгл = "ToolBarButtonCollection" или 
		ИмяКонтекстКлассаАнгл = "ToolBarButtonStyle" или 
		ИмяКонтекстКлассаАнгл = "ToolBarTextAlign" или 
		ИмяКонтекстКлассаАнгл = "TreeViewAction" или 
		ИмяКонтекстКлассаАнгл = "TreeViewCancelEventArgs" или 
		ИмяКонтекстКлассаАнгл = "TreeViewEventArgs" или 
		ИмяКонтекстКлассаАнгл = "Version" или 
		ИмяКонтекстКлассаАнгл = "WatcherChangeTypes" или 
		ИмяКонтекстКлассаАнгл = "Appearance" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "AnnuallyBoldedDates" или
		ИмяКонтекстКлассаАнгл = "DataTable" или
		ИмяКонтекстКлассаАнгл = "DataSet" или
		ИмяКонтекстКлассаАнгл = "DataRowView" или
		ИмяКонтекстКлассаАнгл = "DataRow" или
		ИмяКонтекстКлассаАнгл = "DataItem" или
		ИмяКонтекстКлассаАнгл = "DataColumn" или
		ИмяКонтекстКлассаАнгл = "ContextMenu" или
		ИмяКонтекстКлассаАнгл = "Collection" или
		ИмяКонтекстКлассаАнгл = "BoldedDates" или
		ИмяКонтекстКлассаАнгл = "Font" или
		ИмяКонтекстКлассаАнгл = "Graphics" или
		ИмяКонтекстКлассаАнгл = "GridColumnStylesCollection" или
		ИмяКонтекстКлассаАнгл = "GridItemCollection" или
		ИмяКонтекстКлассаАнгл = "LinkCollection" или
		ИмяКонтекстКлассаАнгл = "ListItem" или
		ИмяКонтекстКлассаАнгл = "ListViewColumnHeaderCollection" или
		ИмяКонтекстКлассаАнгл = "ListViewItemCollection" или
		ИмяКонтекстКлассаАнгл = "ListViewSubItemCollection" или
		ИмяКонтекстКлассаАнгл = "MainMenu" или
		ИмяКонтекстКлассаАнгл = "Menu" или
		ИмяКонтекстКлассаАнгл = "MonthlyBoldedDates" или
		ИмяКонтекстКлассаАнгл = "SelectionRange" или
		ИмяКонтекстКлассаАнгл = "TreeNodeCollection" или
		ИмяКонтекстКлассаАнгл = "Bitmap" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Application" или 
		ИмяКонтекстКлассаАнгл = "EventArgs" или 
		ИмяКонтекстКлассаАнгл = "Environment" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using System.Reflection;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ArrayList" или 
		ИмяКонтекстКлассаАнгл = "HashTable" Тогда
		Стр = 
		"using System.Collections;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Brush" или 
		ИмяКонтекстКлассаАнгл = "FileDialog" или 
		ИмяКонтекстКлассаАнгл = "DataGridColumnStyle" или 
		ИмяКонтекстКлассаАнгл = "ContainerControl" или 
		ИмяКонтекстКлассаАнгл = "Component" или 
		ИмяКонтекстКлассаАнгл = "CommonDialog" или 
		ИмяКонтекстКлассаАнгл = "Image" или 
		ИмяКонтекстКлассаАнгл = "ListControl" или 
		ИмяКонтекстКлассаАнгл = "ScrollableControl" или 
		ИмяКонтекстКлассаАнгл = "TextBoxBase" или 
		ИмяКонтекстКлассаАнгл = "UpDownBase" или 
		ИмяКонтекстКлассаАнгл = "ButtonBase" Тогда
		Стр = 
		"
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Button" или 
		ИмяКонтекстКлассаАнгл = "DateTimePicker" или 
		ИмяКонтекстКлассаАнгл = "DataGrid" или 
		ИмяКонтекстКлассаАнгл = "ComboBoxObjectCollection" или 
		ИмяКонтекстКлассаАнгл = "Color" или 
		ИмяКонтекстКлассаАнгл = "GroupBox" или 
		ИмяКонтекстКлассаАнгл = "HScrollBar" или 
		ИмяКонтекстКлассаАнгл = "Label" или 
		ИмяКонтекстКлассаАнгл = "LinkLabel" или 
		ИмяКонтекстКлассаАнгл = "MonthCalendar" или 
		ИмяКонтекстКлассаАнгл = "NumericUpDown" или 
		ИмяКонтекстКлассаАнгл = "Panel" или 
		ИмяКонтекстКлассаАнгл = "PictureBox" или 
		ИмяКонтекстКлассаАнгл = "ProgressBar" или 
		ИмяКонтекстКлассаАнгл = "PropertyGrid" или 
		ИмяКонтекстКлассаАнгл = "RadioButton" или 
		ИмяКонтекстКлассаАнгл = "Splitter" или 
		ИмяКонтекстКлассаАнгл = "StatusBar" или 
		ИмяКонтекстКлассаАнгл = "TabControl" или 
		ИмяКонтекстКлассаАнгл = "TabPage" или 
		ИмяКонтекстКлассаАнгл = "TextBox" или 
		ИмяКонтекстКлассаАнгл = "ToolBar" или 
		ИмяКонтекстКлассаАнгл = "TreeView" или 
		ИмяКонтекстКлассаАнгл = "UserControl" или 
		ИмяКонтекстКлассаАнгл = "VScrollBar" или 
		ИмяКонтекстКлассаАнгл = "CheckBox" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Reflection;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Clipboard" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using System.Windows.Forms;
		|using System.Threading;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "CollectionBase" или 
		ИмяКонтекстКлассаАнгл = "ScrollBar" Тогда
		Стр = 
		"using System;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ColorDialog" или 
		ИмяКонтекстКлассаАнгл = "FontDialog" или 
		ИмяКонтекстКлассаАнгл = "OpenFileDialog" или 
		ИмяКонтекстКлассаАнгл = "SaveFileDialog" или 
		ИмяКонтекстКлассаАнгл = "FolderBrowserDialog" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Threading;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ComboBox" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Windows.Forms;
		|using System.Reflection;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Control" Тогда
		Стр = 
		"using System;
		|using System.Linq;
		|using System.Reflection;
		|using System.Runtime.InteropServices;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ControlEventArgs" или 
		ИмяКонтекстКлассаАнгл = "DictionaryEntry" или 
		ИмяКонтекстКлассаАнгл = "DataGridTableStyle" или 
		ИмяКонтекстКлассаАнгл = "GridItem" или 
		ИмяКонтекстКлассаАнгл = "Link" или 
		ИмяКонтекстКлассаАнгл = "ListBoxSelectedObjectCollection" или 
		ИмяКонтекстКлассаАнгл = "ManagedProperty" или 
		ИмяКонтекстКлассаАнгл = "Math" или 
		ИмяКонтекстКлассаАнгл = "MenuItem" или 
		ИмяКонтекстКлассаАнгл = "PropertyValueChangedEventArgs" или 
		ИмяКонтекстКлассаАнгл = "SelectedGridItemChangedEventArgs" или
		ИмяКонтекстКлассаАнгл = "ToolTip" или
		ИмяКонтекстКлассаАнгл = "TreeNode" или
		ИмяКонтекстКлассаАнгл = "ControlCollection" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "DataColumnCollection" или 
		ИмяКонтекстКлассаАнгл = "TabPageCollection" или 
		ИмяКонтекстКлассаАнгл = "DataTableCollection" Тогда
		Стр = 
		"using System;
		|using System.Collections;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "DataGridComboBoxColumnStyle" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using System.Windows.Forms;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "DataGridTextBox" или 
		ИмяКонтекстКлассаАнгл = "GridTableStylesCollection" или 
		ИмяКонтекстКлассаАнгл = "Icon" или 
		ИмяКонтекстКлассаАнгл = "KeyPressEventArgs" или 
		ИмяКонтекстКлассаАнгл = "ListBoxSelectedIndexCollection" или 
		ИмяКонтекстКлассаАнгл = "Stream" или 
		ИмяКонтекстКлассаАнгл = "FileSystemWatcher" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "DataRowCollection" Тогда
		Стр = 
		"using System;
		|using System.Collections;
		|using ScriptEngine.Machine.Contexts;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "DataView" Тогда
		Стр = 
		"using System.Collections;
		|using ScriptEngine.Machine.Contexts;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ExtractIconClass" Тогда
		Стр = 
		"using System;
		|using System.Runtime.InteropServices;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "FlatStyle" или 
		ИмяКонтекстКлассаАнгл = "View" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using System.Windows.Forms;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Form" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Windows.Forms;
		|using System.Reflection;
		|using System.Runtime.InteropServices;
		|using System.Threading;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "InputBox" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using System.Threading;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ListBox" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Windows.Forms;
		|using System.Drawing;
		|using System.Reflection;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ListBoxObjectCollection" или 
		ИмяКонтекстКлассаАнгл = "Type" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Reflection;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ListView" Тогда
		Стр = 
		"using System;
		|using System.Collections;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Reflection;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "ProcessStartInfo" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using Microsoft.VisualBasic;
		|using System.Security;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "RichTextBox" Тогда
		Стр = 
		"using System;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Reflection;
		|using System.Runtime.InteropServices;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "SortedList" Тогда
		Стр = 
		"using System.Collections;
		|using ScriptEngine.Machine.Contexts;
		|using ScriptEngine.Machine;
		|using System.Runtime.CompilerServices;
		|
		|";
		Возврат Стр;
	ИначеЕсли ИмяКонтекстКлассаАнгл = "Sound" Тогда
		Стр = 
		"using ScriptEngine.Machine.Contexts;
		|using System.Runtime.InteropServices;
		|
		|";
		Возврат Стр;
	КонецЕсли;
КонецФункции//Директивы

Функция Шапка(ИмяКонтекстКлассаАнгл, ИмяКонтекстКлассаРус)
	Стр = "";
	Если ИмяКонтекстКлассаАнгл = "OneScriptForms" Тогда
		Стр = Стр + 
		"
		|    [ContextClass(""" + ИмяКонтекстКлассаРус + """, """ + ИмяКонтекстКлассаАнгл + """)]
		|    public class " + ИмяКонтекстКлассаАнгл + " : AutoContext<" + ИмяКонтекстКлассаАнгл + ">
		|    {";
	Иначе
		Стр = Стр + 
		"
		|    [ContextClass(""Кл" + ИмяКонтекстКлассаРус + """, ""Cl" + ИмяКонтекстКлассаАнгл + """)]
		|    public class Cl" + ИмяКонтекстКлассаАнгл + " : AutoContext<Cl" + ИмяКонтекстКлассаАнгл + ">
		|    {";
	КонецЕсли;
	Возврат Стр;
КонецФункции

Функция РазделОбъявленияПеременных(ИмяФайлаЧленов, ИмяКласса)
	Если ИмяКласса = "OneScriptForms" Тогда
		Стр = 
		"        [DllImport(""user32"", CharSet = CharSet.Ansi, SetLastError = true)] public static extern int WaitMessage();
		|        [DllImport(""User32.dll"")] static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);
		|        public static ClForm FirstForm = null;
		|        public static IValue Event = null;
		|        public static string EventString = """";
		|        public static System.Collections.ArrayList EventQueue = new System.Collections.ArrayList();
		|        public static System.Collections.Hashtable hashtable = new Hashtable();
		|        public static System.Random Random = new Random();
		|        public static bool goOn = true;";
	ИначеЕсли ИмяКласса = "ManagedProperty" Тогда
		Стр = 
		"        private IValue managedObject;
		|        private string managedProperty;
		|        private IValue ratio;";
	ИначеЕсли ИмяКласса = "ListBoxObjectCollection" или
			  ИмяКласса = "ListBoxSelectedObjectCollection" Тогда
		Стр = 
		"        public ClListBox M_obj;";
	ИначеЕсли ИмяКласса = "BoldedDates" или 
			ИмяКласса = "AnnuallyBoldedDates" или
			ИмяКласса = "MonthlyBoldedDates" Тогда
		Стр = 
		"        public System.DateTime[] M_Object;";
	ИначеЕсли ИмяКласса = "MonthCalendar" Тогда
		Стр = 
		"        private ClAnnuallyBoldedDates annuallyBoldedDates;
		|        private ClBoldedDates boldedDates;
		|        private ClMonthlyBoldedDates monthlyBoldedDates;";
	ИначеЕсли ИмяКласса = "MenuNotifyIcon" Тогда
		Стр = 
		"        private bool firstShow;
		|        private ClNotifyIcon notifyIcon;";
	ИначеЕсли ИмяКласса = "NotifyIcon" Тогда
		Стр = 
		"        private ClMenuNotifyIcon menu;
		|        private ClUserControl userControl1 = new ClUserControl();";
	ИначеЕсли ИмяКласса = "ComboBox" Тогда
		Стр = 
		"        private ClComboBoxObjectCollection items;
		|        private ClArrayList heights = new ClArrayList();";
	ИначеЕсли ИмяКласса = "ComboBoxObjectCollection" Тогда
		Стр = 
		"        public ArrayList heightItems;
		|        public ClComboBox m_obj;";
		
		
		
	Иначе
		Стр = "";
	КонецЕсли;
	Возврат Стр;
КонецФункции//РазделОбъявленияПеременных

Функция Конструктор(ИмяФайлаЧленов, ИмяКласса)
	Если ИмяКласса = "OneScriptForms" Тогда
		Стр = 
		"        [ScriptConstructor]
		|        public static IRuntimeContextInstance Constructor()
		|        {
		|            return new OneScriptForms();
		|        }
		|";
	ИначеЕсли ИмяКласса = "DataRowView" Тогда
		Стр = 
		"        public ClDataRowView()
		|        {
		|            DataRowView DataRowView1 = new DataRowView();
		|            DataRowView1.dll_obj = this;
		|            Base_obj = DataRowView1;
		|        }//end_constr
		|		
		|        public ClDataRowView(DataRowView p1)
		|        {
		|            DataRowView DataRowView1 = p1;
		|            DataRowView1.dll_obj = this;
		|            Base_obj = DataRowView1;
		|        }//end_constr
		|
		|        public ClDataRowView(System.Data.DataRowView p1)
		|        {
		|            DataRowView DataRowView1 = new DataRowView(p1);
		|            DataRowView1.dll_obj = this;
		|            Base_obj = DataRowView1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "DataView" Тогда
		Стр = 
		"        public ClDataView()
		|        {
		|            DataView DataView1 = new DataView();
		|            DataView1.dll_obj = this;
		|            Base_obj = DataView1;
		|        }//end_constr
		|		
		|        public ClDataView(DataView p1)
		|        {
		|            DataView DataView1 = p1;
		|            DataView1.dll_obj = this;
		|            Base_obj = DataView1;
		|        }//end_constr
		|        
		|        public ClDataView(System.Data.DataView p1)
		|        {
		|            DataView DataView1 = new DataView(p1);
		|            DataView1.dll_obj = this;
		|            Base_obj = DataView1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "DataGridComboBoxColumnStyle" Тогда
		Стр = 
		"        public ClDataGridComboBoxColumnStyle()
		|        {
		|            DataGridComboBoxColumn DataGridComboBoxColumnStyle1 = new DataGridComboBoxColumn();
		|            DataGridComboBoxColumnStyle1.dll_obj = this;
		|            Base_obj = DataGridComboBoxColumnStyle1;
		|        }//end_constr
		|
		|        public ClDataGridComboBoxColumnStyle(DataGridComboBoxColumn p1)
		|        {
		|            DataGridComboBoxColumn DataGridComboBoxColumnStyle1 = p1;
		|            DataGridComboBoxColumnStyle1.dll_obj = this;
		|            Base_obj = DataGridComboBoxColumnStyle1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "DictionaryEntry" Тогда
		Стр = 
		"        public ClDictionaryEntry(IValue p1, IValue p2)
		|        {
		|            DictionaryEntry DictionaryEntry1 = new DictionaryEntry(p1, p2);
		|            DictionaryEntry1.dll_obj = this;
		|            Base_obj = DictionaryEntry1;
		|        }//end_constr
		|		
		|        public ClDictionaryEntry(DictionaryEntry p1)
		|        {
		|            DictionaryEntry DictionaryEntry1 = p1;
		|            DictionaryEntry1.dll_obj = this;
		|            Base_obj = DictionaryEntry1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "HatchBrush" Тогда
		Стр = 
		"        public ClHatchBrush(int p1, osf.Color p2, osf.Color p3 = null)
		|        {
		|            HatchBrush HatchBrush1 = new HatchBrush(p1, p2, p3);
		|            HatchBrush1.dll_obj = this;
		|            Base_obj = HatchBrush1;
		|        }//end_constr
		|		
		|        public ClHatchBrush(HatchBrush p1)
		|        {
		|            HatchBrush HatchBrush1 = p1;
		|            HatchBrush1.dll_obj = this;
		|            Base_obj = HatchBrush1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ImageList" Тогда
		Стр = 
		"        public ClImageList()
		|        {
		|            ImageList ImageList1 = new ImageList();
		|            ImageList1.dll_obj = this;
		|            Base_obj = ImageList1;
		|        }//end_constr
		|		
		|        public ClImageList(ImageList p1)
		|        {
		|            ImageList ImageList1 = p1;
		|            ImageList1.dll_obj = this;
		|            Base_obj = ImageList1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "DataGridCell" Тогда
		Стр = 
		"        public ClDataGridCell(int p1, int p2)
		|        {
		|            DataGridCell DataGridCell1 = new DataGridCell(p1, p2);
		|            DataGridCell1.dll_obj = this;
		|            Base_obj = DataGridCell1;
		|        }//end_constr
		|		
		|        public ClDataGridCell(DataGridCell p1)
		|        {
		|            DataGridCell DataGridCell1 = p1;
		|            DataGridCell1.dll_obj = this;
		|            Base_obj = DataGridCell1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "DataColumn" Тогда
		Стр = 
		"        public ClDataColumn()
		|        {
		|            DataColumn DataColumn1 = new DataColumn();
		|            DataColumn1.dll_obj = this;
		|            Base_obj = DataColumn1;
		|        }//end_constr
		|
		|        public ClDataColumn(string p1)
		|        {
		|            DataColumn DataColumn1 = new DataColumn(p1);
		|            DataColumn1.dll_obj = this;
		|            Base_obj = DataColumn1;
		|        }//end_constr
		|		
		|        public ClDataColumn(string p1, System.Type p2)
		|        {
		|            DataColumn DataColumn1 = new DataColumn(p1, p2);
		|            DataColumn1.dll_obj = this;
		|            Base_obj = DataColumn1;
		|        }//end_constr
		|
		|        public ClDataColumn(DataColumn p1)
		|        {
		|            DataColumn DataColumn1 = p1;
		|            DataColumn1.dll_obj = this;
		|            Base_obj = DataColumn1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "DataTable" Тогда
		Стр = 
		"        public ClDataTable()
		|        {
		|            DataTable DataTable1 = new DataTable();
		|            DataTable1.dll_obj = this;
		|            Base_obj = DataTable1;
		|        }//end_constr
		|		
		|        public ClDataTable(string p1)
		|        {
		|            DataTable DataTable1 = new DataTable(p1);
		|            DataTable1.dll_obj = this;
		|            Base_obj = DataTable1;
		|        }//end_constr
		|
		|        public ClDataTable(DataTable p1)
		|        {
		|            DataTable DataTable1 = p1;
		|            DataTable1.dll_obj = this;
		|            Base_obj = DataTable1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "LinkArea" Тогда
		Стр = 
		"        public ClLinkArea(int p1, int p2)
		|        {
		|            LinkArea LinkArea1 = new LinkArea(p1, p2);
		|            LinkArea1.dll_obj = this;
		|            Base_obj = LinkArea1;
		|        }//end_constr
		|		
		|        public ClLinkArea(LinkArea p1)
		|        {
		|            LinkArea LinkArea1 = p1;
		|            LinkArea1.dll_obj = this;
		|            Base_obj = LinkArea1;
		|        }//end_constr
		|		
		|        public ClLinkArea(System.Windows.Forms.LinkArea p1)
		|        {
		|            LinkArea LinkArea1 = new LinkArea(p1);
		|            LinkArea1.dll_obj = this;
		|            Base_obj = LinkArea1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Link" Тогда
		Стр = 
		"        public ClLink()
		|        {
		|            Link Link1 = new Link();
		|            Link1.dll_obj = this;
		|            Base_obj = Link1;
		|        }//end_constr
		|		
		|        public ClLink(Link p1)
		|        {
		|            Link Link1 = p1;
		|            Link1.dll_obj = this;
		|            Base_obj = Link1;
		|        }//end_constr
		|        
		|        public ClLink(System.Windows.Forms.LinkLabel.Link p1)
		|        {
		|            Link Link1 = new Link(p1);
		|            Link1.dll_obj = this;
		|            Base_obj = Link1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Form" Тогда
		Стр = 
		"        public System.Windows.Forms.ContainerControl M_ContainerControl;
		|		
		|        public ClForm()
		|        {
		|            Form Form1 = new Form();
		|            Form1.dll_obj = this;
		|            Base_obj = Form1;
		|            if (OneScriptForms.FirstForm == null)
		|            {
		|                OneScriptForms.FirstForm = this;
		|            }
		|        }//end_constr
		|        ";
	ИначеЕсли ИмяКласса = "FormClosingEventArgs" Тогда
		Стр = 
		"        public ClFormClosingEventArgs()
		|        {
		|            FormClosingEventArgs FormClosingEventArgs1 = new FormClosingEventArgs(System.Windows.Forms.CloseReason.None, true);
		|            FormClosingEventArgs1.dll_obj = this;
		|            Base_obj = FormClosingEventArgs1;
		|        }//end_constr
		|
		|        public ClFormClosingEventArgs(FormClosingEventArgs p1)
		|        {
		|            FormClosingEventArgs FormClosingEventArgs1 = p1;
		|            FormClosingEventArgs1.dll_obj = this;
		|            Base_obj = FormClosingEventArgs1;
		|        }//end_constr
		|";		
	ИначеЕсли ИмяКласса = "Pen" Тогда
		Стр = 
		"        public ClPen(ClColor p1, float p2 = 1.0f)
		|        {
		|            Pen Pen1 = new Pen(p1.Base_obj.M_Color, p2);
		|            Pen1.dll_obj = this;
		|            Base_obj = Pen1;
		|        }//end_constr
		|		
		|        public ClPen(Pen p1)
		|        {
		|            Pen Pen1 = p1;
		|            Pen1.dll_obj = this;
		|            Base_obj = Pen1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Size" Тогда
		Стр = 
		"        public ClSize(int width, int height)
		|        {
		|            Size Size1 = new Size(width, height);
		|            Size1.dll_obj = this;
		|            Base_obj = Size1;
		|        }//end_constr
		|
		|        public ClSize(Size p1)
		|        {
		|            Size Size1 = p1;
		|            Size1.dll_obj = this;
		|            Base_obj = Size1;
		|        }//end_constr
		|		
		|        public ClSize(System.Drawing.Size p1)
		|        {
		|            Size Size1 = new Size(p1);
		|            Size1.dll_obj = this;
		|            Base_obj = Size1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Point" Тогда
		Стр = 
		"        public ClPoint(int x, int y)
		|        {
		|            Point Point1 = new Point(x, y);
		|            Point1.dll_obj = this;
		|            Base_obj = Point1;
		|        }//end_constr
		|
		|        public ClPoint(Point p1)
		|        {
		|            Point Point1 = p1;
		|            Point1.dll_obj = this;
		|            Base_obj = Point1;
		|        }//end_constr
		|		
		|        public ClPoint(System.Drawing.Point p1)
		|        {
		|            Point Point1 = new Point(p1);
		|            Point1.dll_obj = this;
		|            Base_obj = Point1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Rectangle" Тогда
		Стр = 
		"        public ClRectangle(int x = 0, int y = 0, int width = 0, int height = 0)
		|        {
		|            Rectangle Rectangle1 = new Rectangle(x, y, width, height);
		|            Rectangle1.dll_obj = this;
		|            Base_obj = Rectangle1;
		|            X = x;
		|            Y = y;
		|            Width = width;
		|            Height = height;
		|        }//end_constr
		|		
		|        public ClRectangle(Rectangle p1)
		|        {
		|            Rectangle Rectangle1 = p1;
		|            Rectangle1.dll_obj = this;
		|            Base_obj = Rectangle1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Clipboard"  или 
			ИмяКласса = "BoldedDates" или 
			ИмяКласса = "AnnuallyBoldedDates" или 
			ИмяКласса = "Math" или 
			ИмяКласса = "InputBox" или 
			ИмяКласса = "MonthlyBoldedDates" Тогда
		Стр = "";
	ИначеЕсли ИмяКласса = "SolidBrush" Тогда
		Стр = 
		"        public ClSolidBrush(Color p1)
		|        {
		|            SolidBrush SolidBrush1 = new SolidBrush(p1.M_Color);
		|            SolidBrush1.dll_obj = this;
		|            Base_obj = SolidBrush1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "TextureBrush" Тогда
		Стр = 
		"        public ClTextureBrush(Image p1)
		|        {
		|            TextureBrush TextureBrush1 = new TextureBrush(p1.M_Image);
		|            TextureBrush1.dll_obj = this;
		|            Base_obj = TextureBrush1;
		|        }//end_constr
		|		
		|        public ClTextureBrush(TextureBrush p1)
		|        {
		|            TextureBrush TextureBrush1 = p1;
		|            TextureBrush1.dll_obj = this;
		|            Base_obj = TextureBrush1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Type" Тогда
		Стр = 
		"        public ClType(IValue p1)
		|        {
		|            Type Type1 = null;
		|            if (p1.SystemType.Name == ""Строка"")
		|            {
		|                string p2 = p1.AsString();
		|                try
		|                {
		|                    string str1 = """";
		|                    string str2 = """";
		|                    var a = Assembly.GetExecutingAssembly();
		|                    var allTypes = a.GetTypes();
		|                    foreach (var type1 in allTypes)
		|                    {
		|                        try
		|                        {
		|                            str1 = type1.GetCustomAttribute<ContextClassAttribute>().GetName();
		|                            str2 = type1.GetCustomAttribute<ContextClassAttribute>().GetAlias();
		|                        }
		|                        catch { }
		|                        if (str1.Replace(""Кл"", """") == p2 || str2.Replace(""Cl"", """") == p2)
		|                        {
		|                            Type1 = new Type(type1);
		|                            break;
		|                        }
		|                        else
		|                        {
		|                        }
		|                    }
		|                }
		|                catch { }
		|            }
		|            else
		|            {
		|                Type1 = new Type(p1.GetType());
		|            }
		|            Base_obj = Type1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Bitmap" Тогда
		Стр = 
		"        public ClBitmap(ClSize p1)
		|        {
		|            Bitmap Bitmap1 = new Bitmap(p1.Base_obj);
		|            Bitmap1.dll_obj = this;
		|            Base_obj = Bitmap1;
		|        }//end_constr
		|
		|        public ClBitmap(Image p1)
		|        {
		|            Bitmap Bitmap1 = new Bitmap(p1);
		|            Bitmap1.dll_obj = this;
		|            Base_obj = Bitmap1;
		|        }//end_constr
		|
		|        public ClBitmap(Image p1, ClSize p2)
		|        {
		|            Bitmap Bitmap1 = new Bitmap(p1, p2.Base_obj);
		|            Bitmap1.dll_obj = this;
		|            Base_obj = Bitmap1;
		|        }//end_constr
		|
		|        public ClBitmap(string p1)
		|        {
		|            Bitmap Bitmap1 = new Bitmap(p1);
		|            Bitmap1.dll_obj = this;
		|            Base_obj = Bitmap1;
		|        }//end_constr
		|
		|        public ClBitmap(ClStream p1)
		|        {
		|            Bitmap Bitmap1 = new Bitmap(p1.Base_obj);
		|            Bitmap1.dll_obj = this;
		|            Base_obj = Bitmap1;
		|        }//end_constr
		|
		|        public ClBitmap(ClBitmap p1)
		|        {
		|            Bitmap Bitmap1 = p1.Base_obj;
		|            Bitmap1.dll_obj = this;
		|            Base_obj = Bitmap1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "MenuItem" Тогда
		Стр = 
		"        public ClMenuItem()
		|        {
		|            MenuItem MenuItem1 = new MenuItem();
		|            MenuItem1.dll_obj = this;
		|            Base_obj = MenuItem1;
		|        }//end_constr
		|		
		|        public ClMenuItem(MenuItem p1)
		|        {
		|            MenuItem MenuItem1 = p1;
		|            MenuItem1.dll_obj = this;
		|            Base_obj = MenuItem1;
		|        }//end_constr
		|
		|        public ClMenuItem(string p1 = """", string p2 = """", int p3 = 0)
		|        {
		|            MenuItem MenuItem1 = new MenuItem(p1, p2, (System.Windows.Forms.Shortcut)p3);
		|            MenuItem1.dll_obj = this;
		|            Base_obj = MenuItem1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Font" Тогда
		Стр = 
		"        public ClFont(string p1 = null, float p2 = 6.0f, int p3 = 0)
		|        {
		|            Font Font1 = new Font(p1, p2, (System.Drawing.FontStyle)p3);
		|            Font1.dll_obj = this;
		|            Base_obj = Font1;
		|        }//end_constr
		|		
		|        public ClFont(Font p1)
		|        {
		|            Font Font1 = p1;
		|            Font1.dll_obj = this;
		|            Base_obj = Font1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ManagedProperty" Тогда
		Стр = 
		"        public ClManagedProperty(IValue p1, string p2, IValue p3 = null)
		|        {
		|            managedObject = p1;
		|            managedProperty = p2;
		|            ratio = p3;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "TabPage" Тогда
		Стр = 
		"        public ClTabPage(string p1 = null)
		|        {
		|            TabPage TabPage1 = new TabPage(p1);
		|            TabPage1.dll_obj = this;
		|            Base_obj = TabPage1;
		|        }//end_constr
		|		
		|        public ClTabPage(TabPage p1)
		|        {
		|            TabPage TabPage1 = p1;
		|            TabPage1.dll_obj = this;
		|            Base_obj = TabPage1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ListItem" Тогда
		Стр = 
		"        public ClListItem(string p1 = null, IValue p2 = null)
		|        {
		|            dynamic p3 = p2;
		|            if (p2 != null)
		|            {
		|                if (p2.GetType().ToString().Contains(""osf.""))
		|                {
		|                    p3 = ((dynamic)p2).Base_obj;
		|                }
		|            }
		|            ListItem ListItem1 = new ListItem(p1, p3);
		|            ListItem1.dll_obj = this;
		|            Base_obj = ListItem1;
		|        }//end_constr
		|		
		|        public ClListItem(ListItem p1)
		|        {
		|            ListItem ListItem1 = p1;
		|            ListItem1.dll_obj = this;
		|            Base_obj = ListItem1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Icon" Тогда
		Стр = 
		"    public ClIcon(string p1)
		|        {
		|            Icon Icon1 = new Icon(p1);
		|            Icon1.dll_obj = this;
		|            Base_obj = Icon1;
		|        }//end_constr
		|
		|        public ClIcon(string p1, int p2)
		|        {
		|            Icon Icon1 = new Icon(p1, p2);
		|            Icon1.dll_obj = this;
		|            Base_obj = Icon1;
		|        }//end_constr
		|
		|        public ClIcon(Icon p1)
		|        {
		|            Icon Icon1 = p1;
		|            Icon1.dll_obj = this;
		|            Base_obj = Icon1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ColumnHeader" Тогда
		Стр = 
		"        public ClColumnHeader()
		|        {
		|            ColumnHeader ColumnHeader1 = new ColumnHeader();
		|            ColumnHeader1.dll_obj = this;
		|            Base_obj = ColumnHeader1;
		|        }//end_constr
		|
		|        public ClColumnHeader(ColumnHeader p1)
		|        {
		|            ColumnHeader ColumnHeader1 = p1;
		|            ColumnHeader1.dll_obj = this;
		|            Base_obj = ColumnHeader1;
		|        }//end_constr
		|
		|        public ClColumnHeader(string p1, int p2, int p3)
		|        {
		|            ColumnHeader ColumnHeader1 = new ColumnHeader(p1, p2, (System.Windows.Forms.HorizontalAlignment)p3);
		|            ColumnHeader1.dll_obj = this;
		|            Base_obj = ColumnHeader1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ListViewItem" Тогда
		Стр = 
		"        public ClListViewItem(string p1 = """", int p2 = -1)
		|        {
		|            ListViewItem ListViewItem1 = new ListViewItem(p1, p2);
		|            ListViewItem1.dll_obj = this;
		|            Base_obj = ListViewItem1;
		|        }//end_constr
		|		
		|        public ClListViewItem(ListViewItem p1)
		|        {
		|            ListViewItem ListViewItem1 = p1;
		|            ListViewItem1.dll_obj = this;
		|            Base_obj = ListViewItem1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ListViewSubItem" Тогда
		Стр = 
		"        public ClListViewSubItem(string text = """")
		|        {
		|            ListViewSubItem ListViewSubItem1 = new ListViewSubItem(text);
		|            ListViewSubItem1.dll_obj = this;
		|            Base_obj = ListViewSubItem1;
		|        }//end_constr
		|
		|        public ClListViewSubItem(ListViewSubItem p1)
		|        {
		|            ListViewSubItem ListViewSubItem1 = p1;
		|            ListViewSubItem1.dll_obj = this;
		|            Base_obj = ListViewSubItem1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ProcessStartInfo" Тогда
		Стр = 
		"        public ClProcessStartInfo(string p1 = null, string p2 = null)
		|        {
		|            ProcessStartInfo ProcessStartInfo1 = new ProcessStartInfo(p1, p2);
		|            ProcessStartInfo1.dll_obj = this;
		|            Base_obj = ProcessStartInfo1;
		|        }//end_constr
		|
		|        public ClProcessStartInfo(ProcessStartInfo p1)
		|        {
		|            ProcessStartInfo ProcessStartInfo1 = p1;
		|            ProcessStartInfo1.dll_obj = this;
		|            Base_obj = ProcessStartInfo1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ProgressBar" Тогда
		Стр = 
		"        public ClProgressBar(bool p1)
		|        {
		|            ProgressBar ProgressBar1 = new ProgressBar(p1);
		|            ProgressBar1.dll_obj = this;
		|            Base_obj = ProgressBar1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "SelectionRange" Тогда
		Стр = 
		"        public ClSelectionRange()
		|        {
		|            SelectionRange SelectionRange1 = new SelectionRange();
		|            SelectionRange1.dll_obj = this;
		|            Base_obj = SelectionRange1;
		|        }//end_constr
		|		
		|        public ClSelectionRange(IValue p1, IValue p2)
		|        {
		|            SelectionRange SelectionRange1 = new SelectionRange(p1.AsDate(), p2.AsDate());
		|            SelectionRange1.dll_obj = this;
		|            Base_obj = SelectionRange1;
		|        }//end_constr
		|		
		|        public ClSelectionRange(SelectionRange p1)
		|        {
		|            SelectionRange SelectionRange1 = p1;
		|            SelectionRange1.dll_obj = this;
		|            Base_obj = SelectionRange1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "MonthCalendar" Тогда
		Стр = 
		"        public ClMonthCalendar()
		|        {
		|            MonthCalendar MonthCalendar1 = new MonthCalendar();
		|            MonthCalendar1.dll_obj = this;
		|            Base_obj = MonthCalendar1;
		|            boldedDates = new ClBoldedDates();
		|            boldedDates.M_Object = Base_obj.BoldedDates;
		|            annuallyBoldedDates = new ClAnnuallyBoldedDates();
		|            annuallyBoldedDates.M_Object = Base_obj.AnnuallyBoldedDates;
		|            monthlyBoldedDates = new ClMonthlyBoldedDates();
		|            monthlyBoldedDates.M_Object = Base_obj.MonthlyBoldedDates;
		|        }//end_constr
		|
		|        public ClMonthCalendar(MonthCalendar p1)
		|        {
		|            MonthCalendar MonthCalendar1 = p1;
		|            MonthCalendar1.dll_obj = this;
		|            Base_obj = MonthCalendar1;
		|            boldedDates = new ClBoldedDates();
		|            boldedDates.M_Object = Base_obj.BoldedDates;
		|            annuallyBoldedDates = new ClAnnuallyBoldedDates();
		|            annuallyBoldedDates.M_Object = Base_obj.AnnuallyBoldedDates;
		|            monthlyBoldedDates = new ClMonthlyBoldedDates();
		|            monthlyBoldedDates.M_Object = Base_obj.MonthlyBoldedDates;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "TreeNode" Тогда
		Стр = 
		"        public ClTreeNode()
		|        {
		|            TreeNode TreeNode1 = new TreeNode();
		|            TreeNode1.dll_obj = this;
		|            Base_obj = TreeNode1;
		|        }//end_constr
		|		
		|        public ClTreeNode(string p1)
		|        {
		|            TreeNode TreeNode1 = new TreeNode(p1);
		|            TreeNode1.dll_obj = this;
		|            Base_obj = TreeNode1;
		|        }//end_constr
		|		
		|        public ClTreeNode(TreeNode p1)
		|        {
		|            TreeNode TreeNode1 = p1;
		|            TreeNode1.dll_obj = this;
		|            Base_obj = TreeNode1;
		|        }//end_constr
		|		
		|        public ClTreeNode(System.Windows.Forms.TreeNode p1)
		|        {
		|            TreeNode TreeNode1 = new TreeNode(p1);
		|            TreeNode1.dll_obj = this;
		|            Base_obj = TreeNode1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ToolBarButton" Тогда
		Стр = 
		"        public ClToolBarButton(string p1 = null)
		|        {
		|            ToolBarButton ToolBarButton1 = new ToolBarButton(p1);
		|            ToolBarButton1.dll_obj = this;
		|            Base_obj = ToolBarButton1;
		|        }//end_constr
		|		
		|        public ClToolBarButton(ToolBarButton p1)
		|        {
		|            ToolBarButton ToolBarButton1 = p1;
		|            ToolBarButton1.dll_obj = this;
		|            Base_obj = ToolBarButton1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "MenuNotifyIcon" Тогда
		Стр = 
		"        public ClMenuNotifyIcon()
		|        {
		|            MenuNotifyIcon MenuNotifyIcon1 = new MenuNotifyIcon();
		|            MenuNotifyIcon1.dll_obj = this;
		|            Base_obj = MenuNotifyIcon1;
		|            firstShow = true;
		|            notifyIcon = null;
		|        }//end_constr
		|		
		|        public void Show(ClUserControl p1, ClPoint p2)
		|        {
		|            Base_obj.Show(p1.Base_obj.M_UserControl, p2.Base_obj.M_Point);
		|        }
		|";
	ИначеЕсли ИмяКласса = "NotifyIcon" Тогда
		Стр = 
		"        public ClNotifyIcon(ref ClMenuNotifyIcon p1)
		|        {
		|            NotifyIcon NotifyIcon1 = new NotifyIcon();
		|            NotifyIcon1.dll_obj = this;
		|            Base_obj = NotifyIcon1;
		|            menu = p1;
		|            p1.NotifyIcon = this;
		|            NotifyIcon1.ContextMenu = p1.Base_obj;
		|            userControl1.Size = new ClSize(0, 0);
		|            userControl1.Parent = OneScriptForms.FirstForm;
		|            userControl1.Value = this;
		|            p1.Show(userControl1, new ClPoint(5, 5));
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "GridItemCollection" Тогда
		Стр = 
		"        public ClGridItemCollection(GridItemCollection p1)
		|        {
		|            GridItemCollection GridItemCollection1 = p1;
		|            GridItemCollection1.dll_obj = this;
		|            Base_obj = GridItemCollection1;
		|        }//end_constr
		|
		|        public ClGridItemCollection(System.Windows.Forms.GridItemCollection p1)
		|        {
		|            GridItemCollection GridItemCollection1 = new GridItemCollection(p1);
		|            GridItemCollection1.dll_obj = this;
		|            Base_obj = GridItemCollection1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ListBoxSelectedObjectCollection" Тогда
		Стр = 
		"        public ClListBoxSelectedObjectCollection(ListBoxSelectedObjectCollection p1, ClListBox p2)
		|        {
		|            ListBoxSelectedObjectCollection ListBoxSelectedObjectCollection1 = p1;
		|            ListBoxSelectedObjectCollection1.dll_obj = this;
		|            Base_obj = ListBoxSelectedObjectCollection1;
		|            M_obj = p2;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "Version" Тогда
		Стр = 
		"        public ClVersion(Version p1)
		|        {
		|            Version Version1 = p1;
		|            Version1.dll_obj = this;
		|            Base_obj = Version1;
		|        }//end_constr
		|
		|        public ClVersion(System.Version p1)
		|        {
		|            Version Version1 = new Version(p1);
		|            Version1.dll_obj = this;
		|            Base_obj = Version1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "StreamReader" Тогда
		Стр = 
		"        public ClStreamReader(string p1)
		|        {
		|            StreamReader StreamReader1 = new StreamReader(p1);
		|            StreamReader1.dll_obj = this;
		|            Base_obj = StreamReader1;
		|        }//end_constr
		|		
		|        public ClStreamReader(StreamReader p1)
		|        {
		|            StreamReader StreamReader1 = p1;
		|            StreamReader1.dll_obj = this;
		|            Base_obj = StreamReader1;
		|        }//end_constr
		|";
	ИначеЕсли ИмяКласса = "ComboBox" Тогда
		Стр = 
		"        public ClComboBox()
		|        {
		|            ComboBox ComboBox1 = new ComboBox();
		|            ComboBox1.dll_obj = this;
		|            Base_obj = ComboBox1;
		|            items = new ClComboBoxObjectCollection(Base_obj.Items);
		|        }//end_constr
		|		
		|        public ClComboBox(osf.NoKeyUpComboBoxEx p1)
		|        {
		|            ComboBox ComboBox1 = new ComboBox(p1);
		|            ComboBox1.dll_obj = this;
		|            Base_obj = ComboBox1;
		|            items = new ClComboBoxObjectCollection(Base_obj.Items);
		|        }//end_constr
		|		
		|        public ClComboBox(ComboBox p1)
		|        {
		|            ComboBox ComboBox1 = p1;
		|            ComboBox1.dll_obj = this;
		|            Base_obj = ComboBox1;
		|            items = new ClComboBoxObjectCollection(Base_obj.Items);
		|        }//end_constr
		|		
		|        public ClArrayList _HeightItems
		|        {
		|            get { return heights; }
		|            set { heights = value; }
		|        }
		|";
	ИначеЕсли ИмяКласса = "TabPageCollection" или
			  ИмяКласса = "ListViewSelectedItemCollection" или
			  ИмяКласса = "Graphics" или
			  ИмяКласса = "DockPaddingEdges" или
			  ИмяКласса = "LinkCollection" или
			  ИмяКласса = "DataColumnCollection" или
			  ИмяКласса = "DataTableCollection" или
			  ИмяКласса = "DataRow" или
			  ИмяКласса = "DataRowCollection" или
			  ИмяКласса = "GridTableStylesCollection" или
			  ИмяКласса = "GridColumnStylesCollection" или
			  ИмяКласса = "ComboBoxObjectCollection" или
			  ИмяКласса = "BitmapData" или
			  ИмяКласса = "GridItem" Тогда
		Стр = 
		"        public Cl" + ИмяКласса + "(" + ИмяКласса + " p1)
		|        {
		|            " + ИмяКласса + " " + ИмяКласса + "1 = p1;
		|            " + ИмяКласса + "1.dll_obj = this;
		|            Base_obj = " + ИмяКласса + "1;
		|        }//end_constr
		|";
		
		
		


	Иначе
		Стр = 
		"        public Cl" + ИмяКласса + "()
		|        {
		|            " + ИмяКласса + " " + ИмяКласса + "1 = new " + ИмяКласса + "();
		|            " + ИмяКласса + "1.dll_obj = this;
		|            Base_obj = " + ИмяКласса + "1;
		|        }//end_constr
		|		
		|        public Cl" + ИмяКласса + "(" + ИмяКласса + " p1)
		|        {
		|            " + ИмяКласса + " " + ИмяКласса + "1 = p1;
		|            " + ИмяКласса + "1.dll_obj = this;
		|            Base_obj = " + ИмяКласса + "1;
		|        }//end_constr
		|        ";
	КонецЕсли;
	Возврат Стр;
КонецФункции//Конструктор

Функция Base_obj(ИмяКласса)
	Если ИмяКласса = "OneScriptForms" или
		ИмяКласса = "ManagedProperty" или
		ИмяКласса = "BoldedDates" или
		ИмяКласса = "AnnuallyBoldedDates" или
		ИмяКласса = "Clipboard" или
		ИмяКласса = "Math" или
		ИмяКласса = "InputBox" или
		ИмяКласса = "MonthlyBoldedDates" Тогда
		Возврат "";
	ИначеЕсли ИмяКласса = "ComboBox" Тогда
		Стр = 
		"        public dynamic Base_obj;
		|";
		Возврат Стр;
	ИначеЕсли ИмяКласса = "DataGridComboBoxColumnStyle" Тогда
		Стр = 
		"        public DataGridComboBoxColumn Base_obj;
		|";
		Возврат Стр;
	КонецЕсли;
	Стр = 
	"        public " + ИмяКласса + " Base_obj;
	|";
	Возврат Стр;
КонецФункции//Base_obj

Функция Свойства(ИмяФайлаЧленов, ИмяКонтекстКлассаАнгл)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptFormsru\OneScriptForms.html");
	Стр = ТекстДок.ПолучитьТекст();
	//находим текст таблицы
	СтрТаблица = СтрНайтиМежду(Стр, "<H3 class=dtH3>Перечисления</H3>", "</TBODY></TABLE>", Ложь, );
	// Сообщить("==================" + СтрТаблица[0]);
	Массив1 = СтрНайтиМежду(СтрТаблица[0], "<TD width=""50%""><A href", "</A></TD>", , );
	// Сообщить("Массив1.Количество = " + Массив1.Количество());
	Если Массив1.Количество() > 0 Тогда
		СписокСтрПеречислений = Новый СписокЗначений;
		Для А = 0 По Массив1.ВГраница() Цикл
			СтрХ = Массив1[А];
			// Сообщить("=СтрХ=================" + СтрХ);
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			ПеречислениеАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			СписокСтрПеречислений.Добавить(ПеречислениеАнгл);
		КонецЦикла;
	КонецЕсли;
	СтрПеречислений = "";
	СписокСтрПеречислений.СортироватьПоЗначению();
	Для А = 0 По СписокСтрПеречислений.Количество() - 1 Цикл
		Если А = (СписокСтрПеречислений.Количество() - 1) Тогда
			СтрПеречислений = СтрПеречислений + СписокСтрПеречислений.Получить(А).Значение;
		Иначе
			СтрПеречислений = СтрПеречислений + СписокСтрПеречислений.Получить(А).Значение + ",";
		КонецЕсли;
	КонецЦикла;
	
	М_СтрПеречислений = РазобратьСтроку(СтрПеречислений, ",");
	
	ТекстДокЧленов = Новый ТекстовыйДокумент;
	КаталогНаДиске = Новый Файл(ИмяФайлаЧленов);
    Если Не (КаталогНаДиске.Существует()) Тогда
        Стр = 
		"        //Свойства============================================================" + Символы.ПС;
			
		Возврат Стр;
	КонецЕсли;
	ТекстДокЧленов.Прочитать(ИмяФайлаЧленов);
	СтрТекстДокЧленов = ТекстДокЧленов.ПолучитьТекст();
	Если Не (СтрНайтиМежду(СтрТекстДокЧленов, "<H4 class=dtH4>Свойства</H4>", "</TBODY></TABLE>", Ложь, ).Количество() > 0) Тогда
		Стр = 
		"        //Свойства============================================================" + Символы.ПС;
		Возврат Стр;
	КонецЕсли;
	СтрТаблицаЧленов = СтрНайтиМежду(СтрТекстДокЧленов, "<H4 class=dtH4>Свойства</H4>", "</TBODY></TABLE>", Ложь, )[0];
	Массив1 = СтрНайтиМежду(СтрТаблицаЧленов, "<TR vAlign=top>", "</TD></TR>", Ложь, );
	// Сообщить("Массив1.Количество()=" + Массив1.Количество());
	Если Массив1.Количество() > 0 Тогда
		Стр = "        //Свойства============================================================" + Символы.ПС;
		Для А = 0 По Массив1.ВГраница() Цикл
			//найдем первую ячейку строки таблицы
			М07 = СтрНайтиМежду(Массив1[А], "<TD width=""50%"">", "</TD>", Ложь, );
			СтрХ = М07[0];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			
			ИмяФайлаСвойства = "C:\444\OneScriptFormsru\" + СтрНайтиМежду(СтрХ, "<A href=""", """>", , )[0];
			ТекстДокСвойства = Новый ТекстовыйДокумент;
			ТекстДокСвойства.Прочитать(ИмяФайлаСвойства);
			СтрТекстДокСвойства = ТекстДокСвойства.ПолучитьТекст();
			СтрРаздела = СтрНайтиМежду(СтрТекстДокСвойства, "<H4 class=dtH4>Использование</H4>", "<H4 class=dtH4>Значение</H4>", , )[0];
			СтрИспользование = СтрНайтиМежду(СтрРаздела, "<P>", "</P>", , )[0];

			СвойствоАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			СвойствоРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			Если (СвойствоРус = "Сборка") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextProperty(""Сборка"", ""Build"")]
				|        public int Build
				|        {
				|            get { return Assembly.GetExecutingAssembly().GetName().Version.Build; }
				|        }				
				|        
				|";
			ИначеЕсли СвойствоРус = "РазмерШрифта" Тогда
				Стр = Стр +
				"        [ContextProperty(""РазмерШрифта"", ""FontSize"")]
				|        public int FontSize
				|        {
				|            get { return Convert.ToInt32(Base_obj.FontSize); }
				|            set { Base_obj.FontSize = value; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "ВысотаШрифта" Тогда
				Стр = Стр +
				"        [ContextProperty(""ВысотаШрифта"", ""FontHeight"")]
				|        public int FontHeight
				|        {
				|            get { return Convert.ToInt32(Base_obj.FontHeight); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "ПозицияМыши" Тогда
				Стр = Стр +
				"        [ContextProperty(""ПозицияМыши"", ""MousePosition"")]
				|        public ClPoint MousePosition
				|        {
				|            get { return new ClPoint(System.Windows.Forms.Control.MousePosition); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "АргументыСобытия" Тогда
				Стр = Стр +
				"        [ContextProperty(""АргументыСобытия"", ""EventArgs"")]
				|        public IValue EventArgs
				|        {
				|            get { return Event; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ВерсияПродукта") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВерсияПродукта"", ""ProductVersion"")]
				|        public ClVersion ProductVersion
				|        {
				|            get { return new ClVersion(Assembly.GetExecutingAssembly().GetName().Version); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "АктивнаяФорма" Тогда
				Стр = Стр +
				"        [ContextProperty(""АктивнаяФорма"", ""ActiveForm"")]
				|        public ClForm ActiveForm
				|        {
				|            get
				|            {
				|                if (System.Windows.Forms.Form.ActiveForm != null)
				|                {
				|                    return ((Form)((FormEx)System.Windows.Forms.Form.ActiveForm).M_Object).dll_obj;
				|                }
				|                return null;
				|            }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "АктивныйЭлемент" Тогда
				Стр = Стр +
				"        [ContextProperty(""АктивныйЭлемент"", ""ActiveControl"")]
				|        public IValue ActiveControl
				|        {
				|            get { return ((dynamic)Base_obj.ActiveControl).dll_obj; }
				|            set { Base_obj.ActiveControl = ((dynamic)value).Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "ИмяПродукта" Тогда
				Стр = Стр +
				"        [ContextProperty(""ИмяПродукта"", ""ProductName"")]
				|        public string ProductName
				|        {
				|            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Отправитель" Тогда
				Стр = Стр +
				"        [ContextProperty(""Отправитель"", ""Sender"")]
				|        public IValue Sender
				|        {
				|            get { return OneScriptForms.RevertObj(((dynamic)Event).Base_obj.Sender); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "ПричинаЗакрытия" Тогда
				Стр = Стр +
				"        [ContextProperty(""ПричинаЗакрытия"", ""CloseReason"")]
				|        public int CloseReason
				|        {
				|            get { return (int)Base_obj.CloseReason; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Размер") и (ИмяКонтекстКлассаАнгл = "Font") Тогда
				Стр = Стр +
				"        [ContextProperty(""Размер"", ""Size"")]
				|        public IValue Size
				|        {
				|            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.Size))); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ПриЗакрытии") и (ИмяКонтекстКлассаАнгл = "Form") Тогда
				Стр = Стр +
				"        [ContextProperty(""ПриЗакрытии"", ""FormClosing"")]
				|        public string FormClosing
				|        {
				|            get { return Base_obj.Closing; }
				|            set { Base_obj.Closing = value; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Продолжать" Тогда
				Стр = Стр +
				"        [ContextProperty(""Продолжать"", ""GoOn"")]
				|        public bool GoOn
				|        {
				|            get
				|            {
				|                PostEventProcessing();
				|                return goOn;
				|            }
				|            set { goOn = value; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Метка" Тогда
				СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + Символы.ПС +
				"        private ClCollection tag = new ClCollection();";
				Стр = Стр +
				"        [ContextProperty(""Метка"", ""Tag"")]
				|        public ClCollection Tag
				|        {
				|            get { return tag; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Тип" Тогда
				Стр = Стр +
				"        [ContextProperty(""Тип"", ""Type"")]
				|        public ClType Type
				|        {
				|            get { return new ClType(this); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "ЭлементВерхнегоУровня" Тогда
				Стр = Стр +
				"        [ContextProperty(""ЭлементВерхнегоУровня"", ""TopLevelControl"")]
				|        public IValue TopLevelControl
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.TopLevelControl); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ЭлементУправления") и (ИмяКонтекстКлассаАнгл = "Color") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЭлементУправления"", ""Control"")]
				|        public ClColor Control
				|        {
				|            get { return new ClColor(Base_obj.Control); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "ЭлементУправления" Тогда
				Стр = Стр +
				"        [ContextProperty(""ЭлементУправления"", ""Control"")]
				|        public IValue Control
				|        {
				|            get { return (IValue)OneScriptForms.RevertObj(Base_obj.Control); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "КнопкаОтмена" Тогда
				Стр = Стр +
				"        [ContextProperty(""КнопкаОтмена"", ""CancelButton"")]
				|        public IValue CancelButton
				|        {
				|            get { return ((dynamic)Base_obj.CancelButton).dll_obj; }
				|            set { Base_obj.CancelButton = ((dynamic)value).Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "КнопкаПринять" Тогда
				Стр = Стр +
				"        [ContextProperty(""КнопкаПринять"", ""AcceptButton"")]
				|        public IValue AcceptButton
				|        {
				|            get { return ((dynamic)Base_obj.AcceptButton).dll_obj; }
				|            set { Base_obj.AcceptButton = ((dynamic)value).Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "КолонкаСортировки") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextProperty(""КолонкаСортировки"", ""SortedColumn"")]
				|        public ClColumnHeader SortedColumn
				|        {
				|            get
				|            {
				|                if (Base_obj.SortedColumn != null)
				|                {
				|                    return Base_obj.SortedColumn.dll_obj;
				|                }
				|                return null;
				|            }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Родитель") и (ИмяКонтекстКлассаАнгл = "MenuItem") Тогда
				Стр = Стр +
				"        [ContextProperty(""Родитель"", ""Parent"")]
				|        public IValue Parent
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Родитель") и (ИмяКонтекстКлассаАнгл = "TreeNode") Тогда
				Стр = Стр +
				"        [ContextProperty(""Родитель"", ""Parent"")]
				|        public IValue Parent
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Родитель" Тогда
				Стр = Стр +
				"        [ContextProperty(""Родитель"", ""Parent"")]
				|        public IValue Parent
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Parent); }
				|            set { Base_obj.Parent = ((dynamic)value).Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Источник" Тогда
				Стр = Стр +
				"        [ContextProperty(""Источник"", ""SourceControl"")]
				|        public IValue SourceControl
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.SourceControl); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Меню") и (ИмяКонтекстКлассаАнгл = "Form") Тогда
				Стр = Стр +
				"        [ContextProperty(""Меню"", ""Menu"")]
				|        public ClMainMenu Menu
				|        {
				|            get { return Base_obj.Menu.dll_obj; }
				|            set { Base_obj.Menu = value.Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "Владелец" Тогда
				Стр = Стр +
				"        [ContextProperty(""Владелец"", ""Owner"")]
				|        public ClForm Owner
				|        {
				|            get { return Base_obj.Owner.dll_obj; }
				|            set { Base_obj.Owner = value.Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Коэффициент") и (ИмяКонтекстКлассаАнгл = "ManagedProperty") Тогда
				Стр = Стр +
				"        [ContextProperty(""Коэффициент"", ""Ratio"")]
				|        public IValue Ratio
				|        {
				|            get { return ratio; }
				|            set { ratio = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "УправляемоеСвойство") и (ИмяКонтекстКлассаАнгл = "ManagedProperty") Тогда
				Стр = Стр +
				"        [ContextProperty(""УправляемоеСвойство"", ""ManagedProperty"")]
				|        public string ManagedProperty
				|        {
				|            get { return managedProperty; }
				|            set { managedProperty = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "УправляемыйОбъект") и (ИмяКонтекстКлассаАнгл = "ManagedProperty") Тогда
				Стр = Стр +
				"        [ContextProperty(""УправляемыйОбъект"", ""ManagedObject"")]
				|        public IValue ManagedObject
				|        {
				|            get { return managedObject; }
				|            set { managedObject = value; }
				|        }
				|        
				|";
			ИначеЕсли СвойствоРус = "УправляемыеСвойства" Тогда
				Стр = Стр +
				"        [ContextProperty(""УправляемыеСвойства"", ""ManagedProperties"")]
				|        public ClArrayList ManagedProperties
				|        {
				|            get { return Base_obj.ManagedProperties; }
				|            set { Base_obj.ManagedProperties = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ВыбранныйЭлемент") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВыбранныйЭлемент"", ""SelectedItem"")]
				|        public IValue SelectedItem
				|        {
				|            get
				|            {
				|                if (Base_obj.DataSource != null)
				|                {
				|                    if (Base_obj.DataSource is osf.ArrayList)
				|                    {
				|                        return (ClListItem)Base_obj.SelectedItem;
				|                    }
				|                    if (Base_obj.DataSource is osf.DataTable || Base_obj.DataSource is osf.DataView)
				|                    {
				|                        DataRowView DataRowView1 = new DataRowView((System.Data.DataRowView)Base_obj.SelectedItem);
				|                        ListItem ListItem1 = new ListItem();
				|                        ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
				|                        ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
				|                        return new ClListItem(ListItem1);
				|                    }
				|                }
				|                return OneScriptForms.RevertObj(Base_obj.SelectedItem);
				|            }
				|            set
				|            {
				|                if (Base_obj.DataSource == null)
				|                {
				|                    Base_obj.SelectedItem = ((dynamic)value).Base_obj;
				|                }
				|            }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ВыбранныеЭлементы") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВыбранныеЭлементы"", ""SelectedItems"")]
				|        public ClListBoxSelectedObjectCollection SelectedItems
				|        {
				|            get { return new ClListBoxSelectedObjectCollection(Base_obj.SelectedItems, this); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Строка") и (ИмяКонтекстКлассаАнгл = "DataRowView") Тогда
				Стр = Стр +
				"        [ContextProperty(""Строка"", ""Row"")]
				|        public ClDataRow Row
				|        {
				|            get { return new ClDataRow(Base_obj.Row); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Значение") и (ИмяКонтекстКлассаАнгл = "DictionaryEntry") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значение"", ""Value"")]
				|        public IValue Value
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Value); }
				|            set { Base_obj.Value = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Значение") и (ИмяКонтекстКлассаАнгл = "ListItem") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значение"", ""Value"")]
				|        public IValue Value
				|        {
				|            get
				|            {
				|                if (Base_obj.Value.GetType().ToString() == ""ScriptEngine.Machine.SimpleConstantValue"")
				|                {
				|                    if (((IValue)Base_obj.Value).SystemType.Name == ""Число"")
				|                    {
				|                        return (IValue)Base_obj.Value;
				|                    }
				|                }
				|                return OneScriptForms.RevertObj(Base_obj.Value);
				|            }
				|            set { Base_obj.Value = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ВыбранныйОбъект") и (ИмяКонтекстКлассаАнгл = "PropertyGrid") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВыбранныйОбъект"", ""SelectedObject"")]
				|        public IValue SelectedObject
				|        {
				|            get { return ((dynamic)Base_obj.SelectedObject).dll_obj; }
				|            set { Base_obj.SelectedObject = ((dynamic)value).Base_obj; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ЭлементыСетки") и (ИмяКонтекстКлассаАнгл = "GridItem") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЭлементыСетки"", ""GridItems"")]
				|        public ClGridItemCollection GridItems
				|        {
				|            get { return new ClGridItemCollection(Base_obj.M_GridItem.GridItems); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ТипЭлементаСетки") и (ИмяКонтекстКлассаАнгл = "GridItem") Тогда
				Стр = Стр +
				"        [ContextProperty(""ТипЭлементаСетки"", ""GridItemType"")]
				|        public int GridItemType
				|        {
				|            get { return (int)Base_obj.M_GridItem.GridItemType; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ЭлементыСетки") и (ИмяКонтекстКлассаАнгл = "PropertyGrid") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЭлементыСетки"", ""GridItems"")]
				|        public ClGridItemCollection GridItems
				|        {
				|            get
				|            {
				|                object comp = Base_obj.M_PropertyGrid;
				|                object comp1 = new System.Windows.Forms.PropertyGrid();
				|                System.Type comp1Type = comp1.GetType();
				|                object view = comp1Type.GetField(""gridView"", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(comp);
				|                System.Windows.Forms.GridItemCollection GridItemCollection1 = (System.Windows.Forms.GridItemCollection)view.GetType().InvokeMember(
				|                    ""GetAllGridEntries"", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, view, null);
				|                return new ClGridItemCollection(new osf.GridItemCollection(GridItemCollection1));
				|            }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "НовоеЗначение") и (ИмяКонтекстКлассаАнгл = "SelectedGridItemChangedEventArgs") Тогда
				Стр = Стр +
				"        [ContextProperty(""НовоеЗначение"", ""NewValue"")]
				|        public IValue NewValue
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.NewValue); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "СтароеЗначение") и (ИмяКонтекстКлассаАнгл = "SelectedGridItemChangedEventArgs") Тогда
				Стр = Стр +
				"        [ContextProperty(""СтароеЗначение"", ""OldValue"")]
				|        public IValue OldValue
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.OldValue); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Количество") и (ИмяКонтекстКлассаАнгл = "BoldedDates") Тогда
				Стр = Стр +
				"        [ContextProperty(""Количество"", ""Count"")]
				|        public int Count
				|        {
				|            get { return M_Object.Length; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Количество") и (ИмяКонтекстКлассаАнгл = "AnnuallyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextProperty(""Количество"", ""Count"")]
				|        public int Count
				|        {
				|            get { return M_Object.Length; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Количество") и (ИмяКонтекстКлассаАнгл = "MonthlyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextProperty(""Количество"", ""Count"")]
				|        public int Count
				|        {
				|            get { return M_Object.Length; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ВыделенныеДаты") и (ИмяКонтекстКлассаАнгл = "MonthCalendar") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВыделенныеДаты"", ""BoldedDates"")]
				|        public ClBoldedDates BoldedDates
				|        {
				|            get { return boldedDates; }
				|
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ЕжегодныеДаты") и (ИмяКонтекстКлассаАнгл = "MonthCalendar") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЕжегодныеДаты"", ""AnnuallyBoldedDates"")]
				|        public ClAnnuallyBoldedDates AnnuallyBoldedDates
				|        {
				|            get { return annuallyBoldedDates; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ЕжемесячныеДаты") и (ИмяКонтекстКлассаАнгл = "MonthCalendar") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЕжемесячныеДаты"", ""MonthlyBoldedDates"")]
				|        public ClMonthlyBoldedDates MonthlyBoldedDates
				|        {
				|            get { return monthlyBoldedDates; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "РазрешениеИкс") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextProperty(""РазрешениеИкс"", ""DpiX"")]
				|        public IValue DpiX
				|        {
				|            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.DpiX))); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "РазрешениеИгрек") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextProperty(""РазрешениеИгрек"", ""DpiY"")]
				|        public IValue DpiY
				|        {
				|            get { return ValueFactory.Create((Convert.ToDecimal(Base_obj.DpiY))); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Имя") и (ИмяКонтекстКлассаАнгл = "Color") Тогда
				Стр = Стр +
				"        [ContextProperty(""Имя"", ""Имя"")]
				|        public string NameRu
				|        {
				|            get
				|            {
				|                try
				|                {
				|                    return this.GetType().GetProperty(this.Base_obj.Name).GetCustomAttribute<ContextPropertyAttribute>().GetName();
				|                }
				|                catch
				|                {
				|                    int Dec1 = (Base_obj.R * 65536) + (Base_obj.G * 256) + Base_obj.B;
				|                    if (Dec1 == 0)
				|                    {
				|                        return ""Черный (Black)"";
				|                    }
				|                    return ""RGB("" + this.R.ToString() + "", "" + this.G.ToString() + "", "" + this.B.ToString() + "")"";
				|                }
				|            }
				|        }
				|
				|        [ContextProperty(""Name"", ""Name"")]
				|        public string NameEn
				|        {
				|            get
				|            {
				|                try
				|                {
				|                    return this.GetType().GetProperty(this.Base_obj.Name).GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
				|                }
				|                catch
				|                {
				|                    int Dec1 = (Base_obj.R * 65536) + (Base_obj.G * 256) + Base_obj.B;
				|                    if (Dec1 == 0)
				|                    {
				|                        return ""Черный (Black)"";
				|                    }
				|                    return ""RGB("" + this.R.ToString() + "", "" + this.G.ToString() + "", "" + this.B.ToString() + "")"";
				|                }
				|            }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "СтароеЗначение") и (ИмяКонтекстКлассаАнгл = "PropertyValueChangedEventArgs") Тогда
				Стр = Стр +
				"        [ContextProperty(""СтароеЗначение"", ""OldValue"")]
				|        public IValue OldValue
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.OldValue); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Значение") и (ИмяКонтекстКлассаАнгл = "GridItem") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значение"", ""Value"")]
				|        public IValue Value
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Value); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ЗначокУведомления") и (ИмяКонтекстКлассаАнгл = "MenuNotifyIcon") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЗначокУведомления"", ""NotifyIcon"")]
				|        public ClNotifyIcon NotifyIcon
				|        {
				|            get { return notifyIcon; }
				|            set { notifyIcon = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ПервыйПоказ") и (ИмяКонтекстКлассаАнгл = "MenuNotifyIcon") Тогда
				Стр = Стр +
				"        [ContextProperty(""ПервыйПоказ"", ""FirstShow"")]
				|        public bool FirstShow
				|        {
				|            get { return firstShow; }
				|            set { firstShow = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Меню") и (ИмяКонтекстКлассаАнгл = "NotifyIcon") Тогда
				Стр = Стр +
				"        [ContextProperty(""Меню"", ""Menu"")]
				|        public ClMenuNotifyIcon Menu
				|        {
				|            get { return menu; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "Значение") и (ИмяКонтекстКлассаАнгл = "UserControl") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значение"", ""Value"")]
				|        public IValue Value
				|        {
				|            get { return (IValue)Base_obj.Value; }
				|            set { Base_obj.Value = value; }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ОбластьСсылки") и (ИмяКонтекстКлассаАнгл = "LinkLabel") Тогда
				Стр = Стр +
				"        [ContextProperty(""ОбластьСсылки"", ""LinkArea"")]
				|        public ClLinkArea LinkArea
				|        {
				|            get { return (ClLinkArea)OneScriptForms.RevertObj(Base_obj.LinkArea); }
				|            set { Base_obj.LinkArea = value.Base_obj; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Графика") и (ИмяКонтекстКлассаАнгл = "PaintEventArgs") Тогда
				Стр = Стр +
				"        [ContextProperty(""Графика"", ""Graphics"")]
				|        public ClGraphics Graphics
				|        {
				|            get { return new ClGraphics(Base_obj.Graphics); }
				|        }
				|        
				|";
			ИначеЕсли (СвойствоРус = "ТипДанных") и (ИмяКонтекстКлассаАнгл = "DataColumn") Тогда
				Стр = Стр +
				"        [ContextProperty(""ТипДанных"", ""DataType"")]
				|        public new IValue DataType
				|        {
				|            get
				|            {
				|                if (Base_obj.DataType == typeof(System.String))
				|                {
				|                    return ValueFactory.Create(0);
				|                }
				|                if (Base_obj.DataType == typeof(System.Decimal))
				|                {
				|                    return ValueFactory.Create(1);
				|                }
				|                if (Base_obj.DataType == typeof(System.Boolean))
				|                {
				|                    return ValueFactory.Create(2);
				|                }
				|                if (Base_obj.DataType == typeof(System.DateTime))
				|                {
				|                    return ValueFactory.Create(3);
				|                }
				|                if (Base_obj.DataType == typeof(System.Object))
				|                {
				|                    return ValueFactory.Create(4);
				|                }
				|                return null;
				|            }
				|            set
				|            {
				|                Base_obj.DataType = typeof(ScriptEngine.Machine.Values.StringValue);
				|                int type1 = Convert.ToInt32(value.AsNumber());
				|                if (type1 == 0)
				|                {
				|                    Base_obj.DataType = typeof(System.String);
				|                }
				|                else if (type1 == 1)
				|                {
				|                    Base_obj.DataType = typeof(System.Decimal);
				|                }
				|                else if (type1 == 2)
				|                {
				|                    Base_obj.DataType = typeof(System.Boolean);
				|                }
				|                else if (type1 == 3)
				|                {
				|                    Base_obj.DataType = typeof(System.DateTime);
				|                }
				|                else if (type1 == 4)
				|                {
				|                    Base_obj.DataType = typeof(System.Object);
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ИсточникДанных") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextProperty(""ИсточникДанных"", ""DataSource"")]
				|        public IValue DataSource
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.DataSource); }
				|            set
				|            {
				|                try
				|                {
				|                    Base_obj.DataSource = ((dynamic)value).Base_obj;
				|                }
				|                catch
				|                {
				|                    Base_obj.DataSource = null;
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ИсточникДанных") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""ИсточникДанных"", ""DataSource"")]
				|        public IValue DataSource
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.DataSource); }
				|            set
				|            {
				|                try
				|                {
				|                    Base_obj.DataSource = ((dynamic)value).Base_obj;
				|                }
				|                catch
				|                {
				|                    Base_obj.DataSource = null;
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ИсточникДанных") и (ИмяКонтекстКлассаАнгл = "ComboBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""ИсточникДанных"", ""DataSource"")]
				|        public IValue DataSource
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.DataSource); }
				|            set
				|            {
				|                try
				|                {
				|                    ArrayList ArrayList1 = Base_obj.HeightItems;
				|                    int count1 = 0;
				|                    if (value.GetType().ToString() == ""osf.ClDataTable"")
				|                    {
				|                        count1 = ((osf.ClDataTable)value).Base_obj.Rows.Count;
				|                    }
				|                    else if (value.GetType().ToString() == ""osf.ClArrayList"")
				|                    {
				|                        count1 = ((osf.ClArrayList)value).Base_obj.Count;
				|                    }
				|                    for (int i = 0; i < count1; i++)
				|                    {
				|                        ArrayList1.Add(ItemHeight);
				|                    }
				|                    Base_obj.DataSource = ((dynamic)value).Base_obj;
				|                }
				|                catch
				|                {
				|                    Base_obj.DataSource = null;
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ЗначениеПоУмолчанию") и (ИмяКонтекстКлассаАнгл = "DataColumn") Тогда
				Стр = Стр +
				"        [ContextProperty(""ЗначениеПоУмолчанию"", ""DefaultValue"")]
				|        public IValue DefaultValue
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.DefaultValue); }
				|            set
				|            {
				|                if (value.GetType().ToString().Contains(""osf.""))
				|                {
				|                    Base_obj.DefaultValue = value;
				|                }
				|                else if (value.SystemType.Name == ""Строка"")
				|                {
				|                    Base_obj.DefaultValue = value.AsString();
				|                }
				|                else if (value.SystemType.Name == ""Булево"")
				|                {
				|                    Base_obj.DefaultValue = value.AsBoolean();
				|                }
				|                else if (value.SystemType.Name == ""Дата"")
				|                {
				|                    Base_obj.DefaultValue = new System.DateTime(
				|                        value.AsDate().Year,
				|                        value.AsDate().Month,
				|                        value.AsDate().Day,
				|                        value.AsDate().Hour,
				|                        value.AsDate().Minute,
				|                        value.AsDate().Second
				|                        );
				|                }
				|                else if (value.SystemType.Name == ""Число"")
				|                {
				|                    Base_obj.DefaultValue = value.AsNumber();
				|                }
				|                else
				|                {
				|                    Base_obj.DefaultValue = value;
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли СвойствоРус = "Изображение" Тогда
				Стр = Стр +
				"        [ContextProperty(""Изображение"", ""Image"")]
				|        public ClBitmap Image
				|        {
				|            get { return (ClBitmap)OneScriptForms.RevertObj(Base_obj.Image); }
				|            set
				|            {
				|                Base_obj.Image = value.Base_obj;
				|                Base_obj.Image.dll_obj = value;
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Данные") и (ИмяКонтекстКлассаАнгл = "Link") Тогда
				Стр = Стр +
				"        [ContextProperty(""Данные"", ""LinkData"")]
				|        public IValue LinkData
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.LinkData); }
				|            set { Base_obj.LinkData = value; }
				|        }
				|
				|";
			ИначеЕсли СвойствоРус = "Е" Тогда
				Стр = Стр +
				"        [ContextProperty(""Е"", ""E"")]
				|        public double E
				|        {
				|            get { return System.Math.E; }
				|        }
				|
				|";
			ИначеЕсли СвойствоРус = "Пи" Тогда
				Стр = Стр +
				"        [ContextProperty(""Пи"", ""PI"")]
				|        public double PI
				|        {
				|            get { return System.Math.PI; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Значения") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значения"", ""Values"")]
				|        public ClArrayList Values
				|        {
				|            get
				|            {
				|                System.Collections.SortedList SortedList1 = Base_obj.M_SortedList;
				|                ArrayList ArrayList1 = new ArrayList();
				|                System.Collections.ICollection Values1 = SortedList1.Values;
				|                foreach (IValue val1 in Values1)
				|                {
				|                    ArrayList1.Add(val1);
				|                }
				|                return new ClArrayList(ArrayList1);
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Ключи") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextProperty(""Ключи"", ""Keys"")]
				|        public ClArrayList Keys
				|        {
				|            get
				|            {
				|                System.Collections.SortedList SortedList1 = Base_obj.M_SortedList;
				|                ArrayList ArrayList1 = new ArrayList();
				|                System.Collections.ICollection Keys1 = SortedList1.Keys;
				|                foreach (object key1 in Keys1)
				|                {
				|                    ArrayList1.Add(OneScriptForms.RevertObj(key1));
				|                }
				|                return new ClArrayList(ArrayList1);
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Элементы") и (ИмяКонтекстКлассаАнгл = "ComboBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""Элементы"", ""Items"")]
				|        public ClComboBoxObjectCollection Items
				|        {
				|            get
				|            {
				|                items.m_obj = this;
				|                items.heightItems = items.m_obj.Base_obj.HeightItems;
				|                return items;
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ПользовательскийФормат") и (ИмяКонтекстКлассаАнгл = "DateTimePicker") Тогда
				Стр = Стр +
				"        [ContextProperty(""ПользовательскийФормат"", ""ПользовательскийФормат"")]
				|        public string CustomFormatEn
				|        {
				|            get
				|            {
				|                string srt1 = Base_obj.CustomFormat;
				|                if (srt1.Length > 0)
				|                {
				|                    string[] result = srt1.Split('\'');
				|                    for (int i = 0; i < result.Length; i++)
				|                    {
				|                        string fragment1 = result[i];
				|                        if (fragment1 != """")
				|                        {
				|                            fragment1 = fragment1.
				|                            Replace(""y"", ""г"").
				|                            Replace(""M"", ""М"").
				|                            Replace(""d"", ""д"").
				|                            Replace(""h"", ""ч"").
				|                            Replace(""H"", ""Ч"").
				|                            Replace(""m"", ""м"").
				|                            Replace(""s"", ""с"").
				|                            Replace(""t"", ""в"");
				|                            srt1 = srt1.Replace(result[i], fragment1);
				|                        }
				|                        i = i + 1;
				|                    }
				|                }
				|                return srt1;
				|            }
				|            set
				|            {
				|                string srt1 = value;
				|                string[] result = srt1.Split('\'');
				|                for (int i = 0; i < result.Length; i++)
				|                {
				|                    string fragment1 = result[i];
				|                    if (fragment1 != """")
				|                    {
				|                        fragment1 = fragment1.
				|                        Replace(""г"", ""y"").
				|                        Replace(""М"", ""M"").
				|                        Replace(""д"", ""d"").
				|                        Replace(""ч"", ""h"").
				|                        Replace(""Ч"", ""H"").
				|                        Replace(""м"", ""m"").
				|                        Replace(""с"", ""s"").
				|                        Replace(""в"", ""t"");
				|                        srt1 = srt1.Replace(result[i], fragment1);
				|                    }
				|                    i = i + 1;
				|                }
				|                Base_obj.CustomFormat = srt1;
				|            }
				|        }
				|
				|        [ContextProperty(""CustomFormat"", ""CustomFormat"")]
				|        public string CustomFormatRu
				|        {
				|            get { return Base_obj.CustomFormat; }
				|            set
				|            {
				|                string srt1 = value;
				|                string[] result = srt1.Split('\'');
				|                for (int i = 0; i < result.Length; i++)
				|                {
				|                    string fragment1 = result[i];
				|                    if (fragment1 != """")
				|                    {
				|                        fragment1 = fragment1.
				|                        Replace(""г"", ""y"").
				|                        Replace(""М"", ""M"").
				|                        Replace(""д"", ""d"").
				|                        Replace(""ч"", ""h"").
				|                        Replace(""Ч"", ""H"").
				|                        Replace(""м"", ""m"").
				|                        Replace(""с"", ""s"").
				|                        Replace(""в"", ""t"");
				|                        srt1 = srt1.Replace(result[i], fragment1);
				|                    }
				|                    i = i + 1;
				|                }
				|                Base_obj.CustomFormat = srt1;
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Значение") и (ИмяКонтекстКлассаАнгл = "DataItem") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значение"", ""Value"")]
				|        public IValue Value
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Value); }
				|            set
				|            {
				|                Base_obj.Value = OneScriptForms.DefineTypeIValue(value);
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Увеличение") и (ИмяКонтекстКлассаАнгл = "NumericUpDown") Тогда
				Стр = Стр +
				"        [ContextProperty(""Увеличение"", ""Increment"")]
				|        public IValue Increment
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Increment); }
				|            set { Base_obj.Increment = value.AsNumber(); }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Масштаб") и (ИмяКонтекстКлассаАнгл = "RichTextBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""Масштаб"", ""ZoomFactor"")]
				|        public IValue ZoomFactor
				|        {
				|            get { return ValueFactory.Create(Convert.ToDecimal(Base_obj.ZoomFactor)); }
				|            set { Base_obj.ZoomFactor = Convert.ToSingle(value.AsNumber()); }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Значение") и (ИмяКонтекстКлассаАнгл = "NumericUpDown") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значение"", ""Value"")]
				|        public IValue Value
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Value); }
				|            set { Base_obj.Value = value.AsNumber(); }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Максимум") и (ИмяКонтекстКлассаАнгл = "NumericUpDown") Тогда
				Стр = Стр +
				"        [ContextProperty(""Максимум"", ""Maximum"")]
				|        public IValue Maximum
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Maximum); }
				|            set { Base_obj.Maximum = value.AsNumber(); }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Минимум") и (ИмяКонтекстКлассаАнгл = "NumericUpDown") Тогда
				Стр = Стр +
				"        [ContextProperty(""Минимум"", ""Minimum"")]
 				|       public IValue Minimum
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Minimum); }
				|            set { Base_obj.Minimum = value.AsNumber(); }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Выравнивание") и (ИмяКонтекстКлассаАнгл = "DataGridBoolColumn") Тогда
				Стр = Стр +
				"        [ContextProperty(""Выравнивание"", ""Alignment"")]
				|        public int Alignment
				|        {
				|            get { return (int)Base_obj.Alignment; }
				|            set { Base_obj.Alignment = value; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Выравнивание") и (ИмяКонтекстКлассаАнгл = "DataGridComboBoxColumnStyle") Тогда
				Стр = Стр +
				"        [ContextProperty(""Выравнивание"", ""Alignment"")]
				|        public int Alignment
				|        {
				|            get { return (int)Base_obj.Alignment; }
				|            set { Base_obj.Alignment = (System.Windows.Forms.HorizontalAlignment)value; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ТекущаяЯчейка") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextProperty(""ТекущаяЯчейка"", ""CurrentCell"")]
				|        public ClDataGridCell CurrentCell
				|        {
				|            get { return new ClDataGridCell(Base_obj.CurrentCell); }
				|            set { Base_obj.CurrentCell = value.Base_obj; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Ключ") и (ИмяКонтекстКлассаАнгл = "DictionaryEntry") Тогда
				Стр = Стр +
				"        [ContextProperty(""Ключ"", ""Key"")]
				|        public IValue Key
				|        {
				|            get { return OneScriptForms.RevertObj(Base_obj.Key); }
				|            set { Base_obj.Key = value; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ВыбранноеЗначение") и (ИмяКонтекстКлассаАнгл = "ComboBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВыбранноеЗначение"", ""SelectedValue"")]
				|        public IValue SelectedValue
				|        {
				|            get { return (IValue)OneScriptForms.RevertObj(Base_obj.SelectedValue); }
				|            set { Base_obj.SelectedValue = value; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ВыбранноеЗначение") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextProperty(""ВыбранноеЗначение"", ""SelectedValue"")]
				|        public IValue SelectedValue
				|        {
				|            get { return (IValue)OneScriptForms.RevertObj(Base_obj.SelectedValue); }
				|            set { Base_obj.SelectedValue = value; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ПолеВвода") и (ИмяКонтекстКлассаАнгл = "DataGridTextBoxColumn") Тогда
				Стр = Стр +
				"        [ContextProperty(""ПолеВвода"", ""TextBox"")]
				|        public ClDataGridTextBox TextBox
				|        {
				|            get { return new ClDataGridTextBox(Base_obj.TextBox); }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Значения") и (ИмяКонтекстКлассаАнгл = "HashTable") Тогда
				Стр = Стр +
				"        [ContextProperty(""Значения"", ""Values"")]
				|        public ClArrayList Values
				|        {
				|            get
				|            {
				|                System.Collections.Hashtable Hashtable1 = (System.Collections.Hashtable)Base_obj.M_HashTable;
				|                osf.ArrayList ArrayList1 = new osf.ArrayList();
				|                System.Collections.ICollection Values1 = Hashtable1.Values;
				|                foreach (IValue val1 in Values1)
				|                {
				|                    ArrayList1.Add(val1);
				|                }
				|                return new ClArrayList(ArrayList1);
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "Ключи") и (ИмяКонтекстКлассаАнгл = "HashTable") Тогда
				Стр = Стр +
				"        [ContextProperty(""Ключи"", ""Keys"")]
				|        public ClArrayList Keys
				|        {
				|            get
				|            {
				|                System.Collections.Hashtable Hashtable1 = (System.Collections.Hashtable)Base_obj.M_HashTable;
				|                osf.ArrayList ArrayList1 = new osf.ArrayList();
				|                System.Collections.ICollection Keys1 = Hashtable1.Keys;
				|                foreach (IValue key1 in Keys1)
				|                {
				|                    ArrayList1.Add(key1);
				|                }
				|                return new ClArrayList(ArrayList1);
				|            }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ОсновнойЭкран") и (ИмяКонтекстКлассаАнгл = "Screen") Тогда
				Стр = Стр +
				"        [ContextProperty(""ОсновнойЭкран"", ""PrimaryScreen"")]
				|        public ClScreen PrimaryScreen
				|        {
				|            get { return new ClScreen(Base_obj.PrimaryScreen); }
				|        }
				|
				|";
			ИначеЕсли СвойствоРус = "ФоновоеИзображение" Тогда
				Стр = Стр +
				"        [ContextProperty(""ФоновоеИзображение"", ""BackgroundImage"")]
				|        public ClBitmap BackgroundImage
				|        {
				|            get { return new ClBitmap(Base_obj.BackgroundImage); }
				|            set { Base_obj.BackgroundImage = value.Base_obj; }
				|        }
				|
				|";
			ИначеЕсли (СвойствоРус = "ПредставлениеПоУмолчанию") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextProperty(""ПредставлениеПоУмолчанию"", ""DefaultView"")]
				|        public ClDataView DefaultView
				|        {
				|            get { return new ClDataView(Base_obj.DefaultView); }
				|        }
				|
				|";
				
				
				
				
				
				
				
				
				
				
				
				
			Иначе	
				//находим ТипВозвращаемогоЗначения
				СтрРаздела = СтрНайтиМежду(СтрТекстДокСвойства, "<H4 class=dtH4>Значение</H4>", "<H4 class=dtH4>Примечание</H4>", , )[0];
				СтрЗначение = СтрНайтиМежду(СтрРаздела, "<P>", "</P>", , )[0];
				М09 = СтрНайтиМежду(СтрЗначение, "(", ")", , );
				Если М09.Количество() > 0 Тогда
					ТипВозвращаемогоЗначения = М09[0];
				Иначе
					ТипВозвращаемогоЗначения = СтрЗаменить(СтрЗначение, "Тип: ", "");
				КонецЕсли;
				// Сообщить(ТипВозвращаемогоЗначения);
				// // // // Строка.
				// // // // Число.
				// // // // Булево.
				// // // // Дата.
				// // // // Произвольный.
				ВозвратГет = "хххх";
				ВозвратСет = "хххх";
				Комментарий = "//";
				Если ТипВозвращаемогоЗначения = "Число." Тогда/////////////////////////////////////////////////
					ТипВозвращаемогоЗначения = "int";
					ВозвратГет = "    get { return Base_obj." + СвойствоАнгл + "; }";
					ВозвратСет = "    set { Base_obj." + СвойствоАнгл + " = value; }";
					Комментарий = "";
				ИначеЕсли ТипВозвращаемогоЗначения = "Строка." Тогда////////////////////////////////////////////
					ТипВозвращаемогоЗначения = "string";
					ВозвратГет = "    get { return Base_obj." + СвойствоАнгл + "; }";
					ВозвратСет = "    set { Base_obj." + СвойствоАнгл + " = value; }";
					Комментарий = "";
				ИначеЕсли ТипВозвращаемогоЗначения = "Булево." Тогда////////////////////////////////////////////
					ТипВозвращаемогоЗначения = "bool";
					ВозвратГет = "    get { return Base_obj." + СвойствоАнгл + "; }";
					ВозвратСет = "    set { Base_obj." + СвойствоАнгл + " = value; }";
					Комментарий = "";
				ИначеЕсли ТипВозвращаемогоЗначения = "Дата." Тогда///////////////////////////////////////////////
					ТипВозвращаемогоЗначения = "DateTime";
					ВозвратГет = "    get { return Base_obj." + СвойствоАнгл + "; }";
					ВозвратСет = "    set { Base_obj." + СвойствоАнгл + " = value; }";
					Комментарий = "";
				ИначеЕсли ТипВозвращаемогоЗначения = "Произвольный." Тогда
					ТипВозвращаемогоЗначения = "dynamic";
					ВозвратГет = "    get { return Base_obj." + СвойствоАнгл + "; }";
					ВозвратСет = "    set { Base_obj." + СвойствоАнгл + " = value; }";
					
				Иначе // ТипВозвращаемогоЗначения это экземпляр класса
					Комментарий = "";
					ШаблонДляГетСет = "ОбщийШаблон";
					Если Не (М_СтрПеречислений.Найти(ТипВозвращаемогоЗначения) = Неопределено) Тогда //ТипВозвращаемогоЗначения это перечисление
						ТипВозвращаемогоЗначения = "int";
						ШаблонДляГетСет = "ШаблонДляПеречисления";
					ИначеЕсли ТипВозвращаемогоЗначения = "GridColumnStylesCollection" или //ТипВозвращаемогоЗначения это не перечисление
							ТипВозвращаемогоЗначения = "TreeNodeCollection" или
							ТипВозвращаемогоЗначения = "ListViewSubItemCollection" или
							ТипВозвращаемогоЗначения = "ListViewItemCollection" или
							ТипВозвращаемогоЗначения = "ListViewCheckedItemCollection" или
							ТипВозвращаемогоЗначения = "ListViewColumnHeaderCollection" или
							ТипВозвращаемогоЗначения = "ListViewSelectedItemCollection" или
							ТипВозвращаемогоЗначения = "ListBoxObjectCollection" или
							ТипВозвращаемогоЗначения = "ListBoxSelectedIndexCollection" или
							ТипВозвращаемогоЗначения = "ImageCollection" или
							ТипВозвращаемогоЗначения = "GridItemCollection" или
							ТипВозвращаемогоЗначения = "DataRowCollection" или
							ТипВозвращаемогоЗначения = "DataColumnCollection" или
							ТипВозвращаемогоЗначения = "DataTableCollection" или
							ТипВозвращаемогоЗначения = "ToolBarButtonCollection" или
							ТипВозвращаемогоЗначения = "MenuItemCollection" или
							ТипВозвращаемогоЗначения = "TabPageCollection" или
							ТипВозвращаемогоЗначения = "ControlCollection" или
							ТипВозвращаемогоЗначения = "DockPaddingEdges" или
							ТипВозвращаемогоЗначения = "LinkCollection" или
							ТипВозвращаемогоЗначения = "StatusBarPanelCollection" или
							ТипВозвращаемогоЗначения = "GridTableStylesCollection" Тогда
						ТипВозвращаемогоЗначения = "Cl" + ТипВозвращаемогоЗначения;
						ШаблонДляГетСет = "ШаблонДляКоллекций";
					ИначеЕсли (ТипВозвращаемогоЗначения = "Color") Тогда
						ТипВозвращаемогоЗначения = "Cl" + ТипВозвращаемогоЗначения;
						Если (ИмяКонтекстКлассаАнгл = "Color") или
							(ИмяКонтекстКлассаАнгл = "FontDialog") Тогда
							ШаблонДляГетСет = "ОбщийШаблон";
						Иначе
							ШаблонДляГетСет = "ШаблонДляНекоторыхКлассов";
						КонецЕсли;
					ИначеЕсли (ТипВозвращаемогоЗначения = "Rectangle") Тогда
						ТипВозвращаемогоЗначения = "Cl" + ТипВозвращаемогоЗначения;
						Если (ИмяКонтекстКлассаАнгл = "ToolBarButton") Тогда
							ШаблонДляГетСет = "ОбщийШаблон";
						ИначеЕсли (Прав(ИмяКонтекстКлассаАнгл, 4) <> "Args") Тогда
							ШаблонДляГетСет = "ШаблонДляНекоторыхКлассов";
						КонецЕсли;
					ИначеЕсли (ТипВозвращаемогоЗначения = "ImageList") Тогда
						ТипВозвращаемогоЗначения = "Cl" + ТипВозвращаемогоЗначения;
						ШаблонДляГетСет = "ОбщийШаблон";
					ИначеЕсли (ТипВозвращаемогоЗначения = "Icon") или
							(ТипВозвращаемогоЗначения = "Font") Тогда
						ТипВозвращаемогоЗначения = "Cl" + ТипВозвращаемогоЗначения;
						ШаблонДляГетСет = "ШаблонДляКлассовЧерезHashtable";
					Иначе
						ТипВозвращаемогоЗначения = "Cl" + ТипВозвращаемогоЗначения;
					КонецЕсли;
					
					Если ШаблонДляГетСет = "ШаблонДляКоллекций" Тогда
						// gridColumnStyles = new ClGridColumnStylesCollection(Base_obj.GridColumnStyles);
						// public ClGridColumnStylesCollection gridColumnStyles;
						// [ContextProperty("СтилиКолонкиСеткиДанных", "GridColumnStyles")]
						// public ClGridColumnStylesCollection GridColumnStyles
						// {
							// get { return gridColumnStyles; }
						// }
						ПриватСвойство = НРег(Лев(СвойствоАнгл, 1)) + Сред(СвойствоАнгл, 2);
						СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + Символы.ПС +
						"        private " + ТипВозвращаемогоЗначения + " " + ПриватСвойство + ";";
						СтрКонструктор = СтрЗаменить(СтрКонструктор, 
						"        }//end_constr"
						, 
						"            " + ПриватСвойство + " = new " + ТипВозвращаемогоЗначения + "(Base_obj." + СвойствоАнгл + ");
						|        }//end_constr"
						);
						ВозвратГет = "    " + Комментарий + "get { return " + ПриватСвойство + "; }";
						ВозвратСет = "    " + Комментарий + "set { " + ПриватСвойство + " = new " + ТипВозвращаемогоЗначения + "(value.Base_obj); }";
					ИначеЕсли ШаблонДляГетСет = "ШаблонДляНекоторыхКлассов" Тогда
						// backColor = new ClColor(Base_obj.BackColor);
						// public ClColor backColor;
						// public ClColor BackColor
						// {
							// get { return backColor; }
							// set
							// {
								// backColor = value;
								// Base_obj.BackColor = value.Base_obj;
							// }
						// }
						ПриватСвойство = НРег(Лев(СвойствоАнгл, 1)) + Сред(СвойствоАнгл, 2);
						СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + Символы.ПС +
						"        private " + ТипВозвращаемогоЗначения + " " + ПриватСвойство + ";";
						СтрКонструктор = СтрЗаменить(СтрКонструктор, 
						"        }//end_constr"
						, 
						"            " + ПриватСвойство + " = new " + ТипВозвращаемогоЗначения + "(Base_obj." + СвойствоАнгл + ");
						|        }//end_constr"
						);
						ВозвратГет = "    " + Комментарий + "get { return " + ПриватСвойство + "; }";
						ВозвратСет = "    " + Комментарий + "set 
						|            {
						|                " + ПриватСвойство + " = value;
						|                Base_obj." + СвойствоАнгл + " = value.Base_obj;
						|            }";
					ИначеЕсли ШаблонДляГетСет = "ШаблонДляКлассовЧерезHashtable" Тогда
						// get
						// {
							// return (ClIcon)OneScriptForms.RevertObj(Base_obj.Icon, "StatusBarPanel.Значок");
						// }
						// set
						// {
							// Base_obj.Icon = value.Base_obj;
							// Base_obj.Icon.dll_obj = value;
						// }
						ВозвратГет = "    " + Комментарий + "get { return (" + ТипВозвращаемогоЗначения + ")OneScriptForms.RevertObj(Base_obj." + СвойствоАнгл + "); }";
						ВозвратСет = "    " + Комментарий + "set 
						|            {
						|                Base_obj." + СвойствоАнгл + " = value.Base_obj; 
						|                Base_obj." + СвойствоАнгл + ".dll_obj = value;
						|            }";
					ИначеЕсли ШаблонДляГетСет = "ШаблонДляПеречисления" Тогда
						// get { return (int)Base_obj.TextAlign; }
						// set { Base_obj.TextAlign = value; }
						ВозвратГет = "    get { return (int)Base_obj." + СвойствоАнгл + "; }";          
						ВозвратСет = "    set { Base_obj." + СвойствоАнгл + " = value; }";
					ИначеЕсли ШаблонДляГетСет = "ОбщийШаблон" Тогда
						// get { return (ClDataGridCell)OneScriptForms.RevertObj(Base_obj.CurrentCell); }
						// set { Base_obj.Bounds = value.Base_obj; }
						ВозвратГет = "    " + Комментарий + "get { return (" + ТипВозвращаемогоЗначения + ")OneScriptForms.RevertObj(Base_obj." + СвойствоАнгл + "); }";
						ВозвратСет = "    " + Комментарий + "set { Base_obj." + СвойствоАнгл + " = value.Base_obj; }";
					КонецЕсли;
				КонецЕсли;

				Стр = Стр +
				"        " + Комментарий + "[ContextProperty(""" + СвойствоРус + """, """ + СвойствоАнгл + """)]" + Символы.ПС + 
				"        " + Комментарий + "public " + ТипВозвращаемогоЗначения + " " + СвойствоАнгл + Символы.ПС + 
				"        " + Комментарий + "{" + Символы.ПС;
				//находим есть ли set get
				Если СтрИспользование = "Чтение и запись." Тогда
					Стр = Стр +
					"        " + Комментарий + ВозвратГет + Символы.ПС +
					"        " + Комментарий + ВозвратСет + Символы.ПС;
				Иначе
					Стр = Стр +
					"        " + Комментарий + ВозвратГет + Символы.ПС;
				КонецЕсли;
				Стр = Стр +
				"        " + Комментарий + "}" + Символы.ПС + Символы.ПС;
			КонецЕсли;
		КонецЦикла;
	Иначе
		Стр = 
		"        //Свойства============================================================" + Символы.ПС;
	КонецЕсли;
	
	Возврат Стр;
КонецФункции//Свойства

Функция ПеречисленияКакСвойства(ИмяФайлаЧленов)
	Если Не (ИмяФайлаЧленов = "C:\444\OneScriptFormsru\OneScriptForms.OneScriptFormsMembers.html") Тогда
		Возврат "";
	КонецЕсли;
	
	// // // СписокПолей2 = Новый СписокЗначений;
	СписокПереч2 = Новый СписокЗначений;
	// // // ТекстДок = Новый ТекстовыйДокумент;
	// // // ТекстДок.Прочитать("C:\444\OneScriptFormsru\OneScriptForms.OneScriptFormsFields.html");
	// // // Стр = ТекстДок.ПолучитьТекст();
	// // // //находим строку таблицы
	// // // М48 = СтрНайтиМежду(Стр, "<TR vAlign=top>" + Символы.ПС + "    <TD", "</TD></TR>", Ложь, );
	// // // Для А61 = 0 По М48.ВГраница() Цикл
		// // // СтрТабл = М48[А61];
		// // // СтрТабл = СтрЗаменить(СтрТабл, "&nbsp;", " ");
		// // // // Сообщить("-СтрТабл-----------------------");
		// // // // Сообщить("" + СтрТабл);
		// // // Предст2 = СтрНайтиМежду(СтрТабл, ".html"">", " ", , )[0];
		// // // Знач2 = СтрНайтиМежду(СтрТабл, "(", ")", , )[0];
		// // // СписокПолей2.Добавить(Знач2, Предст2);
	// // // КонецЦикла;
	// // // // Для А = 0 По СписокПолей2.Количество() - 1 Цикл
		// // // // Сообщить("" + СписокПолей2.Получить(А).Представление + " -- " + СписокПолей2.Получить(А).Значение);
	// // // // КонецЦикла;
	
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptFormsru\OneScriptForms.html");
	Стр = ТекстДок.ПолучитьТекст();
	//находим строку таблицы
	СтрТаблПереч = СтрНайтиМежду(Стр, "<H3 class=dtH3>Перечисления</H3>", "</TBODY></TABLE>", Ложь, )[0];
	М48 = СтрНайтиМежду(СтрТаблПереч, "<TR vAlign=top>" + Символы.ПС + "    <TD", "</TD></TR>", Ложь, );
	Для А61 = 0 По М48.ВГраница() Цикл
		СтрТабл = М48[А61];
		СтрТабл = СтрЗаменить(СтрТабл, "&nbsp;", " ");
		// Сообщить("-СтрТабл-----------------------");
		// Сообщить("" + СтрТабл);
		Предст2 = СтрНайтиМежду(СтрТабл, ".html"">", " ", , )[0];
		Знач2 = СтрНайтиМежду(СтрТабл, "(", ")", , )[0];
		СписокПереч2.Добавить(Знач2, Предст2);
	КонецЦикла;
	// Для А = 0 По СписокПереч2.Количество() - 1 Цикл
		// Сообщить("" + СписокПереч2.Получить(А).Представление + " -- " + СписокПереч2.Получить(А).Значение);
	// КонецЦикла;
	Стр = "" + Символы.ПС + "        //ПеречисленияКакСвойства============================================================" + Символы.ПС;
	// // // Для А = 0 По СписокПолей2.Количество() - 1 Цикл
		// // // // Сообщить("" + СписокПолей2.Получить(А).Представление + " -- " + СписокПолей2.Получить(А).Значение);
		// // // Знач4 = СписокПолей2.Получить(А).Значение;
		// // // Предст4 = СписокПолей2.Получить(А).Представление;
		// // // Стр = Стр + Символы.ПС + 
		// // // "        [ContextProperty(""" + Предст4 + """, """ + Знач4 + """)]
		// // // |        public int Cl" + Знач4 + "1
		// // // |        {
		// // // |            get { return cl_" + Знач4 + "; }
		// // // |        }" + Символы.ПС;
		// // // СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + Символы.ПС +
		// // // "        private int cl_" + Знач4 + " = cl_" + СтрЗаменить(Знач4, "_", ".") + ";";
	// // // КонецЦикла;
	
	Для А = 0 По СписокПереч2.Количество() - 1 Цикл
		// Сообщить("" + СписокПереч2.Получить(А).Представление + " -- " + СписокПереч2.Получить(А).Значение);
		Знач3 = СписокПереч2.Получить(А).Значение;
		Предст3 = СписокПереч2.Получить(А).Представление;
		// Сообщить("Знач3 - " + Знач3 + " Предст3 - " + Предст3);
		СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + Символы.ПС +
		"        private static Cl" + Знач3 + " cl_" + Знач3 + " = new Cl" + Знач3 + "();";
		
		Стр = Стр + Символы.ПС + 
		"        [ContextProperty(""" + Предст3 + """, """ + Знач3 + """)]
		|        public Cl" + Знач3 + " " + Знач3 + "
		|        {
		|            get { return cl_" + Знач3 + "; }
		|        }" + Символы.ПС;
	КонецЦикла;
		Стр = Стр + Символы.ПС;
	Возврат Стр;
	
КонецФункции//ПеречисленияКакСвойства

Функция Методы(ИмяФайлаЧленов, ИмяКонтекстКлассаАнгл)
	ТекстДокЧленов = Новый ТекстовыйДокумент;
	КаталогНаДиске = Новый Файл(ИмяФайлаЧленов);
    Если Не (КаталогНаДиске.Существует()) Тогда
        Стр = 
		"        //Методы============================================================" + Символы.ПС;
		Возврат Стр;
	КонецЕсли;
	ТекстДокЧленов.Прочитать(ИмяФайлаЧленов);
	СтрТекстДокЧленов = ТекстДокЧленов.ПолучитьТекст();
	Если Не (СтрНайтиМежду(СтрТекстДокЧленов, "<H4 class=dtH4>Методы</H4>", "</TBODY></TABLE>", Ложь, ).Количество() > 0) Тогда
		Стр = 
		"        //Методы============================================================" + Символы.ПС;
		Возврат Стр;
	КонецЕсли;
	СтрТаблицаЧленов = СтрНайтиМежду(СтрТекстДокЧленов, "<H4 class=dtH4>Методы</H4>", "</TBODY></TABLE>", Ложь, )[0];
	Массив1 = СтрНайтиМежду(СтрТаблицаЧленов, "<TR vAlign=top>", "</TD></TR>", Ложь, );
	//переберем строки таблицы
	Если Массив1.Количество() > 0 Тогда
		Стр = "        //Методы============================================================" + Символы.ПС;
		Для А = 0 По Массив1.ВГраница() Цикл
			//найдем первую ячейку строки таблицы
			М07 = СтрНайтиМежду(Массив1[А], "<TD width=""50%"">", "</TD>", Ложь, );
			СтрХ = М07[0];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			МетодАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			// // // Сообщить("-ИмяФайлаЧленов---------------------------");
			// // // Сообщить("" + ИмяФайлаЧленов);
			// // // Сообщить("-МетодАнгл---------------------------");
			// // // Сообщить("" + МетодАнгл);
			МетодРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			Если (МетодРус = "ПолучитьСобытие") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр + 
				"        [ContextMethod(""ПолучитьСобытие"", ""DoEvents"")]
				|        public string DoEvents()
				|        {
				|            EventString = """";
				|            EventHandling();
				|            return EventString;
				|        }
				|
				|        public static void EventHandling()
				|        {
				|            while (EventString == """")
				|            {
				|                if (EventQueue.Count > 0)
				|                {
				|                    dynamic EventArgs1 = (dynamic)EventQueue[0];
				|                    Event = EventArgs1.dll_obj;
				|                    EventString = EventArgs1.EventString;
				|                    EventQueue.RemoveAt(0);
				|                }
				|                else
				|                {
				|                    WaitMessage();
				|                    System.Windows.Forms.Application.DoEvents();
				|                }
				|            }
				|        }
				|        //Функция WaitMessage передает управление к другим потокам тогда, когда поток не имеет никаких других сообщений 
				|        //в своей очереди сообщений. Функция WaitMessage приостанавливает работу потока и не возвращает управление до 
				|        //тех пор, пока не будет помещено новое сообщение в очередь сообщений потока.
				|        //При вызове DoEvents в коде, приложение может выполнять другие события. Например, если имеется форма, добавляющая 
				|        //данные в ListBox, добавление DoEvents в код позволит форме перерисовывается при перетаскивании над ней другого окна. 
				|        //Если удалить DoEvents из кода, форма не будет перерисовываться до завершения выполнения обработчика события.
				|        //DoEvents передает управление Windows-у чтобы тот выполнил обработку своих событий
				|        
				|";
			ИначеЕсли (МетодРус = "ДоступностьВизуальныхСтилей") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ДоступностьВизуальныхСтилей"", ""EnableVisualStyles"")]
				|        public void EnableVisualStyles()
				|        {
				|            System.Windows.Forms.Application.EnableVisualStyles();
				|            System.Windows.Forms.Application.DoEvents();
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "УстановитьИндексДочернего") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьИндексДочернего"", ""SetChildIndex"")]
				|        public void SetChildIndex(IValue p1, int p2)
				|        {
				|            Base_obj.SetChildIndex(((osf.Control)((dynamic)p1).Base_obj), p2);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ВоспроизвестиСистемныйЗвук" Тогда
				Стр = Стр +
				"        [ContextMethod(""ВоспроизвестиСистемныйЗвук"", ""PlaySystem"")]
				|        public void PlaySystem(int p1)
				|        {
				|            if (p1 == 0)
				|            {
				|                System.Media.SystemSounds.Question.Play();
				|            }
				|            else if (p1 == 1)
				|            {
				|                System.Media.SystemSounds.Exclamation.Play();
				|            }
				|            else if (p1 == 2)
				|            {
				|                System.Media.SystemSounds.Beep.Play();
				|             }
				|             else if (p1 == 3)
				|             {
				|                 System.Media.SystemSounds.Asterisk.Play();
				|             }
				|             else if (p1 == 4)
				|             {
				|                 System.Media.SystemSounds.Hand.Play();
				|             }
				|         }
				|        
				|";
			ИначеЕсли МетодРус = "Выше" Тогда
				Стр = Стр +
				"        [ContextMethod(""Выше"", ""PlaceTop"")]
				|        public void PlaceTop(IValue p1, int p2)
				|        {
				|            dynamic p3 = ((dynamic)p1).Base_obj;
				|            Base_obj.Location = new Point(p3.Left, p3.Top - Base_obj.Height - p2);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Левее" Тогда
				Стр = Стр +
				"        [ContextMethod(""Левее"", ""PlaceLeft"")]
				|        public void PlaceLeft(IValue p1, int p2)
				|        {
				|            dynamic p3 = ((dynamic)p1).Base_obj;
				|            Base_obj.Location = new Point(p3.Left - Base_obj.Width - p2, p3.Top);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Ниже" Тогда
				Стр = Стр +
				"        [ContextMethod(""Ниже"", ""PlaceBottom"")]
				|        public void PlaceBottom(IValue p1, int p2)
				|        {
				|            dynamic p3 = ((dynamic)p1).Base_obj;
				|            Base_obj.Location = new Point(p3.Left, p3.Top + p3.Height + p2);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Правее" Тогда
				Стр = Стр +
				"        [ContextMethod(""Правее"", ""PlaceRight"")]
				|        public void PlaceRight(IValue p1, int p2)
				|        {
				|            dynamic p3 = ((dynamic)p1).Base_obj;
				|            Base_obj.Location = new Point(p3.Right + p2, p3.Top);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ЗакрепитьНаРабочемСтоле" Тогда
				СтрРазделОбъявленияПеременных = СтрРазделОбъявленияПеременных + Символы.ПС +
				"        [DllImport(""user32.dll"", SetLastError = true)] static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
				|        [DllImport(""user32.dll"")] static extern int SetParent(int hWndChild, int hWndNewParent);";
				Стр = Стр +
				"        [ContextMethod(""ЗакрепитьНаРабочемСтоле"", ""PinToDesktop"")]
				|        public void PinToDesktop()
				|        {
				|            IntPtr hWnd = Base_obj.M_Form.Handle;
				|            IntPtr hWndProgMan = FindWindow(""Progman"", ""Program Manager"");
				|            SetParent(hWnd.ToInt32(), hWndProgMan.ToInt32());
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ОткрепитьОтРабочегоСтола" Тогда
				Стр = Стр +
				"        [ContextMethod(""ОткрепитьОтРабочегоСтола"", ""UnpinFromDesktop"")]
				|        public void UnpinFromDesktop()
				|        {
				|            IntPtr hWnd = Base_obj.M_Form.Handle;
				|            SetParent(hWnd.ToInt32(), IntPtr.Zero.ToInt32());
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ЗаполнитьПрямоугольник") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗаполнитьПрямоугольник"", ""FillRectangle"")]
				|        public void FillRectangle(IValue p1, IValue p2, IValue p3, IValue p4, IValue p5)
				|        {
				|            Base_obj.FillRectangle(((dynamic)p1).Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "КопироватьСЭкрана") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""КопироватьСЭкрана"", ""CopyFromScreen"")]
				|        public void CopyFromScreen(int p1, int p2, int p3, int p4, ClSize p5)
				|        {
				|            Base_obj.CopyFromScreen(p1, p2, p3, p4, p5.Base_obj);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Масштабировать") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""Масштабировать"", ""ScaleTransform"")]
				|        public void ScaleTransform(IValue p1, IValue p2)
				|        {
				|            Base_obj.ScaleTransform(Convert.ToSingle(p1.AsNumber()), Convert.ToSingle(p2.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Повернуть") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""Повернуть"", ""RotateTransform"")]
				|        public void RotateTransform(IValue p1)
				|        {
				|            Base_obj.RotateTransform(Convert.ToSingle(p1.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "РисоватьИзображение") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""РисоватьИзображение"", ""DrawImage"")]
				|        public void DrawImage(ClBitmap p1, IValue p2, IValue p3, IValue p4, IValue p5)
				|        {
				|            Base_obj.DrawImage(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Перо" Тогда
				Стр = Стр +
				"        [ContextMethod(""Перо"", ""Pen"")]
				|        public ClPen Pen(ClColor p1, IValue p2 = null)
				|        {
				|            float _p2;
				|            if (p2 == null)
				|            {
				|                _p2 = 1.0f;
				|            }
				|            else
				|            {
				|                _p2 = Convert.ToSingle(p2.AsNumber());
				|            }
				|            return new ClPen(p1, _p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "РисоватьЛинию") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""РисоватьЛинию"", ""DrawLine"")]
				|        public void DrawLine(ClPen p1, IValue p2, IValue p3, IValue p4, IValue p5)
				|        {
				|            Base_obj.DrawLine(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "РисоватьПрямоугольник") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""РисоватьПрямоугольник"", ""DrawRectangle"")]
				|        public void DrawRectangle(ClPen p1, IValue p2, IValue p3, IValue p4, IValue p5)
				|        {
				|            Base_obj.DrawRectangle(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "РисоватьСтроку") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""РисоватьСтроку"", ""DrawString"")]
				|        public void DrawString(string p1, ClFont p2, IValue p3, IValue p4, IValue p5)
				|        {
				|            Base_obj.DrawString(p1, p2.Base_obj, ((dynamic)p3).Base_obj, Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "РисоватьЭлипс") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""РисоватьЭлипс"", ""DrawEllipse"")]
				|        public void DrawEllipse(ClPen p1, IValue p2, IValue p3, IValue p4, IValue p5)
				|        {
				|            Base_obj.DrawEllipse(p1.Base_obj, Convert.ToSingle(p2.AsNumber()), Convert.ToSingle(p3.AsNumber()), Convert.ToSingle(p4.AsNumber()), Convert.ToSingle(p5.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Сдвинуть") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""Сдвинуть"", ""TranslateTransform"")]
				|        public void TranslateTransform(IValue p1, IValue p2)
				|        {
				|            Base_obj.TranslateTransform(Convert.ToSingle(p1.AsNumber()), Convert.ToSingle(p2.AsNumber()));
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Тип" Тогда
				Стр = Стр +
				"        [ContextMethod(""Тип"", ""Type"")]
				|        public ClType Type(IValue p1)
				|        {
				|            return new ClType(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "НайтиЭлемент" Тогда
				Стр = Стр +
				"        [ContextMethod(""НайтиЭлемент"", ""FindControl"")]
				|        public IValue FindControl(string p1)
				|        {
				|            return OneScriptForms.RevertObj(Base_obj.FindControl(p1));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ЗакодироватьВСтроку") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗакодироватьВСтроку"", ""ToBase64String"")]
				|        public string ToBase64String(ClImageFormat p1 = null)
				|        {
				|            if (p1 == null)
				|            {
				|                return Base_obj.ToBase64String();
				|            }
				|            return Base_obj.ToBase64String(p1.Base_obj);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "НайтиФорму" Тогда
				Стр = Стр +
				"        [ContextMethod(""НайтиФорму"", ""FindForm"")]
				|        public ClForm FindForm()
				|        {
				|            if (Base_obj.FindForm() != null)
				|            {
				|                return Base_obj.FindForm().dll_obj;
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ДочернийПоКоординатам" Тогда
				Стр = Стр +
				"        [ContextMethod(""ДочернийПоКоординатам"", ""GetChildAtPoint"")]
				|        public IValue GetChildAtPoint(ClPoint p1)
				|        {
				|            return ((dynamic)Base_obj.GetChildAtPoint(p1.Base_obj)).dll_obj;
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "СледующийЭлемент" Тогда
				Стр = Стр +
				"        [ContextMethod(""СледующийЭлемент"", ""GetNextControl"")]
				|        public IValue GetNextControl(IValue p1, bool p2)
				|        {
				|            return Base_obj.GetNextControl(((dynamic)p1).Base_obj, p2).dll_obj;
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ЭлементУправления" Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементУправления"", ""Control"")]
				|        public IValue Control(int p1)
				|        {
				|            return OneScriptForms.RevertObj(Base_obj.getControl(p1));
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "СоздатьГрафику" Тогда
				Стр = Стр +
				"        [ContextMethod(""СоздатьГрафику"", ""CreateGraphics"")]
				|        public ClGraphics CreateGraphics()
				|        {
				|            return new ClGraphics(Base_obj.CreateGraphics());
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ИзРазмера") и (ИмяКонтекстКлассаАнгл = "Rectangle") Тогда
				Стр = Стр +
				"        [ContextMethod(""ИзРазмера"", ""FromSize"")]
				|        public ClRectangle FromSize(ClSize p1)
				|        {
				|            return new ClRectangle(Base_obj.FromSize(p1.Base_obj));
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Картинка" Тогда
				Стр = Стр +
				"        [ContextMethod(""Картинка"", ""Bitmap"")]
				|        public ClBitmap Bitmap(IValue p1 = null, ClSize p2 = null)
				|        {
				|            if (p1 == null && p2 == null)
				|            {
				|                return null;
				|            }
				|            if (p1 == null && p2 != null)
				|            {
				|                return new ClBitmap(p2);
				|            }
				|            if (p1 != null && p2 == null)
				|            {
				|                string str1 = p1.GetType().ToString();
				|                if (str1 == ""osf.ClBitmap"")
				|                {
				|                    ClBitmap ClBitmap1 = (ClBitmap)p1.AsObject();
				|                    Image Image1 = (Image)ClBitmap1.Base_obj;
				|                    return new ClBitmap(Image1);
				|                }
				|                if (str1 == ""osf.ClStream"")
				|                {
				|                    return new ClBitmap((ClStream)p1);
				|                }
				|                try
				|                {
				|                    if (p1.SystemType.Name == ""Строка"")
				|                    {
				|                        Image Image1 = (Image)new Bitmap(p1.AsString());
				|                        return new ClBitmap(Image1);
				|                    }
				|                }
				|                catch
				|                {
				|                }
				|            }
				|            if (p1 != null && p2 != null)
				|            {
				|                string str1 = p1.GetType().ToString();
				|                if (str1 == ""osf.ClBitmap"")
				|                {
				|                    ClBitmap ClBitmap1 = (ClBitmap)p1.AsObject();
				|                    Image Image1 = (Image)ClBitmap1.Base_obj;
				|                    return new ClBitmap(Image1, p2);
				|                }
				|                if (str1 == ""osf.ClStream"")
				|                {
				|                    ClStream ClStream1 = (ClStream)p1.AsObject();
				|                    return new ClBitmap(new Image(ClStream1.Base_obj), p2);
				|                }
				|                try
				|                {
				|                    if (p1.SystemType.Name == ""Строка"")
				|                    {
				|                        Image Image1 = (Image)new Bitmap(p1.AsString());
				|                        return new ClBitmap(Image1, p2);
				|                    }
				|                }
				|                catch
				|                {
				|                }
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ЗаписатьБайт" Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗаписатьБайт"", ""WriteByte"")]
				|        public void WriteByte(int p1)
				|        {
				|            Base_obj.WriteByte(Convert.ToByte(p1));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Клонировать") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""Клонировать"", ""Clone"")]
				|        public ClBitmap Clone(int p1, int p2, int p3, int p4)
				|        {
				|            Bitmap Bitmap1 = Base_obj.Clone(Convert.ToSingle(p1), Convert.ToSingle(p2), Convert.ToSingle(p3), Convert.ToSingle(p4));
				|            return new ClBitmap(Bitmap1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Записать") и (ИмяКонтекстКлассаАнгл = "Stream") Тогда
				Стр = Стр +
				"        [ContextMethod(""Записать"", ""Write"")]
				|        public void Write(ClArrayList p1, int p2, int p3)
				|        {
				|            ArrayList ArrayList1 = p1.Base_obj;
				|            int Count1 = ArrayList1.Count;
				|            object[] objects = new object[Count1];
				|            for (int i = 0; i < Count1; i++)
				|            {
				|                objects[i] = System.Convert.ToByte(ArrayList1[i]);
				|            }
				|            Base_obj.Write(objects, p2, p3);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "СлитьМеню" Тогда
				Стр = Стр +
				"        [ContextMethod(""СлитьМеню"", ""MergeMenu"")]
				|        public void MergeMenu(IValue p1)
				|        {
				|            string p1_type = OneScriptForms.RevertObj(p1).GetType().ToString();
				|            if ((p1_type == ""osf.ClMainMenu"") || (p1_type == ""osf.ClContextMenu""))
				|            {
				|                dynamic Menu2 = p1;
				|                for (int i = 0; i < Menu2.MenuItems.Count; i++)
				|                {
				|                    ClMenuItem ClMenuItem1 = (ClMenuItem)MenuItems.Item(i);
				|                    int MergeOrder1 = ClMenuItem1.MergeOrder;
				|                    ClMenuItem ClMenuItem2 = (ClMenuItem)Menu2.MenuItems.Item(i);
				|                    int MergeType2 = ClMenuItem2.MergeType;
				|                    int MergeOrder2 = ClMenuItem2.MergeOrder;
				|                    ClMenuItem new_MenuItem = ClMenuItem2.CloneMenu();
				|                    if (MergeOrder1 == MergeOrder2)
				|                    {
				|                        if (MergeType2 == 0)//Добавить (Add)
				|                        {
				|                            MenuItems.Add(new_MenuItem);
				|                        }
				|                        if (MergeType2 == 1)//Заменить (Replace)
				|                        {
				|                            MenuItems.Add(new_MenuItem);
				|                            MenuItems.RemoveAt(i);
				|                            new_MenuItem.Index = i;
				|                        }
				|                        if (MergeType2 == 2)//ОбъединитьМеню (MergeItems)
				|                        {
				|                            MenuItems.Add(new_MenuItem);
				|                            new_MenuItem.Index = i + 1;
				|                        }
				|                        if (MergeType2 == 3)//Удалить (Remove)
				|                        {
				|                        }
				|                    }
				|                    else
				|                    {
				|                        MenuItems.Add(new_MenuItem);
				|                    }
				|                }
				|                //теперь нужно пройти по объединенному меню и построить рейтинг на основании текущего индекса меню и MergeOrder
				|                //рейтинг = индексМеню + (MergeOrder * 100000)
				|                //перестраиваем меню согласно рейтинга
				|                //заполняем СортированныйСписок. Ключом будет рейтинг, значением будет MenuItem
				|                //очищаем Menu и заполняем его из СортированныйСписок
				|                ClSortedList ClSortedList1 = new ClSortedList();
				|                for (int i = 0; i < MenuItems.Count; i++)
				|                {
				|                    ClMenuItem ClMenuItem1 = (ClMenuItem)MenuItems.Item(i);
				|                    int rating = ClMenuItem1.Index + (ClMenuItem1.MergeOrder * 100000);
				|                    ClSortedList1.Add(rating, ClMenuItem1.CloneMenu());
				|                }
				|                MenuItems.Clear();
				|                ClArrayList ClArrayList1 = ClSortedList1.Keys;
				|                for (int i = 0; i < ClArrayList1.Count; i++)
				|                {
				|                    int key1 = Convert.ToInt32(ClArrayList1.Item(i).AsNumber());
				|                    MenuItems.Add((ClMenuItem)ClSortedList1.Item(key1).Value);
				|                }
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Показать") и (ИмяКонтекстКлассаАнгл = "ContextMenu") Тогда
				Стр = Стр +
				"        [ContextMethod(""Показать"", ""Show"")]
				|        public void Show(IValue p1, ClPoint p2)
				|        {
				|            Control Control1 = (Control)((dynamic)p1).Base_obj;
				|            Point Point1 = new Point(Control1.ClientRectangle.X + p2.Base_obj.X, Control1.ClientRectangle.Y + p2.Base_obj.Y);
				|            Point Point2 = Control1.PointToScreen(Point1);
				|            Cursor Cursor1 = new Cursor();
				|            Cursor1.Current.Position = Point2;
				|            Base_obj.Show(Control1.M_Control, Point2.M_Point);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Показать") и (ИмяКонтекстКлассаАнгл = "MessageBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""Показать"", ""Show"")]
				|        public void Show(string text = null, string title = null, int buttons = 0, int icon = 0)
				|        {
				|            Base_obj.Show(text, title, buttons, icon);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Показать") и (ИмяКонтекстКлассаАнгл = "InputBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""Показать"", ""Show"")]
				|        public string Show(string p1, string p2, string p3 = """", int p4 = -1, int p5 = -1)
				|        {
				|            string str1 = null;
				|            var thread = new Thread(() =>
				|            {
				|                str1 = Microsoft.VisualBasic.Interaction.InputBox(p1, p2, p3, p4, p5);
				|            }
				|            );
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|
				|            return str1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ЭлементМеню") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементМеню"", ""MenuItem"")]
				|        public ClMenuItem MenuItem(string p1 = """", string p2 = """", int p3 = 0)
				|        {
				|            return new ClMenuItem(p1, p2, p3);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ЭлементМеню" Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементМеню"", ""MenuItem"")]
				|        public ClMenuItem MenuItem(int p1)
				|        {
				|            return new ClMenuItem(Base_obj.MenuItems[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПолучитьТекст") и (ИмяКонтекстКлассаАнгл = "Clipboard") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьТекст"", ""GetText"")]
				|        public string GetText()
				|        {
				|            string str1 = null;
				|            var thread = new Thread(() => 
				|                {
				|                    IDataObject dataObject = Clipboard.GetDataObject();
				|                    if (dataObject.GetDataPresent(DataFormats.UnicodeText))
				|                    {
				|                        str1 = (String)dataObject.GetData(DataFormats.UnicodeText);
				|                    }
				|                }
				|            );
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|
				|            return str1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Очистить") и (ИмяКонтекстКлассаАнгл = "Clipboard") Тогда
				Стр = Стр +
				"        [ContextMethod(""Очистить"", ""Clear"")]
				|        public void Clear()
				|        {
				|            var thread = new Thread(() => Clipboard.Clear());
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "УстановитьТекст") и (ИмяКонтекстКлассаАнгл = "Clipboard") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьТекст"", ""SetText"")]
				|        public void SetText(string text)
				|        {
				|            var data = new DataObject();
				|            data.SetData(DataFormats.UnicodeText, true, text);
				|            var thread = new Thread(() => Clipboard.SetDataObject(data, true));
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "УстановитьИзображение") и (ИмяКонтекстКлассаАнгл = "Clipboard") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьИзображение"", ""SetImage"")]
				|        public void SetImage(ClBitmap bitmap)
				|        {
				|            var data = new DataObject();
				|            data.SetData(DataFormats.Bitmap, true, ((System.Drawing.Image)(bitmap.Base_obj.M_Image)));
				|            var thread = new Thread(() => Clipboard.SetDataObject(data, true));
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПолучитьИзображение") и (ИмяКонтекстКлассаАнгл = "Clipboard") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьИзображение"", ""GetImage"")]
				|        public ClBitmap GetImage()
				|        {
				|            ClBitmap ClBitmap1 = null;
				|            var thread = new Thread(() =>
				|                {
				|                    if (Clipboard.ContainsImage())
				|                    {
				|                        Bitmap Bitmap1 = new Bitmap((System.Drawing.Image)Clipboard.GetImage());
				|                        ClBitmap1 = new ClBitmap(Bitmap1);
				|                    }
				|                }
				|            );
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|
				|            return ClBitmap1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Значок") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""Значок"", ""Icon"")]
				|        public ClIcon Icon(IValue p1, IValue p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                return new ClIcon(p1.AsString(), Convert.ToInt32(p2.AsNumber()));
				|            }
				|            else
				|            {
				|                if (p1.GetType().ToString() == ""osf.ClBitmap"")
				|                {
				|                    Icon Icon1 = new Icon(System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)((ClBitmap)p1.AsObject()).Base_obj.M_Bitmap).GetHicon()));
				|                    return new ClIcon(Icon1);
				|                }
				|                else
				|                {
				|                    if (p1.SystemType.Name == ""Строка"")
				|                    {
				|                        return new ClIcon(p1.AsString());
				|                    }
				|                }
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Шрифт") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""Шрифт"", ""Font"")]
				|        public ClFont Font(string p1 = null, IValue p2 = null, int p3 = 0)
				|        {
				|            float _p2;
				|            if (p2 == null)
				|            {
				|                _p2 = 6.0f;
				|            }
				|            else
				|            {
				|                _p2 = Convert.ToSingle(p2.AsNumber());
				|            }
				|            return new ClFont(p1, _p2, p3);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "МассивСписок") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""МассивСписок"", ""ArrayList"")]
				|        public ClArrayList ArrayList(IValue p1 = null)
				|        {
				|            if (p1 != null)
				|            {
				|                if (p1.SystemType.Name == ""Массив"")
				|                {
				|                    ClArrayList ClArrayList1 = new ClArrayList();
				|                    ScriptEngine.HostedScript.Library.ArrayImpl ArrayImpl1 = (ScriptEngine.HostedScript.Library.ArrayImpl)p1;
				|                    for (int i = 0; i < ArrayImpl1.Count(); i++)
				|                    {
				|                        ClArrayList1.Add(ArrayImpl1.Get(i));
				|                    }
				|                    return ClArrayList1;
				|                }
				|                else if (p1 is osf.ClArrayList)
				|                {
				|                    return new ClArrayList(((ClArrayList)p1).Base_obj);
				|                }
				|            }
				|            return new ClArrayList();
				|        }
				|
				|";
			ИначеЕсли МетодРус = "МассивСписок" Тогда
				Стр = Стр +
				"        [ContextMethod(""МассивСписок"", ""ArrayList"")]
				|        public ClArrayList ArrayList(IValue p1 = null)
				|        {
				|            if (p1 == null)
				|            {
				|                return new ClArrayList();
				|            }
				|            else
				|            {
				|                return new ClArrayList(((dynamic)p1).Base_obj);
				|            }
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "УправляемоеСвойство" Тогда
				Стр = Стр +
				"        [ContextMethod(""УправляемоеСвойство"", ""ManagedProperty"")]
				|        public ClManagedProperty ManagedProperty(IValue p1, string p2, IValue p3 = null)
				|        {
				|            return new ClManagedProperty(p1, p2, p3);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Вкладка" Тогда
				Стр = Стр +
				"        [ContextMethod(""Вкладка"", ""TabPage"")]
				|        public ClTabPage TabPage(string p1 = null)
				|        {
				|            return new ClTabPage(p1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ListViewSubItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClListViewSubItem Insert(int p1, ClListViewSubItem p2)
				|        {
				|            return (ClListViewSubItem)OneScriptForms.RevertObj(Base_obj.Insert(p1, p2.Base_obj));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ListViewColumnHeaderCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClColumnHeader Insert(int p1, ClColumnHeader p2)
				|        {
				|            return Base_obj.Insert(p1, p2.Base_obj).dll_obj;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "StatusBarPanelCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClStatusBarPanel Insert(int p1, ClStatusBarPanel p2)
				|        {
				|            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj.Insert(p1, p2.Base_obj));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListViewSubItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClListViewSubItem Item(int p1, ClListViewSubItem p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                Base_obj.Insert(p1, p2.Base_obj);
				|                return p2;
				|            }
				|            else
				|            {
				|                return new ClListViewSubItem(Base_obj[p1]);
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "StatusBarPanelCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClStatusBarPanel Item(int p1, ClStatusBarPanel p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                Base_obj.Insert(p1, p2.Base_obj);
				|                return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj[p1]);
				|            }
				|            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "StatusBarPanelCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClStatusBarPanel Add(ClStatusBarPanel p1)
				|        {
				|            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj.Add(p1.Base_obj));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListViewColumnHeaderCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClColumnHeader Item(int p1)
				|        {
				|            return Base_obj[p1].dll_obj;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "TabPageCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClTabPage Insert(int p1, IValue p2)
				|        {
				|            if (p2.SystemType.Name == ""КлВкладка"")
				|            {
				|                ClTabPage ClTabPage1 = new ClTabPage(((ClTabPage)p2).Text);
				|                Base_obj.Insert(p1, ClTabPage1.Base_obj);
				|                return ClTabPage1;
				|            }
				|            else if (p2.SystemType.Name == ""Строка"")
				|            {
				|                ClTabPage ClTabPage1 = new ClTabPage(p2.AsString());
				|                Base_obj.Insert(p1, ClTabPage1.Base_obj);
				|                return ClTabPage1;
				|            }
				|            else
				|            {
				|                return null;
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListViewCheckedItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClListViewItem Item(int p1)
				|        {
				|            return new ClListViewItem(Base_obj[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListBoxSelectedIndexCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public int Item(int p1)
				|        {
				|            return Base_obj[p1];
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Индекс") и (ИмяКонтекстКлассаАнгл = "ListBoxSelectedObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Индекс"", ""IndexOf"")]
				|        public int IndexOf(IValue p1)
				|        {
				|            for (int i = 0; i < Base_obj.Count; i++)
				|            {
				|                if (Base_obj[i].ToString() == p1.AsString())
				|                {
				|                    return i;
				|                }
				|            }
				|            return Base_obj.IndexOf(p1.AsString());
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Индекс") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Индекс"", ""IndexOf"")]
				|        public int IndexOf(IValue p1)
				|        {
				|            int index1 = -1;
				|            for (int i = 0; i < Base_obj.Count; i++)
				|            {
				|                if (Base_obj[i] == ((dynamic)p1).Base_obj)
				|                {
				|                    index1 = i;
				|                    break;
				|                }
				|            }
				|            return index1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "УстановитьЭлемент") и (ИмяКонтекстКлассаАнгл = "DataRowView") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьЭлемент"", ""SetItem"")]
				|        public void SetItem(IValue p1, IValue p2)
				|        {
				|            dynamic p3 = p1;
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                p3 = p1.AsString();
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                p3 = Convert.ToInt32(p1.AsNumber());
				|            }
				|
				|            if (p2.GetType().ToString().Contains(""osf.""))
				|            {
				|                Base_obj.SetItem(p3, OneScriptForms.RevertObj(p2));
				|            }
				|            else if (p2.SystemType.Name == ""Строка"")
				|            {
				|                Base_obj.SetItem(p3, p2.AsString());
				|            }
				|            else if (p2.SystemType.Name == ""Булево"")
				|            {
				|                Base_obj.SetItem(p3, p2.AsBoolean());
				|            }
				|            else if (p2.SystemType.Name == ""Дата"")
				|            {
				|                Base_obj.SetItem(p3, new System.DateTime(
				|                    p2.AsDate().Year,
				|                    p2.AsDate().Month,
				|                    p2.AsDate().Day,
				|                    p2.AsDate().Hour,
				|                    p2.AsDate().Minute,
				|                    p2.AsDate().Second
				|                    ));
				|            }
				|            else if (p2.SystemType.Name == ""Число"")
				|            {
				|                Base_obj.SetItem(p3, p2.AsNumber());
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Содержит") и (ИмяКонтекстКлассаАнгл = "ListBoxSelectedObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Содержит"", ""Contains"")]
				|        public bool Contains(IValue p1)
				|        {
				|            foreach (object o in Base_obj)
				|            {
				|                if (o.ToString() == p1.AsString())
				|                {
				|                    return true;
				|                }
				|            }
				|            return false;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ЭлементСписка") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементСписка"", ""ListItem"")]
				|        public ClListItem ListItem(string p1 = null, IValue p2 = null)
				|        {
				|            return new ClListItem(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Сортировать") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextMethod(""Сортировать"", ""Sort"")]
				|        public void Sort(ClColumnHeader p1, int p2)
				|        {
				|            Base_obj.Sort(p1.Base_obj, p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Колонка") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Колонка"", ""Column"")]
				|        public ClDataColumn Column(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Число"")
				|            {
				|                return new ClDataColumn(Base_obj.get_Column(Convert.ToInt32(p1.AsNumber())));
				|            }
				|            else if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return new ClDataColumn(Base_obj.get_Column(Convert.ToString(p1.AsString())));
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Колонка" Тогда
				Стр = Стр +
				"        [ContextMethod(""Колонка"", ""ColumnHeader"")]
				|        public ClColumnHeader ColumnHeader(string p1 = null, int p2 = 60, int p3 = 0)
				|        {
				|            return new ClColumnHeader(p1, p2, p3);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ImageCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public int Add(ClBitmap p1, ClColor p2 = null)
				|        {
				|            int index1 = -1;
				|            if (p2 != null)
				|            {
				|                index1 = Base_obj.Add(p1.Base_obj, p2.Base_obj);
				|            }
				|            else
				|            {
				|                index1 = Base_obj.Add(p1.Base_obj);
				|            }
				|            return index1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public void Add(object p1, IValue p2)
				|        {
				|            Base_obj.Add(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ImageCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClBitmap Item(int p1)
				|        {
				|            return new ClBitmap(Base_obj[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "TabPageCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClTabPage Add(ClTabPage p1)
				|        {
				|            return Base_obj.Add(p1.Base_obj).dll_obj;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ArrayList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1 = null)
				|        {
				|            return (IValue)Base_obj.Add(p1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1)
				|        {
				|            Base_obj.Add(((dynamic)p1).Base_obj);
				|            System.Windows.Forms.Application.DoEvents();
				|            return p1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "MenuItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClMenuItem Add(ClMenuItem p1)
				|        {
				|            return Base_obj.Add(p1.Base_obj).dll_obj;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ListViewColumnHeaderCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClColumnHeader Add(IValue p1 = null)
				|        {
				|            if (p1 == null)
				|            {
				|                return new ClColumnHeader(Base_obj.Add());
				|            }
				|            else if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return new ClColumnHeader(Base_obj.Add(p1.AsString()));
				|            }
				|            else if (p1.GetType() == typeof(ClColumnHeader))
				|            {
				|                return Base_obj.Add(((ClColumnHeader)p1).Base_obj).dll_obj;
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ListViewItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClListViewItem Add(IValue p1)
				|        {
				|            ListViewItem ListViewItem1 = null;
				|            if (p1.GetType().ToString() == ""osf.ClListViewItem"")
				|            {
				|                ListViewItem1 = Base_obj.Add(((ClListViewItem)p1).Base_obj);
				|            }
				|            else if (p1.SystemType.Name == ""Строка"")
				|            {
				|                ListViewItem1 = Base_obj.Add(p1.ToString());
				|            }
				|            else
				|            {
				|                return null;
				|            }
				|            return new ClListViewItem(ListViewItem1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1, IValue p2 = null)
				|        {
				|            ListItem ListItem1 = new ListItem();
				|            if (p2 != null)
				|            {
				|                if (Base_obj[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|                {
				|                    return (IValue)null;
				|                }
				|                else if (Base_obj[p1].GetType().ToString() == ""osf.ClListBox"")
				|                {
				|                    return (IValue)null;
				|                }
				|                else if (p2.GetType().ToString() == ""osf.ClListItem"")
				|                {
				|                    ListItem ListItem2 = ((dynamic)p2).Base_obj;
				|                    ListItem1 = (ListItem)Base_obj[p1];
				|                    ListItem1.Text = ListItem2.Text;
				|                    ListItem1.Value = ListItem2.Value;
				|                    ListItem1.ForeColor = ListItem2.ForeColor;
				|                }
				|                else
				|                {
				|                    string s = """";
				|                    try
				|                    {
				|                        s = p2.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
				|                    }
				|                    catch
				|                    {
				|                        s = p2.ToString();
				|                    }
				|                    ListItem1 = (ListItem)Base_obj[p1];
				|                    ListItem1.Text = s;
				|                    ListItem1.Value = p2;
				|                }
				|                M_obj.Base_obj.Invalidate();
				|                return (IValue)new ClListItem(ListItem1);
				|            }
				|            else
				|            {
				|                if (Base_obj[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|                {
				|                    DataRowView DataRowView1 = new DataRowView((System.Data.DataRowView)Base_obj[p1]);
				|                    ListItem1.Text = DataRowView1.get_Item(M_obj.Base_obj.DisplayMember).ToString();
				|                    ListItem1.Value = DataRowView1.get_Item(M_obj.Base_obj.ValueMember);
				|                }
				|                else if (Base_obj[p1].GetType().ToString() == ""osf.ListItem"")
				|                {
				|                    ListItem1 = (ListItem)Base_obj[p1];
				|                }
				|                else
				|                {
				|                    ListItem1.Text = Base_obj[p1].ToString();
				|                    ListItem1.Value = Base_obj[p1];
				|                    ListItem1.ForeColor = ((dynamic)Base_obj[p1]).ForeColor;
				|                }
				|                return new ClListItem(ListItem1);
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListBoxSelectedObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            ListItem ListItem1 = new ListItem();
				|            if (Base_obj[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|            {
				|                DataRowView DataRowView1 = new DataRowView((System.Data.DataRowView)Base_obj[p1]);
				|                ListItem1.Text = DataRowView1.get_Item(M_obj.Base_obj.DisplayMember).ToString();
				|                ListItem1.Value = DataRowView1.get_Item(M_obj.Base_obj.ValueMember);
				|            }
				|            else if (Base_obj[p1].GetType().ToString() == ""osf.ListItem"")
				|            {
				|                ListItem1 = (ListItem)Base_obj[p1];
				|            }
				|            else
				|            {
				|                ListItem1.Text = Base_obj[p1].ToString();
				|                ListItem1.Value = Base_obj[p1];
				|            }
				|            return new ClListItem(ListItem1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "TabPageCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClTabPage Item(int p1, ClTabPage p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                Base_obj.Insert(p1, p2.Base_obj);
				|                return p2;
				|            }
				|            else
				|            {
				|                return Base_obj[p1].dll_obj;
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ArrayList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            return OneScriptForms.RevertObj(Base_obj[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Установить") и (ИмяКонтекстКлассаАнгл = "ArrayList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Установить"", ""Set"")]
				|        public void Set(int p1, IValue p2)
				|        {
				|            Base_obj[p1] = p2;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListViewItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClListViewItem Item(int p1, ClListViewItem p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                Base_obj.Insert(p1, p2.Base_obj);
				|                return new ClListViewItem(Base_obj[p1]);
				|            }
				|            else
				|            {
				|                return new ClListViewItem(Base_obj[p1]);
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ListViewSelectedItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClListViewItem Item(int p1)
				|        {
				|            return new ClListViewItem(Base_obj[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ВСтроку") и (ИмяКонтекстКлассаАнгл = "ListItem") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВСтроку"", ""ToString"")]
				|        public new string ToString()
				|        {
				|            return Base_obj.ToString();
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ВСтроку") и (ИмяКонтекстКлассаАнгл = "Type") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВСтроку"", ""ToString"")]
				|        public override string ToString()
				|        {
				|            return Base_obj.ToString();
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ЭлементСпискаЭлементов" Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементСпискаЭлементов"", ""ListViewItem"")]
				|        public ClListViewItem ListViewItem(string p1 = """", int p2 = -1)
				|        {
				|            return new ClListViewItem(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ПодэлементСпискаЭлементов" Тогда
				Стр = Стр +
				"        [ContextMethod(""ПодэлементСпискаЭлементов"", ""ListViewSubItem"")]
				|        public ClListViewSubItem ListViewSubItem(string p1 = """")
				|        {
				|            return new ClListViewSubItem(p1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "GridItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClGridItem Item(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Число"")
				|            {
				|                return new ClGridItem(Base_obj[Convert.ToInt32(p1.AsNumber())]);
				|            }
				|            return new ClGridItem(Base_obj[p1.AsString()]);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ИнформацияЗапускаПроцесса" Тогда
				Стр = Стр +
				"        [ContextMethod(""ИнформацияЗапускаПроцесса"", ""ProcessStartInfo"")]
				|        public ClProcessStartInfo ProcessStartInfo(string p1 = null, string p2 = null)
				|        {
				|            return new ClProcessStartInfo(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Начать") и (ИмяКонтекстКлассаАнгл = "Process") Тогда
				Стр = Стр +
				"        [ContextMethod(""Начать"", ""Start"")]
				|        public ClProcess Start()
				|        {
				|            return new ClProcess(Base_obj.Start());
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "BoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1)
				|        {
				|            DateTime[] DateTime2 = new DateTime[M_Object.Length + 1];
				|            M_Object.CopyTo(DateTime2, 0);
				|            System.DateTime p2 = p1.AsDate();
				|            DateTime2[M_Object.Length] = new System.DateTime(p2.Year, p2.Month, p2.Day, p2.Hour, p2.Minute, p2.Second);
				|            M_Object = DateTime2;
				|            return p1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Очистить") и (ИмяКонтекстКлассаАнгл = "BoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Очистить"", ""Clear"")]
				|        public void Clear()
				|        {
				|            M_Object = new DateTime[0];
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "BoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            return ValueFactory.Create(M_Object[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "AnnuallyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1)
				|        {
				|            DateTime[] DateTime2 = new DateTime[M_Object.Length + 1];
				|            M_Object.CopyTo(DateTime2, 0);
				|            System.DateTime p2 = p1.AsDate();
				|            DateTime2[M_Object.Length] = new System.DateTime(p2.Year, p2.Month, p2.Day, p2.Hour, p2.Minute, p2.Second);
				|            M_Object = DateTime2;
				|            return p1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Очистить") и (ИмяКонтекстКлассаАнгл = "AnnuallyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Очистить"", ""Clear"")]
				|        public void Clear()
				|        {
				|            M_Object = new DateTime[0];
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "AnnuallyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            return ValueFactory.Create(M_Object[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "MonthlyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1)
				|        {
				|            DateTime[] DateTime2 = new DateTime[M_Object.Length + 1];
				|            M_Object.CopyTo(DateTime2, 0);
				|            System.DateTime p2 = p1.AsDate();
				|            DateTime2[M_Object.Length] = new System.DateTime(p2.Year, p2.Month, p2.Day, p2.Hour, p2.Minute, p2.Second);
				|            M_Object = DateTime2;
				|            return p1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Очистить") и (ИмяКонтекстКлассаАнгл = "MonthlyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Очистить"", ""Clear"")]
				|        public void Clear()
				|        {
				|            M_Object = new DateTime[0];
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "MonthlyBoldedDates") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            return ValueFactory.Create(M_Object[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "DataView") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDataRowView Item(int p1)
				|        {
				|            return new ClDataRowView((osf.DataRowView)Base_obj.get_Item(p1));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "DataRowView") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return OneScriptForms.RevertObj(Base_obj.get_Item(p1.AsString()));
				|            }
				|            return OneScriptForms.RevertObj(Base_obj.get_Item(Convert.ToInt32(p1.AsNumber())));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "DataRow") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDataItem Item(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return new ClDataItem((DataItem)Base_obj.get_Item(p1.AsString()));
				|            }
				|            return new ClDataItem((DataItem)Base_obj.get_Item(Convert.ToInt32(p1.AsNumber())));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ВыделенныйДиапазон") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВыделенныйДиапазон"", ""SelectionRange"")]
				|        public ClSelectionRange SelectionRange(IValue p1 = null, IValue p2 = null)
				|        {
				|            if ((p1 != null) && (p2 != null))
				|            {
				|                return new ClSelectionRange(p1, p2);
				|            }
				|            else if ((p1 == null) && (p2 == null))
				|            {
				|                return new ClSelectionRange();
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПолучитьФорму") и (ИмяКонтекстКлассаАнгл = "MainMenu") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьФорму"", ""GetForm"")]
				|        public ClForm GetForm()
				|        {
				|            return Base_obj.GetForm().dll_obj;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "КлонироватьМеню") и (ИмяКонтекстКлассаАнгл = "MainMenu") Тогда
				Стр = Стр +
				"        [ContextMethod(""КлонироватьМеню"", ""CloneMenu"")]
 				|        public ClMainMenu CloneMenu()
 				|       {
				|            MainMenu MainMenu1 = new MainMenu();
				|
				|            for (int i = 0; i < Base_obj.MenuItems.Count; i++)
				|            {
				|                MenuItem CurrentMenuItem1 = Base_obj.MenuItems[i];
				|                MenuItem MenuItem1 = new MenuItem();
				|
				|                MenuItem1.Enabled = CurrentMenuItem1.Enabled;
				|                MenuItem1.Name = CurrentMenuItem1.Name;
				|                MenuItem1.Index = CurrentMenuItem1.Index;
				|                MenuItem1.Click = CurrentMenuItem1.Click;
				|                MenuItem1.Visible = CurrentMenuItem1.Visible;
				|                MenuItem1.RadioCheck = CurrentMenuItem1.RadioCheck;
				|                MenuItem1.Checked = CurrentMenuItem1.Checked;
				|                MenuItem1.MergeOrder = CurrentMenuItem1.MergeOrder;
				|                MenuItem1.Shortcut = (int)CurrentMenuItem1.Shortcut;
				|                MenuItem1.Text = CurrentMenuItem1.Text;
				|                MenuItem1.MergeType = (int)CurrentMenuItem1.MergeType;
				|
				|                MainMenu1.MenuItems.Add(MenuItem1);
				|                if (CurrentMenuItem1.MenuItems.Count > 0)
				|                {
				|                    BypassMainMenu(MenuItem1, CurrentMenuItem1.MenuItems);
				|                }
				|            }
				|            return new ClMainMenu(MainMenu1);
				|        }
				|
				|        public void BypassMainMenu(MenuItem MainMenu, MenuItemCollection MenuItems)
				|        {
				|            for (int i = 0; i < MenuItems.Count; i++)
				|            {
				|                MenuItem CurrentMenuItem1 = MenuItems[i];
				|                MenuItem MenuItem1 = new MenuItem();
				|
				|                MenuItem1.Enabled = CurrentMenuItem1.Enabled;
				|                MenuItem1.Name = CurrentMenuItem1.Name;
				|                MenuItem1.Index = CurrentMenuItem1.Index;
				|                MenuItem1.Click = CurrentMenuItem1.Click;
				|                MenuItem1.Visible = CurrentMenuItem1.Visible;
				|                MenuItem1.RadioCheck = CurrentMenuItem1.RadioCheck;
				|                MenuItem1.Checked = CurrentMenuItem1.Checked;
				|                MenuItem1.MergeOrder = CurrentMenuItem1.MergeOrder;
				|                MenuItem1.Shortcut = (int)CurrentMenuItem1.Shortcut;
				|                MenuItem1.Text = CurrentMenuItem1.Text;
				|                MenuItem1.MergeType = (int)CurrentMenuItem1.MergeType;
				|
				|                MainMenu.MenuItems.Add(MenuItem1);
				|                if (CurrentMenuItem1.MenuItems.Count > 0)
				|                {
				|                    BypassMainMenu(MenuItem1, CurrentMenuItem1.MenuItems);
				|                }
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "MenuItem") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClMenuItem Item(int p1)
				|        {
				|            return new ClMenuItem(Base_obj[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ArrayList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public IValue Insert(int p1, IValue p2)
				|        {
				|            return (IValue)Base_obj.Insert(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "MenuItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClMenuItem Item(int p1)
				|        {
				|            return new ClMenuItem(Base_obj[p1]);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ИзИзображения") и (ИмяКонтекстКлассаАнгл = "Graphics") Тогда
				Стр = Стр +
				"        [ContextMethod(""ИзИзображения"", ""FromImage"")]
				|        public ClGraphics FromImage(ClBitmap p1)
				|        {
				|            return new ClGraphics(Base_obj.FromImage(p1.Base_obj));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ВКартинку") и (ИмяКонтекстКлассаАнгл = "Icon") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВКартинку"", ""ToBitmap"")]
				|        public ClBitmap ToBitmap()
				|        {
				|            return new ClBitmap(Base_obj.ToBitmap());
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "УзелДерева") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""УзелДерева"", ""TreeNode"")]
				|        public ClTreeNode TreeNode(string p1 = null)
				|        {
				|            return new ClTreeNode(p1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "TreeNodeCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClTreeNode Add(IValue p1)
				|        {
				|            if (p1.GetType() == typeof(osf.ClTreeNode))
				|            {
				|                Base_obj.Add((TreeNode)((ClTreeNode)p1.AsObject()).Base_obj);
				|                return (ClTreeNode)p1;
				|            }
				|            else if (p1.SystemType.Name == ""Строка"")
				|            {
				|                ClTreeNode ClTreeNode1 = new ClTreeNode(new TreeNode(p1.AsString()));
				|                Base_obj.Add(ClTreeNode1.Base_obj);
				|                return ClTreeNode1;
				|            }
				|            return null;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ОтправитьКлавиши") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ОтправитьКлавиши"", ""SendKeys"")]
				|        public void SendKeys(string p1)
				|        {
				|            System.Windows.Forms.SendKeys.SendWait(p1);
				|            System.Windows.Forms.Application.DoEvents();
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ОбработкаПослеСобытия" Тогда
				Стр = Стр +
				"        [ContextMethod(""ОбработкаПослеСобытия"", ""PostEventProcessing"")]
				|        public void PostEventProcessing()
				|        {
				|            if (Event != null)
				|            {
				|                ((dynamic)Event).Base_obj.PostEvent();
				|            }
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПолучитьУзел") и (ИмяКонтекстКлассаАнгл = "TreeView") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьУзел"", ""GetNodeAt"")]
				|        public ClTreeNode GetNodeAt(int p1, int p2)
				|        {
				|            return new ClTreeNode(Base_obj.GetNodeAt(p1, p2));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПоказатьДиалог") и (ИмяКонтекстКлассаАнгл = "FolderBrowserDialog") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПоказатьДиалог"", ""ShowDialog"")]
				|        public IValue ShowDialog()
				|        {
				|            int Res1 = 0;
				|            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|            return ValueFactory.Create(Res1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "НайтиОкноПоЗаголовку") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [DllImport(""user32.dll"", EntryPoint = ""FindWindow"", CharSet = CharSet.Auto, SetLastError = true)] private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string WindowName);
				|        
				|        [ContextMethod(""НайтиОкноПоЗаголовку"", ""FindWindowByCaption"")]
				|        public IValue FindWindowByCaption(string WindowName)
				|        {
				|            IntPtr numWnd = FindWindowByCaption(IntPtr.Zero, WindowName);
				|            return ValueFactory.Create((int)numWnd);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПоказатьДиалог") и (ИмяКонтекстКлассаАнгл = "ColorDialog") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПоказатьДиалог"", ""ShowDialog"")]
				|        public IValue ShowDialog()
				|        {
				|            int Res1 = 0;
				|            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|            return ValueFactory.Create(Res1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПоказатьДиалог") и (ИмяКонтекстКлассаАнгл = "FontDialog") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПоказатьДиалог"", ""ShowDialog"")]
				|        public IValue ShowDialog()
				|        {
				|            int Res1 = 0;
				|            var thread = new Thread(() => 
				|                {
				|                    Base_obj.ShowColor = true;
				|                    Res1 = (int)Base_obj.ShowDialog();
				|                }
				|            );
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|            return ValueFactory.Create(Res1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПоказатьДиалог") и (ИмяКонтекстКлассаАнгл = "OpenFileDialog") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПоказатьДиалог"", ""ShowDialog"")]
				|        public IValue ShowDialog()
				|        {
				|            int Res1 = 0;
				|            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|            return ValueFactory.Create(Res1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПоказатьДиалог") и (ИмяКонтекстКлассаАнгл = "SaveFileDialog") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПоказатьДиалог"", ""ShowDialog"")]
				|        public IValue ShowDialog()
				|        {
				|            int Res1 = 0;
				|            var thread = new Thread(() => Res1 = (int)Base_obj.ShowDialog());
				|            thread.IsBackground = true;
				|            thread.SetApartmentState(ApartmentState.STA);
				|            thread.Start();
				|            thread.Join();
				|            return ValueFactory.Create(Res1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "СвойстваОбъекта") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""СвойстваОбъекта"", ""PropObj"")]
				|        public string PropObj1(IValue p1)
				|        {
				|            System.Reflection.PropertyInfo[] myPropertyInfo = p1.GetType().GetProperties();
				|            List<string> p = new List<string>();
				|            for (int i = 0; i < myPropertyInfo.Length; i++)
				|            {
				|                if (myPropertyInfo[i].CustomAttributes.Count() == 1)
				|                {
				|                    string NameRu = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetName();
				|                    string NameEn = myPropertyInfo[i].GetCustomAttribute<ContextPropertyAttribute>().GetAlias();
				|                    p.Add(NameRu + "" ("" + NameEn + "")"");
				|                }
				|            }
				|            p.Sort();
				|            string str1 = """";
				|            string transfer = """";
				|            foreach (string str in p)
				|            {
				|                str1 = str1 + transfer + str;
				|                transfer = ""\r\n"";
				|            }
				|            return str1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "МетодыОбъекта") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""МетодыОбъекта"", ""MethodsObj"")]
				|        public string MethodsObj1(IValue p1)
				|        {
				|            System.Reflection.MethodInfo[] myMethodInfo = p1.GetType().GetMethods();
				|            List<string> p = new List<string>();
				|            for (int i = 0; i < myMethodInfo.Count(); i++)
				|            {
				|                if (myMethodInfo[i].CustomAttributes.Count() == 1)
				|                {
				|                    if (myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>() != null)
				|                    {
				|                        string NameRu = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetName();
				|                        string NameEn = myMethodInfo[i].GetCustomAttribute<ContextMethodAttribute>().GetAlias();
				|                        p.Add(NameRu + "" ("" + NameEn + "")"");
				|                    }
				|                }
				|            }
				|            p.Sort();
				|            string str1 = """";
				|            string transfer = """";
				|            foreach (string str in p)
				|            {
				|                str1 = str1 + transfer + str;
				|                transfer = ""\r\n"";
				|            }
				|            return str1;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ИзArgb") и (ИмяКонтекстКлассаАнгл = "Color") Тогда
				Стр = Стр +
				"        [ContextMethod(""ИзArgb"", ""FromArgb"")]
				|        public ClColor FromArgb(int p1, int p2, int p3, int p4)
				|        {
				|            return new ClColor(Base_obj.FromArgb(p1, p2, p3, p4));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ИзRgb") и (ИмяКонтекстКлассаАнгл = "Color") Тогда
				Стр = Стр +
				"        [ContextMethod(""ИзRgb"", ""FromRgb"")]
				|        public ClColor FromRgb(int p1, int p2, int p3)
				|        {
				|            return new ClColor(Base_obj.FromRgb(p1, p2, p3));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ИзИмени") и (ИмяКонтекстКлассаАнгл = "Color") Тогда
				Стр = Стр +
				"        [ContextMethod(""ИзИмени"", ""FromName"")]
				|        public ClColor FromName(string p1)
				|        {
				|            int NumberProp1 = this.FindProperty(p1);
				|            dynamic obj1 = this.GetPropValue(NumberProp1);
				|            return (ClColor)ValueFactory.Create(obj1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ListViewSubItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClListViewSubItem Add(IValue p1)
				|        {
				|            ListViewSubItem ListViewSubItem1 = null;
				|            if (p1.GetType().ToString() == ""osf.ClListViewSubItem"")
				|            {
				|                ListViewSubItem1 = Base_obj.Add(((ClListViewSubItem)p1).Base_obj);
				|            }
				|            else if (p1.SystemType.Name == ""Строка"")
				|            {
				|                ListViewSubItem1 = Base_obj.Add(p1.ToString());
				|            }
				|            else
				|            {
				|                return null;
				|            }
				|            return new ClListViewSubItem(ListViewSubItem1);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ВСтроку") и (ИмяКонтекстКлассаАнгл = "ImageFormat") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВСтроку"", ""ToString"")]
				|        public new string ToString()
				|        {
				|            if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cae-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cae-0728-11d3-9d7b-0000f81ef32e] Jpeg"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3caa-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3caa-0728-11d3-9d7b-0000f81ef32e] MemoryBMP"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cab-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cab-0728-11d3-9d7b-0000f81ef32e] Bmp"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cb0-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cb0-0728-11d3-9d7b-0000f81ef32e] Gif"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3caf-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3caf-0728-11d3-9d7b-0000f81ef32e] Png"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cb1-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cb1-0728-11d3-9d7b-0000f81ef32e] Tiff"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cb5-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cb5-0728-11d3-9d7b-0000f81ef32e] Icon"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cac-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""emf"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cb2-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cac-0728-11d3-9d7b-0000f81ef32e] exif"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cad-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cad-0728-11d3-9d7b-0000f81ef32e] wmf"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cb3 - 0728 - 11d3 - 9d7b - 0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cb3 - 0728 - 11d3 - 9d7b - 0000f81ef32e] pcd"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3cb4-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""[ImageFormat: b96b3cb4-0728-11d3-9d7b-0000f81ef32e] fpx"";
				|            }
				|            else if (Base_obj.M_ImageFormat.ToString() == ""[ImageFormat: b96b3ca9-0728-11d3-9d7b-0000f81ef32e]"")
				|            {
				|                return ""Windows GDI + не может определить формат."";
				|            }
				|            return """";
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Сохранить") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""Сохранить"", ""Save"")]
				|        public void Save(IValue p1, ClImageFormat p2 = null)
				|        {
				|            if (p1.GetType() == typeof(osf.ClStream))
				|            {
				|                Base_obj.Save(((ClStream)p1).Base_obj, p2.Base_obj);
				|            }
				|            else
				|            {
				|                Base_obj.Save(p1.AsString(), p2.Base_obj);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "НажатьКнопкуМыши") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""НажатьКнопкуМыши"", ""MouseKeyPress"")]
				|        public void MouseKeyPress(int p1, IValue p2 = null, IValue p3 = null)
				|        {
				|            if (p2 != null &&  p3 != null)
				|            {
				|                mouse_event(Convert.ToUInt32(p1), Convert.ToInt32(p2.AsNumber()), Convert.ToInt32(p3.AsNumber()), 0, UIntPtr.Zero);
				|            }
				|            else
				|            {
				|                mouse_event(Convert.ToUInt32(p1), System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y, 0, UIntPtr.Zero);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ToolBarButtonCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClToolBarButton Add(ClToolBarButton p1)
				|        {
				|            return new ClToolBarButton(Base_obj.Add(p1.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЗначокУведомления") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗначокУведомления"", ""NotifyIcon"")]
				|        public ClNotifyIcon NotifyIcon([ByRef] IVariable p1)
				|        {
				|            ClMenuNotifyIcon p2 = (ClMenuNotifyIcon)(p1.Value);
				|            return new ClNotifyIcon(ref p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ToolBarButtonCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClToolBarButton Insert(int p1, ClToolBarButton p2)
				|        {
				|            return new ClToolBarButton(Base_obj.Insert(p1, p2.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ToolBarButtonCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClToolBarButton Item(int p1, ClToolBarButton p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                Base_obj.Insert(p1, p2.Base_obj);
				|                return p2;
				|            }
				|            else
				|            {
				|                return new ClToolBarButton(Base_obj[p1]);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "Collection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public void Add(IValue p1, string p2 = null)
				|        {
				|            Base_obj.Add(p1, p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "Collection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return (IValue)Base_obj[p1.AsString()];
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                return (IValue)Base_obj[Convert.ToInt32(p1.AsNumber())];
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "DataColumnCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDataColumn Item(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Число"")
				|            {
				|                return new ClDataColumn(Base_obj[Convert.ToInt32(p1.AsNumber())]);
				|            }
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return new ClDataColumn(Base_obj[p1.AsString()]);
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Удалить") и (ИмяКонтекстКлассаАнгл = "Collection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Удалить"", ""Remove"")]
				|        public void Remove(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                Base_obj.Remove(p1.AsString());
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                Base_obj.Remove(Convert.ToInt32(p1.AsNumber()));
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Удалить") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Удалить"", ""Remove"")]
				|        public void Remove(object p1)
				|        {
				|            Base_obj.Remove(p1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьБайты") и (ИмяКонтекстКлассаАнгл = "Encoding") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьБайты"", ""GetBytes"")]
				|        public ClArrayList GetBytes(string p1)
				|        {
				|            ClArrayList ClArrayList1 = new ClArrayList();
				|            byte[] Bytes1 = Base_obj.M_Encoding.GetBytes(p1);
				|            for (int i = 0; i < Bytes1.Length; i++)
				|            {
				|                ClArrayList1.Base_obj.Add(Bytes1[i]);
				|            }
				|            return ClArrayList1;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьБайты") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьБайты"", ""GetBytes"")]
				|        public ClArrayList GetBytes(ClBitmapData p1)
				|        {
				|            return new ClArrayList(Base_obj.GetBytes(p1.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьКодировку") и (ИмяКонтекстКлассаАнгл = "Encoding") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьКодировку"", ""GetEncoding"")]
				|        public ClEncoding GetEncoding(int p1)
				|        {
				|            return new ClEncoding(Base_obj.GetEncoding(p1));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьСтроку") и (ИмяКонтекстКлассаАнгл = "Encoding") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьСтроку"", ""GetString"")]
				|        public string GetString(ClArrayList p1)
				|        {
				|            System.Collections.ArrayList ArrayList1 = p1.Base_obj.M_ArrayList;
				|            byte[] Bytes1 = new byte[checked(ArrayList1.Count + 2)];
				|
				|            for (int i = 0; i < ArrayList1.Count; i++)
				|            {
				|                Bytes1[i] = System.Convert.ToByte(System.Convert.ToInt32(ArrayList1[i].ToString()));
				|            }
				|            string str1 = Base_obj.M_Encoding.GetString(Bytes1);
				|            if ((BodyName == ""utf-16"") || (BodyName == ""utf-16BE""))
				|            {
				|                return Base_obj.M_Encoding.GetString(Bytes1).Substring(0, str1.Length - 1);
				|            }
				|            else if ((BodyName == ""us-ascii"") || (BodyName == ""utf-7"") || (BodyName == ""utf-8""))
				|            {
				|                return Base_obj.M_Encoding.GetString(Bytes1).Substring(0, str1.Length - 2);
				|            }
				|            return str1;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Преобразовать") и (ИмяКонтекстКлассаАнгл = "Encoding") Тогда
				Стр = Стр +
				"        [ContextMethod(""Преобразовать"", ""Convert"")]
				|        public ClArrayList Convert(ClEncoding p1, ClEncoding p2, ClArrayList p3)
				|        {
				|            System.Collections.ArrayList ArrayList1 = p3.Base_obj.M_ArrayList;
				|            byte[] Bytes1 = new byte[checked(ArrayList1.Count + 2)];
				|            for (int i = 0; i < ArrayList1.Count; i++)
				|            {
				|                Bytes1[i] = System.Convert.ToByte(ArrayList1[i]);
				|            }
				|            byte[] Array1 = System.Text.Encoding.Convert(p1.Base_obj.M_Encoding, p2.Base_obj.M_Encoding, Bytes1);
				|            object[] objArray = new object[checked(Array1.Length + 1)];
				|            for (int i = 0; i < Array1.Length; i++)
				|            {
				|                objArray[i] = (object)Array1[i];
				|            }
				|            ClArrayList ClArrayList2 = new ClArrayList();
				|            int Length1 = objArray.Length - 1;
				|            if ((p1.BodyName == ""utf-16"") || (p1.BodyName == ""utf-16BE""))
				|            {
				|                if ((p2.BodyName == ""utf-16"") || (p2.BodyName == ""utf-16BE""))
				|                {
				|                    Length1 = objArray.Length - 3;
				|                }
				|                else if ((p2.BodyName == ""us-ascii"") || (p2.BodyName == ""utf-7"") || (p2.BodyName == ""utf-8""))
				|                {
				|                    Length1 = objArray.Length - 2;
				|                }
				|            }
				|            else if ((p1.BodyName == ""us-ascii"") || (p1.BodyName == ""utf-7"") || (p1.BodyName == ""utf-8""))
				|            {
				|                if ((p2.BodyName == ""utf-16"") || (p2.BodyName == ""utf-16BE""))
				|                {
				|                    Length1 = objArray.Length - 5;
				|                }
				|                else if ((p2.BodyName == ""us-ascii"") || (p2.BodyName == ""utf-7"") || (p2.BodyName == ""utf-8""))
				|                {
				|                    Length1 = objArray.Length - 3;
				|                }
				|            }
				|            for (int i = 0; i < Length1; i++)
				|            {
				|                ClArrayList2.Base_obj.Add(objArray[i]);
				|            }
				|            return ClArrayList2;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ДобавитьКнопку") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""ДобавитьКнопку"", ""AddButton"")]
				|        public ClButton AddButton(string p1 = null, int p2 = 0, int p3 = 0, int p4 = 0, int p5 = 0)
				|        {
				|            return new ClButton(Base_obj.AddButton(p1, p2, p3, p4, p5));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "КолонкаДанных") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""КолонкаДанных"", ""DataColumn"")]
				|        public ClDataColumn DataColumn(string p1 = null, IValue p2 = null)
				|        {
				|            if (p1 == null && p2 == null)
				|            {
				|                return new ClDataColumn();
				|            }
				|            else if (p1 != null && p2 == null)
				|            {
				|                return new ClDataColumn(p1);
				|            }
				|            else if (p1 != null && p2 != null)
				|            {
				|                int type1 = Convert.ToInt32(p2.AsNumber());
				|                System.Type DataType1 = typeof(System.String);
				|                if (type1 == 0)
				|                {
				|                    DataType1 = typeof(System.String);
				|                }
				|                else if (type1 == 1)
				|                {
				|                    DataType1 = typeof(System.Decimal);
				|                }
				|                else if (type1 == 2)
				|                {
				|                    DataType1 = typeof(System.Boolean);
				|                }
				|                else if (type1 == 3)
				|                {
				|                    DataType1 = typeof(System.DateTime);
				|                }
				|                else if (type1 == 4)
				|                {
				|                    DataType1 = typeof(System.Object);
				|                }
				|                return new ClDataColumn(p1, DataType1);
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ТаблицаДанных") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ТаблицаДанных"", ""DataTable"")]
				|        public ClDataTable DataTable(string p1 = null)
				|        {
				|            if (p1 == null)
				|            {
				|                return new ClDataTable();
				|            }
				|            return new ClDataTable(p1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Клонировать") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Клонировать"", ""Clone"")]
				|        public ClDataTable Clone()
				|        {
				|            return new ClDataTable(Base_obj.Clone());
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Копировать") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Копировать"", ""Copy"")]
				|        public ClDataTable Copy()
				|        {
				|            return new ClDataTable(Base_obj.Copy());
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЗагрузитьКолонку") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗагрузитьКолонку"", ""LoadColumn"")]
				|        public void LoadColumn(ClArrayList p1, IValue p2)
				|        {
				|            dynamic p3 = null;
				|            if (p2.SystemType.Name == ""Число"")
				|            {
				|                p3 = Convert.ToInt32(p2.AsNumber());
				|            }
				|            else if (p2.SystemType.Name == ""Строка"")
				|            {
				|                p3 = p2.AsString();
				|            }
				|            else if (p2.SystemType.Name == ""КлКолонкаДанных"")
				|            {
				|                p3 = ((ClDataColumn)p2.AsObject()).Base_obj.ColumnName;
				|            }
				|
				|            for (int i = 0; i < p1.Count; i++)
				|            {
				|                Base_obj.Rows[i].SetItem(p3, OneScriptForms.DefineTypeIValue(p1.Base_obj[i]));
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "LinkCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClLink Item(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return new ClLink(Base_obj.M_LinkCollection[p1.AsString()]);
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                return new ClLink(Base_obj.M_LinkCollection[Convert.ToInt32(p1.AsNumber())]);
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЯчейкаСеткиДанных") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЯчейкаСеткиДанных"", ""DataGridCell"")]
				|        public ClDataGridCell DataGridCell(int p1, int p2)
				|        {
				|            return new ClDataGridCell(p1, p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "УстановитьЭлемент") и (ИмяКонтекстКлассаАнгл = "DataRow") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьЭлемент"", ""SetItem"")]
				|        public void SetItem(IValue p1, IValue p2)
				|        {
				|            dynamic p3 = p1;
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                p3 = p1.AsString();
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                p3 = Convert.ToInt32(p1.AsNumber());
				|            }
				|
				|            if (p2.GetType().ToString().Contains(""osf.""))
				|            {
				|                Base_obj.SetItem(p3, OneScriptForms.RevertObj(p2));
				|            }
				|            else if (p2.SystemType.Name == ""Строка"")
				|            {
				|                Base_obj.SetItem(p3, p2.AsString());
				|            }
				|            else if (p2.SystemType.Name == ""Булево"")
				|            {
				|                Base_obj.SetItem(p3, p2.AsBoolean());
				|            }
				|            else if (p2.SystemType.Name == ""Дата"")
				|            {
				|                Base_obj.SetItem(p3, new System.DateTime(
				|                    p2.AsDate().Year,
				|                    p2.AsDate().Month,
				|                    p2.AsDate().Day,
				|                    p2.AsDate().Hour,
				|                    p2.AsDate().Minute,
				|                    p2.AsDate().Second
				|                    ));
				|            }
				|            else if (p2.SystemType.Name == ""Число"")
				|            {
				|                Base_obj.SetItem(p3, p2.AsNumber());
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "НоваяСтрока") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""НоваяСтрока"", ""NewRow"")]
				|        public ClDataRow NewRow()
				|        {
				|            return new ClDataRow(Base_obj.NewRow());
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "DataRowCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClDataRow Add(ClDataRow p1)
				|        {
				|            return new ClDataRow(Base_obj.Add(p1.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "DataRowCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDataRow Item(int p1, ClDataRow p2 = null)
				|        {
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                Base_obj.InsertAt(p2.Base_obj, p1);
				|                return new ClDataRow(Base_obj[p1]);
				|            }
				|            else
				|            {
				|                return new ClDataRow(Base_obj[p1]);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "DataColumnCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClDataColumn Add(ClDataColumn p1)
				|        {
				|            return new ClDataColumn(Base_obj.Add(p1.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "GridTableStylesCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDataGridTableStyle Item(int p1)
				|        {
				|            return new ClDataGridTableStyle(Base_obj[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "GridColumnStylesCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public int Add(IValue p1)
				|        {
				|            return Base_obj.Add(((dynamic)p1).Base_obj);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЗавершитьРедактирование") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗавершитьРедактирование"", ""EndEdit"")]
				|        public bool EndEdit(IValue p1, int p2, bool p3)
				|        {
				|            return Base_obj.EndEdit(((dynamic)p1).Base_obj, p2, p3);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "НачатьРедактирование") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextMethod(""НачатьРедактирование"", ""BeginEdit"")]
				|        public bool BeginEdit(IValue p1, int p2)
				|        {
				|            return Base_obj.BeginEdit(((dynamic)p1).Base_obj, p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "НачатьРедактирование") и (ИмяКонтекстКлассаАнгл = "DataRow") Тогда
				Стр = Стр +
				"        [ContextMethod(""НачатьРедактирование"", ""BeginEdit"")]
				|        public void BeginEdit()
				|        {
				|            Base_obj.BeginEdit();
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "КлонироватьМеню") и (ИмяКонтекстКлассаАнгл = "ContextMenu") Тогда
				Стр = Стр +
				"        [ContextMethod(""КлонироватьМеню"", ""CloneMenu"")]
				|        public ClContextMenu CloneMenu()
				|        {
				|            ContextMenu ContextMenu1 = new ContextMenu();
				|
				|            for (int i = 0; i < Base_obj.MenuItems.Count; i++)
				|            {
				|                MenuItem CurrentMenuItem1 = Base_obj.MenuItems[i];
				|                MenuItem MenuItem1 = new MenuItem();
				|
				|                MenuItem1.Enabled = CurrentMenuItem1.Enabled;
				|                MenuItem1.Name = CurrentMenuItem1.Name;
				|                MenuItem1.Index = CurrentMenuItem1.Index;
				|                MenuItem1.Click = CurrentMenuItem1.Click;
				|                MenuItem1.Visible = CurrentMenuItem1.Visible;
				|                MenuItem1.RadioCheck = CurrentMenuItem1.RadioCheck;
				|                MenuItem1.Checked = CurrentMenuItem1.Checked;
				|                MenuItem1.MergeOrder = CurrentMenuItem1.MergeOrder;
				|                MenuItem1.Shortcut = (int)CurrentMenuItem1.Shortcut;
				|                MenuItem1.Text = CurrentMenuItem1.Text;
				|                MenuItem1.MergeType = (int)CurrentMenuItem1.MergeType;
				|
				|                ContextMenu1.MenuItems.Add(MenuItem1);
				|                if (CurrentMenuItem1.MenuItems.Count > 0)
				|                {
				|                    BypassContextMenu(MenuItem1, CurrentMenuItem1.MenuItems);
				|                }
				|            }
				|            return new ClContextMenu(ContextMenu1);
				|        }
				|
				|        public void BypassContextMenu(MenuItem ContextMenu, MenuItemCollection MenuItems)
				|        {
				|            for (int i = 0; i < MenuItems.Count; i++)
				|            {
				|                MenuItem CurrentMenuItem1 = MenuItems[i];
				|                MenuItem MenuItem1 = new MenuItem();
				|
				|                MenuItem1.Enabled = CurrentMenuItem1.Enabled;
				|                MenuItem1.Name = CurrentMenuItem1.Name;
				|                MenuItem1.Index = CurrentMenuItem1.Index;
				|                MenuItem1.Click = CurrentMenuItem1.Click;
				|                MenuItem1.Visible = CurrentMenuItem1.Visible;
				|                MenuItem1.RadioCheck = CurrentMenuItem1.RadioCheck;
				|                MenuItem1.Checked = CurrentMenuItem1.Checked;
				|                MenuItem1.MergeOrder = CurrentMenuItem1.MergeOrder;
				|                MenuItem1.Shortcut = (int)CurrentMenuItem1.Shortcut;
				|                MenuItem1.Text = CurrentMenuItem1.Text;
				|                MenuItem1.MergeType = (int)CurrentMenuItem1.MergeType;
				|
				|                ContextMenu.MenuItems.Add(MenuItem1);
				|                if (CurrentMenuItem1.MenuItems.Count > 0)
				|                {
				|                    BypassContextMenu(MenuItem1, CurrentMenuItem1.MenuItems);
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "КлонироватьМеню") и (ИмяКонтекстКлассаАнгл = "MenuItem") Тогда
				Стр = Стр +
				"        [ContextMethod(""КлонироватьМеню"", ""CloneMenu"")]
				|        public ClMenuItem CloneMenu()
				|        {
				|            MenuItem MenuItem4 = new MenuItem();
				|
				|            MenuItem4.Enabled = Base_obj.Enabled;
				|            MenuItem4.Name = Base_obj.Name;
				|            MenuItem4.Index = Base_obj.Index;
				|            MenuItem4.Click = Base_obj.Click;
				|            MenuItem4.Visible = Base_obj.Visible;
				|            MenuItem4.RadioCheck = Base_obj.RadioCheck;
				|            MenuItem4.Checked = Base_obj.Checked;
				|            MenuItem4.MergeOrder = Base_obj.MergeOrder;
				|            MenuItem4.Shortcut = (int)Base_obj.Shortcut;
				|            MenuItem4.Text = Base_obj.Text;
				|            MenuItem4.MergeType = (int)Base_obj.MergeType;
				|
				|            for (int i = 0; i < Base_obj.MenuItems.Count; i++)
				|            {
				|                MenuItem CurrentMenuItem = Base_obj.MenuItems[i];
				|                MenuItem MenuItem5 = new MenuItem();
				|
				|                MenuItem5.Enabled = CurrentMenuItem.Enabled;
				|                MenuItem5.Name = CurrentMenuItem.Name;
				|                MenuItem5.Index = CurrentMenuItem.Index;
				|                MenuItem5.Click = CurrentMenuItem.Click;
				|                MenuItem5.Visible = CurrentMenuItem.Visible;
				|                MenuItem5.RadioCheck = CurrentMenuItem.RadioCheck;
				|                MenuItem5.Checked = CurrentMenuItem.Checked;
				|                MenuItem5.MergeOrder = CurrentMenuItem.MergeOrder;
				|                MenuItem5.Shortcut = (int)CurrentMenuItem.Shortcut;
				|                MenuItem5.Text = CurrentMenuItem.Text;
				|                MenuItem5.MergeType = (int)CurrentMenuItem.MergeType;
				|
				|                MenuItem NewMenuItem = MenuItem4.MenuItems.Add(MenuItem5);
				|                if (CurrentMenuItem.MenuItems.Count > 0)
				|                {
				|                    BypassMenu(NewMenuItem, CurrentMenuItem.MenuItems);
				|                }
				|            }
				|            return new ClMenuItem(MenuItem4);
				|        }
				|
				|        public void BypassMenu(MenuItem MenuItem, MenuItemCollection MenuItems)
				|        {
				|            for (int i = 0; i < MenuItems.Count; i++)
				|            {
				|                MenuItem CurrentMenuItem = MenuItems[i];
				|                MenuItem MenuItem5 = new MenuItem();
				|
				|                MenuItem5.Enabled = CurrentMenuItem.Enabled;
				|                MenuItem5.Name = CurrentMenuItem.Name;
				|                MenuItem5.Index = CurrentMenuItem.Index;
				|                MenuItem5.Click = CurrentMenuItem.Click;
				|                MenuItem5.Visible = CurrentMenuItem.Visible;
				|                MenuItem5.RadioCheck = CurrentMenuItem.RadioCheck;
				|                MenuItem5.Checked = CurrentMenuItem.Checked;
				|                MenuItem5.MergeOrder = CurrentMenuItem.MergeOrder;
				|                MenuItem5.Shortcut = (int)CurrentMenuItem.Shortcut;
				|                MenuItem5.Text = CurrentMenuItem.Text;
				|                MenuItem5.MergeType = (int)CurrentMenuItem.MergeType;
				|
				|                MenuItem NewMenuItem = MenuItem.MenuItems.Add(MenuItem5);
				|                if (CurrentMenuItem.MenuItems.Count > 0)
				|                {
				|                    BypassMenu(NewMenuItem, CurrentMenuItem.MenuItems);
				|                }
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ДобавитьЭлемент") и (ИмяКонтекстКлассаАнгл = "DataColumnCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""ДобавитьЭлемент"", ""AddItem"")]
				|        public ClDataColumn AddItem(string p1)
				|        {
				|            return new ClDataColumn(Base_obj.AddItem(p1));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СловарнаяЗапись") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""СловарнаяЗапись"", ""DictionaryEntry"")]
				|        public ClDictionaryEntry DictionaryEntry(IValue p1, IValue p2)
				|        {
				|            return new ClDictionaryEntry(p1, p2);
				|        }
				|
				|";
			ИначеЕсли МетодРус = "АКосинус" Тогда
				Стр = Стр + 
				"        [ContextMethod(""АКосинус"", ""Acos"")]
				|        public double Acos(double p1)
				|        {
				|            return System.Math.Acos(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "АСинус" Тогда
				Стр = Стр + 
				"        [ContextMethod(""АСинус"", ""Asin"")]
				|        public double Asin(double p1)
				|        {
				|            return System.Math.Asin(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "АТангенс" Тогда
				Стр = Стр + 
				"        [ContextMethod(""АТангенс"", ""Atan"")]
				|        public double Atan(double p1)
				|        {
				|            return System.Math.Atan(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "АТангенс2" Тогда
				Стр = Стр + 
				"        [ContextMethod(""АТангенс2"", ""Atan2"")]
				|        public double Atan2(double p1, double p2)
				|        {
 				|           return System.Math.Atan2(p1, p2);
 				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ГКосинус" Тогда
				Стр = Стр + 
				"        [ContextMethod(""ГКосинус"", ""Cosh"")]
				|        public double Cosh(double p1)
				|        {
				|            return System.Math.Cosh(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ГСинус" Тогда
				Стр = Стр + 
				"        [ContextMethod(""ГСинус"", ""Sinh"")]
				|        public double Sinh(double p1)
				|        {
				|            return System.Math.Sinh(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ГТангенс" Тогда
				Стр = Стр + 
				"        [ContextMethod(""ГТангенс"", ""Tanh"")]
				|        public double Tanh(double p1)
				|        {
				|            return System.Math.Tanh(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ККорень" Тогда
				Стр = Стр + 
				"        [ContextMethod(""ККорень"", ""Sqrt"")]
				|        public double Sqrt(double p1)
				|        {
				|            return System.Math.Sqrt(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Косинус" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Косинус"", ""Cos"")]
				|        public double Cos(double p1)
				|        {
				|            return System.Math.Cos(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Логарифм" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Логарифм"", ""Log"")]
				|        public double Log(double p1)
				|        {
				|            return System.Math.Log(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Логарифм10" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Логарифм10"", ""Log10"")]
				|        public double Log10(double p1)
				|        {
				|            return System.Math.Log10(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "НаибольшееЦелое" Тогда
				Стр = Стр + 
				"        [ContextMethod(""НаибольшееЦелое"", ""Floor"")]
				|        public double Floor(double p1)
				|        {
				|            return System.Math.Floor(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "НаименьшееЦел" Тогда
				Стр = Стр + 
				"        [ContextMethod(""НаименьшееЦел"", ""Ceiling"")]
				|        public double Ceiling(double p1)
				|        {
				|            return System.Math.Ceiling(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Окр" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Окр"", ""Round"")]
				|        public double Round(double p1, int p2)
				|        {
				|            return System.Math.Round(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Синус" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Синус"", ""Sin"")]
				|        public double Sin(double p1)
				|        {
				|            return System.Math.Sin(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Случайное" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Случайное"", ""Random"")]
				|        public double Random()
				|        {
				|            return OneScriptForms.Random.NextDouble();
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Степень" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Степень"", ""Pow"")]
				|        public double Pow(double p1, double p2)
				|        {
				|            return System.Math.Pow(p1, p2);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Тангенс" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Тангенс"", ""Tan"")]
				|        public double Tan(double p1)
				|        {
				|            return System.Math.Tan(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "Экспонента" Тогда
				Стр = Стр + 
				"        [ContextMethod(""Экспонента"", ""Exp"")]
				|        public double Exp(double p1)
				|        {
				|            return System.Math.Exp(p1);
				|        }
				|        
				|";
			ИначеЕсли МетодРус = "ПолучитьГлавноеМеню" Тогда
				Стр = Стр + 
				"        [ContextMethod(""ПолучитьГлавноеМеню"", ""GetMainMenu"")]
 				|        public ClMainMenu GetMainMenu()
				|        {
				|            return (ClMainMenu)OneScriptForms.RevertObj(Base_obj.GetMainMenu());
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDictionaryEntry Item(object p1, IValue p2 = null)
				|        {
				|            System.Collections.SortedList SortedList1 = Base_obj.M_SortedList;
				|            if (p2 != null)
				|            {
				|                SortedList1[p1] = p2;
				|            }
				|            DictionaryEntry DictionaryEntry1 = new DictionaryEntry(p1, SortedList1[p1]);
				|            return new ClDictionaryEntry(DictionaryEntry1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "DataTableCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public ClDataTable Add(ClDataTable p1)
				|        {
				|            return (ClDataTable)OneScriptForms.RevertObj(Base_obj.Add(p1.Base_obj));
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ПолучитьПодсказку") и (ИмяКонтекстКлассаАнгл = "ToolTip") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьПодсказку"", ""GetToolTip"")]
				|        public string GetToolTip(IValue p1)
				|        {
				|            return Base_obj.GetToolTip(((dynamic)p1).Base_obj);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "УстановитьПодсказку") и (ИмяКонтекстКлассаАнгл = "ToolTip") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьПодсказку"", ""SetToolTip"")]
				|        public void SetToolTip(IValue p1, string p2)
				|        {
				|            Base_obj.SetToolTip(((dynamic)p1).Base_obj, p2);
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "ВысотаЭлемента") и (ИмяКонтекстКлассаАнгл = "ComboBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВысотаЭлемента"", ""HeightItem"")]
				|        public int HeightItem(int p1, IValue p2 = null)
				|        {
				|            if (m_obj.DrawMode == 2)
				|            {
				|                if (p2 != null)
				|                {
				|                    heightItems.RemoveAt(p1);
				|                    heightItems.Insert(p1, Convert.ToInt32(p2.AsNumber()));
				|                    return Convert.ToInt32(p2.AsNumber());
				|                }
				|                else
				|                {
				|                    System.Collections.ArrayList ArrayList2 = (System.Collections.ArrayList)heightItems.M_ArrayList;
				|                    return (int)ArrayList2[p1];
				|                }
				|            }
				|            return m_obj.Height;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ListBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1)
				|        {
				|            osf.ClListItem p2;
				|            if (p1.GetType().ToString().Contains(""osf.ClListItem""))
				|            {
				|                p2 = new ClListItem(((osf.ClListItem)p1).Base_obj);
				|            }
				|            else
				|            {
				|                string s = """";
				|                try
				|                {
				|                    s = p1.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
				|                }
				|                catch
				|                {
				|                    s = p1.ToString();
				|                }
				|                p2 = new ClListItem(new ListItem(s, p1));
				|            }
				|            Base_obj.Add(p2.Base_obj);
				|            return p2;
				|        }
				|        
				|";
			ИначеЕсли (МетодРус = "Добавить") и (ИмяКонтекстКлассаАнгл = "ComboBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Добавить"", ""Add"")]
				|        public IValue Add(IValue p1)
				|        {
				|            m_obj.Base_obj.HeightItems.Add(ValueFactory.Create(m_obj.ItemHeight));
				|            osf.ClListItem p2;
				|            if (p1.GetType().ToString().Contains(""osf.ClListItem""))
				|            {
				|                p2 = new ClListItem(((osf.ClListItem)p1).Base_obj);
				|            }
				|            else
				|            {
				|                string s = """";
				|                try
				|                {
				|                    s = p1.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
				|                }
				|                catch
				|                {
				|                    s = p1.ToString();
				|                }
				|                p2 = new ClListItem(new ListItem(s, p1));
				|            }
				|            Base_obj.Add(p2.Base_obj);
				|            return p2;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ДобавитьНовуюСтроку") и (ИмяКонтекстКлассаАнгл = "DataView") Тогда
				Стр = Стр +
				"        [ContextMethod(""ДобавитьНовуюСтроку"", ""AddNew"")]
				|        public ClDataRowView AddNew()
				|        {
				|            return new ClDataRowView(Base_obj.AddNew());
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ВключитьВизуальныеСтили") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВключитьВизуальныеСтили"", ""EnableVisualStyles"")]
				|        public void EnableVisualStyles()
				|        {
				|            System.Windows.Forms.Application.EnableVisualStyles();
				|            System.Windows.Forms.Application.DoEvents();
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ТекстурнаяКисть") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""ТекстурнаяКисть"", ""TextureBrush"")]
				|        public ClTextureBrush TextureBrush(IValue p1)
				|        {
				|            return new ClTextureBrush(((dynamic)p1).Base_obj);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Прямоугольник") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""Прямоугольник"", ""Rectangle"")]
				|        public ClRectangle Rectangle(IValue p1 = null, int p2 = 0, int p3 = 0, int p4 = 0)
				|        {
				|            if (p1 is osf.ClSize)
				|            {
				|                return new ClRectangle(0, 0, ((dynamic)p1).Base_obj.Width, ((dynamic)p1).Base_obj.Height);
				|            }
				|            else if (p1 == null)
				|            {
				|                int p5 = 0;
				|                return new ClRectangle(p5, p2, p3, p4);
				|            }
				|            else
				|            {
				|                int p5 = Convert.ToInt32(p1.AsNumber());
				|                return new ClRectangle(p5, p2, p3, p4);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            return OneScriptForms.RevertObj((osf.Control)Base_obj[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "УстановитьСвязьДанных") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextMethod(""УстановитьСвязьДанных"", ""SetDataBinding"")]
				|        public void SetDataBinding(IValue p1, string p2 = null)
				|        {
				|            dynamic p3 = p1.AsObject();
				|            Base_obj.SetDataBinding(p3.Base_obj, p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Выбрать") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Выбрать"", ""Select"")]
				|        public ClArrayList Select(string p1)
				|        {
				|            ClArrayList ClArrayList1 = new ClArrayList();
				|            try
				|            {
				|                object[] objects = Base_obj.Select(p1);
				|                for (int i = 0; i < objects.Length; i++)
				|                {
				|                    ClArrayList1.Base_obj.Add(new ClDataRow((osf.DataRow)objects[i]));
				|                }
				|            }
				|            catch
				|            {
				|            }
				|            return ClArrayList1;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ВыгрузитьКолонку") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВыгрузитьКолонку"", ""UnloadColumn"")]
				|        public ClArrayList UnloadColumn(IValue p1)
				|        {
				|            ClArrayList ClArrayList1 = new ClArrayList();
				|            if (p1.SystemType.Name == ""Число"")
				|            {
				|                for (int i = 0; i < Base_obj.Rows.Count; i++)
				|                {
				|                    dynamic p2 = Base_obj.Rows[i].get_Item(Convert.ToInt32(p1.AsNumber()));
				|                    ClArrayList1.Base_obj.Add(p2.Value);
				|                }
				|                return ClArrayList1;
				|            }
				|            else if (p1.SystemType.Name == ""Строка"")
				|            {
				|                for (int i = 0; i < Base_obj.Rows.Count; i++)
				|                {
				|                    dynamic p2 = Base_obj.Rows[i].get_Item(p1.AsString());
				|                    ClArrayList1.Base_obj.Add(p2.Value);
				|                }
				|                return ClArrayList1;
				|            }
				|            else if (p1.SystemType.Name == ""КлКолонкаДанных"")
				|            {
				|                for (int i = 0; i < Base_obj.Rows.Count; i++)
				|                {
				|                    dynamic p2 = Base_obj.Rows[i].get_Item(((ClDataColumn)p1.AsObject()).Base_obj.ColumnName);
				|                    ClArrayList1.Base_obj.Add(p2.Value);
				|                }
				|                return ClArrayList1;
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ГраницыТекущейЯчейки") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextMethod(""ГраницыТекущейЯчейки"", ""GetCurrentCellBounds"")]
				|        public ClRectangle GetCurrentCellBounds()
				|        {
				|            return new ClRectangle(Base_obj.GetCurrentCellBounds());
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Цвет") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""Цвет"", ""Color"")]
				|        public ClColor Color(IValue p1 = null, int p2 = 0, int p3 = 0)
				|        {
				|            if (p1 != null)
				|            {
				|                if (p1.SystemType.Name == ""Строка"")
				|                {
				|                    ClColor ClColor1 = new ClColor();
				|                    int NumberProp1 = ClColor1.FindProperty(p1.AsString());
				|                    dynamic obj1 = ClColor1.GetPropValue(NumberProp1);
				|                    return (ClColor)ValueFactory.Create(obj1);
				|                }
				|                if (p1.SystemType.Name == ""Число"")
				|                {
				|                    Color Color1 = new Color(System.Drawing.Color.FromArgb(Convert.ToInt32(p1.AsNumber()), p2, p3));
				|                    return new ClColor(Color1);
				|                }
				|            }
				|            return new ClColor();
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "GridColumnStylesCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1)
				|        {
				|            return OneScriptForms.RevertObj(((dynamic)Base_obj[p1].M_DataGridColumnStyle).M_Object);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьПоИндексу") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьПоИндексу"", ""GetByIndex"")]
				|        public IValue GetByIndex(int p1)
				|        {
				|            return (IValue)Base_obj.GetByIndex(p1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Блокировать") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""Блокировать"", ""LockBits"")]
				|        public ClBitmapData LockBits()
				|        {
				|            return new ClBitmapData(Base_obj.LockBits());
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Разблокировать") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""Разблокировать"", ""UnlockBits"")]
				|        public void UnlockBits(ClBitmapData p1)
				|        {
				|            Base_obj.UnlockBits(p1.Base_obj);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьПиксель") и (ИмяКонтекстКлассаАнгл = "Bitmap") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьПиксель"", ""GetPixel"")]
				|        public ClColor GetPixel(int p1, int p2)
				|        {
				|            return new ClColor(Base_obj.GetPixel(p1, p2));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьЭлемент") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьЭлемент"", ""GetItemAt"")]
				|        public ClListViewItem GetItemAt(int p1, int p2)
				|        {
				|            return new ClListViewItem(Base_obj.GetItemAt(p1, p2));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Четное") и (ИмяКонтекстКлассаАнгл = "Math") Тогда
				Стр = Стр +
				"        [ContextMethod(""Четное"", ""Even"")]
				|        public IValue Even(IValue p1)
				|        {
				|            if (p1.AsNumber() - (System.Math.Floor(p1.AsNumber())) > 0)
				|            {
				|                return null;
				|            }
				|            return ValueFactory.Create((p1.AsNumber() % 2) == 0);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЗагрузитьФайл") и (ИмяКонтекстКлассаАнгл = "RichTextBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЗагрузитьФайл"", ""LoadFile"")]
				|        public void LoadFile(string p1, int p2)
				|        {
				|            Base_obj.LoadFile(p1, (System.Windows.Forms.RichTextBoxStreamType)p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Поиск") и (ИмяКонтекстКлассаАнгл = "RichTextBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""Поиск"", ""Find"")]
				|        public int Find(string p1, int p2, int p3)
				|        {
				|            return Base_obj.Find(p1, p2, (System.Windows.Forms.RichTextBoxFinds)p3);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СохранитьФайл") и (ИмяКонтекстКлассаАнгл = "RichTextBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""СохранитьФайл"", ""SaveFile"")]
				|        public void SaveFile(string p1, int p2)
				|        {
				|            Base_obj.SaveFile(p1, (System.Windows.Forms.RichTextBoxStreamType)p2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "DataRowCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""InsertAt"")]
				|        public ClDataRow InsertAt(ClDataRow p1, int p2)
				|        {
				|            return new ClDataRow(Base_obj.InsertAt(p1.Base_obj, p2));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Удалить") и (ИмяКонтекстКлассаАнгл = "DataTableCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Удалить"", ""Remove"")]
				|        public void Remove(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                Base_obj.Remove(p1.AsString());
				|            }
				|            else
				|            {
				|                Base_obj.Remove(((dynamic)p1).Base_obj);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "DataTableCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClDataTable Item(IValue p1)
				|        {
				|            ClDataTable ClDataTable1 = new ClDataTable();
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return new ClDataTable(Base_obj[p1.AsString()]);
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                return new ClDataTable(Base_obj[Convert.ToInt32(p1.AsNumber())]);
				|            }
				|            else
				|            {
				|                return null;
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЕжегодныеДаты") и (ИмяКонтекстКлассаАнгл = "MonthCalendar") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЕжегодныеДаты"", ""AnnuallyBoldedDates"")]
				|        public DateTime AnnuallyBoldedDates2(int p1)
				|        {
				|            return AnnuallyBoldedDates.Item(p1).AsDate();
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ВыделенныеДаты") и (ИмяКонтекстКлассаАнгл = "MonthCalendar") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВыделенныеДаты"", ""BoldedDates"")]
				|        public DateTime BoldedDates2(int p1)
				|        {
				|            return BoldedDates.Item(p1).AsDate();
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЕжемесячныеДаты") и (ИмяКонтекстКлассаАнгл = "MonthCalendar") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЕжемесячныеДаты"", ""MonthlyBoldedDates"")]
				|        public DateTime MonthlyBoldedDates2(int p1)
				|        {
				|            return MonthlyBoldedDates.Item(p1).AsDate();
				|        }
				|
				|";
			ИначеЕсли МетодРус = "ЭлементыУправления" Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементыУправления"", ""Controls"")]
				|        public IValue Controls2(int p1)
				|        {
				|            return OneScriptForms.RevertObj(Base_obj.Controls2(p1));
				|        }
				|
				|";
			ИначеЕсли МетодРус = "ЭлементыМеню" Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементыМеню"", ""MenuItems"")]
				|        public ClMenuItem MenuItems2(int p1)
				|        {
				|            return (ClMenuItem)OneScriptForms.RevertObj(Base_obj.MenuItems[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Колонки") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Колонки"", ""Columns"")]
				|        public ClDataColumn Columns2(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Число"")
				|            {
				|                return ((DataColumnEx)Base_obj.M_DataTable.Columns[Convert.ToInt32(p1.AsNumber())]).M_Object.dll_obj;
				|            }
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return ((DataColumnEx)Base_obj.M_DataTable.Columns[p1.AsString()]).M_Object.dll_obj;
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Изображения") и (ИмяКонтекстКлассаАнгл = "ImageList") Тогда
				Стр = Стр +
				"        [ContextMethod(""Изображения"", ""Images"")]
				|        public ClBitmap Images2(int p1)
				|        {
				|            return new ClBitmap(Base_obj.Images[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Кнопки") и (ИмяКонтекстКлассаАнгл = "ToolBar") Тогда
				Стр = Стр +
				"        [ContextMethod(""Кнопки"", ""Buttons"")]
				|        public ClToolBarButton Buttons2(int p1)
				|        {
				|            return (ClToolBarButton)OneScriptForms.RevertObj(Base_obj.Buttons[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Ссылки") и (ИмяКонтекстКлассаАнгл = "LinkLabel") Тогда
				Стр = Стр +
				"        [ContextMethod(""Ссылки"", ""Links"")]
				|        public ClLink Links2(int p1)
				|        {
				|            return (ClLink)OneScriptForms.RevertObj(Base_obj.Links[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ИндексыВыбранных") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""ИндексыВыбранных"", ""SelectedIndices"")]
				|        public int SelectedIndices2(int p1)
				|        {
				|            return Base_obj.SelectedIndices[p1];
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Панели") и (ИмяКонтекстКлассаАнгл = "StatusBar") Тогда
				Стр = Стр +
				"        [ContextMethod(""Панели"", ""Panels"")]
				|        public ClStatusBarPanel Panels2(int p1)
				|        {
				|            return (ClStatusBarPanel)OneScriptForms.RevertObj(Base_obj.Panels[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СтилиТаблицы") и (ИмяКонтекстКлассаАнгл = "DataGrid") Тогда
				Стр = Стр +
				"        [ContextMethod(""СтилиТаблицы"", ""TableStyles"")]
				|        public ClDataGridTableStyle TableStyles2(int p1)
				|        {
				|            return (ClDataGridTableStyle)OneScriptForms.RevertObj(Base_obj.TableStyles[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЭтоПодкласс") и (ИмяКонтекстКлассаАнгл = "Type") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭтоПодкласс"", ""IsSubclassOf"")]
				|        public bool IsSubclassOf(ClType p1)
				|        {
				|            string str1 = Base_obj.ToString();
				|            string str2 = p1.Base_obj.ToString();
				|            System.Type Type1 = System.Type.GetType(str1.Replace(""osf.Cl"", ""osf.""));
				|            System.Type Type2 = System.Type.GetType(str2.Replace(""osf.Cl"", ""osf.""));
				|            return Type1.IsSubclassOf(Type2);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЭтоЭкземплярТипа") и (ИмяКонтекстКлассаАнгл = "Type") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭтоЭкземплярТипа"", ""IsInstanceOfType"")]
				|        public bool IsInstanceOfType(IValue p1)
				|        {
				|            string str1 = Base_obj.ToString();
				|            System.Type Type1 = System.Type.GetType(str1.Replace(""osf.Cl"", ""osf.""));
				|            return Type1.IsInstanceOfType(((dynamic)p1).Base_obj);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Узлы") и (ИмяКонтекстКлассаАнгл = "TreeNode") Тогда
				Стр = Стр +
				"        [ContextMethod(""Узлы"", ""Nodes"")]
				|        public ClTreeNode Nodes2(int p1)
				|        {
				|            return new ClTreeNode(Base_obj.Nodes[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "TreeNodeCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClTreeNode Insert(int p1, ClTreeNode p2)
				|        {
				|            return new ClTreeNode(Base_obj.Insert(p1, p2.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "TreeNodeCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public ClTreeNode Item(int p1)
				|        {
				|            return (ClTreeNode)OneScriptForms.RevertObj(Base_obj[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "HashTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(IValue p1)
				|        {
				|            return (IValue)Base_obj.get_Item(p1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПолучитьArgb") и (ИмяКонтекстКлассаАнгл = "Color") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПолучитьArgb"", ""ToArgb"")]
				|        public int ToArgb()
				|        {
				|            return (Base_obj.R * 65536) + (Base_obj.G * 256) + Base_obj.B;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ЭлементыСетки") и (ИмяКонтекстКлассаАнгл = "PropertyGrid") Тогда
				Стр = Стр +
				"        [ContextMethod(""ЭлементыСетки"", ""GridItems"")]
				|        public ClGridItem GridItems2(IValue p1)
				|        {
				|            object comp = Base_obj.M_PropertyGrid;
				|            object comp1 = new System.Windows.Forms.PropertyGrid();
				|            System.Type comp1Type = comp1.GetType();
				|            object view = comp1Type.GetField(""gridView"", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(comp);
				|            System.Windows.Forms.GridItemCollection GridItemCollection1 = (System.Windows.Forms.GridItemCollection)view.GetType().InvokeMember(
				|                ""GetAllGridEntries"", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, view, null);
				|            osf.GridItemCollection GridItemCollection2 = new osf.GridItemCollection(GridItemCollection1);
				|            if (p1.SystemType.Name == ""Число"")
				|            {
				|                return new ClGridItem(GridItemCollection2[Convert.ToInt32(p1.AsNumber())]);
				|            }
				|            return new ClGridItem(GridItemCollection2[p1.AsString()]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элемент") и (ИмяКонтекстКлассаАнгл = "ComboBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элемент"", ""Item"")]
				|        public IValue Item(int p1, IValue p2 = null)
				|        {
				|            osf.ListItem ListItem1 = new osf.ListItem();
				|            if (p2 != null)
				|            {
				|                Base_obj.RemoveAt(p1);
				|                if (p2.GetType().ToString().Contains(""osf.ClListItem""))
				|                {
				|                    ListItem1 = ((dynamic)p2).Base_obj;
				|                }
				|                else
				|                {
				|                    ListItem1 = new osf.ListItem(p2.ToString(), p2);
				|                }
				|                Base_obj.Insert(p1, ListItem1);
				|            }
				|            else
				|            {
				|                if (Base_obj[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|                {
				|                    osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj[p1]);
				|                    ListItem1.Text = DataRowView1.get_Item(m_obj.Base_obj.DisplayMember).ToString();
				|                    ListItem1.Value = DataRowView1.get_Item(m_obj.Base_obj.ValueMember);
				|                }
				|                else if (Base_obj[p1].GetType().ToString() == ""osf.ListItem"")
				|                {
				|                    ListItem1 = (osf.ListItem)Base_obj[p1];
				|                }
				|                else
				|                {
				|                    ListItem1.Text = Base_obj[p1].ToString();
				|                    ListItem1.Value = Base_obj[p1];
				|                    ListItem1.ForeColor = ((dynamic)Base_obj[p1]).ForeColor;
				|                }
				|            }
				|            return (IValue)new ClListItem(ListItem1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элементы") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элементы"", ""Items"")]
				|        public ClListViewItem Items2(int p1)
				|        {
				|            return new ClListViewItem(Base_obj.Items[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элементы") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элементы"", ""Items"")]
				|        public ClListItem Items2(int p1)
				|        {
				|            osf.ListItem ListItem1 = new osf.ListItem();
				|            if (Base_obj.Items[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|            {
				|                osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj.Items[p1]);
				|                ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
				|                ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
				|            }
				|            else if (Base_obj.Items[p1].GetType().ToString() == ""osf.ListItem"")
				|            {
				|                ListItem1 = (osf.ListItem)Base_obj.Items[p1];
				|            }
				|            else
				|            {
				|                ListItem1.Text = Base_obj.Items[p1].ToString();
				|                ListItem1.Value = Base_obj.Items[p1];
				|                try
				|                {
				|                    ListItem1.ForeColor = ((dynamic)Base_obj.Items[p1]).ForeColor.Base_obj;
				|                }
				|                catch
				|                {
				|                }
				|            }
				|            return new ClListItem(ListItem1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Подэлементы") и (ИмяКонтекстКлассаАнгл = "ListViewItem") Тогда
				Стр = Стр +
				"        [ContextMethod(""Подэлементы"", ""SubItems"")]
				|        public ClListViewSubItem SubItems2(int p1)
				|        {
				|            return new ClListViewSubItem(Base_obj.SubItems[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Удалить") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Удалить"", ""Remove"")]
				|        public void Remove(IValue p1)
				|        {
				|            Base_obj.Remove(((dynamic)p1).Base_obj);
				|        }
				|
				|";
			ИначеЕсли МетодРус = "ВозобновитьРазмещение" Тогда
				Стр = Стр +
				"        [ContextMethod(""ВозобновитьРазмещение"", ""ResumeLayout"")]
				|        public void ResumeLayout(bool p1 = false)
				|        {
				|            Base_obj.ResumeLayout(p1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ComboBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public IValue Insert(int p1, IValue p2)
				|        {
				|            heightItems.Insert(p1, ValueFactory.Create(m_obj._HeightItems));
				|            osf.ClListItem p3 = new ClListItem();
				|            if (p2.GetType().ToString().Contains(""osf.ClListItem""))
				|            {
				|                p3.Base_obj = ((osf.ClListItem)p2).Base_obj;
				|            }
				|            else
				|            {
				|                p3.Base_obj = new ListItem(p2.ToString(), p2);
				|            }
				|            Base_obj.Insert(p1, p3.Base_obj);
				|            return p3;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ListBoxObjectCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public IValue Insert(int p1, IValue p2)
				|        {
				|            osf.ClListItem p3 = new ClListItem();
				|            if (p2.GetType().ToString().Contains(""osf.ClListItem""))
				|            {
				|                p3.Base_obj = ((osf.ClListItem)p2).Base_obj;
				|            }
				|            else
				|            {
				|                p3.Base_obj = new ListItem(p2.ToString(), p2);
				|            }
				|            Base_obj.Insert(p1, p3.Base_obj);
				|            return p3;
				|        }
				|
				|";
			ИначеЕсли МетодРус = "ТочкаНаКлиенте" Тогда
				Стр = Стр +
				"        [ContextMethod(""ТочкаНаКлиенте"", ""PointToClient"")]
				|        public ClPoint PointToClient(ClPoint p1)
				|        {
				|            return new ClPoint(Base_obj.PointToClient(p1.Base_obj));
				|        }
				|
				|";
			ИначеЕсли МетодРус = "ТочкаНаЭкране" Тогда
				Стр = Стр +
				"        [ContextMethod(""ТочкаНаЭкране"", ""PointToScreen"")]
				|        public ClPoint PointToScreen(ClPoint p1)
				|        {
				|            return new ClPoint(Base_obj.PointToScreen(p1.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Содержит") и (ИмяКонтекстКлассаАнгл = "ControlCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Содержит"", ""Contains"")]
				|        public bool Contains(IValue p1)
				|        {
				|            return Base_obj.Contains(((dynamic)p1).Base_obj);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СодержитКлюч") и (ИмяКонтекстКлассаАнгл = "SortedList") Тогда
				Стр = Стр +
				"        [ContextMethod(""СодержитКлюч"", ""ContainsKey"")]
				|        public bool ContainsKey(object p1)
				|        {
				|            return Base_obj.ContainsKey(p1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вставить") и (ИмяКонтекстКлассаАнгл = "ListViewItemCollection") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вставить"", ""Insert"")]
				|        public ClListViewItem Insert(int p1, ClListViewItem p2)
				|        {
				|            return new ClListViewItem(Base_obj.Insert(p1, p2.Base_obj));
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Элементы") и (ИмяКонтекстКлассаАнгл = "ComboBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""Элементы"", ""Items"")]
				|        public ClListItem Items2(int p1)
				|        {
				|            osf.ListItem ListItem1 = new osf.ListItem();
				|            if (Base_obj.Items[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|            {
				|                osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj.Items[p1]);
				|                ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
				|                ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
				|            }
				|            else if (Base_obj.Items[p1].GetType().ToString() == ""osf.ListItem"")
				|            {
				|                ListItem1 = (osf.ListItem)Base_obj.Items[p1];
				|            }
				|            else
				|            {
				|                ListItem1.Text = Base_obj.Items[p1].ToString();
				|                ListItem1.Value = Base_obj.Items[p1];
				|                try
				|                {
				|                    ListItem1.ForeColor = ((dynamic)Base_obj.Items[p1]).ForeColor.Base_obj;
				|                }
				|                catch
				|                {
				|                }
				|            }
				|            return new ClListItem(ListItem1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СтилиКолонкиСеткиДанных") и (ИмяКонтекстКлассаАнгл = "DataGridTableStyle") Тогда
				Стр = Стр +
				"        [ContextMethod(""СтилиКолонкиСеткиДанных"", ""GridColumnStyles"")]
				|        public IValue GridColumnStyles2(int p1)
				|        {
				|            try
				|            {
				|                return ((dynamic)Base_obj.GridColumnStyles.M_GridColumnStylesCollection[p1]).M_Object.dll_obj;
				|            }
				|            catch
				|            {
				|                return new ClDataGridComboBoxColumnStyle((dynamic)Base_obj.GridColumnStyles.M_GridColumnStylesCollection[p1]);
				|            }
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Таблицы") и (ИмяКонтекстКлассаАнгл = "DataSet") Тогда
				Стр = Стр +
				"        [ContextMethod(""Таблицы"", ""Tables"")]
				|        public ClDataTable Tables2(IValue p1)
				|        {
				|            if (p1.SystemType.Name == ""Строка"")
				|            {
				|                return Base_obj.Tables[p1.AsString()].dll_obj;
				|            }
				|            else if (p1.SystemType.Name == ""Число"")
				|            {
				|                return Base_obj.Tables[Convert.ToInt32(p1.AsNumber())].dll_obj;
				|            }
				|            return null;
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Строки") и (ИмяКонтекстКлассаАнгл = "DataTable") Тогда
				Стр = Стр +
				"        [ContextMethod(""Строки"", ""Rows"")]
				|        public ClDataRow Rows2(int p1)
				|        {
				|            return new ClDataRow(Base_obj.Rows[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ВыбранныеЭлементы") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВыбранныеЭлементы"", ""SelectedItems"")]
				|        public ClListViewItem SelectedItems2(int p1)
				|        {
				|            return new ClListViewItem(Base_obj.SelectedItems[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Колонки") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextMethod(""Колонки"", ""Columns"")]
				|        public ClColumnHeader Columns2(int p1)
				|        {
				|            return new ClColumnHeader(Base_obj.Columns[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПомеченныеЭлементы") и (ИмяКонтекстКлассаАнгл = "ListView") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПомеченныеЭлементы"", ""CheckedItems"")]
				|        public ClListViewItem CheckedItems2(int p1)
				|        {
				|            return new ClListViewItem(Base_obj.CheckedItems[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ВыбранныеЭлементы") и (ИмяКонтекстКлассаАнгл = "ListBox") Тогда
				Стр = Стр +
				"        [ContextMethod(""ВыбранныеЭлементы"", ""SelectedItems"")]
				|        public IValue SelectedItems2(int p1)
				|        {
				|            osf.ListItem ListItem1 = new osf.ListItem();
				|            if (Base_obj.SelectedItems[p1].GetType().ToString() == ""System.Data.DataRowView"")
				|            {
				|                osf.DataRowView DataRowView1 = new osf.DataRowView((System.Data.DataRowView)Base_obj.SelectedItems[p1]);
				|                ListItem1.Text = DataRowView1.get_Item(Base_obj.DisplayMember).ToString();
				|                ListItem1.Value = DataRowView1.get_Item(Base_obj.ValueMember);
				|            }
				|            else if (Base_obj.SelectedItems[p1].GetType().ToString() == ""osf.ListItem"")
				|            {
				|                ListItem1 = (osf.ListItem)Base_obj.SelectedItems[p1];
				|            }
				|            else
				|            {
				|                ListItem1.Text = Base_obj.SelectedItems[p1].ToString();
				|                ListItem1.Value = Base_obj.SelectedItems[p1];
				|                try
				|                {
				|                    ListItem1.ForeColor = ((dynamic)Base_obj.SelectedItems[p1]).ForeColor.Base_obj;
				|                }
				|                catch
				|                {
				|                }
				|            }
				|            return new ClListItem(ListItem1);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "Вкладки") и (ИмяКонтекстКлассаАнгл = "TabControl") Тогда
				Стр = Стр +
				"        [ContextMethod(""Вкладки"", ""TabPages"")]
				|        public ClTabPage TabPages2(int p1)
				|        {
				|            return (ClTabPage)OneScriptForms.RevertObj(Base_obj.TabPages[p1]);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ПоказатьДиалог") и (ИмяКонтекстКлассаАнгл = "Form") Тогда
				Стр = Стр +
				"        [ContextMethod(""ПоказатьДиалог"", ""ShowDialog"")]
				|        public int ShowDialog()
				|        {
				|            return Base_obj.ShowDialog();
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "ВосстановитьКонсоль") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [DllImport(""User32"")] private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
				|
				|        [ContextMethod(""ВосстановитьКонсоль"", ""RestoreConsole"")]
				|        public void RestoreConsole()
				|        {
				|            ShowWindow(GetConsoleWindow(), 9);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СкрытьКонсоль") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [DllImport(""kernel32.dll"")] static extern IntPtr GetConsoleWindow();
				|
				|        [ContextMethod(""СкрытьКонсоль"", ""HideConsole"")]
				|        public void HideConsole()
				|        {
				|            ShowWindow(GetConsoleWindow(), 0);
				|        }
				|
				|";
			ИначеЕсли (МетодРус = "СвернутьКонсоль") и (ИмяКонтекстКлассаАнгл = "OneScriptForms") Тогда
				Стр = Стр +
				"        [ContextMethod(""СвернутьКонсоль"", ""MinimizedConsole"")]
				|        public void MinimizedConsole()
				|        {
				|            ShowWindow(GetConsoleWindow(), 7);
				|        }
				|
				|";
				
				
				
				
				
				
				
				
				
			
			
			
			Иначе
				ИмяФайлаМетода = "C:\444\OneScriptFormsru\" + СтрНайтиМежду(СтрХ, "<A href=""", """>", , )[0];
				ТекстДокМетода = Новый ТекстовыйДокумент;
				ТекстДокМетода.Прочитать(ИмяФайлаМетода);
				СтрТекстДокМетода = ТекстДокМетода.ПолучитьТекст();
				// Сообщить("===================================================");
				// Сообщить("ИмяФайлаМетода = " + ИмяФайлаМетода);
				// Сообщить("СтрТекстДокМетода = " + СтрТекстДокМетода);
				СтрРаздела = СтрНайтиМежду(СтрТекстДокМетода, "<H4 class=dtH4>Параметры</H4>", "<H4 class=dtH4>Возвращаемое значение</H4>", , )[0];
				// <H4 class=dtH4>Параметры</H4>
				// <DL>
				// <DT><I>ИмяФайла</I> (обязательный)</DT>
				// <DD>Тип: Строка.</DD>
				// <DD>Строка, содержащая имя файла для сохранения этого объекта <A href="OneScriptForms.Image.html">Изображение&nbsp;(Image)</A>.</DD>
				
				// <DT><I>Формат</I> (необязательный)</DT>
				// <DD>Тип: <A href="OneScriptForms.ImageFormat.html">ФорматИзображения&nbsp;(ImageFormat)</A>.</DD>
				// <DD>Объект <A href="OneScriptForms.ImageFormat.html">ФорматИзображения&nbsp;(ImageFormat)</A> для этого 
				// объекта <A href="OneScriptForms.Image.html">Изображение&nbsp;(Image)</A>.</DD></DL>
				// <H4 class=dtH4>Возвращаемое значение</H4>
				М06 = СтрНайтиМежду(СтрРаздела, "<DT><I>", "</DD>", Ложь, );//Строка содержит параметр и тип параметра
				СтрПараметровВСкобках = "(";
				СтрПараметровВСкобках2 = "(";
				Для А01 = 0 По М06.ВГраница() Цикл
					М10 = СтрНайтиМежду(М06[А01], "<DD>", "</DD>", , );//Строка содержит тип параметра
					// Тип: Строка.
					// Тип: Число.
					// Тип: Булево.
					// Тип: Дата.
					// Тип: Произвольный.
					// Тип: Массив.
					// Тип: Строка; <A href="OneScriptForms.ColumnHeader.html">Колонка&nbsp;(ColumnHeader)</A>.
					// Тип: Строка; Число.
					// Тип: Строка; Число; <A href="OneScriptForms.DataColumn.html">КолонкаДанных&nbsp;(DataColumn)</A>.
					ТипПараметраВСкобках = "хххх";
					Если М10.Количество() > 0 Тогда
						// Сообщить("" + М10[0]);
						М11 = СтрНайтиМежду(М06[А01], "(", ")", , );
						Если М11.Количество() > 1 Тогда
							ТипПараметраВСкобках = "Cl" + М11[1];
							// если ТипПараметраВСкобках является перечислением, меняем его на int
							Если ИменаКалассовПеречислений.НайтиПоЗначению(ТипПараметраВСкобках) = Неопределено Тогда
							Иначе
								ТипПараметраВСкобках = "int";
							КонецЕсли;
						Иначе
							Если М10[0] = "Тип: Строка." Тогда
								ТипПараметраВСкобках = "string";
							ИначеЕсли М10[0] = "Тип: Число." Тогда
								ТипПараметраВСкобках = "int";
							ИначеЕсли М10[0] = "Тип: Булево." Тогда
								ТипПараметраВСкобках = "bool";
							ИначеЕсли М10[0] = "Тип: Дата." Тогда
								ТипПараметраВСкобках = "DateTime";	
							ИначеЕсли М10[0] = "Тип: Произвольный." Тогда
								ТипПараметраВСкобках = "IValue";
							ИначеЕсли М10[0] = "Тип: Массив." Тогда
								ТипПараметраВСкобках = "dynamic";	
							ИначеЕсли СтрНайти(М10[0], ";") > 0 Тогда
								ТипПараметраВСкобках = "dynamic";
							Иначе
								Сообщить("Не хватает типа " + М10[0]);
								ЗавершитьРаботу(5);
							КонецЕсли;
						КонецЕсли;
					КонецЕсли;
					
					Если А01 = М06.ВГраница() Тогда
						Если СтрНайти(ТипПараметраВСкобках, "Cl") > 0 Тогда
							СтрПараметровВСкобках = СтрПараметровВСкобках + ТипПараметраВСкобках + " p" + Строка(А01 + 1);
							СтрПараметровВСкобках2 = СтрПараметровВСкобках2 + "p" + Строка(А01 + 1) + ".Base_obj";
						Иначе
							СтрПараметровВСкобках = СтрПараметровВСкобках + ТипПараметраВСкобках + " p" + Строка(А01 + 1);
							СтрПараметровВСкобках2 = СтрПараметровВСкобках2 + "p" + Строка(А01 + 1);
						КонецЕсли;
					Иначе
						Если СтрНайти(ТипПараметраВСкобках, "Cl") > 0 Тогда
							СтрПараметровВСкобках = СтрПараметровВСкобках + ТипПараметраВСкобках + " p" + Строка(А01 + 1) + ", ";
							СтрПараметровВСкобках2 = СтрПараметровВСкобках2 + "p" + Строка(А01 + 1) + ".Base_obj, ";
						Иначе
							СтрПараметровВСкобках = СтрПараметровВСкобках + ТипПараметраВСкобках + " p" + Строка(А01 + 1) + ", ";
							СтрПараметровВСкобках2 = СтрПараметровВСкобках2 + "p" + Строка(А01 + 1) + ", ";
						КонецЕсли;
					КонецЕсли;
					
				КонецЦикла;
				СтрПараметровВСкобках =СтрПараметровВСкобках + ")";
				СтрПараметровВСкобках2 =СтрПараметровВСкобках2 + ")";
				
				//найдем возвращаемое методом значение
				ВозвращаемоеМетодомЗначение = СтрНайтиМежду(СтрТекстДокМетода, "<H4 class=dtH4>Возвращаемое значение</H4>", "<H4 class=dtH4>Описание</H4>", , )[0];
				ВозвращаемоеМетодомЗначение = СтрНайтиМежду(ВозвращаемоеМетодомЗначение, "<P>", "</P>", , )[0];
				// Сообщить("" + МетодАнгл + " == " + ВозвращаемоеМетодомЗначение);
				// Сообщить("" + ВозвращаемоеМетодомЗначение);
				// Тип: Строка.
				// Тип: Число.
				// Тип: Булево.
				// Тип: Дата.
				// Тип: Произвольный.
				// Тип: <A href="OneScriptForms.Application.html">Приложение&nbsp;(Application)</A>.
				Комментарий = "//";
				Ретён = "return Base_obj." + МетодАнгл;
				Если СтрНайтиМежду(ВозвращаемоеМетодомЗначение, "(", ")", , ).Количество() > 0 Тогда // это класс
					ВозвращаемоеМетодомЗначение = "Cl" + СтрНайтиМежду(ВозвращаемоеМетодомЗначение, "(", ")", , )[0];
					Ретён = "return new " + ВозвращаемоеМетодомЗначение;
					//раскомментим если ВозвращаемоеМетодомЗначение равно
					Если (ВозвращаемоеМетодомЗначение = "ClPoint") или 
						(ВозвращаемоеМетодомЗначение = "ClForm") или 
						(ВозвращаемоеМетодомЗначение = "ClScreen") или 
						(ВозвращаемоеМетодомЗначение = "ClHashTable") или 
						(ВозвращаемоеМетодомЗначение = "ClCheckBox") или 
						(ВозвращаемоеМетодомЗначение = "ClDataGridComboBoxColumnStyle") или 
						(ВозвращаемоеМетодомЗначение = "ClRichTextBox") или 
						(ВозвращаемоеМетодомЗначение = "ClDataGridBoolColumn") или 
						(ВозвращаемоеМетодомЗначение = "ClNumericUpDown") или 
						(ВозвращаемоеМетодомЗначение = "ClGroupBox") или 
						(ВозвращаемоеМетодомЗначение = "ClSplitter") или 
						(ВозвращаемоеМетодомЗначение = "ClHatchBrush") или 
						(ВозвращаемоеМетодомЗначение = "ClTextureBrush") или 
						(ВозвращаемоеМетодомЗначение = "ClApplication") или 
						(ВозвращаемоеМетодомЗначение = "ClStreamReader") или 
						(ВозвращаемоеМетодомЗначение = "ClUserControl") или 
						(ВозвращаемоеМетодомЗначение = "ClDataView") или 
						(ВозвращаемоеМетодомЗначение = "ClDateTimePicker") или 
						(ВозвращаемоеМетодомЗначение = "ClComboBox") или 
						(ВозвращаемоеМетодомЗначение = "ClToolTip") или 
						(ВозвращаемоеМетодомЗначение = "ClRadioButton") или 
						(ВозвращаемоеМетодомЗначение = "ClStatusBarPanel") или 
						(ВозвращаемоеМетодомЗначение = "ClStatusBar") или 
						(ВозвращаемоеМетодомЗначение = "ClInputBox") или 
						(ВозвращаемоеМетодомЗначение = "ClLinkArea") или 
						(ВозвращаемоеМетодомЗначение = "ClDataSet") или 
						(ВозвращаемоеМетодомЗначение = "ClFileSystemWatcher") или 
						(ВозвращаемоеМетодомЗначение = "ClSortedList") или 
						(ВозвращаемоеМетодомЗначение = "ClMath") или 
						(ВозвращаемоеМетодомЗначение = "ClDataGridTextBoxColumn") или 
						(ВозвращаемоеМетодомЗначение = "ClDataGridTextBox") или 
						(ВозвращаемоеМетодомЗначение = "ClDataGridTableStyle") или 
						(ВозвращаемоеМетодомЗначение = "ClDataGrid") или 
						(ВозвращаемоеМетодомЗначение = "ClDataColumn") или 
						(ВозвращаемоеМетодомЗначение = "ClSolidBrush") или 
						(ВозвращаемоеМетодомЗначение = "ClRectangle") или 
						(ВозвращаемоеМетодомЗначение = "ClProgressBar") или 
						(ВозвращаемоеМетодомЗначение = "ClLinkLabel") или 
						(ВозвращаемоеМетодомЗначение = "ClLink") или 
						(ВозвращаемоеМетодомЗначение = "ClColor") или 
						(ВозвращаемоеМетодомЗначение = "ClPictureBox") или 
						(ВозвращаемоеМетодомЗначение = "ClImageFormat") или 
						(ВозвращаемоеМетодомЗначение = "ClMainMenu") или 
						(ВозвращаемоеМетодомЗначение = "ClMessageBox") или 
						(ВозвращаемоеМетодомЗначение = "ClClipboard") или 
						(ВозвращаемоеМетодомЗначение = "ClEnvironment") или 
						(ВозвращаемоеМетодомЗначение = "ClVScrollBar") или 
						(ВозвращаемоеМетодомЗначение = "ClHScrollBar") или 
						(ВозвращаемоеМетодомЗначение = "ClLabel") или 
						(ВозвращаемоеМетодомЗначение = "ClPanel") или 
						(ВозвращаемоеМетодомЗначение = "ClTabControl") или 
						(ВозвращаемоеМетодомЗначение = "ClImageList") или 
						(ВозвращаемоеМетодомЗначение = "ClListBox") или 
						(ВозвращаемоеМетодомЗначение = "ClListView") или 
						(ВозвращаемоеМетодомЗначение = "ClPropertyGrid") или 
						(ВозвращаемоеМетодомЗначение = "ClTextBox") или 
						(ВозвращаемоеМетодомЗначение = "ClMonthCalendar") или 
						(ВозвращаемоеМетодомЗначение = "ClProcess") или 
						(ВозвращаемоеМетодомЗначение = "ClTreeView") или 
						(ВозвращаемоеМетодомЗначение = "ClFolderBrowserDialog") или 
						(ВозвращаемоеМетодомЗначение = "ClTimer") или 
						(ВозвращаемоеМетодомЗначение = "ClColorDialog") или 
						(ВозвращаемоеМетодомЗначение = "ClFontDialog") или 
						(ВозвращаемоеМетодомЗначение = "ClOpenFileDialog") или 
						(ВозвращаемоеМетодомЗначение = "ClSaveFileDialog") или 
						(ВозвращаемоеМетодомЗначение = "ClType") или 
						(ВозвращаемоеМетодомЗначение = "ClBitmap") или 
						(ВозвращаемоеМетодомЗначение = "ClButton") или 
						(ВозвращаемоеМетодомЗначение = "ClCollection") или 
						(ВозвращаемоеМетодомЗначение = "ClEncoding") или 
						(ВозвращаемоеМетодомЗначение = "ClContextMenu") или 
						(ВозвращаемоеМетодомЗначение = "ClToolBar") или 
						(ВозвращаемоеМетодомЗначение = "ClCursor") или 
						(ВозвращаемоеМетодомЗначение = "ClStream") или 
						(ВозвращаемоеМетодомЗначение = "ClMenuNotifyIcon") или 
						(ВозвращаемоеМетодомЗначение = "ClSound") или 
						(ВозвращаемоеМетодомЗначение = "ClSize") или 
						(ВозвращаемоеМетодомЗначение = "ClToolBarButton") или 
						(ВозвращаемоеМетодомЗначение = "ClCursors") или 
						(ВозвращаемоеМетодомЗначение = "ClDictionaryEntry") или 
						
						(ВозвращаемоеМетодомЗначение = "ClGraphics") Тогда
						Комментарий = "";
					КонецЕсли;
				ИначеЕсли ВозвращаемоеМетодомЗначение = "Тип: Строка." Тогда
					ВозвращаемоеМетодомЗначение = "string";
					Комментарий = "";
				ИначеЕсли ВозвращаемоеМетодомЗначение = "Тип: Число." Тогда
					ВозвращаемоеМетодомЗначение = "int";
					Комментарий = "";
				ИначеЕсли ВозвращаемоеМетодомЗначение = "Тип: Булево." Тогда
					ВозвращаемоеМетодомЗначение = "bool";
					Комментарий = "";
				ИначеЕсли ВозвращаемоеМетодомЗначение = "Тип: Дата." Тогда
					ВозвращаемоеМетодомЗначение = "DateTime";
					Комментарий = "";
				ИначеЕсли ВозвращаемоеМетодомЗначение = "Тип: Произвольный." Тогда
					ВозвращаемоеМетодомЗначение = "IValue";
				ИначеЕсли СтрНайти(ВозвращаемоеМетодомЗначение,";") > 0 Тогда
					ВозвращаемоеМетодомЗначение = "dynamic";
				ИначеЕсли СокрЛП(ВозвращаемоеМетодомЗначение) = "" Тогда
					ВозвращаемоеМетодомЗначение = "void";
					Комментарий = "";
				Иначе
					Сообщить("Не хватает ВозвращаемоеМетодомЗначение " + М10[0]);
					ЗавершитьРаботу(4);
				КонецЕсли;
			
				Если ВозвращаемоеМетодомЗначение = "void" Тогда
					Если СтрПараметровВСкобках = "()" Тогда
						// [ContextMethod("ЗавершитьОбновление", "EndUpdate")]
						// public void EndUpdate()
						// {
						//	   Base_obj.EndUpdate();
						// }
						СтрХвост = 
						"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
						|        " + Комментарий + "public void " + МетодАнгл + "()
						|        " + Комментарий + "{
						|        " + Комментарий + "    Base_obj." + МетодАнгл + "();
						|        " + Комментарий + "}
						|					
						|";
						// Сообщить("СтрХвост = " + СтрХвост);
						Стр = Стр + СтрХвост;
					Иначе
						// [ContextMethod("ЗагрузитьФайл", "LoadFile")]
						// public void LoadFile(string p1, ClRichTextBoxStreamType p2)
						// {
						// 	Base_obj.LoadFile(p1, p2.Base_obj);
						// }
						СтрХвост = 
						"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
						|        " + Комментарий + "public void " + МетодАнгл + СтрПараметровВСкобках + "
						|        " + Комментарий + "{
						|        " + Комментарий + "    Base_obj." + МетодАнгл + СтрПараметровВСкобках2 + ";
						|        " + Комментарий + "}" + Символы.ПС +Символы.ПС;
						// Сообщить("СтрХвост = " + СтрХвост);
						Стр = Стр + СтрХвост;
					КонецЕсли;
				ИначеЕсли ВозвращаемоеМетодомЗначение = "string" или 
					ВозвращаемоеМетодомЗначение = "int" или 
					ВозвращаемоеМетодомЗначение = "bool" или 
					ВозвращаемоеМетодомЗначение = "DateTime" Тогда // это простые типы
					Если СтрПараметровВСкобках = "()" Тогда
						// [ContextMethod("ПрочитатьДоКонца", "ReadToEnd")]
						// public string ReadToEnd()
						// {
						// 		return Base_obj.ReadToEnd();
						// }					
						СтрХвост = 
						"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
						|        " + Комментарий + "public " + ВозвращаемоеМетодомЗначение + " " + МетодАнгл + "()
						|        " + Комментарий + "{
						|        " + Комментарий + "    " + Ретён + СтрПараметровВСкобках2 + ";
						|        " + Комментарий + "}" + Символы.ПС +Символы.ПС;
						// Сообщить("СтрХвост = " + СтрХвост);
						Стр = Стр + СтрХвост;
					Иначе
						// [ContextMethod("Найти", "Seek")]
						// public int Seek(int p1, int p2)
						// {
						// 	return Base_obj.Seek(p1, p2);
						// }
						СтрХвост = 
						"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
						|        " + Комментарий + "public " + ВозвращаемоеМетодомЗначение + " " + МетодАнгл + СтрПараметровВСкобках + "
						|        " + Комментарий + "{
						|        " + Комментарий + "    " + Ретён + СтрПараметровВСкобках2 + ";
						|        " + Комментарий + "}" + Символы.ПС +Символы.ПС;
						// Сообщить("СтрХвост = " + СтрХвост);
						Стр = Стр + СтрХвост;
					КонецЕсли;
				ИначеЕсли СтрНайти(ВозвращаемоеМетодомЗначение, "Cl") > 0 Тогда // это класс
					Если СтрПараметровВСкобках = "()" Тогда
						// [ContextMethod("Форма", "Form")]
						// public ClForm Form()
						// {
						// 	return new ClForm();
						// }
						СтрХвост = 
						"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
						|        " + Комментарий + "public " + ВозвращаемоеМетодомЗначение + " " + МетодАнгл + "()
						|        " + Комментарий + "{
						|        " + Комментарий + "    " + Ретён + "();
						|        " + Комментарий + "}" + Символы.ПС +Символы.ПС;
						// Сообщить("СтрХвост = " + СтрХвост);
						Стр = Стр + СтрХвост;
					Иначе
						//[ContextMethod("Вставить", "Insert")]
						//public ClListViewItem Insert(int p1, ClListViewItem p2)
						//{
						//    return new ClListViewItem(p1, p2.Base_obj);
						//}						
						СтрХвост = 
						"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]
						|        " + Комментарий + "public " + ВозвращаемоеМетодомЗначение + " " + МетодАнгл + СтрПараметровВСкобках + "
						|        " + Комментарий + "{
						|        " + Комментарий + "    " + Ретён + СтрПараметровВСкобках2 + ";
						|        " + Комментарий + "}" + Символы.ПС +Символы.ПС;
						// Сообщить("СтрХвост = " + СтрХвост);
						Стр = Стр + СтрХвост;
					КонецЕсли;
				Иначе // до сюда не должны дойти, все варианты учтены
					Стр = Стр + 
					"        " + Комментарий + "[ContextMethod(""" + МетодРус + """, """ + МетодАнгл + """)]" + Символы.ПС +
					"        " + Комментарий + "public void " + МетодАнгл + "()" + Символы.ПС +
					"        " + Комментарий + "{" + Символы.ПС;
					Если Не (ВозвращаемоеМетодомЗначение = "void") Тогда
						Стр = Стр + 
						"        " + Комментарий + "    " + Ретён + СтрПараметровВСкобках2 + ";" + Символы.ПС;
					Иначе
						Стр = Стр + 
						"        " + Комментарий + "    Base_obj." + МетодАнгл + СтрПараметровВСкобках2 + ";" + Символы.ПС;
					КонецЕсли;
					Стр = Стр + 
					"        " + Комментарий + "}" + Символы.ПС +Символы.ПС;
				КонецЕсли;
			КонецЕсли;
			
			
		КонецЦикла;
	Иначе
		Стр = 
		"        //Методы============================================================" + Символы.ПС;
	КонецЕсли;
	
	
	Возврат Стр;
КонецФункции//Методы

Функция Подвал()
	Стр = 
	"    }//endClass";
	Возврат Стр;
КонецФункции

Функция СтрНайтиМежду(СтрПараметр, Фрагмент1 = Неопределено, Фрагмент2 = Неопределено, ИсключитьФрагменты = Истина, БезНаложения = Истина)
	//Стр - исходная строка
	//Фрагмент1 - подстрока поиска от которой ведем поиск
	//Фрагмент2 - подстрока поиска до которой ведем поиск
	//ИсключитьФрагменты - не включать Фрагмент1 и Фрагмент2 в результат
	//БезНаложения - в результат не будут включены участки, содержащие другие найденные участки, удовлетворяющие переданным параметрам
	//функция возвращает массив строк
	Стр = СтрПараметр;
	М = Новый Массив;
	Если (Фрагмент1 <> Неопределено) и (Фрагмент2 = Неопределено) Тогда
		Позиция = Найти(Стр, Фрагмент1);
		Пока Позиция > 0 Цикл
			М.Добавить(?(ИсключитьФрагменты, Сред(Стр, Позиция + СтрДлина(Фрагмент1)), Сред(Стр, Позиция)));
			Стр = Сред(Стр, Позиция + 1);
			Позиция = Найти(Стр, Фрагмент1);
		КонецЦикла;
	ИначеЕсли (Фрагмент1 = Неопределено) и (Фрагмент2 <> Неопределено) Тогда
		Позиция = Найти(Стр, Фрагмент2);
		СуммаПозиций = Позиция;
		Пока Позиция > 0 Цикл
			М.Добавить(?(ИсключитьФрагменты, Сред(Стр, 1, СуммаПозиций - 1), Сред(Стр, 1, СуммаПозиций - 1 + СтрДлина(Фрагмент2))));
			Позиция = Найти(Сред(Стр, СуммаПозиций + 1), Фрагмент2);
			СуммаПозиций = СуммаПозиций + Позиция;
		КонецЦикла;
	ИначеЕсли (Фрагмент1 <> Неопределено) и (Фрагмент2 <> Неопределено) Тогда
		Позиция = Найти(Стр, Фрагмент1);
		Пока Позиция > 0 Цикл
			Стр2 = ?(ИсключитьФрагменты, Сред(Стр, Позиция + СтрДлина(Фрагмент1)), Сред(Стр, Позиция));
			Позиция2 = Найти(Стр2, Фрагмент2);
			СуммаПозиций2 = Позиция2;
			Пока Позиция2 > 0 Цикл
				Если БезНаложения Тогда
					Если Найти(Сред(Стр2, 1, СуммаПозиций2 - 1), Фрагмент2) = 0 Тогда
						М.Добавить("" + ?(ИсключитьФрагменты, Сред(Стр2, 1, СуммаПозиций2 - 1), Сред(Стр2, 1, СуммаПозиций2 - 1 + СтрДлина(Фрагмент2))));
					КонецЕсли;
				Иначе
					М.Добавить("" + ?(ИсключитьФрагменты, Сред(Стр2, 1, СуммаПозиций2 - 1), Сред(Стр2, 1, СуммаПозиций2 - 1 + СтрДлина(Фрагмент2))));
				КонецЕсли;
				Позиция2 = Найти(Сред(Стр2, СуммаПозиций2 + 1), Фрагмент2);
				СуммаПозиций2 = СуммаПозиций2 + Позиция2;
			КонецЦикла;
			Стр = Сред(Стр, Позиция + 1);
			Позиция = Найти(Стр, Фрагмент1);
		КонецЦикла;
	КонецЕсли;
	
	Возврат М;
КонецФункции//СтрНайтиМежду

Процедура ВыгрузкаДляCS()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ИменаКалассовПеречислений = Новый СписокЗначений;
	ОтобранныеПеречисления = ОтобратьФайлы("Перечисление");
	Для А = 0 По ОтобранныеПеречисления.ВГраница() Цикл
		// C:\444\OneScriptFormsru\OneScriptForms.TreeViewAction.html
		СтрКлассПеречисления = "" + ОтобранныеПеречисления[А];
		СтрКлассПеречисления = СтрЗаменить(СтрКлассПеречисления, "C:\444\OneScriptFormsru\OneScriptForms.", "Cl");
		СтрКлассПеречисления = СтрЗаменить(СтрКлассПеречисления, ".html", "");
		ИменаКалассовПеречислений.Добавить(СтрКлассПеречисления);
	КонецЦикла;
	// Сообщить("Количество = " + ИменаКалассовПеречислений.Количество());
	// Для А = 0 По ИменаКалассовПеречислений.Количество() - 1 Цикл
		// Сообщить("" + ИменаКалассовПеречислений.Получить(А).Значение);
	// КонецЦикла;
	
	УдалитьФайлы("C:\444\ВыгруженныеОбъекты", "*.cs");
	
	СоздатьФайлCs("ButtonBase");
	СоздатьФайлCs("Button");
	СоздатьФайлCs("Component");
	СоздатьФайлCs("ContainerControl");
	СоздатьФайлCs("ScrollableControl");
	СоздатьФайлCs("Control");
	СоздатьФайлCs("Form");
	СоздатьФайлCs("Color");
	СоздатьФайлCs("Point");
	СоздатьФайлCs("Size");
	СоздатьФайлCs("EventArgs");
	СоздатьФайлCs("Font");
	СоздатьФайлCs("Version");
	СоздатьФайлCs("Rectangle");
	СоздатьФайлCs("Cursor");
	СоздатьФайлCs("Image");
	СоздатьФайлCs("ImageFormat");
	СоздатьФайлCs("Stream");
	СоздатьФайлCs("MouseEventArgs");
	СоздатьФайлCs("DockPaddingEdges");
	СоздатьФайлCs("CollectionBase");
	СоздатьФайлCs("ControlCollection");
	СоздатьФайлCs("CancelEventArgs");
	СоздатьФайлCs("FileSystemEventArgs");
	СоздатьФайлCs("ColumnClickEventArgs");
	СоздатьФайлCs("LinkLabelLinkClickedEventArgs");
	СоздатьФайлCs("ToolBarButtonClickEventArgs");
	СоздатьФайлCs("PropertyValueChangedEventArgs");
	СоздатьФайлCs("TreeViewCancelEventArgs");
	СоздатьФайлCs("TreeViewEventArgs");
	СоздатьФайлCs("NodeLabelEditEventArgs");
	СоздатьФайлCs("PaintEventArgs");
	СоздатьФайлCs("ControlEventArgs");
	СоздатьФайлCs("SelectedGridItemChangedEventArgs");
	СоздатьФайлCs("ScrollEventArgs");
	СоздатьФайлCs("LinkClickedEventArgs");
	СоздатьФайлCs("RenamedEventArgs");
	СоздатьФайлCs("LabelEditEventArgs");
	СоздатьФайлCs("KeyPressEventArgs");
	СоздатьФайлCs("KeyEventArgs");
	СоздатьФайлCs("ItemCheckEventArgs");
	СоздатьФайлCs("Sound");
	СоздатьФайлCs("FormClosingEventArgs");
	СоздатьФайлCs("Collection");
	СоздатьФайлCs("Graphics");
	СоздатьФайлCs("Brush");
	СоздатьФайлCs("SolidBrush");
	СоздатьФайлCs("Pen");
	СоздатьФайлCs("Type");
	СоздатьФайлCs("Icon");
	СоздатьФайлCs("Bitmap");
	СоздатьФайлCs("PictureBox");
	СоздатьФайлCs("ArrayList");
	СоздатьФайлCs("Menu");
	СоздатьФайлCs("MainMenu");
	СоздатьФайлCs("ContextMenu");
	СоздатьФайлCs("MenuItem");
	СоздатьФайлCs("MenuItemCollection");
	СоздатьФайлCs("Environment");
	СоздатьФайлCs("ScrollBar");
	СоздатьФайлCs("VScrollBar");
	СоздатьФайлCs("HScrollBar");
	СоздатьФайлCs("Label");
	СоздатьФайлCs("Panel");
	СоздатьФайлCs("TabPageCollection");
	СоздатьФайлCs("TabPage");
	СоздатьФайлCs("TabControl");
	СоздатьФайлCs("ImageCollection");
	СоздатьФайлCs("ImageList");
	СоздатьФайлCs("Stream");
	СоздатьФайлCs("StreamReader");
	СоздатьФайлCs("ListControl");
	СоздатьФайлCs("ListBox");
	СоздатьФайлCs("ListItem");
	СоздатьФайлCs("ListBoxObjectCollection");
	СоздатьФайлCs("ListBoxSelectedObjectCollection");
	СоздатьФайлCs("ListBoxSelectedIndexCollection");
	СоздатьФайлCs("DataRowView");
	СоздатьФайлCs("ContextMenuPopupEventArgs");
	СоздатьФайлCs("ListView");
	СоздатьФайлCs("ListViewCheckedItemCollection");
	СоздатьФайлCs("ListViewColumnHeaderCollection");
	СоздатьФайлCs("ListViewItem");
	СоздатьФайлCs("ListViewItemCollection");
	СоздатьФайлCs("ListViewSelectedItemCollection");
	СоздатьФайлCs("ListViewSubItem");
	СоздатьФайлCs("ListViewSubItemCollection");
	СоздатьФайлCs("ColumnHeader");
	СоздатьФайлCs("GridItemCollection");
	СоздатьФайлCs("GridItem");
	СоздатьФайлCs("PropertyGrid");
	СоздатьФайлCs("TextBoxBase");
	СоздатьФайлCs("TextBox");
	СоздатьФайлCs("ProcessStartInfo");
	СоздатьФайлCs("Process");
	СоздатьФайлCs("SelectionRange");
	СоздатьФайлCs("MonthCalendar");
	СоздатьФайлCs("ExtractIconClass");
	СоздатьФайлCs("TreeView");
	СоздатьФайлCs("TreeNode");
	СоздатьФайлCs("TreeNodeCollection");
	СоздатьФайлCs("CommonDialog");
	СоздатьФайлCs("FolderBrowserDialog");
	СоздатьФайлCs("Timer");
	СоздатьФайлCs("ColorDialog");
	СоздатьФайлCs("FontDialog");
	СоздатьФайлCs("FileDialog");
	СоздатьФайлCs("OpenFileDialog");
	СоздатьФайлCs("SaveFileDialog");
	СоздатьФайлCs("MenuNotifyIcon");
	СоздатьФайлCs("NotifyIcon");
	СоздатьФайлCs("UserControl");
	СоздатьФайлCs("MessageBox");
	СоздатьФайлCs("ProgressBar");
	СоздатьФайлCs("ToolBarButtonCollection");
	СоздатьФайлCs("ToolBar");
	СоздатьФайлCs("ToolBarButton");
	СоздатьФайлCs("Encoding");
	СоздатьФайлCs("LinkCollection");
	СоздатьФайлCs("LinkLabel");
	СоздатьФайлCs("LinkArea");
	СоздатьФайлCs("Link");
	СоздатьФайлCs("DataColumn");
	СоздатьФайлCs("DataColumnCollection");
	СоздатьФайлCs("DataTableCollection");
	СоздатьФайлCs("DataTable");
	СоздатьФайлCs("DataSet");
	СоздатьФайлCs("DataView");
	СоздатьФайлCs("DataRow");
	СоздатьФайлCs("DataRowCollection");
	СоздатьФайлCs("DataItem");
	СоздатьФайлCs("DataGrid");
	СоздатьФайлCs("DataGridCell");
	СоздатьФайлCs("GridTableStylesCollection");
	СоздатьФайлCs("DataGridTableStyle");
	СоздатьФайлCs("DataGridColumnStyle");
	СоздатьФайлCs("GridColumnStylesCollection");
	СоздатьФайлCs("DataGridTextBox");
	СоздатьФайлCs("DataGridTextBoxColumn");
	СоздатьФайлCs("Cursors");
	СоздатьФайлCs("DictionaryEntry");
	СоздатьФайлCs("SortedList");
	СоздатьФайлCs("FileSystemWatcher");
	СоздатьФайлCs("StatusBar");
	СоздатьФайлCs("StatusBarPanel");
	СоздатьФайлCs("StatusBarPanelCollection");
	СоздатьФайлCs("RadioButton");
	СоздатьФайлCs("ToolTip");
	СоздатьФайлCs("ComboBox");
	СоздатьФайлCs("ComboBoxObjectCollection");
	СоздатьФайлCs("DateTimePicker");
	СоздатьФайлCs("Application");
	СоздатьФайлCs("HatchBrush");
	СоздатьФайлCs("TextureBrush");
	СоздатьФайлCs("Splitter");
	СоздатьФайлCs("GroupBox");
	СоздатьФайлCs("NumericUpDown");
	СоздатьФайлCs("UpDownBase");
	СоздатьФайлCs("DataGridBoolColumn");
	СоздатьФайлCs("BitmapData");
	СоздатьФайлCs("RichTextBox");
	СоздатьФайлCs("DataGridComboBoxColumnStyle");
	СоздатьФайлCs("CheckBox");
	СоздатьФайлCs("HashTable");
	СоздатьФайлCs("Screen");
	

	
	СписокЗамен = Новый СписокЗначений;
	
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptFormsru\OneScriptForms.OneScriptFormsMethods.html");
	Стр = ТекстДок.ПолучитьТекст();
	Массив1 = СтрНайтиМежду(Стр, "<TR vAlign=top>", "</TD></TR>", Ложь, );
	Если Массив1.Количество() > 0 Тогда
		СтрМетодовСистема = "";
		Для А = 0 По Массив1.ВГраница() Цикл
			М07 = СтрНайтиМежду(Массив1[А], "<TD width=""50%"">", "</TD>", Ложь, );
			СтрХ = М07[0];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			МетодАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			МетодРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			Если А = Массив1.ВГраница() Тогда
				СтрМетодовСистема = СтрМетодовСистема + МетодРус + " (" + МетодАнгл + ")";
			Иначе
				СтрМетодовСистема = СтрМетодовСистема + МетодРус + " (" + МетодАнгл + "),";
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
	
	СписокСтрМетодовСистема = Новый СписокЗначений;
	М15 = РазобратьСтроку(СтрМетодовСистема, ",");
	Для А = 0 По М15.ВГраница() Цикл
		СписокСтрМетодовСистема.Добавить(СтрНайтиМежду(М15[А], "(", ")", , )[0]);
	КонецЦикла;
	// Сообщить("СписокСтрМетодовСистема.Количество = " + СписокСтрМетодовСистема.Количество());
	
	СписокФайлов = Новый СписокЗначений;
	ВыбранныеФайлы = ОтобратьФайлы("Класс");
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		Стр = ТекстДок.ПолучитьТекст();
		СтрЗаголовка = СтрНайтиМежду(Стр, "<H1 class=dtH1", "/H1>", , )[0];
		М01 = СтрНайтиМежду(СтрЗаголовка, "(", ")", , );
		Стр33 = СтрЗаголовка;
		Стр33 = СтрЗаменить(Стр33, "&nbsp;", " ");
		Стр33 = СтрЗаменить(Стр33, ">", "");
		М08 = РазобратьСтроку(Стр33, " ");
		
		ИмяФайлаВыгрузки = "C:\444\ВыгруженныеОбъекты\" + М01[0] + ".cs";
		
		ИмяКонтекстКлассаАнгл = М01[0];
		ИмяКонтекстКлассаРус = М08[0];
		// находим имя файла членов
		ИмяФайлаЧленов = "C:\444\OneScriptFormsru\OneScriptForms." + М01[0] + "Members.html";
		СтрДирективы = Директивы(ИмяКонтекстКлассаАнгл);
		СтрШапка = Шапка(ИмяКонтекстКлассаАнгл, ИмяКонтекстКлассаРус);
		СтрРазделОбъявленияПеременных = РазделОбъявленияПеременных(ИмяФайлаЧленов, М01[0]);
		СтрКонструктор = Конструктор(ИмяФайлаЧленов, М01[0]);
		СтрBase_obj = Base_obj(ИмяКонтекстКлассаАнгл);
		СтрСвойства = Свойства(ИмяФайлаЧленов, ИмяКонтекстКлассаАнгл);
		СтрПеречисленияКакСвойства = ПеречисленияКакСвойства(ИмяФайлаЧленов);
		СтрМетоды = Методы(ИмяФайлаЧленов, ИмяКонтекстКлассаАнгл);
		СтрПодвал = Подвал();
		
		СортироватьСтрРазделОбъявленияПеременных();
		СтрВыгрузки = "";
		СтрВыгрузки = СтрВыгрузки + СтрШапка + Символы.ПС;
		СтрВыгрузки = СтрВыгрузки + СтрРазделОбъявленияПеременных + Символы.ПС;
		СтрВыгрузки = СтрВыгрузки + СтрКонструктор + Символы.ПС;
		СтрВыгрузки = СтрВыгрузки + СтрBase_obj + Символы.ПС;
		СтрВыгрузки = СтрВыгрузки + СтрСвойства;
		СтрВыгрузки = СтрВыгрузки + "        //endProperty" + Символы.ПС;
		СтрВыгрузки = СтрВыгрузки + СтрПеречисленияКакСвойства;
		СтрВыгрузки = СтрВыгрузки + СтрМетоды;
		СтрВыгрузки = СтрВыгрузки + "        //endMethods" + Символы.ПС;
		СтрВыгрузки = СтрВыгрузки + СтрПодвал + Символы.ПС;
		
		//если это класс ИмяКонтекстКлассаАнгл = OneScriptForms 
		// тогда нужно дозаписать методы создания экземпляров каждого класса если он ещё отсутствует в СтрВыгрузки
		Если ИмяКонтекстКлассаАнгл = "OneScriptForms" Тогда
			ВыбранныеФайлы_2 = ОтобратьФайлы("Класс");
			Для А_2 = 0 По ВыбранныеФайлы_2.ВГраница() Цикл
				ТекстДок_2 = Новый ТекстовыйДокумент;
				ТекстДок_2.Прочитать(ВыбранныеФайлы_2[А_2]);
				Стр_2 = ТекстДок_2.ПолучитьТекст();
				СтрЗаголовка_2 = СтрНайтиМежду(Стр_2, "<H1 class=dtH1", "/H1>", , )[0];
				М01_2 = СтрНайтиМежду(СтрЗаголовка_2, "(", ")", , );
				Стр33_2 = СтрЗаголовка_2;
				Стр33_2 = СтрЗаменить(Стр33_2, "&nbsp;", " ");
				Стр33_2 = СтрЗаменить(Стр33_2, ">", "");
				М08_2 = РазобратьСтроку(Стр33_2, " ");
				ИмяКонтекстКлассаАнгл = М01_2[0];
				ИмяКонтекстКлассаРус = М08_2[0];
				
				// для классов - аргументов свои правила
				Если Прав(ИмяКонтекстКлассаАнгл, 4) = "Args" Тогда
					Если Не (ИмяКонтекстКлассаАнгл = "EventArgs") Тогда
						ПодстрокаПоиска = 
						"        //endMethods";
						ПодстрокаЗамены = 
						"        [ContextMethod(""" + ИмяКонтекстКлассаРус + """, """ + ИмяКонтекстКлассаАнгл + """)]
						|        public Cl" + ИмяКонтекстКлассаАнгл + " " + ИмяКонтекстКлассаАнгл + "()
						|        {
						|        	return (Cl" + ИмяКонтекстКлассаАнгл + ")Event;
						|        }
						|        
						|        //endMethods";
						СтрВыгрузки = СтрЗаменить(СтрВыгрузки, ПодстрокаПоиска, ПодстрокаЗамены);
					КонецЕсли;
				КонецЕсли;
			КонецЦикла;
			
			//добавим метод RevertObj
			ПодстрокаПоиска = 
			"        //endMethods";
			ПодстрокаЗамены = 
			"        public static void AddToHashtable(dynamic p1, dynamic p2)
			|        {
			|            if (!OneScriptForms.hashtable.ContainsKey(p1))
			|            {
			|                OneScriptForms.hashtable.Add(p1, p2);
			|            }
			|        }
			|
			|        public static IValue RevertObj(dynamic initialObject) 
			|        {
			|            //ScriptEngine.Machine.Values.NullValue NullValue1;
			|            //ScriptEngine.Machine.Values.BooleanValue BooleanValue1;
			|            //ScriptEngine.Machine.Values.DateValue DateValue1;
			|            //ScriptEngine.Machine.Values.NumberValue NumberValue1;
			|            //ScriptEngine.Machine.Values.StringValue StringValue1;
			|
			|            //ScriptEngine.Machine.Values.GenericValue GenericValue1;
			|            //ScriptEngine.Machine.Values.TypeTypeValue TypeTypeValue1;
			|            //ScriptEngine.Machine.Values.UndefinedValue UndefinedValue1;
			|
			|            try
			|            {
			|                if (initialObject == null)
			|                {
			|                    return (IValue)null;
			|                }
			|            }
			|            catch { }
			|
			|            try
			|            {
			|                string str_initialObject = initialObject.GetType().ToString();
			|            }
			|            catch
			|            {
			|                return (IValue)null;
			|            }
			|
			|            dynamic Obj1 = null;
			|            string str1 = initialObject.GetType().ToString();
			|            try
			|            {
			|                Obj1 = initialObject.dll_obj;
			|            }
			|            catch { }
			|            if (Obj1 != null)
			|            {
			|                return (IValue)Obj1;
			|            }
			|
			|            try
			|            {
			|                Obj1 = initialObject.M_Object.dll_obj;
			|            }
			|            catch { }
			|            if (Obj1 != null)
			|            {
			|                return (IValue)Obj1;
			|            }
			|			
			|            try
			|            {
			|                if (str1.Contains(""osf.""))
			|                {
			|                    foreach (System.Collections.DictionaryEntry de in OneScriptForms.hashtable)
			|                    {
			|                        if (de.Key.Equals(initialObject.GetType().GetField(""M_"" + str1.Substring(str1.LastIndexOf(""."") + 1)).GetValue(initialObject)))
			|                        {
			|                            Obj1 = ((dynamic)de.Value).dll_obj;
			|                            break;
			|                        }
			|                    }
			|                }
			|            }
			|            catch { }
			|            if (Obj1 != null)
			|            {
			|                return (IValue)Obj1;
			|            }
			|
			|            try // если initialObject не из пространства имен onescriptgui, то есть Уровень1
			|            {
			|                if (!str1.Contains(""osf.""))
			|                {
			|                    string str2 = ""osf.Cl"" + str1.Substring(str1.LastIndexOf(""."") + 1);
			|                    System.Type TestType = System.Type.GetType(str2, false, true);
			|                    object[] args = { initialObject };
			|                    Obj1 = Activator.CreateInstance(TestType, args);
			|                }
			|            }
			|            catch { }
			|            if (Obj1 != null)
			|            {
			|                return (IValue)Obj1;
			|            }
			|
			|            try // если initialObject из пространства имен onescriptgui, то есть Уровень2
			|            {
			|                if (str1.Contains(""osf.""))
			|                {
			|                    string str3 = str1.Replace(""osf."", ""osf.Cl"");
			|                    System.Type TestType = System.Type.GetType(str3, false, true);
			|                    object[] args = { initialObject };
			|                    Obj1 = Activator.CreateInstance(TestType, args);
			|                }
			|            }
			|            catch { }
			|            if (Obj1 != null)
			|            {
			|                return (IValue)Obj1;
			|            }
			|
			|            string str4 = null;
			|            try
			|            {
			|                str4 = initialObject.SystemType.Name;
			|            }
			|            catch
			|            {
			|                if ((str1 == ""System.String"") ||
			|                (str1 == ""System.Decimal"") ||
			|                (str1 == ""System.Int32"") ||
			|                (str1 == ""System.Boolean"") ||
			|                (str1 == ""System.DateTime""))
			|                {
			|                    return (IValue)ValueFactory.Create(initialObject);
			|                }
			|                else if (str1 == ""System.Byte"")
			|                {
			|                    int vOut = Convert.ToInt32(initialObject);
			|                    return (IValue)ValueFactory.Create(vOut);
			|                }
			|                else if (str1 == ""System.DBNull"")
			|                {
			|                    string vOut = Convert.ToString(initialObject);
			|                    return (IValue)ValueFactory.Create(vOut);
			|                }
			|            }
			|			
			|            if (str4 == ""Неопределено"")
			|            {
			|                return (IValue)null;
			|            }
			|            if (str4 == ""Булево"")
			|            {
			|                return (IValue)initialObject;
			|            }
			|            if (str4 == ""Дата"")
			|            {
			|                return (IValue)initialObject;
			|            }
			|            if (str4 == ""Число"")
			|            {
			|                return (IValue)initialObject;
			|            }
			|            if (str4 == ""Строка"")
			|            {
			|                return (IValue)initialObject;
			|            }
			|            return (IValue)initialObject;
			|        }
			|			
			|        public static dynamic DefineTypeIValue(dynamic p1)
			|        {
			|            if (p1.GetType() == typeof(ScriptEngine.Machine.Values.StringValue))
			|            {
			|                return p1.AsString();
			|            }
			|            else if (p1.GetType() == typeof(ScriptEngine.Machine.Values.NumberValue))
			|            {
			|                return p1.AsNumber();
			|            }
			|            else if (p1.GetType() == typeof(ScriptEngine.Machine.Values.BooleanValue))
			|            {
			|                return p1.AsBoolean();
			|            }
			|            else if (p1.GetType() == typeof(ScriptEngine.Machine.Values.DateValue))
			|            {
			|                return p1.AsDate();
			|            }
			|            else
			|            {
			|                return p1;
			|            }
			|        }
			|        //endMethods";
			СтрВыгрузки = СтрЗаменить(СтрВыгрузки, ПодстрокаПоиска, ПодстрокаЗамены);
		КонецЕсли;
		
		//последние исправления СтрВыгрузки
		ПодстрокаПоиска = "public ClDataType DataType";
		ПодстрокаЗамены = "public new ClDataType DataType";
		СтрВыгрузки = СтрЗаменить(СтрВыгрузки, ПодстрокаПоиска, ПодстрокаЗамены);
		
		ПодстрокаПоиска = "items = new ClListBoxObjectCollection(Base_obj.Items);";
		ПодстрокаЗамены = "items = new ClListBoxObjectCollection(Base_obj.Items);
		|            items.M_obj = this;";
		СтрВыгрузки = СтрЗаменить(СтрВыгрузки, ПодстрокаПоиска, ПодстрокаЗамены);
		
		Файл1 = Новый Файл(ИмяФайлаВыгрузки);
		Если Не (Файл1.Существует()) Тогда
			ЗаписьТекста1 = Новый ЗаписьТекста();
			ЗаписьТекста1.Открыть(ИмяФайлаВыгрузки,,,);
			Если ИмяФайлаВыгрузки = "C:\444\ВыгруженныеОбъекты\OneScriptForms.cs" Тогда
				Стр88 = 
				"using System;
				|using System.Collections;
				|using System.Collections.Generic;
				|using System.Linq;
				|using ScriptEngine.Machine.Contexts;
				|using ScriptEngine.Machine;
				|using System.Reflection;
				|using System.Runtime.InteropServices;
				|
				|";
			Иначе
				Стр88 = Директивы(ИмяКонтекстКлассаАнгл);
			КонецЕсли;
			Стр88 = Стр88 + 
			"namespace osf
			|{
			|}//endnamespace
			|";
			ЗаписьТекста1.Записать(Стр88);
			ЗаписьТекста1.Закрыть();
		Иначе

		КонецЕсли;
		
		//не создаем класса с префиксом Cl (остается только класс второго уровня)
		Если Не (
			ИмяКонтекстКлассаАнгл = "ButtonBase" или 
			ИмяКонтекстКлассаАнгл = "UpDownBase" или 
			ИмяКонтекстКлассаАнгл = "Component" или 
			ИмяКонтекстКлассаАнгл = "ScrollableControl" или 
			ИмяКонтекстКлассаАнгл = "Control" или 
			ИмяКонтекстКлассаАнгл = "CollectionBase" или 
			ИмяКонтекстКлассаАнгл = "Brush" или 
			ИмяКонтекстКлассаАнгл = "ScrollBar" или 
			ИмяКонтекстКлассаАнгл = "ListControl" или 
			ИмяКонтекстКлассаАнгл = "TextBoxBase" или 
			ИмяКонтекстКлассаАнгл = "Image" или 
			ИмяКонтекстКлассаАнгл = "CommonDialog" или 
			ИмяКонтекстКлассаАнгл = "DataGridColumnStyle" или 
			ИмяКонтекстКлассаАнгл = "FileDialog" или 
			ИмяКонтекстКлассаАнгл = "ContainerControl")
		
		Тогда //дописываем в файл класс с префиксом Cl (класс третьего уровня) для классов
			ЧтениеТекста1 = Новый ЧтениеТекста(ИмяФайлаВыгрузки);
			Стр77 = ЧтениеТекста1.Прочитать();
			ЧтениеТекста1.Закрыть();
			
			ПодстрокаПоиска = "}//endnamespace";
			ПодстрокаЗамены = СтрВыгрузки + Символы.ПС + "}//endnamespace";
			Стр77 = СтрЗаменить(Стр77, ПодстрокаПоиска, ПодстрокаЗамены);
			
			ЗаписьТекста1 = Новый ЗаписьТекста();
			ЗаписьТекста1.Открыть(ИмяФайлаВыгрузки,,,);
			ЗаписьТекста1.Записать(Стр77);
			ЗаписьТекста1.Закрыть();
		КонецЕсли;
	КонецЦикла;
	//===============================================================================================================================
	ВыбранныеФайлы = ОтобратьФайлы("Перечисление");
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		Стр = ТекстДок.ПолучитьТекст();
		СтрЗаголовка= СтрНайтиМежду(Стр, "<H1 class=dtH1", "/H1>", , )[0];
		М01 = СтрНайтиМежду(СтрЗаголовка, "(", ")", , );
		СтрЗаголовка = СтрЗаменить(СтрЗаголовка, "&nbsp;", " ");
		Стр33 = СтрНайтиМежду(СтрЗаголовка, ">", " Перечисление<", , )[0];
		Стр33 = СтрЗаменить(Стр33, "&nbsp;", " ");
		Стр33 = СтрЗаменить(Стр33, ">", "");
		М08 = РазобратьСтроку(Стр33, " ");
		ИмяФайлаВыгрузки = "C:\444\ВыгруженныеОбъекты\" + М01[0] + ".cs";
		ИмяКонтекстКлассаАнгл = М01[0];
		ИмяКонтекстКлассаРус = М08[0];
		
		//находим текст таблицы
		СтрТаблица = СтрНайтиМежду(Стр, "</TH></TR>" + Символы.ПС + "  <TR vAlign=top>", "</TBODY></TABLE>", Ложь, );
		СтрТаблицыПеречисления = СтрНайтиМежду(СтрТаблица[0], "<TR vAlign=top>", "</TD></TR>", Ложь, );
		СтрРазделОбъявленияПеременныхДляПеречисления = "";
		СтрСвойстваДляПеречисления = "";
		Для А02 = 0 По СтрТаблицыПеречисления.ВГраница() Цикл
			М12 = СтрНайтиМежду(СтрТаблицыПеречисления[А02], "<TD>", "</TD>", , );
			М14 = СтрНайтиМежду(М12[0], "<B>", "</B>", , );
			М13 = РазобратьСтроку(СтрЗаменить(М14[0], "&nbsp;", " "), " ");
			ИмяПеречАнгл = М01[0];
			ИмяПеречРус = М08[0];
			ИмяЧленаАнгл = М13[1];
			// Сообщить("==" + ИмяЧленаАнгл);
			ИмяЧленаАнгл = СтрНайтиМежду(ИмяЧленаАнгл, "(", ")", , )[0];
			ИмяЧленаРус = М13[0];
			ОписаниеЧлена = М12[1];
			Пока СтрЧислоВхождений(ОписаниеЧлена, Символы.ПС) > 0 Цикл
				ОписаниеЧлена = СтрЗаменить(ОписаниеЧлена, Символы.ПС, " ");
			КонецЦикла;
			Пока СтрЧислоВхождений(ОписаниеЧлена, Символы.Таб) > 0 Цикл
				ОписаниеЧлена = СтрЗаменить(ОписаниеЧлена, Символы.Таб, " ");
			КонецЦикла;
			Пока СтрЧислоВхождений(ОписаниеЧлена, "  ") > 0 Цикл
				ОписаниеЧлена = СтрЗаменить(ОписаниеЧлена, "  ", " ");
			КонецЦикла;
			ЗначениеЧлена = М12[2];
			// Сообщить("--------------");
			// Сообщить("ИмяПеречРус = " + ИмяПеречРус);
			// Сообщить("ИмяПеречАнгл = " + ИмяПеречАнгл);
			// Сообщить("ИмяЧленаРус = " + ИмяЧленаРус);
			// Сообщить("ИмяЧленаАнгл = " + ИмяЧленаАнгл);
			// Сообщить("ОписаниеЧлена = " + ОписаниеЧлена);
			// Сообщить("ЗначениеЧлена = " + ЗначениеЧлена);
			
			СоставнаяСтр = ИмяЧленаАнгл;
			СоставнаяСтр = НРег(Лев(СоставнаяСтр, 1)) + Сред(СоставнаяСтр, 2);
			// private int strikeout = (int)FontStyle.Strikeout; // 8 Зачеркнутый шрифт.
			Если ИмяКонтекстКлассаАнгл = "AnchorStyles" или 
				ИмяКонтекстКлассаАнгл = "Appearance" или 
				ИмяКонтекстКлассаАнгл = "BorderStyle" или 
				ИмяКонтекстКлассаАнгл = "CharacterCasing" или 
				ИмяКонтекстКлассаАнгл = "CheckState" или 
				ИмяКонтекстКлассаАнгл = "CloseReason" или 
				ИмяКонтекстКлассаАнгл = "ColorDepth" или 
				ИмяКонтекстКлассаАнгл = "ColumnHeaderStyle" или 
				ИмяКонтекстКлассаАнгл = "ComboBoxStyle" или 
				ИмяКонтекстКлассаАнгл = "Day" или 
				ИмяКонтекстКлассаАнгл = "DialogResult" или 
				ИмяКонтекстКлассаАнгл = "DockStyle" или 
				ИмяКонтекстКлассаАнгл = "DrawMode" или 
				ИмяКонтекстКлассаАнгл = "FormBorderStyle" или 
				ИмяКонтекстКлассаАнгл = "FormStartPosition" или 
				ИмяКонтекстКлассаАнгл = "FormWindowState" или 
				ИмяКонтекстКлассаАнгл = "GridItemType" или 
				ИмяКонтекстКлассаАнгл = "HorizontalAlignment" или 
				ИмяКонтекстКлассаАнгл = "ImageLayout" или 
				ИмяКонтекстКлассаАнгл = "ItemActivation" или 
				ИмяКонтекстКлассаАнгл = "Keys" или 
				ИмяКонтекстКлассаАнгл = "LeftRightAlignment" или 
				ИмяКонтекстКлассаАнгл = "ListViewAlignment" или 
				ИмяКонтекстКлассаАнгл = "MenuMerge" или 
				ИмяКонтекстКлассаАнгл = "MessageBoxButtons" или 
				ИмяКонтекстКлассаАнгл = "MessageBoxIcon" или 
				ИмяКонтекстКлассаАнгл = "MouseButtons" или 
				ИмяКонтекстКлассаАнгл = "PictureBoxSizeMode" или 
				ИмяКонтекстКлассаАнгл = "PropertySort" или 
				ИмяКонтекстКлассаАнгл = "RichTextBoxFinds" или 
				ИмяКонтекстКлассаАнгл = "RichTextBoxStreamType" или 
				ИмяКонтекстКлассаАнгл = "ScrollBars" или 
				ИмяКонтекстКлассаАнгл = "ScrollEventType" или 
				ИмяКонтекстКлассаАнгл = "ScrollOrientation" или 
				ИмяКонтекстКлассаАнгл = "SelectionMode" или 
				ИмяКонтекстКлассаАнгл = "Shortcut" или 
				ИмяКонтекстКлассаАнгл = "SortOrder" или 
				ИмяКонтекстКлассаАнгл = "StatusBarPanelAutoSize" или 
				ИмяКонтекстКлассаАнгл = "StatusBarPanelBorderStyle" или 
				ИмяКонтекстКлассаАнгл = "TabAlignment" или 
				ИмяКонтекстКлассаАнгл = "TabAppearance" или 
				ИмяКонтекстКлассаАнгл = "TabSizeMode" или 
				ИмяКонтекстКлассаАнгл = "ToolBarAppearance" или 
				ИмяКонтекстКлассаАнгл = "ToolBarButtonStyle" или 
				ИмяКонтекстКлассаАнгл = "ToolBarTextAlign" или 
				ИмяКонтекстКлассаАнгл = "TreeViewAction" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Windows.Forms." + ИмяКонтекстКлассаАнгл;
			ИначеЕсли ИмяКонтекстКлассаАнгл = "ContentAlignment" или 
				ИмяКонтекстКлассаАнгл = "FontStyle" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Drawing." + ИмяКонтекстКлассаАнгл;
			ИначеЕсли ИмяКонтекстКлассаАнгл = "NotifyFilters" или 
				ИмяКонтекстКлассаАнгл = "SeekOrigin" или 
				ИмяКонтекстКлассаАнгл = "WatcherChangeTypes" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.IO." + ИмяКонтекстКлассаАнгл;
			ИначеЕсли ИмяКонтекстКлассаАнгл = "ProcessWindowStyle" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Diagnostics." + ИмяКонтекстКлассаАнгл;
			ИначеЕсли ИмяКонтекстКлассаАнгл = "SpecialFolder" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Environment." + ИмяКонтекстКлассаАнгл;
			ИначеЕсли ИмяКонтекстКлассаАнгл = "FormatDateTimePicker" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Windows.Forms.DateTimePickerFormat";
			ИначеЕсли ИмяКонтекстКлассаАнгл = "HatchStyle" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Drawing.Drawing2D.HatchStyle";
			ИначеЕсли ИмяКонтекстКлассаАнгл = "LinkLabelLinkBehavior" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Windows.Forms.LinkBehavior";
			ИначеЕсли ИмяКонтекстКлассаАнгл = "PixelFormat" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Drawing.Imaging." + ИмяКонтекстКлассаАнгл;
			ИначеЕсли ИмяКонтекстКлассаАнгл = "FlatStyle" Тогда
				ИмяКонтекстКлассаАнгл1 = "(System.Windows.Forms.FlatStyle)FlatStyle";
			ИначеЕсли ИмяКонтекстКлассаАнгл = "DataRowState" Тогда
				ИмяКонтекстКлассаАнгл1 = "System.Data.DataRowState";
			Иначе
				ИмяКонтекстКлассаАнгл1 = ИмяКонтекстКлассаАнгл;
			КонецЕсли;
			Если ИмяКонтекстКлассаАнгл = "Sounds" или
				ИмяКонтекстКлассаАнгл = "MouseFlags" или
				ИмяКонтекстКлассаАнгл = "SortType" или
				ИмяКонтекстКлассаАнгл = "DataType" Тогда
				СтрРазделОбъявленияПеременныхДляПеречисления = СтрРазделОбъявленияПеременныхДляПеречисления + Символы.ПС + 
				"        private int m_" + СоставнаяСтр + " = " + ЗначениеЧлена + "; // " + ЗначениеЧлена + " " + ОписаниеЧлена;
				
				СтрСвойстваДляПеречисления = СтрСвойстваДляПеречисления + Символы.ПС + 
				"        [ContextProperty(""" + ИмяЧленаРус + """, """ + ИмяЧленаАнгл + """)]
				|        public int " + ИмяЧленаАнгл + "
				|        {
				|        	get { return m_" + СоставнаяСтр + "; }
				|        }" + ?(А02 = СтрТаблицыПеречисления.ВГраница(), "", Символы.ПС);
			Иначе
				СтрРазделОбъявленияПеременныхДляПеречисления = СтрРазделОбъявленияПеременныхДляПеречисления + Символы.ПС + 
				"        private int m_" + СоставнаяСтр + " = (int)" + ИмяКонтекстКлассаАнгл1 + "." + ИмяЧленаАнгл + "; // " + ЗначениеЧлена + " " + ОписаниеЧлена;
				
				СтрСвойстваДляПеречисления = СтрСвойстваДляПеречисления + Символы.ПС + 
				"        [ContextProperty(""" + ИмяЧленаРус + """, """ + ИмяЧленаАнгл + """)]
				|        public int " + ИмяЧленаАнгл + "
				|        {
				|        	get { return m_" + СоставнаяСтр + "; }
				|        }" + ?(А02 = СтрТаблицыПеречисления.ВГраница(), "", Символы.ПС);
			КонецЕсли;
		КонецЦикла;
		
		//последние исправления СтрСвойстваДляПеречисления
		ПодстрокаПоиска = "(int)System.Environment.SpecialFolder.SystemDirectory;";
		ПодстрокаЗамены = "(int)System.Environment.SpecialFolder.System;";
		СтрРазделОбъявленияПеременныхДляПеречисления = СтрЗаменить(СтрРазделОбъявленияПеременныхДляПеречисления, ПодстрокаПоиска, ПодстрокаЗамены);
		
		СтрВыгрузкиПеречисленийШапка = Директивы(ИмяКонтекстКлассаАнгл);
		СтрВыгрузкиПеречислений = СтрВыгрузкиПеречисленийШапка + Символы.ПС + 
		"
		|namespace osf
		|{
		|    [ContextClass(""Кл" + ИмяКонтекстКлассаРус + """, ""Cl" + ИмяКонтекстКлассаАнгл + """)]
		|    public class Cl" + ИмяКонтекстКлассаАнгл + " : AutoContext<Cl" + ИмяКонтекстКлассаАнгл + ">
		|    {";
		СортироватьСтрРазделОбъявленияПеременныхДляПеречисления();
		СтрВыгрузкиПеречислений = СтрВыгрузкиПеречислений + СтрРазделОбъявленияПеременныхДляПеречисления + Символы.ПС;
		СтрВыгрузкиПеречислений = СтрВыгрузкиПеречислений + СтрСвойстваДляПеречисления + Символы.ПС;
		СтрВыгрузкиПеречислений = СтрВыгрузкиПеречислений + Символы.ПС + 
		"    }//endClass" + Символы.ПС + 
		"}//endnamespace";
	
		ТекстДокПеречислений = Новый ТекстовыйДокумент;
		ТекстДокПеречислений.УстановитьТекст(СтрВыгрузкиПеречислений);
		ТекстДокПеречислений.Записать(ИмяФайлаВыгрузки);
		
	КонецЦикла;
	
	// СписокЗамен.СортироватьПоЗначению();
	// Сообщить("=СписокЗамен========================================================");
	// Для А = 0 По СписокЗамен.Количество() - 1 Цикл
		// Сообщить("" + СписокЗамен.Получить(А).Значение);
	// КонецЦикла;
	
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин." + " " + ТекущаяДата());
КонецПроцедуры//ВыгрузкаДляCS

Процедура СоздатьФайлCs(ИмяФайлаCs)
	СтрВыгрузки = Директивы(ИмяФайлаCs);
	Если Ложь Тогда
	// ИначеЕсли ИмяФайлаCs = "" Тогда
		// СтрВыгрузки = СтрВыгрузки + 
		// "namespace osf
		// |{

		// |}//endnamespace
		// |";
		// ТекстДокХХХ = Новый ТекстовыйДокумент;
		// ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		// ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Screen" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Screen
		|    {
		|        public ClScreen dll_obj;
		|        public System.Windows.Forms.Screen M_Screen;
		|
		|        public Screen()
		|        {
		|            M_Screen = System.Windows.Forms.Screen.PrimaryScreen;
		|        }
		|
		|        public Screen(osf.Screen p1)
		|        {
		|            M_Screen = p1.M_Screen;
		|        }
		|
		|        public Screen(System.Windows.Forms.Screen p1)
		|        {
		|            M_Screen = p1;
		|        }
		|
		|        public osf.Rectangle Bounds
		|        {
		|            get { return new osf.Rectangle(M_Screen.Bounds); }
		|        }
		|
		|        public osf.Screen PrimaryScreen
		|        {
		|            get { return new osf.Screen(System.Windows.Forms.Screen.PrimaryScreen); }
		|        }
		|
		|        public osf.Rectangle WorkingArea
		|        {
		|            get { return new osf.Rectangle(M_Screen.WorkingArea); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "HashTable" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class HashTable : IEnumerable, IEnumerator
		|    {
		|        public ClHashTable dll_obj;
		|        public System.Collections.Hashtable M_HashTable;
		|        public System.Collections.IEnumerator Enumerator;
		|
		|        public HashTable()
		|        {
		|            M_HashTable = new System.Collections.Hashtable();
		|            OneScriptForms.AddToHashtable(M_HashTable, this);
		|        }
		|
		|        public HashTable(osf.HashTable p1)
		|        {
		|            M_HashTable = p1.M_HashTable;
		|            OneScriptForms.AddToHashtable(M_HashTable, this);
		|        }
		|
		|        public HashTable(System.Collections.Hashtable p1)
		|        {
		|            M_HashTable = p1;
		|            OneScriptForms.AddToHashtable(M_HashTable, this);
		|        }
		|
		|        public void Add(object key, object value)
		|        {
		|            M_HashTable.Add(key, value);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void Clear()
		|        {
		|            M_HashTable.Clear();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_HashTable.Count; }
		|        }
		|
		|        public object get_Item(object key)
		|        {
		|            return M_HashTable[key];
		|        }
		|
		|        public void set_Item(object key, object value)
		|        {
		|            M_HashTable[key] = value;
		|        }
		|
		|        public void Remove(object key)
		|        {
		|            M_HashTable.Remove(key);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void Set(object key, object value)
		|        {
		|            M_HashTable[key] = value;
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_HashTable.GetEnumerator();
		|            return (System.Collections.IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "CheckBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class CheckBoxEx : System.Windows.Forms.CheckBox
		|    {
		|        public osf.CheckBox M_Object;
		|    }//endClass
		|
		|    public class CheckBox : ButtonBase
		|    {
		|        public ClCheckBox dll_obj;
		|        private CheckBoxEx m_CheckBox;
		|        public string CheckChanged;
		|
		|        public CheckBoxEx M_CheckBox
		|        {
		|            get { return m_CheckBox; }
		|            set
		|            {
		|                m_CheckBox = value;
		|                m_CheckBox.CheckedChanged += M_CheckBox_CheckedChanged;
		|            }
		|        }
		|
		|        public CheckBox()
		|        {
		|            M_CheckBox = new CheckBoxEx();
		|            M_CheckBox.M_Object = this;
		|            base.M_ButtonBase = M_CheckBox;
		|            CheckChanged = """";
		|        }
		|
		|        public CheckBox(osf.CheckBox p1)
		|        {
		|            M_CheckBox = p1.M_CheckBox;
		|            M_CheckBox.M_Object = this;
		|            base.M_ButtonBase = M_CheckBox;
		|            CheckChanged = """";
		|        }
		|
		|        public CheckBox(System.Windows.Forms.CheckBox p1)
		|        {
		|            M_CheckBox = (CheckBoxEx)p1;
		|            M_CheckBox.M_Object = this;
		|            base.M_ButtonBase = M_CheckBox;
		|            CheckChanged = """";
		|        }
		|
		|        public int Appearance
		|        {
		|            get { return (int)M_CheckBox.Appearance; }
		|            set { M_CheckBox.Appearance = (System.Windows.Forms.Appearance)value; }
		|        }
		|
		|        public bool AutoCheck
		|        {
		|            get { return M_CheckBox.AutoCheck; }
		|            set { M_CheckBox.AutoCheck = value; }
		|        }
		|
		|        public int CheckAlign
		|        {
		|            get { return (int)M_CheckBox.CheckAlign; }
		|            set { M_CheckBox.CheckAlign = (System.Drawing.ContentAlignment)value; }
		|        }
		|
		|        public bool Checked
		|        {
		|            get { return M_CheckBox.Checked; }
		|            set { M_CheckBox.Checked = value; }
		|        }
		|
		|        public int CheckState
		|        {
		|            get { return (int)M_CheckBox.CheckState; }
		|            set { M_CheckBox.CheckState = (System.Windows.Forms.CheckState)value; }
		|        }
		|
		|        public void M_CheckBox_CheckedChanged(object sender, System.EventArgs e)
		|        {
		|            if (CheckChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = CheckChanged;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridComboBoxColumnStyle" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    // Переопределим методы
		|    // Первый из них - Edit. Он вызывается, когда ячейка должна перейти в режим редактирования.
		|    // Второй - метод Paint, здесь изменяется внешний вид ячейки.
		|    // Третий - метод Commit. Он вызывается при завершении редактирования, когда значение необходимо сохранить
		|    // в источнике данных. В этом методе обнуляются поля, заполняемые в перегруженной версии метода Edit. 
		|    public class DataGridComboBoxColumn : System.Windows.Forms.DataGridTextBoxColumn
		|    {
		|        private bool _readOnly;
		|        public ClDataGridComboBoxColumnStyle dll_obj;
		|        public System.Windows.Forms.ComboBox ColumnComboBox;
		|        public ClComboBox comboBox;
		|        private System.Windows.Forms.CurrencyManager _source;
		|        private int _rowNum;
		|        private bool _isEditing;
		|        public static int _RowCount;
		|
		|        public DataGridComboBoxColumn() : base()
		|        {
		|            _source = null;
		|            _isEditing = false;
		|            _RowCount = -1;
		|            osf.NoKeyUpComboBoxEx NoKeyUpComboEx1 = new osf.NoKeyUpComboBoxEx();
		|            comboBox = new ClComboBox(NoKeyUpComboEx1);
		|            ColumnComboBox = (System.Windows.Forms.ComboBox)NoKeyUpComboEx1;
		|            ColumnComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		|            ColumnComboBox.Leave += ColumnComboBox_Leave;
		|            ColumnComboBox.SelectionChangeCommitted += ColumnComboBox_SelectionChangeCommitted;
		|            _readOnly = false;
		|        }
		|
		|        public override bool ReadOnly
		|        {
		|            get { return _readOnly; }
		|            set { _readOnly = value; }
		|        }
		|
		|        private void ColumnComboBox_SelectionChangeCommitted(object sender, System.EventArgs e)
		|        {
		|            _isEditing = true;
		|            base.ColumnStartedEditing((System.Windows.Forms.Control)sender);
		|        }
		|
		|        private void ColumnComboBox_Leave(object sender, System.EventArgs e)
		|        {
		|            if (_isEditing)
		|            {
		|                try
		|                {
		|                    SetColumnValueAtRow(_source, _rowNum, ColumnComboBox.Text);
		|                    _isEditing = false;
		|                    Invalidate();
		|                }
		|                catch { }
		|            }
		|            ColumnComboBox.Hide();
		|            this.DataGridTableStyle.DataGrid.Scroll -= DataGrid_Scroll;
		|        }
		|
		|        private void DataGrid_Scroll(object sender, System.EventArgs e)
		|        {
		|            if (ColumnComboBox.Visible)
		|            {
		|                ColumnComboBox.Hide();
		|            }
		|        }
		|
		|        public ClComboBox ComboBox
		|        {
		|            get { return comboBox; }
		|        }
		|
		|        protected override void Edit(
		|            CurrencyManager source,
		|            int rowNum,
		|            System.Drawing.Rectangle bounds,
		|            bool readOnly,
		|            string instantText,
		|            bool cellIsVisible)
		|        {
		|            if (!_readOnly)
		|            {
		|                base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible);
		|                _rowNum = rowNum;
		|                _source = source;
		|                ColumnComboBox.Parent = this.TextBox.Parent;
		|                ColumnComboBox.Location = new System.Drawing.Point(this.TextBox.Location.X - 2, this.TextBox.Location.Y - 2);
		|                ColumnComboBox.Size = new System.Drawing.Size(this.TextBox.Size.Width, ColumnComboBox.Size.Height);
		|                ColumnComboBox.SelectedIndex = ColumnComboBox.FindStringExact(this.TextBox.Text);
		|                ColumnComboBox.Text = this.TextBox.Text;
		|                this.TextBox.Visible = false;
		|                ColumnComboBox.Visible = true;
		|                this.DataGridTableStyle.DataGrid.Scroll += DataGrid_Scroll;
		|
		|                ColumnComboBox.BringToFront();
		|                ColumnComboBox.Focus();
		|            }
		|        }
		|
		|        protected override bool Commit(CurrencyManager dataSource, int rowNum)
		|        {
		|            if (_isEditing)
		|            {
		|                _isEditing = false;
		|                SetColumnValueAtRow(dataSource, rowNum, ColumnComboBox.Text);
		|            }
		|            return true;
		|        }
		|
		|        protected override void ConcedeFocus()
		|        {
		|            base.ConcedeFocus();
		|        }
		|
		|        protected override object GetColumnValueAtRow(CurrencyManager source, int rowNum)
		|        {
		|            object s = base.GetColumnValueAtRow(source, rowNum);
		|            System.Data.DataView dv = (System.Data.DataView)((System.Data.DataTable)this.ColumnComboBox.DataSource).DefaultView;
		|            int rowCount = dv.Count;
		|            int i = 0;
		|            while (i < rowCount)
		|            {
		|                if (s.Equals(dv[i][this.ComboBox.Base_obj.ValueMember]))
		|                {
		|                    break;
		|                }
		|                ++i;
		|            }
		|
		|            if (i < rowCount)
		|            {
		|                return dv[i][this.ComboBox.Base_obj.DisplayMember];
		|            }
		|            return DBNull.Value;
		|        }
		|
		|        protected override void SetColumnValueAtRow(CurrencyManager source, int rowNum, object value)
		|        {
		|            object s = value;
		|            System.Data.DataView dv = (System.Data.DataView)((System.Data.DataTable)this.ColumnComboBox.DataSource).DefaultView;
		|            int rowCount = dv.Count;
		|            int i = 0;
		|            while (i < rowCount)
		|            {
		|                if (s.Equals(dv[i][this.ComboBox.Base_obj.DisplayMember]))
		|                {
		|                    break;
		|                }
		|                ++i;
		|            }
		|            if (i < rowCount)
		|            {
		|                s = dv[i][this.ComboBox.Base_obj.ValueMember];
		|            }
		|            else
		|                s = DBNull.Value;
		|            try
		|            {
		|                base.SetColumnValueAtRow(source, rowNum, s);
		|            }
		|            catch { }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "RichTextBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class RichTextBoxEx : System.Windows.Forms.RichTextBox
		|    {
		|        public osf.RichTextBox M_Object;
		|    }//endClass
		|
		|    public class RichTextBox : TextBoxBase
		|    {
		|        public ClRichTextBox dll_obj;
		|        private RichTextBoxEx m_RichTextBox;
		|        public string LinkClicked;
		|        public string SelectionChanged;
		|
		|        [DllImport(""user32"", EntryPoint = ""SendMessageA"", CharSet = CharSet.Auto, SetLastError = true)] private static extern new bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		|
		|        public RichTextBoxEx M_RichTextBox
		|        {
		|            get { return m_RichTextBox; }
		|            set
		|            {
		|                m_RichTextBox = value;
		|                m_RichTextBox.SelectionChanged += M_RichTextBox_SelectionChanged;
		|                m_RichTextBox.LinkClicked += M_RichTextBox_LinkClicked;
		|            }
		|        }
		|
		|        public RichTextBox()
		|        {
		|            M_RichTextBox = new RichTextBoxEx();
		|            M_RichTextBox.M_Object = this;
		|            base.M_TextBoxBase = M_RichTextBox;
		|            LinkClicked = """";
		|            SelectionChanged = """";
		|        }
		|
		|        public RichTextBox(osf.RichTextBox p1)
		|        {
		|            M_RichTextBox = p1.M_RichTextBox;
		|            M_RichTextBox.M_Object = this;
		|            base.M_TextBoxBase = M_RichTextBox;
		|            LinkClicked = """";
		|            SelectionChanged = """";
		|        }
		|
		|        public RichTextBox(System.Windows.Forms.RichTextBox p1)
		|        {
		|            M_RichTextBox = (RichTextBoxEx)p1;
		|            M_RichTextBox.M_Object = this;
		|            base.M_TextBoxBase = M_RichTextBox;
		|            LinkClicked = """";
		|            SelectionChanged = """";
		|        }
		|
		|        public bool AutoWordSelection
		|        {
		|            get { return M_RichTextBox.AutoWordSelection; }
		|            set { M_RichTextBox.AutoWordSelection = value; }
		|        }
		|
		|        public override void BeginUpdate()
		|        {
		|            RichTextBox.SendMessage(M_RichTextBox.Handle, 11, 0, 0);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public override void EndUpdate()
		|        {
		|            RichTextBox.SendMessage(M_RichTextBox.Handle, 11, -1, 0);
		|            M_RichTextBox.Invalidate();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public int GetCharIndexFromPosition(osf.Point pt)
		|        {
		|            return M_RichTextBox.GetCharIndexFromPosition(pt.M_Point);
		|        }
		|
		|        public int BulletIndent
		|        {
		|            get { return M_RichTextBox.BulletIndent; }
		|            set { M_RichTextBox.BulletIndent = value; }
		|        }
		|
		|        public bool CanPaste()
		|        {
		|            return M_RichTextBox.CanPaste(System.Windows.Forms.DataFormats.GetFormat(System.Windows.Forms.DataFormats.Text));
		|        }
		|
		|        public bool CanRedo
		|        {
		|            get { return M_RichTextBox.CanRedo; }
		|        }
		|
		|        public bool DetectUrls
		|        {
		|            get { return M_RichTextBox.DetectUrls; }
		|            set { M_RichTextBox.DetectUrls = value; }
		|        }
		|
		|        public int Find(string str, int start = 0, System.Windows.Forms.RichTextBoxFinds options = System.Windows.Forms.RichTextBoxFinds.None)
		|        {
		|            return M_RichTextBox.Find(str, start, (System.Windows.Forms.RichTextBoxFinds)options);
		|        }
		|
		|        public int GetLineFromCharIndex(int index)
		|        {
		|            return M_RichTextBox.GetLineFromCharIndex(index);
		|        }
		|
		|        public void LoadFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType = System.Windows.Forms.RichTextBoxStreamType.RichText)
		|        {
		|            M_RichTextBox.LoadFile(path, (System.Windows.Forms.RichTextBoxStreamType)fileType);
		|        }
		|
		|        public void Redo()
		|        {
		|            M_RichTextBox.Redo();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public int RightMargin
		|        {
		|            get { return M_RichTextBox.RightMargin; }
		|            set { M_RichTextBox.RightMargin = value; }
		|        }
		|
		|        public string Rtf
		|        {
		|            get { return M_RichTextBox.Rtf; }
		|            set { M_RichTextBox.Rtf = value; }
		|        }
		|
		|        public void SaveFile(string path, System.Windows.Forms.RichTextBoxStreamType fileType = System.Windows.Forms.RichTextBoxStreamType.RichText)
		|        {
		|            M_RichTextBox.SaveFile(path, (System.Windows.Forms.RichTextBoxStreamType)fileType);
		|        }
		|
		|        public int ScrollBars
		|        {
		|            get { return (int)M_RichTextBox.ScrollBars; }
		|            set { M_RichTextBox.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars)value; }
		|        }
		|
		|        public osf.Color SelectionBackColor
		|        {
		|            get { return new Color(M_RichTextBox.SelectionBackColor); }
		|            set { M_RichTextBox.SelectionBackColor = value.M_Color; }
		|        }
		|
		|        public osf.Color SelectionColor
		|        {
		|            get { return new Color(M_RichTextBox.SelectionColor); }
		|            set { M_RichTextBox.SelectionColor = value.M_Color; }
		|        }
		|
		|        public osf.Font SelectionFont
		|        {
		|            get { return new Font(M_RichTextBox.SelectionFont);            }
		|            set { M_RichTextBox.SelectionFont = (System.Drawing.Font)value.M_Font;            }
		|        }
		|
		|        public int SelectionIndent
		|        {
		|            get { return M_RichTextBox.SelectionIndent; }
		|            set { M_RichTextBox.SelectionIndent = value; }
		|        }
		|
		|        public int[] SelectionTabs
		|        {
		|            get { return M_RichTextBox.SelectionTabs; }
		|            set { M_RichTextBox.SelectionTabs = value; }
		|        }
		|
		|        public float ZoomFactor
		|        {
		|            get { return M_RichTextBox.ZoomFactor; }
		|            set { M_RichTextBox.ZoomFactor = value; }
		|        }
		|
		|        public void M_RichTextBox_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
		|        {
		|            if (LinkClicked.Length > 0)
		|            {
		|                LinkClickedEventArgs LinkClickedEventArgs1 = new LinkClickedEventArgs();
		|                LinkClickedEventArgs1.EventString = LinkClicked;
		|                LinkClickedEventArgs1.Sender = this;
		|                LinkClickedEventArgs1.LinkText = e.LinkText;
		|                OneScriptForms.EventQueue.Add(LinkClickedEventArgs1);
		|                ClLinkClickedEventArgs ClLinkClickedEventArgs1 = new ClLinkClickedEventArgs(LinkClickedEventArgs1);
		|            }
		|        }
		|
		|        public void M_RichTextBox_SelectionChanged(object sender, System.EventArgs e)
		|        {
		|            if (SelectionChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = SelectionChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "BitmapData" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class BitmapData
		|    {
		|        public ClBitmapData dll_obj;
		|        public System.Drawing.Imaging.BitmapData M_BitmapData;
		|
		|        public BitmapData(osf.BitmapData p1)
		|        {
		|            M_BitmapData = p1.M_BitmapData;
		|            OneScriptForms.AddToHashtable(M_BitmapData, this);
		|        }
		|
		|        public BitmapData(System.Drawing.Imaging.BitmapData p1)
		|        {
		|            M_BitmapData = p1;
		|            OneScriptForms.AddToHashtable(M_BitmapData, this);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridBoolColumn" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridBoolColumnEx : System.Windows.Forms.DataGridBoolColumn
		|    {
		|        public osf.DataGridBoolColumn M_Object;
		|    }//endClass
		|
		|    public class DataGridBoolColumn : DataGridColumnStyle
		|    {
		|        public ClDataGridBoolColumn dll_obj;
		|        public DataGridBoolColumnEx M_DataGridBoolColumn;
		|
		|        public DataGridBoolColumn()
		|        {
		|            M_DataGridBoolColumn = new DataGridBoolColumnEx();
		|            M_DataGridBoolColumn.M_Object = this;
		|            base.M_DataGridColumnStyle = M_DataGridBoolColumn;
		|        }
		|
		|        public DataGridBoolColumn(osf.DataGridBoolColumn p1)
		|        {
		|            M_DataGridBoolColumn = p1.M_DataGridBoolColumn;
		|            M_DataGridBoolColumn.M_Object = this;
		|            base.M_DataGridColumnStyle = M_DataGridBoolColumn;
		|        }
		|
		|        public DataGridBoolColumn(System.Windows.Forms.DataGridBoolColumn p1)
		|        {
		|            M_DataGridBoolColumn = (DataGridBoolColumnEx)p1;
		|            M_DataGridBoolColumn.M_Object = this;
		|            base.M_DataGridColumnStyle = M_DataGridBoolColumn;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "UpDownBase" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class UpDownBase : ContainerControl
		|    {
		|        private System.Windows.Forms.UpDownBase m_UpDownBase;
		|
		|        public System.Windows.Forms.UpDownBase M_UpDownBase
		|        {
		|            get { return m_UpDownBase; }
		|            set
		|            {
		|                m_UpDownBase = value;
		|                base.M_ContainerControl = m_UpDownBase;
		|            }
		|        }
		|
		|        public UpDownBase()
		|        {
		|        }
		|
		|        public UpDownBase(osf.UpDownBase p1)
		|        {
		|            M_UpDownBase = p1.M_UpDownBase;
		|            base.M_ContainerControl = M_UpDownBase;
		|        }
		|
		|        public UpDownBase(System.Windows.Forms.UpDownBase p1)
		|        {
		|            M_UpDownBase = p1;
		|            base.M_ContainerControl = M_UpDownBase;
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_UpDownBase.BorderStyle; }
		|            set
		|            {
		|                M_UpDownBase.BorderStyle = (System.Windows.Forms.BorderStyle)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool ReadOnly
		|        {
		|            get { return M_UpDownBase.ReadOnly; }
		|            set
		|            {
		|                M_UpDownBase.ReadOnly = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "NumericUpDown" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class NumericUpDownEx : System.Windows.Forms.NumericUpDown
		|    {
		|        public object M_Object;
		|    }//endClass
		|
		|    public class NumericUpDown : UpDownBase
		|    {
		|        public ClNumericUpDown dll_obj;
		|        public string ValueChanged;
		|        private NumericUpDownEx m_NumericUpDown;
		|
		|        public NumericUpDownEx M_NumericUpDown
		|        {
		|            get { return m_NumericUpDown; }
		|            set
		|            {
		|                m_NumericUpDown = value;
		|                m_NumericUpDown.ValueChanged += M_NumericUpDown_ValueChanged;
		|            }
		|        }
		|
		|        public NumericUpDown()
		|        {
		|            M_NumericUpDown = new NumericUpDownEx();
		|            M_NumericUpDown.M_Object = this;
		|            base.M_UpDownBase = M_NumericUpDown;
		|            ValueChanged = """";
		|        }
		|
		|        public NumericUpDown(osf.NumericUpDown p1)
		|        {
		|            M_NumericUpDown = p1.M_NumericUpDown;
		|            M_NumericUpDown.M_Object = this;
		|            base.M_UpDownBase = M_NumericUpDown;
		|            ValueChanged = """";
		|        }
		|
		|        public NumericUpDown(System.Windows.Forms.NumericUpDown p1)
		|        {
		|            M_NumericUpDown = (NumericUpDownEx)p1;
		|            M_NumericUpDown.M_Object = this;
		|            base.M_UpDownBase = M_NumericUpDown;
		|            ValueChanged = """";
		|        }
		|
		|        public int DecimalPlaces
		|        {
		|            get { return M_NumericUpDown.DecimalPlaces; }
		|            set
		|            {
		|                M_NumericUpDown.DecimalPlaces = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public Decimal Increment
		|        {
		|            get { return M_NumericUpDown.Increment; }
		|            set
		|            {
		|                M_NumericUpDown.Increment = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public Decimal Maximum
		|        {
		|            get { return M_NumericUpDown.Maximum; }
		|            set
		|            {
		|                M_NumericUpDown.Maximum = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public Decimal Minimum
		|        {
		|            get { return M_NumericUpDown.Minimum; }
		|            set
		|            {
		|                M_NumericUpDown.Minimum = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public Decimal Value
		|        {
		|            get { return M_NumericUpDown.Value; }
		|            set
		|            {
		|                M_NumericUpDown.Value = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        private void M_NumericUpDown_ValueChanged(object sender, System.EventArgs e)
		|        {
		|            if (ValueChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = ValueChanged;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "GroupBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class GroupBoxEx : System.Windows.Forms.GroupBox
		|    {
		|        public osf.GroupBox M_Object;
		|    }//endClass
		|
		|    public class GroupBox : Control
		|    {
		|        public ClGroupBox dll_obj;
		|        public GroupBoxEx M_GroupBox;
		|
		|        public GroupBox()
		|        {
		|            M_GroupBox = new GroupBoxEx();
		|            M_GroupBox.M_Object = this;
		|            base.M_Control = M_GroupBox;
		|        }
		|
		|        public GroupBox(osf.GroupBox p1)
		|        {
		|            M_GroupBox = p1.M_GroupBox;
		|            M_GroupBox.M_Object = this;
		|            base.M_Control = M_GroupBox;
		|        }
		|
		|        public GroupBox(System.Windows.Forms.GroupBox p1)
		|        {
		|            M_GroupBox = (GroupBoxEx)p1;
		|            M_GroupBox.M_Object = this;
		|            base.M_Control = M_GroupBox;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Splitter" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class SplitterEx : System.Windows.Forms.Splitter
		|    {
		|        public osf.Splitter M_Object;
		|    }//endClass
		|
		|    public class Splitter : Control
		|    {
		|        public ClSplitter dll_obj;
		|        public SplitterEx M_Splitter;
		|
		|        public Splitter()
		|        {
		|            M_Splitter = new SplitterEx();
		|            M_Splitter.M_Object = this;
		|            base.M_Control = M_Splitter;
		|        }
		|
		|        public Splitter(osf.Splitter p1)
		|        {
		|            M_Splitter = p1.M_Splitter;
		|            M_Splitter.M_Object = this;
		|            base.M_Control = M_Splitter;
		|        }
		|
		|        public Splitter(System.Windows.Forms.Splitter p1)
		|        {
		|            M_Splitter = (SplitterEx)p1;
		|            M_Splitter.M_Object = this;
		|            base.M_Control = M_Splitter;
		|        }
		|
		|        public int MinExtra
		|        {
		|            get { return M_Splitter.MinExtra; }
		|            set { M_Splitter.MinExtra = value; }
		|        }
		|
		|        public int MinSize
		|        {
		|            get { return M_Splitter.MinSize; }
		|            set { M_Splitter.MinSize = value; }
		|        }
		|
		|        public int SplitPosition
		|        {
		|            get { return M_Splitter.SplitPosition; }
		|            set { M_Splitter.SplitPosition = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TextureBrush" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TextureBrush : Brush
		|    {
		|        public ClTextureBrush dll_obj;
		|        public System.Drawing.TextureBrush M_TextureBrush;
		|
		|        public TextureBrush(System.Drawing.Image p1)
		|        {
		|            M_TextureBrush = new System.Drawing.TextureBrush((System.Drawing.Image)p1);
		|            base.M_Brush = M_TextureBrush;
		|            OneScriptForms.AddToHashtable(M_TextureBrush, this);
		|        }
		|
		|        public TextureBrush(osf.TextureBrush p1)
		|        {
		|            M_TextureBrush = p1.M_TextureBrush;
		|            base.M_Brush = M_TextureBrush;
		|            OneScriptForms.AddToHashtable(M_TextureBrush, this);
		|        }
		|
		|        public TextureBrush(System.Drawing.TextureBrush p1)
		|        {
		|            M_TextureBrush = p1;
		|            base.M_Brush = M_TextureBrush;
		|            OneScriptForms.AddToHashtable(M_TextureBrush, this);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "HatchBrush" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class HatchBrush : Brush
		|    {
		|        public ClHatchBrush dll_obj;
		|        public System.Drawing.Drawing2D.HatchBrush M_HatchBrush;
		|
		|        public HatchBrush(int hatchStyle, osf.Color foreColor, osf.Color backColor = null)
		|        {
		|            if (backColor != null)
		|            {
		|                M_HatchBrush = new System.Drawing.Drawing2D.HatchBrush((System.Drawing.Drawing2D.HatchStyle)hatchStyle, foreColor.M_Color, backColor.M_Color);
		|                base.M_Brush = M_HatchBrush;
		|                OneScriptForms.AddToHashtable(M_HatchBrush, this);
		|            }
		|            else
		|            {
		|                M_HatchBrush = new System.Drawing.Drawing2D.HatchBrush((System.Drawing.Drawing2D.HatchStyle)hatchStyle, foreColor.M_Color);
		|                base.M_Brush = M_HatchBrush;
		|                OneScriptForms.AddToHashtable(M_HatchBrush, this);
		|            }
		|        }
		|
		|        public HatchBrush(osf.HatchBrush p1)
		|        {
		|            M_HatchBrush = p1.M_HatchBrush;
		|            base.M_Brush = M_HatchBrush;
		|            OneScriptForms.AddToHashtable(M_HatchBrush, this);
		|        }
		|
		|        public HatchBrush(System.Drawing.Drawing2D.HatchBrush p1)
		|        {
		|            M_HatchBrush = p1;
		|            base.M_Brush = M_HatchBrush;
		|            OneScriptForms.AddToHashtable(M_HatchBrush, this);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Application" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Application
		|    {
		|        public ClApplication dll_obj;
		|        private static bool m_IsRunning = false;
		|
		|        public void Exit()
		|        {
		|            System.Windows.Forms.Application.Exit();
		|            Application.m_IsRunning = false;
		|        }
		|
		|        public void Run(Form form = null)
		|        {
		|            Application.m_IsRunning = true;
		|            if (form.GetType() != typeof(Form))
		|                return;
		|            form.Show();
		|        }
		|
		|        public bool IsRunning
		|        {
		|            get { return Application.m_IsRunning; }
		|        }
		|
		|        public string DoEvents(bool wait = true)
		|        {
		|            OneScriptForms.EventString = """";
		|            OneScriptForms.EventHandling();
		|            return OneScriptForms.EventString;
		|        }
		|
		|        public void EnableVisualStyles()
		|        {
		|            System.Windows.Forms.Application.EnableVisualStyles();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public string ProductName
		|        {
		|            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
		|        }
		|
		|        public string ProductVersion
		|        {
		|            get { return new osf.Version((dynamic)Assembly.GetExecutingAssembly().GetName().Version).ToString(); }
		|        }
		|
		|        public string UserAppDataPath
		|        {
		|            get { return System.Windows.Forms.Application.UserAppDataPath; }
		|        }
		|
		|        public Version Version
		|        {
		|            get { return new osf.Version((dynamic)Assembly.GetExecutingAssembly().GetName().Version); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DateTimePicker" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DateTimePickerEx : System.Windows.Forms.DateTimePicker
		|    {
		|        public osf.DateTimePicker M_Object;
		|    }//endClass
		|
		|    public class DateTimePicker : Control
		|    {
		|        public ClDateTimePicker dll_obj;
		|        public DateTimePickerEx M_DateTimePicker;
		|        public string ValueChanged;
		|
		|        public DateTimePicker()
		|        {
		|            M_DateTimePicker = new DateTimePickerEx();
		|            M_DateTimePicker.M_Object = this;
		|            base.M_Control = M_DateTimePicker;
		|            M_DateTimePicker.ValueChanged += M_DateTimePicker_ValueChanged;
		|            ValueChanged = """";
		|        }
		|
		|        public DateTimePicker(osf.DateTimePicker p1)
		|        {
		|            M_DateTimePicker = p1.M_DateTimePicker;
		|            M_DateTimePicker.M_Object = this;
		|            base.M_Control = M_DateTimePicker;
		|            M_DateTimePicker.ValueChanged += M_DateTimePicker_ValueChanged;
		|            ValueChanged = """";
		|        }
		|
		|        public DateTimePicker(System.Windows.Forms.DateTimePicker p1)
		|        {
		|            M_DateTimePicker = (DateTimePickerEx)p1;
		|            M_DateTimePicker.M_Object = this;
		|            base.M_Control = M_DateTimePicker;
		|            M_DateTimePicker.ValueChanged += M_DateTimePicker_ValueChanged;
		|            ValueChanged = """";
		|        }
		|
		|        public bool ShowCheckBox
		|        {
		|            get { return M_DateTimePicker.ShowCheckBox; }
		|            set
		|            {
		|                M_DateTimePicker.ShowCheckBox = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool ShowUpDown
		|        {
		|            get { return M_DateTimePicker.ShowUpDown; }
		|            set
		|            {
		|                M_DateTimePicker.ShowUpDown = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int DropDownAlign
		|        {
		|            get { return (int)M_DateTimePicker.DropDownAlign; }
		|            set
		|            {
		|                M_DateTimePicker.DropDownAlign = (System.Windows.Forms.LeftRightAlignment)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public System.DateTime Value
		|        {
		|            get { return M_DateTimePicker.Value; }
		|            set
		|            {
		|                M_DateTimePicker.Value = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public System.DateTime MaxDate
		|        {
		|            get { return M_DateTimePicker.MaxDate; }
		|            set
		|            {
		|                M_DateTimePicker.MaxDate = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public System.DateTime MinDate
		|        {
		|            get { return M_DateTimePicker.MinDate; }
		|            set
		|            {
		|                M_DateTimePicker.MinDate = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string CustomFormat
		|        {
		|            get
		|            {
		|                if (M_DateTimePicker.CustomFormat == null)
		|                {
		|                    return """";
		|                }
		|                return M_DateTimePicker.CustomFormat;
		|            }
		|            set
		|            {
		|                M_DateTimePicker.CustomFormat = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new string Text
		|        {
		|            get
		|            {
		|                if (M_DateTimePicker.Format.ToString() == ""Short"")
		|                {
		|                    return M_DateTimePicker.Value.ToShortDateString() + "" "" + M_DateTimePicker.Value.ToShortTimeString();
		|                }
		|                else if (M_DateTimePicker.Format.ToString() == ""Time"")
		|                {
		|                    return M_DateTimePicker.Value.ToLongTimeString();
		|                }
		|                else if (M_DateTimePicker.Format.ToString() == ""Long"")
		|                {
		|                    return M_DateTimePicker.Value.ToLongDateString() + "" "" + M_DateTimePicker.Value.ToLongTimeString();
		|                }
		|                else if (M_DateTimePicker.Format.ToString() == ""Custom"")
		|                {
		|                    if (M_DateTimePicker.CustomFormat != null)
		|                    {
		|                        return M_DateTimePicker.Value.ToString(M_DateTimePicker.CustomFormat);
		|                    }
		|                }
		|                return """";
		|            }
		|            set
		|            {
		|                M_DateTimePicker.Text = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int PreferredHeight
		|        {
		|            get { return M_DateTimePicker.PreferredHeight; }
		|        }
		|
		|        public osf.Size PreferredSize
		|        {
		|            get { return new Size(M_DateTimePicker.PreferredSize); }
		|        }
		|
		|        public int Format
		|        {
		|            get { return (int)M_DateTimePicker.Format; }
		|            set
		|            {
		|                M_DateTimePicker.Format = (System.Windows.Forms.DateTimePickerFormat)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void M_DateTimePicker_ValueChanged(object sender, System.EventArgs e)
		|        {
		|            if (ValueChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = ValueChanged;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ComboBoxObjectCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ComboBoxObjectCollection : CollectionBase
		|    {
		|        public ClComboBoxObjectCollection dll_obj;
		|        public System.Windows.Forms.ComboBox.ObjectCollection M_ComboBoxObjectCollection;
		|
		|        public ComboBoxObjectCollection()
		|        {
		|        }
		|
		|        public ComboBoxObjectCollection(System.Windows.Forms.ComboBox.ObjectCollection p1)
		|        {
		|            M_ComboBoxObjectCollection = p1;
		|            base.List = M_ComboBoxObjectCollection;
		|        }
		|
		|        public new object Add(object item)
		|        {
		|            M_ComboBoxObjectCollection.Add(item);
		|            System.Windows.Forms.Application.DoEvents();
		|            return item;
		|        }
		|
		|        public new object Insert(int index, object item)
		|        {
		|            M_ComboBoxObjectCollection.Insert(index, item);
		|            System.Windows.Forms.Application.DoEvents();
		|            return item;
		|        }
		|
		|        public new object this[int index]
		|        {
		|            get { return M_ComboBoxObjectCollection[index]; }
		|        }
		|
		|        public new void Remove(object item)
		|        {
		|            M_ComboBoxObjectCollection.Remove(item);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public override object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ComboBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class NoKeyUpComboBoxEx : System.Windows.Forms.ComboBox
		|    {
		|        public osf.ComboBox M_Object;
		|        private const int WM_KEYUP = 0x101;
		|
		|        protected override void WndProc(ref Message m)
		|        {
		|            if (m.Msg == WM_KEYUP)
		|            {
		|                // Игнорировать поднятие клавиши Tab, чтобы избежать проблем с перемещением по колонке, содержащей поле выбора;
		|                // Иначе невозможно будет с помощью клавиши Tab передать фокус колонке, содержащей поле выбора.
		|                return;
		|            }
		|            base.WndProc(ref m);
		|        }
		|    }//endClass
		|		
		|    public class ComboBoxEx : System.Windows.Forms.ComboBox
		|    {
		|        public osf.ComboBox M_Object;
		|    }//endClass
		|
		|    public class ComboBox : ListControl
		|    {
		|        public ClComboBox dll_obj;
		|        private dynamic m_ComboBox;
		|        public string SelectedIndexChanged;
		|        public string DropDown;
		|        public ArrayList heights;
		|
		|        public dynamic M_ComboBox
		|        {
		|            get { return m_ComboBox; }
		|            set
		|            {
		|                m_ComboBox = value;
		|                ((System.Windows.Forms.ComboBox)m_ComboBox).DropDown += M_ComboBox_DropDown;
		|                ((System.Windows.Forms.ComboBox)m_ComboBox).SelectedIndexChanged += M_ComboBox_SelectedIndexChanged;
		|                ((System.Windows.Forms.ComboBox)m_ComboBox).DrawItem += M_ComboBox_DrawItem;
		|                ((System.Windows.Forms.ComboBox)m_ComboBox).MeasureItem += M_ComboBox_MeasureItem;
		|            }
		|        }
		|
		|        public ComboBox()
		|        {
		|            M_ComboBox = new ComboBoxEx();
		|            M_ComboBox.M_Object = this;
		|            base.M_ListControl = M_ComboBox;
		|            SelectedIndexChanged = """";
		|            DropDown = """";
		|            heights = new ArrayList();
		|        }
		|
		|        public ComboBox(osf.ComboBox p1)
		|        {
		|            M_ComboBox = p1.M_ComboBox;
		|            M_ComboBox.M_Object = this;
		|            base.M_ListControl = M_ComboBox;
		|            SelectedIndexChanged = """";
		|            DropDown = """";
		|            heights = new ArrayList();
		|        }
		|
		|        public ComboBox(System.Windows.Forms.ComboBox p1)
		|        {
		|            M_ComboBox = (ComboBoxEx)p1;
		|            M_ComboBox.M_Object = this;
		|            base.M_ListControl = M_ComboBox;
		|            SelectedIndexChanged = """";
		|            DropDown = """";
		|            heights = new ArrayList();
		|        }
		|
		|        public ComboBox(osf.NoKeyUpComboBoxEx p1)
		|        {
		|            M_ComboBox = (dynamic)((System.Windows.Forms.ComboBox)p1);
		|            M_ComboBox.M_Object = this;
		|            base.M_ListControl = M_ComboBox;
		|            SelectedIndexChanged = """";
		|            DropDown = """";
		|            heights = new ArrayList();
		|        }
		|
		|        public osf.ArrayList HeightItems
		|        {
		|            get { return heights; }
		|            set { heights = value; }
		|        }
		|
		|        public int DropDownStyle
		|        {
		|            get { return (int)M_ComboBox.DropDownStyle; }
		|            set { M_ComboBox.DropDownStyle = (System.Windows.Forms.ComboBoxStyle)value; }
		|        }
		|
		|        public int DropDownWidth
		|        {
		|            get { return M_ComboBox.DropDownWidth; }
		|            set { M_ComboBox.DropDownWidth = value; }
		|        }
		|
		|        public bool DroppedDown
		|        {
		|            get { return M_ComboBox.DroppedDown; }
		|            set { M_ComboBox.DroppedDown = value; }
		|        }
		|
		|        public bool IntegralHeight
		|        {
		|            get { return M_ComboBox.IntegralHeight; }
		|            set { M_ComboBox.IntegralHeight = value; }
		|        }
		|
		|        public int ItemHeight
		|        {
		|            get { return M_ComboBox.ItemHeight; }
		|            set { M_ComboBox.ItemHeight = value; }
		|        }
		|
		|        public osf.ComboBoxObjectCollection Items
		|        {
		|            get { return new ComboBoxObjectCollection(M_ComboBox.Items); }
		|        }
		|
		|        public int MaxDropDownItems
		|        {
		|            get { return M_ComboBox.MaxDropDownItems; }
		|            set { M_ComboBox.MaxDropDownItems = value; }
		|        }
		|
		|        public int MaxLength
		|        {
		|            get { return M_ComboBox.MaxLength; }
		|            set { M_ComboBox.MaxLength = value; }
		|        }
		|
		|        public void Paste()
		|        {
		|            System.Windows.Forms.IDataObject dataObject = System.Windows.Forms.Clipboard.GetDataObject();
		|            if (dataObject.GetDataPresent(System.Windows.Forms.DataFormats.Text))
		|            {
		|                M_ComboBox.Text = Convert.ToString(dataObject.GetData(System.Windows.Forms.DataFormats.Text));
		|            }
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public virtual int PreferredHeight
		|        {
		|            get { return M_ComboBox.PreferredHeight; }
		|        }
		|
		|        public int SelectedIndex
		|        {
		|            get { return M_ComboBox.SelectedIndex; }
		|            set { M_ComboBox.SelectedIndex = value; }
		|        }
		|
		|        public string SelectedText
		|        {
		|            get { return M_ComboBox.SelectedText; }
		|            set { M_ComboBox.SelectedText = value; }
		|        }
		|
		|        public int SelectionLength
		|        {
		|            get { return M_ComboBox.SelectionLength; }
		|            set { M_ComboBox.SelectionLength = value; }
		|        }
		|
		|        public int SelectionStart
		|        {
		|            get { return M_ComboBox.SelectionStart; }
		|            set { M_ComboBox.SelectionStart = value; }
		|        }
		|
		|        public bool Sorted
		|        {
		|            get { return M_ComboBox.Sorted; }
		|            set { M_ComboBox.Sorted = value; }
		|        }
		|
		|        public int DrawMode
		|        {
		|            get { return (int)M_ComboBox.DrawMode; }
		|            set { M_ComboBox.DrawMode = (System.Windows.Forms.DrawMode)value; }
		|        }
		|
		|        public void M_ComboBox_DropDown(object sender, System.EventArgs e)
		|        {
		|            if (DropDown.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = DropDown;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public void M_ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		|        {
		|            if (SelectedIndexChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = SelectedIndexChanged;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        private void M_ComboBox_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		|        {
		|            dynamic var1 = HeightItems[e.Index];
		|            try
		|            {
		|                e.ItemHeight = Convert.ToInt32(var1.AsString());
		|            }
		|            catch
		|            {
		|                e.ItemHeight = Convert.ToInt32(var1);
		|            }
		|        }
		|
		|        private void M_ComboBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		|        {
		|            if (e.Index == -1)
		|            {
		|                return;
		|            }
		|            e.DrawBackground();
		|            e.DrawFocusRectangle();
		|            dynamic item = M_ComboBox.Items[e.Index];
		|            System.Type type = item.GetType();
		|            System.Drawing.Color color1 = M_ComboBox.ForeColor;
		|            PropertyInfo propertyForeColor = type.GetProperty(""ForeColor"");
		|            Color colorForeColor = null;
		|            if (propertyForeColor != null)
		|            {
		|                try
		|                {
		|                    colorForeColor = (Color)propertyForeColor.GetValue(Items[e.Index], (object[])null);
		|                }
		|                catch
		|                {
		|                    colorForeColor = ((ClColor)propertyForeColor.GetValue(Items[e.Index], (object[])null)).Base_obj;
		|                }
		|            }
		|            if ((e.State & System.Windows.Forms.DrawItemState.Disabled) == System.Windows.Forms.DrawItemState.Disabled)
		|            {
		|                try
		|                {
		|                    if (!colorForeColor.IsEmpty)
		|                    {
		|                        color1 = colorForeColor.M_Color;
		|                    }
		|                }
		|                catch
		|                {
		|                    color1 = System.Drawing.SystemColors.GrayText;
		|                }
		|            }
		|            else if ((e.State & System.Windows.Forms.DrawItemState.Selected) == System.Windows.Forms.DrawItemState.Selected)
		|            {
		|                color1 = System.Drawing.SystemColors.HighlightText;
		|            }
		|            else
		|            {
		|                try
		|                {
		|                    if (!colorForeColor.IsEmpty)
		|                    {
		|                        color1 = colorForeColor.M_Color;
		|                    }
		|                }
		|                catch
		|                {
		|                }
		|            }
		|            string s = """";
		|            string ObjType = item.GetType().ToString();
		|            if (ObjType == ""System.Data.DataRowView"")
		|            {
		|                System.Data.DataRowView drv = (System.Data.DataRowView)item;
		|                try
		|                {
		|                    dynamic var1 = drv.Row[M_ComboBox.DisplayMember];
		|                    System.Type Type1 = var1.GetType();
		|                    s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
		|                }
		|                catch
		|                {
		|                    if (drv.Row[M_ComboBox.DisplayMember].GetType() == typeof(System.Boolean))
		|                    {
		|                        ScriptEngine.Machine.Values.BooleanValue Bool1;
		|                        if ((System.Boolean)drv.Row[M_ComboBox.DisplayMember])
		|                        {
		|                            Bool1 = ScriptEngine.Machine.Values.BooleanValue.True;
		|                        }
		|                        else
		|                        {
		|                            Bool1 = ScriptEngine.Machine.Values.BooleanValue.False;
		|                        }
		|                        s = Bool1.ToString();
		|                    }
		|                    else
		|                    {
		|                        s = drv.Row[M_ComboBox.DisplayMember].ToString();
		|                    }
		|                }
		|            }
		|            else if (ObjType == ""osf.ListItem"")
		|            {
		|                try
		|                {
		|                    s = ((osf.ListItem)item).Value.GetType().GetCustomAttribute<ContextClassAttribute>().GetName();
		|                }
		|                catch
		|                {
		|                    s = ((osf.ListItem)item).Text;
		|                }
		|            }
		|            if (s == """")
		|            {
		|                PropertyInfo property1 = type.GetProperty(M_ComboBox.DisplayMember);
		|                if (property1 != null)
		|                {
		|                    s = Convert.ToString(property1.GetValue(Items[e.Index]));
		|                }
		|                else
		|                {
		|                    if (SelectedIndexChanged != """")
		|                    {
		|                        try
		|                        {
		|                            System.Type Type1 = item.GetType();
		|                            s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
		|                        }
		|                        catch
		|                        {
		|                            s = item.ToString();
		|                        }
		|                    }
		|                    else
		|                    {
		|                        s = item.ToString();
		|                    }
		|                }
		|            }
		|            e.Graphics.DrawString(s, M_ComboBox.Font, (System.Drawing.Brush)new System.Drawing.SolidBrush(color1), (float)e.Bounds.X, (float)e.Bounds.Y);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ToolTip" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ToolTipEx : System.Windows.Forms.ToolTip
		|    {
		|        public osf.ToolTip M_Object;
		|    }//endClass
		|
		|    public class ToolTip
		|    {
		|        public ClToolTip dll_obj;
		|        public ToolTipEx M_ToolTip;
		|
		|        public ToolTip()
		|        {
		|            M_ToolTip = new ToolTipEx();
		|            M_ToolTip.M_Object = this;
		|        }
		|
		|        public ToolTip(osf.ToolTip p1)
		|        {
		|            M_ToolTip = p1.M_ToolTip;
		|            M_ToolTip.M_Object = this;
		|        }
		|
		|        public ToolTip(System.Windows.Forms.ToolTip p1)
		|        {
		|            M_ToolTip = (ToolTipEx)p1;
		|            M_ToolTip.M_Object = this;
		|        }
		|
		|        public bool Active
		|        {
		|            get { return M_ToolTip.Active; }
		|            set { M_ToolTip.Active = value; }
		|        }
		|
		|        public int AutomaticDelay
		|        {
		|            get { return M_ToolTip.AutomaticDelay; }
		|            set { M_ToolTip.AutomaticDelay = value; }
		|        }
		|
		|        public int AutoPopDelay
		|        {
		|            get { return M_ToolTip.AutoPopDelay; }
		|            set { M_ToolTip.AutoPopDelay = value; }
		|        }
		|
		|        public string GetToolTip(Control p1)
		|        {
		|            return M_ToolTip.GetToolTip(p1.M_Control);
		|        }
		|
		|        public int InitialDelay
		|        {
		|            get { return M_ToolTip.InitialDelay; }
		|            set { M_ToolTip.InitialDelay = value; }
		|        }
		|
		|        public void RemoveAll()
		|        {
		|            M_ToolTip.RemoveAll();
		|        }
		|
		|        public int ReshowDelay
		|        {
		|            get { return M_ToolTip.ReshowDelay; }
		|            set { M_ToolTip.ReshowDelay = value; }
		|        }
		|
		|        public void SetToolTip(Control p1, string p2)
		|        {
		|            M_ToolTip.SetToolTip(p1.M_Control, p2);
		|        }
		|
		|        public bool ShowAlways
		|        {
		|            get { return M_ToolTip.ShowAlways; }
		|            set { M_ToolTip.ShowAlways = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "RadioButton" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class RadioButtonEx : System.Windows.Forms.RadioButton
		|    {
		|        public osf.RadioButton M_Object;
		|    }//endClass
		|
		|    public class RadioButton : ButtonBase
		|    {
		|        public ClRadioButton dll_obj;
		|        private RadioButtonEx m_RadioButton;
		|        public string CheckChanged;
		|
		|        public RadioButtonEx M_RadioButton
		|        {
		|            get { return m_RadioButton; }
		|            set
		|            {
		|                m_RadioButton = value;
		|                m_RadioButton.CheckedChanged += M_RadioButton_CheckedChanged;
		|            }
		|        }
		|
		|        public RadioButton()
		|        {
		|            M_RadioButton = new RadioButtonEx();
		|            M_RadioButton.M_Object = this;
		|            base.M_ButtonBase = M_RadioButton;
		|            CheckChanged = """";
		|        }
		|
		|        public RadioButton(osf.RadioButton p1)
		|        {
		|            M_RadioButton = p1.M_RadioButton;
		|            M_RadioButton.M_Object = this;
		|            base.M_ButtonBase = M_RadioButton;
		|            CheckChanged = """";
		|        }
		|
		|        public RadioButton(System.Windows.Forms.RadioButton p1)
		|        {
		|            M_RadioButton = (RadioButtonEx)p1;
		|            M_RadioButton.M_Object = this;
		|            base.M_ButtonBase = M_RadioButton;
		|            CheckChanged = """";
		|        }
		|
		|        public int Appearance
		|        {
		|            get { return (int)M_RadioButton.Appearance; }
		|            set { M_RadioButton.Appearance = (System.Windows.Forms.Appearance)value; }
		|        }
		|
		|        public bool AutoCheck
		|        {
		|            get { return M_RadioButton.AutoCheck; }
		|            set { M_RadioButton.AutoCheck = value; }
		|        }
		|
		|        public int CheckAlign
		|        {
		|            get { return (int)M_RadioButton.CheckAlign; }
		|            set { M_RadioButton.CheckAlign = (System.Drawing.ContentAlignment)value; }
		|        }
		|
		|
		|        public bool Checked
		|        {
		|            get { return M_RadioButton.Checked; }
		|            set { M_RadioButton.Checked = value; }
		|        }
		|
		|        private void M_RadioButton_CheckedChanged(object sender, System.EventArgs e)
		|        {
		|            if (CheckChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = CheckChanged;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClKeyEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "StatusBarPanel" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class StatusBarPanelEx : System.Windows.Forms.StatusBarPanel
		|    {
		|        public osf.StatusBarPanel M_Object;
		|    }//endClass
		|
		|    public class StatusBarPanel : Component
		|    {
		|        public ClStatusBarPanel dll_obj;
		|        public StatusBarPanelEx M_StatusBarPanel;
		|
		|        public StatusBarPanel(string text = null)
		|        {
		|            M_StatusBarPanel = new StatusBarPanelEx();
		|            M_StatusBarPanel.M_Object = this;
		|            base.M_Component = M_StatusBarPanel;
		|            if (text != null)
		|            {
		|                M_StatusBarPanel.Text = text;
		|            }
		|        }
		|
		|        public StatusBarPanel(osf.StatusBarPanel p1)
		|        {
		|            M_StatusBarPanel = p1.M_StatusBarPanel;
		|            M_StatusBarPanel.M_Object = this;
		|            base.M_Component = M_StatusBarPanel;
		|        }
		|
		|        public StatusBarPanel(System.Windows.Forms.StatusBarPanel p1)
		|        {
		|            M_StatusBarPanel = (StatusBarPanelEx)p1;
		|            M_StatusBarPanel.M_Object = this;
		|            base.M_Component = M_StatusBarPanel;
		|        }
		|
		|        public int AutoSize
		|        {
		|            get { return (int)M_StatusBarPanel.AutoSize; }
		|            set { M_StatusBarPanel.AutoSize = (System.Windows.Forms.StatusBarPanelAutoSize)value; }
		|        }
		|
		|        public osf.Icon Icon
		|        {
		|            get { return new Icon(M_StatusBarPanel.Icon); }
		|            set { M_StatusBarPanel.Icon = (System.Drawing.Icon)value.M_Icon; }
		|        }
		|
		|        public int MinWidth
		|        {
		|            get { return M_StatusBarPanel.MinWidth; }
		|            set { M_StatusBarPanel.MinWidth = value; }
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_StatusBarPanel.BorderStyle; }
		|            set { M_StatusBarPanel.BorderStyle = (System.Windows.Forms.StatusBarPanelBorderStyle)value; }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_StatusBarPanel.Text; }
		|            set { M_StatusBarPanel.Text = value; }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_StatusBarPanel.Width; }
		|            set { M_StatusBarPanel.Width = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "StatusBarPanelCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class StatusBarPanelCollection : CollectionBase
		|    {
		|        public ClStatusBarPanelCollection dll_obj;
		|        public System.Windows.Forms.StatusBar.StatusBarPanelCollection M_StatusBarPanelCollection;
		|
		|        public StatusBarPanelCollection()
		|        {
		|        }
		|
		|        public StatusBarPanelCollection(System.Windows.Forms.StatusBar.StatusBarPanelCollection p1)
		|        {
		|            M_StatusBarPanelCollection = p1;
		|            base.List = M_StatusBarPanelCollection;
		|        }
		|
		|        public osf.StatusBarPanel Add(osf.StatusBarPanel p1)
		|        {
		|            M_StatusBarPanelCollection.Add(p1.M_StatusBarPanel);
		|            return p1;
		|        }
		|
		|        public osf.StatusBarPanel Insert(int index, osf.StatusBarPanel p1)
		|        {
		|            M_StatusBarPanelCollection.Insert(index, p1.M_StatusBarPanel);
		|            return p1;
		|        }
		|
		|        public void Remove(osf.StatusBarPanel p1)
		|        {
		|            M_StatusBarPanelCollection.Remove(p1.M_StatusBarPanel);
		|        }
		|
		|        public new osf.StatusBarPanel this[int Index]
		|        {
		|            get { return ((StatusBarPanelEx)M_StatusBarPanelCollection[Index]).M_Object; }
		|        }
		|
		|        public override object Current
		|        {
		|            get { return (object)((StatusBarPanelEx)Enumerator.Current).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "StatusBar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class StatusBarEx : System.Windows.Forms.StatusBar
		|    {
		|        public osf.StatusBar M_Object;
		|    }//endClass
		|
		|    public class StatusBar : Control
		|    {
		|        public ClStatusBar dll_obj;
		|        public StatusBarEx M_StatusBar;
		|
		|        public StatusBar()
		|        {
		|            M_StatusBar = new StatusBarEx();
		|            M_StatusBar.M_Object = this;
		|            base.M_Control = M_StatusBar;
		|        }
		|
		|        public StatusBar(osf.StatusBar p1)
		|        {
		|            M_StatusBar = p1.M_StatusBar;
		|            M_StatusBar.M_Object = this;
		|            base.M_Control = M_StatusBar;
		|        }
		|
		|        public StatusBar(System.Windows.Forms.StatusBar p1)
		|        {
		|            M_StatusBar = (StatusBarEx)p1;
		|            M_StatusBar.M_Object = this;
		|            base.M_Control = M_StatusBar;
		|        }
		|
		|        public osf.StatusBarPanelCollection Panels
		|        {
		|            get { return new StatusBarPanelCollection(M_StatusBar.Panels); }
		|        }
		|
		|        public bool ShowPanels
		|        {
		|            get { return M_StatusBar.ShowPanels; }
		|            set { M_StatusBar.ShowPanels = value; }
		|        }
		|
		|        public bool SizingGrip
		|        {
		|            get { return M_StatusBar.SizingGrip; }
		|            set { M_StatusBar.SizingGrip = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "FileSystemWatcher" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FileSystemWatcherEx : System.IO.FileSystemWatcher
		|    {
		|        public osf.FileSystemWatcher M_Object;
		|    }//endClass
		|
		|    public class FileSystemWatcher : Component
		|    {
		|        public ClFileSystemWatcher dll_obj;
		|        private FileSystemWatcherEx m_FileSystemWatcher;
		|        public string Changed;
		|        public string Created;
		|        public string Deleted;
		|        public string Renamed;
		|
		|        public FileSystemWatcherEx M_FileSystemWatcher
		|        {
		|            get { return m_FileSystemWatcher; }
		|            set
		|            {
		|                m_FileSystemWatcher = value;
		|                base.M_Component = m_FileSystemWatcher;
		|                System.Windows.Forms.Form obj1 = new System.Windows.Forms.Form();
		|                IntPtr num1 = obj1.Handle;
		|                m_FileSystemWatcher.SynchronizingObject = obj1;
		|                m_FileSystemWatcher.Renamed += M_FileSystemWatcher_Renamed;
		|                m_FileSystemWatcher.Deleted += M_FileSystemWatcher_Deleted;
		|                m_FileSystemWatcher.Created += M_FileSystemWatcher_Created;
		|                m_FileSystemWatcher.Changed += M_FileSystemWatcher_Changed;
		|            }
		|        }
		|
		|        public FileSystemWatcher()
		|        {
		|            M_FileSystemWatcher = new FileSystemWatcherEx();
		|            M_FileSystemWatcher.M_Object = this;
		|            Changed = """";
		|            Created = """";
		|            Deleted = """";
		|            Renamed = """";
		|        }
		|
		|        public FileSystemWatcher(osf.FileSystemWatcher p1)
		|        {
		|            M_FileSystemWatcher = p1.M_FileSystemWatcher;
		|            M_FileSystemWatcher.M_Object = this;
		|            Changed = """";
		|            Created = """";
		|            Deleted = """";
		|            Renamed = """";
		|        }
		|
		|        public FileSystemWatcher(System.IO.FileSystemWatcher FileSystemWatcher)
		|        {
		|            M_FileSystemWatcher = (FileSystemWatcherEx)FileSystemWatcher;
		|            M_FileSystemWatcher.M_Object = this;
		|            Changed = """";
		|            Created = """";
		|            Deleted = """";
		|            Renamed = """";
		|        }
		|
		|        public bool EnableRaisingEvents
		|        {
		|            get { return M_FileSystemWatcher.EnableRaisingEvents; }
		|            set
		|            {
		|                M_FileSystemWatcher.EnableRaisingEvents = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Filter
		|        {
		|            get { return M_FileSystemWatcher.Filter; }
		|            set
		|            {
		|                M_FileSystemWatcher.Filter = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool IncludeSubDirectories
		|        {
		|            get { return M_FileSystemWatcher.EnableRaisingEvents; }
		|            set
		|            {
		|                M_FileSystemWatcher.EnableRaisingEvents = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int InternalBufferSize
		|        {
		|            get { return M_FileSystemWatcher.InternalBufferSize; }
		|            set
		|            {
		|                M_FileSystemWatcher.InternalBufferSize = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int NotifyFilter
		|        {
		|            get { return (int)M_FileSystemWatcher.NotifyFilter; }
		|            set
		|            {
		|                M_FileSystemWatcher.NotifyFilter = (System.IO.NotifyFilters)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Path
		|        {
		|            get { return M_FileSystemWatcher.Path; }
		|            set
		|            {
		|                M_FileSystemWatcher.Path = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void M_FileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
		|        {
		|            if (Changed.Length > 0)
		|            {
		|                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
		|                FileSystemEventArgs1.Sender = (object)this;
		|                FileSystemEventArgs1.EventString = Changed;
		|                FileSystemEventArgs1.ChangeType = (int)e.ChangeType;
		|                FileSystemEventArgs1.FullPath = e.FullPath;
		|                FileSystemEventArgs1.Name = e.Name;
		|                OneScriptForms.EventQueue.Add(FileSystemEventArgs1);
		|                ClFileSystemEventArgs ClFileSystemEventArgs1 = new ClFileSystemEventArgs(FileSystemEventArgs1);
		|            }
		|        }
		|
		|        public void M_FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
		|        {
		|            if (Created.Length > 0)
		|            {
		|                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
		|                FileSystemEventArgs1.Sender = (object)this;
		|                FileSystemEventArgs1.EventString = Created;
		|                FileSystemEventArgs1.ChangeType = (int)e.ChangeType;
		|                FileSystemEventArgs1.FullPath = e.FullPath;
		|                FileSystemEventArgs1.Name = e.Name;
		|                OneScriptForms.EventQueue.Add(FileSystemEventArgs1);
		|                ClFileSystemEventArgs ClFileSystemEventArgs1 = new ClFileSystemEventArgs(FileSystemEventArgs1);
		|            }
		|        }
		|
		|        public void M_FileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
		|        {
		|            if (Deleted.Length > 0)
		|            {
		|                FileSystemEventArgs FileSystemEventArgs1 = new FileSystemEventArgs();
		|                FileSystemEventArgs1.Sender = (object)this;
		|                FileSystemEventArgs1.EventString = Deleted;
		|                FileSystemEventArgs1.ChangeType = (int)e.ChangeType;
		|                FileSystemEventArgs1.FullPath = e.FullPath;
		|                FileSystemEventArgs1.Name = e.Name;
		|                OneScriptForms.EventQueue.Add(FileSystemEventArgs1);
		|                ClFileSystemEventArgs ClFileSystemEventArgs1 = new ClFileSystemEventArgs(FileSystemEventArgs1);
		|            }
		|        }
		|
		|        public void M_FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
		|        {
		|            if (Renamed.Length > 0)
		|            {
		|                RenamedEventArgs RenamedEventArgs1 = new RenamedEventArgs();
		|                RenamedEventArgs1.Sender = (object)this;
		|                RenamedEventArgs1.EventString = Renamed;
		|                RenamedEventArgs1.ChangeType = (int)e.ChangeType;
		|                RenamedEventArgs1.FullPath = e.FullPath;
		|                RenamedEventArgs1.Name = e.Name;
		|                RenamedEventArgs1.OldFullPath = e.OldFullPath;
		|                RenamedEventArgs1.OldName = e.OldName;
		|                OneScriptForms.EventQueue.Add(RenamedEventArgs1);
		|                ClRenamedEventArgs ClRenamedEventArgs1 = new ClRenamedEventArgs(RenamedEventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "SortedList" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class SortedList : IEnumerator
		|    {
		|        public ClSortedList dll_obj;
		|        public System.Collections.SortedList M_SortedList;
		|        public IEnumerator Enumerator;
		|
		|        public SortedList()
		|        {
		|            Enumerator = null;
		|            M_SortedList = new System.Collections.SortedList();
		|        }
		|
		|        public SortedList(System.Collections.SortedList p1)
		|        {
		|            Enumerator = null;
		|            M_SortedList = (System.Collections.SortedList)p1;
		|        }
		|
		|        public void Add(object key, object value)
		|        {
		|            M_SortedList.Add(RuntimeHelpers.GetObjectValue(key), RuntimeHelpers.GetObjectValue(value));
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_SortedList.Count; }
		|        }
		|
		|        public DictionaryEntry get_Item(object key)
		|        {
		|            return (DictionaryEntry)M_SortedList[RuntimeHelpers.GetObjectValue(key)];
		|        }
		|
		|        public object GetByIndex(int index)
		|        {
		|            return M_SortedList.GetByIndex(index);
		|        }
		|
		|        public void Remove(object key)
		|        {
		|            M_SortedList.Remove(RuntimeHelpers.GetObjectValue(key));
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public virtual IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_SortedList.GetEnumerator();
		|            return this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|
		|        public virtual bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public virtual void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|		
		|        public bool ContainsValue(object  p1)
		|        {
		|            return M_SortedList.ContainsValue(p1);
		|        }
		|
		|        public bool ContainsKey(object  p1)
		|        {
		|            return M_SortedList.ContainsKey(p1);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DictionaryEntry" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DictionaryEntry
		|    {
		|        public ClDictionaryEntry dll_obj;
		|        public System.Collections.DictionaryEntry M_DictionaryEntry;
		|
		|        public DictionaryEntry(object p1, object p2)
		|        {
		|            M_DictionaryEntry = new System.Collections.DictionaryEntry(p1, p2);
		|            OneScriptForms.AddToHashtable(M_DictionaryEntry, this);
		|        }
		|
		|        public DictionaryEntry(osf.DictionaryEntry p1)
		|        {
		|            M_DictionaryEntry = p1.M_DictionaryEntry;
		|            OneScriptForms.AddToHashtable(M_DictionaryEntry, this);
		|        }
		|
		|        public DictionaryEntry(System.Collections.DictionaryEntry p1)
		|        {
		|            M_DictionaryEntry = p1;
		|            OneScriptForms.AddToHashtable(M_DictionaryEntry, this);
		|        }
		|
		|        public object Key
		|        {
		|            get{return M_DictionaryEntry.Key;}
		|            set{M_DictionaryEntry.Key = value;}
		|        }
		|
		|        public object Value
		|        {
		|            get{return M_DictionaryEntry.Value;}
		|            set{M_DictionaryEntry.Value = value;}
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Cursors" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Cursors
		|    {
		|        public ClCursors dll_obj;
		|
		|        public osf.Cursor AppStarting
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.AppStarting); }
		|        }
		|
		|        public osf.Cursor Arrow
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.Arrow); }
		|        }
		|
		|        public osf.Cursor Cross
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.Cross); }
		|        }
		|
		|        public osf.Cursor Default
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.Default); }
		|        }
		|
		|        public osf.Cursor Hand
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.Hand); }
		|        }
		|
		|        public osf.Cursor Help
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.Help); }
		|        }
		|
		|        public osf.Cursor HSplit
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.HSplit); }
		|        }
		|
		|        public osf.Cursor IBeam
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.IBeam); }
		|        }
		|
		|        public osf.Cursor No
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.No); }
		|        }
		|
		|        public osf.Cursor NoMove2D
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.NoMove2D); }
		|        }
		|
		|        public osf.Cursor NoMoveHoriz
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.NoMoveHoriz); }
		|        }
		|
		|        public osf.Cursor NoMoveVert
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.NoMoveVert); }
		|        }
		|
		|        public osf.Cursor PanEast
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanEast); }
		|        }
		|
		|        public osf.Cursor PanNE
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanNE); }
		|        }
		|
		|        public osf.Cursor PanNorth
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanNorth); }
		|        }
		|
		|        public osf.Cursor PanNW
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanNW); }
		|        }
		|
		|        public osf.Cursor PanSE
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanSE); }
		|        }
		|
		|        public osf.Cursor PanSouth
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanSouth); }
		|        }
		|
		|        public osf.Cursor PanSW
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanSW); }
		|        }
		|
		|        public osf.Cursor PanWest
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.PanWest); }
		|        }
		|
		|        public osf.Cursor SizeAll
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.SizeAll); }
		|        }
		|
		|        public osf.Cursor SizeNESW
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.SizeNESW); }
		|        }
		|
		|        public osf.Cursor SizeNS
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.SizeNS); }
		|        }
		|
		|        public osf.Cursor SizeNWSE
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.SizeNWSE); }
		|        }
		|
		|        public osf.Cursor SizeWE
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.SizeWE); }
		|        }
		|
		|        public osf.Cursor UpArrow
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.UpArrow); }
		|        }
		|
		|        public osf.Cursor VSplit
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.VSplit); }
		|        }
		|
		|        public osf.Cursor WaitCursor
		|        {
		|            get {return new Cursor(System.Windows.Forms.Cursors.WaitCursor); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridTextBoxColumn" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridTextBoxColumnEx : System.Windows.Forms.DataGridTextBoxColumn
		|    {
		|        public osf.DataGridTextBoxColumn M_Object;
		|    }//endClass
		|		
		|    public class DataGridTextBoxColumn : DataGridColumnStyle
		|    {
		|        public ClDataGridTextBoxColumn dll_obj;
		|        public DataGridTextBoxColumnEx M_DataGridTextBoxColumn;
		|
		|        public DataGridTextBoxColumn()
		|        {
		|            M_DataGridTextBoxColumn = new DataGridTextBoxColumnEx();
		|            M_DataGridTextBoxColumn.M_Object = this;
		|            base.M_DataGridColumnStyle = (System.Windows.Forms.DataGridColumnStyle)M_DataGridTextBoxColumn;
		|        }
		|		
		|        public DataGridTextBoxColumn(osf.DataGridTextBoxColumn p1)
		|        {
		|            M_DataGridTextBoxColumn = p1.M_DataGridTextBoxColumn;
		|            M_DataGridTextBoxColumn.M_Object = this;
		|            base.M_DataGridColumnStyle = M_DataGridTextBoxColumn;
		|        }
		|		
		|        public DataGridTextBoxColumn(System.Windows.Forms.DataGridTextBoxColumn p1)
		|        {
		|            M_DataGridTextBoxColumn = (DataGridTextBoxColumnEx)p1;
		|            M_DataGridTextBoxColumn.M_Object = this;
		|            base.M_DataGridColumnStyle = (System.Windows.Forms.DataGridColumnStyle)M_DataGridTextBoxColumn;
		|        }
		|
		|        public osf.DataGridTextBox TextBox
		|        {
		|            get { return new DataGridTextBox((System.Windows.Forms.DataGridTextBox)M_DataGridTextBoxColumn.TextBox); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridColumnStyle" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridColumnStyle : Component
		|    {
		|        public System.Windows.Forms.DataGridColumnStyle M_DataGridColumnStyle;
		|
		|        public DataGridColumnStyle()
		|        {
		|        }
		|
		|        public DataGridColumnStyle(osf.DataGridColumnStyle p1)
		|        {
		|            M_DataGridColumnStyle = p1.M_DataGridColumnStyle;
		|            base.M_Component = M_DataGridColumnStyle;
		|        }
		|
		|        public DataGridColumnStyle(System.Windows.Forms.DataGridColumnStyle p1)
		|        {
		|            M_DataGridColumnStyle = p1;
		|            base.M_Component = M_DataGridColumnStyle;
		|        }
		|
		|        public int Alignment
		|        {
		|            get { return (int)M_DataGridColumnStyle.Alignment; }
		|            set { M_DataGridColumnStyle.Alignment = (System.Windows.Forms.HorizontalAlignment)value; }
		|        }
		|
		|        public string HeaderText
		|        {
		|            get { return M_DataGridColumnStyle.HeaderText; }
		|            set { M_DataGridColumnStyle.HeaderText = value; }
		|        }
		|
		|        public string MappingName
		|        {
		|            get { return M_DataGridColumnStyle.MappingName; }
		|            set { M_DataGridColumnStyle.MappingName = value; }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_DataGridColumnStyle.Width; }
		|            set { M_DataGridColumnStyle.Width = value; }
		|        }
		|		
		|        public bool ReadOnly
		|        {
		|            get { return M_DataGridColumnStyle.ReadOnly; }
		|            set { M_DataGridColumnStyle.ReadOnly = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridTextBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridTextBox : TextBox
		|    {
		|        public new ClDataGridTextBox dll_obj;
		|        public System.Windows.Forms.DataGridTextBox M_DataGridTextBox;
		|
		|        public DataGridTextBox()
		|        {
		|            M_DataGridTextBox = new System.Windows.Forms.DataGridTextBox();
		|            base.M_Control = M_DataGridTextBox;
		|        }
		|
		|        public DataGridTextBox(System.Windows.Forms.TextBox p1)
		|        {
		|            M_DataGridTextBox = (System.Windows.Forms.DataGridTextBox)p1;
		|            base.M_Control = M_DataGridTextBox;
		|        }
		|
		|        public DataGridTextBox(osf.DataGridTextBox p1)
		|        {
		|            M_DataGridTextBox = p1.M_DataGridTextBox;
		|            base.M_Control = M_DataGridTextBox;
		|        }
		|
		|        public DataGridTextBox(System.Windows.Forms.DataGridTextBox p1)
		|        {
		|            M_DataGridTextBox = p1;
		|            base.M_Control = M_DataGridTextBox;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "GridColumnStylesCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class GridColumnStylesCollection : CollectionBase
		|    {
		|        public ClGridColumnStylesCollection dll_obj;
		|        public System.Windows.Forms.GridColumnStylesCollection M_GridColumnStylesCollection;
		|
		|        public GridColumnStylesCollection(System.Windows.Forms.GridColumnStylesCollection p1)
		|        {
		|            M_GridColumnStylesCollection = p1;
		|            base.List = M_GridColumnStylesCollection;
		|        }
		|
		|        public int Add(osf.DataGridColumnStyle p1)
		|        {
		|            int res = Convert.ToInt32(M_GridColumnStylesCollection.Add((System.Windows.Forms.DataGridColumnStyle)p1.M_DataGridColumnStyle));
		|            System.Windows.Forms.Application.DoEvents();
		|            return res;
		|        }
		|
		|        public new osf.DataGridColumnStyle this[int p1]
		|        {
		|            get { return new DataGridColumnStyle(M_GridColumnStylesCollection[p1]); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridTableStyle" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridTableStyleEx : System.Windows.Forms.DataGridTableStyle
		|    {
		|        public osf.DataGridTableStyle M_Object;
		|    }//endClass
		|
		|    public class DataGridTableStyle : Component
		|    {
		|        public ClDataGridTableStyle dll_obj;
		|        public DataGridTableStyleEx M_DataGridTableStyle;
		|
		|        public DataGridTableStyle()
		|        {
		|            M_DataGridTableStyle = new DataGridTableStyleEx();
		|            M_DataGridTableStyle.M_Object = this;
		|            base.M_Component = M_DataGridTableStyle;
		|        }
		|		
		|        public DataGridTableStyle(osf.DataGridTableStyle p1)
		|        {
		|            M_DataGridTableStyle = p1.M_DataGridTableStyle;
		|            M_DataGridTableStyle.M_Object = this;
		|            base.M_Component = M_DataGridTableStyle;
		|        }
		|
		|        public DataGridTableStyle(System.Windows.Forms.DataGridTableStyle p1)
		|        {
		|            M_DataGridTableStyle = (DataGridTableStyleEx)p1;
		|            M_DataGridTableStyle.M_Object = this;
		|            base.M_Component = M_DataGridTableStyle;
		|        }
		|
		|        public osf.GridColumnStylesCollection GridColumnStyles
		|        {
		|            get { return new GridColumnStylesCollection(M_DataGridTableStyle.GridColumnStyles); }
		|        }
		|
		|        public string MappingName
		|        {
		|            get { return M_DataGridTableStyle.MappingName; }
		|            set { M_DataGridTableStyle.MappingName = value; }
		|        }
		|
		|        public osf.Color ForeColor
		|        {
		|            get { return new Color(M_DataGridTableStyle.ForeColor); }
		|            set { M_DataGridTableStyle.ForeColor = value.M_Color; }
		|        }
		|
		|        public osf.Color HeaderForeColor
		|        {
		|            get { return new Color(M_DataGridTableStyle.HeaderForeColor); }
		|            set { M_DataGridTableStyle.HeaderForeColor = value.M_Color; }
		|        }
		|
		|        public bool ColumnHeadersVisible
		|        {
		|            get { return M_DataGridTableStyle.ColumnHeadersVisible; }
		|            set { M_DataGridTableStyle.ColumnHeadersVisible = value; }
		|        }
		|
		|        public bool RowHeadersVisible
		|        {
		|            get { return M_DataGridTableStyle.RowHeadersVisible; }
		|            set { M_DataGridTableStyle.RowHeadersVisible = value; }
		|        }
		|
		|        public int PreferredRowHeight
		|        {
		|            get { return M_DataGridTableStyle.PreferredRowHeight; }
		|            set { M_DataGridTableStyle.PreferredRowHeight = value; }
		|        }
		|		
		|        public int PreferredColumnWidth
		|        {
		|            get { return M_DataGridTableStyle.PreferredColumnWidth; }
		|            set { M_DataGridTableStyle.PreferredColumnWidth = value; }
		|        }
		|
		|        public bool AllowSorting
		|        {
		|            get { return M_DataGridTableStyle.AllowSorting; }
		|            set { M_DataGridTableStyle.AllowSorting = value; }
		|        }
		|
		|        public osf.DataGrid DataGrid
		|        {
		|            get { return ((DataGridEx)(M_DataGridTableStyle.DataGrid)).M_Object; }
		|            set { M_DataGridTableStyle.DataGrid = value.M_DataGrid; }
		|        }
		|
		|        public bool ReadOnly
		|        {
		|            get { return M_DataGridTableStyle.ReadOnly; }
		|            set { M_DataGridTableStyle.ReadOnly = value; }
		|        }
		|
		|        public osf.Color GridLineColor
		|        {
		|            get { return new Color(M_DataGridTableStyle.GridLineColor); }
		|            set { M_DataGridTableStyle.GridLineColor = value.M_Color; }
		|        }
		|
		|        public osf.Color BackColor
		|        {
		|            get { return new Color(M_DataGridTableStyle.BackColor); }
		|            set { M_DataGridTableStyle.BackColor = value.M_Color; }
		|        }
		|
		|        public osf.Color HeaderBackColor
		|        {
		|            get { return new Color(M_DataGridTableStyle.HeaderBackColor); }
		|            set { M_DataGridTableStyle.HeaderBackColor = value.M_Color; }
		|        }
		|
		|        public osf.Color AlternatingBackColor
		|        {
		|            get { return new Color(M_DataGridTableStyle.AlternatingBackColor); }
		|            set { M_DataGridTableStyle.AlternatingBackColor = value.M_Color; }
		|        }
		|
		|        public int RowHeaderWidth
		|        {
		|            get { return M_DataGridTableStyle.RowHeaderWidth; }
		|            set { M_DataGridTableStyle.RowHeaderWidth = value; }
		|        }
		|
		|        public osf.Font HeaderFont
		|        {
		|            get { return new Font(M_DataGridTableStyle.HeaderFont); }
		|            set { M_DataGridTableStyle.HeaderFont = value.M_Font; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "GridTableStylesCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class GridTableStylesCollection : CollectionBase
		|    {
		|        public ClGridTableStylesCollection dll_obj;
		|        public System.Windows.Forms.GridTableStylesCollection M_GridTableStylesCollection;
		|
		|        public GridTableStylesCollection(System.Windows.Forms.GridTableStylesCollection p1)
		|        {
		|            M_GridTableStylesCollection = p1;
		|            base.List = M_GridTableStylesCollection;
		|        }
		|
		|        public int Add(osf.DataGridTableStyle p1)
		|        {
		|            int res = Convert.ToInt32(M_GridTableStylesCollection.Add((System.Windows.Forms.DataGridTableStyle)p1.M_DataGridTableStyle));
		|            System.Windows.Forms.Application.DoEvents();
		|            return res;
		|        }
		|
		|        public new osf.DataGridTableStyle this[int p1]
		|        {
		|            get { return ((DataGridTableStyleEx)M_GridTableStylesCollection[p1]).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGridCell" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridCell
		|    {
		|        public ClDataGridCell dll_obj;
		|        public System.Windows.Forms.DataGridCell M_DataGridCell;
		|
		|        public DataGridCell(int p1, int p2)
		|        {
		|            M_DataGridCell = new System.Windows.Forms.DataGridCell(p1, p2);
		|            M_DataGridCell.RowNumber = p1;
		|            M_DataGridCell.ColumnNumber = p2;
		|            OneScriptForms.AddToHashtable(M_DataGridCell, this);
		|        }
		|
		|        public DataGridCell(osf.DataGridCell p1)
		|        {
		|            M_DataGridCell = p1.M_DataGridCell;
		|            OneScriptForms.AddToHashtable(M_DataGridCell, this);
		|        }
		|		
		|        public DataGridCell(System.Windows.Forms.DataGridCell p1)
		|        {
		|            M_DataGridCell = p1;
		|            OneScriptForms.AddToHashtable(M_DataGridCell, this);
		|        }
		|
		|        public int ColumnNumber
		|        {
		|            get { return M_DataGridCell.ColumnNumber; }
		|            set
		|            {
		|                M_DataGridCell.ColumnNumber = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int RowNumber
		|        {
		|            get { return M_DataGridCell.RowNumber; }
		|            set
		|            {
		|                M_DataGridCell.RowNumber = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataGrid" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataGridEx : System.Windows.Forms.DataGrid
		|    {
		|        public osf.DataGrid M_Object;
		|    }//endClass
		|
		|    public class DataGrid : Control
		|    {
		|        public ClDataGrid dll_obj;
		|        public string CurrentCellChanged;
		|        public DataGridEx M_DataGrid;
		|
		|        public DataGrid()
		|        {
		|            M_DataGrid = new DataGridEx();
		|            M_DataGrid.M_Object = this;
		|            base.M_Control = M_DataGrid;
		|            M_DataGrid.CurrentCellChanged += M_DataGrid_CurrentCellChanged;
		|            CurrentCellChanged = """";
		|        }
		|
		|        public DataGrid(osf.DataGrid p1)
		|        {
		|            M_DataGrid = p1.M_DataGrid;
		|            M_DataGrid.M_Object = this;
		|            base.M_Control = M_DataGrid;
		|            M_DataGrid.CurrentCellChanged += M_DataGrid_CurrentCellChanged;
		|            CurrentCellChanged = """";
		|        }
		|
		|        public DataGrid(System.Windows.Forms.DataGrid p1)
		|        {
		|            M_DataGrid = (DataGridEx)p1;
		|            M_DataGrid.M_Object = this;
		|            base.M_Control = M_DataGrid;
		|            M_DataGrid.CurrentCellChanged += M_DataGrid_CurrentCellChanged;
		|            CurrentCellChanged = """";
		|        }
		|
		|        public bool AllowSorting
		|        {
		|            get { return M_DataGrid.AllowSorting; }
		|            set
		|            {
		|                M_DataGrid.AllowSorting = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Color BackgroundColor
		|        {
		|            get { return new Color(M_DataGrid.BackgroundColor); }
		|            set
		|            {
		|                M_DataGrid.BackgroundColor = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Color CaptionBackColor
		|        {
		|            get { return new Color(M_DataGrid.CaptionBackColor); }
		|            set
		|            {
		|                M_DataGrid.CaptionBackColor = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string CaptionText
		|        {
		|            get { return M_DataGrid.CaptionText; }
		|            set
		|            {
		|                M_DataGrid.CaptionText = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool CaptionVisible
		|        {
		|            get { return M_DataGrid.CaptionVisible; }
		|            set
		|            {
		|                M_DataGrid.CaptionVisible = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.DataGridCell CurrentCell
		|        {
		|            get { return new DataGridCell(M_DataGrid.CurrentCell); }
		|            set
		|            {
		|                M_DataGrid.CurrentCell = value.M_DataGridCell;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int CurrentRowIndex
		|        {
		|            get { return M_DataGrid.CurrentRowIndex; }
		|            set
		|            {
		|                M_DataGrid.CurrentRowIndex = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string DataMember
		|        {
		|            get { return M_DataGrid.DataMember; }
		|            set { M_DataGrid.DataMember = value; }
		|        }
		|
		|        public object DataSource
		|        {
		|            get
		|            {
		|                if (M_DataGrid.DataSource != null)
		|                {
		|                    return ((dynamic)M_DataGrid.DataSource).M_Object;
		|                }
		|                return null;
		|            }
		|            set
		|            {
		|                System.Type Type1 = ((dynamic)value).GetType();
		|                string strType1 = Type1.ToString();
		|                string str1 = strType1.Substring(strType1.LastIndexOf(""."") + 1);
		|                M_DataGrid.DataSource = Type1.GetField(""M_"" + str1).GetValue(value);
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Rectangle GetCurrentCellBounds()
		|        {
		|            return new Rectangle(M_DataGrid.GetCurrentCellBounds());
		|        }
		|
		|        public bool IsSelected(int row)
		|        {
		|            return M_DataGrid.IsSelected(row);
		|        }
		|
		|        public bool ReadOnly
		|        {
		|            get { return M_DataGrid.ReadOnly; }
		|            set
		|            {
		|                M_DataGrid.ReadOnly = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void SetDataBinding(object source, string member = null)
		|        {
		|            if (source is osf.DataView)
		|            {
		|                M_DataGrid.SetDataBinding((System.Data.DataView)((osf.DataView)source).M_DataView, member);
		|            }
		|            if (source is osf.DataTable)
		|            {
		|                M_DataGrid.SetDataBinding((System.Data.DataTable)((osf.DataTable)source).M_DataTable, member);
		|            }
		|            if (source is osf.DataSet)
		|            {
		|                M_DataGrid.SetDataBinding((System.Data.DataSet)((osf.DataSet)source).M_DataSet, member);
		|            }
		|            if (source is osf.ArrayList)
		|            {
		|                M_DataGrid.SetDataBinding((System.Collections.ArrayList)((osf.ArrayList)source).M_ArrayList, member);
		|            }
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public osf.GridTableStylesCollection TableStyles
		|        {
		|            get { return new GridTableStylesCollection(M_DataGrid.TableStyles); }
		|        }
		|
		|        public void M_DataGrid_CurrentCellChanged(object sender, System.EventArgs e)
		|        {
		|            if (CurrentCellChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = CurrentCellChanged;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public int PreferredRowHeight
		|        {
		|            get { return M_DataGrid.PreferredRowHeight; }
		|            set { M_DataGrid.PreferredRowHeight = value; }
		|        }
		|
		|        public bool EndEdit(osf.DataGridColumnStyle p1, int p2, bool p3)
		|        {
		|            return M_DataGrid.EndEdit(p1.M_DataGridColumnStyle, p2, p3);
		|        }
		|
		|        public bool BeginEdit(osf.DataGridColumnStyle p1, int p2)
		|        {
		|            return M_DataGrid.BeginEdit(p1.M_DataGridColumnStyle, p2);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataItem" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataItem
		|    {
		|        public ClDataItem dll_obj;
		|        public System.Data.DataRow M_DataRow;
		|        public object Index;
		|
		|        public DataItem()
		|        {
		|        }
		|
		|        public DataItem(System.Data.DataRow p1, object p2)
		|        {
		|            M_DataRow = p1;
		|            Index = p2;
		|        }
		|		
		|        public DataItem(osf.DataItem p1)
		|        {
		|            M_DataRow = p1.M_DataRow;
		|            Index = p1.Index;
		|        }
		|
		|        public osf.DataRow DataRow
		|        {
		|            get { return new DataRow(M_DataRow); }
		|            set { M_DataRow = value.M_DataRow; }
		|        }
		|
		|        public object Value
		|        {
		|            get
		|            {
		|                if (Index != null)
		|                {
		|                    if (Index.GetType() == typeof(int))
		|                    {
		|                        return M_DataRow[Convert.ToInt32(Index)];
		|                    }
		|                    if (Index.GetType() == typeof(string))
		|                    {
		|                        return M_DataRow[Convert.ToString(Index)];
		|                    }
		|                }
		|                return null;
		|            }
		|            set
		|            {
		|                if (Index is string)
		|                {
		|                    M_DataRow[(string)Index] = value;
		|                }
		|                else
		|                {
		|                    M_DataRow[(int)Index] = value;
		|                }
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataRowCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataRowCollection : ICollection, IEnumerable, IEnumerator
		|    {
		|        public ClDataRowCollection dll_obj;
		|        public System.Data.DataRowCollection M_DataRowCollection;
		|        private System.Collections.IEnumerator Enumerator;
		|
		|        public DataRowCollection(System.Data.DataRowCollection p1)
		|        {
		|            M_DataRowCollection = p1;
		|        }
		|
		|        public osf.DataRow Add(DataRow p1)
		|        {
		|            M_DataRowCollection.Add(p1.M_DataRow);
		|            return p1;
		|        }
		|
		|        public void Clear()
		|        {
		|            M_DataRowCollection.Clear();
		|        }
		|
		|        public osf.DataRow InsertAt(osf.DataRow p1, int index)
		|        {
		|            M_DataRowCollection.InsertAt(p1.M_DataRow, index);
		|            return p1;
		|        }
		|
		|        public void Remove(DataRow p1)
		|        {
		|            M_DataRowCollection.Remove(p1.M_DataRow);
		|        }
		|
		|        public void RemoveAt(int p1)
		|        {
		|            M_DataRowCollection.RemoveAt(p1);
		|        }
		|
		|        public osf.DataRow this[int index]
		|        {
		|            get { return new DataRow(M_DataRowCollection[index]); }
		|            set
		|            {
		|            }
		|        }
		|
		|        public void CopyTo(Array array, int index)
		|        {
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_DataRowCollection.Count; }
		|        }
		|
		|        public bool IsSynchronized
		|        {
		|            get { return M_DataRowCollection.IsSynchronized; }
		|        }
		|
		|        public object SyncRoot
		|        {
		|            get { return M_DataRowCollection.SyncRoot; }
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_DataRowCollection.GetEnumerator();
		|            return (IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return new DataRow((System.Data.DataRow)Enumerator.Current); }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataRow" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataRow
		|    {
		|        public ClDataRow dll_obj;
		|        public System.Data.DataRow M_DataRow;
		|
		|        public DataRow(osf.DataRow p1)
		|        {
		|            M_DataRow = p1.M_DataRow;
		|            OneScriptForms.AddToHashtable(M_DataRow, this);
		|        }
		|
		|        public DataRow(System.Data.DataRow p1)
		|        {
		|            M_DataRow = p1;
		|            OneScriptForms.AddToHashtable(M_DataRow, this);
		|        }
		|
		|        public void AcceptChanges()
		|        {
		|            M_DataRow.AcceptChanges();
		|        }
		|
		|        public object get_Item(object index)
		|        {
		|            return (object)new DataItem(M_DataRow, index);
		|        }
		|
		|        public void SetItem(object index, object item)
		|        {
		|            if (index is string)
		|            {
		|                M_DataRow[(string)index] = item;
		|            }
		|            else
		|            {
		|                M_DataRow[(int)index] = item;
		|            }
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|		
		|        public void BeginEdit()
		|        {
		|            M_DataRow.BeginEdit();
		|        }
		|
		|        public void EndEdit()
		|        {
		|            M_DataRow.EndEdit();
		|        }
		|
		|        public void RejectChanges()
		|        {
		|            M_DataRow.RejectChanges();
		|        }
		|		
		|        public void Delete()
		|        {
		|            M_DataRow.Delete();
		|        }
		|		
		|        public void CancelEdit()
		|        {
		|            M_DataRow.CancelEdit();
		|        }
		|
		|        public int RowState
		|        {
		|            get { return (int)M_DataRow.RowState; }
		|        }
		|		
		|        public osf.DataTable Table
		|        {
		|            get { return ((osf.DataTableEx)M_DataRow.Table).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataView" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataView : IEnumerable, IEnumerator
		|    {
		|        public ClDataView dll_obj;
		|        public System.Data.DataView M_DataView;
		|        private System.Collections.IEnumerator Enumerator;
		|
		|        public DataView()
		|        {
		|            M_DataView = new System.Data.DataView();
		|            OneScriptForms.AddToHashtable(M_DataView, this);
		|        }
		|
		|        public DataView(osf.DataView p1)
		|        {
		|            M_DataView = p1.M_DataView;
		|            OneScriptForms.AddToHashtable(M_DataView, this);
		|        }
		|
		|        public DataView(System.Data.DataView p1)
		|        {
		|            M_DataView = p1;
		|            OneScriptForms.AddToHashtable(M_DataView, this);
		|        }
		|
		|        public osf.DataRowView AddNew()
		|        {
		|            return new DataRowView(M_DataView.AddNew());
		|        }
		|
		|        public bool AllowEdit
		|        {
		|            get { return M_DataView.AllowEdit; }
		|            set
		|            {
		|                M_DataView.AllowEdit = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool AllowNew
		|        {
		|            get { return M_DataView.AllowNew; }
		|            set
		|            {
		|                M_DataView.AllowNew = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool ApplyDefaultSort
		|        {
		|            get { return M_DataView.ApplyDefaultSort; }
		|            set
		|            {
		|                M_DataView.ApplyDefaultSort = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void BeginInit()
		|        {
		|            M_DataView.BeginInit();
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_DataView.Count; }
		|        }
		|
		|        public void EndInit()
		|        {
		|            M_DataView.EndInit();
		|        }
		|
		|        public object get_Item(int index)
		|        {
		|            return new DataRowView(M_DataView[index]);
		|        }
		|
		|        public string RowFilter
		|        {
		|            get { return M_DataView.RowFilter; }
		|            set { M_DataView.RowFilter = value; }
		|        }
		|
		|        public string Sort
		|        {
		|            get { return M_DataView.Sort; }
		|            set { M_DataView.Sort = value; }
		|        }
		|
		|        public osf.DataTable Table
		|        {
		|            get { return  (DataTable)((DataTableEx)M_DataView.Table).M_Object; }
		|            set { M_DataView.Table = (System.Data.DataTable)value.M_DataTable; }
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_DataView.GetEnumerator();
		|            return (IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return (object)new DataRow((System.Data.DataRow)Enumerator.Current); }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataSet" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataSetEx : System.Data.DataSet
		|    {
		|        public osf.DataSet M_Object;
		|    }//endClass
		|		
		|    public class DataSet
		|    {
		|        public ClDataSet dll_obj;
		|        public DataSetEx M_DataSet;
		|
		|        public DataSet()
		|        {
		|            M_DataSet = new DataSetEx();
		|            M_DataSet.M_Object = this;
		|        }
		|

		|        public DataSet(osf.DataSet p1)
		|        {
		|            M_DataSet = p1.M_DataSet;
		|            M_DataSet.M_Object = this;
		|        }
		|
		|        public DataSet(System.Data.DataSet p1)
		|        {
		|            M_DataSet = (DataSetEx)p1;
		|            M_DataSet.M_Object = this;
		|        }
		|
		|        public void AcceptChanges()
		|        {
		|            M_DataSet.AcceptChanges();
		|        }
		|
		|        public string DataSetName
		|        {
		|            get { return M_DataSet.DataSetName; }
		|            set { M_DataSet.DataSetName = value; }
		|        }
		|
		|        public bool HasChanges()
		|        {
		|            return M_DataSet.HasChanges();
		|        }
		|
		|        public void RejectChanges()
		|        {
		|            M_DataSet.RejectChanges();
		|        }
		|
		|        public osf.DataTableCollection Tables
		|        {
		|            get
		|            {
		|                if (M_DataSet.Tables != null)
		|                {
		|                    return new DataTableCollection(M_DataSet.Tables);
		|                }
		|                return null;
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataTable" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataTableEx : System.Data.DataTable
		|    {
		|        public osf.DataTable M_Object;
		|    }//endClass
		|
		|    public class DataTable
		|    {
		|        public ClDataTable dll_obj;
		|        public DataTableEx M_DataTable;
		|
		|        public DataTable()
		|        {
		|            M_DataTable = new DataTableEx();
		|            M_DataTable.M_Object = this;
		|        }
		|
		|        public DataTable(string p1)
		|        {
		|            M_DataTable = new DataTableEx();
		|            M_DataTable.M_Object = this;
		|            M_DataTable.TableName = p1;
		|        }
		|
		|        public DataTable(osf.DataTable p1)
		|        {
		|            M_DataTable = p1.M_DataTable;
		|            M_DataTable.M_Object = this;
		|        }
		|
		|        public DataTable(System.Data.DataTable p1)
		|        {
		|            M_DataTable = (DataTableEx)p1;
		|            M_DataTable.M_Object = this;
		|        }
		|
		|        public void AcceptChanges()
		|        {
		|            M_DataTable.AcceptChanges();
		|        }
		|
		|        public osf.DataTable Clone()
		|        {
		|            return new DataTable(M_DataTable.Clone());
		|        }
		|
		|        public osf.DataColumn get_Column(object p1)
		|        {
		|            if (p1 is int)
		|            {
		|                return ((DataColumnEx)(M_DataTable.Columns[Convert.ToInt32(p1)])).M_Object;
		|            }
		|            else
		|            {
		|                return ((DataColumnEx)(M_DataTable.Columns[Convert.ToString(p1)])).M_Object;
		|            }
		|        }
		|
		|        public osf.DataColumnCollection Columns
		|        {
		|            get { return new DataColumnCollection(M_DataTable.Columns); }
		|        }
		|
		|        public osf.DataTable Copy()
		|        {
		|            return new DataTable(M_DataTable.Copy());
		|        }
		|
		|        public osf.DataSet DataSet
		|        {
		|            get { return ((DataSetEx)M_DataTable.DataSet).M_Object; }
		|        }
		|
		|        public osf.DataView DefaultView
		|        {
		|            get { return new DataView(M_DataTable.DefaultView); }
		|        }
		|
		|        public osf.DataRow NewRow()
		|        {
		|            return new DataRow(M_DataTable.NewRow());
		|        }
		|
		|        public void RejectChanges()
		|        {
		|            M_DataTable.RejectChanges();
		|        }
		|
		|        public osf.DataRowCollection Rows
		|        {
		|            get { return new DataRowCollection(M_DataTable.Rows); }
		|        }
		|
		|        public object[] Select(string filter)
		|        {
		|            System.Data.DataRow[] dataRowArray = M_DataTable.Select(filter);
		|            int num1 = dataRowArray.Length;
		|            object[] objArray = new object[num1];
		|            for (int i = 0; i < dataRowArray.Length; i++)
		|            {
		|                objArray[i] = (object)new DataRow(dataRowArray[i]);
		|            }
		|            return objArray;
		|        }
		|
		|        public void Sort(string expression)
		|        {
		|            if (M_DataTable.Rows.Count > 0)
		|            {
		|                System.Data.DataTable DataTable1 = M_DataTable.Copy();
		|                M_DataTable.Clear();
		|                System.Data.DataRow[] DataRowArray1 = DataTable1.Select((string)null, expression);
		|                for (int i = 0; i < DataRowArray1.Length; i++)
		|                {
		|                    M_DataTable.ImportRow(DataRowArray1[i]);
		|                }
		|            }
		|        }
		|
		|        public string TableName
		|        {
		|            get { return M_DataTable.TableName; }
		|            set { M_DataTable.TableName = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataTableCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataTableCollection : ICollection, IEnumerable, IEnumerator
		|    {
		|        public ClDataTableCollection dll_obj;
		|        public System.Data.DataTableCollection M_DataTableCollection;
		|        private System.Collections.IEnumerator Enumerator;
		|
		|        public DataTableCollection(System.Data.DataTableCollection p1)
		|        {
		|            M_DataTableCollection = p1;
		|        }
		|
		|        public osf.DataTable Add(osf.DataTable p1 = null)
		|        {
		|            if (p1 == null)
		|            {
		|                return new DataTable(M_DataTableCollection.Add());
		|            }
		|            M_DataTableCollection.Add(p1.M_DataTable);
		|            return p1;
		|        }
		|
		|        public void Remove(object p1)
		|        {
		|            if (p1 is DataTable)
		|            {
		|                M_DataTableCollection.Remove(((DataTable)p1).M_DataTable);
		|            }
		|            else
		|            {
		|                M_DataTableCollection.Remove(Convert.ToString(p1));
		|            }
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void RemoveAt(int p1)
		|        {
		|            M_DataTableCollection.RemoveAt(p1);
		|        }
		|
		|        public osf.DataTable this[object p1]
		|        {
		|            get
		|            {
		|                if (p1 is int)
		|                {
		|                    return ((DataTableEx)M_DataTableCollection[(int)p1]).M_Object;
		|                }
		|                return ((DataTableEx)M_DataTableCollection[(string)p1]).M_Object;
		|            }
		|        }
		|
		|        public void CopyTo(Array array, int index)
		|        {
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_DataTableCollection.Count; }
		|        }
		|
		|        public bool IsSynchronized
		|        {
		|            get { return M_DataTableCollection.IsSynchronized; }
		|        }
		|
		|        public object SyncRoot
		|        {
		|            get { return M_DataTableCollection.SyncRoot; }
		|        }
		|
		|        public IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_DataTableCollection.GetEnumerator();
		|            return (IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return ((DataTableEx)(System.Data.DataTable)Enumerator.Current).M_Object; }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataColumnCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataColumnCollection : ICollection, IEnumerable, IEnumerator
		|    {
		|        public ClDataColumnCollection dll_obj;
		|        public System.Data.DataColumnCollection M_DataColumnCollection;
		|        public System.Collections.IEnumerator Enumerator;
		|
		|        public DataColumnCollection(System.Data.DataColumnCollection p1)
		|        {
		|            M_DataColumnCollection = p1;
		|        }
		|
		|        public osf.DataColumn AddItem(string p1)
		|        {
		|            DataColumn DataColumn1 = new DataColumn(p1);
		|            M_DataColumnCollection.Add(DataColumn1.M_DataColumn);
		|            System.Windows.Forms.Application.DoEvents();
		|            return DataColumn1;
		|        }
		|
		|        public osf.DataColumn Add(osf.DataColumn p1)
		|        {
		|            M_DataColumnCollection.Add(p1.M_DataColumn);
		|            System.Windows.Forms.Application.DoEvents();
		|            return p1;
		|        }
		|
		|        public void Clear()
		|        {
		|            M_DataColumnCollection.Clear();
		|        }
		|
		|        public void Remove(osf.DataColumn p1)
		|        {
		|            M_DataColumnCollection.Remove(p1.M_DataColumn);
		|        }
		|
		|        public void RemoveAt(int index)
		|        {
		|            M_DataColumnCollection.RemoveAt(index);
		|        }
		|
		|        public osf.DataColumn this[object index]
		|        {
		|            get
		|            {
		|                if (index is string)
		|                {
		|                    return new osf.DataColumn(M_DataColumnCollection[Convert.ToString(index)]);
		|                }
		|                return new osf.DataColumn(M_DataColumnCollection[Convert.ToInt32(index)]);
		|            }
		|            set
		|            {
		|            }
		|        }
		|
		|        public void CopyTo(Array array, int index)
		|        {
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_DataColumnCollection.Count; }
		|        }
		|
		|        public bool IsSynchronized
		|        {
		|            get { return M_DataColumnCollection.IsSynchronized; }
		|        }
		|
		|        public object SyncRoot
		|        {
		|            get { return M_DataColumnCollection.SyncRoot; }
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_DataColumnCollection.GetEnumerator();
		|            return (IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return (object)((DataColumnEx)((System.Data.DataColumn)Enumerator.Current)).M_Object; }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataColumn" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataColumnEx : System.Data.DataColumn
		|    {
		|        public osf.DataColumn M_Object;
		|
		|        public DataColumnEx()
		|        {
		|        }
		|
		|        public DataColumnEx(string p1) : base(p1)
		|        {
		|        }
		|
		|        public DataColumnEx(string p1, System.Type p2) : base(p1, p2)
		|        {
		|        }
		|    }//endClass
		|
		|    public class DataColumn
		|    {
		|        public ClDataColumn dll_obj;
		|        public DataColumnEx M_DataColumn;
		|
		|        public DataColumn()
		|        {
		|            M_DataColumn = new DataColumnEx();
		|            M_DataColumn.M_Object = this;
		|        }
		|        public DataColumn(string p1)
		|        {
		|            M_DataColumn = new DataColumnEx(p1);
		|            M_DataColumn.M_Object = this;
		|        }
		|        public DataColumn(string p1, System.Type p2)
		|        {
		|            M_DataColumn = new DataColumnEx(p1, p2);
		|            M_DataColumn.M_Object = this;
		|        }
		|
		|        public DataColumn(osf.DataColumn p1)
		|        {
		|            M_DataColumn = p1.M_DataColumn;
		|            M_DataColumn.M_Object = this;
		|        }
		|
		|        public DataColumn(System.Data.DataColumn p1)
		|        {
		|            M_DataColumn = (DataColumnEx)p1;
		|            M_DataColumn.M_Object = this;
		|        }
		|
		|        public bool AutoIncrement
		|        {
		|            get { return M_DataColumn.AutoIncrement; }
		|            set { M_DataColumn.AutoIncrement = value; }
		|        }
		|
		|        public string ColumnName
		|        {
		|            get { return M_DataColumn.ColumnName; }
		|            set { M_DataColumn.ColumnName = value; }
		|        }
		|
		|        public string Caption
		|        {
		|            get { return M_DataColumn.Caption; }
		|            set { M_DataColumn.Caption = value; }
		|        }
		|
		|        public System.Type DataType
		|        {
		|            get { return M_DataColumn.DataType; }
		|            set { M_DataColumn.DataType = value; }
		|        }
		|
		|        public object DefaultValue
		|        {
		|            get { return M_DataColumn.DefaultValue; }
		|            set { M_DataColumn.DefaultValue = value; }
		|        }
		|
		|        public int Ordinal
		|        {
		|            get { return M_DataColumn.Ordinal; }
		|        }
		|
		|        public bool ReadOnly
		|        {
		|            get { return M_DataColumn.ReadOnly; }
		|            set { M_DataColumn.ReadOnly = value; }
		|        }
		|
		|        public osf.DataTable Table
		|        {
		|            get { return  (DataTable)((DataTableEx)M_DataColumn.Table).M_Object; }
		|        }
		|		
		|        public int AutoIncrementSeed
		|        {
		|            get { return Convert.ToInt32(M_DataColumn.AutoIncrementSeed); }
		|            set { M_DataColumn.AutoIncrementSeed = value; }
		|        }
		|
		|        public int AutoIncrementStep
		|        {
		|            get { return Convert.ToInt32(M_DataColumn.AutoIncrementStep); }
		|            set { M_DataColumn.AutoIncrementStep = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Link" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LinkEx : System.Windows.Forms.LinkLabel.Link
		|    {
		|        public osf.Link M_Object;
		|    }//endClass
		|
		|    public class Link
		|    {
		|        public ClLink dll_obj;
		|        public LinkEx M_Link;
		|
		|        public Link()
		|        {
		|            M_Link = new LinkEx();
		|            M_Link.M_Object = this;
		|        }
		|		
		|        public Link(osf.Link p1)
		|        {
		|            M_Link = p1.M_Link;
		|            M_Link.M_Object = this;
		|        }
		|
		|        public Link(System.Windows.Forms.LinkLabel.Link p1)
		|        {
		|            M_Link = (LinkEx)p1;
		|            M_Link.M_Object = this;
		|        }
		|
		|        public int Length
		|        {
		|            get { return M_Link.Length; }
		|            set { M_Link.Length = value; }
		|        }
		|
		|        public bool Enabled
		|        {
		|            get { return M_Link.Enabled; }
		|            set { M_Link.Enabled = value; }
		|        }
		|
		|        public string Name
		|        {
		|            get { return M_Link.Name; }
		|            set { M_Link.Name = value; }
		|        }
		|
		|        public int Start
		|        {
		|            get { return M_Link.Start; }
		|            set { M_Link.Start = value; }
		|        }
		|
		|        public string Description
		|        {
		|            get { return M_Link.Description; }
		|            set { M_Link.Description = value; }
		|        }
		|
		|        public bool Visited
		|        {
		|            get { return M_Link.Visited; }
		|            set { M_Link.Visited = value; }
		|        }
		|
		|        public object LinkData
		|        {
		|            get { return M_Link.LinkData; }
		|            set { M_Link.LinkData = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "LinkArea" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LinkArea
		|    {
		|        public ClLinkArea dll_obj;
		|        public System.Windows.Forms.LinkArea M_LinkArea;
		|
		|        public LinkArea(int p1, int p2)
		|        {
		|            M_LinkArea = new System.Windows.Forms.LinkArea(p1, p2);
		|            OneScriptForms.AddToHashtable(M_LinkArea, this);
		|        }
		|		
		|        public LinkArea(osf.LinkArea p1)
		|        {
		|            M_LinkArea = p1.M_LinkArea;
		|            OneScriptForms.AddToHashtable(M_LinkArea, this);
		|        }
		|
		|        public LinkArea(System.Windows.Forms.LinkArea p1)
		|        {
		|            M_LinkArea = p1;
		|            OneScriptForms.AddToHashtable(M_LinkArea, this);
		|        }
		|
		|        public int Length
		|        {
		|            get { return M_LinkArea.Length; }
		|            set { M_LinkArea.Length = value; }
		|        }
		|
		|        public int Start
		|        {
		|            get { return M_LinkArea.Start; }
		|            set { M_LinkArea.Start = value; }
		|        }
		|
		|        public bool IsEmpty
		|        {
		|            get { return M_LinkArea.IsEmpty; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Label" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LabelEx : System.Windows.Forms.Label
		|    {
		|        public osf.Label M_Object;
		|    }//endClass
		|
		|    public class Label : Control
		|    {
		|        public ClLabel dll_obj;
		|        public LabelEx M_Label;
		|        private osf.Bitmap image;
		|
		|        public Label()
		|        {
		|            M_Label = new LabelEx();
		|            M_Label.M_Object = this;
		|            base.M_Control = M_Label;
		|        }
		|
		|        public Label(osf.Label p1)
		|        {
		|            M_Label = p1.M_Label;
		|            M_Label.M_Object = this;
		|            base.M_Control = M_Label;
		|        }
		|
		|        public Label(System.Windows.Forms.Label p1)
		|        {
		|            M_Label = (LabelEx)p1;
		|            M_Label.M_Object = this;
		|            base.M_Control = M_Label;
		|        }
		|
		|        public bool AutoSize
		|        {
		|            get { return M_Label.AutoSize; }
		|            set
		|            {
		|                M_Label.AutoSize = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_Label.BorderStyle; }
		|            set
		|            {
		|                M_Label.BorderStyle = (System.Windows.Forms.BorderStyle)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Bitmap Image
		|        {
		|            get { return image; }
		|            set
		|            {
		|                image = value;
		|                M_Label.Image = value.M_Image;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int ImageAlign
		|        {
		|            get { return (int)M_Label.ImageAlign; }
		|            set
		|            {
		|                M_Label.ImageAlign = (System.Drawing.ContentAlignment)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_Label.ImageIndex; }
		|            set
		|            {
		|                M_Label.ImageIndex = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_Label.ImageList); }
		|            set
		|            {
		|                M_Label.ImageList = value.M_ImageList;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int PreferredHeight
		|        {
		|            get { return M_Label.PreferredHeight; }
		|        }
		|
		|        public int PreferredWidth
		|        {
		|            get { return M_Label.PreferredWidth; }
		|        }
		|
		|        public int TextAlign
		|        {
		|            get { return (int)M_Label.TextAlign; }
		|            set
		|            {
		|                M_Label.TextAlign = (System.Drawing.ContentAlignment)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "LinkLabel" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LinkLabelEx : System.Windows.Forms.LinkLabel
		|    {
		|        public osf.LinkLabel M_Object;
		|    }//endClass
		|
		|    public class LinkLabel : Label
		|    {
		|        public new ClLinkLabel dll_obj;
		|        public LinkLabelEx M_LinkLabel;
		|        public string LinkClicked;
		|        private osf.Bitmap image;
		|
		|        public LinkLabel()
		|        {
		|            M_LinkLabel = new LinkLabelEx();
		|            M_LinkLabel.M_Object = this;
		|            base.M_Control = M_LinkLabel;
		|            M_LinkLabel.LinkClicked += M_LinkLabel_LinkClicked;
		|            LinkClicked = """";
		|        }
		|
		|        public LinkLabel(osf.LinkLabel p1)
		|        {
		|            M_LinkLabel = p1.M_LinkLabel;
		|            M_LinkLabel.M_Object = this;
		|            base.M_Control = M_LinkLabel;
		|            M_LinkLabel.LinkClicked += M_LinkLabel_LinkClicked;
		|            LinkClicked = """";
		|        }
		|
		|        public LinkLabel(System.Windows.Forms.LinkLabel p1)
		|        {
		|            M_LinkLabel = (LinkLabelEx)p1;
		|            M_LinkLabel.M_Object = this;
		|            base.M_Control = M_LinkLabel;
		|            M_LinkLabel.LinkClicked += M_LinkLabel_LinkClicked;
		|            LinkClicked = """";
		|        }
		|
		|        public osf.Color VisitedLinkColor
		|        {
		|            get { return new Color(M_LinkLabel.VisitedLinkColor); }
		|            set { M_LinkLabel.VisitedLinkColor = value.M_Color; }
		|        }
		|
		|        public osf.Color LinkColor
		|        {
		|            get { return new Color(M_LinkLabel.LinkColor); }
		|            set { M_LinkLabel.LinkColor = value.M_Color; }
		|        }
		|
		|        public bool LinkVisited
		|        {
		|            get { return M_LinkLabel.LinkVisited; }
		|            set { M_LinkLabel.LinkVisited = value; }
		|        }
		|
		|        public osf.Color ActiveLinkColor
		|        {
		|            get { return new Color(M_LinkLabel.ActiveLinkColor); }
		|            set { M_LinkLabel.ActiveLinkColor = value.M_Color; }
		|        }
		|
		|
		|        public osf.LinkArea LinkArea
		|        {
		|            get { return new LinkArea(M_LinkLabel.LinkArea); }
		|            set { M_LinkLabel.LinkArea = value.M_LinkArea; }
		|        }
		|
		|        public osf.LinkCollection Links
		|        {
		|            get { return new LinkCollection(M_LinkLabel.Links); }
		|        }
		|
		|        public int LinkBehavior
		|        {
		|            get { return (int)M_LinkLabel.LinkBehavior; }
		|            set { M_LinkLabel.LinkBehavior = (System.Windows.Forms.LinkBehavior)value; }
		|        }
		|
		|        public new bool AutoSize
		|        {
		|            get { return M_LinkLabel.AutoSize; }
		|            set
		|            {
		|                M_LinkLabel.AutoSize = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new int ImageAlign
		|        {
		|            get { return (int)M_LinkLabel.ImageAlign; }
		|            set
		|            {
		|                M_LinkLabel.ImageAlign = (System.Drawing.ContentAlignment)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new int TextAlign
		|        {
		|            get { return (int)M_LinkLabel.TextAlign; }
		|            set
		|            {
		|                M_LinkLabel.TextAlign = (System.Drawing.ContentAlignment)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new osf.Bitmap Image
		|        {
		|            get { return image; }
		|            set
		|            {
		|                image = value;
		|                M_LinkLabel.Image = value.M_Image;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_LinkLabel.ImageList); }
		|            set
		|            {
		|                M_LinkLabel.ImageList = value.M_ImageList;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new int ImageIndex
		|        {
		|            get { return M_LinkLabel.ImageIndex; }
		|            set
		|            {
		|                M_LinkLabel.ImageIndex = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new int PreferredHeight
		|        {
		|            get { return M_LinkLabel.PreferredHeight; }
		|        }
		|
		|        public new int PreferredWidth
		|        {
		|            get { return M_LinkLabel.PreferredWidth; }
		|        }
		|
		|        public new int BorderStyle
		|        {
		|            get { return (int)M_LinkLabel.BorderStyle; }
		|            set
		|            {
		|                M_LinkLabel.BorderStyle = (System.Windows.Forms.BorderStyle)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|		
		|        private void M_LinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		|        {
		|            if (LinkClicked.Length > 0)
		|            {
		|                LinkLabelLinkClickedEventArgs LinkLabelLinkClickedEventArgs1 = new LinkLabelLinkClickedEventArgs();
		|                LinkLabelLinkClickedEventArgs1.EventString = LinkClicked;
		|                LinkLabelLinkClickedEventArgs1.Sender = (object)this;
		|                LinkLabelLinkClickedEventArgs1.Button = (int)e.Button;
		|                LinkLabelLinkClickedEventArgs1.Link = ((LinkEx)e.Link).M_Object;
		|                OneScriptForms.EventQueue.Add(LinkLabelLinkClickedEventArgs1);
		|                ClLinkLabelLinkClickedEventArgs ClLinkLabelLinkClickedEventArgs1 = new ClLinkLabelLinkClickedEventArgs(LinkLabelLinkClickedEventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "LinkCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LinkCollection
		|    {
		|        public ClLinkCollection dll_obj;
		|        public System.Windows.Forms.LinkLabel.LinkCollection M_LinkCollection;
		|
		|        public LinkCollection(System.Windows.Forms.LinkLabel p1)
		|        {
		|            M_LinkCollection = p1.Links;
		|        }
		|		
		|        public LinkCollection(System.Windows.Forms.LinkLabel.LinkCollection p1)
		|        {
		|            M_LinkCollection = p1;
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_LinkCollection.Count; }
		|        }
		|
		|        public bool LinksAdded
		|        {
		|            get { return M_LinkCollection.LinksAdded; }
		|        }
		|
		|        public bool IsReadOnly
		|        {
		|            get { return M_LinkCollection.IsReadOnly; }
		|        }
		|
		|
		|        public int Add(osf.Link p1)
		|        {
		|            return M_LinkCollection.Add((System.Windows.Forms.LinkLabel.Link)p1.M_Link);
		|        }
		|
		|        public void Clear()
		|        {
		|            M_LinkCollection.Clear();
		|        }
		|
		|        public void Remove(osf.Link p1)
		|        {
		|            M_LinkCollection.Remove((System.Windows.Forms.LinkLabel.Link)p1.M_Link);
		|        }
		|
		|        public void RemoveAt(int p1)
		|        {
		|            M_LinkCollection.RemoveAt(p1);
		|        }
		|
		|        public virtual object this[int index]
		|        {
		|            get { return M_LinkCollection[index]; }
		|            set { M_LinkCollection[index] = (System.Windows.Forms.LinkLabel.Link)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Encoding" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Encoding
		|    {
		|        public ClEncoding dll_obj;
		|        public System.Text.Encoding M_Encoding;
		|
		|        public Encoding()
		|        {
		|            M_Encoding = System.Text.Encoding.Default;
		|        }
		|
		|        private Encoding(osf.Encoding p1)
		|        {
		|            M_Encoding = p1.M_Encoding;
		|        }
		|
		|        private Encoding(System.Text.Encoding p1)
		|        {
		|            M_Encoding = p1;
		|        }
		|
		|        public osf.Encoding GetEncoding(int p1)
		|        {
		|            return new Encoding(System.Text.Encoding.GetEncoding(p1));
		|        }
		|
		|        public int GetByteCount(string sText)
		|        {
		|            return M_Encoding.GetByteCount(sText);
		|        }
		|
		|        public osf.Encoding ByDefault
		|        {
		|            get { return new Encoding(System.Text.Encoding.Default); }
		|        }
		|
		|        public osf.Encoding Unicode
		|        {
		|            get { return new Encoding(System.Text.Encoding.Unicode); }
		|        }
		|
		|        public osf.Encoding UTF8
		|        {
		|            get { return new Encoding(System.Text.Encoding.UTF8); }
		|        }
		|
		|        public osf.Encoding UTF7
		|        {
		|            get { return new Encoding(System.Text.Encoding.UTF7); }
		|        }
		|
		|        public osf.Encoding ASCII
		|        {
		|            get { return new Encoding(System.Text.Encoding.ASCII); }
		|        }
		|
		|        public osf.Encoding BigEndianUnicode
		|        {
		|            get { return new Encoding(System.Text.Encoding.BigEndianUnicode); }
		|        }
		|
		|        public int WindowsCodePage
		|        {
		|            get { return M_Encoding.WindowsCodePage; }
		|        }
		|
		|        public string BodyName
		|        {
		|            get { return M_Encoding.BodyName; }
		|        }
		|
		|        public string HeaderName
		|        {
		|            get { return M_Encoding.HeaderName; }
		|        }
		|
		|        public string EncodingName
		|        {
		|            get { return M_Encoding.EncodingName; }
		|        }
		|
		|        public string WebName
		|        {
		|            get { return M_Encoding.WebName; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ToolBarButton" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ToolBarButtonEx : System.Windows.Forms.ToolBarButton
		|    {
		|        public osf.ToolBarButton M_Object;
		|    }//endClass
		|
		|    public class ToolBarButton
		|    {
		|        public ClToolBarButton dll_obj;
		|        public ToolBarButtonEx M_ToolBarButton;
		|
		|        public ToolBarButton(string text = null)
		|        {
		|            M_ToolBarButton = new ToolBarButtonEx();
		|            M_ToolBarButton.M_Object = this;
		|            M_ToolBarButton.Text = text;
		|        }
		|
		|        public ToolBarButton(osf.ToolBarButton p1)
		|        {
		|            M_ToolBarButton = p1.M_ToolBarButton;
		|            M_ToolBarButton.M_Object = this;
		|        }
		|
		|        public ToolBarButton(System.Windows.Forms.ToolBarButton p1)
		|        {
		|            M_ToolBarButton = (ToolBarButtonEx)p1;
		|            M_ToolBarButton.M_Object = this;
		|        }
		|
		|        public osf.ContextMenu DropDownMenu
		|        {
		|            get { return (ContextMenu)((ContextMenuEx)M_ToolBarButton.DropDownMenu).M_Object; }
		|            set { M_ToolBarButton.DropDownMenu = value.M_ContextMenu; }
		|        }
		|
		|        public bool Enabled
		|        {
		|            get { return M_ToolBarButton.Enabled; }
		|            set
		|            {
		|                M_ToolBarButton.Enabled = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_ToolBarButton.ImageIndex; }
		|            set { M_ToolBarButton.ImageIndex = value; }
		|        }
		|
		|        public bool ParitalPush
		|        {
		|            get { return M_ToolBarButton.PartialPush; }
		|            set { M_ToolBarButton.PartialPush = value; }
		|        }
		|
		|        public bool Pushed
		|        {
		|            get { return M_ToolBarButton.Pushed; }
		|            set { M_ToolBarButton.Pushed = value; }
		|        }
		|
		|        public osf.Rectangle Rectangle
		|        {
		|            get { return new Rectangle(M_ToolBarButton.Rectangle); }
		|        }
		|
		|        public int Style
		|        {
		|            get { return (int)M_ToolBarButton.Style; }
		|            set { M_ToolBarButton.Style = (System.Windows.Forms.ToolBarButtonStyle)value; }
		|        }
		|
		|        public object Tag
		|        {
		|            get { return M_ToolBarButton.Tag; }
		|            set { M_ToolBarButton.Tag = value; }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_ToolBarButton.Text; }
		|            set { M_ToolBarButton.Text = value; }
		|        }
		|
		|        public string ToolTipText
		|        {
		|            get { return M_ToolBarButton.ToolTipText; }
		|            set { M_ToolBarButton.ToolTipText = value; }
		|        }
		|
		|        public bool Visible
		|        {
		|            get { return M_ToolBarButton.Visible; }
		|            set { M_ToolBarButton.Visible = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ToolBar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ToolBarEx : System.Windows.Forms.ToolBar
		|    {
		|        public osf.ToolBar M_Object;
		|    }//endClass
		|
		|    public class ToolBar : Control
		|    {
		|        public ClToolBar dll_obj;
		|        private ToolBarEx m_ToolBar;
		|        public string ButtonClick;
		|
		|        public ToolBarEx M_ToolBar
		|        {
		|            get { return m_ToolBar; }
		|            set
		|            {
		|                m_ToolBar = value;
		|                m_ToolBar.ButtonClick += M_ToolBar_ButtonClick;
		|            }
		|        }
		|
		|        public ToolBar()
		|        {
		|            M_ToolBar = new ToolBarEx();
		|            M_ToolBar.M_Object = this;
		|            base.M_Control = M_ToolBar;
		|            ButtonClick = """";
		|        }
		|		
		|        public ToolBar(osf.ToolBar p1)
		|        {
		|            M_ToolBar = p1.M_ToolBar;
		|            M_ToolBar.M_Object = this;
		|            base.M_Control = M_ToolBar;
		|            ButtonClick = """";
		|        }
		|
		|        public ToolBar(System.Windows.Forms.ToolBar p1)
		|        {
		|            M_ToolBar = (ToolBarEx)p1;
		|            M_ToolBar.M_Object = this;
		|            base.M_Control = M_ToolBar;
		|            ButtonClick = """";
		|        }
		|
		|        public void M_ToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		|        {
		|            if (ButtonClick.Length > 0)
		|            {
		|                ToolBarButtonClickEventArgs ToolBarButtonClickEventArgs1 = new ToolBarButtonClickEventArgs();
		|                ToolBarButtonClickEventArgs1.EventString = ButtonClick;
		|                ToolBarButtonClickEventArgs1.Sender = (object)this;
		|                ToolBarButtonClickEventArgs1.Button = ((ToolBarButtonEx)e.Button).M_Object;
		|                OneScriptForms.EventQueue.Add(ToolBarButtonClickEventArgs1);
		|                ClToolBarButtonClickEventArgs ClToolBarButtonClickEventArgs1 = new ClToolBarButtonClickEventArgs(ToolBarButtonClickEventArgs1);
		|            }
		|        }
		|
		|        public int Appearance
		|        {
		|            get { return (int)M_ToolBar.Appearance; }
		|            set { M_ToolBar.Appearance = (System.Windows.Forms.ToolBarAppearance)value; }
		|        }
		|
		|        public bool AutoSize
		|        {
		|            get { return M_ToolBar.AutoSize; }
		|            set { M_ToolBar.AutoSize = value; }
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_ToolBar.BorderStyle; }
		|            set { M_ToolBar.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
		|        }
		|
		|        public osf.ToolBarButtonCollection Buttons
		|        {
		|            get { return new ToolBarButtonCollection(M_ToolBar.Buttons); }
		|        }
		|
		|        public osf.Size ButtonSize
		|        {
		|            get { return new Size(M_ToolBar.ButtonSize); }
		|            set { M_ToolBar.ButtonSize = value.M_Size; }
		|        }
		|
		|        public bool Divider
		|        {
		|            get { return M_ToolBar.Divider; }
		|            set { M_ToolBar.Divider = value; }
		|        }
		|
		|        public bool DropDownArrows
		|        {
		|            get { return M_ToolBar.DropDownArrows; }
		|            set { M_ToolBar.DropDownArrows = value; }
		|        }
		|
		|        public osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_ToolBar.ImageList); }
		|            set { M_ToolBar.ImageList = value.M_ImageList; }
		|        }
		|
		|        public osf.Size ImageSize
		|        {
		|            get { return new Size(M_ToolBar.ImageSize); }
		|        }
		|
		|        public bool ShowToolTips
		|        {
		|            get { return M_ToolBar.ShowToolTips; }
		|            set { M_ToolBar.ShowToolTips = value; }
		|        }
		|
		|        public int TextAlign
		|        {
		|            get { return (int)M_ToolBar.TextAlign; }
		|            set { M_ToolBar.TextAlign = (System.Windows.Forms.ToolBarTextAlign)value; }
		|        }
		|
		|        public bool Wrappable
		|        {
		|            get { return M_ToolBar.Wrappable; }
		|            set { M_ToolBar.Wrappable = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ToolBarButtonCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ToolBarButtonCollection : CollectionBase
		|    {
		|        public ClToolBarButtonCollection dll_obj;
		|        private System.Windows.Forms.ToolBar.ToolBarButtonCollection M_ToolBarButtonCollection;
		|
		|        public ToolBarButtonCollection()
		|        {
		|        }
		|
		|        public ToolBarButtonCollection(System.Windows.Forms.ToolBar.ToolBarButtonCollection p1)
		|        {
		|            M_ToolBarButtonCollection = p1;
		|            base.List = M_ToolBarButtonCollection;
		|        }
		|
		|        public osf.ToolBarButton Add(ToolBarButton ToolBarButton)
		|        {
		|            M_ToolBarButtonCollection.Add(ToolBarButton.M_ToolBarButton);
		|            return ToolBarButton;
		|        }
		|
		|        public osf.ToolBarButton Insert(int index, ToolBarButton ToolBarButton)
		|        {
		|            M_ToolBarButtonCollection.Insert(index, ToolBarButton.M_ToolBarButton);
		|            return ToolBarButton;
		|        }
		|
		|        public void Remove(ToolBarButton ToolBarButton)
		|        {
		|            M_ToolBarButtonCollection.Remove(ToolBarButton.M_ToolBarButton);
		|        }
		|
		|        public new osf.ToolBarButton this[int Index]
		|        {
		|            get { return ((ToolBarButtonEx)M_ToolBarButtonCollection[Index]).M_Object; }
		|            set
		|            {
		|            }
		|        }
		|
		|        public override object Current
		|        {
		|            get { return (object)((ToolBarButtonEx)((System.Windows.Forms.ToolBarButton)Enumerator.Current)).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ProgressBar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class HProgressBarEx : System.Windows.Forms.ProgressBar
		|    {
		|        public object M_Object;
		|    }//endClass
		|
		|    public class VProgressBarEx : System.Windows.Forms.ProgressBar
		|    {
		|        public object M_Object;
		|
		|        protected override System.Windows.Forms.CreateParams CreateParams
		|        {
		|            get
		|            {
		|                System.Windows.Forms.CreateParams cp = base.CreateParams;
		|                cp.Style |= 0x04;
		|                return cp;
		|            }
		|        }
		|    }//endClass
		|
		|    public class ProgressBar : Control
		|    {
		|        public ClProgressBar dll_obj;
		|        public HProgressBarEx M_ProgressBarH;
		|        public VProgressBarEx M_ProgressBarV;
		|        private bool HV;
		|
		|        public ProgressBar(bool p1)
		|        {
		|            HV = p1;
		|            if (p1)
		|            {
		|                M_ProgressBarV = new VProgressBarEx();
		|                M_ProgressBarV.M_Object = M_ProgressBarV;
		|                base.M_Control = M_ProgressBarV;
		|            }
		|            else
		|            {
		|                M_ProgressBarH = new HProgressBarEx();
		|                M_ProgressBarH.M_Object = M_ProgressBarH;
		|                base.M_Control = M_ProgressBarH;
		|            }
		|        }
		|
		|        public int Maximum
		|        {
		|            get
		|            {
		|                if (HV)
		|                {
		|                    return M_ProgressBarV.Maximum;
		|                }
		|                else
		|                {
		|                    return M_ProgressBarH.Maximum;
		|                }
		|            }
		|            set
		|            {
		|                if (HV)
		|                {
		|                    M_ProgressBarV.Maximum = value;
		|                }
		|                else
		|                {
		|                    M_ProgressBarH.Maximum = value;
		|                }
		|            }
		|        }
		|
		|        public int Minimum
		|        {
		|            get
		|            {
		|                if (HV)
		|                {
		|                    return M_ProgressBarV.Minimum;
		|                }
		|                else
		|                {
		|                    return M_ProgressBarH.Minimum;
		|                }
		|            }
		|            set
		|            {
		|                if (HV)
		|                {
		|                    M_ProgressBarV.Minimum = value;
		|                }
		|                else
		|                {
		|                    M_ProgressBarH.Minimum = value;
		|                }
		|            }
		|        }
		|
		|        public int Value
		|        {
		|            get
		|            {
		|                if (HV)
		|                {
		|                    return M_ProgressBarV.Value;
		|                }
		|                else
		|                {
		|                    return M_ProgressBarH.Value;
		|                }
		|            }
		|            set
		|            {
		|                if (HV)
		|                {
		|                    M_ProgressBarV.Value = value;
		|                }
		|                else
		|                {
		|                    M_ProgressBarH.Value = value;
		|                }
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MessageBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MessageBox
		|    {
		|        public ClMessageBox dll_obj;
		|        public string Text;
		|        public string Title;
		|        public int Buttons;
		|        public int Icon;
		|
		|        public MessageBox()
		|        {
		|            Text = null;
		|            Title = null;
		|            Buttons = (int)System.Windows.Forms.MessageBoxButtons.OK;
		|            Icon = (int)System.Windows.Forms.MessageBoxIcon.None;
		|        }
		|
		|        public int Show(string text = null, string title = null, int buttons = (int)System.Windows.Forms.MessageBoxButtons.OK, int icon = (int)System.Windows.Forms.MessageBoxIcon.None)
		|        {
		|            if (text == null)
		|            {
		|                text = Text;
		|            }
		|            if (title == null)
		|            {
		|                title = Title;
		|            }
		|            if (buttons == (int)System.Windows.Forms.MessageBoxButtons.OK)
		|            {
		|                buttons = Buttons;
		|            }
		|            if (icon == (int)System.Windows.Forms.MessageBoxIcon.None)
		|            {
		|                icon = Icon;
		|            }
		|            return (int)System.Windows.Forms.MessageBox.Show(text, title, (System.Windows.Forms.MessageBoxButtons)buttons, (System.Windows.Forms.MessageBoxIcon)icon);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "UserControl" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class UserControlEx : System.Windows.Forms.UserControl
		|    {
		|        public osf.UserControl M_Object;
		|    }//endClass
		|
		|    public class UserControl : ContainerControl
		|    {
		|        public ClUserControl dll_obj;
		|        public UserControlEx M_UserControl;
		|        public object M_Value;
		|
		|        public UserControl()
		|        {
		|            M_UserControl = new UserControlEx();
		|            M_UserControl.M_Object = this;
		|            base.M_ContainerControl = M_UserControl;
		|            M_Value = null;
		|        }
		|		
		|        public UserControl(osf.UserControl p1)
		|        {
		|            M_UserControl = p1.M_UserControl;
		|            M_UserControl.M_Object = this;
		|            base.M_ContainerControl = M_UserControl;
		|            M_Value = null;
		|        }
		|
		|        public UserControl(System.Windows.Forms.UserControl p1)
		|        {
		|            M_UserControl = (UserControlEx)p1;
		|            M_UserControl.M_Object = this;
		|            base.M_ContainerControl = M_UserControl;
		|            M_Value = null;
		|        }
		|
		|        public new string Text
		|        {
		|            get { return M_UserControl.Text; }
		|            set
		|            {
		|                M_UserControl.Text = value;
		|                M_UserControl.Invalidate();
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public object Value
		|        {
		|            get { return M_Value; }
		|            set
		|            {
		|                M_Value = value;
		|                M_UserControl.Invalidate();
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "NotifyIcon" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class NotifyIcon : Component
		|    {
		|        public ClNotifyIcon dll_obj;
		|        private System.Windows.Forms.NotifyIcon m_NotifyIcon;
		|        public string Click;
		|        public string DoubleClick;
		|        public string MouseDown;
		|        public string MouseMove;
		|        public string MouseUp;
		|
		|        public System.Windows.Forms.NotifyIcon M_NotifyIcon
		|        {
		|            get { return m_NotifyIcon; }
		|            set
		|            {
		|                m_NotifyIcon = value;
		|                base.M_Component = m_NotifyIcon;
		|                m_NotifyIcon.DoubleClick += M_NotifyIcon_DoubleClick;
		|                m_NotifyIcon.Click += M_NotifyIcon_Click;
		|                m_NotifyIcon.MouseMove += M_NotifyIcon_MouseMove;
		|                m_NotifyIcon.MouseUp += M_NotifyIcon_MouseUp;
		|                m_NotifyIcon.MouseDown += M_NotifyIcon_MouseDown;
		|            }
		|        }
		|		
		|        public NotifyIcon()
		|        {
		|            M_NotifyIcon = new System.Windows.Forms.NotifyIcon();
		|            Click = """";
		|            DoubleClick = """";
		|            MouseDown = """";
		|            MouseMove = """";
		|            MouseUp = """";
		|            OneScriptForms.AddToHashtable(M_NotifyIcon, this);
		|        }
		|
		|        public NotifyIcon(osf.NotifyIcon p1)
		|        {
		|            M_NotifyIcon = p1.M_NotifyIcon;
		|            Click = """";
		|            DoubleClick = """";
		|            MouseDown = """";
		|            MouseMove = """";
		|            MouseUp = """";
		|            OneScriptForms.AddToHashtable(M_NotifyIcon, this);
		|        }
		|
		|        public NotifyIcon(System.Windows.Forms.NotifyIcon p1)
		|        {
		|            M_NotifyIcon = p1;
		|            Click = """";
		|            DoubleClick = """";
		|            MouseDown = """";
		|            MouseMove = """";
		|            MouseUp = """";
		|            OneScriptForms.AddToHashtable(M_NotifyIcon, this);
		|        }
		|
		|        public osf.MenuNotifyIcon ContextMenu
		|        {
		|            get { return new MenuNotifyIcon(M_NotifyIcon.ContextMenu); }
		|            set { M_NotifyIcon.ContextMenu = value.M_MenuNotifyIcon; }
		|        }
		|
		|        public osf.Icon Icon
		|        {
		|            get { return new Icon(M_NotifyIcon.Icon); }
		|            set
		|            {
		|                M_NotifyIcon.Icon = (System.Drawing.Icon)value.M_Icon;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_NotifyIcon.Text; }
		|            set
		|            {
		|                M_NotifyIcon.Text = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool Visible
		|        {
		|            get { return M_NotifyIcon.Visible; }
		|            set
		|            {
		|                M_NotifyIcon.Visible = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void M_NotifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		|        {
		|            if (MouseDown.Length > 0)
		|            {
		|                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
		|                MouseEventArgs1.EventString = MouseDown;
		|                MouseEventArgs1.Sender = (object)this;
		|                MouseEventArgs1.Clicks = e.Clicks;
		|                MouseEventArgs1.Button = (int)e.Button;
		|                MouseEventArgs1.X = e.X;
		|                MouseEventArgs1.Y = e.Y;
		|                OneScriptForms.EventQueue.Add(MouseEventArgs1);
		|                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
		|            }
		|        }
		|
		|        public void M_NotifyIcon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		|        {
		|            if (MouseUp.Length > 0)
		|            {
		|                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
		|                MouseEventArgs1.EventString = MouseUp;
		|                MouseEventArgs1.Sender = (object)this;
		|                MouseEventArgs1.Clicks = e.Clicks;
		|                MouseEventArgs1.Button = (int)e.Button;
		|                MouseEventArgs1.X = e.X;
		|                MouseEventArgs1.Y = e.Y;
		|                OneScriptForms.EventQueue.Add(MouseEventArgs1);
		|                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
		|            }
		|        }
		|
		|        public void M_NotifyIcon_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		|        {
		|            if (MouseMove.Length > 0)
		|            {
		|                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
		|                MouseEventArgs1.EventString = MouseMove;
		|                MouseEventArgs1.Sender = (object)this;
		|                MouseEventArgs1.Clicks = e.Clicks;
		|                MouseEventArgs1.Button = (int)e.Button;
		|                MouseEventArgs1.X = e.X;
		|                MouseEventArgs1.Y = e.Y;
		|                OneScriptForms.EventQueue.Add(MouseEventArgs1);
		|                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
		|            }
		|        }
		|
		|        public void M_NotifyIcon_Click(object sender, System.EventArgs e)
		|        {
		|            if (Click.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Click;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public void M_NotifyIcon_DoubleClick(object sender, System.EventArgs e)
		|        {
		|            if (DoubleClick.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = DoubleClick;
		|                EventArgs1.Sender = (object)this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MenuNotifyIcon" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MenuNotifyIcon : Menu
		|    {
		|        public new ClMenuNotifyIcon dll_obj;
		|        public string Popup;
		|        public ContextMenuEx M_MenuNotifyIcon;
		|
		|        public MenuNotifyIcon()
		|        {
		|            M_MenuNotifyIcon = new ContextMenuEx();
		|            M_MenuNotifyIcon.M_Object = this;
		|            base.M_Menu = M_MenuNotifyIcon;
		|            M_MenuNotifyIcon.Popup += M_ContextMenu_Popup;
		|            Popup = """";
		|            OneScriptForms.AddToHashtable(M_MenuNotifyIcon, this);
		|        }
		|
		|        public MenuNotifyIcon(osf.MenuNotifyIcon p1)
		|        {
		|            M_MenuNotifyIcon = p1.M_MenuNotifyIcon;
		|            M_MenuNotifyIcon.M_Object = this;
		|            base.M_Menu = M_MenuNotifyIcon;
		|            M_MenuNotifyIcon.Popup += M_ContextMenu_Popup;
		|            Popup = """";
		|            OneScriptForms.AddToHashtable(M_MenuNotifyIcon, this);
		|        }
		|
		|        public MenuNotifyIcon(System.Windows.Forms.ContextMenu p1)
		|        {
		|            M_MenuNotifyIcon = (ContextMenuEx)p1;
		|            M_MenuNotifyIcon.M_Object = this;
		|            base.M_Menu = M_MenuNotifyIcon;
		|            M_MenuNotifyIcon.Popup += M_ContextMenu_Popup;
		|            Popup = """";
		|            OneScriptForms.AddToHashtable(M_MenuNotifyIcon, this);
		|        }
		|
		|        public void Show(System.Windows.Forms.Control p1, System.Drawing.Point p2)
		|        {
		|            M_MenuNotifyIcon.Show(p1, p2);
		|        }
		|
		|        public osf.Control SourceControl
		|        {
		|            get { return (osf.Control)((dynamic)M_MenuNotifyIcon.SourceControl).M_Object; }
		|        }
		|
		|        public void M_ContextMenu_Popup(object sender, System.EventArgs e)
		|        {
		|            if (M_MenuNotifyIcon.SourceControl != null)
		|            {
		|                foreach (MenuItemEx itemEx in M_MenuNotifyIcon.MenuItems)
		|                {
		|                    MenuItem item = (MenuItem)itemEx.M_Object;
		|                    item.M_VisibleSaveState = item.Visible;
		|                    item.M_MenuItem.Visible = false;
		|                }
		|                ContextMenuPopupEventArgs ContextMenuPopupEventArgs1 = new ContextMenuPopupEventArgs();
		|                ContextMenuPopupEventArgs1.Sender = (object)this;
		|                ContextMenuPopupEventArgs1.EventString = Popup;
		|                ContextMenuPopupEventArgs1.Point = new Point(M_MenuNotifyIcon.SourceControl.PointToClient(System.Windows.Forms.Control.MousePosition));
		|                OneScriptForms.EventQueue.Add(ContextMenuPopupEventArgs1);
		|                ClContextMenuPopupEventArgs ClContextMenuPopupEventArgs1 = new ClContextMenuPopupEventArgs(ContextMenuPopupEventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "SaveFileDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class SaveFileDialog : FileDialog
		|    {
		|        public ClSaveFileDialog dll_obj;
		|        public System.Windows.Forms.SaveFileDialog M_SaveFileDialog;
		|
		|        public SaveFileDialog()
		|        {
		|            M_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
		|            base.M_FileDialog = M_SaveFileDialog;
		|            OneScriptForms.AddToHashtable(M_SaveFileDialog, this);
		|        }
		|		
		|        public SaveFileDialog(osf.SaveFileDialog p1)
		|        {
		|            M_SaveFileDialog = p1.M_SaveFileDialog;
		|            base.M_FileDialog = M_SaveFileDialog;
		|            OneScriptForms.AddToHashtable(M_SaveFileDialog, this);
		|        }
		|
		|        public SaveFileDialog(System.Windows.Forms.SaveFileDialog p1)
		|        {
		|            M_SaveFileDialog = p1;
		|            base.M_FileDialog = M_SaveFileDialog;
		|            OneScriptForms.AddToHashtable(M_SaveFileDialog, this);
		|        }
		|
		|        public bool CreatePrompt
		|        {
		|            get { return M_SaveFileDialog.CreatePrompt; }
		|            set { M_SaveFileDialog.CreatePrompt = value; }
		|        }
		|
		|        public void Reset()
		|        {
		|            M_SaveFileDialog.Reset();
		|        }
		|
		|        public bool OverwritePrompt
		|        {
		|            get { return M_SaveFileDialog.OverwritePrompt; }
		|            set { M_SaveFileDialog.OverwritePrompt = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "OpenFileDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class OpenFileDialog : FileDialog
		|    {
		|        public ClOpenFileDialog dll_obj;
		|        public System.Windows.Forms.OpenFileDialog M_OpenFileDialog;
		|
		|        public OpenFileDialog()
		|        {
		|            M_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
		|            base.M_FileDialog = M_OpenFileDialog;
		|            OneScriptForms.AddToHashtable(M_OpenFileDialog, this);
		|        }
		|		
		|        public OpenFileDialog(osf.OpenFileDialog p1)
		|        {
		|            M_OpenFileDialog = p1.M_OpenFileDialog;
		|            base.M_FileDialog = M_OpenFileDialog;
		|            OneScriptForms.AddToHashtable(M_OpenFileDialog, this);
		|        }
		|
		|        public OpenFileDialog(System.Windows.Forms.OpenFileDialog p1)
		|        {
		|            M_OpenFileDialog = p1;
		|            base.M_FileDialog = M_OpenFileDialog;
		|            OneScriptForms.AddToHashtable(M_OpenFileDialog, this);
		|        }
		|
		|        public override bool CheckFileExists
		|        {
		|            get { return M_OpenFileDialog.CheckFileExists; }
		|            set { M_OpenFileDialog.CheckFileExists = value; }
		|        }
		|
		|        public bool ReadOnlyChecked
		|        {
		|            get { return M_OpenFileDialog.ReadOnlyChecked; }
		|            set { M_OpenFileDialog.ReadOnlyChecked = value; }
		|        }
		|
		|        public void Reset()
		|        {
		|            M_OpenFileDialog.Reset();
		|        }
		|
		|        public bool ShowReadOnly
		|        {
		|            get { return M_OpenFileDialog.ShowReadOnly; }
		|            set { M_OpenFileDialog.ShowReadOnly = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "FileDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FileDialog : CommonDialog
		|    {
		|        private System.Windows.Forms.FileDialog m_FileDialog;
		|
		|        public System.Windows.Forms.FileDialog M_FileDialog
		|        {
		|            get { return m_FileDialog; }
		|            set
		|            {
		|                m_FileDialog = value;
		|                base.M_CommonDialog = m_FileDialog;
		|            }
		|        }
		|
		|        public FileDialog(System.Windows.Forms.FileDialog p1 = null)
		|        {
		|        }
		|
		|        public bool AddExtension
		|        {
		|            get { return M_FileDialog.AddExtension; }
		|            set { M_FileDialog.AddExtension = value; }
		|        }
		|
		|        public virtual bool CheckFileExists
		|        {
		|            get { return M_FileDialog.CheckFileExists; }
		|            set { M_FileDialog.CheckFileExists = value; }
		|        }
		|
		|        public bool CheckPathExists
		|        {
		|            get { return M_FileDialog.CheckPathExists; }
		|            set { M_FileDialog.CheckPathExists = value; }
		|        }
		|
		|        public string DefaultExt
		|        {
		|            get { return M_FileDialog.DefaultExt; }
		|            set { M_FileDialog.DefaultExt = value; }
		|        }
		|
		|        public bool DereferenceLinks
		|        {
		|            get { return M_FileDialog.DereferenceLinks; }
		|            set { M_FileDialog.DereferenceLinks = value; }
		|        }
		|
		|        public string FileName
		|        {
		|            get { return M_FileDialog.FileName; }
		|            set { M_FileDialog.FileName = value; }
		|        }
		|
		|        public string Filter
		|        {
		|            get { return M_FileDialog.Filter; }
		|            set { M_FileDialog.Filter = value; }
		|        }
		|
		|        public int FilterIndex
		|        {
		|            get { return M_FileDialog.FilterIndex; }
		|            set { M_FileDialog.FilterIndex = value; }
		|        }
		|
		|        public string InitialDirectory
		|        {
		|            get { return M_FileDialog.InitialDirectory; }
		|            set { M_FileDialog.InitialDirectory = value; }
		|        }
		|
		|        public bool RestoreDirectory
		|        {
		|            get { return M_FileDialog.RestoreDirectory; }
		|            set { M_FileDialog.RestoreDirectory = value; }
		|        }
		|
		|        public string Title
		|        {
		|            get { return M_FileDialog.Title; }
		|            set { M_FileDialog.Title = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "FontDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FontDialogEx : System.Windows.Forms.FontDialog
		|    {
		|        public osf.FontDialog M_Object;
		|    }//endClass
		|
		|    public class FontDialog : CommonDialog
		|    {
		|        public ClFontDialog dll_obj;
		|        public FontDialogEx M_FontDialog;
		|
		|        public FontDialog()
		|        {
		|            M_FontDialog = new FontDialogEx();
		|            M_FontDialog.M_Object = this;
		|            base.M_CommonDialog = M_FontDialog;
		|        }
		|
		|        public FontDialog(osf.FontDialog p1)
		|        {
		|            M_FontDialog = p1.M_FontDialog;
		|            M_FontDialog.M_Object = this;
		|            base.M_CommonDialog = M_FontDialog;
		|        }
		|
		|        public FontDialog(System.Windows.Forms.FontDialog p1)
		|        {
		|            M_FontDialog = (FontDialogEx)p1;
		|            M_FontDialog.M_Object = this;
		|            base.M_CommonDialog = M_FontDialog;
		|        }
		|
		|        public osf.Font Font
		|        {
		|            get { return new Font(M_FontDialog.Font); }
		|            set { M_FontDialog.Font = value.M_Font; }
		|        }
		|
		|        public osf.Color Color
		|        {
		|            get { return new Color(M_FontDialog.Color); }
		|            set { M_FontDialog.Color = value.M_Color; }
		|        }
		|
		|        public bool ShowColor
		|        {
		|            get { return M_FontDialog.ShowColor; }
		|            set { M_FontDialog.ShowColor = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ColorDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ColorDialogEx : System.Windows.Forms.ColorDialog
		|    {
		|        public osf.ColorDialog M_Object;
		|    }//endClass
		|
		|    public class ColorDialog : CommonDialog
		|    {
		|        public ClColorDialog dll_obj;
		|        public ColorDialogEx M_ColorDialog;
		|
		|        public ColorDialog()
		|        {
		|            M_ColorDialog = new ColorDialogEx();
		|            M_ColorDialog.M_Object = this;
		|            base.M_CommonDialog = M_ColorDialog;
		|        }
		|
		|        public ColorDialog(osf.ColorDialog p1)
		|        {
		|            M_ColorDialog = p1.M_ColorDialog;
		|            M_ColorDialog.M_Object = this;
		|            base.M_CommonDialog = M_ColorDialog;
		|        }
		|
		|        public ColorDialog(System.Windows.Forms.ColorDialog p1)
		|        {
		|            M_ColorDialog = (ColorDialogEx)p1;
		|            M_ColorDialog.M_Object = this;
		|            base.M_CommonDialog = M_ColorDialog;
		|        }
		|
		|        public osf.Color Color
		|        {
		|            get { return new Color(M_ColorDialog.Color); }
		|            set { M_ColorDialog.Color = value.M_Color; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Timer" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TimerEx : System.Windows.Forms.Timer
		|    {
		|        public osf.Timer M_Object;
		|    }//endClass
		|
		|    public class Timer : Component
		|    {
		|        public ClTimer dll_obj;
		|        public TimerEx M_Timer;
		|        public string Tick;
		|
		|        public Timer()
		|        {
		|            M_Timer = new TimerEx();
		|            M_Timer.M_Object = this;
		|            base.M_Component = M_Timer;
		|            M_Timer.Tick += M_Timer_Tick1;
		|            Tick = """";
		|        }
		|		
		|        public Timer(osf.Timer p1)
		|        {
		|            M_Timer = p1.M_Timer;
		|            M_Timer.M_Object = this;
		|            base.M_Component = M_Timer;
		|            M_Timer.Tick += M_Timer_Tick1;
		|            Tick = """";
		|        }
		|
		|        public Timer(System.Windows.Forms.Timer p1)
		|        {
		|            M_Timer = (TimerEx)p1;
		|            M_Timer.M_Object = this;
		|            base.M_Component = M_Timer;
		|            M_Timer.Tick += M_Timer_Tick1;
		|            Tick = """";
		|        }
		|
		|        public int Interval
		|        {
		|            get { return M_Timer.Interval; }
		|            set { M_Timer.Interval = value; }
		|        }
		|
		|        public void Start()
		|        {
		|            M_Timer.Start();
		|        }
		|
		|        public void Stop()
		|        {
		|            M_Timer.Stop();
		|        }
		|
		|        public void M_Timer_Tick1(object sender, System.EventArgs e)
		|        {
		|            if (Tick.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Tick;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "FolderBrowserDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FolderBrowserDialog : CommonDialog
		|    {
		|        public ClFolderBrowserDialog dll_obj;
		|        public System.Windows.Forms.FolderBrowserDialog M_FolderBrowserDialog;
		|
		|        public FolderBrowserDialog()
		|        {
		|            M_FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
		|            base.M_CommonDialog = M_FolderBrowserDialog;
		|            OneScriptForms.AddToHashtable(M_FolderBrowserDialog, this);
		|        }
		|
		|        public FolderBrowserDialog(osf.FolderBrowserDialog p1)
		|        {
		|            M_FolderBrowserDialog = p1.M_FolderBrowserDialog;
		|            base.M_CommonDialog = M_FolderBrowserDialog;
		|        }
		|
		|        public FolderBrowserDialog(System.Windows.Forms.FolderBrowserDialog p1)
		|        {
		|            M_FolderBrowserDialog = p1;
		|            base.M_CommonDialog = M_FolderBrowserDialog;
		|        }
		|
		|        public string Description
		|        {
		|            get { return M_FolderBrowserDialog.Description; }
		|            set { M_FolderBrowserDialog.Description = value; }
		|        }
		|
		|        public void Reset()
		|        {
		|            M_FolderBrowserDialog.Reset();
		|        }
		|
		|        public int RootFolder
		|        {
		|            get { return (int)M_FolderBrowserDialog.RootFolder; }
		|            set { M_FolderBrowserDialog.RootFolder = (System.Environment.SpecialFolder)value; }
		|        }
		|
		|        public string SelectedPath
		|        {
		|            get { return M_FolderBrowserDialog.SelectedPath; }
		|            set { M_FolderBrowserDialog.SelectedPath = value; }
		|        }
		|
		|        public bool ShowNewFolderButton
		|        {
		|            get { return M_FolderBrowserDialog.ShowNewFolderButton; }
		|            set { M_FolderBrowserDialog.ShowNewFolderButton = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "CommonDialog" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class CommonDialog : Component
		|    {
		|        public System.Windows.Forms.CommonDialog M_CommonDialog;
		|
		|        public CommonDialog()
		|        {
		|        }
		|
		|        public CommonDialog(osf.CommonDialog p1)
		|        {
		|            M_CommonDialog = p1.M_CommonDialog;
		|            base.M_Component = M_CommonDialog;
		|        }
		|
		|        public CommonDialog(System.Windows.Forms.CommonDialog p1)
		|        {
		|            M_CommonDialog = p1;
		|            base.M_Component = M_CommonDialog;
		|        }
		|
		|        public int ShowDialog()
		|        {
		|            return (int)M_CommonDialog.ShowDialog();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TreeNodeCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TreeNodeCollection : CollectionBase
		|    {
		|        public ClTreeNodeCollection dll_obj;
		|        public System.Windows.Forms.TreeNodeCollection M_TreeNodeCollection;
		|
		|        public TreeNodeCollection()
		|        {
		|        }
		|
		|        public TreeNodeCollection(System.Windows.Forms.TreeNodeCollection p1)
		|        {
		|            M_TreeNodeCollection = p1;
		|            base.List = M_TreeNodeCollection;
		|        }
		|
		|        public new osf.TreeNode Add(object p1)
		|        {
		|            if (p1 is TreeNode)
		|            {
		|                M_TreeNodeCollection.Add((System.Windows.Forms.TreeNode)((TreeNode)p1).M_TreeNode);
		|                System.Windows.Forms.Application.DoEvents();
		|                return (TreeNode)p1;
		|            }
		|            TreeNode TreeNode1 = new TreeNode();
		|            TreeNode1.Text = Convert.ToString(p1);
		|            M_TreeNodeCollection.Add((System.Windows.Forms.TreeNode)((TreeNode)TreeNode1).M_TreeNode);
		|            System.Windows.Forms.Application.DoEvents();
		|            return TreeNode1;
		|        }
		|
		|        public osf.TreeNode Insert(int p1, TreeNode p2)
		|        {
		|            M_TreeNodeCollection.Insert(p1, p2.M_TreeNode);
		|            return p2;
		|        }
		|
		|        public new osf.TreeNode this[int index]
		|        {
		|            get { return ((TreeNodeEx)M_TreeNodeCollection[index]).M_Object; }
		|        }
		|
		|        public void Remove(TreeNode TreeNode)
		|        {
		|            M_TreeNodeCollection.Remove((System.Windows.Forms.TreeNode)TreeNode.M_TreeNode);
		|        }
		|
		|        public override object Current
		|        {
		|            get { return (object)((TreeNodeEx)(System.Windows.Forms.TreeNode)Enumerator.Current).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TreeNode" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TreeNodeEx : System.Windows.Forms.TreeNode
		|    {
		|        public osf.TreeNode M_Object;
		|    }//endClass
		|
		|    public class TreeNode
		|    {
		|        public ClTreeNode dll_obj;
		|        public TreeNodeEx M_TreeNode;
		|
		|        public TreeNode()
		|        {
		|            M_TreeNode = new TreeNodeEx();
		|            M_TreeNode.M_Object = this;
		|        }
		|
		|        public TreeNode(string p1)
		|        {
		|            M_TreeNode = new TreeNodeEx();
		|            M_TreeNode.M_Object = this;
		|            M_TreeNode.Text = p1;
		|        }
		|
		|        public TreeNode(osf.TreeNode p1)
		|        {
		|            M_TreeNode = p1.M_TreeNode;
		|            M_TreeNode.M_Object = this;
		|        }
		|
		|        public TreeNode(System.Windows.Forms.TreeNode p1)
		|        {
		|            M_TreeNode = (TreeNodeEx)p1;
		|            M_TreeNode.M_Object = this;
		|        }
		|
		|        public void BeginEdit()
		|        {
		|            M_TreeNode.BeginEdit();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool Checked
		|        {
		|            get { return M_TreeNode.Checked; }
		|            set { M_TreeNode.Checked = value; }
		|        }
		|
		|        public void Collapse()
		|        {
		|            M_TreeNode.Collapse();
		|        }
		|
		|        public void Expand()
		|        {
		|            M_TreeNode.Expand();
		|        }
		|
		|        public string FullPath
		|        {
		|            get { return M_TreeNode.FullPath; }
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_TreeNode.ImageIndex; }
		|            set { M_TreeNode.ImageIndex = value; }
		|        }
		|
		|        public int Index
		|        {
		|            get { return M_TreeNode.Index; }
		|        }
		|
		|        public osf.TreeNodeCollection Nodes
		|        {
		|            get { return new TreeNodeCollection(M_TreeNode.Nodes); }
		|        }
		|
		|        public osf.Font NodeFont
		|        {
		|            get { return new Font(M_TreeNode.NodeFont); }
		|            set { M_TreeNode.NodeFont = value.M_Font; }
		|        }
		|
		|        public osf.TreeNode Parent
		|        {
		|            get { return (TreeNode)((TreeNodeEx)M_TreeNode.Parent).M_Object; }
		|        }
		|
		|        public osf.TreeNode NextVisibleNode
		|        {
		|            get { return ((TreeNodeEx)M_TreeNode.NextVisibleNode).M_Object; }
		|        }
		|
		|        public osf.TreeNode PrevVisibleNode
		|        {
		|            get { return ((TreeNodeEx)M_TreeNode.PrevVisibleNode).M_Object; }
		|        }
		|
		|        public void Remove()
		|        {
		|            M_TreeNode.Remove();
		|        }
		|
		|        public int SelectedImageIndex
		|        {
		|            get { return M_TreeNode.SelectedImageIndex; }
		|            set { M_TreeNode.SelectedImageIndex = value; }
		|        }
		|
		|        public object Tag
		|        {
		|            get { return M_TreeNode.Tag; }
		|            set { M_TreeNode.Tag = value; }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_TreeNode.Text; }
		|            set { M_TreeNode.Text = value; }
		|        }
		|
		|        public osf.TreeView TreeView
		|        {
		|            get { return (TreeView)((TreeViewEx)M_TreeNode.TreeView).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TreeView" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TreeViewEx : System.Windows.Forms.TreeView
		|    {
		|        public osf.TreeView M_Object;
		|    }//endClass
		|
		|    public class TreeView : Control
		|    {
		|        public ClTreeView dll_obj;
		|        public TreeViewEx M_TreeView;
		|        public string AfterLabelEdit;
		|        public string AfterSelect;
		|        public string BeforeExpand;
		|        public string BeforeLabelEdit;
		|        public string BeforeSelect;
		|
		|        public TreeView()
		|        {
		|            M_TreeView = new TreeViewEx();
		|            M_TreeView.M_Object = this;
		|            base.M_Control = M_TreeView;
		|            M_TreeView.BeforeExpand += M_TreeView_BeforeExpand;
		|            M_TreeView.AfterSelect += M_TreeView_AfterSelect;
		|            M_TreeView.AfterLabelEdit += M_TreeView_AfterLabelEdit;
		|            M_TreeView.BeforeSelect += M_TreeView_BeforeSelect;
		|            AfterLabelEdit = """";
		|            AfterSelect = """";
		|            BeforeExpand = """";
		|            BeforeLabelEdit = """";
		|            BeforeSelect = """";
		|        }
		|
		|        public TreeView(osf.TreeView p1)
		|        {
		|            M_TreeView = p1.M_TreeView;
		|            M_TreeView.M_Object = this;
		|            base.M_Control = M_TreeView;
		|            M_TreeView.BeforeExpand += M_TreeView_BeforeExpand;
		|            M_TreeView.AfterSelect += M_TreeView_AfterSelect;
		|            M_TreeView.AfterLabelEdit += M_TreeView_AfterLabelEdit;
		|            M_TreeView.BeforeSelect += M_TreeView_BeforeSelect;
		|            AfterLabelEdit = """";
		|            AfterSelect = """";
		|            BeforeExpand = """";
		|            BeforeLabelEdit = """";
		|            BeforeSelect = """";
		|        }
		|
		|        public TreeView(System.Windows.Forms.TreeView p1)
		|        {
		|            M_TreeView = (TreeViewEx)p1;
		|            M_TreeView.M_Object = this;
		|            base.M_Control = M_TreeView;
		|            M_TreeView.BeforeExpand += M_TreeView_BeforeExpand;
		|            M_TreeView.AfterSelect += M_TreeView_AfterSelect;
		|            M_TreeView.AfterLabelEdit += M_TreeView_AfterLabelEdit;
		|            M_TreeView.BeforeSelect += M_TreeView_BeforeSelect;
		|            AfterLabelEdit = """";
		|            AfterSelect = """";
		|            BeforeExpand = """";
		|            BeforeLabelEdit = """";
		|            BeforeSelect = """";
		|        }
		|
		|        public override void BeginUpdate()
		|        {
		|            M_TreeView.BeginUpdate();
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_TreeView.BorderStyle; }
		|            set { M_TreeView.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
		|        }
		|
		|        public bool CheckBoxes
		|        {
		|            get { return M_TreeView.CheckBoxes; }
		|            set { M_TreeView.CheckBoxes = value; }
		|        }
		|
		|        public override void EndUpdate()
		|        {
		|            M_TreeView.EndUpdate();
		|        }
		|
		|        public bool FullRowSelect
		|        {
		|            get { return M_TreeView.FullRowSelect; }
		|            set { M_TreeView.FullRowSelect = value; }
		|        }
		|
		|        public osf.TreeNode GetNodeAt(int x, int y)
		|        {
		|            if (M_TreeView.GetNodeAt(x, y) != null)
		|            {
		|                return ((TreeNodeEx)M_TreeView.GetNodeAt(x, y)).M_Object;
		|            }
		|            return null;
		|        }
		|
		|        public bool HideSelection
		|        {
		|            get { return M_TreeView.HideSelection; }
		|            set { M_TreeView.HideSelection = value; }
		|        }
		|
		|        public bool HotTracking
		|        {
		|            get { return M_TreeView.HotTracking; }
		|            set { M_TreeView.HotTracking = value; }
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_TreeView.ImageIndex; }
		|            set { M_TreeView.ImageIndex = value; }
		|        }
		|
		|        public osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_TreeView.ImageList); }
		|            set { M_TreeView.ImageList = value.M_ImageList; }
		|        }
		|
		|        public int Indent
		|        {
		|            get { return M_TreeView.Indent; }
		|            set { M_TreeView.Indent = value; }
		|        }
		|
		|        public int ItemHeight
		|        {
		|            get { return M_TreeView.ItemHeight; }
		|            set { M_TreeView.ItemHeight = value; }
		|        }
		|
		|        public bool LabelEdit
		|        {
		|            get { return M_TreeView.LabelEdit; }
		|            set { M_TreeView.LabelEdit = value; }
		|        }
		|
		|        public osf.TreeNodeCollection Nodes
		|        {
		|            get { return new TreeNodeCollection(M_TreeView.Nodes); }
		|        }
		|
		|        public string PathSeparator
		|        {
		|            get { return M_TreeView.PathSeparator; }
		|            set { M_TreeView.PathSeparator = value; }
		|        }
		|
		|        public bool Scrollable
		|        {
		|            get { return M_TreeView.Scrollable; }
		|            set { M_TreeView.Scrollable = value; }
		|        }
		|
		|        public int SelectedImageIndex
		|        {
		|            get { return M_TreeView.SelectedImageIndex; }
		|            set { M_TreeView.SelectedImageIndex = value; }
		|        }
		|
		|        public osf.TreeNode SelectedNode
		|        {
		|            get
		|            {
		|                if (M_TreeView.SelectedNode != null)
		|                {
		|                    return ((TreeNodeEx)M_TreeView.SelectedNode).M_Object;
		|                }
		|                return null;
		|            }
		|            set { M_TreeView.SelectedNode = (System.Windows.Forms.TreeNode)value.M_TreeNode; }
		|        }
		|
		|        public bool ShowLines
		|        {
		|            get { return M_TreeView.ShowLines; }
		|            set { M_TreeView.ShowLines = value; }
		|        }
		|
		|        public bool ShowPlusMinus
		|        {
		|            get { return M_TreeView.ShowPlusMinus; }
		|            set { M_TreeView.ShowPlusMinus = value; }
		|        }
		|
		|        public bool ShowRootLines
		|        {
		|            get { return M_TreeView.ShowRootLines; }
		|            set { M_TreeView.ShowRootLines = value; }
		|        }
		|
		|        public bool Sorted
		|        {
		|            get { return M_TreeView.Sorted; }
		|            set { M_TreeView.Sorted = value; }
		|        }
		|
		|        public void M_TreeView_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		|        {
		|            if (AfterLabelEdit.Length > 0)
		|            {
		|                NodeLabelEditEventArgs NodeLabelEditEventArgs1 = new NodeLabelEditEventArgs();
		|                NodeLabelEditEventArgs1.EventString = AfterLabelEdit;
		|                NodeLabelEditEventArgs1.Sender = this;
		|                NodeLabelEditEventArgs1.CancelEdit = e.CancelEdit;
		|                NodeLabelEditEventArgs1.Label = e.Label;
		|                NodeLabelEditEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
		|                NodeLabelEditEventArgs1.Label_old = e.Node.Text;
		|                OneScriptForms.EventQueue.Add(NodeLabelEditEventArgs1);
		|                ClNodeLabelEditEventArgs ClNodeLabelEditEventArgs1 = new ClNodeLabelEditEventArgs(NodeLabelEditEventArgs1);
		|            }
		|        }
		|
		|        public void M_TreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		|        {
		|            if (AfterSelect.Length > 0)
		|            {
		|                TreeViewEventArgs TreeViewEventArgs1 = new TreeViewEventArgs();
		|                TreeViewEventArgs1.Action = (int)e.Action;
		|                TreeViewEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
		|                TreeViewEventArgs1.EventString = AfterSelect;
		|                TreeViewEventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(TreeViewEventArgs1);
		|                ClTreeViewEventArgs ClTreeViewEventArgs1 = new ClTreeViewEventArgs(TreeViewEventArgs1);
		|            }
		|        }
		|
		|        public void M_TreeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		|        {
		|            if (BeforeExpand.Length > 0)
		|            {
		|                TreeViewCancelEventArgs TreeViewCancelEventArgs1 = new TreeViewCancelEventArgs();
		|                TreeViewCancelEventArgs1.Cancel = e.Cancel;
		|                TreeViewCancelEventArgs1.Action = (int)e.Action;
		|                TreeViewCancelEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
		|                TreeViewCancelEventArgs1.EventString = BeforeExpand;
		|                TreeViewCancelEventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(TreeViewCancelEventArgs1);
		|                ClTreeViewCancelEventArgs ClTreeViewCancelEventArgs1 = new ClTreeViewCancelEventArgs(TreeViewCancelEventArgs1);
		|                e.Cancel = true;
		|            }
		|        }
		|
		|        public void M_TreeView_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		|        {
		|            if (BeforeSelect.Length > 0)
		|            {
		|                TreeViewCancelEventArgs TreeViewCancelEventArgs1 = new TreeViewCancelEventArgs();
		|                TreeViewCancelEventArgs1.Cancel = e.Cancel;
		|                TreeViewCancelEventArgs1.Action = (int)e.Action;
		|                TreeViewCancelEventArgs1.Node = (TreeNode)((TreeNodeEx)e.Node).M_Object;
		|                TreeViewCancelEventArgs1.EventString = BeforeSelect;
		|                TreeViewCancelEventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(TreeViewCancelEventArgs1);
		|                ClTreeViewCancelEventArgs ClTreeViewCancelEventArgs1 = new ClTreeViewCancelEventArgs(TreeViewCancelEventArgs1);
		|                e.Cancel = true;
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ExtractIconClass" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    class ExtractIconClass
		|    {
		|        [DllImport(""Kernel32.dll"")] public static extern int GetModuleHandle(string lpModuleName);
		|        [DllImport(""Shell32.dll"")] public static extern IntPtr ExtractIcon(int hInst, string FileName, int nIconIndex);
		|        [DllImport(""Shell32.dll"")] public static extern int DestroyIcon(IntPtr hIcon);
		|        [DllImport(""Shell32.dll"")] public static extern IntPtr ExtractIconEx(string FileName, int nIconIndex, int[] lgIcon, int[] smIcon, int nIcons);
		|        [DllImport(""Shell32.dll"")] private static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbfileInfo, SHGFI uFlags);
		|        [StructLayout(LayoutKind.Sequential)]
		|
		|        private struct SHFILEINFO
		|        {
		|            public SHFILEINFO(bool b)
		|            {
		|                hIcon = IntPtr.Zero;
		|                iIcon = 0;
		|                dwAttributes = 0;
		|                szDisplayName = """";
		|                szTypeName = """";
		|            }
		|            public IntPtr hIcon;
		|            public int iIcon;
		|            public uint dwAttributes;
		|            [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
		|            public string szDisplayName;
		|            [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
		|            public string szTypeName;
		|        };
		|
		|        private enum SHGFI
		|        {
		|            SmallIcon = 0x00000001,
		|            LargeIcon = 0x00000000,
		|            Icon = 0x00000100,
		|            DisplayName = 0x00000200,
		|            Typename = 0x00000400,
		|            SysIconIndex = 0x00004000,
		|            UseFileAttributes = 0x00000010
		|        }
		|
		|        public static System.Drawing.Icon GetIcon(string strPath, bool bSmall)
		|        {
		|            SHFILEINFO info = new SHFILEINFO(true);
		|            int cbFileInfo = Marshal.SizeOf(info);
		|            SHGFI flags;
		|            if (bSmall)
		|                flags = SHGFI.Icon | SHGFI.SmallIcon | SHGFI.UseFileAttributes;
		|            else
		|                flags = SHGFI.Icon | SHGFI.LargeIcon | SHGFI.UseFileAttributes;
		|
		|            SHGetFileInfo(strPath, 256, out info, (uint)cbFileInfo, flags);
		|            
		|            return System.Drawing.Icon.FromHandle(info.hIcon);
		|        }        
		|
		|        public static System.Drawing.Icon GetSysIcon(int icNo)
		|        {
		|            IntPtr HIcon = ExtractIcon(GetModuleHandle(string.Empty), ""DDORes.dll""/*""Shell32.dll""*/, icNo);            
		|            return System.Drawing.Icon.FromHandle(HIcon);
		|        }
		|        public static System.Drawing.Icon GetSysIconFromDll(int icNo, string dll)
		|        {
		|            IntPtr HIcon = ExtractIcon(GetModuleHandle(string.Empty), dll + "".dll"", icNo);
		|            return System.Drawing.Icon.FromHandle(HIcon);
		|        }
		|        public static System.Drawing.Icon GetIconFromExeDll(int icNo, string dll)
		|        {
		|            IntPtr HIcon = ExtractIcon(GetModuleHandle(string.Empty), dll, icNo);
		|
		|            return System.Drawing.Icon.FromHandle(HIcon);
		|        }
		|    }
		|}
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MonthCalendar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MonthCalendarEx : System.Windows.Forms.MonthCalendar
		|    {
		|        public osf.MonthCalendar M_Object;
		|    }//endClass
		|
		|    public class MonthCalendar : Control
		|    {
		|        public ClMonthCalendar dll_obj;
		|        public MonthCalendarEx M_MonthCalendar;
		|        public string M_DateChanged;
		|        public string M_DateSelected;
		|
		|        public MonthCalendar()
		|        {
		|            M_MonthCalendar = new MonthCalendarEx();
		|            M_MonthCalendar.M_Object = this;
		|            base.M_Control = M_MonthCalendar;
		|            M_MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateChanged);
		|            M_MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateSelected);
		|            M_DateChanged = """";
		|            M_DateSelected = """";
		|        }
		|
		|        public MonthCalendar(osf.MonthCalendar p1)
		|        {
		|            M_MonthCalendar = p1.M_MonthCalendar;
		|            M_MonthCalendar.M_Object = this;
		|            base.M_Control = M_MonthCalendar;
		|            M_MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateChanged);
		|            M_MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateSelected);
		|            M_DateChanged = """";
		|            M_DateSelected = """";
		|        }
		|
		|        public MonthCalendar(System.Windows.Forms.MonthCalendar p1)
		|        {
		|            M_MonthCalendar = (MonthCalendarEx)p1;
		|            M_MonthCalendar.M_Object = this;
		|            base.M_Control = M_MonthCalendar;
		|            M_MonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateChanged);
		|            M_MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(MonthCalendar_DateSelected);
		|            M_DateChanged = """";
		|            M_DateSelected = """";
		|        }
		|
		|        public bool ShowToday
		|        {
		|            get { return M_MonthCalendar.ShowToday; }
		|            set { M_MonthCalendar.ShowToday = value; }
		|        }
		|
		|        public int FirstDayOfWeek
		|        {
		|            get { return (int)M_MonthCalendar.FirstDayOfWeek; }
		|            set { M_MonthCalendar.FirstDayOfWeek = (System.Windows.Forms.Day)value; }
		|        }
		|
		|        public bool ShowTodayCircle
		|        {
		|            get { return M_MonthCalendar.ShowTodayCircle; }
		|            set { M_MonthCalendar.ShowTodayCircle = value; }
		|        }
		|
		|        public int MaxSelectionCount
		|        {
		|            get { return M_MonthCalendar.MaxSelectionCount; }
		|            set { M_MonthCalendar.MaxSelectionCount = value; }
		|        }
		|
		|        public System.DateTime[] MonthlyBoldedDates
		|        {
		|            get { return M_MonthCalendar.MonthlyBoldedDates; }
		|            set { M_MonthCalendar.MonthlyBoldedDates = value; }
		|        }
		|
		|        public System.DateTime[] AnnuallyBoldedDates
		|        {
		|            get { return M_MonthCalendar.AnnuallyBoldedDates; }
		|            set { M_MonthCalendar.AnnuallyBoldedDates = value; }
		|        }
		|
		|        public osf.SelectionRange SelectionRange
		|        {
		|            get { return new SelectionRange(M_MonthCalendar.SelectionRange); }
		|            set { M_MonthCalendar.SelectionRange = value.M_SelectionRange; }
		|        }
		|
		|        public System.DateTime TodayDate
		|        {
		|            get { return M_MonthCalendar.TodayDate; }
		|            set { M_MonthCalendar.TodayDate = value; }
		|        }
		|
		|        public System.DateTime[] BoldedDates
		|        {
		|            get { return M_MonthCalendar.BoldedDates; }
		|            set { M_MonthCalendar.BoldedDates = value; }
		|        }
		|
		|        public System.DateTime SelectionStart
		|        {
		|            get { return M_MonthCalendar.SelectionStart; }
		|            set
		|            {
		|                M_MonthCalendar.SelectionStart = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public System.DateTime SelectionEnd
		|        {
		|            get { return M_MonthCalendar.SelectionEnd; }
		|            set
		|            {
		|                M_MonthCalendar.SelectionEnd = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string DateChanged
		|        {
		|            get { return M_DateChanged; }
		|            set { M_DateChanged = value; }
		|        }
		|
		|        public string DateSelected
		|        {
		|            get { return M_DateSelected; }
		|            set { M_DateSelected = value; }
		|        }
		|
		|        public System.DateTime MaxDate
		|        {
		|            get { return M_MonthCalendar.MaxDate; }
		|            set
		|            {
		|                M_MonthCalendar.MaxDate = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public System.DateTime MinDate
		|        {
		|            get { return M_MonthCalendar.MinDate; }
		|            set
		|            {
		|                M_MonthCalendar.MinDate = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Size PreferredSize
		|        {
		|            get { return new Size(M_MonthCalendar.PreferredSize); }
		|        }
		|
		|        private void MonthCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		|        {
		|            if (M_DateChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = M_DateChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        private void MonthCalendar_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
		|        {
		|            if (M_DateSelected.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = M_DateSelected;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "SelectionRange" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class SelectionRange
		|    {
		|        public ClSelectionRange dll_obj;
		|        public System.Windows.Forms.SelectionRange M_SelectionRange;
		|
		|        public SelectionRange()
		|        {
		|            M_SelectionRange = new System.Windows.Forms.SelectionRange();
		|            OneScriptForms.AddToHashtable(M_SelectionRange, this);
		|        }
		|
		|        public SelectionRange(DateTime p1, DateTime p2)
		|        {
		|            M_SelectionRange = new System.Windows.Forms.SelectionRange(p1, p2);
		|            OneScriptForms.AddToHashtable(M_SelectionRange, this);
		|        }
		|
		|        public SelectionRange(osf.SelectionRange p1)
		|        {
		|            M_SelectionRange = p1.M_SelectionRange;
		|            OneScriptForms.AddToHashtable(M_SelectionRange, this);
		|        }
		|		
		|        public SelectionRange(System.Windows.Forms.SelectionRange p1)
		|        {
		|            M_SelectionRange = p1;
		|            OneScriptForms.AddToHashtable(M_SelectionRange, this);
		|        }
		|
		|        public System.DateTime End
		|        {
		|            get { return M_SelectionRange.End; }
		|            set { M_SelectionRange.End = value; }
		|        }
		|
		|        public System.DateTime Start
		|        {
		|            get { return M_SelectionRange.Start; }
		|            set { M_SelectionRange.Start = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Process" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ProcessEx : System.Diagnostics.Process
		|    {
		|        public osf.Process M_Object;
		|    }//endClass
		|
		|    public class Process
		|    {
		|        public ClProcess dll_obj;
		|        public ProcessEx M_Process;
		|
		|        public Process()
		|        {
		|            M_Process = new ProcessEx();
		|            M_Process.M_Object = this;
		|        }
		|		
		|        public Process(osf.Process p1)
		|        {
		|            M_Process = p1.M_Process;
		|            M_Process.M_Object = this;
		|        }
		|
		|        public Process(System.Diagnostics.Process p1)
		|        {
		|            M_Process = (ProcessEx)p1;
		|            M_Process.M_Object = this;
		|        }
		|
		|        public bool HasExited
		|        {
		|            get { return M_Process.HasExited; }
		|        }
		|
		|        public osf.StreamReader StandardOutput
		|        {
		|            get { return new StreamReader(M_Process.StandardOutput); }
		|        }
		|
		|        public osf.Process Start()
		|        {
		|            M_Process.Start();
		|            return this;
		|        }
		|
		|        public osf.ProcessStartInfo StartInfo
		|        {
		|            get { return new ProcessStartInfo(M_Process.StartInfo); }
		|            set { M_Process.StartInfo = (System.Diagnostics.ProcessStartInfo)value.M_ProcessStartInfo; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ProcessStartInfo" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ProcessStartInfo
		|    {
		|        public ClProcessStartInfo dll_obj;
		|        public System.Diagnostics.ProcessStartInfo M_ProcessStartInfo;
		|
		|        public ProcessStartInfo(string filename = null, string arguments = null)
		|        {
		|            M_ProcessStartInfo = new System.Diagnostics.ProcessStartInfo(filename, arguments);
		|            OneScriptForms.AddToHashtable(M_ProcessStartInfo, this);
		|        }
		|
		|        public ProcessStartInfo(osf.ProcessStartInfo p1)
		|        {
		|            M_ProcessStartInfo = p1.M_ProcessStartInfo;
		|            OneScriptForms.AddToHashtable(M_ProcessStartInfo, this);
		|        }
		|		
		|        public ProcessStartInfo(System.Diagnostics.ProcessStartInfo p1)
		|        {
		|            M_ProcessStartInfo = p1;
		|            OneScriptForms.AddToHashtable(M_ProcessStartInfo, this);
		|        }
		|
		|        public string Arguments
		|        {
		|            get { return M_ProcessStartInfo.Arguments; }
		|            set { M_ProcessStartInfo.Arguments = value; }
		|        }
		|
		|        public bool CreateNoWindow
		|        {
		|            get { return M_ProcessStartInfo.CreateNoWindow; }
		|            set { M_ProcessStartInfo.CreateNoWindow = value; }
		|        }
		|
		|        public string Domain
		|        {
		|            get { return M_ProcessStartInfo.Domain; }
		|            set { M_ProcessStartInfo.Domain = value; }
		|        }
		|
		|        public string FileName
		|        {
		|            get { return M_ProcessStartInfo.FileName; }
		|            set { M_ProcessStartInfo.FileName = value; }
		|        }
		|
		|        public string Password
		|        {
		|            get { return """"; }
		|            set
		|            {
		|                SecureString secureString = new SecureString();
		|                for (int i = 0; i < Strings.Len(value); i++)
		|                {
		|                    secureString.AppendChar(Convert.ToChar(value.Substring(i, 1)));
		|                }
		|                M_ProcessStartInfo.Password = secureString;
		|            }
		|        }
		|
		|        public bool RedirectStandardOutput
		|        {
		|            get { return M_ProcessStartInfo.RedirectStandardOutput; }
		|            set { M_ProcessStartInfo.RedirectStandardOutput = value; }
		|        }
		|
		|        public string UserName
		|        {
		|            get { return M_ProcessStartInfo.UserName; }
		|            set { M_ProcessStartInfo.UserName = value; }
		|        }
		|
		|        public bool UseShellExecute
		|        {
		|            get { return M_ProcessStartInfo.UseShellExecute; }
		|            set { M_ProcessStartInfo.UseShellExecute = value; }
		|        }
		|
		|        public int WindowStyle
		|        {
		|            get { return (int)M_ProcessStartInfo.WindowStyle; }
		|            set { M_ProcessStartInfo.WindowStyle = (System.Diagnostics.ProcessWindowStyle)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TextBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TextBoxEx : System.Windows.Forms.TextBox
		|    {
		|        public osf.TextBox M_Object;
		|    }//endClass
		|
		|    public class TextBox : TextBoxBase
		|    {
		|        public ClTextBox dll_obj;
		|        public TextBoxEx M_TextBox;
		|
		|        public TextBox()
		|        {
		|            M_TextBox = new TextBoxEx();
		|            M_TextBox.M_Object = this;
		|            base.M_TextBoxBase = M_TextBox;
		|        }
		|		
		|        public TextBox(osf.TextBox p1)
		|        {
		|            M_TextBox = p1.M_TextBox;
		|            M_TextBox.M_Object = this;
		|            base.M_TextBoxBase = M_TextBox;
		|        }
		|
		|        public TextBox(System.Windows.Forms.TextBox p1)
		|        {
		|            M_TextBox = (TextBoxEx)p1;
		|            M_TextBox.M_Object = this;
		|            base.M_TextBoxBase = M_TextBox;
		|        }
		|
		|        public bool AcceptsReturn
		|        {
		|            get { return M_TextBox.AcceptsReturn; }
		|            set
		|            {
		|                M_TextBox.AcceptsReturn = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int CharacterCasing
		|        {
		|            get { return (int)M_TextBox.CharacterCasing; }
		|            set { M_TextBox.CharacterCasing = (System.Windows.Forms.CharacterCasing)value; }
		|        }
		|
		|        public string PasswordChar
		|        {
		|            get { return Convert.ToString(M_TextBox.PasswordChar); }
		|            set { M_TextBox.PasswordChar = Convert.ToChar(value); }
		|        }
		|
		|        public int ScrollBars
		|        {
		|            get { return (int)M_TextBox.ScrollBars; }
		|            set { M_TextBox.ScrollBars = (System.Windows.Forms.ScrollBars)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TextBoxBase" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TextBoxBase : Control
		|    {
		|        private System.Windows.Forms.TextBoxBase m_TextBoxBase;
		|
		|        public System.Windows.Forms.TextBoxBase M_TextBoxBase
		|        {
		|            get { return m_TextBoxBase; }
		|            set
		|            {
		|                m_TextBoxBase = value;
		|                base.M_Control = m_TextBoxBase;
		|            }
		|        }
		|
		|        public TextBoxBase()
		|        {
		|        }
		|
		|        public bool AcceptsTab
		|        {
		|            get { return M_TextBoxBase.AcceptsTab; }
		|            set
		|            {
		|                M_TextBoxBase.AcceptsTab = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void AppendText(string text)
		|        {
		|            M_TextBoxBase.AppendText(text);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool AutoSize
		|        {
		|            get { return M_TextBoxBase.AutoSize; }
		|            set
		|            {
		|                M_TextBoxBase.AutoSize = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_TextBoxBase.BorderStyle; }
		|            set
		|            {
		|                M_TextBoxBase.BorderStyle = (System.Windows.Forms.BorderStyle)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool CanUndo
		|        {
		|            get { return M_TextBoxBase.CanUndo; }
		|        }
		|
		|        public void Copy()
		|        {
		|            M_TextBoxBase.Copy();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void Cut()
		|        {
		|            M_TextBoxBase.Cut();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool HideSelection
		|        {
		|            get { return M_TextBoxBase.HideSelection; }
		|            set
		|            {
		|                M_TextBoxBase.HideSelection = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int MaxLength
		|        {
		|            get { return M_TextBoxBase.MaxLength; }
		|            set
		|            {
		|                M_TextBoxBase.MaxLength = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool Modified
		|        {
		|            get { return M_TextBoxBase.Modified; }
		|            set
		|            {
		|                M_TextBoxBase.Modified = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool MultiLine
		|        {
		|            get { return M_TextBoxBase.Multiline; }
		|            set
		|            {
		|                M_TextBoxBase.Multiline = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public virtual int PreferredHeight
		|        {
		|            get { return M_TextBoxBase.PreferredHeight; }
		|        }
		|
		|        public void Paste()
		|        {
		|            M_TextBoxBase.Paste();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool ReadOnly
		|        {
		|            get { return M_TextBoxBase.ReadOnly; }
		|            set
		|            {
		|                M_TextBoxBase.ReadOnly = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void ScrollToCaret()
		|        {
		|            M_TextBoxBase.ScrollToCaret();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void SelectAll()
		|        {
		|            M_TextBoxBase.SelectAll();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public string SelectedText
		|        {
		|            get { return M_TextBoxBase.SelectedText; }
		|            set
		|            {
		|                M_TextBoxBase.SelectedText = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int SelectionLength
		|        {
		|            get { return M_TextBoxBase.SelectionLength; }
		|            set
		|            {
		|                M_TextBoxBase.SelectionLength = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int SelectionStart
		|        {
		|            get { return M_TextBoxBase.SelectionStart; }
		|            set
		|            {
		|                M_TextBoxBase.SelectionStart = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int TextLength
		|        {
		|            get { return M_TextBoxBase.TextLength; }
		|        }
		|
		|        public void Undo()
		|        {
		|            M_TextBoxBase.Undo();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool WordWrap
		|        {
		|            get { return M_TextBoxBase.WordWrap; }
		|            set
		|            {
		|                M_TextBoxBase.WordWrap = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "PropertyGrid" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class PropertyGridEx : System.Windows.Forms.PropertyGrid
		|    {
		|        public osf.PropertyGrid M_Object;
		|    }//endClass
		|
		|    public class PropertyGrid : ContainerControl
		|    {
		|        public ClPropertyGrid dll_obj;
		|        public string PropertyValueChanged;
		|        public string SelectedGridItemChanged;
		|        public PropertyGridEx M_PropertyGrid;
		|
		|        public PropertyGrid()
		|        {
		|            M_PropertyGrid = new PropertyGridEx();
		|            M_PropertyGrid.M_Object = this;
		|            base.M_ContainerControl = M_PropertyGrid;
		|            M_PropertyGrid.PropertyValueChanged += M_PropertyGrid_PropertyValueChanged;
		|            M_PropertyGrid.SelectedGridItemChanged += M_PropertyGrid_SelectedGridItemChanged;
		|            PropertyValueChanged = """";
		|            SelectedGridItemChanged = """";
		|        }
		|
		|        public PropertyGrid(osf.PropertyGrid p1)
		|        {
		|            M_PropertyGrid = p1.M_PropertyGrid;
		|            M_PropertyGrid.M_Object = this;
		|            base.M_ContainerControl = M_PropertyGrid;
		|            M_PropertyGrid.PropertyValueChanged += M_PropertyGrid_PropertyValueChanged;
		|            M_PropertyGrid.SelectedGridItemChanged += M_PropertyGrid_SelectedGridItemChanged;
		|            PropertyValueChanged = """";
		|            SelectedGridItemChanged = """";
		|        }
		|
		|        public PropertyGrid(System.Windows.Forms.PropertyGrid p1)
		|        {
		|            M_PropertyGrid = (PropertyGridEx)p1;
		|            M_PropertyGrid.M_Object = this;
		|            base.M_ContainerControl = M_PropertyGrid;
		|            M_PropertyGrid.PropertyValueChanged += M_PropertyGrid_PropertyValueChanged;
		|            M_PropertyGrid.SelectedGridItemChanged += M_PropertyGrid_SelectedGridItemChanged;
		|            PropertyValueChanged = """";
		|            SelectedGridItemChanged = """";
		|        }
		|
		|        private void M_PropertyGrid_SelectedGridItemChanged(object sender, System.Windows.Forms.SelectedGridItemChangedEventArgs e)
		|        {
		|            if (SelectedGridItemChanged.Length > 0)
		|            {
		|                SelectedGridItemChangedEventArgs SelectedGridItemChangedEventArgs1 = new SelectedGridItemChangedEventArgs();
		|                SelectedGridItemChangedEventArgs1.OldLabel = e.OldSelection.Label;
		|                SelectedGridItemChangedEventArgs1.NewLabel = e.NewSelection.Label;
		|                SelectedGridItemChangedEventArgs1.OldValue = e.OldSelection.Value;
		|                SelectedGridItemChangedEventArgs1.NewValue = e.NewSelection.Value;
		|                SelectedGridItemChangedEventArgs1.EventString = SelectedGridItemChanged;
		|                SelectedGridItemChangedEventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(SelectedGridItemChangedEventArgs1);
		|                ClSelectedGridItemChangedEventArgs ClSelectedGridItemChangedEventArgs1 = new ClSelectedGridItemChangedEventArgs(SelectedGridItemChangedEventArgs1);
		|            }
		|        }
		|
		|        public void M_PropertyGrid_PropertyValueChanged(object sender, System.Windows.Forms.PropertyValueChangedEventArgs e)
		|        {
		|            if (PropertyValueChanged.Length > 0)
		|            {
		|                PropertyValueChangedEventArgs PropertyValueChangedEventArgs1 = new PropertyValueChangedEventArgs();
		|                PropertyValueChangedEventArgs1.EventString = PropertyValueChanged;
		|                PropertyValueChangedEventArgs1.Sender = this;
		|                PropertyValueChangedEventArgs1.OldValue = e.OldValue;
		|                PropertyValueChangedEventArgs1.ChangedItem = new GridItem(e.ChangedItem);
		|                OneScriptForms.EventQueue.Add(PropertyValueChangedEventArgs1);
		|                ClPropertyValueChangedEventArgs ClPropertyValueChangedEventArgs1 = new ClPropertyValueChangedEventArgs(PropertyValueChangedEventArgs1);
		|            }
		|        }
		|
		|        public int PropertySort
		|        {
		|            get { return (int)M_PropertyGrid.PropertySort; }
		|            set { M_PropertyGrid.PropertySort = (System.Windows.Forms.PropertySort)value; }
		|        }
		|
		|        public object SelectedObject
		|        {
		|            get { return M_PropertyGrid.SelectedObject; }
		|            set
		|            {
		|                try
		|                {
		|                    M_PropertyGrid.SelectedObject = ((dynamic)value).M_Object;
		|                }
		|                catch
		|                {
		|                    M_PropertyGrid.SelectedObject = value;
		|                }
		|            }
		|        }
		|
		|        public osf.GridItem SelectedGridItem
		|        {
		|            get { return new GridItem(M_PropertyGrid.SelectedGridItem); }
		|            set { M_PropertyGrid.SelectedGridItem = value.M_GridItem; }
		|        }
		|
		|        public bool ToolbarVisible
		|        {
		|            get { return this.M_PropertyGrid.ToolbarVisible; }
		|            set { this.M_PropertyGrid.ToolbarVisible = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "GridItem" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class GridItem
		|    {
		|        public ClGridItem dll_obj;
		|        public System.Windows.Forms.GridItem M_GridItem;
		|
		|        public GridItem(osf.GridItem p1)
		|        {
		|            M_GridItem = p1.M_GridItem;
		|            OneScriptForms.AddToHashtable(M_GridItem, this);
		|        }
		|		
		|        public GridItem(System.Windows.Forms.GridItem p1)
		|        {
		|            M_GridItem = p1;
		|            OneScriptForms.AddToHashtable(M_GridItem, this);
		|        }
		|
		|        public string Label
		|        {
		|            get { return M_GridItem.Label; }
		|        }
		|
		|        public object Value
		|        {
		|            get { return M_GridItem.Value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "GridItemCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class GridItemCollection : System.Collections.ICollection
		|    {
		|        public ClGridItemCollection dll_obj;
		|        public System.Windows.Forms.GridItemCollection M_GridItemCollection;
		|
		|        public GridItemCollection(System.Windows.Forms.GridItemCollection p1)
		|        {
		|            M_GridItemCollection = p1;
		|        }
		|
		|        public osf.GridItem this[int index]
		|        {
		|            get { return new GridItem(M_GridItemCollection[index]); }
		|        }
		|
		|        public osf.GridItem this[string str]
		|        {
		|            get { return new GridItem(M_GridItemCollection[str]); }
		|        }
		|
		|        public void CopyTo(Array array, int index)
		|        {
		|            CopyTo(array, index);
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_GridItemCollection.Count; }
		|        }
		|
		|        public bool IsSynchronized
		|        {
		|            get { return IsSynchronized; }
		|        }
		|
		|        public object SyncRoot
		|        {
		|            get { return SyncRoot; }
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            return M_GridItemCollection.GetEnumerator();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ColumnHeader" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ColumnHeaderEx : System.Windows.Forms.ColumnHeader
		|    {
		|        public osf.ColumnHeader M_Object;
		|    }//endClass
		|
		|    public class ColumnHeader
		|    {
		|        public ClColumnHeader dll_obj;
		|        public ColumnHeaderEx M_ColumnHeader;
		|        public int SortType;
		|
		|        public ColumnHeader()
		|        {
		|            M_ColumnHeader = new ColumnHeaderEx();
		|            M_ColumnHeader.M_Object = this;
		|            SortType = 0;
		|        }
		|
		|        public ColumnHeader(string text, int width, System.Windows.Forms.HorizontalAlignment alignment)
		|        {
		|            M_ColumnHeader = new ColumnHeaderEx();
		|            if (text is string)
		|            {
		|                M_ColumnHeader.Text = text;
		|            }
		|            M_ColumnHeader.Width = width;
		|            M_ColumnHeader.TextAlign = (System.Windows.Forms.HorizontalAlignment)alignment;
		|            M_ColumnHeader.M_Object = this;
		|            SortType = 0;
		|        }
		|
		|        public ColumnHeader(osf.ColumnHeader p1)
		|        {
		|            M_ColumnHeader = p1.M_ColumnHeader;
		|            M_ColumnHeader.M_Object = this;
		|            SortType = 0;
		|        }
		|
		|        public ColumnHeader(System.Windows.Forms.ColumnHeader p1)
		|        {
		|            M_ColumnHeader = (ColumnHeaderEx)p1;
		|            M_ColumnHeader.M_Object = this;
		|            SortType = 0;
		|        }
		|
		|        public int Index
		|        {
		|            get { return M_ColumnHeader.Index; }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_ColumnHeader.Text; }
		|            set { M_ColumnHeader.Text = value; }
		|        }
		|
		|        public int TextAlign
		|        {
		|            get { return (int)M_ColumnHeader.TextAlign; }
		|            set { M_ColumnHeader.TextAlign = (System.Windows.Forms.HorizontalAlignment)value; }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_ColumnHeader.Width; }
		|            set { M_ColumnHeader.Width = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewSubItemCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewSubItemCollection : CollectionBase
		|    {
		|        public ClListViewSubItemCollection dll_obj;
		|        public System.Windows.Forms.ListViewItem.ListViewSubItemCollection M_ListViewSubItemCollection;
		|
		|        public ListViewSubItemCollection()
		|        {
		|        }
		|
		|        public ListViewSubItemCollection(System.Windows.Forms.ListViewItem.ListViewSubItemCollection p1)
		|        {
		|            M_ListViewSubItemCollection = p1;
		|            base.List = M_ListViewSubItemCollection;
		|        }
		|
		|        public new osf.ListViewSubItem Add(object item)
		|        {
		|            if (item is ListViewSubItem)
		|            {
		|                M_ListViewSubItemCollection.Add((((ListViewSubItem)item).M_ListViewSubItem));
		|                System.Windows.Forms.Application.DoEvents();
		|                return (ListViewSubItem)item;
		|            }
		|            ListViewSubItem ListViewSubItem1 = new ListViewSubItem("""");
		|            ListViewSubItem1.Text = Convert.ToString(item);
		|            M_ListViewSubItemCollection.Add(ListViewSubItem1.M_ListViewSubItem);
		|            System.Windows.Forms.Application.DoEvents();
		|            return (ListViewSubItem)ListViewSubItem1;
		|        }
		|
		|        public osf.ListViewSubItem Insert(int index, ListViewSubItem p1)
		|        {
		|            M_ListViewSubItemCollection.Insert(index, (System.Windows.Forms.ListViewItem.ListViewSubItem)p1.M_ListViewSubItem);
		|            return p1;
		|        }
		|
		|        public new osf.ListViewSubItem this[int index]
		|        {
		|            get { return new ListViewSubItem(M_ListViewSubItemCollection[index]); }
		|        }
		|
		|        public override object Current
		|        {
		|            get { return ((dynamic)Enumerator.Current).M_ListViewSubItem; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewSubItem" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewSubItem
		|    {
		|        public ClListViewSubItem dll_obj;
		|        public System.Windows.Forms.ListViewItem.ListViewSubItem M_ListViewSubItem;
		|
		|        public ListViewSubItem(string p1 = """")
		|        {
		|            M_ListViewSubItem = new System.Windows.Forms.ListViewItem.ListViewSubItem();
		|            M_ListViewSubItem.Text = p1;
		|            OneScriptForms.AddToHashtable(M_ListViewSubItem, this);
		|        }
		|
		|        public ListViewSubItem(osf.ListViewSubItem p1)
		|        {
		|            M_ListViewSubItem = p1.M_ListViewSubItem;
		|            OneScriptForms.AddToHashtable(M_ListViewSubItem, this);
		|        }
		|
		|        public ListViewSubItem(System.Windows.Forms.ListViewItem.ListViewSubItem p1)
		|        {
		|            M_ListViewSubItem = p1;
		|            OneScriptForms.AddToHashtable(M_ListViewSubItem, this);
		|        }
		|
		|        public osf.Color BackColor
		|        {
		|            get { return new Color(M_ListViewSubItem.BackColor); }
		|            set
		|            {
		|                M_ListViewSubItem.BackColor = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Font Font
		|        {
		|            get { return new Font(M_ListViewSubItem.Font); }
		|            set { M_ListViewSubItem.Font = value.M_Font; }
		|        }
		|
		|        public osf.Color ForeColor
		|        {
		|            get { return new Color(M_ListViewSubItem.ForeColor); }
		|            set { M_ListViewSubItem.ForeColor = value.M_Color; }
		|        }
		|
		|        public object Tag
		|        {
		|            get { return M_ListViewSubItem.Tag; }
		|            set
		|            {
		|                M_ListViewSubItem.Tag = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_ListViewSubItem.Text; }
		|            set
		|            {
		|                M_ListViewSubItem.Text = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewSelectedItemCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewSelectedItemCollection : CollectionBase
		|    {
		|        public ClListViewSelectedItemCollection dll_obj;
		|        public System.Windows.Forms.ListView.SelectedListViewItemCollection M_SelectedListViewItemCollection;
		|
		|        public ListViewSelectedItemCollection(System.Windows.Forms.ListView.SelectedListViewItemCollection p1)
		|        {
		|            M_SelectedListViewItemCollection = p1;
		|            base.List = M_SelectedListViewItemCollection;
		|        }
		|
		|        public bool Contains(ListViewItem item)
		|        {
		|            return M_SelectedListViewItemCollection.Contains((System.Windows.Forms.ListViewItem)item.M_ListViewItem);
		|        }
		|
		|        public new osf.ListViewItem this[int index]
		|        {
		|            get { return ((ListViewItemEx)M_SelectedListViewItemCollection[index]).M_Object; }
		|        }
		|
		|        public override object Current
		|        {
		|            get { return (object)((ListViewItemEx)Enumerator.Current).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewItemCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewItemCollection : CollectionBase
		|    {
		|        public ClListViewItemCollection dll_obj;
		|        public System.Windows.Forms.ListView.ListViewItemCollection M_ListViewItemCollection;
		|
		|        public ListViewItemCollection()
		|        {
		|        }
		|
		|        public ListViewItemCollection(System.Windows.Forms.ListView.ListViewItemCollection p1)
		|        {
		|            M_ListViewItemCollection = p1;
		|            base.List = M_ListViewItemCollection;
		|        }
		|
		|        public new osf.ListViewItem Add(object item)
		|        {
		|            if (item is ListViewItem)
		|            {
		|                M_ListViewItemCollection.Add((ListViewItemEx)((ListViewItem)item).M_ListViewItem);
		|                System.Windows.Forms.Application.DoEvents();
		|                return (ListViewItem)item;
		|            }
		|            ListViewItem ListViewItem1 = new ListViewItem("""", -1);
		|            ListViewItem1.Text = Convert.ToString(item);
		|            M_ListViewItemCollection.Add((ListViewItemEx)ListViewItem1.M_ListViewItem);
		|            System.Windows.Forms.Application.DoEvents();
		|            return (ListViewItem)ListViewItem1;
		|        }
		|
		|        public osf.ListViewItem Insert(int index, ListViewItem item)
		|        {
		|            M_ListViewItemCollection.Insert(index, (ListViewItemEx)item.M_ListViewItem);
		|            return item;
		|        }
		|
		|        public new osf.ListViewItem this[int index]
		|        {
		|            get { return ((ListViewItemEx)M_ListViewItemCollection[index]).M_Object; }
		|        }
		|
		|        public void Remove(ListViewItem item)
		|        {
		|            M_ListViewItemCollection.Remove((System.Windows.Forms.ListViewItem)item.M_ListViewItem);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public override object Current
		|        {
		|            get { return ((dynamic)Enumerator.Current).M_ListViewItem; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewItem" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewItemEx : System.Windows.Forms.ListViewItem
		|    {
		|        public osf.ListViewItem M_Object;
		|    }//endClass
		|
		|    public class ListViewItem
		|    {
		|        public ClListViewItem dll_obj;
		|        public ListViewItemEx M_ListViewItem;
		|
		|        public ListViewItem(string text = """", int imageIndex = -1)
		|        {
		|            M_ListViewItem = new ListViewItemEx();
		|            M_ListViewItem.M_Object = this;
		|            M_ListViewItem.Text = text;
		|            M_ListViewItem.ImageIndex = imageIndex;
		|        }
		|
		|        public ListViewItem(osf.ListViewItem p1)
		|        {
		|            M_ListViewItem = p1.M_ListViewItem;
		|            M_ListViewItem.M_Object = this;
		|        }
		|
		|        public ListViewItem(System.Windows.Forms.ListViewItem p1)
		|        {
		|            M_ListViewItem = (ListViewItemEx)p1;
		|            M_ListViewItem.M_Object = this;
		|        }
		|
		|        public osf.Color BackColor
		|        {
		|            get { return new Color(M_ListViewItem.BackColor); }
		|            set
		|            {
		|                M_ListViewItem.BackColor = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void BeginEdit()
		|        {
		|            M_ListViewItem.BeginEdit();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public osf.Rectangle Bounds
		|        {
		|            get { return new Rectangle(M_ListViewItem.Bounds); }
		|        }
		|
		|        public bool Checked
		|        {
		|            get { return M_ListViewItem.Checked; }
		|            set
		|            {
		|                M_ListViewItem.Checked = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void EnsureVisible()
		|        {
		|            M_ListViewItem.EnsureVisible();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool Focused
		|        {
		|            get { return M_ListViewItem.Focused; }
		|            set
		|            {
		|                M_ListViewItem.Focused = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Font Font
		|        {
		|            get { return new Font(M_ListViewItem.Font); }
		|            set
		|            {
		|                M_ListViewItem.Font = value.M_Font;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Color ForeColor
		|        {
		|            get { return new Color(M_ListViewItem.ForeColor); }
		|            set
		|            {
		|                M_ListViewItem.ForeColor = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_ListViewItem.ImageIndex; }
		|            set
		|            {
		|                M_ListViewItem.ImageIndex = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_ListViewItem.ImageList); }
		|        }
		|
		|        public int Index
		|        {
		|            get { return M_ListViewItem.Index; }
		|        }
		|
		|        public void Remove()
		|        {
		|            M_ListViewItem.Remove();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public bool Selected
		|        {
		|            get { return M_ListViewItem.Selected; }
		|            set
		|            {
		|                M_ListViewItem.Selected = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.ListViewSubItemCollection SubItems
		|        {
		|            get { return new ListViewSubItemCollection(M_ListViewItem.SubItems); }
		|        }
		|
		|        public object Tag
		|        {
		|            get { return M_ListViewItem.Tag; }
		|            set
		|            {
		|                M_ListViewItem.Tag = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_ListViewItem.Text; }
		|            set
		|            {
		|                M_ListViewItem.Text = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool UseItemStyleForSubItems
		|        {
		|            get { return M_ListViewItem.UseItemStyleForSubItems; }
		|            set
		|            {
		|                M_ListViewItem.UseItemStyleForSubItems = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewColumnHeaderCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewColumnHeaderCollection : CollectionBase
		|    {
		|        public ClListViewColumnHeaderCollection dll_obj;
		|        public System.Windows.Forms.ListView.ColumnHeaderCollection M_ColumnHeaderCollection;
		|
		|        public ListViewColumnHeaderCollection()
		|        {
		|        }
		|
		|        public ListViewColumnHeaderCollection(System.Windows.Forms.ListView.ColumnHeaderCollection p1)
		|        {
		|            M_ColumnHeaderCollection = p1;
		|            base.List = M_ColumnHeaderCollection;
		|        }
		|
		|        public new osf.ColumnHeader Add(object column = null)
		|        {
		|            if (column is ColumnHeader)
		|            {
		|                M_ColumnHeaderCollection.Add((ColumnHeaderEx)((ColumnHeader)column).M_ColumnHeader);
		|                System.Windows.Forms.Application.DoEvents();
		|                return (ColumnHeader)column;
		|            }
		|            ColumnHeader ColumnHeader1 = new ColumnHeader();
		|            if (column is string)
		|            {
		|                ColumnHeader1.Text = Convert.ToString(column);
		|            }
		|            M_ColumnHeaderCollection.Add((ColumnHeaderEx)ColumnHeader1.M_ColumnHeader);
		|            System.Windows.Forms.Application.DoEvents();
		|            return ColumnHeader1;
		|        }
		|
		|        public osf.ColumnHeader Insert(int index, ColumnHeader p1)
		|        {
		|            M_ColumnHeaderCollection.Insert(index, p1.M_ColumnHeader);
		|            return p1;
		|        }
		|
		|        public new osf.ColumnHeader this[int index]
		|        {
		|            get { return (ColumnHeader)((ColumnHeaderEx)M_ColumnHeaderCollection[index]).M_Object; }
		|        }
		|
		|        public void Remove(ColumnHeader column)
		|        {
		|            M_ColumnHeaderCollection.Remove((System.Windows.Forms.ColumnHeader)column.M_ColumnHeader);
		|        }
		|
		|        public override object Current
		|        {
		|            get { return (object)(ColumnHeader)((ColumnHeaderEx)Enumerator.Current).M_Object; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListViewCheckedItemCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewCheckedItemCollection : CollectionBase
		|    {
		|        public ClListViewCheckedItemCollection dll_obj;
		|        public System.Windows.Forms.ListView.CheckedListViewItemCollection M_ListViewCheckedListViewItemCollection;
		|
		|        public ListViewCheckedItemCollection()
		|        {
		|        }
		|
		|        public ListViewCheckedItemCollection(System.Windows.Forms.ListView.CheckedListViewItemCollection p1)
		|        {
		|            M_ListViewCheckedListViewItemCollection = p1;
		|            base.List = M_ListViewCheckedListViewItemCollection;
		|        }
		|
		|        public new osf.ListViewItem this[int index]
		|        {
		|            get { return ((ListViewItemEx)M_ListViewCheckedListViewItemCollection[index]).M_Object; }
		|        }
		|
		|        public override object Current
		|        {
		|            get
		|            {
		|                return (object)((ListViewItemEx)Enumerator.Current).M_Object;
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListView" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListViewEx : System.Windows.Forms.ListView
		|    {
		|        public osf.ListView M_Object;
		|    }//endClass
		|
		|    public class ListView : Control
		|    {
		|        public ClListView dll_obj;
		|        public osf.ColumnHeader SortedColumn;
		|        public int SortOrder;
		|        public bool AllowSorting;
		|        public string AfterLabelEdit;
		|        public string BeforeLabelEdit;
		|        public string SelectedIndexChanged;
		|        public string ColumnClick;
		|        public string ItemCheck;
		|        public string ItemActivate;
		|        public ListViewEx M_ListView;
		|
		|        public ListView()
		|        {
		|            M_ListView = new ListViewEx();
		|            M_ListView.M_Object = this;
		|            base.M_Control = M_ListView;
		|            M_ListView.AfterLabelEdit += M_ListView_AfterLabelEdit;
		|            M_ListView.ColumnClick += M_ListView_ColumnClick;
		|            M_ListView.SelectedIndexChanged += M_ListView_SelectedIndexChanged;
		|            M_ListView.ItemCheck += M_ListView_ItemCheck;
		|            M_ListView.ItemActivate += M_ListView_ItemActivate;
		|            M_ListView.BeforeLabelEdit += M_ListView_BeforeLabelEdit;
		|            SortedColumn = null;
		|            AllowSorting = true;
		|            Sorting = (int)System.Windows.Forms.SortOrder.None;
		|            AfterLabelEdit = """";
		|            BeforeLabelEdit = """";
		|            SelectedIndexChanged = """";
		|            ColumnClick = """";
		|            ItemCheck = """";
		|            ItemActivate = """";
		|        }
		|
		|        public ListView(osf.ListView p1)
		|        {
		|            M_ListView = p1.M_ListView;
		|            M_ListView.M_Object = this;
		|            base.M_Control = M_ListView;
		|            M_ListView.AfterLabelEdit += M_ListView_AfterLabelEdit;
		|            M_ListView.ColumnClick += M_ListView_ColumnClick;
		|            M_ListView.SelectedIndexChanged += M_ListView_SelectedIndexChanged;
		|            M_ListView.ItemCheck += M_ListView_ItemCheck;
		|            M_ListView.ItemActivate += M_ListView_ItemActivate;
		|            M_ListView.BeforeLabelEdit += M_ListView_BeforeLabelEdit;
		|            SortedColumn = null;
		|            AllowSorting = true;
		|            Sorting = (int)System.Windows.Forms.SortOrder.None;
		|            AfterLabelEdit = """";
		|            BeforeLabelEdit = """";
		|            SelectedIndexChanged = """";
		|            ColumnClick = """";
		|            ItemCheck = """";
		|            ItemActivate = """";
		|        }
		|
		|        public ListView(System.Windows.Forms.ListView p1)
		|        {
		|            M_ListView = (ListViewEx)p1;
		|            M_ListView.M_Object = this;
		|            base.M_Control = M_ListView;
		|            M_ListView.AfterLabelEdit += M_ListView_AfterLabelEdit;
		|            M_ListView.ColumnClick += M_ListView_ColumnClick;
		|            M_ListView.SelectedIndexChanged += M_ListView_SelectedIndexChanged;
		|            M_ListView.ItemCheck += M_ListView_ItemCheck;
		|            M_ListView.ItemActivate += M_ListView_ItemActivate;
		|            M_ListView.BeforeLabelEdit += M_ListView_BeforeLabelEdit;
		|            SortedColumn = null;
		|            AllowSorting = true;
		|            Sorting = (int)System.Windows.Forms.SortOrder.None;
		|            AfterLabelEdit = """";
		|            BeforeLabelEdit = """";
		|            SelectedIndexChanged = """";
		|            ColumnClick = """";
		|            ItemCheck = """";
		|            ItemActivate = """";
		|        }
		|
		|        public void M_ListView_BeforeLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
		|        {
		|            if (BeforeLabelEdit.Length > 0)
		|            {
		|                LabelEditEventArgs LabelEditEventArgs1 = new LabelEditEventArgs();
		|                LabelEditEventArgs1.Sender = this;
		|                LabelEditEventArgs1.EventString = BeforeLabelEdit;
		|                LabelEditEventArgs1.Type = ""BeforeLabelEdit"";
		|                LabelEditEventArgs1.CancelEdit = false;
		|                LabelEditEventArgs1.Item = e.Item;
		|                LabelEditEventArgs1.Label = e.Label;
		|                OneScriptForms.EventQueue.Add(LabelEditEventArgs1);
		|                ClLabelEditEventArgs ClLabelEditEventArgs1 = new ClLabelEditEventArgs(LabelEditEventArgs1);
		|                e.CancelEdit = true;
		|            }
		|        }
		|
		|        private void M_ListView_ItemActivate(object sender, System.EventArgs e)
		|        {
		|            if (ItemActivate.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = ItemActivate;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public void M_ListView_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		|        {
		|            if (ItemCheck.Length > 0)
		|            {
		|                ItemCheckEventArgs ItemCheckEventArgs1 = new ItemCheckEventArgs();
		|                ItemCheckEventArgs1.EventString = ItemCheck;
		|                ItemCheckEventArgs1.Sender = this;
		|                ItemCheckEventArgs1.CurrentValue = (int)e.CurrentValue;
		|                ItemCheckEventArgs1.Index = e.Index;
		|                ItemCheckEventArgs1.NewValue = (int)e.NewValue;
		|                OneScriptForms.EventQueue.Add(ItemCheckEventArgs1);
		|                ClItemCheckEventArgs ClItemCheckEventArgs1 = new ClItemCheckEventArgs(ItemCheckEventArgs1);
		|                e.NewValue = e.CurrentValue;
		|            }
		|        }
		|
		|        private void M_ListView_SelectedIndexChanged(object sender, System.EventArgs e)
		|        {
		|            if (SelectedIndexChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = SelectedIndexChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClKeyEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        private void M_ListView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		|        {
		|            if (ColumnClick.Length > 0)
		|            {
		|                ColumnClickEventArgs ColumnClickEventArgs1 = new ColumnClickEventArgs();
		|                ColumnClickEventArgs1.Sender = this;
		|                ColumnClickEventArgs1.EventString = ColumnClick;
		|                ColumnClickEventArgs1.Column = e.Column;
		|                OneScriptForms.EventQueue.Add(ColumnClickEventArgs1);
		|                ClColumnClickEventArgs ClColumnClickEventArgs1 = new ClColumnClickEventArgs(ColumnClickEventArgs1);
		|            }
		|            if (!AllowSorting)
		|            {
		|                return;
		|            }
		|            if (SortedColumn == null)
		|            {
		|                SortedColumn = Columns[e.Column];
		|            }
		|            else if (SortedColumn.Index != e.Column)
		|            {
		|                SortedColumn = Columns[e.Column];
		|            }
		|            if (Sorting == (int)System.Windows.Forms.SortOrder.None)
		|            {
		|                Sorting = (int)System.Windows.Forms.SortOrder.Ascending;
		|            }
		|            else if (Sorting == (int)System.Windows.Forms.SortOrder.Ascending)
		|            {
		|                Sorting = (int)System.Windows.Forms.SortOrder.Descending;
		|            }
		|            else
		|            {
		|                Sorting = (int)System.Windows.Forms.SortOrder.Ascending;
		|            }
		|            M_ListView.ListViewItemSorter = new ListViewItemSorter(Sorting, this);
		|            M_ListView.ListViewItemSorter = null;
		|        }
		|
		|        public void M_ListView_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
		|        {
		|            if (AfterLabelEdit.Length > 0)
		|            {
		|                LabelEditEventArgs LabelEditEventArgs1 = new LabelEditEventArgs();
		|                LabelEditEventArgs1.Sender = this;
		|                LabelEditEventArgs1.EventString = AfterLabelEdit;
		|                LabelEditEventArgs1.Type = ""AfterLabelEdit"";
		|                LabelEditEventArgs1.CancelEdit = false;
		|                LabelEditEventArgs1.Label = e.Label;
		|                LabelEditEventArgs1.Item = e.Item;
		|                OneScriptForms.EventQueue.Add(LabelEditEventArgs1);
		|                ClLabelEditEventArgs ClLabelEditEventArgs1 = new ClLabelEditEventArgs(LabelEditEventArgs1);
		|                e.CancelEdit = true;
		|            }
		|        }
		|
		|        public int Activation
		|        {
		|            get { return (int)M_ListView.Activation; }
		|            set { M_ListView.Activation = (System.Windows.Forms.ItemActivation)value; }
		|        }
		|
		|        public int Alignment
		|        {
		|            get { return (int)M_ListView.Alignment; }
		|            set { M_ListView.Alignment = (System.Windows.Forms.ListViewAlignment)value; }
		|        }
		|
		|        public bool AllowColumnReorder
		|        {
		|            get { return M_ListView.AllowColumnReorder; }
		|            set { M_ListView.AllowColumnReorder = value; }
		|        }
		|
		|        public bool AutoArrange
		|        {
		|            get { return M_ListView.AutoArrange; }
		|            set { M_ListView.AutoArrange = value; }
		|        }
		|
		|        public override void BeginUpdate()
		|        {
		|            M_ListView.BeginUpdate();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_ListView.BorderStyle; }
		|            set { M_ListView.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
		|        }
		|
		|        public bool CheckBoxes
		|        {
		|            get { return M_ListView.CheckBoxes; }
		|            set { M_ListView.CheckBoxes = value; }
		|        }
		|
		|        public osf.ListViewCheckedItemCollection CheckedItems
		|        {
		|            get { return new ListViewCheckedItemCollection(M_ListView.CheckedItems); }
		|        }
		|
		|        public osf.ListViewColumnHeaderCollection Columns
		|        {
		|            get { return new ListViewColumnHeaderCollection(M_ListView.Columns); }
		|        }
		|
		|        public override void EndUpdate()
		|        {
		|            M_ListView.EndUpdate();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void EnsureVisible(int index)
		|        {
		|            M_ListView.EnsureVisible(index);
		|        }
		|
		|        public osf.ListViewItem FocusedItem
		|        {
		|            get
		|            {
		|                if (M_ListView.FocusedItem != null)
		|                {
		|                    return ((ListViewItemEx)M_ListView.FocusedItem).M_Object;
		|                }
		|                return null;
		|            }
		|        }
		|
		|        public bool FullRowSelect
		|        {
		|            get { return M_ListView.FullRowSelect; }
		|            set { M_ListView.FullRowSelect = value; }
		|        }
		|
		|        public osf.ListViewItem GetItemAt(int x, int y)
		|        {
		|            System.Windows.Forms.ListViewItem item = M_ListView.GetItemAt(x, y);
		|            if (item != null)
		|            {
		|                return ((ListViewItemEx)item).M_Object;
		|            }
		|            return null;
		|        }
		|
		|        public bool GridLines
		|        {
		|            get { return M_ListView.GridLines; }
		|            set { M_ListView.GridLines = value; }
		|        }
		|
		|        public int HeaderStyle
		|        {
		|            get { return (int)M_ListView.HeaderStyle; }
		|            set { M_ListView.HeaderStyle = (System.Windows.Forms.ColumnHeaderStyle)value; }
		|        }
		|
		|        public bool HideSelection
		|        {
		|            get { return M_ListView.HideSelection; }
		|            set { M_ListView.HideSelection = value; }
		|        }
		|
		|        public bool HoverSelection
		|        {
		|            get { return M_ListView.HoverSelection; }
		|            set { M_ListView.HoverSelection = value; }
		|        }
		|
		|        public osf.ListViewItemCollection Items
		|        {
		|            get { return new ListViewItemCollection(M_ListView.Items); }
		|        }
		|
		|        public bool LabelEdit
		|        {
		|            get { return M_ListView.LabelEdit; }
		|            set { M_ListView.LabelEdit = value; }
		|        }
		|
		|        public bool LabelWrap
		|        {
		|            get { return M_ListView.LabelWrap; }
		|            set { M_ListView.LabelWrap = value; }
		|        }
		|
		|        public osf.ImageList LargeImageList
		|        {
		|            get { return new ImageList(M_ListView.LargeImageList); }
		|            set { M_ListView.LargeImageList = value.M_ImageList; }
		|        }
		|
		|        public bool MultiSelect
		|        {
		|            get { return M_ListView.MultiSelect; }
		|            set { M_ListView.MultiSelect = value; }
		|        }
		|
		|        public bool Scrollable
		|        {
		|            get { return M_ListView.Scrollable; }
		|            set { M_ListView.Scrollable = value; }
		|        }
		|
		|        public osf.ListViewSelectedItemCollection SelectedItems
		|        {
		|            get { return new ListViewSelectedItemCollection(M_ListView.SelectedItems); }
		|        }
		|
		|        public object SelectedIndices
		|        {
		|            get { return (object)""""; }
		|        }
		|
		|        public osf.ImageList SmallImageList
		|        {
		|            get
		|            {
		|                ImageList ImageList1 = new ImageList(M_ListView.SmallImageList);
		|                System.Windows.Forms.Application.DoEvents();
		|                return ImageList1;
		|            }
		|            set
		|            {
		|                M_ListView.SmallImageList = value.M_ImageList;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void Sort(ColumnHeader column, int order)
		|        {
		|            SortedColumn = column;
		|            SortOrder = order;
		|            M_ListView.ListViewItemSorter = new ListViewItemSorter(SortOrder, this);
		|            M_ListView.ListViewItemSorter = (IComparer)null;
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public int Sorting
		|        {
		|            get { return (int)M_ListView.Sorting; }
		|            set { M_ListView.Sorting = (System.Windows.Forms.SortOrder)value; }
		|        }
		|
		|        public int View
		|        {
		|            get { return (int)M_ListView.View; }
		|            set { M_ListView.View = (System.Windows.Forms.View)value; }
		|        }
		|    }//endClass
		|
		|    public class ListViewItemSorter : IComparer
		|    {
		|        private int col;
		|        private int sortOrder;
		|        public osf.ListView owner;
		|
		|        public ListViewItemSorter(int Sorting, osf.ListView p1)
		|        {
		|            sortOrder = Sorting;
		|            owner = p1;
		|            col = owner.SortedColumn.Index;
		|        }
		|
		|        public int Compare(object x, object y)
		|        {
		|            ListViewItemEx Item1 = (ListViewItemEx)x;
		|            ListViewItemEx Item2 = (ListViewItemEx)y;
		|            int sortType = owner.Columns[col].SortType;
		|            int num = 0;
		|            if (sortType == 3)//Boolean
		|            {
		|                object Boolean1 = null;
		|                object Boolean2 = null;
		|                try
		|                {
		|                    Boolean1 = (System.Boolean)Boolean.Parse(Convert.ToString(Item1.SubItems[col].Text));
		|                }
		|                catch { }
		|                try
		|                {
		|                    Boolean2 = (System.Boolean)Boolean.Parse(Convert.ToString(Item2.SubItems[col].Text));
		|                }
		|                catch { }
		|                if (Boolean1 == null && Boolean2 == null)
		|                {
		|                    num = 0;
		|                }
		|                else if (Boolean1 != null && Boolean2 == null)
		|                {
		|                    num = 1;
		|                }
		|                else if (Boolean1 == null && Boolean2 != null)
		|                {
		|                    num = -1;
		|                }
		|                else
		|                {
		|                    num = ((System.Boolean)Boolean1).CompareTo((System.Boolean)Boolean2);
		|                }
		|            }
		|            if (sortType == 2)//DateTime
		|            {
		|                object DateTime1 = null;
		|                object DateTime2 = null;
		|                try
		|                {
		|                    DateTime1 = (System.DateTime)DateTime.Parse(Convert.ToString(Item1.SubItems[col].Text));
		|                }
		|                catch { }
		|                try
		|                {
		|                    DateTime2 = (System.DateTime)DateTime.Parse(Convert.ToString(Item2.SubItems[col].Text));
		|                }
		|                catch { }
		|                if (DateTime1 == null && DateTime2 == null)
		|                {
		|                    num = 0;
		|                }
		|                else if (DateTime1 != null && DateTime2 == null)
		|                {
		|                    num = 1;
		|                }
		|                else if(DateTime1 == null && DateTime2 != null)
		|                {
		|                    num = -1;
		|                }
		|                else
		|                {
		|                    num = System.DateTime.Compare((System.DateTime)DateTime1, (System.DateTime)DateTime2);
		|                }
		|            }
		|            else if (sortType == 1)//Number
		|            {
		|                object Number1 = null;
		|                object Number2 = null;
		|                try
		|                {
		|                    Number1 = (System.Decimal)decimal.Parse(Convert.ToString(Item1.SubItems[col].Text));
		|                }
		|                catch { }
		|                try
		|                {
		|                    Number2 = (System.Decimal)decimal.Parse(Convert.ToString(Item2.SubItems[col].Text));
		|                }
		|                catch { }
		|                if (Number1 == null && Number2 == null)
		|                {
		|                    num = 0;
		|                }
		|                else if (Number1 != null && Number2 == null)
		|                {
		|                    num = 1;
		|                }
		|                else if (Number1 == null && Number2 != null)
		|                {
		|                    num = -1;
		|                }
		|                else
		|                {
		|                    num = System.Decimal.Compare((System.Decimal)Number1, (System.Decimal)Number2);
		|                }
		|            }
		|            else //(sortType == 0)// text
		|            {
		|                string str1 = Convert.ToString(Item1.SubItems[col].Text);
		|                string str2 = Convert.ToString(Item2.SubItems[col].Text);
		|                if (str1 == null && str2 == null)
		|                {
		|                    num = 0;
		|                }
		|                else if (str1 != null && str2 == null)
		|                {
		|                    num = 1;
		|                }
		|                else if (str1 == null && str2 != null)
		|                {
		|                    num = -1;
		|                }
		|                else
		|                {
		|                    num = String.Compare(str1, str2, true);
		|                }
		|            }
		|            if (sortOrder == (int)System.Windows.Forms.SortOrder.Ascending)
		|            {
		|                return num;
		|            }
		|            if (sortOrder == (int)System.Windows.Forms.SortOrder.Descending)
		|            {
		|                return checked(-num);
		|            }
		|            return num;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ContextMenuPopupEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ContextMenuPopupEventArgs : EventArgs
		|    {
		|        public new ClContextMenuPopupEventArgs dll_obj;
		|        public osf.Point Point;
		|
		|        public override bool PostEvent()
		|        {
		|            if (Sender.GetType() == typeof(osf.MenuNotifyIcon))
		|            {
		|                MenuNotifyIcon MenuNotifyIcon1 = (MenuNotifyIcon)Sender;
		|                foreach (MenuItem item in MenuNotifyIcon1.MenuItems)
		|                {
		|                    item.Visible = item.M_VisibleSaveState;
		|                }
		|                MenuNotifyIcon1.M_MenuNotifyIcon.Popup -= MenuNotifyIcon1.M_ContextMenu_Popup;
		|                MenuNotifyIcon1.Show((System.Windows.Forms.Control)MenuNotifyIcon1.M_MenuNotifyIcon.SourceControl, Point.M_Point);
		|                MenuNotifyIcon1.M_MenuNotifyIcon.Popup += MenuNotifyIcon1.M_ContextMenu_Popup;
		|
		|            }
		|            else
		|            {
		|                ContextMenu ContextMenu1 = (ContextMenu)Sender;
		|                foreach (MenuItem item in ContextMenu1.MenuItems)
		|                {
		|                    item.Visible = item.M_VisibleSaveState;
		|                }
		|                ContextMenu1.M_ContextMenu.Popup -= ContextMenu1.M_ContextMenu_Popup;
		|                ContextMenu1.Show((System.Windows.Forms.Control)ContextMenu1.M_ContextMenu.SourceControl, Point.M_Point);
		|                ContextMenu1.M_ContextMenu.Popup += ContextMenu1.M_ContextMenu_Popup;
		|            }
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DataRowView" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DataRowView
		|    {
		|        public ClDataRowView dll_obj;
		|        public System.Data.DataRowView M_DataRowView;
		|
		|        public DataRowView()
		|        {
		|        }
		|
		|        public DataRowView(osf.DataRowView p1)
		|        {
		|            M_DataRowView = p1.M_DataRowView;
		|            OneScriptForms.AddToHashtable(M_DataRowView, this);
		|        }
		|
		|        public DataRowView(System.Data.DataRowView p1)
		|        {
		|            M_DataRowView = p1;
		|            OneScriptForms.AddToHashtable(M_DataRowView, this);
		|        }
		|
		|        public void Delete()
		|        {
		|            M_DataRowView.Delete();
		|        }
		|
		|        public void EndEdit()
		|        {
		|            M_DataRowView.EndEdit();
		|        }
		|
		|        public object get_Item(object p1)
		|        {
		|            if (p1 is string)
		|            {
		|                return M_DataRowView[(string)p1];
		|            }
		|            return M_DataRowView[(int)p1];
		|        }
		|
		|        public osf.DataRow Row
		|        {
		|            get { return new DataRow(M_DataRowView.Row); }
		|        }
		|
		|        public void SetItem(object index, object item)
		|        {
		|            if (index is string)
		|            {
		|                M_DataRowView[(string)index] = item;
		|            }
		|            else
		|            {
		|                M_DataRowView[(int)index] = item;
		|            }
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListBoxSelectedIndexCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListBoxSelectedIndexCollection : CollectionBase
		|    {
		|        public ClListBoxSelectedIndexCollection dll_obj;
		|        public System.Windows.Forms.ListBox.SelectedIndexCollection M_ListBoxSelectedIndexCollection;
		|
		|        public ListBoxSelectedIndexCollection()
		|        {
		|        }
		|
		|        public ListBoxSelectedIndexCollection(System.Windows.Forms.ListBox.SelectedIndexCollection p1)
		|        {
		|            M_ListBoxSelectedIndexCollection = p1;
		|            base.List = M_ListBoxSelectedIndexCollection;
		|        }
		|
		|        public override void Clear()
		|        {
		|        }
		|
		|        public override bool Contains(object value)
		|        {
		|            return M_ListBoxSelectedIndexCollection.Contains(Convert.ToInt32(value));
		|        }
		|
		|        public override int IndexOf(object value)
		|        {
		|            return M_ListBoxSelectedIndexCollection.IndexOf(Convert.ToInt32(value));
		|        }
		|
		|        public new int this[int index]
		|        {
		|            get { return M_ListBoxSelectedIndexCollection[index]; }
		|        }
		|
		|        public new void Insert(int index, object item)
		|        {
		|        }
		|
		|        public override object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListBoxSelectedObjectCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListBoxSelectedObjectCollection : CollectionBase
		|    {
		|        public ClListBoxSelectedObjectCollection dll_obj;
		|        public System.Windows.Forms.ListBox.SelectedObjectCollection M_ListBoxSelectedObjectCollection;
		|
		|        public ListBoxSelectedObjectCollection(System.Windows.Forms.ListBox.SelectedObjectCollection p1)
		|        {
		|            M_ListBoxSelectedObjectCollection = p1;
		|            base.List = M_ListBoxSelectedObjectCollection;
		|        }
		|
		|        public override void Clear()
		|        {
		|        }
		|
		|        public override bool Contains(object value)
		|        {
		|            return M_ListBoxSelectedObjectCollection.Contains(value);
		|        }
		|
		|        public override int IndexOf(object value)
		|        {
		|            return M_ListBoxSelectedObjectCollection.IndexOf(value);
		|        }
		|
		|        public new object this[int index]
		|        {
		|            get { return M_ListBoxSelectedObjectCollection[index]; }
		|            set { M_ListBoxSelectedObjectCollection[index] = value; }
		|        }
		|
		|        public new void Insert(int index, object item)
		|        {
		|        }
		|
		|        public override object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListBoxObjectCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListBoxObjectCollection : CollectionBase
		|    {
		|        public ClListBoxObjectCollection dll_obj;
		|        public System.Windows.Forms.ListBox.ObjectCollection M_ListBoxObjectCollection;
		|
		|        public ListBoxObjectCollection()
		|        {
		|        }
		|
		|        public ListBoxObjectCollection(System.Windows.Forms.ListBox.ObjectCollection p1)
		|        {
		|            M_ListBoxObjectCollection = p1;
		|            base.List = M_ListBoxObjectCollection;
		|        }
		|
		|        public new object Add(object item)
		|        {
		|            M_ListBoxObjectCollection.Add(item);
		|            System.Windows.Forms.Application.DoEvents();
		|            return item;
		|        }
		|
		|        public new object Insert(int index, object item)
		|        {
		|            M_ListBoxObjectCollection.Insert(index, item);
		|            System.Windows.Forms.Application.DoEvents();
		|            return item;
		|        }
		|
		|        public new object this[int index]
		|        {
		|            get { return M_ListBoxObjectCollection[index]; }
		|        }
		|
		|        public new void Remove(object item)
		|        {
		|            M_ListBoxObjectCollection.Remove(item);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public override object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListItem" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListItem
		|    {
		|        public ClListItem dll_obj;
		|
		|        private object M_Value;
		|        private string M_Text;
		|        private System.Drawing.Color M_ForeColor;
		|
		|        public ListItem(string text = null, object value = null)
		|        {
		|            M_ForeColor = new System.Drawing.Color();
		|            M_Text = text;
		|            M_Value = value;
		|            OneScriptForms.AddToHashtable(this, this);
		|        }
		|		
		|        public ListItem(osf.ListItem p1)
		|        {
		|            M_ForeColor = p1.M_ForeColor;
		|            M_Text = p1.M_Text;
		|            M_Value = p1.M_Value;
		|            OneScriptForms.AddToHashtable(this, this);
		|        }
		|
		|        public osf.Color ForeColor
		|        {
		|            get { return new Color(M_ForeColor); }
		|            set
		|            {
		|                M_ForeColor = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public object Value
		|        {
		|            get
		|            {
		|                if (M_Value != null)
		|                {
		|                    return M_Value;
		|                }
		|                if (M_Text != null)
		|                {
		|                    return M_Text;
		|                }
		|                return """";
		|            }
		|            set
		|            {
		|                M_Value = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Text
		|        {
		|            get
		|            {
		|                if (M_Text != null)
		|                {
		|                    return M_Text;
		|                }
		|                if (M_Value != null)
		|                {
		|                    return Convert.ToString(M_Value);
		|                }
		|                return """";
		|            }
		|            set
		|            {
		|                M_Text = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public override string ToString()
		|        {
		|            return Text;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListBoxEx : System.Windows.Forms.ListBox
		|    {
		|        public osf.ListBox M_Object;
		|    }//endClass
		|
		|    public class ListBox : ListControl
		|    {
		|        public ClListBox dll_obj;
		|        public string M_SelectedIndexChanged;
		|        public ListBoxEx M_ListBox;
		|        public osf.Color M_SelectedBackColor;
		|        public osf.Color M_SelectedForeColor;
		|
		|        public ListBox()
		|        {
		|            M_ListBox = new ListBoxEx();
		|            M_ListBox.M_Object = this;
		|            base.M_ListControl = M_ListBox;
		|            M_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		|            M_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
		|            M_ListBox.DrawItem += M_ListBox_DrawItem;
		|            M_ListBox.MeasureItem += M_ListBox_MeasureItem;
		|            M_ListBox.FontChanged += M_ListBox_FontChanged;
		|            M_ListBox.ItemHeight = FontHeight;
		|            M_SelectedForeColor = new Color(SystemColors.HighlightText);
		|            M_SelectedBackColor = new Color(SystemColors.Highlight);
		|            M_SelectedIndexChanged = """";
		|        }
		|
		|        public ListBox(osf.ListBox p1)
		|        {
		|            M_ListBox = p1.M_ListBox;
		|            M_ListBox.M_Object = this;
		|            base.M_ListControl = M_ListBox;
		|            M_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		|            M_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
		|            M_ListBox.DrawItem += M_ListBox_DrawItem;
		|            M_ListBox.MeasureItem += M_ListBox_MeasureItem;
		|            M_ListBox.FontChanged += M_ListBox_FontChanged;
		|            M_ListBox.ItemHeight = FontHeight;
		|            M_SelectedForeColor = new Color(SystemColors.HighlightText);
		|            M_SelectedBackColor = new Color(SystemColors.Highlight);
		|            M_SelectedIndexChanged = """";
		|        }
		|
		|        public ListBox(System.Windows.Forms.ListBox p1)
		|        {
		|            M_ListBox = (ListBoxEx)p1;
		|            M_ListBox.M_Object = this;
		|            base.M_ListControl = M_ListBox;
		|            M_ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
		|            M_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
		|            M_ListBox.DrawItem += M_ListBox_DrawItem;
		|            M_ListBox.MeasureItem += M_ListBox_MeasureItem;
		|            M_ListBox.FontChanged += M_ListBox_FontChanged;
		|            M_ListBox.ItemHeight = FontHeight;
		|            M_SelectedForeColor = new Color(SystemColors.HighlightText);
		|            M_SelectedBackColor = new Color(SystemColors.Highlight);
		|            M_SelectedIndexChanged = """";
		|        }
		|		
		|        private void M_ListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		|        {
		|            if (M_SelectedIndexChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = M_SelectedIndexChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public void M_ListBox_FontChanged(object sender, System.EventArgs e)
		|        {
		|            M_ListBox.ItemHeight = ((osf.Control)M_ListBox.M_Object).FontHeight;
		|        }
		|
		|        public void M_ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
		|        {
		|            e.ItemHeight = ((osf.Control)M_ListBox.M_Object).FontHeight;
		|        }
		|
		|        public void M_ListBox_DrawItem(object sender, DrawItemEventArgs e)
		|        {
		|            if (e.Index == -1)
		|            {
		|                return;
		|            }
		|            e.DrawBackground();
		|            e.DrawFocusRectangle();
		|            dynamic item = M_ListBox.Items[e.Index];
		|            System.Type type = item.GetType();
		|            System.Drawing.Color color1 = M_ListBox.ForeColor;
		|            PropertyInfo propertyForeColor = type.GetProperty(""ForeColor"");
		|            Color colorForeColor = null;
		|            if (propertyForeColor != null)
		|            {
		|                try
		|                {
		|                    colorForeColor = (Color)propertyForeColor.GetValue(Items[e.Index], (object[])null);
		|                }
		|                catch
		|                {
		|                    colorForeColor = ((ClColor)propertyForeColor.GetValue(Items[e.Index], (object[])null)).Base_obj;
		|                }
		|            }
		|
		|            if ((e.State & System.Windows.Forms.DrawItemState.Disabled) == System.Windows.Forms.DrawItemState.Disabled)
		|            {
		|                try
		|                {
		|                    if (!colorForeColor.IsEmpty)
		|                    {
		|                        color1 = colorForeColor.M_Color;
		|                    }
		|                }
		|                catch
		|                {
		|                    color1 = System.Drawing.SystemColors.GrayText;
		|                }
		|            }
		|            else if ((e.State & System.Windows.Forms.DrawItemState.Selected) == System.Windows.Forms.DrawItemState.Selected)
		|            {
		|                color1 = System.Drawing.SystemColors.HighlightText;
		|            }
		|            else
		|            {
		|                try
		|                {
		|                    if (!colorForeColor.IsEmpty)
		|                    {
		|                        color1 = colorForeColor.M_Color;
		|                    }
		|                }
		|                catch
		|                {
		|                }
		|            }
		|            string s = item.ToString();
		|            System.Data.DataRowView drv;
		|            try
		|            {
		|                drv = (System.Data.DataRowView)item;
		|            }
		|            catch
		|            {
		|                drv = null;
		|            }
		|            if (drv != null)
		|            {
		|                s = drv[M_ListBox.DisplayMember].ToString();
		|            }
		|            else
		|            {
		|                PropertyInfo property1 = type.GetProperty(M_ListBox.DisplayMember);
		|                if (property1 != null)
		|                {
		|                    s = Convert.ToString(property1.GetValue(Items[e.Index], (object[])null));
		|                }
		|            }
		|            e.Graphics.DrawString(s, M_ListBox.Font, (System.Drawing.Brush)new System.Drawing.SolidBrush(color1), (float)e.Bounds.X, (float)e.Bounds.Y);
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_ListBox.BorderStyle; }
		|            set { M_ListBox.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
		|        }
		|
		|        public int ColumnWidth
		|        {
		|            get { return M_ListBox.ColumnWidth; }
		|            set { M_ListBox.ColumnWidth = value; }
		|        }
		|
		|        public bool GetSelected(int index)
		|        {
		|            return M_ListBox.GetSelected(index);
		|        }
		|
		|        public int HorizontalExtent
		|        {
		|            get { return M_ListBox.HorizontalExtent; }
		|            set { M_ListBox.HorizontalExtent = value; }
		|        }
		|
		|        public bool HorizontalScrollbar
		|        {
		|            get { return M_ListBox.HorizontalScrollbar; }
		|            set
		|            {
		|                System.Drawing.Graphics g = M_ListBox.CreateGraphics();
		|                int hzSize = (int)g.MeasureString(M_ListBox.Items[M_ListBox.Items.Count - 1].ToString(), M_ListBox.Font).Width;
		|                M_ListBox.HorizontalExtent = hzSize + 10;
		|                M_ListBox.HorizontalScrollbar = value;
		|            }
		|        }
		|
		|        public bool IntegralHeight
		|        {
		|            get { return M_ListBox.IntegralHeight; }
		|            set { M_ListBox.IntegralHeight = value; }
		|        }
		|
		|        public int ItemHeight
		|        {
		|            get { return M_ListBox.ItemHeight; }
		|            set { M_ListBox.ItemHeight = value; }
		|        }
		|
		|        public osf.ListBoxObjectCollection Items
		|        {
		|            get { return new ListBoxObjectCollection(M_ListBox.Items); }
		|        }
		|
		|        public bool MultiColumn
		|        {
		|            get { return M_ListBox.MultiColumn; }
		|            set { M_ListBox.MultiColumn = value; }
		|        }
		|
		|        public bool ScrollAlwaysVisible
		|        {
		|            get { return M_ListBox.ScrollAlwaysVisible; }
		|            set { M_ListBox.ScrollAlwaysVisible = value; }
		|        }
		|
		|        public int SelectedIndex
		|        {
		|            get { return M_ListBox.SelectedIndex; }
		|            set { M_ListBox.SelectedIndex = value; }
		|        }
		|
		|        public string SelectedIndexChanged
		|        {
		|            get { return M_SelectedIndexChanged; }
		|            set { M_SelectedIndexChanged = value; }
		|        }
		|
		|        public osf.ListBoxSelectedIndexCollection SelectedIndices
		|        {
		|            get { return new ListBoxSelectedIndexCollection(M_ListBox.SelectedIndices); }
		|        }
		|
		|        public object SelectedItem
		|        {
		|            get { return M_ListBox.SelectedItem; }
		|            set
		|            {
		|                M_ListBox.SelectedItem = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.ListBoxSelectedObjectCollection SelectedItems
		|        {
		|            get { return new ListBoxSelectedObjectCollection(M_ListBox.SelectedItems); }
		|        }
		|
		|        public int SelectionMode
		|        {
		|            get { return (int)M_ListBox.SelectionMode; }
		|            set { M_ListBox.SelectionMode = (System.Windows.Forms.SelectionMode)value; }
		|        }
		|
		|        public void SetSelected(int index, bool value)
		|        {
		|            M_ListBox.SetSelected(index, value);
		|        }
		|
		|        public bool Sorted
		|        {
		|            get { return M_ListBox.Sorted; }
		|            set { M_ListBox.Sorted = value; }
		|        }
		|
		|        public int TopIndex
		|        {
		|            get { return M_ListBox.TopIndex; }
		|            set { M_ListBox.TopIndex = value; }
		|        }
		|
		|        public bool UseTabStops
		|        {
		|            get { return M_ListBox.UseTabStops; }
		|            set { M_ListBox.UseTabStops = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ListControl" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ListControl : Control
		|    {
		|        private System.Windows.Forms.ListControl m_ListControl;
		|
		|        public System.Windows.Forms.ListControl M_ListControl
		|        {
		|            get { return m_ListControl; }
		|            set
		|            {
		|                m_ListControl = value;
		|                base.M_Control = m_ListControl;
		|            }
		|        }
		|
		|        public ListControl()
		|        {
		|        }
		|
		|        public object DataSource
		|        {
		|            get
		|            {
		|                object obj;
		|                try
		|                {
		|                    obj = ((dynamic)M_ListControl.DataSource).M_Object;
		|                }
		|                catch
		|                {
		|                    obj = M_ListControl.DataSource;
		|                }
		|                return obj;
		|            }
		|            set
		|            {
		|                M_ListControl.DataSource = null;
		|                try
		|                {
		|                    System.Type Type1 = value.GetType();
		|                    string strType1 = Type1.ToString();
		|                    string str1 = strType1.Substring(strType1.LastIndexOf(""."") + 1);
		|                    M_ListControl.DataSource = Type1.GetField(""M_"" + str1).GetValue(value);
		|                }
		|                catch
		|                {
		|                    M_ListControl.DataSource = value;
		|                }
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string DisplayMember
		|        {
		|            get { return M_ListControl.DisplayMember; }
		|            set
		|            {
		|                M_ListControl.DisplayMember = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public object SelectedValue
		|        {
		|            get { return M_ListControl.SelectedValue; }
		|            set
		|            {
		|                M_ListControl.SelectedValue = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string ValueMember
		|        {
		|            get { return M_ListControl.ValueMember; }
		|            set
		|            {
		|                M_ListControl.ValueMember = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ImageList" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ImageList
		|    {
		|        public ClImageList dll_obj;
		|        public System.Windows.Forms.ImageList M_ImageList;
		|
		|        public ImageList()
		|        {
		|            M_ImageList = new System.Windows.Forms.ImageList();
		|            OneScriptForms.AddToHashtable(M_ImageList, this);
		|        }
		|		
		|        public ImageList(osf.ImageList p1)
		|        {
		|            M_ImageList = p1.M_ImageList;
		|            OneScriptForms.AddToHashtable(M_ImageList, this);
		|        }
		|
		|        public ImageList(System.Windows.Forms.ImageList p1)
		|        {
		|            M_ImageList = p1;
		|            OneScriptForms.AddToHashtable(M_ImageList, this);
		|        }
		|
		|        public int ColorDepth
		|        {
		|            get { return (int)M_ImageList.ColorDepth; }
		|            set { M_ImageList.ColorDepth = (System.Windows.Forms.ColorDepth)value; }
		|        }
		|
		|        public osf.ImageCollection Images
		|        {
		|            get { return new ImageCollection(M_ImageList.Images); }
		|        }
		|
		|        public osf.Size ImageSize
		|        {
		|            get { return new Size(M_ImageList.ImageSize); }
		|            set { M_ImageList.ImageSize = value.M_Size; }
		|        }
		|
		|        public osf.Color TransparentColor
		|        {
		|            get { return new Color(M_ImageList.TransparentColor); }
		|            set { M_ImageList.TransparentColor = value.M_Color; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "StreamReader" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class StreamReader
		|    {
		|        public ClStreamReader dll_obj;
		|        public System.IO.StreamReader M_StreamReader;
		|
		|        public StreamReader(string p1)
		|        {
		|            M_StreamReader = new System.IO.StreamReader(p1);
		|        }
		|
		|        public StreamReader(osf.StreamReader p1)
		|        {
		|            M_StreamReader = p1.M_StreamReader;
		|        }
		|		
		|        public StreamReader(System.IO.StreamReader p1)
		|        {
		|            M_StreamReader = p1;
		|        }
		|
		|        public void Close()
		|        {
		|            M_StreamReader.Close();
		|        }
		|
		|        public int Peek()
		|        {
		|            return M_StreamReader.Peek();
		|        }
		|
		|        public string ReadLine()
		|        {
		|            return M_StreamReader.ReadLine();
		|        }
		|
		|        public string ReadToEnd()
		|        {
		|            return M_StreamReader.ReadToEnd();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ImageCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ImageCollection : CollectionBase
		|    {
		|        public ClImageCollection dll_obj;
		|        public System.Windows.Forms.ImageList.ImageCollection M_ImageCollection;
		|
		|        public ImageCollection()
		|        {
		|        }
		|
		|        public ImageCollection(System.Windows.Forms.ImageList.ImageCollection p1)
		|        {
		|            M_ImageCollection = p1;
		|            base.List = M_ImageCollection;
		|        }
		|
		|        public int Add(Image image, Color color = null)
		|        {
		|            if (color == null)
		|            {
		|                return M_ImageCollection.Add(image.M_Image, System.Drawing.Color.Empty);
		|            }
		|            return M_ImageCollection.Add(image.M_Image, color.M_Color);
		|        }
		|
		|        public int AddStrip(Image image)
		|        {
		|            return M_ImageCollection.AddStrip(image.M_Image);
		|        }
		|
		|        public new osf.Image this[int p1]
		|        {
		|            get { return (Image)new Bitmap((System.Drawing.Bitmap)M_ImageCollection[p1]); }
		|        }
		|
		|        public override object Current
		|        {
		|            get { return new Image((System.Drawing.Image)Enumerator.Current); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TabControl" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TabControlEx : System.Windows.Forms.TabControl
		|    {
		|        public osf.TabControl M_Object;
		|    }//endClass
		|
		|    public class TabControl : Control
		|    {
		|        public ClTabControl dll_obj;
		|        public string M_SelectedIndexChanged;
		|        public TabControlEx M_TabControl;
		|
		|        public TabControl()
		|        {
		|            M_TabControl = new TabControlEx();
		|            M_TabControl.M_Object = this;
		|            base.M_Control = M_TabControl;
		|            M_TabControl.SelectedIndexChanged += M_TabControl_SelectedIndexChanged;
		|            M_SelectedIndexChanged = """";
		|        }
		|
		|        public TabControl(osf.TabControl p1)
		|        {
		|            M_TabControl = p1.M_TabControl;
		|            M_TabControl.M_Object = this;
		|            base.M_Control = M_TabControl;
		|            M_TabControl.SelectedIndexChanged += M_TabControl_SelectedIndexChanged;
		|            M_SelectedIndexChanged = """";
		|        }
		|
		|        public TabControl(System.Windows.Forms.TabControl p1)
		|        {
		|            M_TabControl = (TabControlEx)p1;
		|            M_TabControl.M_Object = this;
		|            base.M_Control = M_TabControl;
		|            M_TabControl.SelectedIndexChanged += M_TabControl_SelectedIndexChanged;
		|            M_SelectedIndexChanged = """";
		|        }
		|
		|        private void M_TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		|        {
		|            if (M_SelectedIndexChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = M_SelectedIndexChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public int Alignment
		|        {
		|            get { return (int)M_TabControl.Alignment; }
		|            set { M_TabControl.Alignment = (System.Windows.Forms.TabAlignment)value; }
		|        }
		|
		|        public int Appearance
		|        {
		|            get { return (int)M_TabControl.Appearance; }
		|            set { M_TabControl.Appearance = (System.Windows.Forms.TabAppearance)value; }
		|        }
		|
		|        public osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_TabControl.ImageList); }
		|            set { M_TabControl.ImageList = value.M_ImageList; }
		|        }
		|
		|        public osf.Size ItemSize
		|        {
		|            get { return new Size(M_TabControl.ItemSize); }
		|            set { M_TabControl.ItemSize = value.M_Size; }
		|        }
		|
		|        public bool MultiLine
		|        {
		|            get { return M_TabControl.Multiline; }
		|            set { M_TabControl.Multiline = value; }
		|        }
		|
		|        public int SelectedIndex
		|        {
		|            get { return M_TabControl.SelectedIndex; }
		|            set { M_TabControl.SelectedIndex = value; }
		|        }
		|
		|        public string SelectedIndexChanged
		|        {
		|            get { return M_SelectedIndexChanged; }
		|            set { M_SelectedIndexChanged = value; }
		|        }
		|
		|        public osf.TabPage SelectedTab
		|        {
		|            get
		|            {
		|                if (M_TabControl.SelectedTab == null)
		|                {
		|                    return null;
		|                }
		|                return (osf.TabPage)((TabPageEx)M_TabControl.SelectedTab).M_Object;
		|            }
		|            set { M_TabControl.SelectedTab = (System.Windows.Forms.TabPage)value.M_TabPage; }
		|        }
		|
		|        public bool ShowToolTips
		|        {
		|            get { return M_TabControl.ShowToolTips; }
		|            set { M_TabControl.ShowToolTips = value; }
		|        }
		|
		|        public int SizeMode
		|        {
		|            get { return (int)M_TabControl.SizeMode; }
		|            set { M_TabControl.SizeMode = (System.Windows.Forms.TabSizeMode)value; }
		|        }
		|
		|        public osf.TabPageCollection TabPages
		|        {
		|            get { return new TabPageCollection(M_TabControl.TabPages); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TabPage" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TabPageEx : System.Windows.Forms.TabPage
		|    {
		|        public osf.TabPage M_Object;
		|    }//endClass
		|
		|    public class TabPage : Panel
		|    {
		|        public new ClTabPage dll_obj;
		|        public TabPageEx M_TabPage;
		|
		|        public TabPage(string p1 = null)
		|        {
		|            M_TabPage = new TabPageEx();
		|            M_TabPage.M_Object = this;
		|            base.M_ScrollableControl = M_TabPage;
		|            if (p1 != null)
		|            {
		|                M_TabPage.Text = p1;
		|            }
		|        }
		|		
		|        public TabPage(osf.TabPage p1)
		|        {
		|            M_TabPage = p1.M_TabPage;
		|            M_TabPage.M_Object = this;
		|            base.M_ScrollableControl = M_TabPage;
		|        }
		|
		|        public TabPage(System.Windows.Forms.TabPage p1)
		|        {
		|            M_TabPage = (TabPageEx)p1;
		|            M_TabPage.M_Object = this;
		|            base.M_ScrollableControl = M_TabPage;
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_TabPage.ImageIndex; }
		|            set { M_TabPage.ImageIndex = value; }
		|        }
		|
		|        public string ToolTipText
		|        {
		|            get { return M_TabPage.ToolTipText; }
		|            set { M_TabPage.ToolTipText = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TabPageCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TabPageCollection : IEnumerable, IEnumerator
		|    {
		|        public ClTabPageCollection dll_obj;
		|        public System.Windows.Forms.TabControl.TabPageCollection M_TabPageCollection;
		|        private System.Collections.IEnumerator Enumerator;
		|
		|        public TabPageCollection(System.Windows.Forms.TabControl.TabPageCollection p1)
		|        {
		|            M_TabPageCollection = p1;
		|        }
		|
		|        public TabPage Add(TabPage page)
		|        {
		|            M_TabPageCollection.Add(page.M_TabPage);
		|            return page;
		|        }
		|
		|        public void Clear()
		|        {
		|            M_TabPageCollection.Clear();
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_TabPageCollection.Count; }
		|        }
		|
		|        public int IndexOf(TabPage page)
		|        {
		|            return M_TabPageCollection.IndexOf((System.Windows.Forms.TabPage)page.M_TabPage);
		|        }
		|
		|        public osf.TabPage Insert(int index, object page)
		|        {
		|            if (page is TabPage)
		|            {
		|                M_TabPageCollection.Insert(index, ((dynamic)page).M_TabPage);
		|                System.Windows.Forms.Application.DoEvents();
		|                return (TabPage)page;
		|            }
		|            if (!(page is string))
		|            {
		|                return null;
		|            }
		|            TabPage TabPage1 = new TabPage((string)null);
		|            TabPage1.Text = Convert.ToString(page);
		|            M_TabPageCollection.Insert(index, (System.Windows.Forms.TabPage)TabPage1.M_TabPage);
		|            return TabPage1;
		|        }
		|
		|        public osf.TabPage this[int index]
		|        {
		|            get { return (TabPage)((TabPageEx)M_TabPageCollection[index]).M_Object; }
		|        }
		|
		|        public void Remove(TabPage page)
		|        {
		|            M_TabPageCollection.Remove((System.Windows.Forms.TabPage)page.M_TabPage);
		|        }
		|
		|        public void RemoveAt(int index)
		|        {
		|            M_TabPageCollection.RemoveAt(index);
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_TabPageCollection.GetEnumerator();
		|            return (IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return ((TabPageEx)Enumerator.Current).M_Object; }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Panel" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class PanelEx : System.Windows.Forms.Panel
		|    {
		|        public osf.Panel M_Object;
		|    }//endClass
		|
		|    public class Panel : ScrollableControl
		|    {
		|        public ClPanel dll_obj;
		|        public PanelEx M_Panel;
		|
		|        public Panel()
		|        {
		|            M_Panel = new PanelEx();
		|            M_Panel.M_Object = this;
		|            base.M_ScrollableControl = M_Panel;
		|        }
		|		
		|        public Panel(osf.Panel p1)
		|        {
		|            M_Panel = p1.M_Panel;
		|            M_Panel.M_Object = this;
		|            base.M_ScrollableControl = M_Panel;
		|        }
		|
		|        public Panel(System.Windows.Forms.Panel p1)
		|        {
		|            M_Panel = (PanelEx)p1;
		|            M_Panel.M_Object = this;
		|            base.M_ScrollableControl = M_Panel;
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_Panel.BorderStyle; }
		|            set { M_Panel.BorderStyle = (System.Windows.Forms.BorderStyle)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "HScrollBar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class HScrollBarEx : System.Windows.Forms.HScrollBar
		|    {
		|        public osf.HScrollBar M_Object;
		|    }//endClass
		|
		|    public class HScrollBar : ScrollBar
		|    {
		|        public ClHScrollBar dll_obj;
		|        public HScrollBarEx M_HScrollBar;
		|
		|        public HScrollBar()
		|        {
		|            M_HScrollBar = new HScrollBarEx();
		|            M_HScrollBar.M_Object = this;
		|            base.M_Control = M_HScrollBar;
		|            base.v_h_ScrollBar = M_HScrollBar;
		|            base.LargeChange = 1;
		|            M_HScrollBar.ValueChanged += base.M_ScrollBar_ValueChanged;
		|            M_HScrollBar.Scroll += base.M_ScrollBar_Scroll;
		|            ValueChanged = """";
		|            Scroll = """";
		|        }
		|
		|        public HScrollBar(osf.HScrollBar p1)
		|        {
		|            M_HScrollBar = p1.M_HScrollBar;
		|            M_HScrollBar.M_Object = this;
		|            base.M_Control = M_HScrollBar;
		|            base.v_h_ScrollBar = M_HScrollBar;
		|            base.LargeChange = 1;
		|            M_HScrollBar.ValueChanged += base.M_ScrollBar_ValueChanged;
		|            M_HScrollBar.Scroll += base.M_ScrollBar_Scroll;
		|            ValueChanged = """";
		|            Scroll = """";
		|        }
		|
		|        public HScrollBar(System.Windows.Forms.HScrollBar p1)
		|        {
		|            M_HScrollBar = (HScrollBarEx)p1;
		|            M_HScrollBar.M_Object = this;
		|            base.M_Control = M_HScrollBar;
		|            base.v_h_ScrollBar = M_HScrollBar;
		|            base.LargeChange = 1;
		|            M_HScrollBar.ValueChanged += base.M_ScrollBar_ValueChanged;
		|            M_HScrollBar.Scroll += base.M_ScrollBar_Scroll;
		|            ValueChanged = """";
		|            Scroll = """";
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "VScrollBar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class VScrollBarEx : System.Windows.Forms.VScrollBar
		|    {
		|        public osf.VScrollBar M_Object;
		|    }//endClass
		|
		|    public class VScrollBar : ScrollBar
		|    {
		|        public ClVScrollBar dll_obj;
		|        public VScrollBarEx M_VScrollBar;
		|
		|        public VScrollBar()
		|        {
		|            M_VScrollBar = new VScrollBarEx();
		|            M_VScrollBar.M_Object = this;
		|            base.M_Control = M_VScrollBar;
		|            base.v_h_ScrollBar = M_VScrollBar;
		|            base.LargeChange = 1;
		|            M_VScrollBar.ValueChanged += base.M_ScrollBar_ValueChanged;
		|            M_VScrollBar.Scroll += base.M_ScrollBar_Scroll;
		|            ValueChanged = """";
		|            Scroll = """";
		|        }
		|
		|        public VScrollBar(osf.VScrollBar p1)
		|        {
		|            M_VScrollBar = p1.M_VScrollBar;
		|            M_VScrollBar.M_Object = this;
		|            base.M_Control = M_VScrollBar;
		|            base.v_h_ScrollBar = M_VScrollBar;
		|            base.LargeChange = 1;
		|            M_VScrollBar.ValueChanged += base.M_ScrollBar_ValueChanged;
		|            M_VScrollBar.Scroll += base.M_ScrollBar_Scroll;
		|            ValueChanged = """";
		|            Scroll = """";
		|        }
		|
		|        public VScrollBar(System.Windows.Forms.VScrollBar p1)
		|        {
		|            M_VScrollBar = (VScrollBarEx)p1;
		|            M_VScrollBar.M_Object = this;
		|            base.M_Control = M_VScrollBar;
		|            base.v_h_ScrollBar = M_VScrollBar;
		|            base.LargeChange = 1;
		|            M_VScrollBar.ValueChanged += base.M_ScrollBar_ValueChanged;
		|            M_VScrollBar.Scroll += base.M_ScrollBar_Scroll;
		|            ValueChanged = """";
		|            Scroll = """";
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ScrollBar" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ScrollBar : Control
		|    {
		|        public string ValueChanged;
		|        public string Scroll;
		|        public ClArrayList ManagedProperties = new ClArrayList();
		|        public dynamic v_h_ScrollBar;
		|
		|        public System.Windows.Forms.ScrollBar M_ScrollBar
		|        {
		|            get { return v_h_ScrollBar; }
		|            set
		|            {
		|                v_h_ScrollBar = value;
		|                base.M_Control = v_h_ScrollBar;
		|            }
		|        }
		|
		|        public ScrollBar()
		|        {
		|        }
		|
		|        public void M_ScrollBar_ValueChanged(object sender, System.EventArgs e)
		|        {
		|            if (ValueChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = ValueChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        public void M_ScrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		|        {
		|            if (Scroll.Length > 0)
		|            {
		|                ScrollEventArgs ScrollEventArgs1 = new ScrollEventArgs();
		|                ScrollEventArgs1.Sender = this;
		|                ScrollEventArgs1.EventString = Scroll;
		|                ScrollEventArgs1.OldValue = e.OldValue;
		|                ScrollEventArgs1.NewValue = e.NewValue;
		|                ScrollEventArgs1.ScrollOrientation = (int)e.ScrollOrientation;
		|                ScrollEventArgs1.EventType = (int)e.Type;
		|                OneScriptForms.EventQueue.Add(ScrollEventArgs1);
		|                ClScrollEventArgs ClScrollEventArgs1 = new ClScrollEventArgs(ScrollEventArgs1);
		|
		|                ScrollBarManagedProperties();
		|            }
		|        }
		|
		|        public int LargeChange
		|        {
		|            get { return M_ScrollBar.LargeChange; }
		|            set
		|            {
		|                M_ScrollBar.LargeChange = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int Maximum
		|        {
		|            get { return M_ScrollBar.Maximum; }
		|            set
		|            {
		|                M_ScrollBar.Maximum = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int Minimum
		|        {
		|            get { return M_ScrollBar.Minimum; }
		|            set
		|            {
		|                M_ScrollBar.Minimum = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int SmallChange
		|        {
		|            get { return M_ScrollBar.SmallChange; }
		|            set
		|            {
		|                M_ScrollBar.SmallChange = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int Value
		|        {
		|            get { return M_ScrollBar.Value; }
		|            set
		|            {
		|                M_ScrollBar.Value = value;
		|                ScrollBarManagedProperties();
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void ScrollBarManagedProperties()
		|        {
		|            if (ManagedProperties.Count > 0)
		|            {
		|                foreach (ClManagedProperty ClManagedProperty1 in ManagedProperties.Base_obj)
		|                {
		|                    object obj1 = ClManagedProperty1.ManagedObject;
		|                    string prop1 = """";
		|                    float ratio1 = 1.0f;
		|                    if (ClManagedProperty1.Ratio == null)
		|                    {
		|                    }
		|                    else
		|                    {
		|                        ratio1 = Convert.ToSingle(ClManagedProperty1.Ratio.AsNumber());
		|                    }
		|                    System.Reflection.PropertyInfo[] myPropertyInfo;
		|                    myPropertyInfo = obj1.GetType().GetProperties();
		|                    for (int i = 0; i < myPropertyInfo.Length; i++)
		|                    {
		|                        System.Collections.Generic.IEnumerable<System.Reflection.CustomAttributeData> CustomAttributeData1 =
		|                            myPropertyInfo[i].CustomAttributes;
		|                        foreach (System.Reflection.CustomAttributeData CustomAttribute1 in CustomAttributeData1)
		|                        {
		|                            string quote = ""\"""";
		|                            string text = CustomAttribute1.ToString();
		|                            if (text.Contains(""[ScriptEngine.Machine.Contexts.ContextPropertyAttribute("" + quote))
		|                            {
		|                                text = text.Replace(""[ScriptEngine.Machine.Contexts.ContextPropertyAttribute("" + quote, """");
		|                                text = text.Replace(quote + "", "" + quote, "" "");
		|                                text = text.Replace(quote + "")]"", """");
		|                                string[] stringSeparators = new string[] { };
		|                                string[] result = text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
		|                                if (ClManagedProperty1.ManagedProperty == result[0])
		|                                {
		|                                    prop1 = result[1];
		|                                    break;
		|                                }
		|                            }
		|                        }
		|                    }
		|                    System.Type Type1 = obj1.GetType();
		|                    float _Value = Convert.ToSingle(v_h_ScrollBar.Value);
		|                    int res = Convert.ToInt32(ratio1 * _Value);
		|                    if (Type1.GetProperty(prop1).PropertyType.ToString() != ""System.String"")
		|                    {
		|                        Type1.GetProperty(prop1).SetValue(obj1, res);
		|                    }
		|                    else
		|                    {
		|                        Type1.GetProperty(prop1).SetValue(obj1, res.ToString());
		|                    }
		|                }
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Environment" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Environment
		|    {
		|        public ClEnvironment dll_obj;
		|
		|        public string CommandLine
		|        {
		|            get { return System.Environment.CommandLine; }
		|        }
		|
		|        public osf.Version Version
		|        {
		|            get { return new Version(Assembly.GetExecutingAssembly().GetName().Version); }
		|        }
		|		
		|        public string GetFolderPath(int p1)
		|        {
		|            return System.Environment.GetFolderPath((System.Environment.SpecialFolder)p1);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MenuItemCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MenuItemCollection : CollectionBase
		|    {
		|        public ClMenuItemCollection dll_obj;
		|        public System.Windows.Forms.Menu.MenuItemCollection M_MenuItemCollection;
		|
		|        public MenuItemCollection()
		|        {
		|        }
		|
		|        public MenuItemCollection(System.Windows.Forms.Menu.MenuItemCollection p1)
		|        {
		|            M_MenuItemCollection = p1;
		|            base.List = M_MenuItemCollection;
		|        }
		|
		|        public osf.MenuItem Add(MenuItem item)
		|        {
		|            MenuItem menuItem;
		|            if (item is MenuItem)
		|            {
		|                menuItem = item;
		|            }
		|            else
		|            {
		|                menuItem = new MenuItem();
		|            }
		|            M_MenuItemCollection.Add(menuItem.M_MenuItem);
		|            System.Windows.Forms.Application.DoEvents();
		|            return menuItem;
		|        }
		|
		|        public bool Contains(osf.MenuItem item)
		|        {
		|            return M_MenuItemCollection.Contains((System.Windows.Forms.MenuItem)item.M_MenuItem);
		|        }
		|
		|        public int IndexOf(osf.MenuItem item)
		|        {
		|            return M_MenuItemCollection.IndexOf((System.Windows.Forms.MenuItem)item.M_MenuItem);
		|        }
		|
		|        public object Remove(osf.MenuItem item)
		|        {
		|            M_MenuItemCollection.Remove((System.Windows.Forms.MenuItem)item.M_MenuItem);
		|            return null;
		|        }
		|
		|        public new osf.MenuItem this[int p1]
		|        {
		|            get { return (MenuItem)((MenuItemEx)M_MenuItemCollection[p1]).M_Object; }
		|        }
		|
		|        public override object Current
		|        {
		|            get
		|            {
		|                return ((MenuItemEx)Enumerator.Current).M_Object;
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MenuItem" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MenuItemEx : System.Windows.Forms.MenuItem
		|    {
		|        public osf.MenuItem M_Object;
		|    }//endClass
		|
		|    public class MenuItem : Menu
		|    {
		|        public new ClMenuItem dll_obj;
		|        public string Name;
		|        public string Click;
		|        public string Popup;
		|        public bool M_VisibleSaveState;
		|        public MenuItemEx M_MenuItem;
		|
		|        public MenuItem(string text = null, string click = null, System.Windows.Forms.Shortcut shortcut = System.Windows.Forms.Shortcut.None)
		|        {
		|            M_MenuItem = new MenuItemEx();
		|            M_MenuItem.M_Object = this;
		|            base.M_Menu = M_MenuItem;
		|            M_MenuItem.Click += M_MenuItem_Click;
		|            M_MenuItem.Popup += M_MenuItem_Popup;
		|            Name = """";
		|            Click = click;
		|            Popup = """";
		|            M_VisibleSaveState = false;
		|            M_MenuItem.Text = text;
		|            M_MenuItem.Shortcut = shortcut;
		|        }
		|
		|        public MenuItem(osf.MenuItem p1)
		|        {
		|            M_MenuItem = p1.M_MenuItem;
		|            M_MenuItem.M_Object = this;
		|            base.M_Menu = M_MenuItem;
		|            M_MenuItem.Click += M_MenuItem_Click;
		|            M_MenuItem.Popup += M_MenuItem_Popup;
		|            Name = """";
		|            Click = """";
		|            Popup = """";
		|            M_VisibleSaveState = false;
		|        }
		|
		|        public MenuItem(System.Windows.Forms.MenuItem p1)
		|        {
		|            M_MenuItem = (MenuItemEx)p1;
		|            M_MenuItem.M_Object = this;
		|            base.M_Menu = M_MenuItem;
		|            M_MenuItem.Click += M_MenuItem_Click;
		|            M_MenuItem.Popup += M_MenuItem_Popup;
		|            Name = """";
		|            Click = """";
		|            Popup = """";
		|            M_VisibleSaveState = false;
		|        }
		|
		|        public osf.MenuItem FromString(string p1)
		|        {
		|            MenuItem MenuItem1 = new MenuItem((string)null, (string)null, System.Windows.Forms.Shortcut.None);
		|            MenuItem1.Text = p1;
		|            return MenuItem1;
		|        }
		|
		|        public bool Checked
		|        {
		|            get { return M_MenuItem.Checked; }
		|            set { M_MenuItem.Checked = value; }
		|        }
		|
		|        public bool Enabled
		|        {
		|            get { return M_MenuItem.Enabled; }
		|            set { M_MenuItem.Enabled = value; }
		|        }
		|
		|        public int Index
		|        {
		|            get { return M_MenuItem.Index; }
		|            set { M_MenuItem.Index = value; }
		|        }
		|
		|        public bool MdiList
		|        {
		|            get { return M_MenuItem.MdiList; }
		|            set { M_MenuItem.MdiList = value; }
		|        }
		|
		|        public int MergeOrder
		|        {
		|            get { return M_MenuItem.MergeOrder; }
		|            set { M_MenuItem.MergeOrder = value; }
		|        }
		|
		|        public int MergeType
		|        {
		|            get { return (int)M_MenuItem.MergeType; }
		|            set { M_MenuItem.MergeType = (System.Windows.Forms.MenuMerge)value; }
		|        }
		|
		|        public osf.Menu Parent
		|        {
		|            get
		|            {
		|                dynamic p1 = M_MenuItem.Parent;
		|                if (M_MenuItem.Parent is System.Windows.Forms.MainMenu)
		|                {
		|                    return (Menu)((MainMenuEx)p1).M_Object;
		|                }
		|                if (M_MenuItem.Parent is System.Windows.Forms.ContextMenu)
		|                {
		|                    return (Menu)((ContextMenuEx)p1).M_Object;
		|                }
		|                if (M_MenuItem.Parent is MenuItemEx)
		|                {
		|                    return (Menu)((MenuItemEx)p1).M_Object;
		|                }
		|                return null;
		|            }
		|        }
		|
		|        public bool RadioCheck
		|        {
		|            get { return M_MenuItem.RadioCheck; }
		|            set { M_MenuItem.RadioCheck = value; }
		|        }
		|
		|        public int Shortcut
		|        {
		|            get { return (int)M_MenuItem.Shortcut; }
		|            set { M_MenuItem.Shortcut = (System.Windows.Forms.Shortcut)value; }
		|        }
		|
		|        public string Text
		|        {
		|            get { return M_MenuItem.Text; }
		|            set { M_MenuItem.Text = value; }
		|        }
		|
		|        public bool Visible
		|        {
		|            get { return M_MenuItem.Visible; }
		|            set
		|            {
		|                M_MenuItem.Visible = value;
		|                M_VisibleSaveState = value;
		|            }
		|        }
		|
		|        public void M_MenuItem_Click(object sender, System.EventArgs e)
		|        {
		|            if (Click.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Click;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        private void M_MenuItem_Popup(object sender, System.EventArgs e)
		|        {
		|            if (Popup.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Popup;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ContextMenu" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ContextMenuEx : System.Windows.Forms.ContextMenu
		|    {
		|        public object M_Object;
		|    }//endClass
		|		
		|    public class ContextMenu : Menu
		|    {
		|        public new ClContextMenu dll_obj;
		|        public string Popup;
		|        public ContextMenuEx M_ContextMenu;
		|
		|        public ContextMenu()
		|        {
		|            M_ContextMenu = new ContextMenuEx();
		|            M_ContextMenu.M_Object = this;
		|            base.M_Menu = M_ContextMenu;
		|            M_ContextMenu.Popup += M_ContextMenu_Popup;
		|            Popup = """";
		|        }
		|
		|        public ContextMenu(osf.ContextMenu p1)
		|        {
		|            M_ContextMenu = p1.M_ContextMenu;
		|            M_ContextMenu.M_Object = this;
		|            base.M_Menu = M_ContextMenu;
		|            M_ContextMenu.Popup += M_ContextMenu_Popup;
		|            Popup = """";
		|        }
		|
		|        public ContextMenu(System.Windows.Forms.ContextMenu p1)
		|        {
		|            M_ContextMenu = (ContextMenuEx)p1;
		|            M_ContextMenu.M_Object = this;
		|            base.M_Menu = M_ContextMenu;
		|            M_ContextMenu.Popup += M_ContextMenu_Popup;
		|            Popup = """";
		|        }
		|
		|        public void Show(System.Windows.Forms.Control p1, System.Drawing.Point p2)
		|        {
		|            M_ContextMenu.Show(p1, p2);
		|        }
		|
		|        public osf.Control SourceControl
		|        {
		|            get { return (osf.Control)((dynamic)M_ContextMenu.SourceControl).M_Object; }
		|        }
		|
		|        public void M_ContextMenu_Popup(object sender, System.EventArgs e)
		|        {
		|            if (M_ContextMenu.SourceControl != null)
		|            {
		|                foreach (MenuItemEx itemEx in M_ContextMenu.MenuItems)
		|                {
		|                    MenuItem item = (MenuItem)itemEx.M_Object;
		|                    item.M_VisibleSaveState = item.Visible;
		|                    item.M_MenuItem.Visible = false;
		|                }
		|                ContextMenuPopupEventArgs ContextMenuPopupEventArgs1 = new ContextMenuPopupEventArgs();
		|                ContextMenuPopupEventArgs1.Sender = this;
		|                ContextMenuPopupEventArgs1.EventString = Popup;
		|                ContextMenuPopupEventArgs1.Point = new Point(M_ContextMenu.SourceControl.PointToClient(System.Windows.Forms.Control.MousePosition));
		|                OneScriptForms.EventQueue.Add(ContextMenuPopupEventArgs1);
		|                ClContextMenuPopupEventArgs ClContextMenuPopupEventArgs1 = new ClContextMenuPopupEventArgs(ContextMenuPopupEventArgs1);
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MainMenu" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MainMenuEx : System.Windows.Forms.MainMenu
		|    {
		|        public osf.MainMenu M_Object;
		|    }//endClass
		|
		|    public class MainMenu : Menu
		|    {
		|        public new ClMainMenu dll_obj;
		|        public MainMenuEx M_MainMenu;
		|
		|        public MainMenu()
		|        {
		|            M_MainMenu = new MainMenuEx();
		|            M_MainMenu.M_Object = this;
		|            base.M_Menu = M_MainMenu;
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public MainMenu(osf.MainMenu p1)
		|        {
		|            M_MainMenu = p1.M_MainMenu;
		|            M_MainMenu.M_Object = this;
		|            base.M_Menu = M_MainMenu;
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public MainMenu(System.Windows.Forms.MainMenu MainMenu)
		|        {
		|            M_MainMenu = (MainMenuEx)MainMenu;
		|            M_MainMenu.M_Object = this;
		|            base.M_Menu = M_MainMenu;
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public osf.Form GetForm()
		|        {
		|            return (osf.Form)((FormEx)M_MainMenu.GetForm()).M_Object;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Menu" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Menu
		|    {
		|        public ClMenu dll_obj;
		|        public System.Windows.Forms.Menu M_Menu;
		|
		|        public MainMenu GetMainMenu()
		|        {
		|            try
		|            {
		|                return ((MainMenuEx)M_Menu.GetMainMenu()).M_Object;
		|            }
		|            catch
		|            {
		|                return null;
		|            }
		|        }
		|
		|        public osf.MenuItem get_MenuItem(int index)
		|        {
		|            return (MenuItem)((MenuItemEx)M_Menu.MenuItems[index]).M_Object;
		|        }
		|
		|        public osf.MenuItemCollection MenuItems
		|        {
		|            get { return new MenuItemCollection(M_Menu.MenuItems); }
		|        }
		|		
		|        public osf.MenuItem MenuItems2(int p1)
		|        {
		|            return MenuItems[p1];
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ArrayList" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ArrayListEx : System.Collections.ArrayList
		|    {
		|        public osf.ArrayList M_Object;
		|    }//endClass
		|
		|    public class ArrayList : IEnumerable, IEnumerator
		|    {
		|        public ClArrayList dll_obj;
		|        public ArrayListEx M_ArrayList;
		|        public System.Collections.IEnumerator Enumerator;
		|
		|        public ArrayList()
		|        {
		|            M_ArrayList = new ArrayListEx();
		|            M_ArrayList.M_Object = this;
		|        }
		|
		|        public ArrayList(osf.ArrayList p1)
		|        {
		|            M_ArrayList = p1.M_ArrayList;
		|            M_ArrayList.M_Object = this;
		|        }
		|
		|        public ArrayList(System.Collections.ArrayList p1)
		|        {
		|            M_ArrayList = (ArrayListEx)p1;
		|            M_ArrayList.M_Object = this;
		|        }
		|
		|        public object Add(object value)
		|        {
		|            M_ArrayList.Add(value);
		|            System.Windows.Forms.Application.DoEvents();
		|            return value;
		|        }
		|
		|        public void Clear()
		|        {
		|            M_ArrayList.Clear();
		|        }
		|
		|        public virtual int Count
		|        {
		|            get { return M_ArrayList.Count; }
		|        }
		|
		|        public int IndexOf(object value)
		|        {
		|            return M_ArrayList.IndexOf(value);
		|        }
		|
		|        public object Insert(int index, object value)
		|        {
		|            M_ArrayList.Insert(index, value);
		|            return value;
		|        }
		|
		|        public object this[int index]
		|        {
		|            get { return M_ArrayList[index]; }
		|            set { M_ArrayList[index] = value; }
		|        }
		|
		|        public void Remove(object obj)
		|        {
		|            M_ArrayList.Remove(obj);
		|        }
		|
		|        public virtual void RemoveAt(int index)
		|        {
		|            M_ArrayList.RemoveAt(index);
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            Enumerator = M_ArrayList.GetEnumerator();
		|            return (System.Collections.IEnumerator)this;
		|        }
		|
		|        public object Current
		|        {
		|            get { return Enumerator.Current; }
		|        }
		|
		|        public bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "PictureBox" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class PictureBoxEx : System.Windows.Forms.PictureBox
		|    {
		|        public osf.PictureBox M_Object;
		|    }//endClass
		|
		|    public class PictureBox : Control
		|    {
		|        public ClPictureBox dll_obj;
		|        public PictureBoxEx M_PictureBox;
		|        private osf.Bitmap image;
		|
		|        public PictureBox()
		|        {
		|            M_PictureBox = new PictureBoxEx();
		|            M_PictureBox.M_Object = this;
		|            base.M_Control = M_PictureBox;
		|        }
		|
		|        public PictureBox(osf.PictureBox p1)
		|        {
		|            M_PictureBox = p1.M_PictureBox;
		|            M_PictureBox.M_Object = this;
		|            base.M_Control = M_PictureBox;
		|        }
		|
		|        public PictureBox(System.Windows.Forms.PictureBox p1)
		|        {
		|            M_PictureBox = (PictureBoxEx)p1;
		|            M_PictureBox.M_Object = this;
		|            base.M_Control = M_PictureBox;
		|        }
		|
		|        public int BorderStyle
		|        {
		|            get { return (int)M_PictureBox.BorderStyle; }
		|            set
		|            {
		|                M_PictureBox.BorderStyle = (System.Windows.Forms.BorderStyle)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Bitmap Image
		|        {
		|            get { return image; }
		|            set
		|            {
		|                image = value;
		|                M_PictureBox.Image = value.M_Image;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int SizeMode
		|        {
		|            get { return (int)M_PictureBox.SizeMode; }
		|            set
		|            {
		|                M_PictureBox.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int BackgroundImageLayout
		|        {
		|            get { return (int)M_PictureBox.BackgroundImageLayout; }
		|            set
		|            {
		|                M_PictureBox.BackgroundImageLayout = (System.Windows.Forms.ImageLayout)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Bitmap" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Bitmap : Image
		|    {
		|        public ClBitmap dll_obj;
		|        public System.Drawing.Bitmap M_Bitmap;
		|
		|        public Bitmap(System.Drawing.Image p1)
		|        {
		|            M_Bitmap = new System.Drawing.Bitmap(p1);
		|            base.M_Image = M_Bitmap;
		|            OneScriptForms.AddToHashtable(M_Bitmap, this);
		|        }
		|
		|        public Bitmap(Image p1)
		|        {
		|            M_Bitmap = new System.Drawing.Bitmap(p1.M_Image);
		|            base.M_Image = M_Bitmap;
		|            OneScriptForms.AddToHashtable(M_Bitmap, this);
		|        }
		|
		|        public Bitmap(Image p1, Size p2)
		|        {
		|            M_Bitmap = new System.Drawing.Bitmap(p1.M_Image, p2.M_Size);
		|            base.M_Image = M_Bitmap;
		|            OneScriptForms.AddToHashtable(M_Bitmap, this);
		|        }
		|
		|        public Bitmap(Size p1)
		|        {
		|            M_Bitmap = new System.Drawing.Bitmap(p1.Width, p1.Height);
		|            base.M_Image = M_Bitmap;
		|            OneScriptForms.AddToHashtable(M_Bitmap, this);
		|        }
		|
		|        public Bitmap(Stream p1)
		|        {
		|            M_Bitmap = new System.Drawing.Bitmap(p1.M_Stream);
		|            base.M_Image = M_Bitmap;
		|            OneScriptForms.AddToHashtable(M_Bitmap, this);
		|        }
		|
		|        public Bitmap(string p1)
		|        {
		|            try
		|            {
		|                M_Bitmap = new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(p1)));
		|                base.M_Image = M_Bitmap;
		|            }
		|            catch
		|            {
		|                M_Bitmap = new System.Drawing.Bitmap(p1);
		|                base.M_Image = M_Bitmap;
		|            }
		|            OneScriptForms.AddToHashtable(M_Bitmap, this);
		|        }
		|
		|        public Bitmap(osf.Bitmap p1)
		|        {
		|            M_Bitmap = p1.M_Bitmap;
		|            base.M_Image = M_Bitmap;
		|        }
		|
		|        public Bitmap(System.Drawing.Bitmap p1)
		|        {
		|            M_Bitmap = p1;
		|            base.M_Image = M_Bitmap;
		|        }
		|
		|        public osf.Bitmap Clone(float x, float y, float width, float height)
		|        {
		|            return new Bitmap(M_Bitmap.Clone(
		|                new System.Drawing.Rectangle(
		|                    Convert.ToInt32(x),
		|                    Convert.ToInt32(y),
		|                    Convert.ToInt32(width),
		|                    Convert.ToInt32(height)
		|                    ), 
		|                System.Drawing.Imaging.PixelFormat.Undefined)
		|                );
		|        }
		|
		|        public osf.Bitmap FromBase64String(string str)
		|        {
		|            return new Bitmap(new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(str))));
		|        }
		|
		|        public osf.Bitmap FromSize(System.Drawing.Size size)
		|        {
		|            return new Bitmap(new System.Drawing.Bitmap(size.Width, size.Height));
		|        }
		|
		|        public void MakeTransparent(Color p1)
		|        {
		|            M_Bitmap.MakeTransparent(p1.M_Color);
		|        }
		|
		|        public string ToBase64String(ImageFormat format = null)
		|        {
		|            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
		|            if (format != null)
		|            {
		|                M_Bitmap.Save((System.IO.Stream)memoryStream, format.M_ImageFormat);
		|            }
		|            else
		|            {
		|                try
		|                {
		|                    M_Bitmap.Save((System.IO.Stream)memoryStream, M_Bitmap.RawFormat);
		|                }
		|                catch
		|                {
		|                    M_Bitmap.Save((System.IO.Stream)memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
		|                }
		|            }
		|            string base64String = Convert.ToBase64String(memoryStream.ToArray());
		|            memoryStream.Close();
		|            return base64String;
		|        }
		|		
		|        public void SetPixel(int x, int y, osf.Color color)
		|        {
		|            M_Bitmap.SetPixel(x, y, color.M_Color);
		|        }
		|		
		|        public osf.BitmapData LockBits()
		|        {
		|            osf.Rectangle Rectangle1 = new Rectangle(0, 0, M_Bitmap.Width, M_Bitmap.Height);
		|            System.Drawing.Imaging.ImageLockMode ImageLockMode1 = System.Drawing.Imaging.ImageLockMode.ReadWrite;
		|            System.Drawing.Imaging.PixelFormat PixelFormat1 = M_Bitmap.PixelFormat;
		|            osf.BitmapData BitmapData1 = new BitmapData(M_Bitmap.LockBits(Rectangle1.M_Rectangle, ImageLockMode1, PixelFormat1));
		|            return BitmapData1;
		|        }
		|
		|        public void UnlockBits(osf.BitmapData p1)
		|        {
		|            M_Bitmap.UnlockBits(p1.M_BitmapData);
		|        }
		|		
		|        public void SetBytes(osf.BitmapData p1, osf.ArrayList p2)
		|        {
		|            int num = p2.M_ArrayList.Count;
		|            byte[] Bytes1 = new byte[num];
		|            for (int i = 0; i < num; i++)
		|            {
		|                Bytes1[i] = System.Convert.ToByte(p2.M_ArrayList[i].ToString());
		|            }
		|            System.Runtime.InteropServices.Marshal.Copy(Bytes1, 0, p1.M_BitmapData.Scan0, num);
		|        }
		|
		|        public osf.ArrayList GetBytes(osf.BitmapData p1)
		|        {
		|            int num = Math.Abs(p1.M_BitmapData.Stride) * M_Bitmap.Height;
		|            byte[] Bytes1 = new byte[num];
		|            System.Runtime.InteropServices.Marshal.Copy(p1.M_BitmapData.Scan0, Bytes1, 0, num);
		|            ArrayList ArrayList1 = new ArrayList();
		|            for (int i = 0; i < num; i++)
		|            {
		|                ArrayList1.Add(System.Convert.ToInt32(Bytes1[i]));
		|            }
		|            return ArrayList1;
		|        }
		|		
		|        public osf.Color GetPixel(int p1, int p2)
		|        {
		|            return new Color(M_Bitmap.GetPixel(p1, p2));
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Icon" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Icon
		|    {
		|        public ClIcon dll_obj;
		|        public System.Drawing.Icon M_Icon;
		|
		|        public Icon(string p1)
		|        {
		|            M_Icon = null;
		|            try
		|            {
		|                System.Drawing.Bitmap Bitmap = new System.Drawing.Bitmap((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(p1)));
		|                IntPtr Hicon = Bitmap.GetHicon();
		|                System.Drawing.Icon Icon1 = System.Drawing.Icon.FromHandle(Hicon);
		|                M_Icon = Icon1;
		|            }
		|            catch
		|            {
		|            }
		|            try
		|            {
		|                M_Icon = new System.Drawing.Icon((System.IO.Stream)new System.IO.MemoryStream(Convert.FromBase64String(p1)));
		|            }
		|            catch
		|            {
		|            }
		|            if (M_Icon == null)
		|            {
		|                M_Icon = new System.Drawing.Icon(p1);
		|            }
		|            OneScriptForms.AddToHashtable(M_Icon, this);
		|        }
		|
		|        public Icon(string p1, int p2)
		|        {
		|            M_Icon = ExtractIconClass.GetIconFromExeDll(p2, p1);
		|            OneScriptForms.AddToHashtable(M_Icon, this);
		|        }
		|
		|        public Icon(Bitmap bitmap)
		|        {
		|            M_Icon = System.Drawing.Icon.FromHandle(((System.Drawing.Bitmap)bitmap.M_Bitmap).GetHicon());
		|            OneScriptForms.AddToHashtable(M_Icon, this);
		|        }
		|		
		|        public Icon(osf.Icon p1)
		|        {
		|            M_Icon = p1.M_Icon;
		|            OneScriptForms.AddToHashtable(M_Icon, this);
		|        }
		|
		|        public Icon(System.Drawing.Icon p1)
		|        {
		|            M_Icon = p1;
		|            OneScriptForms.AddToHashtable(M_Icon, this);
		|        }
		|
		|        public osf.Bitmap ToBitmap()
		|        {
		|            return new Bitmap(M_Icon.ToBitmap());
		|        }
		|
		|        public int Height
		|        {
		|            get { return M_Icon.Height; }
		|        }
		|
		|        public osf.Size Size
		|        {
		|            get { return new Size(M_Icon.Size); }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_Icon.Width; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Type" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Type
		|    {
		|        public System.Type M_Type;
		|
		|        public Type(string p1)
		|        {
		|            M_Type = System.Type.GetType(p1, false, true);
		|        }
		|
		|        public Type(System.Type p1)
		|        {
		|            M_Type = p1;
		|        }
		|
		|        public bool IsClass
		|        {
		|            get { return M_Type.IsClass; }
		|        }
		|
		|        public bool IsInstanceOfType(osf.Type p1)
		|        {
		|            return M_Type.IsInstanceOfType(p1.M_Type);
		|        }
		|
		|        public bool IsSubclassOf(osf.Type p1)
		|        {
		|            return M_Type.IsSubclassOf(p1.M_Type);
		|        }
		|
		|        public string Name
		|        {
		|            get { return M_Type.Name; }
		|        }
		|
		|        public override string ToString()
		|        {
		|            return M_Type.ToString();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Pen" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Pen
		|    {
		|        public ClPen dll_obj;
		|        public System.Drawing.Pen M_Pen;
		|
		|        public Pen(System.Drawing.Color color, float width = 1f)
		|        {
		|            M_Pen = new System.Drawing.Pen(color, width);
		|            OneScriptForms.AddToHashtable(M_Pen, this);
		|        }
		|
		|        public Pen(osf.Pen p1)
		|        {
		|            M_Pen = p1.M_Pen;
		|            OneScriptForms.AddToHashtable(M_Pen, this);
		|        }
		|
		|        public Pen(System.Drawing.Pen p1)
		|        {
		|            M_Pen = p1;
		|            OneScriptForms.AddToHashtable(M_Pen, this);
		|        }
		|
		|        public void Dispose()
		|        {
		|            M_Pen.Dispose();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "SolidBrush" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class SolidBrush : Brush
		|    {
		|        public ClSolidBrush dll_obj;
		|        public System.Drawing.SolidBrush M_SolidBrush;
		|
		|        public SolidBrush(System.Drawing.Color p1)
		|        {
		|            M_SolidBrush = new System.Drawing.SolidBrush(p1);
		|            base.M_Brush = M_SolidBrush;
		|            OneScriptForms.AddToHashtable(M_SolidBrush, this);
		|        }
		|		
		|        public SolidBrush(osf.SolidBrush p1)
		|        {
		|            M_SolidBrush = p1.M_SolidBrush;
		|            base.M_Brush = M_SolidBrush;
		|            OneScriptForms.AddToHashtable(M_SolidBrush, this);
		|        }
		|
		|        public SolidBrush(System.Drawing.SolidBrush p1)
		|        {
		|            M_SolidBrush = p1;
		|            base.M_Brush = M_SolidBrush;
		|            OneScriptForms.AddToHashtable(M_SolidBrush, this);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Brush" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Brush : System.Drawing.Brush
		|    {
		|        public object M_Brush;
		|
		|        public override object Clone()
		|        {
		|            return (System.Drawing.Brush)Clone();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Graphics" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Graphics
		|    {
		|        public ClGraphics dll_obj;
		|        public System.Drawing.Graphics M_Graphics;
		|		
		|        public Graphics(osf.Graphics p1)
		|        {
		|            M_Graphics = p1.M_Graphics;
		|            OneScriptForms.AddToHashtable(M_Graphics, this);
		|        }
		|
		|        public Graphics(System.Drawing.Graphics p1)
		|        {
		|            M_Graphics = p1;
		|            OneScriptForms.AddToHashtable(M_Graphics, this);
		|        }
		|
		|        public void Clear(Color p1)
		|        {
		|            M_Graphics.Clear(p1.M_Color);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void DrawEllipse(osf.Pen pen, float x, float y, float width, float height)
		|        {
		|            M_Graphics.DrawEllipse(pen.M_Pen, x, y, width, height);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void DrawImage(osf.Image image, float dx, float dy, float dw, float dh, float sx = 0.0f, float sy = 0.0f, float sw = -1f, float sh = -1f)
		|        {
		|            System.Drawing.Rectangle Rectangle1 = new System.Drawing.Rectangle();
		|            Rectangle1.X = (int)System.Math.Round((double)dx);
		|            Rectangle1.Y = (int)System.Math.Round((double)dy);
		|            Rectangle1.Width = (int)System.Math.Round((double)dw);
		|            Rectangle1.Height = (int)System.Math.Round((double)dh);
		|            if ((double)sw == -1.0)
		|            {
		|                sw = (float)image.Width;
		|            }
		|            if ((double)sh == -1.0)
		|            {
		|                sh = (float)image.Height;
		|            }
		|            M_Graphics.DrawImage(image.M_Image, Rectangle1, sx, sy, sw, sh, System.Drawing.GraphicsUnit.Pixel);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void DrawLine(osf.Pen pen, float x1, float y1, float x2, float y2)
		|        {
		|            M_Graphics.DrawLine(pen.M_Pen, x1, y1, x2, y2);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void DrawString(string str, osf.Font font, osf.Brush brush, float x, float y)
		|        {
		|            M_Graphics.DrawString(str, font.M_Font, (System.Drawing.Brush)brush.M_Brush, x, y);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void DrawRectangle(osf.Pen pen, float x, float y, float width, float height)
		|        {
		|            M_Graphics.DrawRectangle(pen.M_Pen, x, y, width, height);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void FillRectangle(osf.Brush brush, float x, float y, float width, float height)
		|        {
		|            M_Graphics.FillRectangle((System.Drawing.Brush)brush.M_Brush, x, y, width, height);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public osf.Graphics FromImage(osf.Image p1)
		|        {
		|            Graphics Graphics1 = new Graphics(System.Drawing.Graphics.FromImage(p1.M_Image));
		|            System.Windows.Forms.Application.DoEvents();
		|            return Graphics1;
		|        }
		|		
		|        public void Dispose()
		|        {
		|            M_Graphics.Dispose();
		|        }
		|		
		|        public float DpiX
		|        {
		|            get { return M_Graphics.DpiX; }
		|        }
		|
		|        public float DpiY
		|        {
		|            get { return M_Graphics.DpiY; }
		|        }
		|		
		|        public void CopyFromScreen(int p1, int p2, int p3, int p4, Size p5)
		|        {
		|            M_Graphics.CopyFromScreen(p1, p2, p3, p4, p5.M_Size);
		|        }
		|		
		|        public void ScaleTransform(float p1, float p2)
		|        {
		|            M_Graphics.ScaleTransform(p1, p2);
		|        }
		|		
		|        public void TranslateTransform(float p1, float p2)
		|        {
		|            M_Graphics.TranslateTransform(p1, p2);
		|        }
		|		
		|        public void RotateTransform(float p1)
		|        {
		|            M_Graphics.RotateTransform(p1);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Collection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Collection : System.Collections.IEnumerable
		|    {
		|        public ClCollection dll_obj;
		|        public Microsoft.VisualBasic.Collection M_Collection;
		|
		|        public Collection()
		|        {
		|            M_Collection = new Microsoft.VisualBasic.Collection();
		|            OneScriptForms.AddToHashtable(M_Collection, this);
		|        }
		|
		|        public Collection(osf.Collection p1)
		|        {
		|            M_Collection = p1.M_Collection;
		|        }
		|
		|        public Collection(Microsoft.VisualBasic.Collection p1)
		|        {
		|            M_Collection = p1;
		|        }
		|
		|        public void Add(object item, string key = null)
		|        {
		|            M_Collection.Add(item, key);
		|        }
		|
		|        public int Count
		|        {
		|            get { return M_Collection.Count; }
		|        }
		|
		|        public object this[object index]
		|        {
		|            get
		|            {
		|                if (index is int)
		|                {
		|                    return M_Collection[checked(Convert.ToInt32(index) + 1)];
		|                }
		|                if (index is string)
		|                {
		|                    return M_Collection[Convert.ToString(index)];
		|                }
		|                return M_Collection[index];
		|            }
		|        }
		|
		|        public void Remove(object index)
		|        {
		|            if (index is int)
		|            {
		|                M_Collection.Remove(checked(Convert.ToInt32(index) + 1));
		|            }
		|            else if (index is string)
		|            {
		|                M_Collection.Remove(checked(Convert.ToString(index)));
		|            }
		|        }
		|
		|        public System.Collections.IEnumerator GetEnumerator()
		|        {
		|            return M_Collection.GetEnumerator();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "FormClosingEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FormClosingEventArgs : CancelEventArgs
		|    {
		|        public new ClFormClosingEventArgs dll_obj;
		|        public int CloseReason;
		|
		|        public FormClosingEventArgs(System.Windows.Forms.CloseReason p1, bool p2)
		|        {
		|            CloseReason = (int)p1;
		|            Cancel = p2;
		|        }
		|
		|        public override bool PostEvent()
		|        {
		|            if (Cancel)
		|            {
		|                return true;
		|            }
		|            Form Form1 = (Form)Sender;
		|            Form1.M_Form.FormClosing -= Form1.M_Form_FormClosing;
		|            Form1.Close();
		|            Form1.M_Form.FormClosing += Form1.M_Form_FormClosing;
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Sound" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Sound
		|    {
		|        public ClSound dll_obj;
		|
		|        [DllImport(""winmm.dll"", CharSet = CharSet.Auto, SetLastError = true)] public static extern int PlaySound([MarshalAs(UnmanagedType.VBByRefStr)] ref string name, int hmod, int flags);
		|
		|        public void Play(string filename)
		|        {
		|            try
		|            {
		|                Sound.PlaySound(ref filename, 0, 131073);
		|            }
		|            catch
		|            {
		|            }
		|        }
		|
		|        public void PlaySystem(string name)
		|        {
		|            Sound.PlaySound(ref name, 0, 65539);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ItemCheckEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ItemCheckEventArgs : EventArgs
		|    {
		|        public new ClItemCheckEventArgs dll_obj;
		|        public int CurrentValue = (int)System.Windows.Forms.CheckState.Unchecked;
		|        public int Index = -1;
		|        public int NewValue = (int)System.Windows.Forms.CheckState.Unchecked;
		|
		|        public override bool PostEvent()
		|        {
		|            ListView ListView1 = (ListView)Sender;
		|            ListViewEx ListViewEx1 = ListView1.M_ListView;
		|            ListViewEx1.ItemCheck -= ListView1.M_ListView_ItemCheck;
		|            ListViewEx1.Items[Index].Checked = (uint)NewValue > 0U;
		|            ListViewEx1.ItemCheck += ListView1.M_ListView_ItemCheck;
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "KeyEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class KeyEventArgs : EventArgs
		|    {
		|        public new ClKeyEventArgs dll_obj;
		|        public bool Alt = false;
		|        public bool Control = false;
		|        public int KeyCode = (int)System.Windows.Forms.Keys.None;
		|        public int Modifiers = (int)System.Windows.Forms.Keys.None;
		|        public bool Shift = false;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "KeyPressEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class KeyPressEventArgs : EventArgs
		|    {
		|        public new ClKeyPressEventArgs dll_obj;
		|        public string KeyChar;
		|
		|        public KeyPressEventArgs()
		|        {
		|            KeyChar = Convert.ToString(char.MinValue);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "LabelEditEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LabelEditEventArgs : EventArgs
		|    {
		|        public new ClLabelEditEventArgs dll_obj;
		|        public bool CancelEdit = false;
		|        public int Item = -1;
		|        public string Label = """";
		|        public string Type = ""BeforeLabelEdit"";
		|
		|        public override bool PostEvent()
		|        {
		|            if (CancelEdit)
		|            {
		|                return true;
		|            }
		|            ListView ListView1 = (ListView)Sender;
		|            ListViewEx ListViewEx1 = ListView1.M_ListView;
		|            if (Type == ""BeforeLabelEdit"")
		|            {
		|                ListViewEx1.BeforeLabelEdit -= ListView1.M_ListView_BeforeLabelEdit;
		|                ListViewEx1.Items[Item].BeginEdit();
		|                ListViewEx1.BeforeLabelEdit += ListView1.M_ListView_BeforeLabelEdit;
		|            }
		|            if (Type == ""AfterLabelEdit"")
		|            {
		|                ListViewEx1.Items[Item].Text = Label;
		|            }
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "RenamedEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class RenamedEventArgs : FileSystemEventArgs
		|    {
		|        public new ClRenamedEventArgs dll_obj;
		|        public string OldFullPath = """";
		|        public string OldName = """";
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "LinkClickedEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LinkClickedEventArgs : EventArgs
		|    {
		|        public new ClLinkClickedEventArgs dll_obj;
		|        public string LinkText = """";
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ScrollEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ScrollEventArgs : EventArgs
		|    {
		|        public new ClScrollEventArgs dll_obj;
		|        public int NewValue;
		|        public int OldValue;
		|        public int ScrollOrientation;
		|        public int EventType;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "SelectedGridItemChangedEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class SelectedGridItemChangedEventArgs : EventArgs
		|    {
		|        public new ClSelectedGridItemChangedEventArgs dll_obj;
		|        public string OldLabel;
		|        public object OldValue;
		|        public string NewLabel;
		|        public object NewValue;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ControlEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ControlEventArgs : EventArgs
		|    {
		|        public new ClControlEventArgs dll_obj;
		|        public dynamic Control = null;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "PaintEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class PaintEventArgs : EventArgs
		|    {
		|        public new ClPaintEventArgs dll_obj;
		|        public osf.Graphics Graphics = null;
		|        public osf.Rectangle ClipRectangle = null;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "NodeLabelEditEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class NodeLabelEditEventArgs : EventArgs
		|    {
		|        public new ClNodeLabelEditEventArgs dll_obj;
		|        public bool CancelEdit;
		|        public string Label;
		|        public string Label_old;
		|        public osf.TreeNode Node;
		|		
		|        public override bool PostEvent()
		|        {
		|            if (CancelEdit)
		|            {
		|                Node.Text = Label_old;
		|                Node.BeginEdit();
		|                return true;
		|            }
		|            Node.M_TreeNode.EndEdit(false);
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TreeViewEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TreeViewEventArgs : EventArgs
		|    {
		|        public new ClTreeViewEventArgs dll_obj;
		|        public int Action = (int)System.Windows.Forms.TreeViewAction.Unknown;
		|        public osf.TreeNode Node = null;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "TreeViewCancelEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class TreeViewCancelEventArgs : CancelEventArgs
		|    {
		|        public new ClTreeViewCancelEventArgs dll_obj;
		|        public int Action = (int)System.Windows.Forms.TreeViewAction.Unknown;
		|        public osf.TreeNode Node = null;
		|
		|        public override bool PostEvent()
		|        {
		|            if (Cancel)
		|            {
		|                return true;
		|            }
		|            TreeView TreeView1 = (TreeView)Sender;
		|            TreeView1.M_TreeView.BeforeExpand -= TreeView1.M_TreeView_BeforeExpand;
		|            Node.Expand();
		|            TreeView1.M_TreeView.BeforeExpand += TreeView1.M_TreeView_BeforeExpand;
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "PropertyValueChangedEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class PropertyValueChangedEventArgs : EventArgs
		|    {
		|        public new ClPropertyValueChangedEventArgs dll_obj;
		|        public object oldValue = null;
		|        public osf.GridItem ChangedItem = null;
		|
		|        public object OldValue
		|        {
		|            get { return oldValue; }
		|            set { oldValue = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ToolBarButtonClickEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ToolBarButtonClickEventArgs : EventArgs
		|    {
		|        public new ClToolBarButtonClickEventArgs dll_obj;
		|        public osf.ToolBarButton Button = null;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "LinkLabelLinkClickedEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class LinkLabelLinkClickedEventArgs : EventArgs
		|    {
		|        public new ClLinkLabelLinkClickedEventArgs dll_obj;
		|        public int Button;
		|        public osf.Link Link;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ColumnClickEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ColumnClickEventArgs : EventArgs
		|    {
		|        public new ClColumnClickEventArgs dll_obj;
		|        public int Column = -1;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "FileSystemEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FileSystemEventArgs : EventArgs
		|    {
		|        public new ClFileSystemEventArgs dll_obj;
		|        public int ChangeType = 0;
		|        public string FullPath = null;
		|        public string Name = null;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "CancelEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class CancelEventArgs : EventArgs
		|    {
		|        public new ClCancelEventArgs dll_obj;
		|        public bool Cancel = false;
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ControlCollection" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ControlCollection : CollectionBase
		|    {
		|        public System.Windows.Forms.Control.ControlCollection M_ControlCollection;
		|        public ClControlCollection dll_obj;
		|
		|        public ControlCollection()
		|        {
		|        }
		|
		|        public ControlCollection(System.Windows.Forms.Control.ControlCollection p1)
		|        {
		|            M_ControlCollection = p1;
		|            base.List = M_ControlCollection;
		|        }
		|
		|        public osf.Control Add(Control p1)
		|        {
		|            M_ControlCollection.Add(p1.M_Control);
		|            return (osf.Control)p1;
		|        }
		|
		|        public osf.Button AddButton(string text = null, int left = 0, int top = 0, int width = 0, int height = 0)
		|        {
		|            Button Button1 = new Button();
		|            Button1.Text = text;
		|            Button1.Left = left;
		|            Button1.Top = top;
		|            Button1.Width = width;
		|            Button1.Height = height;
		|            M_ControlCollection.Add((System.Windows.Forms.Control)Button1.M_Button);
		|            System.Windows.Forms.Application.DoEvents();
		|            return Button1;
		|        }
		|
		|        public new osf.Control this[int p1]
		|        {
		|            get
		|            {
		|                if (M_ControlCollection[p1] != null)
		|                {
		|                    return (osf.Control)((dynamic)M_ControlCollection[p1]).M_Object;
		|                }
		|                return null;
		|            }
		|        }
		|
		|        public bool Contains(Control p1)
		|        {
		|            return M_ControlCollection.Contains(p1.M_Control);
		|        }
		|
		|        public void Remove(Control p1)
		|        {
		|            M_ControlCollection.Remove(p1.M_Control);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void SetChildIndex(Control p1, int p2)
		|        {
		|            M_ControlCollection.SetChildIndex(p1.M_Control, p2);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public override object Current
		|        {
		|            get
		|            {
		|                object objectValue = Enumerator.Current;
		|                if (objectValue != null)
		|                {
		|                    return new Control(((dynamic)objectValue).M_Control);
		|                }
		|                return null;
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "CollectionBase" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class CollectionBase : System.Collections.IList, System.Collections.IEnumerator, System.Collections.IEnumerable
		|    {
		|        public System.Collections.IList List;
		|        public System.Collections.IEnumerator Enumerator;
		|        public object current;
		|
		|
		|        public virtual int Add(object value)
		|        {
		|            return List.Add(value);
		|        }
		|
		|        public virtual void Clear()
		|        {
		|            List.Clear();
		|        }
		|
		|        public virtual void CopyTo(Array array, int index)
		|        {
		|            List.CopyTo(array, index);
		|        }
		|
		|        public virtual bool Contains(object value)
		|        {
		|            return List.Contains(value);
		|        }
		|
		|        public virtual int Count
		|        {
		|            get { return List.Count; }
		|        }
		|
		|        public virtual int IndexOf(object value)
		|        {
		|            return List.IndexOf(value);
		|        }
		|
		|        public virtual void Insert(int index, object value)
		|        {
		|            List.Insert(index, value);
		|        }
		|
		|        public virtual bool IsFixedSize
		|        {
		|            get { return List.IsFixedSize; }
		|        }
		|
		|        public virtual bool IsReadOnly
		|        {
		|            get { return List.IsReadOnly; }
		|        }
		|
		|        public virtual bool IsSynchronized
		|        {
		|            get { return List.IsSynchronized; }
		|        }
		|
		|        public virtual void Remove(object value)
		|        {
		|            List.Remove(value);
		|        }
		|
		|        public void RemoveAt(int Index)
		|        {
		|            List.RemoveAt(Index);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public virtual object SyncRoot
		|        {
		|            get { return List.SyncRoot; }
		|        }
		|
		|        public virtual object this[int index]
		|        {
		|            get { return List[index]; }
		|            set { List[index] = value; }
		|        }
		|
		|        public virtual System.Collections.IEnumerator GetEnumerator()
		|        {
		|            Enumerator = List.GetEnumerator();
		|            return (System.Collections.IEnumerator)this;
		|        }
		|
		|        public virtual object Current
		|        {
		|            get { return current; }
		|        }
		|
		|        public virtual bool MoveNext()
		|        {
		|            return Enumerator.MoveNext();
		|        }
		|
		|        public virtual void Reset()
		|        {
		|            Enumerator.Reset();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "DockPaddingEdges" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class DockPaddingEdges
		|    {
		|        public ClDockPaddingEdges dll_obj;
		|        public System.Windows.Forms.ScrollableControl.DockPaddingEdges M_DockPaddingEdges;
		|		
		|        public DockPaddingEdges(osf.DockPaddingEdges p1)
		|        {
		|            M_DockPaddingEdges = p1.M_DockPaddingEdges;
		|            OneScriptForms.AddToHashtable(M_DockPaddingEdges, this);
		|        }
		|
		|        public DockPaddingEdges(System.Windows.Forms.ScrollableControl.DockPaddingEdges p1)
		|        {
		|            M_DockPaddingEdges = p1;
		|            OneScriptForms.AddToHashtable(M_DockPaddingEdges, this);
		|        }
		|
		|        public int All
		|        {
		|            get { return M_DockPaddingEdges.All; }
		|            set { M_DockPaddingEdges.All = value; }
		|        }
		|
		|        public int Bottom
		|        {
		|            get { return M_DockPaddingEdges.Bottom; }
		|            set { M_DockPaddingEdges.Bottom = value; }
		|        }
		|
		|        public int Left
		|        {
		|            get { return M_DockPaddingEdges.Left; }
		|            set { M_DockPaddingEdges.Left = value; }
		|        }
		|
		|        public int Right
		|        {
		|            get { return M_DockPaddingEdges.Right; }
		|            set { M_DockPaddingEdges.Right = value; }
		|        }
		|
		|        public int Top
		|        {
		|            get { return M_DockPaddingEdges.Top; }
		|            set { M_DockPaddingEdges.Top = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "MouseEventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class MouseEventArgs : EventArgs
		|    {
		|        public new ClMouseEventArgs dll_obj;
		|        private int button = -1;
		|        public int X = -1;
		|        public int Y = -1;
		|        public int Clicks = -1;
		|
		|        public int Button
		|        {
		|            get { return (int)button; }
		|            set { button = (int)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Stream" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Stream
		|    {
		|        public ClStream dll_obj;
		|        public System.IO.Stream M_Stream;
		|
		|        public Stream()
		|        {
		|            M_Stream = (System.IO.Stream)new System.IO.MemoryStream();
		|        }
		|		
		|        public Stream(osf.Stream p1)
		|        {
		|            M_Stream = p1.M_Stream;
		|        }
		|
		|        public Stream(System.IO.Stream p1)
		|        {
		|            M_Stream = p1;
		|        }
		|
		|        public virtual bool CanRead
		|        {
		|            get { return M_Stream.CanRead; }
		|        }
		|
		|        public virtual bool CanSeek
		|        {
		|            get { return M_Stream.CanSeek; }
		|        }
		|
		|        public virtual bool CanWrite
		|        {
		|            get { return M_Stream.CanWrite; }
		|        }
		|
		|        public virtual int Length
		|        {
		|            get { return checked((int)M_Stream.Length); }
		|        }
		|
		|        public virtual void Close()
		|        {
		|            M_Stream.Close();
		|        }
		|
		|        public virtual void Flush()
		|        {
		|            M_Stream.Flush();
		|        }
		|
		|        public virtual int Position
		|        {
		|            get { return checked((int)M_Stream.Position); }
		|            set { M_Stream.Position = (long)value; }
		|        }
		|
		|        public virtual int ReadByte()
		|        {
		|            return M_Stream.ReadByte();
		|        }
		|
		|        public virtual int Seek(int offset, int origin)
		|        {
		|            return checked((int)M_Stream.Seek((long)offset, (System.IO.SeekOrigin)origin));
		|        }
		|
		|        public virtual void SetLength(int value)
		|        {
		|            M_Stream.SetLength((long)value);
		|        }
		|
		|        public virtual void Write(object[] buffer, int offset, int count)
		|        {
		|            byte[] Bytes1 = new byte[checked(count)];
		|            for (int i = 0; i < count; i++)
		|            {
		|                Bytes1[i] = Convert.ToByte(buffer[checked(i + offset)]);
		|            }
		|            M_Stream.Write(Bytes1, 0, count);
		|        }
		|
		|        public virtual void WriteByte(byte value)
		|        {
		|            M_Stream.WriteByte(value);
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ImageFormat" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ImageFormat
		|    {
		|        public ClImageFormat dll_obj;
		|        public System.Drawing.Imaging.ImageFormat M_ImageFormat;
		|
		|        public ImageFormat()
		|        {
		|            M_ImageFormat = new System.Drawing.Imaging.ImageFormat(System.Guid.Empty);
		|        }
		|
		|        public ImageFormat(osf.ImageFormat p1)
		|        {
		|            M_ImageFormat = p1.M_ImageFormat;
		|        }
		|		
		|        public ImageFormat(System.Drawing.Imaging.ImageFormat p1)
		|        {
		|            M_ImageFormat = p1;
		|        }
		|
		|        public osf.ImageFormat Bmp
		|        {
		|            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Bmp); }
		|        }
		|
		|        public osf.ImageFormat Gif
		|        {
		|            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Gif); }
		|        }
		|
		|        public osf.ImageFormat Icon
		|        {
		|            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Icon); }
		|        }
		|
		|        public osf.ImageFormat Jpeg
		|        {
		|            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Jpeg); }
		|        }
		|
		|        public osf.ImageFormat Png
		|        {
		|            get { return new ImageFormat(System.Drawing.Imaging.ImageFormat.Png); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Image" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Image
		|    {
		|        public System.Drawing.Image M_Image;
		|		
		|        public Image()
		|        {
		|        }
		|		
		|        public Image(Stream stream)
		|        {
		|            M_Image = System.Drawing.Image.FromStream((System.IO.Stream)stream.M_Stream);
		|        }
		|
		|        public Image(osf.Image p1)
		|        {
		|            M_Image = p1.M_Image;
		|        }
		|		
		|        public Image(System.Drawing.Image p1)
		|        {
		|            M_Image = p1;
		|        }
		|
		|        public int Height
		|        {
		|            get { return M_Image.Height; }
		|        }
		|
		|        public osf.ImageFormat  RawFormat
		|        {
		|            get { return new ImageFormat(M_Image.RawFormat); }
		|        }
		|
		|        public void Save(string p1, ImageFormat p2 = null)
		|        {
		|            if (p2 == null)
		|            {
		|                M_Image.Save(p1);
		|            }
		|            else
		|            {
		|                M_Image.Save(p1, p2.M_ImageFormat);
		|            }
		|        }
		|
		|        public void Save(Stream p1, ImageFormat p2)
		|        {
		|            M_Image.Save(p1.M_Stream, p2.M_ImageFormat);
		|        }
		|
		|        public osf.Size Size
		|        {
		|            get { return new Size(M_Image.Size); }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_Image.Width; }
		|        }
		|		
		|        public void Dispose()
		|        {
		|            M_Image.Dispose();
		|        }
		|
		|        public object Clone()
		|        {
		|            return M_Image.Clone();
		|        }
		|		
		|        public int PixelFormat
		|        {
		|            get { return (int)M_Image.PixelFormat; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Cursor" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Cursor
		|    {
		|        public ClCursor dll_obj;
		|        public System.Windows.Forms.Cursor M_Cursor;
		|
		|        public Cursor()
		|        {
		|            M_Cursor = System.Windows.Forms.Cursor.Current;
		|            OneScriptForms.AddToHashtable(M_Cursor, this);
		|        }
		|
		|        public Cursor(osf.Cursor p1)
		|        {
		|            M_Cursor = p1.M_Cursor;
		|            OneScriptForms.AddToHashtable(M_Cursor, this);
		|        }
		|
		|        public Cursor(System.Windows.Forms.Cursor p1)
		|        {
		|            M_Cursor = p1;
		|            OneScriptForms.AddToHashtable(M_Cursor, this);
		|        }
		|
		|        public osf.Cursor Current
		|        {
		|            get { return new Cursor(System.Windows.Forms.Cursor.Current); }
		|            set { System.Windows.Forms.Cursor.Current = value.M_Cursor; }
		|        }
		|
		|        public osf.Point Position
		|        {
		|            get { return new Point(System.Windows.Forms.Cursor.Position); }
		|            set { System.Windows.Forms.Cursor.Position = value.M_Point; }
		|        }
		|
		|        public osf.Size Size
		|        {
		|            get { return new Size(M_Cursor.Size); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Rectangle" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Rectangle
		|    {
		|        public ClRectangle dll_obj;
		|        public System.Drawing.Rectangle M_Rectangle;
		|
		|        public Rectangle(int x = 0, int y = 0, int width = 0, int height = 0)
		|        {
		|            M_Rectangle = new System.Drawing.Rectangle();
		|            X = x;
		|            Y = y;
		|            Width = width;
		|            Height = height;
		|        }
		|
		|        public Rectangle(osf.Rectangle p1)
		|        {
		|            M_Rectangle = p1.M_Rectangle;
		|            X = p1.X;
		|            Y = p1.Y;
		|            Width = p1.Width;
		|            Height = p1.Height;
		|        }
		|		
		|        public Rectangle(System.Drawing.Rectangle p1)
		|        {
		|            M_Rectangle = p1;
		|            X = p1.X;
		|            Y = p1.Y;
		|            Width = p1.Width;
		|            Height = p1.Height;
		|        }
		|
		|        public int Bottom
		|        {
		|            get { return M_Rectangle.Bottom; }
		|        }
		|
		|        public osf.Rectangle FromSize(Size Size)
		|        {
		|            return new Rectangle(new System.Drawing.Rectangle(0, 0, Size.Width, Size.Height));
		|        }
		|
		|        public int Height
		|        {
		|            get { return M_Rectangle.Height; }
		|            set { M_Rectangle.Height = value; }
		|        }
		|
		|        public osf.Point Location
		|        {
		|            get { return new Point(M_Rectangle.Location); }
		|            set { M_Rectangle.Location = value.M_Point; }
		|        }
		|
		|        public int Left
		|        {
		|            get { return M_Rectangle.Left; }
		|        }
		|
		|        public int Right
		|        {
		|            get { return M_Rectangle.Right; }
		|        }
		|
		|        public osf.Size Size
		|        {
		|            get { return new Size(M_Rectangle.Size); }
		|            set { M_Rectangle.Size = value.M_Size; }
		|        }
		|
		|        public int Top
		|        {
		|            get { return M_Rectangle.Top; }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_Rectangle.Width; }
		|            set { M_Rectangle.Width = value; }
		|        }
		|
		|        public int X
		|        {
		|            get { return M_Rectangle.X; }
		|            set { M_Rectangle.X = value; }
		|        }
		|
		|        public int Y
		|        {
		|            get { return M_Rectangle.Y; }
		|            set { M_Rectangle.Y = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Version" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Version
		|    {
		|        public ClVersion dll_obj;
		|        public System.Version M_Version;
		|		
		|        public Version(System.Version p1)
		|        {
		|            M_Version = p1;
		|        }
		|
		|        public new string ToString()
		|        {
		|            return M_Version.ToString();
		|        }
		|
		|        public int Build
		|        {
		|            get { return M_Version.Build; }
		|        }
		|
		|        public int Major
		|        {
		|            get { return M_Version.Major; }
		|        }
		|
		|        public int Minor
		|        {
		|            get { return M_Version.Minor; }
		|        }
		|
		|        public int Revision
		|        {
		|            get { return M_Version.Revision; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Font" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Font
		|    {
		|        public ClFont dll_obj;
		|        public System.Drawing.Font M_Font;
		|
		|        public Font(string name = null, float size = 0.0f, System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular)
		|        {
		|            M_Font = new System.Drawing.Font(name, size, style);
		|            OneScriptForms.AddToHashtable(M_Font, this);
		|        }
		|
		|        public Font(osf.Font p1)
		|        {
		|            M_Font = p1.M_Font;
		|            OneScriptForms.AddToHashtable(M_Font, this);
		|        }
		|
		|        public Font(System.Drawing.Font p1)
		|        {
		|            M_Font = p1;
		|            OneScriptForms.AddToHashtable(M_Font, this);
		|        }
		|
		|        public int Height
		|        {
		|            get { return M_Font.Height; }
		|        }
		|
		|        public string Name
		|        {
		|            get { return M_Font.Name; }
		|        }
		|
		|        public float Size
		|        {
		|            get { return M_Font.Size; }
		|        }
		|
		|        public int Style
		|        {
		|            get { return (int)M_Font.Style; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "EventArgs" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class EventArgs
		|    {
		|        public ClEventArgs dll_obj;
		|        public string EventString = """";
		|        public dynamic Sender;
		|
		|        public EventArgs()
		|        {
		|            Sender = null;
		|        }
		|
		|        public virtual bool PostEvent()
		|        {
		|            if (Sender.GetType() == typeof(osf.ComboBox))
		|            {
		|                string s = """";
		|                osf.ComboBox ComboBox1 = (osf.ComboBox)Sender;
		|                if (ComboBox1.DrawMode != 0)
		|                {
		|                    dynamic item = ComboBox1.Items[ComboBox1.SelectedIndex];
		|                    if (Sender.GetType() == typeof(osf.ComboBox))
		|                    {
		|                        string ObjType = item.GetType().ToString();
		|                        if (ObjType == ""System.Data.DataRowView"")
		|                        {
		|                            System.Data.DataRowView drv = (System.Data.DataRowView)item;
		|                            try
		|                            {
		|                                dynamic var1 = drv.Row[ComboBox1.DisplayMember];
		|                                System.Type Type1 = var1.GetType();
		|                                s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
		|                            }
		|                            catch
		|                            {
		|                                if (drv.Row[ComboBox1.DisplayMember].GetType() == typeof(System.Boolean))
		|                                {
		|                                    ScriptEngine.Machine.Values.BooleanValue Bool1;
		|                                    if ((System.Boolean)drv.Row[ComboBox1.DisplayMember])
		|                                    {
		|                                        Bool1 = ScriptEngine.Machine.Values.BooleanValue.True;
		|                                    }
		|                                    else
		|                                    {
		|                                        Bool1 = ScriptEngine.Machine.Values.BooleanValue.False;
		|                                    }
		|                                    s = Bool1.ToString();
		|                                }
		|                                else
		|                                {
		|                                    s = drv.Row[ComboBox1.DisplayMember].ToString();
		|                                }
		|                            }
		|                        }
		|                    }
		|                    else if (Sender.GetType() == typeof(osf.ListItem))
		|                    {
		|
		|                    }
		|                    if (s == """")
		|                    {
		|                        try
		|                        {
		|                            System.Type Type1 = item.GetType();
		|                            s = Type1.GetCustomAttribute<ContextClassAttribute>().GetName();
		|                        }
		|                        catch
		|                        {
		|                            s = item.ToString();
		|                        }
		|                    }
		|                    ComboBox1.Text = s;
		|                }
		|            }
		|            return true;
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Size" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Size
		|    {
		|        public ClSize dll_obj;
		|        public System.Drawing.Size M_Size;
		|
		|        public Size(int width = 0, int height = 0)
		|        {
		|            M_Size = new System.Drawing.Size(width, height);
		|        }
		|
		|        public Size(osf.Size p1)
		|        {
		|            M_Size = p1.M_Size;
		|        }
		|		
		|        public Size(System.Drawing.Size p1)
		|        {
		|            M_Size = p1;
		|        }
		|
		|        public int Height
		|        {
		|            get { return M_Size.Height; }
		|            set { M_Size.Height = value; }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_Size.Width; }
		|            set { M_Size.Width = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Point" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Point
		|    {
		|        public ClPoint dll_obj;
		|        public System.Drawing.Point M_Point;
		|
		|        public Point(int x = 0, int y = 0)
		|        {
		|            M_Point = new System.Drawing.Point(x, y);
		|        }
		|		
		|        public Point(osf.Point p1)
		|        {
		|            M_Point = p1.M_Point;
		|        }
		|
		|        public Point(System.Drawing.Point p1)
		|        {
		|            M_Point = p1;
		|        }
		|
		|        public int X
		|        {
		|            get { return M_Point.X; }
		|            set { M_Point.X = value; }
		|        }
		|
		|        public int Y
		|        {
		|            get { return M_Point.Y; }
		|            set { M_Point.Y = value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Color" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Color
		|    {
		|        public ClColor dll_obj;
		|        public System.Drawing.Color M_Color;
		|
		|        public Color()
		|        {
		|            M_Color = System.Drawing.Color.Empty;
		|        }
		|
		|        public Color(osf.Color p1)
		|        {
		|            M_Color = p1.M_Color;
		|        }
		|
		|        public Color(System.Drawing.Color p1)
		|        {
		|            M_Color = p1;
		|        }
		|
		|        //Свойства============================================================
		|        public int A
		|        {
		|            get { return M_Color.A; }
		|        }
		|
		|        public osf.Color ActiveBorder
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ActiveBorder"")); }
		|        }
		|
		|        public osf.Color ActiveCaption
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ActiveCaption"")); }
		|        }
		|
		|        public osf.Color ActiveCaptionText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ActiveCaptionText"")); }
		|        }
		|
		|        public osf.Color AliceBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""AliceBlue"")); }
		|        }
		|
		|        public osf.Color AntiqueWhite
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""AntiqueWhite"")); }
		|        }
		|
		|        public osf.Color AppWorkspace
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""AppWorkspace"")); }
		|        }
		|
		|        public osf.Color Aqua
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Aqua"")); }
		|        }
		|
		|        public osf.Color Aquamarine
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Aquamarine"")); }
		|        }
		|
		|        public osf.Color Azure
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Azure"")); }
		|        }
		|
		|        public int B
		|        {
		|            get { return Convert.ToInt32(M_Color.B); }
		|        }
		|
		|        public osf.Color Beige
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Beige"")); }
		|        }
		|
		|        public osf.Color Bisque
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Bisque"")); }
		|        }
		|
		|        public osf.Color Black
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Black"")); }
		|        }
		|
		|        public osf.Color BlanchedAlmond
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""BlanchedAlmond"")); }
		|        }
		|
		|        public osf.Color Blue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Blue"")); }
		|        }
		|
		|        public osf.Color BlueViolet
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""BlueViolet"")); }
		|        }
		|
		|        public osf.Color Brown
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Brown"")); }
		|        }
		|
		|        public osf.Color BurlyWood
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""BurlyWood"")); }
		|        }
		|
		|        public osf.Color CadetBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""CadetBlue"")); }
		|        }
		|
		|        public osf.Color Chartreuse
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Chartreuse"")); }
		|        }
		|
		|        public osf.Color Chocolate
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Chocolate"")); }
		|        }
		|
		|        public osf.Color Control
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Control"")); }
		|        }
		|
		|        public osf.Color ControlDark
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ControlDark"")); }
		|        }
		|
		|        public osf.Color ControlDarkDark
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ControlDarkDark"")); }
		|        }
		|
		|        public osf.Color ControlLight
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ControlLight"")); }
		|        }
		|
		|        public osf.Color ControlLightLight
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ControlLightLight"")); }
		|        }
		|
		|        public osf.Color ControlText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ControlText"")); }
		|        }
		|
		|        public osf.Color Coral
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Coral"")); }
		|        }
		|
		|        public osf.Color CornflowerBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""CornflowerBlue"")); }
		|        }
		|
		|        public osf.Color Cornsilk
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Cornsilk"")); }
		|        }
		|
		|        public osf.Color Crimson
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Crimson"")); }
		|        }
		|
		|        public osf.Color Cyan
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Cyan"")); }
		|        }
		|
		|        public osf.Color DarkBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkBlue"")); }
		|        }
		|
		|        public osf.Color DarkCyan
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkCyan"")); }
		|        }
		|
		|        public osf.Color DarkGoldenrod
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkGoldenrod"")); }
		|        }
		|
		|        public osf.Color DarkGray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkGray"")); }
		|        }
		|
		|        public osf.Color DarkGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkGreen"")); }
		|        }
		|
		|        public osf.Color DarkKhaki
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkKhaki"")); }
		|        }
		|
		|        public osf.Color DarkMagenta
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkMagenta"")); }
		|        }
		|
		|        public osf.Color DarkOliveGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkOliveGreen"")); }
		|        }
		|
		|        public osf.Color DarkOrange
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkOrange"")); }
		|        }
		|
		|        public osf.Color DarkOrchid
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkOrchid"")); }
		|        }
		|
		|        public osf.Color DarkRed
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkRed"")); }
		|        }
		|
		|        public osf.Color DarkSalmon
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkSalmon"")); }
		|        }
		|
		|        public osf.Color DarkSeaGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkSeaGreen"")); }
		|        }
		|
		|        public osf.Color DarkSlateBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkSlateBlue"")); }
		|        }
		|
		|        public osf.Color DarkSlateGray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkSlateGray"")); }
		|        }
		|
		|        public osf.Color DarkTurquoise
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkTurquoise"")); }
		|        }
		|
		|        public osf.Color DarkViolet
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DarkViolet"")); }
		|        }
		|
		|        public osf.Color DeepPink
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DeepPink"")); }
		|        }
		|
		|        public osf.Color DeepSkyBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DeepSkyBlue"")); }
		|        }
		|
		|        public osf.Color Desktop
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Desktop"")); }
		|        }
		|
		|        public osf.Color DimGray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DimGray"")); }
		|        }
		|
		|        public osf.Color DodgerBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""DodgerBlue"")); }
		|        }
		|
		|        public osf.Color Firebrick
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Firebrick"")); }
		|        }
		|
		|        public osf.Color FloralWhite
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""FloralWhite"")); }
		|        }
		|
		|        public osf.Color ForestGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ForestGreen"")); }
		|        }
		|
		|        public osf.Color Fuchsia
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Fuchsia"")); }
		|        }
		|
		|        public int G
		|        {
		|            get { return Convert.ToInt32(M_Color.G); }
		|        }
		|
		|        public osf.Color Gainsboro
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Gainsboro"")); }
		|        }
		|
		|        public osf.Color GhostWhite
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""GhostWhite"")); }
		|        }
		|
		|        public osf.Color Gold
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Gold"")); }
		|        }
		|
		|        public osf.Color Goldenrod
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Goldenrod"")); }
		|        }
		|
		|        public osf.Color Gray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Gray"")); }
		|        }
		|
		|        public osf.Color GrayText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""GrayText"")); }
		|        }
		|
		|        public osf.Color Green
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Green"")); }
		|        }
		|
		|        public osf.Color GreenYellow
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""GreenYellow"")); }
		|        }
		|
		|        public osf.Color Highlight
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Highlight"")); }
		|        }
		|
		|        public osf.Color HighlightText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""HighlightText"")); }
		|        }
		|
		|        public osf.Color Honeydew
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Honeydew"")); }
		|        }
		|
		|        public osf.Color HotPink
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""HotPink"")); }
		|        }
		|
		|        public osf.Color HotTrack
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""HotTrack"")); }
		|        }
		|
		|        public osf.Color InactiveBorder
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""InactiveBorder"")); }
		|        }
		|
		|        public osf.Color InactiveCaption
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""InactiveCaption"")); }
		|        }
		|
		|        public osf.Color InactiveCaptionText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""InactiveCaptionText"")); }
		|        }
		|
		|        public osf.Color IndianRed
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""IndianRed"")); }
		|        }
		|
		|        public osf.Color Indigo
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Indigo"")); }
		|        }
		|
		|        public osf.Color Info
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Info"")); }
		|        }
		|
		|        public osf.Color InfoText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""InfoText"")); }
		|        }
		|
		|        public bool IsEmpty
		|        {
		|            get { return M_Color.IsEmpty; }
		|        }
		|
		|        public osf.Color Ivory
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Ivory"")); }
		|        }
		|
		|        public osf.Color Khaki
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Khaki"")); }
		|        }
		|
		|        public osf.Color Lavender
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Lavender"")); }
		|        }
		|
		|        public osf.Color LavenderBlush
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LavenderBlush"")); }
		|        }
		|
		|        public osf.Color LawnGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LawnGreen"")); }
		|        }
		|
		|        public osf.Color LemonChiffon
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LemonChiffon"")); }
		|        }
		|
		|        public osf.Color LightBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightBlue"")); }
		|        }
		|
		|        public osf.Color LightCoral
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightCoral"")); }
		|        }
		|
		|        public osf.Color LightCyan
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightCyan"")); }
		|        }
		|
		|        public osf.Color LightGoldenrodYellow
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightGoldenrodYellow"")); }
		|        }
		|
		|        public osf.Color LightGray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightGray"")); }
		|        }
		|
		|        public osf.Color LightGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightGreen"")); }
		|        }
		|
		|        public osf.Color LightPink
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightPink"")); }
		|        }
		|
		|        public osf.Color LightSalmon
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightSalmon"")); }
		|        }
		|
		|        public osf.Color LightSeaGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightSeaGreen"")); }
		|        }
		|
		|        public osf.Color LightSkyBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightSkyBlue"")); }
		|        }
		|
		|        public osf.Color LightSlateGray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightSlateGray"")); }
		|        }
		|
		|        public osf.Color LightSteelBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightSteelBlue"")); }
		|        }
		|
		|        public osf.Color LightYellow
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LightYellow"")); }
		|        }
		|
		|        public osf.Color Lime
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Lime"")); }
		|        }
		|
		|        public osf.Color LimeGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""LimeGreen"")); }
		|        }
		|
		|        public osf.Color Linen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Linen"")); }
		|        }
		|
		|        public osf.Color Magenta
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Magenta"")); }
		|        }
		|
		|        public osf.Color Maroon
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Maroon"")); }
		|        }
		|
		|        public osf.Color MediumAquamarine
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumAquamarine"")); }
		|        }
		|
		|        public osf.Color MediumBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumBlue"")); }
		|        }
		|
		|        public osf.Color MediumOrchid
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumOrchid"")); }
		|        }
		|
		|        public osf.Color MediumPurple
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumPurple"")); }
		|        }
		|
		|        public osf.Color MediumSeaGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumSeaGreen"")); }
		|        }
		|
		|        public osf.Color MediumSlateBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumSlateBlue"")); }
		|        }
		|
		|        public osf.Color MediumSpringGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumSpringGreen"")); }
		|        }
		|
		|        public osf.Color MediumTurquoise
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumTurquoise"")); }
		|        }
		|
		|        public osf.Color MediumVioletRed
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MediumVioletRed"")); }
		|        }
		|
		|        public osf.Color Menu
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Menu"")); }
		|        }
		|
		|        public osf.Color MenuText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MenuText"")); }
		|        }
		|
		|        public osf.Color MidnightBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MidnightBlue"")); }
		|        }
		|
		|        public osf.Color MintCream
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MintCream"")); }
		|        }
		|
		|        public osf.Color MistyRose
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""MistyRose"")); }
		|        }
		|
		|        public osf.Color Moccasin
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Moccasin"")); }
		|        }
		|
		|        public string Name
		|        {
		|            get { return M_Color.Name; }
		|        }
		|
		|        public osf.Color NavajoWhite
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""NavajoWhite"")); }
		|        }
		|
		|        public osf.Color Navy
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Navy"")); }
		|        }
		|
		|        public osf.Color OldLace
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""OldLace"")); }
		|        }
		|
		|        public osf.Color Olive
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Olive"")); }
		|        }
		|
		|        public osf.Color OliveDrab
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""OliveDrab"")); }
		|        }
		|
		|        public osf.Color Orange
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Orange"")); }
		|        }
		|
		|        public osf.Color OrangeRed
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""OrangeRed"")); }
		|        }
		|
		|        public osf.Color Orchid
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Orchid"")); }
		|        }
		|
		|        public osf.Color PaleGoldenrod
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PaleGoldenrod"")); }
		|        }
		|
		|        public osf.Color PaleGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PaleGreen"")); }
		|        }
		|
		|        public osf.Color PaleTurquoise
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PaleTurquoise"")); }
		|        }
		|
		|        public osf.Color PaleVioletRed
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PaleVioletRed"")); }
		|        }
		|
		|        public osf.Color PapayaWhip
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PapayaWhip"")); }
		|        }
		|
		|        public osf.Color PeachPuff
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PeachPuff"")); }
		|        }
		|
		|        public osf.Color Peru
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Peru"")); }
		|        }
		|
		|        public osf.Color Pink
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Pink"")); }
		|        }
		|
		|        public osf.Color Plum
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Plum"")); }
		|        }
		|
		|        public osf.Color PowderBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""PowderBlue"")); }
		|        }
		|
		|        public osf.Color Purple
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Purple"")); }
		|        }
		|
		|        public int R
		|        {
		|            get { return Convert.ToInt32(M_Color.R); }
		|        }
		|
		|        public osf.Color Red
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Red"")); }
		|        }
		|
		|        public osf.Color RosyBrown
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""RosyBrown"")); }
		|        }
		|
		|        public osf.Color RoyalBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""RoyalBlue"")); }
		|        }
		|
		|        public osf.Color SaddleBrown
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SaddleBrown"")); }
		|        }
		|
		|        public osf.Color Salmon
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Salmon"")); }
		|        }
		|
		|        public osf.Color SandyBrown
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SandyBrown"")); }
		|        }
		|
		|        public osf.Color ScrollBar
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""ScrollBar"")); }
		|        }
		|
		|        public osf.Color SeaGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SeaGreen"")); }
		|        }
		|
		|        public osf.Color SeaShell
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SeaShell"")); }
		|        }
		|
		|        public osf.Color Sienna
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Sienna"")); }
		|        }
		|
		|        public osf.Color Silver
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Silver"")); }
		|        }
		|
		|        public osf.Color SkyBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SkyBlue"")); }
		|        }
		|
		|        public osf.Color SlateBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SlateBlue"")); }
		|        }
		|
		|        public osf.Color SlateGray
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SlateGray"")); }
		|        }
		|
		|        public osf.Color Snow
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Snow"")); }
		|        }
		|
		|        public osf.Color SpringGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SpringGreen"")); }
		|        }
		|
		|        public osf.Color SteelBlue
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""SteelBlue"")); }
		|        }
		|
		|        public osf.Color Tan
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Tan"")); }
		|        }
		|
		|        public osf.Color Teal
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Teal"")); }
		|        }
		|
		|        public osf.Color Thistle
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Thistle"")); }
		|        }
		|
		|        public osf.Color Tomato
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Tomato"")); }
		|        }
		|
		|        public osf.Color Transparent
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Transparent"")); }
		|        }
		|
		|        public osf.Color Turquoise
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Turquoise"")); }
		|        }
		|
		|        public osf.Color Violet
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Violet"")); }
		|        }
		|
		|        public osf.Color Wheat
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Wheat"")); }
		|        }
		|
		|        public osf.Color White
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""White"")); }
		|        }
		|
		|        public osf.Color WhiteSmoke
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""WhiteSmoke"")); }
		|        }
		|
		|        public osf.Color Window
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Window"")); }
		|        }
		|
		|        public osf.Color WindowFrame
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""WindowFrame"")); }
		|        }
		|
		|        public osf.Color WindowText
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""WindowText"")); }
		|        }
		|
		|        public osf.Color Yellow
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""Yellow"")); }
		|        }
		|
		|        public osf.Color YellowGreen
		|        {
		|            get { return new Color(System.Drawing.Color.FromName(""YellowGreen"")); }
		|        }
		|
		|        //Методы============================================================
		|        public osf.Color FromArgb(int a, int r, int g, int b)
		|        {
		|            return new Color(System.Drawing.Color.FromArgb(a, r, g, b));
		|        }
		|
		|        public osf.Color FromName(string p1)
		|        {
		|            return new Color(System.Drawing.Color.FromName(p1));
		|        }
		|
		|        public osf.Color FromRgb(int r, int g, int b)
		|        {
		|            return new Color(System.Drawing.Color.FromArgb(r, g, b));
		|        }
		|
		|        public int ToArgb()
		|        {
		|            return M_Color.ToArgb();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Button" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ButtonEx : System.Windows.Forms.Button
		|    {
		|        public osf.Button M_Object;
		|    }//endClass
		|
		|    public class Button : ButtonBase
		|    {
		|        public ClButton dll_obj;
		|        public ButtonEx M_Button;
		|
		|        public Button()
		|        {
		|            M_Button = new ButtonEx();
		|            M_Button.M_Object = this;
		|            base.M_ButtonBase = M_Button;
		|        }
		|
		|        public Button(osf.Button p1)
		|        {
		|            M_Button = p1.M_Button;
		|            M_Button.M_Object = this;
		|            base.M_ButtonBase = M_Button;
		|        }
		|
		|        public Button(System.Windows.Forms.Button p1)
		|        {
		|            M_Button = (ButtonEx)p1;
		|            M_Button.M_Object = this;
		|            base.M_ButtonBase = M_Button;
		|        }
		|
		|        public int DialogResult
		|        {
		|            get { return (int)M_Button.DialogResult; }
		|            set { M_Button.DialogResult = (System.Windows.Forms.DialogResult)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ScrollableControl" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ScrollableControl : Control
		|    {
		|        private System.Windows.Forms.ScrollableControl m_ScrollableControl;
		|
		|        public System.Windows.Forms.ScrollableControl M_ScrollableControl
		|        {
		|            get { return m_ScrollableControl; }
		|            set
		|            {
		|                m_ScrollableControl = value;
		|                base.M_Control = m_ScrollableControl;
		|            }
		|        }
		|		
		|        public bool AutoScroll
		|        {
		|            get { return m_ScrollableControl.AutoScroll; }
		|            set { m_ScrollableControl.AutoScroll = value; }
		|        }
		|
		|        public osf.Size AutoScrollMargin
		|        {
		|            get { return new Size(m_ScrollableControl.AutoScrollMargin); }
		|            set { m_ScrollableControl.AutoScrollMargin = value.M_Size; }
		|        }
		|
		|        public osf.DockPaddingEdges DockPadding
		|        {
		|            get { return new DockPaddingEdges(m_ScrollableControl.DockPadding); }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Form" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class FormEx : System.Windows.Forms.Form
		|    {
		|        public osf.Form M_Object;
		|    }//endClass
		|
		|    public class Form : ContainerControl
		|    {
		|        public ClForm dll_obj;
		|        public FormEx M_Form;
		|        public string Closed;
		|        private string activated;
		|        private string deactivate;
		|        private string load;
		|        private string resize;
		|        private string mdiChildActivate;
		|
		|        [DllImport(""user32"", CharSet = CharSet.Ansi, SetLastError = true)] public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
		|        [DllImport(""User32"", EntryPoint = ""GetKeyState"", CharSet = CharSet.Ansi, SetLastError = true)] public static extern short UserGetKeyState(int nVirtKey);
		|
		|        public Form()
		|        {
		|            M_Form = new FormEx();
		|            M_Form.M_Object = this;
		|            base.M_ContainerControl = M_Form;
		|            M_Form.FormClosed += M_Form_FormClosed;
		|            Closed = """";
		|            M_Form.Load += M_Form_Load;
		|            Load = """";
		|            M_Form.Deactivate += M_Form_Deactivate;
		|            Deactivate = """";
		|            M_Form.Activated += M_Form_Activated;
		|            Activated = """";
		|            M_Form.FormClosing += M_Form_FormClosing;
		|            Closing = """";
		|        }
		|
		|        public Form(osf.Form p1)
		|        {
		|            M_Form = p1.M_Form;
		|            M_Form.M_Object = this;
		|            base.M_ContainerControl = M_Form;
		|            M_Form.FormClosed += M_Form_FormClosed;
		|            Closed = """";
		|            M_Form.Load += M_Form_Load;
		|            Load = """";
		|            M_Form.Deactivate += M_Form_Deactivate;
		|            Deactivate = """";
		|            M_Form.Activated += M_Form_Activated;
		|            Activated = """";
		|            M_Form.FormClosing += M_Form_FormClosing;
		|            Closing = """";
		|        }
		|
		|        public Form(System.Windows.Forms.Form p1)
		|        {
		|            M_Form = (FormEx)p1;
		|            M_Form.M_Object = this;
		|            base.M_ContainerControl = M_Form;
		|            M_Form.FormClosed += M_Form_FormClosed;
		|            Closed = """";
		|            M_Form.Load += M_Form_Load;
		|            Load = """";
		|            M_Form.Deactivate += M_Form_Deactivate;
		|            Deactivate = """";
		|            M_Form.Activated += M_Form_Activated;
		|            Activated = """";
		|            M_Form.FormClosing += M_Form_FormClosing;
		|            Closing = """";
		|        }
		|		
		|        public void M_Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		|        {
		|            if (Closing.Length > 0)
		|            {
		|                FormClosingEventArgs FormClosingEventArgs1 = new FormClosingEventArgs(e.CloseReason, e.Cancel);
		|                FormClosingEventArgs1.EventString = Closing;
		|                FormClosingEventArgs1.Sender = this;
		|                FormClosingEventArgs1.Cancel = e.Cancel;
		|                FormClosingEventArgs1.CloseReason = (int)e.CloseReason;
		|                OneScriptForms.EventQueue.Add(FormClosingEventArgs1);
		|                ClFormClosingEventArgs ClFormClosingEventArgs1 = new ClFormClosingEventArgs(FormClosingEventArgs1);
		|                e.Cancel = true;
		|            }
		|        }
		|		
		|        private void M_Form_Activated(object sender, System.EventArgs e)
		|        {
		|            if (Activated.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Activated;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|		
		|        private void M_Form_Deactivate(object sender, System.EventArgs e)
		|        {
		|            if (Deactivate.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Deactivate;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		
		|
		|        private void M_Form_Load(object sender, System.EventArgs e)
		|        {
		|            if (Load.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Load;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|
		|        private void M_Form_FormClosed(object sender, FormClosedEventArgs e)
		|        {
		|            EventArgs EventArgs1 = new EventArgs();
		|            EventArgs1.EventString = Closed;
		|            EventArgs1.Sender = this;
		|            OneScriptForms.EventQueue.Add(EventArgs1);
		|            ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            if (sender == OneScriptForms.FirstForm.Base_obj.M_Form)
		|            {
		|                OneScriptForms.goOn = false;
		|                EventArgs EventArgs2 = new EventArgs();
		|                EventArgs2.EventString = ""Sleep(20)"";
		|                EventArgs2.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs2);
		|                ClEventArgs ClEventArgs2 = new ClEventArgs(EventArgs2);
		|            }
		|        }
		|
		|        public osf.Form ActiveForm
		|        {
		|            get
		|            {
		|                if (System.Windows.Forms.Form.ActiveForm != null)
		|                {
		|                    return (osf.Form)((FormEx)System.Windows.Forms.Form.ActiveForm).M_Object;
		|                }
		|                return null;
		|            }
		|        }
		|
		|        public void Activate()
		|        {
		|            M_Form.Activate();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public osf.Control AcceptButton
		|        {
		|            get
		|            {
		|                if (M_Form.AcceptButton != null)
		|                {
		|                    return (osf.Control)((dynamic)M_Form.AcceptButton).M_Object;
		|                }
		|                return null;
		|            }
		|            set { M_Form.AcceptButton = (IButtonControl)value.M_Control; }
		|        }
		|
		|        public string Activated
		|        {
		|            get { return activated; }
		|            set { activated = value; }
		|        }
		|
		|        public osf.Form ActiveMdiChild
		|        {
		|            get
		|            {
		|                if (M_Form.ActiveMdiChild != null)
		|                {
		|                    return (osf.Form)((dynamic)M_Form.ActiveMdiChild).M_Object;
		|                }
		|                return null;
		|            }
		|        }
		|
		|        public osf.Size AutoScaleBaseSize
		|        {
		|            get { return new Size(M_Form.AutoScaleBaseSize); }
		|            set
		|            {
		|                M_Form.AutoScaleBaseSize = value.M_Size;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Control CancelButton
		|        {
		|            get
		|            {
		|                if (M_Form.CancelButton != null)
		|                {
		|                    return (osf.Control)((dynamic)M_Form.CancelButton).M_Object;
		|                }
		|                return null;
		|            }
		|            set
		|            {
		|                M_Form.CancelButton = (IButtonControl)value.M_Control;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void Close()
		|        {
		|            M_Form.Close();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public string Closing;
		|
		|        public bool ControlBox
		|        {
		|            get { return M_Form.ControlBox; }
		|            set
		|            {
		|                M_Form.ControlBox = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Deactivate
		|        {
		|            get { return deactivate; }
		|            set
		|            {
		|                deactivate = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Point DesktopLocation
		|        {
		|            get { return new Point(M_Form.DesktopLocation.X, M_Form.DesktopLocation.Y); }
		|            set
		|            {
		|                M_Form.DesktopLocation = value.M_Point;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int DialogResult
		|        {
		|            get { return (int)M_Form.DialogResult; }
		|            set
		|            {
		|                M_Form.DialogResult = (System.Windows.Forms.DialogResult)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int FormBorderStyle
		|        {
		|            get { return (int)M_Form.FormBorderStyle; }
		|            set
		|            {
		|                M_Form.FormBorderStyle = (System.Windows.Forms.FormBorderStyle)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int GetKeyState(Keys Key)
		|        {
		|            return (int)UserGetKeyState((int)Key);
		|        }
		|
		|        public Icon Icon
		|        {
		|            get { return new Icon(M_Form.Icon); }
		|            set
		|            {
		|                M_Form.Icon = (System.Drawing.Icon)value.M_Icon;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool IsMdiChild
		|        {
		|            get { return M_Form.IsMdiChild; }
		|        }
		|
		|        public bool IsMdiContainer
		|        {
		|            get { return M_Form.IsMdiContainer; }
		|            set
		|            {
		|                M_Form.IsMdiContainer = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool KeyPreview
		|        {
		|            get { return M_Form.KeyPreview; }
		|            set
		|            {
		|                M_Form.KeyPreview = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public void LayoutMdi(MdiLayout value)
		|        {
		|            M_Form.LayoutMdi((System.Windows.Forms.MdiLayout)value);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public new int Left
		|        {
		|            get { return M_Form.Left; }
		|            set
		|            {
		|                M_Form.Left = value;
		|                M_Form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Load
		|        {
		|            get { return load; }
		|            set
		|            {
		|                load = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool MaximizeBox
		|        {
		|            get { return M_Form.MaximizeBox; }
		|            set
		|            {
		|                M_Form.MaximizeBox = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Size MaximumSize
		|        {
		|            get { return new Size(M_Form.MaximumSize); }
		|            set
		|            {
		|                M_Form.MaximumSize = value.M_Size;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string MdiChildActivate
		|        {
		|            get { return mdiChildActivate; }
		|            set
		|            {
		|                mdiChildActivate = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.MainMenu Menu
		|        {
		|            get { return ((MainMenuEx)M_Form.Menu).M_Object; }
		|            set
		|            {
		|                M_Form.Menu = (System.Windows.Forms.MainMenu)value.M_MainMenu;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool MinimizeBox
		|        {
		|            get { return M_Form.MinimizeBox; }
		|            set
		|            {
		|                M_Form.MinimizeBox = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Size MinimumSize
		|        {
		|            get { return new Size(M_Form.MinimumSize); }
		|            set
		|            {
		|                M_Form.MinimumSize = value.M_Size;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Form Owner
		|        {
		|            get
		|            {
		|                if (M_Form.Owner != null)
		|                {
		|                    return (osf.Form)((FormEx)M_Form.Owner).M_Object;
		|                }
		|                return null;
		|            }
		|            set
		|            {
		|                M_Form.Owner = (System.Windows.Forms.Form)value.M_Form;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new object Parent
		|        {
		|            get
		|            {
		|                if (M_Form.Owner != null)
		|                {
		|                    return ((FormEx)M_Form.Owner).M_Object;
		|                }
		|                return null;
		|            }
		|            set
		|            {
		|                Form.SetParent(M_Form.Handle, ((Control)value).M_Control.Handle);
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public string Resize
		|        {
		|            get { return resize; }
		|            set
		|            {
		|                resize = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int ShowDialog()
		|        {
		|            System.Windows.Forms.Application.DoEvents();
		|            System.Windows.Forms.DialogResult DialogResult1 = System.Windows.Forms.DialogResult.None;
		|            var thread = new Thread(() =>
		|            {
		|                DialogResult1 = (System.Windows.Forms.DialogResult)M_Form.ShowDialog();
		|            }
		|            );
		|            thread.IsBackground = true;
		|            thread.SetApartmentState(ApartmentState.STA);
		|            thread.Start();
		|            thread.Join();
		|
		|            return (int)DialogResult1;
		|        }
		|
		|        public bool ShowInTaskbar
		|        {
		|            get { return M_Form.ShowInTaskbar; }
		|            set
		|            {
		|                M_Form.ShowInTaskbar = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int StartPosition
		|        {
		|            get { return (int)M_Form.StartPosition; }
		|            set
		|            {
		|                M_Form.StartPosition = (System.Windows.Forms.FormStartPosition)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public new int Top
		|        {
		|            get { return M_Form.Top; }
		|            set
		|            {
		|                M_Form.Top = value;
		|                M_Form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public bool TopMost
		|        {
		|            get { return M_Form.TopMost; }
		|            set
		|            {
		|                M_Form.TopMost = value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Color TransparencyKey
		|        {
		|            get { return new Color(M_Form.TransparencyKey); }
		|            set
		|            {
		|                M_Form.TransparencyKey = value.M_Color;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int WindowState
		|        {
		|            get { return (int)M_Form.WindowState; }
		|            set
		|            {
		|                M_Form.WindowState = (System.Windows.Forms.FormWindowState)value;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Control" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Control : Component
		|    {
		|        private System.Windows.Forms.Control m_Control;
		|		
		|        [DllImport(""user32"", EntryPoint = ""SendMessageA"", CharSet = CharSet.Auto, SetLastError = true)] public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		|		
		|        public System.Windows.Forms.Control M_Control
		|        {
		|            get { return m_Control; }
		|            set
		|            {
		|                m_Control = value;
		|                base.M_Component = m_Control;
		|                m_Control.DoubleClick += m_Control_DoubleClick;
		|                DoubleClick = """";
		|                m_Control.KeyUp += m_Control_KeyUp;
		|                KeyUp = """";
		|                m_Control.KeyDown += m_Control_KeyDown;
		|                KeyDown = """";
		|                m_Control.KeyPress += m_Control_KeyPress;
		|                KeyPress = """";
		|                m_Control.MouseEnter += m_Control_MouseEnter;
		|                MouseEnter = """";
		|                m_Control.MouseLeave += m_Control_MouseLeave;
		|                MouseLeave = """";
		|                m_Control.Click += m_Control_Click;
		|                Click = """";
		|                m_Control.LocationChanged += m_Control_LocationChanged;
		|                LocationChanged = """";
		|                m_Control.Enter += m_Control_Enter;
		|                Enter = """";
		|                m_Control.MouseHover += m_Control_MouseHover;
		|                MouseHover = """";
		|                m_Control.MouseDown += m_Control_MouseDown;
		|                MouseDown = """";
		|                m_Control.MouseUp += m_Control_MouseUp;
		|                MouseUp = """";
		|                m_Control.Move += m_Control_Move;
		|                Move = """";
		|                m_Control.MouseMove += m_Control_MouseMove;
		|                MouseMove = """";
		|                m_Control.Paint += m_Control_Paint;
		|                Paint = """";
		|                m_Control.LostFocus += m_Control_LostFocus;
		|                LostFocus = """";
		|                m_Control.Leave += m_Control_Leave;
		|                Leave = """";
		|                m_Control.SizeChanged += m_Control_SizeChanged;
		|                SizeChanged = """";
		|                m_Control.TextChanged += m_Control_TextChanged;
		|                TextChanged = """";
		|                m_Control.ControlAdded += m_Control_ControlAdded;
		|                ControlAdded = """";
		|                m_Control.ControlRemoved += m_Control_ControlRemoved;
		|                ControlRemoved = """";
		|            }//endset
		|        }
		|
		|        public Control(System.Windows.Forms.Control control = null)
		|        {
		|        }
		|        
		|        private void m_Control_DoubleClick(object sender, System.EventArgs e)
		|        {
		|            if (DoubleClick.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = DoubleClick;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		|        {
		|            if (KeyUp.Length > 0)
		|            {
		|                KeyEventArgs KeyEventArgs1 = new KeyEventArgs();
		|                KeyEventArgs1.EventString = KeyUp;
		|                KeyEventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(KeyEventArgs1);
		|                ClKeyEventArgs ClKeyEventArgs1 = new ClKeyEventArgs(KeyEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		|        {
		|            if (KeyDown.Length > 0)
		|            {
		|                KeyEventArgs KeyEventArgs1 = new KeyEventArgs();
		|                KeyEventArgs1.EventString = KeyDown;
		|                KeyEventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(KeyEventArgs1);
		|                ClKeyEventArgs ClKeyEventArgs1 = new ClKeyEventArgs(KeyEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		|        {
		|            if (KeyPress.Length > 0)
		|            {
		|                KeyPressEventArgs KeyPressEventArgs1 = new KeyPressEventArgs();
		|                KeyPressEventArgs1.EventString = KeyPress;
		|                KeyPressEventArgs1.Sender = this;
		|                KeyPressEventArgs1.KeyChar = Convert.ToString(e.KeyChar);
		|                OneScriptForms.EventQueue.Add(KeyPressEventArgs1);
		|                ClKeyPressEventArgs ClKeyPressEventArgs1 = new ClKeyPressEventArgs(KeyPressEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_MouseEnter(object sender, System.EventArgs e)
		|        {
		|            if (MouseEnter.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = MouseEnter;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_MouseLeave(object sender, System.EventArgs e)
		|        {
		|            if (MouseLeave.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = MouseLeave;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_Click(object sender, System.EventArgs e)
		|        {
		|            if (Click.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Click;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_LocationChanged(object sender, System.EventArgs e)
		|        {
		|            if (LocationChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = LocationChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_Enter(object sender, System.EventArgs e)
		|        {
		|            if (Enter.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Enter;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_MouseHover(object sender, System.EventArgs e)
		|        {
		|            if (MouseHover.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = MouseHover;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		|        {
		|            if (MouseDown.Length > 0)
		|            {
		|                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
		|                MouseEventArgs1.EventString = MouseDown;
		|                MouseEventArgs1.Sender = this;
		|                MouseEventArgs1.Clicks = e.Clicks;
		|                MouseEventArgs1.Button = (int)e.Button;
		|                MouseEventArgs1.X = e.X;
		|                MouseEventArgs1.Y = e.Y;
		|                OneScriptForms.EventQueue.Add(MouseEventArgs1);
		|                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		|        {
		|            if (MouseUp.Length > 0)
		|            {
		|                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
		|                MouseEventArgs1.EventString = MouseUp;
		|                MouseEventArgs1.Sender = this;
		|                MouseEventArgs1.Clicks = e.Clicks;
		|                MouseEventArgs1.Button = (int)e.Button;
		|                MouseEventArgs1.X = e.X;
		|                MouseEventArgs1.Y = e.Y;
		|                OneScriptForms.EventQueue.Add(MouseEventArgs1);
		|                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_Move(object sender, System.EventArgs e)
		|        {
		|            if (Move.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Move;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		|        {
		|            if (MouseMove.Length > 0)
		|            {
		|                MouseEventArgs MouseEventArgs1 = new MouseEventArgs();
		|                MouseEventArgs1.EventString = MouseMove;
		|                MouseEventArgs1.Sender = this;
		|                MouseEventArgs1.Clicks = e.Clicks;
		|                MouseEventArgs1.Button = (int)e.Button;
		|                MouseEventArgs1.X = e.X;
		|                MouseEventArgs1.Y = e.Y;
		|                OneScriptForms.EventQueue.Add(MouseEventArgs1);
		|                ClMouseEventArgs ClMouseEventArgs1 = new ClMouseEventArgs(MouseEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		|        {
		|            if (Paint.Length > 0)
		|            {
		|                PaintEventArgs PaintEventArgs1 = new PaintEventArgs();
		|                PaintEventArgs1.EventString = Paint;
		|                PaintEventArgs1.Sender = this;
		|                PaintEventArgs1.Graphics = new Graphics(M_Control.CreateGraphics());
		|                PaintEventArgs1.ClipRectangle = new Rectangle(e.ClipRectangle);
		|                OneScriptForms.EventQueue.Add(PaintEventArgs1);
		|                ClPaintEventArgs ClPaintEventArgs1 = new ClPaintEventArgs(PaintEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_LostFocus(object sender, System.EventArgs e)
		|        {
		|            if (LostFocus.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = LostFocus;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_Leave(object sender, System.EventArgs e)
		|        {
		|            if (Leave.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = Leave;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_SizeChanged(object sender, System.EventArgs e)
		|        {
		|            if (SizeChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = SizeChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_TextChanged(object sender, System.EventArgs e)
		|        {
		|            if (TextChanged.Length > 0)
		|            {
		|                EventArgs EventArgs1 = new EventArgs();
		|                EventArgs1.EventString = TextChanged;
		|                EventArgs1.Sender = this;
		|                OneScriptForms.EventQueue.Add(EventArgs1);
		|                ClEventArgs ClEventArgs1 = new ClEventArgs(EventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
		|        {
		|            if (ControlAdded.Length > 0)
		|            {
		|                ControlEventArgs ControlEventArgs1 = new ControlEventArgs();
		|                ControlEventArgs1.EventString = ControlAdded;
		|                ControlEventArgs1.Sender = this;
		|                ControlEventArgs1.Control = e.Control;
		|                OneScriptForms.EventQueue.Add(ControlEventArgs1);
		|                ClControlEventArgs ClControlEventArgs1 = new ClControlEventArgs(ControlEventArgs1);
		|            }
		|        }
		|        
		|        private void m_Control_ControlRemoved(object sender, System.Windows.Forms.ControlEventArgs e)
		|        {
		|            if (ControlRemoved.Length > 0)
		|            {
		|                ControlEventArgs ControlEventArgs1 = new ControlEventArgs();
		|                ControlEventArgs1.EventString = ControlRemoved;
		|                ControlEventArgs1.Sender = this;
		|                ControlEventArgs1.Control = e.Control;
		|                OneScriptForms.EventQueue.Add(ControlEventArgs1);
		|                ClControlEventArgs ClControlEventArgs1 = new ClControlEventArgs(ControlEventArgs1);
		|            }
		|        }
		|
		|        //Свойства============================================================
		|        public string ProductVersion
		|        {
		|            get { return M_Control.ProductVersion; }
		|        }
		|
		|        public int Top
		|        {
		|            get { return M_Control.Top; }
		|            set { M_Control.Top = value; }
		|        }
		|
		|        public int Height
		|        {
		|            get { return M_Control.Height; }
		|            set { M_Control.Height = value; }
		|        }
		|
		|        public int FontHeight
		|        {
		|            get { return Convert.ToInt32(M_Control.Font.Height); }
		|        }
		|
		|        public osf.Rectangle Bounds
		|        {
		|            get { return new Rectangle(M_Control.Bounds); }
		|            set { M_Control.Bounds = value.M_Rectangle; }
		|        }
		|
		|        public string DoubleClick;
		|
		|        public bool Enabled
		|        {
		|            get { return M_Control.Enabled; }
		|            set { M_Control.Enabled = value; }
		|        }
		|
		|        public bool FontBold
		|        {
		|            get
		|            {
		|                if (M_Control.Font.Bold)
		|                {
		|                    return true;
		|                }
		|                else
		|                {
		|                    return false;
		|                }
		|            }
		|            set
		|            {
		|                System.Drawing.Font Font1 = M_Control.Font;
		|                if (!value)
		|                {
		|                    M_Control.Font = new System.Drawing.Font(Font1.Name, Font1.Size, Font1.Style & System.Drawing.FontStyle.Bold);
		|                }
		|                else
		|                {
		|                    M_Control.Font = new System.Drawing.Font(Font1.Name, Font1.Size, Font1.Style | System.Drawing.FontStyle.Bold);
		|                }
		|            }
		|        }
		|
		|        public bool Capture
		|        {
		|            get { return M_Control.Capture; }
		|            set { M_Control.Capture = value; }
		|        }
		|
		|        public string Name
		|        {
		|            get { return M_Control.Name; }
		|            set { M_Control.Name = value; }
		|        }
		|
		|        public string ProductName
		|        {
		|            get { return ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title.ToString(); }
		|        }
		|
		|        public string FontName
		|        {
		|            get { return M_Control.Font.Name; }
		|            set
		|            {
		|                System.Drawing.Font Font1 = M_Control.Font;
		|                M_Control.Font = new System.Drawing.Font(value, Font1.Size, Font1.Style);
		|            }
		|        }
		|
		|        public bool UseWaitCursor
		|        {
		|            get { return M_Control.UseWaitCursor; }
		|            set { M_Control.UseWaitCursor = value; }
		|        }
		|
		|        public string KeyUp;
		|
		|        public string KeyDown;
		|
		|        public string KeyPress;
		|
		|        public int ClientHeight
		|        {
		|            get { return M_Control.ClientSize.Height; }
		|            set { M_Control.ClientSize = new System.Drawing.Size(M_Control.ClientSize.Width, value); }
		|        }
		|
		|        public osf.Rectangle ClientRectangle
		|        {
		|            get { return new Rectangle(M_Control.ClientRectangle); }
		|        }
		|
		|        public osf.Size ClientSize
		|        {
		|            get { return new Size(M_Control.ClientSize); }
		|            set { M_Control.ClientSize = value.M_Size; }
		|        }
		|
		|        public int ClientWidth
		|        {
		|            get { return M_Control.ClientSize.Width; }
		|            set { M_Control.ClientSize = new System.Drawing.Size(value, M_Control.ClientSize.Height); }
		|        }
		|
		|        public int MouseButtons
		|        {
		|            get
		|            {
		|                try
		|                {
		|                    return (int)((dynamic)OneScriptForms.Event).Button;
		|                }
		|                catch
		|                {
		|                    return (int)System.Windows.Forms.Control.MouseButtons;
		|                }
		|            }
		|        }
		|
		|        public osf.ContextMenu ContextMenu
		|        {
		|            get
		|            {
		|                if (M_Control.ContextMenu != null)
		|                {
		|                    return (ContextMenu)((ContextMenuEx)M_Control.ContextMenu).M_Object;
		|                }
		|                else
		|                {
		|                    return null;
		|                }
		|            }
		|            set
		|            {
		|                M_Control.ContextMenu = value.M_ContextMenu;
		|                ((ContextMenuEx)M_Control.ContextMenu).M_Object = value;
		|            }
		|        }
		|
		|        public osf.Cursor Cursor
		|        {
		|            get { return new Cursor(M_Control.Cursor); }
		|            set { M_Control.Cursor = value.M_Cursor; }
		|        }
		|
		|        public int Left
		|        {
		|            get { return M_Control.Left; }
		|            set { M_Control.Left = value; }
		|        }
		|
		|        public object Tag
		|        {
		|            get { return M_Control.Tag; }
		|            set { M_Control.Tag = value; }
		|        }
		|
		|        public string MouseEnter;
		|
		|        public string MouseLeave;
		|
		|        public string Click;
		|
		|        public int Bottom
		|        {
		|            get { return M_Control.Bottom; }
		|        }
		|
		|        public osf.Color ForeColor
		|        {
		|            get { return new Color(M_Control.ForeColor); }
		|            set { M_Control.ForeColor = value.M_Color; }
		|        }
		|
		|        public bool Visible
		|        {
		|            get { return M_Control.Visible; }
		|            set { M_Control.Visible = value; }
		|        }
		|
		|        public osf.Point MousePosition
		|        {
		|            get { return new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y); }
		|        }
		|
		|        public osf.Point Location
		|        {
		|            get { return new Point(M_Control.Location); }
		|            set { M_Control.Location = value.M_Point; }
		|        }
		|
		|        public string LocationChanged;
		|
		|        public int TabIndex
		|        {
		|            get { return M_Control.TabIndex; }
		|            set { M_Control.TabIndex = value; }
		|        }
		|
		|        public int Right
		|        {
		|            get { return M_Control.Right; }
		|        }
		|
		|        public string Enter;
		|
		|        public string MouseHover;
		|
		|        public string MouseDown;
		|
		|        public string MouseUp;
		|
		|        public string Move;
		|
		|        public string MouseMove;
		|
		|        public string Paint;
		|
		|        public string LostFocus;
		|
		|        public string Leave;
		|
		|        public osf.Size Size
		|        {
		|            get { return new Size(M_Control.Size); }
		|            set { M_Control.Size = value.M_Size; }
		|        }
		|
		|        public string SizeChanged;
		|
		|        public int FontSize
		|        {
		|            get { return Convert.ToInt32(M_Control.Font.Size); }
		|            set
		|            {
		|                System.Drawing.Font Font1 = M_Control.Font;
		|                M_Control.Font = new System.Drawing.Font(Font1.Name, Convert.ToSingle(value), Font1.Style);
		|            }
		|        }
		|
		|        public object Parent
		|        {
		|            get { return ((dynamic)M_Control.Parent).M_Object; }
		|            set { M_Control.Parent = ((dynamic)value).M_Control; }
		|        }
		|
		|        public int Dock
		|        {
		|            get { return (int)M_Control.Dock; }
		|            set { M_Control.Dock = (System.Windows.Forms.DockStyle)value; }
		|        }
		|
		|        public bool Focused
		|        {
		|            get { return M_Control.Focused; }
		|        }
		|
		|        public bool TabStop
		|        {
		|            get { return M_Control.TabStop; }
		|            set { M_Control.TabStop = value; }
		|        }
		|
		|        public string Text
		|        {
		|            get { return Convert.ToString(M_Control.Text); }
		|            set { M_Control.Text = value; }
		|        }
		|
		|        public string TextChanged;
		|
		|        public bool CanFocus
		|        {
		|            get { return M_Control.CanFocus; }
		|        }
		|
		|        public osf.Bitmap BackgroundImage
		|        {
		|            get
		|            {
		|                if (M_Control.BackgroundImage != null)
		|                {
		|                    return new Bitmap(M_Control.BackgroundImage);
		|                }
		|                else
		|                {
		|                    return null;
		|                }
		|            }
		|            set
		|            {
		|                M_Control.BackgroundImage = value.M_Image;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public osf.Color BackColor
		|        {
		|            get { return new Color(M_Control.BackColor); }
		|            set { M_Control.BackColor = value.M_Color; }
		|        }
		|
		|        public int Width
		|        {
		|            get { return M_Control.Width; }
		|            set { M_Control.Width = value; }
		|        }
		|
		|        public osf.Font Font
		|        {
		|            get { return new Font(M_Control.Font); }
		|            set { M_Control.Font = value.M_Font; }
		|        }
		|
		|        public osf.Control TopLevelControl
		|        {
		|            get
		|            {
		|                if (M_Control.TopLevelControl != null)
		|                {
		|                    return ((osf.Control)((dynamic)M_Control.TopLevelControl).M_Object);
		|                }
		|                return null;
		|            }
		|        }
		|
		|        public string ControlAdded;
		|
		|        public string ControlRemoved;
		|
		|        public osf.ControlCollection Controls
		|        {
		|            get { return new ControlCollection(M_Control.Controls); }
		|        }
		|
		|        public osf.Control Controls2(int p1)
		|        {
		|            return Controls[p1];
		|        }
		|
		|        public int Anchor
		|        {
		|            get { return (int)M_Control.Anchor; }
		|            set { M_Control.Anchor = (System.Windows.Forms.AnchorStyles)value; }
		|        }
		|
		|
		|        //Методы============================================================
		|        public void PlaceLeft(Control p1, int p2)
		|        {
		|            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Left - Width - p2, p1.M_Control.Top);
		|        }
		|        public void PlaceRight(Control p1, int p2)
		|        {
		|            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Right + p2, p1.M_Control.Top);
		|        }
		|        public void PlaceTop(Control p1, int p2)
		|        {
		|            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Left, p1.M_Control.Top - Height - p2);
		|        }
		|        public void PlaceBottom(Control p1, int p2)
		|        {
		|            p1.M_Control.Location = new System.Drawing.Point(p1.M_Control.Left, p1.M_Control.Top + p1.M_Control.Height + p2);
		|        }
		|		
		|        public void Refresh()
		|        {
		|            M_Control.Refresh();
		|        }
		|
		|        public void Invalidate()
		|        {
		|            M_Control.Invalidate();
		|        }
		|
		|        public void ResumeLayout(bool p1 = false)
		|        {
		|            M_Control.ResumeLayout(p1);
		|        }
		|
		|        public void ResetBackgroundImage()
		|        {
		|            M_Control.BackgroundImage = null;
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void Select()
		|        {
		|            M_Control.Select();
		|        }
		|
		|        public void PerformLayout()
		|        {
		|            M_Control.PerformLayout();
		|        }
		|
		|        public osf.Control GetChildAtPoint(Point p1)
		|        {
		|            if (M_Control.GetChildAtPoint(p1.M_Point) != null)
		|            {
		|                return ((osf.Control)((dynamic)M_Control.GetChildAtPoint(p1.M_Point)).M_Object);
		|            }
		|            return null;
		|        }
		|
		|        public virtual void EndUpdate()
		|        {
		|            SendMessage(M_Control.Handle, 11, -1, 0);
		|            M_Control.Invalidate();
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|
		|        public void SendToBack()
		|        {
		|            M_Control.SendToBack();
		|        }
		|
		|        public void BringToFront()
		|        {
		|            M_Control.BringToFront();
		|        }
		|
		|        public osf.Form FindForm()
		|        {
		|            if ((FormEx)M_Control.FindForm() != null)
		|            {
		|                return (osf.Form)((FormEx)M_Control.FindForm()).M_Object;
		|            }
		|            return null;
		|        }
		|
		|        public dynamic FindControl(string p1)
		|        {
		|            foreach (dynamic item in M_Control.Controls)
		|            {
		|                if (item.Name == p1)
		|                {
		|                    return item;
		|                }
		|            }
		|            return null;
		|        }
		|
		|        public virtual void BeginUpdate()
		|        {
		|            SendMessage(M_Control.Handle, 11, 0, 0);
		|            System.Windows.Forms.Application.DoEvents();
		|        }
		|		
		|        public void Update()
		|        {
		|            M_Control.Update();
		|        }
		|
		|        public void Show()
		|        {
		|            M_Control.Show();
		|        }
		|
		|        public void SuspendLayout()
		|        {
		|            M_Control.SuspendLayout();
		|        }
		|
		|        public void Hide()
		|        {
		|            M_Control.Hide();
		|        }
		|
		|        public osf.Control GetNextControl(Control p1, bool p2)
		|        {
		|            return (osf.Control)((dynamic)M_Control.GetNextControl(p1.M_Control, p2)).M_Object;
		|        }
		|
		|        public osf.Graphics CreateGraphics()
		|        {
		|            return new Graphics(M_Control.CreateGraphics());
		|        }
		|		
		|        public void CreateControl()
		|        {
		|            M_Control.CreateControl();
		|        }
		|
		|        public osf.Point PointToClient(Point p1)
		|        {
		|            return new Point(M_Control.PointToClient(p1.M_Point));
		|        }
		|		
		|        public osf.Point PointToScreen(Point p1)
		|        {
		|            return new Point(M_Control.PointToScreen(p1.M_Point));
		|        }
		|
		|        public void SetBounds(int p1, int p2, int p3, int p4)
		|        {
		|            M_Control.SetBounds(p1, p2, p3, p4);
		|        }
		|
		|        public void Focus()
		|        {
		|            M_Control.Focus();
		|        }
		|
		|        public virtual void Center()
		|        {
		|            System.Windows.Forms.Control parent = M_Control.Parent;
		|            M_Control.Location = new System.Drawing.Point((int)System.Math.Round((parent.ClientSize.Width - M_Control.Width) / 2.0), (int)System.Math.Round((parent.ClientSize.Height - M_Control.Height) / 2.0));
		|        }
		|
		|        public osf.Control getControl(object p1)
		|        {
		|            System.Windows.Forms.Control.ControlCollection ControlCollection1 = M_Control.Controls;
		|            object[] array1 = new object[ControlCollection1.Count];
		|            ControlCollection1.CopyTo(array1, 0);
		|            try
		|            {
		|                return (osf.Control)((dynamic)ControlCollection1[(int)p1]).M_Object;
		|            }
		|            catch
		|            {
		|                return (osf.Control)((dynamic)array1.ElementAt((int)p1)).M_Object;
		|            }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ContainerControl" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ContainerControl : ScrollableControl
		|    {
		|        private System.Windows.Forms.ContainerControl m_ContainerControl;
		|
		|        public System.Windows.Forms.ContainerControl M_ContainerControl
		|        {
		|            get { return m_ContainerControl; }
		|            set
		|            {
		|                m_ContainerControl = value;
		|                base.M_ScrollableControl = m_ContainerControl;
		|            }
		|        }
		|
		|        public osf.Control ActiveControl
		|        {
		|            get { return ((dynamic)M_ContainerControl.ActiveControl).M_Object; }
		|            set { M_ContainerControl.ActiveControl = ((dynamic)value).M_Control; }
		|        }
		|
		|        //Свойства============================================================
		|        //Методы============================================================
		|
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "Component" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class Component : System.ComponentModel.Component
		|    {
		|        public System.ComponentModel.Component M_Component;
		|
		|        public Type Type
		|        {
		|            get { return new Type(GetType()); }
		|        }
		|
		|        //Методы============================================================
		|        public new void Dispose()
		|        {
		|            M_Component.Dispose();
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	ИначеЕсли ИмяФайлаCs = "ButtonBase" Тогда
		СтрВыгрузки = СтрВыгрузки + 
		"namespace osf
		|{
		|    public class ButtonBase : Control
		|    {
		|        private System.Windows.Forms.ButtonBase m_ButtonBase;
		|        private osf.Bitmap image;
		|		
		|        public System.Windows.Forms.ButtonBase M_ButtonBase
		|        {
		|            get { return m_ButtonBase; }
		|            set
		|            {
		|                m_ButtonBase = value;
		|                base.M_Control = m_ButtonBase;
		|            }
		|        }
		|
		|        public ButtonBase()
		|        {
		|        }
		|		
		|        public int FlatStyle
		|        {
		|            get { return (int)M_ButtonBase.FlatStyle; }
		|            set { M_ButtonBase.FlatStyle = (System.Windows.Forms.FlatStyle)value; }
		|        }
		|
		|        public osf.Bitmap Image
		|        {
		|            get { return image; }
		|            set
		|            {
		|                image = value;
		|                M_ButtonBase.Image = value.M_Image;
		|                System.Windows.Forms.Application.DoEvents();
		|            }
		|        }
		|
		|        public int ImageAlign
		|        {
		|            get { return (int)M_ButtonBase.ImageAlign; }
		|            set { M_ButtonBase.ImageAlign = (System.Drawing.ContentAlignment)value; }
		|        }
		|
		|        public int ImageIndex
		|        {
		|            get { return M_ButtonBase.ImageIndex; }
		|            set { M_ButtonBase.ImageIndex = value; }
		|        }
		|
		|        public osf.ImageList ImageList
		|        {
		|            get { return new ImageList(M_ButtonBase.ImageList); }
		|            set { M_ButtonBase.ImageList = value.M_ImageList; }
		|        }
		|
		|        public int TextAlign
		|        {
		|            get { return (int)M_ButtonBase.TextAlign; }
		|            set { M_ButtonBase.TextAlign = (System.Drawing.ContentAlignment)value; }
		|        }
		|    }//endClass
		|}//endnamespace
		|";
		ТекстДокХХХ = Новый ТекстовыйДокумент;
		ТекстДокХХХ.УстановитьТекст(СтрВыгрузки);
		ТекстДокХХХ.Записать("C:\444\ВыгруженныеОбъекты\" + ИмяФайлаCs + ".cs");
	КонецЕсли;
КонецПроцедуры//СоздатьФайлCs

Процедура СтраницыБезПримера()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ВыбранныеФайлы = НайтиФайлы("C:\444", "*.html", Истина);
	Найдено1 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "<H4 class=dtH4>Пример</H4>", "<H4 class=dtH4>Смотрите также</H4>", , );
		Если М.Количество() > 0 Тогда
			СтрПримера= СтрНайтиМежду(М[0], "<PRE class=code>", "</PRE>", , )[0];
			Если (СокрЛП(СтрПримера) = "") или (СтрНайти(СтрПримера, "$") > 0) Тогда//
				Найдено1 = Найдено1 + 1;
				Сообщить("================================================================================================");
				Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
				
			КонецЕсли;
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 = " + Найдено1);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//СтраницыБезПримера

Процедура ИзменениеСекцииПример()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ВыбранныеФайлы = НайтиФайлы("C:\444", "*.html", Истина);
	Найдено1 = 0;
	СделаноЗамен1 = 0;
	СделаноЗамен2 = 0;
	СделаноЗамен3 = 0;
	СделаноЗамен4 = 0;
	СделаноЗамен5 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		Если Не (СтрНайти(ВыбранныеФайлы[А].ПолноеИмя, "C:\444\OneScriptFormsru\OneScriptForms.Form.") > 0) Тогда
			// Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя);
			Продолжить;
		КонецЕсли;
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "<H4 class=dtH4>Пример</H4>", "<H4 class=dtH4>Смотрите также</H4>", Ложь, );
		
		Если М.Количество() > 0 Тогда
			// Сообщить("==========" + ВыбранныеФайлы[А].ПолноеИмя);
			СтрПримера= М[0];
			
			ПодстрокаПоиска = "</PRE>
			|</details>
			|<P></P>
			|<H4 class=dtH4>Смотрите также</H4>";
			ПодстрокаЗамены = "</PRE>
			|</details>
			|<P></P>
			|<details><summary>Тестовый код</summary>
			|<P><PRE class=code>
			|
			|</PRE>
			|</details>
			|<P></P>
			|<H4 class=dtH4>Смотрите также</H4>";
			Если СтрНайти(Стр, ПодстрокаПоиска) > 0 Тогда
				СделаноЗамен1 = СделаноЗамен1 + 1;
				Сообщить("==================================================");
				Сообщить("ПодстрокаПоиска------------------------------");
				Сообщить("" + ПодстрокаПоиска);
				Сообщить("ПодстрокаЗамены------------------------------");
				Сообщить("" + ПодстрокаЗамены);
				Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
				ТекстДок.УстановитьТекст(Стр);
				ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
			Иначе
				ПодстрокаПоиска2 = "</PRE>
				|</details>
				|<P></P>
				|<IMG src";
				ПодстрокаЗамены2 = "</PRE>
				|</details>
				|<P></P>
				|<details><summary>Тестовый код</summary>
				|<P><PRE class=code>
				|
				|</PRE>
				|</details>
				|<P></P>
				|<IMG src";
				Если СтрНайти(Стр, ПодстрокаПоиска2) > 0 Тогда
					СделаноЗамен2 = СделаноЗамен2 + 1;
					Сообщить("==================================================");
					Сообщить("ПодстрокаПоиска2------------------------------");
					Сообщить("" + ПодстрокаПоиска2);
					Сообщить("ПодстрокаЗамены2------------------------------");
					Сообщить("" + ПодстрокаЗамены2);
					Стр = СтрЗаменить(Стр, ПодстрокаПоиска2, ПодстрокаЗамены2);
					ТекстДок.УстановитьТекст(Стр);
					ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
				Иначе
					ПодстрокаПоиска3 = "</PRE>
					|</details>
					|<IMG src";
					ПодстрокаЗамены3 = "</PRE>
					|</details>
					|<P></P>
					|<details><summary>Тестовый код</summary>
					|<P><PRE class=code>
					|
					|</PRE>
					|</details>
					|<P></P>
					|<IMG src";
					Если СтрНайти(Стр, ПодстрокаПоиска3) > 0 Тогда
						СделаноЗамен3 = СделаноЗамен3 + 1;
						Сообщить("==================================================");
						Сообщить("ПодстрокаПоиска3------------------------------");
						Сообщить("" + ПодстрокаПоиска3);
						Сообщить("ПодстрокаЗамены3------------------------------");
						Сообщить("" + ПодстрокаЗамены3);
						Стр = СтрЗаменить(Стр, ПодстрокаПоиска3, ПодстрокаЗамены3);
						ТекстДок.УстановитьТекст(Стр);
						ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
					Иначе
						ПодстрокаПоиска4 = "</PRE>
						|</details>
						|<style>img";
						ПодстрокаЗамены4 = "</PRE>
						|</details>
						|<P></P>
						|<details><summary>Тестовый код</summary>
						|<P><PRE class=code>
						|
						|</PRE>
						|</details>
						|<P></P>
						|<style>img";
						Если СтрНайти(Стр, ПодстрокаПоиска4) > 0 Тогда
							СделаноЗамен4 = СделаноЗамен4 + 1;
							Сообщить("==================================================");
							Сообщить("ПодстрокаПоиска4------------------------------");
							Сообщить("" + ПодстрокаПоиска4);
							Сообщить("ПодстрокаЗамены4------------------------------");
							Сообщить("" + ПодстрокаЗамены4);
							Стр = СтрЗаменить(Стр, ПодстрокаПоиска4, ПодстрокаЗамены4);
							ТекстДок.УстановитьТекст(Стр);
							ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
						Иначе
							ПодстрокаПоиска5 = "</PRE>
							|</details>
							|<P></P>
							|<style>img";
							ПодстрокаЗамены5 = "</PRE>
							|</details>
							|<P></P>
							|<details><summary>Тестовый код</summary>
							|<P><PRE class=code>
							|
							|</PRE>
							|</details>
							|<P></P>
							|<style>img";
							Если СтрНайти(Стр, ПодстрокаПоиска5) > 0 Тогда
								СделаноЗамен5 = СделаноЗамен5 + 1;
								Сообщить("==================================================");
								Сообщить("ПодстрокаПоиска5------------------------------");
								Сообщить("" + ПодстрокаПоиска5);
								Сообщить("ПодстрокаЗамены5------------------------------");
								Сообщить("" + ПодстрокаЗамены5);
								Стр = СтрЗаменить(Стр, ПодстрокаПоиска5, ПодстрокаЗамены5);
								ТекстДок.УстановитьТекст(Стр);
								ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
							Иначе
						
								ИмяФайлаБат = "C:\444\Baty\gggggggg.bat";
								ИмяРедактируемогоФайла = ВыбранныеФайлы[А].ПолноеИмя;

								ТекстДок3 = Новый ТекстовыйДокумент;
								СтрБат = "cd c:\" + Символы.ПС + """C:\Program Files (x86)\Notepad++\notepad++.exe"" """ + ИмяРедактируемогоФайла + """";
								ТекстДок3.УстановитьТекст(СтрБат);
								ТекстДок3.Записать(ИмяФайлаБат);
								Приостановить(1000);
								ЗапуститьПриложение(ИмяФайлаБат);
								ЗавершитьРаботу(2);
							КонецЕсли;
						КонецЕсли;
					КонецЕсли;
				КонецЕсли;
			КонецЕсли;
			
			
			Найдено1 = Найдено1 + 1;
			// Сообщить("================================================================================================");
			// Сообщить("==========" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 = " + Найдено1);
	Сообщить("СделаноЗамен1 = " + СделаноЗамен1);
	Сообщить("СделаноЗамен2 = " + СделаноЗамен2);
	Сообщить("СделаноЗамен3 = " + СделаноЗамен3);
	Сообщить("СделаноЗамен4 = " + СделаноЗамен4);
	Сообщить("СделаноЗамен5 = " + СделаноЗамен5);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//ИзменениеСекцииПример

Процедура ДобавлениеКопированияВПример()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ВыбранныеФайлы = НайтиФайлы("C:\444", "*.html", Истина);
	Найдено1 = 0;
	СделаноЗамен1 = 0;
	СделаноЗамен2 = 0;
	СделаноЗамен3 = 0;
	СделаноЗамен4 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		// Если Не (СтрНайти(ВыбранныеФайлы[А].ПолноеИмя, "C:\444\OneScriptFormsru\OneScriptForms.Form.") > 0) Тогда
			// // Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя);
			// Продолжить;
		// КонецЕсли;
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "<H4 class=dtH4>Пример</H4>", "<H4 class=dtH4>Смотрите также</H4>", Ложь, );
		
		Если М.Количество() > 0 Тогда
			// Сообщить("==========" + ВыбранныеФайлы[А].ПолноеИмя);
			СтрПримера= М[0];
			
			ПодстрокаПоиска = "<details><summary>Полный пример кода</summary>
			|<P><PRE class=code>";
			ПодстрокаЗамены = "<details><summary>Полный пример кода</summary>
			|<P><PRE class=code>
			|<a id=""copy1"" href=""jаvascript://"" title=""Выделяет код, копирует и снимает выделение."">Копировать</a>     <a id=""select1"" href=""jаvascript://"" title=""Выделяет код."">Выделить всё</a>
			|<hr style=""border-color: lightgray;""><DIV id=""cont1"">";
			Если СтрНайти(Стр, ПодстрокаПоиска) > 0 Тогда
				СделаноЗамен1 = СделаноЗамен1 + 1;
				Сообщить("==================================================");
				Сообщить("ПодстрокаПоиска------------------------------");
				Сообщить("" + ПодстрокаПоиска);
				Сообщить("ПодстрокаЗамены------------------------------");
				Сообщить("" + ПодстрокаЗамены);
				// Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
				// ТекстДок.УстановитьТекст(Стр);
				// ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
			// // Иначе
				// // Сообщить("================================================================================================");
				// // Сообщить("==========1" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
			КонецЕсли;
			
			ПодстрокаПоиска = "<details><summary>Тестовый код</summary>
			|<P><PRE class=code>";
			ПодстрокаЗамены = "<details><summary>Тестовый код</summary>
			|<P><PRE class=code>
			|<a id=""copy2"" href=""jаvascript://"" title=""Выделяет код, копирует и снимает выделение."">Копировать</a>     <a id=""select2"" href=""jаvascript://"" title=""Выделяет код."">Выделить всё</a>
			|<hr style=""border-color: lightgray;""><DIV id=""cont2"">";
			Если СтрНайти(Стр, ПодстрокаПоиска) > 0 Тогда
				СделаноЗамен2 = СделаноЗамен2 + 1;
				Сообщить("==================================================");
				Сообщить("ПодстрокаПоиска------------------------------");
				Сообщить("" + ПодстрокаПоиска);
				Сообщить("ПодстрокаЗамены------------------------------");
				Сообщить("" + ПодстрокаЗамены);
				// Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
				// ТекстДок.УстановитьТекст(Стр);
				// ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
			// // Иначе
				// // Сообщить("================================================================================================");
				// // Сообщить("==========2" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
			КонецЕсли;
			
			ПодстрокаПоиска = "</PRE>
			|</details>";
			ПодстрокаЗамены = "</DIV>
			|</PRE>
			|</details>";
			Если СтрНайти(Стр, ПодстрокаПоиска) > 0 Тогда
				СделаноЗамен3 = СделаноЗамен3 + 1;
				Сообщить("==================================================");
				Сообщить("ПодстрокаПоиска------------------------------");
				Сообщить("" + ПодстрокаПоиска);
				Сообщить("ПодстрокаЗамены------------------------------");
				Сообщить("" + ПодстрокаЗамены);
				// Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
				// ТекстДок.УстановитьТекст(Стр);
				// ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
			// // Иначе
				// // Сообщить("================================================================================================");
				// // Сообщить("==========3" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
			КонецЕсли;
			
			ПодстрокаПоиска = "</DIV></BODY></HTML>";
			ПодстрокаЗамены = "</DIV>
			|<script>
			|window.onload = function () {
			|    var a = document.getElementById('select1');
			|    a.onclick = function() {
			|		window.getSelection().removeAllRanges();
			|		var ta1 = document.getElementById('cont1'); 
			|		var range1 = document.createRange();
			|		range1.selectNode(ta1); 
			|		window.getSelection().addRange(range1); 
			|        return false;
			|    }
			|	
			|    var b = document.getElementById('copy1');
			|    b.onclick = function() {
			|		window.getSelection().removeAllRanges();
			|		var ta2 = document.getElementById('cont1'); 
			|		var range2 = document.createRange();
			|		range2.selectNode(ta2); 
			|		window.getSelection().addRange(range2);
			|		try { 
			|		  document.execCommand('copy'); 
			|		} catch(err) {} 
			|		window.getSelection().removeRange(range2);
			|        return false;
			|    }
			|	
			|    var c = document.getElementById('select2');
			|    c.onclick = function() {
			|		window.getSelection().removeAllRanges();
			|		var ta3 = document.getElementById('cont2'); 
			|		var range3 = document.createRange();
			|		range3.selectNode(ta3); 
			|		window.getSelection().addRange(range3); 
			|        return false;
			|    }
			|	
			|    var d = document.getElementById('copy2');
			|    d.onclick = function() {
			|		window.getSelection().removeAllRanges();
			|		var ta4 = document.getElementById('cont2'); 
			|		var range4 = document.createRange();
			|		range4.selectNode(ta4); 
			|		window.getSelection().addRange(range4);
			|		try { 
			|		  document.execCommand('copy'); 
			|		} catch(err) {} 
			|		window.getSelection().removeRange(range4);
			|        return false;
			|    }
			|}
			|</script>
			|</BODY></HTML>";
			Если СтрНайти(Стр, ПодстрокаПоиска) > 0 Тогда
				СделаноЗамен4 = СделаноЗамен4 + 1;
				Сообщить("==================================================");
				Сообщить("ПодстрокаПоиска------------------------------");
				Сообщить("" + ПодстрокаПоиска);
				Сообщить("ПодстрокаЗамены------------------------------");
				Сообщить("" + ПодстрокаЗамены);
				// Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
				// ТекстДок.УстановитьТекст(Стр);
				// ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
			// // Иначе
				// // Сообщить("================================================================================================");
				// // Сообщить("==========4" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
			КонецЕсли;
			
			
			
			
			
			
			Найдено1 = Найдено1 + 1;
			// Сообщить("================================================================================================");
			// Сообщить("==========" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 = " + Найдено1);
	Сообщить("СделаноЗамен1 = " + СделаноЗамен1);
	Сообщить("СделаноЗамен2 = " + СделаноЗамен2);
	Сообщить("СделаноЗамен3 = " + СделаноЗамен3);
	Сообщить("СделаноЗамен4 = " + СделаноЗамен4);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//ДобавлениеКопированияВПример

Процедура СтавлюДвоеточие()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ВыбранныеФайлы = НайтиФайлы("C:\444", "*.html", Истина);
	Найдено1 = 0;
	СделаноЗамен1 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		// Если Не (СтрНайти(ВыбранныеФайлы[А].ПолноеИмя, "C:\444\OneScriptFormsru\OneScriptForms.Form.") > 0) Тогда
			// // Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя);
			// Продолжить;
		// КонецЕсли;
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "<H4 class=dtH4>Пример</H4>", "<H4 class=dtH4>Смотрите также</H4>", Ложь, );
		
		Если М.Количество() > 0 Тогда
			// Сообщить("==========" + ВыбранныеФайлы[А].ПолноеИмя);
			СтрПримера= М[0];
			
			ПодстрокаПоиска = "ТекущаяДата())
			|</DIV>";
			ПодстрокаЗамены = "ТекущаяДата());
			|</DIV>";
			Если СтрНайти(Стр, ПодстрокаПоиска) > 0 Тогда
				СделаноЗамен1 = СделаноЗамен1 + 1;
				Сообщить("==================================================");
				Сообщить("ПодстрокаПоиска------------------------------");
				Сообщить("" + ПодстрокаПоиска);
				Сообщить("ПодстрокаЗамены------------------------------");
				Сообщить("" + ПодстрокаЗамены);
				// Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
				// ТекстДок.УстановитьТекст(Стр);
				// ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
			// // Иначе
				// // Сообщить("================================================================================================");
				// // Сообщить("==========1" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
			КонецЕсли;
			
			Найдено1 = Найдено1 + 1;
			// Сообщить("================================================================================================");
			// Сообщить("==========" + ВыбранныеФайлы[А].ПолноеИмя + Символы.ПС + СтрПримера);
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 = " + Найдено1);
	Сообщить("СделаноЗамен1 = " + СделаноЗамен1);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//СтавлюДвоеточие

Процедура СвойстваМеткаИРодитель()
	// Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	// ВыбранныеФайлы = ОтобратьФайлы("Члены");
	// Найдено1 = 0;
	// Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		// ТекстДок = Новый ТекстовыйДокумент;
		// ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		// Стр = ТекстДок.ПолучитьТекст();
		// СтрЗаголовка = СтрНайтиМежду(Стр, "<H1 class=dtH1", "/H1>", , )[0];
		// Стр33 = СтрЗаголовка;
		// Стр33 = СтрЗаменить(Стр33, "&nbsp;", " ");
		// // Сообщить("================================================================================================");
		// // Сообщить("" + ВыбранныеФайлы[А] + Символы.ПС + Стр33);
		// Если СтрНайти(Стр, ".html"">ЭлементыУправления") > 0 Тогда
			// Найдено1 = Найдено1 + 1;
			// // Если (СтрНайти(Стр, ".html"">Метка") > 0) и (СтрНайти(Стр, ".html"">Родитель") > 0) Тогда
			// // Иначе
				// // // Сообщить("================================================================================================");
				// // // Сообщить("" + ВыбранныеФайлы[А] + Символы.ПС + Стр33);
			// // КонецЕсли;
		// // Иначе
			// // Сообщить("================================================================================================");
			// // Сообщить("" + ВыбранныеФайлы[А] + Символы.ПС + Стр33);
			// Сообщить("" + СтрНайтиМежду(Стр33, "(", ")", , )[0]);
			
		// КонецЕсли;
		
	// КонецЦикла;
	
	// Сообщить("Найдено1 = " + Найдено1);
	// Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//СвойстваМеткаИРодитель()

Процедура СвойстваАрг()
	// Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	// СписокКлассовАрг = Новый СписокЗначений;
	// ВыбранныеФайлы = ОтобратьФайлы("Свойство");
	// Найдено1 = 0;
	// Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		// ТекстДок = Новый ТекстовыйДокумент;
		// ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		// Стр = ТекстДок.ПолучитьТекст();
		// СтрЗаголовка = СтрНайтиМежду(Стр, "<H1 class=dtH1", "/H1>", , )[0];
		// Если СтрНайти(СтрЗаголовка, "Арг.") > 0 Тогда
			// Найдено1 = Найдено1 + 1;
			// // Сообщить("================================================================================================");
			// // Сообщить("" + ВыбранныеФайлы[А] + Символы.ПС + СтрЗаголовка);
			// КлассАрг = СтрНайтиМежду(СтрЗаголовка, ">", ".", , )[0];
			// Если СписокКлассовАрг.НайтиПоЗначению(КлассАрг) = Неопределено Тогда
				// СписокКлассовАрг.Добавить(КлассАрг);
			// КонецЕсли;
			
			// Если СтрНайти(Стр, "<P>Чтение и запись.</P>") > 0 Тогда
				// Сообщить("<P>Чтение и запись.</P>");
			// Иначе
				// // Сообщить("================================================================================================");
				// // Сообщить("" + ВыбранныеФайлы[А] + Символы.ПС + СтрЗаголовка);
			// КонецЕсли;
			// ПодстрокаПоиска = "<P>Чтение и запись.</P>";
			// ПодстрокаЗамены = "<P>Только чтение.</P>";
			// Стр = СтрЗаменить(Стр,ПодстрокаПоиска,ПодстрокаЗамены);
			// ТекстДок.УстановитьТекст(Стр);
			// ТекстДок.Записать(ВыбранныеФайлы[А]);
		// КонецЕсли;
	// КонецЦикла;
	
	// Сообщить("===========");
	// Сообщить("СписокКлассовАрг.Количество = " + СписокКлассовАрг.Количество());	
	// Для А = 0 По СписокКлассовАрг.Количество() - 1 Цикл
		// Сообщить("" + СписокКлассовАрг.Получить(А).Значение);
	// КонецЦикла;
	
	// Сообщить("Найдено1 = " + Найдено1);
	// Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//СвойстваАрг()

Процедура ЗаполнитьПримерамиЦвета()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ВыбранныеФайлы = ОтобратьФайлы("Свойство");
	Найдено1 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		Стр = ТекстДок.ПолучитьТекст();
		СтрЗаголовка = СтрНайтиМежду(Стр, "<H1 class=dtH1", "/H1>", Ложь, )[0];
		Если СтрНайти(СтрЗаголовка, "<H1 class=dtH1>Цвет.") > 0 Тогда
			Если (СтрНайти(СтрЗаголовка, "Цвет.ЗначениеАльфа&nbsp;(Color.A)&nbsp;Свойство") > 0) или 
			     (СтрНайти(СтрЗаголовка, "Цвет.ЗначениеЗеленый&nbsp;(Color.G)&nbsp;Свойство") > 0) или 
			     (СтрНайти(СтрЗаголовка, "Цвет.ЗначениеКрасный&nbsp;(Color.R)&nbsp;Свойство") > 0) или 
			     (СтрНайти(СтрЗаголовка, "Цвет.Пусто&nbsp;(Color.IsEmpty)&nbsp;Свойство") > 0) или 
			     (СтрНайти(СтрЗаголовка, "Цвет.ЗначениеСиний&nbsp;(Color.B)&nbsp;Свойство") > 0) или 
			     (СтрНайти(СтрЗаголовка, "Цвет.Имя&nbsp;(Color.Name)&nbsp;Свойство") > 0) Тогда
			Иначе
				// <H1 class=dtH1>Цвет.Серебристый&nbsp;(Color.Silver)&nbsp;Свойство</H1>
				ЦветРус = СтрНайтиМежду(Стр, "<H1 class=dtH1>Цвет.", "&nbsp;", , )[0];
				ЦветАнгл = СтрНайтиМежду(Стр, "(Color.", ")", , )[0];
				Найдено1 = Найдено1 + 1;
				Сообщить("================================================================================================");
				Сообщить("" + ВыбранныеФайлы[А] + Символы.ПС + СтрЗаголовка);
				Сообщить("ЦветРус = " + ЦветРус);
				Сообщить("ЦветАнгл = " + ЦветАнгл);
				ПримерИсх = СтрНайтиМежду(Стр, "<H4 class=dtH4>Пример</H4>", "</PRE>", Ложь, )[0];
				ПримерКон = "<H4 class=dtH4>Пример</H4>
					|<P><PRE class=code>
					|Цвет1 = Ф.Цвет()." + ЦветРус + ";
					|</PRE>";
				ПодстрокаПоиска = ПримерИсх;
				ПодстрокаЗамены = ПримерКон; 
				Стр = СтрЗаменить(Стр,ПодстрокаПоиска,ПодстрокаЗамены);
					
				ПолныйПримерИсх = СтрНайтиМежду(Стр, "<hr style=""border-color: lightgray;""><DIV id=""cont1"">", "</DIV>", Ложь, )[0];
				ПолныйПримерКон = "<hr style=""border-color: lightgray;""><DIV id=""cont1"">
					|ПодключитьВнешнююКомпоненту(""C:\444\111\onescriptgui\onescriptgui\bin\Debug\osf.dll"");
					|Ф = Новый ФормыДляОдноСкрипта();
					|Форма1 = Ф.Форма();
					|Форма1.Отображать = Истина;
					|Форма1.Показать();
					|Форма1.Активизировать();
					|
					|Цвет1 = Ф.Цвет()." + ЦветРус + ";
					|
					|Сообщить("""" + Цвет1.Имя);
					|
					|Пока Ф.Продолжать Цикл
					|	Выполнить(Ф.ПолучитьСобытие());
					|КонецЦикла;
					|</DIV>";
				ПодстрокаПоиска = ПолныйПримерИсх;
				ПодстрокаЗамены = ПолныйПримерКон; 
				Стр = СтрЗаменить(Стр,ПодстрокаПоиска,ПодстрокаЗамены);
					
				ТестовыйИсх = СтрНайтиМежду(Стр, "<hr style=""border-color: lightgray;""><DIV id=""cont2"">", "</DIV>", Ложь, )[0];
				ТестовыйКон = "<hr style=""border-color: lightgray;""><DIV id=""cont2"">
					|ПодключитьВнешнююКомпоненту(""C:\444\111\onescriptgui\onescriptgui\bin\Debug\osf.dll"");
					|Ф = Новый ФормыДляОдноСкрипта();
					|Форма1 = Ф.Форма();
					|Форма1.Отображать = Истина;
					|Форма1.Показать();
					|Форма1.Активизировать();
					|
					|Сообщить(?(
					|Ф.Цвет()." + ЦветРус + ".Имя = """ + ЦветРус + """
					|, """", ""!!! "") + ""Цвет." + ЦветРус + " (Color." + ЦветАнгл + ") Свойство"" + "" "" + ТекущаяДата());
					|</DIV>";
				ПодстрокаПоиска = ТестовыйИсх;
				ПодстрокаЗамены = ТестовыйКон; 
				Стр = СтрЗаменить(Стр,ПодстрокаПоиска,ПодстрокаЗамены);
				// // // ТекстДок.УстановитьТекст(Стр);
				// // // ТекстДок.Записать(ВыбранныеФайлы[А]);
			КонецЕсли;
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("Найдено1 = " + Найдено1);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//ЗаполнитьПримерамиЦвета()

Процедура ПолучитьКлассыСвойстваМетодыПеречисления()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	КолСвойств = 0;
	КолМетодов = 0;
	КолСвойствМетодов = 0;
	
	// Тестируем свойства, методы, перечисления.
	// Список классов берем из файла OneScriptForms.html
	// Свойства - из файла OneScriptForms....(Класс).....Members.html
	// Методы - из файла OneScriptForms....(Класс).....Members.html
	// Перечисления - из файла OneScriptForms.html
	
	ВыбранныеФайлы0 = ОтобратьФайлы("Класс");
	ВыбранныеФайлы1 = ОтобратьФайлы("Перечисление");
	ВыбранныеФайлы2 = ОтобратьФайлы("Свойство");
	ВыбранныеФайлы3 = ОтобратьФайлы("Метод");
	Сообщить("Классов = " + ВыбранныеФайлы0.Количество());
	Сообщить("Свойств = " + ВыбранныеФайлы2.Количество());
	Сообщить("Методов = " + ВыбранныеФайлы3.Количество());
	Сообщить("Перечислений = " + ВыбранныеФайлы1.Количество());
	
	Классы = ПолучитьМассивКлассов();
	// Сообщить("Классов = " + Классы.Количество());
	// Возврат;
	Для А1 = 0 По Классы.ВГраница() Цикл
			КлассРус = РазобратьСтроку(Классы[А1], " ")[0];
			КлассАнгл = РазобратьСтроку(Классы[А1], " ")[1];
			// Сообщить("===Класс===");
			// Сообщить("" + КлассРус + " (" + КлассАнгл + ")");
			
			//находим свойства класса из файла OneScriptForms....(Класс).....Members.html
			ИмяФайлаЧленов = "C:\444\OneScriptFormsru\OneScriptForms." + КлассАнгл + "Members.html";
			Свойства = ПолучитьМассивСвойствКласса(ИмяФайлаЧленов, КлассАнгл);
			// Сообщить("---Свойства---(" + Свойства.Количество() + ")");
			Для А2 = 0 По Свойства.ВГраница() Цикл
				СвойствоРус = РазобратьСтроку(Свойства[А2], " ")[0];
				СвойствоАнгл = РазобратьСтроку(Свойства[А2], " ")[1];
				// Сообщить("" + Символы.Таб + СвойствоРус + " (" + СвойствоАнгл + ")");
				КолСвойств = КолСвойств + 1;
			КонецЦикла;
			
			//находим методы класса из файла OneScriptForms....(Класс).....Members.html
			Методы = ПолучитьМассивМетодовКласса(ИмяФайлаЧленов, КлассАнгл);
			// Сообщить("---Методы---(" + Методы.Количество() + ")");
			Для А3 = 0 По Методы.ВГраница() Цикл
				МетодРус = РазобратьСтроку(Методы[А3], " ")[0];
				МетодАнгл = РазобратьСтроку(Методы[А3], " ")[1];
				// Сообщить("" + Символы.Таб + МетодРус + " (" + МетодАнгл + ")");
				КолМетодов = КолМетодов + 1;
			КонецЦикла;
	КонецЦикла;
	// Возврат;
		
	//находим Перечисления из файла OneScriptForms.html
	Перечисления = ПолучитьМассивПеречислений();
	Сообщить("Перечислений = " + Перечисления.Количество());
	Сообщить("===============================");
	Для А4 = 0 По Перечисления.ВГраница() Цикл
		ПеречислениеРус = РазобратьСтроку(Перечисления[А4], " ")[0];
		ПеречислениеАнгл = РазобратьСтроку(Перечисления[А4], " ")[1];
		// Сообщить("===Перечисление===");
		Сообщить("" + ПеречислениеРус + " (" + ПеречислениеАнгл + ")");
		
		//находим значения перечисления из файла OneScriptForms....(Перечисление)......html
		ИмяФайлаПеречисления = "C:\444\OneScriptFormsru\OneScriptForms." + ПеречислениеАнгл + ".html";
		ЗначенияПеречисления = ПолучитьМассивЗначенийПеречисления(ИмяФайлаПеречисления, ПеречислениеАнгл);
		Для А5 = 0 По ЗначенияПеречисления.ВГраница() Цикл
			ЗначениеПеречисленияРус = РазобратьСтроку(ЗначенияПеречисления[А5], " ")[0];
			ЗначениеПеречисленияАнгл = РазобратьСтроку(ЗначенияПеречисления[А5], " ")[1];
			// Сообщить("" + Символы.Таб + ЗначениеПеречисленияРус + " (" + ЗначениеПеречисленияАнгл + ")");
		КонецЦикла;
	КонецЦикла;
	
	Сообщить("КолСвойств = " + КолСвойств);
	Сообщить("КолМетодов = " + КолМетодов);
	Сообщить("КолСвойствМетодов = " + (КолСвойств + КолМетодов));
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//ПолучитьКлассыСвойстваМетодыПеречисления()

Функция ПолучитьМассивКлассов();
	// Список классов берем из файла OneScriptForms.html
	МассивКлассов = Новый Массив;
	
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptFormsru\OneScriptForms.html");
	Стр12 = ТекстДок.ПолучитьТекст();
	Массив1 = СтрНайтиМежду(Стр12, "<H3 class=dtH3>Классы</H3>", "</TBODY></TABLE>", Ложь, );
	Массив2 = СтрНайтиМежду(Массив1[0], "Описание</TH></TR>", "</TBODY></TABLE>", Ложь, );
	Массив3 = СтрНайтиМежду(Массив2[0], "<TR vAlign=top>", "</TD></TR>", Ложь, );
	// Сообщить("Классов = " + Массив3.Количество());
	Для А1 = 0 По Массив3.ВГраница() Цикл
		Массив4 = СтрНайтиМежду(Массив3[А1], ".html"">", "</A></TD>", Ложь, );
		Для А = 0 По Массив4.ВГраница() Цикл
			СтрХ = Массив4[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			КлассАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			КлассРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			// Сообщить("===Класс===");
			// Сообщить("" + КлассРус + " (" + КлассАнгл + ")");
			МассивКлассов.Добавить("" + КлассРус + " " + КлассАнгл);
		КонецЦикла;	
	КонецЦикла;		
			
	Возврат МассивКлассов;	
КонецФункции

Функция ПолучитьМассивСвойствКласса(ИмяФайлаЧленов, ИмяКонтекстКлассаАнгл)
	МассивСвойств = Новый Массив;
	ТекстДок = Новый ТекстовыйДокумент;
	Файл = Новый Файл(ИмяФайлаЧленов);
	Если Не (Файл.Существует()) Тогда
		Возврат МассивСвойств;
	КонецЕсли;
	ТекстДок.Прочитать(ИмяФайлаЧленов);
	Стр10 = ТекстДок.ПолучитьТекст();
	СтрТаблица = СтрНайтиМежду(Стр10, "<H4 class=dtH4>Свойства</H4>", "</TBODY></TABLE>", Ложь, );
	Если Не (СтрТаблица.Количество() > 0) Тогда
		Возврат МассивСвойств;
	КонецЕсли;
	Массив5 = СтрНайтиМежду(СтрТаблица[0], "pubproperty.gif", "</A>", Ложь, );
	// Сообщить("---Свойства---(" + Массив5.Количество() + ")");
	Для А = 0 По Массив5.ВГраница() Цикл
		СтрХ = Массив5[А];
		СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
		СвойствоАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
		СвойствоРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
		// Сообщить("" + Символы.Таб + СвойствоРус + " (" + СвойствоАнгл + ")");
		МассивСвойств.Добавить("" + СвойствоРус + " " + СвойствоАнгл);
	КонецЦикла;
	Возврат МассивСвойств;
КонецФункции

Функция ПолучитьМассивМетодовКласса(ИмяФайлаЧленов, ИмяКонтекстКлассаАнгл)
	МассивМетодов = Новый Массив;
	ТекстДок = Новый ТекстовыйДокумент;
	Файл = Новый Файл(ИмяФайлаЧленов);
	Если Не (Файл.Существует()) Тогда
		Возврат МассивМетодов;
	КонецЕсли;
	ТекстДок.Прочитать(ИмяФайлаЧленов);
	Стр10 = ТекстДок.ПолучитьТекст();
	СтрТаблица = СтрНайтиМежду(Стр10, "<H4 class=dtH4>Методы</H4>", "</TBODY></TABLE>", Ложь, );
	Если СтрТаблица.Количество() > 0 Тогда
		Массив6 = СтрНайтиМежду(СтрТаблица[0], "pubmethod.gif", "</A>", Ложь, );
		// Сообщить("---Методы---(" + Массив6.Количество() + ")");
		Для А = 0 По Массив6.ВГраница() Цикл
			СтрХ = Массив6[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			МетодАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			МетодРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			// Сообщить("" + Символы.Таб + МетодРус + " (" + МетодАнгл + ")");
			МассивМетодов.Добавить("" + МетодРус + " " + МетодАнгл);
		КонецЦикла;
	Иначе
		// Сообщить("" + Символы.Таб + "---Методы---(0)");
	КонецЕсли;
	Возврат МассивМетодов;
КонецФункции

Функция ПолучитьМассивПеречислений();
	МассивПеречислений = Новый Массив;
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptFormsru\OneScriptForms.html");
	Стр12 = ТекстДок.ПолучитьТекст();
	Массив7 = СтрНайтиМежду(Стр12, "<H3 class=dtH3>Перечисления</H3>", "</TBODY></TABLE>", Ложь, );
	Массив8 = СтрНайтиМежду(Массив7[0], "Описание</TH></TR>", "</TBODY></TABLE>", Ложь, );
	Массив9 = СтрНайтиМежду(Массив8[0], "<TR vAlign=top>", "</TD></TR>", Ложь, );
	// Сообщить("Перечислений = " + Массив9.Количество());
	// Сообщить("===============================");
	Для А1 = 0 По Массив9.ВГраница() Цикл
		Массив10 = СтрНайтиМежду(Массив9[А1], ".html"">", "</A></TD>", Ложь, );
		Для А = 0 По Массив10.ВГраница() Цикл
			СтрХ = Массив10[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			ПеречислениеАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			ПеречислениеРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			// Сообщить("===Перечисление===");
			// Сообщить("" + ПеречислениеРус + " (" + ПеречислениеАнгл + ")");
			МассивПеречислений.Добавить("" + ПеречислениеРус + " " + ПеречислениеАнгл);
			
			//находим значения перечисления из файла OneScriptForms....(Перечисление)......html
			ИмяФайлаПеречисления = "C:\444\OneScriptFormsru\OneScriptForms." + ПеречислениеАнгл + ".html";
			ПолучитьМассивЗначенийПеречисления(ИмяФайлаПеречисления, ПеречислениеАнгл);
			
		КонецЦикла;
	КонецЦикла;
	Возврат МассивПеречислений;
КонецФункции

Функция ПолучитьМассивЗначенийПеречисления(ИмяФайлаПеречисления, ПеречислениеАнгл)
	МассивЗначенийПеречисления = Новый Массив;
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ИмяФайлаПеречисления);
	Стр10 = ТекстДок.ПолучитьТекст();
	СтрТаблица = СтрНайтиМежду(Стр10, "<TD><B>", "</B></TD>", Ложь, );
	// Сообщить("---Перечисления---(" + СтрТаблица.Количество() + ")");
	Для А = 0 По СтрТаблица.ВГраница() Цикл
		СтрХ = СтрТаблица[А];
		СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
		ЗначениеПеречисленияАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
		ЗначениеПеречисленияРус = СтрНайтиМежду(СтрХ, "<TD><B>", " (", , )[0];
		// Сообщить("" + Символы.Таб + ЗначениеПеречисленияРус + " (" + ЗначениеПеречисленияАнгл + ")");
		МассивЗначенийПеречисления.Добавить("" + ЗначениеПеречисленияРус + " " + ЗначениеПеречисленияАнгл);
	КонецЦикла;
	Возврат МассивЗначенийПеречисления;
КонецФункции

Процедура КлассыБезКонструктора()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	БезКонструктора = 0;
	ВыбранныеФайлы0 = ОтобратьФайлы("Класс");
	ВыбранныеФайлы = ОтобратьФайлы("Члены");
	ВыбранныеФайлы2 = ОтобратьФайлы("Свойство");
	ВыбранныеФайлы3 = ОтобратьФайлы("Метод");
	
	// Сообщить("" + ВыбранныеФайлы0.Количество());
	Для А = 0 По ВыбранныеФайлы0.Количество() - 1 Цикл
		Путь = СтрЗаменить(ВыбранныеФайлы0[А], ".html", "Members.html");
		Файл = Новый Файл(Путь);
		Если Не Файл.Существует() Тогда
			Сообщить("" + ВыбранныеФайлы0[А]);
			ВыбранныеФайлы.Добавить(ВыбранныеФайлы0[А]);
		КонецЕсли;
	КонецЦикла;
	// Возврат;
	
	НайденоСоответствий = 0;
	Список = Новый СписокЗначений;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		Стр = ТекстДок.ПолучитьТекст();
		СтрЗаголовка = СтрНайтиМежду(Стр, "<H1 class=dtH1>", "</H1>", , );
		СтрЗаголовка = СтрЗаголовка[0];
		СтрЗаголовка = СтрЗаменить(СтрЗаголовка, "Члены", "");
		СтрЗаголовка = СтрЗаменить(СтрЗаголовка, "Класс", "");
		СтрЗаголовка = СтрЗаменить(СтрЗаголовка, "&nbsp;", " ");
		СтрЗаголовка = СокрЛП(СтрЗаголовка);
		
		Сообщить("СтрЗаголовка = " + СтрЗаголовка);
		
		Если Не (СтрНайти(Стр, "<H4 class=dtH4>Конструктор</H4>") > 0) Тогда
			Добавлять = Истина;
			СтрВСписок = "";
			Для А1 = 0 По ВыбранныеФайлы2.ВГраница() Цикл
				ТекстДок2 = Новый ТекстовыйДокумент;
				ТекстДок2.Прочитать(ВыбранныеФайлы2[А1]);
				Стр2 = ТекстДок2.ПолучитьТекст();
				
				СтрЗаголовка2 = СтрНайтиМежду(Стр2, "<H1 class=dtH1>", "</H1>", , );
				СтрЗаголовка2 = СтрЗаголовка2[0];
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Свойство", "");
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
				СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
				
				Стр3 = СтрНайтиМежду(Стр2, "<H4 class=dtH4>Значение</H4>", "<H4 class=dtH4>Примечание</H4>", Ложь, );
				Стр3 = СтрНайтиМежду(Стр3[0], "<P>Тип:", "</P>", Ложь, );
				Стр3 = СтрНайтиМежду(Стр3[0], ".html"">", "</A>", , );
				Если Стр3.Количество() > 0 Тогда
					Стр3 = Стр3[0];
					Стр3 = СтрЗаменить(Стр3, "&nbsp;", " ");
				КонецЕсли;
				Если Стр3 = СтрЗаголовка Тогда
					Добавлять = Истина;
				КонецЕсли;
			КонецЦикла;
			Для А1 = 0 По ВыбранныеФайлы3.ВГраница() Цикл
				ТекстДок2 = Новый ТекстовыйДокумент;
				ТекстДок2.Прочитать(ВыбранныеФайлы3[А1]);
				Стр2 = ТекстДок2.ПолучитьТекст();
				
				СтрЗаголовка2 = СтрНайтиМежду(Стр2, "<H1 class=dtH1>", "</H1>", , );
				СтрЗаголовка2 = СтрЗаголовка2[0];
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Метод", "");
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
				СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
				
				Стр3 = СтрНайтиМежду(Стр2, "<H4 class=dtH4>Возвращаемое значение</H4>", "<H4 class=dtH4>Описание</H4>", Ложь, );
				Если Стр3.Количество() > 0 Тогда
					Если Стр3.Количество() > 0 Тогда
						Стр3 = СтрНайтиМежду(Стр3[0], "<P>Тип:", "</P>", Ложь, );
						Если Стр3.Количество() > 0 Тогда
							Стр3 = СтрНайтиМежду(Стр3[0], ".html"">", "</A>", , );
							Если Стр3.Количество() > 0 Тогда
								Стр3 = Стр3[0];
								Стр3 = СтрЗаменить(Стр3, "&nbsp;", " ");
							КонецЕсли;
							Если Стр3 = СтрЗаголовка Тогда
								Добавлять = Истина;
							КонецЕсли;
						КонецЕсли;
					КонецЕсли;
				КонецЕсли;
			КонецЦикла;
			Если Добавлять = Истина Тогда
				БезКонструктора = БезКонструктора + 1;
				СтрВСписок = СтрВСписок + "===================";
				СтрВСписок = СтрВСписок + Символы.ПС + "Класс = " + СтрЗаголовка;
			КонецЕсли;
			
			// найдем в каком свойстве возвращается этот класс
			Для А1 = 0 По ВыбранныеФайлы2.ВГраница() Цикл
				ТекстДок2 = Новый ТекстовыйДокумент;
				ТекстДок2.Прочитать(ВыбранныеФайлы2[А1]);
				Стр2 = ТекстДок2.ПолучитьТекст();
				
				СтрЗаголовка2 = СтрНайтиМежду(Стр2, "<H1 class=dtH1>", "</H1>", , );
				СтрЗаголовка2 = СтрЗаголовка2[0];
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Свойство", "");
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
				СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
				
				Стр3 = СтрНайтиМежду(Стр2, "<H4 class=dtH4>Значение</H4>", "<H4 class=dtH4>Примечание</H4>", Ложь, );
				Стр3 = СтрНайтиМежду(Стр3[0], "<P>Тип:", "</P>", Ложь, );
				Стр3 = СтрНайтиМежду(Стр3[0], ".html"">", "</A>", , );
				Если Стр3.Количество() > 0 Тогда
					Стр3 = Стр3[0];
					Стр3 = СтрЗаменить(Стр3, "&nbsp;", " ");
				КонецЕсли;
				Если Стр3 = СтрЗаголовка Тогда
					НайденоСоответствий = НайденоСоответствий + 1;
					СтрВСписок = СтрВСписок + Символы.ПС + "Как конструктор = " + СтрЗаголовка2;
				КонецЕсли;
			КонецЦикла;
			
			// найдем в каком методе возвращается этот класс
			Для А1 = 0 По ВыбранныеФайлы3.ВГраница() Цикл
				ТекстДок2 = Новый ТекстовыйДокумент;
				ТекстДок2.Прочитать(ВыбранныеФайлы3[А1]);
				Стр2 = ТекстДок2.ПолучитьТекст();
				
				СтрЗаголовка2 = СтрНайтиМежду(Стр2, "<H1 class=dtH1>", "</H1>", , );
				СтрЗаголовка2 = СтрЗаголовка2[0];
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Метод", "");
				СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
				СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
				
				Стр3 = СтрНайтиМежду(Стр2, "<H4 class=dtH4>Возвращаемое значение</H4>", "<H4 class=dtH4>Описание</H4>", Ложь, );
				Если Стр3.Количество() > 0 Тогда
					Если Стр3.Количество() > 0 Тогда
						Стр3 = СтрНайтиМежду(Стр3[0], "<P>Тип:", "</P>", Ложь, );
						Если Стр3.Количество() > 0 Тогда
							Стр3 = СтрНайтиМежду(Стр3[0], ".html"">", "</A>", , );
							Если Стр3.Количество() > 0 Тогда
								Стр3 = Стр3[0];
								Стр3 = СтрЗаменить(Стр3, "&nbsp;", " ");
							КонецЕсли;
							Если Стр3 = СтрЗаголовка Тогда
								НайденоСоответствий = НайденоСоответствий + 1;
								СтрВСписок = СтрВСписок + Символы.ПС + "Как конструктор = " + СтрЗаголовка2;
							КонецЕсли;
						КонецЕсли;
					КонецЕсли;
				КонецЕсли;
			КонецЦикла;
			Если Добавлять = Истина Тогда
				Список.Добавить(СтрЗаголовка, СтрВСписок);
			КонецЕсли;
		КонецЕсли;
		
	КонецЦикла;
	Список.СортироватьПоЗначению();
	Если Список.Количество() > 0 Тогда
		Для А2 = 0 По Список.Количество() - 1 Цикл
			Сообщить("" + Список.Получить(А2).Представление);
			// Сообщить("" + Список.Получить(А2).Значение);
		КонецЦикла;
	КонецЕсли;
	
	Сообщить("===================");
	Сообщить("БезКонструктора = " + БезКонструктора);
	Сообщить("НайденоСоответствий = " + НайденоСоответствий);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин.");
КонецПроцедуры//КлассыБезКонструктора()

Процедура ТипыЗначений()
	// Список = Новый СписокЗначений;
	// ВыбранныеФайлы = НайтиФайлы("C:\444", "*.html", Истина);
	// Найдено1 = 0;
	// Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		// ТекстДок = Новый ТекстовыйДокумент;
		// ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		// Стр = ТекстДок.ПолучитьТекст();
		// М = СтрНайтиМежду(Стр, "<P>Тип:", "</P>", , );
		// Если М.Количество() > 0 Тогда
			// СтрТип = М[0];
			// Если Список.НайтиПоЗначению(СтрТип) = Неопределено Тогда
				// Список.Добавить(СтрТип);
			// КонецЕсли;
		// КонецЕсли;
	// КонецЦикла;
	
	// Для А = 0 По Список.Количество() - 1 Цикл
		// Стр1 = Список.Получить(А).Значение;
		// Если СтрНайти(Стр1, "<A href") > 0 Тогда
		// Иначе
			// Сообщить("" + Стр1);
		// КонецЕсли;
	// КонецЦикла;
КонецПроцедуры// ТипыЗначений()

Процедура ЗаполнениеМетодовФормыДляОдноСкрипта();
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ИмяФайлаЧленов = "C:\444\OneScriptFormsru\OneScriptForms.OneScriptFormsMembers.html";
	КлассАнгл = "OneScriptForms";
	КолМетодов = 0;
	//находим методы класса из файла OneScriptForms....(Класс).....Members.html
	Методы = ПолучитьМассивМетодовКласса(ИмяФайлаЧленов, КлассАнгл);
	Сообщить("---Методы---(" + Методы.Количество() + ")");
	Для А3 = 0 По Методы.ВГраница() Цикл
		МетодРус = РазобратьСтроку(Методы[А3], " ")[0];
		МетодАнгл = РазобратьСтроку(Методы[А3], " ")[1];
		// Сообщить("" + Символы.Таб + МетодРус + " (" + МетодАнгл + ")");
		КолМетодов = КолМетодов + 1;
		//Находим файлы источника и назначения
		ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms." + МетодАнгл + "Constructor.html";
		ПутьНазн = "C:\444\OneScriptFormsru\OneScriptForms.OneScriptForms." + МетодАнгл + ".html";
		Если ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.EnableVisualStylesConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.MethodsObjConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.MouseKeyPressConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.FindWindowByCaptionConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.PostEventProcessingConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.SendKeysConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.DoEventsConstructor.html" или//
			ПутьИст = "C:\444\OneScriptFormsru\OneScriptForms.PropObjConstructor.html" Тогда//
			Продолжить;
		КонецЕсли;
		ФайлИст = Новый Файл(ПутьИст);
		ФайлНазн = Новый Файл(ПутьНазн);
		Если ФайлИст.Существует() И ФайлНазн.Существует() Тогда
		Иначе
			Сообщить("Нет " + ПутьИст);
		КонецЕсли;
		
		ТекстДокИст = Новый ТекстовыйДокумент;
		ТекстДокИст.Прочитать(ПутьИст);
		СтрИст = ТекстДокИст.ПолучитьТекст();
		СинтаксисИст = СтрНайтиМежду(СтрИст, "<H4 class=dtH4>Синтаксис</H4>", "<H4 class=dtH4>Описание</H4>", , )[0];
		
		ТекстДокНазн = Новый ТекстовыйДокумент;
		ТекстДокНазн.Прочитать(ПутьНазн);
		СтрНазн = ТекстДокНазн.ПолучитьТекст();
		СинтаксисНазн = СтрНайтиМежду(СтрНазн, "<H4 class=dtH4>Синтаксис</H4>", "<H4 class=dtH4>Возвращаемое значение</H4>", , )[0];
		// // Сообщить("=====" + ПутьИст + "==========================================================================================");
		// // Сообщить("" + СинтаксисИст);
		// // Сообщить("" + СинтаксисНазн);
		ПодстрокаПоиска = СинтаксисНазн;
		ПодстрокаЗамены = СинтаксисИст;
		СтрНазн = СтрЗаменить(СтрНазн, ПодстрокаПоиска, ПодстрокаЗамены);
		
		ПримерИст = СтрНайтиМежду(СтрИст, "<H4 class=dtH4>Пример</H4>", "<H4 class=dtH4>Смотрите также</H4>", , )[0];
		ПримерНазн = СтрНайтиМежду(СтрНазн, "<H4 class=dtH4>Пример</H4>", "<H4 class=dtH4>Смотрите также</H4>", , )[0];
		// // Сообщить("=====" + ПутьИст + "==========================================================================================");
		// // Сообщить("" + ПримерИст);
		// // Сообщить("" + ПримерНазн);
		ПодстрокаПоиска = ПримерНазн;
		ПодстрокаЗамены = ПримерИст;
		СтрНазн = СтрЗаменить(СтрНазн, ПодстрокаПоиска, ПодстрокаЗамены);
		
		//"ИнформацияЗапускаПроцесса (ProcessStartInfo) Конструктор" + " " + ТекущаяДата())
		//ФормыДляОдноСкрипта.ИнформацияЗапускаПроцесса (OneScriptForms.ProcessStartInfo) Метод
		ПодстрокаПоиска = """" + МетодРус + " (" + МетодАнгл + ") Конструктор"" + "" "" + ТекущаяДата())";
		ПодстрокаЗамены = """ФормыДляОдноСкрипта." + МетодРус + " (OneScriptForms." + МетодАнгл + ") Метод"" + "" "" + ТекущаяДата())";
		// // Сообщить("=====" + ПутьИст + "==========================================================================================");
		// // Сообщить("" + ПодстрокаПоиска);
		// // Сообщить("===");
		// // Сообщить("" + ПодстрокаЗамены);
		СтрНазн = СтрЗаменить(СтрНазн, ПодстрокаПоиска, ПодстрокаЗамены);
		
		СкриптИст = СтрНайтиМежду(СтрИст, "<script>", "</script>", , )[0];
		СкриптНазн = СтрНайтиМежду(СтрНазн, "<script>", "</script>", , )[0];
		// // Сообщить("=====" + ПутьИст + "==========================================================================================");
		// // Сообщить("" + СкриптИст);
		// // Сообщить("" + СкриптНазн);
		ПодстрокаПоиска = СкриптНазн;
		ПодстрокаЗамены = СкриптИст;
		СтрНазн = СтрЗаменить(СтрНазн, ПодстрокаПоиска, ПодстрокаЗамены);
		
		ТекстДокНазн.УстановитьТекст(СтрНазн);
		ТекстДокНазн.Записать(ПутьНазн);
		
	КонецЦикла;
	
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//ЗаполнениеМетодовФормыДляОдноСкрипта()

Процедура БезТестовыхКодов()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	БезТестов = 0;
	ВыбранныеФайлы = НайтиФайлы("C:\444\OneScriptFormsru", "*.html", Истина);
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		
		М = СтрНайтиМежду(Стр, "<H1 class=dtH1>", "</H1>", , );
		Если М.Количество() > 0 Тогда
			Заголовок = СтрНайтиМежду(Стр, "<H1 class=dtH1>", "</H1>", , )[0];
			Заголовок = СтрЗаменить(Заголовок, "&nbsp;", " ");
			
			М1 = СтрНайтиМежду(Стр, "<details><summary>Тестовый код</summary>", "</DIV>", , );
			Для А1 = 0 По М1.Количество() - 1 Цикл
				СтрКода = М1[А1];
				Если СтрНайти(СтрКода, "Сообщить(?(") > 0 Тогда
					
				Иначе
					БезТестов = БезТестов + 1;
					Сообщить("===" + Заголовок);
				КонецЕсли;
				
			КонецЦикла;
		Иначе
			Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя);
		КонецЕсли;
	КонецЦикла;
	
	Сообщить("БезТестов = " + БезТестов);
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//БезТестовыхКодов()

Процедура КтоНаследует()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	КолНаследуемых = 0;
	ВыбранныеФайлы = ОтобратьФайлы("Члены");
	Список = Новый СписокЗначений;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		Стр = ТекстДок.ПолучитьТекст();
		
		РодительМассив = СтрНайтиМежду(Стр, "(унаследовано", "</TD>", , );
		Для А1 = 0 По РодительМассив.ВГраница() Цикл
			РодительСтрока = РодительМассив[А1];
			РодительСтрока2 = СтрНайтиМежду(РодительСтрока, "<B>", "</B>", , )[0];
			РодительСтрока2 = СтрЗаменить(РодительСтрока2, "&nbsp;", " ");
			КолНаследуемых = КолНаследуемых + 1;
			Если Список.НайтиПоЗначению(РодительСтрока2) = Неопределено Тогда
				Список.Добавить(РодительСтрока2);
			КонецЕсли;
			
			
		КонецЦикла;
		
		// Если СтрНайти() > 0 Тогда
			// СтрВСписок = ВыбранныеФайлы[А] + " - " + 
			
		// КонецЕсли;
		// СтрЗаголовка2 = СтрНайтиМежду(Стр, "<H1 class=dtH1>", "</H1>", , );
		// СтрЗаголовка2 = СтрЗаголовка2[0];
		// СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Методы", "");
		// СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
		// СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
		// // Сообщить("СтрЗаголовка = " + СтрЗаголовка);
		// // Сообщить("СтрЗаголовка2 = " + СтрЗаголовка2);
		// // Сообщить("==========================================================================================================================================");
	
	КонецЦикла;
	
	Список.СортироватьПоЗначению();
	Сообщить("КолНаследуемых = " + КолНаследуемых);
	Сообщить("Найдено родителей " + Список.Количество());
	Сообщить("-------------------------------------------------");
	Для А2 = 0 По Список.Количество() - 1 Цикл
		СтрСписок = Список.Получить(А2).Значение;
		Сообщить("" + СтрСписок);
	КонецЦикла;
	Сообщить("-------------------------------------------------");
	
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//КтоНаследует()

Процедура КлассыНеИспользующиеНаследованиеСвойствМетодов()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	// ВыбранныеФайлы = ОтобратьФайлы("Члены");
	ВыбранныеФайлы = ОтобратьФайлы("Методы");
	Список = Новый СписокЗначений;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А]);
		Стр = ТекстДок.ПолучитьТекст();
		
		РодительМассив = СтрНайтиМежду(Стр, "(унаследовано", "</TD>", , );
		// Для А1 = 0 По РодительМассив.ВГраница() Цикл
			// РодительСтрока = РодительМассив[А1];
			// РодительСтрока2 = СтрНайтиМежду(РодительСтрока, "<B>", "</B>", , )[0];
			// РодительСтрока2 = СтрЗаменить(РодительСтрока2, "&nbsp;", " ");
			// КолНаследуемых = КолНаследуемых + 1;
			// Если Список.НайтиПоЗначению(РодительСтрока2) = Неопределено Тогда
				// Список.Добавить(РодительСтрока2);
			// КонецЕсли;
		// КонецЦикла;
		
		Если РодительМассив.Количество() = 0 Тогда
			Если Список.НайтиПоЗначению(ВыбранныеФайлы[А]) = Неопределено Тогда
				Список.Добавить(ВыбранныеФайлы[А]);
			КонецЕсли;
			
			СтрЗаголовка2 = СтрНайтиМежду(Стр, "<H1 class=dtH1>", "</H1>", , );
			СтрЗаголовка2 = СтрЗаголовка2[0];
			СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Методы", "");
			СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
			СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
			Сообщить("" + СтрЗаголовка2);
			
		КонецЕсли;
		
		// Если СтрНайти() > 0 Тогда
			// СтрВСписок = ВыбранныеФайлы[А] + " - " + 
			
		// КонецЕсли;
		// СтрЗаголовка2 = СтрНайтиМежду(Стр, "<H1 class=dtH1>", "</H1>", , );
		// СтрЗаголовка2 = СтрЗаголовка2[0];
		// СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "Методы", "");
		// СтрЗаголовка2 = СтрЗаменить(СтрЗаголовка2, "&nbsp;", " ");
		// СтрЗаголовка2 = СокрЛП(СтрЗаголовка2);
		// // Сообщить("СтрЗаголовка = " + СтрЗаголовка);
		// // Сообщить("СтрЗаголовка2 = " + СтрЗаголовка2);
		// // Сообщить("==========================================================================================================================================");
	
	КонецЦикла;
	
	Список.СортироватьПоЗначению();
	Сообщить("Найдено классов не использующих наследуемых свойств и методов " + Список.Количество());
	Сообщить("-------------------------------------------------");
	Для А2 = 0 По Список.Количество() - 1 Цикл
		СтрСписок = Список.Получить(А2).Значение;
		Сообщить("" + СтрСписок);
	КонецЦикла;
	Сообщить("-------------------------------------------------");
	
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//КлассыНеИспользующиеНаследованиеСвойствМетодов()

Процедура СортировкаКода()
	Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();
	
	ВыбранныеФайлы = НайтиФайлы("C:\444\ВыгруженныеОбъекты", "*.cs", Ложь);
	Найдено1 = 0;
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		СтрДирективы = "";
		Директивы = Новый СписокЗначений;
		Классы1Уровня = Новый СписокЗначений;
		Классы2Уровня = Новый СписокЗначений;
		Классы3Уровня = Новый СписокЗначений;
		
		Если ВыбранныеФайлы[А].Имя = "ExtractIconClass.cs" Тогда
			Продолжить;
		КонецЕсли;
		// // // Если ВыбранныеФайлы[А].Имя <> "Control.cs" Тогда
			// // // Продолжить;
		// // // КонецЕсли;
		
		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		
		Сообщить(" (" + Лев(Строка(((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60), 4) + " мин." + " " + (А + 1) + " из " + ВыбранныеФайлы.Количество() + ") " + ВыбранныеФайлы[А].ПолноеИмя);
		
		// Сообщить("=== " + ВыбранныеФайлы[А].Имя + " ========================================================================================");
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "using", "namespace", , );
		Если М.Количество() > 0 Тогда
			// Сообщить("=== " + ВыбранныеФайлы[А].Имя + " =========================================================================");
			СтрДирективы = М[0];
			СтрДирективы = СокрЛП(СтрДирективы);
			Директивы.Добавить("using " + СтрДирективы);
		КонецЕсли;
		
		Если Не (СтрДирективы = "") Тогда
			Стр = СтрЗаменить(Стр, СтрДирективы, "");
		КонецЕсли;
		
		//Классы3Уровня оставляем без изменения
		М = СтрНайтиМежду(Стр, "[ContextClass", "//endClass", , );
		Если М.Количество() > 0 Тогда
			Для А1 = 0 По М.ВГраница() Цикл
				СтрКлассы3Уровня = М[А1];
				СтрКлассы3Уровня = СокрЛП(СтрКлассы3Уровня);
				Классы3Уровня.Добавить("    [ContextClass " + СтрКлассы3Уровня);
			КонецЦикла;
			Стр = СтрЗаменить(Стр, СтрКлассы3Уровня, "");
		КонецЕсли;
		
		//Классы1Уровня оставляем без изменения
		М = СтрНайтиМежду(Стр, "public class", "//endClass", Ложь, );
		Если М.Количество() > 0 Тогда
			Для А1 = 0 По М.ВГраница() Цикл
				Если СтрНайти(М[А1], "Ex :") > 0 Тогда
					СтрКлассы1Уровня = М[А1];
					СтрКлассы1Уровня = СтрЗаменить(СтрКлассы1Уровня, "//endClass", "");
					СтрКлассы1Уровня = СокрЛП(СтрКлассы1Уровня);
					Классы1Уровня.Добавить("    " + СтрКлассы1Уровня);
					Стр = СтрЗаменить(Стр, СтрКлассы1Уровня, "");
				Иначе
					СтрКлассы2Уровня = М[А1];
					СтрКлассы2Уровня = СокрЛП(СтрКлассы2Уровня);
					Классы2Уровня.Добавить(СортировкаКласса2Уровня(СтрКлассы2Уровня));
					Стр = СтрЗаменить(Стр, СтрКлассы2Уровня, "");
				КонецЕсли;
			КонецЦикла;
		КонецЕсли;
		
		Директивы.СортироватьПоЗначению();
		Стр = "";
		
		Для А1 = 0 По Директивы.Количество() - 1 Цикл
				Стр = Стр + Символы.ПС + Директивы.Получить(А1).Значение;
		КонецЦикла;
		Стр = Стр + Символы.ПС + Символы.ПС + "namespace osf" + Символы.ПС + "{";
		Для А1 = 0 По Классы1Уровня.Количество() - 1 Цикл
			Стр = Стр + Символы.ПС + Классы1Уровня.Получить(А1).Значение;
		КонецЦикла;
		Если Классы2Уровня.Количество() > 0 Тогда
			Для А1 = 0 По Классы2Уровня.Количество() - 1 Цикл
				Стр = Стр + Символы.ПС + Классы2Уровня.Получить(А1).Значение;
				Стр = Стр + Символы.ПС;
				Стр = Стр + Символы.ПС + "    }" + Символы.ПС;
			КонецЦикла;
		КонецЕсли;
		Для А1 = 0 По Классы3Уровня.Количество() - 1 Цикл
			Стр = Стр + Символы.ПС + Классы3Уровня.Получить(А1).Значение;
		КонецЦикла;
		Стр = Стр + Символы.ПС + "}";
		
		//удалим "//endMethods"
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) - 1 Цикл
			Фрагмент1 = СокрЛП(СтрПолучитьСтроку(Стр, А1)) + СокрЛП(СтрПолучитьСтроку(Стр, А1 + 1));
			Если Не (Фрагмент1 = "//endMethods") Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, СтрЧислоСтрок(Стр));
		Стр = СтрКонечная;
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) Цикл
			Если Не (СокрЛП(СтрПолучитьСтроку(Стр, А1)) = "//endMethods") Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		
		//удалим "//endProperty"
		Стр = СтрКонечная;
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) - 1 Цикл
			Фрагмент1 = СокрЛП(СтрПолучитьСтроку(Стр, А1)) + СокрЛП(СтрПолучитьСтроку(Стр, А1 + 1));
			Если Не (Фрагмент1 = "//endProperty") Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, СтрЧислоСтрок(Стр));
		Стр = СтрКонечная;
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) Цикл
			Если Не (СокрЛП(СтрПолучитьСтроку(Стр, А1)) = "//endProperty") Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		
		//подправим "//Методы============================================================"
		Стр = СтрКонечная;
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) Цикл
			Если СокрЛП(СтрПолучитьСтроку(Стр, А1)) = "//Методы============================================================" Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + Символы.ПС + СтрПолучитьСтроку(Стр, А1) + Символы.ПС;
			Иначе
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		
		//подправим "//Свойства============================================================"
		Стр = СтрКонечная;
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) Цикл
			Если СокрЛП(СтрПолучитьСтроку(Стр, А1)) = "//Свойства============================================================" Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1) + Символы.ПС;
			Иначе
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		
		//заменим две пустые строки подряд на одну пустую
		Стр = СтрКонечная;
		СтрКонечная = "";
		Для А1 = 1 По СтрЧислоСтрок(Стр) - 1 Цикл
			Фрагмент1 = СокрЛП(СтрПолучитьСтроку(Стр, А1)) + СокрЛП(СтрПолучитьСтроку(Стр, А1 + 1));
			Если Не (Фрагмент1 = "") Тогда
				СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, А1);
			КонецЕсли;
		КонецЦикла;
		СтрКонечная = СтрКонечная + Символы.ПС + СтрПолучитьСтроку(Стр, СтрЧислоСтрок(Стр));
		
		ПодстрокаПоиска = "//end_constr";
		ПодстрокаЗамены = "";
		СтрКонечная = СтрЗаменить(СтрКонечная, ПодстрокаПоиска, ПодстрокаЗамены);
		
		ПодстрокаПоиска = "//Методы============================================================
		|
		|        //Методы============================================================";
		ПодстрокаЗамены = "//Методы============================================================";
		СтрКонечная = СтрЗаменить(СтрКонечная, ПодстрокаПоиска, ПодстрокаЗамены);
		
		СтрКонечная = СокрЛП(СтрКонечная);
		// Сообщить("" + СтрКонечная);
		
		ТекстДок.УстановитьТекст(СтрКонечная);
		ТекстДок.Записать(ВыбранныеФайлы[А].ПолноеИмя);
	КонецЦикла;
	
	Сообщить("Найдено " + ВыбранныеФайлы.Количество());
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//СортировкаКода()

Функция СортировкаКласса2Уровня(СтрКласса)
	Стр = СтрЗаменить(СтрКласса,  "}//endClass", "//end");
	
	М3 = СтрНайтиМежду(Стр, "[DllImport", ";", Ложь, );
	Для А = 0 По М3.ВГраница() Цикл
		Стр = СтрЗаменить(Стр, М3[А], "");
	КонецЦикла;
	
	//повставлять \r\n//end перед каждым private, public, [DllImport
	Стр = СтрЗаменить(Стр, "private", "//end" + Символы.ПС + "private");
	Стр = СтрЗаменить(Стр, "public", "//end" + Символы.ПС + "public");
	
	Голова = "";
	Поля = Новый СписокЗначений;
	Конструкторы = Новый СписокЗначений;
	Свойства = Новый СписокЗначений;
	Методы = Новый СписокЗначений;
	
	М = Новый Массив;
	М1 = СтрНайтиМежду(Стр, "private", "//end", , );
	М2 = СтрНайтиМежду(Стр, "public", "//end", , );
	Для А = 0 По М1.ВГраница() Цикл
		М.Добавить("private" + М1[А]);
	КонецЦикла;
	Для А = 0 По М2.ВГраница() Цикл
		М.Добавить("public" + М2[А]);
	КонецЦикла;
	Для А = 0 По М3.ВГраница() Цикл
		М.Добавить("" + М3[А]);
	КонецЦикла;
	
	Для А = 0 По М.ВГраница() Цикл
		Фрагмент = СокрЛП(М[А]);
		ВтороеСловоВоФрагменте = "";
		М125 = СтрРазделить(Фрагмент, "");
		Если М125.Количество() > 0 Тогда
			ВтороеСловоВоФрагменте = М125[1];
		КонецЕсли;
		
		ИмяКласса = "";
		СтрокаСИменемКласса = СтрПолучитьСтроку(СокрЛП(СтрКласса), 1);
		ИмяКласса = СтрРазделить(СтрПолучитьСтроку(СокрЛП(СтрКласса), 1), " ")[2];
		
		// если есть слово class тогда это Голова
		Если СтрНайти(Фрагмент, "class") > 0 Тогда
			Голова = Голова + Символы.ПС + "    " + Фрагмент;
		// если последний знак ; тогда это Поля
		ИначеЕсли (Прав(Фрагмент, 1) = ";") или (СтрНайти(Фрагмент, "DllImport") > 0) Тогда
			//создать представление
			Поля.Добавить("        " + Фрагмент, СтрРазделить(СтрПолучитьСтроку(Фрагмент, 1), " ")[2]);
		// если первая строка содержит имя класса со следующей за ним скобкой тогда это Конструкторы
		ИначеЕсли Лев(ВтороеСловоВоФрагменте, СтрДлина(ИмяКласса + "(")) = ИмяКласса + "(" Тогда
			Конструкторы.Добавить("        " + Фрагмент);
		// если есть слово set или get тогда это Свойства
		ИначеЕсли (СтрНайти(Фрагмент, "get") > 0) или (СтрНайти(Фрагмент, "set") > 0) Тогда
			Свойства.Добавить("        " + Фрагмент, СтрРазделить(СтрПолучитьСтроку(Фрагмент, 1), " ")[2]);
		// если в первой строке есть скобка ( тогда это Методы
		ИначеЕсли СтрНайти(СтрПолучитьСтроку(Фрагмент, 1), "(") > 0 Тогда
			Методы.Добавить("        " + Фрагмент, СтрРазделить(СтрПолучитьСтроку(Фрагмент, 1), " ")[2]);
		// иначе сообщить этот фрагмент
		Иначе
			Сообщить("=====================================");
			Сообщить("Не обработан фрагмент " + Символы.ПС + М[А]);
			Сообщить("=====================================");
		КонецЕсли;
	КонецЦикла;
	
	Поля.СортироватьПоПредставлению();
	Конструкторы.СортироватьПоЗначению();
	Свойства.СортироватьПоПредставлению();
	Методы.СортироватьПоПредставлению();

	Стр = Голова;
	Для А = 0 По Поля.Количество() - 1 Цикл
		Стр = Стр + Символы.ПС + Поля.Получить(А).Значение;
	КонецЦикла;
	Для А = 0 По Конструкторы.Количество() - 1 Цикл
		Стр = Стр + Символы.ПС + Символы.ПС + Конструкторы.Получить(А).Значение;
	КонецЦикла;
	Стр = Стр + Символы.ПС + Символы.ПС + "        //Свойства============================================================";
	Для А = 0 По Свойства.Количество() - 1 Цикл
		Стр = Стр + Символы.ПС + Символы.ПС + Свойства.Получить(А).Значение;
	КонецЦикла;
	Стр = Стр + Символы.ПС + Символы.ПС + "        //Методы============================================================";
	Для А = 0 По Методы.Количество() - 1 Цикл
		Стр = Стр + Символы.ПС + Символы.ПС + Методы.Получить(А).Значение;
	КонецЦикла;
	
	ПодстрокаПоиска = "ControlRemoved = """";
	|            }";
	ПодстрокаЗамены = "ControlRemoved = """";
	|            }
	|        }
	|	";
	Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	
	Возврат Стр;
КонецФункции//СортировкаКласса2Уровня(СтрКласса)

// ЗаполнитьПримерамиЦвета();
// СвойстваАрг();
// СвойстваМеткаИРодитель();
// // // СтраницыБезПримера();
// ИзменениеСекцииПример();
// ДобавлениеКопированияВПример();
// СтавлюДвоеточие();
// // // ВыгрузкаДляCS();//запускать перед СортировкаКода и связанно
// // // СортировкаКода();//запускать после ВыгрузкаДляCS и связанно
// ТипыЗначений();
// // // ПолучитьКлассыСвойстваМетодыПеречисления();
// // // КлассыБезКонструктора();
// ЗаполнениеМетодовФормыДляОдноСкрипта();
БезТестовыхКодов();
// КтоНаследует();
// КлассыНеИспользующиеНаследованиеСвойствМетодов();
