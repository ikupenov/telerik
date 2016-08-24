var navName = navigator.appName,
	addScroll = false,
	pointerX = 0,
	pointerY = 0,
	layer;

document.onmousemove = mouseMove;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
	addScroll = true;
}

if (navName === "Netscape") {
	document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(ev) {
	if (navName === "Netscape") {
		pointerX = ev.pageX - 5;
		pointerY = ev.pageY;
	} else {
		pointerX = ev.x - 5;
		pointerY = ev.y;
	}

	if (navName === "Netscape") {
		if (document.layers.ToolTip.visibility === 'show') {
			PopTip();
		}
	} else {
		if (document.all.ToolTip.style.visibility === 'visible') {
			PopTip();
		}
	}
}

function PopTip() {
	if (navName === "Netscape") {
		layer = document.layers.ToolTip;

		if ((pointerX + 120) > window.innerWidth) {
			pointerX = window.innerWidth - 150;
		}

		layer.left = pointerX + 10;
		layer.top = pointerY + 15;

		layer.visibility = 'show';
	} else {
		layer = document.all.ToolTip;

		if (layer) {
			pointerX = event.x - 5;
			pointerY = event.y;

			if (addScroll) {
				pointerX = pointerX + document.body.scrollLeft;
				pointerY = pointerY + document.body.scrollTop;
			}

			if ((pointerX + 120) > document.body.clientWidth) {
				pointerX = pointerX - 150;
			}

			layer.style.pixelLeft = pointerX + 10;
			layer.style.pixelTop = pointerY + 15;

			layer.style.visibility = 'visible';
		}
	}
}

function HideTip() {
	if (navName === "Netscape") {
		document.layers.ToolTip.visibility = 'hide';
	} else {
		document.all.ToolTip.style.visibility = 'hidden';
	}
}

function HideMenu1() {
	if (navName === "Netscape") {
		document.layers.menu1.visibility = 'hide';
	} else {
		document.all.menu1.style.visibility = 'hidden';
	}
}

function ShowMenu1() {
	if (navName === "Netscape") {
		layer = document.layers.menu1;
		layer.visibility = 'show';
	} else {
		layer = document.all.menu1;
		layer.style.visibility = 'visible';
	}
}

function HideMenu2() {
	if (navName === "Netscape") {
		document.layers.menu2.visibility = 'hide';
	} else {
		document.all.menu2.style.visibility = 'hidden';
	}
}

function ShowMenu2() {
	if (navName === "Netscape") {
		layer = document.layers.menu2;
		layer.visibility = 'show';
	} else {
		layer = document.all.menu2;
		layer.style.visibility = 'visible';
	}
}