var mobilmode = false;
function label1click() {
	let el5 = document.getElementById('toggle');
	el5.checked = !el5.checked;

	let elems2 = document.querySelectorAll("nav");
	for (elem of elems2) {
		elem.setAttribute('style',
			'display: none;' +
			'position: absolute;' +
			'right: 0px;' +
			'top: 55px;' +
			'padding: 0px;' +
			'margin-right: 15px;' +
			'margin-top: -9px;' +
			'z-index: 1100;' +
			''
		);
	}
	
	// Увеличиваем размер шрифта
	elems2 = document.querySelectorAll("nav a");
	for (elem of elems2) {
		elem.setAttribute('style',
			'display: block;' +
			'float: none;' +
			'font-size: 35px;' +
			'padding: 0px 5px 0px 5px;' +
			'border: 2px solid rgba(200,200,200);' +
			'background-color: #ebebeb;' +
			'z-index: 1200;' +
			''
		);
	}

	let el6 = document.querySelectorAll("input[type=checkbox]#toggle")[0];
	if (el6.checked) {
		let elems3 = document.querySelectorAll("nav");
		for (elem of elems3) {
			elem.setAttribute('style',
				'display: inline-block;' +
				'position: absolute;' +
				'z-index: 1100;' +
				'background-color: #c8c8c8;' +
				'border-radius: 10px;' +
				''
			);
		}

		elems32 = document.querySelectorAll("#mobil");
		for (elem of elems32) {
			elem.setAttribute('style',
				'float: none;' +
				'background-color: #ebebeb;' +
				'color: #ebebeb;' +
				'background-image: url("icons8min.png");' +
				''
			);
		}
	}
}

function label2click() {
	let el7 = document.getElementById('toggle1');
	el7.checked = !el7.checked;

	let elems8 = document.querySelectorAll("div.divmodal");
	for (elem of elems8) {
		elem.setAttribute('style',
			'display: none;' +
			'position: fixed;' +
			'padding-top: 100px;' +
			'left: 0px;' +
			'top: 0px;' +
			'width: 100%;' +
			'height: 100%;' +
			'overflow: auto;' +
			'background-color: rgba(0, 0, 0, 0.4);' +
			''
		);
	}

	if (el7.checked) {
		let elems9 = document.querySelectorAll("div.divmodal");
		for (elem of elems9) {
			elem.setAttribute('style',
				'display: block;' +
				''
			);
		}

		let elems40 = document.querySelectorAll("div.divleft");
		for (elem of elems40) {
			elem.setAttribute('style',
				'display: block;' +
				'position: absolute;' +
				'top: 118px;' +
				'background-color: #ebebeb;' +
				'padding: 0px;' +
				'margin-right: 15px;' +
				'z-index: 1100;' +
				'border: 1px solid #000000;' +
				'height: 82%;' +
				'width: 60%;' +
				'overflow-y: scroll;' +
				''
			);
		}
	}
	else {
		let elems11 = document.querySelectorAll("div.divmodal");
		for (elem of elems11) {
			elem.setAttribute('style',
				'display: none;' +
				''
			);
		}

		let elems41 = document.querySelectorAll("div.divleft");
		for (elem of elems41) {
			elem.setAttribute('style',
				'display: none;' +
				''
			);
		}
	}
}

