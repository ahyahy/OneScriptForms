// КаталогСправки задан как "C:\444". Разместите там каталог OneScriptFormsru с файлами справки или укажите свой.
// КаталогБиблиотеки задан как "C:\444\111\OneScriptForms\OneScriptForms\bin\Debug". Разместите там файл библиотеки OneScriptForms.dll или укажите свой.
// Продолжительность примерно 20 минут.
Перем Ф, ИмяВременногоФайла, Таймер, ПолеВвода1, Форма1, Сч1, Сч2, Сч3, Сч4, Сч5, Сч6;
Перем ТекстТеста, СтрКода0, СтрСозданияОбъекта, СтрСозданияОбъекта2, СписокИменПараметров, ФормаNotifyIcon;
Перем СписокОшибок, КаталогСправки, КаталогБиблиотеки, М_Свойств;

Функция РазобратьСтроку(Строка, Разделитель)
	Стр = СтрЗаменить(Строка, Разделитель, Символы.ПС);
	М = Новый Массив;
	Если ПустаяСтрока(Стр) Тогда
		Возврат М;
	КонецЕсли;
	Для Ч = 1 По СтрЧислоСтрок(Стр) Цикл
		М.Добавить(СтрПолучитьСтроку(Стр,Ч));
	КонецЦикла;
	Возврат М;
КонецФункции

Функция СтрНайтиМежду(СтрПараметр, Фрагмент1 = Неопределено, Фрагмент2 = Неопределено, ИсключитьФрагменты = Истина, БезНаложения = Истина)
	//Стр - исходная строка
	//Фрагмент1 - подстрока поиска от которой ведем поиск
	//Фрагмент2 - подстрока поиска до которой ведем поиск
	//ИсключитьФрагменты - не включать Фрагмент1 и Фрагмент2 в результат
	//БезНаложения - в результат не будут включены участки, содержащие дугие найденные участки, удовлетворяющие переданным параметрам
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
КонецФункции

