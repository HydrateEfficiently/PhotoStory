define(function () {

	var	isReady = false,
		isReadyCallbacks = [];

	function start(isDebug) {
		requirejs.config({
			baseUrl: "/Scripts",
			paths: {
				"jquery": isDebug ? "jquery-2.1.4" : "jquery-2.1.4.min",
				"knockout": isDebug ? "knockout-3.3.0.debug" : "knockout-3.3.0",
				"knockoutmapping": isDebug ? "knockout.mapping-latest.debug" : "knockout.mapping-latest.debug",
				"bootstrap": isDebug ? "bootstrap" : "bootstrap.min",
				"fileinput": isDebug ? "fileinput" : "fileinput.min"
			},
			shim: {
				knockoutmapping: {
					deps: ["knockout"],
					exports: "komapping"
				},
				fileinput: ["bootstrap"]
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

	function initialiseView(viewModelConstructor, data) {
		whenReady(function () {
			require(["Packages/KnockoutPackage"], function (KnockoutPackage) {
				KnockoutPackage.ko.applyBindings(new viewModelConstructor(data));
			});
		});
	}

	return {
		start: start,
		whenReady: whenReady,
		initialiseView: initialiseView
	};
});