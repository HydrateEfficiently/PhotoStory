define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		FileUploader = require("Util/FileUploader");

	function Chapter_New() {
		var self = this;
		this._isEnabled = true;

		this.Title = ko.observable();
		this.FileInputElement = ko.observable();
		this.Photos = ko.observableArray();

		this.FileUploader = new FileUploader(this.FileInputElement);
	}

	return Chapter_New;

});