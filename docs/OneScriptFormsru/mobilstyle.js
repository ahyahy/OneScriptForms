if (localStorage['keybt0hutbo'] == 'true') {
	document.body.setAttribute('style',
		'font-size: 35px !important;' +
		''
	);
	
	let elems = document.querySelectorAll("div#nsbanner");
	for (elem of elems) {
		elem.setAttribute('style',
			'height: 60px;' +
			''
		);
	}
}
else {
	document.body.setAttribute('style',
		'font-size: 16px !important' +
		''
	);
}

// ================================
function divrightClick(e) {
	if (e.target.nodeName == 'A') {
		localStorage["destination"] = '' + e.target;
	}
}

document.addEventListener('DOMContentLoaded', function (event) {
	localStorage["destination"] = '' + document.location;
});
// ================================
// Функция копирования примеров.
document.addEventListener('DOMContentLoaded', function () {
    // Используем делегирование: вешаем один клик на все окно документа
    document.body.addEventListener('click', function(event) {
        // Проверяем, что кликнули именно по кнопке с нужным классом
        if (event.target.classList.contains('copy-btn')) {
            event.preventDefault(); // Отменяем стандартное поведение button внутри details
            const button = event.target;
            // Читаем из data-атрибута, какой именно div нам нужен
            const targetId = button.getAttribute('data-target-id'); 
            // Находим нужный элемент с кодом
            const codeBlock = document.getElementById(targetId);
            if (!codeBlock) return;
            // Создаем временный невидимый textarea для браузера
            const textArea = document.createElement("textarea");
            // Получаем текст
            textArea.value = codeBlock.innerText;
            // Стилизуем его, чтобы он был вне экрана
            textArea.style.position = "fixed"; 
            textArea.style.top = "-9999px";
            document.body.appendChild(textArea);
            textArea.focus();
            textArea.select();
            let successful = false;
            try {
                // Современный API
                successful = navigator.clipboard.writeText(textArea.value);
            } catch (err) {
                // Fallback для старых браузеров
                successful = document.execCommand('copy');
            }
            document.body.removeChild(textArea);
            // Опционально: визуальная обратная связь
            const originalText = button.textContent;
            if (successful) {
                button.textContent = 'Скопировано!';
                setTimeout(() => button.textContent = originalText, 1500); // Вернуть текст через 1.5 сек
            } else {
                alert('Не удалось скопировать текст.');
            }
        }
    });
});
// ================================