function mobilClick() {
	let el = document.getElementById('toggle2');
	el.checked = !el.checked;
	let elmobil = document.getElementById('mobil');
	if (el.checked) {
		mobilmode = true;
		localStorage['keybt0hutbo'] = '' + mobilmode;

		// Начало увеличиваем шрифт
		document.body.setAttribute('style',
			'font-size: 35px !important;' +
			''
		);
		// Конец увеличиваем шрифт

		let elems38 = document.querySelectorAll('#div2');
		for (elem of elems38) {
			elem.setAttribute('style',
				'display: inline-block;' +
				''
			);
		}

		let elems33 = document.querySelectorAll("#div22");
		for (elem of elems33) {
			elem.setAttribute('style',
				'display: inline-block;' +
				'padding: 10px 5px 10px 20px;' +
				'margin-top: -7px;' +
				''
			);
		}

		elmobil.style.backgroundImage = "url('icons8min.png')";

		let elems = document.querySelectorAll("div.divleft");
		for (elem of elems) {
			elem.setAttribute('style',
				'display:none;' +
				''
			);
		}

		elems = document.querySelectorAll("div#nsbanner");
		for (elem of elems) {
			elem.setAttribute('style',
				'display: inline-block;' +
				''
			);
		}

		elems = document.querySelectorAll("div.frameright");
		for (elem of elems) {
			elem.setAttribute('style',
				'display: inline-block;' +
				'margin-left: 0px;' +
				'margin-right: 2px;' +
				'width: 100%;' +
				'border: 1px solid black;' +
				'border-right: 2px solid black;' +
				'padding: 0px 4px 0px 0px;' +
				''
			);
		}

		elems = document.querySelectorAll("div.cont1");
		for (elem of elems) {
			elem.setAttribute('style',
				'display: block;' +
				'height: 86%;' +
				'width: 97%;' +
				'max-width: 1100px;' +
				'margin: 0px auto;' +
				''
			);
		}

		elems = document.querySelectorAll(".hamburger-icon");
		for (elem of elems) {
			elem.setAttribute('style',
				'margin-right: 15px;' +
				''
			);
		}

		elems = document.querySelectorAll(".hamburger-icon div");
		for (elem of elems) {
			elem.setAttribute('style',
				'width: 40px;' +
				'height: 5px;' +
				'margin: 4px 0px;' +
				'background-color: black;' +
				''
			);
		}

		elems = document.querySelectorAll("label#label1");
		for (elem of elems) {
			elem.setAttribute('style',
				'float: right;' +
				'padding: 8px 0px;' +
				'display: inline-block;' +
				'cursor: pointer;' +
				''
			);
		}
		label1click();
	}
	else {
		mobilmode = false;
		localStorage["keybt0hutbo"] = '' + mobilmode;

		// Начало уменьшаем шрифт
		document.body.setAttribute('style',
			'font-size: 16px !important;' +
			''
		);
		// Конец уменьшаем шрифт

		elmobil.style.backgroundImage = "url('icons8max.png')";

		let elems34 = document.querySelectorAll("#div22");
		for (elem of elems34) {
			elem.setAttribute('style',
				'display: none;' +
				''
			);
		}

		let elems35 = document.querySelectorAll("nav");
		for (elem of elems35) {
			elem.setAttribute('style',
				'display: flex;' +
				'font-size: 16px' +
				''
			);
		}
		
		// Уменьшаем размер шрифта
		let elems36 = document.querySelectorAll("nav a");
		for (elem of elems36) {
			elem.setAttribute('style',
				'font-size: 16px;' +
				''
			);
		}

		let el37 = document.getElementById('toggle');
		el37.checked = !el37.checked;

		let elems37 = document.querySelectorAll("#div2");
		for (elem of elems37) {
			elem.setAttribute('style',
				'display: none;' +
				''
			);
		}

		let elems40 = document.querySelectorAll("div.cont1");
		for (elem of elems40) {
			elem.setAttribute('style',
				'display: flex;' +
				''
			);
		}

		let elems39 = document.querySelectorAll("div.divleft");
		for (elem of elems39) {
			elem.setAttribute('style',
				'display: inline-block;' +
				''
			);
		}

		let elems47 = document.querySelectorAll("div#nsbanner");
		for (elem of elems47) {
			elem.setAttribute('style',
				'display: none;' +
				''
			);
		}
		
		let iframe = document.getElementById('iframeid');
		iframe.src = iframe.src;
	}
}

function disableScroll() {
	let el = document.getElementById('toggle1');
	el.checked = !el.checked;
	if (!el.checked) {
		let el = document.getElementById('divleftid');
		let el2 = document.getElementById('div2');
		el.style.top = '' + el2.getClientRects()[0].bottom + 'px';
		document.body.style.overflow = 'hidden';
	}
	else {
		document.body.style.overflow = 'visible';
	}
}

function navclick(e) {
	let el57 = document.getElementById('toggle');
	if (e.target.nodeName == 'A') {
		localStorage["keybt0hutbo"] = '' + mobilmode;
	}
}

function divleftClick(e) {
	let el = document.getElementById('toggle1');
	if (el.checked) {
		if (e.target.nodeName == 'A') {
			localStorage["keybt0hutbo"] = '' + mobilmode;

			let el3 = document.getElementById('titlepage');
			el3.innerText = e.target.innerText;
			el.checked = !el.checked;

			let elems11 = document.querySelectorAll("div.divmodal");
			for (elem of elems11) {
				elem.setAttribute('style',
					'display: none;' +
					''
				);
			}

			let elems41 = document.querySelectorAll("div.divleft");
			for (elem of elems41) {
				elem.setAttribute('style',
					'display: none;' +
					''
				);
			}
		}
	}
}

function expand() {
	document.querySelectorAll('details').forEach(detail => {
		detail.open = true;
	});
}

function collapse() {
	document.querySelectorAll('details').forEach(detail => {
		detail.open = false;
	});
}

if (localStorage["keybt0hutbo"] == 'true') {
	mobilClick();
	let el77 = document.getElementById('toggle2');
	el77.checked = !el77.checked;
	mobilClick();
}

function clickimg(e) {
	var img01 = e.target;
	let tail = img01.id.replace("myImg", "");
	var modal01 = document.getElementById('myModal' + tail);
	var modalImg01 = document.getElementById('img' + tail);

	modal01.style.display = "block";
	modalImg01.src = img01.src;

	var span01 = document.getElementById('close' + tail);
	span01.onclick = function () {
		modal01.style.display = "none";
	}
}
