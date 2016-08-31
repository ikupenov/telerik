const CONSTANTS = {
	NETSCAPE: 'Netscape',
	TOOLTIP: 'ToolTip',

	VISIBILITY: {
		VISIBLE: 'visible',
		HIDDEN: 'hidden'
	},

	DISPLAY: {
		SHOW: 'show',
		HIDE: 'hide'
	}
};

let currentBrowserName = navigator.appName,
	addScroll = false,
	positionX = 0,
	positionY = 0,
	layer;

document.onmousemove = mouseMove;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
	(navigator.userAgent.indexOf('MSIE 6')) > 0) {
	addScroll = true;
}

if (currentBrowserName === CONSTANTS.NETSCAPE) {
	document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(ev) {
	let offSetX = 5;

	if (currentBrowserName === CONSTANTS.NETSCAPE) {
		positionX = ev.pageX - offSetX;
		positionY = ev.pageY;
	} else {
		positionX = ev.x - offSetX;
		positionY = ev.y;
	}

	if (currentBrowserName === CONSTANTS.NETSCAPE) {
		if (document.layers.ToolTip.visibility === CONSTANTS.DISPLAY.SHOW) {
			showToolTip();
		}
	} else {
		if (document.all.ToolTip.style.visibility === CONSTANTS.VISIBILITY.VISIBLE) {
			showToolTip();
		}
	}
}

function showToolTip() {

	// I would put the "magic numbers" in variables if I had idea what they actually mean

	if (currentBrowserName === CONSTANTS.NETSCAPE) {
		layer = document.layers.ToolTip;

		if ((positionX + 120) > window.innerWidth) {
			positionX = window.innerWidth - 150;
		}

		layer.left = positionX + 10;
		layer.top = positionY + 15;

		layer.visibility = CONSTANTS.SHOW;
	} else {
		layer = document.all.ToolTip;

		if (layer) {
			positionX = event.x - 5;
			positionY = event.y;

			if (addScroll) {
				positionX = positionX + document.body.scrollLeft;
				positionY = positionY + document.body.scrollTop;
			}

			if ((positionX + 120) > document.body.clientWidth) {
				positionX = positionX - 150;
			}

			layer.style.pixelLeft = positionX + 10;
			layer.style.pixelTop = positionY + 15;

			layer.style.visibility = CONSTANTS.VISIBLE;
		}
	}
}

function hideToolTip() {
	setVisibilityBasedOnBrowser(CONSTANTS.NETSCAPE, CONSTANTS.TOOLTIP, false);
}

function hideMenu(menu) {
	setVisibilityBasedOnBrowser(CONSTANTS.NETSCAPE, menu, false);
}

function showMenu(menu) {
	setVisibilityBasedOnBrowser(CONSTANTS.NETSCAPE, menu, true);
}

function setVisibilityBasedOnBrowser(browserName, element, isVisible) {
	if (currentBrowserName === browserName) {
		setDisplayType(element, isVisible);
	} else {
		setVisibility(element, isVisible);
	}

	function setVisibility(element, isVisible) {
		layer = document.layers[element];

		layer.style.visibility = isVisible ?
			CONSTANTS.VISIBILITY.VISIBLE
			: CONSTANTS.VISIBILITY.HIDDEN;
	}

	function setDisplayType(element, isVisible) {
		layer = document.all[element];

		layer.visibility = isVisible ?
			CONSTANTS.DISPLAY.SHOW
			: CONSTANTS.DISPLAY.HIDE;
	}
}