Функция ПолучитьОбъектДляСвойств(КлассРус, КлассАнгл)
	// Тестируются только те свойства или методы, которые наследуются от родителя.
	// остальные можно протестировать из тестового кода в справке

	Если (КлассАнгл = "FileDialog") или 
		(КлассАнгл = "ScrollBar") или 
		(КлассАнгл = "Control") или 
		(КлассАнгл = "ListControl") или 
		(КлассАнгл = "ContainerControl") или 
		(КлассАнгл = "UpDownBase") или 
		(КлассАнгл = "ScrollableControl") или 
		(КлассАнгл = "TextBoxBase") или 
		(КлассАнгл = "ButtonBase") или 
		(КлассАнгл = "CommonDialog") или 
		(КлассАнгл = "EventArgs") или 
		(КлассАнгл = "BitmapData") или 
		(КлассАнгл = "DataGridViewHeaderCell") или
		(КлассАнгл = "Brush") Тогда // базовые классы
		Возврат Ложь;
	ИначеЕсли (КлассАнгл = "DataGridViewCell") Тогда // ЯчейкаТаблицы (DataGridViewCell) Класс
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|Таблица1.ДобавлятьСтроки = Ложь;
		|Таблица1.КоличествоСтрок = 2;
		|Таблица1.КоличествоКолонок = 2;
		|
		|ЯчейкаТаблицы1 = Таблица1.Ячейка(0, 0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewCellCollection") Тогда // ЯчейкиТаблицы (DataGridViewCellCollection)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|Таблица1.КоличествоКолонок = 2;
		|Таблица1.КоличествоСтрок = 5;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|ЯчейкиТаблицы1 =Таблица1.Строки(0).Ячейки;
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewCheckBoxCell") Тогда // ФлажокЯчейки (DataGridViewCheckBoxCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаФлажок1 = Ф.КолонкаФлажок();
		|Таблица1.Колонки.Добавить(КолонкаФлажок1);
		|Таблица1.Колонки.Добавить(Ф.КолонкаФлажок());
		|Таблица1.КоличествоСтрок = 3;
		|
		|КолонкаФлажок1.ПлоскийСтиль = Ф.ПлоскийСтиль.Всплывающий;
		|
		|ФлажокЯчейки1 = Таблица1.Ячейка(0, 0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewLinkCell") Тогда // СсылкаЯчейки (DataGridViewLinkCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаСсылка1 = Ф.КолонкаСсылка();
		|Таблица1.Колонки.Добавить(КолонкаСсылка1);
		|Таблица1.Колонки.Добавить(Ф.КолонкаСсылка());
		|Таблица1.КоличествоСтрок = 5;
		|Таблица1.ДобавлятьСтроки = Ложь;
		|
		|КолонкаСсылка1.Текст = ""infostart.ru"";
		|КолонкаСсылка1.ИспользоватьТекстКакСсылку = Истина;
		|
		|СсылкаЯчейки1 = Таблица1.Ячейка(0, 2);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewBand") Тогда // ПолосаТаблицы (DataGridViewBand)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.КоличествоКолонок = 4;
		|Таблица1.КоличествоСтрок = 7;
		|
		|Для А = 0 По Таблица1.Колонки.Количество - 1 Цикл
		|	Колонка = Таблица1.Колонки(А);
		|	Колонка.ТекстЗаголовка = ""Кол"" + А;
		|	Колонка.РежимСортировки = Ф.РежимСортировки.Программный;
		|КонецЦикла;
		|Для А = 0 По Таблица1.Строки.Количество - 1 Цикл
		|	Таблица1.Строки(А).ЗаголовокСтроки.Значение = """" + А;
		|КонецЦикла;
		|
		|Таблица1.РежимВыбора = Ф.РежимВыбораТаблицы.Колонка;
		|
		|ПолосаТаблицы1 = Таблица1.Колонки(2);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewComboBoxCell") Тогда // ПолеВыбораЯчейки (DataGridViewComboBoxCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаПолеВыбора1 = Ф.КолонкаПолеВыбора();
		|КолонкаПолеВыбора1.Ширина = 215;
		|Таблица1.Колонки.Добавить(КолонкаПолеВыбора1);
		|Таблица1.Колонки.Добавить(Ф.КолонкаПолеВыбора());
		|Таблица1.КоличествоСтрок = 3;
		|
		|КолонкаПолеВыбора1.Элементы.Добавить(""Челябинск"");
		|КолонкаПолеВыбора1.Элементы.Добавить(""Хабаровск"");
		|КолонкаПолеВыбора1.Элементы.Добавить(""Тюмень"");
		|КолонкаПолеВыбора1.Элементы.Добавить(""Москва"");
		|КолонкаПолеВыбора1.Элементы.Добавить(""Саратов""); 
		|
		|Таблица1.Строки(0).Ячейки(0).Значение = ""Тюмень"";
		|Таблица1.Строки(1).Ячейки(0).Значение = ""Саратов"";
		|Таблица1.Строки(2).Ячейки(0).Значение = ""Москва"";
		|
		|КолонкаПолеВыбора1.Отсортирован = Истина;
		|
		|ПолеВыбораЯчейки1 = Таблица1.Ячейка(0, 0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewTextBoxCell") Тогда // ПолеВводаЯчейки (DataGridViewTextBoxCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоШиринаЗаголовковСтрок = Ф.РежимШириныЗаголовковСтрок.ДляОтображаемых;
		|Таблица1.КоличествоКолонок = 3;
		|Таблица1.КоличествоСтрок = 20;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|Для А = 0 По Таблица1.Колонки.Количество - 1 Цикл
		|	Таблица1.Колонки(А).ТекстЗаголовка = ""Кол"" + А;
		|КонецЦикла;
		|
		|ПолеВводаЯчейки1 = Таблица1.Ячейка(0, 0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewColumnCollection") Тогда // КолонкиТаблицы (DataGridViewColumnCollection)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтонумерацияСтрок = Истина;
		|	
		|КолонкиТаблицы1 = Таблица1.Колонки;
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewColumn") Тогда // КолонкаТаблицы (DataGridViewColumn)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|Таблица1.ДобавлятьСтроки = Ложь;
		|Таблица1.АвтоШиринаЗаголовковСтрок = Ф.РежимШириныЗаголовковСтрок.ДляОтображаемых;
		|
		|Для А = 0 По 3 Цикл
		|	КолонкаПолеВвода = Ф.КолонкаПолеВвода();
		|	КолонкаПолеВвода.РежимАвтоРазмера = Ф.РежимАвтоРазмераКолонки.Заполнение;
		|	КолонкаПолеВвода.ТекстЗаголовка = ""Кол"" + А;
		|	Таблица1.Колонки.Добавить(КолонкаПолеВвода);
		|КонецЦикла;
		|Таблица1.КоличествоСтрок = 100000;
		|
		|КолонкаТаблицы1 = Таблица1.Колонки(1);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewButtonCell") Тогда // КнопкаЯчейки (DataGridViewButtonCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|Таблица1.ДобавлятьСтроки = Ложь;
		|
		|КолонкаКнопка1 = Ф.КолонкаКнопка();
		|КолонкаКнопка1.ТекстЗаголовка = ""Кол0"";
		|Таблица1.Колонки.Добавить(КолонкаКнопка1);
		|Таблица1.Колонки.Добавить(Ф.КолонкаКнопка());
		|Таблица1.КоличествоСтрок = 2;
		|
		|КолонкаКнопка1.Текст = ""Кнопа"";
		|КнопкаЯчейки1 = Таблица1.Ячейка(0, 0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewImageCell") Тогда // КартинкаЯчейки (DataGridViewImageCell)
		СтрКода0 = "
		|СтрМасленица1 = ""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"";
		|Картинка1 = Ф.Картинка(СтрМасленица1);
		|
		|Таблица1 = Ф.Таблица();
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.Родитель = Форма1;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаКартинка1 = Ф.КолонкаКартинка();
		|Таблица1.Колонки.Добавить(КолонкаКартинка1);
		|
		|Таблица1.ДобавлятьСтроки = Ложь;
		|Таблица1.КоличествоСтрок = 5;
		|
		|КолонкаКартинка1.ТекстЗаголовка = ""КолонкаКартинка1"";
		|Таблица1.Колонки.Элемент(0).Ширина = 140;
		|Таблица1.Строки(0).Высота = 60;
		|
		|КолонкаКартинка1.Картинка = Картинка1;
		|КолонкаКартинка1.РазмещениеИзображения = Ф.РазмещениеИзображенияЯчейки.Масштабировать;
		|КолонкаКартинка1.Описание = ""Масленица"";
		|
		|КартинкаЯчейки1 = Таблица1.Ячейка(0, 0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridView") Тогда // Таблица (DataGridView)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewButtonColumn") Тогда // КолонкаКнопка (DataGridViewButtonColumn)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|
		|КолонкаКнопка1 = Ф.КолонкаКнопка();
		|КолонкаКнопка1.ТекстЗаголовка = ""Кол0"";
		|Таблица1.Колонки.Добавить(КолонкаКнопка1);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewImageColumn") Тогда // КолонкаКартинка (DataGridViewImageColumn)
		СтрКода0 = "
		|СтрМасленица1 = ""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"";
		|Картинка1 = Ф.Картинка(СтрМасленица1);
		|
		|Таблица1 = Ф.Таблица();
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.Родитель = Форма1;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаКартинка1 = Ф.КолонкаКартинка();
		|
		|Таблица1.Колонки.Добавить(КолонкаКартинка1);
		|
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewTextBoxColumn") Тогда // КолонкаПолеВвода (DataGridViewTextBoxColumn)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.Родитель = Форма1;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаПолеВвода1 = Ф.КолонкаПолеВвода();
		|Таблица1.Колонки.Добавить(КолонкаПолеВвода1);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewComboBoxColumn") Тогда //  КолонкаПолеВыбора (DataGridViewComboBoxColumn)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаПолеВыбора1 = Ф.КолонкаПолеВыбора();
		|КолонкаПолеВыбора1.Ширина = 215;
		|Таблица1.Колонки.Добавить(КолонкаПолеВыбора1);
		|Таблица1.Колонки.Добавить(Ф.КолонкаПолеВыбора());
		|Таблица1.КоличествоСтрок = 3;
		|
		|Булево2 = Истина;
		|Дата2 = Дата(2020,01,02,03);
		|Дата3 = Дата(2022,01,02,03);
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Строка"", ""СтрЗначение""));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Число"", 156.54888));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Булево"", Ложь));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Булево2"", Булево2));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Дата"", (Дата(2019,01,02,03))));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Дата3"", Дата3));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Дата2"", Дата2));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Объект"", Форма1));
		|КолонкаПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка(""Массив"", Новый Массив()));
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewLinkColumn") Тогда // КолонкаСсылка (DataGridViewLinkColumn)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаСсылка1 = Ф.КолонкаСсылка();
		|Таблица1.Колонки.Добавить(КолонкаСсылка1);
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewCheckBoxColumn") Тогда // КолонкаФлажок (DataGridViewCheckBoxColumn)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтоНумерацияСтрок = Истина;
		|
		|КолонкаФлажок1 = Ф.КолонкаФлажок();
		|Таблица1.Колонки.Добавить(КолонкаФлажок1);
		|
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewRow") Тогда //  СтрокаТаблицы (DataGridViewRow)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтонумерацияСтрок = Истина;
		|
		|Для А = 0 По 20 Цикл
		|	Таблица1.Колонки.Добавить(Ф.КолонкаПолеВвода());
		|	Таблица1.Колонки(А).ТекстЗаголовка = ""Кол"" + А;
		|КонецЦикла;
		|
		|СтрокаТаблицы1 = Ф.СтрокаТаблицы();
		|Таблица1.Строки.Добавить(СтрокаТаблицы1);
		|
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewRowHeaderCell") Тогда // ЗаголовокСтроки (DataGridViewRowHeaderCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.КоличествоКолонок = 10;
		|Таблица1.КоличествоСтрок = 2;
		|
		|Для А = 0 По Таблица1.Колонки.Количество - 1 Цикл
		|	Таблица1.Колонки(А).ЗаголовокКолонки.Значение = ""Кол"" + А;
		|КонецЦикла;
		|ЗаголовокСтроки1 = Таблица1.Строки(0).ЗаголовокСтроки;
		|ЗаголовокСтроки1.Значение = ""Стр1"";
		|";
	ИначеЕсли (КлассАнгл  = "ProgressBar") Тогда 
		СтрКода0 = "" + КлассРус + "1 = Ф.Индикатор(Ложь);";
	ИначеЕсли (КлассАнгл  = "DataGridTextBox") Тогда //ПолеВводаКолонки(DataGridTextBox)
		СтрКода0 = "СтильКолонки1 = Ф.СтильКолонкиПолеВвода();
		|" + КлассРус + "1 = СтильКолонки1.ПолеВвода;";
	ИначеЕсли (КлассАнгл  = "NotifyIcon") Тогда
		ФормаNotifyIcon = Ф.Форма();
		ФормаNotifyIcon.Текст = "Тест NotifyIcon";
		ФормаNotifyIcon.Отображать = Истина;
		ФормаNotifyIcon.Показать();
		СтрКода0 = "КонтекстноеМеню1 = Ф.КонтекстноеМеню();" + Символы.ПС;
		СтрКода0 = СтрКода0 + "" + КлассРус + "1 = Ф.ЗначокУведомления();";//ЗначокУведомления(<Меню>)
	ИначеЕсли (КлассАнгл = "ComboBoxObjectCollection") Тогда // нет конструктора ЭлементыПоляВыбора (ComboBoxObjectCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.ПолеВыбора().Элементы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ControlCollection") Тогда // нет конструктора ЭлементыУправления(ControlCollection)
		СтрКода0 = "" + КлассРус + "1 = Форма1.ЭлементыУправления;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ContextMenu") Тогда // КонтекстноеМеню(ContextMenu)
		СтрКода0 = "
		|КонтекстноеМеню1 = Ф.КонтекстноеМеню();
		|ЭлементМеню1 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Первый элемент меню""));
		|ЭлементМеню2 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Второй элемент меню""));
		|ЭлементМеню3 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Третий элемент меню""));
		|Надпись1 = Форма1.ЭлементыУправления.Добавить(Ф.Надпись());
		|Надпись1.Текст = ""Надпись с контекстным меню"";
		|Надпись1.Лево = 10;
		|Надпись1.Верх = 10;
		|Надпись1.Ширина = 200;
		|Надпись1.Высота = 100;
		|Надпись1.СтильГраницы = Ф.СтильГраницы.Трехмерная;
		|Надпись1.КонтекстноеМеню = КонтекстноеМеню1;
		|
		|";
	ИначеЕсли (КлассАнгл = "GridColumnStylesCollection") Тогда // СтилиКолонкиСеткиДанных (GridColumnStylesCollection)
		СтрКода0 = "
		|СтильТаблицыСеткиДанных1 = Ф.СтильТаблицыСеткиДанных();
		|СтилиКолонкиСеткиДанных1 = СтильТаблицыСеткиДанных1.СтилиКолонкиСеткиДанных;
		|";
	ИначеЕсли (КлассАнгл = "DataGridViewColumnHeaderCell") Тогда // ЗаголовокКолонки (DataGridViewColumnHeaderCell)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.КоличествоКолонок = 10;
		|Таблица1.КоличествоСтрок = 2;
		|
		|Для А = 0 По Таблица1.Колонки.Количество - 1 Цикл
		|	Таблица1.Колонки(А).ЗаголовокКолонки.Значение = ""Кол"" + А;
		|КонецЦикла;
		|ЗаголовокКолонки1 = Таблица1.Колонки(0).ЗаголовокКолонки;
		|ЗаголовокКолонки1.Значение = ""Первая"";
		|";
	ИначеЕсли (КлассАнгл = "ComboBox") Тогда
		СтрКода0 = "
		|ПолеВыбора1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеВыбора());
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|
		|ПолеВыбора1.ОтображениеЭлемента = ""Отображение_Элемента"";
		|ПолеВыбора1.ЗначениеЭлемента  = ""Значение_элемента"";
		|ПолеВыбора1.ИсточникДанных = ТаблицаДанных1;  
		|
		|ПолеВыбора1.ИндексВыбранного = 0;
		|";
	ИначеЕсли (КлассАнгл = "GridTableStylesCollection") Тогда // СтилиТаблицыСеткиДанных (GridTableStylesCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.СеткаДанных().СтилиТаблицы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ImageCollection") Тогда // Изображения (ImageCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.СписокИзображений().Изображения;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ListBoxObjectCollection") Тогда // ЭлементыПоляСписка (ListBoxObjectCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.ПолеСписка().Элементы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ListViewItemCollection") Тогда // ЭлементыСпискаЭлементов (ListViewItemCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.СписокЭлементов().Элементы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "MenuItemCollection") Тогда // ЭлементыМеню (MenuItemCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.КонтекстноеМеню().ЭлементыМеню;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ToolBarButtonCollection") Тогда // КнопкиПанелиИнструментов (ToolBarButtonCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.ПанельИнструментов().Кнопки;";//нет конструктора
	ИначеЕсли (КлассАнгл = "TreeNodeCollection") Тогда // УзлыДерева (TreeNodeCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.Дерево().Узлы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ListBoxSelectedIndexCollection") Тогда // ИндексыВыбранныхПоляСписка (ListBoxSelectedIndexCollection)
		СтрКода0 = "
		|ПолеСписка1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеСписка());
		|ПолеСписка1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|ПолеСписка1.РежимВыбора = Ф.РежимВыбора.МножественныйПростой;
		|ПолеСпискаЭлементы1 = ПолеСписка1.Элементы;
		|Для А = 1 По 10 Цикл
		|	ПолеСписка1.Элементы.Добавить(""Элемент"" + А);
		|КонецЦикла;
		|ПолеСписка1.ВыбранныйЭлемент = ПолеСпискаЭлементы1.Элемент(0);
		|ПолеСписка1.ВыбранныйЭлемент = ПолеСпискаЭлементы1.Элемент(1);
		|ПолеСписка1.ВыбранныйЭлемент = ПолеСпискаЭлементы1.Элемент(3);
		|
		|ИндексыВыбранныхПоляСписка1 = ПолеСписка1.ИндексыВыбранных;
		|";
	ИначеЕсли (КлассАнгл = "ListBoxSelectedObjectCollection") Тогда // ВыбранныеЭлементыПоляСписка (ListBoxSelectedObjectCollection)
		СтрКода0 = "
		|ПолеСписка1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеСписка());
		|ПолеСписка1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|ПолеСписка1.РежимВыбора = Ф.РежимВыбора.МножественныйПростой;
		|ПолеСпискаЭлементы1 = ПолеСписка1.Элементы;
		|Для А = 1 По 10 Цикл
		|	ПолеСписка1.Элементы.Добавить(""Элемент"" + А);
		|КонецЦикла;
		|ПолеСписка1.ВыбранныйЭлемент = ПолеСпискаЭлементы1.Элемент(0);
		|ПолеСписка1.ВыбранныйЭлемент = ПолеСпискаЭлементы1.Элемент(1);
		|ПолеСписка1.ВыбранныйЭлемент = ПолеСпискаЭлементы1.Элемент(3);
		|
		|ВыбранныеЭлементыПоляСписка1 = ПолеСписка1.ВыбранныеЭлементы;
		|";
	ИначеЕсли (КлассАнгл = "ListViewCheckedItemCollection") Тогда // ОтмеченныеЭлементыСпискаЭлементов (ListViewCheckedItemCollection)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы1 = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы1.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы1.Элемент(1).Помечен = Истина;
		|Элементы1.Элемент(3).Помечен = Истина;
		|Элементы1.Элемент(4).Помечен = Истина;
		|
		|ПомеченныеЭлементыСпискаЭлементов1 = СписокЭлементов1.ПомеченныеЭлементы;
		|";
	ИначеЕсли (КлассАнгл = "ListViewSelectedItemCollection") Тогда // ВыбранныеЭлементыСпискаЭлементов (ListViewSelectedItemCollection)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы.Элемент(1).Выбран = Истина;
		|Элементы.Элемент(3).Выбран = Истина;
		|Элементы.Элемент(4).Выбран = Истина;
		|
		|СписокЭлементов1.Фокус();
		|
		|ВыбранныеЭлементыСпискаЭлементов1 = СписокЭлементов1.ВыбранныеЭлементы;
		|";
	ИначеЕсли (КлассАнгл = "ListViewColumnHeaderCollection") Тогда // ЗаголовкиКолонокСпискаЭлементов (ListViewColumnHeaderCollection)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы.Элемент(1).Выбран = Истина;
		|Элементы.Элемент(3).Выбран = Истина;
		|Элементы.Элемент(4).Выбран = Истина;
		|
		|Колонки1 = СписокЭлементов1.Колонки;
		|";
	ИначеЕсли (КлассАнгл = "ListViewSubItemCollection") Тогда // ПодэлементыСпискаЭлементов (ListViewSubItemCollection)
		СтрКода0 = "
		|Форма1.Ширина = 400;
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|Колонки1 = СписокЭлементов1.Колонки;
		|Колонки1.Добавить(Ф.Колонка(""Имя цвета"", 200, Ф.ГоризонтальноеВыравнивание.Центр));
		|Колонки1.Добавить(Ф.Колонка(""R"", 40, 1));
		|Колонки1.Добавить(Ф.Колонка(""G"", 40, 1));
		|Колонки1.Добавить(Ф.Колонка(""B"", 40, 1));
		|	
		|Элементы = СписокЭлементов1.Элементы;
		|Элемент1 = Ф.ЭлементСпискаЭлементов(Ф.Цвет().Красный.Имя);
		|Элементы.Добавить(Элемент1);
		|ПодэлементыСпискаЭлементов1 = Элемент1.Подэлементы;
		|ПодэлементыСпискаЭлементов1.Добавить(Ф.ПодэлементСпискаЭлементов(255));
		|ПодэлементыСпискаЭлементов1.Добавить(Ф.ПодэлементСпискаЭлементов(0));
		|ПодэлементыСпискаЭлементов1.Добавить(Ф.ПодэлементСпискаЭлементов(0));
		|";
	ИначеЕсли (КлассАнгл = "StatusBarPanelCollection") Тогда // ПанелиСтрокиСостояния (StatusBarPanelCollection)
		СтрКода0 = "
		|СтрокаСостояния1 = Ф.СтрокаСостояния();
		|СтрокаСостояния1.Родитель = Форма1;
		|СтрокаСостояния1.ПоказатьПанели = Истина;
		|ПанелиСтрокиСостояния1 = СтрокаСостояния1.Панели;
		|";
	ИначеЕсли (КлассАнгл = "Form") Тогда // Форма (Form)
		СтрКода0 = "
		|Форма2 = Ф.Форма();
		|Форма2.Отображать = Истина;
		|Форма2.Показать();
		|Форма1.Родитель = Форма2;
		|Форма1.Владелец = Форма2;
		|		
		|Кнопка1 = Форма1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|Форма1.АктивныйЭлемент = Кнопка1;
		|Форма1.КнопкаОтмена = Кнопка1;
		|Форма1.КнопкаПринять = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "TreeView") Тогда // Дерево (TreeView)
		СтрКода0 = "
		|Дерево1 = Форма1.ЭлементыУправления.Добавить(Ф.Дерево());
		|Узел1 = Дерево1.Узлы.Добавить(""Узел1"");
		|Дерево1.ВыбранныйУзел = Узел1;
		|";
	ИначеЕсли (КлассАнгл = "UserControl") Тогда // ПользовательскийЭлементУправления (UserControl)
		СтрКода0 = "
		|ПользовательскийЭлементУправления1 = Ф.ПользовательскийЭлементУправления();
		|ПользовательскийЭлементУправления1.Значение = Ф.Цвет().Синий;
		|Кнопка1 = ПользовательскийЭлементУправления1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|ПользовательскийЭлементУправления1.АктивныйЭлемент = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "NumericUpDown") Тогда // РегуляторВверхВниз (NumericUpDown)
		СтрКода0 = "
		|РегуляторВверхВниз1 = Ф.РегуляторВверхВниз();
		|Кнопка1 = РегуляторВверхВниз1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|РегуляторВверхВниз1.АктивныйЭлемент = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "ListBox") Тогда // ПолеСписка(ListBox)
		СтрКода0 = "
		|ПолеСписка1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеСписка());
		|ПолеСписка1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|ПолеСписка1.РежимВыбора = Ф.РежимВыбора.МножественныйПростой;
		|
		|ТаблицаДанных4 = Ф.ТаблицаДанных();
		|ТаблицаДанных4.ИмяТаблицы = ""ТД4"";
		|Колонка7 = ТаблицаДанных4.Колонки.Добавить(Ф.КолонкаДанных(""Как Отобразить Элемент"", Ф.ТипДанных.Строка));
		|Колонка8 = ТаблицаДанных4.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Объект));
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(""Как Отобразить Элемент"", ""Строка1 (Строка)"");
		|ТекСтрока.УстановитьЭлемент(""Значение_элемента"", ""Значение строки 1 в список"");
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2 (Булево)"");
		|ТекСтрока.УстановитьЭлемент(1, Истина);
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка3 (Объект)"");
		|ТекСтрока.УстановитьЭлемент(1, Форма1);
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка4 (Дата)"");
		|ТекСтрока.УстановитьЭлемент(1, (Дата(2019,01,02,03)));
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка5 (Число)"");
		|ТекСтрока.УстановитьЭлемент(1, 156.54888);
		|ПолеСписка1.ОтображениеЭлемента = ""Как Отобразить Элемент"";
		|ПолеСписка1.ЗначениеЭлемента = ""Значение_элемента"";
		|ПолеСписка1.ИсточникДанных = ТаблицаДанных4;
		|
		|ПолеСписка1.УстановитьВыбор(0, Ложь);
		|ПолеСписка1.УстановитьВыбор(2, Истина);
		|";
	ИначеЕсли (КлассАнгл = "DataGrid") Тогда // СеткаДанных(DataGrid)
		СтрКода0 = "
		|СеткаДанных1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаДанных());
		|СеткаДанных1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаДанных1.ОтображатьЗаголовок = Истина;
		|СеткаДанных1.ТекстЗаголовка = ""Сетка данных333333"";
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|СеткаДанных1.ИсточникДанных = ТаблицаДанных1;
		|";
	ИначеЕсли (КлассАнгл = "PropertyGrid") Тогда // СеткаСвойств(PropertyGrid)
		СтрКода0 = "
		|СеткаСвойств1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаСвойств());
		|СеткаСвойств1.ОтображатьПанельИнструментов = Истина;
		|СеткаСвойств1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаСвойств1.ВыбранныйОбъект = Форма1;
		|Кнопка1 = СеткаСвойств1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|СеткаСвойств1.АктивныйЭлемент = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "ListView") Тогда // СписокЭлементов(ListView)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|Колонка1 = СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы.Элемент(1).Выбран = Истина;
		|Элементы.Элемент(3).Выбран = Истина;
		|Элементы.Элемент(4).Выбран = Истина;
		|Элементы.Элемент(5).Сфокусирован = Истина;
		|СписокЭлементов1.Сортировать(Колонка1, Ф.ПорядокСортировки.ПоВозрастанию);
		|
		|СписокЭлементов1.Фокус();
		|";
	ИначеЕсли (КлассАнгл = "DataGridColumnStyle") Тогда // СтильКолонкиСеткиДанных(DataGridColumnStyle)
		СтрКода0 = "
		|СеткаДанных1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаДанных());
		|СеткаДанных1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаДанных1.ОтображатьЗаголовок = Истина;
		|СеткаДанных1.ТекстЗаголовка = ""Сетка данных333333"";
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|СеткаДанных1.ИсточникДанных = ТаблицаДанных1;
		|
		|СтильТаблицыСеткиДанных1 = Ф.СтильТаблицыСеткиДанных();
		|СтильТаблицыСеткиДанных1.ИмяОтображаемого = ""ТД1"";
		|СтилиТаблицы1 = СеткаДанных1.СтилиТаблицы;
		|СтилиТаблицы1.Добавить(СтильТаблицыСеткиДанных1);
		|СтилиКолонкиСеткиДанных1 = СтильТаблицыСеткиДанных1.СтилиКолонкиСеткиДанных;
		|СтильКолонкиСеткиДанных1 = СтилиКолонкиСеткиДанных1.Элемент(1);
		|СтильКолонкиСеткиДанных1.ТекстЗаголовка = СтильКолонкиСеткиДанных1.ТекстЗаголовка + ""55"";
		|";
	ИначеЕсли (КлассАнгл = "DataGridTableStyle") Тогда // СтильТаблицыСеткиДанных(DataGridTableStyle)
		СтрКода0 = "
		|СеткаДанных1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаДанных());
		|СеткаДанных1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаДанных1.ОтображатьЗаголовок = Истина;
		|СеткаДанных1.ТекстЗаголовка = ""Сетка данных333333"";
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|СеткаДанных1.ИсточникДанных = ТаблицаДанных1;
		|
		|СтильТаблицыСеткиДанных1 = Ф.СтильТаблицыСеткиДанных();
		|СтильТаблицыСеткиДанных1.ИмяОтображаемого = ""ТД1"";
		|СтильТаблицыСеткиДанных1.СеткаДанных = СеткаДанных1;
		|";
	ИначеЕсли (КлассАнгл = "Bitmap") Тогда // Картинка(Bitmap)
		СтрКода0 = "" + Символы.ПС + 
		"СтрМасленица1 = ""/9j/4AAQSkZJRgABAQEAeAB4AAD/4QA2RXhpZgAATU0AKgAAAAgAAQEyAAIAAAAUAAAAGgAAAAAyMDE4OjA3OjE5IDA5OjQxOjQxAP/bAEMACAYGBwYFCAcHBwkJCAoMFA0MCwsMGRITDxQdGh8eHRocHCAkLi"" + Символы.ПС + "+ Символы.ПС + 
		"""cgIiwjHBwoNyksMDE0NDQfJzk9ODI8LjM0Mv/bAEMBCQkJDAsMGA0NGDIhHCEyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMv/AABEIAFAAdwMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAA"" + Символы.ПС + "+ Символы.ПС + 
		"""AAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaH"" + Символы.ПС + "+ Символы.ПС + 
		"""iImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITE"" + Символы.ПС + "+ Символы.ПС + 
		"""GEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1t"" + Символы.ПС + "+ Символы.ПС + 
		"""fY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/AJL2XUYr+CeYldgIlkTJKlTzj5gOMD8AvIxWlLrF/qWtwyQpdfangIPlqzNEAFxjjgEng7j82c4/i9AUMHjZbe1RovuOY9zjjbnPByRx+NVk1COHWYtFjISaaEzoE2opI"" + Символы.ПС + "+ Символы.ПС + 
		"""J+XA5yQGPuFNdSnZaoyb1ORTTtVuNYs7m6s7s+aZWmlmj2bzkBSc5C5BJAIUkLgeta+laRf6ReG8fyWWMqodG34/cplgvBwGBUAkHA54Oatfbml1WGCKXfEYvNEudyybyERs9fUY9T7HFjUtSTQlsd8M1w93eRWxbeRt3nBbp0Hp/8A"" + Символы.ПС + "+ Символы.ПС + 
		"""XqPaxnewpKUd0RT69dmKSGyvIJ5mDL87KCi/3gU5LcHHGDleetUp9Q8Q2Hh29kkmgs32B4pXHIZmyVVefmOWA3Zwcfht2+q2j61PpqWconih817gBRGT8oKg5zuAdevHXngiqXimyuNR8NX0Ec0ocR+YrIvLFfmCkd1OOQME+1KTTg1"" + Символы.ПС + "+ Символы.ПС + 
		"""FDjJqST6mgy64zunmBRvOfN2BQu4H5ShLZxlefcjBxWDfeGtWfWvtyPG/m+buZZW3RbjlcbiOPmbAHAwODjJ2b3WrgagLSwtzceW6efdzMI4woPzAd2YgY+UYBYHnGKuteEp8qyMcc7Bj9Wx/KhNp3sNu/Uw4bT+w9PN5q+vTxIiqJJ"" + Символы.ПС + "+ Символы.ПС + 
		"""JBBGmeAAvHUnAGSTz1rPmlu/7OstdvZ5bDDtG0d3KYcxFmyAoTliFVhkbjgdDXQvLPIwaO2VJEOUlnO8qemRjO3gkcetZV5o91eszXN1FKZBtbfbEnHcKS/H4AUKOvvOw09O5j2vhmRbxrq31N2glxhDACfL42ruz25IO0EEg84IOkl"" + Символы.ПС + "+ Символы.ПС + 
		"""qkckqfb5Hd/3ckZlDHjOARjjHP45znmlfR20nRbiOzvJ5GWF1U3LKdqkc8hewyQCCM8dOK8a8QaMmhXsSRKwgkXMeW3MpXgjIPXgHr/ABDvmpqV7S5URKE4w9qlovM9gj0pIbi5uY3KzTkM0rYLIAuCFPZepwc8knvVG90uxubqFZW8"" + Символы.ПС + "+ Символы.ПС + 
		"""+8twbhEG0lhgjkHjn2A7dKj8M6nP4g8I280t2Y7m2lMM9wx3F9g4LEnqVZCSe4JrPi0Y3mpC5tp5JpTCxjkSZ4iy5A+5GSVwCMk4PzqNi1UXdXuHNtYvXelzXV1p7LfA28byLMSuWdPm4I5DESYwfl4ZjzmimQacyX726alqOQN67nD"" + Символы.ПС + "+ Символы.ПС + 
		"""pIrc7lLBucgg5JIxjp1KJR1vcqMtNjp/GnigeFNE+2KUjdpREqiHzXfOScDcACAC2SccY6kVnawrrbt4ijntrmRtNSB5PJZGdWcmT5RynGwDOSuDu6E10eq6dFqmnzWV2qG2lZWdVH3trh8HdwQSoBGORkVzHjHxTb+DtJtbm++0XMc"" + Символы.ПС + "+ Символы.ПС + 
		"""ji3jSMjzHIQ5ZiTg9OT6tUcl73dilNRa0vqclLqd5NriGKSPzCSqbNuQwYnGzGAwzjptxzgkmu9Nq/irRbJZpprVrS8ScOjBjIyA8E55X5sc9duSOa5iK88Im1sr17cy/bbdLpY9zOyqxyd2SRkFSD7riu60+e2ktYPs0YEDIPL2nIx"" + Символы.ПС + "+ Символы.ПС + 
		"""04/LHFc+HwzpzcnJP5HRisTCcEowsc14XsJk8XeIr65aRmkkHll4wPOQvKu5sjs0Z2kYAVh2NdcbeFsZC5BznIGPxp+yPP+pXJ7nFc9rHjrw5oN69jdyyPcx8SR28O4pwCMnIGcEHGc/SuvSCOHWT2OjEAOCNhA5BJyRXJ3HjnT7P4g"" + Символы.ПС + "+ Символы.ПС + 
		"""f8ItfIsCtGnlXpmyrzMFIjK4+X73Unrj1ra03xDo2sJu0jUra7YIJCkThmAYfLlTyD0yCMjkGvHtbHgdtQ8TyXd5HeXyXMrFp2ffISS2IwODjOwEDquc7SDSlOKV2b0afO7bHtdw0VrFJNKrusYJIUc4rgNKv9Uj8TTz3b3y2RBDiWJ"" + Символы.ПС + "+ Символы.ПС + 
		"""QJm6IFGeCM5OzOcADIxUukeJR4t8Ly3VnFLbNaxj7RbuclFKHPPUgjdg9Ts5A5qvd3ttdNdaXGhTy7YyNck7VGGVTg9c/NnPtXj5hialOrBQ16nfg4LkkpLfTU6XV9cs9IsJbq+I8hPlIHzFyeigdyef1JwATXiPiLXLjXJI2Fk1pZW"" + Символы.ПС + "+ Символы.ПС + 
		"""zssW4ZYb8FQ7dN2Ez26d8Zr0HVNV0XxHol3axJJJNCBPDFd45UfKH4PXDkYP8Ae961ZLHTvtF48MSONTnV7iN/mVgFbAx6ZDN9Se2BV4vHQpSVlfS5zxwtaUXFuyZg/C9m/srVY1VtqvGVGcAkqwwPQ8D9PSt7Ur77Alva77pftdxGj"" + Символы.ПС + "+ Символы.ПС + 
		"""lUKqz8ZC84UEL931wflIJqHwtYW2i3OrLbBVhe5URxsc7AI1JwT2y/TtitPVLSS+NhLDs/0W5+0bWyFYiN1UZGe7g/hXdRqKdNTWzOdUnT9x7odAIbq6uJVeby2kPl+YNrHlssMY4JPfnAHXAwVWYa1JGN624O7kW0r5I9egP4e/tRW"" + Символы.ПС + "+ Символы.ПС + 
		"""/Lf7RLbXQ7Qr5jFjgL/vYrk/EHhqw8V6nbLqlvHc2NmXKBXlYru+98sYBJOxRy2B+VbuySUt5mwHGOgz+ladqIHtWn8qOKRpCG2gDZhsAcj0x9cn1p1LJWJg23c8T8R6JDouv6RpmmNJHazSGztUkcuYyZCcEjrgz+/3evGa9a0m1sb"" + Символы.ПС + "+ Символы.ПС + 
		"""DTLa188jyIhEoJIJA4yfc4zWZcSRJqYVLOJoZZliZimTEzBiGT0baCMj1HtnajhjRAFic4GP85FUoRjJtdbEOrKcUnsrjdS1CeHT5f7MsVvrgL8kLTCJWPpuIPb/PevJYW0nS9d1A+KJP7O1a8uZLuO1U+cyJJt2qWjX74yxC5BIK5H"" + Символы.ПС + "+ Символы.ПС + 
		"""Y+ry3E0WAkDDc2AT834YFeba94M1651i8vFh8uPzJHjuGuYlB3sWXd95gRu28D8cc1nVjG1m7F0qkk7xVy58PddhX7dbWHh+6ht59Smu1kzyuSGQMCBt+QBQATjr0YtXNRfDjV08Qx2MLwy25lRDcSMuVjALfMmQ27aOi5B9epHfKjW"" + Символы.ПС + "+ Символы.ПС + 
		"""cs0FvHFCluFURwSMqIdq7gOvBYscHJ+brVVLm5g1S3aHZ5speOJBu5Yxtlh0JOO/wBPavEeMqVMSqKSsnY9ihGVGnKae61LWgNpGk3l9pSQ6ek1xJGqizkL/aE5ALDHy43MSmTtBJBwQTi6jfx6FDevPZLexWCkB9oInXgIGb0zt3Af"" + Символы.ПС + "+ Символы.ПС + 
		"""3T14rGvdLtfCej2WqIZ723uZUkVlkEfKszkmTByr/KRtC7gobjv3UPhjS5rOOV472GArlrSe6by1X0YHnHsT04PpWlfDJuKh9l+ZUJct5y+F7eZ5r4M/sm4+1fZLX7B5c8UswlmaUyAb9qrhQdvJJBOSdpzxXU3d5aFDfFpGS3ILOqr"" + Символы.ПС + "+ Символы.ПС + 
		"""FApPyjOR74+YnrXUW+i6NJIDBpdtHDGAiKkexHJJJOwcHHPJGeawPiiPK8C3agAebNDGOMcbwcf8Ajpoq4WdWTc5tLsR7aDmlCPUzNF13T7jXTZ2t0LmV4mlmI+6HBH3W/iBDAf8AAM4GWqPxbqGpaRf2WuaZDcXLRq6TW5djA0fA4A"" + Символы.ПС + "+ Символы.ПС + 
		"""6OSc5z/CeOMV5lpFydL1W0vxkeRKC+OMoeG/8AHSa94uUSKLcPOZuiIhbLt2A54zjqcAdyK7sKkqSpp7GeNpexqJ23I9F1ZNXUzxwXcCYUqJsgtlQW/wC+WLL6HbkE0Uy0ivvtDPLHb2satg+bOzOcg46cL+Jzx06UVu4pdTi5vI6F7"" + Символы.ПС + "+ Символы.ПС + 
		"""yRVJVSX3BVRTt3EnAHAzyTWsulrtL3MjyyuBuwSqgjoAB6epJNYnkypcxzmGTYkyOTtPIVw3FdaskMsAZZFZGGVYHII7EVvW921jnpq+5w+sWclpqWl21uw+zyX6SnceVIVyee+cd66pXiXGZWJx6GuX8VXsX9saV8xWC2ulkmk2kgH"" + Символы.ПС + "+ Символы.ПС + 
		"""a2AcDgk4xWrBrWlXm2MXMLyP8uGXDEnjHQc0OMmrtCi0nZMvRfv7mWVG4DBBkZwu0nj6k8//AFqZcFfLeO5thLC6lX2DcGU9QUPUY7c5qKzv7K3nmtjKFYSgcqQoyikKWxgHByBnPNW3ZCxj3rnnGT1A/wAK4K/uzvbQ7aKfJvqcNqH"" + Символы.ПС + "+ Символы.ПС + 
		"""g68nkB8Pa8AFG0214Szxr2UPjzdo/usTj17VV0zwBqv24y6zqcDRYIkhsldXlB/haZjvCE9VHB9q7m6s47hQJEDY6E4OPoe34VQe2nDLHDfXQTnzCJi2BjsWyQfoaI1IvVP8AD9S3KaVmgvNQgsVW1gg+0XCAKltbqFVABwCeiADHHX"" + Символы.ПС + "+ Символы.ПС + 
		"""HQVDHFdXCia/YZzlYYwQiH056n3P6U63tpbZRAgiZVJD4TDbu/1yefXnv1rK1zxHDZ2bLG5MrEqioSrvglTg/wLkEFupAO3JII0haT5aa1Iaduab0JX8RWFpqMtlJeWUdxHLh4HuFRwSo28EjOVKnjPPFcV8Ttbg1HSNNsoJY2kN2ZJ"" + Символы.ПС + "+ Символы.ПС + 
		"""I0lV/uoQDx7uRXnF9dNqV7dXUqqJLiYu6quAvzdMf45PqTSpGsSRSBQOWzge5xXNUq6ONj28LlvLONTm87EOMnYRkMMHn616tYeIIJtA00rcs1/cww20gkz5aEsI+e3Lr1HPOMgdPKCfmBB/wA5r0H4e3NmLZvtMayXFtdLFbswyIfM"" + Символы.ПС + "+ Символы.ПС + 
		"""DFDj3dWGRyMj1ows7SaZWb0r0lNdH+Z0F1IujQRWbFdXugXYWxQFpoyxOTkn5wTknvgnAopbK8hlNveawAW2Zt5DcbAq44IfIO5wSexOx8jjFFejdLRo+cWp6Zqc9zDayi3hjL7SE8xsAntwOfr09q4LWI/GF/cS3Vtv02I4QWlk8bc"" + Символы.ПС + "+ Символы.ПС + 
		"""ckvuYHLc4JAXtweo7xY4A7sCwLHJ6VIZYgMKUH1ohWUNUrilSctzy200PxmmkTaWbu5+y3beZKZ5Y2OeO/wB8Z2jgHirMXgy/gMa/b0REXIWMb8t6cgHGe+a9ELoxz56fQVBI8S9WjOTgZ3cn860+uS6JIXsF1PNPEdlc6XYrPLcs11"" + Символы.ПС + "+ Символы.ПС + 
		"""JKgWdHYOAFb5c8HHTjkHHNQ2nie+hhJyHl3bt8hLAZPXHUHryCOuTk113ijS/7bsFt4p4IpEcOrOhI9wcEHv8A56jkbXwDdwTrJJ4gSbDbiptSN3ryHz3P9c81NGUZTlKrs7WLmpKEVTequbv/AAnES7Rc29wHJAYpAjKvTPJZScc9F"" + Символы.ПС + "+ Символы.ПС + 
		"""HTvWoPF+kfZkl+1QspIV9rgFMjuv3l/EY9+9Z8nh2ye4c7IltSd0cMUZVkOACN/Vhx0OcZ4xWPq/hqzt9Pubm3e4DIAVSTBAyQPTPAJ/L8ayrRw6g5R3SLpTquajJaFjVvHMJuzHZ3MPmMQixRzJIePvF3TcA3QBVbOOSecLgeRNfXE"" + Символы.ПС + "+ Символы.ПС + 
		"""txLMqxomWaPbiNQvChSRj5eOnXn1NXfDvhe1ubFLyd5Nt0z+dsA3fK7qAN3GMAV0dr4Us7OF4v7Qnmt34aHy4yrL3ByTn0rajUpU6acN2jOqpznaWyZj6h4V0qeDyhDbBVVII5TBl1iVCQ5IIOSePUjaayZPA+lOZCsVwgZjGi/aWby"" + Символы.ПС + "+ Символы.ПС + 
		"""iBu3j5eQcgY6/0TxUtv4cWCPQrG7dizeYiST26pjoQqMA+cnkfnzXGpqmukgLqV5tBDCOEM2zncoDHLYBORkn8a8KeBqQ2l+Z7NLGReibR2MvgTToY7sLBJIVXbGHuGLbuTlcKA3UcEfwn1OGXelW+kWZfTwI1O1Z0tweVJJ5YsWPKo"" + Символы.ПС + "+ Символы.ПС + 
		"""TyPlcdQxzW0qx1+70ZLpdQm3SFh5Utz5L4VmUYzgqMEnjbnceua0bfw/qUsaPeajkoMJFLdNchOMcBiQDgkccgE104bA1ITjUlPRephicbGcXT1dyhq+orqumRrYyx/aLRjJCqn95tO1GU/wC1kk8AcLkcNRVWfQNRhnRlBmKjassFz"" + Символы.ПС + "+ Символы.ПС + 
		"""iVR1xhsZH698dyV67cY6JnlKLP/2Q=="";"+ Символы.ПС + 
		"Картинка1 = Ф.Картинка(СтрМасленица1);" + Символы.ПС;
		
	Иначе
		СтрКода0 = "" + КлассРус + "1 = Ф." + КлассРус + "();";
	КонецЕсли;
	Возврат Истина;
КонецФункции//ПолучитьОбъектДляСвойств

Процедура ТестированиеСвойств();
	// Если конструктора нет, то получаем методом или свойством другого объекта
	// Тестируем свойства, методы, перечисления.
	// Список классов берем из файла OneScriptForms.html
	// Свойства - из файла OneScriptForms....(Класс).....Members.html
	// Методы - из файла OneScriptForms....(Класс).....Members.html
	// Перечисления - из файла OneScriptForms.html
	
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(КаталогСправки + "\OneScriptFormsru\OneScriptForms.html");
	Стр12 = ТекстДок.ПолучитьТекст();
	Массив1 = СтрНайтиМежду(Стр12, "<H3 class=dtH3>Классы</H3>", "</TBODY></TABLE>", Ложь, );
	Массив2 = СтрНайтиМежду(Массив1[0], "Описание</TH></TR>", "</TBODY></TABLE>", Ложь, );
	Массив3 = СтрНайтиМежду(Массив2[0], "<TR vAlign=top>", "</TD></TR>", Ложь, );
	Для А1 = 0 По Массив3.ВГраница() Цикл
		Массив4 = СтрНайтиМежду(Массив3[А1], ".html"">", "</A></TD>", Ложь, );
		Для А = 0 По Массив4.ВГраница() Цикл
			ТекстТеста = 
			"ПодключитьВнешнююКомпоненту(""" + КаталогБиблиотеки + "\OneScriptForms.dll"");
			|Ф = Новый ФормыДляОдноСкрипта();
			|Форма1 = Ф.Форма();
			|Форма1.Отображать = Истина;
			|Форма1.Показать();
			|";
			
			СтрХ = Массив4[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			КлассАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			
			// не создаем файл для теста, если у класса нет наследуемых свойств, или свойств нет совсем.
			Если (КлассАнгл = "BitmapData") или
				(КлассАнгл = "Brush") или 
				(КлассАнгл = "EventArgs") Тогда
				Продолжить;
			КонецЕсли;
			
			КлассРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			//находим свойства класса из файла OneScriptForms....(Класс).....Members.html
			ИмяФайлаЧленов = КаталогСправки + "\OneScriptFormsru\OneScriptForms." + КлассАнгл + "Members.html";
			
			Сообщить(" (" + Ф.Математика().Окр(((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60, 2) + " мин." + " " + А1 + " из " + Массив3.ВГраница() + ") " + 
			КлассРус + " (" + КлассАнгл + ")");
			
			Если Не ПолучитьОбъектДляСвойств(КлассРус, КлассАнгл) Тогда
				Продолжить;
			КонецЕсли;
			
			ТекстТеста = ТекстТеста + "
			|" + СтрКода0 + "
			|";
			
			ТекстТеста = ТекстТеста + "
			|НекорректныеСвойства = Новый СписокЗначений;
			|";
			
			М_СвойстваТест = СвойстваТест(ИмяФайлаЧленов, КлассРус, КлассАнгл);
			// не создаем файл для теста, если у класса нет наследуемых свойств, или свойств нет совсем.
			Если М_СвойстваТест.Количество() = 0 Тогда
				// Сообщить("Нет наследуемых свойств у класса " + КлассРус + " (" + КлассАнгл + ")");
				Продолжить;
			КонецЕсли;
			
			ТекстТеста = ТекстТеста + "
			|Если НекорректныеСвойства.Количество() > 0 Тогда
			|	Сообщить(""---Не прошли тест свойства:---"");
			|КонецЕсли;
			|Для А = 0 По НекорректныеСвойства.Количество() - 1 Цикл
			|	Сообщить("""" + НекорректныеСвойства.Получить(А).Значение);
			|КонецЦикла;
			|Сообщить(""Тест завершен."");
			|Сообщить(""==============================================="");
			|";
			
			// подправляем код тестируемого класса
			Если КлассРус = "ЭлементМеню" Тогда
				ПодстрокаПоиска = "Сообщить(""ЭлементМеню1.Родитель = "" + ЭлементМеню1.Родитель + "" (Тип: "" + ЭлементМеню1.Родитель.Тип.ВСтроку() + "" ("" + ЭлементМеню1.Родитель.Type.ВСтроку() + "").)(Только чтение.)"");";
				ПодстрокаЗамены = "
				|	ГлавноеМеню1 = Ф.ГлавноеМеню();
				|	ГлавноеМеню1.ЭлементыМеню.Добавить(ЭлементМеню1);
				|	Сообщить(""ЭлементМеню1.Родитель = "" + ЭлементМеню1.Родитель + "" (Тип: "" + ЭлементМеню1.Родитель.Тип.ВСтроку() + "" ("" + ЭлементМеню1.Родитель.Type.ВСтроку() + "").)(Только чтение.)"");";
				ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			КонецЕсли;
			Если КлассРус = "УзелДерева" Тогда
				ПодстрокаПоиска = "Сообщить(""УзелДерева1.Дерево = "" + УзелДерева1.Дерево + "" (Тип: "" + УзелДерева1.Дерево.Тип.ВСтроку() + "" ("" + УзелДерева1.Дерево.Type.ВСтроку() + "").)(Только чтение.)"");";
				ПодстрокаЗамены = "
				|	Дерево = Ф.Дерево();
				|	Дерево.Узлы.Добавить(УзелДерева1);
				|	Сообщить(""УзелДерева1.Дерево = "" + УзелДерева1.Дерево + "" (Тип: "" + УзелДерева1.Дерево.Тип.ВСтроку() + "" ("" + УзелДерева1.Дерево.Type.ВСтроку() + "").)(Только чтение.)"");";
				ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			КонецЕсли;
			Если КлассРус = "КнопкаПанелиИнструментов" Тогда
				ПодстрокаПоиска = "КнопкаПанелиИнструментов1.ВыпадающееМеню = КнопкаПанелиИнструментов1.ВыпадающееМеню;";
				ПодстрокаЗамены = "Меню20 = Ф.КонтекстноеМеню();
				|	Меню21 = Меню20.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""1 действие""));
				|	КнопкаПанелиИнструментов1.Стиль = Ф.СтильКнопокПанелиИнструментов.КнопкаВыпадающегоСписка;
				|	КнопкаПанелиИнструментов1.ВыпадающееМеню = Меню20;
				|	КнопкаПанелиИнструментов1.ВыпадающееМеню = КнопкаПанелиИнструментов1.ВыпадающееМеню;";
				ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			КонецЕсли;
			Если КлассРус = "ПолеСписка" Тогда
				ПодстрокаПоиска = "ПолеСписка1.ИсточникДанных = ПолеСписка1.ИсточникДанных;";
				ПодстрокаЗамены = "// ПолеСписка1.ИсточникДанных = ПолеСписка1.ИсточникДанных;";
				ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			КонецЕсли;
			Если КлассРус = "СписокЭлементов" Тогда
				ПодстрокаПоиска = "Попытка
				|	СписокЭлементов1.ИндексыВыбранных = СписокЭлементов1.ИндексыВыбранных;
				|	
				|	Сообщить(""СписокЭлементов1.ИндексыВыбранных = "" + СписокЭлементов1.ИндексыВыбранных + "" (Тип: "" + СписокЭлементов1.ИндексыВыбранных.Тип.ВСтроку() + "" ("" + СписокЭлементов1.ИндексыВыбранных.Type.ВСтроку() + "").)(Чтение и запись.)"");
				|
				|Исключение
				|	НекорректныеСвойства.Добавить(""ИндексыВыбранных (SelectedIndices)""); КонецПопытки;";
				ПодстрокаЗамены = "// свойство СписокЭлементов.ИндексыВыбранных (ListView.SelectedIndices) в разработке";
				ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			КонецЕсли;
			// закончили подправлять код тестируемого класса
			
			ТекстТеста = ТекстТеста + "
			|Форма1.Текст = ""Тест " + КлассРус + "(" + КлассАнгл + ")"";
			|Ф.ЗапуститьОбработкуСобытий();
			|";
			
			ПодстрокаПоиска = "Сообщить(""Тест завершен."");
			|Сообщить(""==============================================="");";
			ПодстрокаЗамены = "Сообщить(""Тест завершен."");
			|Сообщить(""==============================================="");
			|Форма1.Закрыть();
			|";
			ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			
			ПодстрокаПоиска = "Форма1 = Ф.Форма();";
			ПодстрокаЗамены = 
			"Форма1 = Ф.Форма();
			|Форма1.СостояниеОкна = Ф.СостояниеОкнаФормы.Свернутое;";
			ТекстТеста = СтрЗаменить(ТекстТеста, ПодстрокаПоиска, ПодстрокаЗамены);
			
			Если 
				КлассРус = "ДеревоОтменаАрг" или 
				КлассРус = "ЯчейкаОтменаАрг" или 
				КлассРус = "ЯчейкаТаблицыМышьАрг" или 
				КлассРус = "ПереименованиеАрг" Тогда
			Иначе
				ТекстДокХХХ = Новый ТекстовыйДокумент;
				
				// // // ИмяВременногоФайла = "C:\Users\master\AppData\Local\Temp\" + КлассРус + "-свойство.tmp";
				// // // ТекстДокХХХ.Записать(ИмяВременногоФайла);
				
				ТекстДокХХХ.УстановитьТекст(ТекстТеста);
				ТекстДокХХХ.Записать(ИмяВременногоФайла, "UTF-8");
				Команда3("""C:\Program Files\OneScript\bin\oscript.exe""", ИмяВременногоФайла, ПолеВвода1, КлассРус + " (" + КлассАнгл + ")");
			КонецЕсли;
			Форма1.Фокус();
		КонецЦикла;
	КонецЦикла;
		
	//находим Перечисления из файла OneScriptForms.html
	ПеречисленияТест();
	
	Сообщить("Выполнено за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60 + " мин.");
КонецПроцедуры//ТестированиеСвойств

Процедура ТестированиеКодов()
	ВыбранныеФайлы = НайтиФайлы(КаталогСправки + "\OneScriptFormsru", "*.html", Истина);
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		Сообщить(" (" + Ф.Математика().Окр(((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60, 2) + " мин." + " " + А + " из " + ВыбранныеФайлы.ВГраница() + ") " + 
			ВыбранныеФайлы[А].ПолноеИмя);
		Если (ВыбранныеФайлы[А].ПолноеИмя = КаталогСправки + "\OneScriptFormsru\SaveFileDialog.Reset.html") Тогда
			Продолжить;
		КонецЕсли;
		
		// // // Если ВыбранныеФайлы[А].Имя = "OneScriptForms.DataGridViewButtonColumn.DefaultCellStyle.html" Тогда 
		// // // ИначеЕсли ВыбранныеФайлы[А].Имя = "OneScriptForms.DataGridViewCell.Style.html" Тогда  
		// // // ИначеЕсли ВыбранныеФайлы[А].Имя = "OneScriptForms.DataGridViewColumn.DefaultCellStyle.html" Тогда 
		// // // ИначеЕсли ВыбранныеФайлы[А].Имя = "OneScriptForms.DataGridViewImageColumn.DefaultCellStyle.html" Тогда 
		// // // Иначе
			// // // Продолжить;
		// // // КонецЕсли;

		ТекстДок = Новый ТекстовыйДокумент;
		ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
		Стр = ТекстДок.ПолучитьТекст();
		М = СтрНайтиМежду(Стр, "<details><summary>Тестовый код</summary>", "</PRE>", Ложь, );
		Если М.Количество() > 0 Тогда
			Для А2 = 0 По М.Количество() - 1 Цикл
				ТестовыйКод0 = СтрНайтиМежду(М[А2], "<DIV id=""cont", "</DIV>", Ложь, )[0];
				ТестовыйКод = СтрНайтиМежду(ТестовыйКод0, """>", "</DIV>", , )[0];
				Если Не (СокрЛП(ТестовыйКод) = "") Тогда
					ТекстДокХХХ = Новый ТекстовыйДокумент;
					
					// // // ИмяВременногоФайла = "C:\Users\master\AppData\Local\Temp\" + СтрЗаменить(ВыбранныеФайлы[А].Имя, ".html", "") + "-код.tmp";
					// // // ТекстДокХХХ.Записать(ИмяВременногоФайла);
					
					ТекстДокХХХ.Прочитать(ИмяВременногоФайла);
					ТекстДокХХХ.УстановитьТекст(ТестовыйКод);
					ТекстДокХХХ.Записать(ИмяВременногоФайла);
					Команда1("""C:\Program Files\OneScript\bin\oscript.exe""", ИмяВременногоФайла, ПолеВвода1, ВыбранныеФайлы[А].Имя);
					Форма1.Фокус();
				КонецЕсли;
			КонецЦикла;
		КонецЕсли;
	КонецЦикла;
КонецПроцедуры//ТестированиеКодов

Функция Команда1(ИмяФайла, Аргументы, Объект, ИмяФайлаСправки)
	ИнформацияЗапускаПроцесса1 = Ф.ИнформацияЗапускаПроцесса();
	ИнформацияЗапускаПроцесса1.ИмяФайла = ИмяФайла;
	ИнформацияЗапускаПроцесса1.Аргументы = Аргументы;
	ИнформацияЗапускаПроцесса1.СоздатьБезОкна = Истина;
	ИнформацияЗапускаПроцесса1.ИспользоватьОболочку = Ложь;
	ИнформацияЗапускаПроцесса1.СтильОкна = Ф.СтильОкнаПроцесса.Скрытое;
	ИнформацияЗапускаПроцесса1.ПеренаправитьСтандартныйВывод = Истина;

	Процесс1 = Ф.Процесс();
	Процесс1.НачальнаяИнформация = ИнформацияЗапускаПроцесса1;
	Процесс1.Начать();
	Если Не Процесс1.Завершен Тогда
		Стр1 = Процесс1.СтандартныйВывод.ПрочитатьСтроку();
		Пока Стр1 <> Неопределено Цикл
			Стр3 = "" + Стр1;
			Двоеточие = Прав(Стр3, 3);
			Двоеточие = Лев(Двоеточие, 1);
			Если (СтрНайти(Стр3, "!!!") > 0) или (СтрНайти(Стр3, "{") > 0)  или (Двоеточие <> ":") Тогда
				СписокОшибок.Добавить(Стр3 + "  " + ИмяФайлаСправки);
			КонецЕсли;
			Объект.ДобавитьТекст(Стр3 + "  " + ИмяФайлаСправки + Символы.ПС);
			Стр1 = Процесс1.СтандартныйВывод.ПрочитатьСтроку();
		КонецЦикла;
	Иначе
		Объект.ДобавитьТекст("Процесс1 завершен");
	КонецЕсли;
КонецФункции

Функция Команда2(ИмяФайла, Аргументы, Объект, КлассОшибки)
	ИнформацияЗапускаПроцесса1 = Ф.ИнформацияЗапускаПроцесса();
	ИнформацияЗапускаПроцесса1.ИмяФайла = ИмяФайла;
	ИнформацияЗапускаПроцесса1.Аргументы = Аргументы;
	ИнформацияЗапускаПроцесса1.СоздатьБезОкна = Истина;
	ИнформацияЗапускаПроцесса1.ИспользоватьОболочку = Ложь;
	ИнформацияЗапускаПроцесса1.СтильОкна = Ф.СтильОкнаПроцесса.Скрытое;
	ИнформацияЗапускаПроцесса1.ПеренаправитьСтандартныйВывод = Истина;
	
	Процесс1 = Ф.Процесс();
	Процесс1.НачальнаяИнформация = ИнформацияЗапускаПроцесса1;
	Процесс1.Начать();
	ВыводитьСтроки = Ложь;
	Если Не Процесс1.Завершен Тогда
		Стр1 = Процесс1.СтандартныйВывод.ПрочитатьСтроку();
		Если Стр1 = "---Не прошли тест методы:---" Тогда
			ВыводитьСтроки = Истина;
		КонецЕсли;
		Если ВыводитьСтроки Тогда
			Сообщить("" + Стр1);
		КонецЕсли;
		
		Пока Стр1 <> Неопределено Цикл
			Если Стр1 <> "Тест завершен." Тогда
				ДваПоследнихСимвола = Прав(Стр1, 2);
				ПервыйСимвол = Лев(Стр1, 1);
				Если ПервыйСимвол = "{" Тогда
					СписокОшибок.Добавить(Стр1 + "  " + КлассОшибки);
				ИначеЕсли Не (ДваПоследнихСимвола = ";;") и (  (Не (ДваПоследнихСимвола = "=="))  и  (Не (ДваПоследнихСимвола = "--"))  ) Тогда
					СписокОшибок.Добавить("" + КлассОшибки + " - метод - " + Стр1);
				КонецЕсли;
				Объект.ДобавитьТекст("" + Стр1 + Символы.ПС);
			КонецЕсли;
			Стр1 = Процесс1.СтандартныйВывод.ПрочитатьСтроку();
			
			Если Стр1 = "---Не прошли тест методы:---" Тогда
				ВыводитьСтроки = Истина;
			КонецЕсли;
			Если ВыводитьСтроки Тогда
				Если Стр1 <> "Тест завершен." Тогда
					Сообщить("" + Стр1);
				КонецЕсли;
			КонецЕсли;
		КонецЦикла;
	Иначе
		Объект.ДобавитьТекст("Процесс1 завершен");
	КонецЕсли;
КонецФункции

Функция Команда3(ИмяФайла, Аргументы, Объект, КлассОшибки)
	ИнформацияЗапускаПроцесса1 = Ф.ИнформацияЗапускаПроцесса();
	ИнформацияЗапускаПроцесса1.ИмяФайла = ИмяФайла;
	ИнформацияЗапускаПроцесса1.Аргументы = Аргументы;
	ИнформацияЗапускаПроцесса1.СоздатьБезОкна = Истина;
	ИнформацияЗапускаПроцесса1.ИспользоватьОболочку = Ложь;
	ИнформацияЗапускаПроцесса1.СтильОкна = Ф.СтильОкнаПроцесса.Скрытое;
	ИнформацияЗапускаПроцесса1.ПеренаправитьСтандартныйВывод = Истина;

	Процесс1 = Ф.Процесс();
	Процесс1.НачальнаяИнформация = ИнформацияЗапускаПроцесса1;
	Процесс1.Начать();
	ВыводитьСтроки = Ложь;
	Если Не Процесс1.Завершен Тогда
		Стр1 = Процесс1.СтандартныйВывод.ПрочитатьСтроку();
		Если Стр1 = "---Не прошли тест свойства:---" Тогда
			ВыводитьСтроки = Истина;
		КонецЕсли;
		Если ВыводитьСтроки Тогда
			Сообщить("" + Стр1);
		КонецЕсли;
		
		Пока Стр1 <> Неопределено Цикл
			Если Стр1 <> "Тест завершен." Тогда
				ДваПоследнихСимвола = Прав(Стр1, 2);
				ПервыйСимвол = Лев(Стр1, 1);
				Если ПервыйСимвол = "{" Тогда
					СписокОшибок.Добавить(Стр1);
				ИначеЕсли Не (ДваПоследнихСимвола = ".)") и (  (Не (ДваПоследнихСимвола = "=="))  и  (Не (ДваПоследнихСимвола = "--"))  ) Тогда
					СписокОшибок.Добавить("" + КлассОшибки + " - свойство - " + Стр1);
				КонецЕсли;
				Объект.ДобавитьТекст("" + Стр1 + Символы.ПС);
			КонецЕсли;
			Стр1 = Процесс1.СтандартныйВывод.ПрочитатьСтроку();
			
			Если Стр1 = "---Не прошли тест свойства:---" Тогда
				ВыводитьСтроки = Истина;
			КонецЕсли;
			Если ВыводитьСтроки Тогда
				Если Стр1 <> "Тест завершен." Тогда
					Сообщить("" + Стр1);
				КонецЕсли;
			КонецЕсли;
		КонецЦикла;
	Иначе
		Объект.ДобавитьТекст("Процесс1 завершен");
	КонецЕсли;
КонецФункции

Функция ПолучитьОбъектДляМетодов(КлассРус, КлассАнгл)
	СтрСозданияОбъекта = "";
	СтрСозданияОбъекта2 = "";
	// Тестируются только те свойства или методы, которые наследуются от родителя.
	// остальные можно протестировать из тестового кода в справке
	
	Если (КлассАнгл = "FileDialog") или 
		(КлассАнгл = "ScrollBar") или 
		(КлассАнгл = "Control") или 
		(КлассАнгл = "ListControl") или 
		(КлассАнгл = "ContainerControl") или 
		(КлассАнгл = "UpDownBase") или 
		(КлассАнгл = "ScrollableControl") или 
		(КлассАнгл = "TextBoxBase") или 
		(КлассАнгл = "ButtonBase") или 
		(КлассАнгл = "CommonDialog") или 
		(КлассАнгл = "EventArgs") или 
		(КлассАнгл = "BitmapData") или 
		(КлассАнгл = "Brush") Тогда // базовые классы
		Возврат Ложь;
	ИначеЕсли (КлассАнгл = "DataGridViewColumnCollection") Тогда // КолонкиТаблицы (DataGridViewColumnCollection)
		СтрКода0 = "
		|Таблица1 = Ф.Таблица();
		|Таблица1.Родитель = Форма1;
		|Таблица1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|Таблица1.АвтонумерацияСтрок = Истина;
		|
		|Для А = 0 По 20 Цикл
		|	Таблица1.Колонки.Добавить(Ф.КолонкаПолеВвода());
		|	Таблица1.Колонки(А).ТекстЗаголовка = ""Кол"" + А;
		|КонецЦикла;
		|Для А = 0 По 20 Цикл
		|	Таблица1.Строки.Добавить();
		|КонецЦикла;
		|
		|КолонкаПолеВвода = Ф.КолонкаПолеВвода();
		|КолонкаПолеВвода.ТекстЗаголовка = ""Вставленная"";
		|КолонкиТаблицы1 = Таблица1.Колонки;
		|";
	ИначеЕсли (КлассАнгл  = "ProgressBar") Тогда 
		СтрКода0 = "Индикатор1 = Форма1.ЭлементыУправления.Добавить(Ф.Индикатор(Ложь));";
	ИначеЕсли (КлассАнгл  = "NotifyIcon") Тогда
		ФормаNotifyIcon = Ф.Форма();
		ФормаNotifyIcon.Текст = "Тест NotifyIcon";
		ФормаNotifyIcon.Отображать = Истина;
		ФормаNotifyIcon.Показать();
		СтрКода0 = "КонтекстноеМеню1 = Ф.КонтекстноеМеню();" + Символы.ПС;
		СтрКода0 = СтрКода0 + "" + КлассРус + "1 = Ф.ЗначокУведомления();";//ЗначокУведомления(<Меню>)
	ИначеЕсли (КлассАнгл = "ComboBoxObjectCollection") Тогда // нет конструктора ЭлементыПоляВыбора (ComboBoxObjectCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.ПолеВыбора().Элементы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ControlCollection") Тогда // нет конструктора ЭлементыУправления(ControlCollection)
		СтрКода0 = "" + КлассРус + "1 = Форма1.ЭлементыУправления;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ContextMenu") Тогда // КонтекстноеМеню(ContextMenu)
		СтрКода0 = "
		|КонтекстноеМеню1 = Ф.КонтекстноеМеню();
		|ЭлементМеню1 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Первый элемент меню""));
		|ЭлементМеню2 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Второй элемент меню""));
		|ЭлементМеню3 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Третий элемент меню""));
		|Надпись1 = Форма1.ЭлементыУправления.Добавить(Ф.Надпись());
		|Надпись1.Текст = ""Надпись с контекстным меню"";
		|Надпись1.Лево = 10;
		|Надпись1.Верх = 10;
		|Надпись1.Ширина = 200;
		|Надпись1.Высота = 100;
		|Надпись1.СтильГраницы = Ф.СтильГраницы.Трехмерная;
		|Надпись1.КонтекстноеМеню = КонтекстноеМеню1;
		|
		|";
	ИначеЕсли (КлассАнгл = "GridColumnStylesCollection") Тогда // СтилиКолонкиСеткиДанных (GridColumnStylesCollection)
		СтрКода0 = "
		|СтильТаблицыСеткиДанных1 = Ф.СтильТаблицыСеткиДанных();
		|СтилиКолонкиСеткиДанных1 = СтильТаблицыСеткиДанных1.СтилиКолонкиСеткиДанных;
		|";
	ИначеЕсли (КлассАнгл = "ComboBox") Тогда
		СтрКода0 = "
		|ПолеВыбора1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеВыбора());
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|
		|ПолеВыбора1.ОтображениеЭлемента = ""Отображение_Элемента"";
		|ПолеВыбора1.ЗначениеЭлемента  = ""Значение_элемента"";
		|ПолеВыбора1.ИсточникДанных = ТаблицаДанных1;  
		|
		|ПолеВыбора1.ИндексВыбранного = 0;
		|";
	ИначеЕсли (КлассАнгл = "GridTableStylesCollection") Тогда // СтилиТаблицыСеткиДанных (GridTableStylesCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.СеткаДанных().СтилиТаблицы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ImageCollection") Тогда // Изображения (ImageCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.СписокИзображений().Изображения;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ListBoxObjectCollection") Тогда // ЭлементыПоляСписка (ListBoxObjectCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.ПолеСписка().Элементы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ListViewItemCollection") Тогда // ЭлементыСпискаЭлементов (ListViewItemCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.СписокЭлементов().Элементы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "MenuItemCollection") Тогда // ЭлементыМеню (MenuItemCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.КонтекстноеМеню().ЭлементыМеню;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ToolBarButtonCollection") Тогда // КнопкиПанелиИнструментов (ToolBarButtonCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.ПанельИнструментов().Кнопки;";//нет конструктора
	ИначеЕсли (КлассАнгл = "TreeNodeCollection") Тогда // УзлыДерева (TreeNodeCollection)
		СтрКода0 = "" + КлассРус + "1 = Ф.Дерево().Узлы;";//нет конструктора
	ИначеЕсли (КлассАнгл = "ListViewSelectedItemCollection") Тогда // ВыбранныеЭлементыСпискаЭлементов (ListViewSelectedItemCollection)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы.Элемент(1).Выбран = Истина;
		|Элементы.Элемент(3).Выбран = Истина;
		|Элементы.Элемент(4).Выбран = Истина;
		|
		|СписокЭлементов1.Фокус();
		|
		|ВыбранныеЭлементыСпискаЭлементов1 = СписокЭлементов1.ВыбранныеЭлементы;
		|";
	ИначеЕсли (КлассАнгл = "ListViewColumnHeaderCollection") Тогда // Колонки (ListViewColumnHeaderCollection)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы.Элемент(1).Выбран = Истина;
		|Элементы.Элемент(3).Выбран = Истина;
		|Элементы.Элемент(4).Выбран = Истина;
		|
		|Колонки1 = СписокЭлементов1.Колонки;
		|";
	ИначеЕсли (КлассАнгл = "ListViewSubItemCollection") Тогда // ПодэлементыСпискаЭлементов (ListViewSubItemCollection)
		СтрКода0 = "
		|Форма1.Ширина = 400;
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|Колонки1 = СписокЭлементов1.Колонки;
		|Колонки1.Добавить(Ф.Колонка(""Имя цвета"", 200, Ф.ГоризонтальноеВыравнивание.Центр));
		|Колонки1.Добавить(Ф.Колонка(""R"", 40, 1));
		|Колонки1.Добавить(Ф.Колонка(""G"", 40, 1));
		|Колонки1.Добавить(Ф.Колонка(""B"", 40, 1));
		|	
		|Элементы = СписокЭлементов1.Элементы;
		|Элемент1 = Ф.ЭлементСпискаЭлементов(Ф.Цвет().Красный.Имя);
		|Элементы.Добавить(Элемент1);
		|ПодэлементыСпискаЭлементов1 = Элемент1.Подэлементы;
		|ПодэлементыСпискаЭлементов1.Добавить(Ф.ПодэлементСпискаЭлементов(255));
		|ПодэлементыСпискаЭлементов1.Добавить(Ф.ПодэлементСпискаЭлементов(0));
		|ПодэлементыСпискаЭлементов1.Добавить(Ф.ПодэлементСпискаЭлементов(0));
		|";
	ИначеЕсли (КлассАнгл = "StatusBarPanelCollection") Тогда // ПанелиСтрокиСостояния (StatusBarPanelCollection)
		СтрКода0 = "
		|СтрокаСостояния1 = Форма1.ЭлементыУправления.Добавить(Ф.СтрокаСостояния());
		|СтрокаСостояния1.ПоказатьПанели = Истина;
		|ПанелиСтрокиСостояния1 = СтрокаСостояния1.Панели;
		|";
	ИначеЕсли (КлассАнгл = "Form") Тогда // Форма (Form)
		СтрКода0 = "
		|Кнопка1 = Форма1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|Форма1.АктивныйЭлемент = Кнопка1;
		|Форма1.КнопкаОтмена = Кнопка1;
		|Форма1.КнопкаПринять = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "TreeView") Тогда // Дерево (TreeView)
		СтрКода0 = "
		|Дерево1 = Форма1.ЭлементыУправления.Добавить(Ф.Дерево());
		|Узел1 = Дерево1.Узлы.Добавить(""Узел1"");
		|Дерево1.ВыбранныйУзел = Узел1;
		|";
	ИначеЕсли (КлассАнгл = "UserControl") Тогда // ПользовательскийЭлементУправления (UserControl)
		СтрКода0 = "
		|ПользовательскийЭлементУправления1 = Форма1.ЭлементыУправления.Добавить(Ф.ПользовательскийЭлементУправления());
		|ПользовательскийЭлементУправления1.Значение = Ф.Цвет().Синий;
		|Кнопка1 = ПользовательскийЭлементУправления1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|ПользовательскийЭлементУправления1.АктивныйЭлемент = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "NumericUpDown") Тогда // РегуляторВверхВниз (NumericUpDown)
		СтрКода0 = "
		|РегуляторВверхВниз1 = Форма1.ЭлементыУправления.Добавить(Ф.РегуляторВверхВниз());
		|Кнопка1 = РегуляторВверхВниз1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|РегуляторВверхВниз1.АктивныйЭлемент = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "ListBox") Тогда // ПолеСписка(ListBox)
		СтрКода0 = "
		|ПолеСписка1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеСписка());
		|ПолеСписка1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|ПолеСписка1.РежимВыбора = Ф.РежимВыбора.МножественныйПростой;
		|
		|ТаблицаДанных4 = Ф.ТаблицаДанных();
		|ТаблицаДанных4.ИмяТаблицы = ""ТД4"";
		|Колонка7 = ТаблицаДанных4.Колонки.Добавить(Ф.КолонкаДанных(""Как Отобразить Элемент"", Ф.ТипДанных.Строка));
		|Колонка8 = ТаблицаДанных4.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Объект));
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(""Как Отобразить Элемент"", ""Строка1 (Строка)"");
		|ТекСтрока.УстановитьЭлемент(""Значение_элемента"", ""Значение строки 1 в список"");
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2 (Булево)"");
		|ТекСтрока.УстановитьЭлемент(1, Истина);
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка3 (Объект)"");
		|ТекСтрока.УстановитьЭлемент(1, Форма1);
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка4 (Дата)"");
		|ТекСтрока.УстановитьЭлемент(1, (Дата(2019,01,02,03)));
		|ТекСтрока = ТаблицаДанных4.Строки.Добавить(ТаблицаДанных4.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка5 (Число)"");
		|ТекСтрока.УстановитьЭлемент(1, 156.54888);
		|ПолеСписка1.ОтображениеЭлемента = ""Как Отобразить Элемент"";
		|ПолеСписка1.ЗначениеЭлемента = ""Значение_элемента"";
		|ПолеСписка1.ИсточникДанных = ТаблицаДанных4;
		|
		|ПолеСписка1.УстановитьВыбор(0, Ложь);
		|ПолеСписка1.УстановитьВыбор(2, Истина);
		|";
	ИначеЕсли (КлассАнгл = "DataGrid") Тогда // СеткаДанных(DataGrid)
		СтрКода0 = "
		|СеткаДанных1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаДанных());
		|СеткаДанных1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаДанных1.ОтображатьЗаголовок = Истина;
		|СеткаДанных1.ТекстЗаголовка = ""Сетка данных333333"";
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|СеткаДанных1.ИсточникДанных = ТаблицаДанных1;
		|";
	ИначеЕсли (КлассАнгл = "PropertyGrid") Тогда // СеткаСвойств(PropertyGrid)
		СтрКода0 = "
		|СеткаСвойств1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаСвойств());
		|СеткаСвойств1.ОтображатьПанельИнструментов = Истина;
		|СеткаСвойств1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаСвойств1.ВыбранныйОбъект = Форма1;
		|Кнопка1 = СеткаСвойств1.ЭлементыУправления.Добавить(Ф.Кнопка());
		|СеткаСвойств1.АктивныйЭлемент = Кнопка1;
		|";
	ИначеЕсли (КлассАнгл = "ListView") Тогда // СписокЭлементов(ListView)
		СтрКода0 = "
		|СписокЭлементов1 = Форма1.ЭлементыУправления.Добавить(Ф.СписокЭлементов());
		|СписокЭлементов1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СписокЭлементов1.Флажки = Истина;
		|СписокЭлементов1.РежимОтображения = Ф.РежимОтображения.Подробно;
		|СписокЭлементов1.МножественныйВыбор = Истина;
		|
		|Колонка1 = СписокЭлементов1.Колонки.Добавить(Ф.Колонка(""Номер"", 70, Ф.ГоризонтальноеВыравнивание.Лево));
		|Элементы = СписокЭлементов1.Элементы;
		|Для А = 1 По 10 Цикл
		|	Элементы.Добавить(Ф.ЭлементСпискаЭлементов("""" + А));
		|КонецЦикла;
		|Элементы.Элемент(1).Выбран = Истина;
		|Элементы.Элемент(3).Выбран = Истина;
		|Элементы.Элемент(4).Выбран = Истина;
		|Элементы.Элемент(5).Сфокусирован = Истина;
		|СписокЭлементов1.Сортировать(Колонка1, Ф.ПорядокСортировки.ПоВозрастанию);
		|
		|СписокЭлементов1.Фокус();
		|";
	ИначеЕсли (КлассАнгл = "DataGridColumnStyle") Тогда // СтильКолонкиСеткиДанных(DataGridColumnStyle)
		СтрКода0 = "
		|СеткаДанных1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаДанных());
		|СеткаДанных1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаДанных1.ОтображатьЗаголовок = Истина;
		|СеткаДанных1.ТекстЗаголовка = ""Сетка данных333333"";
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|
		|СтильТаблицыСеткиДанных1 = Ф.СтильТаблицыСеткиДанных();
		|СтильТаблицыСеткиДанных1.ИмяОтображаемого = ""ТД1"";
		|ИндексСтильТаблицыСеткиДанных1 = СеткаДанных1.СтилиТаблицы.Добавить(СтильТаблицыСеткиДанных1);
		|
		|СтильКолонки1 = Ф.СтильКолонкиПолеВвода();
		|СтильКолонки1.ИмяОтображаемого = ""Отображение_Элемента"";
		|СтильКолонки1.ТекстЗаголовка = ""ОтображениеЭл"";
		|СтильКолонки1.Ширина = 250;
		|СтильТаблицыСеткиДанных1.СтилиКолонкиСеткиДанных.Добавить(СтильКолонки1);
		|
		|СеткаДанных1.ИсточникДанных = ТаблицаДанных1;
		|
		|СтильКолонкиСеткиДанных1 = СтильТаблицыСеткиДанных1.СтилиКолонкиСеткиДанных.Элемент(0);
		|";
	ИначеЕсли (КлассАнгл = "DataGridTableStyle") Тогда // СтильТаблицыСеткиДанных(DataGridTableStyle)
		СтрКода0 = "
		|СеткаДанных1 = Форма1.ЭлементыУправления.Добавить(Ф.СеткаДанных());
		|СеткаДанных1.Стыковка = Ф.СтильСтыковки.Заполнение;
		|СеткаДанных1.ОтображатьЗаголовок = Истина;
		|СеткаДанных1.ТекстЗаголовка = ""Сетка данных333333"";
		|
		|ТаблицаДанных1 = Ф.ТаблицаДанных();
		|ТаблицаДанных1.ИмяТаблицы = ""ТД1"";
		|Колонка1 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Отображение_Элемента"", Ф.ТипДанных.Строка));
		|Колонка2 = ТаблицаДанных1.Колонки.Добавить(Ф.КолонкаДанных(""Значение_элемента"", Ф.ТипДанных.Строка));
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка1"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка1"");
		|ТекСтрока = ТаблицаДанных1.Строки.Добавить(ТаблицаДанных1.НоваяСтрока());
		|ТекСтрока.УстановитьЭлемент(0, ""Строка2"");
		|ТекСтрока.УстановитьЭлемент(1, ""Строка2"");		
		|СеткаДанных1.ИсточникДанных = ТаблицаДанных1;
		|
		|СтильТаблицыСеткиДанных1 = Ф.СтильТаблицыСеткиДанных();
		|СтильТаблицыСеткиДанных1.ИмяОтображаемого = ""ТД1"";
		|СтильТаблицыСеткиДанных1.СеткаДанных = СеткаДанных1;
		|";
	ИначеЕсли (КлассАнгл = "Bitmap") Тогда // Картинка(Bitmap)
		СтрКода0 = "" + Символы.ПС + 
		"СтрМасленица1 = ""/9j/4AAQSkZJRgABAQEAeAB4AAD/4QA2RXhpZgAATU0AKgAAAAgAAQEyAAIAAAAUAAAAGgAAAAAyMDE4OjA3OjE5IDA5OjQxOjQxAP/bAEMACAYGBwYFCAcHBwkJCAoMFA0MCwsMGRITDxQdGh8eHRocHCAkLi"" + Символы.ПС + "+ Символы.ПС + 
		"""cgIiwjHBwoNyksMDE0NDQfJzk9ODI8LjM0Mv/bAEMBCQkJDAsMGA0NGDIhHCEyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMv/AABEIAFAAdwMBIgACEQEDEQH/xAAfAAABBQEBAQEBAQAAA"" + Символы.ПС + "+ Символы.ПС + 
		"""AAAAAAAAQIDBAUGBwgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzYnKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaH"" + Символы.ПС + "+ Символы.ПС + 
		"""iImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABAncAAQIDEQQFITE"" + Символы.ПС + "+ Символы.ПС + 
		"""GEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1t"" + Символы.ПС + "+ Символы.ПС + 
		"""fY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/AJL2XUYr+CeYldgIlkTJKlTzj5gOMD8AvIxWlLrF/qWtwyQpdfangIPlqzNEAFxjjgEng7j82c4/i9AUMHjZbe1RovuOY9zjjbnPByRx+NVk1COHWYtFjISaaEzoE2opI"" + Символы.ПС + "+ Символы.ПС + 
		"""J+XA5yQGPuFNdSnZaoyb1ORTTtVuNYs7m6s7s+aZWmlmj2bzkBSc5C5BJAIUkLgeta+laRf6ReG8fyWWMqodG34/cplgvBwGBUAkHA54Oatfbml1WGCKXfEYvNEudyybyERs9fUY9T7HFjUtSTQlsd8M1w93eRWxbeRt3nBbp0Hp/8A"" + Символы.ПС + "+ Символы.ПС + 
		"""XqPaxnewpKUd0RT69dmKSGyvIJ5mDL87KCi/3gU5LcHHGDleetUp9Q8Q2Hh29kkmgs32B4pXHIZmyVVefmOWA3Zwcfht2+q2j61PpqWconih817gBRGT8oKg5zuAdevHXngiqXimyuNR8NX0Ec0ocR+YrIvLFfmCkd1OOQME+1KTTg1"" + Символы.ПС + "+ Символы.ПС + 
		"""FDjJqST6mgy64zunmBRvOfN2BQu4H5ShLZxlefcjBxWDfeGtWfWvtyPG/m+buZZW3RbjlcbiOPmbAHAwODjJ2b3WrgagLSwtzceW6efdzMI4woPzAd2YgY+UYBYHnGKuteEp8qyMcc7Bj9Wx/KhNp3sNu/Uw4bT+w9PN5q+vTxIiqJJ"" + Символы.ПС + "+ Символы.ПС + 
		"""JBBGmeAAvHUnAGSTz1rPmlu/7OstdvZ5bDDtG0d3KYcxFmyAoTliFVhkbjgdDXQvLPIwaO2VJEOUlnO8qemRjO3gkcetZV5o91eszXN1FKZBtbfbEnHcKS/H4AUKOvvOw09O5j2vhmRbxrq31N2glxhDACfL42ruz25IO0EEg84IOkl"" + Символы.ПС + "+ Символы.ПС + 
		"""qkckqfb5Hd/3ckZlDHjOARjjHP45znmlfR20nRbiOzvJ5GWF1U3LKdqkc8hewyQCCM8dOK8a8QaMmhXsSRKwgkXMeW3MpXgjIPXgHr/ABDvmpqV7S5URKE4w9qlovM9gj0pIbi5uY3KzTkM0rYLIAuCFPZepwc8knvVG90uxubqFZW8"" + Символы.ПС + "+ Символы.ПС + 
		"""+8twbhEG0lhgjkHjn2A7dKj8M6nP4g8I280t2Y7m2lMM9wx3F9g4LEnqVZCSe4JrPi0Y3mpC5tp5JpTCxjkSZ4iy5A+5GSVwCMk4PzqNi1UXdXuHNtYvXelzXV1p7LfA28byLMSuWdPm4I5DESYwfl4ZjzmimQacyX726alqOQN67nD"" + Символы.ПС + "+ Символы.ПС + 
		"""pIrc7lLBucgg5JIxjp1KJR1vcqMtNjp/GnigeFNE+2KUjdpREqiHzXfOScDcACAC2SccY6kVnawrrbt4ijntrmRtNSB5PJZGdWcmT5RynGwDOSuDu6E10eq6dFqmnzWV2qG2lZWdVH3trh8HdwQSoBGORkVzHjHxTb+DtJtbm++0XMc"" + Символы.ПС + "+ Символы.ПС + 
		"""ji3jSMjzHIQ5ZiTg9OT6tUcl73dilNRa0vqclLqd5NriGKSPzCSqbNuQwYnGzGAwzjptxzgkmu9Nq/irRbJZpprVrS8ScOjBjIyA8E55X5sc9duSOa5iK88Im1sr17cy/bbdLpY9zOyqxyd2SRkFSD7riu60+e2ktYPs0YEDIPL2nIx"" + Символы.ПС + "+ Символы.ПС + 
		"""04/LHFc+HwzpzcnJP5HRisTCcEowsc14XsJk8XeIr65aRmkkHll4wPOQvKu5sjs0Z2kYAVh2NdcbeFsZC5BznIGPxp+yPP+pXJ7nFc9rHjrw5oN69jdyyPcx8SR28O4pwCMnIGcEHGc/SuvSCOHWT2OjEAOCNhA5BJyRXJ3HjnT7P4g"" + Символы.ПС + "+ Символы.ПС + 
		"""f8ItfIsCtGnlXpmyrzMFIjK4+X73Unrj1ra03xDo2sJu0jUra7YIJCkThmAYfLlTyD0yCMjkGvHtbHgdtQ8TyXd5HeXyXMrFp2ffISS2IwODjOwEDquc7SDSlOKV2b0afO7bHtdw0VrFJNKrusYJIUc4rgNKv9Uj8TTz3b3y2RBDiWJ"" + Символы.ПС + "+ Символы.ПС + 
		"""QJm6IFGeCM5OzOcADIxUukeJR4t8Ly3VnFLbNaxj7RbuclFKHPPUgjdg9Ts5A5qvd3ttdNdaXGhTy7YyNck7VGGVTg9c/NnPtXj5hialOrBQ16nfg4LkkpLfTU6XV9cs9IsJbq+I8hPlIHzFyeigdyef1JwATXiPiLXLjXJI2Fk1pZW"" + Символы.ПС + "+ Символы.ПС + 
		"""zssW4ZYb8FQ7dN2Ez26d8Zr0HVNV0XxHol3axJJJNCBPDFd45UfKH4PXDkYP8Ae961ZLHTvtF48MSONTnV7iN/mVgFbAx6ZDN9Se2BV4vHQpSVlfS5zxwtaUXFuyZg/C9m/srVY1VtqvGVGcAkqwwPQ8D9PSt7Ur77Alva77pftdxGj"" + Символы.ПС + "+ Символы.ПС + 
		"""lUKqz8ZC84UEL931wflIJqHwtYW2i3OrLbBVhe5URxsc7AI1JwT2y/TtitPVLSS+NhLDs/0W5+0bWyFYiN1UZGe7g/hXdRqKdNTWzOdUnT9x7odAIbq6uJVeby2kPl+YNrHlssMY4JPfnAHXAwVWYa1JGN624O7kW0r5I9egP4e/tRW"" + Символы.ПС + "+ Символы.ПС + 
		"""/Lf7RLbXQ7Qr5jFjgL/vYrk/EHhqw8V6nbLqlvHc2NmXKBXlYru+98sYBJOxRy2B+VbuySUt5mwHGOgz+ladqIHtWn8qOKRpCG2gDZhsAcj0x9cn1p1LJWJg23c8T8R6JDouv6RpmmNJHazSGztUkcuYyZCcEjrgz+/3evGa9a0m1sb"" + Символы.ПС + "+ Символы.ПС + 
		"""DTLa188jyIhEoJIJA4yfc4zWZcSRJqYVLOJoZZliZimTEzBiGT0baCMj1HtnajhjRAFic4GP85FUoRjJtdbEOrKcUnsrjdS1CeHT5f7MsVvrgL8kLTCJWPpuIPb/PevJYW0nS9d1A+KJP7O1a8uZLuO1U+cyJJt2qWjX74yxC5BIK5H"" + Символы.ПС + "+ Символы.ПС + 
		"""Y+ry3E0WAkDDc2AT834YFeba94M1651i8vFh8uPzJHjuGuYlB3sWXd95gRu28D8cc1nVjG1m7F0qkk7xVy58PddhX7dbWHh+6ht59Smu1kzyuSGQMCBt+QBQATjr0YtXNRfDjV08Qx2MLwy25lRDcSMuVjALfMmQ27aOi5B9epHfKjW"" + Символы.ПС + "+ Символы.ПС + 
		"""cs0FvHFCluFURwSMqIdq7gOvBYscHJ+brVVLm5g1S3aHZ5speOJBu5Yxtlh0JOO/wBPavEeMqVMSqKSsnY9ihGVGnKae61LWgNpGk3l9pSQ6ek1xJGqizkL/aE5ALDHy43MSmTtBJBwQTi6jfx6FDevPZLexWCkB9oInXgIGb0zt3Af"" + Символы.ПС + "+ Символы.ПС + 
		"""3T14rGvdLtfCej2WqIZ723uZUkVlkEfKszkmTByr/KRtC7gobjv3UPhjS5rOOV472GArlrSe6by1X0YHnHsT04PpWlfDJuKh9l+ZUJct5y+F7eZ5r4M/sm4+1fZLX7B5c8UswlmaUyAb9qrhQdvJJBOSdpzxXU3d5aFDfFpGS3ILOqr"" + Символы.ПС + "+ Символы.ПС + 
		"""FApPyjOR74+YnrXUW+i6NJIDBpdtHDGAiKkexHJJJOwcHHPJGeawPiiPK8C3agAebNDGOMcbwcf8Ajpoq4WdWTc5tLsR7aDmlCPUzNF13T7jXTZ2t0LmV4mlmI+6HBH3W/iBDAf8AAM4GWqPxbqGpaRf2WuaZDcXLRq6TW5djA0fA4A"" + Символы.ПС + "+ Символы.ПС + 
		"""6OSc5z/CeOMV5lpFydL1W0vxkeRKC+OMoeG/8AHSa94uUSKLcPOZuiIhbLt2A54zjqcAdyK7sKkqSpp7GeNpexqJ23I9F1ZNXUzxwXcCYUqJsgtlQW/wC+WLL6HbkE0Uy0ivvtDPLHb2satg+bOzOcg46cL+Jzx06UVu4pdTi5vI6F7"" + Символы.ПС + "+ Символы.ПС + 
		"""yRVJVSX3BVRTt3EnAHAzyTWsulrtL3MjyyuBuwSqgjoAB6epJNYnkypcxzmGTYkyOTtPIVw3FdaskMsAZZFZGGVYHII7EVvW921jnpq+5w+sWclpqWl21uw+zyX6SnceVIVyee+cd66pXiXGZWJx6GuX8VXsX9saV8xWC2ulkmk2kgH"" + Символы.ПС + "+ Символы.ПС + 
		"""a2AcDgk4xWrBrWlXm2MXMLyP8uGXDEnjHQc0OMmrtCi0nZMvRfv7mWVG4DBBkZwu0nj6k8//AFqZcFfLeO5thLC6lX2DcGU9QUPUY7c5qKzv7K3nmtjKFYSgcqQoyikKWxgHByBnPNW3ZCxj3rnnGT1A/wAK4K/uzvbQ7aKfJvqcNqH"" + Символы.ПС + "+ Символы.ПС + 
		"""g68nkB8Pa8AFG0214Szxr2UPjzdo/usTj17VV0zwBqv24y6zqcDRYIkhsldXlB/haZjvCE9VHB9q7m6s47hQJEDY6E4OPoe34VQe2nDLHDfXQTnzCJi2BjsWyQfoaI1IvVP8AD9S3KaVmgvNQgsVW1gg+0XCAKltbqFVABwCeiADHHX"" + Символы.ПС + "+ Символы.ПС + 
		"""HQVDHFdXCia/YZzlYYwQiH056n3P6U63tpbZRAgiZVJD4TDbu/1yefXnv1rK1zxHDZ2bLG5MrEqioSrvglTg/wLkEFupAO3JII0haT5aa1Iaduab0JX8RWFpqMtlJeWUdxHLh4HuFRwSo28EjOVKnjPPFcV8Ttbg1HSNNsoJY2kN2ZJ"" + Символы.ПС + "+ Символы.ПС + 
		"""I0lV/uoQDx7uRXnF9dNqV7dXUqqJLiYu6quAvzdMf45PqTSpGsSRSBQOWzge5xXNUq6ONj28LlvLONTm87EOMnYRkMMHn616tYeIIJtA00rcs1/cww20gkz5aEsI+e3Lr1HPOMgdPKCfmBB/wA5r0H4e3NmLZvtMayXFtdLFbswyIfM"" + Символы.ПС + "+ Символы.ПС + 
		"""DFDj3dWGRyMj1ows7SaZWb0r0lNdH+Z0F1IujQRWbFdXugXYWxQFpoyxOTkn5wTknvgnAopbK8hlNveawAW2Zt5DcbAq44IfIO5wSexOx8jjFFejdLRo+cWp6Zqc9zDayi3hjL7SE8xsAntwOfr09q4LWI/GF/cS3Vtv02I4QWlk8bc"" + Символы.ПС + "+ Символы.ПС + 
		"""ckvuYHLc4JAXtweo7xY4A7sCwLHJ6VIZYgMKUH1ohWUNUrilSctzy200PxmmkTaWbu5+y3beZKZ5Y2OeO/wB8Z2jgHirMXgy/gMa/b0REXIWMb8t6cgHGe+a9ELoxz56fQVBI8S9WjOTgZ3cn860+uS6JIXsF1PNPEdlc6XYrPLcs11"" + Символы.ПС + "+ Символы.ПС + 
		"""JKgWdHYOAFb5c8HHTjkHHNQ2nie+hhJyHl3bt8hLAZPXHUHryCOuTk113ijS/7bsFt4p4IpEcOrOhI9wcEHv8A56jkbXwDdwTrJJ4gSbDbiptSN3ryHz3P9c81NGUZTlKrs7WLmpKEVTequbv/AAnES7Rc29wHJAYpAjKvTPJZScc9F"" + Символы.ПС + "+ Символы.ПС + 
		"""HTvWoPF+kfZkl+1QspIV9rgFMjuv3l/EY9+9Z8nh2ye4c7IltSd0cMUZVkOACN/Vhx0OcZ4xWPq/hqzt9Pubm3e4DIAVSTBAyQPTPAJ/L8ayrRw6g5R3SLpTquajJaFjVvHMJuzHZ3MPmMQixRzJIePvF3TcA3QBVbOOSecLgeRNfXE"" + Символы.ПС + "+ Символы.ПС + 
		"""txLMqxomWaPbiNQvChSRj5eOnXn1NXfDvhe1ubFLyd5Nt0z+dsA3fK7qAN3GMAV0dr4Us7OF4v7Qnmt34aHy4yrL3ByTn0rajUpU6acN2jOqpznaWyZj6h4V0qeDyhDbBVVII5TBl1iVCQ5IIOSePUjaayZPA+lOZCsVwgZjGi/aWby"" + Символы.ПС + "+ Символы.ПС + 
		"""iBu3j5eQcgY6/0TxUtv4cWCPQrG7dizeYiST26pjoQqMA+cnkfnzXGpqmukgLqV5tBDCOEM2zncoDHLYBORkn8a8KeBqQ2l+Z7NLGReibR2MvgTToY7sLBJIVXbGHuGLbuTlcKA3UcEfwn1OGXelW+kWZfTwI1O1Z0tweVJJ5YsWPKo"" + Символы.ПС + "+ Символы.ПС + 
		"""TyPlcdQxzW0qx1+70ZLpdQm3SFh5Utz5L4VmUYzgqMEnjbnceua0bfw/qUsaPeajkoMJFLdNchOMcBiQDgkccgE104bA1ITjUlPRephicbGcXT1dyhq+orqumRrYyx/aLRjJCqn95tO1GU/wC1kk8AcLkcNRVWfQNRhnRlBmKjassFz"" + Символы.ПС + "+ Символы.ПС + 
		"""iVR1xhsZH698dyV67cY6JnlKLP/2Q=="";"+ Символы.ПС + 
		"Картинка1 = Ф.Картинка(СтрМасленица1);" + Символы.ПС;
	ИначеЕсли (КлассАнгл = "TabPage") Тогда // Вкладка (TabPage)
		СтрКода0 = "
		|	ПанельВкладок1 = Форма1.ЭлементыУправления.Добавить(Ф.ПанельВкладок());
		|	Вкладка1 = Ф.Вкладка();
		|	Вкладка1.Родитель = ПанельВкладок1;
		|	Вкладка1.Текст = ""Вкладка1"";
		|";
	Иначе
		СтрКода0 = 
		"Попытка
		|    " + КлассРус + "1 = Форма1.ЭлементыУправления.Добавить(Ф." + КлассРус + "());" + "
		|Исключение
		|    Попытка
		|        " + КлассРус + "1 = Ф." + КлассРус + "();" + "
		|    Исключение
		|    КонецПопытки;
		|КонецПопытки;
		|";
	КонецЕсли;
	СтрСозданияОбъекта = СтрКода0;
	СтрСозданияОбъекта2 = СтрЗаменить(СтрСозданияОбъекта, Символы.ПС, Символы.ПС + "    ");
	Возврат Истина;
КонецФункции//ПолучитьОбъектДляМетодов

Процедура ТестированиеМетодов()
	// Если конструктора нет, то получаем методом или свойством другого объекта
	// Тестируем свойства, методы, перечисления.
	// Список классов берем из файла OneScriptForms.html
	// Свойства - из файла OneScriptForms....(Класс).....Members.html
	// Методы - из файла OneScriptForms....(Класс).....Members.html
	// Перечисления - из файла OneScriptForms.html
	
	Сч1 = 0;
	Сч2 = 0;
	Сч3 = 0;
	Сч4 = 0;
	Сч5 = 0;
	Сч6 = 0;
	
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(КаталогСправки + "\OneScriptFormsru\OneScriptForms.html");
	Стр12 = ТекстДок.ПолучитьТекст();
	Массив1 = СтрНайтиМежду(Стр12, "<H3 class=dtH3>Классы</H3>", "</TBODY></TABLE>", Ложь, );
	Массив2 = СтрНайтиМежду(Массив1[0], "Описание</TH></TR>", "</TBODY></TABLE>", Ложь, );
	Массив3 = СтрНайтиМежду(Массив2[0], "<TR vAlign=top>", "</TD></TR>", Ложь, );
	Для А1 = 0 По Массив3.ВГраница() Цикл
		Массив4 = СтрНайтиМежду(Массив3[А1], ".html"">", "</A></TD>", Ложь, );
		Для А = 0 По Массив4.ВГраница() Цикл
			ТекстТеста = 
			"ПодключитьВнешнююКомпоненту(""" + КаталогБиблиотеки + "\OneScriptForms.dll"");
			|НекорректныеМетоды = Новый СписокЗначений;
			|Ф = Новый ФормыДляОдноСкрипта();
			|Форма1 = Ф.Форма();
			|Форма1.СостояниеОкна = Ф.СостояниеОкнаФормы.Свернутое;
			|Форма1.Отображать = Истина;
			|Форма1.Показать();
			|";
			
			СтрХ = Массив4[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			КлассАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			// у аргументов события нет методов, поэтому эти классы пропустим
			Если Прав(КлассАнгл, 4) = "Args" Тогда
				Продолжить;
			КонецЕсли;
			КлассРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			//находим свойства класса из файла OneScriptForms....(Класс).....Members.html
			ИмяФайлаЧленов = КаталогСправки + "\OneScriptFormsru\OneScriptForms." + КлассАнгл + "Members.html";
			
			Сообщить(" (" + Ф.Математика().Окр(((ТекущаяУниверсальнаяДатаВМиллисекундах() - Таймер)/1000)/60, 2) + " мин." + " " + А1 + " из " + Массив3.ВГраница() + ") " + 
			КлассРус + " (" + КлассАнгл + ")");
			
			Если Не ПолучитьОбъектДляМетодов(КлассРус, КлассАнгл) Тогда
				Продолжить;//пропустили классы без конструктора
			КонецЕсли;
			
			ТекстТеста = ТекстТеста + "
			|" + СтрКода0 + "
			|";
			
			//находим методы класса из файла OneScriptForms....(Класс).....Members.html
			М_МетодыТест = МетодыТест(ИмяФайлаЧленов, КлассРус, КлассАнгл);
			// не создаем файл для теста, если у класса нет наследуемых методов, или методов нет совсем.
			Если М_МетодыТест.Количество() = 0 Тогда
				// Сообщить("Нет наследуемых методов у класса " + КлассРус + " (" + КлассАнгл + ")");
				Продолжить;
			КонецЕсли;
			
			ТекстТеста = ТекстТеста + "
			|Если НекорректныеМетоды.Количество() > 0 Тогда
			|	Сообщить(""---Не прошли тест методы:---"");
			|КонецЕсли;
			|Для А = 0 По НекорректныеМетоды.Количество() - 1 Цикл
			|	Сообщить("""" + НекорректныеМетоды.Получить(А).Значение);
			|КонецЦикла;
			|Сообщить(""Тест завершен."");
			|Сообщить(""==============================================="");
			|Форма1.Закрыть();
			|";
			
			ТекстТеста = ТекстТеста + "
			|Форма1.Текст = ""Тест " + КлассРус + "(" + КлассАнгл + ")"";
			|Ф.ЗапуститьОбработкуСобытий();";
			
			Если КлассАнгл = "FolderBrowserDialog" или 
				КлассАнгл = "ColorDialog" или 
				КлассАнгл = "FontDialog" или 
				КлассАнгл = "OpenFileDialog" или 
				КлассАнгл = "SaveFileDialog" Тогда // эти объекты интерактивны, тестировать отдельно вручную
			Иначе
				ТекстДокХХХ = Новый ТекстовыйДокумент;
				
				// // // ИмяВременногоФайла = "C:\Users\master\AppData\Local\Temp\" + КлассРус + "-метод.tmp";
				// // // ТекстДокХХХ.Записать(ИмяВременногоФайла);
				
				ТекстДокХХХ.Прочитать(ИмяВременногоФайла);
				ТекстДокХХХ.УстановитьТекст(ТекстТеста);
				ТекстДокХХХ.Записать(ИмяВременногоФайла);
				Команда2("""C:\Program Files\OneScript\bin\oscript.exe""", ИмяВременногоФайла, ПолеВвода1, КлассРус + " (" + КлассАнгл + ")");
			КонецЕсли;
			Форма1.Фокус();
		КонецЦикла;
	КонецЦикла;
	
	// Сообщить("методы, у которых параметров нет " + Сч1);
	// Сообщить("методы, у которых параметров нет, возвращаемого значения нет " + Сч2);
	// Сообщить("методы, у которых параметров нет, возвращаемое значение есть " + Сч3);
	// Сообщить("методы, у которых параметры есть " + Сч4);
	// Сообщить("методы, у которых параметры есть, возвращаемого значения нет " + Сч5);
	// Сообщить("методы, у которых параметры есть, возвращаемое значение есть " + Сч6);
КонецПроцедуры//ТестированиеМетодов

Функция СвойстваТест(ИмяФайлаЧленов, КлассРус, КлассАнгл)
	МассивСвойств = МассивСвойств(ИмяФайлаЧленов);
	Для А = 0 По МассивСвойств.ВГраница() Цикл
		ФайлСвойства    = МассивСвойств[А][0];
		СвойствоАнгл    = МассивСвойств[А][1];
		СвойствоРус     = МассивСвойств[А][2];
		СвойствоРусАнгл = МассивСвойств[А][3];
		ТипСвойства = ТипСвойства(ФайлСвойства);
		// Сообщить("ТипСвойства = " + ТипСвойства);
		
		ИмяПеречисления = ИмяПеречисления(ФайлСвойства);
		// Сообщить("ИмяПеречисления = " + ИмяПеречисления);
		ИспользованиеСвойства = ИспользованиеСвойства(ФайлСвойства);
		
		СтрКода1 = "" + КлассРус + "1." + СвойствоРус;
		
		Если (СвойствоРус = "Отправитель") или (СвойствоРус = "Параметр") Тогда
			Продолжить;
		КонецЕсли;
		
		Если М_Свойств.Найти(СвойствоРус) <> Неопределено Тогда
			Продолжить;
		КонецЕсли;
			
		Если СвойствоРус = "Родитель" Тогда
			Если(КлассАнгл = "TabPage") Тогда
				ТекстТеста = ТекстТеста + "
				|ПанельВкладок1 = Ф.ПанельВкладок();
				|ПанельВкладок1.Родитель = Форма1;
				|Вкладка1.Родитель = ПанельВкладок1;
				|";
			ИначеЕсли(КлассАнгл = "Form") Тогда
				ТекстТеста = ТекстТеста + "";
			ИначеЕсли(КлассАнгл = "MenuItem") Тогда
				ТекстТеста = ТекстТеста + "";
			Иначе
				ТекстТеста = ТекстТеста + "
				|" + КлассРус + "1.Родитель = Форма1;
				|";
			КонецЕсли;
		КонецЕсли;
		
		Если СвойствоРус = "ФоновоеИзображение" Тогда
			ТекстТеста = ТекстТеста + "
			|СтрСтрелкаВлево = ""iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAAMPSURBVFhH7ZftS1NhGMb9ZyKIQgxRTDFFE0VQISQUNCXTbSm+TpR8Kf2SrAxUFDGMENIwbUPnROfL1Pn+bkM0NSuUXE0NJPx29dwDTz3ucTu+pH3oww92zn12Xdd27nM/53F7rNHgIvk3AkTFxp47UoDDhbtKJR6VlaGEFc8S0iTtw35SgLiUFFiWl/Fzf/+vQh7k5RBgfHYWP/b2zgXy4gLEJiXBurNj54vVio+bm1g7Y0iTtA98yFMKkFtcjM9bW7CsrWF+ZUUWgxMTeNXUJKw5gzzIizylAGp28H51FbPs/sihx2zGnYQEPK+pEdZdQV7kKQVIz8/HzNKSLAx9fYiKiUFIVBSeVlUJr5EDeUoBHqjVmFpcdIm2sxPh0dEIjoiwcz8tDZrKSqeY2K0SaZEnF2DCYnFKk1aLW5GRCAwPPxb6nh6hHhdAlZODsYWFI3nZ2IibYWHwDw3loHOuaDcahZrkyQUYmZsTUl1fD7+QkBOj6+oS6nIBlNnZMM/MOKCpqIBPUJBsbgQHO/CO9Y1Imzy5AINTUxwVtbXwCgiAd2DgqWjt6HDQJhwCDExOSozNz+MrGxYxiYnw9Pc/FW9ZgD+1D+ACKLKy0D8+zkEhvtlsSFAo4OHry3Hdz082zW1tDtoEeXIBekdHHTBPT8O2uwtFejrcfXxOxBudTqjNBUjJzIRxeFiIiaW1scUjKy8PV728hFzz9j4Smh8iXfLkAnQNDR1J78gIvm9vo7C0FFc8PY/F69ZWoSYXIJkddA4MOIW+ZGU98aS8HJc9POyk0QBjo1YIazSCwov0yPN3gIwMdPT3u8RgMmGTPR3VdXW45O6O3MJC4XVyIE8pADVEO1vl9DL5tLGBBjae1QUFwroryEtqwttxcVCyhaFZr0cbWzjk8mF9HZNspIpqriAvFfOMjo+HW6JKZW+IF+wXNbS0oMVggJbNb113t0uM7MVEdF4EaZI2eZAXDaJ7qalwe1hSgmT2nNNfchHYNya5RUXC4nkgbc2esbeXg8+nRbQxEV1H/N+cXnAADX4Bo1ztMEwHgc8AAAAASUVORK5CYII="";
			|" + КлассРус + "1.ФоновоеИзображение = Ф.Картинка(СтрСтрелкаВлево);
			|";
		КонецЕсли;
			
		Если СвойствоРус = "Изображение" Тогда
			ТекстТеста = ТекстТеста + "
			|СтрСтрелкаВлево = ""iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAAMPSURBVFhH7ZftS1NhGMb9ZyKIQgxRTDFFE0VQISQUNCXTbSm+TpR8Kf2SrAxUFDGMENIwbUPnROfL1Pn+bkM0NSuUXE0NJPx29dwDTz3ucTu+pH3oww92zn12Xdd27nM/53F7rNHgIvk3AkTFxp47UoDDhbtKJR6VlaGEFc8S0iTtw35SgLiUFFiWl/Fzf/+vQh7k5RBgfHYWP/b2zgXy4gLEJiXBurNj54vVio+bm1g7Y0iTtA98yFMKkFtcjM9bW7CsrWF+ZUUWgxMTeNXUJKw5gzzIizylAGp28H51FbPs/sihx2zGnYQEPK+pEdZdQV7kKQVIz8/HzNKSLAx9fYiKiUFIVBSeVlUJr5EDeUoBHqjVmFpcdIm2sxPh0dEIjoiwcz8tDZrKSqeY2K0SaZEnF2DCYnFKk1aLW5GRCAwPPxb6nh6hHhdAlZODsYWFI3nZ2IibYWHwDw3loHOuaDcahZrkyQUYmZsTUl1fD7+QkBOj6+oS6nIBlNnZMM/MOKCpqIBPUJBsbgQHO/CO9Y1Imzy5AINTUxwVtbXwCgiAd2DgqWjt6HDQJhwCDExOSozNz+MrGxYxiYnw9Pc/FW9ZgD+1D+ACKLKy0D8+zkEhvtlsSFAo4OHry3Hdz082zW1tDtoEeXIBekdHHTBPT8O2uwtFejrcfXxOxBudTqjNBUjJzIRxeFiIiaW1scUjKy8PV728hFzz9j4Smh8iXfLkAnQNDR1J78gIvm9vo7C0FFc8PY/F69ZWoSYXIJkddA4MOIW+ZGU98aS8HJc9POyk0QBjo1YIazSCwov0yPN3gIwMdPT3u8RgMmGTPR3VdXW45O6O3MJC4XVyIE8pADVEO1vl9DL5tLGBBjae1QUFwroryEtqwttxcVCyhaFZr0cbWzjk8mF9HZNspIpqriAvFfOMjo+HW6JKZW+IF+wXNbS0oMVggJbNb113t0uM7MVEdF4EaZI2eZAXDaJ7qalwe1hSgmT2nNNfchHYNya5RUXC4nkgbc2esbeXg8+nRbQxEV1H/N+cXnAADX4Bo1ztMEwHgc8AAAAASUVORK5CYII="";
			|" + КлассРус + "1.Изображение = Ф.Картинка(СтрСтрелкаВлево);
			|";
		КонецЕсли;
		
		Если СвойствоРус = "ВыбраннаяВкладка" Тогда
			ТекстТеста = ТекстТеста + "
			|ПанельВкладок1.Вкладки.Добавить(Ф.Вкладка(""Вкладка1""));
			|ПанельВкладок1.Вкладки.Добавить(Ф.Вкладка(""Вкладка2""));
			|ПанельВкладок1.Вкладки.Добавить(Ф.Вкладка(""Вкладка3""));
			|ПанельВкладок1.ВыбраннаяВкладка = ПанельВкладок1.Вкладки.Элемент(1);
			|";
		КонецЕсли;
		
		ТекстТеста = ТекстТеста + "
		|Попытка";
		Если (СвойствоРус = "ИсточникДанных") и (КлассРус = "ПолеВыбора") Тогда
			ТекстТеста = ТекстТеста + "
			|		Сообщить(""ПолеВыбора1.ИсточникДанных = "" + ПолеВыбора1.ИсточникДанных + "" (Тип: "" + ПолеВыбора1.ИсточникДанных + "".)(Чтение и запись.)"");
			|";
		ИначеЕсли (СвойствоРус = "ИсточникДанных") и (КлассРус = "ПолеСписка") Тогда
			ТекстТеста = ТекстТеста + "
			|	Сообщить(""ПолеСписка1.ИсточникДанных = "" + ПолеСписка1.ИсточникДанных + "" (Тип: "" + ПолеСписка1.ИсточникДанных + "".)(Чтение и запись.)"");
			|";
		ИначеЕсли (СвойствоРус = "ВыбранноеЗначение") и (КлассРус = "ПолеВыбора") Тогда
			ТекстТеста = ТекстТеста + "
			|		Сообщить(""ПолеВыбора1.ВыбранноеЗначение = "" + ПолеВыбора1.ВыбранноеЗначение + "" (Тип: "" + ПолеВыбора1.ВыбранноеЗначение + "".)(Только чтение.)"");
			|";
		ИначеЕсли (СвойствоРус = "ВыбранноеЗначение") и (КлассРус = "ПолеСписка") Тогда
			ТекстТеста = ТекстТеста + "
			|		Сообщить(""ПолеСписка1.ВыбранноеЗначение = "" + ПолеСписка1.ВыбранноеЗначение + "" (Тип: "" + ПолеСписка1.ВыбранноеЗначение + "".)(Только чтение.)"");
			|";
		ИначеЕсли СвойствоРус = "КонтекстноеМеню" Тогда
			ТекстТеста = ТекстТеста + "
			|	КонтекстноеМеню1 = Ф.КонтекстноеМеню();
			|	ЭлементМеню1 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Первый элемент меню""));
			|	ЭлементМеню2 = КонтекстноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Второй элемент меню""));
			|	" + КлассРус + "1.КонтекстноеМеню = КонтекстноеМеню1;
			|	Сообщить(""" + КлассРус + "1.КонтекстноеМеню = "" + " + КлассРус + "1.КонтекстноеМеню + """ + " (" + ТипСвойства + ")(" + ИспользованиеСвойства + ")"");
			|";
		ИначеЕсли СвойствоРус = "СписокИзображений" Тогда
			ТекстТеста = ТекстТеста + "
			|    Стр = ""Qk02DAAAAAAAADYAAAAoAAAAIAAAACAAAAABABgAAAAAAAAMAAAAAAAAAAAAAAAAAAAAAAAA"";
			|    Для А = 1 По 1184 Цикл Стр = Стр + ""/""; КонецЦикла;
			|    Для А = 1 По 16 Цикл Стр = Стр + ""AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/AAD/////////////////////////////////////////////////////""; КонецЦикла;
			|    Для А = 1 По 864 Цикл Стр = Стр + ""/""; КонецЦикла;
			|    Картинка1 = Ф.Картинка(Стр);
			|    СписокИзображений1 = Ф.СписокИзображений();
			|    СписокИзображений1.РазмерИзображения = Ф.Размер(75, 50);
			|    " + КлассРус + "1.СписокИзображений = СписокИзображений1;
			|    Сообщить(""" + КлассРус + "1.СписокИзображений = "" + " + КлассРус + "1.СписокИзображений + """ + " (" + ТипСвойства + ")(" + ИспользованиеСвойства + ")"");
			|";
		ИначеЕсли СвойствоРус = "Стиль" и (КлассРус = "КартинкаЯчейки") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КартинкаЯчейки1.Стиль = СтильЯчейки1;
			|	
			|	Сообщить(""КартинкаЯчейки1.Стиль = "" + КартинкаЯчейки1.Стиль + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "Стиль" и (КлассРус = "КнопкаЯчейки") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КнопкаЯчейки1.Стиль = СтильЯчейки1;
			|	
			|	Сообщить(""КнопкаЯчейки1.Стиль = "" + КнопкаЯчейки1.Стиль + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "Стиль" и (КлассРус = "ФлажокЯчейки") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	ФлажокЯчейки1.Стиль = СтильЯчейки1;
			|	
			|	Сообщить(""ФлажокЯчейки1.Стиль = "" + ФлажокЯчейки1.Стиль + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "Стиль" и (КлассРус = "СсылкаЯчейки") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	СсылкаЯчейки1.Стиль = СтильЯчейки1;
			|	
			|	Сообщить(""СсылкаЯчейки1.Стиль = "" + СсылкаЯчейки1.Стиль + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "СтильЯчейки" и (КлассРус = "КолонкаКартинка") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КолонкаКартинка1.СтильЯчейки = СтильЯчейки1;
			|	
			|	Сообщить(""КолонкаКартинка1.СтильЯчейки = "" + КолонкаКартинка1.СтильЯчейки + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "СтильЯчейки" и (КлассРус = "КолонкаКнопка") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КолонкаКнопка1.СтильЯчейки = СтильЯчейки1;
			|	
			|	Сообщить(""КолонкаКнопка1.СтильЯчейки = "" + КолонкаКнопка1.СтильЯчейки + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "СтильЯчейки" и (КлассРус = "КолонкаПолеВвода") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КолонкаПолеВвода1.СтильЯчейки = СтильЯчейки1;
			|	
			|	Сообщить(""КолонкаПолеВвода1.СтильЯчейки = "" + КолонкаПолеВвода1.СтильЯчейки + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "СтильЯчейки" и (КлассРус = "КолонкаПолеВыбора") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КолонкаПолеВыбора1.СтильЯчейки = СтильЯчейки1;
			|	
			|	Сообщить(""КолонкаПолеВыбора1.СтильЯчейки = "" + КолонкаПолеВыбора1.СтильЯчейки + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "СтильЯчейки" и (КлассРус = "КолонкаСсылка") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КолонкаСсылка1.СтильЯчейки = СтильЯчейки1;
			|	
			|	Сообщить(""КолонкаСсылка1.СтильЯчейки = "" + КолонкаСсылка1.СтильЯчейки + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "СтильЯчейки" и (КлассРус = "КолонкаФлажок") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	КолонкаФлажок1.СтильЯчейки = СтильЯчейки1;
			|	
			|	Сообщить(""КолонкаФлажок1.СтильЯчейки = "" + КолонкаФлажок1.СтильЯчейки + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "Стиль" и (КлассРус = "ПолеВводаЯчейки") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	ПолеВводаЯчейки1.Стиль = СтильЯчейки1;
			|	
			|	Сообщить(""ПолеВводаЯчейки1.Стиль = "" + ПолеВводаЯчейки1.Стиль + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
		ИначеЕсли СвойствоРус = "Стиль" и (КлассРус = "ПолеВыбораЯчейки") Тогда
			ТекстТеста = ТекстТеста + "
			|	СтильЯчейки1 = Ф.СтильЯчейки();
			|	СтильЯчейки1.Выравнивание = Ф.ВыравниваниеСодержимогоЯчейки.ВерхПраво;
			|	СтильЯчейки1.ЦветФона = Ф.Цвет().Бирюзовый;
			|	ПолеВыбораЯчейки1.Стиль = СтильЯчейки1;
			|	
			|	Сообщить(""ПолеВыбораЯчейки1.Стиль = "" + ПолеВыбораЯчейки1.Стиль + "" (Тип: СтильЯчейки (DataGridViewCellStyle))(Чтение и запись.)"");
			|";
			
			
		Иначе
			Если (СтрНайти(ТипСвойства, "Произвольный") > 0) Тогда
				Если ИспользованиеСвойства = "Чтение и запись." Тогда
					ТекстТеста = ТекстТеста + "
					|	" + СтрКода1 + " = " + СтрКода1 + ";
					|	";
				ИначеЕсли ИспользованиеСвойства = "Только чтение." Тогда
				Иначе
					Сообщить("ИспользованиеСвойства = " + ИспользованиеСвойства);
					ЗавершитьРаботу(11);
				КонецЕсли;
				Если Не (ИмяПеречисления = "") Тогда
					ТекстТеста = ТекстТеста + "
					|	Сообщить(""" + СтрКода1 + " = "" + " + СтрКода1 + " + "" (Тип: " + ИмяПеречисления + ".)(" + ИспользованиеСвойства + ")"");
					|";
				Иначе
					ТекстТеста = ТекстТеста + "
					|	Сообщить(""" + СтрКода1 + " = "" + " + СтрКода1 + " + "" (Тип: "" + ТипЗнч(" + СтрКода1 + ") + "" ("" + ТипЗнч(" + СтрКода1 + ") + "").)(Только чтение.)"");
					|";
				КонецЕсли;
			Иначе
				Если ИспользованиеСвойства = "Чтение и запись." Тогда
					ТекстТеста = ТекстТеста + "
					|	" + СтрКода1 + " = " + СтрКода1 + ";
					|	";
				ИначеЕсли ИспользованиеСвойства = "Только чтение." Тогда
				Иначе
					Сообщить("ИспользованиеСвойства = " + ИспользованиеСвойства);
					ЗавершитьРаботу(11);
				КонецЕсли;
				ТекстТеста = ТекстТеста + "
				|	Сообщить(""" + СтрКода1 + " = "" + " + СтрКода1 + " + "" (" + ТипСвойства + ")(" + ИспользованиеСвойства + ")"");
				|";
			КонецЕсли;
		КонецЕсли;
		ТекстТеста = ТекстТеста + "
		|Исключение НекорректныеСвойства.Добавить(""" + СвойствоРусАнгл + """); КонецПопытки;
		|";
		
	КонецЦикла;
	Возврат МассивСвойств;
КонецФункции//СвойстваТест

Функция МассивСвойств(ИмяФайлаЧленов)
	М = Новый Массив;
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ИмяФайлаЧленов);
	Стр = ТекстДок.ПолучитьТекст();
	СтрТаблица = СтрНайтиМежду(Стр, "<H4 class=dtH4>Свойства</H4>", "</TBODY></TABLE>", Ложь, );
	
	Если СтрТаблица.Количество() = 0 Тогда
		Возврат М;
	КонецЕсли;
	
	М2 = СтрНайтиМежду(СтрТаблица[0], "pubproperty.gif", "</TD>", Ложь, );
	Для А = 0 По М2.ВГраница() Цикл
		Если Не (СтрНайти(М2[А], "унаследовано") > 0) Тогда
			Продолжить;
		КонецЕсли;
		
		ФайлСвойства = СтрНайтиМежду(М2[А], "<A href=""OneScriptForms.", ".html"">", , );
		ФайлСвойства = КаталогСправки + "\OneScriptFormsru\OneScriptForms." + ФайлСвойства[0] + ".html";
		
		СтрХ = М2[А];
		СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
		СвойствоАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
		СвойствоРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
		
		М1 = Новый Массив;
		М1.Добавить(ФайлСвойства);
		М1.Добавить(СвойствоАнгл);
		М1.Добавить(СвойствоРус);
		М1.Добавить(СвойствоРус + " (" + СвойствоАнгл + ")");
		М.Добавить(М1);
	КонецЦикла;
	Возврат М;
КонецФункции//МассивСвойств

Функция МетодыТест(ИмяФайлаЧленов, КлассРус, КлассАнгл)
	МассивМетодов = МассивМетодов(ИмяФайлаЧленов);
	Если МассивМетодов.Количество() > 0 Тогда
		Для А = 0 По МассивМетодов.ВГраница() Цикл
			ФайлМетода   = МассивМетодов[А][0];
			МетодАнгл    = МассивМетодов[А][1];
			МетодРус     = МассивМетодов[А][2];
			МетодРусАнгл = МассивМетодов[А][3];
			
			Если (МетодРус = "ОбновитьСтили") или (МетодРус = "УстановитьСтиль") или (МетодРус = "ПолучитьСтиль") Тогда
				Продолжить;
			КонецЕсли;
			
			Параметры = Параметры(ФайлМетода);
			ВозвращаемоеЗначение = ВозвращаемоеЗначение(ФайлМетода);
			
			Если Параметры = "" Тогда // параметров нет (588 шт)
				Сч1 = Сч1 + 1;
				
				СтрКода4 = "" + КлассРус + "1." + МетодРус + "()";
				Если ВозвращаемоеЗначение = "" Тогда // параметров нет, возвращаемого значения нет (522 шт)======================================
					Сч2 = Сч2 + 1;
					
					Если МетодРус = "Освободить" Тогда
						Продолжить;
					КонецЕсли;
					
					ТекстТеста = ТекстТеста + "
					|Попытка";
					
					// пересоздадим объект для другого метода
					ТекстТеста = ТекстТеста + "
					|    " + СтрСозданияОбъекта2;
					
					// выполним другой метод
					ТекстТеста = ТекстТеста + "
					|    " + СтрКода4 + ";";
					
					ТекстТеста = ТекстТеста + "
					|	Сообщить(""" + СтрКода4 + ";;"");
					
					|Исключение НекорректныеМетоды.Добавить(""" + МетодРусАнгл + """); КонецПопытки;
					|";
				Иначе // параметров нет, возвращаемое значение есть (66 шт)=====================================================================
					Сч3 = Сч3 + 1;
					// нужно пропустить диалоги,так как они требуют интерактивных действий, их проверить вручную
					
					ТекстТеста = ТекстТеста + "
					|Попытка";
					
					// пересоздадим объект для другого метода
					ТекстТеста = ТекстТеста + "
					|    " + СтрСозданияОбъекта2 + "
					|";
					
					Если ВозвращаемоеЗначение = "Тип: Строка." Тогда
						ТипВозврата = "Строка";
					ИначеЕсли ВозвращаемоеЗначение = "Тип: Число." Тогда
						ТипВозврата = "Число";
					ИначеЕсли ВозвращаемоеЗначение = "Тип: Булево." Тогда
						ТипВозврата = "Булево";
					ИначеЕсли СтрНайти(ВозвращаемоеЗначение, "Тип: <A href=") > 0 Тогда
						// Тип: <A href="OneScriptForms.Graphics.html">Графика&nbsp;(Graphics)</A>.
						Массив1 = СтрНайтиМежду(ВозвращаемоеЗначение, ">", "(", , );
						ТипВозврата = СтрЗаменить(Массив1[0], "&nbsp;", "");
						ТипВозвратаРус = "Кл" + СтрНайтиМежду(ВозвращаемоеЗначение, ">", "&nbsp;", , )[0];
						ТипВозвратаАнгл = "Cl" + СтрНайтиМежду(ВозвращаемоеЗначение, "(", ")", , )[0];
					Иначе
						ТипВозврата = "НеПонятноЧто";
					КонецЕсли;
					
					Если СтрНайти(ВозвращаемоеЗначение, "Тип: <A href=") > 0 Тогда
						Если (МетодРус = "ПолучитьГлавноеМеню") и (КлассРус = "ЭлементМеню" или КлассРус = "КонтекстноеМеню") Тогда
							ТекстТеста = ТекстТеста + "
							|	Если " + СтрКода4 + " = Неопределено Тогда
							|	Иначе
							|		НекорректныеМетоды.Добавить(""" + СтрКода4 + """);
							|	КонецЕсли;";
						КонецЕсли;
					Иначе
						ТекстТеста = ТекстТеста + "
						|	Если """" + " + СтрКода4 + " = """ + ТипВозвратаРус + """ Тогда
						|	Иначе
						|		НекорректныеМетоды.Добавить(""" + СтрКода4 + """);
						|	КонецЕсли;";
					КонецЕсли;
					
					ТекстТеста = ТекстТеста + "
					|	Сообщить(""" + СтрКода4 + ";;"");
					|";
					
					ТекстТеста = ТекстТеста + "
					|Исключение НекорректныеМетоды.Добавить(""" + МетодРусАнгл + """); КонецПопытки;
					|";
				КонецЕсли;
			Иначе // параметры есть (358 шт)
				Сч4 = Сч4 + 1;
				Если ВозвращаемоеЗначение = "" Тогда // параметры есть, возвращаемого значения нет (157 шт)=============================
					Сч5 = Сч5 + 1;
					
					ТекстТеста = ТекстТеста + "
					|Попытка";
					
					// пересоздадим объект для другого метода
					ТекстТеста = ТекстТеста + "
					|    " + СтрСозданияОбъекта2 + "
					|";

					М10 = СтрНайтиМежду(Параметры, "<DD>", "</DD>", , );
					Для А5 = 0 По М10.ВГраница() Цикл
						СтрУстановкиПараметров = "";
						ТипПараметра1 = М10[А5];
						Если СтрНайти(ТипПараметра1, "Тип: ") > 0 Тогда
							ТипПараметра1 = СтрЗаменить(ТипПараметра1, "Тип: ", "");
						КонецЕсли;
					КонецЦикла;
					
					М_Параметр = СтрНайтиМежду(Параметры, "<DT><I>", "</DD>", Ложь, );
					
					СтрПараметровВсех = "(";
					СтрПараметровОбязательных = "(";
					Для А6 = 0 По М_Параметр.ВГраница() Цикл
						М07 = СтрНайтиМежду(М_Параметр[А6], "<DT><I>", "</DT>", , );
						М06 = СтрНайтиМежду(М_Параметр[А6], "<DT><I>", "</I>", , );
						М05 = СтрНайтиМежду(М_Параметр[А6], "<DD>", "</DD>", , );
						ТипПараметра = М05[0];
						ПараметрВСкобки = М06[0];
						Если ПараметрВСкобки = "Формат" Тогда
							СписокИменПараметров.Добавить("" + ПараметрВСкобки + " -- " + КлассРус + "." + МетодРус + "()");
						КонецЕсли;
						СтрУстановкиПараметра = "";
											
						Если ТипПараметра = "Тип: Строка." Тогда
							СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = ""Произвольный текст"";" + Символы.ПС;
						ИначеЕсли ТипПараметра = "Тип: Число." Тогда
							Если (МетодРус = "УдалитьПоИндексу") и (КлассРус = "Колонки") Тогда
								ТекстТеста = ТекстТеста + "
								|	Колонки1 = СписокЭлементов1.Колонки;
								|	Колонки1.Добавить(Ф.Колонка(""А1"", 40, 1));
								|	Колонки1.Добавить(Ф.Колонка(""А2"", 40, 1));
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "КолонкиТаблицы") Тогда
								ТекстТеста = ТекстТеста + "
								|	Для А = 0 По 25 Цикл
								|		Таблица1.Колонки.Добавить(Ф.КолонкаПолеВвода());
								|		Таблица1.Колонки(А).ТекстЗаголовка = ""Кол"" + А;
								|	КонецЦикла;
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "КнопкиПанелиИнструментов") Тогда
								ТекстТеста = ТекстТеста + "
								|	КнопкиПанелиИнструментов1.Добавить(Ф.КнопкаПанелиИнструментов(""КнопкаПанелиИнструментов1""));
								|	КнопкиПанелиИнструментов1.Добавить(Ф.КнопкаПанелиИнструментов(""КнопкаПанелиИнструментов2""));
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "СтилиКолонкиСеткиДанных") Тогда
								ТекстТеста = ТекстТеста + "
								|	СтилиКолонкиСеткиДанных1.Добавить(Ф.СтильКолонкиПолеВвода());
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "СтилиТаблицыСеткиДанных") Тогда
								ТекстТеста = ТекстТеста + "
								|	СтилиТаблицыСеткиДанных1.Добавить(Ф.СтильТаблицыСеткиДанных());
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ПанелиСтрокиСостояния") Тогда
								ТекстТеста = ТекстТеста + "
								|	ПанелиСтрокиСостояния1.Добавить(Ф.ПанельСтрокиСостояния());
								|	ПанелиСтрокиСостояния1.Добавить(Ф.ПанельСтрокиСостояния());
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "УзлыДерева") Тогда
								ТекстТеста = ТекстТеста + "
								|	УзлыДерева1.Добавить(Ф.УзелДерева(""Корень""));
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ЭлементыМеню") Тогда
								ТекстТеста = ТекстТеста + "
								|	Элемент = ЭлементыМеню1.Добавить(Ф.ЭлементМеню(""1 действие""));
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ЭлементыПоляВыбора") Тогда
								ТекстТеста = ТекстТеста + "
								|	ЭлементыПоляВыбора1.Добавить(""Строка1"");
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ЭлементыПоляСписка") Тогда
								ТекстТеста = ТекстТеста + "
								|	ЭлементыПоляСписка1.Добавить(""Строка66"");
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ЭлементыСпискаЭлементов") Тогда
								ТекстТеста = ТекстТеста + "
								|	ЭлементыСпискаЭлементов1.Добавить(Ф.ЭлементСпискаЭлементов(""Зеленоград"", 1));
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ЭлементыУправления") Тогда
								ТекстТеста = ТекстТеста + "
								|	Форма1.ЭлементыУправления.Добавить(Ф.Кнопка());
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ВыбранныеЭлементыСпискаЭлементов") Тогда
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "Изображения") Тогда
								ТекстТеста = ТекстТеста + "
								|	СтрЗначок7 = ""AAABAAEAICAAAAEAIACoEAAAFgAAACgAAAAgAAAAQAAAAAEAIAAAAAAAABAAABMLAAATCwAAAAAAAAAAAAD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AAAAAAUAAAAIAAAADQAAABQAAAAbAAAAIgAAACgAAAAsAAAAMAAAADMAAAA0AAAANQAAADUAAAA1AAAANQAAADUAAAA1AAAANQAAADUAAAA1AAAANQAAADQAAAAzAAAAMAAAACwAAAAoAAAAIgAAABsAAAAUAAAADQAAAAgAAAAFAAAACQAAABIAAAAbAAAAJhISEqsVFRX/FRUV/xUVFf8VFRX/FRUV/3Nzc/9zc3P/c3Nz/3Nzc/9zc3P/c3Nz/3Nzc/9zc3P/c3Nz/3Nzc/9zc3P/c3Nz/3Nzc/9zc3P/c3Nz/3Nzc/9zc3P/ampqxlZWVmgAAAAbAAAAEgAAAAkAAAADAAAABQAAAAgAAAAMFRUV/2NjY/8vLy//Ly8v/y8vL/8VFRX/1NTU/9DQ0P/T09P/1dXV/83Nzf/W1tb/0dHR/9bW1v/W1tb/1NTU/9bW1v/Pz8//0dHR/9XV1f/T09P/0dHR/9bW1v+6urr/cnJyugAAAAgAAAAFAAAAA////wD///8A////AP///wAVFRX/ZGRk/ywsLP8sLCz/MDAw/xUVFf/V1dX/0NDQ/9DQ0P/Kysr/y8vL/9LS0v/Ly8v/yMjI/8zMzP/R0dH/ycnJ/9HR0f/Pz8//0NDQ/8vLy//MzMz/zs7O/9TU1P91dXX/////AP///wD///8A////AP///wD///8A////ABUVFf9lZWX/LS0t/y0tLf8xMTH/FRUV/9fX1//R0dH/0dHR/8/Pz//MzMz/zc3N/9DQ0P/Ozs7/09PT/83Nzf/MzMz/zMzM/8rKyv/MzMz/ycnJ/8vLy//R0dH/1NTU/3V1df////8A////AP///wD///8A////AP///wAAAAAOEhIS/1BQUP8eHh7/Kysr/zExMf8VFRX/19fX/8vLy//Ly8v/0tLS/8rKyv/Nzc3/0dHR/8vLy//T09P/zc3N/8vLy//S0tL/y8vL/8/Pz//S0tL/0tLS/8rKyv/Pz8//dnZ2/////wD///8A////AP///wD///8A////AAAAAES4oZH/2sm8//////8fHx//MzMz/xUVFf/Q0ND/y8vL/9XV1f/U1NT/zs7O/8vLy//U1NT/zMzM/8zMzP/Q0ND/0dHR/8zMzP/T09P/0dHR/9HR0f/V1dX/z8/P/9bW1v93d3f/////AP///wD///8A////AP///wD///8Ae2hZ/7ihkf/aybz//////yAgIP80NDT/FRUV/9XV1f/Pz8//1NTU/9PT0//X19f/0NDQ/9bW1v/X19f/09PT/9DQ0P/S0tL/19fX/9fX1//R0dH/0dHR/9bW1v/W1tb/1dXV/3h4eP////8A////AP///wD///8A////AP///wB7aFn/Dg4O/1JSUv8oKCj/LS0t/zU1Nf8VFRX/3Nzc/9PT0//R0dH/1dXV/9fX1//Q0ND/1tbW/9TU1P/Q0ND/09PT/9LS0v/R0dH/1dXV/9PT0//X19f/19fX/9fX1//W1tb/eXl5/////wD///8A////AP///wD///8A////AAAAABsUFBT/aGho/zExMf8xMTH/NjY2/xUVFf/W1tb/1NTU/9DQ0P/X19f/1dXV/9PT0//X19f/19fX/9PT0//Z2dn/0tLS/8/Pz//T09P/z8/P/9PT0//T09P/0tLS/9vb2/96enr/////AP///wD///8A////AP///wD///8AAAAADhISEv9TU1P/IiIi/y8vL/83Nzf/FRUV/93d3f/b29v/09PT/9bW1v/b29v/09PT/9fX1//a2tr/2tra/9nZ2f/V1dX/1dXV/9LS0v/R0dH/1dXV/9PT0//U1NT/1tbW/3t7e/////8A////AP///wD///8A////AP///wAAAABEuKGR/9rJvP//////IiIi/zg4OP8VFRX/2tra/9jY2P/Z2dn/2dnZ/9zc3P/S0tL/29vb/9ra2v/Z2dn/3Nzc/9PT0//Z2dn/2tra/9ra2v/Z2dn/0tLS/9PT0//d3d3/fX19/////wD///8A////AP///wD///8A////AHtoWf+4oZH/2sm8//////8jIyP/OTk5/xUVFf/X19f/3Nzc/9nZ2f/T09P/3Nzc/9TU1P/d3d3/1tbW/9ra2v/W1tb/x8fH/9HR0f/U1NT/zs7O/87Ozv/R0dH/1NTU/+Dg4P9+fn7/////AP///wD///8A////AP///wD///8Ae2hZ/w4ODv9UVFT/LCws/zIyMv86Ojr/FRUV/9nZ2f/Y2Nj/19fX/93d3f/a2tr/2NjY/9jY2P/e3t7/19fX/8rKyv+tra3/t7e3/8rKyv+4uLj/qamp/8fHx//Y2Nj/4eHh/39/f/////8A////AP///wD///8A////AP///wAAAAAbFBQU/2xsbP82Njb/NjY2/zs7O/8VFRX/29vb/9bW1v/Z2dn/3Nzc/9zc3P/a2tr/3t7e/9bW1v/a2tr/vLy8/wAEfP+SkpL/pqam/4+Pj/8ABHz/vLy8/93d3f/c3Nz/gICA/////wD///8A////AP///wD///8A////AAAAAA4SEhL/VlZW/yUlJf80NDT/PDw8/xUVFf/f39//2tra/97e3v/b29v/2dnZ/93d3f/b29v/3t7e/+Dg4P/CwsL/AQaA/wAEfP96enr/AAR8/wEGgP++vr7/2tra/+Dg4P+BgYH/////AP///wD///8A////AP///wD///8AAAAARLihkf/aybz//////yYmJv89PT3/FRUV/9/f3//j4+P/4+Pj/+Hh4f/f39//3t7e/+Pj4//j4+P/29vb/8TExP8CCIb/Ji+5/wAEfP8mL7n/AgiG/8TExP/d3d3/4ODg/4KCgv////8A////AP///wD///8A////AP///wB7aFn/uKGR/9rJvP//////JiYm/z8/P/8VFRX/5+fn/+Dg4P/f39//3Nzc/9vb2//h4eH/29vb/93d3f/b29v/w8PD/wQKjP8cJ7n/HCe5/xwnuf8ECoz/x8fH/+Li4v/f39//hISE/////wD///8A////AP///wD///8A////AHtoWf8ODg7/WFhY/zExMf83Nzf/QEBA/xUVFf/k5OT/4+Pj/+Tk5P/e3t7/5OTk/+Hh4f/j4+P/3t7e/+Li4v/Hx8f/BQ2T/yEuwP8LGbr/IS7A/wUNk//BwcH/5ubm/9/f3/+FhYX/////AP///wD///8A////AP///wD///8AAAAAGxQUFP9xcXH/Ozs7/zs7O/9BQUH/FRUV/+Pj4//e3t7/3d3d/93d3f/m5ub/39/f/+Tk5P/e3t7/3t7e/8PDw/8HD5v/JjTI/xEgwv8mNMj/Bw+b/8XFxf/k5OT/5ubm/4aGhv////8A////AP///wD///8A////AP///wAAAAAOEhIS/1lZWf8oKCj/OTk5/0JCQv8VFRX/4+Pj/+jo6P/m5ub/6Ojo/9/f3//j4+P/4ODg/+fn5//l5eX/yMjI/wkTpP8sOtD/FyfL/yw60P8JE6T/yMjI/+Li4v/i4uL/h4eH/////wD///8A////AP///wD///8A////AAAAAES4oZH/2sm8//////8pKSn/Q0ND/xUVFf/r6+v/4eHh/+Hh4f/g4OD/6urq/+bm5v/l5eX/5eXl/+np6f/Kysr/Cxas/zJC2P8eL9T/MkLY/wsWrP/Ly8v/4+Pj/+bm5v+IiIj/////AP///wD///8A////AP///wD///8Ae2hZ/7ihkf/aybz//////ykpKf9DQ0P/FRUV/+np6f/r6+v/5eXl/+Pj4//o6Oj/4+Pj/+Hh4f/j4+P/6urq/8rKyv8NGbX/OEnh/yQ33v84SeH/DRm1/8rKyv/i4uL/6enp/4mJif////8A////AP///wD///8A////AP///wB7aFn/Dg4O/1tbW/80NDT/Ozs7/0RERP8VFRX/7e3t/+Li4v/p6en/6+vr/+Li4v/k5OT/5+fn/+zs7P/q6ur/y8vL/w8bvf89UOj/Kj/m/z1Q6P8PG73/x8fH/+Tk5P/m5ub/ioqK/////wD///8A////AP///wD///8A////AAAAABsUFBT/dHR0/z8/P/8/Pz//RUVF/xUVFf/r6+v/6Ojo/+jo6P/j4+P/5ubm/+vr6//l5eX/4+Pj/+jo6P/MzMz/EB7E/0NW8P8wRe7/Q1bw/xAexP/Jycn/5OTk/+jo6P+Kior/////AP///wD///8A////AP///wD///8A////ABUVFf90dHT/Pz8//z8/P/9FRUX/FRUV/+jo6P/q6ur/6+vr/+zs7P/o6Oj/5ubm/+jo6P/t7e3/7e3t/8/Pz/8SIcr/Rlv1/0Zb9f9GW/X/EiHK/9XV1f/s7Oz/6urq/4uLi/////8A////AP///wD///8A////AP///wD///8AFRUV/4KCgv9YWFj/WFhY/1hYWP8VFRX/7+/v//Ly8v/u7u7/8vLy//Ly8v/v7+//8vLy//Dw8P/v7+//7Ozs/xMj0P+dqfz/nan8/52p/P8TI9D/6Ojo//T09P/Y2Nj/jIyMvf///wD///8A////AP///wD///8A////AP///wAVFRX/FRUV/xUVFf8VFRX/FRUV/xUVFf+MjIz/jIyM/4yMjP+MjIz/jIyM/4yMjP+MjIz/jIyM/4yMjP+MjIz/FCTU/xQk1P8UJNT/FCTU/xQk1P+MjIz/jIyM/4yMjP+MjIxU////AP///wD///8A////AP///wD///8A////ABUVFf9ra2z/rq6v/93d3f////////////////////////////////////////////////////////////////////////////////////////////j4+P/Ozs7/jIyMvQAAAAD///8A////AP///wD///8A////AP///wD///8AFRUVVBUVFf8VFRX/HR0d/zg4OP9aWlr/enp6/4yMjP+MjIz/jIyM/4yMjP+MjIz/jIyM/4yMjP+MjIz/jIyM/4yMjP+MjIz/jIyM/4yMjP+MjIz/jIyM/4yMjL2MjIxU////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A////AP///wD///8A/////wAAAAAAAAAAAAAAAPAAAAfwAAAH4AAAB+AAAAfgAAAH4AAAB+AAAAfgAAAH4AAAB+AAAAfgAAAH4AAAB+AAAAfgAAAH4AAAB+AAAAfgAAAH4AAAB+AAAAfgAAAH4AAAB+AAAAfwAAAH8AAAB/AAAAfwAAAP8AAAD/////8="";
								|	Значок7 = Ф.Значок(СтрЗначок7);
								|	Рисунок7 = Значок7.ВКартинку();
								|	Изображения1.Добавить(Рисунок7, Ф.Цвет().Зеленый);
								|";
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							ИначеЕсли (МетодРус = "УдалитьПоИндексу") и (КлассРус = "ПодэлементыСпискаЭлементов") Тогда
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 0;" + Символы.ПС;
							Иначе
								СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 20;" + Символы.ПС;
							КонецЕсли;
						ИначеЕсли ТипПараметра = "Тип: Булево." Тогда
							СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = Истина;" + Символы.ПС;
						ИначеЕсли СтрНайти(ТипПараметра, "Тип: <A href=") > 0 Тогда
						ИначеЕсли ТипПараметра = "Тип: Произвольный." Тогда
							Если (МетодРус = "СлитьМеню") и (КлассРус = "ГлавноеМеню" или КлассРус = "КонтекстноеМеню") Тогда
								ТекстТеста = ТекстТеста + 
								"	ГлавноеМеню1 = Ф.ГлавноеМеню();
								|	Г1М1 = ГлавноеМеню1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Г1М1""));
								|	// создадим второе меню
								|	Меню = Ф.КонтекстноеМеню();
								|	Г2М1 = Меню.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Г2М1""));
								|	
								|	ГлавноеМеню1.СлитьМеню(Меню);
								|	Если ГлавноеМеню1.ЭлементыМеню.Количество <> 2 Тогда
								|		ВызовемОшибку = 10/0;
								|	КонецЕсли;
								|";
							ИначеЕсли (МетодРус = "Выше") или (МетодРус = "Ниже") или (МетодРус = "Левее") или (МетодРус = "Правее") Тогда
								ТекстТеста = ТекстТеста + 
								"	ЭлементУправления = Форма1.ЭлементыУправления.Добавить(Ф.Кнопка());
								|	ЭлементУправления.Центр();
								|";
							КонецЕсли;
						ИначеЕсли СтрНайти(ТипПараметра, ";") > 0 Тогда // параметр может быть разных типов
							Если СтрНайти(ТипПараметра, "Строка; <A href=""OneScriptForms.Stream.html"">Поток&nbsp;(Stream)</A>.") > 0 Тогда
									ТекстТеста = ТекстТеста + 
									"	Параметр1 = Ф.Поток();
									|	ФорматИзображения = Ф.ФорматИзображения().Jpeg;
									|";
							КонецЕсли;
						КонецЕсли;
						
						СтрУстановкиПараметров = СтрУстановкиПараметров + СтрУстановкиПараметра;
						
						Если СтрНайти(М07[0], "(обязательный)") > 0 Тогда
							СтрПараметровОбязательных = СтрПараметровОбязательных + ПараметрВСкобки;
							СтрПараметровВсех = СтрПараметровВсех + ПараметрВСкобки;
						Иначе
							СтрПараметровВсех = СтрПараметровВсех + ПараметрВСкобки;
						КонецЕсли;
						
						Если А6 = М_Параметр.ВГраница() Тогда
							СтрПараметровОбязательных = СтрПараметровОбязательных;
							СтрПараметровВсех = СтрПараметровВсех;
						Иначе
							СтрПараметровОбязательных = СтрПараметровОбязательных + ", ";
							СтрПараметровВсех = СтрПараметровВсех + ", ";
						КонецЕсли;
					КонецЦикла;	
					СтрПараметровВсех = СтрПараметровВсех + ")";
					СтрПараметровОбязательных = СтрПараметровОбязательных + ")";
					СтрМетодаСоВсемиПараметрами = "" + КлассРус + "1." + МетодРус + СтрПараметровВсех;
					СтрМетодаСОбязательнымиПараметрами = "" + КлассРус + "1." + МетодРус + СтрПараметровОбязательных;
					ТекстТеста = ТекстТеста + СтрУстановкиПараметров;
					
					Если СтрМетодаСоВсемиПараметрами = СтрМетодаСОбязательнымиПараметрами Тогда
						ТекстТеста = ТекстТеста + Символы.Таб + СтрМетодаСоВсемиПараметрами + ";";
						ТекстТеста = ТекстТеста + "
						|	Сообщить(""" + СтрМетодаСоВсемиПараметрами + ";;"");
						|";
					Иначе
						ТекстТеста = ТекстТеста + Символы.Таб + СтрМетодаСоВсемиПараметрами + ";" + Символы.ПС;
						ТекстТеста = ТекстТеста + Символы.Таб + СтрМетодаСОбязательнымиПараметрами + ";";
						ТекстТеста = ТекстТеста + "
						|	Сообщить(""" + СтрМетодаСоВсемиПараметрами + ";;"");
						|	Сообщить(""" + СтрМетодаСОбязательнымиПараметрами + ";;"");
						|";
					КонецЕсли;
					
					ТекстТеста = ТекстТеста + "
					|Исключение НекорректныеМетоды.Добавить(""" + МетодРусАнгл + """); КонецПопытки;
					|";
					
				Иначе // параметры есть, возвращаемое значение есть (201 шт)=====================================================================
					Сч6 = Сч6 + 1;
					
					ТекстТеста = ТекстТеста + "
					|Попытка";

					// пересоздадим объект для другого метода
					ТекстТеста = ТекстТеста + "
					|    " + СтрСозданияОбъекта2 + "
					|";

					М10 = СтрНайтиМежду(Параметры, "<DD>", "</DD>", , );
					Для А5 = 0 По М10.ВГраница() Цикл
						СтрУстановкиПараметров = "";
						ТипПараметра1 = М10[А5];
						Если СтрНайти(ТипПараметра1, "Тип: ") > 0 Тогда
							ТипПараметра1 = СтрЗаменить(ТипПараметра1, "Тип: ", "");
						КонецЕсли;
					КонецЦикла;
					
					М_Параметр = СтрНайтиМежду(Параметры, "<DT><I>", "</DD>", Ложь, );
					
					СтрПараметровВсех = "(";
					СтрПараметровОбязательных = "(";
					Для А6 = 0 По М_Параметр.ВГраница() Цикл
						М07 = СтрНайтиМежду(М_Параметр[А6], "<DT><I>", "</DT>", , );
						М06 = СтрНайтиМежду(М_Параметр[А6], "<DT><I>", "</I>", , );
						М05 = СтрНайтиМежду(М_Параметр[А6], "<DD>", "</DD>", , );
						ТипПараметра = М05[0];
						ПараметрВСкобки = М06[0];
						Если ПараметрВСкобки = "Формат" Тогда
							СписокИменПараметров.Добавить("" + ПараметрВСкобки + " -- " + КлассРус + "." + МетодРус + "()");
						КонецЕсли;
						СтрУстановкиПараметра = "";
											
						Если ТипПараметра = "Тип: Строка." Тогда
							СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = ""Произвольный текст"";" + Символы.ПС;
						ИначеЕсли ТипПараметра = "Тип: Число." Тогда
							СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = 20;" + Символы.ПС;
						ИначеЕсли ТипПараметра = "Тип: Булево." Тогда
							СтрУстановкиПараметра = СтрУстановкиПараметра + Символы.Таб + ПараметрВСкобки + " = Истина;" + Символы.ПС;
						ИначеЕсли СтрНайти(ТипПараметра, "Тип: <A href=") > 0 Тогда
						ИначеЕсли СтрНайти(ТипПараметра, ";") > 0 Тогда // параметр может быть разных типов
							Сообщить("Не сформирована СтрУстановкиПараметра. - " + ТипПараметра);
							ЗавершитьРаботу(46);
						КонецЕсли;
						
						СтрУстановкиПараметров = СтрУстановкиПараметров + СтрУстановкиПараметра;
						
						Если СтрНайти(М07[0], "(обязательный)") > 0 Тогда
							СтрПараметровОбязательных = СтрПараметровОбязательных + ПараметрВСкобки;
							СтрПараметровВсех = СтрПараметровВсех + ПараметрВСкобки;
						Иначе
							СтрПараметровВсех = СтрПараметровВсех + ПараметрВСкобки;
						КонецЕсли;
						
						Если А6 = М_Параметр.ВГраница() Тогда
							СтрПараметровОбязательных = СтрПараметровОбязательных;
							СтрПараметровВсех = СтрПараметровВсех;
						Иначе
							СтрПараметровОбязательных = СтрПараметровОбязательных + ", ";
							СтрПараметровВсех = СтрПараметровВсех + ", ";
						КонецЕсли;
					КонецЦикла;	
					СтрПараметровВсех = СтрПараметровВсех + ")";
					СтрПараметровОбязательных = СтрПараметровОбязательных + ")";
					СтрМетодаСоВсемиПараметрами = "" + КлассРус + "1." + МетодРус + СтрПараметровВсех;
					СтрМетодаСОбязательнымиПараметрами = "" + КлассРус + "1." + МетодРус + СтрПараметровОбязательных;
					ТекстТеста = ТекстТеста + СтрУстановкиПараметров;
					
					Если ВозвращаемоеЗначение = "Тип: Строка." Тогда
						ТипВозврата = "Строка";
					ИначеЕсли ВозвращаемоеЗначение = "Тип: Число." Тогда
						ТипВозврата = "Число";
					ИначеЕсли ВозвращаемоеЗначение = "Тип: Булево." Тогда
						ТипВозврата = "Булево";
					ИначеЕсли СтрНайти(ВозвращаемоеЗначение, "Тип: <A href=") > 0 Тогда
						Массив1 = СтрНайтиМежду(ВозвращаемоеЗначение, ">", "(", , );
						ТипВозврата = СтрЗаменить(Массив1[0], "&nbsp;", "");
						ТипВозвратаРус = "Кл" + СтрНайтиМежду(ВозвращаемоеЗначение, ">", "&nbsp;", , )[0];
						ТипВозвратаАнгл = "Cl" + СтрНайтиМежду(ВозвращаемоеЗначение, "(", ")", , )[0];
					Иначе
						ТипВозврата = "НеПонятноЧто";
					КонецЕсли;
					Если (МетодРус = "ЭлементУправления") или (МетодРус = "ЭлементыУправления") Тогда
						ТекстТеста = ТекстТеста + "
						|	Для А = 0 По 20 Цикл
						|		" + КлассРус + "1.ЭлементыУправления.Добавить(Ф.Кнопка());
						|	КонецЦикла;
						|";
						ТипВозвратаРус = "КлКнопка";
					КонецЕсли;
					Если МетодРус = "НайтиЭлемент" Тогда
						ТекстТеста = ТекстТеста + "
						|	Кнопка3 = Ф.Кнопка();
						|	Кнопка3.Имя = ""Имя элемента"";
						|	Кнопка4 = Ф.Кнопка();
						|	Кнопка4.Имя = ""Имя элемента4"";
						|	" + КлассРус + "1.ЭлементыУправления.Добавить(Кнопка3);
						|	" + КлассРус + "1.ЭлементыУправления.Добавить(Кнопка4);
						|	Имя = ""Имя элемента4"";
						|";
						ТипВозвратаРус = "КлКнопка";
					КонецЕсли;
					Если МетодРус = "СледующийЭлемент" Тогда
						ТекстТеста = ТекстТеста + "
						|	Кнопка10 = " + КлассРус + "1.ЭлементыУправления.Добавить(Ф.Кнопка());
						|	Кнопка11 = " + КлассРус + "1.ЭлементыУправления.Добавить(Ф.Кнопка());
						|	ЭлементУправления = Кнопка10;
						|	
						|";
						ТипВозвратаРус = "КлКнопка";
					КонецЕсли;
					Если МетодРус = "ДочернийПоКоординатам" Тогда
						Если КлассРус = "Форма" Тогда
							ТекстТеста = ТекстТеста + "
							|	Форма1.СостояниеОкна = Ф.СостояниеОкнаФормы.Развернутое;
							|	
							|	Кнопка10 = " + КлассРус + "1.ЭлементыУправления.Добавить(Ф.Кнопка());
							|	Кнопка10.Положение = Ф.Точка(" + КлассРус + "1.Границы.Икс + 10, " + КлассРус + "1.Границы.Игрек + 10);
							|	ТочкаПоиска = Ф.Точка(" + КлассРус + "1.Границы.Икс + 11, " + КлассРус + "1.Границы.Игрек + 11);
							|	
							|";
						Иначе
							ТекстТеста = ТекстТеста + "
							|	Форма1.СостояниеОкна = Ф.СостояниеОкнаФормы.Развернутое;
							|	
							|	Кнопка10 = " + КлассРус + "1.ЭлементыУправления.Добавить(Ф.Кнопка());
							|	Кнопка10.Положение = Ф.Точка(" + КлассРус + "1.Границы.Икс + 1, " + КлассРус + "1.Границы.Игрек + 1);
							|	ТочкаПоиска = Ф.Точка(" + КлассРус + "1.Границы.Икс + 1, " + КлассРус + "1.Границы.Игрек + 1);
							|	
							|";
						КонецЕсли;
						ТипВозвратаРус = "КлКнопка";
					КонецЕсли;
					Если МетодРус = "ТочкаНаКлиенте" Тогда
						ТекстТеста = ТекстТеста + "
						|	Форма1.СостояниеОкна = Ф.СостояниеОкнаФормы.Стандартное;
						|	Точка = Ф.Точка(100, 100);
						|	
						|";
						ТипВозвратаРус = "КлТочка";
					КонецЕсли;
					Если МетодРус = "ЭлементМеню" Тогда
						ТекстТеста = ТекстТеста + "
						|	Подменю_Файл = " + КлассРус + "1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Файл""));
						|	Подменю_Справка  = " + КлассРус + "1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Справка""));
						|	Индекс = 0;
						|	
						|";
						ТипВозвратаРус = "КлЭлементМеню";
					КонецЕсли;
					Если МетодРус = "ЭлементыМеню" Тогда
						ТекстТеста = ТекстТеста + "
						|	Подменю_Файл = " + КлассРус + "1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Файл""));
						|	Подменю_Справка  = " + КлассРус + "1.ЭлементыМеню.Добавить(Ф.ЭлементМеню(""Справка""));
						|	Индекс = 0;
						|	
						|";
						ТипВозвратаРус = "КлЭлементМеню";
					КонецЕсли;
					
					М08 = Новый Массив;
					Если СтрМетодаСоВсемиПараметрами = СтрМетодаСОбязательнымиПараметрами Тогда
						М08.Добавить(СтрМетодаСоВсемиПараметрами);
						ТекстТеста = ТекстТеста + "
						|	Сообщить(""" + СтрМетодаСоВсемиПараметрами + ";;"");
						|";
					Иначе
						М08.Добавить(СтрМетодаСоВсемиПараметрами);
						М08.Добавить(СтрМетодаСОбязательнымиПараметрами);
						ТекстТеста = ТекстТеста + "
						|	Сообщить(""" + СтрМетодаСоВсемиПараметрами + ";;"");
						|	Сообщить(""" + СтрМетодаСОбязательнымиПараметрами + ";;"");
						|";
					КонецЕсли;
					
					Для А8 = 0 По М08.ВГраница() Цикл
						ТекстТеста = ТекстТеста + "
						|	Если """" + " + М08[А8] + " = """ + ТипВозвратаРус + """ Тогда
						|	Иначе
						|		НекорректныеМетоды.Добавить(""" + М08[А8] + """);
						|	КонецЕсли;";
					КонецЦикла;
					
					ТекстТеста = ТекстТеста + "
					|Исключение НекорректныеМетоды.Добавить(""" + МетодРусАнгл + """); КонецПопытки;
					|";
				КонецЕсли;
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
	
	Возврат МассивМетодов;
КонецФункции

Функция ПеречисленияТест();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(КаталогСправки + "\OneScriptFormsru\OneScriptForms.html");
	Стр12 = ТекстДок.ПолучитьТекст();
	Массив7 = СтрНайтиМежду(Стр12, "<H3 class=dtH3>Перечисления</H3>", "</TBODY></TABLE>", Ложь, );
	Массив8 = СтрНайтиМежду(Массив7[0], "Описание</TH></TR>", "</TBODY></TABLE>", Ложь, );
	Массив9 = СтрНайтиМежду(Массив8[0], "<TR vAlign=top>", "</TD></TR>", Ложь, );
	Для А1 = 0 По Массив9.ВГраница() Цикл
		Массив10 = СтрНайтиМежду(Массив9[А1], ".html"">", "</A></TD>", Ложь, );
		Для А = 0 По Массив10.ВГраница() Цикл
			ТекстТеста = 
			"ПодключитьВнешнююКомпоненту(""" + КаталогБиблиотеки + "\OneScriptForms.dll"");
			|Ф = Новый ФормыДляОдноСкрипта();
			|Форма1 = Ф.Форма();
			|Форма1.Отображать = Истина;
			|Форма1.Показать();
			|";
			
			СтрХ = Массив10[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			ПеречислениеАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			ПеречислениеРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			//находим перечисления из файла OneScriptForms....(Перечисление)......html
			ИмяФайлаПеречисления = КаталогСправки + "\OneScriptFormsru\OneScriptForms." + ПеречислениеАнгл + ".html";
			ПеречислениеТест(ИмяФайлаПеречисления, ПеречислениеРус, ПеречислениеАнгл);
			
			ТекстТеста = ТекстТеста + "
			|Форма1.Текст = ""Тест " + ПеречислениеРус + "(" + ПеречислениеАнгл + ")"";
			|Ф.ЗапуститьОбработкуСобытий();
			|";
		КонецЦикла;
	КонецЦикла;
КонецФункции

Функция ПеречислениеТест(ИмяФайлаПеречисления, ПеречислениеРус, ПеречислениеАнгл)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ИмяФайлаПеречисления);
	Стр10 = ТекстДок.ПолучитьТекст();
	СтрТаблица = СтрНайтиМежду(Стр10, "<TD><B>", "</B></TD>", Ложь, );
	Для А = 0 По СтрТаблица.ВГраница() Цикл
		СтрХ = СтрТаблица[А];
		СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
		ЗначениеПеречисленияАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
		ЗначениеПеречисленияРус = СтрНайтиМежду(СтрХ, "<TD><B>", " (", , )[0];
		СтрКода1 = "Ф." + ПеречислениеРус + "." + ЗначениеПеречисленияРус;
		ТекстТеста = ТекстТеста + "
		|Сообщить(""" + СтрКода1 + " = "" + " + СтрКода1 + ");
		|";
	КонецЦикла;
КонецФункции

Функция ИспользованиеСвойства(ФайлСвойства)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ФайлСвойства);
	Стр = ТекстДок.ПолучитьТекст();
	Стр = СтрНайтиМежду(Стр, "<H4 class=dtH4>Использование</H4>", "<H4 class=dtH4>Значение</H4>", Ложь, );
	Стр = СтрНайтиМежду(Стр[0], "<P>", "</P>", , );
	Стр = Стр[0];
	ИспользованиеСвойства = СтрЗаменить(Стр, """", """""");
	Возврат ИспользованиеСвойства;
КонецФункции

Функция ТипСвойства(ФайлСвойства)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ФайлСвойства);
	Стр = ТекстДок.ПолучитьТекст();
	Стр = СтрНайтиМежду(Стр, "<H4 class=dtH4>Значение</H4>", "<H4 class=dtH4>Примечание</H4>", Ложь, );
	Стр = СтрНайтиМежду(Стр[0], "<P>", "</P>", , );
	М = СтрНайтиМежду(Стр[0], ">", "<", , );
	Если М.Количество() > 0 Тогда
		Стр = М[0];
		Стр = "Тип: " + СтрЗаменить(Стр, "&nbsp;", " ");
	Иначе
		Стр = Стр[0];
	КонецЕсли;
	ТипСвойства = СтрЗаменить(Стр, """", """""");
	Возврат ТипСвойства;
КонецФункции

Функция ВозвращаемоеЗначение(ФайлМетода)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ФайлМетода);
	Стр = ТекстДок.ПолучитьТекст();
	Стр = СтрНайтиМежду(Стр, "<H4 class=dtH4>Возвращаемое значение</H4>", "<H4 class=dtH4>Описание</H4>", Ложь, );
	Стр = СтрНайтиМежду(Стр[0], "<P>", "</P>", , );
	Стр = Стр[0];
	ВозвращаемоеЗначение = Стр;
	Возврат ВозвращаемоеЗначение;
КонецФункции

Функция Параметры(ФайлМетода)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ФайлМетода);
	Стр = ТекстДок.ПолучитьТекст();
	Стр = СтрНайтиМежду(Стр, "<H4 class=dtH4>Параметры</H4>", "<H4 class=dtH4>Возвращаемое значение</H4>", Ложь, );
	Стр = СтрНайтиМежду(Стр[0], "<DL>", "</DL>", , );
	Стр = Стр[0];
	Параметры = Стр;
	Возврат Параметры;
КонецФункции

Функция МассивМетодов(ИмяФайлаЧленов)
	М = Новый Массив;
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ИмяФайлаЧленов);
	Стр10 = ТекстДок.ПолучитьТекст();
	СтрТаблица = СтрНайтиМежду(Стр10, "<H4 class=dtH4>Методы</H4>", "</TBODY></TABLE>", Ложь, );
	Если СтрТаблица.Количество() > 0 Тогда
		Массив6 = СтрНайтиМежду(СтрТаблица[0], "pubmethod.gif", "</TD>", Ложь, );
		Для А = 0 По Массив6.ВГраница() Цикл
			Если Не (СтрНайти(Массив6[А], "унаследовано") > 0) Тогда
				Продолжить;
			КонецЕсли;
			
			ФайлМетода = СтрНайтиМежду(Массив6[А], "<A href=""OneScriptForms.", ".html"">", , );
			ФайлМетода = КаталогСправки + "\OneScriptFormsru\OneScriptForms." + ФайлМетода[0] + ".html";
			
			СтрХ = Массив6[А];
			СтрХ = СтрЗаменить(СтрХ, "&nbsp;", " ");
			МетодАнгл = СтрНайтиМежду(СтрХ, "(", ")", , )[0];
			МетодРус = СтрНайтиМежду(СтрХ, ".html"">", " (", , )[0];
			
			М1 = Новый Массив;
			М1.Добавить(ФайлМетода);
			М1.Добавить(МетодАнгл);
			М1.Добавить(МетодРус);
			М1.Добавить(МетодРус + " (" + МетодАнгл + ")");
			М.Добавить(М1);
		КонецЦикла;
	КонецЕсли;
	Возврат М;
КонецФункции

Функция ИмяПеречисления(ФайлСвойства)
	ИмяПеречисления = "";
	Стр = "";
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ФайлСвойства);
	Стр = ТекстДок.ПолучитьТекст();
	Стр = СтрНайтиМежду(Стр, "<H4 class=dtH4>Значение</H4>", "<H4 class=dtH4>Примечание</H4>", Ложь, );
	Стр = СтрНайтиМежду(Стр[0], "OneScriptForms.", ".html", , );
	Если Стр.Количество() > 0 Тогда
		//открываем файл типа свойства и смотрим в заголовке слово Перечисление
		ТекстДок2 = Новый ТекстовыйДокумент;
		ТекстДок2.Прочитать(КаталогСправки + "\OneScriptFormsru\OneScriptForms." + Стр[0] + ".html");
		Стр2 = ТекстДок2.ПолучитьТекст();
		СтрЗаголовка = СтрНайтиМежду(Стр2, "<H1 class=dtH1>", "</H1>", , )[0];
		Если СтрНайти(СтрЗаголовка, "Перечисление") > 0 Тогда
			// <H1 class=dtH1>СостояниеОкнаФормы (FormWindowState) Перечисление</H1></DIV></DIV>
			ИмяПеречисления = СтрЗаменить(СтрЗаголовка, "&nbsp;", " ");
			ИмяПеречисления = СтрЗаменить(СтрЗаголовка, "Перечисление", "");
			ИмяПеречисления = СокрЛП(ИмяПеречисления);
		КонецЕсли;
	КонецЕсли;
	Возврат ИмяПеречисления;
КонецФункции

Таймер = ТекущаяУниверсальнаяДатаВМиллисекундах();

М_Свойств = Новый Массив();
М_Свойств.Добавить("ПриАктивизации");
М_Свойств.Добавить("ПослеРедактированияНадписи");
М_Свойств.Добавить("ПослеВыбора");
М_Свойств.Добавить("ПередРазвертыванием");
М_Свойств.Добавить("ПередРедактированиемНадписи");
М_Свойств.Добавить("ПриНажатииКнопки");
М_Свойств.Добавить("ПриИзменении");
М_Свойств.Добавить("ПометкаИзменена");
М_Свойств.Добавить("Нажатие");
М_Свойств.Добавить("КолонкаНажатие");
М_Свойств.Добавить("ЭлементДобавлен");
М_Свойств.Добавить("ЭлементУдален");
М_Свойств.Добавить("ПриСоздании");
М_Свойств.Добавить("ТекущаяЯчейкаИзменена");
М_Свойств.Добавить("ПриДеактивации");
М_Свойств.Добавить("ПриУдалении");
М_Свойств.Добавить("ДвойноеНажатие");
М_Свойств.Добавить("ПриВыпадении");
М_Свойств.Добавить("ПриВходе");
М_Свойств.Добавить("ПриАктивизацииЭлемента");
М_Свойств.Добавить("ЭлементПомечен");
М_Свойств.Добавить("КлавишаВниз");
М_Свойств.Добавить("КлавишаНажата");
М_Свойств.Добавить("КлавишаВверх");
М_Свойств.Добавить("ПриУходе");
М_Свойств.Добавить("СсылкаНажата");
М_Свойств.Добавить("ПриЗагрузке");
М_Свойств.Добавить("ПоложениеИзменено");
М_Свойств.Добавить("ПриПотереФокуса");
М_Свойств.Добавить("ДатаИзменена");
М_Свойств.Добавить("ДатаВыбрана");
М_Свойств.Добавить("ИндексВыбранногоИзменен");
М_Свойств.Добавить("ПриНажатииКнопкиМыши");
М_Свойств.Добавить("МышьНадЭлементом");
М_Свойств.Добавить("ПриЗадержкеМыши");
М_Свойств.Добавить("МышьПокинулаЭлемент");
М_Свойств.Добавить("ПриПеремещенииМыши");
М_Свойств.Добавить("ПриОтпусканииМыши");
М_Свойств.Добавить("ПриПеремещении");
М_Свойств.Добавить("ПриПерерисовке");
М_Свойств.Добавить("ЗначениеСвойстваИзменено");
М_Свойств.Добавить("ПриПереименовании");
М_Свойств.Добавить("ПриПрокручивании");
М_Свойств.Добавить("ВыбранныйЭлементСеткиИзменен");
М_Свойств.Добавить("ИндексВыбранногоИзменен");
М_Свойств.Добавить("ВыделениеИзменено");
М_Свойств.Добавить("РазмерИзменен");
М_Свойств.Добавить("ТекстИзменен");
М_Свойств.Добавить("ПриСрабатыванииТаймера");
М_Свойств.Добавить("ЗначениеИзменено");

КаталогСправки = "C:\444";// без слэша
КаталогБиблиотеки = "C:\444\111\OneScriptForms\OneScriptForms\bin\Debug";// без слэша
ИмяВременногоФайла = ПолучитьИмяВременногоФайла();
ТекстДокХХХ = Новый ТекстовыйДокумент;
ТекстДокХХХ.Записать(ИмяВременногоФайла);

// // // Сообщить("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\" + ИмяВременногоФайла);

ПодключитьВнешнююКомпоненту(КаталогБиблиотеки + "\OneScriptForms.dll");
Ф = Новый ФормыДляОдноСкрипта();
Форма1 = Ф.Форма();
Форма1.Текст = "Общий тест OneScriptForms.dll";
Форма1.Ширина = 1100;
Форма1.Высота = 600;
Форма1.Отображать = Истина;
Форма1.Показать();

ПолеВвода1 = Форма1.ЭлементыУправления.Добавить(Ф.ПолеВвода());
ПолеВвода1.МногострочныйРежим = Истина;
ПолеВвода1.Стыковка = Ф.СтильСтыковки.Заполнение;
ПолеВвода1.ЦветФона = Ф.Цвет().Черный;
ПолеВвода1.ОсновнойЦвет = Ф.Цвет().БледноЗеленый;
ПолеВвода1.ПолосыПрокрутки = Ф.ПолосыПрокрутки.Обе;
ПолеВвода1.ПринятиеВозврат = Истина;
ПолеВвода1.Перенос = Ложь;
ПолеВвода1.РегистрСимволов = Ф.РегистрСимволов.Стандартный;

СписокОшибок = Новый СписокЗначений;

ТестированиеКодов();
ТестированиеМетодов();
ФормаNotifyIcon.Закрыть();
ТестированиеСвойств();
ФормаNotifyIcon.Закрыть();

ПолеВвода1.ДобавитьТекст("==============================================================================================" + Символы.ПС);
ПолеВвода1.ДобавитьТекст("Тест выполнен за: " + ((ТекущаяУниверсальнаяДатаВМиллисекундах()-Таймер)/1000)/60 + " мин." + " " + ТекущаяДата() + Символы.ПС);
ПолеВвода1.ДобавитьТекст("Ошибок = " + СписокОшибок.Количество() + Символы.ПС);
Для А = 0 По СписокОшибок.Количество() - 1 Цикл
	ПолеВвода1.ДобавитьТекст("" + СписокОшибок.Получить(А).Значение + Символы.ПС);
КонецЦикла;

УдалитьФайлы(ИмяВременногоФайла);

Ф.ЗапуститьОбработкуСобытий();