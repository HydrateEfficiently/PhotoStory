define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		$ = require("jquery");

	function Chapter_New() {
		var self = this;
		this._isEnabled = true;

		this.Title = ko.observable();
		this.FileInput = ko.observable();
		this.Photos = ko.observableArray();
	}

	Chapter_New.prototype.toggleEnabled = function () {
		if (this._isEnabled) {
			this.FileInput().fileinput("disable");
		} else {
			this.FileInput().fileinput("enable");
		}
		this._isEnabled = !this._isEnabled;
	};

	return Chapter_New;

});