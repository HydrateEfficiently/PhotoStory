define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		$ = require("jquery");

	function CollapsiblePanel(elementObservable, options) {
		options = options || {};
		this._isReady = false;
		this._whenReadyCallbacks = [];
		this._initCollapsiblePanel(elementObservable, options);
	}

	CollapsiblePanel.prototype._initCollapsiblePanel = function (elementObservable, options) {
		var self = this;
		elementObservable.subscribeOnce(function (panelElement) {
			var $panelElement = $(panelElement),
				$panelHeading = $panelElement.find(".panel-heading").first(),
				$panelHeadingButton = $panelHeading.find(".btn").first(),
				$panelBody = $panelElement.find(".panel-body").first();

			self._panelBody = $panelBody;

			$panelHeading.on("click", function (e) {
				self._toggleCollapsed();
			});
			$panelHeadingButton.on("click", function (e) {
				self._toggleCollapsed();
				return false;
			});
			self._triggerReady();
		});
	};

	CollapsiblePanel.prototype._triggerReady = function () {
		var callbacks = this._whenReadyCallbacks,
			length = callbacks.length,
			i;

		for (i = 0; i < length; i++) {
			callbacks[i]();
		}
		callbacks.length = 0;

		this._isReady = true;
	};

	CollapsiblePanel.prototype._whenReady = function (callback) {
		if (this._isReady) {
			callback();
		} else {
			this._whenReadyCallbacks.push(callback);
		}
	};

	CollapsiblePanel.prototype._isCollapsed = function () {
		return this._panelBody.hasClass("panel-collapsed");
	};

	CollapsiblePanel.prototype._toggleCollapsed = function () {
		this._setCollapsed(!this._isCollapsed());
	};

	CollapsiblePanel.prototype._setCollapsed = function (collapsed) {
		var self = this;
		this._whenReady(function () {
			if (collapsed) {
				self._panelBody.slideUp(function () {
					self._panelBody.addClass("panel-collapsed");
				});
			} else {
				self._panelBody.removeClass("panel-collapsed");
				self._panelBody.slideDown();
			}
		});
	};

	CollapsiblePanel.prototype.collapse = function () {
		this._setCollapsed(true);
	};

	CollapsiblePanel.prototype.expand = function () {
		this._setCollapsed(false);
	};

	return CollapsiblePanel;
});