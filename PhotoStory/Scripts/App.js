define(function () {

	var	isReady = false,
		isReadyCallbacks = [];

	function start(isDebug) {
		requirejs.config({
			baseUrl: "/Scripts",
			paths: {
				"knockout": isDebug ? "knockout-3.3.0.debug" : "knockout-3.3.0",
				"knockoutmapping": isDebug ? "knockout.mapping-latest.debug" : "knockout.mapping-latest.debug"
			},
			shim: {
				knockoutmapping: {
					deps: ["knockout"],
					exports: "komapping"
				}
			}
		});
		triggerIsReadyCallbacks();
	}

	function whenReady(callback) {
		if (isReady) {
			callback();
		} else {
			isReadyCallbacks.push(callback);
		}
	}

	function triggerIsReadyCallbacks() {
		var length = isReadyCallbacks.length;
		for (var i = 0; i < length; i++) {
			isReadyCallbacks[i]();
		}
		isReady = true;
	}

	return {
		start: start,
		whenReady: whenReady
	};
});