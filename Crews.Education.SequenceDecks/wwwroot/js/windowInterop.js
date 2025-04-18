window.fullscreenFunctions = {
	enterFullscreen: function (elementId) {
		var element = elementId
			? document.getElementById(elementId)
			: document.documentElement;

		if (element.requestFullscreen) {
			element.requestFullscreen();
		} else if (element.mozRequestFullScreen) {
			/* Firefox */
			element.mozRequestFullScreen();
		} else if (element.webkitRequestFullscreen) {
			/* Chrome, Safari & Opera */
			element.webkitRequestFullscreen();
		} else if (element.msRequestFullscreen) {
			/* IE/Edge */
			element.msRequestFullscreen();
		}
	},

	exitFullscreen: function () {
		if (document.exitFullscreen) {
			document.exitFullscreen();
		} else if (document.mozCancelFullScreen) {
			/* Firefox */
			document.mozCancelFullScreen();
		} else if (document.webkitExitFullscreen) {
			/* Chrome, Safari & Opera */
			document.webkitExitFullscreen();
		} else if (document.msExitFullscreen) {
			/* IE/Edge */
			document.msExitFullscreen();
		}
	},

	isFullscreen: function () {
		return (
			document.fullscreenElement ||
			document.mozFullScreenElement ||
			document.webkitFullscreenElement ||
			document.msFullscreenElement
		);
	},
};
